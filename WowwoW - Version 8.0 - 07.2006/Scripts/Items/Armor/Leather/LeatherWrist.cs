/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:31 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Ice-covered Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IceCoveredBracers : Item
	{
		public IceCoveredBracers() : base()
		{
			Id = 763;
			Resistance[0] = 26;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 17007;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Ice-covered Bracers";
			Name2 = "Ice-covered Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 293;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Madwolf Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MadwolfBracers : Item
	{
		public MadwolfBracers() : base()
		{
			Id = 897;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1022;
			AvailableClasses = 0x7FFF;
			Model = 17011;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Madwolf Bracers";
			Name2 = "Madwolf Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5112;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 2;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Gnoll Kindred Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GnollKindredBracers : Item
	{
		public GnollKindredBracers() : base()
		{
			Id = 1213;
			Resistance[0] = 28;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 3613;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Gnoll Kindred Bracers";
			Name2 = "Gnoll Kindred Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 437;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wolfmane Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class WolfmaneWristguards : Item
	{
		public WolfmaneWristguards() : base()
		{
			Id = 1306;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 352;
			AvailableClasses = 0x7FFF;
			Model = 11387;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Wolfmane Wristguards";
			Name2 = "Wolfmane Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1761;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherBracers : Item
	{
		public RaggedLeatherBracers() : base()
		{
			Id = 1370;
			Resistance[0] = 12;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 14336;
			ObjectClass = 4;
			SubClass = 2;
			Level = 4;
			ReqLevel = 1;
			Name = "Ragged Leather Bracers";
			Name2 = "Ragged Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 14;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherBracers : Item
	{
		public WornLeatherBracers() : base()
		{
			Id = 1420;
			Resistance[0] = 20;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 4471;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Worn Leather Bracers";
			Name2 = "Worn Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 92;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherBracers : Item
	{
		public WarpedLeatherBracers() : base()
		{
			Id = 1504;
			Resistance[0] = 23;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 17024;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Warped Leather Bracers";
			Name2 = "Warped Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 162;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherBracers : Item
	{
		public PatchedLeatherBracers() : base()
		{
			Id = 1789;
			Resistance[0] = 31;
			SellPrice = 136;
			AvailableClasses = 0x7FFF;
			Model = 3653;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Patched Leather Bracers";
			Name2 = "Patched Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 680;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Rawhide Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideBracers : Item
	{
		public RawhideBracers() : base()
		{
			Id = 1797;
			Resistance[0] = 31;
			SellPrice = 161;
			AvailableClasses = 0x7FFF;
			Model = 17015;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Rawhide Bracers";
			Name2 = "Rawhide Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 807;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherBracers : Item
	{
		public ToughLeatherBracers() : base()
		{
			Id = 1805;
			Resistance[0] = 35;
			SellPrice = 351;
			AvailableClasses = 0x7FFF;
			Model = 17022;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Tough Leather Bracers";
			Name2 = "Tough Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 1759;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dirty Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherBracers : Item
	{
		public DirtyLeatherBracers() : base()
		{
			Id = 1836;
			Resistance[0] = 15;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14249;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Bracers";
			Name2 = "Dirty Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherBracers : Item
	{
		public RoughLeatherBracers() : base()
		{
			Id = 1840;
			Resistance[0] = 23;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 17170;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Bracers";
			Name2 = "Rough Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherBracers : Item
	{
		public TannedLeatherBracers() : base()
		{
			Id = 1844;
			Resistance[0] = 30;
			SellPrice = 145;
			AvailableClasses = 0x7FFF;
			Model = 14471;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Bracers";
			Name2 = "Tanned Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 728;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cured Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherBracers : Item
	{
		public CuredLeatherBracers() : base()
		{
			Id = 1850;
			Resistance[0] = 34;
			SellPrice = 278;
			AvailableClasses = 0x7FFF;
			Model = 14282;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Bracers";
			Name2 = "Cured Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1393;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Glowing Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingLeatherBracers : Item
	{
		public GlowingLeatherBracers() : base()
		{
			Id = 2017;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 895;
			AvailableClasses = 0x7FFF;
			Model = 6738;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Glowing Leather Bracers";
			Name2 = "Glowing Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4477;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherBracers : Item
	{
		public CrackedLeatherBracers() : base()
		{
			Id = 2124;
			Resistance[0] = 15;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14427;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Bracers";
			Name2 = "Cracked Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliBracers : Item
	{
		public CuirboulliBracers() : base()
		{
			Id = 2144;
			Resistance[0] = 37;
			SellPrice = 527;
			AvailableClasses = 0x7FFF;
			Model = 3602;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Bracers";
			Name2 = "Cuirboulli Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2639;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sturdy Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyLeatherBracers : Item
	{
		public SturdyLeatherBracers() : base()
		{
			Id = 2327;
			Resistance[0] = 23;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 17172;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Sturdy Leather Bracers";
			Name2 = "Sturdy Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 182;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherBracers : Item
	{
		public BatteredLeatherBracers() : base()
		{
			Id = 2374;
			Resistance[0] = 23;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 17002;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Bracers";
			Name2 = "Battered Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 173;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Studded Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedBracers : Item
	{
		public StuddedBracers() : base()
		{
			Id = 2468;
			Resistance[0] = 44;
			SellPrice = 1262;
			AvailableClasses = 0x7FFF;
			Model = 17020;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Bracers";
			Name2 = "Studded Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6310;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherBracers : Item
	{
		public ReinforcedLeatherBracers() : base()
		{
			Id = 2474;
			Resistance[0] = 55;
			SellPrice = 3446;
			AvailableClasses = 0x7FFF;
			Model = 14493;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Bracers";
			Name2 = "Reinforced Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17233;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Burnt Hide Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BurntHideBracers : Item
	{
		public BurntHideBracers() : base()
		{
			Id = 3158;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 10412;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			Name = "Burnt Hide Bracers";
			Name2 = "Burnt Hide Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 303;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherBracers : Item
	{
		public BurntLeatherBracers() : base()
		{
			Id = 3200;
			Resistance[0] = 20;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 17004;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Burnt Leather Bracers";
			Name2 = "Burnt Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Forest Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherBracers : Item
	{
		public ForestLeatherBracers() : base()
		{
			Id = 3202;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 584;
			AvailableClasses = 0x7FFF;
			Model = 10216;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Forest Leather Bracers";
			Name2 = "Forest Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2921;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Deepwood Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DeepwoodBracers : Item
	{
		public DeepwoodBracers() : base()
		{
			Id = 3204;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 751;
			AvailableClasses = 0x7FFF;
			Model = 3606;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Deepwood Bracers";
			Name2 = "Deepwood Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3758;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherBracers : Item
	{
		public InscribedLeatherBracers() : base()
		{
			Id = 3205;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 229;
			AvailableClasses = 0x7FFF;
			Model = 14410;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Inscribed Leather Bracers";
			Name2 = "Inscribed Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1149;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hunting Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingBracers : Item
	{
		public HuntingBracers() : base()
		{
			Id = 3207;
			Resistance[0] = 28;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 14535;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Hunting Bracers";
			Name2 = "Hunting Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 438;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Black Wolf Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWolfBracers : Item
	{
		public BlackWolfBracers() : base()
		{
			Id = 3230;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 768;
			AvailableClasses = 0x7FFF;
			Model = 17166;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Black Wolf Bracers";
			Name2 = "Black Wolf Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3842;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Tribal Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TribalBracers : Item
	{
		public TribalBracers() : base()
		{
			Id = 3285;
			Resistance[0] = 23;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 27994;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Tribal Bracers";
			Name2 = "Tribal Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 182;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherBracers : Item
	{
		public CeremonialLeatherBracers() : base()
		{
			Id = 3312;
			Resistance[0] = 27;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 14545;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Ceremonial Leather Bracers";
			Name2 = "Ceremonial Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 353;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Zombie Skin Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ZombieSkinBracers : Item
	{
		public ZombieSkinBracers() : base()
		{
			Id = 3435;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 3708;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Zombie Skin Bracers";
			Name2 = "Zombie Skin Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 98;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Hardened Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherBracers : Item
	{
		public HardenedLeatherBracers() : base()
		{
			Id = 3802;
			Resistance[0] = 39;
			SellPrice = 627;
			AvailableClasses = 0x7FFF;
			Model = 14803;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Hardened Leather Bracers";
			Name2 = "Hardened Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 3136;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherBracers : Item
	{
		public ThickLeatherBracers() : base()
		{
			Id = 3963;
			Resistance[0] = 46;
			SellPrice = 1402;
			AvailableClasses = 0x7FFF;
			Model = 17021;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Thick Leather Bracers";
			Name2 = "Thick Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 7012;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherBracers : Item
	{
		public SmoothLeatherBracers() : base()
		{
			Id = 3971;
			Resistance[0] = 60;
			SellPrice = 3811;
			AvailableClasses = 0x7FFF;
			Model = 17171;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Smooth Leather Bracers";
			Name2 = "Smooth Leather Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 19057;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedBracers : Item
	{
		public EmblazonedBracers() : base()
		{
			Id = 4049;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 888;
			AvailableClasses = 0x7FFF;
			Model = 14601;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Emblazoned Bracers";
			Name2 = "Emblazoned Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4443;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Glyphed Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedBracers : Item
	{
		public GlyphedBracers() : base()
		{
			Id = 4059;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2233;
			AvailableClasses = 0x7FFF;
			Model = 14673;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Glyphed Bracers";
			Name2 = "Glyphed Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11169;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherBracers : Item
	{
		public ImperialLeatherBracers() : base()
		{
			Id = 4061;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 3306;
			AvailableClasses = 0x7FFF;
			Model = 17008;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Imperial Leather Bracers";
			Name2 = "Imperial Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16531;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Green Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLeatherBracers : Item
	{
		public GreenLeatherBracers() : base()
		{
			Id = 4259;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 1934;
			AvailableClasses = 0x7FFF;
			Model = 9546;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Green Leather Bracers";
			Name2 = "Green Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9672;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Guardian Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianLeatherBracers : Item
	{
		public GuardianLeatherBracers() : base()
		{
			Id = 4260;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 2559;
			AvailableClasses = 0x7FFF;
			Model = 9550;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Guardian Leather Bracers";
			Name2 = "Guardian Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12796;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Wolf Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WolfBracers : Item
	{
		public WolfBracers() : base()
		{
			Id = 4794;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 703;
			AvailableClasses = 0x7FFF;
			Model = 6787;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Wolf Bracers";
			Name2 = "Wolf Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3515;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 2;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bear Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BearBracers : Item
	{
		public BearBracers() : base()
		{
			Id = 4795;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 705;
			AvailableClasses = 0x7FFF;
			Model = 6756;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Bear Bracers";
			Name2 = "Bear Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3528;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Owl Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OwlBracers : Item
	{
		public OwlBracers() : base()
		{
			Id = 4796;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 708;
			AvailableClasses = 0x7FFF;
			Model = 6758;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Owl Bracers";
			Name2 = "Owl Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3540;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Nomadic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class NomadicBracers : Item
	{
		public NomadicBracers() : base()
		{
			Id = 4908;
			Resistance[0] = 15;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 17169;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Nomadic Bracers";
			Name2 = "Nomadic Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Sandrunner Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SandrunnerWristguards : Item
	{
		public SandrunnerWristguards() : base()
		{
			Id = 4928;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 17017;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Sandrunner Wristguards";
			Name2 = "Sandrunner Wristguards";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 102;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Plains Hunter Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class PlainsHunterWristguards : Item
	{
		public PlainsHunterWristguards() : base()
		{
			Id = 4973;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 17014;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			Name = "Plains Hunter Wristguards";
			Name2 = "Plains Hunter Wristguards";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 178;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Feral Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FeralBracers : Item
	{
		public FeralBracers() : base()
		{
			Id = 5419;
			Resistance[0] = 18;
			Bonding = 1;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 17002;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			Name = "Feral Bracers";
			Name2 = "Feral Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 68;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Ivy Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class IvyCuffs : Item
	{
		public IvyCuffs() : base()
		{
			Id = 5612;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 17010;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			Name = "Ivy Cuffs";
			Name2 = "Ivy Cuffs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 363;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Murloc Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MurlocScaleBracers : Item
	{
		public MurlocScaleBracers() : base()
		{
			Id = 5783;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 2316;
			AvailableClasses = 0x7FFF;
			Model = 8912;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Murloc Scale Bracers";
			Name2 = "Murloc Scale Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11581;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Wolfskin Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WolfskinBracers : Item
	{
		public WolfskinBracers() : base()
		{
			Id = 6070;
			Resistance[0] = 15;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 17173;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Wolfskin Bracers";
			Name2 = "Wolfskin Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Jurassic Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class JurassicWristguards : Item
	{
		public JurassicWristguards() : base()
		{
			Id = 6198;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1113;
			AvailableClasses = 0x7FFF;
			Model = 10529;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Jurassic Wristguards";
			Name2 = "Jurassic Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5566;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 2;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Insignia Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaBracers : Item
	{
		public InsigniaBracers() : base()
		{
			Id = 6410;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1514;
			AvailableClasses = 0x7FFF;
			Model = 17009;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Insignia Bracers";
			Name2 = "Insignia Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7574;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Pioneer Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerBracers : Item
	{
		public PioneerBracers() : base()
		{
			Id = 6519;
			Resistance[0] = 23;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 8437;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Pioneer Bracers";
			Name2 = "Pioneer Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 180;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bard's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BardsBracers : Item
	{
		public BardsBracers() : base()
		{
			Id = 6556;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 174;
			AvailableClasses = 0x7FFF;
			Model = 14728;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Bard's Bracers";
			Name2 = "Bard's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1064;
			BuyPrice = 873;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Scouting Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingBracers : Item
	{
		public ScoutingBracers() : base()
		{
			Id = 6583;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 425;
			AvailableClasses = 0x7FFF;
			Model = 3657;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Scouting Bracers";
			Name2 = "Scouting Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1066;
			BuyPrice = 2126;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Dervish Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DervishBracers : Item
	{
		public DervishBracers() : base()
		{
			Id = 6602;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 873;
			AvailableClasses = 0x7FFF;
			Model = 17167;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Dervish Bracers";
			Name2 = "Dervish Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1068;
			BuyPrice = 4369;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Bands of Serra'kis)
*
***************************************************************/

namespace Server.Items
{
	public class BandsOfSerrakis : Item
	{
		public BandsOfSerrakis() : base()
		{
			Id = 6902;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 877;
			AvailableClasses = 0x7FFF;
			Model = 17001;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Bands of Serra'kis";
			Name2 = "Bands of Serra'kis";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4385;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Handstitched Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherBracers : Item
	{
		public HandstitchedLeatherBracers() : base()
		{
			Id = 7277;
			Resistance[0] = 21;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 14001;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Handstitched Leather Bracers";
			Name2 = "Handstitched Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 142;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Light Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LightLeatherBracers : Item
	{
		public LightLeatherBracers() : base()
		{
			Id = 7281;
			Resistance[0] = 28;
			SellPrice = 84;
			AvailableClasses = 0x7FFF;
			Model = 14002;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Light Leather Bracers";
			Name2 = "Light Leather Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 421;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Dusky Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DuskyBracers : Item
	{
		public DuskyBracers() : base()
		{
			Id = 7378;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2146;
			AvailableClasses = 0x7FFF;
			Model = 14803;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Dusky Bracers";
			Name2 = "Dusky Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10731;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Green Whelp Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GreenWhelpBracers : Item
	{
		public GreenWhelpBracers() : base()
		{
			Id = 7386;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 2387;
			AvailableClasses = 0x7FFF;
			Model = 14831;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Green Whelp Bracers";
			Name2 = "Green Whelp Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11937;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorBracers : Item
	{
		public InfiltratorBracers() : base()
		{
			Id = 7410;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 1174;
			AvailableClasses = 0x7FFF;
			Model = 14803;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Infiltrator Bracers";
			Name2 = "Infiltrator Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1070;
			BuyPrice = 5873;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sentinel Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelBracers : Item
	{
		public SentinelBracers() : base()
		{
			Id = 7447;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 2068;
			AvailableClasses = 0x7FFF;
			Model = 14997;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Sentinel Bracers";
			Name2 = "Sentinel Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1071;
			BuyPrice = 10343;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ranger Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class RangerWristguards : Item
	{
		public RangerWristguards() : base()
		{
			Id = 7484;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 3062;
			AvailableClasses = 0x7FFF;
			Model = 15023;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Ranger Wristguards";
			Name2 = "Ranger Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1073;
			BuyPrice = 15314;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cabalist Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistBracers : Item
	{
		public CabalistBracers() : base()
		{
			Id = 7534;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 4016;
			AvailableClasses = 0x7FFF;
			Model = 15413;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Cabalist Bracers";
			Name2 = "Cabalist Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1074;
			BuyPrice = 20080;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Heraldic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicBracers : Item
	{
		public HeraldicBracers() : base()
		{
			Id = 8118;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4436;
			AvailableClasses = 0x7FFF;
			Model = 14700;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Heraldic Bracers";
			Name2 = "Heraldic Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22184;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinBracers : Item
	{
		public SerpentskinBracers() : base()
		{
			Id = 8257;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 6053;
			AvailableClasses = 0x7FFF;
			Model = 17259;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Serpentskin Bracers";
			Name2 = "Serpentskin Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30265;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 11;
			AgilityBonus = 3;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Traveler's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersBracers : Item
	{
		public TravelersBracers() : base()
		{
			Id = 8295;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 7988;
			AvailableClasses = 0x7FFF;
			Model = 17316;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Traveler's Bracers";
			Name2 = "Traveler's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39940;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Unearthed Bands)
*
***************************************************************/

namespace Server.Items
{
	public class UnearthedBands : Item
	{
		public UnearthedBands() : base()
		{
			Id = 9428;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 2096;
			AvailableClasses = 0x7FFF;
			Model = 18331;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Unearthed Bands";
			Name2 = "Unearthed Bands";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1073;
			BuyPrice = 10481;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9139 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Emissary Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class EmissaryCuffs : Item
	{
		public EmissaryCuffs() : base()
		{
			Id = 9455;
			Resistance[6] = 5;
			Resistance[0] = 47;
			Bonding = 1;
			SellPrice = 1825;
			AvailableClasses = 0x7FFF;
			Model = 18371;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Emissary Cuffs";
			Name2 = "Emissary Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1072;
			BuyPrice = 9129;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gypsy Bands)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyBands : Item
	{
		public GypsyBands() : base()
		{
			Id = 9752;
			Resistance[0] = 26;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 17169;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Gypsy Bands";
			Name2 = "Gypsy Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 289;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bandit Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BanditBracers : Item
	{
		public BanditBracers() : base()
		{
			Id = 9777;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 318;
			AvailableClasses = 0x7FFF;
			Model = 28427;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Bandit Bracers";
			Name2 = "Bandit Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1066;
			BuyPrice = 1591;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Superior Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorBracers : Item
	{
		public SuperiorBracers() : base()
		{
			Id = 9803;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 729;
			AvailableClasses = 0x7FFF;
			Model = 27760;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Superior Bracers";
			Name2 = "Superior Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1068;
			BuyPrice = 3647;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherBracers : Item
	{
		public ScaledLeatherBracers() : base()
		{
			Id = 9829;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1020;
			AvailableClasses = 0x7FFF;
			Model = 28482;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Scaled Leather Bracers";
			Name2 = "Scaled Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1069;
			BuyPrice = 5100;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Archer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersBracers : Item
	{
		public ArchersBracers() : base()
		{
			Id = 9857;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1570;
			AvailableClasses = 0x7FFF;
			Model = 18930;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Archer's Bracers";
			Name2 = "Archer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1071;
			BuyPrice = 7851;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Bands)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansBands : Item
	{
		public HuntsmansBands() : base()
		{
			Id = 9886;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 2589;
			AvailableClasses = 0x7FFF;
			Model = 3606;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Huntsman's Bands";
			Name2 = "Huntsman's Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1072;
			BuyPrice = 12948;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Tracker's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersWristguards : Item
	{
		public TrackersWristguards() : base()
		{
			Id = 9925;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 3789;
			AvailableClasses = 0x7FFF;
			Model = 18938;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Tracker's Wristguards";
			Name2 = "Tracker's Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1074;
			BuyPrice = 18949;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsBracers : Item
	{
		public ChieftainsBracers() : base()
		{
			Id = 9949;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 4855;
			AvailableClasses = 0x7FFF;
			Model = 18945;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Chieftain's Bracers";
			Name2 = "Chieftain's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1075;
			BuyPrice = 24276;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Righteous Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousBracers : Item
	{
		public RighteousBracers() : base()
		{
			Id = 10069;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 5335;
			AvailableClasses = 0x7FFF;
			Model = 19014;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Righteous Bracers";
			Name2 = "Righteous Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1076;
			BuyPrice = 26677;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersBracers : Item
	{
		public WanderersBracers() : base()
		{
			Id = 10107;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 7218;
			AvailableClasses = 0x7FFF;
			Model = 27719;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Wanderer's Bracers";
			Name2 = "Wanderer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1077;
			BuyPrice = 36094;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Mighty Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class MightyArmsplints : Item
	{
		public MightyArmsplints() : base()
		{
			Id = 10147;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 10319;
			AvailableClasses = 0x7FFF;
			Model = 27740;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Mighty Armsplints";
			Name2 = "Mighty Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1079;
			BuyPrice = 51596;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersBracers : Item
	{
		public SwashbucklersBracers() : base()
		{
			Id = 10184;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 6523;
			AvailableClasses = 0x7FFF;
			Model = 4382;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Swashbuckler's Bracers";
			Name2 = "Swashbuckler's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1077;
			BuyPrice = 32617;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nightshade Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeArmguards : Item
	{
		public NightshadeArmguards() : base()
		{
			Id = 10223;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9466;
			AvailableClasses = 0x7FFF;
			Model = 18978;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Nightshade Armguards";
			Name2 = "Nightshade Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1079;
			BuyPrice = 47330;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersBracers : Item
	{
		public AdventurersBracers() : base()
		{
			Id = 10256;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 10675;
			AvailableClasses = 0x7FFF;
			Model = 27847;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Adventurer's Bracers";
			Name2 = "Adventurer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1080;
			BuyPrice = 53376;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Darkwater Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DarkwaterBracers : Item
	{
		public DarkwaterBracers() : base()
		{
			Id = 10800;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 7562;
			AvailableClasses = 0x7FFF;
			Model = 19806;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Darkwater Bracers";
			Name2 = "Darkwater Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1079;
			BuyPrice = 37812;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Cinderhide Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class CinderhideArmsplints : Item
	{
		public CinderhideArmsplints() : base()
		{
			Id = 11764;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 10398;
			AvailableClasses = 0x7FFF;
			Model = 21753;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Cinderhide Armsplints";
			Name2 = "Cinderhide Armsplints";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1080;
			BuyPrice = 51990;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Blackmist Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class BlackmistArmguards : Item
	{
		public BlackmistArmguards() : base()
		{
			Id = 12966;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 14018;
			AvailableClasses = 0x7FFF;
			Model = 23552;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blackmist Armguards";
			Name2 = "Blackmist Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70092;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Drakewing Bands)
*
***************************************************************/

namespace Server.Items
{
	public class DrakewingBands : Item
	{
		public DrakewingBands() : base()
		{
			Id = 12999;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 853;
			AvailableClasses = 0x7FFF;
			Model = 28370;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Drakewing Bands";
			Name2 = "Drakewing Bands";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4267;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enchanted Kodo Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedKodoBracers : Item
	{
		public EnchantedKodoBracers() : base()
		{
			Id = 13119;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 3063;
			AvailableClasses = 0x7FFF;
			Model = 28735;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Enchanted Kodo Bracers";
			Name2 = "Enchanted Kodo Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15316;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 10;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Deepfury Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DeepfuryBracers : Item
	{
		public DeepfuryBracers() : base()
		{
			Id = 13120;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 9505;
			AvailableClasses = 0x7FFF;
			Model = 28373;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Deepfury Bracers";
			Name2 = "Deepfury Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47526;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 15;
			StaminaBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bleak Howler Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class BleakHowlerArmguards : Item
	{
		public BleakHowlerArmguards() : base()
		{
			Id = 13208;
			Resistance[0] = 75;
			Bonding = 1;
			SellPrice = 12520;
			AvailableClasses = 0x7FFF;
			Model = 23760;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Bleak Howler Armguards";
			Name2 = "Bleak Howler Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62602;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 14;
			SpiritBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Chillhide Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChillhideBracers : Item
	{
		public ChillhideBracers() : base()
		{
			Id = 13537;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 9884;
			AvailableClasses = 0x7FFF;
			Model = 24190;
			Resistance[4] = 15;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Chillhide Bracers";
			Name2 = "Chillhide Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49420;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Prospector's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsCuffs : Item
	{
		public ProspectorsCuffs() : base()
		{
			Id = 14561;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 245;
			AvailableClasses = 0x7FFF;
			Model = 17014;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Prospector's Cuffs";
			Name2 = "Prospector's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1225;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			AgilityBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBindings : Item
	{
		public BristlebarkBindings() : base()
		{
			Id = 14569;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 472;
			AvailableClasses = 0x7FFF;
			Model = 13355;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Bristlebark Bindings";
			Name2 = "Bristlebark Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2360;
			InventoryType = InventoryTypes.Wrist;
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
*				(Dokebi Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiBracers : Item
	{
		public DokebiBracers() : base()
		{
			Id = 14580;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 818;
			AvailableClasses = 0x7FFF;
			Model = 27964;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Dokebi Bracers";
			Name2 = "Dokebi Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4093;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 4;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesBracers : Item
	{
		public HawkeyesBracers() : base()
		{
			Id = 14590;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1821;
			AvailableClasses = 0x7FFF;
			Model = 14770;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Hawkeye's Bracers";
			Name2 = "Hawkeye's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9109;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 4;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warden's Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class WardensWristbands : Item
	{
		public WardensWristbands() : base()
		{
			Id = 14600;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 2675;
			AvailableClasses = 0x7FFF;
			Model = 27985;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Warden's Wristbands";
			Name2 = "Warden's Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13377;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 3;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiWristbands : Item
	{
		public ScorpashiWristbands() : base()
		{
			Id = 14654;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 3931;
			AvailableClasses = 0x7FFF;
			Model = 27582;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Scorpashi Wristbands";
			Name2 = "Scorpashi Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19655;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 7;
			AgilityBonus = 6;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Keeper's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersBindings : Item
	{
		public KeepersBindings() : base()
		{
			Id = 14663;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 5141;
			AvailableClasses = 0x7FFF;
			Model = 27565;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Keeper's Bindings";
			Name2 = "Keeper's Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25707;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 5;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Pridelord Bands)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordBands : Item
	{
		public PridelordBands() : base()
		{
			Id = 14672;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 7309;
			AvailableClasses = 0x7FFF;
			Model = 27582;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Pridelord Bands";
			Name2 = "Pridelord Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36548;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 10;
			StrBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Indomitable Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableArmguards : Item
	{
		public IndomitableArmguards() : base()
		{
			Id = 14682;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 9906;
			AvailableClasses = 0x7FFF;
			Model = 17259;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Indomitable Armguards";
			Name2 = "Indomitable Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49534;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Primal Bands)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalBands : Item
	{
		public PrimalBands() : base()
		{
			Id = 15005;
			Resistance[0] = 21;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 17017;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Primal Bands";
			Name2 = "Primal Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 141;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Lupine Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class LupineCuffs : Item
	{
		public LupineCuffs() : base()
		{
			Id = 15013;
			Resistance[0] = 28;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 27989;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Lupine Cuffs";
			Name2 = "Lupine Cuffs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 430;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wicked Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WickedLeatherBracers : Item
	{
		public WickedLeatherBracers() : base()
		{
			Id = 15084;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 7311;
			AvailableClasses = 0x7FFF;
			Model = 25726;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Wicked Leather Bracers";
			Name2 = "Wicked Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36555;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Runic Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RunicLeatherBracers : Item
	{
		public RunicLeatherBracers() : base()
		{
			Id = 15092;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 7656;
			AvailableClasses = 0x7FFF;
			Model = 25736;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Runic Leather Bracers";
			Name2 = "Runic Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38283;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Rigid Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class RigidBracelets : Item
	{
		public RigidBracelets() : base()
		{
			Id = 15112;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 354;
			AvailableClasses = 0x7FFF;
			Model = 27879;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Rigid Bracelets";
			Name2 = "Rigid Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1066;
			BuyPrice = 1771;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Robust Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RobustBracers : Item
	{
		public RobustBracers() : base()
		{
			Id = 15122;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 701;
			AvailableClasses = 0x7FFF;
			Model = 27888;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Robust Bracers";
			Name2 = "Robust Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1068;
			BuyPrice = 3507;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsArmguards : Item
	{
		public CutthroatsArmguards() : base()
		{
			Id = 15132;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1017;
			AvailableClasses = 0x7FFF;
			Model = 27706;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Cutthroat's Armguards";
			Name2 = "Cutthroat's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1069;
			BuyPrice = 5085;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerBindings : Item
	{
		public GhostwalkerBindings() : base()
		{
			Id = 15143;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1439;
			AvailableClasses = 0x7FFF;
			Model = 3652;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Ghostwalker Bindings";
			Name2 = "Ghostwalker Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1070;
			BuyPrice = 7197;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalWristbands : Item
	{
		public NocturnalWristbands() : base()
		{
			Id = 15160;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 2430;
			AvailableClasses = 0x7FFF;
			Model = 27727;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Nocturnal Wristbands";
			Name2 = "Nocturnal Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1072;
			BuyPrice = 12151;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Imposing Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingBracers : Item
	{
		public ImposingBracers() : base()
		{
			Id = 15163;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 3344;
			AvailableClasses = 0x7FFF;
			Model = 27922;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Imposing Bracers";
			Name2 = "Imposing Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1074;
			BuyPrice = 16723;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Potent Bands)
*
***************************************************************/

namespace Server.Items
{
	public class PotentBands : Item
	{
		public PotentBands() : base()
		{
			Id = 15172;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 4706;
			AvailableClasses = 0x7FFF;
			Model = 27589;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Potent Bands";
			Name2 = "Potent Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1075;
			BuyPrice = 23534;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Praetorian Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianWristbands : Item
	{
		public PraetorianWristbands() : base()
		{
			Id = 15182;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 5996;
			AvailableClasses = 0x7FFF;
			Model = 28584;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Praetorian Wristbands";
			Name2 = "Praetorian Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1076;
			BuyPrice = 29982;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grand Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class GrandArmguards : Item
	{
		public GrandArmguards() : base()
		{
			Id = 15188;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 8702;
			AvailableClasses = 0x7FFF;
			Model = 27632;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Grand Armguards";
			Name2 = "Grand Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1078;
			BuyPrice = 43512;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grizzly Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyBracers : Item
	{
		public GrizzlyBracers() : base()
		{
			Id = 15297;
			Resistance[0] = 24;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 28013;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Grizzly Bracers";
			Name2 = "Grizzly Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 227;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Feral Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class FeralBindings : Item
	{
		public FeralBindings() : base()
		{
			Id = 15306;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 208;
			AvailableClasses = 0x7FFF;
			Model = 28045;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Feral Bindings";
			Name2 = "Feral Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1065;
			BuyPrice = 1042;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersWristbands : Item
	{
		public WranglersWristbands() : base()
		{
			Id = 15331;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 555;
			AvailableClasses = 0x7FFF;
			Model = 28001;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Wrangler's Wristbands";
			Name2 = "Wrangler's Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1067;
			BuyPrice = 2776;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderBracers : Item
	{
		public PathfinderBracers() : base()
		{
			Id = 15348;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 792;
			AvailableClasses = 0x7FFF;
			Model = 27675;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Pathfinder Bracers";
			Name2 = "Pathfinder Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1068;
			BuyPrice = 3962;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Bands)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersBands : Item
	{
		public HeadhuntersBands() : base()
		{
			Id = 15351;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1090;
			AvailableClasses = 0x7FFF;
			Model = 27699;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Headhunter's Bands";
			Name2 = "Headhunter's Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1069;
			BuyPrice = 5450;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Trickster's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersBindings : Item
	{
		public TrickstersBindings() : base()
		{
			Id = 15360;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 2372;
			AvailableClasses = 0x7FFF;
			Model = 27954;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Trickster's Bindings";
			Name2 = "Trickster's Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1072;
			BuyPrice = 11861;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersWristbands : Item
	{
		public WolfRidersWristbands() : base()
		{
			Id = 15377;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 3191;
			AvailableClasses = 0x7FFF;
			Model = 27972;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Wolf Rider's Wristbands";
			Name2 = "Wolf Rider's Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1073;
			BuyPrice = 15959;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawBracers : Item
	{
		public RageclawBracers() : base()
		{
			Id = 15380;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4390;
			AvailableClasses = 0x7FFF;
			Model = 15413;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Rageclaw Bracers";
			Name2 = "Rageclaw Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1075;
			BuyPrice = 21954;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Jadefire Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireBracelets : Item
	{
		public JadefireBracelets() : base()
		{
			Id = 15387;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 5583;
			AvailableClasses = 0x7FFF;
			Model = 27655;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Jadefire Bracelets";
			Name2 = "Jadefire Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1076;
			BuyPrice = 27919;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ridgeback Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RidgebackBracers : Item
	{
		public RidgebackBracers() : base()
		{
			Id = 15403;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 279;
			AvailableClasses = 0x7FFF;
			Model = 28243;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Ridgeback Bracers";
			Name2 = "Ridgeback Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1399;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			IqBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Peerless Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessBracers : Item
	{
		public PeerlessBracers() : base()
		{
			Id = 15425;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 8272;
			AvailableClasses = 0x7FFF;
			Model = 28033;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Peerless Bracers";
			Name2 = "Peerless Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1078;
			BuyPrice = 41364;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Supreme Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeBracers : Item
	{
		public SupremeBracers() : base()
		{
			Id = 15436;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 10519;
			AvailableClasses = 0x7FFF;
			Model = 27608;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Supreme Bracers";
			Name2 = "Supreme Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1079;
			BuyPrice = 52596;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Savannah Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SavannahBracers : Item
	{
		public SavannahBracers() : base()
		{
			Id = 15453;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 269;
			AvailableClasses = 0x7FFF;
			Model = 28247;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Savannah Bracers";
			Name2 = "Savannah Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1349;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Loamflake Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LoamflakeBracers : Item
	{
		public LoamflakeBracers() : base()
		{
			Id = 15462;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 653;
			AvailableClasses = 0x7FFF;
			Model = 28286;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Loamflake Bracers";
			Name2 = "Loamflake Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3269;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Leather Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsLeatherArmguards : Item
	{
		public FirstSergeantsLeatherArmguards() : base()
		{
			Id = 16497;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 6880;
			AvailableClasses = 0x08;
			Model = 30801;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "First Sergeant's Leather Armguards";
			Name2 = "First Sergeant's Leather Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34402;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 17;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftBracers : Item
	{
		public ShadowcraftBracers() : base()
		{
			Id = 16710;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 10446;
			AvailableClasses = 0x7FFF;
			Model = 24190;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Shadowcraft Bracers";
			Name2 = "Shadowcraft Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52230;
			Sets = 184;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 15;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Wildheart Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartBracers : Item
	{
		public WildheartBracers() : base()
		{
			Id = 16714;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 10602;
			AvailableClasses = 0x7FFF;
			Model = 29977;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Wildheart Bracers";
			Name2 = "Wildheart Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53012;
			Sets = 185;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SpiritBonus = 15;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerBracelets : Item
	{
		public NightslayerBracelets() : base()
		{
			Id = 16825;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 21977;
			AvailableClasses = 0x08;
			Model = 31106;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Bracelets";
			Name2 = "Nightslayer Bracelets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 109887;
			Sets = 204;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			AgilityBonus = 20;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Cenarion Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionBracers : Item
	{
		public CenarionBracers() : base()
		{
			Id = 16830;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 22972;
			AvailableClasses = 0x400;
			Model = 31725;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Bracers";
			Name2 = "Cenarion Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 114864;
			Sets = 205;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 9396 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			IqBonus = 13;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Stormrage Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageBracers : Item
	{
		public StormrageBracers() : base()
		{
			Id = 16904;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 36606;
			AvailableClasses = 0x400;
			Model = 29774;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Bracers";
			Name2 = "Stormrage Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 183030;
			Sets = 214;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangBracers : Item
	{
		public BloodfangBracers() : base()
		{
			Id = 16911;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 34872;
			AvailableClasses = 0x08;
			Model = 21753;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Bracers";
			Name2 = "Bloodfang Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 174362;
			Sets = 213;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 23;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bracers of the Eclipse)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfTheEclipse : Item
	{
		public BracersOfTheEclipse() : base()
		{
			Id = 18375;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 14329;
			AvailableClasses = 0x7FFF;
			Model = 30727;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Bracers of the Eclipse";
			Name2 = "Bracers of the Eclipse";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71649;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 14027 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Dragonhide Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsDragonhideArmguards : Item
	{
		public FirstSergeantsDragonhideArmguards() : base()
		{
			Id = 18434;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 7493;
			AvailableClasses = 0x400;
			Model = 27262;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "First Sergeant's Dragonhide Armguards";
			Name2 = "First Sergeant's Dragonhide Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37468;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Leather Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsLeatherArmguards18435 : Item
	{
		public FirstSergeantsLeatherArmguards18435() : base()
		{
			Id = 18435;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 3662;
			AvailableClasses = 0x08;
			Model = 30801;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "First Sergeant's Leather Armguards";
			Name2 = "First Sergeant's Leather Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18311;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 14;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Dragonhide Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsDragonhideArmguards18436 : Item
	{
		public FirstSergeantsDragonhideArmguards18436() : base()
		{
			Id = 18436;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 3417;
			AvailableClasses = 0x400;
			Model = 27262;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "First Sergeant's Dragonhide Armguards";
			Name2 = "First Sergeant's Dragonhide Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17086;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Dragonhide Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsDragonhideArmsplints : Item
	{
		public SergeantMajorsDragonhideArmsplints() : base()
		{
			Id = 18452;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 6910;
			AvailableClasses = 0x08;
			Model = 30804;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant Major's Dragonhide Armsplints";
			Name2 = "Sergeant Major's Dragonhide Armsplints";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34553;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 17;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Dragonhide Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsDragonhideArmsplints18453 : Item
	{
		public SergeantMajorsDragonhideArmsplints18453() : base()
		{
			Id = 18453;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 3343;
			AvailableClasses = 0x08;
			Model = 30804;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant Major's Dragonhide Armsplints";
			Name2 = "Sergeant Major's Dragonhide Armsplints";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16716;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 14;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Leather Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsLeatherArmsplints : Item
	{
		public SergeantMajorsLeatherArmsplints() : base()
		{
			Id = 18454;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 6963;
			AvailableClasses = 0x400;
			Model = 30805;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant Major's Leather Armsplints";
			Name2 = "Sergeant Major's Leather Armsplints";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34815;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Leather Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsLeatherArmsplints18455 : Item
	{
		public SergeantMajorsLeatherArmsplints18455() : base()
		{
			Id = 18455;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 3343;
			AvailableClasses = 0x400;
			Model = 30805;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant Major's Leather Armsplints";
			Name2 = "Sergeant Major's Leather Armsplints";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16716;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Bracers of Prosperity)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfProsperity : Item
	{
		public BracersOfProsperity() : base()
		{
			Id = 18525;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 13730;
			AvailableClasses = 0x7FFF;
			Model = 30859;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Bracers of Prosperity";
			Name2 = "Bracers of Prosperity";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68652;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Malefic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MaleficBracers : Item
	{
		public MaleficBracers() : base()
		{
			Id = 18700;
			Resistance[0] = 72;
			Bonding = 1;
			SellPrice = 10910;
			AvailableClasses = 0x7FFF;
			Model = 27048;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Malefic Bracers";
			Name2 = "Malefic Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54552;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 16;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Arena Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ArenaBracers : Item
	{
		public ArenaBracers() : base()
		{
			Id = 18710;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 7224;
			AvailableClasses = 0x7FFF;
			Model = 31159;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Arena Bracers";
			Name2 = "Arena Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36122;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 35;
			StaminaBonus = 14;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Magistrate's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class MagistratesCuffs : Item
	{
		public MagistratesCuffs() : base()
		{
			Id = 18726;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 11296;
			AvailableClasses = 0x7FFF;
			Model = 31175;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Magistrate's Cuffs";
			Name2 = "Magistrate's Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56480;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Barbaric Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricBracers : Item
	{
		public BarbaricBracers() : base()
		{
			Id = 18948;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 1589;
			AvailableClasses = 0x7FFF;
			Model = 31385;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Barbaric Bracers";
			Name2 = "Barbaric Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7945;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 6;
			IqBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Yeti Hide Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class YetiHideBracers : Item
	{
		public YetiHideBracers() : base()
		{
			Id = 19113;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 13730;
			AvailableClasses = 0x7FFF;
			Model = 31620;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Yeti Hide Bracers";
			Name2 = "Yeti Hide Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68652;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 8;
			StaminaBonus = 14;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Wristguards of Stability)
*
***************************************************************/

namespace Server.Items
{
	public class WristguardsOfStability : Item
	{
		public WristguardsOfStability() : base()
		{
			Id = 19146;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 20183;
			AvailableClasses = 0x7FFF;
			Model = 6763;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Wristguards of Stability";
			Name2 = "Wristguards of Stability";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 100919;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StrBonus = 24;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Branded Leather Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrandedLeatherBracers : Item
	{
		public BrandedLeatherBracers() : base()
		{
			Id = 19508;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 1423;
			AvailableClasses = 0x7FFF;
			Model = 32036;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Branded Leather Bracers";
			Name2 = "Branded Leather Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7116;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9142 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Forest Stalker's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ForestStalkersBracers : Item
	{
		public ForestStalkersBracers() : base()
		{
			Id = 19587;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 20183;
			AvailableClasses = 0x7FFF;
			Model = 32090;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Forest Stalker's Bracers";
			Name2 = "Forest Stalker's Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 100919;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			AgilityBonus = 19;
			StrBonus = 11;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Forest Stalker's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ForestStalkersBracers19589 : Item
	{
		public ForestStalkersBracers19589() : base()
		{
			Id = 19589;
			Resistance[0] = 75;
			Bonding = 1;
			SellPrice = 12043;
			AvailableClasses = 0x7FFF;
			Model = 32090;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Forest Stalker's Bracers";
			Name2 = "Forest Stalker's Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60218;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			AgilityBonus = 17;
			StrBonus = 9;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Forest Stalker's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ForestStalkersBracers19590 : Item
	{
		public ForestStalkersBracers19590() : base()
		{
			Id = 19590;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 6181;
			AvailableClasses = 0x7FFF;
			Model = 32090;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Forest Stalker's Bracers";
			Name2 = "Forest Stalker's Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 30909;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			AgilityBonus = 14;
			StrBonus = 8;
			StaminaBonus = 6;
		}
	}
}


