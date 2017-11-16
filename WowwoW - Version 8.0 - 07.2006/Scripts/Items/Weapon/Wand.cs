/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:08:34 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Gnomish Zapper)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishZapper : Item
	{
		public GnomishZapper() : base()
		{
			Id = 4547;
			Bonding = 1;
			SellPrice = 8319;
			AvailableClasses = 0x7FFF;
			Model = 21016;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Gnomish Zapper";
			Name2 = "Gnomish Zapper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41596;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 29 , 56 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Fire Wand)
*
***************************************************************/

namespace Server.Items
{
	public class FireWand : Item
	{
		public FireWand() : base()
		{
			Id = 5069;
			Bonding = 2;
			SellPrice = 293;
			AvailableClasses = 0x7FFF;
			Model = 6097;
			ObjectClass = 2;
			SubClass = 19;
			Level = 12;
			ReqLevel = 7;
			Name = "Fire Wand";
			Name2 = "Fire Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1466;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 30;
			SetDamage( 9 , 17 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Shadow Wand)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowWand : Item
	{
		public ShadowWand() : base()
		{
			Id = 5071;
			Bonding = 2;
			SellPrice = 443;
			AvailableClasses = 0x7FFF;
			Model = 18356;
			ObjectClass = 2;
			SubClass = 19;
			Level = 14;
			ReqLevel = 9;
			Name = "Shadow Wand";
			Name2 = "Shadow Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2216;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			SetDamage( 10 , 19 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Charred Razormane Wand)
*
***************************************************************/

namespace Server.Items
{
	public class CharredRazormaneWand : Item
	{
		public CharredRazormaneWand() : base()
		{
			Id = 5092;
			Bonding = 1;
			SellPrice = 240;
			AvailableClasses = 0x7FFF;
			Model = 6101;
			ObjectClass = 2;
			SubClass = 19;
			Level = 23;
			ReqLevel = 18;
			Name = "Charred Razormane Wand";
			Name2 = "Charred Razormane Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1203;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 16 , 31 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Cookie's Stirring Rod)
*
***************************************************************/

namespace Server.Items
{
	public class CookiesStirringRod : Item
	{
		public CookiesStirringRod() : base()
		{
			Id = 5198;
			Bonding = 1;
			SellPrice = 1660;
			AvailableClasses = 0x7FFF;
			Model = 21011;
			ObjectClass = 2;
			SubClass = 19;
			Level = 22;
			ReqLevel = 17;
			Name = "Cookie's Stirring Rod";
			Name2 = "Cookie's Stirring Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8301;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 20 , 38 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Opaque Wand)
*
***************************************************************/

namespace Server.Items
{
	public class OpaqueWand : Item
	{
		public OpaqueWand() : base()
		{
			Id = 5207;
			Bonding = 2;
			SellPrice = 1081;
			AvailableClasses = 0x7FFF;
			Model = 20903;
			ObjectClass = 2;
			SubClass = 19;
			Level = 20;
			ReqLevel = 15;
			Name = "Opaque Wand";
			Name2 = "Opaque Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5406;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 14 , 28 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Smoldering Wand)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingWand : Item
	{
		public SmolderingWand() : base()
		{
			Id = 5208;
			SellPrice = 668;
			AvailableClasses = 0x7FFF;
			Model = 20829;
			ObjectClass = 2;
			SubClass = 19;
			Level = 20;
			ReqLevel = 15;
			Name = "Smoldering Wand";
			Name2 = "Smoldering Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3340;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 15 , 28 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Gloom Wand)
*
***************************************************************/

namespace Server.Items
{
	public class GloomWand : Item
	{
		public GloomWand() : base()
		{
			Id = 5209;
			SellPrice = 771;
			AvailableClasses = 0x7FFF;
			Model = 6099;
			ObjectClass = 2;
			SubClass = 19;
			Level = 21;
			ReqLevel = 16;
			Name = "Gloom Wand";
			Name2 = "Gloom Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3855;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 18 , 34 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Burning Wand)
*
***************************************************************/

namespace Server.Items
{
	public class BurningWand : Item
	{
		public BurningWand() : base()
		{
			Id = 5210;
			SellPrice = 1161;
			AvailableClasses = 0x7FFF;
			Model = 20787;
			ObjectClass = 2;
			SubClass = 19;
			Level = 25;
			ReqLevel = 20;
			Name = "Burning Wand";
			Name2 = "Burning Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5808;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 17 , 32 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Dusk Wand)
*
***************************************************************/

namespace Server.Items
{
	public class DuskWand : Item
	{
		public DuskWand() : base()
		{
			Id = 5211;
			SellPrice = 1166;
			AvailableClasses = 0x7FFF;
			Model = 20852;
			ObjectClass = 2;
			SubClass = 19;
			Level = 25;
			ReqLevel = 20;
			Name = "Dusk Wand";
			Name2 = "Dusk Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5830;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 21 , 39 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Blazing Wand)
*
***************************************************************/

namespace Server.Items
{
	public class BlazingWand : Item
	{
		public BlazingWand() : base()
		{
			Id = 5212;
			Bonding = 2;
			SellPrice = 672;
			AvailableClasses = 0x7FFF;
			Model = 6081;
			ObjectClass = 2;
			SubClass = 19;
			Level = 17;
			ReqLevel = 12;
			Name = "Blazing Wand";
			Name2 = "Blazing Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3361;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			SetDamage( 13 , 25 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Scorching Wand)
*
***************************************************************/

namespace Server.Items
{
	public class ScorchingWand : Item
	{
		public ScorchingWand() : base()
		{
			Id = 5213;
			Bonding = 2;
			SellPrice = 5218;
			AvailableClasses = 0x7FFF;
			Model = 20907;
			ObjectClass = 2;
			SubClass = 19;
			Level = 35;
			ReqLevel = 30;
			Name = "Scorching Wand";
			Name2 = "Scorching Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26093;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 26 , 49 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Wand of Eventide)
*
***************************************************************/

namespace Server.Items
{
	public class WandOfEventide : Item
	{
		public WandOfEventide() : base()
		{
			Id = 5214;
			Bonding = 2;
			SellPrice = 3935;
			AvailableClasses = 0x7FFF;
			Model = 21020;
			ObjectClass = 2;
			SubClass = 19;
			Level = 32;
			ReqLevel = 27;
			Name = "Wand of Eventide";
			Name2 = "Wand of Eventide";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19678;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 23 , 44 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Ember Wand)
*
***************************************************************/

namespace Server.Items
{
	public class EmberWand : Item
	{
		public EmberWand() : base()
		{
			Id = 5215;
			Bonding = 2;
			SellPrice = 8656;
			AvailableClasses = 0x7FFF;
			Model = 20815;
			ObjectClass = 2;
			SubClass = 19;
			Level = 41;
			ReqLevel = 36;
			Name = "Ember Wand";
			Name2 = "Ember Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5253;
			BuyPrice = 43281;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 35 , 66 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Umbral Wand)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralWand : Item
	{
		public UmbralWand() : base()
		{
			Id = 5216;
			Bonding = 2;
			SellPrice = 11821;
			AvailableClasses = 0x7FFF;
			Model = 20790;
			ObjectClass = 2;
			SubClass = 19;
			Level = 45;
			ReqLevel = 40;
			Name = "Umbral Wand";
			Name2 = "Umbral Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5262;
			BuyPrice = 59109;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 37 , 70 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Alchemist's Wand)
*
***************************************************************/

namespace Server.Items
{
	public class AlchemistsWand : Item
	{
		public AlchemistsWand() : base()
		{
			Id = 5235;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 6081;
			ObjectClass = 2;
			SubClass = 19;
			Level = 7;
			ReqLevel = 1;
			Name = "Alchemist's Wand";
			Name2 = "Alchemist's Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 8;
			BuyPrice = 206;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Flags = 272;
			SetDamage( 12 , 19 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Combustible Wand)
*
***************************************************************/

namespace Server.Items
{
	public class CombustibleWand : Item
	{
		public CombustibleWand() : base()
		{
			Id = 5236;
			SellPrice = 2878;
			AvailableClasses = 0x7FFF;
			Model = 20916;
			ObjectClass = 2;
			SubClass = 19;
			Level = 34;
			ReqLevel = 29;
			Name = "Combustible Wand";
			Name2 = "Combustible Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14394;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 29 , 54 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Pitchwood Wand)
*
***************************************************************/

namespace Server.Items
{
	public class PitchwoodWand : Item
	{
		public PitchwoodWand() : base()
		{
			Id = 5238;
			SellPrice = 7145;
			AvailableClasses = 0x7FFF;
			Model = 20787;
			ObjectClass = 2;
			SubClass = 19;
			Level = 45;
			ReqLevel = 40;
			Name = "Pitchwood Wand";
			Name2 = "Pitchwood Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35727;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 41 , 77 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Blackbone Wand)
*
***************************************************************/

namespace Server.Items
{
	public class BlackboneWand : Item
	{
		public BlackboneWand() : base()
		{
			Id = 5239;
			SellPrice = 7746;
			AvailableClasses = 0x7FFF;
			Model = 20776;
			ObjectClass = 2;
			SubClass = 19;
			Level = 46;
			ReqLevel = 41;
			Name = "Blackbone Wand";
			Name2 = "Blackbone Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38731;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 39 , 74 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Torchlight Wand)
*
***************************************************************/

namespace Server.Items
{
	public class TorchlightWand : Item
	{
		public TorchlightWand() : base()
		{
			Id = 5240;
			Bonding = 1;
			SellPrice = 1244;
			AvailableClasses = 0x7FFF;
			Model = 6101;
			ObjectClass = 2;
			SubClass = 19;
			Level = 21;
			Name = "Torchlight Wand";
			Name2 = "Torchlight Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6221;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 14 , 27 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Dwarven Flamestick)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenFlamestick : Item
	{
		public DwarvenFlamestick() : base()
		{
			Id = 5241;
			Bonding = 1;
			SellPrice = 821;
			AvailableClasses = 0x7FFF;
			Model = 6097;
			ObjectClass = 2;
			SubClass = 19;
			Level = 18;
			Name = "Dwarven Flamestick";
			Name2 = "Dwarven Flamestick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4105;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 17 , 32 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Cinder Wand)
*
***************************************************************/

namespace Server.Items
{
	public class CinderWand : Item
	{
		public CinderWand() : base()
		{
			Id = 5242;
			Bonding = 1;
			SellPrice = 623;
			AvailableClasses = 0x7FFF;
			Model = 6093;
			ObjectClass = 2;
			SubClass = 19;
			Level = 16;
			Name = "Cinder Wand";
			Name2 = "Cinder Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3115;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			SetDamage( 11 , 22 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Firebelcher)
*
***************************************************************/

namespace Server.Items
{
	public class Firebelcher : Item
	{
		public Firebelcher() : base()
		{
			Id = 5243;
			Bonding = 1;
			SellPrice = 1312;
			AvailableClasses = 0x7FFF;
			Model = 12601;
			ObjectClass = 2;
			SubClass = 19;
			Level = 20;
			ReqLevel = 15;
			Name = "Firebelcher";
			Name2 = "Firebelcher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6562;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 24 , 45 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Consecrated Wand)
*
***************************************************************/

namespace Server.Items
{
	public class ConsecratedWand : Item
	{
		public ConsecratedWand() : base()
		{
			Id = 5244;
			Bonding = 1;
			SellPrice = 3465;
			AvailableClasses = 0x7FFF;
			Model = 21024;
			ObjectClass = 2;
			SubClass = 19;
			Level = 30;
			Name = "Consecrated Wand";
			Name2 = "Consecrated Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17325;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1200;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 20 , 38 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Summoner's Wand)
*
***************************************************************/

namespace Server.Items
{
	public class SummonersWand : Item
	{
		public SummonersWand() : base()
		{
			Id = 5245;
			Bonding = 2;
			SellPrice = 5091;
			AvailableClasses = 0x7FFF;
			Model = 21019;
			ObjectClass = 2;
			SubClass = 19;
			Level = 34;
			ReqLevel = 29;
			Name = "Summoner's Wand";
			Name2 = "Summoner's Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25458;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 35 , 66 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Excavation Rod)
*
***************************************************************/

namespace Server.Items
{
	public class ExcavationRod : Item
	{
		public ExcavationRod() : base()
		{
			Id = 5246;
			Bonding = 1;
			SellPrice = 3490;
			AvailableClasses = 0x7FFF;
			Model = 6093;
			ObjectClass = 2;
			SubClass = 19;
			Level = 30;
			Name = "Excavation Rod";
			Name2 = "Excavation Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17450;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 32 , 60 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Rod of Sorrow)
*
***************************************************************/

namespace Server.Items
{
	public class RodOfSorrow : Item
	{
		public RodOfSorrow() : base()
		{
			Id = 5247;
			Bonding = 1;
			SellPrice = 7961;
			AvailableClasses = 0x7FFF;
			Model = 20828;
			ObjectClass = 2;
			SubClass = 19;
			Level = 39;
			Name = "Rod of Sorrow";
			Name2 = "Rod of Sorrow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39806;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 42 , 79 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Flash Wand)
*
***************************************************************/

namespace Server.Items
{
	public class FlashWand : Item
	{
		public FlashWand() : base()
		{
			Id = 5248;
			Bonding = 1;
			SellPrice = 6849;
			AvailableClasses = 0x7FFF;
			Model = 21023;
			ObjectClass = 2;
			SubClass = 19;
			Level = 37;
			Name = "Flash Wand";
			Name2 = "Flash Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34245;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 27 , 52 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Burning Sliver)
*
***************************************************************/

namespace Server.Items
{
	public class BurningSliver : Item
	{
		public BurningSliver() : base()
		{
			Id = 5249;
			Bonding = 1;
			SellPrice = 8658;
			AvailableClasses = 0x7FFF;
			Model = 20793;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Burning Sliver";
			Name2 = "Burning Sliver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43292;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 29 , 56 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Charred Wand)
*
***************************************************************/

namespace Server.Items
{
	public class CharredWand : Item
	{
		public CharredWand() : base()
		{
			Id = 5250;
			Bonding = 1;
			SellPrice = 2646;
			AvailableClasses = 0x7FFF;
			Model = 6140;
			ObjectClass = 2;
			SubClass = 19;
			Level = 28;
			Name = "Charred Wand";
			Name2 = "Charred Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13233;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 28 , 52 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Wand of Decay)
*
***************************************************************/

namespace Server.Items
{
	public class WandOfDecay : Item
	{
		public WandOfDecay() : base()
		{
			Id = 5252;
			Bonding = 1;
			SellPrice = 1175;
			AvailableClasses = 0x7FFF;
			Model = 20825;
			ObjectClass = 2;
			SubClass = 19;
			Level = 21;
			Name = "Wand of Decay";
			Name2 = "Wand of Decay";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5877;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 16 , 31 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Goblin Igniter)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinIgniter : Item
	{
		public GoblinIgniter() : base()
		{
			Id = 5253;
			Bonding = 1;
			SellPrice = 7952;
			AvailableClasses = 0x7FFF;
			Model = 20801;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Goblin Igniter";
			Name2 = "Goblin Igniter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39761;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 46 , 85 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Flaring Baton)
*
***************************************************************/

namespace Server.Items
{
	public class FlaringBaton : Item
	{
		public FlaringBaton() : base()
		{
			Id = 5326;
			Bonding = 1;
			SellPrice = 776;
			AvailableClasses = 0x7FFF;
			Model = 6097;
			ObjectClass = 2;
			SubClass = 19;
			Level = 18;
			Name = "Flaring Baton";
			Name2 = "Flaring Baton";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3880;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 18 , 34 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Pestilent Wand)
*
***************************************************************/

namespace Server.Items
{
	public class PestilentWand : Item
	{
		public PestilentWand() : base()
		{
			Id = 5347;
			SellPrice = 3142;
			AvailableClasses = 0x7FFF;
			Model = 21022;
			ObjectClass = 2;
			SubClass = 19;
			Level = 35;
			ReqLevel = 30;
			Name = "Pestilent Wand";
			Name2 = "Pestilent Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15713;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 28 , 53 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Branding Rod)
*
***************************************************************/

namespace Server.Items
{
	public class BrandingRod : Item
	{
		public BrandingRod() : base()
		{
			Id = 5356;
			Bonding = 1;
			SellPrice = 2594;
			AvailableClasses = 0x7FFF;
			Model = 20834;
			ObjectClass = 2;
			SubClass = 19;
			Level = 27;
			Name = "Branding Rod";
			Name2 = "Branding Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12971;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 24 , 45 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Elven Wand)
*
***************************************************************/

namespace Server.Items
{
	public class ElvenWand : Item
	{
		public ElvenWand() : base()
		{
			Id = 5604;
			Bonding = 1;
			SellPrice = 380;
			AvailableClasses = 0x7FFF;
			Model = 28159;
			ObjectClass = 2;
			SubClass = 19;
			Level = 13;
			Name = "Elven Wand";
			Name2 = "Elven Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1901;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 30;
			SetDamage( 10 , 20 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Moonbeam Wand)
*
***************************************************************/

namespace Server.Items
{
	public class MoonbeamWand : Item
	{
		public MoonbeamWand() : base()
		{
			Id = 5818;
			Bonding = 1;
			SellPrice = 3239;
			AvailableClasses = 0x7FFF;
			Model = 21026;
			ObjectClass = 2;
			SubClass = 19;
			Level = 30;
			Name = "Moonbeam Wand";
			Name2 = "Moonbeam Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16197;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 30 , 57 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Spellcrafter Wand)
*
***************************************************************/

namespace Server.Items
{
	public class SpellcrafterWand : Item
	{
		public SpellcrafterWand() : base()
		{
			Id = 6677;
			Bonding = 1;
			SellPrice = 2401;
			AvailableClasses = 0x7FFF;
			Model = 21018;
			ObjectClass = 2;
			SubClass = 19;
			Level = 26;
			Name = "Spellcrafter Wand";
			Name2 = "Spellcrafter Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12006;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 24 , 45 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Fizzle's Zippy Lighter)
*
***************************************************************/

namespace Server.Items
{
	public class FizzlesZippyLighter : Item
	{
		public FizzlesZippyLighter() : base()
		{
			Id = 6729;
			Bonding = 1;
			SellPrice = 7187;
			AvailableClasses = 0x7FFF;
			Model = 20821;
			ObjectClass = 2;
			SubClass = 19;
			Level = 38;
			Name = "Fizzle's Zippy Lighter";
			Name2 = "Fizzle's Zippy Lighter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35939;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 32 , 61 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Eyepoker)
*
***************************************************************/

namespace Server.Items
{
	public class Eyepoker : Item
	{
		public Eyepoker() : base()
		{
			Id = 6797;
			Bonding = 1;
			SellPrice = 6362;
			AvailableClasses = 0x7FFF;
			Model = 21014;
			ObjectClass = 2;
			SubClass = 19;
			Level = 37;
			Name = "Eyepoker";
			Name2 = "Eyepoker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31813;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 36 , 68 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Dancing Flame)
*
***************************************************************/

namespace Server.Items
{
	public class DancingFlame : Item
	{
		public DancingFlame() : base()
		{
			Id = 6806;
			Bonding = 1;
			SellPrice = 8508;
			AvailableClasses = 0x7FFF;
			Model = 13084;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Dancing Flame";
			Name2 = "Dancing Flame";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42540;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 32 , 60 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Gravestone Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class GravestoneScepter : Item
	{
		public GravestoneScepter() : base()
		{
			Id = 7001;
			Bonding = 1;
			SellPrice = 3535;
			AvailableClasses = 0x7FFF;
			Model = 20824;
			ObjectClass = 2;
			SubClass = 19;
			Level = 29;
			Name = "Gravestone Scepter";
			Name2 = "Gravestone Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17677;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 30 , 57 , Resistances.Shadow );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ragefire Wand)
*
***************************************************************/

namespace Server.Items
{
	public class RagefireWand : Item
	{
		public RagefireWand() : base()
		{
			Id = 7513;
			Bonding = 1;
			SellPrice = 8171;
			AvailableClasses = 0x80;
			Model = 25078;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Ragefire Wand";
			Name2 = "Ragefire Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40857;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetSpell( 7687 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 32 , 60 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Icefury Wand)
*
***************************************************************/

namespace Server.Items
{
	public class IcefuryWand : Item
	{
		public IcefuryWand() : base()
		{
			Id = 7514;
			Bonding = 1;
			SellPrice = 8202;
			AvailableClasses = 0x80;
			Model = 25076;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Icefury Wand";
			Name2 = "Icefury Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41010;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetSpell( 7701 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 36 , 68 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Sable Wand)
*
***************************************************************/

namespace Server.Items
{
	public class SableWand : Item
	{
		public SableWand() : base()
		{
			Id = 7607;
			Bonding = 1;
			SellPrice = 1399;
			AvailableClasses = 0x7FFF;
			Model = 20920;
			ObjectClass = 2;
			SubClass = 19;
			Level = 22;
			Name = "Sable Wand";
			Name2 = "Sable Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6998;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 21 , 40 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Necrotic Wand)
*
***************************************************************/

namespace Server.Items
{
	public class NecroticWand : Item
	{
		public NecroticWand() : base()
		{
			Id = 7708;
			Bonding = 1;
			SellPrice = 6649;
			AvailableClasses = 0x7FFF;
			Model = 20825;
			ObjectClass = 2;
			SubClass = 19;
			Level = 35;
			ReqLevel = 30;
			Name = "Necrotic Wand";
			Name2 = "Necrotic Wand";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 33249;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 32 , 61 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Sizzle Stick)
*
***************************************************************/

namespace Server.Items
{
	public class SizzleStick : Item
	{
		public SizzleStick() : base()
		{
			Id = 8071;
			Bonding = 1;
			SellPrice = 1534;
			AvailableClasses = 0x7FFF;
			Model = 6093;
			ObjectClass = 2;
			SubClass = 19;
			Level = 23;
			Name = "Sizzle Stick";
			Name2 = "Sizzle Stick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7673;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 21 , 39 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Firestarter)
*
***************************************************************/

namespace Server.Items
{
	public class Firestarter : Item
	{
		public Firestarter() : base()
		{
			Id = 8184;
			Bonding = 2;
			SellPrice = 2947;
			AvailableClasses = 0x7FFF;
			Model = 18346;
			ObjectClass = 2;
			SubClass = 19;
			Level = 29;
			ReqLevel = 24;
			Name = "Firestarter";
			Name2 = "Firestarter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14737;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 24 , 46 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Dire Wand)
*
***************************************************************/

namespace Server.Items
{
	public class DireWand : Item
	{
		public DireWand() : base()
		{
			Id = 8186;
			Bonding = 2;
			SellPrice = 2231;
			AvailableClasses = 0x7FFF;
			Model = 20851;
			ObjectClass = 2;
			SubClass = 19;
			Level = 26;
			ReqLevel = 21;
			Name = "Dire Wand";
			Name2 = "Dire Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11156;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 24 , 45 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Earthen Rod)
*
***************************************************************/

namespace Server.Items
{
	public class EarthenRod : Item
	{
		public EarthenRod() : base()
		{
			Id = 9381;
			Bonding = 2;
			SellPrice = 8628;
			AvailableClasses = 0x7FFF;
			Model = 21025;
			ObjectClass = 2;
			SubClass = 19;
			Level = 38;
			ReqLevel = 33;
			Name = "Earthen Rod";
			Name2 = "Earthen Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43144;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 42 , 79 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Flaming Incinerator)
*
***************************************************************/

namespace Server.Items
{
	public class FlamingIncinerator : Item
	{
		public FlamingIncinerator() : base()
		{
			Id = 9483;
			Bonding = 2;
			SellPrice = 19139;
			AvailableClasses = 0x7FFF;
			Model = 20786;
			Resistance[2] = 8;
			ObjectClass = 2;
			SubClass = 19;
			Level = 49;
			ReqLevel = 44;
			Name = "Flaming Incinerator";
			Name2 = "Flaming Incinerator";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 95695;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 59 , 111 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Gyromatic Icemaker)
*
***************************************************************/

namespace Server.Items
{
	public class GyromaticIcemaker : Item
	{
		public GyromaticIcemaker() : base()
		{
			Id = 9489;
			Bonding = 1;
			SellPrice = 3690;
			AvailableClasses = 0x7FFF;
			Model = 18408;
			Resistance[4] = 5;
			ObjectClass = 2;
			SubClass = 19;
			Level = 31;
			ReqLevel = 26;
			Name = "Gyromatic Icemaker";
			Name2 = "Gyromatic Icemaker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18450;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 24 , 46 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Cairnstone Sliver)
*
***************************************************************/

namespace Server.Items
{
	public class CairnstoneSliver : Item
	{
		public CairnstoneSliver() : base()
		{
			Id = 9654;
			Bonding = 1;
			SellPrice = 16928;
			AvailableClasses = 0x7FFF;
			Model = 28307;
			ObjectClass = 2;
			SubClass = 19;
			Level = 50;
			Name = "Cairnstone Sliver";
			Name2 = "Cairnstone Sliver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84644;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 52 , 97 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Freezing Shard)
*
***************************************************************/

namespace Server.Items
{
	public class FreezingShard : Item
	{
		public FreezingShard() : base()
		{
			Id = 10572;
			Bonding = 2;
			SellPrice = 9592;
			AvailableClasses = 0x80;
			Model = 28747;
			ObjectClass = 2;
			SubClass = 19;
			Level = 39;
			ReqLevel = 34;
			Name = "Freezing Shard";
			Name2 = "Freezing Shard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47960;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 7703 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 32 , 61 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Chillnail Splinter)
*
***************************************************************/

namespace Server.Items
{
	public class ChillnailSplinter : Item
	{
		public ChillnailSplinter() : base()
		{
			Id = 10704;
			Bonding = 1;
			SellPrice = 13649;
			AvailableClasses = 0x7FFF;
			Model = 28267;
			ObjectClass = 2;
			SubClass = 19;
			Level = 46;
			Name = "Chillnail Splinter";
			Name2 = "Chillnail Splinter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68246;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 36 , 68 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Plaguerot Sprig)
*
***************************************************************/

namespace Server.Items
{
	public class PlaguerotSprig : Item
	{
		public PlaguerotSprig() : base()
		{
			Id = 10766;
			Bonding = 1;
			SellPrice = 9660;
			AvailableClasses = 0x80;
			Model = 21027;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			ReqLevel = 35;
			Name = "Plaguerot Sprig";
			Name2 = "Plaguerot Sprig";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48304;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 41 , 78 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Rod of Corrosion)
*
***************************************************************/

namespace Server.Items
{
	public class RodOfCorrosion : Item
	{
		public RodOfCorrosion() : base()
		{
			Id = 10836;
			Bonding = 1;
			SellPrice = 28989;
			AvailableClasses = 0x7FFF;
			Model = 20788;
			ObjectClass = 2;
			SubClass = 19;
			Level = 56;
			ReqLevel = 51;
			Name = "Rod of Corrosion";
			Name2 = "Rod of Corrosion";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 144946;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 50 , 93 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Nether Force Wand)
*
***************************************************************/

namespace Server.Items
{
	public class NetherForceWand : Item
	{
		public NetherForceWand() : base()
		{
			Id = 11263;
			Bonding = 1;
			SellPrice = 8419;
			AvailableClasses = 0x80;
			Model = 25077;
			ObjectClass = 2;
			SubClass = 19;
			Level = 40;
			Name = "Nether Force Wand";
			Name2 = "Nether Force Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42097;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetSpell( 13594 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 34 , 64 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Lesser Magic Wand)
*
***************************************************************/

namespace Server.Items
{
	public class LesserMagicWand : Item
	{
		public LesserMagicWand() : base()
		{
			Id = 11287;
			SellPrice = 104;
			AvailableClasses = 0x7FFF;
			Model = 21096;
			ObjectClass = 2;
			SubClass = 19;
			Level = 10;
			ReqLevel = 5;
			Name = "Lesser Magic Wand";
			Name2 = "Lesser Magic Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 521;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 25;
			SetDamage( 6 , 11 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Greater Magic Wand)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterMagicWand : Item
	{
		public GreaterMagicWand() : base()
		{
			Id = 11288;
			SellPrice = 466;
			AvailableClasses = 0x7FFF;
			Model = 21097;
			ObjectClass = 2;
			SubClass = 19;
			Level = 18;
			ReqLevel = 13;
			Name = "Greater Magic Wand";
			Name2 = "Greater Magic Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2330;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 15 , 28 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Lesser Mystic Wand)
*
***************************************************************/

namespace Server.Items
{
	public class LesserMysticWand : Item
	{
		public LesserMysticWand() : base()
		{
			Id = 11289;
			SellPrice = 2148;
			AvailableClasses = 0x7FFF;
			Model = 21098;
			ObjectClass = 2;
			SubClass = 19;
			Level = 31;
			ReqLevel = 26;
			Name = "Lesser Mystic Wand";
			Name2 = "Lesser Mystic Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10743;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 21 , 39 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Greater Mystic Wand)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterMysticWand : Item
	{
		public GreaterMysticWand() : base()
		{
			Id = 11290;
			SellPrice = 3157;
			AvailableClasses = 0x7FFF;
			Model = 21101;
			ObjectClass = 2;
			SubClass = 19;
			Level = 35;
			ReqLevel = 30;
			Name = "Greater Mystic Wand";
			Name2 = "Greater Mystic Wand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15789;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 38 , 71 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Pyric Caduceus)
*
***************************************************************/

namespace Server.Items
{
	public class PyricCaduceus : Item
	{
		public PyricCaduceus() : base()
		{
			Id = 11748;
			Bonding = 1;
			SellPrice = 25083;
			AvailableClasses = 0x7FFF;
			Model = 28807;
			ObjectClass = 2;
			SubClass = 19;
			Level = 53;
			ReqLevel = 48;
			Name = "Pyric Caduceus";
			Name2 = "Pyric Caduceus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125416;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 9400 , 1 , 0 , 0 , 0 , 0 );
			SetDamage( 66 , 123 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Charged Lightning Rod)
*
***************************************************************/

namespace Server.Items
{
	public class ChargedLightningRod : Item
	{
		public ChargedLightningRod() : base()
		{
			Id = 11860;
			Bonding = 1;
			SellPrice = 12970;
			AvailableClasses = 0x7FFF;
			Model = 28108;
			ObjectClass = 2;
			SubClass = 19;
			Level = 46;
			Name = "Charged Lightning Rod";
			Name2 = "Charged Lightning Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64854;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 39 , 73 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Spark of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class SparkOfThePeoplesMilitia : Item
	{
		public SparkOfThePeoplesMilitia() : base()
		{
			Id = 12296;
			Bonding = 1;
			SellPrice = 722;
			AvailableClasses = 0x7FFF;
			Model = 28248;
			ObjectClass = 2;
			SubClass = 19;
			Level = 17;
			Name = "Spark of the People's Militia";
			Name2 = "Spark of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3612;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			SetDamage( 16 , 30 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Serpentine Skuller)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentineSkuller : Item
	{
		public SerpentineSkuller() : base()
		{
			Id = 12605;
			Bonding = 1;
			SellPrice = 29106;
			AvailableClasses = 0x7FFF;
			Model = 24107;
			ObjectClass = 2;
			SubClass = 19;
			Level = 56;
			ReqLevel = 51;
			Name = "Serpentine Skuller";
			Name2 = "Serpentine Skuller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 145533;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 53 , 100 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Skycaller)
*
***************************************************************/

namespace Server.Items
{
	public class Skycaller : Item
	{
		public Skycaller() : base()
		{
			Id = 12984;
			Bonding = 2;
			SellPrice = 1423;
			AvailableClasses = 0x7FFF;
			Model = 28738;
			ObjectClass = 2;
			SubClass = 19;
			Level = 21;
			ReqLevel = 16;
			Name = "Skycaller";
			Name2 = "Skycaller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7115;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			SetDamage( 24 , 45 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Torch of Austen)
*
***************************************************************/

namespace Server.Items
{
	public class TorchOfAusten : Item
	{
		public TorchOfAusten() : base()
		{
			Id = 13004;
			Bonding = 2;
			SellPrice = 33590;
			AvailableClasses = 0x7FFF;
			Model = 28631;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 19;
			Level = 58;
			ReqLevel = 53;
			Name = "Torch of Austen";
			Name2 = "Torch of Austen";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 167954;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 55 , 104 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Thunderwood)
*
***************************************************************/

namespace Server.Items
{
	public class Thunderwood : Item
	{
		public Thunderwood() : base()
		{
			Id = 13062;
			Bonding = 2;
			SellPrice = 2991;
			AvailableClasses = 0x7FFF;
			Model = 28633;
			ObjectClass = 2;
			SubClass = 19;
			Level = 27;
			ReqLevel = 22;
			Name = "Thunderwood";
			Name2 = "Thunderwood";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14958;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			SetDamage( 36 , 67 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Starfaller)
*
***************************************************************/

namespace Server.Items
{
	public class Starfaller : Item
	{
		public Starfaller() : base()
		{
			Id = 13063;
			Bonding = 2;
			SellPrice = 5851;
			AvailableClasses = 0x7FFF;
			Model = 28697;
			ObjectClass = 2;
			SubClass = 19;
			Level = 34;
			ReqLevel = 29;
			Name = "Starfaller";
			Name2 = "Starfaller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29259;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 32 , 60 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Jaina's Firestarter)
*
***************************************************************/

namespace Server.Items
{
	public class JainasFirestarter : Item
	{
		public JainasFirestarter() : base()
		{
			Id = 13064;
			Bonding = 2;
			SellPrice = 11487;
			AvailableClasses = 0x7FFF;
			Model = 28787;
			ObjectClass = 2;
			SubClass = 19;
			Level = 42;
			ReqLevel = 37;
			Name = "Jaina's Firestarter";
			Name2 = "Jaina's Firestarter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57435;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 44 , 82 , Resistances.Fire );
			SpiritBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wand of Allistarj)
*
***************************************************************/

namespace Server.Items
{
	public class WandOfAllistarj : Item
	{
		public WandOfAllistarj() : base()
		{
			Id = 13065;
			Resistance[6] = 9;
			Bonding = 2;
			SellPrice = 20945;
			AvailableClasses = 0x7FFF;
			Model = 28626;
			ObjectClass = 2;
			SubClass = 19;
			Level = 50;
			ReqLevel = 45;
			Name = "Wand of Allistarj";
			Name2 = "Wand of Allistarj";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 104728;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 64 , 120 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Skul's Ghastly Touch)
*
***************************************************************/

namespace Server.Items
{
	public class SkulsGhastlyTouch : Item
	{
		public SkulsGhastlyTouch() : base()
		{
			Id = 13396;
			Bonding = 1;
			SellPrice = 30853;
			AvailableClasses = 0x7FFF;
			Model = 24106;
			ObjectClass = 2;
			SubClass = 19;
			Level = 57;
			ReqLevel = 52;
			Name = "Skul's Ghastly Touch";
			Name2 = "Skul's Ghastly Touch";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 154265;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 9414 , 1 , 0 , 0 , 0 , 0 );
			SetDamage( 70 , 131 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Banshee Finger)
*
***************************************************************/

namespace Server.Items
{
	public class BansheeFinger : Item
	{
		public BansheeFinger() : base()
		{
			Id = 13534;
			Bonding = 1;
			SellPrice = 37727;
			AvailableClasses = 0x7FFF;
			Model = 24186;
			Resistance[4] = 10;
			ObjectClass = 2;
			SubClass = 19;
			Level = 60;
			ReqLevel = 55;
			Name = "Banshee Finger";
			Name2 = "Banshee Finger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 188639;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 79 , 148 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Bonecreeper Stylus)
*
***************************************************************/

namespace Server.Items
{
	public class BonecreeperStylus : Item
	{
		public BonecreeperStylus() : base()
		{
			Id = 13938;
			Bonding = 1;
			SellPrice = 39304;
			AvailableClasses = 0x7FFF;
			Model = 24743;
			ObjectClass = 2;
			SubClass = 19;
			Level = 62;
			ReqLevel = 57;
			Name = "Bonecreeper Stylus";
			Name2 = "Bonecreeper Stylus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 196521;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 9416 , 1 , 0 , 0 , 0 , 0 );
			SetDamage( 83 , 155 , Resistances.Arcane );
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Moonstone Wand)
*
***************************************************************/

namespace Server.Items
{
	public class MoonstoneWand : Item
	{
		public MoonstoneWand() : base()
		{
			Id = 15204;
			Bonding = 1;
			SellPrice = 779;
			AvailableClasses = 0x7FFF;
			Model = 28218;
			ObjectClass = 2;
			SubClass = 19;
			Level = 18;
			Name = "Moonstone Wand";
			Name2 = "Moonstone Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3899;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			SetDamage( 17 , 32 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Ivory Wand)
*
***************************************************************/

namespace Server.Items
{
	public class IvoryWand : Item
	{
		public IvoryWand() : base()
		{
			Id = 15279;
			Bonding = 2;
			SellPrice = 18267;
			AvailableClasses = 0x7FFF;
			Model = 28569;
			ObjectClass = 2;
			SubClass = 19;
			Level = 51;
			ReqLevel = 46;
			Name = "Ivory Wand";
			Name2 = "Ivory Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5280;
			BuyPrice = 91339;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 41 , 77 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Wizard's Hand)
*
***************************************************************/

namespace Server.Items
{
	public class WizardsHand : Item
	{
		public WizardsHand() : base()
		{
			Id = 15280;
			Bonding = 2;
			SellPrice = 20603;
			AvailableClasses = 0x7FFF;
			Model = 28457;
			ObjectClass = 2;
			SubClass = 19;
			Level = 53;
			ReqLevel = 48;
			Name = "Wizard's Hand";
			Name2 = "Wizard's Hand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5289;
			BuyPrice = 103018;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 56 , 104 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Glowstar Rod)
*
***************************************************************/

namespace Server.Items
{
	public class GlowstarRod : Item
	{
		public GlowstarRod() : base()
		{
			Id = 15281;
			Bonding = 2;
			SellPrice = 26110;
			AvailableClasses = 0x7FFF;
			Model = 28538;
			ObjectClass = 2;
			SubClass = 19;
			Level = 57;
			ReqLevel = 52;
			Name = "Glowstar Rod";
			Name2 = "Glowstar Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5298;
			BuyPrice = 130550;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 52 , 98 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Dragon Finger)
*
***************************************************************/

namespace Server.Items
{
	public class DragonFinger : Item
	{
		public DragonFinger() : base()
		{
			Id = 15282;
			Bonding = 2;
			SellPrice = 30628;
			AvailableClasses = 0x7FFF;
			Model = 28518;
			ObjectClass = 2;
			SubClass = 19;
			Level = 60;
			ReqLevel = 55;
			Name = "Dragon Finger";
			Name2 = "Dragon Finger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5307;
			BuyPrice = 153143;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 52 , 97 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Lunar Wand)
*
***************************************************************/

namespace Server.Items
{
	public class LunarWand : Item
	{
		public LunarWand() : base()
		{
			Id = 15283;
			Bonding = 2;
			SellPrice = 37365;
			AvailableClasses = 0x7FFF;
			Model = 28577;
			ObjectClass = 2;
			SubClass = 19;
			Level = 64;
			ReqLevel = 59;
			Name = "Lunar Wand";
			Name2 = "Lunar Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5850;
			BuyPrice = 186826;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 67 , 126 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Stingshot Wand)
*
***************************************************************/

namespace Server.Items
{
	public class StingshotWand : Item
	{
		public StingshotWand() : base()
		{
			Id = 15465;
			Bonding = 1;
			SellPrice = 2713;
			AvailableClasses = 0x7FFF;
			Model = 28216;
			ObjectClass = 2;
			SubClass = 19;
			Level = 28;
			Name = "Stingshot Wand";
			Name2 = "Stingshot Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13565;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			SetDamage( 28 , 52 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Kodo Brander)
*
***************************************************************/

namespace Server.Items
{
	public class KodoBrander : Item
	{
		public KodoBrander() : base()
		{
			Id = 15692;
			Bonding = 1;
			SellPrice = 6935;
			AvailableClasses = 0x7FFF;
			Model = 26412;
			ObjectClass = 2;
			SubClass = 19;
			Level = 38;
			Name = "Kodo Brander";
			Name2 = "Kodo Brander";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34677;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 41 , 77 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Captain Rackmore's Tiller)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainRackmoresTiller : Item
	{
		public CaptainRackmoresTiller() : base()
		{
			Id = 16789;
			Bonding = 1;
			SellPrice = 5992;
			AvailableClasses = 0x7FFF;
			Model = 28408;
			ObjectClass = 2;
			SubClass = 19;
			Level = 36;
			Name = "Captain Rackmore's Tiller";
			Name2 = "Captain Rackmore's Tiller";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29962;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 31 , 58 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Smokey's Fireshooter)
*
***************************************************************/

namespace Server.Items
{
	public class SmokeysFireshooter : Item
	{
		public SmokeysFireshooter() : base()
		{
			Id = 16993;
			Bonding = 1;
			SellPrice = 30989;
			AvailableClasses = 0x7FFF;
			Model = 28818;
			ObjectClass = 2;
			SubClass = 19;
			Level = 60;
			Name = "Smokey's Fireshooter";
			Name2 = "Smokey's Fireshooter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 154945;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 70 , 132 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Stormrager)
*
***************************************************************/

namespace Server.Items
{
	public class Stormrager : Item
	{
		public Stormrager() : base()
		{
			Id = 16997;
			Bonding = 1;
			SellPrice = 41603;
			AvailableClasses = 0x7FFF;
			Model = 28828;
			ObjectClass = 2;
			SubClass = 19;
			Level = 62;
			Name = "Stormrager";
			Name2 = "Stormrager";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 208016;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 57 , 106 , Resistances.Nature );
			StaminaBonus = 8;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Crimson Shocker)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonShocker : Item
	{
		public CrimsonShocker() : base()
		{
			Id = 17077;
			Bonding = 1;
			SellPrice = 59741;
			AvailableClasses = 0x7FFF;
			Model = 29195;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 19;
			Level = 63;
			ReqLevel = 58;
			Name = "Crimson Shocker";
			Name2 = "Crimson Shocker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 298709;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			SetDamage( 102 , 191 , Resistances.Fire );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Noxious Shooter)
*
***************************************************************/

namespace Server.Items
{
	public class NoxiousShooter : Item
	{
		public NoxiousShooter() : base()
		{
			Id = 17745;
			Bonding = 1;
			SellPrice = 22519;
			AvailableClasses = 0x7FFF;
			Model = 29924;
			ObjectClass = 2;
			SubClass = 19;
			Level = 51;
			ReqLevel = 46;
			Name = "Noxious Shooter";
			Name2 = "Noxious Shooter";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112599;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 56 , 104 , Resistances.Nature );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lethtendris's Wand)
*
***************************************************************/

namespace Server.Items
{
	public class LethtendrissWand : Item
	{
		public LethtendrissWand() : base()
		{
			Id = 18301;
			Bonding = 1;
			SellPrice = 29363;
			AvailableClasses = 0x7FFF;
			Model = 30660;
			ObjectClass = 2;
			SubClass = 19;
			Level = 58;
			ReqLevel = 53;
			Name = "Lethtendris's Wand";
			Name2 = "Lethtendris's Wand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 146815;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 60 , 113 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Wand of Arcane Potency)
*
***************************************************************/

namespace Server.Items
{
	public class WandOfArcanePotency : Item
	{
		public WandOfArcanePotency() : base()
		{
			Id = 18338;
			Bonding = 1;
			SellPrice = 36595;
			AvailableClasses = 0x7FFF;
			Model = 21016;
			ObjectClass = 2;
			SubClass = 19;
			Level = 59;
			ReqLevel = 54;
			Name = "Wand of Arcane Potency";
			Name2 = "Wand of Arcane Potency";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 182979;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 13601 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 65 , 122 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Mana Channeling Wand)
*
***************************************************************/

namespace Server.Items
{
	public class ManaChannelingWand : Item
	{
		public ManaChannelingWand() : base()
		{
			Id = 18483;
			Bonding = 1;
			SellPrice = 37362;
			AvailableClasses = 0x7FFF;
			Model = 25076;
			ObjectClass = 2;
			SubClass = 19;
			Level = 61;
			ReqLevel = 56;
			Name = "Mana Channeling Wand";
			Name2 = "Mana Channeling Wand";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 186810;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 21619 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 68 , 127 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Oblivion's Touch)
*
***************************************************************/

namespace Server.Items
{
	public class OblivionsTouch : Item
	{
		public OblivionsTouch() : base()
		{
			Id = 18761;
			Bonding = 1;
			SellPrice = 41011;
			AvailableClasses = 0x7FFF;
			Model = 31677;
			ObjectClass = 2;
			SubClass = 19;
			Level = 62;
			ReqLevel = 57;
			Name = "Oblivion's Touch";
			Name2 = "Oblivion's Touch";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 205055;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetDamage( 78 , 147 , Resistances.Shadow );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Wand of Biting Cold)
*
***************************************************************/

namespace Server.Items
{
	public class WandOfBitingCold : Item
	{
		public WandOfBitingCold() : base()
		{
			Id = 19108;
			Bonding = 1;
			SellPrice = 44327;
			AvailableClasses = 0x7FFF;
			Model = 15238;
			ObjectClass = 2;
			SubClass = 19;
			Level = 63;
			Name = "Wand of Biting Cold";
			Name2 = "Wand of Biting Cold";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 221635;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			SetSpell( 9304 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 67 , 125 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Nature's Breath)
*
***************************************************************/

namespace Server.Items
{
	public class NaturesBreath : Item
	{
		public NaturesBreath() : base()
		{
			Id = 19118;
			Bonding = 1;
			SellPrice = 17344;
			AvailableClasses = 0x7FFF;
			Model = 31628;
			ObjectClass = 2;
			SubClass = 19;
			Level = 50;
			Name = "Nature's Breath";
			Name2 = "Nature's Breath";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86722;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			SetDamage( 40 , 75 , Resistances.Nature );
			SpiritBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cold Snap)
*
***************************************************************/

namespace Server.Items
{
	public class ColdSnap : Item
	{
		public ColdSnap() : base()
		{
			Id = 19130;
			Bonding = 1;
			SellPrice = 77791;
			AvailableClasses = 0x7FFF;
			Model = 31645;
			ObjectClass = 2;
			SubClass = 19;
			Level = 70;
			ReqLevel = 60;
			Name = "Cold Snap";
			Name2 = "Cold Snap";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 388958;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			SetSpell( 9307 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 101 , 189 , Resistances.Frost );
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Essence Gatherer)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceGatherer : Item
	{
		public EssenceGatherer() : base()
		{
			Id = 19435;
			Bonding = 1;
			SellPrice = 79598;
			AvailableClasses = 0x7FFF;
			Model = 31977;
			ObjectClass = 2;
			SubClass = 19;
			Level = 70;
			ReqLevel = 60;
			Name = "Essence Gatherer";
			Name2 = "Essence Gatherer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 397992;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 83 , 156 , Resistances.Arcane );
			SpiritBonus = 7;
			StaminaBonus = 5;
		}
	}
}


