/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:09:57 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Steelarrow Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class SteelarrowCrossbow : Item
	{
		public SteelarrowCrossbow() : base()
		{
			Id = 6315;
			Bonding = 2;
			SellPrice = 2546;
			AvailableClasses = 0x7FFF;
			Model = 11247;
			ObjectClass = 2;
			SubClass = 18;
			Level = 27;
			ReqLevel = 22;
			Name = "Steelarrow Crossbow";
			Name2 = "Steelarrow Crossbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12733;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			AmmoType = 2;
			SetDamage( 29 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blackcrow)
*
***************************************************************/

namespace Server.Items
{
	public class Blackcrow : Item
	{
		public Blackcrow() : base()
		{
			Id = 12651;
			Bonding = 1;
			SellPrice = 36055;
			AvailableClasses = 0x7FFF;
			Model = 22929;
			ObjectClass = 2;
			SubClass = 18;
			Level = 59;
			ReqLevel = 54;
			Name = "Blackcrow";
			Name2 = "Blackcrow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 180279;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 77 , 117 , Resistances.Armor );
			SetDamage( 1 , 4 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Crystalpine Stinger)
*
***************************************************************/

namespace Server.Items
{
	public class CrystalpineStinger : Item
	{
		public CrystalpineStinger() : base()
		{
			Id = 13037;
			Bonding = 2;
			SellPrice = 4729;
			AvailableClasses = 0x7FFF;
			Model = 22929;
			ObjectClass = 2;
			SubClass = 18;
			Level = 32;
			ReqLevel = 27;
			Name = "Crystalpine Stinger";
			Name2 = "Crystalpine Stinger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23645;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 35 , 54 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Swiftwind)
*
***************************************************************/

namespace Server.Items
{
	public class Swiftwind : Item
	{
		public Swiftwind() : base()
		{
			Id = 13038;
			Bonding = 2;
			SellPrice = 9630;
			AvailableClasses = 0x7FFF;
			Model = 25607;
			ObjectClass = 2;
			SubClass = 18;
			Level = 40;
			ReqLevel = 35;
			Name = "Swiftwind";
			Name2 = "Swiftwind";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48150;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 34 , 51 , Resistances.Armor );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Skull Splitting Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class SkullSplittingCrossbow : Item
	{
		public SkullSplittingCrossbow() : base()
		{
			Id = 13039;
			Bonding = 2;
			SellPrice = 17892;
			AvailableClasses = 0x7FFF;
			Model = 25608;
			ObjectClass = 2;
			SubClass = 18;
			Level = 48;
			ReqLevel = 43;
			Name = "Skull Splitting Crossbow";
			Name2 = "Skull Splitting Crossbow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89461;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 9142 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 52 , 79 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heartseeking Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class HeartseekingCrossbow : Item
	{
		public HeartseekingCrossbow() : base()
		{
			Id = 13040;
			Bonding = 2;
			SellPrice = 29444;
			AvailableClasses = 0x7FFF;
			Model = 22929;
			ObjectClass = 2;
			SubClass = 18;
			Level = 56;
			ReqLevel = 51;
			Name = "Heartseeking Crossbow";
			Name2 = "Heartseeking Crossbow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 147220;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 71 , 108 , Resistances.Armor );
			SetDamage( 1 , 4 , Resistances.Shadow );
			AgilityBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Light Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class LightCrossbow : Item
	{
		public LightCrossbow() : base()
		{
			Id = 15807;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 10671;
			ObjectClass = 2;
			SubClass = 18;
			Level = 8;
			ReqLevel = 3;
			Name = "Light Crossbow";
			Name2 = "Light Crossbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 294;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 30;
			AmmoType = 2;
			SetDamage( 6 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fine Light Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class FineLightCrossbow : Item
	{
		public FineLightCrossbow() : base()
		{
			Id = 15808;
			SellPrice = 728;
			AvailableClasses = 0x7FFF;
			Model = 10671;
			ObjectClass = 2;
			SubClass = 18;
			Level = 21;
			ReqLevel = 16;
			Name = "Fine Light Crossbow";
			Name2 = "Fine Light Crossbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3640;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			AmmoType = 2;
			SetDamage( 20 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyCrossbow : Item
	{
		public HeavyCrossbow() : base()
		{
			Id = 15809;
			SellPrice = 2938;
			AvailableClasses = 0x7FFF;
			Model = 28911;
			ObjectClass = 2;
			SubClass = 18;
			Level = 34;
			ReqLevel = 29;
			Name = "Heavy Crossbow";
			Name2 = "Heavy Crossbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14691;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 36 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stoneshatter)
*
***************************************************************/

namespace Server.Items
{
	public class Stoneshatter : Item
	{
		public Stoneshatter() : base()
		{
			Id = 18388;
			Bonding = 1;
			SellPrice = 41928;
			AvailableClasses = 0x7FFF;
			Model = 30747;
			ObjectClass = 2;
			SubClass = 18;
			Level = 62;
			ReqLevel = 57;
			Name = "Stoneshatter";
			Name2 = "Stoneshatter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 209641;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 22188 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 111 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Carapace Spine Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class CarapaceSpineCrossbow : Item
	{
		public CarapaceSpineCrossbow() : base()
		{
			Id = 18738;
			Bonding = 1;
			SellPrice = 37593;
			AvailableClasses = 0x7FFF;
			Model = 31239;
			ObjectClass = 2;
			SubClass = 18;
			Level = 61;
			ReqLevel = 56;
			Name = "Carapace Spine Crossbow";
			Name2 = "Carapace Spine Crossbow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 187966;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 82 , 124 , Resistances.Armor );
			StaminaBonus = 9;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Repeater)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsRepeater : Item
	{
		public GrandMarshalsRepeater() : base()
		{
			Id = 18836;
			Bonding = 1;
			SellPrice = 35130;
			AvailableClasses = 0x7FFF;
			Model = 31757;
			ObjectClass = 2;
			SubClass = 18;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Repeater";
			Name2 = "Grand Marshal's Repeater";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 175650;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 107 , 162 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Crossbow)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsCrossbow : Item
	{
		public HighWarlordsCrossbow() : base()
		{
			Id = 18837;
			Bonding = 1;
			SellPrice = 35259;
			AvailableClasses = 0x7FFF;
			Model = 31749;
			ObjectClass = 2;
			SubClass = 18;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Crossbow";
			Name2 = "High Warlord's Crossbow";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 176297;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 107 , 162 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodseeker)
*
***************************************************************/

namespace Server.Items
{
	public class Bloodseeker : Item
	{
		public Bloodseeker() : base()
		{
			Id = 19107;
			Bonding = 1;
			SellPrice = 44171;
			AvailableClasses = 0x7FFF;
			Model = 32152;
			ObjectClass = 2;
			SubClass = 18;
			Level = 63;
			Name = "Bloodseeker";
			Name2 = "Bloodseeker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 220858;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 85 , 128 , Resistances.Armor );
			AgilityBonus = 7;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ashjre'thul, Crossbow of Smiting)
*
***************************************************************/

namespace Server.Items
{
	public class AshjrethulCrossbowOfSmiting : Item
	{
		public AshjrethulCrossbowOfSmiting() : base()
		{
			Id = 19361;
			Bonding = 1;
			SellPrice = 111546;
			AvailableClasses = 0x7FFF;
			Model = 31909;
			ObjectClass = 2;
			SubClass = 18;
			Level = 77;
			ReqLevel = 60;
			Name = "Ashjre'thul, Crossbow of Smiting";
			Name2 = "Ashjre'thul, Crossbow of Smiting";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 557734;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 124 , 186 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


