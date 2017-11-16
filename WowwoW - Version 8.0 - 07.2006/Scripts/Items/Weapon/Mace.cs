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
*				(Worn Mace)
*
***************************************************************/

namespace Server.Items
{
	public class WornMace : Item
	{
		public WornMace() : base()
		{
			Id = 36;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 5194;
			ObjectClass = 2;
			SubClass = 4;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Mace";
			Name2 = "Worn Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flanged Mace)
*
***************************************************************/

namespace Server.Items
{
	public class FlangedMace : Item
	{
		public FlangedMace() : base()
		{
			Id = 766;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 19621;
			ObjectClass = 2;
			SubClass = 4;
			Level = 7;
			ReqLevel = 2;
			Name = "Flanged Mace";
			Name2 = "Flanged Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 286;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stone Gnoll Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class StoneGnollHammer : Item
	{
		public StoneGnollHammer() : base()
		{
			Id = 781;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 19644;
			ObjectClass = 2;
			SubClass = 4;
			Level = 9;
			ReqLevel = 4;
			Name = "Stone Gnoll Hammer";
			Name2 = "Stone Gnoll Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 552;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stout Battlehammer)
*
***************************************************************/

namespace Server.Items
{
	public class StoutBattlehammer : Item
	{
		public StoutBattlehammer() : base()
		{
			Id = 789;
			Bonding = 2;
			SellPrice = 1969;
			AvailableClasses = 0x7FFF;
			Model = 19699;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Stout Battlehammer";
			Name2 = "Stout Battlehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5197;
			BuyPrice = 9847;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 17 , 33 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hammer of the Northern Wind)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfTheNorthernWind : Item
	{
		public HammerOfTheNorthernWind() : base()
		{
			Id = 810;
			Bonding = 2;
			SellPrice = 45267;
			AvailableClasses = 0x7FFF;
			Model = 19726;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Hammer of the Northern Wind";
			Name2 = "Hammer of the Northern Wind";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 226335;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 13439 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 58 , 108 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wicked Blackjack)
*
***************************************************************/

namespace Server.Items
{
	public class WickedBlackjack : Item
	{
		public WickedBlackjack() : base()
		{
			Id = 827;
			Bonding = 2;
			SellPrice = 971;
			AvailableClasses = 0x7FFF;
			Model = 3498;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			ReqLevel = 12;
			Name = "Wicked Blackjack";
			Name2 = "Wicked Blackjack";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4858;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 26 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mace)
*
***************************************************************/

namespace Server.Items
{
	public class Mace : Item
	{
		public Mace() : base()
		{
			Id = 852;
			SellPrice = 347;
			AvailableClasses = 0x7FFF;
			Model = 8287;
			ObjectClass = 2;
			SubClass = 4;
			Level = 14;
			ReqLevel = 9;
			Name = "Mace";
			Name2 = "Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1739;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 45;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Leaden Mace)
*
***************************************************************/

namespace Server.Items
{
	public class LeadenMace : Item
	{
		public LeadenMace() : base()
		{
			Id = 865;
			Bonding = 2;
			SellPrice = 5096;
			AvailableClasses = 0x7FFF;
			Model = 5212;
			ObjectClass = 2;
			SubClass = 4;
			Level = 31;
			ReqLevel = 26;
			Name = "Leaden Mace";
			Name2 = "Leaden Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5224;
			BuyPrice = 25480;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 32 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ardent Custodian)
*
***************************************************************/

namespace Server.Items
{
	public class ArdentCustodian : Item
	{
		public ArdentCustodian() : base()
		{
			Id = 868;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 21532;
			AvailableClasses = 0x7FFF;
			Model = 19713;
			ObjectClass = 2;
			SubClass = 4;
			Level = 43;
			ReqLevel = 38;
			Name = "Ardent Custodian";
			Name2 = "Ardent Custodian";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 107664;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 7518 , 1 , 0 , 0 , 0 , 0 );
			SetDamage( 48 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wicked Spiked Mace)
*
***************************************************************/

namespace Server.Items
{
	public class WickedSpikedMace : Item
	{
		public WickedSpikedMace() : base()
		{
			Id = 920;
			Bonding = 2;
			SellPrice = 2821;
			AvailableClasses = 0x7FFF;
			Model = 19703;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Wicked Spiked Mace";
			Name2 = "Wicked Spiked Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14106;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 22 , 42 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Flail)
*
***************************************************************/

namespace Server.Items
{
	public class Flail : Item
	{
		public Flail() : base()
		{
			Id = 925;
			SellPrice = 1559;
			AvailableClasses = 0x7FFF;
			Model = 4351;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Flail";
			Name2 = "Flail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7797;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Midnight Mace)
*
***************************************************************/

namespace Server.Items
{
	public class MidnightMace : Item
	{
		public MidnightMace() : base()
		{
			Id = 936;
			Bonding = 2;
			SellPrice = 11620;
			AvailableClasses = 0x7FFF;
			Model = 5215;
			ObjectClass = 2;
			SubClass = 4;
			Level = 38;
			ReqLevel = 33;
			Name = "Midnight Mace";
			Name2 = "Midnight Mace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58104;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 45 , 84 , Resistances.Armor );
			SetDamage( 1 , 10 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Compact Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class CompactHammer : Item
	{
		public CompactHammer() : base()
		{
			Id = 1009;
			Bonding = 1;
			SellPrice = 490;
			AvailableClasses = 0x7FFF;
			Model = 8583;
			ObjectClass = 2;
			SubClass = 4;
			Level = 13;
			Name = "Compact Hammer";
			Name2 = "Compact Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2451;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 45;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Solid Metal Club)
*
***************************************************************/

namespace Server.Items
{
	public class SolidMetalClub : Item
	{
		public SolidMetalClub() : base()
		{
			Id = 1158;
			Bonding = 1;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 19643;
			ObjectClass = 2;
			SubClass = 4;
			Level = 10;
			Name = "Solid Metal Club";
			Name2 = "Solid Metal Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 731;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Murphstar)
*
***************************************************************/

namespace Server.Items
{
	public class Murphstar : Item
	{
		public Murphstar() : base()
		{
			Id = 1207;
			Bonding = 2;
			SellPrice = 9892;
			AvailableClasses = 0x7FFF;
			Model = 5223;
			ObjectClass = 2;
			SubClass = 4;
			Level = 39;
			ReqLevel = 34;
			Name = "Murphstar";
			Name2 = "Murphstar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5242;
			BuyPrice = 49460;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gnoll Punisher)
*
***************************************************************/

namespace Server.Items
{
	public class GnollPunisher : Item
	{
		public GnollPunisher() : base()
		{
			Id = 1214;
			Bonding = 2;
			SellPrice = 930;
			AvailableClasses = 0x7FFF;
			Model = 19625;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			ReqLevel = 12;
			Name = "Gnoll Punisher";
			Name2 = "Gnoll Punisher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4651;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 27 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Blackrock Mace)
*
***************************************************************/

namespace Server.Items
{
	public class BlackrockMace : Item
	{
		public BlackrockMace() : base()
		{
			Id = 1296;
			Bonding = 2;
			SellPrice = 1681;
			AvailableClasses = 0x7FFF;
			Model = 5195;
			ObjectClass = 2;
			SubClass = 4;
			Level = 21;
			ReqLevel = 16;
			Name = "Blackrock Mace";
			Name2 = "Blackrock Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8408;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 18 , 35 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rock Mace)
*
***************************************************************/

namespace Server.Items
{
	public class RockMace : Item
	{
		public RockMace() : base()
		{
			Id = 1382;
			Bonding = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 19636;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Rock Mace";
			Name2 = "Rock Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 122;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Kobold Mining Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class KoboldMiningMallet : Item
	{
		public KoboldMiningMallet() : base()
		{
			Id = 1389;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 8575;
			ObjectClass = 2;
			SubClass = 4;
			Level = 7;
			ReqLevel = 2;
			Name = "Kobold Mining Mallet";
			Name2 = "Kobold Mining Mallet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 291;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Driftwood Club)
*
***************************************************************/

namespace Server.Items
{
	public class DriftwoodClub : Item
	{
		public DriftwoodClub() : base()
		{
			Id = 1394;
			Bonding = 2;
			SellPrice = 740;
			AvailableClasses = 0x7FFF;
			Model = 5204;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			ReqLevel = 10;
			Name = "Driftwood Club";
			Name2 = "Driftwood Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3700;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Carpenter's Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class CarpentersMallet : Item
	{
		public CarpentersMallet() : base()
		{
			Id = 1415;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 19613;
			ObjectClass = 2;
			SubClass = 4;
			Level = 9;
			ReqLevel = 4;
			Name = "Carpenter's Mallet";
			Name2 = "Carpenter's Mallet";
			AvailableRaces = 0x1FF;
			BuyPrice = 363;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 35;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gnoll Skull Basher)
*
***************************************************************/

namespace Server.Items
{
	public class GnollSkullBasher : Item
	{
		public GnollSkullBasher() : base()
		{
			Id = 1440;
			Bonding = 2;
			SellPrice = 1230;
			AvailableClasses = 0x7FFF;
			Model = 8570;
			ObjectClass = 2;
			SubClass = 4;
			Level = 19;
			ReqLevel = 14;
			Name = "Gnoll Skull Basher";
			Name2 = "Gnoll Skull Basher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6151;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 34 , Resistances.Armor );
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Shadowhide Mace)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowhideMace : Item
	{
		public ShadowhideMace() : base()
		{
			Id = 1457;
			Bonding = 2;
			SellPrice = 1850;
			AvailableClasses = 0x7FFF;
			Model = 19683;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Shadowhide Mace";
			Name2 = "Shadowhide Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9251;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 17 , 32 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fist of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class FistOfThePeoplesMilitia : Item
	{
		public FistOfThePeoplesMilitia() : base()
		{
			Id = 1480;
			Bonding = 1;
			SellPrice = 954;
			AvailableClasses = 0x7FFF;
			Model = 9381;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			Name = "Fist of the People's Militia";
			Name2 = "Fist of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4773;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 9 , 18 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Face Smasher)
*
***************************************************************/

namespace Server.Items
{
	public class FaceSmasher : Item
	{
		public FaceSmasher() : base()
		{
			Id = 1483;
			Bonding = 2;
			SellPrice = 2025;
			AvailableClasses = 0x7FFF;
			Model = 9117;
			ObjectClass = 2;
			SubClass = 4;
			Level = 21;
			ReqLevel = 16;
			Name = "Face Smasher";
			Name2 = "Face Smasher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10129;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 70;
			SetDamage( 25 , 48 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heavy Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyHammer : Item
	{
		public HeavyHammer() : base()
		{
			Id = 1510;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 19775;
			ObjectClass = 2;
			SubClass = 4;
			Level = 12;
			ReqLevel = 7;
			Name = "Heavy Hammer";
			Name2 = "Heavy Hammer";
			AvailableRaces = 0x1FF;
			BuyPrice = 752;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skullcrusher Mace)
*
***************************************************************/

namespace Server.Items
{
	public class SkullcrusherMace : Item
	{
		public SkullcrusherMace() : base()
		{
			Id = 1608;
			Bonding = 2;
			SellPrice = 18940;
			AvailableClasses = 0x7FFF;
			Model = 19743;
			ObjectClass = 2;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Skullcrusher Mace";
			Name2 = "Skullcrusher Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5269;
			BuyPrice = 94703;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 53 , 99 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Viking Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class VikingWarhammer : Item
	{
		public VikingWarhammer() : base()
		{
			Id = 1721;
			Bonding = 2;
			SellPrice = 35815;
			AvailableClasses = 0x7FFF;
			Model = 8581;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Viking Warhammer";
			Name2 = "Viking Warhammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 179079;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 60 , 112 , Resistances.Armor );
			StaminaBonus = 11;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ornamental Mace)
*
***************************************************************/

namespace Server.Items
{
	public class OrnamentalMace : Item
	{
		public OrnamentalMace() : base()
		{
			Id = 1815;
			SellPrice = 366;
			AvailableClasses = 0x7FFF;
			Model = 5217;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			ReqLevel = 12;
			Name = "Ornamental Mace";
			Name2 = "Ornamental Mace";
			AvailableRaces = 0x1FF;
			BuyPrice = 1832;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 10 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bludgeoning Cudgel)
*
***************************************************************/

namespace Server.Items
{
	public class BludgeoningCudgel : Item
	{
		public BludgeoningCudgel() : base()
		{
			Id = 1823;
			SellPrice = 779;
			AvailableClasses = 0x7FFF;
			Model = 6794;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Bludgeoning Cudgel";
			Name2 = "Bludgeoning Cudgel";
			AvailableRaces = 0x1FF;
			BuyPrice = 3896;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bulky Bludgeon)
*
***************************************************************/

namespace Server.Items
{
	public class BulkyBludgeon : Item
	{
		public BulkyBludgeon() : base()
		{
			Id = 1825;
			SellPrice = 1548;
			AvailableClasses = 0x7FFF;
			Model = 19784;
			ObjectClass = 2;
			SubClass = 4;
			Level = 28;
			ReqLevel = 23;
			Name = "Bulky Bludgeon";
			Name2 = "Bulky Bludgeon";
			AvailableRaces = 0x1FF;
			BuyPrice = 7742;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 70;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Studded Blackjack)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedBlackjack : Item
	{
		public StuddedBlackjack() : base()
		{
			Id = 1913;
			SellPrice = 148;
			AvailableClasses = 0x7FFF;
			Model = 5009;
			ObjectClass = 2;
			SubClass = 4;
			Level = 10;
			ReqLevel = 5;
			Name = "Studded Blackjack";
			Name2 = "Studded Blackjack";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 742;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Weighted Sap)
*
***************************************************************/

namespace Server.Items
{
	public class WeightedSap : Item
	{
		public WeightedSap() : base()
		{
			Id = 1926;
			Bonding = 2;
			SellPrice = 687;
			AvailableClasses = 0x7FFF;
			Model = 5225;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			ReqLevel = 10;
			Name = "Weighted Sap";
			Name2 = "Weighted Sap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3438;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 22 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Block Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class BlockMallet : Item
	{
		public BlockMallet() : base()
		{
			Id = 1938;
			Bonding = 2;
			SellPrice = 1962;
			AvailableClasses = 0x7FFF;
			Model = 8565;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Block Mallet";
			Name2 = "Block Mallet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9810;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 14 , 26 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Petrified Shinbone)
*
***************************************************************/

namespace Server.Items
{
	public class PetrifiedShinbone : Item
	{
		public PetrifiedShinbone() : base()
		{
			Id = 1958;
			Bonding = 2;
			SellPrice = 975;
			AvailableClasses = 0x7FFF;
			Model = 1515;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			ReqLevel = 12;
			Name = "Petrified Shinbone";
			Name2 = "Petrified Shinbone";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4876;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class Hammer : Item
	{
		public Hammer() : base()
		{
			Id = 2028;
			SellPrice = 1013;
			AvailableClasses = 0x7FFF;
			Model = 22119;
			ObjectClass = 2;
			SubClass = 4;
			Level = 21;
			ReqLevel = 16;
			Name = "Hammer";
			Name2 = "Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5065;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 16 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Anvilmar Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class AnvilmarHammer : Item
	{
		public AnvilmarHammer() : base()
		{
			Id = 2048;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 19770;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Anvilmar Hammer";
			Name2 = "Anvilmar Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 129;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Small Wooden Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SmallWoodenHammer : Item
	{
		public SmallWoodenHammer() : base()
		{
			Id = 2055;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 8579;
			ObjectClass = 2;
			SubClass = 4;
			Level = 4;
			ReqLevel = 1;
			Name = "Small Wooden Hammer";
			Name2 = "Small Wooden Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 25;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Trogg Club)
*
***************************************************************/

namespace Server.Items
{
	public class TroggClub : Item
	{
		public TroggClub() : base()
		{
			Id = 2064;
			SellPrice = 191;
			AvailableClasses = 0x7FFF;
			Model = 19650;
			ObjectClass = 2;
			SubClass = 4;
			Level = 11;
			ReqLevel = 6;
			Name = "Trogg Club";
			Name2 = "Trogg Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 958;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Priest's Mace)
*
***************************************************************/

namespace Server.Items
{
	public class PriestsMace : Item
	{
		public PriestsMace() : base()
		{
			Id = 2075;
			Bonding = 2;
			SellPrice = 386;
			AvailableClasses = 0x7FFF;
			Model = 5218;
			ObjectClass = 2;
			SubClass = 4;
			Level = 12;
			ReqLevel = 7;
			Name = "Priest's Mace";
			Name2 = "Priest's Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5170;
			BuyPrice = 1932;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sergeant's Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsWarhammer : Item
	{
		public SergeantsWarhammer() : base()
		{
			Id = 2079;
			Bonding = 2;
			SellPrice = 933;
			AvailableClasses = 0x7FFF;
			Model = 19637;
			ObjectClass = 2;
			SubClass = 4;
			Level = 17;
			ReqLevel = 12;
			Name = "Sergeant's Warhammer";
			Name2 = "Sergeant's Warhammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5179;
			BuyPrice = 4669;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Club)
*
***************************************************************/

namespace Server.Items
{
	public class Club : Item
	{
		public Club() : base()
		{
			Id = 2130;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 22118;
			ObjectClass = 2;
			SubClass = 4;
			Level = 3;
			ReqLevel = 1;
			Name = "Club";
			Name2 = "Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Diamond Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class DiamondHammer : Item
	{
		public DiamondHammer() : base()
		{
			Id = 2194;
			Bonding = 2;
			SellPrice = 3276;
			AvailableClasses = 0x7FFF;
			Model = 8567;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Diamond Hammer";
			Name2 = "Diamond Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16383;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 28 , 53 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hand of Edward the Odd)
*
***************************************************************/

namespace Server.Items
{
	public class HandOfEdwardTheOdd : Item
	{
		public HandOfEdwardTheOdd() : base()
		{
			Id = 2243;
			Bonding = 2;
			SellPrice = 70554;
			AvailableClasses = 0x7FFF;
			Model = 19729;
			ObjectClass = 2;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Hand of Edward the Odd";
			Name2 = "Hand of Edward the Odd";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 352770;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18803 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
			IqBonus = 10;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Skeletal Club)
*
***************************************************************/

namespace Server.Items
{
	public class SkeletalClub : Item
	{
		public SkeletalClub() : base()
		{
			Id = 2256;
			Bonding = 2;
			SellPrice = 2996;
			AvailableClasses = 0x7FFF;
			Model = 5221;
			ObjectClass = 2;
			SubClass = 4;
			Level = 24;
			ReqLevel = 19;
			Name = "Skeletal Club";
			Name2 = "Skeletal Club";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14982;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 13440 , 2 , 0 , 0 , 0 , 0 );
			SetDamage( 28 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frostmane Club)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneClub : Item
	{
		public FrostmaneClub() : base()
		{
			Id = 2259;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 19623;
			ObjectClass = 2;
			SubClass = 4;
			Level = 8;
			ReqLevel = 3;
			Name = "Frostmane Club";
			Name2 = "Frostmane Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 378;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 35;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonesplinter Mace)
*
***************************************************************/

namespace Server.Items
{
	public class StonesplinterMace : Item
	{
		public StonesplinterMace() : base()
		{
			Id = 2267;
			Bonding = 2;
			SellPrice = 711;
			AvailableClasses = 0x7FFF;
			Model = 5208;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			ReqLevel = 10;
			Name = "Stonesplinter Mace";
			Name2 = "Stonesplinter Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3558;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 10 , 20 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Splintered Board)
*
***************************************************************/

namespace Server.Items
{
	public class SplinteredBoard : Item
	{
		public SplinteredBoard() : base()
		{
			Id = 2485;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 5219;
			ObjectClass = 2;
			SubClass = 4;
			Level = 3;
			ReqLevel = 1;
			Name = "Splintered Board";
			Name2 = "Splintered Board";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 53;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			SetDamage( 1 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cudgel)
*
***************************************************************/

namespace Server.Items
{
	public class Cudgel : Item
	{
		public Cudgel() : base()
		{
			Id = 2492;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 12992;
			ObjectClass = 2;
			SubClass = 4;
			Level = 7;
			ReqLevel = 2;
			Name = "Cudgel";
			Name2 = "Cudgel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 284;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Light Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class LightHammer : Item
	{
		public LightHammer() : base()
		{
			Id = 2500;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 19626;
			ObjectClass = 2;
			SubClass = 4;
			Level = 7;
			ReqLevel = 2;
			Name = "Light Hammer";
			Name2 = "Light Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 293;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Truncheon)
*
***************************************************************/

namespace Server.Items
{
	public class Truncheon : Item
	{
		public Truncheon() : base()
		{
			Id = 2524;
			SellPrice = 3838;
			AvailableClasses = 0x7FFF;
			Model = 8803;
			ObjectClass = 2;
			SubClass = 4;
			Level = 34;
			ReqLevel = 29;
			Name = "Truncheon";
			Name2 = "Truncheon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 19192;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 29 , 54 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Morning Star)
*
***************************************************************/

namespace Server.Items
{
	public class MorningStar : Item
	{
		public MorningStar() : base()
		{
			Id = 2532;
			SellPrice = 10521;
			AvailableClasses = 0x7FFF;
			Model = 22120;
			ObjectClass = 2;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Morning Star";
			Name2 = "Morning Star";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 52608;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 34 , 64 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Death Speaker Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class DeathSpeakerScepter : Item
	{
		public DeathSpeakerScepter() : base()
		{
			Id = 2816;
			Bonding = 1;
			SellPrice = 7324;
			AvailableClasses = 0x7FFF;
			Model = 19669;
			ObjectClass = 2;
			SubClass = 4;
			Level = 33;
			ReqLevel = 28;
			Name = "Death Speaker Scepter";
			Name2 = "Death Speaker Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36620;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 7679 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7708 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 33 , 63 , Resistances.Armor );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Mo'grosh Masher)
*
***************************************************************/

namespace Server.Items
{
	public class MogroshMasher : Item
	{
		public MogroshMasher() : base()
		{
			Id = 2821;
			Bonding = 2;
			SellPrice = 1117;
			AvailableClasses = 0x7FFF;
			Model = 19633;
			ObjectClass = 2;
			SubClass = 4;
			Level = 18;
			ReqLevel = 13;
			Name = "Mo'grosh Masher";
			Name2 = "Mo'grosh Masher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5589;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 55;
			SetDamage( 16 , 30 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Copper Mace)
*
***************************************************************/

namespace Server.Items
{
	public class CopperMace : Item
	{
		public CopperMace() : base()
		{
			Id = 2844;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 2861;
			ObjectClass = 2;
			SubClass = 4;
			Level = 9;
			ReqLevel = 4;
			Name = "Copper Mace";
			Name2 = "Copper Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 530;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 35;
			SetDamage( 6 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bronze Mace)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeMace : Item
	{
		public BronzeMace() : base()
		{
			Id = 2848;
			SellPrice = 1119;
			AvailableClasses = 0x7FFF;
			Model = 5198;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Bronze Mace";
			Name2 = "Bronze Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5595;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frostmane Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneScepter : Item
	{
		public FrostmaneScepter() : base()
		{
			Id = 3223;
			Bonding = 2;
			SellPrice = 306;
			AvailableClasses = 0x7FFF;
			Model = 19624;
			ObjectClass = 2;
			SubClass = 4;
			Level = 11;
			ReqLevel = 6;
			Name = "Frostmane Scepter";
			Name2 = "Frostmane Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1534;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Putrid Wooden Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class PutridWoodenHammer : Item
	{
		public PutridWoodenHammer() : base()
		{
			Id = 3262;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 21052;
			ObjectClass = 2;
			SubClass = 4;
			Level = 3;
			ReqLevel = 1;
			Name = "Putrid Wooden Hammer";
			Name2 = "Putrid Wooden Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Forsaken Maul)
*
***************************************************************/

namespace Server.Items
{
	public class ForsakenMaul : Item
	{
		public ForsakenMaul() : base()
		{
			Id = 3269;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 19772;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Forsaken Maul";
			Name2 = "Forsaken Maul";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 129;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadman Club)
*
***************************************************************/

namespace Server.Items
{
	public class DeadmanClub : Item
	{
		public DeadmanClub() : base()
		{
			Id = 3294;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 5203;
			ObjectClass = 2;
			SubClass = 4;
			Level = 3;
			ReqLevel = 1;
			Name = "Deadman Club";
			Name2 = "Deadman Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 58;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spiked Wooden Plank)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedWoodenPlank : Item
	{
		public SpikedWoodenPlank() : base()
		{
			Id = 3329;
			SellPrice = 179;
			AvailableClasses = 0x7FFF;
			Model = 5204;
			ObjectClass = 2;
			SubClass = 4;
			Level = 11;
			ReqLevel = 6;
			Name = "Spiked Wooden Plank";
			Name2 = "Spiked Wooden Plank";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 896;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crested Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class CrestedScepter : Item
	{
		public CrestedScepter() : base()
		{
			Id = 3414;
			Bonding = 2;
			SellPrice = 4028;
			AvailableClasses = 0x7FFF;
			Model = 6796;
			ObjectClass = 2;
			SubClass = 4;
			Level = 27;
			ReqLevel = 22;
			Name = "Crested Scepter";
			Name2 = "Crested Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20144;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 80;
			SetDamage( 31 , 58 , Resistances.Armor );
			StaminaBonus = 5;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Heavy Bronze Mace)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyBronzeMace : Item
	{
		public HeavyBronzeMace() : base()
		{
			Id = 3491;
			Bonding = 2;
			SellPrice = 2741;
			AvailableClasses = 0x7FFF;
			Model = 5211;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Heavy Bronze Mace";
			Name2 = "Heavy Bronze Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13709;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 25 , 47 , Resistances.Armor );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Mighty Iron Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class MightyIronHammer : Item
	{
		public MightyIronHammer() : base()
		{
			Id = 3492;
			Bonding = 2;
			SellPrice = 4552;
			AvailableClasses = 0x7FFF;
			Model = 3780;
			ObjectClass = 2;
			SubClass = 4;
			Level = 30;
			ReqLevel = 25;
			Name = "Mighty Iron Hammer";
			Name2 = "Mighty Iron Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22764;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 30 , 57 , Resistances.Armor );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bonegrinding Pestle)
*
***************************************************************/

namespace Server.Items
{
	public class BonegrindingPestle : Item
	{
		public BonegrindingPestle() : base()
		{
			Id = 3570;
			Bonding = 1;
			SellPrice = 839;
			AvailableClasses = 0x7FFF;
			Model = 5197;
			ObjectClass = 2;
			SubClass = 4;
			Level = 16;
			Name = "Bonegrinding Pestle";
			Name2 = "Bonegrinding Pestle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4197;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 13 , 26 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stone Club)
*
***************************************************************/

namespace Server.Items
{
	public class StoneClub : Item
	{
		public StoneClub() : base()
		{
			Id = 3787;
			SellPrice = 4289;
			AvailableClasses = 0x7FFF;
			Model = 19694;
			ObjectClass = 2;
			SubClass = 4;
			Level = 40;
			ReqLevel = 35;
			Name = "Stone Club";
			Name2 = "Stone Club";
			AvailableRaces = 0x1FF;
			BuyPrice = 21448;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 20 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blunting Mace)
*
***************************************************************/

namespace Server.Items
{
	public class BluntingMace : Item
	{
		public BluntingMace() : base()
		{
			Id = 4021;
			SellPrice = 7198;
			AvailableClasses = 0x7FFF;
			Model = 19716;
			ObjectClass = 2;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Blunting Mace";
			Name2 = "Blunting Mace";
			AvailableRaces = 0x1FF;
			BuyPrice = 35991;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 24 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mug O' Hurt)
*
***************************************************************/

namespace Server.Items
{
	public class MugOHurt : Item
	{
		public MugOHurt() : base()
		{
			Id = 4090;
			Bonding = 2;
			SellPrice = 20736;
			AvailableClasses = 0x7FFF;
			Model = 18496;
			ObjectClass = 2;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Mug O' Hurt";
			Name2 = "Mug O' Hurt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 103683;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			Durability = 90;
			SetSpell( 13496 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 37 , 69 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bookmaker's Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class BookmakersScepter : Item
	{
		public BookmakersScepter() : base()
		{
			Id = 4122;
			Bonding = 1;
			SellPrice = 8384;
			AvailableClasses = 0x7FFF;
			Model = 3498;
			ObjectClass = 2;
			SubClass = 4;
			Level = 37;
			Name = "Bookmaker's Scepter";
			Name2 = "Bookmaker's Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41922;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 59 , Resistances.Armor );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cranial Thumper)
*
***************************************************************/

namespace Server.Items
{
	public class CranialThumper : Item
	{
		public CranialThumper() : base()
		{
			Id = 4303;
			Bonding = 2;
			SellPrice = 398;
			AvailableClasses = 0x7FFF;
			Model = 19615;
			ObjectClass = 2;
			SubClass = 4;
			Level = 12;
			ReqLevel = 7;
			Name = "Cranial Thumper";
			Name2 = "Cranial Thumper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1991;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 12 , 24 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Bruiser Club)
*
***************************************************************/

namespace Server.Items
{
	public class BruiserClub : Item
	{
		public BruiserClub() : base()
		{
			Id = 4439;
			Bonding = 2;
			SellPrice = 1788;
			AvailableClasses = 0x7FFF;
			Model = 6795;
			ObjectClass = 2;
			SubClass = 4;
			Level = 22;
			ReqLevel = 17;
			Name = "Bruiser Club";
			Name2 = "Bruiser Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8944;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 60;
			SetDamage( 17 , 32 , Resistances.Armor );
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Black Water Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWaterHammer : Item
	{
		public BlackWaterHammer() : base()
		{
			Id = 4511;
			Bonding = 1;
			SellPrice = 11256;
			AvailableClasses = 0x7FFF;
			Model = 19783;
			ObjectClass = 2;
			SubClass = 4;
			Level = 40;
			Name = "Black Water Hammer";
			Name2 = "Black Water Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56284;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 42 , 78 , Resistances.Armor );
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Billy Club)
*
***************************************************************/

namespace Server.Items
{
	public class BillyClub : Item
	{
		public BillyClub() : base()
		{
			Id = 4563;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 4609;
			ObjectClass = 2;
			SubClass = 4;
			Level = 9;
			ReqLevel = 4;
			Name = "Billy Club";
			Name2 = "Billy Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 552;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 35;
			SetDamage( 6 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Staunch Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class StaunchHammer : Item
	{
		public StaunchHammer() : base()
		{
			Id = 4569;
			Bonding = 2;
			SellPrice = 612;
			AvailableClasses = 0x7FFF;
			Model = 19778;
			ObjectClass = 2;
			SubClass = 4;
			Level = 14;
			ReqLevel = 9;
			Name = "Staunch Hammer";
			Name2 = "Staunch Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5170;
			BuyPrice = 3063;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 45;
			SetDamage( 11 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Primitive Club)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveClub : Item
	{
		public PrimitiveClub() : base()
		{
			Id = 4924;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 19634;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Primitive Club";
			Name2 = "Primitive Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 129;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stinging Mace)
*
***************************************************************/

namespace Server.Items
{
	public class StingingMace : Item
	{
		public StingingMace() : base()
		{
			Id = 4948;
			Bonding = 1;
			SellPrice = 326;
			AvailableClasses = 0x7FFF;
			Model = 5009;
			ObjectClass = 2;
			SubClass = 4;
			Level = 11;
			Name = "Stinging Mace";
			Name2 = "Stinging Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1633;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 18 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Skorn's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SkornsHammer : Item
	{
		public SkornsHammer() : base()
		{
			Id = 4971;
			Bonding = 1;
			SellPrice = 383;
			AvailableClasses = 0x7FFF;
			Model = 8572;
			ObjectClass = 2;
			SubClass = 4;
			Level = 12;
			Name = "Skorn's Hammer";
			Name2 = "Skorn's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1919;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 12 , 23 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ryedol's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class RyedolsHammer : Item
	{
		public RyedolsHammer() : base()
		{
			Id = 4978;
			Bonding = 1;
			SellPrice = 7976;
			AvailableClasses = 0x7FFF;
			Model = 19741;
			ObjectClass = 2;
			SubClass = 4;
			Level = 36;
			Name = "Ryedol's Hammer";
			Name2 = "Ryedol's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39882;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 33 , 62 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cookie's Tenderizer)
*
***************************************************************/

namespace Server.Items
{
	public class CookiesTenderizer : Item
	{
		public CookiesTenderizer() : base()
		{
			Id = 5197;
			Bonding = 1;
			SellPrice = 1597;
			AvailableClasses = 0x7FFF;
			Model = 20953;
			ObjectClass = 2;
			SubClass = 4;
			Level = 21;
			ReqLevel = 16;
			Name = "Cookie's Tenderizer";
			Name2 = "Cookie's Tenderizer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7989;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			Durability = 60;
			SetDamage( 20 , 39 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Kovork's Rattle)
*
***************************************************************/

namespace Server.Items
{
	public class KovorksRattle : Item
	{
		public KovorksRattle() : base()
		{
			Id = 5256;
			Bonding = 2;
			SellPrice = 7227;
			AvailableClasses = 0x7FFF;
			Model = 19673;
			ObjectClass = 2;
			SubClass = 4;
			Level = 35;
			ReqLevel = 30;
			Name = "Kovork's Rattle";
			Name2 = "Kovork's Rattle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36136;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 38 , 72 , Resistances.Armor );
			StrBonus = 2;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Engineer's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class EngineersHammer : Item
	{
		public EngineersHammer() : base()
		{
			Id = 5324;
			Bonding = 1;
			SellPrice = 776;
			AvailableClasses = 0x7FFF;
			Model = 8568;
			ObjectClass = 2;
			SubClass = 4;
			Level = 16;
			Name = "Engineer's Hammer";
			Name2 = "Engineer's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3881;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 13 , 26 , Resistances.Armor );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Iridescent Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class IridescentHammer : Item
	{
		public IridescentHammer() : base()
		{
			Id = 5541;
			Bonding = 2;
			SellPrice = 3693;
			AvailableClasses = 0x7FFF;
			Model = 19801;
			ObjectClass = 2;
			SubClass = 4;
			Level = 28;
			ReqLevel = 23;
			Name = "Iridescent Hammer";
			Name2 = "Iridescent Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18469;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 70;
			SetDamage( 18 , 34 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Militia Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaHammer : Item
	{
		public MilitiaHammer() : base()
		{
			Id = 5580;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 19777;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Militia Hammer";
			Name2 = "Militia Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 128;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thornroot Club)
*
***************************************************************/

namespace Server.Items
{
	public class ThornrootClub : Item
	{
		public ThornrootClub() : base()
		{
			Id = 5587;
			Bonding = 1;
			SellPrice = 512;
			AvailableClasses = 0x7FFF;
			Model = 19648;
			ObjectClass = 2;
			SubClass = 4;
			Level = 13;
			Name = "Thornroot Club";
			Name2 = "Thornroot Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2562;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 45;
			SetDamage( 10 , 19 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hardwood Cudgel)
*
***************************************************************/

namespace Server.Items
{
	public class HardwoodCudgel : Item
	{
		public HardwoodCudgel() : base()
		{
			Id = 5757;
			Bonding = 1;
			SellPrice = 1363;
			AvailableClasses = 0x7FFF;
			Model = 8803;
			ObjectClass = 2;
			SubClass = 4;
			Level = 20;
			Name = "Hardwood Cudgel";
			Name2 = "Hardwood Cudgel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6816;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			Durability = 55;
			SetDamage( 18 , 34 , Resistances.Armor );
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Noboru's Cudgel)
*
***************************************************************/

namespace Server.Items
{
	public class NoborusCudgel : Item
	{
		public NoborusCudgel() : base()
		{
			Id = 6196;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6794;
			ObjectClass = 2;
			SubClass = 4;
			Level = 34;
			ReqLevel = 29;
			Name = "Noboru's Cudgel";
			Name2 = "Noboru's Cudgel";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			StartQuest = 1392;
			MaxCount = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			Flags = 2048;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Baron's Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class BaronsScepter : Item
	{
		public BaronsScepter() : base()
		{
			Id = 6323;
			Bonding = 1;
			SellPrice = 2611;
			AvailableClasses = 0x7FFF;
			Model = 21051;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Baron's Scepter";
			Name2 = "Baron's Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13058;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 21 , 40 , Resistances.Armor );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Steelscale Crushfish)
*
***************************************************************/

namespace Server.Items
{
	public class SteelscaleCrushfish : Item
	{
		public SteelscaleCrushfish() : base()
		{
			Id = 6360;
			Bonding = 2;
			SellPrice = 2581;
			AvailableClasses = 0x7FFF;
			Model = 11453;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Steelscale Crushfish";
			Name2 = "Steelscale Crushfish";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12905;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 22 , 42 , Resistances.Armor );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Stinging Viper)
*
***************************************************************/

namespace Server.Items
{
	public class StingingViper : Item
	{
		public StingingViper() : base()
		{
			Id = 6472;
			Bonding = 1;
			SellPrice = 3018;
			AvailableClasses = 0x7FFF;
			Model = 24741;
			ObjectClass = 2;
			SubClass = 4;
			Level = 24;
			ReqLevel = 19;
			Name = "Stinging Viper";
			Name2 = "Stinging Viper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15094;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18197 , 2 , 0 , 0 , 0 , 0 );
			SetDamage( 30 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Broken Wine Bottle)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenWineBottle : Item
	{
		public BrokenWineBottle() : base()
		{
			Id = 6651;
			SellPrice = 234;
			AvailableClasses = 0x7FFF;
			Description = "Alterac Old-and-Yellow";
			Model = 18652;
			ObjectClass = 2;
			SubClass = 4;
			Level = 12;
			ReqLevel = 7;
			Name = "Broken Wine Bottle";
			Name2 = "Broken Wine Bottle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1173;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 40;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Windstorm Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class WindstormHammer : Item
	{
		public WindstormHammer() : base()
		{
			Id = 6804;
			Bonding = 1;
			SellPrice = 11262;
			AvailableClasses = 0x7FFF;
			Model = 19707;
			ObjectClass = 2;
			SubClass = 4;
			Level = 40;
			Name = "Windstorm Hammer";
			Name2 = "Windstorm Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56312;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 32 , 61 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Elunite Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class EluniteHammer : Item
	{
		public EluniteHammer() : base()
		{
			Id = 6968;
			Bonding = 1;
			SellPrice = 698;
			AvailableClasses = 0x01;
			Model = 19771;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			Name = "Elunite Hammer";
			Name2 = "Elunite Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3494;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Umbral Mace)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralMace : Item
	{
		public UmbralMace() : base()
		{
			Id = 6982;
			Bonding = 1;
			SellPrice = 683;
			AvailableClasses = 0x01;
			Model = 19652;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			Name = "Umbral Mace";
			Name2 = "Umbral Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3415;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Haggard's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class HaggardsHammer : Item
	{
		public HaggardsHammer() : base()
		{
			Id = 6983;
			Bonding = 1;
			SellPrice = 685;
			AvailableClasses = 0x01;
			Model = 19773;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			Name = "Haggard's Hammer";
			Name2 = "Haggard's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3428;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Heirloom Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class HeirloomHammer : Item
	{
		public HeirloomHammer() : base()
		{
			Id = 7117;
			Bonding = 1;
			SellPrice = 688;
			AvailableClasses = 0x01;
			Model = 19776;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			Name = "Heirloom Hammer";
			Name2 = "Heirloom Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3441;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Thun'grim's Mace)
*
***************************************************************/

namespace Server.Items
{
	public class ThungrimsMace : Item
	{
		public ThungrimsMace() : base()
		{
			Id = 7328;
			Bonding = 1;
			SellPrice = 701;
			AvailableClasses = 0x01;
			Model = 19649;
			ObjectClass = 2;
			SubClass = 4;
			Level = 15;
			Name = "Thun'grim's Mace";
			Name2 = "Thun'grim's Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3506;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 23 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ironspine's Fist)
*
***************************************************************/

namespace Server.Items
{
	public class IronspinesFist : Item
	{
		public IronspinesFist() : base()
		{
			Id = 7687;
			Bonding = 1;
			SellPrice = 8836;
			AvailableClasses = 0x7FFF;
			Model = 15726;
			ObjectClass = 2;
			SubClass = 4;
			Level = 35;
			ReqLevel = 30;
			Name = "Ironspine's Fist";
			Name2 = "Ironspine's Fist";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44180;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 38 , 72 , Resistances.Armor );
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hand of Righteousness)
*
***************************************************************/

namespace Server.Items
{
	public class HandOfRighteousness : Item
	{
		public HandOfRighteousness() : base()
		{
			Id = 7721;
			Bonding = 1;
			SellPrice = 17922;
			AvailableClasses = 0x7FFF;
			Model = 19735;
			ObjectClass = 2;
			SubClass = 4;
			Level = 44;
			ReqLevel = 39;
			Name = "Hand of Righteousness";
			Name2 = "Hand of Righteousness";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89611;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 7681 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 56 , 105 , Resistances.Armor );
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Fight Club)
*
***************************************************************/

namespace Server.Items
{
	public class FightClub : Item
	{
		public FightClub() : base()
		{
			Id = 7736;
			Bonding = 2;
			SellPrice = 11970;
			AvailableClasses = 0x7FFF;
			Model = 5224;
			ObjectClass = 2;
			SubClass = 4;
			Level = 39;
			ReqLevel = 34;
			Name = "Fight Club";
			Name2 = "Fight Club";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59854;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 41 , 76 , Resistances.Armor );
			StaminaBonus = 6;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dreamslayer)
*
***************************************************************/

namespace Server.Items
{
	public class Dreamslayer : Item
	{
		public Dreamslayer() : base()
		{
			Id = 7752;
			Bonding = 2;
			SellPrice = 6902;
			AvailableClasses = 0x7FFF;
			Model = 19670;
			ObjectClass = 2;
			SubClass = 4;
			Level = 33;
			ReqLevel = 28;
			Name = "Dreamslayer";
			Name2 = "Dreamslayer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34514;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 31 , 59 , Resistances.Armor );
			StrBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Big Black Mace)
*
***************************************************************/

namespace Server.Items
{
	public class BigBlackMace : Item
	{
		public BigBlackMace() : base()
		{
			Id = 7945;
			Bonding = 2;
			SellPrice = 17291;
			AvailableClasses = 0x7FFF;
			Model = 5223;
			ObjectClass = 2;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Big Black Mace";
			Name2 = "Big Black Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86455;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 46 , 86 , Resistances.Armor );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Runed Mithril Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class RunedMithrilHammer : Item
	{
		public RunedMithrilHammer() : base()
		{
			Id = 7946;
			Bonding = 2;
			SellPrice = 21660;
			AvailableClasses = 0x7FFF;
			Model = 15887;
			ObjectClass = 2;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Runed Mithril Hammer";
			Name2 = "Runed Mithril Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 108304;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 41 , 76 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(The Shatterer)
*
***************************************************************/

namespace Server.Items
{
	public class TheShatterer : Item
	{
		public TheShatterer() : base()
		{
			Id = 7954;
			Bonding = 2;
			SellPrice = 23159;
			AvailableClasses = 0x7FFF;
			Model = 19748;
			ObjectClass = 2;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "The Shatterer";
			Name2 = "The Shatterer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 115799;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13534 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 53 , 99 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Goblin Nutcracker)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinNutcracker : Item
	{
		public GoblinNutcracker() : base()
		{
			Id = 8194;
			Bonding = 2;
			SellPrice = 13877;
			AvailableClasses = 0x7FFF;
			Model = 19721;
			ObjectClass = 2;
			SubClass = 4;
			Level = 43;
			ReqLevel = 38;
			Name = "Goblin Nutcracker";
			Name2 = "Goblin Nutcracker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5251;
			BuyPrice = 69388;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 38 , 72 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hammer of Expertise)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfExpertise : Item
	{
		public HammerOfExpertise() : base()
		{
			Id = 8708;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17788;
			ObjectClass = 2;
			SubClass = 4;
			Level = 50;
			ReqLevel = 40;
			Name = "Hammer of Expertise";
			Name2 = "Hammer of Expertise";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetDamage( 54 , 101 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wirt's Third Leg)
*
***************************************************************/

namespace Server.Items
{
	public class WirtsThirdLeg : Item
	{
		public WirtsThirdLeg() : base()
		{
			Id = 9359;
			Bonding = 2;
			SellPrice = 19577;
			AvailableClasses = 0x7FFF;
			Model = 19756;
			ObjectClass = 2;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Wirt's Third Leg";
			Name2 = "Wirt's Third Leg";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 97888;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 49 , 91 , Resistances.Armor );
			AgilityBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Excavator's Brand)
*
***************************************************************/

namespace Server.Items
{
	public class ExcavatorsBrand : Item
	{
		public ExcavatorsBrand() : base()
		{
			Id = 9386;
			Bonding = 2;
			SellPrice = 9859;
			AvailableClasses = 0x7FFF;
			Model = 18268;
			ObjectClass = 2;
			SubClass = 4;
			Level = 36;
			ReqLevel = 31;
			Name = "Excavator's Brand";
			Name2 = "Excavator's Brand";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49296;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 7;
			Durability = 90;
			SetSpell( 13438 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 43 , 82 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Galgann's Firehammer)
*
***************************************************************/

namespace Server.Items
{
	public class GalgannsFirehammer : Item
	{
		public GalgannsFirehammer() : base()
		{
			Id = 9419;
			Bonding = 1;
			SellPrice = 18076;
			AvailableClasses = 0x7FFF;
			Model = 18312;
			ObjectClass = 2;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Galgann's Firehammer";
			Name2 = "Galgann's Firehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 90384;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18083 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 79 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonevault Bonebreaker)
*
***************************************************************/

namespace Server.Items
{
	public class StonevaultBonebreaker : Item
	{
		public StonevaultBonebreaker() : base()
		{
			Id = 9427;
			Bonding = 2;
			SellPrice = 14853;
			AvailableClasses = 0x7FFF;
			Model = 22051;
			ObjectClass = 2;
			SubClass = 4;
			Level = 42;
			ReqLevel = 37;
			Name = "Stonevault Bonebreaker";
			Name2 = "Stonevault Bonebreaker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 74265;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 54 , 101 , Resistances.Armor );
			StrBonus = 8;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Royal Diplomatic Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalDiplomaticScepter : Item
	{
		public RoyalDiplomaticScepter() : base()
		{
			Id = 9457;
			Bonding = 1;
			SellPrice = 8902;
			AvailableClasses = 0x7FFF;
			Model = 18373;
			ObjectClass = 2;
			SubClass = 4;
			Level = 35;
			ReqLevel = 30;
			Name = "Royal Diplomatic Scepter";
			Name2 = "Royal Diplomatic Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44510;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 37 , 69 , Resistances.Armor );
			IqBonus = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Oscillating Power Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class OscillatingPowerHammer : Item
	{
		public OscillatingPowerHammer() : base()
		{
			Id = 9488;
			Bonding = 2;
			SellPrice = 4419;
			AvailableClasses = 0x7FFF;
			Model = 18406;
			ObjectClass = 2;
			SubClass = 4;
			Level = 28;
			ReqLevel = 23;
			Name = "Oscillating Power Hammer";
			Name2 = "Oscillating Power Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22096;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 80;
			SetDamage( 24 , 46 , Resistances.Armor );
			StrBonus = 5;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(The Hand of Antu'sul)
*
***************************************************************/

namespace Server.Items
{
	public class TheHandOfAntusul : Item
	{
		public TheHandOfAntusul() : base()
		{
			Id = 9639;
			Bonding = 1;
			SellPrice = 24111;
			AvailableClasses = 0x7FFF;
			Model = 18572;
			ObjectClass = 2;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "The Hand of Antu'sul";
			Name2 = "The Hand of Antu'sul";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 120556;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13532 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 61 , 113 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gryphon Rider's Stormhammer)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonRidersStormhammer : Item
	{
		public GryphonRidersStormhammer() : base()
		{
			Id = 9651;
			Bonding = 1;
			SellPrice = 26828;
			AvailableClasses = 0x7FFF;
			Model = 18578;
			ObjectClass = 2;
			SubClass = 4;
			Level = 53;
			Name = "Gryphon Rider's Stormhammer";
			Name2 = "Gryphon Rider's Stormhammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 134140;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18081 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 59 , 111 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spirit of the Faerie Dragon)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritOfTheFaerieDragon : Item
	{
		public SpiritOfTheFaerieDragon() : base()
		{
			Id = 9686;
			Bonding = 1;
			SellPrice = 25914;
			AvailableClasses = 0x7FFF;
			Model = 19746;
			ObjectClass = 2;
			SubClass = 4;
			Level = 51;
			Name = "Spirit of the Faerie Dragon";
			Name2 = "Spirit of the Faerie Dragon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 129573;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 55 , 103 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Thistlewood Maul)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodMaul : Item
	{
		public ThistlewoodMaul() : base()
		{
			Id = 10544;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 19782;
			ObjectClass = 2;
			SubClass = 4;
			Level = 5;
			Name = "Thistlewood Maul";
			Name2 = "Thistlewood Maul";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 127;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 30;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ebony Boneclub)
*
***************************************************************/

namespace Server.Items
{
	public class EbonyBoneclub : Item
	{
		public EbonyBoneclub() : base()
		{
			Id = 10571;
			Bonding = 2;
			SellPrice = 10927;
			AvailableClasses = 0x7FFF;
			Model = 19501;
			ObjectClass = 2;
			SubClass = 4;
			Level = 37;
			ReqLevel = 32;
			Name = "Ebony Boneclub";
			Name2 = "Ebony Boneclub";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54635;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 31 , 59 , Resistances.Armor );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fist of the Damned)
*
***************************************************************/

namespace Server.Items
{
	public class FistOfTheDamned : Item
	{
		public FistOfTheDamned() : base()
		{
			Id = 10804;
			Bonding = 1;
			SellPrice = 29551;
			AvailableClasses = 0x7FFF;
			Model = 19892;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Fist of the Damned";
			Name2 = "Fist of the Damned";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 147758;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18084 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Might of Hakkar)
*
***************************************************************/

namespace Server.Items
{
	public class MightOfHakkar : Item
	{
		public MightOfHakkar() : base()
		{
			Id = 10838;
			Bonding = 1;
			SellPrice = 34665;
			AvailableClasses = 0x7FFF;
			Model = 19869;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Might of Hakkar";
			Name2 = "Might of Hakkar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 173325;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 60 , 112 , Resistances.Armor );
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Belgrom's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BelgromsHammer : Item
	{
		public BelgromsHammer() : base()
		{
			Id = 11120;
			Bonding = 1;
			SellPrice = 30144;
			AvailableClasses = 0x7FFF;
			Model = 28262;
			ObjectClass = 2;
			SubClass = 4;
			Level = 55;
			Name = "Belgrom's Hammer";
			Name2 = "Belgrom's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 150720;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 64 , 120 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Large Bear Bone)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBearBone : Item
	{
		public LargeBearBone() : base()
		{
			Id = 11411;
			SellPrice = 1484;
			AvailableClasses = 0x7FFF;
			Model = 6569;
			ObjectClass = 2;
			SubClass = 4;
			Level = 28;
			ReqLevel = 23;
			Name = "Large Bear Bone";
			Name2 = "Large Bear Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 7420;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 70;
			SetDamage( 14 , 28 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ironfoe)
*
***************************************************************/

namespace Server.Items
{
	public class Ironfoe : Item
	{
		public Ironfoe() : base()
		{
			Id = 11684;
			Bonding = 1;
			SellPrice = 63086;
			AvailableClasses = 0x7FFF;
			Model = 23618;
			ObjectClass = 2;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Ironfoe";
			Name2 = "Ironfoe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 315430;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 15494 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 136 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rubidium Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class RubidiumHammer : Item
	{
		public RubidiumHammer() : base()
		{
			Id = 11805;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 40439;
			AvailableClasses = 0x7FFF;
			Model = 28821;
			ObjectClass = 2;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Rubidium Hammer";
			Name2 = "Rubidium Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 202196;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 51 , 96 , Resistances.Armor );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Beastsmasher)
*
***************************************************************/

namespace Server.Items
{
	public class Beastsmasher : Item
	{
		public Beastsmasher() : base()
		{
			Id = 11906;
			Bonding = 1;
			SellPrice = 32723;
			AvailableClasses = 0x7FFF;
			Model = 28075;
			ObjectClass = 2;
			SubClass = 4;
			Level = 55;
			Name = "Beastsmasher";
			Name2 = "Beastsmasher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 163615;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 14565 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 48 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Hammer of Grace)
*
***************************************************************/

namespace Server.Items
{
	public class TheHammerOfGrace : Item
	{
		public TheHammerOfGrace() : base()
		{
			Id = 11923;
			Bonding = 1;
			SellPrice = 43648;
			AvailableClasses = 0x7FFF;
			Model = 21956;
			ObjectClass = 2;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "The Hammer of Grace";
			Name2 = "The Hammer of Grace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 218244;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9317 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 71 , 132 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Swiftstrike Cudgel)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftstrikeCudgel : Item
	{
		public SwiftstrikeCudgel() : base()
		{
			Id = 11964;
			Bonding = 1;
			SellPrice = 30156;
			AvailableClasses = 0x7FFF;
			Model = 28203;
			ObjectClass = 2;
			SubClass = 4;
			Level = 55;
			Name = "Swiftstrike Cudgel";
			Name2 = "Swiftstrike Cudgel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 150783;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 15464 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 36 , 68 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Serenity)
*
***************************************************************/

namespace Server.Items
{
	public class Serenity : Item
	{
		public Serenity() : base()
		{
			Id = 12781;
			Bonding = 2;
			SellPrice = 42721;
			AvailableClasses = 0x7FFF;
			Model = 23244;
			ObjectClass = 2;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Serenity";
			Name2 = "Serenity";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 213605;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16908 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 52 , 98 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Volcanic Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class VolcanicHammer : Item
	{
		public VolcanicHammer() : base()
		{
			Id = 12792;
			Bonding = 2;
			SellPrice = 39255;
			AvailableClasses = 0x7FFF;
			Model = 23267;
			ObjectClass = 2;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Volcanic Hammer";
			Name2 = "Volcanic Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 196279;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18082 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 60 , 113 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Masterwork Stormhammer)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkStormhammer : Item
	{
		public MasterworkStormhammer() : base()
		{
			Id = 12794;
			Bonding = 2;
			SellPrice = 56304;
			AvailableClasses = 0x7FFF;
			Model = 7438;
			ObjectClass = 2;
			SubClass = 4;
			Level = 63;
			ReqLevel = 57;
			Name = "Masterwork Stormhammer";
			Name2 = "Masterwork Stormhammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 281520;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16921 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 58 , 108 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mass of McGowan)
*
***************************************************************/

namespace Server.Items
{
	public class MassOfMcGowan : Item
	{
		public MassOfMcGowan() : base()
		{
			Id = 13006;
			Bonding = 2;
			SellPrice = 54840;
			AvailableClasses = 0x7FFF;
			Model = 28799;
			ObjectClass = 2;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Mass of McGowan";
			Name2 = "Mass of McGowan";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274202;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 80 , 149 , Resistances.Armor );
			StrBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Beazel's Basher)
*
***************************************************************/

namespace Server.Items
{
	public class BeazelsBasher : Item
	{
		public BeazelsBasher() : base()
		{
			Id = 13024;
			Bonding = 2;
			SellPrice = 4863;
			AvailableClasses = 0x7FFF;
			Model = 28671;
			ObjectClass = 2;
			SubClass = 4;
			Level = 29;
			ReqLevel = 24;
			Name = "Beazel's Basher";
			Name2 = "Beazel's Basher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24319;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 32 , 60 , Resistances.Armor );
			StrBonus = 6;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Deadwood Sledge)
*
***************************************************************/

namespace Server.Items
{
	public class DeadwoodSledge : Item
	{
		public DeadwoodSledge() : base()
		{
			Id = 13025;
			Bonding = 2;
			SellPrice = 10464;
			AvailableClasses = 0x7FFF;
			Model = 28706;
			ObjectClass = 2;
			SubClass = 4;
			Level = 37;
			ReqLevel = 32;
			Name = "Deadwood Sledge";
			Name2 = "Deadwood Sledge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52324;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 33 , 62 , Resistances.Armor );
			StaminaBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Heaven's Light)
*
***************************************************************/

namespace Server.Items
{
	public class HeavensLight : Item
	{
		public HeavensLight() : base()
		{
			Id = 13026;
			Bonding = 2;
			SellPrice = 19441;
			AvailableClasses = 0x7FFF;
			Model = 28776;
			ObjectClass = 2;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Heaven's Light";
			Name2 = "Heaven's Light";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 97208;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 57 , 107 , Resistances.Armor );
			StrBonus = 4;
			AgilityBonus = 4;
			IqBonus = 5;
			SpiritBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bonesnapper)
*
***************************************************************/

namespace Server.Items
{
	public class Bonesnapper : Item
	{
		public Bonesnapper() : base()
		{
			Id = 13027;
			Bonding = 2;
			SellPrice = 33832;
			AvailableClasses = 0x7FFF;
			Model = 28689;
			ObjectClass = 2;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Bonesnapper";
			Name2 = "Bonesnapper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 169160;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 66 , 124 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bludstone Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BludstoneHammer : Item
	{
		public BludstoneHammer() : base()
		{
			Id = 13028;
			Bonding = 2;
			SellPrice = 52605;
			AvailableClasses = 0x7FFF;
			Model = 28681;
			ObjectClass = 2;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Bludstone Hammer";
			Name2 = "Bludstone Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 263025;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 59 , 110 , Resistances.Armor );
			IqBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Looming Gavel)
*
***************************************************************/

namespace Server.Items
{
	public class LoomingGavel : Item
	{
		public LoomingGavel() : base()
		{
			Id = 13048;
			Bonding = 2;
			SellPrice = 5971;
			AvailableClasses = 0x7FFF;
			Model = 25623;
			ObjectClass = 2;
			SubClass = 4;
			Level = 31;
			ReqLevel = 26;
			Name = "Looming Gavel";
			Name2 = "Looming Gavel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29858;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 33 , 62 , Resistances.Armor );
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Venomspitter)
*
***************************************************************/

namespace Server.Items
{
	public class Venomspitter : Item
	{
		public Venomspitter() : base()
		{
			Id = 13183;
			Bonding = 1;
			SellPrice = 51771;
			AvailableClasses = 0x7FFF;
			Model = 24740;
			ObjectClass = 2;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Venomspitter";
			Name2 = "Venomspitter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 258857;
			Sets = 65;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18203 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 52 , 98 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bashguuder)
*
***************************************************************/

namespace Server.Items
{
	public class Bashguuder : Item
	{
		public Bashguuder() : base()
		{
			Id = 13204;
			Bonding = 1;
			SellPrice = 39263;
			AvailableClasses = 0x7FFF;
			Model = 25619;
			ObjectClass = 2;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Bashguuder";
			Name2 = "Bashguuder";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 196316;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 17315 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 65 , 122 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Scepter of the Unholy)
*
***************************************************************/

namespace Server.Items
{
	public class ScepterOfTheUnholy : Item
	{
		public ScepterOfTheUnholy() : base()
		{
			Id = 13349;
			Bonding = 1;
			SellPrice = 58428;
			AvailableClasses = 0x7FFF;
			Model = 24033;
			ObjectClass = 2;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Scepter of the Unholy";
			Name2 = "Scepter of the Unholy";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 292144;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 14794 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 69 , 129 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(The Cruel Hand of Timmy)
*
***************************************************************/

namespace Server.Items
{
	public class TheCruelHandOfTimmy : Item
	{
		public TheCruelHandOfTimmy() : base()
		{
			Id = 13401;
			Bonding = 1;
			SellPrice = 51440;
			AvailableClasses = 0x7FFF;
			Model = 24111;
			ObjectClass = 2;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "The Cruel Hand of Timmy";
			Name2 = "The Cruel Hand of Timmy";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 257201;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 17505 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Clout Mace)
*
***************************************************************/

namespace Server.Items
{
	public class CloutMace : Item
	{
		public CloutMace() : base()
		{
			Id = 13820;
			SellPrice = 12042;
			AvailableClasses = 0x7FFF;
			Model = 19716;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Clout Mace";
			Name2 = "Clout Mace";
			AvailableRaces = 0x1FF;
			BuyPrice = 60211;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bonechill Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BonechillHammer : Item
	{
		public BonechillHammer() : base()
		{
			Id = 14487;
			Bonding = 1;
			SellPrice = 53222;
			AvailableClasses = 0x7FFF;
			Model = 25096;
			ObjectClass = 2;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Bonechill Hammer";
			Name2 = "Bonechill Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 266113;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18276 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 68 , 127 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Barbed Club)
*
***************************************************************/

namespace Server.Items
{
	public class BarbedClub : Item
	{
		public BarbedClub() : base()
		{
			Id = 15222;
			Bonding = 2;
			SellPrice = 1219;
			AvailableClasses = 0x7FFF;
			Model = 28314;
			ObjectClass = 2;
			SubClass = 4;
			Level = 19;
			ReqLevel = 14;
			Name = "Barbed Club";
			Name2 = "Barbed Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5188;
			BuyPrice = 6096;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 55;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jagged Star)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedStar : Item
	{
		public JaggedStar() : base()
		{
			Id = 15223;
			Bonding = 2;
			SellPrice = 2376;
			AvailableClasses = 0x7FFF;
			Model = 28571;
			ObjectClass = 2;
			SubClass = 4;
			Level = 24;
			ReqLevel = 19;
			Name = "Jagged Star";
			Name2 = "Jagged Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5197;
			BuyPrice = 11884;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battlesmasher)
*
***************************************************************/

namespace Server.Items
{
	public class Battlesmasher : Item
	{
		public Battlesmasher() : base()
		{
			Id = 15224;
			Bonding = 2;
			SellPrice = 2695;
			AvailableClasses = 0x7FFF;
			Model = 28318;
			ObjectClass = 2;
			SubClass = 4;
			Level = 25;
			ReqLevel = 20;
			Name = "Battlesmasher";
			Name2 = "Battlesmasher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5206;
			BuyPrice = 13479;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sequoia Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SequoiaHammer : Item
	{
		public SequoiaHammer() : base()
		{
			Id = 15225;
			Bonding = 2;
			SellPrice = 5958;
			AvailableClasses = 0x7FFF;
			Model = 28521;
			ObjectClass = 2;
			SubClass = 4;
			Level = 33;
			ReqLevel = 28;
			Name = "Sequoia Hammer";
			Name2 = "Sequoia Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5224;
			BuyPrice = 29793;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 32 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Giant Club)
*
***************************************************************/

namespace Server.Items
{
	public class GiantClub : Item
	{
		public GiantClub() : base()
		{
			Id = 15226;
			Bonding = 2;
			SellPrice = 8755;
			AvailableClasses = 0x7FFF;
			Model = 28531;
			ObjectClass = 2;
			SubClass = 4;
			Level = 37;
			ReqLevel = 32;
			Name = "Giant Club";
			Name2 = "Giant Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5242;
			BuyPrice = 43778;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 26 , 49 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Diamond-Tip Bludgeon)
*
***************************************************************/

namespace Server.Items
{
	public class DiamondTipBludgeon : Item
	{
		public DiamondTipBludgeon() : base()
		{
			Id = 15227;
			Bonding = 2;
			SellPrice = 21925;
			AvailableClasses = 0x7FFF;
			Model = 28508;
			ObjectClass = 2;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Diamond-Tip Bludgeon";
			Name2 = "Diamond-Tip Bludgeon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5278;
			BuyPrice = 109625;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 49 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Smashing Star)
*
***************************************************************/

namespace Server.Items
{
	public class SmashingStar : Item
	{
		public SmashingStar() : base()
		{
			Id = 15228;
			Bonding = 2;
			SellPrice = 28308;
			AvailableClasses = 0x7FFF;
			Model = 28512;
			ObjectClass = 2;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Smashing Star";
			Name2 = "Smashing Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5287;
			BuyPrice = 141543;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 62 , 115 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blesswind Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BlesswindHammer : Item
	{
		public BlesswindHammer() : base()
		{
			Id = 15229;
			Bonding = 2;
			SellPrice = 31924;
			AvailableClasses = 0x7FFF;
			Model = 19735;
			ObjectClass = 2;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Blesswind Hammer";
			Name2 = "Blesswind Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5296;
			BuyPrice = 159622;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 48 , 90 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hammer of Orgrimmar)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfOrgrimmar : Item
	{
		public HammerOfOrgrimmar() : base()
		{
			Id = 15445;
			Bonding = 1;
			SellPrice = 1127;
			AvailableClasses = 0x7FFF;
			Model = 28191;
			ObjectClass = 2;
			SubClass = 4;
			Level = 18;
			Name = "Hammer of Orgrimmar";
			Name2 = "Hammer of Orgrimmar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5637;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
			StrBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Grave Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class GraveScepter : Item
	{
		public GraveScepter() : base()
		{
			Id = 15863;
			Bonding = 1;
			SellPrice = 28896;
			AvailableClasses = 0x7FFF;
			Model = 5207;
			ObjectClass = 2;
			SubClass = 4;
			Level = 54;
			Name = "Grave Scepter";
			Name2 = "Grave Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 144482;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 36 , 67 , Resistances.Armor );
			SpiritBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Furbolg Medicine Totem)
*
***************************************************************/

namespace Server.Items
{
	public class FurbolgMedicineTotem : Item
	{
		public FurbolgMedicineTotem() : base()
		{
			Id = 16769;
			Bonding = 1;
			SellPrice = 26616;
			AvailableClasses = 0x7FFF;
			Model = 28194;
			ObjectClass = 2;
			SubClass = 4;
			Level = 52;
			Name = "Furbolg Medicine Totem";
			Name2 = "Furbolg Medicine Totem";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 133081;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 54 , 101 , Resistances.Armor );
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Skullstone Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SkullstoneHammer : Item
	{
		public SkullstoneHammer() : base()
		{
			Id = 17003;
			Bonding = 1;
			SellPrice = 44982;
			AvailableClasses = 0x7FFF;
			Model = 28835;
			ObjectClass = 2;
			SubClass = 4;
			Level = 61;
			Name = "Skullstone Hammer";
			Name2 = "Skullstone Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 224911;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 68 , 128 , Resistances.Armor );
			SpiritBonus = 9;
			StaminaBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Skullbreaker)
*
***************************************************************/

namespace Server.Items
{
	public class Skullbreaker : Item
	{
		public Skullbreaker() : base()
		{
			Id = 17039;
			Bonding = 1;
			SellPrice = 8317;
			AvailableClasses = 0x7FFF;
			Model = 28869;
			ObjectClass = 2;
			SubClass = 4;
			Level = 36;
			Name = "Skullbreaker";
			Name2 = "Skullbreaker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41585;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 59 , Resistances.Armor );
			SpiritBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Changuk Smasher)
*
***************************************************************/

namespace Server.Items
{
	public class ChangukSmasher : Item
	{
		public ChangukSmasher() : base()
		{
			Id = 17055;
			Bonding = 2;
			SellPrice = 26747;
			AvailableClasses = 0x7FFF;
			Model = 15887;
			ObjectClass = 2;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Changuk Smasher";
			Name2 = "Changuk Smasher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 133735;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetDamage( 44 , 83 , Resistances.Armor );
			StaminaBonus = 6;
			SpiritBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Aurastone Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class AurastoneHammer : Item
	{
		public AurastoneHammer() : base()
		{
			Id = 17105;
			Bonding = 1;
			SellPrice = 102178;
			AvailableClasses = 0x7FFF;
			Model = 29714;
			ObjectClass = 2;
			SubClass = 4;
			Level = 69;
			ReqLevel = 60;
			Name = "Aurastone Hammer";
			Name2 = "Aurastone Hammer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 510891;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15715 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 78 , 161 , Resistances.Armor );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Empyrean Demolisher)
*
***************************************************************/

namespace Server.Items
{
	public class EmpyreanDemolisher : Item
	{
		public EmpyreanDemolisher() : base()
		{
			Id = 17112;
			Bonding = 1;
			SellPrice = 90558;
			AvailableClasses = 0x7FFF;
			Model = 29171;
			ObjectClass = 2;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Empyrean Demolisher";
			Name2 = "Empyrean Demolisher";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 452792;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			SetSpell( 21165 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 94 , 175 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fist of Stone)
*
***************************************************************/

namespace Server.Items
{
	public class FistOfStone : Item
	{
		public FistOfStone() : base()
		{
			Id = 17733;
			Bonding = 1;
			SellPrice = 34735;
			AvailableClasses = 0x7FFF;
			Model = 29910;
			ObjectClass = 2;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Fist of Stone";
			Name2 = "Fist of Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 173678;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			Flags = 16;
			SetSpell( 21951 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 44 , 83 , Resistances.Armor );
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fist of Stone)
*
***************************************************************/

namespace Server.Items
{
	public class FistOfStone17943 : Item
	{
		public FistOfStone17943() : base()
		{
			Id = 17943;
			Bonding = 1;
			SellPrice = 32156;
			AvailableClasses = 0x7FFF;
			Model = 29910;
			ObjectClass = 2;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Fist of Stone";
			Name2 = "Fist of Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160783;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 21951 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 44 , 83 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hurley's Tankard)
*
***************************************************************/

namespace Server.Items
{
	public class HurleysTankard : Item
	{
		public HurleysTankard() : base()
		{
			Id = 18044;
			Bonding = 1;
			SellPrice = 33830;
			AvailableClasses = 0x7FFF;
			Model = 30436;
			ObjectClass = 2;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Hurley's Tankard";
			Name2 = "Hurley's Tankard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 169154;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			Durability = 75;
			SetDamage( 42 , 80 , Resistances.Armor );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Mastersmith's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class MastersmithsHammer : Item
	{
		public MastersmithsHammer() : base()
		{
			Id = 18048;
			Bonding = 1;
			SellPrice = 43589;
			AvailableClasses = 0x7FFF;
			Model = 30440;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Mastersmith's Hammer";
			Name2 = "Mastersmith's Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 217945;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetSpell( 7688 , 1 , 0 , 0 , 0 , -1 );
			SetDamage( 62 , 116 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Energetic Rod)
*
***************************************************************/

namespace Server.Items
{
	public class EnergeticRod : Item
	{
		public EnergeticRod() : base()
		{
			Id = 18321;
			Bonding = 1;
			SellPrice = 49320;
			AvailableClasses = 0x7FFF;
			Model = 30915;
			ObjectClass = 2;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Energetic Rod";
			Name2 = "Energetic Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 246601;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 71 , 107 , Resistances.Armor );
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Timeworn Mace)
*
***************************************************************/

namespace Server.Items
{
	public class TimewornMace : Item
	{
		public TimewornMace() : base()
		{
			Id = 18376;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 52306;
			AvailableClasses = 0x7FFF;
			Model = 30728;
			ObjectClass = 2;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Timeworn Mace";
			Name2 = "Timeworn Mace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 261534;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 62 , 117 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Baron Charr's Sceptre)
*
***************************************************************/

namespace Server.Items
{
	public class BaronCharrsSceptre : Item
	{
		public BaronCharrsSceptre() : base()
		{
			Id = 18671;
			Bonding = 2;
			SellPrice = 45184;
			AvailableClasses = 0x7FFF;
			Model = 31119;
			ObjectClass = 2;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Baron Charr's Sceptre";
			Name2 = "Baron Charr's Sceptre";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 225923;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13442 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 70 , 132 , Resistances.Armor );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Hammer of the Vesper)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfTheVesper : Item
	{
		public HammerOfTheVesper() : base()
		{
			Id = 18683;
			Bonding = 1;
			SellPrice = 51100;
			AvailableClasses = 0x7FFF;
			Model = 31126;
			ObjectClass = 2;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Hammer of the Vesper";
			Name2 = "Hammer of the Vesper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 255504;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 70 , 131 , Resistances.Armor );
			StaminaBonus = 12;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Punisher)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsPunisher : Item
	{
		public GrandMarshalsPunisher() : base()
		{
			Id = 18865;
			Bonding = 1;
			SellPrice = 49684;
			AvailableClasses = 0x7FFF;
			Model = 31955;
			ObjectClass = 2;
			SubClass = 4;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Punisher";
			Name2 = "Grand Marshal's Punisher";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 248422;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Bludgeon)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsBludgeon : Item
	{
		public HighWarlordsBludgeon() : base()
		{
			Id = 18866;
			Bonding = 1;
			SellPrice = 49861;
			AvailableClasses = 0x7FFF;
			Model = 31751;
			ObjectClass = 2;
			SubClass = 4;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Bludgeon";
			Name2 = "High Warlord's Bludgeon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 249308;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Stormstrike Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class StormstrikeHammer : Item
	{
		public StormstrikeHammer() : base()
		{
			Id = 19104;
			Bonding = 1;
			SellPrice = 64227;
			AvailableClasses = 0x7FFF;
			Model = 31612;
			ObjectClass = 2;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Stormstrike Hammer";
			Name2 = "Stormstrike Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 321137;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 80 , 150 , Resistances.Armor );
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Ebon Hand)
*
***************************************************************/

namespace Server.Items
{
	public class EbonHand : Item
	{
		public EbonHand() : base()
		{
			Id = 19170;
			Bonding = 2;
			SellPrice = 103689;
			AvailableClasses = 0x7FFF;
			Model = 31822;
			Resistance[2] = 7;
			ObjectClass = 2;
			SubClass = 4;
			Level = 70;
			ReqLevel = 60;
			Name = "Ebon Hand";
			Name2 = "Ebon Hand";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 518448;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18211 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 83 , 154 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Last Months Mutton)
*
***************************************************************/

namespace Server.Items
{
	public class LastMonthsMutton : Item
	{
		public LastMonthsMutton() : base()
		{
			Id = 19292;
			SellPrice = 4022;
			AvailableClasses = 0x7FFF;
			Model = 31777;
			ObjectClass = 2;
			SubClass = 4;
			Level = 34;
			ReqLevel = 29;
			Name = "Last Months Mutton";
			Name2 = "Last Months Mutton";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20113;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 29 , 54 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Last Years Mutton)
*
***************************************************************/

namespace Server.Items
{
	public class LastYearsMutton : Item
	{
		public LastYearsMutton() : base()
		{
			Id = 19293;
			SellPrice = 19376;
			AvailableClasses = 0x7FFF;
			Model = 7462;
			ObjectClass = 2;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Last Years Mutton";
			Name2 = "Last Years Mutton";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 96881;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			Durability = 75;
			SetDamage( 44 , 82 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spineshatter)
*
***************************************************************/

namespace Server.Items
{
	public class Spineshatter : Item
	{
		public Spineshatter() : base()
		{
			Id = 19335;
			Bonding = 1;
			SellPrice = 128825;
			AvailableClasses = 0x7FFF;
			Model = 31862;
			ObjectClass = 2;
			SubClass = 4;
			Level = 73;
			ReqLevel = 60;
			Name = "Spineshatter";
			Name2 = "Spineshatter";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 644128;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 7518 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 99 , 184 , Resistances.Armor );
			StaminaBonus = 16;
			StrBonus = 9;
		}
	}
}


