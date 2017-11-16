/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:54 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Support Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class SupportGirdle : Item
	{
		public SupportGirdle() : base()
		{
			Id = 1215;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 469;
			AvailableClasses = 0x7FFF;
			Model = 16942;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Support Girdle";
			Name2 = "Support Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2347;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherBelt : Item
	{
		public RaggedLeatherBelt() : base()
		{
			Id = 1369;
			Resistance[0] = 18;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 14335;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Ragged Leather Belt";
			Name2 = "Ragged Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 21;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherBelt : Item
	{
		public WornLeatherBelt() : base()
		{
			Id = 1418;
			Resistance[0] = 22;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 14344;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			ReqLevel = 2;
			Name = "Worn Leather Belt";
			Name2 = "Worn Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 46;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherBelt : Item
	{
		public WarpedLeatherBelt() : base()
		{
			Id = 1502;
			Resistance[0] = 35;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 16947;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Warped Leather Belt";
			Name2 = "Warped Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 302;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherBelt : Item
	{
		public PatchedLeatherBelt() : base()
		{
			Id = 1787;
			Resistance[0] = 38;
			SellPrice = 102;
			AvailableClasses = 0x7FFF;
			Model = 14360;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Patched Leather Belt";
			Name2 = "Patched Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 510;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Rawhide Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideBelt : Item
	{
		public RawhideBelt() : base()
		{
			Id = 1795;
			Resistance[0] = 42;
			SellPrice = 235;
			AvailableClasses = 0x7FFF;
			Model = 16935;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Rawhide Belt";
			Name2 = "Rawhide Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 1176;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherBelt : Item
	{
		public ToughLeatherBelt() : base()
		{
			Id = 1803;
			Resistance[0] = 47;
			SellPrice = 465;
			AvailableClasses = 0x7FFF;
			Model = 16945;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Tough Leather Belt";
			Name2 = "Tough Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 2325;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dirty Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherBelt : Item
	{
		public DirtyLeatherBelt() : base()
		{
			Id = 1835;
			Resistance[0] = 19;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14443;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Belt";
			Name2 = "Dirty Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherBelt : Item
	{
		public RoughLeatherBelt() : base()
		{
			Id = 1839;
			Resistance[0] = 29;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 17126;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Belt";
			Name2 = "Rough Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 184;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherBelt : Item
	{
		public TannedLeatherBelt() : base()
		{
			Id = 1843;
			Resistance[0] = 39;
			SellPrice = 145;
			AvailableClasses = 0x7FFF;
			Model = 14469;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Belt";
			Name2 = "Tanned Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 725;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cured Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherBelt : Item
	{
		public CuredLeatherBelt() : base()
		{
			Id = 1849;
			Resistance[0] = 43;
			SellPrice = 277;
			AvailableClasses = 0x7FFF;
			Model = 16914;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Belt";
			Name2 = "Cured Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1388;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherBelt : Item
	{
		public CrackedLeatherBelt() : base()
		{
			Id = 2122;
			Resistance[0] = 19;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14425;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Belt";
			Name2 = "Cracked Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliBelt : Item
	{
		public CuirboulliBelt() : base()
		{
			Id = 2142;
			Resistance[0] = 47;
			SellPrice = 524;
			AvailableClasses = 0x7FFF;
			Model = 17117;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Belt";
			Name2 = "Cuirboulli Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2620;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Old Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class OldLeatherBelt : Item
	{
		public OldLeatherBelt() : base()
		{
			Id = 2173;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 28227;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Old Leather Belt";
			Name2 = "Old Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Outfitter Belt)
*
***************************************************************/

namespace Server.Items
{
	public class OutfitterBelt : Item
	{
		public OutfitterBelt() : base()
		{
			Id = 2186;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 4545;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Outfitter Belt";
			Name2 = "Outfitter Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherBelt : Item
	{
		public BatteredLeatherBelt() : base()
		{
			Id = 2371;
			Resistance[0] = 29;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 17114;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Belt";
			Name2 = "Battered Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 189;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Studded Belt)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedBelt : Item
	{
		public StuddedBelt() : base()
		{
			Id = 2464;
			Resistance[0] = 56;
			SellPrice = 1374;
			AvailableClasses = 0x7FFF;
			Model = 11558;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Belt";
			Name2 = "Studded Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6871;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherBelt : Item
	{
		public ReinforcedLeatherBelt() : base()
		{
			Id = 2471;
			Resistance[0] = 71;
			SellPrice = 3408;
			AvailableClasses = 0x7FFF;
			Model = 14492;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Belt";
			Name2 = "Reinforced Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17040;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wendigo Collar)
*
***************************************************************/

namespace Server.Items
{
	public class WendigoCollar : Item
	{
		public WendigoCollar() : base()
		{
			Id = 2899;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 169;
			AvailableClasses = 0x7FFF;
			Model = 16949;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Wendigo Collar";
			Name2 = "Wendigo Collar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 846;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Guardsman Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GuardsmanBelt : Item
	{
		public GuardsmanBelt() : base()
		{
			Id = 3429;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 586;
			AvailableClasses = 0x7FFF;
			Model = 4532;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Guardsman Belt";
			Name2 = "Guardsman Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2931;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StaminaBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Belt of Vindication)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfVindication : Item
	{
		public BeltOfVindication() : base()
		{
			Id = 3562;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 823;
			AvailableClasses = 0x7FFF;
			Model = 16910;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Belt of Vindication";
			Name2 = "Belt of Vindication";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4117;
			InventoryType = InventoryTypes.Waist;
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
*				(Weathered Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WeatheredBelt : Item
	{
		public WeatheredBelt() : base()
		{
			Id = 3583;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 16948;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			Name = "Weathered Belt";
			Name2 = "Weathered Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 288;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Meditative Sash)
*
***************************************************************/

namespace Server.Items
{
	public class MeditativeSash : Item
	{
		public MeditativeSash() : base()
		{
			Id = 3747;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 1092;
			AvailableClasses = 0x7FFF;
			Model = 11167;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Meditative Sash";
			Name2 = "Meditative Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5462;
			InventoryType = InventoryTypes.Waist;
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
*				(Shepherd's Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ShepherdsGirdle : Item
	{
		public ShepherdsGirdle() : base()
		{
			Id = 3753;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 1635;
			AvailableClasses = 0x7FFF;
			Model = 17129;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			Name = "Shepherd's Girdle";
			Name2 = "Shepherd's Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8178;
			InventoryType = InventoryTypes.Waist;
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
*				(Hardened Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherBelt : Item
	{
		public HardenedLeatherBelt() : base()
		{
			Id = 3800;
			Resistance[0] = 55;
			SellPrice = 1068;
			AvailableClasses = 0x7FFF;
			Model = 19042;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Hardened Leather Belt";
			Name2 = "Hardened Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 5343;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherBelt : Item
	{
		public ThickLeatherBelt() : base()
		{
			Id = 3961;
			Resistance[0] = 61;
			SellPrice = 1503;
			AvailableClasses = 0x7FFF;
			Model = 16943;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Thick Leather Belt";
			Name2 = "Thick Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 7518;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherBelt : Item
	{
		public SmoothLeatherBelt() : base()
		{
			Id = 3969;
			Resistance[0] = 73;
			SellPrice = 3256;
			AvailableClasses = 0x7FFF;
			Model = 14408;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Smooth Leather Belt";
			Name2 = "Smooth Leather Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 16283;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Belt of Corruption)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfCorruption : Item
	{
		public BeltOfCorruption() : base()
		{
			Id = 4131;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 3815;
			AvailableClasses = 0x7FFF;
			Model = 17115;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			Name = "Belt of Corruption";
			Name2 = "Belt of Corruption";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19079;
			InventoryType = InventoryTypes.Waist;
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
*				(Handstitched Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherBelt : Item
	{
		public HandstitchedLeatherBelt() : base()
		{
			Id = 4237;
			Resistance[0] = 29;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 9501;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Handstitched Leather Belt";
			Name2 = "Handstitched Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 174;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherBelt : Item
	{
		public FineLeatherBelt() : base()
		{
			Id = 4246;
			Resistance[0] = 38;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 9513;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Fine Leather Belt";
			Name2 = "Fine Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 625;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherBelt : Item
	{
		public DarkLeatherBelt() : base()
		{
			Id = 4249;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 703;
			AvailableClasses = 0x7FFF;
			Model = 12464;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Dark Leather Belt";
			Name2 = "Dark Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3515;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hillman's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HillmansBelt : Item
	{
		public HillmansBelt() : base()
		{
			Id = 4250;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 705;
			AvailableClasses = 0x7FFF;
			Model = 17237;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Hillman's Belt";
			Name2 = "Hillman's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3527;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Green Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLeatherBelt : Item
	{
		public GreenLeatherBelt() : base()
		{
			Id = 4257;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 1311;
			AvailableClasses = 0x7FFF;
			Model = 17224;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Green Leather Belt";
			Name2 = "Green Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6556;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Guardian Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianBelt : Item
	{
		public GuardianBelt() : base()
		{
			Id = 4258;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 1592;
			AvailableClasses = 0x7FFF;
			Model = 9538;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Guardian Belt";
			Name2 = "Guardian Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7963;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Gem-studded Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GemStuddedLeatherBelt : Item
	{
		public GemStuddedLeatherBelt() : base()
		{
			Id = 4262;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 2652;
			AvailableClasses = 0x7FFF;
			Model = 17218;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Gem-studded Leather Belt";
			Name2 = "Gem-studded Leather Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13260;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9163 , 0 , 0 , 3600000 , 30 , 180000 );
			StaminaBonus = 8;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Barbaric Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricBelt : Item
	{
		public BarbaricBelt() : base()
		{
			Id = 4264;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 2804;
			AvailableClasses = 0x7FFF;
			Model = 17111;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Barbaric Belt";
			Name2 = "Barbaric Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14022;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9174 , 0 , 0 , 3600000 , 28 , 300000 );
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Raptor Hide Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorHideBelt : Item
	{
		public RaptorHideBelt() : base()
		{
			Id = 4456;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 1553;
			AvailableClasses = 0x7FFF;
			Model = 17231;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Raptor Hide Belt";
			Name2 = "Raptor Hide Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7768;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherBelt : Item
	{
		public BurntLeatherBelt() : base()
		{
			Id = 4666;
			Resistance[0] = 27;
			SellPrice = 26;
			AvailableClasses = 0x7FFF;
			Model = 16911;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Burnt Leather Belt";
			Name2 = "Burnt Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 132;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Tribal Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TribalBelt : Item
	{
		public TribalBelt() : base()
		{
			Id = 4675;
			Resistance[0] = 29;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 16911;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Tribal Belt";
			Name2 = "Tribal Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 178;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Hunting Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingBelt : Item
	{
		public HuntingBelt() : base()
		{
			Id = 4690;
			Resistance[0] = 35;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 14533;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Hunting Belt";
			Name2 = "Hunting Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 356;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherBelt : Item
	{
		public CeremonialLeatherBelt() : base()
		{
			Id = 4693;
			Resistance[0] = 37;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 29632;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Ceremonial Leather Belt";
			Name2 = "Ceremonial Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 433;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherBelt : Item
	{
		public ImperialLeatherBelt() : base()
		{
			Id = 4738;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 3294;
			AvailableClasses = 0x7FFF;
			Model = 16921;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Imperial Leather Belt";
			Name2 = "Imperial Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16471;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 11;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Squealer's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SquealersBelt : Item
	{
		public SquealersBelt() : base()
		{
			Id = 4951;
			Resistance[0] = 23;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 16938;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			ReqLevel = 1;
			Name = "Squealer's Belt";
			Name2 = "Squealer's Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 69;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Nomadic Belt)
*
***************************************************************/

namespace Server.Items
{
	public class NomadicBelt : Item
	{
		public NomadicBelt() : base()
		{
			Id = 4954;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 16932;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Nomadic Belt";
			Name2 = "Nomadic Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Ripped Prospector Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RippedProspectorBelt : Item
	{
		public RippedProspectorBelt() : base()
		{
			Id = 4982;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 961;
			AvailableClasses = 0x7FFF;
			Model = 10411;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			Name = "Ripped Prospector Belt";
			Name2 = "Ripped Prospector Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 4807;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Binding Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class BindingGirdle : Item
	{
		public BindingGirdle() : base()
		{
			Id = 5275;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 7545;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Binding Girdle";
			Name2 = "Binding Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 879;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Beastmaster's Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class BeastmastersGirdle : Item
	{
		public BeastmastersGirdle() : base()
		{
			Id = 5355;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 947;
			AvailableClasses = 0x7FFF;
			Model = 7662;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			Name = "Beastmaster's Girdle";
			Name2 = "Beastmaster's Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4738;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Steadfast Cinch)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastCinch : Item
	{
		public SteadfastCinch() : base()
		{
			Id = 5609;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 447;
			AvailableClasses = 0x7FFF;
			Model = 6755;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			Name = "Steadfast Cinch";
			Name2 = "Steadfast Cinch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2235;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Murloc Scale Belt)
*
***************************************************************/

namespace Server.Items
{
	public class MurlocScaleBelt : Item
	{
		public MurlocScaleBelt() : base()
		{
			Id = 5780;
			Resistance[0] = 40;
			SellPrice = 156;
			AvailableClasses = 0x7FFF;
			Model = 8905;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Murloc Scale Belt";
			Name2 = "Murloc Scale Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 781;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Animal Skin Belt)
*
***************************************************************/

namespace Server.Items
{
	public class AnimalSkinBelt : Item
	{
		public AnimalSkinBelt() : base()
		{
			Id = 5936;
			Resistance[0] = 25;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 9365;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Animal Skin Belt";
			Name2 = "Animal Skin Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 99;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Ruffian Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RuffianBelt : Item
	{
		public RuffianBelt() : base()
		{
			Id = 5975;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 532;
			AvailableClasses = 0x7FFF;
			Model = 9584;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Ruffian Belt";
			Name2 = "Ruffian Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2664;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blackened Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedLeatherBelt : Item
	{
		public BlackenedLeatherBelt() : base()
		{
			Id = 6058;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 8419;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Blackened Leather Belt";
			Name2 = "Blackened Leather Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Ratty Old Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RattyOldBelt : Item
	{
		public RattyOldBelt() : base()
		{
			Id = 6147;
			Resistance[0] = 29;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 9508;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Ratty Old Belt";
			Name2 = "Ratty Old Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Girdle of the Blindwatcher)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfTheBlindwatcher : Item
	{
		public GirdleOfTheBlindwatcher() : base()
		{
			Id = 6319;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 803;
			AvailableClasses = 0x7FFF;
			Model = 11253;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Girdle of the Blindwatcher";
			Name2 = "Girdle of the Blindwatcher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4016;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 3;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherBelt : Item
	{
		public InscribedLeatherBelt() : base()
		{
			Id = 6379;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 244;
			AvailableClasses = 0x7FFF;
			Model = 16922;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Inscribed Leather Belt";
			Name2 = "Inscribed Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1223;
			InventoryType = InventoryTypes.Waist;
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
*				(Forest Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherBelt : Item
	{
		public ForestLeatherBelt() : base()
		{
			Id = 6382;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 523;
			AvailableClasses = 0x7FFF;
			Model = 16916;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Forest Leather Belt";
			Name2 = "Forest Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2616;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Belt)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedBelt : Item
	{
		public EmblazonedBelt() : base()
		{
			Id = 6398;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 989;
			AvailableClasses = 0x7FFF;
			Model = 17118;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Emblazoned Belt";
			Name2 = "Emblazoned Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4948;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Insignia Belt)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaBelt : Item
	{
		public InsigniaBelt() : base()
		{
			Id = 6409;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 1660;
			AvailableClasses = 0x7FFF;
			Model = 17121;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Insignia Belt";
			Name2 = "Insignia Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8302;
			InventoryType = InventoryTypes.Waist;
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
*				(Glyphed Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedBelt : Item
	{
		public GlyphedBelt() : base()
		{
			Id = 6421;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 2317;
			AvailableClasses = 0x7FFF;
			Model = 14671;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Glyphed Belt";
			Name2 = "Glyphed Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11585;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			StaminaBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Deviate Scale Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DeviateScaleBelt : Item
	{
		public DeviateScaleBelt() : base()
		{
			Id = 6468;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 658;
			AvailableClasses = 0x7FFF;
			Model = 11960;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Deviate Scale Belt";
			Name2 = "Deviate Scale Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3292;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			AgilityBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pioneer Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerBelt : Item
	{
		public PioneerBelt() : base()
		{
			Id = 6517;
			Resistance[0] = 29;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 17124;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Pioneer Belt";
			Name2 = "Pioneer Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 179;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bard's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BardsBelt : Item
	{
		public BardsBelt() : base()
		{
			Id = 6558;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 180;
			AvailableClasses = 0x7FFF;
			Model = 17113;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Bard's Belt";
			Name2 = "Bard's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 896;
			BuyPrice = 902;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Scouting Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingBelt : Item
	{
		public ScoutingBelt() : base()
		{
			Id = 6581;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 422;
			AvailableClasses = 0x7FFF;
			Model = 17127;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Scouting Belt";
			Name2 = "Scouting Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 898;
			BuyPrice = 2111;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Dervish Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DervishBelt : Item
	{
		public DervishBelt() : base()
		{
			Id = 6600;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 867;
			AvailableClasses = 0x7FFF;
			Model = 14774;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Dervish Belt";
			Name2 = "Dervish Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 900;
			BuyPrice = 4338;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Windborne Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WindborneBelt : Item
	{
		public WindborneBelt() : base()
		{
			Id = 6719;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 1097;
			AvailableClasses = 0x7FFF;
			Model = 17134;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Windborne Belt";
			Name2 = "Windborne Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5485;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Azure Sash)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSash : Item
	{
		public AzureSash() : base()
		{
			Id = 6740;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 12977;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			Name = "Azure Sash";
			Name2 = "Azure Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5004;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 3;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Magram Hunter's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class MagramHuntersBelt : Item
	{
		public MagramHuntersBelt() : base()
		{
			Id = 6788;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 3331;
			AvailableClasses = 0x7FFF;
			Model = 17122;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			Name = "Magram Hunter's Belt";
			Name2 = "Magram Hunter's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16658;
			InventoryType = InventoryTypes.Waist;
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
*				(Moss Cinch)
*
***************************************************************/

namespace Server.Items
{
	public class MossCinch : Item
	{
		public MossCinch() : base()
		{
			Id = 6911;
			Resistance[0] = 59;
			Bonding = 1;
			SellPrice = 1442;
			AvailableClasses = 0x7FFF;
			Model = 16931;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Moss Cinch";
			Name2 = "Moss Cinch";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7210;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SpiritBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Heartwood Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class HeartwoodGirdle : Item
	{
		public HeartwoodGirdle() : base()
		{
			Id = 7000;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 16919;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Heartwood Girdle";
			Name2 = "Heartwood Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3252;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dusky Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DuskyBelt : Item
	{
		public DuskyBelt() : base()
		{
			Id = 7387;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 2587;
			AvailableClasses = 0x7FFF;
			Model = 14832;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Dusky Belt";
			Name2 = "Dusky Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12939;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Cord)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorCord : Item
	{
		public InfiltratorCord() : base()
		{
			Id = 7406;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 1372;
			AvailableClasses = 0x7FFF;
			Model = 6755;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Infiltrator Cord";
			Name2 = "Infiltrator Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 902;
			BuyPrice = 6861;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sentinel Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelGirdle : Item
	{
		public SentinelGirdle() : base()
		{
			Id = 7448;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 2076;
			AvailableClasses = 0x7FFF;
			Model = 14999;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Sentinel Girdle";
			Name2 = "Sentinel Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 903;
			BuyPrice = 10380;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ranger Cord)
*
***************************************************************/

namespace Server.Items
{
	public class RangerCord : Item
	{
		public RangerCord() : base()
		{
			Id = 7485;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 3073;
			AvailableClasses = 0x7FFF;
			Model = 15016;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Ranger Cord";
			Name2 = "Ranger Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 905;
			BuyPrice = 15367;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cabalist Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistBelt : Item
	{
		public CabalistBelt() : base()
		{
			Id = 7535;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 4353;
			AvailableClasses = 0x7FFF;
			Model = 15411;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Cabalist Belt";
			Name2 = "Cabalist Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 907;
			BuyPrice = 21769;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ninja Belt)
*
***************************************************************/

namespace Server.Items
{
	public class NinjaBelt : Item
	{
		public NinjaBelt() : base()
		{
			Id = 7948;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 1121;
			AvailableClasses = 0x7FFF;
			Model = 16131;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ninja Belt";
			Name2 = "Ninja Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5609;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Heraldic Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicBelt : Item
	{
		public HeraldicBelt() : base()
		{
			Id = 8116;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 4632;
			AvailableClasses = 0x7FFF;
			Model = 16920;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Heraldic Belt";
			Name2 = "Heraldic Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23160;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinGirdle : Item
	{
		public SerpentskinGirdle() : base()
		{
			Id = 8255;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 6010;
			AvailableClasses = 0x7FFF;
			Model = 15411;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Serpentskin Girdle";
			Name2 = "Serpentskin Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30052;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 7;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Traveler's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersBelt : Item
	{
		public TravelersBelt() : base()
		{
			Id = 8293;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 8542;
			AvailableClasses = 0x7FFF;
			Model = 17318;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Traveler's Belt";
			Name2 = "Traveler's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42713;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Vinehedge Cinch)
*
***************************************************************/

namespace Server.Items
{
	public class VinehedgeCinch : Item
	{
		public VinehedgeCinch() : base()
		{
			Id = 9657;
			Resistance[0] = 74;
			Bonding = 1;
			SellPrice = 5333;
			AvailableClasses = 0x7FFF;
			Model = 28426;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			Name = "Vinehedge Cinch";
			Name2 = "Vinehedge Cinch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26669;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 14;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Leather Chef's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LeatherChefsBelt : Item
	{
		public LeatherChefsBelt() : base()
		{
			Id = 9682;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 3831;
			AvailableClasses = 0x7FFF;
			Model = 28284;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			Name = "Leather Chef's Belt";
			Name2 = "Leather Chef's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19159;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 3;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Grappler's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GrapplersBelt : Item
	{
		public GrapplersBelt() : base()
		{
			Id = 9687;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 1554;
			AvailableClasses = 0x7FFF;
			Model = 28328;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			Name = "Grappler's Belt";
			Name2 = "Grappler's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7771;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Tharg's Shoelace)
*
***************************************************************/

namespace Server.Items
{
	public class ThargsShoelace : Item
	{
		public ThargsShoelace() : base()
		{
			Id = 9705;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 3586;
			AvailableClasses = 0x7FFF;
			Model = 17231;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			Name = "Tharg's Shoelace";
			Name2 = "Tharg's Shoelace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17930;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Gypsy Sash)
*
***************************************************************/

namespace Server.Items
{
	public class GypsySash : Item
	{
		public GypsySash() : base()
		{
			Id = 9750;
			Resistance[0] = 33;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 19034;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Gypsy Sash";
			Name2 = "Gypsy Sash";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 287;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bandit Cinch)
*
***************************************************************/

namespace Server.Items
{
	public class BanditCinch : Item
	{
		public BanditCinch() : base()
		{
			Id = 9775;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 315;
			AvailableClasses = 0x7FFF;
			Model = 28177;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Bandit Cinch";
			Name2 = "Bandit Cinch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 898;
			BuyPrice = 1579;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Superior Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorBelt : Item
	{
		public SuperiorBelt() : base()
		{
			Id = 9801;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 708;
			AvailableClasses = 0x7FFF;
			Model = 6760;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Superior Belt";
			Name2 = "Superior Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 900;
			BuyPrice = 3542;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherBelt : Item
	{
		public ScaledLeatherBelt() : base()
		{
			Id = 9827;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 1114;
			AvailableClasses = 0x7FFF;
			Model = 14936;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Scaled Leather Belt";
			Name2 = "Scaled Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 901;
			BuyPrice = 5570;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Archer's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersBelt : Item
	{
		public ArchersBelt() : base()
		{
			Id = 9855;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 1895;
			AvailableClasses = 0x7FFF;
			Model = 11956;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Archer's Belt";
			Name2 = "Archer's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 903;
			BuyPrice = 9475;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansBelt : Item
	{
		public HuntsmansBelt() : base()
		{
			Id = 9891;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 2636;
			AvailableClasses = 0x7FFF;
			Model = 17129;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Huntsman's Belt";
			Name2 = "Huntsman's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 904;
			BuyPrice = 13181;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Tracker's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersBelt : Item
	{
		public TrackersBelt() : base()
		{
			Id = 9916;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 3566;
			AvailableClasses = 0x7FFF;
			Model = 17115;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Tracker's Belt";
			Name2 = "Tracker's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 906;
			BuyPrice = 17834;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsBelt : Item
	{
		public ChieftainsBelt() : base()
		{
			Id = 9947;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 5193;
			AvailableClasses = 0x7FFF;
			Model = 14702;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Chieftain's Belt";
			Name2 = "Chieftain's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 907;
			BuyPrice = 25965;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Righteous Waistguard)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousWaistguard : Item
	{
		public RighteousWaistguard() : base()
		{
			Id = 10067;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 5295;
			AvailableClasses = 0x7FFF;
			Model = 19019;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Righteous Waistguard";
			Name2 = "Righteous Waistguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 908;
			BuyPrice = 26478;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersBelt : Item
	{
		public WanderersBelt() : base()
		{
			Id = 10109;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 7273;
			AvailableClasses = 0x7FFF;
			Model = 27717;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Wanderer's Belt";
			Name2 = "Wanderer's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 909;
			BuyPrice = 36366;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Mighty Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class MightyGirdle : Item
	{
		public MightyGirdle() : base()
		{
			Id = 10145;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 9755;
			AvailableClasses = 0x7FFF;
			Model = 18974;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Mighty Girdle";
			Name2 = "Mighty Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 911;
			BuyPrice = 48779;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersBelt : Item
	{
		public SwashbucklersBelt() : base()
		{
			Id = 10190;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 6669;
			AvailableClasses = 0x7FFF;
			Model = 19001;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Swashbuckler's Belt";
			Name2 = "Swashbuckler's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 909;
			BuyPrice = 33349;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nightshade Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeGirdle : Item
	{
		public NightshadeGirdle() : base()
		{
			Id = 10221;
			Resistance[0] = 84;
			Bonding = 2;
			SellPrice = 9148;
			AvailableClasses = 0x7FFF;
			Model = 18980;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Nightshade Girdle";
			Name2 = "Nightshade Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 911;
			BuyPrice = 45742;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersBelt : Item
	{
		public AdventurersBelt() : base()
		{
			Id = 10259;
			Resistance[0] = 89;
			Bonding = 2;
			SellPrice = 11335;
			AvailableClasses = 0x7FFF;
			Model = 27846;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Adventurer's Belt";
			Name2 = "Adventurer's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 912;
			BuyPrice = 56679;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Blackened Defias Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedDefiasBelt : Item
	{
		public BlackenedDefiasBelt() : base()
		{
			Id = 10403;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 451;
			AvailableClasses = 0x7FFF;
			Model = 14389;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Blackened Defias Belt";
			Name2 = "Blackened Defias Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2255;
			Sets = 161;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Belt of the Fang)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfTheFang : Item
	{
		public BeltOfTheFang() : base()
		{
			Id = 10412;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 405;
			AvailableClasses = 0x7FFF;
			Model = 28384;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Belt of the Fang";
			Name2 = "Belt of the Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2028;
			Sets = 162;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StaminaBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Gnomish Harm Prevention Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishHarmPreventionBelt : Item
	{
		public GnomishHarmPreventionBelt() : base()
		{
			Id = 10721;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 3317;
			AvailableClasses = 0x7FFF;
			Model = 14832;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			Name = "Gnomish Harm Prevention Belt";
			Name2 = "Gnomish Harm Prevention Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 215;
			Skill = 202;
			BuyPrice = 16587;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 13234 , 0 , 0 , 3600000 , 28 , 300000 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Girdle of Beastial Fury)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfBeastialFury : Item
	{
		public GirdleOfBeastialFury() : base()
		{
			Id = 11686;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 9329;
			AvailableClasses = 0x7FFF;
			Model = 28763;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Girdle of Beastial Fury";
			Name2 = "Girdle of Beastial Fury";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46645;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 8;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Nagmara's Whipping Belt)
*
***************************************************************/

namespace Server.Items
{
	public class NagmarasWhippingBelt : Item
	{
		public NagmarasWhippingBelt() : base()
		{
			Id = 11866;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 9819;
			AvailableClasses = 0x7FFF;
			Model = 28219;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			Name = "Nagmara's Whipping Belt";
			Name2 = "Nagmara's Whipping Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49098;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 13;
			StaminaBonus = 14;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Excavator's Utility Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ExcavatorsUtilityBelt : Item
	{
		public ExcavatorsUtilityBelt() : base()
		{
			Id = 11909;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 8267;
			AvailableClasses = 0x7FFF;
			Model = 17121;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			Name = "Excavator's Utility Belt";
			Name2 = "Excavator's Utility Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41337;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Crystallized Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class CrystallizedGirdle : Item
	{
		public CrystallizedGirdle() : base()
		{
			Id = 12606;
			Resistance[0] = 97;
			Bonding = 1;
			SellPrice = 12668;
			AvailableClasses = 0x7FFF;
			Model = 22837;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Crystallized Girdle";
			Name2 = "Crystallized Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 63340;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 6;
			SpiritBonus = 22;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Silver-lined Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SilverLinedBelt : Item
	{
		public SilverLinedBelt() : base()
		{
			Id = 13011;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 1031;
			AvailableClasses = 0x7FFF;
			Model = 28372;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Silver-lined Belt";
			Name2 = "Silver-lined Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5155;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SpiritBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ogron's Sash)
*
***************************************************************/

namespace Server.Items
{
	public class OgronsSash : Item
	{
		public OgronsSash() : base()
		{
			Id = 13117;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 3830;
			AvailableClasses = 0x7FFF;
			Model = 28802;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Ogron's Sash";
			Name2 = "Ogron's Sash";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19152;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StrBonus = 9;
			AgilityBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Serpentine Sash)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentineSash : Item
	{
		public SerpentineSash() : base()
		{
			Id = 13118;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 10601;
			AvailableClasses = 0x7FFF;
			Model = 28369;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Serpentine Sash";
			Name2 = "Serpentine Sash";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53007;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 14;
			AgilityBonus = 14;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Cloudrunner Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class CloudrunnerGirdle : Item
	{
		public CloudrunnerGirdle() : base()
		{
			Id = 13252;
			Resistance[0] = 185;
			Bonding = 1;
			SellPrice = 12434;
			AvailableClasses = 0x7FFF;
			Model = 23844;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Cloudrunner Girdle";
			Name2 = "Cloudrunner Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62170;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 15;
			StrBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Flamescarred Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class FlamescarredGirdle : Item
	{
		public FlamescarredGirdle() : base()
		{
			Id = 13526;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 10897;
			AvailableClasses = 0x7FFF;
			Model = 24178;
			Resistance[2] = 20;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Flamescarred Girdle";
			Name2 = "Flamescarred Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54485;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Vosh'gajin's Strand)
*
***************************************************************/

namespace Server.Items
{
	public class VoshgajinsStrand : Item
	{
		public VoshgajinsStrand() : base()
		{
			Id = 13962;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 12064;
			AvailableClasses = 0x7FFF;
			Model = 30391;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			Name = "Vosh'gajin's Strand";
			Name2 = "Vosh'gajin's Strand";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60324;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Frostbite Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class FrostbiteGirdle : Item
	{
		public FrostbiteGirdle() : base()
		{
			Id = 14502;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 13051;
			AvailableClasses = 0x7FFF;
			Model = 28757;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Frostbite Girdle";
			Name2 = "Frostbite Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65259;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StrBonus = 5;
			AgilityBonus = 15;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Sash of Mercy)
*
***************************************************************/

namespace Server.Items
{
	public class SashOfMercy : Item
	{
		public SashOfMercy() : base()
		{
			Id = 14553;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 17733;
			AvailableClasses = 0x7FFF;
			Model = 28386;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Sash of Mercy";
			Name2 = "Sash of Mercy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88667;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 15696 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 10;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Prospector's Sash)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsSash : Item
	{
		public ProspectorsSash() : base()
		{
			Id = 14559;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 279;
			AvailableClasses = 0x7FFF;
			Model = 27520;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Prospector's Sash";
			Name2 = "Prospector's Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1398;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBelt : Item
	{
		public BristlebarkBelt() : base()
		{
			Id = 14567;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 529;
			AvailableClasses = 0x7FFF;
			Model = 27668;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Bristlebark Belt";
			Name2 = "Bristlebark Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2648;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dokebi Cord)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiCord : Item
	{
		public DokebiCord() : base()
		{
			Id = 14578;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 983;
			AvailableClasses = 0x7FFF;
			Model = 27963;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Dokebi Cord";
			Name2 = "Dokebi Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4916;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 6;
			SpiritBonus = 4;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Cord)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesCord : Item
	{
		public HawkeyesCord() : base()
		{
			Id = 14588;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 1989;
			AvailableClasses = 0x7FFF;
			Model = 27976;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Hawkeye's Cord";
			Name2 = "Hawkeye's Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9947;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 6;
			StrBonus = 4;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warden's Waistband)
*
***************************************************************/

namespace Server.Items
{
	public class WardensWaistband : Item
	{
		public WardensWaistband() : base()
		{
			Id = 14598;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 2655;
			AvailableClasses = 0x7FFF;
			Model = 27983;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Warden's Waistband";
			Name2 = "Warden's Waistband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13275;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
			IqBonus = 4;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cadaverous Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CadaverousBelt : Item
	{
		public CadaverousBelt() : base()
		{
			Id = 14636;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 10396;
			AvailableClasses = 0x7FFF;
			Model = 25248;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Cadaverous Belt";
			Name2 = "Cadaverous Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51983;
			Sets = 121;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 10;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Sash)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiSash : Item
	{
		public ScorpashiSash() : base()
		{
			Id = 14652;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 4215;
			AvailableClasses = 0x7FFF;
			Model = 27579;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Scorpashi Sash";
			Name2 = "Scorpashi Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21079;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 10;
			StaminaBonus = 7;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Keeper's Cord)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersCord : Item
	{
		public KeepersCord() : base()
		{
			Id = 14661;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 5461;
			AvailableClasses = 0x7FFF;
			Model = 27566;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Keeper's Cord";
			Name2 = "Keeper's Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27305;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 9;
			SpiritBonus = 7;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Pridelord Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordGirdle : Item
	{
		public PridelordGirdle() : base()
		{
			Id = 14674;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 8270;
			AvailableClasses = 0x7FFF;
			Model = 27579;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Pridelord Girdle";
			Name2 = "Pridelord Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41353;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 4;
			AgilityBonus = 12;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Indomitable Belt)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableBelt : Item
	{
		public IndomitableBelt() : base()
		{
			Id = 14684;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 10477;
			AvailableClasses = 0x7FFF;
			Model = 15411;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Indomitable Belt";
			Name2 = "Indomitable Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52389;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Primal Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalBelt : Item
	{
		public PrimalBelt() : base()
		{
			Id = 15003;
			Resistance[0] = 25;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 28007;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Primal Belt";
			Name2 = "Primal Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Lupine Cord)
*
***************************************************************/

namespace Server.Items
{
	public class LupineCord : Item
	{
		public LupineCord() : base()
		{
			Id = 15011;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 183;
			AvailableClasses = 0x7FFF;
			Model = 27668;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Lupine Cord";
			Name2 = "Lupine Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 896;
			BuyPrice = 919;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wicked Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WickedLeatherBelt : Item
	{
		public WickedLeatherBelt() : base()
		{
			Id = 15088;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 9901;
			AvailableClasses = 0x7FFF;
			Model = 25728;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Wicked Leather Belt";
			Name2 = "Wicked Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49508;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 14;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Runic Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RunicLeatherBelt : Item
	{
		public RunicLeatherBelt() : base()
		{
			Id = 15093;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 8368;
			AvailableClasses = 0x7FFF;
			Model = 25737;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Runic Leather Belt";
			Name2 = "Runic Leather Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41843;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 14;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Rigid Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RigidBelt : Item
	{
		public RigidBelt() : base()
		{
			Id = 15110;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 351;
			AvailableClasses = 0x7FFF;
			Model = 27880;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Rigid Belt";
			Name2 = "Rigid Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 898;
			BuyPrice = 1758;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Robust Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class RobustGirdle : Item
	{
		public RobustGirdle() : base()
		{
			Id = 15120;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 786;
			AvailableClasses = 0x7FFF;
			Model = 27887;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Robust Girdle";
			Name2 = "Robust Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 900;
			BuyPrice = 3934;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsBelt : Item
	{
		public CutthroatsBelt() : base()
		{
			Id = 15136;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 1248;
			AvailableClasses = 0x7FFF;
			Model = 27708;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Cutthroat's Belt";
			Name2 = "Cutthroat's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 902;
			BuyPrice = 6244;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerBelt : Item
	{
		public GhostwalkerBelt() : base()
		{
			Id = 15148;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 1613;
			AvailableClasses = 0x7FFF;
			Model = 27684;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Ghostwalker Belt";
			Name2 = "Ghostwalker Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 903;
			BuyPrice = 8069;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Sash)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalSash : Item
	{
		public NocturnalSash() : base()
		{
			Id = 15154;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 2372;
			AvailableClasses = 0x7FFF;
			Model = 27724;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Nocturnal Sash";
			Name2 = "Nocturnal Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 904;
			BuyPrice = 11860;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Imposing Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingBelt : Item
	{
		public ImposingBelt() : base()
		{
			Id = 15161;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 3319;
			AvailableClasses = 0x7FFF;
			Model = 18980;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Imposing Belt";
			Name2 = "Imposing Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 906;
			BuyPrice = 16596;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Potent Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PotentBelt : Item
	{
		public PotentBelt() : base()
		{
			Id = 15178;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 4935;
			AvailableClasses = 0x7FFF;
			Model = 27590;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Potent Belt";
			Name2 = "Potent Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 907;
			BuyPrice = 24679;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Praetorian Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianGirdle : Item
	{
		public PraetorianGirdle() : base()
		{
			Id = 15180;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 6686;
			AvailableClasses = 0x7FFF;
			Model = 27560;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Praetorian Girdle";
			Name2 = "Praetorian Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 909;
			BuyPrice = 33433;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grand Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GrandBelt : Item
	{
		public GrandBelt() : base()
		{
			Id = 15191;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 9034;
			AvailableClasses = 0x7FFF;
			Model = 18980;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Grand Belt";
			Name2 = "Grand Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 910;
			BuyPrice = 45174;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grizzly Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyBelt : Item
	{
		public GrizzlyBelt() : base()
		{
			Id = 15302;
			Resistance[0] = 31;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 28012;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Grizzly Belt";
			Name2 = "Grizzly Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 237;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Feral Cord)
*
***************************************************************/

namespace Server.Items
{
	public class FeralCord : Item
	{
		public FeralCord() : base()
		{
			Id = 15308;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 241;
			AvailableClasses = 0x7FFF;
			Model = 17114;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Feral Cord";
			Name2 = "Feral Cord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 897;
			BuyPrice = 1208;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersBelt : Item
	{
		public WranglersBelt() : base()
		{
			Id = 15329;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 622;
			AvailableClasses = 0x7FFF;
			Model = 27998;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Wrangler's Belt";
			Name2 = "Wrangler's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 899;
			BuyPrice = 3114;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderBelt : Item
	{
		public PathfinderBelt() : base()
		{
			Id = 15347;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 955;
			AvailableClasses = 0x7FFF;
			Model = 27674;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Pathfinder Belt";
			Name2 = "Pathfinder Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 901;
			BuyPrice = 4777;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersBelt : Item
	{
		public HeadhuntersBelt() : base()
		{
			Id = 15349;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 1549;
			AvailableClasses = 0x7FFF;
			Model = 11953;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Headhunter's Belt";
			Name2 = "Headhunter's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 902;
			BuyPrice = 7749;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Trickster's Sash)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersSash : Item
	{
		public TrickstersSash() : base()
		{
			Id = 15361;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 2204;
			AvailableClasses = 0x7FFF;
			Model = 27958;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Trickster's Sash";
			Name2 = "Trickster's Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 904;
			BuyPrice = 11024;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersBelt : Item
	{
		public WolfRidersBelt() : base()
		{
			Id = 15369;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 3097;
			AvailableClasses = 0x7FFF;
			Model = 17231;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Wolf Rider's Belt";
			Name2 = "Wolf Rider's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 905;
			BuyPrice = 15486;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Belt)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawBelt : Item
	{
		public RageclawBelt() : base()
		{
			Id = 15378;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 4358;
			AvailableClasses = 0x7FFF;
			Model = 14702;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Rageclaw Belt";
			Name2 = "Rageclaw Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 907;
			BuyPrice = 21793;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Jadefire Belt)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireBelt : Item
	{
		public JadefireBelt() : base()
		{
			Id = 15388;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 6357;
			AvailableClasses = 0x7FFF;
			Model = 27654;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Jadefire Belt";
			Name2 = "Jadefire Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 909;
			BuyPrice = 31785;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dryweed Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DryweedBelt : Item
	{
		public DryweedBelt() : base()
		{
			Id = 15399;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 151;
			AvailableClasses = 0x7FFF;
			Model = 28149;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			Name = "Dryweed Belt";
			Name2 = "Dryweed Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 755;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Peerless Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessBelt : Item
	{
		public PeerlessBelt() : base()
		{
			Id = 15428;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 8024;
			AvailableClasses = 0x7FFF;
			Model = 28030;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Peerless Belt";
			Name2 = "Peerless Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 910;
			BuyPrice = 40120;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Supreme Sash)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeSash : Item
	{
		public SupremeSash() : base()
		{
			Id = 15434;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 10964;
			AvailableClasses = 0x7FFF;
			Model = 27616;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Supreme Sash";
			Name2 = "Supreme Sash";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 912;
			BuyPrice = 54823;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Windsong Cinch)
*
***************************************************************/

namespace Server.Items
{
	public class WindsongCinch : Item
	{
		public WindsongCinch() : base()
		{
			Id = 15469;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 1009;
			AvailableClasses = 0x7FFF;
			Model = 28302;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			Name = "Windsong Cinch";
			Name2 = "Windsong Cinch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5048;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ringtail Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class RingtailGirdle : Item
	{
		public RingtailGirdle() : base()
		{
			Id = 15587;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 1822;
			AvailableClasses = 0x7FFF;
			Model = 28292;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			Name = "Ringtail Girdle";
			Name2 = "Ringtail Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9110;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Aquarius Belt)
*
***************************************************************/

namespace Server.Items
{
	public class AquariusBelt : Item
	{
		public AquariusBelt() : base()
		{
			Id = 16608;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 193;
			AvailableClasses = 0x400;
			Model = 16947;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			Name = "Aquarius Belt";
			Name2 = "Aquarius Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 969;
			InventoryType = InventoryTypes.Waist;
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
*				(Deftkin Belt)
*
***************************************************************/

namespace Server.Items
{
	public class DeftkinBelt : Item
	{
		public DeftkinBelt() : base()
		{
			Id = 16659;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 856;
			AvailableClasses = 0x7FFF;
			Model = 28270;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Deftkin Belt";
			Name2 = "Deftkin Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4282;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftBelt : Item
	{
		public ShadowcraftBelt() : base()
		{
			Id = 16713;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 11196;
			AvailableClasses = 0x7FFF;
			Model = 28177;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Shadowcraft Belt";
			Name2 = "Shadowcraft Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55984;
			Sets = 184;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 14;
			StaminaBonus = 10;
			IqBonus = 9;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Wildheart Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartBelt : Item
	{
		public WildheartBelt() : base()
		{
			Id = 16716;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 11620;
			AvailableClasses = 0x7FFF;
			Model = 29976;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Wildheart Belt";
			Name2 = "Wildheart Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58104;
			Sets = 185;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SpiritBonus = 17;
			IqBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Belt)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerBelt : Item
	{
		public NightslayerBelt() : base()
		{
			Id = 16827;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 22139;
			AvailableClasses = 0x08;
			Model = 31339;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Belt";
			Name2 = "Nightslayer Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 110698;
			Sets = 204;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 17;
			StaminaBonus = 18;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Cenarion Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionBelt : Item
	{
		public CenarionBelt() : base()
		{
			Id = 16828;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 22221;
			AvailableClasses = 0x400;
			Model = 31722;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Belt";
			Name2 = "Cenarion Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 111109;
			Sets = 205;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 22;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stormrage Belt)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageBelt : Item
	{
		public StormrageBelt() : base()
		{
			Id = 16903;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 36472;
			AvailableClasses = 0x400;
			Model = 4503;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Belt";
			Name2 = "Stormrage Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 182361;
			Sets = 214;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 25;
			IqBonus = 12;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangBelt : Item
	{
		public BloodfangBelt() : base()
		{
			Id = 16910;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 34738;
			AvailableClasses = 0x08;
			Model = 29747;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Belt";
			Name2 = "Bloodfang Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 173692;
			Sets = 213;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			StaminaBonus = 15;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Screecher Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ScreecherBelt : Item
	{
		public ScreecherBelt() : base()
		{
			Id = 16987;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 884;
			AvailableClasses = 0x7FFF;
			Model = 28767;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Screecher Belt";
			Name2 = "Screecher Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4422;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 5;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sagebrush Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class SagebrushGirdle : Item
	{
		public SagebrushGirdle() : base()
		{
			Id = 17778;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 4506;
			AvailableClasses = 0x7FFF;
			Model = 29954;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			Name = "Sagebrush Girdle";
			Name2 = "Sagebrush Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22532;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Eyestalk Cord)
*
***************************************************************/

namespace Server.Items
{
	public class EyestalkCord : Item
	{
		public EyestalkCord() : base()
		{
			Id = 18391;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 13076;
			AvailableClasses = 0x7FFF;
			Model = 30749;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Eyestalk Cord";
			Name2 = "Eyestalk Cord";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65383;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hyena Hide Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HyenaHideBelt : Item
	{
		public HyenaHideBelt() : base()
		{
			Id = 18451;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 9884;
			AvailableClasses = 0x7FFF;
			Model = 30803;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Hyena Hide Belt";
			Name2 = "Hyena Hide Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49420;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Girdle of Insight)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfInsight : Item
	{
		public GirdleOfInsight() : base()
		{
			Id = 18504;
			Resistance[0] = 98;
			Bonding = 2;
			SellPrice = 14126;
			AvailableClasses = 0x7FFF;
			Model = 30839;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Girdle of Insight";
			Name2 = "Girdle of Insight";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70634;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SpiritBonus = 23;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Mugger's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class MuggersBelt : Item
	{
		public MuggersBelt() : base()
		{
			Id = 18505;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 13076;
			AvailableClasses = 0x7FFF;
			Model = 30838;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Mugger's Belt";
			Name2 = "Mugger's Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65383;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7576 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Might of the Timbermaw)
*
***************************************************************/

namespace Server.Items
{
	public class MightOfTheTimbermaw : Item
	{
		public MightOfTheTimbermaw() : base()
		{
			Id = 19044;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 11116;
			AvailableClasses = 0x7FFF;
			Model = 31542;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Might of the Timbermaw";
			Name2 = "Might of the Timbermaw";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55584;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = -1;
			Durability = 35;
			StrBonus = 21;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Leather Belt)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfLeatherBelt : Item
	{
		public FrostwolfLeatherBelt() : base()
		{
			Id = 19089;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 11860;
			AvailableClasses = 0x7FFF;
			Model = 30839;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Leather Belt";
			Name2 = "Frostwolf Leather Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59304;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			AgilityBonus = 10;
			StaminaBonus = 15;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Stormpike Leather Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeLeatherGirdle : Item
	{
		public StormpikeLeatherGirdle() : base()
		{
			Id = 19093;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 11860;
			AvailableClasses = 0x7FFF;
			Model = 31601;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Leather Girdle";
			Name2 = "Stormpike Leather Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59304;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			AgilityBonus = 10;
			StaminaBonus = 15;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Flayed Doomguard Belt)
*
***************************************************************/

namespace Server.Items
{
	public class FlayedDoomguardBelt : Item
	{
		public FlayedDoomguardBelt() : base()
		{
			Id = 19134;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 23365;
			AvailableClasses = 0x7FFF;
			Model = 31652;
			ObjectClass = 4;
			SubClass = 2;
			Level = 68;
			ReqLevel = 60;
			Name = "Flayed Doomguard Belt";
			Name2 = "Flayed Doomguard Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 116827;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Lava Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LavaBelt : Item
	{
		public LavaBelt() : base()
		{
			Id = 19149;
			Resistance[0] = 223;
			Bonding = 2;
			SellPrice = 21248;
			AvailableClasses = 0x7FFF;
			Model = 31672;
			Resistance[2] = 26;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Lava Belt";
			Name2 = "Lava Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 106243;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Corehound Belt)
*
***************************************************************/

namespace Server.Items
{
	public class CorehoundBelt : Item
	{
		public CorehoundBelt() : base()
		{
			Id = 19162;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 27831;
			AvailableClasses = 0x7FFF;
			Model = 31681;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 2;
			Level = 70;
			ReqLevel = 60;
			Name = "Corehound Belt";
			Name2 = "Corehound Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139159;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 18039 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Molten Belt)
*
***************************************************************/

namespace Server.Items
{
	public class MoltenBelt : Item
	{
		public MoltenBelt() : base()
		{
			Id = 19163;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 27931;
			AvailableClasses = 0x7FFF;
			Model = 31682;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 2;
			Level = 70;
			ReqLevel = 60;
			Name = "Molten Belt";
			Name2 = "Molten Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139659;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			AgilityBonus = 28;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Taut Dragonhide Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TautDragonhideBelt : Item
	{
		public TautDragonhideBelt() : base()
		{
			Id = 19396;
			Resistance[0] = 125;
			Bonding = 1;
			SellPrice = 33084;
			AvailableClasses = 0x7FFF;
			Description = "The flesh from different dragon flights has been sewn together to make this belt.";
			Model = 31927;
			ObjectClass = 4;
			SubClass = 2;
			Level = 75;
			ReqLevel = 60;
			Name = "Taut Dragonhide Belt";
			Name2 = "Taut Dragonhide Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 165421;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 14052 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
		}
	}
}


