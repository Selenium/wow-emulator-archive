/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:15 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Bent Staff)
*
***************************************************************/

namespace Server.Items
{
	public class BentStaff : Item
	{
		public BentStaff() : base()
		{
			Id = 35;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 472;
			ObjectClass = 2;
			SubClass = 10;
			Level = 2;
			ReqLevel = 1;
			Name = "Bent Staff";
			Name2 = "Bent Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 47;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 25;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long Bo Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LongBoStaff : Item
	{
		public LongBoStaff() : base()
		{
			Id = 767;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 20443;
			ObjectClass = 2;
			SubClass = 10;
			Level = 8;
			ReqLevel = 3;
			Name = "Long Bo Staff";
			Name2 = "Long Bo Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 504;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 40;
			SetDamage( 8 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gnarled Ash Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GnarledAshStaff : Item
	{
		public GnarledAshStaff() : base()
		{
			Id = 791;
			Bonding = 2;
			SellPrice = 7069;
			AvailableClasses = 0x7FFF;
			Model = 20334;
			ObjectClass = 2;
			SubClass = 10;
			Level = 31;
			ReqLevel = 26;
			Name = "Gnarled Ash Staff";
			Name2 = "Gnarled Ash Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35347;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 65 , 99 , Resistances.Armor );
			IqBonus = 15;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Glowing Brightwood Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingBrightwoodStaff : Item
	{
		public GlowingBrightwoodStaff() : base()
		{
			Id = 812;
			Bonding = 2;
			SellPrice = 57018;
			AvailableClasses = 0x7FFF;
			Model = 20257;
			ObjectClass = 2;
			SubClass = 10;
			Level = 54;
			ReqLevel = 49;
			Name = "Glowing Brightwood Staff";
			Name2 = "Glowing Brightwood Staff";
			Resistance[3] = 15;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 285093;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetDamage( 127 , 191 , Resistances.Armor );
			SpiritBonus = 29;
			StaminaBonus = 15;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Quarter Staff)
*
***************************************************************/

namespace Server.Items
{
	public class QuarterStaff : Item
	{
		public QuarterStaff() : base()
		{
			Id = 854;
			SellPrice = 604;
			AvailableClasses = 0x7FFF;
			Model = 22147;
			ObjectClass = 2;
			SubClass = 10;
			Level = 16;
			ReqLevel = 11;
			Name = "Quarter Staff";
			Name2 = "Quarter Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3022;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 55;
			SetDamage( 20 , 31 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Monk's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class MonksStaff : Item
	{
		public MonksStaff() : base()
		{
			Id = 866;
			Bonding = 2;
			SellPrice = 16640;
			AvailableClasses = 0x7FFF;
			Model = 20357;
			ObjectClass = 2;
			SubClass = 10;
			Level = 42;
			ReqLevel = 37;
			Name = "Monk's Staff";
			Name2 = "Monk's Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5257;
			BuyPrice = 83204;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 60 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of Jordan)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfJordan : Item
	{
		public StaffOfJordan() : base()
		{
			Id = 873;
			Bonding = 2;
			SellPrice = 21770;
			AvailableClasses = 0x7FFF;
			Model = 20298;
			ObjectClass = 2;
			SubClass = 10;
			Level = 40;
			ReqLevel = 35;
			Name = "Staff of Jordan";
			Name2 = "Staff of Jordan";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 108853;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 18049 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 119 , 180 , Resistances.Armor );
			SpiritBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Staff of Horrors)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfHorrors : Item
	{
		public StaffOfHorrors() : base()
		{
			Id = 880;
			Bonding = 2;
			SellPrice = 2692;
			AvailableClasses = 0x7FFF;
			Model = 20382;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			ReqLevel = 18;
			Name = "Staff of Horrors";
			Name2 = "Staff of Horrors";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13460;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 70;
			SetSpell( 8552 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 41 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Twisted Chanter's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class TwistedChantersStaff : Item
	{
		public TwistedChantersStaff() : base()
		{
			Id = 890;
			Bonding = 2;
			SellPrice = 3517;
			AvailableClasses = 0x7FFF;
			Model = 20386;
			ObjectClass = 2;
			SubClass = 10;
			Level = 24;
			ReqLevel = 19;
			Name = "Twisted Chanter's Staff";
			Name2 = "Twisted Chanter's Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17588;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 90;
			SetDamage( 55 , 84 , Resistances.Armor );
			SpiritBonus = 10;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Long Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LongStaff : Item
	{
		public LongStaff() : base()
		{
			Id = 928;
			SellPrice = 1972;
			AvailableClasses = 0x7FFF;
			Model = 22151;
			ObjectClass = 2;
			SubClass = 10;
			Level = 25;
			ReqLevel = 20;
			Name = "Long Staff";
			Name2 = "Long Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9860;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 75;
			SetDamage( 36 , 55 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Duskwood Staff)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDuskwoodStaff : Item
	{
		public BlackDuskwoodStaff() : base()
		{
			Id = 937;
			Bonding = 2;
			SellPrice = 14577;
			AvailableClasses = 0x7FFF;
			Model = 20329;
			ObjectClass = 2;
			SubClass = 10;
			Level = 38;
			ReqLevel = 33;
			Name = "Black Duskwood Staff";
			Name2 = "Black Duskwood Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72885;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 18138 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 75 , 113 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Warden Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WardenStaff : Item
	{
		public WardenStaff() : base()
		{
			Id = 943;
			Resistance[0] = 260;
			Bonding = 2;
			SellPrice = 42863;
			AvailableClasses = 0x7FFF;
			Model = 20256;
			ObjectClass = 2;
			SubClass = 10;
			Level = 48;
			ReqLevel = 43;
			Name = "Warden Staff";
			Name2 = "Warden Staff";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 214318;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 89 , 134 , Resistances.Armor );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Elemental Mage Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalMageStaff : Item
	{
		public ElementalMageStaff() : base()
		{
			Id = 944;
			Bonding = 2;
			SellPrice = 83000;
			AvailableClasses = 0x7FFF;
			Model = 20253;
			Resistance[2] = 20;
			Resistance[4] = 20;
			ObjectClass = 2;
			SubClass = 10;
			Level = 61;
			ReqLevel = 56;
			Name = "Elemental Mage Staff";
			Name2 = "Elemental Mage Staff";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 415003;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 17873 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 17897 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 147 , 221 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gnarled Short Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GnarledShortStaff : Item
	{
		public GnarledShortStaff() : base()
		{
			Id = 1010;
			Bonding = 1;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 20440;
			ObjectClass = 2;
			SubClass = 10;
			Level = 8;
			Name = "Gnarled Short Staff";
			Name2 = "Gnarled Short Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 498;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 40;
			SetDamage( 9 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rod of the Sleepwalker)
*
***************************************************************/

namespace Server.Items
{
	public class RodOfTheSleepwalker : Item
	{
		public RodOfTheSleepwalker() : base()
		{
			Id = 1155;
			Bonding = 1;
			SellPrice = 5954;
			AvailableClasses = 0x7FFF;
			Model = 20327;
			ObjectClass = 2;
			SubClass = 10;
			Level = 29;
			ReqLevel = 24;
			Name = "Rod of the Sleepwalker";
			Name2 = "Rod of the Sleepwalker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29770;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 53 , 80 , Resistances.Armor );
			SpiritBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Militia Quarterstaff)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaQuarterstaff : Item
	{
		public MilitiaQuarterstaff() : base()
		{
			Id = 1159;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 4994;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Militia Quarterstaff";
			Name2 = "Militia Quarterstaff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 6 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lesser Staff of the Spire)
*
***************************************************************/

namespace Server.Items
{
	public class LesserStaffOfTheSpire : Item
	{
		public LesserStaffOfTheSpire() : base()
		{
			Id = 1300;
			Bonding = 2;
			SellPrice = 1854;
			AvailableClasses = 0x7FFF;
			Model = 20391;
			ObjectClass = 2;
			SubClass = 10;
			Level = 20;
			ReqLevel = 15;
			Name = "Lesser Staff of the Spire";
			Name2 = "Lesser Staff of the Spire";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9270;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 35 , 54 , Resistances.Armor );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hardened Root Staff)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedRootStaff : Item
	{
		public HardenedRootStaff() : base()
		{
			Id = 1317;
			Bonding = 1;
			SellPrice = 3500;
			AvailableClasses = 0x7FFF;
			Model = 20377;
			ObjectClass = 2;
			SubClass = 10;
			Level = 25;
			Name = "Hardened Root Staff";
			Name2 = "Hardened Root Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17501;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 75;
			SetDamage( 44 , 67 , Resistances.Armor );
			StrBonus = 1;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Crooked Staff)
*
***************************************************************/

namespace Server.Items
{
	public class CrookedStaff : Item
	{
		public CrookedStaff() : base()
		{
			Id = 1388;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 20450;
			ObjectClass = 2;
			SubClass = 10;
			Level = 3;
			ReqLevel = 1;
			Name = "Crooked Staff";
			Name2 = "Crooked Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 71;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 25;
			SetDamage( 4 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Riverpaw Mystic Staff)
*
***************************************************************/

namespace Server.Items
{
	public class RiverpawMysticStaff : Item
	{
		public RiverpawMysticStaff() : base()
		{
			Id = 1391;
			Bonding = 2;
			SellPrice = 1392;
			AvailableClasses = 0x7FFF;
			Model = 20410;
			ObjectClass = 2;
			SubClass = 10;
			Level = 18;
			ReqLevel = 13;
			Name = "Riverpaw Mystic Staff";
			Name2 = "Riverpaw Mystic Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6961;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 60;
			SetDamage( 28 , 43 , Resistances.Armor );
			SpiritBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Foamspittle Staff)
*
***************************************************************/

namespace Server.Items
{
	public class FoamspittleStaff : Item
	{
		public FoamspittleStaff() : base()
		{
			Id = 1405;
			Bonding = 2;
			SellPrice = 1184;
			AvailableClasses = 0x7FFF;
			Model = 5540;
			ObjectClass = 2;
			SubClass = 10;
			Level = 17;
			ReqLevel = 12;
			Name = "Foamspittle Staff";
			Name2 = "Foamspittle Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5923;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 60;
			SetDamage( 29 , 44 , Resistances.Armor );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Withered Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WitheredStaff : Item
	{
		public WitheredStaff() : base()
		{
			Id = 1411;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 20442;
			ObjectClass = 2;
			SubClass = 10;
			Level = 8;
			ReqLevel = 3;
			Name = "Withered Staff";
			Name2 = "Withered Staff";
			AvailableRaces = 0x1FF;
			BuyPrice = 343;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 40;
			SetDamage( 8 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Riverside Staff)
*
***************************************************************/

namespace Server.Items
{
	public class RiversideStaff : Item
	{
		public RiversideStaff() : base()
		{
			Id = 1473;
			Bonding = 2;
			SellPrice = 1497;
			AvailableClasses = 0x7FFF;
			Model = 20402;
			ObjectClass = 2;
			SubClass = 10;
			Level = 19;
			ReqLevel = 14;
			Name = "Riverside Staff";
			Name2 = "Riverside Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7489;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 31 , 47 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Witching Stave)
*
***************************************************************/

namespace Server.Items
{
	public class WitchingStave : Item
	{
		public WitchingStave() : base()
		{
			Id = 1484;
			Bonding = 2;
			SellPrice = 2922;
			AvailableClasses = 0x7FFF;
			Model = 9122;
			ObjectClass = 2;
			SubClass = 10;
			Level = 22;
			ReqLevel = 17;
			Name = "Witching Stave";
			Name2 = "Witching Stave";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14612;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetSpell( 9412 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 55 , 83 , Resistances.Armor );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rough Wooden Staff)
*
***************************************************************/

namespace Server.Items
{
	public class RoughWoodenStaff : Item
	{
		public RoughWoodenStaff() : base()
		{
			Id = 1515;
			SellPrice = 196;
			AvailableClasses = 0x7FFF;
			Model = 20421;
			ObjectClass = 2;
			SubClass = 10;
			Level = 12;
			ReqLevel = 7;
			Name = "Rough Wooden Staff";
			Name2 = "Rough Wooden Staff";
			AvailableRaces = 0x1FF;
			BuyPrice = 984;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 50;
			SetDamage( 13 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gnarled Hermit's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GnarledHermitsStaff : Item
	{
		public GnarledHermitsStaff() : base()
		{
			Id = 1539;
			Bonding = 2;
			SellPrice = 1572;
			AvailableClasses = 0x7FFF;
			Model = 20395;
			ObjectClass = 2;
			SubClass = 10;
			Level = 19;
			ReqLevel = 14;
			Name = "Gnarled Hermit's Staff";
			Name2 = "Gnarled Hermit's Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7861;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 28 , 42 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Soulkeeper)
*
***************************************************************/

namespace Server.Items
{
	public class Soulkeeper : Item
	{
		public Soulkeeper() : base()
		{
			Id = 1607;
			Bonding = 2;
			SellPrice = 43420;
			AvailableClasses = 0x7FFF;
			Model = 20272;
			ObjectClass = 2;
			SubClass = 10;
			Level = 54;
			ReqLevel = 49;
			Name = "Soulkeeper";
			Name2 = "Soulkeeper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 217103;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 141 , 213 , Resistances.Armor );
			IqBonus = 26;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Spiritchaser Staff)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritchaserStaff : Item
	{
		public SpiritchaserStaff() : base()
		{
			Id = 1613;
			Bonding = 2;
			SellPrice = 19139;
			AvailableClasses = 0x7FFF;
			Model = 28470;
			ObjectClass = 2;
			SubClass = 10;
			Level = 44;
			ReqLevel = 39;
			Name = "Spiritchaser Staff";
			Name2 = "Spiritchaser Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5266;
			BuyPrice = 95699;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 75 , 113 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spellforce Rod)
*
***************************************************************/

namespace Server.Items
{
	public class SpellforceRod : Item
	{
		public SpellforceRod() : base()
		{
			Id = 1664;
			Bonding = 2;
			SellPrice = 14695;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 41;
			ReqLevel = 36;
			Name = "Spellforce Rod";
			Name2 = "Spellforce Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 73475;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 77 , 116 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tanglewood Staff)
*
***************************************************************/

namespace Server.Items
{
	public class TanglewoodStaff : Item
	{
		public TanglewoodStaff() : base()
		{
			Id = 1720;
			Bonding = 2;
			SellPrice = 26209;
			AvailableClasses = 0x7FFF;
			Model = 21460;
			ObjectClass = 2;
			SubClass = 10;
			Level = 46;
			ReqLevel = 41;
			Name = "Tanglewood Staff";
			Name2 = "Tanglewood Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 131048;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 9411 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 109 , 165 , Resistances.Armor );
			IqBonus = 18;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Chipped Quarterstaff)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedQuarterstaff : Item
	{
		public ChippedQuarterstaff() : base()
		{
			Id = 1813;
			SellPrice = 522;
			AvailableClasses = 0x7FFF;
			Model = 20413;
			ObjectClass = 2;
			SubClass = 10;
			Level = 18;
			ReqLevel = 13;
			Name = "Chipped Quarterstaff";
			Name2 = "Chipped Quarterstaff";
			AvailableRaces = 0x1FF;
			BuyPrice = 2614;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 60;
			SetDamage( 17 , 27 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cedar Walking Stick)
*
***************************************************************/

namespace Server.Items
{
	public class CedarWalkingStick : Item
	{
		public CedarWalkingStick() : base()
		{
			Id = 1822;
			SellPrice = 1096;
			AvailableClasses = 0x7FFF;
			Model = 20385;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			ReqLevel = 18;
			Name = "Cedar Walking Stick";
			Name2 = "Cedar Walking Stick";
			AvailableRaces = 0x1FF;
			BuyPrice = 5484;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 70;
			SetDamage( 20 , 31 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Oaken War Staff)
*
***************************************************************/

namespace Server.Items
{
	public class OakenWarStaff : Item
	{
		public OakenWarStaff() : base()
		{
			Id = 1831;
			SellPrice = 1790;
			AvailableClasses = 0x7FFF;
			Model = 20361;
			ObjectClass = 2;
			SubClass = 10;
			Level = 28;
			ReqLevel = 23;
			Name = "Oaken War Staff";
			Name2 = "Oaken War Staff";
			AvailableRaces = 0x1FF;
			BuyPrice = 8953;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 33 , 51 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Defias Mage Staff)
*
***************************************************************/

namespace Server.Items
{
	public class DefiasMageStaff : Item
	{
		public DefiasMageStaff() : base()
		{
			Id = 1928;
			Bonding = 2;
			SellPrice = 995;
			AvailableClasses = 0x7FFF;
			Model = 20415;
			ObjectClass = 2;
			SubClass = 10;
			Level = 16;
			ReqLevel = 11;
			Name = "Defias Mage Staff";
			Name2 = "Defias Mage Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4979;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 55;
			SetDamage( 24 , 36 , Resistances.Armor );
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Staff of Conjuring)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfConjuring : Item
	{
		public StaffOfConjuring() : base()
		{
			Id = 1933;
			Bonding = 2;
			SellPrice = 905;
			AvailableClasses = 0x7FFF;
			Model = 20418;
			ObjectClass = 2;
			SubClass = 10;
			Level = 15;
			ReqLevel = 10;
			Name = "Staff of Conjuring";
			Name2 = "Staff of Conjuring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4528;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 55;
			SetSpell( 8736 , 0 , 0 , 300000 , 94 , 60000 );
			SetDamage( 24 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodscalp Channeling Staff)
*
***************************************************************/

namespace Server.Items
{
	public class BloodscalpChannelingStaff : Item
	{
		public BloodscalpChannelingStaff() : base()
		{
			Id = 1998;
			Bonding = 2;
			SellPrice = 7239;
			AvailableClasses = 0x7FFF;
			Model = 20356;
			ObjectClass = 2;
			SubClass = 10;
			Level = 33;
			ReqLevel = 28;
			Name = "Bloodscalp Channeling Staff";
			Name2 = "Bloodscalp Channeling Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36199;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 9359 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 75 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cryptbone Staff)
*
***************************************************************/

namespace Server.Items
{
	public class CryptboneStaff : Item
	{
		public CryptboneStaff() : base()
		{
			Id = 2013;
			Bonding = 2;
			SellPrice = 3644;
			AvailableClasses = 0x7FFF;
			Model = 20373;
			ObjectClass = 2;
			SubClass = 10;
			Level = 26;
			ReqLevel = 21;
			Name = "Cryptbone Staff";
			Name2 = "Cryptbone Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18222;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 40 , 61 , Resistances.Armor );
			StrBonus = 4;
			SpiritBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Gnarled Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GnarledStaff : Item
	{
		public GnarledStaff() : base()
		{
			Id = 2030;
			SellPrice = 1108;
			AvailableClasses = 0x7FFF;
			Model = 22146;
			ObjectClass = 2;
			SubClass = 10;
			Level = 20;
			ReqLevel = 15;
			Name = "Gnarled Staff";
			Name2 = "Gnarled Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5544;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 27 , 42 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of Westfall)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfWestfall : Item
	{
		public StaffOfWestfall() : base()
		{
			Id = 2042;
			Bonding = 1;
			SellPrice = 3639;
			AvailableClasses = 0x7FFF;
			Model = 20379;
			ObjectClass = 2;
			SubClass = 10;
			Level = 24;
			Name = "Staff of Westfall";
			Name2 = "Staff of Westfall";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18195;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 90;
			SetDamage( 49 , 74 , Resistances.Armor );
			IqBonus = 11;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Frostbit Staff)
*
***************************************************************/

namespace Server.Items
{
	public class FrostbitStaff : Item
	{
		public FrostbitStaff() : base()
		{
			Id = 2067;
			SellPrice = 186;
			AvailableClasses = 0x7FFF;
			Model = 20431;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			ReqLevel = 5;
			Name = "Frostbit Staff";
			Name2 = "Frostbit Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 931;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 12 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dwarven Magestaff)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenMagestaff : Item
	{
		public DwarvenMagestaff() : base()
		{
			Id = 2072;
			Bonding = 2;
			SellPrice = 4414;
			AvailableClasses = 0x7FFF;
			Model = 20363;
			ObjectClass = 2;
			SubClass = 10;
			Level = 27;
			ReqLevel = 22;
			Name = "Dwarven Magestaff";
			Name2 = "Dwarven Magestaff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5212;
			BuyPrice = 22070;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 41 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Magician Staff)
*
***************************************************************/

namespace Server.Items
{
	public class MagicianStaff : Item
	{
		public MagicianStaff() : base()
		{
			Id = 2077;
			Bonding = 2;
			SellPrice = 5059;
			AvailableClasses = 0x7FFF;
			Model = 28578;
			ObjectClass = 2;
			SubClass = 10;
			Level = 29;
			ReqLevel = 24;
			Name = "Magician Staff";
			Name2 = "Magician Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5221;
			BuyPrice = 25295;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 47 , 71 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Short Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ShortStaff : Item
	{
		public ShortStaff() : base()
		{
			Id = 2132;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 22149;
			ObjectClass = 2;
			SubClass = 10;
			Level = 4;
			ReqLevel = 1;
			Name = "Short Staff";
			Name2 = "Short Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 102;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 30;
			SetDamage( 5 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ogremage Staff)
*
***************************************************************/

namespace Server.Items
{
	public class OgremageStaff : Item
	{
		public OgremageStaff() : base()
		{
			Id = 2226;
			Bonding = 2;
			SellPrice = 4117;
			AvailableClasses = 0x7FFF;
			Model = 20372;
			ObjectClass = 2;
			SubClass = 10;
			Level = 27;
			ReqLevel = 22;
			Name = "Ogremage Staff";
			Name2 = "Ogremage Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20589;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 49 , 75 , Resistances.Armor );
			SpiritBonus = -5;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Frostmane Staff)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneStaff : Item
	{
		public FrostmaneStaff() : base()
		{
			Id = 2257;
			SellPrice = 188;
			AvailableClasses = 0x7FFF;
			Model = 20429;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			ReqLevel = 5;
			Name = "Frostmane Staff";
			Name2 = "Frostmane Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 944;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 14 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of the Blessed Seer)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfTheBlessedSeer : Item
	{
		public StaffOfTheBlessedSeer() : base()
		{
			Id = 2271;
			Bonding = 2;
			SellPrice = 3255;
			AvailableClasses = 0x7FFF;
			Model = 20346;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			ReqLevel = 18;
			Name = "Staff of the Blessed Seer";
			Name2 = "Staff of the Blessed Seer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16278;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetSpell( 9314 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 47 , 71 , Resistances.Armor );
			IqBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Kam's Walking Stick)
*
***************************************************************/

namespace Server.Items
{
	public class KamsWalkingStick : Item
	{
		public KamsWalkingStick() : base()
		{
			Id = 2280;
			Bonding = 2;
			SellPrice = 4023;
			AvailableClasses = 0x7FFF;
			Model = 20370;
			ObjectClass = 2;
			SubClass = 10;
			Level = 27;
			ReqLevel = 22;
			Name = "Kam's Walking Stick";
			Name2 = "Kam's Walking Stick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20117;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 41 , 62 , Resistances.Armor );
			AgilityBonus = 3;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Acolyte Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AcolyteStaff : Item
	{
		public AcolyteStaff() : base()
		{
			Id = 2487;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 20448;
			ObjectClass = 2;
			SubClass = 10;
			Level = 4;
			ReqLevel = 1;
			Name = "Acolyte Staff";
			Name2 = "Acolyte Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Flags = 16;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Walking Stick)
*
***************************************************************/

namespace Server.Items
{
	public class WalkingStick : Item
	{
		public WalkingStick() : base()
		{
			Id = 2495;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 7310;
			ObjectClass = 2;
			SubClass = 10;
			Level = 8;
			ReqLevel = 3;
			Name = "Walking Stick";
			Name2 = "Walking Stick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 504;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 40;
			SetDamage( 8 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Adept Short Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AdeptShortStaff : Item
	{
		public AdeptShortStaff() : base()
		{
			Id = 2503;
			SellPrice = 103;
			AvailableClasses = 0x7FFF;
			Model = 20436;
			ObjectClass = 2;
			SubClass = 10;
			Level = 8;
			ReqLevel = 3;
			Name = "Adept Short Staff";
			Name2 = "Adept Short Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 519;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Flags = 16;
			SetDamage( 8 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battle Staff)
*
***************************************************************/

namespace Server.Items
{
	public class BattleStaff : Item
	{
		public BattleStaff() : base()
		{
			Id = 2527;
			SellPrice = 5871;
			AvailableClasses = 0x7FFF;
			Model = 22150;
			ObjectClass = 2;
			SubClass = 10;
			Level = 36;
			ReqLevel = 31;
			Name = "Battle Staff";
			Name2 = "Battle Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 29356;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 62 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(War Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WarStaff : Item
	{
		public WarStaff() : base()
		{
			Id = 2535;
			SellPrice = 12311;
			AvailableClasses = 0x7FFF;
			Model = 20389;
			ObjectClass = 2;
			SubClass = 10;
			Level = 45;
			ReqLevel = 40;
			Name = "War Staff";
			Name2 = "War Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 61556;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 85 , 129 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of the Shade)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfTheShade : Item
	{
		public StaffOfTheShade() : base()
		{
			Id = 2549;
			Bonding = 2;
			SellPrice = 5016;
			AvailableClasses = 0x7FFF;
			Model = 20330;
			ObjectClass = 2;
			SubClass = 10;
			Level = 27;
			ReqLevel = 22;
			Name = "Staff of the Shade";
			Name2 = "Staff of the Shade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25082;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 95;
			SetSpell( 9328 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 46 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Icicle Rod)
*
***************************************************************/

namespace Server.Items
{
	public class IcicleRod : Item
	{
		public IcicleRod() : base()
		{
			Id = 2950;
			Bonding = 1;
			SellPrice = 3476;
			AvailableClasses = 0x7FFF;
			Model = 20378;
			ObjectClass = 2;
			SubClass = 10;
			Level = 25;
			Name = "Icicle Rod";
			Name2 = "Icicle Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17384;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 75;
			SetSpell( 7703 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 51 , 77 , Resistances.Armor );
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Acrobatic Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AcrobaticStaff : Item
	{
		public AcrobaticStaff() : base()
		{
			Id = 3185;
			Bonding = 2;
			SellPrice = 8088;
			AvailableClasses = 0x7FFF;
			Model = 20362;
			ObjectClass = 2;
			SubClass = 10;
			Level = 34;
			ReqLevel = 29;
			Name = "Acrobatic Staff";
			Name2 = "Acrobatic Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5239;
			BuyPrice = 40440;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 40 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Nightbane Staff)
*
***************************************************************/

namespace Server.Items
{
	public class NightbaneStaff : Item
	{
		public NightbaneStaff() : base()
		{
			Id = 3227;
			Bonding = 2;
			SellPrice = 2633;
			AvailableClasses = 0x7FFF;
			Model = 20381;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			ReqLevel = 18;
			Name = "Nightbane Staff";
			Name2 = "Nightbane Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13169;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 70;
			SetDamage( 32 , 49 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Executor Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ExecutorStaff : Item
	{
		public ExecutorStaff() : base()
		{
			Id = 3277;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 20444;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Executor Staff";
			Name2 = "Executor Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 6 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vile Fin Oracle Staff)
*
***************************************************************/

namespace Server.Items
{
	public class VileFinOracleStaff : Item
	{
		public VileFinOracleStaff() : base()
		{
			Id = 3327;
			SellPrice = 141;
			AvailableClasses = 0x7FFF;
			Model = 20434;
			ObjectClass = 2;
			SubClass = 10;
			Level = 9;
			ReqLevel = 4;
			Name = "Vile Fin Oracle Staff";
			Name2 = "Vile Fin Oracle Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 708;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 40;
			SetDamage( 11 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Farmer's Broom)
*
***************************************************************/

namespace Server.Items
{
	public class FarmersBroom : Item
	{
		public FarmersBroom() : base()
		{
			Id = 3335;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 3509;
			ObjectClass = 2;
			SubClass = 10;
			Level = 6;
			ReqLevel = 3;
			Name = "Farmer's Broom";
			Name2 = "Farmer's Broom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 230;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 9 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of the Friar)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfTheFriar : Item
	{
		public StaffOfTheFriar() : base()
		{
			Id = 3415;
			Bonding = 2;
			SellPrice = 3598;
			AvailableClasses = 0x7FFF;
			Model = 20339;
			ObjectClass = 2;
			SubClass = 10;
			Level = 24;
			ReqLevel = 19;
			Name = "Staff of the Friar";
			Name2 = "Staff of the Friar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17993;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 90;
			SetDamage( 42 , 64 , Resistances.Armor );
			IqBonus = 11;
			StaminaBonus = 4;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Darkwood Staff)
*
***************************************************************/

namespace Server.Items
{
	public class DarkwoodStaff : Item
	{
		public DarkwoodStaff() : base()
		{
			Id = 3446;
			Bonding = 1;
			SellPrice = 592;
			AvailableClasses = 0x7FFF;
			Model = 20419;
			ObjectClass = 2;
			SubClass = 10;
			Level = 13;
			Name = "Darkwood Staff";
			Name2 = "Darkwood Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2963;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 50;
			SetDamage( 23 , 35 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ceranium Rod)
*
***************************************************************/

namespace Server.Items
{
	public class CeraniumRod : Item
	{
		public CeraniumRod() : base()
		{
			Id = 3452;
			Bonding = 1;
			SellPrice = 2322;
			AvailableClasses = 0x7FFF;
			Model = 5120;
			ObjectClass = 2;
			SubClass = 10;
			Level = 22;
			Name = "Ceranium Rod";
			Name2 = "Ceranium Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11610;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 70;
			SetDamage( 31 , 47 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Handcrafted Staff)
*
***************************************************************/

namespace Server.Items
{
	public class HandcraftedStaff : Item
	{
		public HandcraftedStaff() : base()
		{
			Id = 3661;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 18530;
			ObjectClass = 2;
			SubClass = 10;
			Level = 2;
			ReqLevel = 1;
			Name = "Handcrafted Staff";
			Name2 = "Handcrafted Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 25;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Metal Stave)
*
***************************************************************/

namespace Server.Items
{
	public class MetalStave : Item
	{
		public MetalStave() : base()
		{
			Id = 3784;
			SellPrice = 4208;
			AvailableClasses = 0x7FFF;
			Model = 20350;
			ObjectClass = 2;
			SubClass = 10;
			Level = 37;
			ReqLevel = 32;
			Name = "Metal Stave";
			Name2 = "Metal Stave";
			AvailableRaces = 0x1FF;
			BuyPrice = 21042;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 38 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of Nobles)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfNobles : Item
	{
		public StaffOfNobles() : base()
		{
			Id = 3902;
			Bonding = 2;
			SellPrice = 1317;
			AvailableClasses = 0x7FFF;
			Model = 20412;
			ObjectClass = 2;
			SubClass = 10;
			Level = 18;
			ReqLevel = 13;
			Name = "Staff of Nobles";
			Name2 = "Staff of Nobles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6588;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 60;
			SetDamage( 30 , 46 , Resistances.Armor );
			StaminaBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Heavy War Staff)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWarStaff : Item
	{
		public HeavyWarStaff() : base()
		{
			Id = 4024;
			SellPrice = 9821;
			AvailableClasses = 0x7FFF;
			Model = 20309;
			ObjectClass = 2;
			SubClass = 10;
			Level = 47;
			ReqLevel = 42;
			Name = "Heavy War Staff";
			Name2 = "Heavy War Staff";
			AvailableRaces = 0x1FF;
			BuyPrice = 49109;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 59 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Nimboya's Mystical Staff)
*
***************************************************************/

namespace Server.Items
{
	public class NimboyasMysticalStaff : Item
	{
		public NimboyasMysticalStaff() : base()
		{
			Id = 4134;
			Bonding = 1;
			SellPrice = 22495;
			AvailableClasses = 0x7FFF;
			Model = 20294;
			ObjectClass = 2;
			SubClass = 10;
			Level = 46;
			Name = "Nimboya's Mystical Staff";
			Name2 = "Nimboya's Mystical Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 112477;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 65 , 99 , Resistances.Armor );
			SpiritBonus = 8;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Channeler's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ChannelersStaff : Item
	{
		public ChannelersStaff() : base()
		{
			Id = 4437;
			Bonding = 2;
			SellPrice = 1855;
			AvailableClasses = 0x7FFF;
			Model = 20390;
			ObjectClass = 2;
			SubClass = 10;
			Level = 20;
			ReqLevel = 15;
			Name = "Channeler's Staff";
			Name2 = "Channeler's Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9278;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 35 , 54 , Resistances.Armor );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sturdy Quarterstaff)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyQuarterstaff : Item
	{
		public SturdyQuarterstaff() : base()
		{
			Id = 4566;
			Bonding = 2;
			SellPrice = 631;
			AvailableClasses = 0x7FFF;
			Model = 20420;
			ObjectClass = 2;
			SubClass = 10;
			Level = 13;
			ReqLevel = 8;
			Name = "Sturdy Quarterstaff";
			Name2 = "Sturdy Quarterstaff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5176;
			BuyPrice = 3157;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 50;
			SetDamage( 20 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Medicine Staff)
*
***************************************************************/

namespace Server.Items
{
	public class MedicineStaff : Item
	{
		public MedicineStaff() : base()
		{
			Id = 4575;
			Bonding = 2;
			SellPrice = 1487;
			AvailableClasses = 0x7FFF;
			Model = 20401;
			ObjectClass = 2;
			SubClass = 10;
			Level = 19;
			ReqLevel = 14;
			Name = "Medicine Staff";
			Name2 = "Medicine Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5194;
			BuyPrice = 7435;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 25 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blemished Wooden Staff)
*
***************************************************************/

namespace Server.Items
{
	public class BlemishedWoodenStaff : Item
	{
		public BlemishedWoodenStaff() : base()
		{
			Id = 4938;
			Bonding = 1;
			SellPrice = 236;
			AvailableClasses = 0x7FFF;
			Model = 20423;
			ObjectClass = 2;
			SubClass = 10;
			Level = 11;
			Name = "Blemished Wooden Staff";
			Name2 = "Blemished Wooden Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1182;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 16 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dreamwatcher Staff)
*
***************************************************************/

namespace Server.Items
{
	public class DreamwatcherStaff : Item
	{
		public DreamwatcherStaff() : base()
		{
			Id = 4961;
			Bonding = 1;
			SellPrice = 183;
			AvailableClasses = 0x7FFF;
			Model = 20426;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			Name = "Dreamwatcher Staff";
			Name2 = "Dreamwatcher Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 918;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 14 , 22 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Emberstone Staff)
*
***************************************************************/

namespace Server.Items
{
	public class EmberstoneStaff : Item
	{
		public EmberstoneStaff() : base()
		{
			Id = 5201;
			Bonding = 1;
			SellPrice = 3161;
			AvailableClasses = 0x7FFF;
			Model = 20340;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			ReqLevel = 18;
			Name = "Emberstone Staff";
			Name2 = "Emberstone Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15809;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 80;
			SetDamage( 47 , 71 , Resistances.Armor );
			IqBonus = 5;
			StaminaBonus = 5;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Wind Rider Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WindRiderStaff : Item
	{
		public WindRiderStaff() : base()
		{
			Id = 5306;
			Bonding = 1;
			SellPrice = 1710;
			AvailableClasses = 0x7FFF;
			Model = 7524;
			ObjectClass = 2;
			SubClass = 10;
			Level = 20;
			Name = "Wind Rider Staff";
			Name2 = "Wind Rider Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8554;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 29 , 44 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cauldron Stirrer)
*
***************************************************************/

namespace Server.Items
{
	public class CauldronStirrer : Item
	{
		public CauldronStirrer() : base()
		{
			Id = 5340;
			Bonding = 1;
			SellPrice = 919;
			AvailableClasses = 0x7FFF;
			Model = 20417;
			ObjectClass = 2;
			SubClass = 10;
			Level = 15;
			Name = "Cauldron Stirrer";
			Name2 = "Cauldron Stirrer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4596;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 55;
			SetDamage( 25 , 38 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Thistlewood Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodStaff : Item
	{
		public ThistlewoodStaff() : base()
		{
			Id = 5393;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 5108;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Thistlewood Staff";
			Name2 = "Thistlewood Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 6 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Smooth Walking Staff)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothWalkingStaff : Item
	{
		public SmoothWalkingStaff() : base()
		{
			Id = 5581;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 20446;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Smooth Walking Staff";
			Name2 = "Smooth Walking Staff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 161;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 7 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of the Purifier)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfThePurifier : Item
	{
		public StaffOfThePurifier() : base()
		{
			Id = 5613;
			Bonding = 1;
			SellPrice = 2635;
			AvailableClasses = 0x7FFF;
			Model = 20384;
			ObjectClass = 2;
			SubClass = 10;
			Level = 23;
			Name = "Staff of the Purifier";
			Name2 = "Staff of the Purifier";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13177;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 70;
			SetSpell( 14134 , 0 , 3 , -1 , 28 , 300000 );
			SetDamage( 45 , 68 , Resistances.Armor );
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Elder's Cane)
*
***************************************************************/

namespace Server.Items
{
	public class EldersCane : Item
	{
		public EldersCane() : base()
		{
			Id = 5776;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 20449;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Elder's Cane";
			Name2 = "Elder's Cane";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 7 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Primitive Walking Stick)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveWalkingStick : Item
	{
		public PrimitiveWalkingStick() : base()
		{
			Id = 5778;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 5404;
			ObjectClass = 2;
			SubClass = 10;
			Level = 5;
			Name = "Primitive Walking Stick";
			Name2 = "Primitive Walking Stick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 151;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 35;
			SetDamage( 6 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Balanced Fighting Stick)
*
***************************************************************/

namespace Server.Items
{
	public class BalancedFightingStick : Item
	{
		public BalancedFightingStick() : base()
		{
			Id = 6215;
			Bonding = 1;
			SellPrice = 601;
			AvailableClasses = 0x7FFF;
			Model = 10654;
			ObjectClass = 2;
			SubClass = 10;
			Level = 13;
			Name = "Balanced Fighting Stick";
			Name2 = "Balanced Fighting Stick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3009;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 50;
			SetDamage( 18 , 21 , Resistances.Armor );
			AgilityBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Odo's Ley Staff)
*
***************************************************************/

namespace Server.Items
{
	public class OdosLeyStaff : Item
	{
		public OdosLeyStaff() : base()
		{
			Id = 6318;
			Bonding = 1;
			SellPrice = 4802;
			AvailableClasses = 0x7FFF;
			Model = 20335;
			ObjectClass = 2;
			SubClass = 10;
			Level = 26;
			ReqLevel = 21;
			Name = "Odo's Ley Staff";
			Name2 = "Odo's Ley Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24014;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 95;
			SetDamage( 50 , 76 , Resistances.Armor );
			IqBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Crescent Staff)
*
***************************************************************/

namespace Server.Items
{
	public class CrescentStaff : Item
	{
		public CrescentStaff() : base()
		{
			Id = 6505;
			Bonding = 1;
			SellPrice = 3680;
			AvailableClasses = 0x7FFF;
			Model = 12286;
			ObjectClass = 2;
			SubClass = 10;
			Level = 24;
			Name = "Crescent Staff";
			Name2 = "Crescent Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18401;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 90;
			SetDamage( 47 , 71 , Resistances.Armor );
			SpiritBonus = 7;
			IqBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Living Root)
*
***************************************************************/

namespace Server.Items
{
	public class LivingRoot : Item
	{
		public LivingRoot() : base()
		{
			Id = 6631;
			Bonding = 1;
			SellPrice = 4053;
			AvailableClasses = 0x7FFF;
			Model = 20336;
			ObjectClass = 2;
			SubClass = 10;
			Level = 25;
			ReqLevel = 20;
			Name = "Living Root";
			Name2 = "Living Root";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20266;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 90;
			SetDamage( 49 , 74 , Resistances.Armor );
			IqBonus = 12;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Wind Spirit Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WindSpiritStaff : Item
	{
		public WindSpiritStaff() : base()
		{
			Id = 6689;
			Bonding = 1;
			SellPrice = 8267;
			AvailableClasses = 0x7FFF;
			Model = 20325;
			ObjectClass = 2;
			SubClass = 10;
			Level = 32;
			ReqLevel = 27;
			Name = "Wind Spirit Staff";
			Name2 = "Wind Spirit Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41336;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 70 , 106 , Resistances.Armor );
			SpiritBonus = 5;
			IqBonus = 15;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Driftwood Branch)
*
***************************************************************/

namespace Server.Items
{
	public class DriftwoodBranch : Item
	{
		public DriftwoodBranch() : base()
		{
			Id = 7094;
			SellPrice = 174;
			AvailableClasses = 0x7FFF;
			Model = 13711;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			ReqLevel = 5;
			Name = "Driftwood Branch";
			Name2 = "Driftwood Branch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 871;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 15 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Loksey's Training Stick)
*
***************************************************************/

namespace Server.Items
{
	public class LokseysTrainingStick : Item
	{
		public LokseysTrainingStick() : base()
		{
			Id = 7710;
			Bonding = 1;
			SellPrice = 12279;
			AvailableClasses = 0x7FFF;
			Model = 20360;
			ObjectClass = 2;
			SubClass = 10;
			Level = 36;
			ReqLevel = 31;
			Name = "Loksey's Training Stick";
			Name2 = "Loksey's Training Stick";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61398;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 18207 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 77 , 117 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Illusionary Rod)
*
***************************************************************/

namespace Server.Items
{
	public class IllusionaryRod : Item
	{
		public IllusionaryRod() : base()
		{
			Id = 7713;
			Bonding = 1;
			SellPrice = 4777;
			AvailableClasses = 0x7FFF;
			Model = 15806;
			ObjectClass = 2;
			SubClass = 10;
			Level = 39;
			ReqLevel = 34;
			Name = "Illusionary Rod";
			Name2 = "Illusionary Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23886;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 94 , 142 , Resistances.Armor );
			SpiritBonus = 15;
			IqBonus = 10;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Windweaver Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WindweaverStaff : Item
	{
		public WindweaverStaff() : base()
		{
			Id = 7757;
			Bonding = 2;
			SellPrice = 12874;
			AvailableClasses = 0x7FFF;
			Model = 20316;
			ObjectClass = 2;
			SubClass = 10;
			Level = 37;
			ReqLevel = 32;
			Name = "Windweaver Staff";
			Name2 = "Windweaver Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64374;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 13599 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 80 , 121 , Resistances.Armor );
			SpiritBonus = 15;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ironshod Bludgeon)
*
***************************************************************/

namespace Server.Items
{
	public class IronshodBludgeon : Item
	{
		public IronshodBludgeon() : base()
		{
			Id = 9408;
			Bonding = 1;
			SellPrice = 18639;
			AvailableClasses = 0x7FFF;
			Model = 20274;
			ObjectClass = 2;
			SubClass = 10;
			Level = 42;
			ReqLevel = 37;
			Name = "Ironshod Bludgeon";
			Name2 = "Ironshod Bludgeon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 93198;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 74 , 112 , Resistances.Armor );
			StaminaBonus = 20;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Hydrocane)
*
***************************************************************/

namespace Server.Items
{
	public class Hydrocane : Item
	{
		public Hydrocane() : base()
		{
			Id = 9452;
			Bonding = 1;
			SellPrice = 8210;
			AvailableClasses = 0x7FFF;
			Model = 20323;
			Resistance[4] = 15;
			ObjectClass = 2;
			SubClass = 10;
			Level = 32;
			ReqLevel = 27;
			Name = "Hydrocane";
			Name2 = "Hydrocane";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41051;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 11789 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 48 , 73 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Chief's Enforcer)
*
***************************************************************/

namespace Server.Items
{
	public class TheChiefsEnforcer : Item
	{
		public TheChiefsEnforcer() : base()
		{
			Id = 9477;
			Bonding = 1;
			SellPrice = 35936;
			AvailableClasses = 0x7FFF;
			Model = 21514;
			ObjectClass = 2;
			SubClass = 10;
			Level = 50;
			ReqLevel = 45;
			Name = "The Chief's Enforcer";
			Name2 = "The Chief's Enforcer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 179682;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 56 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 118 , 178 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Witch Doctor's Cane)
*
***************************************************************/

namespace Server.Items
{
	public class WitchDoctorsCane : Item
	{
		public WitchDoctorsCane() : base()
		{
			Id = 9482;
			Bonding = 2;
			SellPrice = 29585;
			AvailableClasses = 0x7FFF;
			Model = 20269;
			ObjectClass = 2;
			SubClass = 10;
			Level = 47;
			ReqLevel = 42;
			Name = "Witch Doctor's Cane";
			Name2 = "Witch Doctor's Cane";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 147925;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 17993 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 75 , 114 , Resistances.Armor );
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ley Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LeyStaff : Item
	{
		public LeyStaff() : base()
		{
			Id = 9513;
			Bonding = 1;
			SellPrice = 305;
			AvailableClasses = 0x80;
			Model = 18438;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			Name = "Ley Staff";
			Name2 = "Ley Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1526;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 16 , 25 , Resistances.Armor );
			IqBonus = 1;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Arcane Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneStaff : Item
	{
		public ArcaneStaff() : base()
		{
			Id = 9514;
			Bonding = 1;
			SellPrice = 306;
			AvailableClasses = 0x80;
			Model = 20424;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			Name = "Arcane Staff";
			Name2 = "Arcane Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1532;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 16 , 25 , Resistances.Armor );
			IqBonus = 1;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Celestial Stave)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialStave : Item
	{
		public CelestialStave() : base()
		{
			Id = 9517;
			Bonding = 1;
			SellPrice = 13114;
			AvailableClasses = 0x80;
			Model = 20348;
			ObjectClass = 2;
			SubClass = 10;
			Level = 40;
			Name = "Celestial Stave";
			Name2 = "Celestial Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65572;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 13597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9399 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9402 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 69 , 104 , Resistances.Armor );
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Spellshifter Rod)
*
***************************************************************/

namespace Server.Items
{
	public class SpellshifterRod : Item
	{
		public SpellshifterRod() : base()
		{
			Id = 9527;
			Bonding = 1;
			SellPrice = 21613;
			AvailableClasses = 0x7FFF;
			Model = 20300;
			ObjectClass = 2;
			SubClass = 10;
			Level = 46;
			Name = "Spellshifter Rod";
			Name2 = "Spellshifter Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 108069;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 77 , 116 , Resistances.Armor );
			StaminaBonus = 6;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Gritroot Staff)
*
***************************************************************/

namespace Server.Items
{
	public class GritrootStaff : Item
	{
		public GritrootStaff() : base()
		{
			Id = 9603;
			Bonding = 1;
			SellPrice = 302;
			AvailableClasses = 0x7FFF;
			Model = 20432;
			ObjectClass = 2;
			SubClass = 10;
			Level = 10;
			Name = "Gritroot Staff";
			Name2 = "Gritroot Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1510;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 45;
			SetDamage( 14 , 22 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Strength of the Treant)
*
***************************************************************/

namespace Server.Items
{
	public class StrengthOfTheTreant : Item
	{
		public StrengthOfTheTreant() : base()
		{
			Id = 9683;
			Bonding = 1;
			SellPrice = 29952;
			AvailableClasses = 0x7FFF;
			Model = 20289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 50;
			Name = "Strength of the Treant";
			Name2 = "Strength of the Treant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 149764;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 115 , 173 , Resistances.Armor );
			StaminaBonus = 7;
			SpiritBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Bludgeon of the Grinning Dog)
*
***************************************************************/

namespace Server.Items
{
	public class BludgeonOfTheGrinningDog : Item
	{
		public BludgeonOfTheGrinningDog() : base()
		{
			Id = 10627;
			Bonding = 2;
			SellPrice = 26974;
			AvailableClasses = 0x7FFF;
			Model = 20259;
			ObjectClass = 2;
			SubClass = 10;
			Level = 47;
			ReqLevel = 42;
			Name = "Bludgeon of the Grinning Dog";
			Name2 = "Bludgeon of the Grinning Dog";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 134870;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 56 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 112 , 168 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Enchanted Azsharite Felbane Staff)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedAzshariteFelbaneStaff : Item
	{
		public EnchantedAzshariteFelbaneStaff() : base()
		{
			Id = 10698;
			Bonding = 1;
			SellPrice = 52747;
			AvailableClasses = 0x7FFF;
			Description = "Carved into the shaft: Rakh'likh";
			Model = 20275;
			ObjectClass = 2;
			SubClass = 10;
			Level = 60;
			Name = "Enchanted Azsharite Felbane Staff";
			Name2 = "Enchanted Azsharite Felbane Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 263735;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 18087 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 12938 , 0 , 0 , 0 , 0 , 180000 );
			SetDamage( 104 , 157 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staff of Lore)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfLore : Item
	{
		public StaffOfLore() : base()
		{
			Id = 10826;
			Bonding = 1;
			SellPrice = 25501;
			AvailableClasses = 0x7FFF;
			Model = 20293;
			ObjectClass = 2;
			SubClass = 10;
			Level = 48;
			Name = "Staff of Lore";
			Name2 = "Staff of Lore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 127506;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 92 , 139 , Resistances.Armor );
			SpiritBonus = 5;
			IqBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Spire of Hakkar)
*
***************************************************************/

namespace Server.Items
{
	public class SpireOfHakkar : Item
	{
		public SpireOfHakkar() : base()
		{
			Id = 10844;
			Bonding = 1;
			SellPrice = 44314;
			AvailableClasses = 0x7FFF;
			Model = 20258;
			ObjectClass = 2;
			SubClass = 10;
			Level = 54;
			ReqLevel = 49;
			Name = "Spire of Hakkar";
			Name2 = "Spire of Hakkar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 221570;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 126 , 190 , Resistances.Armor );
			IqBonus = 16;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Kindling Stave)
*
***************************************************************/

namespace Server.Items
{
	public class KindlingStave : Item
	{
		public KindlingStave() : base()
		{
			Id = 11750;
			Bonding = 1;
			SellPrice = 43234;
			AvailableClasses = 0x7FFF;
			Model = 21723;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 10;
			Level = 53;
			ReqLevel = 48;
			Name = "Kindling Stave";
			Name2 = "Kindling Stave";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 216171;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 106 , 160 , Resistances.Armor );
			IqBonus = 25;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Sanctimonial Rod)
*
***************************************************************/

namespace Server.Items
{
	public class SanctimonialRod : Item
	{
		public SanctimonialRod() : base()
		{
			Id = 11857;
			Bonding = 1;
			SellPrice = 21377;
			AvailableClasses = 0x7FFF;
			Model = 28345;
			ObjectClass = 2;
			SubClass = 10;
			Level = 46;
			Name = "Sanctimonial Rod";
			Name2 = "Sanctimonial Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 106888;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 88 , 133 , Resistances.Armor );
			StaminaBonus = 4;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Guiding Stave of Wisdom)
*
***************************************************************/

namespace Server.Items
{
	public class GuidingStaveOfWisdom : Item
	{
		public GuidingStaveOfWisdom() : base()
		{
			Id = 11932;
			Bonding = 1;
			SellPrice = 58322;
			AvailableClasses = 0x7FFF;
			Model = 21968;
			Resistance[4] = 10;
			ObjectClass = 2;
			SubClass = 10;
			Level = 59;
			ReqLevel = 54;
			Name = "Guiding Stave of Wisdom";
			Name2 = "Guiding Stave of Wisdom";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 291612;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 133 , 200 , Resistances.Armor );
			IqBonus = 29;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Big Stick)
*
***************************************************************/

namespace Server.Items
{
	public class BigStick : Item
	{
		public BigStick() : base()
		{
			Id = 12251;
			Bonding = 2;
			SellPrice = 10779;
			AvailableClasses = 0x5FF;
			Model = 22252;
			ObjectClass = 2;
			SubClass = 10;
			Level = 37;
			ReqLevel = 32;
			Name = "Big Stick";
			Name2 = "Big Stick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53896;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 61 , 93 , Resistances.Armor );
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Staff of Protection)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfProtection : Item
	{
		public StaffOfProtection() : base()
		{
			Id = 12252;
			Resistance[6] = 6;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 12619;
			AvailableClasses = 0x5FF;
			Model = 28699;
			Resistance[2] = 6;
			Resistance[4] = 6;
			ObjectClass = 2;
			SubClass = 10;
			Level = 39;
			ReqLevel = 34;
			Name = "Staff of Protection";
			Name2 = "Staff of Protection";
			Resistance[3] = 6;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63095;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 66 , 100 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spire of the Stoneshaper)
*
***************************************************************/

namespace Server.Items
{
	public class SpireOfTheStoneshaper : Item
	{
		public SpireOfTheStoneshaper() : base()
		{
			Id = 12532;
			Bonding = 2;
			SellPrice = 48501;
			AvailableClasses = 0x7FFF;
			Model = 22722;
			ObjectClass = 2;
			SubClass = 10;
			Level = 56;
			ReqLevel = 51;
			Name = "Spire of the Stoneshaper";
			Name2 = "Spire of the Stoneshaper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 242506;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 16470 , 0 , 0 , 900000 , 28 , 300000 );
			SetDamage( 131 , 197 , Resistances.Armor );
			IqBonus = 20;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Staff of Hale Magefire)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfHaleMagefire : Item
	{
		public StaffOfHaleMagefire() : base()
		{
			Id = 13000;
			Bonding = 2;
			SellPrice = 65225;
			AvailableClasses = 0x7FFF;
			Model = 28701;
			ObjectClass = 2;
			SubClass = 10;
			Level = 62;
			ReqLevel = 57;
			Name = "Staff of Hale Magefire";
			Name2 = "Staff of Hale Magefire";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 326129;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 140 , 210 , Resistances.Armor );
			IqBonus = 22;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Trindlehaven Staff)
*
***************************************************************/

namespace Server.Items
{
	public class TrindlehavenStaff : Item
	{
		public TrindlehavenStaff() : base()
		{
			Id = 13161;
			Bonding = 1;
			SellPrice = 65749;
			AvailableClasses = 0x7FFF;
			Model = 23673;
			ObjectClass = 2;
			SubClass = 10;
			Level = 61;
			ReqLevel = 56;
			Name = "Trindlehaven Staff";
			Name2 = "Trindlehaven Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 328748;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 87 , 132 , Resistances.Armor );
			SpiritBonus = 30;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Argent Crusader)
*
***************************************************************/

namespace Server.Items
{
	public class ArgentCrusader : Item
	{
		public ArgentCrusader() : base()
		{
			Id = 13249;
			Bonding = 1;
			SellPrice = 67782;
			AvailableClasses = 0x7FFF;
			Model = 23837;
			ObjectClass = 2;
			SubClass = 10;
			Level = 62;
			Name = "Argent Crusader";
			Name2 = "Argent Crusader";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 338914;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 127 , 191 , Resistances.Armor );
			SpiritBonus = 30;
			StaminaBonus = 6;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Slavedriver's Cane)
*
***************************************************************/

namespace Server.Items
{
	public class SlavedriversCane : Item
	{
		public SlavedriversCane() : base()
		{
			Id = 13372;
			Bonding = 1;
			SellPrice = 63769;
			AvailableClasses = 0x7FFF;
			Model = 24063;
			ObjectClass = 2;
			SubClass = 10;
			Level = 60;
			ReqLevel = 55;
			Name = "Slavedriver's Cane";
			Name2 = "Slavedriver's Cane";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 318845;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 17494 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 139 , 210 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stout War Staff)
*
***************************************************************/

namespace Server.Items
{
	public class StoutWarStaff : Item
	{
		public StoutWarStaff() : base()
		{
			Id = 13823;
			SellPrice = 11924;
			AvailableClasses = 0x7FFF;
			Model = 20309;
			ObjectClass = 2;
			SubClass = 10;
			Level = 51;
			ReqLevel = 46;
			Name = "Stout War Staff";
			Name2 = "Stout War Staff";
			AvailableRaces = 0x1FF;
			BuyPrice = 59622;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 59 , 89 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Headmaster's Charge)
*
***************************************************************/

namespace Server.Items
{
	public class HeadmastersCharge : Item
	{
		public HeadmastersCharge() : base()
		{
			Id = 13937;
			Bonding = 1;
			SellPrice = 87013;
			AvailableClasses = 0x7FFF;
			Model = 24771;
			ObjectClass = 2;
			SubClass = 10;
			Level = 62;
			ReqLevel = 57;
			Name = "Headmaster's Charge";
			Name2 = "Headmaster's Charge";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 435067;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 18264 , 0 , 0 , 1800000 , 102 , 600000 );
			SetDamage( 135 , 204 , Resistances.Armor );
			StaminaBonus = 30;
			IqBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Staff of Noh'Orahil)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfNohOrahil : Item
	{
		public StaffOfNohOrahil() : base()
		{
			Id = 15105;
			Bonding = 1;
			SellPrice = 14397;
			AvailableClasses = 0x100;
			Model = 28231;
			ObjectClass = 2;
			SubClass = 10;
			Level = 40;
			Name = "Staff of Noh'Orahil";
			Name2 = "Staff of Noh'Orahil";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71989;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 9296 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 62 , 94 , Resistances.Armor );
			SpiritBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Staff of Dar'Orahil)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfDarOrahil : Item
	{
		public StaffOfDarOrahil() : base()
		{
			Id = 15106;
			Bonding = 1;
			SellPrice = 14447;
			AvailableClasses = 0x100;
			Model = 28236;
			ObjectClass = 2;
			SubClass = 10;
			Level = 40;
			Name = "Staff of Dar'Orahil";
			Name2 = "Staff of Dar'Orahil";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 72237;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 9326 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 62 , 94 , Resistances.Armor );
			SpiritBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Staff of Soran'ruk)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfSoranruk : Item
	{
		public StaffOfSoranruk() : base()
		{
			Id = 15109;
			Bonding = 1;
			SellPrice = 3344;
			AvailableClasses = 0x100;
			Model = 28225;
			ObjectClass = 2;
			SubClass = 10;
			Level = 25;
			Name = "Staff of Soran'ruk";
			Name2 = "Staff of Soran'ruk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16723;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 75;
			SetSpell( 7710 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7688 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Diviner Long Staff)
*
***************************************************************/

namespace Server.Items
{
	public class DivinerLongStaff : Item
	{
		public DivinerLongStaff() : base()
		{
			Id = 15274;
			Bonding = 2;
			SellPrice = 31666;
			AvailableClasses = 0x7FFF;
			Model = 22144;
			ObjectClass = 2;
			SubClass = 10;
			Level = 52;
			ReqLevel = 47;
			Name = "Diviner Long Staff";
			Name2 = "Diviner Long Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5293;
			BuyPrice = 158334;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 84 , 126 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thaumaturgist Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ThaumaturgistStaff : Item
	{
		public ThaumaturgistStaff() : base()
		{
			Id = 15275;
			Bonding = 2;
			SellPrice = 35714;
			AvailableClasses = 0x7FFF;
			Model = 28467;
			ObjectClass = 2;
			SubClass = 10;
			Level = 54;
			ReqLevel = 49;
			Name = "Thaumaturgist Staff";
			Name2 = "Thaumaturgist Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5293;
			BuyPrice = 178574;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 120 , 181 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Magus Long Staff)
*
***************************************************************/

namespace Server.Items
{
	public class MagusLongStaff : Item
	{
		public MagusLongStaff() : base()
		{
			Id = 15276;
			Bonding = 2;
			SellPrice = 45263;
			AvailableClasses = 0x7FFF;
			Model = 28580;
			ObjectClass = 2;
			SubClass = 10;
			Level = 58;
			ReqLevel = 53;
			Name = "Magus Long Staff";
			Name2 = "Magus Long Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5311;
			BuyPrice = 226315;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 122 , 184 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Solstice Staff)
*
***************************************************************/

namespace Server.Items
{
	public class SolsticeStaff : Item
	{
		public SolsticeStaff() : base()
		{
			Id = 15278;
			Bonding = 2;
			SellPrice = 50285;
			AvailableClasses = 0x7FFF;
			Model = 28502;
			ObjectClass = 2;
			SubClass = 10;
			Level = 60;
			ReqLevel = 55;
			Name = "Solstice Staff";
			Name2 = "Solstice Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5311;
			BuyPrice = 251429;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 97 , 146 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Oakthrush Staff)
*
***************************************************************/

namespace Server.Items
{
	public class OakthrushStaff : Item
	{
		public OakthrushStaff() : base()
		{
			Id = 15397;
			Bonding = 1;
			SellPrice = 731;
			AvailableClasses = 0x7FFF;
			Model = 10654;
			ObjectClass = 2;
			SubClass = 10;
			Level = 14;
			Name = "Oakthrush Staff";
			Name2 = "Oakthrush Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3656;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 50;
			SetDamage( 21 , 32 , Resistances.Armor );
			StaminaBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Staff of Orgrimmar)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfOrgrimmar : Item
	{
		public StaffOfOrgrimmar() : base()
		{
			Id = 15444;
			Bonding = 1;
			SellPrice = 1404;
			AvailableClasses = 0x7FFF;
			Model = 28228;
			ObjectClass = 2;
			SubClass = 10;
			Level = 18;
			Name = "Staff of Orgrimmar";
			Name2 = "Staff of Orgrimmar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7023;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 60;
			SetDamage( 31 , 47 , Resistances.Armor );
			IqBonus = 2;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dancing Sliver)
*
***************************************************************/

namespace Server.Items
{
	public class DancingSliver : Item
	{
		public DancingSliver() : base()
		{
			Id = 15854;
			Bonding = 1;
			SellPrice = 64502;
			AvailableClasses = 0x7FFF;
			Model = 26536;
			ObjectClass = 2;
			SubClass = 10;
			Level = 60;
			Name = "Dancing Sliver";
			Name2 = "Dancing Sliver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 322514;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetDamage( 98 , 148 , Resistances.Armor );
			IqBonus = 29;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Polished Walking Staff)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedWalkingStaff : Item
	{
		public PolishedWalkingStaff() : base()
		{
			Id = 16889;
			Bonding = 1;
			SellPrice = 3093;
			AvailableClasses = 0x7FFF;
			Model = 28592;
			ObjectClass = 2;
			SubClass = 10;
			Level = 24;
			Name = "Polished Walking Staff";
			Name2 = "Polished Walking Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15467;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 75;
			SetDamage( 33 , 50 , Resistances.Armor );
			SpiritBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Clear Crystal Rod)
*
***************************************************************/

namespace Server.Items
{
	public class ClearCrystalRod : Item
	{
		public ClearCrystalRod() : base()
		{
			Id = 16894;
			Bonding = 1;
			SellPrice = 1993;
			AvailableClasses = 0x7FFF;
			Model = 28610;
			ObjectClass = 2;
			SubClass = 10;
			Level = 21;
			Name = "Clear Crystal Rod";
			Name2 = "Clear Crystal Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9967;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 65;
			SetDamage( 34 , 51 , Resistances.Armor );
			SpiritBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sarah's Guide)
*
***************************************************************/

namespace Server.Items
{
	public class SarahsGuide : Item
	{
		public SarahsGuide() : base()
		{
			Id = 17004;
			Bonding = 1;
			SellPrice = 56429;
			AvailableClasses = 0x7FFF;
			Model = 28836;
			ObjectClass = 2;
			SubClass = 10;
			Level = 61;
			Name = "Sarah's Guide";
			Name2 = "Sarah's Guide";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 282145;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetDamage( 94 , 142 , Resistances.Armor );
			StaminaBonus = 20;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Amberseal Keeper)
*
***************************************************************/

namespace Server.Items
{
	public class AmbersealKeeper : Item
	{
		public AmbersealKeeper() : base()
		{
			Id = 17113;
			Resistance[6] = 5;
			Bonding = 1;
			SellPrice = 119278;
			AvailableClasses = 0x7FFF;
			Model = 29703;
			Resistance[2] = 5;
			Resistance[4] = 5;
			ObjectClass = 2;
			SubClass = 10;
			Level = 67;
			ReqLevel = 60;
			Name = "Amberseal Keeper";
			Name2 = "Amberseal Keeper";
			Resistance[3] = 5;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 596390;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 21636 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 17493 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 144 , 228 , Resistances.Armor );
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Resurgence Rod)
*
***************************************************************/

namespace Server.Items
{
	public class ResurgenceRod : Item
	{
		public ResurgenceRod() : base()
		{
			Id = 17743;
			Bonding = 1;
			SellPrice = 40747;
			AvailableClasses = 0x7FFF;
			Model = 22391;
			ObjectClass = 2;
			SubClass = 10;
			Level = 53;
			Name = "Resurgence Rod";
			Name2 = "Resurgence Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 203739;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 20969 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 139 , 209 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Zum'rah's Vexing Cane)
*
***************************************************************/

namespace Server.Items
{
	public class ZumrahsVexingCane : Item
	{
		public ZumrahsVexingCane() : base()
		{
			Id = 18082;
			Bonding = 1;
			SellPrice = 28161;
			AvailableClasses = 0x7FFF;
			Model = 30472;
			ObjectClass = 2;
			SubClass = 10;
			Level = 47;
			ReqLevel = 42;
			Name = "Zum'rah's Vexing Cane";
			Name2 = "Zum'rah's Vexing Cane";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 140809;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Quel'dorai Channeling Rod)
*
***************************************************************/

namespace Server.Items
{
	public class QueldoraiChannelingRod : Item
	{
		public QueldoraiChannelingRod() : base()
		{
			Id = 18311;
			Bonding = 1;
			SellPrice = 56644;
			AvailableClasses = 0x7FFF;
			Model = 28511;
			ObjectClass = 2;
			SubClass = 10;
			Level = 58;
			ReqLevel = 53;
			Name = "Quel'dorai Channeling Rod";
			Name2 = "Quel'dorai Channeling Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 283224;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 21629 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 111 , 167 , Resistances.Armor );
			SpiritBonus = 18;
			StaminaBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Stoneflower Staff)
*
***************************************************************/

namespace Server.Items
{
	public class StoneflowerStaff : Item
	{
		public StoneflowerStaff() : base()
		{
			Id = 18353;
			Bonding = 1;
			SellPrice = 55030;
			AvailableClasses = 0x7FFF;
			Model = 30711;
			ObjectClass = 2;
			SubClass = 10;
			Level = 61;
			ReqLevel = 56;
			Name = "Stoneflower Staff";
			Name2 = "Stoneflower Staff";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 275154;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 85;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 113 , 171 , Resistances.Armor );
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Rod of the Ogre Magi)
*
***************************************************************/

namespace Server.Items
{
	public class RodOfTheOgreMagi : Item
	{
		public RodOfTheOgreMagi() : base()
		{
			Id = 18534;
			Bonding = 1;
			SellPrice = 71503;
			AvailableClasses = 0x7FFF;
			Model = 30870;
			ObjectClass = 2;
			SubClass = 10;
			Level = 63;
			ReqLevel = 58;
			Name = "Rod of the Ogre Magi";
			Name2 = "Rod of the Ogre Magi";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 357515;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 116 , 175 , Resistances.Armor );
			SpiritBonus = 14;
			StaminaBonus = 11;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Benediction)
*
***************************************************************/

namespace Server.Items
{
	public class Benediction : Item
	{
		public Benediction() : base()
		{
			Id = 18608;
			Bonding = 1;
			AvailableClasses = 0x10;
			Model = 31347;
			ObjectClass = 2;
			SubClass = 10;
			Level = 75;
			ReqLevel = 60;
			Name = "Benediction";
			Name2 = "Benediction";
			Quality = 4;
			AvailableRaces = 0x1FF;
			Resistance[5] = 20;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			Flags = 1088;
			SetSpell( 23041 , 0 , 0 , 0 , 1031 , 1800000 );
			SetSpell( 23236 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23264 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 134 , 222 , Resistances.Armor );
			SpiritBonus = 31;
			StaminaBonus = 10;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Anathema)
*
***************************************************************/

namespace Server.Items
{
	public class Anathema : Item
	{
		public Anathema() : base()
		{
			Id = 18609;
			Bonding = 1;
			AvailableClasses = 0x10;
			Model = 31346;
			ObjectClass = 2;
			SubClass = 10;
			Level = 75;
			ReqLevel = 60;
			Name = "Anathema";
			Name2 = "Anathema";
			Quality = 4;
			AvailableRaces = 0x1FF;
			Resistance[5] = 20;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			Flags = 1088;
			SetSpell( 23042 , 0 , 0 , 0 , 1031 , 1800000 );
			SetSpell( 21364 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23265 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 134 , 222 , Resistances.Armor );
			SpiritBonus = 31;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Lok'delar, Stave of the Ancient Keepers)
*
***************************************************************/

namespace Server.Items
{
	public class LokdelarStaveOfTheAncientKeepers : Item
	{
		public LokdelarStaveOfTheAncientKeepers() : base()
		{
			Id = 18715;
			Bonding = 1;
			SellPrice = 180778;
			AvailableClasses = 0x04;
			Model = 31163;
			ObjectClass = 2;
			SubClass = 10;
			Level = 75;
			ReqLevel = 60;
			Name = "Lok'delar, Stave of the Ancient Keepers";
			Name2 = "Lok'delar, Stave of the Ancient Keepers";
			Resistance[3] = 10;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 903890;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 2;
			Durability = 120;
			Flags = 33856;
			SetSpell( 23194 , 0 , 0 , -1 , 0 , -1 );
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14097 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 187 , 282 , Resistances.Armor );
			StaminaBonus = 26;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Staff of Dominance)
*
***************************************************************/

namespace Server.Items
{
	public class StaffOfDominance : Item
	{
		public StaffOfDominance() : base()
		{
			Id = 18842;
			Bonding = 1;
			SellPrice = 138646;
			AvailableClasses = 0x7FFF;
			Model = 20298;
			ObjectClass = 2;
			SubClass = 10;
			Level = 70;
			ReqLevel = 60;
			Name = "Staff of Dominance";
			Name2 = "Staff of Dominance";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 693232;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18056 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 126 , 205 , Resistances.Armor );
			SpiritBonus = 37;
			StaminaBonus = 16;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Stave)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsStave : Item
	{
		public GrandMarshalsStave() : base()
		{
			Id = 18873;
			Bonding = 1;
			SellPrice = 59459;
			AvailableClasses = 0x7FFF;
			Model = 31764;
			ObjectClass = 2;
			SubClass = 10;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Stave";
			Name2 = "Grand Marshal's Stave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 297299;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			Flags = 32768;
			SetSpell( 23929 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 131 , 225 , Resistances.Armor );
			StaminaBonus = 41;
			SpiritBonus = 23;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(High Warlord's War Staff)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsWarStaff : Item
	{
		public HighWarlordsWarStaff() : base()
		{
			Id = 18874;
			Bonding = 1;
			SellPrice = 59681;
			AvailableClasses = 0x7FFF;
			Model = 31765;
			ObjectClass = 2;
			SubClass = 10;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's War Staff";
			Name2 = "High Warlord's War Staff";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 298407;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			Flags = 32768;
			SetSpell( 23929 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 131 , 225 , Resistances.Armor );
			StaminaBonus = 41;
			SpiritBonus = 23;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Whiteout Staff)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteoutStaff : Item
	{
		public WhiteoutStaff() : base()
		{
			Id = 19101;
			Bonding = 1;
			SellPrice = 79411;
			AvailableClasses = 0x7FFF;
			Model = 31608;
			ObjectClass = 2;
			SubClass = 10;
			Level = 65;
			ReqLevel = 60;
			Name = "Whiteout Staff";
			Name2 = "Whiteout Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 397057;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			SpiritBonus = 16;
			StaminaBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Crackling Staff)
*
***************************************************************/

namespace Server.Items
{
	public class CracklingStaff : Item
	{
		public CracklingStaff() : base()
		{
			Id = 19102;
			Bonding = 1;
			SellPrice = 79705;
			AvailableClasses = 0x7FFF;
			Model = 31610;
			ObjectClass = 2;
			SubClass = 10;
			Level = 65;
			ReqLevel = 60;
			Name = "Crackling Staff";
			Name2 = "Crackling Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 398525;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			SpiritBonus = 16;
			StaminaBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Shadow Wing Focus Staff)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowWingFocusStaff : Item
	{
		public ShadowWingFocusStaff() : base()
		{
			Id = 19355;
			Bonding = 1;
			SellPrice = 164835;
			AvailableClasses = 0x7FFF;
			Model = 31964;
			ObjectClass = 2;
			SubClass = 10;
			Level = 75;
			ReqLevel = 60;
			Name = "Shadow Wing Focus Staff";
			Name2 = "Shadow Wing Focus Staff";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 824178;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 120;
			SetSpell( 23732 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 142 , 237 , Resistances.Armor );
			SpiritBonus = 40;
			StaminaBonus = 22;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Advisor's Gnarled Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsGnarledStaff : Item
	{
		public AdvisorsGnarledStaff() : base()
		{
			Id = 19566;
			Bonding = 1;
			SellPrice = 70171;
			AvailableClasses = 0x7FFF;
			Model = 20330;
			ObjectClass = 2;
			SubClass = 10;
			Level = 63;
			ReqLevel = 58;
			Name = "Advisor's Gnarled Staff";
			Name2 = "Advisor's Gnarled Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 350857;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 125 , 188 , Resistances.Armor );
			StaminaBonus = 21;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Advisor's Gnarled Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsGnarledStaff19567 : Item
	{
		public AdvisorsGnarledStaff19567() : base()
		{
			Id = 19567;
			Bonding = 1;
			SellPrice = 40195;
			AvailableClasses = 0x7FFF;
			Model = 20330;
			ObjectClass = 2;
			SubClass = 10;
			Level = 53;
			ReqLevel = 48;
			Name = "Advisor's Gnarled Staff";
			Name2 = "Advisor's Gnarled Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 200979;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21364 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 106 , 160 , Resistances.Armor );
			StaminaBonus = 18;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Advisor's Gnarled Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsGnarledStaff19568 : Item
	{
		public AdvisorsGnarledStaff19568() : base()
		{
			Id = 19568;
			Bonding = 1;
			SellPrice = 19874;
			AvailableClasses = 0x7FFF;
			Model = 20330;
			ObjectClass = 2;
			SubClass = 10;
			Level = 43;
			ReqLevel = 38;
			Name = "Advisor's Gnarled Staff";
			Name2 = "Advisor's Gnarled Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 99373;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
			StaminaBonus = 14;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Advisor's Gnarled Staff)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsGnarledStaff19569 : Item
	{
		public AdvisorsGnarledStaff19569() : base()
		{
			Id = 19569;
			Bonding = 1;
			SellPrice = 8554;
			AvailableClasses = 0x7FFF;
			Model = 20330;
			ObjectClass = 2;
			SubClass = 10;
			Level = 33;
			ReqLevel = 28;
			Name = "Advisor's Gnarled Staff";
			Name2 = "Advisor's Gnarled Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42771;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 64 , 97 , Resistances.Armor );
			StaminaBonus = 11;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersStaff : Item
	{
		public LorekeepersStaff() : base()
		{
			Id = 19570;
			Bonding = 1;
			SellPrice = 71229;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 63;
			ReqLevel = 58;
			Name = "Lorekeeper's Staff";
			Name2 = "Lorekeeper's Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 356148;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 125 , 188 , Resistances.Armor );
			StaminaBonus = 21;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersStaff19571 : Item
	{
		public LorekeepersStaff19571() : base()
		{
			Id = 19571;
			Bonding = 1;
			SellPrice = 41856;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 53;
			ReqLevel = 48;
			Name = "Lorekeeper's Staff";
			Name2 = "Lorekeeper's Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 209282;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21364 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 106 , 160 , Resistances.Armor );
			StaminaBonus = 18;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersStaff19572 : Item
	{
		public LorekeepersStaff19572() : base()
		{
			Id = 19572;
			Bonding = 1;
			SellPrice = 20772;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 43;
			ReqLevel = 38;
			Name = "Lorekeeper's Staff";
			Name2 = "Lorekeeper's Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 103864;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
			StaminaBonus = 14;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Staff)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersStaff19573 : Item
	{
		public LorekeepersStaff19573() : base()
		{
			Id = 19573;
			Bonding = 1;
			SellPrice = 8974;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 2;
			SubClass = 10;
			Level = 33;
			ReqLevel = 28;
			Name = "Lorekeeper's Staff";
			Name2 = "Lorekeeper's Staff";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44870;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			Flags = 32768;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 64 , 97 , Resistances.Armor );
			StaminaBonus = 11;
			SpiritBonus = 7;
		}
	}
}


