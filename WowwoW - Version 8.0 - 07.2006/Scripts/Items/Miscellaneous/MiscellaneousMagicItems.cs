/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:30 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Thunderbrew's Boot Flask)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderbrewsBootFlask : Item
	{
		public ThunderbrewsBootFlask() : base()
		{
			Id = 744;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 18059;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Thunderbrew's Boot Flask";
			Name2 = "Thunderbrew's Boot Flask";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 12257 , 0 , 0 , 1800000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Lifestone)
*
***************************************************************/

namespace Server.Items
{
	public class Lifestone : Item
	{
		public Lifestone() : base()
		{
			Id = 833;
			Bonding = 2;
			SellPrice = 28000;
			AvailableClasses = 0x7FFF;
			Model = 22978;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Lifestone";
			Name2 = "Lifestone";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 112000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 17712 , 0 , 0 , 1800000 , 30 , 180000 );
			SetSpell( 5707 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Runed Ring)
*
***************************************************************/

namespace Server.Items
{
	public class RunedRing : Item
	{
		public RunedRing() : base()
		{
			Id = 862;
			Bonding = 2;
			SellPrice = 38222;
			AvailableClasses = 0x7FFF;
			Model = 18397;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Runed Ring";
			Name2 = "Runed Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3253;
			BuyPrice = 152890;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			SetSpell( 9397 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Freezing Band)
*
***************************************************************/

namespace Server.Items
{
	public class FreezingBand : Item
	{
		public FreezingBand() : base()
		{
			Id = 942;
			Bonding = 2;
			SellPrice = 4500;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Freezing Band";
			Name2 = "Freezing Band";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 18000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 9308 , 1 , 0 , 0 , 0 , -1 );
			SetSpell( 18799 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Defias Renegade Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DefiasRenegadeRing : Item
	{
		public DefiasRenegadeRing() : base()
		{
			Id = 1076;
			Bonding = 2;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 6012;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Defias Renegade Ring";
			Name2 = "Defias Renegade Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2600;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Defias Mage Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DefiasMageRing : Item
	{
		public DefiasMageRing() : base()
		{
			Id = 1077;
			Bonding = 2;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Defias Mage Ring";
			Name2 = "Defias Mage Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SpiritBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ring of Pure Silver)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfPureSilver : Item
	{
		public RingOfPureSilver() : base()
		{
			Id = 1116;
			Bonding = 1;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 6011;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Ring of Pure Silver";
			Name2 = "Ring of Pure Silver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 1;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Totem of Infliction)
*
***************************************************************/

namespace Server.Items
{
	public class TotemOfInfliction : Item
	{
		public TotemOfInfliction() : base()
		{
			Id = 1131;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 1136;
			AvailableClasses = 0x7FFF;
			Model = 9557;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Totem of Infliction";
			Name2 = "Totem of Infliction";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4545;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Flags = 64;
			SetSpell( 7617 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Lavishly Jeweled Ring)
*
***************************************************************/

namespace Server.Items
{
	public class LavishlyJeweledRing : Item
	{
		public LavishlyJeweledRing() : base()
		{
			Id = 1156;
			Bonding = 1;
			SellPrice = 812;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Lavishly Jeweled Ring";
			Name2 = "Lavishly Jeweled Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3250;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			AgilityBonus = 2;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Grayson's Torch)
*
***************************************************************/

namespace Server.Items
{
	public class GraysonsTorch : Item
	{
		public GraysonsTorch() : base()
		{
			Id = 1172;
			Resistance[0] = 15;
			Bonding = 1;
			SellPrice = 968;
			AvailableClasses = 0x7FFF;
			Model = 12313;
			ObjectClass = 4;
			SubClass = 0;
			Level = 21;
			Name = "Grayson's Torch";
			Name2 = "Grayson's Torch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3875;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Overseer's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class OverseersRing : Item
	{
		public OverseersRing() : base()
		{
			Id = 1189;
			Bonding = 2;
			SellPrice = 625;
			AvailableClasses = 0x7FFF;
			Model = 963;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Overseer's Ring";
			Name2 = "Overseer's Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2500;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lesser Firestone)
*
***************************************************************/

namespace Server.Items
{
	public class LesserFirestone : Item
	{
		public LesserFirestone() : base()
		{
			Id = 1254;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24380;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			Name = "Lesser Firestone";
			Name2 = "Lesser Firestone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 758 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 23480 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Bind On Use Test Item)
*
***************************************************************/

namespace Server.Items
{
	public class BindOnUseTestItem : Item
	{
		public BindOnUseTestItem() : base()
		{
			Id = 1258;
			Bonding = 3;
			SellPrice = 1087;
			AvailableClasses = 0x7FFF;
			Model = 6511;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Bind On Use Test Item";
			Name2 = "Bind On Use Test Item";
			AvailableRaces = 0x1FF;
			BuyPrice = 4350;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			SetSpell( 133 , 0 , 0 , 30000 , 24 , 30000 );
		}
	}
}


/**************************************************************
*
*				(Lei of Lilies)
*
***************************************************************/

namespace Server.Items
{
	public class LeiOfLilies : Item
	{
		public LeiOfLilies() : base()
		{
			Id = 1315;
			Bonding = 2;
			SellPrice = 13000;
			AvailableClasses = 0x7FFF;
			Model = 6524;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Lei of Lilies";
			Name2 = "Lei of Lilies";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 52000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18831 , 0 , 0 , 3600000 , 94 , 60000 );
			StaminaBonus = 10;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Ring of Iron Will)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfIronWill : Item
	{
		public RingOfIronWill() : base()
		{
			Id = 1319;
			Bonding = 1;
			SellPrice = 462;
			AvailableClasses = 0x7FFF;
			Model = 14437;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Ring of Iron Will";
			Name2 = "Ring of Iron Will";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1850;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			Language = 7;
			StaminaBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Tidal Charm)
*
***************************************************************/

namespace Server.Items
{
	public class TidalCharm : Item
	{
		public TidalCharm() : base()
		{
			Id = 1404;
			Bonding = 1;
			SellPrice = 10306;
			AvailableClasses = 0x7FFF;
			Model = 6499;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Tidal Charm";
			Name2 = "Tidal Charm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41225;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 835 , 0 , 0 , 900000 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Jeweled Amulet of Cainwyn)
*
***************************************************************/

namespace Server.Items
{
	public class JeweledAmuletOfCainwyn : Item
	{
		public JeweledAmuletOfCainwyn() : base()
		{
			Id = 1443;
			Bonding = 2;
			SellPrice = 21125;
			AvailableClasses = 0x7FFF;
			Model = 6522;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Jeweled Amulet of Cainwyn";
			Name2 = "Jeweled Amulet of Cainwyn";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 84500;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 18;
			IqBonus = 10;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ring of Saviors)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfSaviors : Item
	{
		public RingOfSaviors() : base()
		{
			Id = 1447;
			Bonding = 2;
			SellPrice = 22775;
			AvailableClasses = 0x7FFF;
			Model = 14438;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Ring of Saviors";
			Name2 = "Ring of Saviors";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 91100;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			SetSpell( 18826 , 0 , 0 , 1800000 , 28 , 300000 );
			StaminaBonus = 14;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Minor Channeling Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MinorChannelingRing : Item
	{
		public MinorChannelingRing() : base()
		{
			Id = 1449;
			Bonding = 1;
			SellPrice = 1875;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 24;
			Name = "Minor Channeling Ring";
			Name2 = "Minor Channeling Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7500;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SpiritBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ring of the Shadow)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheShadow : Item
	{
		public RingOfTheShadow() : base()
		{
			Id = 1462;
			Bonding = 2;
			SellPrice = 1306;
			AvailableClasses = 0x7FFF;
			Model = 9846;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Ring of the Shadow";
			Name2 = "Ring of the Shadow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5225;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
		}
	}
}


/**************************************************************
*
*				(Guardian Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianTalisman : Item
	{
		public GuardianTalisman() : base()
		{
			Id = 1490;
			Bonding = 1;
			SellPrice = 8910;
			AvailableClasses = 0x7FFF;
			Model = 6502;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Guardian Talisman";
			Name2 = "Guardian Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35640;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 4070 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ring of Precision)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfPrecision : Item
	{
		public RingOfPrecision() : base()
		{
			Id = 1491;
			Bonding = 2;
			SellPrice = 2207;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Ring of Precision";
			Name2 = "Ring of Precision";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8830;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			AgilityBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ankh of Life)
*
***************************************************************/

namespace Server.Items
{
	public class AnkhOfLife : Item
	{
		public AnkhOfLife() : base()
		{
			Id = 1713;
			Bonding = 2;
			SellPrice = 5350;
			AvailableClasses = 0x7FFF;
			Model = 23949;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Ankh of Life";
			Name2 = "Ankh of Life";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21400;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 1;
			SetSpell( 14053 , 0 , 0 , 300000 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Necklace of Calisea)
*
***************************************************************/

namespace Server.Items
{
	public class NecklaceOfCalisea : Item
	{
		public NecklaceOfCalisea() : base()
		{
			Id = 1714;
			Bonding = 2;
			SellPrice = 2535;
			AvailableClasses = 0x7FFF;
			Model = 9858;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Necklace of Calisea";
			Name2 = "Necklace of Calisea";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10140;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			SpiritBonus = 7;
			IqBonus = 7;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Orb of Deception)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfDeception : Item
	{
		public OrbOfDeception() : base()
		{
			Id = 1973;
			Bonding = 2;
			SellPrice = 4618;
			AvailableClasses = 0x7FFF;
			Model = 6506;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Orb of Deception";
			Name2 = "Orb of Deception";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18475;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 3;
			SetSpell( 16739 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Underworld Band)
*
***************************************************************/

namespace Server.Items
{
	public class UnderworldBand : Item
	{
		public UnderworldBand() : base()
		{
			Id = 1980;
			Bonding = 2;
			SellPrice = 6200;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Underworld Band";
			Name2 = "Underworld Band";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 24800;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			SetSpell( 9414 , 1 , 0 , 0 , 0 , 0 );
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Swampchill Fetish)
*
***************************************************************/

namespace Server.Items
{
	public class SwampchillFetish : Item
	{
		public SwampchillFetish() : base()
		{
			Id = 1992;
			Bonding = 2;
			SellPrice = 5468;
			AvailableClasses = 0x7FFF;
			Model = 21612;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Swampchill Fetish";
			Name2 = "Swampchill Fetish";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27340;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			SetSpell( 9402 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 9412 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Ogremind Ring)
*
***************************************************************/

namespace Server.Items
{
	public class OgremindRing : Item
	{
		public OgremindRing() : base()
		{
			Id = 1993;
			Bonding = 2;
			SellPrice = 2100;
			AvailableClasses = 0x7FFF;
			Model = 14436;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Ogremind Ring";
			Name2 = "Ogremind Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8400;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			SpiritBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Voodoo Band)
*
***************************************************************/

namespace Server.Items
{
	public class VoodooBand : Item
	{
		public VoodooBand() : base()
		{
			Id = 1996;
			Bonding = 2;
			SellPrice = 1720;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Voodoo Band";
			Name2 = "Voodoo Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6880;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Plains Ring)
*
***************************************************************/

namespace Server.Items
{
	public class PlainsRing : Item
	{
		public PlainsRing() : base()
		{
			Id = 2039;
			Bonding = 2;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 6012;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Plains Ring";
			Name2 = "Plains Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			StaminaBonus = 8;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ring of Forlorn Spirits)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfForlornSpirits : Item
	{
		public RingOfForlornSpirits() : base()
		{
			Id = 2043;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 6011;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Ring of Forlorn Spirits";
			Name2 = "Ring of Forlorn Spirits";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			StaminaBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Signet)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsSignet : Item
	{
		public MyrmidonsSignet() : base()
		{
			Id = 2246;
			Bonding = 2;
			SellPrice = 30000;
			AvailableClasses = 0x7FFF;
			Model = 9841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Myrmidon's Signet";
			Name2 = "Myrmidon's Signet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 120000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			StaminaBonus = 17;
			StrBonus = 10;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Mark of Kern)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfKern : Item
	{
		public MarkOfKern() : base()
		{
			Id = 2262;
			Bonding = 2;
			SellPrice = 8746;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Mark of Kern";
			Name2 = "Mark of Kern";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34985;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 9331 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Smoky Torch)
*
***************************************************************/

namespace Server.Items
{
	public class SmokyTorch : Item
	{
		public SmokyTorch() : base()
		{
			Id = 2410;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12312;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Smoky Torch";
			Name2 = "Smoky Torch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Bouquet of Scarlet Begonias)
*
***************************************************************/

namespace Server.Items
{
	public class BouquetOfScarletBegonias : Item
	{
		public BouquetOfScarletBegonias() : base()
		{
			Id = 2562;
			Bonding = 1;
			SellPrice = 575;
			AvailableClasses = 0x7FFF;
			Model = 6488;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			Name = "Bouquet of Scarlet Begonias";
			Name2 = "Bouquet of Scarlet Begonias";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2300;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rod of Molten Fire)
*
***************************************************************/

namespace Server.Items
{
	public class RodOfMoltenFire : Item
	{
		public RodOfMoltenFire() : base()
		{
			Id = 2565;
			Bonding = 2;
			SellPrice = 3113;
			AvailableClasses = 0x7FFF;
			Model = 6555;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Rod of Molten Fire";
			Name2 = "Rod of Molten Fire";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12453;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			SetSpell( 9400 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Blazing Emblem)
*
***************************************************************/

namespace Server.Items
{
	public class BlazingEmblem : Item
	{
		public BlazingEmblem() : base()
		{
			Id = 2802;
			Bonding = 2;
			SellPrice = 1625;
			AvailableClasses = 0x7FFF;
			Model = 6484;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Blazing Emblem";
			Name2 = "Blazing Emblem";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6500;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 13744 , 0 , 0 , 600000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Nifty Stopwatch)
*
***************************************************************/

namespace Server.Items
{
	public class NiftyStopwatch : Item
	{
		public NiftyStopwatch() : base()
		{
			Id = 2820;
			Bonding = 1;
			SellPrice = 4662;
			AvailableClasses = 0x7FFF;
			Model = 6540;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Nifty Stopwatch";
			Name2 = "Nifty Stopwatch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18650;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 14530 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Antipodean Rod)
*
***************************************************************/

namespace Server.Items
{
	public class AntipodeanRod : Item
	{
		public AntipodeanRod() : base()
		{
			Id = 2879;
			Bonding = 2;
			SellPrice = 3121;
			AvailableClasses = 0x7FFF;
			Model = 13109;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Antipodean Rod";
			Name2 = "Antipodean Rod";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15605;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 1600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			SetSpell( 7686 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7700 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tranquil Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TranquilRing : Item
	{
		public TranquilRing() : base()
		{
			Id = 2917;
			Bonding = 1;
			SellPrice = 665;
			AvailableClasses = 0x7FFF;
			Model = 9850;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			Name = "Tranquil Ring";
			Name2 = "Tranquil Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2660;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 1;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sacred Relic)
*
***************************************************************/

namespace Server.Items
{
	public class SacredRelic : Item
	{
		public SacredRelic() : base()
		{
			Id = 2920;
			Resistance[0] = 1;
			Bonding = 2;
			SellPrice = 50;
			AvailableClasses = 0x10;
			Model = 6556;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Sacred Relic";
			Name2 = "Sacred Relic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Blessed Relic)
*
***************************************************************/

namespace Server.Items
{
	public class BlessedRelic : Item
	{
		public BlessedRelic() : base()
		{
			Id = 2921;
			Resistance[0] = 2;
			Bonding = 2;
			SellPrice = 125;
			AvailableClasses = 0x10;
			Model = 6485;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Blessed Relic";
			Name2 = "Blessed Relic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Spirit Relic)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritRelic : Item
	{
		public SpiritRelic() : base()
		{
			Id = 2922;
			Resistance[0] = 2;
			Bonding = 2;
			SellPrice = 250;
			AvailableClasses = 0x10;
			Model = 6564;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Spirit Relic";
			Name2 = "Spirit Relic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Seal of Wrynn)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfWrynn : Item
	{
		public SealOfWrynn() : base()
		{
			Id = 2933;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 9845;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Seal of Wrynn";
			Name2 = "Seal of Wrynn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 2;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Eye of Paleth)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfPaleth : Item
	{
		public EyeOfPaleth() : base()
		{
			Id = 2943;
			Bonding = 1;
			SellPrice = 537;
			AvailableClasses = 0x7FFF;
			Model = 21600;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Eye of Paleth";
			Name2 = "Eye of Paleth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2150;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 7680 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cursed Eye of Paleth)
*
***************************************************************/

namespace Server.Items
{
	public class CursedEyeOfPaleth : Item
	{
		public CursedEyeOfPaleth() : base()
		{
			Id = 2944;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21598;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Cursed Eye of Paleth";
			Name2 = "Cursed Eye of Paleth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 7709 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = -3;
		}
	}
}


/**************************************************************
*
*				(Ring of the Underwood)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheUnderwood : Item
	{
		public RingOfTheUnderwood() : base()
		{
			Id = 2951;
			Bonding = 2;
			SellPrice = 656;
			AvailableClasses = 0x7FFF;
			Model = 9851;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Ring of the Underwood";
			Name2 = "Ring of the Underwood";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 2625;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			AgilityBonus = 10;
			StrBonus = 2;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Relic of the Eye)
*
***************************************************************/

namespace Server.Items
{
	public class RelicOfTheEye : Item
	{
		public RelicOfTheEye() : base()
		{
			Id = 3003;
			Resistance[0] = 1;
			Bonding = 2;
			SellPrice = 50;
			AvailableClasses = 0x10;
			Model = 6492;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Relic of the Eye";
			Name2 = "Relic of the Eye";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Relic of the Dead)
*
***************************************************************/

namespace Server.Items
{
	public class RelicOfTheDead : Item
	{
		public RelicOfTheDead() : base()
		{
			Id = 3004;
			Resistance[0] = 12;
			Bonding = 2;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 6551;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Relic of the Dead";
			Name2 = "Relic of the Dead";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Relic of Truth)
*
***************************************************************/

namespace Server.Items
{
	public class RelicOfTruth : Item
	{
		public RelicOfTruth() : base()
		{
			Id = 3005;
			Resistance[0] = 2;
			Bonding = 2;
			SellPrice = 250;
			AvailableClasses = 0x10;
			Model = 6553;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Relic of Truth";
			Name2 = "Relic of Truth";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Ring of Scorn)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfScorn : Item
	{
		public RingOfScorn() : base()
		{
			Id = 3235;
			Bonding = 1;
			SellPrice = 412;
			AvailableClasses = 0x7FFF;
			Description = "For Deliah";
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Ring of Scorn";
			Name2 = "Ring of Scorn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1650;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			IqBonus = -3;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Stitches' Femur)
*
***************************************************************/

namespace Server.Items
{
	public class StitchesFemur : Item
	{
		public StitchesFemur() : base()
		{
			Id = 3360;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 625;
			AvailableClasses = 0x7FFF;
			Model = 3573;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Stitches' Femur";
			Name2 = "Stitches' Femur";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2500;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 3;
		}
	}
}


/**************************************************************
*
*				(Red Rose)
*
***************************************************************/

namespace Server.Items
{
	public class RedRose : Item
	{
		public RedRose() : base()
		{
			Id = 3419;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 6549;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Red Rose";
			Name2 = "Red Rose";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Black Rose)
*
***************************************************************/

namespace Server.Items
{
	public class BlackRose : Item
	{
		public BlackRose() : base()
		{
			Id = 3420;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 6483;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Black Rose";
			Name2 = "Black Rose";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Simple Wildflowers)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleWildflowers : Item
	{
		public SimpleWildflowers() : base()
		{
			Id = 3421;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 6560;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Simple Wildflowers";
			Name2 = "Simple Wildflowers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Beautiful Wildflowers)
*
***************************************************************/

namespace Server.Items
{
	public class BeautifulWildflowers : Item
	{
		public BeautifulWildflowers() : base()
		{
			Id = 3422;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 6479;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Beautiful Wildflowers";
			Name2 = "Beautiful Wildflowers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bouquet of White Roses)
*
***************************************************************/

namespace Server.Items
{
	public class BouquetOfWhiteRoses : Item
	{
		public BouquetOfWhiteRoses() : base()
		{
			Id = 3423;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 6489;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Bouquet of White Roses";
			Name2 = "Bouquet of White Roses";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bouquet of Black Roses)
*
***************************************************************/

namespace Server.Items
{
	public class BouquetOfBlackRoses : Item
	{
		public BouquetOfBlackRoses() : base()
		{
			Id = 3424;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 6487;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Bouquet of Black Roses";
			Name2 = "Bouquet of Black Roses";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Nightglow Concoction)
*
***************************************************************/

namespace Server.Items
{
	public class NightglowConcoction : Item
	{
		public NightglowConcoction() : base()
		{
			Id = 3451;
			Bonding = 1;
			SellPrice = 607;
			AvailableClasses = 0x7FFF;
			Model = 6541;
			ObjectClass = 4;
			SubClass = 0;
			Level = 18;
			Name = "Nightglow Concoction";
			Name2 = "Nightglow Concoction";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2430;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Skull Ring)
*
***************************************************************/

namespace Server.Items
{
	public class SkullRing : Item
	{
		public SkullRing() : base()
		{
			Id = 3739;
			Bonding = 1;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 16132;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Skull Ring";
			Name2 = "Skull Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 3;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Band of the Undercity)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheUndercity : Item
	{
		public BandOfTheUndercity() : base()
		{
			Id = 3760;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 963;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			Name = "Band of the Undercity";
			Name2 = "Band of the Undercity";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			StaminaBonus = 3;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Choker of the High Shaman)
*
***************************************************************/

namespace Server.Items
{
	public class ChokerOfTheHighShaman : Item
	{
		public ChokerOfTheHighShaman() : base()
		{
			Id = 4112;
			Bonding = 1;
			SellPrice = 4182;
			AvailableClasses = 0x7FFF;
			Model = 9852;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Choker of the High Shaman";
			Name2 = "Choker of the High Shaman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16730;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 5;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Tranquil Orb)
*
***************************************************************/

namespace Server.Items
{
	public class TranquilOrb : Item
	{
		public TranquilOrb() : base()
		{
			Id = 4125;
			Bonding = 1;
			SellPrice = 3142;
			AvailableClasses = 0x7FFF;
			Model = 21605;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			Name = "Tranquil Orb";
			Name2 = "Tranquil Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12570;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 4;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Smotts' Compass)
*
***************************************************************/

namespace Server.Items
{
	public class SmottsCompass : Item
	{
		public SmottsCompass() : base()
		{
			Id = 4130;
			Bonding = 1;
			SellPrice = 2171;
			AvailableClasses = 0x7FFF;
			Model = 6562;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Smotts' Compass";
			Name2 = "Smotts' Compass";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8685;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Language = 7;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Bloodbone Band)
*
***************************************************************/

namespace Server.Items
{
	public class BloodboneBand : Item
	{
		public BloodboneBand() : base()
		{
			Id = 4135;
			Bonding = 1;
			SellPrice = 1130;
			AvailableClasses = 0x7FFF;
			Model = 6486;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Bloodbone Band";
			Name2 = "Bloodbone Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4520;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StaminaBonus = 7;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ethereal Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class EtherealTalisman : Item
	{
		public EtherealTalisman() : base()
		{
			Id = 4430;
			Bonding = 1;
			SellPrice = 4307;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			Name = "Ethereal Talisman";
			Name2 = "Ethereal Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17230;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StrBonus = 5;
			StaminaBonus = 6;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ironforge Memorial Ring)
*
***************************************************************/

namespace Server.Items
{
	public class IronforgeMemorialRing : Item
	{
		public IronforgeMemorialRing() : base()
		{
			Id = 4535;
			Bonding = 1;
			SellPrice = 882;
			AvailableClasses = 0x7FFF;
			Model = 9838;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Ironforge Memorial Ring";
			Name2 = "Ironforge Memorial Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3530;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Seafire Band)
*
***************************************************************/

namespace Server.Items
{
	public class SeafireBand : Item
	{
		public SeafireBand() : base()
		{
			Id = 4549;
			Bonding = 1;
			SellPrice = 2092;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			Name = "Seafire Band";
			Name2 = "Seafire Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 2;
			StaminaBonus = 10;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Coldwater Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ColdwaterRing : Item
	{
		public ColdwaterRing() : base()
		{
			Id = 4550;
			Bonding = 1;
			SellPrice = 2092;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			Name = "Coldwater Ring";
			Name2 = "Coldwater Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SpiritBonus = 3;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Pendant of Myzrael)
*
***************************************************************/

namespace Server.Items
{
	public class PendantOfMyzrael : Item
	{
		public PendantOfMyzrael() : base()
		{
			Id = 4614;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Pendant of Myzrael";
			Name2 = "Pendant of Myzrael";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			StartQuest = 635;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			StaminaBonus = 4;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lapidis Tankard of Tidesippe)
*
***************************************************************/

namespace Server.Items
{
	public class LapidisTankardOfTidesippe : Item
	{
		public LapidisTankardOfTidesippe() : base()
		{
			Id = 4696;
			Bonding = 2;
			SellPrice = 5537;
			AvailableClasses = 0x7FFF;
			Model = 18495;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Lapidis Tankard of Tidesippe";
			Name2 = "Lapidis Tankard of Tidesippe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22150;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 1135 , 0 , 0 , 600000 , 59 , 1000 );
			AgilityBonus = -15;
			IqBonus = 16;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Pulsating Crystalline Shard)
*
***************************************************************/

namespace Server.Items
{
	public class PulsatingCrystallineShard : Item
	{
		public PulsatingCrystallineShard() : base()
		{
			Id = 4743;
			Bonding = 1;
			SellPrice = 5430;
			AvailableClasses = 0x7FFF;
			Model = 6546;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Pulsating Crystalline Shard";
			Name2 = "Pulsating Crystalline Shard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21720;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Fireproof Orb)
*
***************************************************************/

namespace Server.Items
{
	public class FireproofOrb : Item
	{
		public FireproofOrb() : base()
		{
			Id = 4836;
			Bonding = 2;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 21601;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Fireproof Orb";
			Name2 = "Fireproof Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8002;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Strength of Will)
*
***************************************************************/

namespace Server.Items
{
	public class StrengthOfWill : Item
	{
		public StrengthOfWill() : base()
		{
			Id = 4837;
			Bonding = 2;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 21611;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Strength of Will";
			Name2 = "Strength of Will";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8002;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 8;
			Sheath = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Orb of Power)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfPower : Item
	{
		public OrbOfPower() : base()
		{
			Id = 4838;
			Bonding = 2;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 21606;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Orb of Power";
			Name2 = "Orb of Power";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8002;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 8;
			Sheath = 7;
			StaminaBonus = 2;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Skull of Impending Doom)
*
***************************************************************/

namespace Server.Items
{
	public class SkullOfImpendingDoom : Item
	{
		public SkullOfImpendingDoom() : base()
		{
			Id = 4984;
			Bonding = 1;
			SellPrice = 5630;
			AvailableClasses = 0x7FFF;
			Model = 21609;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			Name = "Skull of Impending Doom";
			Name2 = "Skull of Impending Doom";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22520;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			SetSpell( 5024 , 0 , 0 , 0 , 28 , 300000 );
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Burning Obsidian Band)
*
***************************************************************/

namespace Server.Items
{
	public class BurningObsidianBand : Item
	{
		public BurningObsidianBand() : base()
		{
			Id = 4988;
			Bonding = 1;
			SellPrice = 3657;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Burning Obsidian Band";
			Name2 = "Burning Obsidian Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Blood Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BloodRing : Item
	{
		public BloodRing() : base()
		{
			Id = 4998;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Blood Ring";
			Name2 = "Blood Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3350;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Azora's Will)
*
***************************************************************/

namespace Server.Items
{
	public class AzorasWill : Item
	{
		public AzorasWill() : base()
		{
			Id = 4999;
			Bonding = 2;
			SellPrice = 1052;
			AvailableClasses = 0x7FFF;
			Model = 14433;
			ObjectClass = 4;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Azora's Will";
			Name2 = "Azora's Will";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4210;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Coral Band)
*
***************************************************************/

namespace Server.Items
{
	public class CoralBand : Item
	{
		public CoralBand() : base()
		{
			Id = 5000;
			Bonding = 2;
			SellPrice = 962;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Coral Band";
			Name2 = "Coral Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3850;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Flags = 16;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heart Ring)
*
***************************************************************/

namespace Server.Items
{
	public class HeartRing : Item
	{
		public HeartRing() : base()
		{
			Id = 5001;
			Bonding = 2;
			SellPrice = 1038;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Heart Ring";
			Name2 = "Heart Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4155;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Glowing Green Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingGreenTalisman : Item
	{
		public GlowingGreenTalisman() : base()
		{
			Id = 5002;
			Bonding = 2;
			SellPrice = 1535;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Glowing Green Talisman";
			Name2 = "Glowing Green Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6140;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 1;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Crystal Starfire Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class CrystalStarfireMedallion : Item
	{
		public CrystalStarfireMedallion() : base()
		{
			Id = 5003;
			Bonding = 2;
			SellPrice = 1713;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Crystal Starfire Medallion";
			Name2 = "Crystal Starfire Medallion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6855;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 4;
			SpiritBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mark of the Kirin Tor)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfTheKirinTor : Item
	{
		public MarkOfTheKirinTor() : base()
		{
			Id = 5004;
			Bonding = 2;
			SellPrice = 1806;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Mark of the Kirin Tor";
			Name2 = "Mark of the Kirin Tor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7225;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Emberspark Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersparkPendant : Item
	{
		public EmbersparkPendant() : base()
		{
			Id = 5005;
			Bonding = 2;
			SellPrice = 1840;
			AvailableClasses = 0x7FFF;
			Model = 9658;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Emberspark Pendant";
			Name2 = "Emberspark Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7360;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Band of Thorns)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfThorns : Item
	{
		public BandOfThorns() : base()
		{
			Id = 5007;
			Bonding = 2;
			SellPrice = 1632;
			AvailableClasses = 0x7FFF;
			Model = 6478;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Band of Thorns";
			Name2 = "Band of Thorns";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6530;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Quicksilver Ring)
*
***************************************************************/

namespace Server.Items
{
	public class QuicksilverRing : Item
	{
		public QuicksilverRing() : base()
		{
			Id = 5008;
			Bonding = 2;
			SellPrice = 1546;
			AvailableClasses = 0x7FFF;
			Model = 9843;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Quicksilver Ring";
			Name2 = "Quicksilver Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6185;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			Flags = 16;
			AgilityBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mindbender Loop)
*
***************************************************************/

namespace Server.Items
{
	public class MindbenderLoop : Item
	{
		public MindbenderLoop() : base()
		{
			Id = 5009;
			Bonding = 2;
			SellPrice = 1696;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Mindbender Loop";
			Name2 = "Mindbender Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6785;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 7;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Inscribed Gold Ring)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedGoldRing : Item
	{
		public InscribedGoldRing() : base()
		{
			Id = 5010;
			Bonding = 2;
			SellPrice = 1803;
			AvailableClasses = 0x7FFF;
			Model = 3453;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Inscribed Gold Ring";
			Name2 = "Inscribed Gold Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7215;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StrBonus = 2;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Welken Ring)
*
***************************************************************/

namespace Server.Items
{
	public class WelkenRing : Item
	{
		public WelkenRing() : base()
		{
			Id = 5011;
			Bonding = 2;
			SellPrice = 1912;
			AvailableClasses = 0x7FFF;
			Model = 9851;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Welken Ring";
			Name2 = "Welken Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7650;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 5;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lord Sakrasis' Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class LordSakrasisScepter : Item
	{
		public LordSakrasisScepter() : base()
		{
			Id = 5028;
			Bonding = 2;
			SellPrice = 5537;
			AvailableClasses = 0x7FFF;
			Model = 24742;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Lord Sakrasis' Scepter";
			Name2 = "Lord Sakrasis' Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22150;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
			Sheath = 3;
			SpiritBonus = 6;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Talisman of the Naga Lord)
*
***************************************************************/

namespace Server.Items
{
	public class TalismanOfTheNagaLord : Item
	{
		public TalismanOfTheNagaLord() : base()
		{
			Id = 5029;
			Bonding = 2;
			SellPrice = 5282;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Talisman of the Naga Lord";
			Name2 = "Talisman of the Naga Lord";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21130;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StrBonus = 2;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cold Basilisk Eye)
*
***************************************************************/

namespace Server.Items
{
	public class ColdBasiliskEye : Item
	{
		public ColdBasiliskEye() : base()
		{
			Id = 5079;
			Bonding = 2;
			SellPrice = 4642;
			AvailableClasses = 0x7FFF;
			Model = 6492;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Cold Basilisk Eye";
			Name2 = "Cold Basilisk Eye";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18570;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 1139 , 0 , 0 , 300000 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Red Defias Mask)
*
***************************************************************/

namespace Server.Items
{
	public class RedDefiasMask : Item
	{
		public RedDefiasMask() : base()
		{
			Id = 5106;
			SellPrice = 83;
			AvailableClasses = 0x7A08;
			Model = 15308;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			Name = "Red Defias Mask";
			Name2 = "Red Defias Mask";
			AvailableRaces = 0x1FF;
			BuyPrice = 417;
			InventoryType = InventoryTypes.Head;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Necklace of Harmony)
*
***************************************************************/

namespace Server.Items
{
	public class NecklaceOfHarmony : Item
	{
		public NecklaceOfHarmony() : base()
		{
			Id = 5180;
			Bonding = 2;
			SellPrice = 2777;
			AvailableClasses = 0x7FFF;
			Model = 6494;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Necklace of Harmony";
			Name2 = "Necklace of Harmony";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11110;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Pulsating Hydra Heart)
*
***************************************************************/

namespace Server.Items
{
	public class PulsatingHydraHeart : Item
	{
		public PulsatingHydraHeart() : base()
		{
			Id = 5183;
			Bonding = 2;
			SellPrice = 1575;
			AvailableClasses = 0x7FFF;
			Model = 21607;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Pulsating Hydra Heart";
			Name2 = "Pulsating Hydra Heart";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6300;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 7687 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Eye of Adaegus)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfAdaegus : Item
	{
		public EyeOfAdaegus() : base()
		{
			Id = 5266;
			Bonding = 2;
			SellPrice = 11157;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Eye of Adaegus";
			Name2 = "Eye of Adaegus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 12;
			StaminaBonus = 5;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Totemic Clan Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TotemicClanRing : Item
	{
		public TotemicClanRing() : base()
		{
			Id = 5313;
			Bonding = 1;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 7544;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Totemic Clan Ring";
			Name2 = "Totemic Clan Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2600;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SpiritBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Everglow Lantern)
*
***************************************************************/

namespace Server.Items
{
	public class EverglowLantern : Item
	{
		public EverglowLantern() : base()
		{
			Id = 5323;
			Bonding = 1;
			SellPrice = 1632;
			AvailableClasses = 0x7FFF;
			Model = 7557;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Everglow Lantern";
			Name2 = "Everglow Lantern";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6530;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 14053 , 0 , 0 , 1800000 , 30 , 180000 );
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bounty Hunter's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BountyHuntersRing : Item
	{
		public BountyHuntersRing() : base()
		{
			Id = 5351;
			Bonding = 1;
			SellPrice = 403;
			AvailableClasses = 0x7FFF;
			Model = 6011;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Bounty Hunter's Ring";
			Name2 = "Bounty Hunter's Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1615;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			Language = 7;
			StaminaBonus = 1;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Winterhoof Cleansing Totem)
*
***************************************************************/

namespace Server.Items
{
	public class WinterhoofCleansingTotem : Item
	{
		public WinterhoofCleansingTotem() : base()
		{
			Id = 5411;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7866;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Winterhoof Cleansing Totem";
			Name2 = "Winterhoof Cleansing Totem";
			Quality = 1;
			AvailableRaces = 0x20;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Flags = 64;
			SetSpell( 4975 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mana Agate)
*
***************************************************************/

namespace Server.Items
{
	public class ManaAgate : Item
	{
		public ManaAgate() : base()
		{
			Id = 5514;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6851;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Mana Agate";
			Name2 = "Mana Agate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 5405 , 0 , -1 , 0 , 100 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Spellstone)
*
***************************************************************/

namespace Server.Items
{
	public class Spellstone : Item
	{
		public Spellstone() : base()
		{
			Id = 5522;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21610;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Spellstone";
			Name2 = "Spellstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Flags = 2;
			SetSpell( 128 , 0 , -1 , 0 , 0 , 0 );
			SetSpell( 18384 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Tear of Grief)
*
***************************************************************/

namespace Server.Items
{
	public class TearOfGrief : Item
	{
		public TearOfGrief() : base()
		{
			Id = 5611;
			Bonding = 1;
			SellPrice = 452;
			AvailableClasses = 0x7FFF;
			Model = 8436;
			ObjectClass = 4;
			SubClass = 0;
			Level = 16;
			Name = "Tear of Grief";
			Name2 = "Tear of Grief";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1810;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 5;
			IqBonus = -3;
		}
	}
}


/**************************************************************
*
*				(Clergy Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ClergyRing : Item
	{
		public ClergyRing() : base()
		{
			Id = 5622;
			Bonding = 1;
			SellPrice = 556;
			AvailableClasses = 0x7FFF;
			Model = 14432;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			Name = "Clergy Ring";
			Name2 = "Clergy Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2225;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			Language = 7;
			StaminaBonus = 1;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wolfpack Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class WolfpackMedallion : Item
	{
		public WolfpackMedallion() : base()
		{
			Id = 5754;
			Bonding = 2;
			SellPrice = 2538;
			AvailableClasses = 0x7FFF;
			Model = 7093;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Wolfpack Medallion";
			Name2 = "Wolfpack Medallion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10155;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dim Torch)
*
***************************************************************/

namespace Server.Items
{
	public class DimTorch : Item
	{
		public DimTorch() : base()
		{
			Id = 6182;
			AvailableClasses = 0x7FFF;
			Model = 12312;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			ReqLevel = 5;
			Name = "Dim Torch";
			Name2 = "Dim Torch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
			SetSpell( 7363 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Black Widow Band)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWidowBand : Item
	{
		public BlackWidowBand() : base()
		{
			Id = 6199;
			Bonding = 2;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 10530;
			ObjectClass = 4;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Black Widow Band";
			Name2 = "Black Widow Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2600;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			StaminaBonus = -5;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Silverlaine's Family Seal)
*
***************************************************************/

namespace Server.Items
{
	public class SilverlainesFamilySeal : Item
	{
		public SilverlainesFamilySeal() : base()
		{
			Id = 6321;
			Bonding = 1;
			SellPrice = 1650;
			AvailableClasses = 0x7FFF;
			Model = 14433;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Silverlaine's Family Seal";
			Name2 = "Silverlaine's Family Seal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6600;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			StrBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Black Pearl Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BlackPearlRing : Item
	{
		public BlackPearlRing() : base()
		{
			Id = 6332;
			Bonding = 2;
			SellPrice = 1153;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Black Pearl Ring";
			Name2 = "Black Pearl Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4615;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Language = 7;
			IqBonus = 6;
			SpiritBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Eerie Stable Lantern)
*
***************************************************************/

namespace Server.Items
{
	public class EerieStableLantern : Item
	{
		public EerieStableLantern() : base()
		{
			Id = 6341;
			Bonding = 1;
			SellPrice = 666;
			AvailableClasses = 0x7FFF;
			Model = 11410;
			ObjectClass = 4;
			SubClass = 0;
			Level = 19;
			ReqLevel = 14;
			Name = "Eerie Stable Lantern";
			Name2 = "Eerie Stable Lantern";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2665;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Seal of Sylvanas)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfSylvanas : Item
	{
		public SealOfSylvanas() : base()
		{
			Id = 6414;
			Bonding = 1;
			SellPrice = 2055;
			AvailableClasses = 0x7FFF;
			Model = 9846;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			Name = "Seal of Sylvanas";
			Name2 = "Seal of Sylvanas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8220;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			StaminaBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Brainlash)
*
***************************************************************/

namespace Server.Items
{
	public class Brainlash : Item
	{
		public Brainlash() : base()
		{
			Id = 6440;
			Bonding = 2;
			SellPrice = 15812;
			AvailableClasses = 0x7FFF;
			Model = 12643;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Brainlash";
			Name2 = "Brainlash";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 63250;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			SpiritBonus = 15;
			IqBonus = 5;
			StaminaBonus = -10;
		}
	}
}


/**************************************************************
*
*				(Deep Fathom Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DeepFathomRing : Item
	{
		public DeepFathomRing() : base()
		{
			Id = 6463;
			Bonding = 1;
			SellPrice = 1527;
			AvailableClasses = 0x7FFF;
			Model = 9846;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Deep Fathom Ring";
			Name2 = "Deep Fathom Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6110;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 6;
			StaminaBonus = 3;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Viridian Band)
*
***************************************************************/

namespace Server.Items
{
	public class ViridianBand : Item
	{
		public ViridianBand() : base()
		{
			Id = 6589;
			Bonding = 2;
			SellPrice = 1056;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Viridian Band";
			Name2 = "Viridian Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3475;
			BuyPrice = 4225;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Sacred Band)
*
***************************************************************/

namespace Server.Items
{
	public class SacredBand : Item
	{
		public SacredBand() : base()
		{
			Id = 6669;
			Bonding = 1;
			SellPrice = 1378;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Sacred Band";
			Name2 = "Sacred Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5515;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Band of Elven Grace)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfElvenGrace : Item
	{
		public BandOfElvenGrace() : base()
		{
			Id = 6678;
			Bonding = 1;
			SellPrice = 677;
			AvailableClasses = 0x7FFF;
			Model = 14434;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			Name = "Band of Elven Grace";
			Name2 = "Band of Elven Grace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2710;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			Language = 7;
			StaminaBonus = 3;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Agamaggan's Clutch)
*
***************************************************************/

namespace Server.Items
{
	public class AgamaggansClutch : Item
	{
		public AgamaggansClutch() : base()
		{
			Id = 6693;
			Bonding = 1;
			SellPrice = 1816;
			AvailableClasses = 0x7FFF;
			Model = 6486;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Agamaggan's Clutch";
			Name2 = "Agamaggan's Clutch";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7265;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Sheath = 1;
			IqBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Stygian Bone Amulet)
*
***************************************************************/

namespace Server.Items
{
	public class StygianBoneAmulet : Item
	{
		public StygianBoneAmulet() : base()
		{
			Id = 6695;
			Bonding = 1;
			SellPrice = 3002;
			AvailableClasses = 0x7FFF;
			Model = 9852;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			ReqLevel = 27;
			Name = "Stygian Bone Amulet";
			Name2 = "Stygian Bone Amulet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12010;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			IqBonus = 8;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Medal of Courage)
*
***************************************************************/

namespace Server.Items
{
	public class MedalOfCourage : Item
	{
		public MedalOfCourage() : base()
		{
			Id = 6723;
			Bonding = 1;
			SellPrice = 8155;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			Name = "Medal of Courage";
			Name2 = "Medal of Courage";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32620;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 3;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Sustaining Ring)
*
***************************************************************/

namespace Server.Items
{
	public class SustainingRing : Item
	{
		public SustainingRing() : base()
		{
			Id = 6743;
			Bonding = 1;
			SellPrice = 1462;
			AvailableClasses = 0x7FFF;
			Model = 12984;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Sustaining Ring";
			Name2 = "Sustaining Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5850;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 4;
			Language = 7;
			StaminaBonus = 1;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Monkey Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MonkeyRing : Item
	{
		public MonkeyRing() : base()
		{
			Id = 6748;
			Bonding = 1;
			SellPrice = 897;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Monkey Ring";
			Name2 = "Monkey Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3590;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tiger Band)
*
***************************************************************/

namespace Server.Items
{
	public class TigerBand : Item
	{
		public TigerBand() : base()
		{
			Id = 6749;
			Bonding = 1;
			SellPrice = 897;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Tiger Band";
			Name2 = "Tiger Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3590;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Snake Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class SnakeHoop : Item
	{
		public SnakeHoop() : base()
		{
			Id = 6750;
			Bonding = 1;
			SellPrice = 897;
			AvailableClasses = 0x7FFF;
			Model = 12987;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Snake Hoop";
			Name2 = "Snake Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3590;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Jaina's Signet Ring)
*
***************************************************************/

namespace Server.Items
{
	public class JainasSignetRing : Item
	{
		public JainasSignetRing() : base()
		{
			Id = 6757;
			Bonding = 1;
			SellPrice = 4630;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			Name = "Jaina's Signet Ring";
			Name2 = "Jaina's Signet Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18520;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StrBonus = 3;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Uthek's Finger)
*
***************************************************************/

namespace Server.Items
{
	public class UtheksFinger : Item
	{
		public UtheksFinger() : base()
		{
			Id = 6774;
			Bonding = 1;
			SellPrice = 2885;
			AvailableClasses = 0x7FFF;
			Model = 13012;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			Name = "Uthek's Finger";
			Name2 = "Uthek's Finger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11540;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 5;
			SpiritBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Simple Dress)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleDress : Item
	{
		public SimpleDress() : base()
		{
			Id = 6786;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 13043;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Simple Dress";
			Name2 = "Simple Dress";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 298;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ring of Calm)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfCalm : Item
	{
		public RingOfCalm() : base()
		{
			Id = 6790;
			Bonding = 1;
			SellPrice = 1540;
			AvailableClasses = 0x7FFF;
			Model = 6012;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			Name = "Ring of Calm";
			Name2 = "Ring of Calm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6160;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Prophetic Cane)
*
***************************************************************/

namespace Server.Items
{
	public class PropheticCane : Item
	{
		public PropheticCane() : base()
		{
			Id = 6803;
			Bonding = 1;
			SellPrice = 4885;
			AvailableClasses = 0x7FFF;
			Model = 15430;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Prophetic Cane";
			Name2 = "Prophetic Cane";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19540;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 2;
			SpiritBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Black Tuxedo)
*
***************************************************************/

namespace Server.Items
{
	public class BlackTuxedo : Item
	{
		public BlackTuxedo() : base()
		{
			Id = 6834;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 13116;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Black Tuxedo";
			Name2 = "Black Tuxedo";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Black Tuxedo Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BlackTuxedoPants : Item
	{
		public BlackTuxedoPants() : base()
		{
			Id = 6835;
			SellPrice = 504;
			AvailableClasses = 0x7FFF;
			Model = 13117;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			Name = "Black Tuxedo Pants";
			Name2 = "Black Tuxedo Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2521;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Orb of Soran'ruk)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfSoranruk : Item
	{
		public OrbOfSoranruk() : base()
		{
			Id = 6898;
			Bonding = 1;
			SellPrice = 4132;
			AvailableClasses = 0x7B00;
			Model = 21597;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Orb of Soran'ruk";
			Name2 = "Orb of Soran'ruk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16530;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 7685 , 1 , 0 , -1 , 0 , 0 );
			SetSpell( 7706 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18956 , 0 , 0 , 1800000 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Morbent's Bane)
*
***************************************************************/

namespace Server.Items
{
	public class MorbentsBane : Item
	{
		public MorbentsBane() : base()
		{
			Id = 7297;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21604;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			Name = "Morbent's Bane";
			Name2 = "Morbent's Bane";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 3;
			SetSpell( 8913 , 0 , 0 , -1 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(The Rock)
*
***************************************************************/

namespace Server.Items
{
	public class TheRock : Item
	{
		public TheRock() : base()
		{
			Id = 7337;
			SellPrice = 250000;
			AvailableClasses = 0x7FFF;
			Description = "It's huge!";
			Model = 24646;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "The Rock";
			Name2 = "The Rock";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Mood Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MoodRing : Item
	{
		public MoodRing() : base()
		{
			Id = 7338;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Description = "It's blue, wait, it's green!";
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Mood Ring";
			Name2 = "Mood Ring";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Miniscule Diamond Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MinisculeDiamondRing : Item
	{
		public MinisculeDiamondRing() : base()
		{
			Id = 7339;
			SellPrice = 62500;
			AvailableClasses = 0x7FFF;
			Description = "Hey, it's still a diamond.";
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Miniscule Diamond Ring";
			Name2 = "Miniscule Diamond Ring";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Flawless Diamond Solitaire)
*
***************************************************************/

namespace Server.Items
{
	public class FlawlessDiamondSolitaire : Item
	{
		public FlawlessDiamondSolitaire() : base()
		{
			Id = 7340;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Description = "Will you marry me?";
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Flawless Diamond Solitaire";
			Name2 = "Flawless Diamond Solitaire";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Cubic Zirconia Ring)
*
***************************************************************/

namespace Server.Items
{
	public class CubicZirconiaRing : Item
	{
		public CubicZirconiaRing() : base()
		{
			Id = 7341;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Description = "Trust me, she'll know.";
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Cubic Zirconia Ring";
			Name2 = "Cubic Zirconia Ring";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Silver Piffeny Band)
*
***************************************************************/

namespace Server.Items
{
	public class SilverPiffenyBand : Item
	{
		public SilverPiffenyBand() : base()
		{
			Id = 7342;
			SellPrice = 25000;
			AvailableClasses = 0x7FFF;
			Description = "Nothing says sorry like Piffeny.";
			Model = 14432;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Silver Piffeny Band";
			Name2 = "Silver Piffeny Band";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Torch of Holy Flame)
*
***************************************************************/

namespace Server.Items
{
	public class TorchOfHolyFlame7344 : Item
	{
		public TorchOfHolyFlame7344() : base()
		{
			Id = 7344;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 21604;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			Name = "Torch of Holy Flame";
			Name2 = "Torch of Holy Flame";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 3;
			SetSpell( 9176 , 0 , 0 , -1 , 29 , 180000 );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Cerulean Ring)
*
***************************************************************/

namespace Server.Items
{
	public class CeruleanRing : Item
	{
		public CeruleanRing() : base()
		{
			Id = 7426;
			Bonding = 2;
			SellPrice = 1243;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Cerulean Ring";
			Name2 = "Cerulean Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3476;
			BuyPrice = 4975;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Cerulean Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class CeruleanTalisman : Item
	{
		public CeruleanTalisman() : base()
		{
			Id = 7427;
			Bonding = 2;
			SellPrice = 3788;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Cerulean Talisman";
			Name2 = "Cerulean Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3506;
			BuyPrice = 15155;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Vermilion Band)
*
***************************************************************/

namespace Server.Items
{
	public class VermilionBand : Item
	{
		public VermilionBand() : base()
		{
			Id = 7466;
			Bonding = 2;
			SellPrice = 1921;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Vermilion Band";
			Name2 = "Vermilion Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3479;
			BuyPrice = 7685;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Vermilion Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class VermilionNecklace : Item
	{
		public VermilionNecklace() : base()
		{
			Id = 7467;
			Bonding = 2;
			SellPrice = 5658;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Vermilion Necklace";
			Name2 = "Vermilion Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3507;
			BuyPrice = 22635;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Ivory Band)
*
***************************************************************/

namespace Server.Items
{
	public class IvoryBand : Item
	{
		public IvoryBand() : base()
		{
			Id = 7497;
			Bonding = 2;
			SellPrice = 1983;
			AvailableClasses = 0x7FFF;
			Model = 9850;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Ivory Band";
			Name2 = "Ivory Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3480;
			BuyPrice = 7935;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Arcane Orb)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneOrb : Item
	{
		public ArcaneOrb() : base()
		{
			Id = 7507;
			Bonding = 1;
			SellPrice = 400;
			AvailableClasses = 0x80;
			Model = 22923;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Arcane Orb";
			Name2 = "Arcane Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9252 , 0 , 0 , 1800000 , 30 , 180000 );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ley Orb)
*
***************************************************************/

namespace Server.Items
{
	public class LeyOrb : Item
	{
		public LeyOrb() : base()
		{
			Id = 7508;
			Bonding = 1;
			SellPrice = 400;
			AvailableClasses = 0x80;
			Model = 22923;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Ley Orb";
			Name2 = "Ley Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9252 , 0 , 0 , 1800000 , 30 , 180000 );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Celestial Orb)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialOrb : Item
	{
		public CelestialOrb() : base()
		{
			Id = 7515;
			Bonding = 1;
			SellPrice = 5382;
			AvailableClasses = 0x7A80;
			Model = 25072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Celestial Orb";
			Name2 = "Celestial Orb";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21530;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 13595 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 7688 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 7702 , 1 , 0 , 0 , 0 , 0 );
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Onyx Ring)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxRing : Item
	{
		public OnyxRing() : base()
		{
			Id = 7547;
			Bonding = 2;
			SellPrice = 3092;
			AvailableClasses = 0x7FFF;
			Model = 9846;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Onyx Ring";
			Name2 = "Onyx Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3482;
			BuyPrice = 12370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Onyx Choker)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxChoker : Item
	{
		public OnyxChoker() : base()
		{
			Id = 7548;
			Bonding = 2;
			SellPrice = 6507;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Onyx Choker";
			Name2 = "Onyx Choker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3511;
			BuyPrice = 26030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Fairy's Embrace)
*
***************************************************************/

namespace Server.Items
{
	public class FairysEmbrace : Item
	{
		public FairysEmbrace() : base()
		{
			Id = 7549;
			Bonding = 2;
			SellPrice = 6420;
			AvailableClasses = 0x7FFF;
			Model = 14437;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Fairy's Embrace";
			Name2 = "Fairy's Embrace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25680;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 5;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Warrior's Honor)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsHonor : Item
	{
		public WarriorsHonor() : base()
		{
			Id = 7550;
			Bonding = 2;
			SellPrice = 7645;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Warrior's Honor";
			Name2 = "Warrior's Honor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30580;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StrBonus = 3;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Entwined Opaline Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class EntwinedOpalineTalisman : Item
	{
		public EntwinedOpalineTalisman() : base()
		{
			Id = 7551;
			Bonding = 2;
			SellPrice = 7145;
			AvailableClasses = 0x7FFF;
			Model = 15421;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Entwined Opaline Talisman";
			Name2 = "Entwined Opaline Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28580;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 10;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Falcon's Hook)
*
***************************************************************/

namespace Server.Items
{
	public class FalconsHook : Item
	{
		public FalconsHook() : base()
		{
			Id = 7552;
			Bonding = 2;
			SellPrice = 2542;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Falcon's Hook";
			Name2 = "Falcon's Hook";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 3;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Band of the Unicorn)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheUnicorn : Item
	{
		public BandOfTheUnicorn() : base()
		{
			Id = 7553;
			Bonding = 2;
			SellPrice = 2542;
			AvailableClasses = 0x7FFF;
			Model = 15422;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Band of the Unicorn";
			Name2 = "Band of the Unicorn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SetSpell( 9342 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Willow Branch)
*
***************************************************************/

namespace Server.Items
{
	public class WillowBranch : Item
	{
		public WillowBranch() : base()
		{
			Id = 7554;
			Bonding = 2;
			SellPrice = 1039;
			AvailableClasses = 0x7FFF;
			Model = 15424;
			ObjectClass = 4;
			SubClass = 0;
			Level = 19;
			ReqLevel = 14;
			Name = "Willow Branch";
			Name2 = "Willow Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2002;
			BuyPrice = 4158;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Regal Star)
*
***************************************************************/

namespace Server.Items
{
	public class RegalStar : Item
	{
		public RegalStar() : base()
		{
			Id = 7555;
			Bonding = 2;
			SellPrice = 7123;
			AvailableClasses = 0x7FFF;
			Model = 6098;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Regal Star";
			Name2 = "Regal Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2050;
			BuyPrice = 28493;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Twilight Orb)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightOrb : Item
	{
		public TwilightOrb() : base()
		{
			Id = 7556;
			Bonding = 2;
			SellPrice = 5387;
			AvailableClasses = 0x7FFF;
			Model = 21598;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Twilight Orb";
			Name2 = "Twilight Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2044;
			BuyPrice = 21548;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Gossamer Rod)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerRod : Item
	{
		public GossamerRod() : base()
		{
			Id = 7557;
			Bonding = 2;
			SellPrice = 7596;
			AvailableClasses = 0x7FFF;
			Model = 15427;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Gossamer Rod";
			Name2 = "Gossamer Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2062;
			BuyPrice = 30385;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Shimmering Stave)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringStave : Item
	{
		public ShimmeringStave() : base()
		{
			Id = 7558;
			Bonding = 2;
			SellPrice = 1609;
			AvailableClasses = 0x7FFF;
			Model = 15428;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Shimmering Stave";
			Name2 = "Shimmering Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2014;
			BuyPrice = 6438;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Runic Cane)
*
***************************************************************/

namespace Server.Items
{
	public class RunicCane : Item
	{
		public RunicCane() : base()
		{
			Id = 7559;
			Bonding = 2;
			SellPrice = 666;
			AvailableClasses = 0x7FFF;
			Model = 11919;
			ObjectClass = 4;
			SubClass = 0;
			Level = 17;
			ReqLevel = 12;
			Name = "Runic Cane";
			Name2 = "Runic Cane";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2665;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 2;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Seer's Fine Stein)
*
***************************************************************/

namespace Server.Items
{
	public class SeersFineStein : Item
	{
		public SeersFineStein() : base()
		{
			Id = 7608;
			Bonding = 2;
			SellPrice = 1106;
			AvailableClasses = 0x7FFF;
			Model = 18494;
			ObjectClass = 4;
			SubClass = 0;
			Level = 21;
			ReqLevel = 16;
			Name = "Seer's Fine Stein";
			Name2 = "Seer's Fine Stein";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4425;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 3;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Elder's Amber Stave)
*
***************************************************************/

namespace Server.Items
{
	public class EldersAmberStave : Item
	{
		public EldersAmberStave() : base()
		{
			Id = 7609;
			Bonding = 2;
			SellPrice = 4210;
			AvailableClasses = 0x7FFF;
			Model = 15564;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Elder's Amber Stave";
			Name2 = "Elder's Amber Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2032;
			BuyPrice = 16843;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Aurora Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraSphere : Item
	{
		public AuroraSphere() : base()
		{
			Id = 7610;
			Bonding = 2;
			SellPrice = 5811;
			AvailableClasses = 0x7FFF;
			Model = 21596;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Aurora Sphere";
			Name2 = "Aurora Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23245;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Mistscape Stave)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeStave : Item
	{
		public MistscapeStave() : base()
		{
			Id = 7611;
			Bonding = 2;
			SellPrice = 7364;
			AvailableClasses = 0x7FFF;
			Model = 15561;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Mistscape Stave";
			Name2 = "Mistscape Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29458;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 3;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Talvash's Enhancing Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TalvashsEnhancingNecklace : Item
	{
		public TalvashsEnhancingNecklace() : base()
		{
			Id = 7673;
			Bonding = 1;
			SellPrice = 8990;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Talvash's Enhancing Necklace";
			Name2 = "Talvash's Enhancing Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35961;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 1;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Orb of the Forgotten Seer)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfTheForgottenSeer : Item
	{
		public OrbOfTheForgottenSeer() : base()
		{
			Id = 7685;
			Bonding = 1;
			SellPrice = 5468;
			AvailableClasses = 0x7FFF;
			Model = 15725;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Orb of the Forgotten Seer";
			Name2 = "Orb of the Forgotten Seer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27340;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9417 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Ironspine's Eye)
*
***************************************************************/

namespace Server.Items
{
	public class IronspinesEye : Item
	{
		public IronspinesEye() : base()
		{
			Id = 7686;
			Bonding = 1;
			SellPrice = 4308;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Ironspine's Eye";
			Name2 = "Ironspine's Eye";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17235;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Sheath = 1;
			AgilityBonus = 9;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Triune Amulet)
*
***************************************************************/

namespace Server.Items
{
	public class TriuneAmulet : Item
	{
		public TriuneAmulet() : base()
		{
			Id = 7722;
			Bonding = 1;
			SellPrice = 9295;
			AvailableClasses = 0x7FFF;
			Model = 6522;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Triune Amulet";
			Name2 = "Triune Amulet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37180;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			SpiritBonus = 7;
			IqBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ghostshard Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class GhostshardTalisman : Item
	{
		public GhostshardTalisman() : base()
		{
			Id = 7731;
			Bonding = 1;
			SellPrice = 3482;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Ghostshard Talisman";
			Name2 = "Ghostshard Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13930;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Six Demon Bag)
*
***************************************************************/

namespace Server.Items
{
	public class SixDemonBag : Item
	{
		public SixDemonBag() : base()
		{
			Id = 7734;
			Bonding = 2;
			SellPrice = 15495;
			AvailableClasses = 0x7FFF;
			Model = 3410;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Six Demon Bag";
			Name2 = "Six Demon Bag";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61980;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 14537 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Explorers' League Commendation)
*
***************************************************************/

namespace Server.Items
{
	public class ExplorersLeagueCommendation : Item
	{
		public ExplorersLeagueCommendation() : base()
		{
			Id = 7746;
			Bonding = 1;
			SellPrice = 8430;
			AvailableClasses = 0x7FFF;
			Model = 7899;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			Name = "Explorers' League Commendation";
			Name2 = "Explorers' League Commendation";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33720;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Omega Orb)
*
***************************************************************/

namespace Server.Items
{
	public class OmegaOrb : Item
	{
		public OmegaOrb() : base()
		{
			Id = 7749;
			Bonding = 1;
			SellPrice = 4885;
			AvailableClasses = 0x7FFF;
			Model = 21595;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			Name = "Omega Orb";
			Name2 = "Omega Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19540;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 9416 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Easter Dress)
*
***************************************************************/

namespace Server.Items
{
	public class EasterDress : Item
	{
		public EasterDress() : base()
		{
			Id = 7809;
			SellPrice = 1024;
			AvailableClasses = 0x7FFF;
			Model = 15966;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Easter Dress";
			Name2 = "Easter Dress";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5124;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Jarkal's Enhancing Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class JarkalsEnhancingNecklace : Item
	{
		public JarkalsEnhancingNecklace() : base()
		{
			Id = 7888;
			Bonding = 1;
			SellPrice = 8990;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Jarkal's Enhancing Necklace";
			Name2 = "Jarkal's Enhancing Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35961;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 1;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Red Defias Mask)
*
***************************************************************/

namespace Server.Items
{
	public class RedDefiasMask7997 : Item
	{
		public RedDefiasMask7997() : base()
		{
			Id = 7997;
			Bonding = 1;
			SellPrice = 81;
			AvailableClasses = 0x7A08;
			Model = 15308;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			Name = "Red Defias Mask";
			Name2 = "Red Defias Mask";
			AvailableRaces = 0x1FF;
			BuyPrice = 406;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The 1 Ring)
*
***************************************************************/

namespace Server.Items
{
	public class The1Ring : Item
	{
		public The1Ring() : base()
		{
			Id = 8350;
			Bonding = 2;
			SellPrice = 1130;
			AvailableClasses = 0x7FFF;
			Description = "Not quite as good as the 2 Ring";
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "The 1 Ring";
			Name2 = "The 1 Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4520;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 1;
			AgilityBonus = 1;
			StaminaBonus = 1;
			IqBonus = 1;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Red Sparkler)
*
***************************************************************/

namespace Server.Items
{
	public class RedSparkler : Item
	{
		public RedSparkler() : base()
		{
			Id = 8624;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17599;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Red Sparkler";
			Name2 = "Red Sparkler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(White Sparkler)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteSparkler : Item
	{
		public WhiteSparkler() : base()
		{
			Id = 8625;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17600;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "White Sparkler";
			Name2 = "White Sparkler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Blue Sparkler)
*
***************************************************************/

namespace Server.Items
{
	public class BlueSparkler : Item
	{
		public BlueSparkler() : base()
		{
			Id = 8626;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17602;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Blue Sparkler";
			Name2 = "Blue Sparkler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Bind On Acquire Test Item)
*
***************************************************************/

namespace Server.Items
{
	public class BindOnAcquireTestItem : Item
	{
		public BindOnAcquireTestItem() : base()
		{
			Id = 8688;
			Bonding = 1;
			SellPrice = 1087;
			AvailableClasses = 0x7FFF;
			Model = 6511;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Bind On Acquire Test Item";
			Name2 = "Bind On Acquire Test Item";
			AvailableRaces = 0x1FF;
			BuyPrice = 4350;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			SetSpell( 133 , 0 , 0 , 30000 , 24 , 30000 );
		}
	}
}


/**************************************************************
*
*				(Shriveled Heart)
*
***************************************************************/

namespace Server.Items
{
	public class ShriveledHeart : Item
	{
		public ShriveledHeart() : base()
		{
			Id = 9243;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17918;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Shriveled Heart";
			Name2 = "Shriveled Heart";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			IqBonus = -5;
			StrBonus = -5;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Tarnished Silver Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedSilverNecklace : Item
	{
		public TarnishedSilverNecklace() : base()
		{
			Id = 9333;
			SellPrice = 73;
			AvailableClasses = 0x7FFF;
			Model = 18172;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Tarnished Silver Necklace";
			Name2 = "Tarnished Silver Necklace";
			AvailableRaces = 0x1FF;
			BuyPrice = 295;
			InventoryType = InventoryTypes.Neck;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Brilliant Gold Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BrilliantGoldRing : Item
	{
		public BrilliantGoldRing() : base()
		{
			Id = 9362;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Brilliant Gold Ring";
			Name2 = "Brilliant Gold Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Beacon of Hope)
*
***************************************************************/

namespace Server.Items
{
	public class BeaconOfHope : Item
	{
		public BeaconOfHope() : base()
		{
			Id = 9393;
			Bonding = 2;
			SellPrice = 7882;
			AvailableClasses = 0x7FFF;
			Model = 11410;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Beacon of Hope";
			Name2 = "Beacon of Hope";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31530;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9408 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Archaedic Shard)
*
***************************************************************/

namespace Server.Items
{
	public class ArchaedicShard : Item
	{
		public ArchaedicShard() : base()
		{
			Id = 9417;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 10795;
			AvailableClasses = 0x7FFF;
			Model = 18308;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Archaedic Shard";
			Name2 = "Archaedic Shard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43180;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Electrocutioner Lagnut)
*
***************************************************************/

namespace Server.Items
{
	public class ElectrocutionerLagnut : Item
	{
		public ElectrocutionerLagnut() : base()
		{
			Id = 9447;
			Bonding = 1;
			SellPrice = 3237;
			AvailableClasses = 0x7FFF;
			Model = 18365;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Electrocutioner Lagnut";
			Name2 = "Electrocutioner Lagnut";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12950;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Sheath = 1;
			IqBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Charged Gear)
*
***************************************************************/

namespace Server.Items
{
	public class ChargedGear : Item
	{
		public ChargedGear() : base()
		{
			Id = 9461;
			Resistance[6] = 5;
			Bonding = 1;
			SellPrice = 4586;
			AvailableClasses = 0x7FFF;
			Model = 3258;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Charged Gear";
			Name2 = "Charged Gear";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3481;
			BuyPrice = 18345;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Masons Fraternity Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MasonsFraternityRing : Item
	{
		public MasonsFraternityRing() : base()
		{
			Id = 9533;
			Bonding = 1;
			SellPrice = 7092;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Masons Fraternity Ring";
			Name2 = "Masons Fraternity Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			AgilityBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Talvash's Gold Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TalvashsGoldRing : Item
	{
		public TalvashsGoldRing() : base()
		{
			Id = 9538;
			Bonding = 1;
			SellPrice = 6463;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Talvash's Gold Ring";
			Name2 = "Talvash's Gold Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25852;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Nogg's Gold Ring)
*
***************************************************************/

namespace Server.Items
{
	public class NoggsGoldRing : Item
	{
		public NoggsGoldRing() : base()
		{
			Id = 9588;
			Bonding = 1;
			SellPrice = 6463;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Nogg's Gold Ring";
			Name2 = "Nogg's Gold Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25852;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Reedknot Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ReedknotRing : Item
	{
		public ReedknotRing() : base()
		{
			Id = 9622;
			Bonding = 1;
			SellPrice = 5665;
			AvailableClasses = 0x7FFF;
			Model = 14432;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Reedknot Ring";
			Name2 = "Reedknot Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22660;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 3;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Explorer's League Lodestar)
*
***************************************************************/

namespace Server.Items
{
	public class ExplorersLeagueLodestar : Item
	{
		public ExplorersLeagueLodestar() : base()
		{
			Id = 9627;
			Bonding = 1;
			SellPrice = 2542;
			AvailableClasses = 0x7FFF;
			Model = 11410;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			Name = "Explorer's League Lodestar";
			Name2 = "Explorer's League Lodestar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10170;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lifeblood Amulet)
*
***************************************************************/

namespace Server.Items
{
	public class LifebloodAmulet : Item
	{
		public LifebloodAmulet() : base()
		{
			Id = 9641;
			Bonding = 1;
			SellPrice = 13041;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Lifeblood Amulet";
			Name2 = "Lifeblood Amulet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52165;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			IqBonus = 5;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Band of the Great Tortoise)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheGreatTortoise : Item
	{
		public BandOfTheGreatTortoise() : base()
		{
			Id = 9642;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 2092;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Band of the Great Tortoise";
			Name2 = "Band of the Great Tortoise";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Thermotastic Egg Timer)
*
***************************************************************/

namespace Server.Items
{
	public class ThermotasticEggTimer : Item
	{
		public ThermotasticEggTimer() : base()
		{
			Id = 9644;
			Bonding = 1;
			SellPrice = 9885;
			AvailableClasses = 0x7FFF;
			Model = 18575;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			Name = "Thermotastic Egg Timer";
			Name2 = "Thermotastic Egg Timer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39540;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			AgilityBonus = 3;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Seedtime Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class SeedtimeHoop : Item
	{
		public SeedtimeHoop() : base()
		{
			Id = 9655;
			Bonding = 1;
			SellPrice = 7092;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Seedtime Hoop";
			Name2 = "Seedtime Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 4;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Greenweave Branch)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveBranch : Item
	{
		public GreenweaveBranch() : base()
		{
			Id = 9769;
			Bonding = 2;
			SellPrice = 1637;
			AvailableClasses = 0x7FFF;
			Model = 28023;
			ObjectClass = 4;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Greenweave Branch";
			Name2 = "Greenweave Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2014;
			BuyPrice = 6548;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Ivy Orb)
*
***************************************************************/

namespace Server.Items
{
	public class IvyOrb : Item
	{
		public IvyOrb() : base()
		{
			Id = 9800;
			Bonding = 2;
			SellPrice = 2027;
			AvailableClasses = 0x7FFF;
			Model = 27756;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Ivy Orb";
			Name2 = "Ivy Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2020;
			BuyPrice = 8110;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererSphere : Item
	{
		public SorcererSphere() : base()
		{
			Id = 9882;
			Bonding = 2;
			SellPrice = 6209;
			AvailableClasses = 0x7FFF;
			Model = 21603;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Sorcerer Sphere";
			Name2 = "Sorcerer Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2050;
			BuyPrice = 24836;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Royal Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalScepter : Item
	{
		public RoyalScepter() : base()
		{
			Id = 9914;
			Bonding = 2;
			SellPrice = 7557;
			AvailableClasses = 0x7FFF;
			Model = 18714;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Royal Scepter";
			Name2 = "Royal Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2056;
			BuyPrice = 30230;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Crystal)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersCrystal : Item
	{
		public AbjurersCrystal() : base()
		{
			Id = 9944;
			Bonding = 2;
			SellPrice = 8570;
			AvailableClasses = 0x7FFF;
			Model = 27801;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Abjurer's Crystal";
			Name2 = "Abjurer's Crystal";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2068;
			BuyPrice = 34283;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 2;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Simple Black Dress)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBlackDress : Item
	{
		public SimpleBlackDress() : base()
		{
			Id = 10053;
			SellPrice = 4499;
			AvailableClasses = 0x7FFF;
			Model = 19142;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Simple Black Dress";
			Name2 = "Simple Black Dress";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22497;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gnomeregan Band)
*
***************************************************************/

namespace Server.Items
{
	public class GnomereganBand : Item
	{
		public GnomereganBand() : base()
		{
			Id = 10298;
			Bonding = 1;
			SellPrice = 1243;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Gnomeregan Band";
			Name2 = "Gnomeregan Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3476;
			BuyPrice = 4975;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Gnomeregan Amulet)
*
***************************************************************/

namespace Server.Items
{
	public class GnomereganAmulet : Item
	{
		public GnomereganAmulet() : base()
		{
			Id = 10299;
			Bonding = 1;
			SellPrice = 3778;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Gnomeregan Amulet";
			Name2 = "Gnomeregan Amulet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3506;
			BuyPrice = 15112;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Chained Essence of Eranikus)
*
***************************************************************/

namespace Server.Items
{
	public class ChainedEssenceOfEranikus : Item
	{
		public ChainedEssenceOfEranikus() : base()
		{
			Id = 10455;
			Bonding = 1;
			SellPrice = 6464;
			AvailableClasses = 0x7FFF;
			Model = 6513;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Chained Essence of Eranikus";
			Name2 = "Chained Essence of Eranikus";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25859;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12766 , 0 , 0 , 900000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Torch of Retribution)
*
***************************************************************/

namespace Server.Items
{
	public class TorchOfRetribution : Item
	{
		public TorchOfRetribution() : base()
		{
			Id = 10515;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Description = "The flame never falters";
			Model = 19461;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Torch of Retribution";
			Name2 = "Torch of Retribution";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 500;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Sheath = 2;
			Flags = 128;
			SetSpell( 12534 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mindseye Circle)
*
***************************************************************/

namespace Server.Items
{
	public class MindseyeCircle : Item
	{
		public MindseyeCircle() : base()
		{
			Id = 10634;
			Bonding = 2;
			SellPrice = 10812;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Mindseye Circle";
			Name2 = "Mindseye Circle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43250;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			StaminaBonus = 5;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shard of Afrasa)
*
***************************************************************/

namespace Server.Items
{
	public class ShardOfAfrasa : Item
	{
		public ShardOfAfrasa() : base()
		{
			Id = 10659;
			Bonding = 1;
			SellPrice = 4662;
			AvailableClasses = 0x7FFF;
			Model = 2516;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			Name = "Shard of Afrasa";
			Name2 = "Shard of Afrasa";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18650;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 12732 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Skullspell Orb)
*
***************************************************************/

namespace Server.Items
{
	public class SkullspellOrb : Item
	{
		public SkullspellOrb() : base()
		{
			Id = 10708;
			Bonding = 1;
			SellPrice = 8982;
			AvailableClasses = 0x7FFF;
			Model = 19786;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			Name = "Skullspell Orb";
			Name2 = "Skullspell Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35930;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Pyrestone Orb)
*
***************************************************************/

namespace Server.Items
{
	public class PyrestoneOrb : Item
	{
		public PyrestoneOrb() : base()
		{
			Id = 10709;
			Bonding = 1;
			SellPrice = 10953;
			AvailableClasses = 0x7FFF;
			Model = 28291;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Pyrestone Orb";
			Name2 = "Pyrestone Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43814;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dragonclaw Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DragonclawRing : Item
	{
		public DragonclawRing() : base()
		{
			Id = 10710;
			Bonding = 1;
			SellPrice = 6130;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			Name = "Dragonclaw Ring";
			Name2 = "Dragonclaw Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24520;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			IqBonus = 4;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dragon's Blood Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class DragonsBloodNecklace : Item
	{
		public DragonsBloodNecklace() : base()
		{
			Id = 10711;
			Bonding = 1;
			SellPrice = 8377;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Dragon's Blood Necklace";
			Name2 = "Dragon's Blood Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 33510;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ring of Fortitude)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfFortitude : Item
	{
		public RingOfFortitude() : base()
		{
			Id = 10739;
			Bonding = 1;
			SellPrice = 5292;
			AvailableClasses = 0x7FFF;
			Model = 15422;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			Name = "Ring of Fortitude";
			Name2 = "Ring of Fortitude";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Glowing Eye of Mordresh)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingEyeOfMordresh : Item
	{
		public GlowingEyeOfMordresh() : base()
		{
			Id = 10769;
			Bonding = 1;
			SellPrice = 5277;
			AvailableClasses = 0x7FFF;
			Model = 19785;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Glowing Eye of Mordresh";
			Name2 = "Glowing Eye of Mordresh";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21110;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 11;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mordresh's Lifeless Skull)
*
***************************************************************/

namespace Server.Items
{
	public class MordreshsLifelessSkull : Item
	{
		public MordreshsLifelessSkull() : base()
		{
			Id = 10770;
			Bonding = 1;
			SellPrice = 7835;
			AvailableClasses = 0x7FFF;
			Model = 19786;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Mordresh's Lifeless Skull";
			Name2 = "Mordresh's Lifeless Skull";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31340;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Necklace of Sanctuary)
*
***************************************************************/

namespace Server.Items
{
	public class NecklaceOfSanctuary : Item
	{
		public NecklaceOfSanctuary() : base()
		{
			Id = 10778;
			Bonding = 1;
			SellPrice = 16930;
			AvailableClasses = 0x7FFF;
			Model = 1399;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Necklace of Sanctuary";
			Name2 = "Necklace of Sanctuary";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67720;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Demon's Blood)
*
***************************************************************/

namespace Server.Items
{
	public class DemonsBlood : Item
	{
		public DemonsBlood() : base()
		{
			Id = 10779;
			Bonding = 1;
			SellPrice = 8807;
			AvailableClasses = 0x7FFF;
			Model = 16452;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Demon's Blood";
			Name2 = "Demon's Blood";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35230;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 12956 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Mark of Hakkar)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfHakkar : Item
	{
		public MarkOfHakkar() : base()
		{
			Id = 10780;
			Bonding = 1;
			SellPrice = 5542;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Mark of Hakkar";
			Name2 = "Mark of Hakkar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StrBonus = 7;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Drakeclaw Band)
*
***************************************************************/

namespace Server.Items
{
	public class DrakeclawBand : Item
	{
		public DrakeclawBand() : base()
		{
			Id = 10795;
			Bonding = 1;
			SellPrice = 5542;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Drakeclaw Band";
			Name2 = "Drakeclaw Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3486;
			BuyPrice = 22170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SetSpell( 7517 , 1 , 0 , 900000 , 0 , 30000 );
		}
	}
}


/**************************************************************
*
*				(Drakestone)
*
***************************************************************/

namespace Server.Items
{
	public class Drakestone : Item
	{
		public Drakestone() : base()
		{
			Id = 10796;
			Bonding = 1;
			SellPrice = 8982;
			AvailableClasses = 0x7FFF;
			Model = 21602;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Drakestone";
			Name2 = "Drakestone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 2080;
			BuyPrice = 35930;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 9397 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Amberglow Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class AmberglowTalisman : Item
	{
		public AmberglowTalisman() : base()
		{
			Id = 10824;
			Bonding = 1;
			SellPrice = 5930;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Amberglow Talisman";
			Name2 = "Amberglow Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23720;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			AgilityBonus = 1;
			IqBonus = 10;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dragon's Eye)
*
***************************************************************/

namespace Server.Items
{
	public class DragonsEye : Item
	{
		public DragonsEye() : base()
		{
			Id = 10829;
			Bonding = 1;
			SellPrice = 10680;
			AvailableClasses = 0x7FFF;
			Model = 6494;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Dragon's Eye";
			Name2 = "Dragon's Eye";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42720;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 6;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Archaedic Stone)
*
***************************************************************/

namespace Server.Items
{
	public class ArchaedicStone : Item
	{
		public ArchaedicStone() : base()
		{
			Id = 11118;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 10795;
			AvailableClasses = 0x7FFF;
			Model = 20769;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Archaedic Stone";
			Name2 = "Archaedic Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3484;
			BuyPrice = 43180;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Carrot on a Stick)
*
***************************************************************/

namespace Server.Items
{
	public class CarrotOnAStick : Item
	{
		public CarrotOnAStick() : base()
		{
			Id = 11122;
			Bonding = 1;
			SellPrice = 7162;
			AvailableClasses = 0x7FFF;
			Model = 21115;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Carrot on a Stick";
			Name2 = "Carrot on a Stick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28650;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 13587 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Deprecated Silver Totem of Aquementas)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedSilverTotemOfAquementas : Item
	{
		public DeprecatedSilverTotemOfAquementas() : base()
		{
			Id = 11170;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 21373;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Deprecated Silver Totem of Aquementas";
			Name2 = "Deprecated Silver Totem of Aquementas";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 14247 , 0 , 0 , 45000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mindburst Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class MindburstMedallion : Item
	{
		public MindburstMedallion() : base()
		{
			Id = 11196;
			Bonding = 1;
			SellPrice = 16875;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			Name = "Mindburst Medallion";
			Name2 = "Mindburst Medallion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67500;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 5;
			SpiritBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Orb of Lorica)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfLorica : Item
	{
		public OrbOfLorica() : base()
		{
			Id = 11262;
			Bonding = 1;
			SellPrice = 8142;
			AvailableClasses = 0x7FFF;
			Model = 28337;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			Name = "Orb of Lorica";
			Name2 = "Orb of Lorica";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32570;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			IqBonus = 11;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Uther's Strength)
*
***************************************************************/

namespace Server.Items
{
	public class UthersStrength : Item
	{
		public UthersStrength() : base()
		{
			Id = 11302;
			Bonding = 1;
			SellPrice = 7130;
			AvailableClasses = 0x7FFF;
			Model = 6515;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Uther's Strength";
			Name2 = "Uther's Strength";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28520;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SetSpell( 8397 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Silver Totem of Aquementas)
*
***************************************************************/

namespace Server.Items
{
	public class SilverTotemOfAquementas : Item
	{
		public SilverTotemOfAquementas() : base()
		{
			Id = 11522;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 21608;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Silver Totem of Aquementas";
			Name2 = "Silver Totem of Aquementas";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 14247 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Enthralled Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class EnthralledSphere : Item
	{
		public EnthralledSphere() : base()
		{
			Id = 11625;
			Bonding = 1;
			SellPrice = 10452;
			AvailableClasses = 0x7FFF;
			Model = 21595;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Enthralled Sphere";
			Name2 = "Enthralled Sphere";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41810;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SpiritBonus = 14;
			IqBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Naglering)
*
***************************************************************/

namespace Server.Items
{
	public class Naglering : Item
	{
		public Naglering() : base()
		{
			Id = 11669;
			Resistance[6] = 10;
			Bonding = 1;
			SellPrice = 17157;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Naglering";
			Name2 = "Naglering";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 15438 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Verek's Collar)
*
***************************************************************/

namespace Server.Items
{
	public class VereksCollar : Item
	{
		public VereksCollar() : base()
		{
			Id = 11755;
			Bonding = 1;
			SellPrice = 14627;
			AvailableClasses = 0x7FFF;
			Model = 21725;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Verek's Collar";
			Name2 = "Verek's Collar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58510;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , -1 );
			StrBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Force of Will)
*
***************************************************************/

namespace Server.Items
{
	public class ForceOfWill : Item
	{
		public ForceOfWill() : base()
		{
			Id = 11810;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 19767;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Force of Will";
			Name2 = "Force of Will";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15594 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Smoking Heart of the Mountain)
*
***************************************************************/

namespace Server.Items
{
	public class SmokingHeartOfTheMountain : Item
	{
		public SmokingHeartOfTheMountain() : base()
		{
			Id = 11811;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 21804;
			Resistance[2] = 7;
			Resistance[4] = 7;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Smoking Heart of the Mountain";
			Name2 = "Smoking Heart of the Mountain";
			Resistance[3] = 7;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Hand of Justice)
*
***************************************************************/

namespace Server.Items
{
	public class HandOfJustice : Item
	{
		public HandOfJustice() : base()
		{
			Id = 11815;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 6337;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Hand of Justice";
			Name2 = "Hand of Justice";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15600 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Second Wind)
*
***************************************************************/

namespace Server.Items
{
	public class SecondWind : Item
	{
		public SecondWind() : base()
		{
			Id = 11819;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 18725;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Second Wind";
			Name2 = "Second Wind";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15604 , 0 , 0 , 900000 , 30 , 180000 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cyclopean Band)
*
***************************************************************/

namespace Server.Items
{
	public class CyclopeanBand : Item
	{
		public CyclopeanBand() : base()
		{
			Id = 11824;
			Bonding = 1;
			SellPrice = 13657;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Cyclopean Band";
			Name2 = "Cyclopean Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 15;
			StrBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Burst of Knowledge)
*
***************************************************************/

namespace Server.Items
{
	public class BurstOfKnowledge : Item
	{
		public BurstOfKnowledge() : base()
		{
			Id = 11832;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 19764;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Burst of Knowledge";
			Name2 = "Burst of Knowledge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15646 , 0 , 0 , 900000 , 28 , 300000 );
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tork Wrench)
*
***************************************************************/

namespace Server.Items
{
	public class TorkWrench : Item
	{
		public TorkWrench() : base()
		{
			Id = 11855;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 782;
			AvailableClasses = 0x7FFF;
			Model = 7494;
			ObjectClass = 4;
			SubClass = 0;
			Level = 19;
			Name = "Tork Wrench";
			Name2 = "Tork Wrench";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3130;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 3;
			StrBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Jademoon Orb)
*
***************************************************************/

namespace Server.Items
{
	public class JademoonOrb : Item
	{
		public JademoonOrb() : base()
		{
			Id = 11859;
			Bonding = 1;
			SellPrice = 7135;
			AvailableClasses = 0x7FFF;
			Model = 21853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			Name = "Jademoon Orb";
			Name2 = "Jademoon Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28540;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 3;
			SpiritBonus = 4;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(White Bone Band)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteBoneBand : Item
	{
		public WhiteBoneBand() : base()
		{
			Id = 11862;
			Bonding = 1;
			SellPrice = 7042;
			AvailableClasses = 0x7FFF;
			Model = 6486;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			Name = "White Bone Band";
			Name2 = "White Bone Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SetSpell( 14027 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Choking Band)
*
***************************************************************/

namespace Server.Items
{
	public class ChokingBand : Item
	{
		public ChokingBand() : base()
		{
			Id = 11868;
			Bonding = 1;
			SellPrice = 6542;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			Name = "Choking Band";
			Name2 = "Choking Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Sha'ni's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ShanisRing : Item
	{
		public ShanisRing() : base()
		{
			Id = 11869;
			Bonding = 1;
			SellPrice = 6542;
			AvailableClasses = 0x7FFF;
			Model = 9849;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			Name = "Sha'ni's Ring";
			Name2 = "Sha'ni's Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Oblivion Orb)
*
***************************************************************/

namespace Server.Items
{
	public class OblivionOrb : Item
	{
		public OblivionOrb() : base()
		{
			Id = 11870;
			Bonding = 1;
			SellPrice = 10287;
			AvailableClasses = 0x7FFF;
			Model = 28226;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			Name = "Oblivion Orb";
			Name2 = "Oblivion Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41150;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 4;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Spirit of Aquementas)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritOfAquementas : Item
	{
		public SpiritOfAquementas() : base()
		{
			Id = 11904;
			Bonding = 1;
			SellPrice = 13815;
			AvailableClasses = 0x7FFF;
			Model = 21936;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			Name = "Spirit of Aquementas";
			Name2 = "Spirit of Aquementas";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55260;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Linken's Boomerang)
*
***************************************************************/

namespace Server.Items
{
	public class LinkensBoomerang : Item
	{
		public LinkensBoomerang() : base()
		{
			Id = 11905;
			Bonding = 1;
			SellPrice = 6203;
			AvailableClasses = 0x7FFF;
			Model = 22753;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			Name = "Linken's Boomerang";
			Name2 = "Linken's Boomerang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24813;
			InventoryType = InventoryTypes.Trinket1;
			Delay = 500;
			Stackable = 1;
			Material = 2;
			Flags = 64;
			SetSpell( 15712 , 0 , 0 , 180000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Thaurissan's Royal Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class ThaurissansRoyalScepter : Item
	{
		public ThaurissansRoyalScepter() : base()
		{
			Id = 11928;
			Bonding = 1;
			SellPrice = 22045;
			AvailableClasses = 0x7FFF;
			Model = 21962;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Thaurissan's Royal Scepter";
			Name2 = "Thaurissan's Royal Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88181;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 3;
			IqBonus = 15;
			SpiritBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Imperial Jewel)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialJewel : Item
	{
		public ImperialJewel() : base()
		{
			Id = 11933;
			Bonding = 1;
			SellPrice = 19646;
			AvailableClasses = 0x7FFF;
			Model = 28784;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Imperial Jewel";
			Name2 = "Imperial Jewel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 78585;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 15807 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Emperor's Seal)
*
***************************************************************/

namespace Server.Items
{
	public class EmperorsSeal : Item
	{
		public EmperorsSeal() : base()
		{
			Id = 11934;
			Resistance[6] = 6;
			Bonding = 1;
			SellPrice = 19921;
			AvailableClasses = 0x7FFF;
			Model = 28733;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 55;
			Name = "Emperor's Seal";
			Name2 = "Emperor's Seal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3256;
			BuyPrice = 79685;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Magmus Stone)
*
***************************************************************/

namespace Server.Items
{
	public class MagmusStone : Item
	{
		public MagmusStone() : base()
		{
			Id = 11935;
			Bonding = 1;
			SellPrice = 13162;
			AvailableClasses = 0x7FFF;
			Model = 28795;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Magmus Stone";
			Name2 = "Magmus Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52650;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			IqBonus = 4;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronRing : Item
	{
		public DarkIronRing() : base()
		{
			Id = 11945;
			Bonding = 1;
			SellPrice = 6592;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Dark Iron Ring";
			Name2 = "Dark Iron Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3484;
			BuyPrice = 26370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
		}
	}
}


/**************************************************************
*
*				(Fire Opal Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class FireOpalNecklace : Item
	{
		public FireOpalNecklace() : base()
		{
			Id = 11946;
			Bonding = 1;
			SellPrice = 7912;
			AvailableClasses = 0x7FFF;
			Model = 9854;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Fire Opal Necklace";
			Name2 = "Fire Opal Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3513;
			BuyPrice = 31650;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Quartz Ring)
*
***************************************************************/

namespace Server.Items
{
	public class QuartzRing : Item
	{
		public QuartzRing() : base()
		{
			Id = 11965;
			Bonding = 2;
			SellPrice = 464;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Quartz Ring";
			Name2 = "Quartz Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3295;
			BuyPrice = 1858;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Zircon Band)
*
***************************************************************/

namespace Server.Items
{
	public class ZirconBand : Item
	{
		public ZirconBand() : base()
		{
			Id = 11967;
			Bonding = 2;
			SellPrice = 1087;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Zircon Band";
			Name2 = "Zircon Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3296;
			BuyPrice = 4351;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Amber Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class AmberHoop : Item
	{
		public AmberHoop() : base()
		{
			Id = 11968;
			Bonding = 2;
			SellPrice = 997;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Amber Hoop";
			Name2 = "Amber Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3297;
			BuyPrice = 3988;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Jacinth Circle)
*
***************************************************************/

namespace Server.Items
{
	public class JacinthCircle : Item
	{
		public JacinthCircle() : base()
		{
			Id = 11969;
			Bonding = 2;
			SellPrice = 1721;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Jacinth Circle";
			Name2 = "Jacinth Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3298;
			BuyPrice = 6887;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Spinel Ring)
*
***************************************************************/

namespace Server.Items
{
	public class SpinelRing : Item
	{
		public SpinelRing() : base()
		{
			Id = 11970;
			Bonding = 2;
			SellPrice = 1710;
			AvailableClasses = 0x7FFF;
			Model = 9842;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Spinel Ring";
			Name2 = "Spinel Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3300;
			BuyPrice = 6841;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Amethyst Band)
*
***************************************************************/

namespace Server.Items
{
	public class AmethystBand : Item
	{
		public AmethystBand() : base()
		{
			Id = 11971;
			Bonding = 2;
			SellPrice = 3969;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Amethyst Band";
			Name2 = "Amethyst Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3301;
			BuyPrice = 15876;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Carnelian Loop)
*
***************************************************************/

namespace Server.Items
{
	public class CarnelianLoop : Item
	{
		public CarnelianLoop() : base()
		{
			Id = 11972;
			Bonding = 2;
			SellPrice = 4649;
			AvailableClasses = 0x7FFF;
			Model = 4284;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Carnelian Loop";
			Name2 = "Carnelian Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3302;
			BuyPrice = 18597;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Hematite Link)
*
***************************************************************/

namespace Server.Items
{
	public class HematiteLink : Item
	{
		public HematiteLink() : base()
		{
			Id = 11973;
			Bonding = 2;
			SellPrice = 3971;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Hematite Link";
			Name2 = "Hematite Link";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3303;
			BuyPrice = 15887;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Aquamarine Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AquamarineRing : Item
	{
		public AquamarineRing() : base()
		{
			Id = 11974;
			Bonding = 2;
			SellPrice = 4971;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Aquamarine Ring";
			Name2 = "Aquamarine Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3304;
			BuyPrice = 19885;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Topaz Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TopazRing : Item
	{
		public TopazRing() : base()
		{
			Id = 11975;
			Bonding = 2;
			SellPrice = 4739;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 49;
			ReqLevel = 44;
			Name = "Topaz Ring";
			Name2 = "Topaz Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3305;
			BuyPrice = 18958;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Sardonyx Knuckle)
*
***************************************************************/

namespace Server.Items
{
	public class SardonyxKnuckle : Item
	{
		public SardonyxKnuckle() : base()
		{
			Id = 11976;
			Bonding = 2;
			SellPrice = 7778;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Sardonyx Knuckle";
			Name2 = "Sardonyx Knuckle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3306;
			BuyPrice = 31112;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Serpentine Loop)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentineLoop : Item
	{
		public SerpentineLoop() : base()
		{
			Id = 11977;
			Bonding = 2;
			SellPrice = 7896;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Serpentine Loop";
			Name2 = "Serpentine Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3307;
			BuyPrice = 31587;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Jasper Link)
*
***************************************************************/

namespace Server.Items
{
	public class JasperLink : Item
	{
		public JasperLink() : base()
		{
			Id = 11978;
			Bonding = 2;
			SellPrice = 7414;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Jasper Link";
			Name2 = "Jasper Link";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3308;
			BuyPrice = 29658;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Perdiot Circle)
*
***************************************************************/

namespace Server.Items
{
	public class PerdiotCircle : Item
	{
		public PerdiotCircle() : base()
		{
			Id = 11979;
			Bonding = 2;
			SellPrice = 7471;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Perdiot Circle";
			Name2 = "Perdiot Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3309;
			BuyPrice = 29885;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Opal Ring)
*
***************************************************************/

namespace Server.Items
{
	public class OpalRing : Item
	{
		public OpalRing() : base()
		{
			Id = 11980;
			Bonding = 2;
			SellPrice = 10539;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "Opal Ring";
			Name2 = "Opal Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3310;
			BuyPrice = 42158;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lead Band)
*
***************************************************************/

namespace Server.Items
{
	public class LeadBand : Item
	{
		public LeadBand() : base()
		{
			Id = 11981;
			Bonding = 2;
			SellPrice = 496;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Lead Band";
			Name2 = "Lead Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3241;
			BuyPrice = 1985;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Viridian Band)
*
***************************************************************/

namespace Server.Items
{
	public class ViridianBand11982 : Item
	{
		public ViridianBand11982() : base()
		{
			Id = 11982;
			Bonding = 2;
			SellPrice = 1062;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Viridian Band";
			Name2 = "Viridian Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3242;
			BuyPrice = 4251;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chrome Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ChromeRing : Item
	{
		public ChromeRing() : base()
		{
			Id = 11983;
			Bonding = 2;
			SellPrice = 1130;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Chrome Ring";
			Name2 = "Chrome Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3243;
			BuyPrice = 4521;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cobalt Ring)
*
***************************************************************/

namespace Server.Items
{
	public class CobaltRing : Item
	{
		public CobaltRing() : base()
		{
			Id = 11984;
			Bonding = 2;
			SellPrice = 2189;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Cobalt Ring";
			Name2 = "Cobalt Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3244;
			BuyPrice = 8756;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cerulean Ring)
*
***************************************************************/

namespace Server.Items
{
	public class CeruleanRing11985 : Item
	{
		public CeruleanRing11985() : base()
		{
			Id = 11985;
			Bonding = 2;
			SellPrice = 2144;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Cerulean Ring";
			Name2 = "Cerulean Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3246;
			BuyPrice = 8576;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thallium Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class ThalliumHoop : Item
	{
		public ThalliumHoop() : base()
		{
			Id = 11986;
			Bonding = 2;
			SellPrice = 1745;
			AvailableClasses = 0x7FFF;
			Model = 9849;
			ObjectClass = 4;
			SubClass = 0;
			Level = 39;
			ReqLevel = 34;
			Name = "Thallium Hoop";
			Name2 = "Thallium Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3247;
			BuyPrice = 6981;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Iridium Circle)
*
***************************************************************/

namespace Server.Items
{
	public class IridiumCircle : Item
	{
		public IridiumCircle() : base()
		{
			Id = 11987;
			Bonding = 2;
			SellPrice = 2885;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Iridium Circle";
			Name2 = "Iridium Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3249;
			BuyPrice = 11543;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tellurium Band)
*
***************************************************************/

namespace Server.Items
{
	public class TelluriumBand : Item
	{
		public TelluriumBand() : base()
		{
			Id = 11988;
			Bonding = 2;
			SellPrice = 7113;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Tellurium Band";
			Name2 = "Tellurium Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3250;
			BuyPrice = 28455;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Vanadium Loop)
*
***************************************************************/

namespace Server.Items
{
	public class VanadiumLoop : Item
	{
		public VanadiumLoop() : base()
		{
			Id = 11989;
			Bonding = 2;
			SellPrice = 7471;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Vanadium Loop";
			Name2 = "Vanadium Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3251;
			BuyPrice = 29887;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Selenium Loop)
*
***************************************************************/

namespace Server.Items
{
	public class SeleniumLoop : Item
	{
		public SeleniumLoop() : base()
		{
			Id = 11990;
			Bonding = 2;
			SellPrice = 8306;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Selenium Loop";
			Name2 = "Selenium Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3253;
			BuyPrice = 33225;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Quicksilver Ring)
*
***************************************************************/

namespace Server.Items
{
	public class QuicksilverRing11991 : Item
	{
		public QuicksilverRing11991() : base()
		{
			Id = 11991;
			Bonding = 2;
			SellPrice = 6317;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Quicksilver Ring";
			Name2 = "Quicksilver Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3254;
			BuyPrice = 25268;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Vermilion Band)
*
***************************************************************/

namespace Server.Items
{
	public class VermilionBand11992 : Item
	{
		public VermilionBand11992() : base()
		{
			Id = 11992;
			Bonding = 2;
			SellPrice = 7396;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Vermilion Band";
			Name2 = "Vermilion Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3255;
			BuyPrice = 29585;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Clay Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ClayRing : Item
	{
		public ClayRing() : base()
		{
			Id = 11993;
			Bonding = 2;
			SellPrice = 874;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Clay Ring";
			Name2 = "Clay Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3259;
			BuyPrice = 3498;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Coral Band)
*
***************************************************************/

namespace Server.Items
{
	public class CoralBand11994 : Item
	{
		public CoralBand11994() : base()
		{
			Id = 11994;
			Bonding = 2;
			SellPrice = 1312;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Coral Band";
			Name2 = "Coral Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3260;
			BuyPrice = 5251;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ivory Band)
*
***************************************************************/

namespace Server.Items
{
	public class IvoryBand11995 : Item
	{
		public IvoryBand11995() : base()
		{
			Id = 11995;
			Bonding = 2;
			SellPrice = 914;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Ivory Band";
			Name2 = "Ivory Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3261;
			BuyPrice = 3658;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Basalt Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BasaltRing : Item
	{
		public BasaltRing() : base()
		{
			Id = 11996;
			Bonding = 2;
			SellPrice = 1713;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Basalt Ring";
			Name2 = "Basalt Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3263;
			BuyPrice = 6854;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Greenstone Circle)
*
***************************************************************/

namespace Server.Items
{
	public class GreenstoneCircle : Item
	{
		public GreenstoneCircle() : base()
		{
			Id = 11997;
			Bonding = 2;
			SellPrice = 6469;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Greenstone Circle";
			Name2 = "Greenstone Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3264;
			BuyPrice = 25876;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Jet Loop)
*
***************************************************************/

namespace Server.Items
{
	public class JetLoop : Item
	{
		public JetLoop() : base()
		{
			Id = 11998;
			Bonding = 2;
			SellPrice = 2896;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			ReqLevel = 37;
			Name = "Jet Loop";
			Name2 = "Jet Loop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3265;
			BuyPrice = 11587;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lodestone Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class LodestoneHoop : Item
	{
		public LodestoneHoop() : base()
		{
			Id = 11999;
			Bonding = 2;
			SellPrice = 5538;
			AvailableClasses = 0x7FFF;
			Model = 4284;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Lodestone Hoop";
			Name2 = "Lodestone Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3267;
			BuyPrice = 22155;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Onyx Ring)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxRing12001 : Item
	{
		public OnyxRing12001() : base()
		{
			Id = 12001;
			Bonding = 2;
			SellPrice = 4971;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Onyx Ring";
			Name2 = "Onyx Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3268;
			BuyPrice = 19885;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Marble Circle)
*
***************************************************************/

namespace Server.Items
{
	public class MarbleCircle : Item
	{
		public MarbleCircle() : base()
		{
			Id = 12002;
			Bonding = 2;
			SellPrice = 6322;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Marble Circle";
			Name2 = "Marble Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3269;
			BuyPrice = 25289;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Obsidian Band)
*
***************************************************************/

namespace Server.Items
{
	public class ObsidianBand : Item
	{
		public ObsidianBand() : base()
		{
			Id = 12004;
			Bonding = 2;
			SellPrice = 9163;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Obsidian Band";
			Name2 = "Obsidian Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3271;
			BuyPrice = 36652;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Granite Ring)
*
***************************************************************/

namespace Server.Items
{
	public class GraniteRing : Item
	{
		public GraniteRing() : base()
		{
			Id = 12005;
			Bonding = 2;
			SellPrice = 8813;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Granite Ring";
			Name2 = "Granite Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3272;
			BuyPrice = 35254;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Meadow Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MeadowRing : Item
	{
		public MeadowRing() : base()
		{
			Id = 12006;
			Bonding = 2;
			SellPrice = 1064;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Meadow Ring";
			Name2 = "Meadow Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2123;
			BuyPrice = 4258;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Prairie Ring)
*
***************************************************************/

namespace Server.Items
{
	public class PrairieRing : Item
	{
		public PrairieRing() : base()
		{
			Id = 12007;
			Bonding = 2;
			SellPrice = 1064;
			AvailableClasses = 0x7FFF;
			Model = 4284;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Prairie Ring";
			Name2 = "Prairie Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2124;
			BuyPrice = 4258;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Savannah Ring)
*
***************************************************************/

namespace Server.Items
{
	public class SavannahRing : Item
	{
		public SavannahRing() : base()
		{
			Id = 12008;
			Bonding = 2;
			SellPrice = 895;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Savannah Ring";
			Name2 = "Savannah Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2125;
			BuyPrice = 3581;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tundra Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TundraRing : Item
	{
		public TundraRing() : base()
		{
			Id = 12009;
			Bonding = 2;
			SellPrice = 2174;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Tundra Ring";
			Name2 = "Tundra Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2126;
			BuyPrice = 8698;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fen Ring)
*
***************************************************************/

namespace Server.Items
{
	public class FenRing : Item
	{
		public FenRing() : base()
		{
			Id = 12010;
			Bonding = 2;
			SellPrice = 2469;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Fen Ring";
			Name2 = "Fen Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2128;
			BuyPrice = 9876;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Forest Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class ForestHoop : Item
	{
		public ForestHoop() : base()
		{
			Id = 12011;
			Bonding = 2;
			SellPrice = 4649;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Forest Hoop";
			Name2 = "Forest Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2129;
			BuyPrice = 18599;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Marsh Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MarshRing : Item
	{
		public MarshRing() : base()
		{
			Id = 12012;
			Bonding = 2;
			SellPrice = 2463;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Marsh Ring";
			Name2 = "Marsh Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2130;
			BuyPrice = 9853;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Desert Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DesertRing : Item
	{
		public DesertRing() : base()
		{
			Id = 12013;
			Bonding = 2;
			SellPrice = 4649;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 49;
			ReqLevel = 44;
			Name = "Desert Ring";
			Name2 = "Desert Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2132;
			BuyPrice = 18599;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Arctic Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ArcticRing : Item
	{
		public ArcticRing() : base()
		{
			Id = 12014;
			Bonding = 2;
			SellPrice = 6289;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Arctic Ring";
			Name2 = "Arctic Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2133;
			BuyPrice = 25158;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Swamp Ring)
*
***************************************************************/

namespace Server.Items
{
	public class SwampRing : Item
	{
		public SwampRing() : base()
		{
			Id = 12015;
			Bonding = 2;
			SellPrice = 8811;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Swamp Ring";
			Name2 = "Swamp Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2134;
			BuyPrice = 35245;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Jungle Ring)
*
***************************************************************/

namespace Server.Items
{
	public class JungleRing : Item
	{
		public JungleRing() : base()
		{
			Id = 12016;
			Bonding = 2;
			SellPrice = 7781;
			AvailableClasses = 0x7FFF;
			Model = 9847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Jungle Ring";
			Name2 = "Jungle Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2136;
			BuyPrice = 31125;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Prismatic Band)
*
***************************************************************/

namespace Server.Items
{
	public class PrismaticBand : Item
	{
		public PrismaticBand() : base()
		{
			Id = 12017;
			Bonding = 2;
			SellPrice = 8963;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Prismatic Band";
			Name2 = "Prismatic Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3461;
			BuyPrice = 35853;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cerulean Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class CeruleanTalisman12019 : Item
	{
		public CeruleanTalisman12019() : base()
		{
			Id = 12019;
			Bonding = 2;
			SellPrice = 4220;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			ReqLevel = 27;
			Name = "Cerulean Talisman";
			Name2 = "Cerulean Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2030;
			BuyPrice = 16881;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Thallium Choker)
*
***************************************************************/

namespace Server.Items
{
	public class ThalliumChoker : Item
	{
		public ThalliumChoker() : base()
		{
			Id = 12020;
			Bonding = 2;
			SellPrice = 3969;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Thallium Choker";
			Name2 = "Thallium Choker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2036;
			BuyPrice = 15878;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Iridium Chain)
*
***************************************************************/

namespace Server.Items
{
	public class IridiumChain : Item
	{
		public IridiumChain() : base()
		{
			Id = 12022;
			Bonding = 2;
			SellPrice = 4718;
			AvailableClasses = 0x7FFF;
			Model = 9658;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Iridium Chain";
			Name2 = "Iridium Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2048;
			BuyPrice = 18875;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Tellurium Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TelluriumNecklace : Item
	{
		public TelluriumNecklace() : base()
		{
			Id = 12023;
			Bonding = 2;
			SellPrice = 4971;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Tellurium Necklace";
			Name2 = "Tellurium Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2054;
			BuyPrice = 19885;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Vanadium Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class VanadiumTalisman : Item
	{
		public VanadiumTalisman() : base()
		{
			Id = 12024;
			Bonding = 2;
			SellPrice = 5396;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Vanadium Talisman";
			Name2 = "Vanadium Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2066;
			BuyPrice = 21587;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Selenium Chain)
*
***************************************************************/

namespace Server.Items
{
	public class SeleniumChain : Item
	{
		public SeleniumChain() : base()
		{
			Id = 12025;
			Bonding = 2;
			SellPrice = 5282;
			AvailableClasses = 0x7FFF;
			Model = 9852;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Selenium Chain";
			Name2 = "Selenium Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2072;
			BuyPrice = 21130;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Quicksilver Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class QuicksilverPendant : Item
	{
		public QuicksilverPendant() : base()
		{
			Id = 12026;
			Bonding = 2;
			SellPrice = 7757;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Quicksilver Pendant";
			Name2 = "Quicksilver Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2084;
			BuyPrice = 31030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Vermilion Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class VermilionNecklace12027 : Item
	{
		public VermilionNecklace12027() : base()
		{
			Id = 12027;
			Bonding = 2;
			SellPrice = 6257;
			AvailableClasses = 0x7FFF;
			Model = 9858;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Vermilion Necklace";
			Name2 = "Vermilion Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2090;
			BuyPrice = 25030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Basalt Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class BasaltNecklace : Item
	{
		public BasaltNecklace() : base()
		{
			Id = 12028;
			Bonding = 2;
			SellPrice = 4007;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			ReqLevel = 27;
			Name = "Basalt Necklace";
			Name2 = "Basalt Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3281;
			BuyPrice = 16030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Greenstone Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class GreenstoneTalisman : Item
	{
		public GreenstoneTalisman() : base()
		{
			Id = 12029;
			Bonding = 2;
			SellPrice = 5395;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Greenstone Talisman";
			Name2 = "Greenstone Talisman";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3282;
			BuyPrice = 21581;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Jet Chain)
*
***************************************************************/

namespace Server.Items
{
	public class JetChain : Item
	{
		public JetChain() : base()
		{
			Id = 12030;
			Bonding = 2;
			SellPrice = 7143;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 39;
			ReqLevel = 34;
			Name = "Jet Chain";
			Name2 = "Jet Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3283;
			BuyPrice = 28574;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Lodestone Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class LodestoneNecklace : Item
	{
		public LodestoneNecklace() : base()
		{
			Id = 12031;
			Bonding = 2;
			SellPrice = 7894;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Lodestone Necklace";
			Name2 = "Lodestone Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3285;
			BuyPrice = 31578;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Onyx Choker)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxChoker12032 : Item
	{
		public OnyxChoker12032() : base()
		{
			Id = 12032;
			Bonding = 2;
			SellPrice = 5396;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Onyx Choker";
			Name2 = "Onyx Choker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3286;
			BuyPrice = 21587;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Marble Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class MarbleNecklace : Item
	{
		public MarbleNecklace() : base()
		{
			Id = 12034;
			Bonding = 2;
			SellPrice = 5012;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Marble Necklace";
			Name2 = "Marble Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3288;
			BuyPrice = 20050;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Obsidian Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ObsidianPendant : Item
	{
		public ObsidianPendant() : base()
		{
			Id = 12035;
			Bonding = 2;
			SellPrice = 5513;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Obsidian Pendant";
			Name2 = "Obsidian Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3289;
			BuyPrice = 22053;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Granite Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class GraniteNecklace : Item
	{
		public GraniteNecklace() : base()
		{
			Id = 12036;
			Bonding = 2;
			SellPrice = 5982;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Granite Necklace";
			Name2 = "Granite Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3291;
			BuyPrice = 23930;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Lagrave's Seal)
*
***************************************************************/

namespace Server.Items
{
	public class LagravesSeal : Item
	{
		public LagravesSeal() : base()
		{
			Id = 12038;
			Bonding = 1;
			SellPrice = 9092;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			Name = "Lagrave's Seal";
			Name2 = "Lagrave's Seal";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36370;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			IqBonus = 7;
			StaminaBonus = 7;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Tundra Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TundraNecklace : Item
	{
		public TundraNecklace() : base()
		{
			Id = 12039;
			Bonding = 2;
			SellPrice = 4224;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Tundra Necklace";
			Name2 = "Tundra Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3539;
			BuyPrice = 16899;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Forest Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ForestPendant : Item
	{
		public ForestPendant() : base()
		{
			Id = 12040;
			Bonding = 2;
			SellPrice = 4164;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Forest Pendant";
			Name2 = "Forest Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3541;
			BuyPrice = 16658;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Marsh Chain)
*
***************************************************************/

namespace Server.Items
{
	public class MarshChain : Item
	{
		public MarshChain() : base()
		{
			Id = 12042;
			Bonding = 2;
			SellPrice = 4749;
			AvailableClasses = 0x7FFF;
			Model = 9852;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			ReqLevel = 37;
			Name = "Marsh Chain";
			Name2 = "Marsh Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3542;
			BuyPrice = 18997;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Desert Choker)
*
***************************************************************/

namespace Server.Items
{
	public class DesertChoker : Item
	{
		public DesertChoker() : base()
		{
			Id = 12043;
			Bonding = 2;
			SellPrice = 5396;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Desert Choker";
			Name2 = "Desert Choker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3544;
			BuyPrice = 21587;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Arctic Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ArcticPendant : Item
	{
		public ArcticPendant() : base()
		{
			Id = 12044;
			Bonding = 2;
			SellPrice = 5145;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Arctic Pendant";
			Name2 = "Arctic Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3545;
			BuyPrice = 20581;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Swamp Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class SwampPendant : Item
	{
		public SwampPendant() : base()
		{
			Id = 12045;
			Bonding = 2;
			SellPrice = 7767;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Swamp Pendant";
			Name2 = "Swamp Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3547;
			BuyPrice = 31068;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Jungle Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class JungleNecklace : Item
	{
		public JungleNecklace() : base()
		{
			Id = 12046;
			Bonding = 2;
			SellPrice = 5757;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Jungle Necklace";
			Name2 = "Jungle Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3548;
			BuyPrice = 23030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Spectral Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class SpectralNecklace : Item
	{
		public SpectralNecklace() : base()
		{
			Id = 12047;
			Bonding = 2;
			SellPrice = 4996;
			AvailableClasses = 0x7FFF;
			Model = 9852;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Spectral Necklace";
			Name2 = "Spectral Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3463;
			BuyPrice = 19987;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Prismatic Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class PrismaticPendant : Item
	{
		public PrismaticPendant() : base()
		{
			Id = 12048;
			Bonding = 2;
			SellPrice = 6507;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Prismatic Pendant";
			Name2 = "Prismatic Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3462;
			BuyPrice = 26030;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Ring of the Moon)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheMoon : Item
	{
		public RingOfTheMoon() : base()
		{
			Id = 12052;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 21;
			ReqLevel = 16;
			Name = "Ring of the Moon";
			Name2 = "Ring of the Moon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3350;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StrBonus = 1;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Volcanic Rock Ring)
*
***************************************************************/

namespace Server.Items
{
	public class VolcanicRockRing : Item
	{
		public VolcanicRockRing() : base()
		{
			Id = 12053;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 21;
			ReqLevel = 16;
			Name = "Volcanic Rock Ring";
			Name2 = "Volcanic Rock Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3350;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 1;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Demon Band)
*
***************************************************************/

namespace Server.Items
{
	public class DemonBand : Item
	{
		public DemonBand() : base()
		{
			Id = 12054;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Demon Band";
			Name2 = "Demon Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3350;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StrBonus = 4;
			StaminaBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stardust Band)
*
***************************************************************/

namespace Server.Items
{
	public class StardustBand : Item
	{
		public StardustBand() : base()
		{
			Id = 12055;
			Bonding = 2;
			SellPrice = 8375;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Stardust Band";
			Name2 = "Stardust Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33500;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 5;
			SpiritBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ring of the Heavens)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheHeavens : Item
	{
		public RingOfTheHeavens() : base()
		{
			Id = 12056;
			Bonding = 2;
			SellPrice = 8375;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Ring of the Heavens";
			Name2 = "Ring of the Heavens";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33500;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 13;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dragonscale Band)
*
***************************************************************/

namespace Server.Items
{
	public class DragonscaleBand : Item
	{
		public DragonscaleBand() : base()
		{
			Id = 12057;
			Bonding = 2;
			SellPrice = 8375;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Dragonscale Band";
			Name2 = "Dragonscale Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33500;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 13;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Demonic Bone Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DemonicBoneRing : Item
	{
		public DemonicBoneRing() : base()
		{
			Id = 12058;
			Bonding = 2;
			SellPrice = 8376;
			AvailableClasses = 0x7FFF;
			Model = 3666;
			ObjectClass = 4;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "Demonic Bone Ring";
			Name2 = "Demonic Bone Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33505;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StrBonus = 8;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Conqueror's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class ConquerorsMedallion : Item
	{
		public ConquerorsMedallion() : base()
		{
			Id = 12059;
			Bonding = 1;
			SellPrice = 12377;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			Name = "Conqueror's Medallion";
			Name2 = "Conqueror's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49510;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 11;
			StrBonus = 10;
			IqBonus = 5;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ward of the Elements)
*
***************************************************************/

namespace Server.Items
{
	public class WardOfTheElements : Item
	{
		public WardOfTheElements() : base()
		{
			Id = 12065;
			Resistance[6] = 8;
			Bonding = 1;
			SellPrice = 7953;
			AvailableClasses = 0x7FFF;
			Model = 22037;
			Resistance[2] = 8;
			Resistance[4] = 8;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Ward of the Elements";
			Name2 = "Ward of the Elements";
			Resistance[3] = 8;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31813;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Trinket1;
			Delay = 500;
			Stackable = 1;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Ring of the Aristocrat)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheAristocrat : Item
	{
		public RingOfTheAristocrat() : base()
		{
			Id = 12102;
			Bonding = 1;
			SellPrice = 9042;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			Name = "Ring of the Aristocrat";
			Name2 = "Ring of the Aristocrat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36170;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Star of Mystaria)
*
***************************************************************/

namespace Server.Items
{
	public class StarOfMystaria : Item
	{
		public StarOfMystaria() : base()
		{
			Id = 12103;
			Bonding = 1;
			SellPrice = 12157;
			AvailableClasses = 0x7FFF;
			Model = 23717;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Star of Mystaria";
			Name2 = "Star of Mystaria";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48630;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 5;
			IqBonus = 9;
			SpiritBonus = 9;
			AgilityBonus = 7;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Seal of Ascension)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfAscension : Item
	{
		public SealOfAscension() : base()
		{
			Id = 12344;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Draconic runes appear and disappear along the inner band.";
			Model = 22415;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Seal of Ascension";
			Name2 = "Seal of Ascension";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 16349 , 0 , 0 , 0 , 491 , 180000 );
			SetSpell( 16372 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Songstone of Ironforge)
*
***************************************************************/

namespace Server.Items
{
	public class SongstoneOfIronforge : Item
	{
		public SongstoneOfIronforge() : base()
		{
			Id = 12543;
			Bonding = 1;
			SellPrice = 7156;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Songstone of Ironforge";
			Name2 = "Songstone of Ironforge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28625;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 9346 , 1 , 0 , 0 , 0 , 0 );
			SpiritBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Thrall's Resolve)
*
***************************************************************/

namespace Server.Items
{
	public class ThrallsResolve : Item
	{
		public ThrallsResolve() : base()
		{
			Id = 12544;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 7407;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Thrall's Resolve";
			Name2 = "Thrall's Resolve";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 7;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Eye of Orgrimmar)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfOrgrimmar : Item
	{
		public EyeOfOrgrimmar() : base()
		{
			Id = 12545;
			Bonding = 1;
			SellPrice = 7082;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Eye of Orgrimmar";
			Name2 = "Eye of Orgrimmar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28330;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 9346 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 4;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Magni's Will)
*
***************************************************************/

namespace Server.Items
{
	public class MagnisWill : Item
	{
		public MagnisWill() : base()
		{
			Id = 12548;
			Bonding = 1;
			SellPrice = 7102;
			AvailableClasses = 0x7FFF;
			Model = 9837;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Magni's Will";
			Name2 = "Magni's Will";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28410;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , 0 );
			StrBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Polychromatic Visionwrap)
*
***************************************************************/

namespace Server.Items
{
	public class PolychromaticVisionwrap : Item
	{
		public PolychromaticVisionwrap() : base()
		{
			Id = 12609;
			Resistance[6] = 20;
			Bonding = 1;
			SellPrice = 20498;
			AvailableClasses = 0x7FFF;
			Model = 22843;
			Resistance[2] = 20;
			Resistance[4] = 20;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Polychromatic Visionwrap";
			Name2 = "Polychromatic Visionwrap";
			Resistance[3] = 20;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102494;
			Resistance[5] = 20;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Argent Dawn Commission)
*
***************************************************************/

namespace Server.Items
{
	public class ArgentDawnCommission : Item
	{
		public ArgentDawnCommission() : base()
		{
			Id = 12846;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Equipping this badge is an indication of service to the Argent Dawn.";
			Model = 23716;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Argent Dawn Commission";
			Name2 = "Argent Dawn Commission";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 17670 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Flaming Band)
*
***************************************************************/

namespace Server.Items
{
	public class FlamingBand : Item
	{
		public FlamingBand() : base()
		{
			Id = 12926;
			Bonding = 1;
			SellPrice = 14907;
			AvailableClasses = 0x7FFF;
			Model = 23435;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Flaming Band";
			Name2 = "Flaming Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 3248;
			BuyPrice = 59630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SetSpell( 9298 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Emberfury Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class EmberfuryTalisman : Item
	{
		public EmberfuryTalisman() : base()
		{
			Id = 12929;
			Bonding = 1;
			SellPrice = 19646;
			AvailableClasses = 0x7FFF;
			Model = 9658;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Emberfury Talisman";
			Name2 = "Emberfury Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 78585;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Briarwood Reed)
*
***************************************************************/

namespace Server.Items
{
	public class BriarwoodReed : Item
	{
		public BriarwoodReed() : base()
		{
			Id = 12930;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 8232;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Briarwood Reed";
			Name2 = "Briarwood Reed";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 13881 , 1 , 0 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Alex's Ring of Audacity)
*
***************************************************************/

namespace Server.Items
{
	public class AlexsRingOfAudacity : Item
	{
		public AlexsRingOfAudacity() : base()
		{
			Id = 12947;
			AvailableClasses = 0x7FFF;
			Model = 23496;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Alex's Ring of Audacity";
			Name2 = "Alex's Ring of Audacity";
			Quality = 6;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SetSpell( 17178 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ring of Defense)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfDefense : Item
	{
		public RingOfDefense() : base()
		{
			Id = 12985;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1153;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Ring of Defense";
			Name2 = "Ring of Defense";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4615;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Language = 7;
			SetSpell( 7517 , 1 , 0 , 900000 , 0 , 30000 );
		}
	}
}


/**************************************************************
*
*				(Band of Purification)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfPurification : Item
	{
		public BandOfPurification() : base()
		{
			Id = 12996;
			Bonding = 2;
			SellPrice = 1527;
			AvailableClasses = 0x7FFF;
			Model = 24646;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Band of Purification";
			Name2 = "Band of Purification";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6110;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 6;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Maiden's Circle)
*
***************************************************************/

namespace Server.Items
{
	public class MaidensCircle : Item
	{
		public MaidensCircle() : base()
		{
			Id = 13001;
			Bonding = 2;
			SellPrice = 10648;
			AvailableClasses = 0x7FFF;
			Model = 9833;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 55;
			Name = "Maiden's Circle";
			Name2 = "Maiden's Circle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42594;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 9346 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 6;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lady Alizabeth's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class LadyAlizabethsPendant : Item
	{
		public LadyAlizabethsPendant() : base()
		{
			Id = 13002;
			Bonding = 2;
			SellPrice = 14617;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Lady Alizabeth's Pendant";
			Name2 = "Lady Alizabeth's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58469;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			IqBonus = 15;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Umbral Crystal)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralCrystal : Item
	{
		public UmbralCrystal() : base()
		{
			Id = 13029;
			Bonding = 2;
			SellPrice = 5613;
			AvailableClasses = 0x7FFF;
			Model = 24122;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Umbral Crystal";
			Name2 = "Umbral Crystal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22453;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			SetSpell( 9325 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Basilisk Bone)
*
***************************************************************/

namespace Server.Items
{
	public class BasiliskBone : Item
	{
		public BasiliskBone() : base()
		{
			Id = 13030;
			Resistance[6] = 6;
			Bonding = 2;
			SellPrice = 13113;
			AvailableClasses = 0x7FFF;
			Model = 28647;
			Resistance[2] = 6;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Basilisk Bone";
			Name2 = "Basilisk Bone";
			Resistance[3] = 6;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52453;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Orb of Mistmantle)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfMistmantle : Item
	{
		public OrbOfMistmantle() : base()
		{
			Id = 13031;
			Bonding = 2;
			SellPrice = 1401;
			AvailableClasses = 0x7FFF;
			Model = 28803;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Orb of Mistmantle";
			Name2 = "Orb of Mistmantle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5605;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			SetSpell( 7678 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7707 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Kaleidoscope Chain)
*
***************************************************************/

namespace Server.Items
{
	public class KaleidoscopeChain : Item
	{
		public KaleidoscopeChain() : base()
		{
			Id = 13084;
			Bonding = 2;
			SellPrice = 6614;
			AvailableClasses = 0x7FFF;
			Model = 6497;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Kaleidoscope Chain";
			Name2 = "Kaleidoscope Chain";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26458;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			SpiritBonus = 4;
			IqBonus = 4;
			StaminaBonus = 4;
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Horizon Choker)
*
***************************************************************/

namespace Server.Items
{
	public class HorizonChoker : Item
	{
		public HorizonChoker() : base()
		{
			Id = 13085;
			Bonding = 2;
			SellPrice = 9137;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Horizon Choker";
			Name2 = "Horizon Choker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36548;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			SpiritBonus = 14;
			IqBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(River Pride Choker)
*
***************************************************************/

namespace Server.Items
{
	public class RiverPrideChoker : Item
	{
		public RiverPrideChoker() : base()
		{
			Id = 13087;
			Bonding = 2;
			SellPrice = 5896;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "River Pride Choker";
			Name2 = "River Pride Choker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23584;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 9;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Gazlowe's Charm)
*
***************************************************************/

namespace Server.Items
{
	public class GazlowesCharm : Item
	{
		public GazlowesCharm() : base()
		{
			Id = 13088;
			Bonding = 2;
			SellPrice = 7413;
			AvailableClasses = 0x7FFF;
			Model = 6522;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Gazlowe's Charm";
			Name2 = "Gazlowe's Charm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29654;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 11;
			StrBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Skibi's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class SkibisPendant : Item
	{
		public SkibisPendant() : base()
		{
			Id = 13089;
			Bonding = 2;
			SellPrice = 8039;
			AvailableClasses = 0x7FFF;
			Model = 6497;
			ObjectClass = 4;
			SubClass = 0;
			Level = 49;
			ReqLevel = 44;
			Name = "Skibi's Pendant";
			Name2 = "Skibi's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32156;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StrBonus = 5;
			AgilityBonus = 13;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Medallion of Grand Marshal Morris)
*
***************************************************************/

namespace Server.Items
{
	public class MedallionOfGrandMarshalMorris : Item
	{
		public MedallionOfGrandMarshalMorris() : base()
		{
			Id = 13091;
			Bonding = 2;
			SellPrice = 10637;
			AvailableClasses = 0x7FFF;
			Model = 23717;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Medallion of Grand Marshal Morris";
			Name2 = "Medallion of Grand Marshal Morris";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42549;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 13390 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Blush Ember Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BlushEmberRing : Item
	{
		public BlushEmberRing() : base()
		{
			Id = 13093;
			Bonding = 2;
			SellPrice = 3381;
			AvailableClasses = 0x7FFF;
			Model = 28682;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Blush Ember Ring";
			Name2 = "Blush Ember Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13524;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			IqBonus = 8;
			AgilityBonus = 5;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(The Queen's Jewel)
*
***************************************************************/

namespace Server.Items
{
	public class TheQueensJewel : Item
	{
		public TheQueensJewel() : base()
		{
			Id = 13094;
			Bonding = 2;
			SellPrice = 2646;
			AvailableClasses = 0x7FFF;
			Model = 26537;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "The Queen's Jewel";
			Name2 = "The Queen's Jewel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10584;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			IqBonus = 8;
			SpiritBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Assault Band)
*
***************************************************************/

namespace Server.Items
{
	public class AssaultBand : Item
	{
		public AssaultBand() : base()
		{
			Id = 13095;
			Bonding = 2;
			SellPrice = 6646;
			AvailableClasses = 0x7FFF;
			Model = 9834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Assault Band";
			Name2 = "Assault Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26584;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Band of the Hierophant)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheHierophant : Item
	{
		public BandOfTheHierophant() : base()
		{
			Id = 13096;
			Bonding = 2;
			SellPrice = 7913;
			AvailableClasses = 0x7FFF;
			Model = 23629;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Band of the Hierophant";
			Name2 = "Band of the Hierophant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31654;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			IqBonus = 11;
			SpiritBonus = 10;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Thunderbrow Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderbrowRing : Item
	{
		public ThunderbrowRing() : base()
		{
			Id = 13097;
			Bonding = 2;
			SellPrice = 2164;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Thunderbrow Ring";
			Name2 = "Thunderbrow Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8658;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			AgilityBonus = 3;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Painweaver Band)
*
***************************************************************/

namespace Server.Items
{
	public class PainweaverBand : Item
	{
		public PainweaverBand() : base()
		{
			Id = 13098;
			Bonding = 1;
			SellPrice = 15282;
			AvailableClasses = 0x7FFF;
			Model = 23608;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Painweaver Band";
			Name2 = "Painweaver Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61130;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Tooth of Gnarr)
*
***************************************************************/

namespace Server.Items
{
	public class ToothOfGnarr : Item
	{
		public ToothOfGnarr() : base()
		{
			Id = 13141;
			Bonding = 1;
			SellPrice = 12093;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Tooth of Gnarr";
			Name2 = "Tooth of Gnarr";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48373;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 15;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Mark of the Dragon Lord)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfTheDragonLord : Item
	{
		public MarkOfTheDragonLord() : base()
		{
			Id = 13143;
			Bonding = 1;
			SellPrice = 21372;
			AvailableClasses = 0x7FFF;
			Model = 23629;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Mark of the Dragon Lord";
			Name2 = "Mark of the Dragon Lord";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85490;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			Flags = 64;
			SetSpell( 17252 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Heart of the Scale)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfTheScale : Item
	{
		public HeartOfTheScale() : base()
		{
			Id = 13164;
			Bonding = 1;
			SellPrice = 10539;
			AvailableClasses = 0x7FFF;
			Model = 6006;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Heart of the Scale";
			Name2 = "Heart of the Scale";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42158;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17275 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Smokey's Lighter)
*
***************************************************************/

namespace Server.Items
{
	public class SmokeysLighter : Item
	{
		public SmokeysLighter() : base()
		{
			Id = 13171;
			Bonding = 1;
			SellPrice = 7000;
			AvailableClasses = 0x7FFF;
			Model = 24060;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Smokey's Lighter";
			Name2 = "Smokey's Lighter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 17283 , 0 , 0 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Talisman of Evasion)
*
***************************************************************/

namespace Server.Items
{
	public class TalismanOfEvasion : Item
	{
		public TalismanOfEvasion() : base()
		{
			Id = 13177;
			Bonding = 1;
			SellPrice = 16396;
			AvailableClasses = 0x7FFF;
			Model = 6494;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Talisman of Evasion";
			Name2 = "Talisman of Evasion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65585;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , -1 );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Rosewine Circle)
*
***************************************************************/

namespace Server.Items
{
	public class RosewineCircle : Item
	{
		public RosewineCircle() : base()
		{
			Id = 13178;
			Bonding = 1;
			SellPrice = 13782;
			AvailableClasses = 0x7FFF;
			Model = 23728;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Rosewine Circle";
			Name2 = "Rosewine Circle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55130;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 16;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Seal of the Dawn)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfTheDawn : Item
	{
		public SealOfTheDawn() : base()
		{
			Id = 13209;
			Bonding = 1;
			SellPrice = 9615;
			AvailableClasses = 0x7FFF;
			Model = 23763;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Seal of the Dawn";
			Name2 = "Seal of the Dawn";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38462;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 23930 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Halycon's Spiked Collar)
*
***************************************************************/

namespace Server.Items
{
	public class HalyconsSpikedCollar : Item
	{
		public HalyconsSpikedCollar() : base()
		{
			Id = 13212;
			Bonding = 1;
			SellPrice = 10670;
			AvailableClasses = 0x7FFF;
			Model = 23766;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Halycon's Spiked Collar";
			Name2 = "Halycon's Spiked Collar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42683;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 18067 , 1 , 0 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Smolderweb's Eye)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderwebsEye : Item
	{
		public SmolderwebsEye() : base()
		{
			Id = 13213;
			Bonding = 1;
			SellPrice = 9633;
			AvailableClasses = 0x7FFF;
			Model = 16209;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Smolderweb's Eye";
			Name2 = "Smolderweb's Eye";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38533;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 17330 , 0 , 0 , 180000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Band of the Penitent)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfThePenitent : Item
	{
		public BandOfThePenitent() : base()
		{
			Id = 13217;
			Bonding = 1;
			SellPrice = 8814;
			AvailableClasses = 0x7FFF;
			Model = 28830;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Band of the Penitent";
			Name2 = "Band of the Penitent";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35258;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Globe of D'sak)
*
***************************************************************/

namespace Server.Items
{
	public class GlobeOfDsak : Item
	{
		public GlobeOfDsak() : base()
		{
			Id = 13261;
			Bonding = 1;
			SellPrice = 10452;
			AvailableClasses = 0x7FFF;
			Description = "Glows with the power of magiskull.";
			Model = 23867;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Globe of D'sak";
			Name2 = "Globe of D'sak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41810;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SpiritBonus = 16;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Magus Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MagusRing : Item
	{
		public MagusRing() : base()
		{
			Id = 13283;
			Bonding = 1;
			SellPrice = 14907;
			AvailableClasses = 0x7FFF;
			Model = 23435;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Magus Ring";
			Name2 = "Magus Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59630;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SpiritBonus = 9;
			IqBonus = 4;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Testament of Hope)
*
***************************************************************/

namespace Server.Items
{
	public class TestamentOfHope : Item
	{
		public TestamentOfHope() : base()
		{
			Id = 13315;
			Bonding = 1;
			SellPrice = 11396;
			AvailableClasses = 0x7FFF;
			Model = 23955;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Testament of Hope";
			Name2 = "Testament of Hope";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45587;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			SetSpell( 17448 , 0 , 0 , 1800000 , 30 , 180000 );
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Seal of Rivendare)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfRivendare : Item
	{
		public SealOfRivendare() : base()
		{
			Id = 13345;
			Bonding = 1;
			SellPrice = 15457;
			AvailableClasses = 0x7FFF;
			Model = 24022;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Seal of Rivendare";
			Name2 = "Seal of Rivendare";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61830;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SpiritBonus = 17;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Book of the Dead)
*
***************************************************************/

namespace Server.Items
{
	public class BookOfTheDead : Item
	{
		public BookOfTheDead() : base()
		{
			Id = 13353;
			Bonding = 1;
			SellPrice = 10452;
			AvailableClasses = 0x7FFF;
			Model = 24039;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Book of the Dead";
			Name2 = "Book of the Dead";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 41810;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 17490 , 0 , 0 , 900000 , 94 , 60000 );
			IqBonus = 10;
			SpiritBonus = 15;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Father Flame)
*
***************************************************************/

namespace Server.Items
{
	public class FatherFlame : Item
	{
		public FatherFlame() : base()
		{
			Id = 13371;
			SellPrice = 6657;
			AvailableClasses = 0x7FFF;
			Model = 24061;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			Name = "Father Flame";
			Name2 = "Father Flame";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26630;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Band of Flesh)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfFlesh : Item
	{
		public BandOfFlesh() : base()
		{
			Id = 13373;
			Bonding = 1;
			SellPrice = 14846;
			AvailableClasses = 0x7FFF;
			Model = 1225;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Band of Flesh";
			Name2 = "Band of Flesh";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59387;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			StaminaBonus = 16;
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Piccolo of the Flaming Fire)
*
***************************************************************/

namespace Server.Items
{
	public class PiccoloOfTheFlamingFire : Item
	{
		public PiccoloOfTheFlamingFire() : base()
		{
			Id = 13379;
			Bonding = 1;
			SellPrice = 10734;
			AvailableClasses = 0x7FFF;
			Model = 2618;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Piccolo of the Flaming Fire";
			Name2 = "Piccolo of the Flaming Fire";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42939;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 18400 , 0 , 0 , 60000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Cannonball Runner)
*
***************************************************************/

namespace Server.Items
{
	public class CannonballRunner : Item
	{
		public CannonballRunner() : base()
		{
			Id = 13382;
			Bonding = 1;
			SellPrice = 10850;
			AvailableClasses = 0x7FFF;
			Model = 7888;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Cannonball Runner";
			Name2 = "Cannonball Runner";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43400;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 6251 , 0 , 0 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Tome of Knowledge)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfKnowledge : Item
	{
		public TomeOfKnowledge() : base()
		{
			Id = 13385;
			Bonding = 1;
			SellPrice = 13237;
			AvailableClasses = 0x7FFF;
			Model = 24072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Tome of Knowledge";
			Name2 = "Tome of Knowledge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52950;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			AgilityBonus = 8;
			StrBonus = 8;
			SpiritBonus = 8;
			IqBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(The Postmaster's Seal)
*
***************************************************************/

namespace Server.Items
{
	public class ThePostmastersSeal : Item
	{
		public ThePostmastersSeal() : base()
		{
			Id = 13392;
			Bonding = 1;
			SellPrice = 12211;
			AvailableClasses = 0x7FFF;
			Model = 24087;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "The Postmaster's Seal";
			Name2 = "The Postmaster's Seal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48846;
			Sets = 81;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			IqBonus = 17;
			AgilityBonus = 3;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Felstone Good Luck Charm)
*
***************************************************************/

namespace Server.Items
{
	public class FelstoneGoodLuckCharm : Item
	{
		public FelstoneGoodLuckCharm() : base()
		{
			Id = 13473;
			Bonding = 1;
			SellPrice = 7164;
			AvailableClasses = 0x7FFF;
			Model = 23715;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			Name = "Felstone Good Luck Charm";
			Name2 = "Felstone Good Luck Charm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28658;
			Resistance[5] = 13;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Dalson Family Wedding Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DalsonFamilyWeddingRing : Item
	{
		public DalsonFamilyWeddingRing() : base()
		{
			Id = 13475;
			Bonding = 1;
			SellPrice = 8109;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Dalson Family Wedding Ring";
			Name2 = "Dalson Family Wedding Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32436;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Ramstein's Lightning Bolts)
*
***************************************************************/

namespace Server.Items
{
	public class RamsteinsLightningBolts : Item
	{
		public RamsteinsLightningBolts() : base()
		{
			Id = 13515;
			Bonding = 1;
			SellPrice = 9600;
			AvailableClasses = 0x7FFF;
			Model = 1236;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Ramstein's Lightning Bolts";
			Name2 = "Ramstein's Lightning Bolts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38400;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 17668 , 0 , 0 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Skull of Burning Shadows)
*
***************************************************************/

namespace Server.Items
{
	public class SkullOfBurningShadows : Item
	{
		public SkullOfBurningShadows() : base()
		{
			Id = 13524;
			Bonding = 1;
			SellPrice = 12458;
			AvailableClasses = 0x7FFF;
			Model = 24176;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Skull of Burning Shadows";
			Name2 = "Skull of Burning Shadows";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49835;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Spectral Essence)
*
***************************************************************/

namespace Server.Items
{
	public class SpectralEssence : Item
	{
		public SpectralEssence() : base()
		{
			Id = 13544;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Allows communication with the deceased of Caer Darrow.";
			Model = 24220;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Spectral Essence";
			Name2 = "Spectral Essence";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 17623 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Greater Spellstone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterSpellstone : Item
	{
		public GreaterSpellstone() : base()
		{
			Id = 13602;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21610;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Greater Spellstone";
			Name2 = "Greater Spellstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Flags = 2;
			SetSpell( 17729 , 0 , -1 , 0 , 0 , 0 );
			SetSpell( 18384 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Major Spellstone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorSpellstone : Item
	{
		public MajorSpellstone() : base()
		{
			Id = 13603;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21610;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Major Spellstone";
			Name2 = "Major Spellstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Flags = 2;
			SetSpell( 17730 , 0 , -1 , 0 , 0 , 0 );
			SetSpell( 18384 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Firestone)
*
***************************************************************/

namespace Server.Items
{
	public class Firestone : Item
	{
		public Firestone() : base()
		{
			Id = 13699;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24380;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			Name = "Firestone";
			Name2 = "Firestone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 17945 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 23481 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Greater Firestone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterFirestone : Item
	{
		public GreaterFirestone() : base()
		{
			Id = 13700;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24380;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			Name = "Greater Firestone";
			Name2 = "Greater Firestone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 17947 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 23482 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Major Firestone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorFirestone : Item
	{
		public MajorFirestone() : base()
		{
			Id = 13701;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24380;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			Name = "Major Firestone";
			Name2 = "Major Firestone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 17949 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 23483 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Ring of the Dawn)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfTheDawn : Item
	{
		public RingOfTheDawn() : base()
		{
			Id = 13812;
			Bonding = 1;
			SellPrice = 8303;
			AvailableClasses = 0x7FFF;
			Model = 24569;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			Name = "Ring of the Dawn";
			Name2 = "Ring of the Dawn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33215;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Formal Dangui)
*
***************************************************************/

namespace Server.Items
{
	public class FormalDangui : Item
	{
		public FormalDangui() : base()
		{
			Id = 13895;
			SellPrice = 101324;
			AvailableClasses = 0x7FFF;
			Model = 24644;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Formal Dangui";
			Name2 = "Formal Dangui";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 506622;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Blue Wedding Hanbok)
*
***************************************************************/

namespace Server.Items
{
	public class BlueWeddingHanbok : Item
	{
		public BlueWeddingHanbok() : base()
		{
			Id = 13896;
			SellPrice = 11020;
			AvailableClasses = 0x7FFF;
			Model = 24643;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Blue Wedding Hanbok";
			Name2 = "Blue Wedding Hanbok";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 55102;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(White Traditional Hanbok)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteTraditionalHanbok : Item
	{
		public WhiteTraditionalHanbok() : base()
		{
			Id = 13897;
			SellPrice = 595;
			AvailableClasses = 0x7FFF;
			Model = 24641;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "White Traditional Hanbok";
			Name2 = "White Traditional Hanbok";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2976;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Royal Dangui)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalDangui : Item
	{
		public RoyalDangui() : base()
		{
			Id = 13898;
			SellPrice = 57739;
			AvailableClasses = 0x7FFF;
			Model = 24645;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Royal Dangui";
			Name2 = "Royal Dangui";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 288699;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Red Traditional Hanbok)
*
***************************************************************/

namespace Server.Items
{
	public class RedTraditionalHanbok : Item
	{
		public RedTraditionalHanbok() : base()
		{
			Id = 13899;
			SellPrice = 3528;
			AvailableClasses = 0x7FFF;
			Model = 24639;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Red Traditional Hanbok";
			Name2 = "Red Traditional Hanbok";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17641;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Green Wedding Hanbok)
*
***************************************************************/

namespace Server.Items
{
	public class GreenWeddingHanbok : Item
	{
		public GreenWeddingHanbok() : base()
		{
			Id = 13900;
			SellPrice = 27442;
			AvailableClasses = 0x7FFF;
			Model = 24642;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Green Wedding Hanbok";
			Name2 = "Green Wedding Hanbok";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 137214;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Heart of the Fiend)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfTheFiend : Item
	{
		public HeartOfTheFiend() : base()
		{
			Id = 13960;
			Bonding = 1;
			SellPrice = 12828;
			AvailableClasses = 0x7FFF;
			Model = 19785;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Heart of the Fiend";
			Name2 = "Heart of the Fiend";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51315;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 5;
			IqBonus = 15;
			SpiritBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Blackhand's Breadth)
*
***************************************************************/

namespace Server.Items
{
	public class BlackhandsBreadth : Item
	{
		public BlackhandsBreadth() : base()
		{
			Id = 13965;
			Bonding = 1;
			SellPrice = 16250;
			AvailableClasses = 0x7FFF;
			Model = 24776;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Blackhand's Breadth";
			Name2 = "Blackhand's Breadth";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mark of Tyranny)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfTyranny : Item
	{
		public MarkOfTyranny() : base()
		{
			Id = 13966;
			Resistance[6] = 10;
			Resistance[0] = 180;
			Bonding = 1;
			SellPrice = 16250;
			AvailableClasses = 0x7FFF;
			Model = 24778;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Mark of Tyranny";
			Name2 = "Mark of Tyranny";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eye of the Beast)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfTheBeast : Item
	{
		public EyeOfTheBeast() : base()
		{
			Id = 13968;
			Bonding = 1;
			SellPrice = 16250;
			AvailableClasses = 0x5D0;
			Model = 24784;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Eye of the Beast";
			Name2 = "Eye of the Beast";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 18382 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Barov Peasant Caller)
*
***************************************************************/

namespace Server.Items
{
	public class BarovPeasantCaller : Item
	{
		public BarovPeasantCaller() : base()
		{
			Id = 14022;
			Bonding = 1;
			SellPrice = 8991;
			AvailableClasses = 0x7FFF;
			Model = 26622;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Barov Peasant Caller";
			Name2 = "Barov Peasant Caller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35965;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 18307 , 0 , 0 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Barov Peasant Caller)
*
***************************************************************/

namespace Server.Items
{
	public class BarovPeasantCaller14023 : Item
	{
		public BarovPeasantCaller14023() : base()
		{
			Id = 14023;
			Bonding = 1;
			SellPrice = 8991;
			AvailableClasses = 0x7FFF;
			Model = 26622;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Barov Peasant Caller";
			Name2 = "Barov Peasant Caller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35965;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 18308 , 0 , 0 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(The Lion Horn of Stormwind)
*
***************************************************************/

namespace Server.Items
{
	public class TheLionHornOfStormwind : Item
	{
		public TheLionHornOfStormwind() : base()
		{
			Id = 14557;
			Bonding = 2;
			SellPrice = 17880;
			AvailableClasses = 0x7FFF;
			Model = 6338;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "The Lion Horn of Stormwind";
			Name2 = "The Lion Horn of Stormwind";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 71520;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 20847 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Lady Maye's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class LadyMayesPendant : Item
	{
		public LadyMayesPendant() : base()
		{
			Id = 14558;
			Bonding = 2;
			SellPrice = 10500;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "Lady Maye's Pendant";
			Name2 = "Lady Maye's Pendant";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 42000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 19;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Orb of Noh'Orahil)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfNohOrahil : Item
	{
		public OrbOfNohOrahil() : base()
		{
			Id = 15107;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7B00;
			Model = 25072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Orb of Noh'Orahil";
			Name2 = "Orb of Noh'Orahil";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9401 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 18957 , 0 , 0 , 1800000 , 30 , 180000 );
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Orb of Dar'Orahil)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfDarOrahil : Item
	{
		public OrbOfDarOrahil() : base()
		{
			Id = 15108;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7B00;
			Model = 25072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Orb of Dar'Orahil";
			Name2 = "Orb of Dar'Orahil";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 9414 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 18957 , 0 , 0 , 1800000 , 30 , 180000 );
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Senior Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class SeniorSergeantsInsignia : Item
	{
		public SeniorSergeantsInsignia() : base()
		{
			Id = 15200;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 30797;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Senior Sergeant's Insignia";
			Name2 = "Senior Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Jadefinger Baton)
*
***************************************************************/

namespace Server.Items
{
	public class JadefingerBaton : Item
	{
		public JadefingerBaton() : base()
		{
			Id = 15206;
			Bonding = 1;
			SellPrice = 857;
			AvailableClasses = 0x7FFF;
			Model = 28197;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Jadefinger Baton";
			Name2 = "Jadefinger Baton";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3430;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mark of Fordring)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfFordring : Item
	{
		public MarkOfFordring() : base()
		{
			Id = 15411;
			Bonding = 1;
			SellPrice = 10283;
			AvailableClasses = 0x7FFF;
			Model = 23716;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Mark of Fordring";
			Name2 = "Mark of Fordring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41135;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9334 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Inventor's League Ring)
*
***************************************************************/

namespace Server.Items
{
	public class InventorsLeagueRing : Item
	{
		public InventorsLeagueRing() : base()
		{
			Id = 15467;
			Bonding = 1;
			SellPrice = 8630;
			AvailableClasses = 0x7FFF;
			Model = 23728;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Inventor's League Ring";
			Name2 = "Inventor's League Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34520;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Trader's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TradersRing : Item
	{
		public TradersRing() : base()
		{
			Id = 15689;
			Bonding = 1;
			SellPrice = 4040;
			AvailableClasses = 0x7FFF;
			Model = 26391;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Trader's Ring";
			Name2 = "Trader's Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16160;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Kodobone Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class KodoboneNecklace : Item
	{
		public KodoboneNecklace() : base()
		{
			Id = 15690;
			Bonding = 1;
			SellPrice = 4912;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			Name = "Kodobone Necklace";
			Name2 = "Kodobone Necklace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19650;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Chemist's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class ChemistsRing : Item
	{
		public ChemistsRing() : base()
		{
			Id = 15702;
			Bonding = 1;
			SellPrice = 7396;
			AvailableClasses = 0x7FFF;
			Model = 6486;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Chemist's Ring";
			Name2 = "Chemist's Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29585;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			Sheath = 1;
			SpiritBonus = 10;
			IqBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hunter's Insignia Medal)
*
***************************************************************/

namespace Server.Items
{
	public class HuntersInsigniaMedal : Item
	{
		public HuntersInsigniaMedal() : base()
		{
			Id = 15704;
			Bonding = 1;
			SellPrice = 6145;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Hunter's Insignia Medal";
			Name2 = "Hunter's Insignia Medal";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24580;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Ripped Ogre Loincloth)
*
***************************************************************/

namespace Server.Items
{
	public class RippedOgreLoincloth : Item
	{
		public RippedOgreLoincloth() : base()
		{
			Id = 15794;
			SellPrice = 39;
			AvailableClasses = 0x7FFF;
			Model = 12413;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Ripped Ogre Loincloth";
			Name2 = "Ripped Ogre Loincloth";
			AvailableRaces = 0x1FF;
			BuyPrice = 195;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Heroic Commendation Medal)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicCommendationMedal : Item
	{
		public HeroicCommendationMedal() : base()
		{
			Id = 15799;
			Bonding = 1;
			SellPrice = 7108;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			Name = "Heroic Commendation Medal";
			Name2 = "Heroic Commendation Medal";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28435;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Penelope's Rose)
*
***************************************************************/

namespace Server.Items
{
	public class PenelopesRose : Item
	{
		public PenelopesRose() : base()
		{
			Id = 15805;
			Bonding = 1;
			SellPrice = 14662;
			AvailableClasses = 0x7FFF;
			Model = 26491;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Penelope's Rose";
			Name2 = "Penelope's Rose";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58650;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SpiritBonus = 11;
			IqBonus = 11;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ring of Protection)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfProtection : Item
	{
		public RingOfProtection() : base()
		{
			Id = 15855;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 7888;
			AvailableClasses = 0x7FFF;
			Model = 26537;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Ring of Protection";
			Name2 = "Ring of Protection";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31555;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Archlight Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class ArchlightTalisman : Item
	{
		public ArchlightTalisman() : base()
		{
			Id = 15856;
			Bonding = 1;
			SellPrice = 8788;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Archlight Talisman";
			Name2 = "Archlight Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35155;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 10;
			IqBonus = 10;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Magebane Scion)
*
***************************************************************/

namespace Server.Items
{
	public class MagebaneScion : Item
	{
		public MagebaneScion() : base()
		{
			Id = 15857;
			Resistance[6] = 10;
			Bonding = 1;
			SellPrice = 15335;
			AvailableClasses = 0x7FFF;
			Model = 26539;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Magebane Scion";
			Name2 = "Magebane Scion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61342;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Veildust Medicine Bag)
*
***************************************************************/

namespace Server.Items
{
	public class VeildustMedicineBag : Item
	{
		public VeildustMedicineBag() : base()
		{
			Id = 15866;
			Bonding = 1;
			SellPrice = 562;
			AvailableClasses = 0x400;
			Model = 26549;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			Name = "Veildust Medicine Bag";
			Name2 = "Veildust Medicine Bag";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2250;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SetSpell( 19634 , 0 , 0 , 1800000 , 30 , 180000 );
			IqBonus = 1;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Prismcharm)
*
***************************************************************/

namespace Server.Items
{
	public class Prismcharm : Item
	{
		public Prismcharm() : base()
		{
			Id = 15867;
			Bonding = 1;
			SellPrice = 7464;
			AvailableClasses = 0x7FFF;
			Model = 26551;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Prismcharm";
			Name2 = "Prismcharm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29857;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 19638 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Ragged John's Neverending Cup)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedJohnsNeverendingCup : Item
	{
		public RaggedJohnsNeverendingCup() : base()
		{
			Id = 15873;
			Bonding = 1;
			SellPrice = 8144;
			AvailableClasses = 0x7FFF;
			Model = 18119;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Ragged John's Neverending Cup";
			Name2 = "Ragged John's Neverending Cup";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32578;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			SetSpell( 20587 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Orb)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersOrb : Item
	{
		public BuccaneersOrb() : base()
		{
			Id = 15912;
			Bonding = 2;
			SellPrice = 1148;
			AvailableClasses = 0x7FFF;
			Model = 28471;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Buccaneer's Orb";
			Name2 = "Buccaneer's Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2008;
			BuyPrice = 4594;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersSphere : Item
	{
		public ConjurersSphere() : base()
		{
			Id = 15918;
			Bonding = 2;
			SellPrice = 4848;
			AvailableClasses = 0x7FFF;
			Model = 28472;
			ObjectClass = 4;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Conjurer's Sphere";
			Name2 = "Conjurer's Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2038;
			BuyPrice = 19392;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Stave)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansStave : Item
	{
		public JourneymansStave() : base()
		{
			Id = 15925;
			Bonding = 2;
			SellPrice = 439;
			AvailableClasses = 0x7FFF;
			Model = 28462;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			ReqLevel = 5;
			Name = "Journeyman's Stave";
			Name2 = "Journeyman's Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1758;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Orb)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderOrb : Item
	{
		public SpellbinderOrb() : base()
		{
			Id = 15926;
			Bonding = 2;
			SellPrice = 802;
			AvailableClasses = 0x7FFF;
			Model = 28464;
			ObjectClass = 4;
			SubClass = 0;
			Level = 17;
			ReqLevel = 12;
			Name = "Spellbinder Orb";
			Name2 = "Spellbinder Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3210;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bright Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class BrightSphere : Item
	{
		public BrightSphere() : base()
		{
			Id = 15927;
			Bonding = 2;
			SellPrice = 1864;
			AvailableClasses = 0x7FFF;
			Model = 27556;
			ObjectClass = 4;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Bright Sphere";
			Name2 = "Bright Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7458;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Rod)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadRod : Item
	{
		public SilverThreadRod() : base()
		{
			Id = 15928;
			Bonding = 2;
			SellPrice = 2387;
			AvailableClasses = 0x7FFF;
			Model = 28466;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Silver-thread Rod";
			Name2 = "Silver-thread Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9548;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 3;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Nightsky Orb)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyOrb : Item
	{
		public NightskyOrb() : base()
		{
			Id = 15929;
			Bonding = 2;
			SellPrice = 4396;
			AvailableClasses = 0x7FFF;
			Model = 27558;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Nightsky Orb";
			Name2 = "Nightsky Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17585;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 6;
			IqBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedScepter : Item
	{
		public ImperialRedScepter() : base()
		{
			Id = 15930;
			Bonding = 2;
			SellPrice = 9146;
			AvailableClasses = 0x7FFF;
			Model = 27563;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Imperial Red Scepter";
			Name2 = "Imperial Red Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36584;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 12;
			StaminaBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Arcane Star)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneStar : Item
	{
		public ArcaneStar() : base()
		{
			Id = 15931;
			Bonding = 2;
			SellPrice = 10646;
			AvailableClasses = 0x7FFF;
			Model = 27575;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Arcane Star";
			Name2 = "Arcane Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42584;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 10;
			IqBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Disciple's Stein)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesStein : Item
	{
		public DisciplesStein() : base()
		{
			Id = 15932;
			Bonding = 2;
			SellPrice = 527;
			AvailableClasses = 0x7FFF;
			Model = 28473;
			ObjectClass = 4;
			SubClass = 0;
			Level = 12;
			ReqLevel = 7;
			Name = "Disciple's Stein";
			Name2 = "Disciple's Stein";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6273;
			BuyPrice = 2110;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Simple Branch)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBranch : Item
	{
		public SimpleBranch() : base()
		{
			Id = 15933;
			Bonding = 2;
			SellPrice = 620;
			AvailableClasses = 0x7FFF;
			Model = 27851;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "Simple Branch";
			Name2 = "Simple Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6272;
			BuyPrice = 2480;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Sage's Stave)
*
***************************************************************/

namespace Server.Items
{
	public class SagesStave : Item
	{
		public SagesStave() : base()
		{
			Id = 15934;
			Bonding = 2;
			SellPrice = 2596;
			AvailableClasses = 0x7FFF;
			Model = 28481;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			ReqLevel = 27;
			Name = "Sage's Stave";
			Name2 = "Sage's Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2026;
			BuyPrice = 10384;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Durable Rod)
*
***************************************************************/

namespace Server.Items
{
	public class DurableRod : Item
	{
		public DurableRod() : base()
		{
			Id = 15935;
			Bonding = 2;
			SellPrice = 3323;
			AvailableClasses = 0x7FFF;
			Model = 27863;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Durable Rod";
			Name2 = "Durable Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2032;
			BuyPrice = 13295;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Branch)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenBranch : Item
	{
		public DuskwovenBranch() : base()
		{
			Id = 15936;
			Bonding = 2;
			SellPrice = 8950;
			AvailableClasses = 0x7FFF;
			Model = 28475;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Duskwoven Branch";
			Name2 = "Duskwoven Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2074;
			BuyPrice = 35802;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Hibernal Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalSphere : Item
	{
		public HibernalSphere() : base()
		{
			Id = 15937;
			Bonding = 2;
			SellPrice = 7922;
			AvailableClasses = 0x7FFF;
			Model = 28455;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Hibernal Sphere";
			Name2 = "Hibernal Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31690;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Mystical Orb)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalOrb : Item
	{
		public MysticalOrb() : base()
		{
			Id = 15938;
			Bonding = 2;
			SellPrice = 9550;
			AvailableClasses = 0x7FFF;
			Model = 28480;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Mystical Orb";
			Name2 = "Mystical Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2080;
			BuyPrice = 38203;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Councillor's Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsScepter : Item
	{
		public CouncillorsScepter() : base()
		{
			Id = 15939;
			Bonding = 2;
			SellPrice = 10455;
			AvailableClasses = 0x7FFF;
			Model = 27612;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Councillor's Scepter";
			Name2 = "Councillor's Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2080;
			BuyPrice = 41823;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Elegant Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantScepter : Item
	{
		public ElegantScepter() : base()
		{
			Id = 15940;
			Bonding = 2;
			SellPrice = 10957;
			AvailableClasses = 0x7FFF;
			Model = 28476;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Elegant Scepter";
			Name2 = "Elegant Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2086;
			BuyPrice = 43829;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsScepter : Item
	{
		public HighCouncillorsScepter() : base()
		{
			Id = 15941;
			Bonding = 2;
			SellPrice = 12345;
			AvailableClasses = 0x7FFF;
			Model = 27650;
			ObjectClass = 4;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "High Councillor's Scepter";
			Name2 = "High Councillor's Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2092;
			BuyPrice = 49382;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Master's Rod)
*
***************************************************************/

namespace Server.Items
{
	public class MastersRod : Item
	{
		public MastersRod() : base()
		{
			Id = 15942;
			Bonding = 2;
			SellPrice = 12757;
			AvailableClasses = 0x7FFF;
			Model = 28478;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Master's Rod";
			Name2 = "Master's Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2092;
			BuyPrice = 51029;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Ancestral Orb)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralOrb : Item
	{
		public AncestralOrb() : base()
		{
			Id = 15944;
			Bonding = 2;
			SellPrice = 512;
			AvailableClasses = 0x7FFF;
			Model = 28483;
			ObjectClass = 4;
			SubClass = 0;
			Level = 12;
			ReqLevel = 7;
			Name = "Ancestral Orb";
			Name2 = "Ancestral Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2051;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Runic Stave)
*
***************************************************************/

namespace Server.Items
{
	public class RunicStave : Item
	{
		public RunicStave() : base()
		{
			Id = 15945;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 28488;
			ObjectClass = 4;
			SubClass = 0;
			Level = 18;
			ReqLevel = 13;
			Name = "Runic Stave";
			Name2 = "Runic Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3351;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mystic's Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsSphere : Item
	{
		public MysticsSphere() : base()
		{
			Id = 15946;
			Bonding = 2;
			SellPrice = 802;
			AvailableClasses = 0x7FFF;
			Model = 28487;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Mystic's Sphere";
			Name2 = "Mystic's Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4495;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 2;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sanguine Star)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineStar : Item
	{
		public SanguineStar() : base()
		{
			Id = 15947;
			Bonding = 2;
			SellPrice = 1887;
			AvailableClasses = 0x7FFF;
			Model = 28489;
			ObjectClass = 4;
			SubClass = 0;
			Level = 28;
			ReqLevel = 23;
			Name = "Sanguine Star";
			Name2 = "Sanguine Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7548;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Satyr's Rod)
*
***************************************************************/

namespace Server.Items
{
	public class SatyrsRod : Item
	{
		public SatyrsRod() : base()
		{
			Id = 15962;
			Bonding = 2;
			SellPrice = 2716;
			AvailableClasses = 0x7FFF;
			Model = 28492;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Satyr's Rod";
			Name2 = "Satyr's Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10864;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			AgilityBonus = 1;
			IqBonus = 2;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Branch)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothBranch : Item
	{
		public StoneclothBranch() : base()
		{
			Id = 15963;
			Bonding = 2;
			SellPrice = 4887;
			AvailableClasses = 0x7FFF;
			Model = 28491;
			ObjectClass = 4;
			SubClass = 0;
			Level = 39;
			ReqLevel = 34;
			Name = "Stonecloth Branch";
			Name2 = "Stonecloth Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19548;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			StrBonus = 3;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Silksand Star)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandStar : Item
	{
		public SilksandStar() : base()
		{
			Id = 15964;
			Bonding = 2;
			SellPrice = 6364;
			AvailableClasses = 0x7FFF;
			Model = 28493;
			ObjectClass = 4;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Silksand Star";
			Name2 = "Silksand Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25458;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 9;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Windchaser Orb)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserOrb : Item
	{
		public WindchaserOrb() : base()
		{
			Id = 15965;
			Bonding = 2;
			SellPrice = 7996;
			AvailableClasses = 0x7FFF;
			Model = 28490;
			ObjectClass = 4;
			SubClass = 0;
			Level = 49;
			ReqLevel = 44;
			Name = "Windchaser Orb";
			Name2 = "Windchaser Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31986;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 2;
			IqBonus = 11;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Orb)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudOrb : Item
	{
		public VenomshroudOrb() : base()
		{
			Id = 15966;
			Bonding = 2;
			SellPrice = 9137;
			AvailableClasses = 0x7FFF;
			Model = 27874;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Venomshroud Orb";
			Name2 = "Venomshroud Orb";
			Resistance[3] = 3;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36548;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			IqBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Highborne Star)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneStar : Item
	{
		public HighborneStar() : base()
		{
			Id = 15967;
			Bonding = 2;
			SellPrice = 10304;
			AvailableClasses = 0x7FFF;
			Model = 28486;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Highborne Star";
			Name2 = "Highborne Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41218;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 11;
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Elunarian Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianSphere : Item
	{
		public ElunarianSphere() : base()
		{
			Id = 15968;
			Bonding = 2;
			SellPrice = 802;
			AvailableClasses = 0x7FFF;
			Model = 28484;
			ObjectClass = 4;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "Elunarian Sphere";
			Name2 = "Elunarian Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48765;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			SpiritBonus = 14;
			StaminaBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Beaded Orb)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedOrb : Item
	{
		public BeadedOrb() : base()
		{
			Id = 15969;
			Bonding = 2;
			SellPrice = 425;
			AvailableClasses = 0x7FFF;
			Model = 28503;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			ReqLevel = 5;
			Name = "Beaded Orb";
			Name2 = "Beaded Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6273;
			BuyPrice = 1700;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Native Branch)
*
***************************************************************/

namespace Server.Items
{
	public class NativeBranch : Item
	{
		public NativeBranch() : base()
		{
			Id = 15970;
			Bonding = 2;
			SellPrice = 587;
			AvailableClasses = 0x7FFF;
			Model = 28554;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "Native Branch";
			Name2 = "Native Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6272;
			BuyPrice = 2348;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Rod)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalRod : Item
	{
		public AboriginalRod() : base()
		{
			Id = 15971;
			Bonding = 2;
			SellPrice = 1064;
			AvailableClasses = 0x7FFF;
			Model = 24014;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Aboriginal Rod";
			Name2 = "Aboriginal Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2002;
			BuyPrice = 4258;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Ritual Stein)
*
***************************************************************/

namespace Server.Items
{
	public class RitualStein : Item
	{
		public RitualStein() : base()
		{
			Id = 15972;
			Bonding = 2;
			SellPrice = 1171;
			AvailableClasses = 0x7FFF;
			Model = 28562;
			ObjectClass = 4;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Ritual Stein";
			Name2 = "Ritual Stein";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2008;
			BuyPrice = 4685;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Watcher's Star)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersStar : Item
	{
		public WatchersStar() : base()
		{
			Id = 15973;
			Bonding = 2;
			SellPrice = 2313;
			AvailableClasses = 0x7FFF;
			Model = 28551;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Watcher's Star";
			Name2 = "Watcher's Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2020;
			BuyPrice = 9254;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Pagan Rod)
*
***************************************************************/

namespace Server.Items
{
	public class PaganRod : Item
	{
		public PaganRod() : base()
		{
			Id = 15974;
			Bonding = 2;
			SellPrice = 1461;
			AvailableClasses = 0x7FFF;
			Model = 5072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Pagan Rod";
			Name2 = "Pagan Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2014;
			BuyPrice = 5846;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Raincaller Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerScepter : Item
	{
		public RaincallerScepter() : base()
		{
			Id = 15975;
			Bonding = 2;
			SellPrice = 2421;
			AvailableClasses = 0x7FFF;
			Model = 28514;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Raincaller Scepter";
			Name2 = "Raincaller Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2026;
			BuyPrice = 9684;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Branch)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurBranch : Item
	{
		public ThistlefurBranch() : base()
		{
			Id = 15976;
			Bonding = 2;
			SellPrice = 4146;
			AvailableClasses = 0x7FFF;
			Model = 28555;
			ObjectClass = 4;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Thistlefur Branch";
			Name2 = "Thistlefur Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2032;
			BuyPrice = 16584;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Vital Orb)
*
***************************************************************/

namespace Server.Items
{
	public class VitalOrb : Item
	{
		public VitalOrb() : base()
		{
			Id = 15977;
			Bonding = 2;
			SellPrice = 4614;
			AvailableClasses = 0x7FFF;
			Model = 28025;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Vital Orb";
			Name2 = "Vital Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2038;
			BuyPrice = 18456;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Rod)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersRod : Item
	{
		public GeomancersRod() : base()
		{
			Id = 15978;
			Bonding = 2;
			SellPrice = 5385;
			AvailableClasses = 0x7FFF;
			Model = 28513;
			ObjectClass = 4;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Geomancer's Rod";
			Name2 = "Geomancer's Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2044;
			BuyPrice = 21542;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Embersilk Stave)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkStave : Item
	{
		public EmbersilkStave() : base()
		{
			Id = 15979;
			Bonding = 2;
			SellPrice = 7215;
			AvailableClasses = 0x7FFF;
			Model = 18289;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			ReqLevel = 37;
			Name = "Embersilk Stave";
			Name2 = "Embersilk Stave";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2044;
			BuyPrice = 23515;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Darkmist Orb)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistOrb : Item
	{
		public DarkmistOrb() : base()
		{
			Id = 15980;
			Bonding = 2;
			SellPrice = 7469;
			AvailableClasses = 0x7FFF;
			Model = 28505;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Darkmist Orb";
			Name2 = "Darkmist Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2056;
			BuyPrice = 29878;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Lunar Sphere)
*
***************************************************************/

namespace Server.Items
{
	public class LunarSphere : Item
	{
		public LunarSphere() : base()
		{
			Id = 15981;
			Bonding = 2;
			SellPrice = 7215;
			AvailableClasses = 0x7FFF;
			Model = 28553;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Lunar Sphere";
			Name2 = "Lunar Sphere";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2056;
			BuyPrice = 31548;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Rod)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenRod : Item
	{
		public BloodwovenRod() : base()
		{
			Id = 15982;
			Bonding = 2;
			SellPrice = 8142;
			AvailableClasses = 0x7FFF;
			Model = 28510;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloodwoven Rod";
			Name2 = "Bloodwoven Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2062;
			BuyPrice = 32568;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Gaea's Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasScepter : Item
	{
		public GaeasScepter() : base()
		{
			Id = 15983;
			Bonding = 2;
			SellPrice = 8387;
			AvailableClasses = 0x7FFF;
			Model = 28516;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Gaea's Scepter";
			Name2 = "Gaea's Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2068;
			BuyPrice = 33548;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Opulent Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentScepter : Item
	{
		public OpulentScepter() : base()
		{
			Id = 15984;
			Bonding = 2;
			SellPrice = 9614;
			AvailableClasses = 0x7FFF;
			Model = 27929;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Opulent Scepter";
			Name2 = "Opulent Scepter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2074;
			BuyPrice = 38458;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Branch)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianBranch : Item
	{
		public ArachnidianBranch() : base()
		{
			Id = 15985;
			Bonding = 2;
			SellPrice = 9887;
			AvailableClasses = 0x7FFF;
			Model = 28500;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Arachnidian Branch";
			Name2 = "Arachnidian Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2074;
			BuyPrice = 39548;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Star)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersStar : Item
	{
		public BonecastersStar() : base()
		{
			Id = 15986;
			Bonding = 2;
			SellPrice = 10813;
			AvailableClasses = 0x7FFF;
			Model = 20384;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Bonecaster's Star";
			Name2 = "Bonecaster's Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2080;
			BuyPrice = 43254;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Astral Orb)
*
***************************************************************/

namespace Server.Items
{
	public class AstralOrb : Item
	{
		public AstralOrb() : base()
		{
			Id = 15987;
			Bonding = 2;
			SellPrice = 10996;
			AvailableClasses = 0x7FFF;
			Model = 28501;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Astral Orb";
			Name2 = "Astral Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2086;
			BuyPrice = 43985;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Resplendent Orb)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentOrb : Item
	{
		public ResplendentOrb() : base()
		{
			Id = 15988;
			Bonding = 2;
			SellPrice = 12471;
			AvailableClasses = 0x7FFF;
			Model = 15884;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Resplendent Orb";
			Name2 = "Resplendent Orb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2086;
			BuyPrice = 49885;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Eternal Rod)
*
***************************************************************/

namespace Server.Items
{
	public class EternalRod : Item
	{
		public EternalRod() : base()
		{
			Id = 15989;
			Bonding = 2;
			SellPrice = 12498;
			AvailableClasses = 0x7FFF;
			Model = 28511;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Eternal Rod";
			Name2 = "Eternal Rod";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2092;
			BuyPrice = 49995;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 2000;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
		}
	}
}


/**************************************************************
*
*				(Voice Amplification Modulator)
*
***************************************************************/

namespace Server.Items
{
	public class VoiceAmplificationModulator : Item
	{
		public VoiceAmplificationModulator() : base()
		{
			Id = 16009;
			Bonding = 2;
			SellPrice = 5930;
			AvailableClasses = 0x7FFF;
			Model = 6497;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			Name = "Voice Amplification Modulator";
			Name2 = "Voice Amplification Modulator";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23720;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 19786 , 1 , 0 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Fordring's Seal)
*
***************************************************************/

namespace Server.Items
{
	public class FordringsSeal : Item
	{
		public FordringsSeal() : base()
		{
			Id = 16058;
			Bonding = 1;
			SellPrice = 10156;
			AvailableClasses = 0x7FFF;
			Model = 26001;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Fordring's Seal";
			Name2 = "Fordring's Seal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40625;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 18030 , 1 , 0 , 0 , 0 , 0 );
			SpiritBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Drakefire Amulet)
*
***************************************************************/

namespace Server.Items
{
	public class DrakefireAmulet : Item
	{
		public DrakefireAmulet() : base()
		{
			Id = 16309;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The Blood of Drakkisath Flows Within...";
			Model = 26950;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 50;
			Name = "Drakefire Amulet";
			Name2 = "Drakefire Amulet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsInsignia : Item
	{
		public SergeantsInsignia() : base()
		{
			Id = 16334;
			Bonding = 1;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 26001;
			ObjectClass = 4;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Sergeant's Insignia";
			Name2 = "Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			IqBonus = 6;
			StaminaBonus = 6;
			SpiritBonus = 6;
			AgilityBonus = 6;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Senior Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class SeniorSergeantsInsignia16335 : Item
	{
		public SeniorSergeantsInsignia16335() : base()
		{
			Id = 16335;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 30797;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Senior Sergeant's Insignia";
			Name2 = "Senior Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 17;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Opaline Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class OpalineMedallion : Item
	{
		public OpalineMedallion() : base()
		{
			Id = 16623;
			Bonding = 1;
			SellPrice = 7783;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			Name = "Opaline Medallion";
			Name2 = "Opaline Medallion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31135;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 13;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Furbolg Medicine Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class FurbolgMedicinePouch : Item
	{
		public FurbolgMedicinePouch() : base()
		{
			Id = 16768;
			Bonding = 1;
			SellPrice = 37500;
			AvailableClasses = 0x7FFF;
			Model = 28187;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			Name = "Furbolg Medicine Pouch";
			Name2 = "Furbolg Medicine Pouch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 150000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 20631 , 0 , 0 , 1200000 , 30 , 180000 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Witch's Finger)
*
***************************************************************/

namespace Server.Items
{
	public class WitchsFinger : Item
	{
		public WitchsFinger() : base()
		{
			Id = 16887;
			Bonding = 1;
			SellPrice = 1988;
			AvailableClasses = 0x7FFF;
			Model = 28588;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Witch's Finger";
			Name2 = "Witch's Finger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7954;
			InventoryType = InventoryTypes.HeldInHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			SpiritBonus = 7;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Alexis)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfAlexis : Item
	{
		public RoyalSealOfAlexis() : base()
		{
			Id = 16999;
			Bonding = 2;
			SellPrice = 10709;
			AvailableClasses = 0x7FFF;
			Model = 28830;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Royal Seal of Alexis";
			Name2 = "Royal Seal of Alexis";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42837;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			Flags = 16;
			SpiritBonus = 10;
			StaminaBonus = 10;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Elemental Circle)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalCircle : Item
	{
		public ElementalCircle() : base()
		{
			Id = 17001;
			Bonding = 1;
			SellPrice = 10314;
			AvailableClasses = 0x7FFF;
			Model = 28831;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Elemental Circle";
			Name2 = "Elemental Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41258;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Will of the Martyr)
*
***************************************************************/

namespace Server.Items
{
	public class WillOfTheMartyr : Item
	{
		public WillOfTheMartyr() : base()
		{
			Id = 17044;
			Bonding = 1;
			SellPrice = 15038;
			AvailableClasses = 0x7FFF;
			Model = 23716;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Will of the Martyr";
			Name2 = "Will of the Martyr";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60155;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 5;
			SetSpell( 9336 , 1 , 0 , 0 , 0 , 0 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blood of the Martyr)
*
***************************************************************/

namespace Server.Items
{
	public class BloodOfTheMartyr : Item
	{
		public BloodOfTheMartyr() : base()
		{
			Id = 17045;
			Bonding = 1;
			SellPrice = 14846;
			AvailableClasses = 0x7FFF;
			Model = 28682;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			Name = "Blood of the Martyr";
			Name2 = "Blood of the Martyr";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59387;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 15;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Band of Accuria)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfAccuria : Item
	{
		public BandOfAccuria() : base()
		{
			Id = 17063;
			Bonding = 1;
			SellPrice = 23961;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 78;
			ReqLevel = 60;
			Name = "Band of Accuria";
			Name2 = "Band of Accuria";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 95846;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 15465 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 10;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Shard of the Scale)
*
***************************************************************/

namespace Server.Items
{
	public class ShardOfTheScale : Item
	{
		public ShardOfTheScale() : base()
		{
			Id = 17064;
			Bonding = 1;
			SellPrice = 45914;
			AvailableClasses = 0x7FFF;
			Model = 26374;
			ObjectClass = 4;
			SubClass = 0;
			Level = 71;
			ReqLevel = 60;
			Name = "Shard of the Scale";
			Name2 = "Shard of the Scale";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 183658;
			Sets = 241;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 2;
			SetSpell( 23212 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Medallion of Steadfast Might)
*
***************************************************************/

namespace Server.Items
{
	public class MedallionOfSteadfastMight : Item
	{
		public MedallionOfSteadfastMight() : base()
		{
			Id = 17065;
			Bonding = 1;
			SellPrice = 33381;
			AvailableClasses = 0x7FFF;
			Model = 4841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 68;
			ReqLevel = 60;
			Name = "Medallion of Steadfast Might";
			Name2 = "Medallion of Steadfast Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 133525;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ancient Cornerstone Grimoire)
*
***************************************************************/

namespace Server.Items
{
	public class AncientCornerstoneGrimoire : Item
	{
		public AncientCornerstoneGrimoire() : base()
		{
			Id = 17067;
			Bonding = 1;
			SellPrice = 75452;
			AvailableClasses = 0x7FFF;
			Model = 29717;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Ancient Cornerstone Grimoire";
			Name2 = "Ancient Cornerstone Grimoire";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 301810;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 17490 , 0 , 0 , 900000 , 94 , 60000 );
			IqBonus = 11;
			SpiritBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Shard of the Flame)
*
***************************************************************/

namespace Server.Items
{
	public class ShardOfTheFlame : Item
	{
		public ShardOfTheFlame() : base()
		{
			Id = 17082;
			Bonding = 1;
			SellPrice = 46146;
			AvailableClasses = 0x7FFF;
			Model = 29722;
			ObjectClass = 4;
			SubClass = 0;
			Level = 74;
			ReqLevel = 60;
			Name = "Shard of the Flame";
			Name2 = "Shard of the Flame";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 184585;
			Sets = 241;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 2;
			SetSpell( 23210 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Choker of Enlightenment)
*
***************************************************************/

namespace Server.Items
{
	public class ChokerOfEnlightenment : Item
	{
		public ChokerOfEnlightenment() : base()
		{
			Id = 17109;
			Bonding = 1;
			SellPrice = 33625;
			AvailableClasses = 0x7FFF;
			Model = 9858;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Choker of Enlightenment";
			Name2 = "Choker of Enlightenment";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 134500;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 9346 , 1 , 0 , 0 , 0 , 0 );
			SpiritBonus = 10;
			IqBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Seal of the Archmagus)
*
***************************************************************/

namespace Server.Items
{
	public class SealOfTheArchmagus : Item
	{
		public SealOfTheArchmagus() : base()
		{
			Id = 17110;
			Resistance[6] = 6;
			Bonding = 1;
			SellPrice = 24648;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			Resistance[2] = 6;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 0;
			Level = 70;
			ReqLevel = 60;
			Name = "Seal of the Archmagus";
			Name2 = "Seal of the Archmagus";
			Resistance[3] = 6;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 98595;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 21361 , 1 , 0 , 0 , 0 , -1 );
			SpiritBonus = 11;
			StaminaBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Blazefury Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class BlazefuryMedallion : Item
	{
		public BlazefuryMedallion() : base()
		{
			Id = 17111;
			Bonding = 1;
			SellPrice = 34648;
			AvailableClasses = 0x7FFF;
			Model = 6484;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 0;
			Level = 68;
			ReqLevel = 60;
			Name = "Blazefury Medallion";
			Name2 = "Blazefury Medallion";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 138595;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 7711 , 1 , 0 , 0 , 0 , 0 );
			AgilityBonus = 13;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 1)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank1 : Item
	{
		public FrostwolfInsigniaRank1() : base()
		{
			Id = 17690;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31475;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 1";
			Name2 = "Frostwolf Insignia Rank 1";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 1)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank1 : Item
	{
		public StormpikeInsigniaRank1() : base()
		{
			Id = 17691;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31480;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 1";
			Name2 = "Stormpike Insignia Rank 1";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Horn Ring)
*
***************************************************************/

namespace Server.Items
{
	public class HornRing : Item
	{
		public HornRing() : base()
		{
			Id = 17692;
			Bonding = 1;
			SellPrice = 881;
			AvailableClasses = 0x7FFF;
			Model = 4284;
			ObjectClass = 4;
			SubClass = 0;
			Level = 23;
			Name = "Horn Ring";
			Name2 = "Horn Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3525;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Band of the Fist)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheFist : Item
	{
		public BandOfTheFist() : base()
		{
			Id = 17694;
			Bonding = 1;
			SellPrice = 881;
			AvailableClasses = 0x7FFF;
			Model = 4284;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Band of the Fist";
			Name2 = "Band of the Fist";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3525;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			AgilityBonus = 3;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gemshard Heart)
*
***************************************************************/

namespace Server.Items
{
	public class GemshardHeart : Item
	{
		public GemshardHeart() : base()
		{
			Id = 17707;
			Bonding = 1;
			SellPrice = 11631;
			AvailableClasses = 0x7FFF;
			Model = 29842;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Gemshard Heart";
			Name2 = "Gemshard Heart";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46525;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 64;
			SpiritBonus = 10;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blackstone Ring)
*
***************************************************************/

namespace Server.Items
{
	public class BlackstoneRing : Item
	{
		public BlackstoneRing() : base()
		{
			Id = 17713;
			Bonding = 1;
			SellPrice = 14641;
			AvailableClasses = 0x7FFF;
			Model = 23629;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Blackstone Ring";
			Name2 = "Blackstone Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58565;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SetSpell( 9331 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cloud Stone)
*
***************************************************************/

namespace Server.Items
{
	public class CloudStone : Item
	{
		public CloudStone() : base()
		{
			Id = 17737;
			Resistance[6] = 10;
			Bonding = 1;
			SellPrice = 10163;
			AvailableClasses = 0x7FFF;
			Model = 29914;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Cloud Stone";
			Name2 = "Cloud Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40655;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SpiritBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Heart of Noxxion)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfNoxxion : Item
	{
		public HeartOfNoxxion() : base()
		{
			Id = 17744;
			Bonding = 1;
			SellPrice = 9031;
			AvailableClasses = 0x7FFF;
			Model = 29922;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Heart of Noxxion";
			Name2 = "Heart of Noxxion";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36125;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 5;
			SetSpell( 21954 , 0 , 0 , 0 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Mark of Resolution)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfResolution : Item
	{
		public MarkOfResolution() : base()
		{
			Id = 17759;
			Bonding = 1;
			SellPrice = 10307;
			AvailableClasses = 0x7FFF;
			Model = 23716;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Mark of Resolution";
			Name2 = "Mark of Resolution";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41230;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 21956 , 0 , 0 , 1800000 , 28 , 300000 );
			SetSpell( 21958 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Woodseed Hoop)
*
***************************************************************/

namespace Server.Items
{
	public class WoodseedHoop : Item
	{
		public WoodseedHoop() : base()
		{
			Id = 17768;
			Bonding = 1;
			SellPrice = 7891;
			AvailableClasses = 0x7FFF;
			Model = 23608;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Woodseed Hoop";
			Name2 = "Woodseed Hoop";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31565;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SpiritBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Zealous Shadowshard Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ZealousShadowshardPendant : Item
	{
		public ZealousShadowshardPendant() : base()
		{
			Id = 17772;
			Bonding = 1;
			SellPrice = 7132;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			Name = "Zealous Shadowshard Pendant";
			Name2 = "Zealous Shadowshard Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28530;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 9331 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Prodigious Shadowshard Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ProdigiousShadowshardPendant : Item
	{
		public ProdigiousShadowshardPendant() : base()
		{
			Id = 17773;
			Bonding = 1;
			SellPrice = 7132;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 42;
			Name = "Prodigious Shadowshard Pendant";
			Name2 = "Prodigious Shadowshard Pendant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28530;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Mark of the Chosen)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfTheChosen : Item
	{
		public MarkOfTheChosen() : base()
		{
			Id = 17774;
			Bonding = 1;
			SellPrice = 6133;
			AvailableClasses = 0x7FFF;
			Model = 29947;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			Name = "Mark of the Chosen";
			Name2 = "Mark of the Chosen";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24535;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 5;
			SetSpell( 21969 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Talisman of Binding Shard)
*
***************************************************************/

namespace Server.Items
{
	public class TalismanOfBindingShard : Item
	{
		public TalismanOfBindingShard() : base()
		{
			Id = 17782;
			Bonding = 1;
			SellPrice = 33625;
			AvailableClasses = 0x7FFF;
			Model = 6494;
			Resistance[2] = 24;
			ObjectClass = 4;
			SubClass = 0;
			Level = 80;
			ReqLevel = 60;
			Name = "Talisman of Binding Shard";
			Name2 = "Talisman of Binding Shard";
			Resistance[3] = 24;
			Quality = 5;
			AvailableRaces = 0x1FF;
			BuyPrice = 134500;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			Flags = 16;
			SetSpell( 21991 , 1 , 0 , 0 , 0 , 0 );
			StrBonus = 13;
			StaminaBonus = 8;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 2)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank2 : Item
	{
		public StormpikeInsigniaRank2() : base()
		{
			Id = 17900;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31480;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 2";
			Name2 = "Stormpike Insignia Rank 2";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 3)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank3 : Item
	{
		public StormpikeInsigniaRank3() : base()
		{
			Id = 17901;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31481;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 3";
			Name2 = "Stormpike Insignia Rank 3";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 4)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank4 : Item
	{
		public StormpikeInsigniaRank4() : base()
		{
			Id = 17902;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31482;
			Resistance[4] = 8;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 4";
			Name2 = "Stormpike Insignia Rank 4";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21596 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 5)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank5 : Item
	{
		public StormpikeInsigniaRank5() : base()
		{
			Id = 17903;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31483;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 5";
			Name2 = "Stormpike Insignia Rank 5";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21600 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Insignia Rank 6)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeInsigniaRank6 : Item
	{
		public StormpikeInsigniaRank6() : base()
		{
			Id = 17904;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The Eye of Command";
			Model = 31484;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Stormpike Insignia Rank 6";
			Name2 = "Stormpike Insignia Rank 6";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 20885 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22564 , 0 , 0 , 0 , 1091 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 2)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank2 : Item
	{
		public FrostwolfInsigniaRank2() : base()
		{
			Id = 17905;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31475;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 2";
			Name2 = "Frostwolf Insignia Rank 2";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 3)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank3 : Item
	{
		public FrostwolfInsigniaRank3() : base()
		{
			Id = 17906;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31476;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 3";
			Name2 = "Frostwolf Insignia Rank 3";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 4)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank4 : Item
	{
		public FrostwolfInsigniaRank4() : base()
		{
			Id = 17907;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31477;
			Resistance[4] = 8;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 4";
			Name2 = "Frostwolf Insignia Rank 4";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21596 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 5)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank5 : Item
	{
		public FrostwolfInsigniaRank5() : base()
		{
			Id = 17908;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31478;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 5";
			Name2 = "Frostwolf Insignia Rank 5";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 21600 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Insignia Rank 6)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfInsigniaRank6 : Item
	{
		public FrostwolfInsigniaRank6() : base()
		{
			Id = 17909;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The Eye of Command";
			Model = 31479;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Frostwolf Insignia Rank 6";
			Name2 = "Frostwolf Insignia Rank 6";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32832;
			SetSpell( 20885 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22563 , 0 , 0 , 0 , 1091 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Ragnaros Core)
*
***************************************************************/

namespace Server.Items
{
	public class RagnarosCore : Item
	{
		public RagnarosCore() : base()
		{
			Id = 17982;
			Bonding = 1;
			SellPrice = 23961;
			AvailableClasses = 0x7FFF;
			Model = 28682;
			Resistance[2] = 18;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Ragnaros Core";
			Name2 = "Ragnaros Core";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3474;
			BuyPrice = 95846;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Alexis)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfAlexis18022 : Item
	{
		public RoyalSealOfAlexis18022() : base()
		{
			Id = 18022;
			Bonding = 1;
			SellPrice = 10709;
			AvailableClasses = 0x7FFF;
			Model = 28830;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Alexis";
			Name2 = "Royal Seal of Alexis";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42837;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SpiritBonus = 10;
			StaminaBonus = 10;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Band of Rumination)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfRumination : Item
	{
		public BandOfRumination() : base()
		{
			Id = 18103;
			Bonding = 1;
			SellPrice = 15252;
			AvailableClasses = 0x7FFF;
			Model = 24022;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Band of Rumination";
			Name2 = "Band of Rumination";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61010;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			SetSpell( 21620 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eskhandar's Collar)
*
***************************************************************/

namespace Server.Items
{
	public class EskhandarsCollar : Item
	{
		public EskhandarsCollar() : base()
		{
			Id = 18205;
			Bonding = 1;
			SellPrice = 33287;
			AvailableClasses = 0x7FFF;
			Model = 16132;
			ObjectClass = 4;
			SubClass = 0;
			Level = 71;
			ReqLevel = 60;
			Name = "Eskhandar's Collar";
			Name2 = "Eskhandar's Collar";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 133150;
			Sets = 261;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Barbed Thorn Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class BarbedThornNecklace : Item
	{
		public BarbedThornNecklace() : base()
		{
			Id = 18289;
			Bonding = 1;
			SellPrice = 9701;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 4;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Barbed Thorn Necklace";
			Name2 = "Barbed Thorn Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38804;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 2;
			SetSpell( 9358 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Band of Vigor)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfVigor : Item
	{
		public BandOfVigor() : base()
		{
			Id = 18302;
			Bonding = 1;
			SellPrice = 7530;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Band of Vigor";
			Name2 = "Band of Vigor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30122;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			StrBonus = 8;
			StaminaBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ring of Demonic Guile)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfDemonicGuile : Item
	{
		public RingOfDemonicGuile() : base()
		{
			Id = 18314;
			Bonding = 1;
			SellPrice = 12100;
			AvailableClasses = 0x7FFF;
			Model = 24646;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Ring of Demonic Guile";
			Name2 = "Ring of Demonic Guile";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48400;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ring of Demonic Potency)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfDemonicPotency : Item
	{
		public RingOfDemonicPotency() : base()
		{
			Id = 18315;
			Bonding = 1;
			SellPrice = 12100;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Ring of Demonic Potency";
			Name2 = "Ring of Demonic Potency";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48400;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 5;
			SetSpell( 21598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Tempest Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class TempestTalisman : Item
	{
		public TempestTalisman() : base()
		{
			Id = 18317;
			Bonding = 1;
			SellPrice = 12503;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			ObjectClass = 4;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Tempest Talisman";
			Name2 = "Tempest Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50012;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Eidolon Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class EidolonTalisman : Item
	{
		public EidolonTalisman() : base()
		{
			Id = 18340;
			Bonding = 1;
			SellPrice = 28853;
			AvailableClasses = 0x7FFF;
			Model = 30696;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Eidolon Talisman";
			Name2 = "Eidolon Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 115412;
			Resistance[5] = 15;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Petrified Band)
*
***************************************************************/

namespace Server.Items
{
	public class PetrifiedBand : Item
	{
		public PetrifiedBand() : base()
		{
			Id = 18343;
			Bonding = 1;
			SellPrice = 14615;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 59;
			Name = "Petrified Band";
			Name2 = "Petrified Band";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58462;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Murmuring Ring)
*
***************************************************************/

namespace Server.Items
{
	public class MurmuringRing : Item
	{
		public MurmuringRing() : base()
		{
			Id = 18345;
			Bonding = 1;
			SellPrice = 14727;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Murmuring Ring";
			Name2 = "Murmuring Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58908;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 18985 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Pimgib's Collar)
*
***************************************************************/

namespace Server.Items
{
	public class PimgibsCollar : Item
	{
		public PimgibsCollar() : base()
		{
			Id = 18354;
			Bonding = 1;
			SellPrice = 17466;
			AvailableClasses = 0x7B00;
			Model = 1399;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Pimgib's Collar";
			Name2 = "Pimgib's Collar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 69864;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 22855 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Vigilance Charm)
*
***************************************************************/

namespace Server.Items
{
	public class VigilanceCharm : Item
	{
		public VigilanceCharm() : base()
		{
			Id = 18370;
			Bonding = 1;
			SellPrice = 21612;
			AvailableClasses = 0x7FFF;
			Model = 30722;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Vigilance Charm";
			Name2 = "Vigilance Charm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86450;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 3;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mindtap Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class MindtapTalisman : Item
	{
		public MindtapTalisman() : base()
		{
			Id = 18371;
			Bonding = 1;
			SellPrice = 20737;
			AvailableClasses = 0x7FFF;
			Model = 30723;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Mindtap Talisman";
			Name2 = "Mindtap Talisman";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82948;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 3;
			SetSpell( 21366 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Evil Eye Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class EvilEyePendant : Item
	{
		public EvilEyePendant() : base()
		{
			Id = 18381;
			Bonding = 1;
			SellPrice = 21635;
			AvailableClasses = 0x7FFF;
			Model = 30738;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Evil Eye Pendant";
			Name2 = "Evil Eye Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86542;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Emerald Flame Ring)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldFlameRing : Item
	{
		public EmeraldFlameRing() : base()
		{
			Id = 18395;
			Bonding = 1;
			SellPrice = 36645;
			AvailableClasses = 0x7FFF;
			Model = 9842;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Emerald Flame Ring";
			Name2 = "Emerald Flame Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 146580;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 7681 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Elder Magus Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class ElderMagusPendant : Item
	{
		public ElderMagusPendant() : base()
		{
			Id = 18397;
			Bonding = 1;
			SellPrice = 22464;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Elder Magus Pendant";
			Name2 = "Elder Magus Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89857;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 10;
			IqBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tidal Loop)
*
***************************************************************/

namespace Server.Items
{
	public class TidalLoop : Item
	{
		public TidalLoop() : base()
		{
			Id = 18398;
			Bonding = 1;
			SellPrice = 27103;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Tidal Loop";
			Name2 = "Tidal Loop";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108413;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 4;
			SpiritBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ocean's Breeze)
*
***************************************************************/

namespace Server.Items
{
	public class OceansBreeze : Item
	{
		public OceansBreeze() : base()
		{
			Id = 18399;
			Bonding = 1;
			SellPrice = 27103;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			Name = "Ocean's Breeze";
			Name2 = "Ocean's Breeze";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108413;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			AgilityBonus = 7;
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ring of Living Stone)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfLivingStone : Item
	{
		public RingOfLivingStone() : base()
		{
			Id = 18400;
			Bonding = 1;
			SellPrice = 14853;
			AvailableClasses = 0x7FFF;
			Model = 26001;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			Name = "Ring of Living Stone";
			Name2 = "Ring of Living Stone";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59412;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			StrBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Glowing Crystal Ring)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingCrystalRing : Item
	{
		public GlowingCrystalRing() : base()
		{
			Id = 18402;
			Bonding = 1;
			SellPrice = 18662;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			ObjectClass = 4;
			SubClass = 0;
			Level = 57;
			Name = "Glowing Crystal Ring";
			Name2 = "Glowing Crystal Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74651;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Dragonslayer's Signet)
*
***************************************************************/

namespace Server.Items
{
	public class DragonslayersSignet : Item
	{
		public DragonslayersSignet() : base()
		{
			Id = 18403;
			Bonding = 1;
			SellPrice = 49060;
			AvailableClasses = 0x7FFF;
			Model = 26391;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 74;
			Name = "Dragonslayer's Signet";
			Name2 = "Dragonslayer's Signet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 196240;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 6;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Onyxia Tooth Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxiaToothPendant : Item
	{
		public OnyxiaToothPendant() : base()
		{
			Id = 18404;
			Bonding = 1;
			SellPrice = 6714;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 74;
			Name = "Onyxia Tooth Pendant";
			Name2 = "Onyxia Tooth Pendant";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 26856;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Onyxia Blood Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxiaBloodTalisman : Item
	{
		public OnyxiaBloodTalisman() : base()
		{
			Id = 18406;
			Bonding = 1;
			SellPrice = 46030;
			AvailableClasses = 0x7FFF;
			Model = 30764;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 74;
			Name = "Onyxia Blood Talisman";
			Name2 = "Onyxia Blood Talisman";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 184123;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 3;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21601 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Kreeg's Mug)
*
***************************************************************/

namespace Server.Items
{
	public class KreegsMug : Item
	{
		public KreegsMug() : base()
		{
			Id = 18425;
			Bonding = 1;
			SellPrice = 5537;
			AvailableClasses = 0x7FFF;
			Model = 30796;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Kreeg's Mug";
			Name2 = "Kreeg's Mug";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22150;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			StaminaBonus = 12;
			IqBonus = 15;
			SpiritBonus = -10;
		}
	}
}


/**************************************************************
*
*				(Senior Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class SeniorSergeantsInsignia18428 : Item
	{
		public SeniorSergeantsInsignia18428() : base()
		{
			Id = 18428;
			Bonding = 1;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 30797;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Senior Sergeant's Insignia";
			Name2 = "Senior Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 14;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Master Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class MasterSergeantsInsignia : Item
	{
		public MasterSergeantsInsignia() : base()
		{
			Id = 18442;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 30799;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Master Sergeant's Insignia";
			Name2 = "Master Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Master Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class MasterSergeantsInsignia18443 : Item
	{
		public MasterSergeantsInsignia18443() : base()
		{
			Id = 18443;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 30799;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Master Sergeant's Insignia";
			Name2 = "Master Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 17;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Master Sergeant's Insignia)
*
***************************************************************/

namespace Server.Items
{
	public class MasterSergeantsInsignia18444 : Item
	{
		public MasterSergeantsInsignia18444() : base()
		{
			Id = 18444;
			Bonding = 1;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 30799;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Master Sergeant's Insignia";
			Name2 = "Master Sergeant's Insignia";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Flags = 32768;
			StaminaBonus = 14;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Gordok Nose Ring)
*
***************************************************************/

namespace Server.Items
{
	public class GordokNoseRing : Item
	{
		public GordokNoseRing() : base()
		{
			Id = 18464;
			Bonding = 1;
			SellPrice = 29135;
			AvailableClasses = 0x7FFF;
			Model = 9849;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Gordok Nose Ring";
			Name2 = "Gordok Nose Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 116541;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			StaminaBonus = 9;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas : Item
	{
		public RoyalSealOfEldreThalas() : base()
		{
			Id = 18465;
			Bonding = 1;
			AvailableClasses = 0x08;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18466 : Item
	{
		public RoyalSealOfEldreThalas18466() : base()
		{
			Id = 18466;
			Bonding = 1;
			AvailableClasses = 0x01;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 14803 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18467 : Item
	{
		public RoyalSealOfEldreThalas18467() : base()
		{
			Id = 18467;
			Bonding = 1;
			AvailableClasses = 0x100;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18468 : Item
	{
		public RoyalSealOfEldreThalas18468() : base()
		{
			Id = 18468;
			Bonding = 1;
			AvailableClasses = 0x80;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18469 : Item
	{
		public RoyalSealOfEldreThalas18469() : base()
		{
			Id = 18469;
			Bonding = 1;
			AvailableClasses = 0x10;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18470 : Item
	{
		public RoyalSealOfEldreThalas18470() : base()
		{
			Id = 18470;
			Bonding = 1;
			AvailableClasses = 0x400;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 17371 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18471 : Item
	{
		public RoyalSealOfEldreThalas18471() : base()
		{
			Id = 18471;
			Bonding = 1;
			AvailableClasses = 0x40;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18472 : Item
	{
		public RoyalSealOfEldreThalas18472() : base()
		{
			Id = 18472;
			Bonding = 1;
			AvailableClasses = 0x02;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 15693 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Royal Seal of Eldre'Thalas)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalSealOfEldreThalas18473 : Item
	{
		public RoyalSealOfEldreThalas18473() : base()
		{
			Id = 18473;
			Bonding = 1;
			AvailableClasses = 0x04;
			Description = "Blessed by the Shen'dralar Ancients.";
			Model = 29712;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			Name = "Royal Seal of Eldre'Thalas";
			Name2 = "Royal Seal of Eldre'Thalas";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 21445 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tarnished Elven Ring)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedElvenRing : Item
	{
		public TarnishedElvenRing() : base()
		{
			Id = 18500;
			Bonding = 1;
			SellPrice = 31340;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Tarnished Elven Ring";
			Name2 = "Tarnished Elven Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125360;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Band of the Ogre King)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfTheOgreKing : Item
	{
		public BandOfTheOgreKing() : base()
		{
			Id = 18522;
			Bonding = 1;
			SellPrice = 36253;
			AvailableClasses = 0x7FFF;
			Model = 23897;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Band of the Ogre King";
			Name2 = "Band of the Ogre King";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 145013;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			StrBonus = 14;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Brightly Glowing Stone)
*
***************************************************************/

namespace Server.Items
{
	public class BrightlyGlowingStone : Item
	{
		public BrightlyGlowingStone() : base()
		{
			Id = 18523;
			Bonding = 1;
			SellPrice = 34810;
			AvailableClasses = 0x7FFF;
			Model = 30855;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Brightly Glowing Stone";
			Name2 = "Brightly Glowing Stone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 139243;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			Sheath = 7;
			SetSpell( 18030 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Milli's Lexicon)
*
***************************************************************/

namespace Server.Items
{
	public class MillisLexicon : Item
	{
		public MillisLexicon() : base()
		{
			Id = 18536;
			Bonding = 1;
			SellPrice = 38664;
			AvailableClasses = 0x7FFF;
			Model = 30875;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			Name = "Milli's Lexicon";
			Name2 = "Milli's Lexicon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 154658;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 8;
			Sheath = 7;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Counterattack Lodestone)
*
***************************************************************/

namespace Server.Items
{
	public class CounterattackLodestone : Item
	{
		public CounterattackLodestone() : base()
		{
			Id = 18537;
			Bonding = 1;
			SellPrice = 66135;
			AvailableClasses = 0x7FFF;
			Model = 21072;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Counterattack Lodestone";
			Name2 = "Counterattack Lodestone";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 264540;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 3;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ring of Entropy)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfEntropy : Item
	{
		public RingOfEntropy() : base()
		{
			Id = 18543;
			Bonding = 1;
			SellPrice = 63728;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Ring of Entropy";
			Name2 = "Ring of Entropy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 254912;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			StaminaBonus = 11;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Band of Allegiance)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfAllegiance : Item
	{
		public BandOfAllegiance() : base()
		{
			Id = 18585;
			Bonding = 1;
			SellPrice = 14853;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Band of Allegiance";
			Name2 = "Band of Allegiance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59413;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			StrBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lonetree's Circle)
*
***************************************************************/

namespace Server.Items
{
	public class LonetreesCircle : Item
	{
		public LonetreesCircle() : base()
		{
			Id = 18586;
			Bonding = 1;
			SellPrice = 14853;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Lonetree's Circle";
			Name2 = "Lonetree's Circle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59413;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SpiritBonus = 6;
			StaminaBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tome of Sacrifice)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfSacrifice : Item
	{
		public TomeOfSacrifice() : base()
		{
			Id = 18602;
			Bonding = 1;
			AvailableClasses = 0x100;
			Model = 30875;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			Name = "Tome of Sacrifice";
			Name2 = "Tome of Sacrifice";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 21348 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(The Eye of Divinity)
*
***************************************************************/

namespace Server.Items
{
	public class TheEyeOfDivinity : Item
	{
		public TheEyeOfDivinity() : base()
		{
			Id = 18646;
			Bonding = 1;
			AvailableClasses = 0x10;
			Description = "You can see movement when you peer into the Eye.";
			Model = 31029;
			ObjectClass = 4;
			SubClass = 0;
			Level = 71;
			ReqLevel = 60;
			Name = "The Eye of Divinity";
			Name2 = "The Eye of Divinity";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2659;
			PageMaterial = 2;
			SetSpell( 23101 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(The Eye of Shadow)
*
***************************************************************/

namespace Server.Items
{
	public class TheEyeOfShadow : Item
	{
		public TheEyeOfShadow() : base()
		{
			Id = 18665;
			Bonding = 2;
			AvailableClasses = 0x5FF;
			Description = "Seething darkness engulfs the eye.";
			Model = 31096;
			ObjectClass = 4;
			SubClass = 0;
			Level = 71;
			ReqLevel = 60;
			Name = "The Eye of Shadow";
			Name2 = "The Eye of Shadow";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Elemental Ember)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalEmber : Item
	{
		public ElementalEmber() : base()
		{
			Id = 18672;
			Bonding = 2;
			SellPrice = 17855;
			AvailableClasses = 0x7FFF;
			Model = 31120;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Elemental Ember";
			Name2 = "Elemental Ember";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71420;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			SetSpell( 9400 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Hardened Stone Band)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedStoneBand : Item
	{
		public HardenedStoneBand() : base()
		{
			Id = 18674;
			Bonding = 2;
			SellPrice = 22003;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Hardened Stone Band";
			Name2 = "Hardened Stone Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 88014;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 1;
			SetSpell( 7516 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Tempestria's Frozen Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TempestriasFrozenNecklace : Item
	{
		public TempestriasFrozenNecklace() : base()
		{
			Id = 18678;
			Bonding = 2;
			SellPrice = 26635;
			AvailableClasses = 0x7FFF;
			Model = 9853;
			Resistance[4] = 15;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Tempestria's Frozen Necklace";
			Name2 = "Tempestria's Frozen Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 106541;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			StaminaBonus = 8;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Frigid Ring)
*
***************************************************************/

namespace Server.Items
{
	public class FrigidRing : Item
	{
		public FrigidRing() : base()
		{
			Id = 18679;
			Bonding = 2;
			SellPrice = 25136;
			AvailableClasses = 0x7FFF;
			Model = 28831;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Frigid Ring";
			Name2 = "Frigid Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 100546;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 9404 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dimly Opalescent Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DimlyOpalescentRing : Item
	{
		public DimlyOpalescentRing() : base()
		{
			Id = 18684;
			Bonding = 1;
			SellPrice = 36141;
			AvailableClasses = 0x7FFF;
			Model = 9840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Dimly Opalescent Ring";
			Name2 = "Dimly Opalescent Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3306;
			BuyPrice = 144564;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dark Advisor's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class DarkAdvisorsPendant : Item
	{
		public DarkAdvisorsPendant() : base()
		{
			Id = 18691;
			Bonding = 1;
			SellPrice = 31400;
			AvailableClasses = 0x7FFF;
			Model = 15420;
			ObjectClass = 4;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Dark Advisor's Pendant";
			Name2 = "Dark Advisor's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125601;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 9327 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Spellbound Tome)
*
***************************************************************/

namespace Server.Items
{
	public class SpellboundTome : Item
	{
		public SpellboundTome() : base()
		{
			Id = 18695;
			Bonding = 1;
			SellPrice = 34450;
			AvailableClasses = 0x7FFF;
			Model = 31138;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Spellbound Tome";
			Name2 = "Spellbound Tome";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 137801;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 8;
			SpiritBonus = 17;
			StaminaBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Innervating Band)
*
***************************************************************/

namespace Server.Items
{
	public class InnervatingBand : Item
	{
		public InnervatingBand() : base()
		{
			Id = 18701;
			Bonding = 1;
			SellPrice = 36410;
			AvailableClasses = 0x7FFF;
			Model = 28733;
			ObjectClass = 4;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Innervating Band";
			Name2 = "Innervating Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 145640;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			AgilityBonus = 15;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Animated Chain Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class AnimatedChainNecklace : Item
	{
		public AnimatedChainNecklace() : base()
		{
			Id = 18723;
			Bonding = 1;
			SellPrice = 41953;
			AvailableClasses = 0x7FFF;
			Model = 6539;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Animated Chain Necklace";
			Name2 = "Animated Chain Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 167814;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Anastari Heirloom)
*
***************************************************************/

namespace Server.Items
{
	public class AnastariHeirloom : Item
	{
		public AnastariHeirloom() : base()
		{
			Id = 18728;
			Bonding = 1;
			SellPrice = 32466;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Anastari Heirloom";
			Name2 = "Anastari Heirloom";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 129865;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 9413 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Necromantic Band)
*
***************************************************************/

namespace Server.Items
{
	public class NecromanticBand : Item
	{
		public NecromanticBand() : base()
		{
			Id = 18760;
			Bonding = 1;
			SellPrice = 30866;
			AvailableClasses = 0x7FFF;
			Model = 9839;
			ObjectClass = 4;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Necromantic Band";
			Name2 = "Necromantic Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 123465;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 20885 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shard of the Green Flame)
*
***************************************************************/

namespace Server.Items
{
	public class ShardOfTheGreenFlame : Item
	{
		public ShardOfTheGreenFlame() : base()
		{
			Id = 18762;
			Bonding = 1;
			SellPrice = 27631;
			AvailableClasses = 0x7FFF;
			Model = 31223;
			ObjectClass = 4;
			SubClass = 0;
			Level = 54;
			Name = "Shard of the Green Flame";
			Name2 = "Shard of the Green Flame";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 110526;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			SetSpell( 9294 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ring of Binding)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfBinding : Item
	{
		public RingOfBinding() : base()
		{
			Id = 18813;
			Resistance[6] = 10;
			Resistance[0] = 60;
			Bonding = 1;
			SellPrice = 89103;
			AvailableClasses = 0x7FFF;
			Model = 9823;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 0;
			Level = 73;
			Name = "Ring of Binding";
			Name2 = "Ring of Binding";
			Resistance[3] = 10;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 356412;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 7517 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Choker of the Fire Lord)
*
***************************************************************/

namespace Server.Items
{
	public class ChokerOfTheFireLord : Item
	{
		public ChokerOfTheFireLord() : base()
		{
			Id = 18814;
			Bonding = 1;
			SellPrice = 89135;
			AvailableClasses = 0x7FFF;
			Model = 1399;
			ObjectClass = 4;
			SubClass = 0;
			Level = 78;
			ReqLevel = 60;
			Name = "Choker of the Fire Lord";
			Name2 = "Choker of the Fire Lord";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 356542;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 18052 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Essence of the Pure Flame)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfThePureFlame : Item
	{
		public EssenceOfThePureFlame() : base()
		{
			Id = 18815;
			Bonding = 1;
			SellPrice = 64095;
			AvailableClasses = 0x7FFF;
			Model = 31282;
			ObjectClass = 4;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Essence of the Pure Flame";
			Name2 = "Essence of the Pure Flame";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 256380;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23266 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Talisman of Ephemeral Power)
*
***************************************************************/

namespace Server.Items
{
	public class TalismanOfEphemeralPower : Item
	{
		public TalismanOfEphemeralPower() : base()
		{
			Id = 18820;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31287;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Talisman of Ephemeral Power";
			Name2 = "Talisman of Ephemeral Power";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 64;
			SetSpell( 23271 , 0 , 0 , 90000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Quick Strike Ring)
*
***************************************************************/

namespace Server.Items
{
	public class QuickStrikeRing : Item
	{
		public QuickStrikeRing() : base()
		{
			Id = 18821;
			Bonding = 1;
			SellPrice = 64030;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 4;
			SubClass = 0;
			Level = 67;
			ReqLevel = 60;
			Name = "Quick Strike Ring";
			Name2 = "Quick Strike Ring";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 256120;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde : Item
	{
		public InsigniaOfTheHorde() : base()
		{
			Id = 18834;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x01;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 5579 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18845 : Item
	{
		public InsigniaOfTheHorde18845() : base()
		{
			Id = 18845;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x40;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 5579 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18846 : Item
	{
		public InsigniaOfTheHorde18846() : base()
		{
			Id = 18846;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x04;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 5579 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18849 : Item
	{
		public InsigniaOfTheHorde18849() : base()
		{
			Id = 18849;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x08;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23273 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18850 : Item
	{
		public InsigniaOfTheHorde18850() : base()
		{
			Id = 18850;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x80;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23274 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18851 : Item
	{
		public InsigniaOfTheHorde18851() : base()
		{
			Id = 18851;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x10;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23276 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18852 : Item
	{
		public InsigniaOfTheHorde18852() : base()
		{
			Id = 18852;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x100;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23273 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Horde)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheHorde18853 : Item
	{
		public InsigniaOfTheHorde18853() : base()
		{
			Id = 18853;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x400;
			Model = 31306;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Horde";
			Name2 = "Insignia of the Horde";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23277 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance : Item
	{
		public InsigniaOfTheAlliance() : base()
		{
			Id = 18854;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x01;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 5579 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18856 : Item
	{
		public InsigniaOfTheAlliance18856() : base()
		{
			Id = 18856;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x04;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 5579 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18857 : Item
	{
		public InsigniaOfTheAlliance18857() : base()
		{
			Id = 18857;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x08;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23273 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18858 : Item
	{
		public InsigniaOfTheAlliance18858() : base()
		{
			Id = 18858;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x100;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23273 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18859 : Item
	{
		public InsigniaOfTheAlliance18859() : base()
		{
			Id = 18859;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x80;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23274 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18862 : Item
	{
		public InsigniaOfTheAlliance18862() : base()
		{
			Id = 18862;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x10;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23276 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18863 : Item
	{
		public InsigniaOfTheAlliance18863() : base()
		{
			Id = 18863;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x400;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23277 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Insignia of the Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaOfTheAlliance18864 : Item
	{
		public InsigniaOfTheAlliance18864() : base()
		{
			Id = 18864;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x02;
			Model = 31318;
			ObjectClass = 4;
			SubClass = 0;
			Name = "Insignia of the Alliance";
			Name2 = "Insignia of the Alliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 23276 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Heavy Dark Iron Ring)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyDarkIronRing : Item
	{
		public HeavyDarkIronRing() : base()
		{
			Id = 18879;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 53364;
			AvailableClasses = 0x7FFF;
			Model = 9836;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Heavy Dark Iron Ring";
			Name2 = "Heavy Dark Iron Ring";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 213456;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			SetSpell( 13383 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Dimensional Ripper - Everlook)
*
***************************************************************/

namespace Server.Items
{
	public class DimensionalRipperEverlook : Item
	{
		public DimensionalRipperEverlook() : base()
		{
			Id = 18984;
			Bonding = 3;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 31423;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Dimensional Ripper - Everlook";
			Name2 = "Dimensional Ripper - Everlook";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 260;
			Skill = 202;
			SpellReq = 20222;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23442 , 0 , 0 , 14400000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ultrasafe Transporter: Gadgetzan)
*
***************************************************************/

namespace Server.Items
{
	public class UltrasafeTransporterGadgetzan : Item
	{
		public UltrasafeTransporterGadgetzan() : base()
		{
			Id = 18986;
			Bonding = 3;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 31425;
			ObjectClass = 4;
			SubClass = 0;
			Level = 52;
			Name = "Ultrasafe Transporter: Gadgetzan";
			Name2 = "Ultrasafe Transporter: Gadgetzan";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 260;
			Skill = 202;
			SpellReq = 20219;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23453 , 0 , 0 , 14400000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Arena Grand Master)
*
***************************************************************/

namespace Server.Items
{
	public class ArenaGrandMaster : Item
	{
		public ArenaGrandMaster() : base()
		{
			Id = 19024;
			Bonding = 1;
			SellPrice = 10031;
			AvailableClasses = 0x7FFF;
			Model = 31499;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Arena Grand Master";
			Name2 = "Arena Grand Master";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40124;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 23506 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Ring of Subtlety)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfSubtlety : Item
	{
		public RingOfSubtlety() : base()
		{
			Id = 19038;
			Bonding = 1;
			SellPrice = 11145;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 4;
			SubClass = 0;
			Level = 48;
			Name = "Ring of Subtlety";
			Name2 = "Ring of Subtlety";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44581;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 21619 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Legionnaire's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfLegionnairesPendant : Item
	{
		public FrostwolfLegionnairesPendant() : base()
		{
			Id = 19095;
			Bonding = 1;
			SellPrice = 17912;
			AvailableClasses = 0x7FFF;
			Model = 31603;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Legionnaire's Pendant";
			Name2 = "Frostwolf Legionnaire's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71648;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 32768;
			SetSpell( 9330 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Advisor's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfAdvisorsPendant : Item
	{
		public FrostwolfAdvisorsPendant() : base()
		{
			Id = 19096;
			Bonding = 1;
			SellPrice = 17912;
			AvailableClasses = 0x7FFF;
			Model = 9859;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Advisor's Pendant";
			Name2 = "Frostwolf Advisor's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71648;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 32768;
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stormpike Soldier's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeSoldiersPendant : Item
	{
		public StormpikeSoldiersPendant() : base()
		{
			Id = 19097;
			Bonding = 1;
			SellPrice = 17912;
			AvailableClasses = 0x7FFF;
			Model = 31604;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Soldier's Pendant";
			Name2 = "Stormpike Soldier's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71648;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 32768;
			SetSpell( 9330 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Stormpike Sage's Pendant)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeSagesPendant : Item
	{
		public StormpikeSagesPendant() : base()
		{
			Id = 19098;
			Bonding = 1;
			SellPrice = 17912;
			AvailableClasses = 0x7FFF;
			Model = 9857;
			ObjectClass = 4;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Sage's Pendant";
			Name2 = "Stormpike Sage's Pendant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71648;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			Flags = 32768;
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Deep Rooted Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DeepRootedRing : Item
	{
		public DeepRootedRing() : base()
		{
			Id = 19109;
			Bonding = 1;
			SellPrice = 33920;
			AvailableClasses = 0x7FFF;
			Model = 31616;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Deep Rooted Ring";
			Name2 = "Deep Rooted Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 135681;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Flask of Forest Mojo)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfForestMojo : Item
	{
		public FlaskOfForestMojo() : base()
		{
			Id = 19115;
			Bonding = 1;
			SellPrice = 11003;
			AvailableClasses = 0x7FFF;
			Model = 31623;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			Name = "Flask of Forest Mojo";
			Name2 = "Flask of Forest Mojo";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44012;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 3;
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rune of the Guard Captain)
*
***************************************************************/

namespace Server.Items
{
	public class RuneOfTheGuardCaptain : Item
	{
		public RuneOfTheGuardCaptain() : base()
		{
			Id = 19120;
			Bonding = 1;
			SellPrice = 16283;
			AvailableClasses = 0x7FFF;
			Model = 31631;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			Name = "Rune of the Guard Captain";
			Name2 = "Rune of the Guard Captain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65132;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 4;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Band of Sulfuras)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfSulfuras : Item
	{
		public BandOfSulfuras() : base()
		{
			Id = 19138;
			Bonding = 1;
			SellPrice = 79853;
			AvailableClasses = 0x7FFF;
			Model = 31655;
			ObjectClass = 4;
			SubClass = 0;
			Level = 78;
			ReqLevel = 60;
			Name = "Band of Sulfuras";
			Name2 = "Band of Sulfuras";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 319412;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SpiritBonus = 23;
			IqBonus = 10;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Cauterizing Band)
*
***************************************************************/

namespace Server.Items
{
	public class CauterizingBand : Item
	{
		public CauterizingBand() : base()
		{
			Id = 19140;
			Bonding = 1;
			SellPrice = 60256;
			AvailableClasses = 0x7FFF;
			Model = 31657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 71;
			ReqLevel = 60;
			Name = "Cauterizing Band";
			Name2 = "Cauterizing Band";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 241024;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 18033 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Luffa)
*
***************************************************************/

namespace Server.Items
{
	public class Luffa : Item
	{
		public Luffa() : base()
		{
			Id = 19141;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7418;
			ObjectClass = 4;
			SubClass = 0;
			Level = 50;
			Name = "Luffa";
			Name2 = "Luffa";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 7;
			SetSpell( 23595 , 0 , 0 , 180000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ring of Spell Power)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfSpellPower : Item
	{
		public RingOfSpellPower() : base()
		{
			Id = 19147;
			Bonding = 1;
			SellPrice = 91453;
			AvailableClasses = 0x7FFF;
			Model = 31664;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Ring of Spell Power";
			Name2 = "Ring of Spell Power";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 365815;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = 3;
			SetSpell( 18050 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Woven Ivy Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class WovenIvyNecklace : Item
	{
		public WovenIvyNecklace() : base()
		{
			Id = 19159;
			Bonding = 1;
			SellPrice = 21141;
			AvailableClasses = 0x7FFF;
			Model = 31633;
			ObjectClass = 4;
			SubClass = 0;
			Level = 51;
			Name = "Woven Ivy Necklace";
			Name2 = "Woven Ivy Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84564;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 8;
			AgilityBonus = 9;
			StaminaBonus = 10;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Darkmoon Card: Blue Dragon)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonCardBlueDragon : Item
	{
		public DarkmoonCardBlueDragon() : base()
		{
			Id = 19288;
			Bonding = 1;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Model = 31769;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Darkmoon Card: Blue Dragon";
			Name2 = "Darkmoon Card: Blue Dragon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23688 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Card: Maelstrom)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonCardMaelstrom : Item
	{
		public DarkmoonCardMaelstrom() : base()
		{
			Id = 19289;
			Bonding = 1;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Model = 31770;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Darkmoon Card: Maelstrom";
			Name2 = "Darkmoon Card: Maelstrom";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23686 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Card: Twisting Nether)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonCardTwistingNether : Item
	{
		public DarkmoonCardTwistingNether() : base()
		{
			Id = 19290;
			Bonding = 1;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Model = 31771;
			ObjectClass = 4;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Darkmoon Card: Twisting Nether";
			Name2 = "Darkmoon Card: Twisting Nether";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23701 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Flower)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonFlower : Item
	{
		public DarkmoonFlower() : base()
		{
			Id = 19295;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 31779;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Darkmoon Flower";
			Name2 = "Darkmoon Flower";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Darkmoon Ring)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonRing : Item
	{
		public DarkmoonRing() : base()
		{
			Id = 19302;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31800;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Darkmoon Ring";
			Name2 = "Darkmoon Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			Material = -1;
			SetSpell( 21348 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Darkmoon Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonNecklace : Item
	{
		public DarkmoonNecklace() : base()
		{
			Id = 19303;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Darkmoon Necklace";
			Name2 = "Darkmoon Necklace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 18379 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tome of Arcane Domination)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfArcaneDomination : Item
	{
		public TomeOfArcaneDomination() : base()
		{
			Id = 19308;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 31805;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Tome of Arcane Domination";
			Name2 = "Tome of Arcane Domination";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 17829 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tome of Shadow Force)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfShadowForce : Item
	{
		public TomeOfShadowForce() : base()
		{
			Id = 19309;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 24039;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Tome of Shadow Force";
			Name2 = "Tome of Shadow Force";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 18014 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Tome of the Ice Lord)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfTheIceLord : Item
	{
		public TomeOfTheIceLord() : base()
		{
			Id = 19310;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 31806;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Tome of the Ice Lord";
			Name2 = "Tome of the Ice Lord";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 17896 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tome of Fiery Arcana)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfFieryArcana : Item
	{
		public TomeOfFieryArcana() : base()
		{
			Id = 19311;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 23322;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Tome of Fiery Arcana";
			Name2 = "Tome of Fiery Arcana";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 17875 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Lei of the Lifegiver)
*
***************************************************************/

namespace Server.Items
{
	public class LeiOfTheLifegiver : Item
	{
		public LeiOfTheLifegiver() : base()
		{
			Id = 19312;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 31807;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Lei of the Lifegiver";
			Name2 = "Lei of the Lifegiver";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 15696 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Therazane's Touch)
*
***************************************************************/

namespace Server.Items
{
	public class TherazanesTouch : Item
	{
		public TherazanesTouch() : base()
		{
			Id = 19315;
			Bonding = 1;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 31809;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Therazane's Touch";
			Name2 = "Therazane's Touch";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 500000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 18050 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 0;
		}
	}
}


/**************************************************************
*
*				(Don Julio's Band)
*
***************************************************************/

namespace Server.Items
{
	public class DonJuliosBand : Item
	{
		public DonJuliosBand() : base()
		{
			Id = 19325;
			Bonding = 1;
			SellPrice = 188888;
			AvailableClasses = 0x7FFF;
			Model = 31616;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Don Julio's Band";
			Name2 = "Don Julio's Band";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 755555;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Arcane Infused Gem)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneInfusedGem : Item
	{
		public ArcaneInfusedGem() : base()
		{
			Id = 19336;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x7A04;
			Model = 31838;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Arcane Infused Gem";
			Name2 = "Arcane Infused Gem";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23721 , 0 , 0 , 120000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(The Black Book)
*
***************************************************************/

namespace Server.Items
{
	public class TheBlackBook : Item
	{
		public TheBlackBook() : base()
		{
			Id = 19337;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x100;
			Model = 31848;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "The Black Book";
			Name2 = "The Black Book";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23720 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mind Quickening Gem)
*
***************************************************************/

namespace Server.Items
{
	public class MindQuickeningGem : Item
	{
		public MindQuickeningGem() : base()
		{
			Id = 19339;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x7A80;
			Model = 31840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Mind Quickening Gem";
			Name2 = "Mind Quickening Gem";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23723 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Rune of Metamorphosis)
*
***************************************************************/

namespace Server.Items
{
	public class RuneOfMetamorphosis : Item
	{
		public RuneOfMetamorphosis() : base()
		{
			Id = 19340;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x7E00;
			Model = 31841;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Rune of Metamorphosis";
			Name2 = "Rune of Metamorphosis";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23724 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Lifegiving Gem)
*
***************************************************************/

namespace Server.Items
{
	public class LifegivingGem : Item
	{
		public LifegivingGem() : base()
		{
			Id = 19341;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x01;
			Model = 31843;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Lifegiving Gem";
			Name2 = "Lifegiving Gem";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23725 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Venomous Totem)
*
***************************************************************/

namespace Server.Items
{
	public class VenomousTotem : Item
	{
		public VenomousTotem() : base()
		{
			Id = 19342;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x08;
			Model = 31846;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Venomous Totem";
			Name2 = "Venomous Totem";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23726 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scrolls of Blinding Light)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollsOfBlindingLight : Item
	{
		public ScrollsOfBlindingLight() : base()
		{
			Id = 19343;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x02;
			Model = 31847;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Scrolls of Blinding Light";
			Name2 = "Scrolls of Blinding Light";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23733 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Aegis of Preservation)
*
***************************************************************/

namespace Server.Items
{
	public class AegisOfPreservation : Item
	{
		public AegisOfPreservation() : base()
		{
			Id = 19345;
			Bonding = 1;
			SellPrice = 72039;
			AvailableClasses = 0x10;
			Model = 31844;
			ObjectClass = 4;
			SubClass = 0;
			Level = 76;
			ReqLevel = 60;
			Name = "Aegis of Preservation";
			Name2 = "Aegis of Preservation";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 288156;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 23780 , 0 , 0 , 300000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Pendant of the Fallen Dragon)
*
***************************************************************/

namespace Server.Items
{
	public class PendantOfTheFallenDragon : Item
	{
		public PendantOfTheFallenDragon() : base()
		{
			Id = 19371;
			Bonding = 1;
			SellPrice = 88355;
			AvailableClasses = 0x7FFF;
			Model = 31889;
			ObjectClass = 4;
			SubClass = 0;
			Level = 74;
			ReqLevel = 60;
			Name = "Pendant of the Fallen Dragon";
			Name2 = "Pendant of the Fallen Dragon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 353421;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = 3;
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ring of Blackrock)
*
***************************************************************/

namespace Server.Items
{
	public class RingOfBlackrock : Item
	{
		public RingOfBlackrock() : base()
		{
			Id = 19397;
			Bonding = 1;
			SellPrice = 107438;
			AvailableClasses = 0x7FFF;
			Model = 31905;
			ObjectClass = 4;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Ring of Blackrock";
			Name2 = "Ring of Blackrock";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 429754;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Band of Forced Concentration)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfForcedConcentration : Item
	{
		public BandOfForcedConcentration() : base()
		{
			Id = 19403;
			Bonding = 1;
			SellPrice = 105328;
			AvailableClasses = 0x7FFF;
			Model = 31800;
			ObjectClass = 4;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Band of Forced Concentration";
			Name2 = "Band of Forced Concentration";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 421312;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 23727 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Drake Fang Talisman)
*
***************************************************************/

namespace Server.Items
{
	public class DrakeFangTalisman : Item
	{
		public DrakeFangTalisman() : base()
		{
			Id = 19406;
			Bonding = 1;
			SellPrice = 91160;
			AvailableClasses = 0x7FFF;
			Model = 31936;
			ObjectClass = 4;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Drake Fang Talisman";
			Name2 = "Drake Fang Talisman";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 364641;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 15814 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Orb of the Darkmoon)
*
***************************************************************/

namespace Server.Items
{
	public class OrbOfTheDarkmoon : Item
	{
		public OrbOfTheDarkmoon() : base()
		{
			Id = 19426;
			Bonding = 1;
			SellPrice = 25000;
			AvailableClasses = 0x7FFF;
			Model = 31603;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Orb of the Darkmoon";
			Name2 = "Orb of the Darkmoon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Styleen's Impeding Scarab)
*
***************************************************************/

namespace Server.Items
{
	public class StyleensImpedingScarab : Item
	{
		public StyleensImpedingScarab() : base()
		{
			Id = 19431;
			Bonding = 1;
			SellPrice = 103117;
			AvailableClasses = 0x7FFF;
			Model = 31967;
			ObjectClass = 4;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Styleen's Impeding Scarab";
			Name2 = "Styleen's Impeding Scarab";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 412471;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			SetSpell( 21485 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23181 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14249 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Band of Dark Dominion)
*
***************************************************************/

namespace Server.Items
{
	public class BandOfDarkDominion : Item
	{
		public BandOfDarkDominion() : base()
		{
			Id = 19434;
			Bonding = 1;
			SellPrice = 80863;
			AvailableClasses = 0x7FFF;
			Model = 28733;
			ObjectClass = 4;
			SubClass = 0;
			Level = 70;
			ReqLevel = 60;
			Name = "Band of Dark Dominion";
			Name2 = "Band of Dark Dominion";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 323454;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 18013 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Amulet of the Darkmoon)
*
***************************************************************/

namespace Server.Items
{
	public class AmuletOfTheDarkmoon : Item
	{
		public AmuletOfTheDarkmoon() : base()
		{
			Id = 19491;
			Bonding = 1;
			SellPrice = 25000;
			AvailableClasses = 0x7FFF;
			Model = 32008;
			ObjectClass = 4;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Amulet of the Darkmoon";
			Name2 = "Amulet of the Darkmoon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			Material = -1;
			AgilityBonus = 18;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Band)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesBand : Item
	{
		public LegionnairesBand() : base()
		{
			Id = 19510;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Band";
			Name2 = "Legionnaire's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 12;
			AgilityBonus = 11;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Band)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesBand19511 : Item
	{
		public LegionnairesBand19511() : base()
		{
			Id = 19511;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Legionnaire's Band";
			Name2 = "Legionnaire's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 10;
			AgilityBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Band)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesBand19512 : Item
	{
		public LegionnairesBand19512() : base()
		{
			Id = 19512;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Legionnaire's Band";
			Name2 = "Legionnaire's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 8;
			AgilityBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Band)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesBand19513 : Item
	{
		public LegionnairesBand19513() : base()
		{
			Id = 19513;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 29697;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Legionnaire's Band";
			Name2 = "Legionnaire's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 6;
			AgilityBonus = 6;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Protector's Band)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsBand : Item
	{
		public ProtectorsBand() : base()
		{
			Id = 19514;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Protector's Band";
			Name2 = "Protector's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 12;
			AgilityBonus = 11;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Protector's Band)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsBand19515 : Item
	{
		public ProtectorsBand19515() : base()
		{
			Id = 19515;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Protector's Band";
			Name2 = "Protector's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 8;
			AgilityBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector's Band)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsBand19516 : Item
	{
		public ProtectorsBand19516() : base()
		{
			Id = 19516;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Protector's Band";
			Name2 = "Protector's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 10;
			AgilityBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Protector's Band)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsBand19517 : Item
	{
		public ProtectorsBand19517() : base()
		{
			Id = 19517;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 9832;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Protector's Band";
			Name2 = "Protector's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			StrBonus = 6;
			AgilityBonus = 6;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Advisor's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsRing : Item
	{
		public AdvisorsRing() : base()
		{
			Id = 19518;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Advisor's Ring";
			Name2 = "Advisor's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21619 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Advisor's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsRing19519 : Item
	{
		public AdvisorsRing19519() : base()
		{
			Id = 19519;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Advisor's Ring";
			Name2 = "Advisor's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9417 , 0 , 0 , -1 , 0 , -1 );
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Advisor's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsRing19520 : Item
	{
		public AdvisorsRing19520() : base()
		{
			Id = 19520;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Advisor's Ring";
			Name2 = "Advisor's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Advisor's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AdvisorsRing19521 : Item
	{
		public AdvisorsRing19521() : base()
		{
			Id = 19521;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 30661;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Advisor's Ring";
			Name2 = "Advisor's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9397 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21624 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersRing : Item
	{
		public LorekeepersRing() : base()
		{
			Id = 19522;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Lorekeeper's Ring";
			Name2 = "Lorekeeper's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21619 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersRing19523 : Item
	{
		public LorekeepersRing19523() : base()
		{
			Id = 19523;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Lorekeeper's Ring";
			Name2 = "Lorekeeper's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9417 , 0 , 0 , -1 , 0 , -1 );
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersRing19524 : Item
	{
		public LorekeepersRing19524() : base()
		{
			Id = 19524;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Lorekeeper's Ring";
			Name2 = "Lorekeeper's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Lorekeeper's Ring)
*
***************************************************************/

namespace Server.Items
{
	public class LorekeepersRing19525 : Item
	{
		public LorekeepersRing19525() : base()
		{
			Id = 19525;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 28812;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Lorekeeper's Ring";
			Name2 = "Lorekeeper's Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Finger;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			SetSpell( 9397 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21624 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Scout's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsMedallion : Item
	{
		public ScoutsMedallion() : base()
		{
			Id = 19534;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 32008;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Scout's Medallion";
			Name2 = "Scout's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Scout's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsMedallion19535 : Item
	{
		public ScoutsMedallion19535() : base()
		{
			Id = 19535;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 32008;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Scout's Medallion";
			Name2 = "Scout's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 12;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Scout's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsMedallion19536 : Item
	{
		public ScoutsMedallion19536() : base()
		{
			Id = 19536;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 32008;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Scout's Medallion";
			Name2 = "Scout's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 11;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Scout's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsMedallion19537 : Item
	{
		public ScoutsMedallion19537() : base()
		{
			Id = 19537;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 32008;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Scout's Medallion";
			Name2 = "Scout's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsMedallion : Item
	{
		public SentinelsMedallion() : base()
		{
			Id = 19538;
			Bonding = 1;
			SellPrice = 18750;
			AvailableClasses = 0x7FFF;
			Model = 32073;
			ObjectClass = 4;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Sentinel's Medallion";
			Name2 = "Sentinel's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsMedallion19539 : Item
	{
		public SentinelsMedallion19539() : base()
		{
			Id = 19539;
			Bonding = 1;
			SellPrice = 15000;
			AvailableClasses = 0x7FFF;
			Model = 32073;
			ObjectClass = 4;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Sentinel's Medallion";
			Name2 = "Sentinel's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 12;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsMedallion19540 : Item
	{
		public SentinelsMedallion19540() : base()
		{
			Id = 19540;
			Bonding = 1;
			SellPrice = 11250;
			AvailableClasses = 0x7FFF;
			Model = 32073;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			ReqLevel = 38;
			Name = "Sentinel's Medallion";
			Name2 = "Sentinel's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 11;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Medallion)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsMedallion19541 : Item
	{
		public SentinelsMedallion19541() : base()
		{
			Id = 19541;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 32073;
			ObjectClass = 4;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Sentinel's Medallion";
			Name2 = "Sentinel's Medallion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Neck;
			Stackable = 1;
			MaxCount = 1;
			Material = 4;
			Flags = 32768;
			AgilityBonus = 8;
			StaminaBonus = 5;
		}
	}
}


