
/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:00 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Worn Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class WornShortbow : Item
	{
		public WornShortbow() : base()
		{
			Id = 2504;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 8106;
			ObjectClass = 2;
			SubClass = 2;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Shortbow";
			Name2 = "Worn Shortbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 29;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 20;
			AmmoType = 2;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Polished Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedShortbow : Item
	{
		public PolishedShortbow() : base()
		{
			Id = 2505;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 20723;
			ObjectClass = 2;
			SubClass = 2;
			Level = 4;
			ReqLevel = 1;
			Name = "Polished Shortbow";
			Name2 = "Polished Shortbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 59;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 20;
			AmmoType = 2;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hornwood Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HornwoodRecurveBow : Item
	{
		public HornwoodRecurveBow() : base()
		{
			Id = 2506;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 20722;
			ObjectClass = 2;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Hornwood Recurve Bow";
			Name2 = "Hornwood Recurve Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Durability = 30;
			AmmoType = 2;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Laminated Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedRecurveBow : Item
	{
		public LaminatedRecurveBow() : base()
		{
			Id = 2507;
			SellPrice = 350;
			AvailableClasses = 0x7FFF;
			Model = 20714;
			ObjectClass = 2;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Laminated Recurve Bow";
			Name2 = "Laminated Recurve Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1751;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			AmmoType = 2;
			SetDamage( 10 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cracked Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedShortbow : Item
	{
		public CrackedShortbow() : base()
		{
			Id = 2773;
			SellPrice = 39;
			AvailableClasses = 0x7FFF;
			Model = 2786;
			ObjectClass = 2;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Cracked Shortbow";
			Name2 = "Cracked Shortbow";
			AvailableRaces = 0x1FF;
			BuyPrice = 195;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 30;
			AmmoType = 2;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Feeble Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class FeebleShortbow : Item
	{
		public FeebleShortbow() : base()
		{
			Id = 2777;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 2787;
			ObjectClass = 2;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Feeble Shortbow";
			Name2 = "Feeble Shortbow";
			AvailableRaces = 0x1FF;
			BuyPrice = 734;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			AmmoType = 2;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Light Hunting Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LightHuntingBow : Item
	{
		public LightHuntingBow() : base()
		{
			Id = 2780;
			SellPrice = 374;
			AvailableClasses = 0x7FFF;
			Model = 20712;
			ObjectClass = 2;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Light Hunting Bow";
			Name2 = "Light Hunting Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 1872;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			AmmoType = 2;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mishandled Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class MishandledRecurveBow : Item
	{
		public MishandledRecurveBow() : base()
		{
			Id = 2782;
			SellPrice = 751;
			AvailableClasses = 0x7FFF;
			Model = 20671;
			ObjectClass = 2;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Mishandled Recurve Bow";
			Name2 = "Mishandled Recurve Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 3759;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			AmmoType = 2;
			SetDamage( 9 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stiff Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class StiffRecurveBow : Item
	{
		public StiffRecurveBow() : base()
		{
			Id = 2785;
			SellPrice = 1062;
			AvailableClasses = 0x7FFF;
			Model = 20668;
			ObjectClass = 2;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Stiff Recurve Bow";
			Name2 = "Stiff Recurve Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 5311;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			AmmoType = 2;
			SetDamage( 13 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hurricane)
*
***************************************************************/

namespace Server.Items
{
	public class Hurricane : Item
	{
		public Hurricane() : base()
		{
			Id = 2824;
			Bonding = 2;
			SellPrice = 32031;
			AvailableClasses = 0x7FFF;
			Model = 20554;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Hurricane";
			Name2 = "Hurricane";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 160159;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			SetDamage( 34 , 63 , Resistances.Armor );
			SetDamage( 1 , 5 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Bow of Searing Arrows)
*
***************************************************************/

namespace Server.Items
{
	public class BowOfSearingArrows : Item
	{
		public BowOfSearingArrows() : base()
		{
			Id = 2825;
			Bonding = 2;
			SellPrice = 14721;
			AvailableClasses = 0x7FFF;
			Model = 20552;
			ObjectClass = 2;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Bow of Searing Arrows";
			Name2 = "Bow of Searing Arrows";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 73609;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			SetDamage( 47 , 88 , Resistances.Armor );
			SetDamage( 1 , 5 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Daryl's Hunting Bow)
*
***************************************************************/

namespace Server.Items
{
	public class DarylsHuntingBow : Item
	{
		public DarylsHuntingBow() : base()
		{
			Id = 2903;
			Bonding = 1;
			SellPrice = 515;
			AvailableClasses = 0x7FFF;
			Model = 8107;
			ObjectClass = 2;
			SubClass = 2;
			Level = 15;
			Name = "Daryl's Hunting Bow";
			Name2 = "Daryl's Hunting Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2578;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			AmmoType = 2;
			SetDamage( 9 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ranger Bow)
*
***************************************************************/

namespace Server.Items
{
	public class RangerBow : Item
	{
		public RangerBow() : base()
		{
			Id = 3021;
			Bonding = 2;
			SellPrice = 2421;
			AvailableClasses = 0x7FFF;
			Model = 20673;
			ObjectClass = 2;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Ranger Bow";
			Name2 = "Ranger Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12105;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 23 , 45 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Reinforced Bow)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedBow : Item
	{
		public ReinforcedBow() : base()
		{
			Id = 3026;
			SellPrice = 762;
			AvailableClasses = 0x7FFF;
			Model = 20675;
			ObjectClass = 2;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Reinforced Bow";
			Name2 = "Reinforced Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3812;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			AmmoType = 2;
			SetDamage( 11 , 22 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyRecurveBow : Item
	{
		public HeavyRecurveBow() : base()
		{
			Id = 3027;
			SellPrice = 1269;
			AvailableClasses = 0x7FFF;
			Model = 20670;
			ObjectClass = 2;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Heavy Recurve Bow";
			Name2 = "Heavy Recurve Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6349;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			AmmoType = 2;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyShortbow : Item
	{
		public HeavyShortbow() : base()
		{
			Id = 3036;
			Bonding = 2;
			SellPrice = 515;
			AvailableClasses = 0x7FFF;
			Model = 5392;
			ObjectClass = 2;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Heavy Shortbow";
			Name2 = "Heavy Shortbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2578;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			AmmoType = 2;
			SetDamage( 10 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Whipwood Recurve Bow)
*
***************************************************************/

namespace Server.Items
{
	public class WhipwoodRecurveBow : Item
	{
		public WhipwoodRecurveBow() : base()
		{
			Id = 3037;
			Bonding = 2;
			SellPrice = 4814;
			AvailableClasses = 0x7FFF;
			Model = 20653;
			ObjectClass = 2;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Whipwood Recurve Bow";
			Name2 = "Whipwood Recurve Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24071;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Short Ash Bow)
*
***************************************************************/

namespace Server.Items
{
	public class ShortAshBow : Item
	{
		public ShortAshBow() : base()
		{
			Id = 3039;
			Bonding = 2;
			SellPrice = 1610;
			AvailableClasses = 0x7FFF;
			Model = 20672;
			ObjectClass = 2;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Short Ash Bow";
			Name2 = "Short Ash Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8052;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 55;
			AmmoType = 2;
			SetDamage( 12 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Naga Heartpiercer)
*
***************************************************************/

namespace Server.Items
{
	public class NagaHeartpiercer : Item
	{
		public NagaHeartpiercer() : base()
		{
			Id = 3078;
			Bonding = 1;
			SellPrice = 2314;
			AvailableClasses = 0x7FFF;
			Model = 20669;
			ObjectClass = 2;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Naga Heartpiercer";
			Name2 = "Naga Heartpiercer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11572;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			AmmoType = 2;
			SetDamage( 13 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Raptor's End)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorsEnd : Item
	{
		public RaptorsEnd() : base()
		{
			Id = 3493;
			Bonding = 1;
			SellPrice = 3426;
			AvailableClasses = 0x7FFF;
			Model = 20664;
			ObjectClass = 2;
			SubClass = 2;
			Level = 30;
			Name = "Raptor's End";
			Name2 = "Raptor's End";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17133;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 24 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bow of Plunder)
*
***************************************************************/

namespace Server.Items
{
	public class BowOfPlunder : Item
	{
		public BowOfPlunder() : base()
		{
			Id = 3742;
			Bonding = 1;
			SellPrice = 2862;
			AvailableClasses = 0x7FFF;
			Model = 20667;
			ObjectClass = 2;
			SubClass = 2;
			Level = 28;
			Name = "Bow of Plunder";
			Name2 = "Bow of Plunder";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14311;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			AmmoType = 2;
			SetDamage( 20 , 39 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Taut Compound Bow)
*
***************************************************************/

namespace Server.Items
{
	public class TautCompoundBow : Item
	{
		public TautCompoundBow() : base()
		{
			Id = 3778;
			SellPrice = 1541;
			AvailableClasses = 0x7FFF;
			Model = 20660;
			ObjectClass = 2;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Taut Compound Bow";
			Name2 = "Taut Compound Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 7705;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 13 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Balanced Long Bow)
*
***************************************************************/

namespace Server.Items
{
	public class BalancedLongBow : Item
	{
		public BalancedLongBow() : base()
		{
			Id = 4025;
			SellPrice = 5070;
			AvailableClasses = 0x7FFF;
			Model = 20550;
			ObjectClass = 2;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Balanced Long Bow";
			Name2 = "Balanced Long Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 25351;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Trueshot Bow)
*
***************************************************************/

namespace Server.Items
{
	public class TrueshotBow : Item
	{
		public TrueshotBow() : base()
		{
			Id = 4087;
			Bonding = 2;
			SellPrice = 8722;
			AvailableClasses = 0x7FFF;
			Model = 4426;
			ObjectClass = 2;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Trueshot Bow";
			Name2 = "Trueshot Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5851;
			BuyPrice = 43611;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 24 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Master Hunter's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class MasterHuntersBow : Item
	{
		public MasterHuntersBow() : base()
		{
			Id = 4110;
			Bonding = 1;
			SellPrice = 11999;
			AvailableClasses = 0x7FFF;
			Model = 20555;
			ObjectClass = 2;
			SubClass = 2;
			Level = 45;
			Name = "Master Hunter's Bow";
			Name2 = "Master Hunter's Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59995;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			Flags = 16;
			SetDamage( 35 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ravenwood Bow)
*
***************************************************************/

namespace Server.Items
{
	public class RavenwoodBow : Item
	{
		public RavenwoodBow() : base()
		{
			Id = 4474;
			Bonding = 2;
			SellPrice = 4207;
			AvailableClasses = 0x7FFF;
			Model = 12883;
			ObjectClass = 2;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Ravenwood Bow";
			Name2 = "Ravenwood Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21037;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Light Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LightBow : Item
	{
		public LightBow() : base()
		{
			Id = 4576;
			Bonding = 2;
			SellPrice = 1184;
			AvailableClasses = 0x7FFF;
			Model = 20674;
			ObjectClass = 2;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Light Bow";
			Name2 = "Light Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5922;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 50;
			AmmoType = 2;
			SetDamage( 9 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hickory Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class HickoryShortbow : Item
	{
		public HickoryShortbow() : base()
		{
			Id = 4931;
			Bonding = 1;
			SellPrice = 134;
			AvailableClasses = 0x7FFF;
			Model = 7603;
			ObjectClass = 2;
			SubClass = 2;
			Level = 11;
			Name = "Hickory Shortbow";
			Name2 = "Hickory Shortbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 671;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			AmmoType = 2;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Orcish Battle Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishBattleBow : Item
	{
		public OrcishBattleBow() : base()
		{
			Id = 5346;
			Bonding = 1;
			SellPrice = 425;
			AvailableClasses = 0x7FFF;
			Model = 20719;
			ObjectClass = 2;
			SubClass = 2;
			Level = 14;
			Name = "Orcish Battle Bow";
			Name2 = "Orcish Battle Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2125;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			AmmoType = 2;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ashwood Bow)
*
***************************************************************/

namespace Server.Items
{
	public class AshwoodBow : Item
	{
		public AshwoodBow() : base()
		{
			Id = 5596;
			Bonding = 1;
			SellPrice = 141;
			AvailableClasses = 0x7FFF;
			Model = 20720;
			ObjectClass = 2;
			SubClass = 2;
			Level = 11;
			Name = "Ashwood Bow";
			Name2 = "Ashwood Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 708;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			AmmoType = 2;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lunaris Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LunarisBow : Item
	{
		public LunarisBow() : base()
		{
			Id = 5817;
			Bonding = 1;
			SellPrice = 3226;
			AvailableClasses = 0x7FFF;
			Model = 9060;
			ObjectClass = 2;
			SubClass = 2;
			Level = 30;
			Name = "Lunaris Bow";
			Name2 = "Lunaris Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16134;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Venomstrike)
*
***************************************************************/

namespace Server.Items
{
	public class Venomstrike : Item
	{
		public Venomstrike() : base()
		{
			Id = 6469;
			Bonding = 1;
			SellPrice = 2240;
			AvailableClasses = 0x7FFF;
			Model = 20652;
			ObjectClass = 2;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Venomstrike";
			Name2 = "Venomstrike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11201;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 16 , 30 , Resistances.Armor );
			SetDamage( 3 , 6 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Nightstalker Bow)
*
***************************************************************/

namespace Server.Items
{
	public class NightstalkerBow : Item
	{
		public NightstalkerBow() : base()
		{
			Id = 6696;
			Bonding = 1;
			SellPrice = 5086;
			AvailableClasses = 0x7FFF;
			Model = 20650;
			ObjectClass = 2;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Nightstalker Bow";
			Name2 = "Nightstalker Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25431;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 19 , 36 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cliffrunner's Aim)
*
***************************************************************/

namespace Server.Items
{
	public class CliffrunnersAim : Item
	{
		public CliffrunnersAim() : base()
		{
			Id = 6739;
			Bonding = 1;
			SellPrice = 2991;
			AvailableClasses = 0x7FFF;
			Model = 20666;
			ObjectClass = 2;
			SubClass = 2;
			Level = 29;
			Name = "Cliffrunner's Aim";
			Name2 = "Cliffrunner's Aim";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14958;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 19 , 36 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cadet's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class CadetsBow : Item
	{
		public CadetsBow() : base()
		{
			Id = 8179;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 18343;
			ObjectClass = 2;
			SubClass = 2;
			Level = 6;
			ReqLevel = 1;
			Name = "Cadet's Bow";
			Name2 = "Cadet's Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 144;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 25;
			AmmoType = 2;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hunting Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingBow : Item
	{
		public HuntingBow() : base()
		{
			Id = 8180;
			Bonding = 2;
			SellPrice = 240;
			AvailableClasses = 0x7FFF;
			Model = 18350;
			ObjectClass = 2;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Hunting Bow";
			Name2 = "Hunting Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1203;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 35;
			AmmoType = 2;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Precision Bow)
*
***************************************************************/

namespace Server.Items
{
	public class PrecisionBow : Item
	{
		public PrecisionBow() : base()
		{
			Id = 8183;
			Bonding = 2;
			SellPrice = 2426;
			AvailableClasses = 0x7FFF;
			Model = 18355;
			ObjectClass = 2;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Precision Bow";
			Name2 = "Precision Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12132;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 60;
			AmmoType = 2;
			SetDamage( 20 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Baelog's Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class BaelogsShortbow : Item
	{
		public BaelogsShortbow() : base()
		{
			Id = 9400;
			SellPrice = 5414;
			AvailableClasses = 0x7FFF;
			Model = 20553;
			ObjectClass = 2;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Baelog's Shortbow";
			Name2 = "Baelog's Shortbow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27073;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 26 , 50 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Monolithic Bow)
*
***************************************************************/

namespace Server.Items
{
	public class MonolithicBow : Item
	{
		public MonolithicBow() : base()
		{
			Id = 9426;
			Bonding = 2;
			SellPrice = 10275;
			AvailableClasses = 0x7FFF;
			Model = 20556;
			ObjectClass = 2;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Monolithic Bow";
			Name2 = "Monolithic Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51375;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 41 , 77 , Resistances.Armor );
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Quillshooter)
*
***************************************************************/

namespace Server.Items
{
	public class Quillshooter : Item
	{
		public Quillshooter() : base()
		{
			Id = 10567;
			Bonding = 2;
			SellPrice = 8725;
			AvailableClasses = 0x7FFF;
			Model = 20649;
			ObjectClass = 2;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Quillshooter";
			Name2 = "Quillshooter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43628;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 31 , 58 , Resistances.Armor );
			SetDamage( 7 , 16 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Stinging Bow)
*
***************************************************************/

namespace Server.Items
{
	public class StingingBow : Item
	{
		public StingingBow() : base()
		{
			Id = 10624;
			Bonding = 2;
			SellPrice = 17249;
			AvailableClasses = 0x7FFF;
			Model = 25604;
			ObjectClass = 2;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Stinging Bow";
			Name2 = "Stinging Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86246;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 9142 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 36 , 67 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fine Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class FineShortbow : Item
	{
		public FineShortbow() : base()
		{
			Id = 11303;
			Bonding = 2;
			SellPrice = 636;
			AvailableClasses = 0x7FFF;
			Model = 8104;
			ObjectClass = 2;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Fine Shortbow";
			Name2 = "Fine Shortbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3184;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 40;
			AmmoType = 2;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fine Longbow)
*
***************************************************************/

namespace Server.Items
{
	public class FineLongbow : Item
	{
		public FineLongbow() : base()
		{
			Id = 11304;
			Bonding = 2;
			SellPrice = 972;
			AvailableClasses = 0x7FFF;
			Model = 20550;
			ObjectClass = 2;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Fine Longbow";
			Name2 = "Fine Longbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4861;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 45;
			AmmoType = 2;
			SetDamage( 14 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dense Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class DenseShortbow : Item
	{
		public DenseShortbow() : base()
		{
			Id = 11305;
			Bonding = 2;
			SellPrice = 5162;
			AvailableClasses = 0x7FFF;
			Model = 21111;
			ObjectClass = 2;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Dense Shortbow";
			Name2 = "Dense Shortbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25814;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 19 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sturdy Recurve)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyRecurve : Item
	{
		public SturdyRecurve() : base()
		{
			Id = 11306;
			Bonding = 2;
			SellPrice = 3893;
			AvailableClasses = 0x7FFF;
			Model = 20713;
			ObjectClass = 2;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Sturdy Recurve";
			Name2 = "Sturdy Recurve";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19467;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 20 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Massive Longbow)
*
***************************************************************/

namespace Server.Items
{
	public class MassiveLongbow : Item
	{
		public MassiveLongbow() : base()
		{
			Id = 11307;
			Bonding = 2;
			SellPrice = 13590;
			AvailableClasses = 0x7FFF;
			Model = 21112;
			ObjectClass = 2;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Massive Longbow";
			Name2 = "Massive Longbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67952;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 43 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sylvan Shortbow)
*
***************************************************************/

namespace Server.Items
{
	public class SylvanShortbow : Item
	{
		public SylvanShortbow() : base()
		{
			Id = 11308;
			Bonding = 2;
			SellPrice = 15765;
			AvailableClasses = 0x7FFF;
			Model = 21113;
			ObjectClass = 2;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Sylvan Shortbow";
			Name2 = "Sylvan Shortbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78828;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 32 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Houndmaster's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HoundmastersBow : Item
	{
		public HoundmastersBow() : base()
		{
			Id = 11628;
			Bonding = 1;
			SellPrice = 24433;
			AvailableClasses = 0x7FFF;
			Model = 28780;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Houndmaster's Bow";
			Name2 = "Houndmaster's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122167;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 18201 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 34 , 64 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thistlewood Bow)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodBow : Item
	{
		public ThistlewoodBow() : base()
		{
			Id = 12447;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 20723;
			ObjectClass = 2;
			SubClass = 2;
			Level = 5;
			Name = "Thistlewood Bow";
			Name2 = "Thistlewood Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 96;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 25;
			AmmoType = 2;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Primitive Bow)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveBow : Item
	{
		public PrimitiveBow() : base()
		{
			Id = 12449;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 28235;
			ObjectClass = 2;
			SubClass = 2;
			Level = 5;
			Name = "Primitive Bow";
			Name2 = "Primitive Bow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 96;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 25;
			AmmoType = 2;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Riphook)
*
***************************************************************/

namespace Server.Items
{
	public class Riphook : Item
	{
		public Riphook() : base()
		{
			Id = 12653;
			Bonding = 1;
			SellPrice = 36318;
			AvailableClasses = 0x7FFF;
			Model = 28813;
			ObjectClass = 2;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Riphook";
			Name2 = "Riphook";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 181593;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 46 , 87 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Harpyclaw Short Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HarpyclawShortBow : Item
	{
		public HarpyclawShortBow() : base()
		{
			Id = 13019;
			Bonding = 2;
			SellPrice = 4765;
			AvailableClasses = 0x7FFF;
			Model = 28772;
			ObjectClass = 2;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Harpyclaw Short Bow";
			Name2 = "Harpyclaw Short Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23828;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 20 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skystriker Bow)
*
***************************************************************/

namespace Server.Items
{
	public class SkystrikerBow : Item
	{
		public SkystrikerBow() : base()
		{
			Id = 13020;
			Bonding = 2;
			SellPrice = 8985;
			AvailableClasses = 0x7FFF;
			Model = 25602;
			ObjectClass = 2;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Skystriker Bow";
			Name2 = "Skystriker Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44927;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 30 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Needle Threader)
*
***************************************************************/

namespace Server.Items
{
	public class NeedleThreader : Item
	{
		public NeedleThreader() : base()
		{
			Id = 13021;
			Bonding = 2;
			SellPrice = 16694;
			AvailableClasses = 0x7FFF;
			Model = 28801;
			ObjectClass = 2;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Needle Threader";
			Name2 = "Needle Threader";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83473;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 34 , 64 , Resistances.Armor );
			IqBonus = 4;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Gryphonwing Long Bow)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonwingLongBow : Item
	{
		public GryphonwingLongBow() : base()
		{
			Id = 13022;
			Bonding = 2;
			SellPrice = 27990;
			AvailableClasses = 0x7FFF;
			Model = 28766;
			ObjectClass = 2;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Gryphonwing Long Bow";
			Name2 = "Gryphonwing Long Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 139952;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 53 , 100 , Resistances.Armor );
			AgilityBonus = 8;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Eaglehorn Long Bow)
*
***************************************************************/

namespace Server.Items
{
	public class EaglehornLongBow : Item
	{
		public EaglehornLongBow() : base()
		{
			Id = 13023;
			Bonding = 2;
			SellPrice = 42703;
			AvailableClasses = 0x7FFF;
			Model = 25606;
			ObjectClass = 2;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Eaglehorn Long Bow";
			Name2 = "Eaglehorn Long Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 213515;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 40 , 76 , Resistances.Armor );
			AgilityBonus = 10;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Voone's Twitchbow)
*
***************************************************************/

namespace Server.Items
{
	public class VoonesTwitchbow : Item
	{
		public VoonesTwitchbow() : base()
		{
			Id = 13175;
			Bonding = 1;
			SellPrice = 30619;
			AvailableClasses = 0x7FFF;
			Model = 25603;
			ObjectClass = 2;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Voone's Twitchbow";
			Name2 = "Voone's Twitchbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 153095;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 31 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Recurve Long Bow)
*
***************************************************************/

namespace Server.Items
{
	public class RecurveLongBow : Item
	{
		public RecurveLongBow() : base()
		{
			Id = 13824;
			SellPrice = 9015;
			AvailableClasses = 0x7FFF;
			Model = 20550;
			ObjectClass = 2;
			SubClass = 2;
			Level = 55;
			ReqLevel = 45;
			Name = "Recurve Long Bow";
			Name2 = "Recurve Long Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 45078;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 26 , 50 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long Battle Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LongBattleBow : Item
	{
		public LongBattleBow() : base()
		{
			Id = 15284;
			Bonding = 2;
			SellPrice = 3039;
			AvailableClasses = 0x7FFF;
			Model = 28572;
			ObjectClass = 2;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Long Battle Bow";
			Name2 = "Long Battle Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15199;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Archer's Longbow)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersLongbow : Item
	{
		public ArchersLongbow() : base()
		{
			Id = 15285;
			Bonding = 2;
			SellPrice = 4061;
			AvailableClasses = 0x7FFF;
			Model = 28308;
			ObjectClass = 2;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Archer's Longbow";
			Name2 = "Archer's Longbow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20305;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 23 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long Redwood Bow)
*
***************************************************************/

namespace Server.Items
{
	public class LongRedwoodBow : Item
	{
		public LongRedwoodBow() : base()
		{
			Id = 15286;
			Bonding = 2;
			SellPrice = 5568;
			AvailableClasses = 0x7FFF;
			Model = 28575;
			ObjectClass = 2;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Long Redwood Bow";
			Name2 = "Long Redwood Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27843;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 28 , 52 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crusader Bow)
*
***************************************************************/

namespace Server.Items
{
	public class CrusaderBow : Item
	{
		public CrusaderBow() : base()
		{
			Id = 15287;
			Bonding = 2;
			SellPrice = 12516;
			AvailableClasses = 0x7FFF;
			Model = 28344;
			ObjectClass = 2;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Crusader Bow";
			Name2 = "Crusader Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5852;
			BuyPrice = 62583;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 32 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blasthorn Bow)
*
***************************************************************/

namespace Server.Items
{
	public class BlasthornBow : Item
	{
		public BlasthornBow() : base()
		{
			Id = 15288;
			Bonding = 2;
			SellPrice = 33743;
			AvailableClasses = 0x7FFF;
			Model = 28322;
			ObjectClass = 2;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Blasthorn Bow";
			Name2 = "Blasthorn Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5838;
			BuyPrice = 168715;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 51 , 96 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Archstrike Bow)
*
***************************************************************/

namespace Server.Items
{
	public class ArchstrikeBow : Item
	{
		public ArchstrikeBow() : base()
		{
			Id = 15289;
			Bonding = 2;
			SellPrice = 41161;
			AvailableClasses = 0x7FFF;
			Model = 28309;
			ObjectClass = 2;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Archstrike Bow";
			Name2 = "Archstrike Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5859;
			BuyPrice = 205809;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 48 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Harpy Needler)
*
***************************************************************/

namespace Server.Items
{
	public class HarpyNeedler : Item
	{
		public HarpyNeedler() : base()
		{
			Id = 15291;
			Bonding = 2;
			SellPrice = 19591;
			AvailableClasses = 0x7FFF;
			Model = 28543;
			ObjectClass = 2;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Harpy Needler";
			Name2 = "Harpy Needler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5854;
			BuyPrice = 97958;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 44 , 84 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Siege Bow)
*
***************************************************************/

namespace Server.Items
{
	public class SiegeBow : Item
	{
		public SiegeBow() : base()
		{
			Id = 15294;
			Bonding = 2;
			SellPrice = 20135;
			AvailableClasses = 0x7FFF;
			Model = 28515;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Siege Bow";
			Name2 = "Siege Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5855;
			BuyPrice = 100679;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 48 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Quillfire Bow)
*
***************************************************************/

namespace Server.Items
{
	public class QuillfireBow : Item
	{
		public QuillfireBow() : base()
		{
			Id = 15295;
			Bonding = 2;
			SellPrice = 22712;
			AvailableClasses = 0x7FFF;
			Model = 28547;
			ObjectClass = 2;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Quillfire Bow";
			Name2 = "Quillfire Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5856;
			BuyPrice = 113560;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 41 , 77 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hawkeye Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyeBow : Item
	{
		public HawkeyeBow() : base()
		{
			Id = 15296;
			Bonding = 2;
			SellPrice = 34657;
			AvailableClasses = 0x7FFF;
			Model = 28545;
			ObjectClass = 2;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Hawkeye Bow";
			Name2 = "Hawkeye Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5858;
			BuyPrice = 173287;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 35 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thornflinger)
*
***************************************************************/

namespace Server.Items
{
	public class Thornflinger : Item
	{
		public Thornflinger() : base()
		{
			Id = 16622;
			Bonding = 1;
			SellPrice = 27307;
			AvailableClasses = 0x7FFF;
			Model = 27492;
			ObjectClass = 2;
			SubClass = 2;
			Level = 57;
			Name = "Thornflinger";
			Name2 = "Thornflinger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 136535;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 52 , 97 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gorewood Bow)
*
***************************************************************/

namespace Server.Items
{
	public class GorewoodBow : Item
	{
		public GorewoodBow() : base()
		{
			Id = 16996;
			Bonding = 1;
			SellPrice = 41451;
			AvailableClasses = 0x7FFF;
			Model = 28827;
			ObjectClass = 2;
			SubClass = 2;
			Level = 62;
			Name = "Gorewood Bow";
			Name2 = "Gorewood Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 207256;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 55 , 104 , Resistances.Armor );
			StaminaBonus = 9;
			AgilityBonus = 3;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Striker's Mark)
*
***************************************************************/

namespace Server.Items
{
	public class StrikersMark : Item
	{
		public StrikersMark() : base()
		{
			Id = 17069;
			Bonding = 1;
			SellPrice = 75746;
			AvailableClasses = 0x7FFF;
			Model = 30927;
			ObjectClass = 2;
			SubClass = 2;
			Level = 69;
			ReqLevel = 60;
			Name = "Striker's Mark";
			Name2 = "Striker's Mark";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 378731;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 69 , 129 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Master Hunter's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class MasterHuntersBow17686 : Item
	{
		public MasterHuntersBow17686() : base()
		{
			Id = 17686;
			Bonding = 1;
			SellPrice = 9937;
			AvailableClasses = 0x7FFF;
			Model = 20555;
			ObjectClass = 2;
			SubClass = 2;
			Level = 43;
			Name = "Master Hunter's Bow";
			Name2 = "Master Hunter's Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49686;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 32 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Verdant Keeper's Aim)
*
***************************************************************/

namespace Server.Items
{
	public class VerdantKeepersAim : Item
	{
		public VerdantKeepersAim() : base()
		{
			Id = 17753;
			Bonding = 1;
			SellPrice = 26046;
			AvailableClasses = 0x7FFF;
			Model = 29932;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			Name = "Verdant Keeper's Aim";
			Name2 = "Verdant Keeper's Aim";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 130233;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 53 , 100 , Resistances.Armor );
			SetDamage( 1 , 4 , Resistances.Nature );
		}
	}
}


/**************************************************************
*
*				(Satyr's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class SatyrsBow : Item
	{
		public SatyrsBow() : base()
		{
			Id = 18323;
			Bonding = 1;
			SellPrice = 32988;
			AvailableClasses = 0x7FFF;
			Model = 30683;
			ObjectClass = 2;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Satyr's Bow";
			Name2 = "Satyr's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 164943;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 93 , Resistances.Armor );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ogre Toothpick Shooter)
*
***************************************************************/

namespace Server.Items
{
	public class OgreToothpickShooter : Item
	{
		public OgreToothpickShooter() : base()
		{
			Id = 18482;
			Bonding = 1;
			SellPrice = 30986;
			AvailableClasses = 0x7FFF;
			Model = 8106;
			ObjectClass = 2;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Ogre Toothpick Shooter";
			Name2 = "Ogre Toothpick Shooter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 154930;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 61 , 62 , Resistances.Armor );
			AgilityBonus = 6;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ancient Bone Bow)
*
***************************************************************/

namespace Server.Items
{
	public class AncientBoneBow : Item
	{
		public AncientBoneBow() : base()
		{
			Id = 18680;
			Bonding = 1;
			SellPrice = 37894;
			AvailableClasses = 0x7FFF;
			Model = 30926;
			ObjectClass = 2;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Ancient Bone Bow";
			Name2 = "Ancient Bone Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 189474;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 61 , 114 , Resistances.Armor );
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Rhok'delar, Longbow of the Ancient Keepers)
*
***************************************************************/

namespace Server.Items
{
	public class RhokdelarLongbowOfTheAncientKeepers : Item
	{
		public RhokdelarLongbowOfTheAncientKeepers() : base()
		{
			Id = 18713;
			Bonding = 1;
			AvailableClasses = 0x04;
			Model = 31338;
			ObjectClass = 2;
			SubClass = 2;
			Level = 75;
			ReqLevel = 60;
			Name = "Rhok'delar, Longbow of the Ancient Keepers";
			Name2 = "Rhok'delar, Longbow of the Ancient Keepers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2900;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			Flags = 33856;
			SetSpell( 23193 , 0 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21432 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 89 , 166 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Screeching Bow)
*
***************************************************************/

namespace Server.Items
{
	public class ScreechingBow : Item
	{
		public ScreechingBow() : base()
		{
			Id = 18729;
			Bonding = 1;
			SellPrice = 38302;
			AvailableClasses = 0x7FFF;
			Model = 31240;
			ObjectClass = 2;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Screeching Bow";
			Name2 = "Screeching Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 191512;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			SetDamage( 70 , 71 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Bullseye)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsBullseye : Item
	{
		public GrandMarshalsBullseye() : base()
		{
			Id = 18833;
			Bonding = 1;
			SellPrice = 34731;
			AvailableClasses = 0x7FFF;
			Model = 31759;
			ObjectClass = 2;
			SubClass = 2;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Bullseye";
			Name2 = "Grand Marshal's Bullseye";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 173657;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 66 , 100 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Recurve)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsRecurve : Item
	{
		public HighWarlordsRecurve() : base()
		{
			Id = 18835;
			Bonding = 1;
			SellPrice = 34997;
			AvailableClasses = 0x7FFF;
			Model = 31748;
			ObjectClass = 2;
			SubClass = 2;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Recurve";
			Name2 = "High Warlord's Recurve";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 174986;
			InventoryType = InventoryTypes.Ranged;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 66 , 100 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Highland Bow)
*
***************************************************************/

namespace Server.Items
{
	public class HighlandBow : Item
	{
		public HighlandBow() : base()
		{
			Id = 19114;
			Bonding = 1;
			SellPrice = 17887;
			AvailableClasses = 0x7FFF;
			Model = 31622;
			ObjectClass = 2;
			SubClass = 2;
			Level = 51;
			Name = "Highland Bow";
			Name2 = "Highland Bow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 89435;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Durability = 65;
			AmmoType = 2;
			SetDamage( 41 , 77 , Resistances.Armor );
			AgilityBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Heartstriker)
*
***************************************************************/

namespace Server.Items
{
	public class Heartstriker : Item
	{
		public Heartstriker() : base()
		{
			Id = 19350;
			Bonding = 1;
			SellPrice = 104609;
			AvailableClasses = 0x7FFF;
			Model = 32080;
			ObjectClass = 2;
			SubClass = 2;
			Level = 75;
			ReqLevel = 60;
			Name = "Heartstriker";
			Name2 = "Heartstriker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 523048;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 90;
			AmmoType = 2;
			SetSpell( 14027 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 80 , 149 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Outrider's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutridersBow : Item
	{
		public OutridersBow() : base()
		{
			Id = 19558;
			Bonding = 1;
			SellPrice = 44011;
			AvailableClasses = 0x7FFF;
			Model = 32079;
			ObjectClass = 2;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Outrider's Bow";
			Name2 = "Outrider's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 220059;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 54 , 101 , Resistances.Armor );
			StaminaBonus = 10;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Outrider's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutridersBow19559 : Item
	{
		public OutridersBow19559() : base()
		{
			Id = 19559;
			Bonding = 1;
			SellPrice = 24117;
			AvailableClasses = 0x7FFF;
			Model = 32079;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Outrider's Bow";
			Name2 = "Outrider's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 120587;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 46 , 86 , Resistances.Armor );
			StaminaBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Outrider's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutridersBow19560 : Item
	{
		public OutridersBow19560() : base()
		{
			Id = 19560;
			Bonding = 1;
			SellPrice = 11924;
			AvailableClasses = 0x7FFF;
			Model = 32079;
			ObjectClass = 2;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Outrider's Bow";
			Name2 = "Outrider's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59624;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 38 , 71 , Resistances.Armor );
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Outrider's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutridersBow19561 : Item
	{
		public OutridersBow19561() : base()
		{
			Id = 19561;
			Bonding = 1;
			SellPrice = 5132;
			AvailableClasses = 0x7FFF;
			Model = 32079;
			ObjectClass = 2;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Outrider's Bow";
			Name2 = "Outrider's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25663;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 28 , 52 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Outrunner's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersBow : Item
	{
		public OutrunnersBow() : base()
		{
			Id = 19562;
			Bonding = 1;
			SellPrice = 41191;
			AvailableClasses = 0x7FFF;
			Model = 32081;
			ObjectClass = 2;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Outrunner's Bow";
			Name2 = "Outrunner's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 205958;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 54 , 101 , Resistances.Armor );
			StaminaBonus = 10;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersBow19563 : Item
	{
		public OutrunnersBow19563() : base()
		{
			Id = 19563;
			Bonding = 1;
			SellPrice = 24117;
			AvailableClasses = 0x7FFF;
			Model = 32081;
			ObjectClass = 2;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Outrunner's Bow";
			Name2 = "Outrunner's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 120587;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 46 , 86 , Resistances.Armor );
			StaminaBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersBow19564 : Item
	{
		public OutrunnersBow19564() : base()
		{
			Id = 19564;
			Bonding = 1;
			SellPrice = 11924;
			AvailableClasses = 0x7FFF;
			Model = 32081;
			ObjectClass = 2;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Outrunner's Bow";
			Name2 = "Outrunner's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59624;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 38 , 71 , Resistances.Armor );
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Bow)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersBow19565 : Item
	{
		public OutrunnersBow19565() : base()
		{
			Id = 19565;
			Bonding = 1;
			SellPrice = 5132;
			AvailableClasses = 0x7FFF;
			Model = 32081;
			ObjectClass = 2;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Outrunner's Bow";
			Name2 = "Outrunner's Bow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25663;
			InventoryType = InventoryTypes.Ranged;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 2;
			Flags = 32768;
			SetDamage( 28 , 52 , Resistances.Armor );
		}
	}
}


