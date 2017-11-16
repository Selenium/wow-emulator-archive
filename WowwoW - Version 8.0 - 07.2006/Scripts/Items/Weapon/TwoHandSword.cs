/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:28 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Destiny)
*
***************************************************************/

namespace Server.Items
{
	public class Destiny : Item
	{
		public Destiny() : base()
		{
			Id = 647;
			Bonding = 2;
			SellPrice = 70024;
			AvailableClasses = 0x7FFF;
			Model = 20190;
			ObjectClass = 2;
			SubClass = 8;
			Level = 57;
			ReqLevel = 52;
			Name = "Destiny";
			Name2 = "Destiny";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 350121;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 17152 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 112 , 168 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Huge Ogre Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HugeOgreSword : Item
	{
		public HugeOgreSword() : base()
		{
			Id = 913;
			Bonding = 2;
			SellPrice = 5037;
			AvailableClasses = 0x7FFF;
			Model = 20170;
			ObjectClass = 2;
			SubClass = 8;
			Level = 29;
			ReqLevel = 24;
			Name = "Huge Ogre Sword";
			Name2 = "Huge Ogre Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25188;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			SetDamage( 60 , 90 , Resistances.Armor );
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Dacian Falx)
*
***************************************************************/

namespace Server.Items
{
	public class DacianFalx : Item
	{
		public DacianFalx() : base()
		{
			Id = 922;
			SellPrice = 2407;
			AvailableClasses = 0x7FFF;
			Model = 22097;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Dacian Falx";
			Name2 = "Dacian Falx";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12038;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 39 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class BastardSword : Item
	{
		public BastardSword() : base()
		{
			Id = 1194;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 22093;
			ObjectClass = 2;
			SubClass = 8;
			Level = 4;
			ReqLevel = 1;
			Name = "Bastard Sword";
			Name2 = "Bastard Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 104;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 30;
			SetDamage( 5 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class Claymore : Item
	{
		public Claymore() : base()
		{
			Id = 1198;
			SellPrice = 535;
			AvailableClasses = 0x7FFF;
			Model = 22095;
			ObjectClass = 2;
			SubClass = 8;
			Level = 15;
			ReqLevel = 10;
			Name = "Claymore";
			Name2 = "Claymore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2676;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 23 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ghoulfang)
*
***************************************************************/

namespace Server.Items
{
	public class Ghoulfang : Item
	{
		public Ghoulfang() : base()
		{
			Id = 1387;
			Bonding = 2;
			SellPrice = 1578;
			AvailableClasses = 0x7FFF;
			Model = 20087;
			ObjectClass = 2;
			SubClass = 8;
			Level = 19;
			ReqLevel = 14;
			Name = "Ghoulfang";
			Name2 = "Ghoulfang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7892;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetSpell( 16409 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 36 , 54 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crude Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class CrudeBastardSword : Item
	{
		public CrudeBastardSword() : base()
		{
			Id = 1412;
			SellPrice = 49;
			AvailableClasses = 0x7FFF;
			Model = 20074;
			ObjectClass = 2;
			SubClass = 8;
			Level = 7;
			ReqLevel = 2;
			Name = "Crude Bastard Sword";
			Name2 = "Crude Bastard Sword";
			AvailableRaces = 0x1FF;
			BuyPrice = 246;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 7 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shadowhide Two-handed Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowhideTwoHandedSword : Item
	{
		public ShadowhideTwoHandedSword() : base()
		{
			Id = 1460;
			Bonding = 2;
			SellPrice = 1768;
			AvailableClasses = 0x7FFF;
			Model = 20109;
			ObjectClass = 2;
			SubClass = 8;
			Level = 20;
			ReqLevel = 15;
			Name = "Shadowhide Two-handed Sword";
			Name2 = "Shadowhide Two-handed Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8842;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 30 , 46 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Old Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class OldGreatsword : Item
	{
		public OldGreatsword() : base()
		{
			Id = 1513;
			SellPrice = 293;
			AvailableClasses = 0x7FFF;
			Model = 20092;
			ObjectClass = 2;
			SubClass = 8;
			Level = 14;
			ReqLevel = 9;
			Name = "Old Greatsword";
			Name2 = "Old Greatsword";
			AvailableRaces = 0x1FF;
			BuyPrice = 1465;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 50;
			SetDamage( 16 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Edge of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class EdgeOfThePeoplesMilitia : Item
	{
		public EdgeOfThePeoplesMilitia() : base()
		{
			Id = 1566;
			Bonding = 1;
			SellPrice = 1132;
			AvailableClasses = 0x7FFF;
			Model = 20078;
			ObjectClass = 2;
			SubClass = 8;
			Level = 17;
			Name = "Edge of the People's Militia";
			Name2 = "Edge of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5663;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 26 , 39 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Chromatic Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticSword : Item
	{
		public ChromaticSword() : base()
		{
			Id = 1604;
			Resistance[6] = 7;
			Bonding = 2;
			SellPrice = 19463;
			AvailableClasses = 0x7FFF;
			Model = 20188;
			Resistance[2] = 7;
			Resistance[4] = 7;
			ObjectClass = 2;
			SubClass = 8;
			Level = 45;
			ReqLevel = 40;
			Name = "Chromatic Sword";
			Name2 = "Chromatic Sword";
			Resistance[3] = 7;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 97319;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 100 , 150 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Exquisite Flamberge)
*
***************************************************************/

namespace Server.Items
{
	public class ExquisiteFlamberge : Item
	{
		public ExquisiteFlamberge() : base()
		{
			Id = 1625;
			Bonding = 2;
			SellPrice = 14754;
			AvailableClasses = 0x7FFF;
			Model = 26586;
			ObjectClass = 2;
			SubClass = 8;
			Level = 41;
			ReqLevel = 36;
			Name = "Exquisite Flamberge";
			Name2 = "Exquisite Flamberge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5254;
			BuyPrice = 73773;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 72 , 109 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blunt Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class BluntClaymore : Item
	{
		public BluntClaymore() : base()
		{
			Id = 1811;
			SellPrice = 451;
			AvailableClasses = 0x7FFF;
			Model = 20037;
			ObjectClass = 2;
			SubClass = 8;
			Level = 17;
			ReqLevel = 12;
			Name = "Blunt Claymore";
			Name2 = "Blunt Claymore";
			AvailableRaces = 0x1FF;
			BuyPrice = 2255;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 16 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Standard Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class StandardClaymore : Item
	{
		public StandardClaymore() : base()
		{
			Id = 1818;
			SellPrice = 1221;
			AvailableClasses = 0x7FFF;
			Model = 20183;
			ObjectClass = 2;
			SubClass = 8;
			Level = 24;
			ReqLevel = 19;
			Name = "Standard Claymore";
			Name2 = "Standard Claymore";
			AvailableRaces = 0x1FF;
			BuyPrice = 6109;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 23 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LongBastardSword : Item
	{
		public LongBastardSword() : base()
		{
			Id = 1830;
			SellPrice = 1783;
			AvailableClasses = 0x7FFF;
			Model = 4129;
			ObjectClass = 2;
			SubClass = 8;
			Level = 28;
			ReqLevel = 23;
			Name = "Long Bastard Sword";
			Name2 = "Long Bastard Sword";
			AvailableRaces = 0x1FF;
			BuyPrice = 8919;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 29 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Pysan's Old Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class PysansOldGreatsword : Item
	{
		public PysansOldGreatsword() : base()
		{
			Id = 1975;
			Bonding = 2;
			SellPrice = 5744;
			AvailableClasses = 0x7FFF;
			Model = 20179;
			ObjectClass = 2;
			SubClass = 8;
			Level = 28;
			ReqLevel = 23;
			Name = "Pysan's Old Greatsword";
			Name2 = "Pysan's Old Greatsword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28721;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 95;
			SetDamage( 60 , 91 , Resistances.Armor );
			IqBonus = 13;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Nightblade)
*
***************************************************************/

namespace Server.Items
{
	public class Nightblade : Item
	{
		public Nightblade() : base()
		{
			Id = 1982;
			Bonding = 2;
			SellPrice = 29513;
			AvailableClasses = 0x7FFF;
			Model = 20191;
			ObjectClass = 2;
			SubClass = 8;
			Level = 44;
			ReqLevel = 39;
			Name = "Nightblade";
			Name2 = "Nightblade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 147568;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 18211 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 97 , 146 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gutrender)
*
***************************************************************/

namespace Server.Items
{
	public class Gutrender : Item
	{
		public Gutrender() : base()
		{
			Id = 1986;
			Bonding = 2;
			SellPrice = 14861;
			AvailableClasses = 0x7FFF;
			Model = 20638;
			ObjectClass = 2;
			SubClass = 8;
			Level = 41;
			ReqLevel = 36;
			Name = "Gutrender";
			Name2 = "Gutrender";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74309;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 18090 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 62 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Archeus)
*
***************************************************************/

namespace Server.Items
{
	public class Archeus : Item
	{
		public Archeus() : base()
		{
			Id = 2000;
			Bonding = 1;
			SellPrice = 8827;
			AvailableClasses = 0x7FFF;
			Description = "Morgan Ladimore's sword.";
			Model = 20251;
			ObjectClass = 2;
			SubClass = 8;
			Level = 35;
			Name = "Archeus";
			Name2 = "Archeus";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44136;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 18091 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 63 , 95 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Metal Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMetalGreatsword : Item
	{
		public BlackMetalGreatsword() : base()
		{
			Id = 2014;
			Bonding = 2;
			SellPrice = 4869;
			AvailableClasses = 0x7FFF;
			Model = 5176;
			ObjectClass = 2;
			SubClass = 8;
			Level = 29;
			ReqLevel = 24;
			Name = "Black Metal Greatsword";
			Name2 = "Black Metal Greatsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24346;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 52 , 78 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Espadon)
*
***************************************************************/

namespace Server.Items
{
	public class Espadon : Item
	{
		public Espadon() : base()
		{
			Id = 2024;
			SellPrice = 1215;
			AvailableClasses = 0x7FFF;
			Model = 22096;
			ObjectClass = 2;
			SubClass = 8;
			Level = 21;
			ReqLevel = 16;
			Name = "Espadon";
			Name2 = "Espadon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6078;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 29 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Darksteel Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class DarksteelBastardSword : Item
	{
		public DarksteelBastardSword() : base()
		{
			Id = 2084;
			Bonding = 2;
			SellPrice = 5709;
			AvailableClasses = 0x7FFF;
			Model = 20152;
			ObjectClass = 2;
			SubClass = 8;
			Level = 30;
			ReqLevel = 25;
			Name = "Darksteel Bastard Sword";
			Name2 = "Darksteel Bastard Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28547;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 52 , 79 , Resistances.Armor );
			StrBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Scratched Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class ScratchedClaymore : Item
	{
		public ScratchedClaymore() : base()
		{
			Id = 2128;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 2380;
			ObjectClass = 2;
			SubClass = 8;
			Level = 4;
			ReqLevel = 1;
			Name = "Scratched Claymore";
			Name2 = "Scratched Claymore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			SetDamage( 4 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brashclaw's Skewer)
*
***************************************************************/

namespace Server.Items
{
	public class BrashclawsSkewer : Item
	{
		public BrashclawsSkewer() : base()
		{
			Id = 2204;
			Bonding = 2;
			SellPrice = 1133;
			AvailableClasses = 0x7FFF;
			Model = 20038;
			ObjectClass = 2;
			SubClass = 8;
			Level = 17;
			ReqLevel = 12;
			Name = "Brashclaw's Skewer";
			Name2 = "Brashclaw's Skewer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5665;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 29 , 44 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Duskbringer)
*
***************************************************************/

namespace Server.Items
{
	public class Duskbringer : Item
	{
		public Duskbringer() : base()
		{
			Id = 2205;
			Bonding = 2;
			SellPrice = 3961;
			AvailableClasses = 0x7FFF;
			Model = 20153;
			ObjectClass = 2;
			SubClass = 8;
			Level = 25;
			ReqLevel = 20;
			Name = "Duskbringer";
			Name2 = "Duskbringer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19806;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 90;
			SetSpell( 18217 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 86 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Two-handed Sword)
*
***************************************************************/

namespace Server.Items
{
	public class TwoHandedSword : Item
	{
		public TwoHandedSword() : base()
		{
			Id = 2489;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 22094;
			ObjectClass = 2;
			SubClass = 8;
			Level = 7;
			ReqLevel = 2;
			Name = "Two-handed Sword";
			Name2 = "Two-handed Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 342;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 8 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rusted Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class RustedClaymore : Item
	{
		public RustedClaymore() : base()
		{
			Id = 2497;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 2399;
			ObjectClass = 2;
			SubClass = 8;
			Level = 9;
			ReqLevel = 4;
			Name = "Rusted Claymore";
			Name2 = "Rusted Claymore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 711;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Flags = 16;
			SetDamage( 10 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flamberge)
*
***************************************************************/

namespace Server.Items
{
	public class Flamberge : Item
	{
		public Flamberge() : base()
		{
			Id = 2521;
			SellPrice = 6179;
			AvailableClasses = 0x7FFF;
			Model = 22084;
			ObjectClass = 2;
			SubClass = 8;
			Level = 36;
			ReqLevel = 31;
			Name = "Flamberge";
			Name2 = "Flamberge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30896;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 59 , 89 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Zweihander)
*
***************************************************************/

namespace Server.Items
{
	public class Zweihander : Item
	{
		public Zweihander() : base()
		{
			Id = 2529;
			SellPrice = 13006;
			AvailableClasses = 0x7FFF;
			Model = 22098;
			ObjectClass = 2;
			SubClass = 8;
			Level = 46;
			ReqLevel = 41;
			Name = "Zweihander";
			Name2 = "Zweihander";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 65031;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 75 , 113 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tarnished Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedBastardSword : Item
	{
		public TarnishedBastardSword() : base()
		{
			Id = 2754;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 20117;
			ObjectClass = 2;
			SubClass = 8;
			Level = 3;
			ReqLevel = 1;
			Name = "Tarnished Bastard Sword";
			Name2 = "Tarnished Bastard Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 69;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 25;
			SetDamage( 4 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of Hanna)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfHanna : Item
	{
		public BladeOfHanna() : base()
		{
			Id = 2801;
			Bonding = 2;
			SellPrice = 104729;
			AvailableClasses = 0x7FFF;
			Model = 5193;
			ObjectClass = 2;
			SubClass = 8;
			Level = 64;
			ReqLevel = 59;
			Name = "Blade of Hanna";
			Name2 = "Blade of Hanna";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 523648;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2100;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetDamage( 101 , 152 , Resistances.Armor );
			AgilityBonus = 11;
			SpiritBonus = 11;
			IqBonus = 11;
			StaminaBonus = 11;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Mo'grosh Toothpick)
*
***************************************************************/

namespace Server.Items
{
	public class MogroshToothpick : Item
	{
		public MogroshToothpick() : base()
		{
			Id = 2822;
			Bonding = 2;
			SellPrice = 1402;
			AvailableClasses = 0x7FFF;
			Model = 20091;
			ObjectClass = 2;
			SubClass = 8;
			Level = 18;
			ReqLevel = 13;
			Name = "Mo'grosh Toothpick";
			Name2 = "Mo'grosh Toothpick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7012;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 26 , 40 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Combatant Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class CombatantClaymore : Item
	{
		public CombatantClaymore() : base()
		{
			Id = 2877;
			Bonding = 2;
			SellPrice = 8524;
			AvailableClasses = 0x7FFF;
			Model = 20151;
			ObjectClass = 2;
			SubClass = 8;
			Level = 33;
			ReqLevel = 28;
			Name = "Combatant Claymore";
			Name2 = "Combatant Claymore";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42623;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 64 , 97 , Resistances.Armor );
			IqBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Coral Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class CoralClaymore : Item
	{
		public CoralClaymore() : base()
		{
			Id = 3188;
			Bonding = 2;
			SellPrice = 879;
			AvailableClasses = 0x7FFF;
			Model = 20072;
			ObjectClass = 2;
			SubClass = 8;
			Level = 15;
			ReqLevel = 10;
			Name = "Coral Claymore";
			Name2 = "Coral Claymore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4398;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 22 , 34 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Short Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ShortBastardSword : Item
	{
		public ShortBastardSword() : base()
		{
			Id = 3192;
			Bonding = 2;
			SellPrice = 495;
			AvailableClasses = 0x7FFF;
			Model = 26590;
			ObjectClass = 2;
			SubClass = 8;
			Level = 12;
			ReqLevel = 7;
			Name = "Short Bastard Sword";
			Name2 = "Short Bastard Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5173;
			BuyPrice = 2479;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 50;
			SetDamage( 20 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Edged Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class EdgedBastardSword : Item
	{
		public EdgedBastardSword() : base()
		{
			Id = 3196;
			Bonding = 2;
			SellPrice = 1377;
			AvailableClasses = 0x7FFF;
			Model = 26585;
			ObjectClass = 2;
			SubClass = 8;
			Level = 18;
			ReqLevel = 13;
			Name = "Edged Bastard Sword";
			Name2 = "Edged Bastard Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5182;
			BuyPrice = 6886;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 29 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonecutter Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class StonecutterClaymore : Item
	{
		public StonecutterClaymore() : base()
		{
			Id = 3197;
			Bonding = 2;
			SellPrice = 9295;
			AvailableClasses = 0x7FFF;
			Model = 20184;
			ObjectClass = 2;
			SubClass = 8;
			Level = 35;
			ReqLevel = 30;
			Name = "Stonecutter Claymore";
			Name2 = "Stonecutter Claymore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5236;
			BuyPrice = 46478;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 59 , 89 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cavalier Two-hander)
*
***************************************************************/

namespace Server.Items
{
	public class CavalierTwoHander : Item
	{
		public CavalierTwoHander() : base()
		{
			Id = 3206;
			Bonding = 2;
			SellPrice = 4582;
			AvailableClasses = 0x7FFF;
			Model = 20186;
			ObjectClass = 2;
			SubClass = 8;
			Level = 28;
			ReqLevel = 23;
			Name = "Cavalier Two-hander";
			Name2 = "Cavalier Two-hander";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5218;
			BuyPrice = 22910;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 44 , 66 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ancient War Sword)
*
***************************************************************/

namespace Server.Items
{
	public class AncientWarSword : Item
	{
		public AncientWarSword() : base()
		{
			Id = 3209;
			Bonding = 1;
			SellPrice = 6783;
			AvailableClasses = 0x7FFF;
			Model = 20250;
			ObjectClass = 2;
			SubClass = 8;
			Level = 32;
			Name = "Ancient War Sword";
			Name2 = "Ancient War Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33917;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 57 , 86 , Resistances.Armor );
			StrBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Onyx Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxClaymore : Item
	{
		public OnyxClaymore() : base()
		{
			Id = 3417;
			Bonding = 2;
			SellPrice = 4629;
			AvailableClasses = 0x7FFF;
			Model = 20174;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Onyx Claymore";
			Name2 = "Onyx Claymore";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23146;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 95;
			SetDamage( 48 , 73 , Resistances.Armor );
			IqBonus = 6;
			StaminaBonus = 5;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Heavy Copper Broadsword)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyCopperBroadsword : Item
	{
		public HeavyCopperBroadsword() : base()
		{
			Id = 3487;
			Bonding = 2;
			SellPrice = 1498;
			AvailableClasses = 0x7FFF;
			Model = 20196;
			ObjectClass = 2;
			SubClass = 8;
			Level = 19;
			ReqLevel = 14;
			Name = "Heavy Copper Broadsword";
			Name2 = "Heavy Copper Broadsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7490;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 27 , 41 , Resistances.Armor );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Broad Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class BroadClaymore : Item
	{
		public BroadClaymore() : base()
		{
			Id = 3781;
			SellPrice = 3125;
			AvailableClasses = 0x7FFF;
			Model = 20150;
			ObjectClass = 2;
			SubClass = 8;
			Level = 34;
			ReqLevel = 29;
			Name = "Broad Claymore";
			Name2 = "Broad Claymore";
			AvailableRaces = 0x1FF;
			BuyPrice = 15628;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 36 , 55 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Runic Darkblade)
*
***************************************************************/

namespace Server.Items
{
	public class RunicDarkblade : Item
	{
		public RunicDarkblade() : base()
		{
			Id = 3822;
			Bonding = 1;
			SellPrice = 6481;
			AvailableClasses = 0x7FFF;
			Model = 20180;
			ObjectClass = 2;
			SubClass = 8;
			Level = 32;
			Name = "Runic Darkblade";
			Name2 = "Runic Darkblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32405;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 16409 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 86 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Moonsteel Broadsword)
*
***************************************************************/

namespace Server.Items
{
	public class MoonsteelBroadsword : Item
	{
		public MoonsteelBroadsword() : base()
		{
			Id = 3853;
			Bonding = 2;
			SellPrice = 10153;
			AvailableClasses = 0x7FFF;
			Model = 7324;
			ObjectClass = 2;
			SubClass = 8;
			Level = 36;
			ReqLevel = 31;
			Name = "Moonsteel Broadsword";
			Name2 = "Moonsteel Broadsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50768;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 55 , 83 , Resistances.Armor );
			StaminaBonus = 4;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Frost Tiger Blade)
*
***************************************************************/

namespace Server.Items
{
	public class FrostTigerBlade : Item
	{
		public FrostTigerBlade() : base()
		{
			Id = 3854;
			Bonding = 2;
			SellPrice = 14120;
			AvailableClasses = 0x7FFF;
			Model = 20252;
			ObjectClass = 2;
			SubClass = 8;
			Level = 40;
			ReqLevel = 35;
			Name = "Frost Tiger Blade";
			Name2 = "Frost Tiger Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 70603;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13439 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 78 , 118 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Whetted Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class WhettedClaymore : Item
	{
		public WhettedClaymore() : base()
		{
			Id = 4018;
			SellPrice = 6372;
			AvailableClasses = 0x7FFF;
			Model = 20195;
			ObjectClass = 2;
			SubClass = 8;
			Level = 42;
			ReqLevel = 37;
			Name = "Whetted Claymore";
			Name2 = "Whetted Claymore";
			AvailableRaces = 0x1FF;
			BuyPrice = 31863;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 46 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Merc Sword)
*
***************************************************************/

namespace Server.Items
{
	public class MercSword : Item
	{
		public MercSword() : base()
		{
			Id = 4567;
			Bonding = 2;
			SellPrice = 1049;
			AvailableClasses = 0x7FFF;
			Model = 20111;
			ObjectClass = 2;
			SubClass = 8;
			Level = 16;
			ReqLevel = 11;
			Name = "Merc Sword";
			Name2 = "Merc Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5182;
			BuyPrice = 5247;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 24 , 36 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blessed Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class BlessedClaymore : Item
	{
		public BlessedClaymore() : base()
		{
			Id = 4817;
			Bonding = 2;
			SellPrice = 2462;
			AvailableClasses = 0x7FFF;
			Model = 7319;
			ObjectClass = 2;
			SubClass = 8;
			Level = 22;
			ReqLevel = 17;
			Name = "Blessed Claymore";
			Name2 = "Blessed Claymore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12311;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 70;
			SetDamage( 29 , 44 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Executioner's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ExecutionersSword : Item
	{
		public ExecutionersSword() : base()
		{
			Id = 4818;
			Bonding = 2;
			SellPrice = 2854;
			AvailableClasses = 0x7FFF;
			Model = 20155;
			ObjectClass = 2;
			SubClass = 8;
			Level = 24;
			ReqLevel = 19;
			Name = "Executioner's Sword";
			Name2 = "Executioner's Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14273;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 43 , 65 , Resistances.Armor );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Steady Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class SteadyBastardSword : Item
	{
		public SteadyBastardSword() : base()
		{
			Id = 4939;
			Bonding = 1;
			SellPrice = 395;
			AvailableClasses = 0x7FFF;
			Model = 20112;
			ObjectClass = 2;
			SubClass = 8;
			Level = 11;
			Name = "Steady Bastard Sword";
			Name2 = "Steady Bastard Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1977;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 45;
			SetDamage( 16 , 25 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Shiver Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ShiverBlade : Item
	{
		public ShiverBlade() : base()
		{
			Id = 5182;
			Bonding = 2;
			SellPrice = 1769;
			AvailableClasses = 0x7FFF;
			Model = 8000;
			ObjectClass = 2;
			SubClass = 8;
			Level = 20;
			ReqLevel = 15;
			Name = "Shiver Blade";
			Name2 = "Shiver Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8849;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetSpell( 18092 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 30 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Seraph's Strike)
*
***************************************************************/

namespace Server.Items
{
	public class SeraphsStrike : Item
	{
		public SeraphsStrike() : base()
		{
			Id = 5614;
			Bonding = 1;
			SellPrice = 6147;
			AvailableClasses = 0x7FFF;
			Model = 20182;
			ObjectClass = 2;
			SubClass = 8;
			Level = 31;
			Name = "Seraph's Strike";
			Name2 = "Seraph's Strike";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30735;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 54 , 81 , Resistances.Armor );
			StrBonus = 3;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Woodsman Sword)
*
***************************************************************/

namespace Server.Items
{
	public class WoodsmanSword : Item
	{
		public WoodsmanSword() : base()
		{
			Id = 5615;
			Bonding = 1;
			SellPrice = 1776;
			AvailableClasses = 0x7FFF;
			Model = 20121;
			ObjectClass = 2;
			SubClass = 8;
			Level = 20;
			Name = "Woodsman Sword";
			Name2 = "Woodsman Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8883;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 34 , 52 , Resistances.Armor );
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Forsaken Bastard Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ForsakenBastardSword : Item
	{
		public ForsakenBastardSword() : base()
		{
			Id = 5779;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 20084;
			ObjectClass = 2;
			SubClass = 8;
			Level = 5;
			Name = "Forsaken Bastard Sword";
			Name2 = "Forsaken Bastard Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 152;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 7 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Emil's Brand)
*
***************************************************************/

namespace Server.Items
{
	public class EmilsBrand : Item
	{
		public EmilsBrand() : base()
		{
			Id = 5813;
			Bonding = 1;
			SellPrice = 7087;
			AvailableClasses = 0x7FFF;
			Model = 9055;
			ObjectClass = 2;
			SubClass = 8;
			Level = 32;
			Name = "Emil's Brand";
			Name2 = "Emil's Brand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35439;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 53 , 81 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Trogg Slicer)
*
***************************************************************/

namespace Server.Items
{
	public class TroggSlicer : Item
	{
		public TroggSlicer() : base()
		{
			Id = 6186;
			Bonding = 1;
			SellPrice = 1372;
			AvailableClasses = 0x7FFF;
			Model = 20119;
			ObjectClass = 2;
			SubClass = 8;
			Level = 18;
			Name = "Trogg Slicer";
			Name2 = "Trogg Slicer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6864;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 32 , 49 , Resistances.Armor );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Haunting Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HauntingBlade : Item
	{
		public HauntingBlade() : base()
		{
			Id = 6641;
			Bonding = 1;
			SellPrice = 3675;
			AvailableClasses = 0x7FFF;
			Model = 20167;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Haunting Blade";
			Name2 = "Haunting Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18376;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 53 , 80 , Resistances.Armor );
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Orcish War Sword)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishWarSword : Item
	{
		public OrcishWarSword() : base()
		{
			Id = 6741;
			Bonding = 1;
			SellPrice = 3014;
			AvailableClasses = 0x7FFF;
			Model = 20177;
			ObjectClass = 2;
			SubClass = 8;
			Level = 29;
			Name = "Orcish War Sword";
			Name2 = "Orcish War Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15072;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 45 , 68 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Strike of the Hydra)
*
***************************************************************/

namespace Server.Items
{
	public class StrikeOfTheHydra : Item
	{
		public StrikeOfTheHydra() : base()
		{
			Id = 6909;
			Bonding = 1;
			SellPrice = 7155;
			AvailableClasses = 0x7FFF;
			Model = 20185;
			ObjectClass = 2;
			SubClass = 8;
			Level = 31;
			ReqLevel = 26;
			Name = "Strike of the Hydra";
			Name2 = "Strike of the Hydra";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35777;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13526 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 67 , 102 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Whirlwind Sword)
*
***************************************************************/

namespace Server.Items
{
	public class WhirlwindSword : Item
	{
		public WhirlwindSword() : base()
		{
			Id = 6977;
			Bonding = 1;
			SellPrice = 17325;
			AvailableClasses = 0x01;
			Model = 22731;
			ObjectClass = 2;
			SubClass = 8;
			Level = 40;
			Name = "Whirlwind Sword";
			Name2 = "Whirlwind Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86627;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 82 , 124 , Resistances.Armor );
			StaminaBonus = 14;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Morbid Dawn)
*
***************************************************************/

namespace Server.Items
{
	public class MorbidDawn : Item
	{
		public MorbidDawn() : base()
		{
			Id = 7689;
			Bonding = 1;
			SellPrice = 11124;
			AvailableClasses = 0x7FFF;
			Model = 20172;
			ObjectClass = 2;
			SubClass = 8;
			Level = 35;
			ReqLevel = 30;
			Name = "Morbid Dawn";
			Name2 = "Morbid Dawn";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55621;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 70 , 105 , Resistances.Armor );
			StaminaBonus = 15;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Copper Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class CopperClaymore : Item
	{
		public CopperClaymore() : base()
		{
			Id = 7955;
			SellPrice = 241;
			AvailableClasses = 0x7FFF;
			Model = 20071;
			ObjectClass = 2;
			SubClass = 8;
			Level = 11;
			ReqLevel = 6;
			Name = "Copper Claymore";
			Name2 = "Copper Claymore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1208;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 45;
			SetDamage( 15 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bronze Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeGreatsword : Item
	{
		public BronzeGreatsword() : base()
		{
			Id = 7957;
			SellPrice = 2205;
			AvailableClasses = 0x7FFF;
			Model = 16147;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Bronze Greatsword";
			Name2 = "Bronze Greatsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11028;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 38 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Truesilver Champion)
*
***************************************************************/

namespace Server.Items
{
	public class TruesilverChampion : Item
	{
		public TruesilverChampion() : base()
		{
			Id = 7960;
			Bonding = 2;
			SellPrice = 38548;
			AvailableClasses = 0x7FFF;
			Model = 23264;
			ObjectClass = 2;
			SubClass = 8;
			Level = 52;
			ReqLevel = 47;
			Name = "Truesilver Champion";
			Name2 = "Truesilver Champion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 192743;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 9800 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 108 , 162 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Practice Sword)
*
***************************************************************/

namespace Server.Items
{
	public class PracticeSword : Item
	{
		public PracticeSword() : base()
		{
			Id = 8177;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 18354;
			ObjectClass = 2;
			SubClass = 8;
			Level = 7;
			ReqLevel = 2;
			Name = "Practice Sword";
			Name2 = "Practice Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 358;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 9 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Training Sword)
*
***************************************************************/

namespace Server.Items
{
	public class TrainingSword : Item
	{
		public TrainingSword() : base()
		{
			Id = 8178;
			Bonding = 2;
			SellPrice = 306;
			AvailableClasses = 0x7FFF;
			Model = 26591;
			ObjectClass = 2;
			SubClass = 8;
			Level = 10;
			ReqLevel = 5;
			Name = "Training Sword";
			Name2 = "Training Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5173;
			BuyPrice = 1531;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 45;
			SetDamage( 20 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battlefield Destroyer)
*
***************************************************************/

namespace Server.Items
{
	public class BattlefieldDestroyer : Item
	{
		public BattlefieldDestroyer() : base()
		{
			Id = 8199;
			Bonding = 2;
			SellPrice = 24661;
			AvailableClasses = 0x7FFF;
			Model = 18342;
			ObjectClass = 2;
			SubClass = 8;
			Level = 47;
			ReqLevel = 42;
			Name = "Battlefield Destroyer";
			Name2 = "Battlefield Destroyer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5272;
			BuyPrice = 123306;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 90 , 136 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sul'thraze the Lasher)
*
***************************************************************/

namespace Server.Items
{
	public class SulthrazeTheLasher : Item
	{
		public SulthrazeTheLasher() : base()
		{
			Id = 9372;
			Bonding = 1;
			SellPrice = 61936;
			AvailableClasses = 0x7FFF;
			Model = 20616;
			ObjectClass = 2;
			SubClass = 8;
			Level = 55;
			ReqLevel = 50;
			Name = "Sul'thraze the Lasher";
			Name2 = "Sul'thraze the Lasher";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 309681;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 1088;
			SetSpell( 11658 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 108 , 163 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Archaic Defender)
*
***************************************************************/

namespace Server.Items
{
	public class ArchaicDefender : Item
	{
		public ArchaicDefender() : base()
		{
			Id = 9385;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 12280;
			AvailableClasses = 0x7FFF;
			Model = 20249;
			ObjectClass = 2;
			SubClass = 8;
			Level = 36;
			ReqLevel = 31;
			Name = "Archaic Defender";
			Name2 = "Archaic Defender";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61404;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 77 , 117 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stoneslayer)
*
***************************************************************/

namespace Server.Items
{
	public class Stoneslayer : Item
	{
		public Stoneslayer() : base()
		{
			Id = 9418;
			Bonding = 1;
			SellPrice = 32851;
			AvailableClasses = 0x5FF;
			Model = 20193;
			ObjectClass = 2;
			SubClass = 8;
			Level = 49;
			ReqLevel = 44;
			Name = "Stoneslayer";
			Name2 = "Stoneslayer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 164258;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 12731 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 133 , 200 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gizmotron Megachopper)
*
***************************************************************/

namespace Server.Items
{
	public class GizmotronMegachopper : Item
	{
		public GizmotronMegachopper() : base()
		{
			Id = 9490;
			Bonding = 2;
			SellPrice = 6121;
			AvailableClasses = 0x7FFF;
			Model = 18409;
			ObjectClass = 2;
			SubClass = 8;
			Level = 29;
			ReqLevel = 24;
			Name = "Gizmotron Megachopper";
			Name2 = "Gizmotron Megachopper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30609;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 61 , 92 , Resistances.Armor );
			StrBonus = 14;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Brushwood Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BrushwoodBlade : Item
	{
		public BrushwoodBlade() : base()
		{
			Id = 9602;
			Bonding = 1;
			SellPrice = 301;
			AvailableClasses = 0x7FFF;
			Model = 20069;
			ObjectClass = 2;
			SubClass = 8;
			Level = 10;
			Name = "Brushwood Blade";
			Name2 = "Brushwood Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1505;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 45;
			Flags = 16;
			SetDamage( 17 , 26 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Boneslasher)
*
***************************************************************/

namespace Server.Items
{
	public class Boneslasher : Item
	{
		public Boneslasher() : base()
		{
			Id = 10573;
			Bonding = 2;
			SellPrice = 13754;
			AvailableClasses = 0x7FFF;
			Model = 20149;
			ObjectClass = 2;
			SubClass = 8;
			Level = 37;
			ReqLevel = 32;
			Name = "Boneslasher";
			Name2 = "Boneslasher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68773;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 70 , 106 , Resistances.Armor );
			StaminaBonus = 7;
			StrBonus = 16;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Deathblow)
*
***************************************************************/

namespace Server.Items
{
	public class Deathblow : Item
	{
		public Deathblow() : base()
		{
			Id = 10628;
			Bonding = 2;
			SellPrice = 29245;
			AvailableClasses = 0x5FF;
			Model = 20189;
			ObjectClass = 2;
			SubClass = 8;
			Level = 48;
			ReqLevel = 43;
			Name = "Deathblow";
			Name2 = "Deathblow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 146225;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 16411 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 94 , 141 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(X'caliboar)
*
***************************************************************/

namespace Server.Items
{
	public class Xcaliboar : Item
	{
		public Xcaliboar() : base()
		{
			Id = 10758;
			Bonding = 1;
			SellPrice = 20144;
			AvailableClasses = 0x7FFF;
			Model = 19779;
			ObjectClass = 2;
			SubClass = 8;
			Level = 42;
			ReqLevel = 35;
			Name = "X'caliboar";
			Name2 = "X'caliboar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100723;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 98 , 148 , Resistances.Armor );
			StrBonus = 20;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Stone of the Earth)
*
***************************************************************/

namespace Server.Items
{
	public class StoneOfTheEarth : Item
	{
		public StoneOfTheEarth() : base()
		{
			Id = 11786;
			Resistance[0] = 280;
			Bonding = 1;
			SellPrice = 50739;
			AvailableClasses = 0x7FFF;
			Model = 21775;
			ObjectClass = 2;
			SubClass = 8;
			Level = 56;
			ReqLevel = 51;
			Name = "Stone of the Earth";
			Name2 = "Stone of the Earth";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 253699;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 123 , 185 , Resistances.Armor );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Samophlange Screwdriver)
*
***************************************************************/

namespace Server.Items
{
	public class SamophlangeScrewdriver : Item
	{
		public SamophlangeScrewdriver() : base()
		{
			Id = 11854;
			Bonding = 1;
			SellPrice = 1494;
			AvailableClasses = 0x7FFF;
			Model = 28245;
			ObjectClass = 2;
			SubClass = 8;
			Level = 19;
			Name = "Samophlange Screwdriver";
			Name2 = "Samophlange Screwdriver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7472;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 25 , 38 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Drakefang Butcher)
*
***************************************************************/

namespace Server.Items
{
	public class DrakefangButcher : Item
	{
		public DrakefangButcher() : base()
		{
			Id = 12463;
			Bonding = 1;
			SellPrice = 42446;
			AvailableClasses = 0x7FFF;
			Model = 20198;
			ObjectClass = 2;
			SubClass = 8;
			Level = 53;
			ReqLevel = 48;
			Name = "Drakefang Butcher";
			Name2 = "Drakefang Butcher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 212231;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 14118 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 99 , 149 , Resistances.Armor );
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Blackblade of Shahram)
*
***************************************************************/

namespace Server.Items
{
	public class BlackbladeOfShahram : Item
	{
		public BlackbladeOfShahram() : base()
		{
			Id = 12592;
			Bonding = 1;
			SellPrice = 95241;
			AvailableClasses = 0x7FFF;
			Model = 22906;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			ReqLevel = 58;
			Name = "Blackblade of Shahram";
			Name2 = "Blackblade of Shahram";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 476207;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 16602 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 109 , 164 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Corruption)
*
***************************************************************/

namespace Server.Items
{
	public class Corruption : Item
	{
		public Corruption() : base()
		{
			Id = 12782;
			Bonding = 1;
			SellPrice = 56808;
			AvailableClasses = 0x5FF;
			Model = 24255;
			ObjectClass = 2;
			SubClass = 8;
			Level = 58;
			ReqLevel = 53;
			Name = "Corruption";
			Name2 = "Corruption";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 284042;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 119 , 179 , Resistances.Armor );
			StrBonus = 30;
			StaminaBonus = 30;
			IqBonus = -40;
		}
	}
}


/**************************************************************
*
*				(Arcanite Champion)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaniteChampion : Item
	{
		public ArcaniteChampion() : base()
		{
			Id = 12790;
			Bonding = 2;
			SellPrice = 74619;
			AvailableClasses = 0x7FFF;
			Model = 24813;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			ReqLevel = 58;
			Name = "Arcanite Champion";
			Name2 = "Arcanite Champion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 373098;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 16916 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 129 , 194 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Searing Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SearingBlade : Item
	{
		public SearingBlade() : base()
		{
			Id = 12992;
			Bonding = 2;
			SellPrice = 3260;
			AvailableClasses = 0x7FFF;
			Model = 20071;
			ObjectClass = 2;
			SubClass = 8;
			Level = 23;
			ReqLevel = 18;
			Name = "Searing Blade";
			Name2 = "Searing Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16302;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetSpell( 16413 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Guardian Blade)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianBlade : Item
	{
		public GuardianBlade() : base()
		{
			Id = 13041;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 4516;
			AvailableClasses = 0x7FFF;
			Model = 28768;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Guardian Blade";
			Name2 = "Guardian Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22582;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 95;
			SetSpell( 13388 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 76 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sword of the Magistrate)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfTheMagistrate : Item
	{
		public SwordOfTheMagistrate() : base()
		{
			Id = 13042;
			Bonding = 2;
			SellPrice = 17596;
			AvailableClasses = 0x7FFF;
			Model = 28678;
			ObjectClass = 2;
			SubClass = 8;
			Level = 41;
			ReqLevel = 36;
			Name = "Sword of the Magistrate";
			Name2 = "Sword of the Magistrate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87983;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 96 , 145 , Resistances.Armor );
			StrBonus = 8;
			IqBonus = 10;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Blade of the Titans)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfTheTitans : Item
	{
		public BladeOfTheTitans() : base()
		{
			Id = 13043;
			Bonding = 2;
			SellPrice = 32389;
			AvailableClasses = 0x7FFF;
			Model = 28675;
			ObjectClass = 2;
			SubClass = 8;
			Level = 49;
			ReqLevel = 44;
			Name = "Blade of the Titans";
			Name2 = "Blade of the Titans";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 161949;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 112 , 169 , Resistances.Armor );
			StaminaBonus = 24;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Demonslayer)
*
***************************************************************/

namespace Server.Items
{
	public class Demonslayer : Item
	{
		public Demonslayer() : base()
		{
			Id = 13044;
			Bonding = 2;
			SellPrice = 52800;
			AvailableClasses = 0x7FFF;
			Model = 28714;
			ObjectClass = 2;
			SubClass = 8;
			Level = 57;
			ReqLevel = 52;
			Name = "Demonslayer";
			Name2 = "Demonslayer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 264000;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18212 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 121 , 182 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deanship Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class DeanshipClaymore : Item
	{
		public DeanshipClaymore() : base()
		{
			Id = 13049;
			Bonding = 2;
			SellPrice = 6191;
			AvailableClasses = 0x7FFF;
			Model = 28707;
			ObjectClass = 2;
			SubClass = 8;
			Level = 29;
			ReqLevel = 26;
			Name = "Deanship Claymore";
			Name2 = "Deanship Claymore";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30958;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 80 , Resistances.Armor );
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Witchfury)
*
***************************************************************/

namespace Server.Items
{
	public class Witchfury : Item
	{
		public Witchfury() : base()
		{
			Id = 13051;
			Bonding = 2;
			SellPrice = 22911;
			AvailableClasses = 0x7FFF;
			Model = 28598;
			ObjectClass = 2;
			SubClass = 8;
			Level = 44;
			ReqLevel = 39;
			Name = "Witchfury";
			Name2 = "Witchfury";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 114557;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18214 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 87 , 131 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Warmonger)
*
***************************************************************/

namespace Server.Items
{
	public class Warmonger : Item
	{
		public Warmonger() : base()
		{
			Id = 13052;
			Bonding = 2;
			SellPrice = 41677;
			AvailableClasses = 0x7FFF;
			Model = 28624;
			ObjectClass = 2;
			SubClass = 8;
			Level = 52;
			ReqLevel = 47;
			Name = "Warmonger";
			Name2 = "Warmonger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 208388;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15466 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 108 , 162 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Doombringer)
*
***************************************************************/

namespace Server.Items
{
	public class Doombringer : Item
	{
		public Doombringer() : base()
		{
			Id = 13053;
			Bonding = 2;
			SellPrice = 59186;
			AvailableClasses = 0x7FFF;
			Model = 28717;
			ObjectClass = 2;
			SubClass = 8;
			Level = 60;
			ReqLevel = 55;
			Name = "Doombringer";
			Name2 = "Doombringer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 295933;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18211 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 115 , 173 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Relentless Scythe)
*
***************************************************************/

namespace Server.Items
{
	public class RelentlessScythe : Item
	{
		public RelentlessScythe() : base()
		{
			Id = 13163;
			Bonding = 1;
			SellPrice = 69537;
			AvailableClasses = 0x7FFF;
			Model = 23683;
			ObjectClass = 2;
			SubClass = 8;
			Level = 62;
			ReqLevel = 57;
			Name = "Relentless Scythe";
			Name2 = "Relentless Scythe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 347688;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 97 , 147 , Resistances.Armor );
			AgilityBonus = 8;
			StrBonus = 20;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ashbringer)
*
***************************************************************/

namespace Server.Items
{
	public class Ashbringer : Item
	{
		public Ashbringer() : base()
		{
			Id = 13262;
			Bonding = 1;
			SellPrice = 261407;
			AvailableClasses = 0x7FFF;
			Description = "Blade of the Scarlet High Lord";
			Model = 23875;
			ObjectClass = 2;
			SubClass = 8;
			Level = 76;
			ReqLevel = 60;
			Name = "Ashbringer";
			Name2 = "Ashbringer";
			Quality = 5;
			AvailableRaces = 0x1FF;
			BuyPrice = 1307038;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 145;
			SetSpell( 18112 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 201 , 247 , Resistances.Armor );
			SetDamage( 30 , 50 , Resistances.Light );
		}
	}
}


/**************************************************************
*
*				(Demonshear)
*
***************************************************************/

namespace Server.Items
{
	public class Demonshear : Item
	{
		public Demonshear() : base()
		{
			Id = 13348;
			Bonding = 1;
			SellPrice = 72769;
			AvailableClasses = 0x7FFF;
			Model = 24049;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			ReqLevel = 58;
			Name = "Demonshear";
			Name2 = "Demonshear";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 363849;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 17483 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 99 , 149 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Runeblade of Baron Rivendare)
*
***************************************************************/

namespace Server.Items
{
	public class RunebladeOfBaronRivendare : Item
	{
		public RunebladeOfBaronRivendare() : base()
		{
			Id = 13505;
			Bonding = 1;
			SellPrice = 91345;
			AvailableClasses = 0x7FFF;
			Model = 24166;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			ReqLevel = 58;
			Name = "Runeblade of Baron Rivendare";
			Name2 = "Runeblade of Baron Rivendare";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 456725;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 17625 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 133 , 200 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tapered Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class TaperedGreatsword : Item
	{
		public TaperedGreatsword() : base()
		{
			Id = 13817;
			SellPrice = 18796;
			AvailableClasses = 0x7FFF;
			Model = 20195;
			ObjectClass = 2;
			SubClass = 8;
			Level = 58;
			ReqLevel = 53;
			Name = "Tapered Greatsword";
			Name2 = "Tapered Greatsword";
			AvailableRaces = 0x1FF;
			BuyPrice = 93984;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 62 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Warblade of Caer Darrow)
*
***************************************************************/

namespace Server.Items
{
	public class WarbladeOfCaerDarrow : Item
	{
		public WarbladeOfCaerDarrow() : base()
		{
			Id = 13982;
			Bonding = 1;
			SellPrice = 69826;
			AvailableClasses = 0x7FFF;
			Model = 26676;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			Name = "Warblade of Caer Darrow";
			Name2 = "Warblade of Caer Darrow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 349130;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 142 , 214 , Resistances.Armor );
			SetDamage( 1 , 22 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Barovian Family Sword)
*
***************************************************************/

namespace Server.Items
{
	public class BarovianFamilySword : Item
	{
		public BarovianFamilySword() : base()
		{
			Id = 14541;
			Bonding = 1;
			SellPrice = 68426;
			AvailableClasses = 0x7FFF;
			Model = 25649;
			ObjectClass = 2;
			SubClass = 8;
			Level = 61;
			ReqLevel = 56;
			Name = "Barovian Family Sword";
			Name2 = "Barovian Family Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 342132;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18652 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 87 , 132 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gleaming Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class GleamingClaymore : Item
	{
		public GleamingClaymore() : base()
		{
			Id = 15248;
			Bonding = 2;
			SellPrice = 1791;
			AvailableClasses = 0x7FFF;
			Model = 28535;
			ObjectClass = 2;
			SubClass = 8;
			Level = 20;
			ReqLevel = 15;
			Name = "Gleaming Claymore";
			Name2 = "Gleaming Claymore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5191;
			BuyPrice = 8959;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 30 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Polished Zweihander)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedZweihander : Item
	{
		public PolishedZweihander() : base()
		{
			Id = 15249;
			Bonding = 2;
			SellPrice = 3877;
			AvailableClasses = 0x7FFF;
			Model = 20080;
			ObjectClass = 2;
			SubClass = 8;
			Level = 26;
			ReqLevel = 21;
			Name = "Polished Zweihander";
			Name2 = "Polished Zweihander";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5209;
			BuyPrice = 19388;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 50 , 76 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Glimmering Flamberge)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringFlamberge : Item
	{
		public GlimmeringFlamberge() : base()
		{
			Id = 15250;
			Bonding = 2;
			SellPrice = 6894;
			AvailableClasses = 0x7FFF;
			Model = 28536;
			ObjectClass = 2;
			SubClass = 8;
			Level = 32;
			ReqLevel = 27;
			Name = "Glimmering Flamberge";
			Name2 = "Glimmering Flamberge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5227;
			BuyPrice = 34474;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 55 , 84 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Headstriker Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HeadstrikerSword : Item
	{
		public HeadstrikerSword() : base()
		{
			Id = 15251;
			Bonding = 2;
			SellPrice = 17685;
			AvailableClasses = 0x7FFF;
			Model = 28546;
			ObjectClass = 2;
			SubClass = 8;
			Level = 43;
			ReqLevel = 38;
			Name = "Headstriker Sword";
			Name2 = "Headstriker Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5263;
			BuyPrice = 88428;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 62 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tusker Sword)
*
***************************************************************/

namespace Server.Items
{
	public class TuskerSword : Item
	{
		public TuskerSword() : base()
		{
			Id = 15252;
			Bonding = 2;
			SellPrice = 27906;
			AvailableClasses = 0x7FFF;
			Model = 28465;
			ObjectClass = 2;
			SubClass = 8;
			Level = 49;
			ReqLevel = 44;
			Name = "Tusker Sword";
			Name2 = "Tusker Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5281;
			BuyPrice = 139530;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 112 , 169 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Beheading Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BeheadingBlade : Item
	{
		public BeheadingBlade() : base()
		{
			Id = 15253;
			Bonding = 2;
			SellPrice = 31547;
			AvailableClasses = 0x7FFF;
			Model = 28321;
			ObjectClass = 2;
			SubClass = 8;
			Level = 52;
			ReqLevel = 47;
			Name = "Beheading Blade";
			Name2 = "Beheading Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5290;
			BuyPrice = 157738;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 113 , 170 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dark Espadon)
*
***************************************************************/

namespace Server.Items
{
	public class DarkEspadon : Item
	{
		public DarkEspadon() : base()
		{
			Id = 15254;
			Bonding = 2;
			SellPrice = 35584;
			AvailableClasses = 0x7FFF;
			Model = 28347;
			ObjectClass = 2;
			SubClass = 8;
			Level = 54;
			ReqLevel = 49;
			Name = "Dark Espadon";
			Name2 = "Dark Espadon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5290;
			BuyPrice = 177922;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 110 , 166 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gallant Flamberge)
*
***************************************************************/

namespace Server.Items
{
	public class GallantFlamberge : Item
	{
		public GallantFlamberge() : base()
		{
			Id = 15255;
			Bonding = 2;
			SellPrice = 42545;
			AvailableClasses = 0x7FFF;
			Model = 28529;
			ObjectClass = 2;
			SubClass = 8;
			Level = 57;
			ReqLevel = 52;
			Name = "Gallant Flamberge";
			Name2 = "Gallant Flamberge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5299;
			BuyPrice = 212728;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 120 , 181 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Massacre Sword)
*
***************************************************************/

namespace Server.Items
{
	public class MassacreSword : Item
	{
		public MassacreSword() : base()
		{
			Id = 15256;
			Bonding = 2;
			SellPrice = 47531;
			AvailableClasses = 0x7FFF;
			Model = 28576;
			ObjectClass = 2;
			SubClass = 8;
			Level = 59;
			ReqLevel = 54;
			Name = "Massacre Sword";
			Name2 = "Massacre Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5308;
			BuyPrice = 237656;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 139 , 209 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shin Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ShinBlade : Item
	{
		public ShinBlade() : base()
		{
			Id = 15257;
			Bonding = 2;
			SellPrice = 55234;
			AvailableClasses = 0x7FFF;
			Model = 26589;
			ObjectClass = 2;
			SubClass = 8;
			Level = 62;
			ReqLevel = 57;
			Name = "Shin Blade";
			Name2 = "Shin Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5317;
			BuyPrice = 276172;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 84 , 127 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Divine Warblade)
*
***************************************************************/

namespace Server.Items
{
	public class DivineWarblade : Item
	{
		public DivineWarblade() : base()
		{
			Id = 15258;
			Bonding = 2;
			SellPrice = 64185;
			AvailableClasses = 0x7FFF;
			Model = 28517;
			ObjectClass = 2;
			SubClass = 8;
			Level = 65;
			ReqLevel = 60;
			Name = "Divine Warblade";
			Name2 = "Divine Warblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5326;
			BuyPrice = 320928;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 109 , 164 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ta'Kierthan Songblade)
*
***************************************************************/

namespace Server.Items
{
	public class TaKierthanSongblade : Item
	{
		public TaKierthanSongblade() : base()
		{
			Id = 16039;
			Bonding = 2;
			SellPrice = 53598;
			AvailableClasses = 0x7FFF;
			Model = 26674;
			ObjectClass = 2;
			SubClass = 8;
			Level = 57;
			ReqLevel = 52;
			Name = "Ta'Kierthan Songblade";
			Name2 = "Ta'Kierthan Songblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 267990;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 129 , 194 , Resistances.Armor );
			SetDamage( 1 , 20 , Resistances.Arcane );
		}
	}
}


/**************************************************************
*
*				(Bonereaver's Edge)
*
***************************************************************/

namespace Server.Items
{
	public class BonereaversEdge : Item
	{
		public BonereaversEdge() : base()
		{
			Id = 17076;
			Bonding = 1;
			SellPrice = 196438;
			AvailableClasses = 0x7FFF;
			Model = 29170;
			ObjectClass = 2;
			SubClass = 8;
			Level = 77;
			ReqLevel = 60;
			Name = "Bonereaver's Edge";
			Name2 = "Bonereaver's Edge";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 982192;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21153 , 2 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 206 , 310 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sprinter's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class SprintersSword : Item
	{
		public SprintersSword() : base()
		{
			Id = 18410;
			Bonding = 1;
			SellPrice = 45516;
			AvailableClasses = 0x7FFF;
			Model = 30778;
			ObjectClass = 2;
			SubClass = 8;
			Level = 57;
			Name = "Sprinter's Sword";
			Name2 = "Sprinter's Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 227582;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 85;
			SetSpell( 22863 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 99 , 149 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Barbarous Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BarbarousBlade : Item
	{
		public BarbarousBlade() : base()
		{
			Id = 18520;
			Bonding = 1;
			SellPrice = 68652;
			AvailableClasses = 0x7FFF;
			Model = 30853;
			ObjectClass = 2;
			SubClass = 8;
			Level = 63;
			ReqLevel = 58;
			Name = "Barbarous Blade";
			Name2 = "Barbarous Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 343264;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 100;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14052 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Typhoon)
*
***************************************************************/

namespace Server.Items
{
	public class Typhoon : Item
	{
		public Typhoon() : base()
		{
			Id = 18542;
			Bonding = 1;
			SellPrice = 125278;
			AvailableClasses = 0x7FFF;
			Model = 30886;
			ObjectClass = 2;
			SubClass = 8;
			Level = 68;
			ReqLevel = 60;
			Name = "Typhoon";
			Name2 = "Typhoon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 626393;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 150 , 225 , Resistances.Armor );
			StrBonus = 14;
			AgilityBonus = 20;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Obsidian Edged Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ObsidianEdgedBlade : Item
	{
		public ObsidianEdgedBlade() : base()
		{
			Id = 18822;
			Bonding = 1;
			SellPrice = 125768;
			AvailableClasses = 0x7FFF;
			Model = 31288;
			ObjectClass = 2;
			SubClass = 8;
			Level = 68;
			ReqLevel = 60;
			Name = "Obsidian Edged Blade";
			Name2 = "Obsidian Edged Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 628843;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 15771 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 176 , 264 , Resistances.Armor );
			StrBonus = 42;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Claymore)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsClaymore : Item
	{
		public GrandMarshalsClaymore() : base()
		{
			Id = 18876;
			Bonding = 1;
			SellPrice = 60118;
			AvailableClasses = 0x7FFF;
			Model = 31996;
			ObjectClass = 2;
			SubClass = 8;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Claymore";
			Name2 = "Grand Marshal's Claymore";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 300592;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 235 , 353 , Resistances.Armor );
			StaminaBonus = 41;
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Greatsword)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsGreatsword : Item
	{
		public HighWarlordsGreatsword() : base()
		{
			Id = 18877;
			Bonding = 1;
			SellPrice = 60339;
			AvailableClasses = 0x7FFF;
			Model = 31998;
			ObjectClass = 2;
			SubClass = 8;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Greatsword";
			Name2 = "High Warlord's Greatsword";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 301699;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 235 , 353 , Resistances.Armor );
			StaminaBonus = 41;
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(The Untamed Blade)
*
***************************************************************/

namespace Server.Items
{
	public class TheUntamedBlade : Item
	{
		public TheUntamedBlade() : base()
		{
			Id = 19334;
			Bonding = 1;
			SellPrice = 160453;
			AvailableClasses = 0x7FFF;
			Model = 31999;
			ObjectClass = 2;
			SubClass = 8;
			Level = 73;
			ReqLevel = 60;
			Name = "The Untamed Blade";
			Name2 = "The Untamed Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 802268;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 23719 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 192 , 289 , Resistances.Armor );
			AgilityBonus = 22;
			StaminaBonus = 16;
		}
	}
}


