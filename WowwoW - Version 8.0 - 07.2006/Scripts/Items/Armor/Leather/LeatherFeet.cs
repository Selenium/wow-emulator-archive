/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:22 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Dirty Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherBoots : Item
	{
		public DirtyLeatherBoots() : base()
		{
			Id = 210;
			Resistance[0] = 23;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 14444;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Boots";
			Name2 = "Dirty Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cured Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherBoots : Item
	{
		public CuredLeatherBoots() : base()
		{
			Id = 238;
			Resistance[0] = 53;
			SellPrice = 422;
			AvailableClasses = 0x7FFF;
			Model = 14474;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Boots";
			Name2 = "Cured Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2112;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherBoots : Item
	{
		public RoughLeatherBoots() : base()
		{
			Id = 796;
			Resistance[0] = 36;
			SellPrice = 52;
			AvailableClasses = 0x7FFF;
			Model = 22973;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Boots";
			Name2 = "Rough Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 264;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherBoots : Item
	{
		public TannedLeatherBoots() : base()
		{
			Id = 843;
			Resistance[0] = 48;
			SellPrice = 215;
			AvailableClasses = 0x7FFF;
			Model = 14470;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Boots";
			Name2 = "Tanned Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1077;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Feet of the Lynx)
*
***************************************************************/

namespace Server.Items
{
	public class FeetOfTheLynx : Item
	{
		public FeetOfTheLynx() : base()
		{
			Id = 1121;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 1075;
			AvailableClasses = 0x7FFF;
			Model = 703;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Feet of the Lynx";
			Name2 = "Feet of the Lynx";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5375;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Weather-worn Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WeatherWornBoots : Item
	{
		public WeatherWornBoots() : base()
		{
			Id = 1173;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 52;
			AvailableClasses = 0x7FFF;
			Model = 6777;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			Name = "Weather-worn Boots";
			Name2 = "Weather-worn Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 262;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherBoots : Item
	{
		public RaggedLeatherBoots() : base()
		{
			Id = 1367;
			Resistance[0] = 16;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 14354;
			ObjectClass = 4;
			SubClass = 2;
			Level = 3;
			ReqLevel = 1;
			Name = "Ragged Leather Boots";
			Name2 = "Ragged Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 14;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherBoots : Item
	{
		public WornLeatherBoots() : base()
		{
			Id = 1419;
			Resistance[0] = 29;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 14353;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Worn Leather Boots";
			Name2 = "Worn Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 98;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherBoots : Item
	{
		public WarpedLeatherBoots() : base()
		{
			Id = 1503;
			Resistance[0] = 43;
			SellPrice = 109;
			AvailableClasses = 0x7FFF;
			Model = 14846;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Warped Leather Boots";
			Name2 = "Warped Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 546;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherBoots : Item
	{
		public PatchedLeatherBoots() : base()
		{
			Id = 1788;
			Resistance[0] = 47;
			SellPrice = 176;
			AvailableClasses = 0x7FFF;
			Model = 16990;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Patched Leather Boots";
			Name2 = "Patched Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 884;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Rawhide Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideBoots : Item
	{
		public RawhideBoots() : base()
		{
			Id = 1796;
			Resistance[0] = 53;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 16992;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Rawhide Boots";
			Name2 = "Rawhide Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 2001;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherBoots : Item
	{
		public ToughLeatherBoots() : base()
		{
			Id = 1804;
			Resistance[0] = 54;
			SellPrice = 478;
			AvailableClasses = 0x7FFF;
			Model = 16998;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Tough Leather Boots";
			Name2 = "Tough Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 2391;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Ambassador's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AmbassadorsBoots : Item
	{
		public AmbassadorsBoots() : base()
		{
			Id = 2033;
			Resistance[0] = 59;
			Bonding = 1;
			SellPrice = 967;
			AvailableClasses = 0x7FFF;
			Model = 10711;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Ambassador's Boots";
			Name2 = "Ambassador's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4836;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			AgilityBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherBoots : Item
	{
		public CrackedLeatherBoots() : base()
		{
			Id = 2123;
			Resistance[0] = 23;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 14426;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Boots";
			Name2 = "Cracked Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliBoots : Item
	{
		public CuirboulliBoots() : base()
		{
			Id = 2143;
			Resistance[0] = 58;
			SellPrice = 788;
			AvailableClasses = 0x7FFF;
			Model = 2355;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Boots";
			Name2 = "Cuirboulli Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3944;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Swampwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SwampwalkerBoots : Item
	{
		public SwampwalkerBoots() : base()
		{
			Id = 2276;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 4093;
			AvailableClasses = 0x7FFF;
			Model = 16996;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Swampwalker Boots";
			Name2 = "Swampwalker Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20466;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 13;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Handstitched Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherBoots : Item
	{
		public HandstitchedLeatherBoots() : base()
		{
			Id = 2302;
			Resistance[0] = 31;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 4713;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Handstitched Leather Boots";
			Name2 = "Handstitched Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 147;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherBoots : Item
	{
		public FineLeatherBoots() : base()
		{
			Id = 2307;
			Resistance[0] = 49;
			SellPrice = 243;
			AvailableClasses = 0x7FFF;
			Model = 17163;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Fine Leather Boots";
			Name2 = "Fine Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1216;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Embossed Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedLeatherBoots : Item
	{
		public EmbossedLeatherBoots() : base()
		{
			Id = 2309;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 268;
			AvailableClasses = 0x7FFF;
			Model = 13864;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Embossed Leather Boots";
			Name2 = "Embossed Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1343;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherBoots : Item
	{
		public DarkLeatherBoots() : base()
		{
			Id = 2315;
			Resistance[0] = 51;
			SellPrice = 307;
			AvailableClasses = 0x7FFF;
			Model = 9530;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Dark Leather Boots";
			Name2 = "Dark Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1538;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherBoots : Item
	{
		public BatteredLeatherBoots() : base()
		{
			Id = 2373;
			Resistance[0] = 36;
			SellPrice = 51;
			AvailableClasses = 0x7FFF;
			Model = 17158;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Boots";
			Name2 = "Battered Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 259;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Studded Boots)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedBoots : Item
	{
		public StuddedBoots() : base()
		{
			Id = 2467;
			Resistance[0] = 68;
			SellPrice = 1886;
			AvailableClasses = 0x7FFF;
			Model = 17165;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Boots";
			Name2 = "Studded Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9430;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherBoots : Item
	{
		public ReinforcedLeatherBoots() : base()
		{
			Id = 2473;
			Resistance[0] = 86;
			SellPrice = 5150;
			AvailableClasses = 0x7FFF;
			Model = 14295;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Boots";
			Name2 = "Reinforced Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25753;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Mariner Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarinerBoots : Item
	{
		public MarinerBoots() : base()
		{
			Id = 2949;
			Resistance[0] = 59;
			Bonding = 1;
			SellPrice = 1039;
			AvailableClasses = 0x7FFF;
			Model = 16989;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Mariner Boots";
			Name2 = "Mariner Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5196;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StaminaBonus = 6;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherBoots : Item
	{
		public BurntLeatherBoots() : base()
		{
			Id = 2963;
			Resistance[0] = 34;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 16980;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Burnt Leather Boots";
			Name2 = "Burnt Leather Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 208;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Hunting Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingBoots : Item
	{
		public HuntingBoots() : base()
		{
			Id = 2975;
			Resistance[0] = 45;
			SellPrice = 128;
			AvailableClasses = 0x7FFF;
			Model = 14534;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Hunting Boots";
			Name2 = "Hunting Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 642;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherBoots : Item
	{
		public InscribedLeatherBoots() : base()
		{
			Id = 2987;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 408;
			AvailableClasses = 0x7FFF;
			Model = 11373;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Inscribed Leather Boots";
			Name2 = "Inscribed Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2043;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Forest Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherBoots : Item
	{
		public ForestLeatherBoots() : base()
		{
			Id = 3057;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 903;
			AvailableClasses = 0x7FFF;
			Model = 16984;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Forest Leather Boots";
			Name2 = "Forest Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4515;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tribal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TribalBoots : Item
	{
		public TribalBoots() : base()
		{
			Id = 3284;
			Resistance[0] = 40;
			SellPrice = 88;
			AvailableClasses = 0x7FFF;
			Model = 27993;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Tribal Boots";
			Name2 = "Tribal Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 444;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Ankleguards)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherAnkleguards : Item
	{
		public CeremonialLeatherAnkleguards() : base()
		{
			Id = 3311;
			Resistance[0] = 45;
			SellPrice = 152;
			AvailableClasses = 0x7FFF;
			Model = 14544;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Ceremonial Leather Ankleguards";
			Name2 = "Ceremonial Leather Ankleguards";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 761;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Gray Fur Booties)
*
***************************************************************/

namespace Server.Items
{
	public class GrayFurBooties : Item
	{
		public GrayFurBooties() : base()
		{
			Id = 3321;
			Resistance[0] = 34;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 4016;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Gray Fur Booties";
			Name2 = "Gray Fur Booties";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 207;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Zombie Skin Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ZombieSkinBoots : Item
	{
		public ZombieSkinBoots() : base()
		{
			Id = 3439;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 3709;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Zombie Skin Boots";
			Name2 = "Zombie Skin Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Stomping Boots)
*
***************************************************************/

namespace Server.Items
{
	public class StompingBoots : Item
	{
		public StompingBoots() : base()
		{
			Id = 3741;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 922;
			AvailableClasses = 0x7FFF;
			Model = 17164;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			Name = "Stomping Boots";
			Name2 = "Stomping Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4614;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hardened Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherBoots : Item
	{
		public HardenedLeatherBoots() : base()
		{
			Id = 3801;
			Resistance[0] = 63;
			SellPrice = 1031;
			AvailableClasses = 0x7FFF;
			Model = 19043;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Hardened Leather Boots";
			Name2 = "Hardened Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 5156;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherBoots : Item
	{
		public ThickLeatherBoots() : base()
		{
			Id = 3962;
			Resistance[0] = 80;
			SellPrice = 3079;
			AvailableClasses = 0x7FFF;
			Model = 18419;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Thick Leather Boots";
			Name2 = "Thick Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 15399;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherBoots : Item
	{
		public SmoothLeatherBoots() : base()
		{
			Id = 3970;
			Resistance[0] = 88;
			SellPrice = 4296;
			AvailableClasses = 0x7FFF;
			Model = 16994;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Smooth Leather Boots";
			Name2 = "Smooth Leather Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 21481;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedBoots : Item
	{
		public EmblazonedBoots() : base()
		{
			Id = 4051;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 1669;
			AvailableClasses = 0x7FFF;
			Model = 17161;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Emblazoned Boots";
			Name2 = "Emblazoned Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8349;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Insignia Boots)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaBoots : Item
	{
		public InsigniaBoots() : base()
		{
			Id = 4055;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 2481;
			AvailableClasses = 0x7FFF;
			Model = 3036;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Insignia Boots";
			Name2 = "Insignia Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12406;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 8;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Excelsior Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ExcelsiorBoots : Item
	{
		public ExcelsiorBoots() : base()
		{
			Id = 4109;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 4393;
			AvailableClasses = 0x7FFF;
			Model = 16983;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			Name = "Excelsior Boots";
			Name2 = "Excelsior Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21966;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 7;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Agile Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AgileBoots : Item
	{
		public AgileBoots() : base()
		{
			Id = 4788;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 526;
			AvailableClasses = 0x7FFF;
			Model = 4024;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Agile Boots";
			Name2 = "Agile Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2633;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Stable Boots)
*
***************************************************************/

namespace Server.Items
{
	public class StableBoots : Item
	{
		public StableBoots() : base()
		{
			Id = 4789;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 399;
			AvailableClasses = 0x7FFF;
			Model = 6777;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Stable Boots";
			Name2 = "Stable Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1998;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Rainwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RainwalkerBoots : Item
	{
		public RainwalkerBoots() : base()
		{
			Id = 4906;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 8308;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			Name = "Rainwalker Boots";
			Name2 = "Rainwalker Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 109;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tiger Hide Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TigerHideBoots : Item
	{
		public TigerHideBoots() : base()
		{
			Id = 4942;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 16997;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			Name = "Tiger Hide Boots";
			Name2 = "Tiger Hide Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 449;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Buckled Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BuckledBoots : Item
	{
		public BuckledBoots() : base()
		{
			Id = 5311;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 601;
			AvailableClasses = 0x7FFF;
			Model = 17159;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			Name = "Buckled Boots";
			Name2 = "Buckled Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3007;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 4;
			SpiritBonus = 2;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Black Whelp Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWhelpBoots : Item
	{
		public BlackWhelpBoots() : base()
		{
			Id = 6092;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 420;
			AvailableClasses = 0x7FFF;
			Model = 16981;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Black Whelp Boots";
			Name2 = "Black Whelp Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2104;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lithe Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LitheBoots : Item
	{
		public LitheBoots() : base()
		{
			Id = 6201;
			Resistance[0] = 36;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 9510;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Lithe Boots";
			Name2 = "Lithe Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 272;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Grizzled Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzledBoots : Item
	{
		public GrizzledBoots() : base()
		{
			Id = 6335;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 1581;
			AvailableClasses = 0x7FFF;
			Model = 11330;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			Name = "Grizzled Boots";
			Name2 = "Grizzled Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7905;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 2;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Glyphed Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedBoots : Item
	{
		public GlyphedBoots() : base()
		{
			Id = 6420;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 3739;
			AvailableClasses = 0x7FFF;
			Model = 14672;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Glyphed Boots";
			Name2 = "Glyphed Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18698;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 10;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherBoots : Item
	{
		public ImperialLeatherBoots() : base()
		{
			Id = 6431;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 5436;
			AvailableClasses = 0x7FFF;
			Model = 16986;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Imperial Leather Boots";
			Name2 = "Imperial Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27181;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 5;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Pioneer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerBoots : Item
	{
		public PioneerBoots() : base()
		{
			Id = 6518;
			Resistance[0] = 38;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 16991;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Pioneer Boots";
			Name2 = "Pioneer Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 351;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Bard's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BardsBoots : Item
	{
		public BardsBoots() : base()
		{
			Id = 6557;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 302;
			AvailableClasses = 0x7FFF;
			Model = 19184;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Bard's Boots";
			Name2 = "Bard's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 813;
			BuyPrice = 1511;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Scouting Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingBoots : Item
	{
		public ScoutingBoots() : base()
		{
			Id = 6582;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 731;
			AvailableClasses = 0x7FFF;
			Model = 14759;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Scouting Boots";
			Name2 = "Scouting Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 815;
			BuyPrice = 3655;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Dervish Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DervishBoots : Item
	{
		public DervishBoots() : base()
		{
			Id = 6601;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 1437;
			AvailableClasses = 0x7FFF;
			Model = 14769;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Dervish Boots";
			Name2 = "Dervish Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 817;
			BuyPrice = 7185;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Draftsman Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DraftsmanBoots : Item
	{
		public DraftsmanBoots() : base()
		{
			Id = 6668;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 1245;
			AvailableClasses = 0x7FFF;
			Model = 12788;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Draftsman Boots";
			Name2 = "Draftsman Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6226;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StrBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Lancer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LancerBoots : Item
	{
		public LancerBoots() : base()
		{
			Id = 6752;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 1601;
			AvailableClasses = 0x7FFF;
			Model = 16988;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Lancer Boots";
			Name2 = "Lancer Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8009;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 5;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dusky Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DuskyBoots : Item
	{
		public DuskyBoots() : base()
		{
			Id = 7390;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 4237;
			AvailableClasses = 0x7FFF;
			Model = 17215;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Dusky Boots";
			Name2 = "Dusky Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21188;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 11;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Swift Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftBoots : Item
	{
		public SwiftBoots() : base()
		{
			Id = 7391;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 4253;
			AvailableClasses = 0x7FFF;
			Model = 28734;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Swift Boots";
			Name2 = "Swift Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21265;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			SetSpell( 9175 , 0 , 0 , 3600000 , 28 , 300000 );
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Boots)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorBoots : Item
	{
		public InfiltratorBoots() : base()
		{
			Id = 7409;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 2289;
			AvailableClasses = 0x7FFF;
			Model = 19043;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Infiltrator Boots";
			Name2 = "Infiltrator Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 818;
			BuyPrice = 11445;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Sentinel Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelBoots : Item
	{
		public SentinelBoots() : base()
		{
			Id = 7444;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 3377;
			AvailableClasses = 0x7FFF;
			Model = 14996;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Sentinel Boots";
			Name2 = "Sentinel Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 820;
			BuyPrice = 16887;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Ranger Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RangerBoots : Item
	{
		public RangerBoots() : base()
		{
			Id = 7481;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 4908;
			AvailableClasses = 0x7FFF;
			Model = 15017;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Ranger Boots";
			Name2 = "Ranger Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 821;
			BuyPrice = 24541;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Cabalist Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistBoots : Item
	{
		public CabalistBoots() : base()
		{
			Id = 7531;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 6434;
			AvailableClasses = 0x7FFF;
			Model = 15412;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Cabalist Boots";
			Name2 = "Cabalist Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 823;
			BuyPrice = 32171;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Vorrel's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class VorrelsBoots : Item
	{
		public VorrelsBoots() : base()
		{
			Id = 7751;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 1614;
			AvailableClasses = 0x7FFF;
			Model = 15886;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Vorrel's Boots";
			Name2 = "Vorrel's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8072;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 2;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Harbinger Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HarbingerBoots : Item
	{
		public HarbingerBoots() : base()
		{
			Id = 7754;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 1959;
			AvailableClasses = 0x7FFF;
			Model = 15889;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Harbinger Boots";
			Name2 = "Harbinger Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9798;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StaminaBonus = 11;
			IqBonus = 3;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ninja Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NinjaBoots : Item
	{
		public NinjaBoots() : base()
		{
			Id = 7952;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 1606;
			AvailableClasses = 0x7FFF;
			Model = 16136;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ninja Boots";
			Name2 = "Ninja Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8032;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Heraldic Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicBoots : Item
	{
		public HeraldicBoots() : base()
		{
			Id = 8117;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 7161;
			AvailableClasses = 0x7FFF;
			Model = 14701;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Heraldic Boots";
			Name2 = "Heraldic Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35808;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 4;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Nightscape Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NightscapeBoots : Item
	{
		public NightscapeBoots() : base()
		{
			Id = 8197;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 7158;
			AvailableClasses = 0x7FFF;
			Model = 16505;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Nightscape Boots";
			Name2 = "Nightscape Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35790;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			SetSpell( 17746 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Wild Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WildLeatherBoots : Item
	{
		public WildLeatherBoots() : base()
		{
			Id = 8213;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 8150;
			AvailableClasses = 0x7FFF;
			Model = 4389;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Wild Leather Boots";
			Name2 = "Wild Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 824;
			BuyPrice = 40753;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinBoots : Item
	{
		public SerpentskinBoots() : base()
		{
			Id = 8256;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 10261;
			AvailableClasses = 0x7FFF;
			Model = 17258;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Serpentskin Boots";
			Name2 = "Serpentskin Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51306;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 7;
			StaminaBonus = 8;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Traveler's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersBoots : Item
	{
		public TravelersBoots() : base()
		{
			Id = 8294;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 12651;
			AvailableClasses = 0x7FFF;
			Model = 17317;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Traveler's Boots";
			Name2 = "Traveler's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63259;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 17;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tromping Miner's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrompingMinersBoots : Item
	{
		public TrompingMinersBoots() : base()
		{
			Id = 9382;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 3607;
			AvailableClasses = 0x7FFF;
			Model = 28734;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Tromping Miner's Boots";
			Name2 = "Tromping Miner's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18039;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Worn Running Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WornRunningBoots : Item
	{
		public WornRunningBoots() : base()
		{
			Id = 9398;
			Resistance[0] = 72;
			SellPrice = 2488;
			AvailableClasses = 0x7FFF;
			Model = 18361;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Worn Running Boots";
			Name2 = "Worn Running Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12441;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 11;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gnomebot Operating Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GnomebotOperatingBoots : Item
	{
		public GnomebotOperatingBoots() : base()
		{
			Id = 9450;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 2181;
			AvailableClasses = 0x7FFF;
			Model = 18367;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Gnomebot Operating Boots";
			Name2 = "Gnomebot Operating Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10908;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 8;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cushioned Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CushionedBoots : Item
	{
		public CushionedBoots() : base()
		{
			Id = 9601;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 28142;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			Name = "Cushioned Boots";
			Name2 = "Cushioned Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 438;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Pratt's Handcrafted Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PrattsHandcraftedBoots : Item
	{
		public PrattsHandcraftedBoots() : base()
		{
			Id = 9630;
			Resistance[0] = 84;
			Bonding = 1;
			SellPrice = 5780;
			AvailableClasses = 0x7FFF;
			Model = 4440;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			Name = "Pratt's Handcrafted Boots";
			Name2 = "Pratt's Handcrafted Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28903;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 6;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Jangdor's Handcrafted Boots)
*
***************************************************************/

namespace Server.Items
{
	public class JangdorsHandcraftedBoots : Item
	{
		public JangdorsHandcraftedBoots() : base()
		{
			Id = 9633;
			Resistance[0] = 84;
			Bonding = 1;
			SellPrice = 5847;
			AvailableClasses = 0x7FFF;
			Model = 28281;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			Name = "Jangdor's Handcrafted Boots";
			Name2 = "Jangdor's Handcrafted Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29237;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 6;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Gypsy Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class GypsySandals : Item
	{
		public GypsySandals() : base()
		{
			Id = 9751;
			Resistance[0] = 40;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 19033;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Gypsy Sandals";
			Name2 = "Gypsy Sandals";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 433;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Bandit Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BanditBoots : Item
	{
		public BanditBoots() : base()
		{
			Id = 9776;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 547;
			AvailableClasses = 0x7FFF;
			Model = 16981;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Bandit Boots";
			Name2 = "Bandit Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 814;
			BuyPrice = 2735;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Superior Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorBoots : Item
	{
		public SuperiorBoots() : base()
		{
			Id = 9802;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 1204;
			AvailableClasses = 0x7FFF;
			Model = 27761;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Superior Boots";
			Name2 = "Superior Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 816;
			BuyPrice = 6024;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherBoots : Item
	{
		public ScaledLeatherBoots() : base()
		{
			Id = 9828;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 1845;
			AvailableClasses = 0x7FFF;
			Model = 11581;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Scaled Leather Boots";
			Name2 = "Scaled Leather Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 818;
			BuyPrice = 9225;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Archer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersBoots : Item
	{
		public ArchersBoots() : base()
		{
			Id = 9856;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 2839;
			AvailableClasses = 0x7FFF;
			Model = 28734;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Archer's Boots";
			Name2 = "Archer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 819;
			BuyPrice = 14195;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansBoots : Item
	{
		public HuntsmansBoots() : base()
		{
			Id = 9885;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 4179;
			AvailableClasses = 0x7FFF;
			Model = 18904;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Huntsman's Boots";
			Name2 = "Huntsman's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 821;
			BuyPrice = 20899;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Tracker's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersBoots : Item
	{
		public TrackersBoots() : base()
		{
			Id = 9917;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 5519;
			AvailableClasses = 0x7FFF;
			Model = 18937;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Tracker's Boots";
			Name2 = "Tracker's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 822;
			BuyPrice = 27598;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsBoots : Item
	{
		public ChieftainsBoots() : base()
		{
			Id = 9948;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 8365;
			AvailableClasses = 0x7FFF;
			Model = 18944;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Chieftain's Boots";
			Name2 = "Chieftain's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 824;
			BuyPrice = 41826;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Righteous Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousBoots : Item
	{
		public RighteousBoots() : base()
		{
			Id = 10068;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 9128;
			AvailableClasses = 0x7FFF;
			Model = 19013;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Righteous Boots";
			Name2 = "Righteous Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 824;
			BuyPrice = 45640;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersBoots : Item
	{
		public WanderersBoots() : base()
		{
			Id = 10106;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 12120;
			AvailableClasses = 0x7FFF;
			Model = 27718;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Wanderer's Boots";
			Name2 = "Wanderer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 826;
			BuyPrice = 60601;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Mighty Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MightyBoots : Item
	{
		public MightyBoots() : base()
		{
			Id = 10146;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 16194;
			AvailableClasses = 0x7FFF;
			Model = 27741;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Mighty Boots";
			Name2 = "Mighty Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 828;
			BuyPrice = 80970;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersBoots : Item
	{
		public SwashbucklersBoots() : base()
		{
			Id = 10183;
			Resistance[0] = 97;
			Bonding = 2;
			SellPrice = 10954;
			AvailableClasses = 0x7FFF;
			Model = 6762;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Swashbuckler's Boots";
			Name2 = "Swashbuckler's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 825;
			BuyPrice = 54772;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Nightshade Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeBoots : Item
	{
		public NightshadeBoots() : base()
		{
			Id = 10222;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 14462;
			AvailableClasses = 0x7FFF;
			Model = 18979;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Nightshade Boots";
			Name2 = "Nightshade Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 827;
			BuyPrice = 72310;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersBoots : Item
	{
		public AdventurersBoots() : base()
		{
			Id = 10257;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 16877;
			AvailableClasses = 0x7FFF;
			Model = 27844;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Adventurer's Boots";
			Name2 = "Adventurer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 828;
			BuyPrice = 84385;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Blackened Defias Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedDefiasBoots : Item
	{
		public BlackenedDefiasBoots() : base()
		{
			Id = 10402;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 385;
			AvailableClasses = 0x7FFF;
			Model = 21903;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Blackened Defias Boots";
			Name2 = "Blackened Defias Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1926;
			Sets = 161;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 2;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Footpads of the Fang)
*
***************************************************************/

namespace Server.Items
{
	public class FootpadsOfTheFang : Item
	{
		public FootpadsOfTheFang() : base()
		{
			Id = 10411;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 787;
			AvailableClasses = 0x7FFF;
			Model = 27949;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Footpads of the Fang";
			Name2 = "Footpads of the Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3939;
			Sets = 162;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StaminaBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Briar Tredders)
*
***************************************************************/

namespace Server.Items
{
	public class BriarTredders : Item
	{
		public BriarTredders() : base()
		{
			Id = 10582;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 3606;
			AvailableClasses = 0x7FFF;
			Model = 28654;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Briar Tredders";
			Name2 = "Briar Tredders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18031;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			IqBonus = 8;
			AgilityBonus = 5;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Trailblazer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrailblazerBoots : Item
	{
		public TrailblazerBoots() : base()
		{
			Id = 10653;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 1639;
			AvailableClasses = 0x7FFF;
			Model = 9174;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Trailblazer Boots";
			Name2 = "Trailblazer Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8197;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 3;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Enormous Ogre Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EnormousOgreBoots : Item
	{
		public EnormousOgreBoots() : base()
		{
			Id = 10702;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 5379;
			AvailableClasses = 0x7FFF;
			Model = 28273;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			Name = "Enormous Ogre Boots";
			Name2 = "Enormous Ogre Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26897;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Wanderlust Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WanderlustBoots : Item
	{
		public WanderlustBoots() : base()
		{
			Id = 10748;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 4380;
			AvailableClasses = 0x7FFF;
			Model = 4385;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			Name = "Wanderlust Boots";
			Name2 = "Wanderlust Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21903;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 5;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Slitherscale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SlitherscaleBoots : Item
	{
		public SlitherscaleBoots() : base()
		{
			Id = 10801;
			Resistance[0] = 104;
			Bonding = 1;
			SellPrice = 11704;
			AvailableClasses = 0x7FFF;
			Model = 19912;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Slitherscale Boots";
			Name2 = "Slitherscale Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58520;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StaminaBonus = 12;
			StrBonus = 5;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Shadefiend Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShadefiendBoots : Item
	{
		public ShadefiendBoots() : base()
		{
			Id = 11675;
			Resistance[0] = 99;
			Bonding = 1;
			SellPrice = 12053;
			AvailableClasses = 0x7FFF;
			Model = 18979;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Shadefiend Boots";
			Name2 = "Shadefiend Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60266;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 4;
			StaminaBonus = 6;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Rambling Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RamblingBoots : Item
	{
		public RamblingBoots() : base()
		{
			Id = 11853;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 388;
			AvailableClasses = 0x7FFF;
			Model = 28241;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Rambling Boots";
			Name2 = "Rambling Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1941;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 1;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sandstalker Ankleguards)
*
***************************************************************/

namespace Server.Items
{
	public class SandstalkerAnkleguards : Item
	{
		public SandstalkerAnkleguards() : base()
		{
			Id = 12470;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 8784;
			AvailableClasses = 0x7FFF;
			Model = 22656;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Sandstalker Ankleguards";
			Name2 = "Sandstalker Ankleguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43922;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 17;
			IqBonus = 3;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Swiftwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftwalkerBoots : Item
	{
		public SwiftwalkerBoots() : base()
		{
			Id = 12553;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 17699;
			AvailableClasses = 0x7FFF;
			Model = 28670;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Swiftwalker Boots";
			Name2 = "Swiftwalker Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88496;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 21;
			StaminaBonus = 7;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sandals of the Insurgent)
*
***************************************************************/

namespace Server.Items
{
	public class SandalsOfTheInsurgent : Item
	{
		public SandalsOfTheInsurgent() : base()
		{
			Id = 13111;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 13993;
			AvailableClasses = 0x7FFF;
			Model = 28664;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Sandals of the Insurgent";
			Name2 = "Sandals of the Insurgent";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 69968;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			IqBonus = 20;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Pads of the Dread Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class PadsOfTheDreadWolf : Item
	{
		public PadsOfTheDreadWolf() : base()
		{
			Id = 13210;
			Resistance[0] = 116;
			Bonding = 1;
			SellPrice = 18024;
			AvailableClasses = 0x7FFF;
			Model = 23765;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Pads of the Dread Wolf";
			Name2 = "Pads of the Dread Wolf";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 90122;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Deprecated Stormrage Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedStormrageBoots : Item
	{
		public DeprecatedStormrageBoots() : base()
		{
			Id = 13242;
			Resistance[0] = 106;
			Bonding = 1;
			SellPrice = 16114;
			AvailableClasses = 0x7FFF;
			Model = 23824;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Deprecated Stormrage Boots";
			Name2 = "Deprecated Stormrage Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 80573;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			Flags = 16;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9361 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Boots of the Shrieker)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfTheShrieker : Item
	{
		public BootsOfTheShrieker() : base()
		{
			Id = 13398;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 20028;
			AvailableClasses = 0x7FFF;
			Model = 9653;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Boots of the Shrieker";
			Name2 = "Boots of the Shrieker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100142;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			SpiritBonus = 10;
			IqBonus = 10;
			StrBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Verdant Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class VerdantFootpads : Item
	{
		public VerdantFootpads() : base()
		{
			Id = 13954;
			Resistance[0] = 118;
			Bonding = 1;
			SellPrice = 20386;
			AvailableClasses = 0x7FFF;
			Model = 28627;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Verdant Footpads";
			Name2 = "Verdant Footpads";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 101934;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			SetSpell( 18030 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 17988 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Prospector's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsBoots : Item
	{
		public ProspectorsBoots() : base()
		{
			Id = 14560;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 484;
			AvailableClasses = 0x7FFF;
			Model = 27524;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Prospector's Boots";
			Name2 = "Prospector's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2421;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBoots : Item
	{
		public BristlebarkBoots() : base()
		{
			Id = 14568;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 797;
			AvailableClasses = 0x7FFF;
			Model = 16997;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Bristlebark Boots";
			Name2 = "Bristlebark Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3987;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			AgilityBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dokebi Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiBoots : Item
	{
		public DokebiBoots() : base()
		{
			Id = 14579;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 1791;
			AvailableClasses = 0x7FFF;
			Model = 27965;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Dokebi Boots";
			Name2 = "Dokebi Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8958;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			IqBonus = 4;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesShoes : Item
	{
		public HawkeyesShoes() : base()
		{
			Id = 14589;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 3294;
			AvailableClasses = 0x7FFF;
			Model = 9169;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Hawkeye's Shoes";
			Name2 = "Hawkeye's Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16473;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 3;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warden's Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class WardensFootpads : Item
	{
		public WardensFootpads() : base()
		{
			Id = 14599;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 4663;
			AvailableClasses = 0x7FFF;
			Model = 27982;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Warden's Footpads";
			Name2 = "Warden's Footpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23316;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			SpiritBonus = 7;
			IqBonus = 9;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cadaverous Walkers)
*
***************************************************************/

namespace Server.Items
{
	public class CadaverousWalkers : Item
	{
		public CadaverousWalkers() : base()
		{
			Id = 14641;
			Resistance[0] = 107;
			Bonding = 1;
			SellPrice = 15895;
			AvailableClasses = 0x7FFF;
			Model = 11571;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Cadaverous Walkers";
			Name2 = "Cadaverous Walkers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 79477;
			Sets = 121;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 16;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiSlippers : Item
	{
		public ScorpashiSlippers() : base()
		{
			Id = 14653;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 6854;
			AvailableClasses = 0x7FFF;
			Model = 18944;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Scorpashi Slippers";
			Name2 = "Scorpashi Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34271;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 3;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Keeper's Hooves)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersHooves : Item
	{
		public KeepersHooves() : base()
		{
			Id = 14662;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 9413;
			AvailableClasses = 0x7FFF;
			Model = 27568;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Keeper's Hooves";
			Name2 = "Keeper's Hooves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47065;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 6;
			AgilityBonus = 12;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pridelord Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordBoots : Item
	{
		public PridelordBoots() : base()
		{
			Id = 14671;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 13012;
			AvailableClasses = 0x7FFF;
			Model = 18944;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Pridelord Boots";
			Name2 = "Pridelord Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65062;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 4;
			IqBonus = 7;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Indomitable Boots)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableBoots : Item
	{
		public IndomitableBoots() : base()
		{
			Id = 14681;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 17139;
			AvailableClasses = 0x7FFF;
			Model = 17258;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Indomitable Boots";
			Name2 = "Indomitable Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85696;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			IqBonus = 5;
			StaminaBonus = 6;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Primal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalBoots : Item
	{
		public PrimalBoots() : base()
		{
			Id = 15004;
			Resistance[0] = 34;
			SellPrice = 42;
			AvailableClasses = 0x7FFF;
			Model = 7537;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Primal Boots";
			Name2 = "Primal Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 212;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Lupine Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class LupineSlippers : Item
	{
		public LupineSlippers() : base()
		{
			Id = 15012;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 296;
			AvailableClasses = 0x7FFF;
			Model = 14276;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Lupine Slippers";
			Name2 = "Lupine Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 813;
			BuyPrice = 1480;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Lupine Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class LupineSlippers15021 : Item
	{
		public LupineSlippers15021() : base()
		{
			Id = 15021;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 296;
			AvailableClasses = 0x7FFF;
			Model = 14276;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Lupine Slippers";
			Name2 = "Lupine Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 813;
			BuyPrice = 1480;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Frostsaber Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FrostsaberBoots : Item
	{
		public FrostsaberBoots() : base()
		{
			Id = 15071;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 11443;
			AvailableClasses = 0x7FFF;
			Model = 25703;
			Resistance[4] = 12;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Frostsaber Boots";
			Name2 = "Frostsaber Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57218;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Chimeric Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ChimericBoots : Item
	{
		public ChimericBoots() : base()
		{
			Id = 15073;
			Resistance[6] = 12;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 11530;
			AvailableClasses = 0x7FFF;
			Model = 25709;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Chimeric Boots";
			Name2 = "Chimeric Boots";
			Resistance[3] = 12;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57650;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Rigid Moccasins)
*
***************************************************************/

namespace Server.Items
{
	public class RigidMoccasins : Item
	{
		public RigidMoccasins() : base()
		{
			Id = 15111;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 609;
			AvailableClasses = 0x7FFF;
			Model = 1981;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Rigid Moccasins";
			Name2 = "Rigid Moccasins";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 814;
			BuyPrice = 3046;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Robust Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RobustBoots : Item
	{
		public RobustBoots() : base()
		{
			Id = 15121;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 1433;
			AvailableClasses = 0x7FFF;
			Model = 1966;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Robust Boots";
			Name2 = "Robust Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 817;
			BuyPrice = 7167;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsBoots : Item
	{
		public CutthroatsBoots() : base()
		{
			Id = 15131;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 2023;
			AvailableClasses = 0x7FFF;
			Model = 27710;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Cutthroat's Boots";
			Name2 = "Cutthroat's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 818;
			BuyPrice = 10117;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerBoots : Item
	{
		public GhostwalkerBoots() : base()
		{
			Id = 15142;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 2603;
			AvailableClasses = 0x7FFF;
			Model = 27685;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Ghostwalker Boots";
			Name2 = "Ghostwalker Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 819;
			BuyPrice = 13016;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalShoes : Item
	{
		public NocturnalShoes() : base()
		{
			Id = 15152;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 4449;
			AvailableClasses = 0x7FFF;
			Model = 27725;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Nocturnal Shoes";
			Name2 = "Nocturnal Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 821;
			BuyPrice = 22247;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Imposing Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingBoots : Item
	{
		public ImposingBoots() : base()
		{
			Id = 15162;
			Resistance[0] = 84;
			Bonding = 2;
			SellPrice = 5829;
			AvailableClasses = 0x7FFF;
			Model = 27916;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Imposing Boots";
			Name2 = "Imposing Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 822;
			BuyPrice = 29146;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Potent Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PotentBoots : Item
	{
		public PotentBoots() : base()
		{
			Id = 15171;
			Resistance[0] = 91;
			Bonding = 2;
			SellPrice = 8697;
			AvailableClasses = 0x7FFF;
			Model = 11832;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Potent Boots";
			Name2 = "Potent Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 824;
			BuyPrice = 43487;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Praetorian Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianBoots : Item
	{
		public PraetorianBoots() : base()
		{
			Id = 15181;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 11312;
			AvailableClasses = 0x7FFF;
			Model = 27562;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Praetorian Boots";
			Name2 = "Praetorian Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 826;
			BuyPrice = 56561;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Grand Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GrandBoots : Item
	{
		public GrandBoots() : base()
		{
			Id = 15189;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 15722;
			AvailableClasses = 0x7FFF;
			Model = 27634;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Grand Boots";
			Name2 = "Grand Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 827;
			BuyPrice = 78614;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Grizzly Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlySlippers : Item
	{
		public GrizzlySlippers() : base()
		{
			Id = 15301;
			Resistance[0] = 42;
			SellPrice = 108;
			AvailableClasses = 0x7FFF;
			Model = 28016;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Grizzly Slippers";
			Name2 = "Grizzly Slippers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 541;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Feral Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class FeralShoes : Item
	{
		public FeralShoes() : base()
		{
			Id = 15305;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 412;
			AvailableClasses = 0x7FFF;
			Model = 28039;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Feral Shoes";
			Name2 = "Feral Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 813;
			BuyPrice = 2062;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersBoots : Item
	{
		public WranglersBoots() : base()
		{
			Id = 15330;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 1059;
			AvailableClasses = 0x7FFF;
			Model = 27999;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Wrangler's Boots";
			Name2 = "Wrangler's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 816;
			BuyPrice = 5298;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderFootpads : Item
	{
		public PathfinderFootpads() : base()
		{
			Id = 15341;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 1697;
			AvailableClasses = 0x7FFF;
			Model = 27678;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Pathfinder Footpads";
			Name2 = "Pathfinder Footpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 817;
			BuyPrice = 8486;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersSlippers : Item
	{
		public HeadhuntersSlippers() : base()
		{
			Id = 15350;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 2384;
			AvailableClasses = 0x7FFF;
			Model = 27702;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Headhunter's Slippers";
			Name2 = "Headhunter's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 819;
			BuyPrice = 11924;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Trickster's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersBoots : Item
	{
		public TrickstersBoots() : base()
		{
			Id = 15362;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 3871;
			AvailableClasses = 0x7FFF;
			Model = 27957;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Trickster's Boots";
			Name2 = "Trickster's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 820;
			BuyPrice = 19357;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersBoots : Item
	{
		public WolfRidersBoots() : base()
		{
			Id = 15370;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 5439;
			AvailableClasses = 0x7FFF;
			Model = 27969;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Wolf Rider's Boots";
			Name2 = "Wolf Rider's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 822;
			BuyPrice = 27198;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawBoots : Item
	{
		public RageclawBoots() : base()
		{
			Id = 15379;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 7654;
			AvailableClasses = 0x7FFF;
			Model = 15412;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Rageclaw Boots";
			Name2 = "Rageclaw Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 823;
			BuyPrice = 38271;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Jadefire Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireSabatons : Item
	{
		public JadefireSabatons() : base()
		{
			Id = 15389;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 10146;
			AvailableClasses = 0x7FFF;
			Model = 13343;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Jadefire Sabatons";
			Name2 = "Jadefire Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 825;
			BuyPrice = 50734;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Peerless Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessBoots : Item
	{
		public PeerlessBoots() : base()
		{
			Id = 15426;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 13419;
			AvailableClasses = 0x7FFF;
			Model = 28031;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Peerless Boots";
			Name2 = "Peerless Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 827;
			BuyPrice = 67098;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Supreme Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeShoes : Item
	{
		public SupremeShoes() : base()
		{
			Id = 15435;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 18199;
			AvailableClasses = 0x7FFF;
			Model = 27617;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Supreme Shoes";
			Name2 = "Supreme Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 828;
			BuyPrice = 90997;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Tundra Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TundraBoots : Item
	{
		public TundraBoots() : base()
		{
			Id = 15458;
			Resistance[0] = 62;
			Bonding = 1;
			SellPrice = 1423;
			AvailableClasses = 0x7FFF;
			Model = 28192;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			Name = "Tundra Boots";
			Name2 = "Tundra Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7116;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StaminaBonus = 2;
			SpiritBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Swiftfoot Treads)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftfootTreads : Item
	{
		public SwiftfootTreads() : base()
		{
			Id = 15861;
			Resistance[0] = 106;
			Bonding = 1;
			SellPrice = 14969;
			AvailableClasses = 0x7FFF;
			Model = 26543;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			Name = "Swiftfoot Treads";
			Name2 = "Swiftfoot Treads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74845;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 18;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Leather Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsLeatherBoots : Item
	{
		public KnightLieutenantsLeatherBoots() : base()
		{
			Id = 16392;
			Resistance[0] = 121;
			Bonding = 1;
			SellPrice = 10638;
			AvailableClasses = 0x08;
			Model = 31068;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Leather Boots";
			Name2 = "Knight-Lieutenant's Leather Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53190;
			Sets = 348;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 50;
			Flags = 32768;
			SetSpell( 23049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Dragonhide Footwraps)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsDragonhideFootwraps : Item
	{
		public KnightLieutenantsDragonhideFootwraps() : base()
		{
			Id = 16393;
			Resistance[0] = 121;
			Bonding = 1;
			SellPrice = 10676;
			AvailableClasses = 0x400;
			Model = 31070;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Dragonhide Footwraps";
			Name2 = "Knight-Lieutenant's Dragonhide Footwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53384;
			Sets = 381;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			AgilityBonus = 5;
			StaminaBonus = 12;
			SpiritBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Marshal's Leather Footguards)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLeatherFootguards : Item
	{
		public MarshalsLeatherFootguards() : base()
		{
			Id = 16446;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 15701;
			AvailableClasses = 0x08;
			Model = 30333;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Leather Footguards";
			Name2 = "Marshal's Leather Footguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 78506;
			Sets = 394;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 60;
			Flags = 32768;
			SetSpell( 23049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dragonhide Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDragonhideBoots : Item
	{
		public MarshalsDragonhideBoots() : base()
		{
			Id = 16459;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 15291;
			AvailableClasses = 0x400;
			Model = 30333;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dragonhide Boots";
			Name2 = "Marshal's Dragonhide Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 76459;
			Sets = 397;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 60;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 14;
			SpiritBonus = 11;
			IqBonus = 10;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Dragonhide Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsDragonhideBoots : Item
	{
		public BloodGuardsDragonhideBoots() : base()
		{
			Id = 16494;
			Resistance[0] = 121;
			Bonding = 1;
			SellPrice = 11282;
			AvailableClasses = 0x400;
			Model = 27263;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Dragonhide Boots";
			Name2 = "Blood Guard's Dragonhide Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56412;
			Sets = 382;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
			StrBonus = 12;
			SpiritBonus = 5;
			AgilityBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Leather Treads)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsLeatherTreads : Item
	{
		public BloodGuardsLeatherTreads() : base()
		{
			Id = 16498;
			Resistance[0] = 121;
			Bonding = 1;
			SellPrice = 10360;
			AvailableClasses = 0x08;
			Model = 31035;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Leather Treads";
			Name2 = "Blood Guard's Leather Treads";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51802;
			Sets = 347;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 50;
			Flags = 32768;
			SetSpell( 23049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(General's Dragonhide Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDragonhideBoots : Item
	{
		public GeneralsDragonhideBoots() : base()
		{
			Id = 16554;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 16579;
			AvailableClasses = 0x400;
			Model = 32106;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dragonhide Boots";
			Name2 = "General's Dragonhide Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 82895;
			Sets = 398;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 60;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 14;
			SpiritBonus = 11;
			AgilityBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(General's Leather Treads)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsLeatherTreads : Item
	{
		public GeneralsLeatherTreads() : base()
		{
			Id = 16558;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 15644;
			AvailableClasses = 0x08;
			Model = 32114;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Leather Treads";
			Name2 = "General's Leather Treads";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 78221;
			Sets = 393;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 60;
			Flags = 32768;
			SetSpell( 23049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftBoots : Item
	{
		public ShadowcraftBoots() : base()
		{
			Id = 16711;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 17505;
			AvailableClasses = 0x7FFF;
			Model = 28162;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Shadowcraft Boots";
			Name2 = "Shadowcraft Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87528;
			Sets = 184;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 21;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Wildheart Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartBoots : Item
	{
		public WildheartBoots() : base()
		{
			Id = 16715;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 17766;
			AvailableClasses = 0x7FFF;
			Model = 29981;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Wildheart Boots";
			Name2 = "Wildheart Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88833;
			Sets = 185;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			IqBonus = 17;
			StaminaBonus = 10;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerBoots : Item
	{
		public NightslayerBoots() : base()
		{
			Id = 16824;
			Resistance[0] = 138;
			Bonding = 1;
			SellPrice = 32842;
			AvailableClasses = 0x08;
			Model = 31109;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Boots";
			Name2 = "Nightslayer Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 164214;
			Sets = 204;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 26;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Cenarion Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionBoots : Item
	{
		public CenarionBoots() : base()
		{
			Id = 16829;
			Resistance[0] = 138;
			Bonding = 1;
			SellPrice = 34339;
			AvailableClasses = 0x400;
			Model = 31724;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Boots";
			Name2 = "Cenarion Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 171697;
			Sets = 205;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 15;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Stormrage Boots)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageBoots : Item
	{
		public StormrageBoots() : base()
		{
			Id = 16898;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 53709;
			AvailableClasses = 0x400;
			Model = 29772;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Boots";
			Name2 = "Stormrage Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 268546;
			Sets = 214;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 11;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangBoots : Item
	{
		public BloodfangBoots() : base()
		{
			Id = 16906;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 55305;
			AvailableClasses = 0x08;
			Model = 29748;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Boots";
			Name2 = "Bloodfang Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 276527;
			Sets = 213;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 25;
			StaminaBonus = 17;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warsong Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongBoots : Item
	{
		public WarsongBoots() : base()
		{
			Id = 16977;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 1448;
			AvailableClasses = 0x7FFF;
			Model = 28749;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Warsong Boots";
			Name2 = "Warsong Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7242;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 8;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Corehound Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CorehoundBoots : Item
	{
		public CorehoundBoots() : base()
		{
			Id = 16982;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 24397;
			AvailableClasses = 0x7FFF;
			Model = 28770;
			Resistance[2] = 24;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Corehound Boots";
			Name2 = "Corehound Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 121985;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 13;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Albino Crocscale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AlbinoCrocscaleBoots : Item
	{
		public AlbinoCrocscaleBoots() : base()
		{
			Id = 17728;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 12458;
			AvailableClasses = 0x7FFF;
			Model = 29904;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Albino Crocscale Boots";
			Name2 = "Albino Crocscale Boots";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62291;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 20;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Coal Miner Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CoalMinerBoots : Item
	{
		public CoalMinerBoots() : base()
		{
			Id = 18043;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 12912;
			AvailableClasses = 0x7FFF;
			Model = 2373;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Coal Miner Boots";
			Name2 = "Coal Miner Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64563;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Waterspout Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WaterspoutBoots : Item
	{
		public WaterspoutBoots() : base()
		{
			Id = 18322;
			Resistance[0] = 114;
			Bonding = 1;
			SellPrice = 16137;
			AvailableClasses = 0x7FFF;
			Model = 6779;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Waterspout Boots";
			Name2 = "Waterspout Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 80686;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			SetSpell( 15715 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Spry Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SpryBoots : Item
	{
		public SpryBoots() : base()
		{
			Id = 18411;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 13704;
			AvailableClasses = 0x7FFF;
			Model = 31732;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			Name = "Spry Boots";
			Name2 = "Spry Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68520;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Sedge Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SedgeBoots : Item
	{
		public SedgeBoots() : base()
		{
			Id = 18424;
			Resistance[0] = 121;
			Bonding = 1;
			SellPrice = 20595;
			AvailableClasses = 0x7FFF;
			Model = 30795;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			Name = "Sedge Boots";
			Name2 = "Sedge Boots";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102979;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StaminaBonus = 18;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Mud Stained Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MudStainedBoots : Item
	{
		public MudStainedBoots() : base()
		{
			Id = 18476;
			Resistance[0] = 106;
			Bonding = 1;
			SellPrice = 15149;
			AvailableClasses = 0x7FFF;
			Model = 30817;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Mud Stained Boots";
			Name2 = "Mud Stained Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 75747;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 10;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Mongoose Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MongooseBoots : Item
	{
		public MongooseBoots() : base()
		{
			Id = 18506;
			Resistance[0] = 120;
			Bonding = 2;
			SellPrice = 21340;
			AvailableClasses = 0x7FFF;
			Model = 9080;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Mongoose Boots";
			Name2 = "Mongoose Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 106702;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 23;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ash Covered Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AshCoveredBoots : Item
	{
		public AshCoveredBoots() : base()
		{
			Id = 18716;
			Resistance[0] = 118;
			Bonding = 1;
			SellPrice = 18655;
			AvailableClasses = 0x7FFF;
			Model = 31166;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Ash Covered Boots";
			Name2 = "Ash Covered Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 93277;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 13;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dawn Treaders)
*
***************************************************************/

namespace Server.Items
{
	public class DawnTreaders : Item
	{
		public DawnTreaders() : base()
		{
			Id = 19052;
			Resistance[0] = 114;
			Bonding = 2;
			SellPrice = 17621;
			AvailableClasses = 0x7FFF;
			Model = 31549;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Dawn Treaders";
			Name2 = "Dawn Treaders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88105;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = -1;
			Durability = 50;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
		}
	}
}


