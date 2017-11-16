/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:18 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Iron Knuckles)
*
***************************************************************/

namespace Server.Items
{
	public class IronKnuckles : Item
	{
		public IronKnuckles() : base()
		{
			Id = 2942;
			Bonding = 1;
			SellPrice = 3663;
			AvailableClasses = 0x7FFF;
			Model = 3007;
			ObjectClass = 2;
			SubClass = 13;
			Level = 26;
			ReqLevel = 21;
			Name = "Iron Knuckles";
			Name2 = "Iron Knuckles";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18316;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 60;
			SetSpell( 13491 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloody Brass Knuckles)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyBrassKnuckles : Item
	{
		public BloodyBrassKnuckles() : base()
		{
			Id = 7683;
			SellPrice = 3958;
			AvailableClasses = 0x7FFF;
			Model = 15720;
			ObjectClass = 2;
			SubClass = 13;
			Level = 34;
			ReqLevel = 29;
			Name = "Bloody Brass Knuckles";
			Name2 = "Bloody Brass Knuckles";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 19792;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vilerend Slicer)
*
***************************************************************/

namespace Server.Items
{
	public class VilerendSlicer : Item
	{
		public VilerendSlicer() : base()
		{
			Id = 11603;
			Bonding = 2;
			SellPrice = 30656;
			AvailableClasses = 0x7FFF;
			Model = 23270;
			ObjectClass = 2;
			SubClass = 13;
			Level = 51;
			ReqLevel = 46;
			Name = "Vilerend Slicer";
			Name2 = "Vilerend Slicer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 153283;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 16405 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rockfist)
*
***************************************************************/

namespace Server.Items
{
	public class Rockfist : Item
	{
		public Rockfist() : base()
		{
			Id = 11743;
			Bonding = 1;
			SellPrice = 30734;
			AvailableClasses = 0x7FFF;
			Model = 21714;
			ObjectClass = 2;
			SubClass = 13;
			Level = 55;
			ReqLevel = 50;
			Name = "Rockfist";
			Name2 = "Rockfist";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 153672;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 55;
			SetDamage( 32 , 60 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bloodfist)
*
***************************************************************/

namespace Server.Items
{
	public class Bloodfist : Item
	{
		public Bloodfist() : base()
		{
			Id = 11744;
			Bonding = 1;
			SellPrice = 39242;
			AvailableClasses = 0x7FFF;
			Model = 21715;
			ObjectClass = 2;
			SubClass = 13;
			Level = 56;
			ReqLevel = 51;
			Name = "Bloodfist";
			Name2 = "Bloodfist";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 196213;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 16433 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 38 , 72 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(White Bone Shredder)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteBoneShredder : Item
	{
		public WhiteBoneShredder() : base()
		{
			Id = 11863;
			Bonding = 1;
			SellPrice = 27191;
			AvailableClasses = 0x7FFF;
			Model = 21855;
			ObjectClass = 2;
			SubClass = 13;
			Level = 52;
			Name = "White Bone Shredder";
			Name2 = "White Bone Shredder";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 135957;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 55;
			SetDamage( 30 , 57 , Resistances.Armor );
			StrBonus = 4;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hurd Smasher)
*
***************************************************************/

namespace Server.Items
{
	public class HurdSmasher : Item
	{
		public HurdSmasher() : base()
		{
			Id = 13198;
			Bonding = 1;
			SellPrice = 50851;
			AvailableClasses = 0x7FFF;
			Model = 23742;
			ObjectClass = 2;
			SubClass = 13;
			Level = 60;
			ReqLevel = 55;
			Name = "Hurd Smasher";
			Name2 = "Hurd Smasher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 254256;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 17308 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 93 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gargoyle Shredder Talons)
*
***************************************************************/

namespace Server.Items
{
	public class GargoyleShredderTalons : Item
	{
		public GargoyleShredderTalons() : base()
		{
			Id = 13399;
			Bonding = 1;
			SellPrice = 46312;
			AvailableClasses = 0x7FFF;
			Model = 24109;
			ObjectClass = 2;
			SubClass = 13;
			Level = 59;
			ReqLevel = 54;
			Name = "Gargoyle Shredder Talons";
			Name2 = "Gargoyle Shredder Talons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 231560;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 18202 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Right-Handed Claw)
*
***************************************************************/

namespace Server.Items
{
	public class RightHandedClaw : Item
	{
		public RightHandedClaw() : base()
		{
			Id = 15903;
			SellPrice = 1623;
			AvailableClasses = 0x7FFF;
			Model = 26593;
			ObjectClass = 2;
			SubClass = 13;
			Level = 25;
			ReqLevel = 20;
			Name = "Right-Handed Claw";
			Name2 = "Right-Handed Claw";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8117;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 45;
			SetDamage( 12 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Right-Handed Blades)
*
***************************************************************/

namespace Server.Items
{
	public class RightHandedBlades : Item
	{
		public RightHandedBlades() : base()
		{
			Id = 15904;
			SellPrice = 4341;
			AvailableClasses = 0x7FFF;
			Model = 26596;
			ObjectClass = 2;
			SubClass = 13;
			Level = 35;
			ReqLevel = 30;
			Name = "Right-Handed Blades";
			Name2 = "Right-Handed Blades";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 21708;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 55;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Right-Handed Brass Knuckles)
*
***************************************************************/

namespace Server.Items
{
	public class RightHandedBrassKnuckles : Item
	{
		public RightHandedBrassKnuckles() : base()
		{
			Id = 15905;
			SellPrice = 426;
			AvailableClasses = 0x7FFF;
			Model = 26592;
			ObjectClass = 2;
			SubClass = 13;
			Level = 15;
			ReqLevel = 10;
			Name = "Right-Handed Brass Knuckles";
			Name2 = "Right-Handed Brass Knuckles";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2130;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 35;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Left-Handed Brass Knuckles)
*
***************************************************************/

namespace Server.Items
{
	public class LeftHandedBrassKnuckles : Item
	{
		public LeftHandedBrassKnuckles() : base()
		{
			Id = 15906;
			SellPrice = 427;
			AvailableClasses = 0x7FFF;
			Model = 26592;
			ObjectClass = 2;
			SubClass = 13;
			Level = 15;
			ReqLevel = 10;
			Name = "Left-Handed Brass Knuckles";
			Name2 = "Left-Handed Brass Knuckles";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2138;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 35;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Left-Handed Claw)
*
***************************************************************/

namespace Server.Items
{
	public class LeftHandedClaw : Item
	{
		public LeftHandedClaw() : base()
		{
			Id = 15907;
			SellPrice = 1647;
			AvailableClasses = 0x7FFF;
			Model = 26594;
			ObjectClass = 2;
			SubClass = 13;
			Level = 25;
			ReqLevel = 20;
			Name = "Left-Handed Claw";
			Name2 = "Left-Handed Claw";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8237;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 45;
			SetDamage( 12 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Left-Handed Blades)
*
***************************************************************/

namespace Server.Items
{
	public class LeftHandedBlades : Item
	{
		public LeftHandedBlades() : base()
		{
			Id = 15909;
			SellPrice = 4421;
			AvailableClasses = 0x7FFF;
			Model = 26597;
			ObjectClass = 2;
			SubClass = 13;
			Level = 35;
			ReqLevel = 30;
			Name = "Left-Handed Blades";
			Name2 = "Left-Handed Blades";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22107;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 55;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Claw of Celebras)
*
***************************************************************/

namespace Server.Items
{
	public class ClawOfCelebras : Item
	{
		public ClawOfCelebras() : base()
		{
			Id = 17738;
			Bonding = 1;
			SellPrice = 33351;
			AvailableClasses = 0x7FFF;
			Model = 29915;
			ObjectClass = 2;
			SubClass = 13;
			Level = 52;
			ReqLevel = 47;
			Name = "Claw of Celebras";
			Name2 = "Claw of Celebras";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 166758;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 21952 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 43 , 81 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Eskhandar's Left Claw)
*
***************************************************************/

namespace Server.Items
{
	public class EskhandarsLeftClaw : Item
	{
		public EskhandarsLeftClaw() : base()
		{
			Id = 18202;
			Bonding = 1;
			SellPrice = 90576;
			AvailableClasses = 0x7FFF;
			Model = 30594;
			ObjectClass = 2;
			SubClass = 13;
			Level = 66;
			ReqLevel = 60;
			Name = "Eskhandar's Left Claw";
			Name2 = "Eskhandar's Left Claw";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 452881;
			Sets = 261;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
			SetSpell( 22639 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Eskhandar's Right Claw)
*
***************************************************************/

namespace Server.Items
{
	public class EskhandarsRightClaw : Item
	{
		public EskhandarsRightClaw() : base()
		{
			Id = 18203;
			Bonding = 1;
			SellPrice = 90905;
			AvailableClasses = 0x7FFF;
			Model = 30595;
			ObjectClass = 2;
			SubClass = 13;
			Level = 66;
			ReqLevel = 60;
			Name = "Eskhandar's Right Claw";
			Name2 = "Eskhandar's Right Claw";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 454525;
			Sets = 261;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
			SetSpell( 22640 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Jagged Bone Fist)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedBoneFist : Item
	{
		public JaggedBoneFist() : base()
		{
			Id = 18462;
			Bonding = 1;
			SellPrice = 41319;
			AvailableClasses = 0x7FFF;
			Model = 30813;
			ObjectClass = 2;
			SubClass = 13;
			Level = 60;
			ReqLevel = 55;
			Name = "Jagged Bone Fist";
			Name2 = "Jagged Bone Fist";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 206595;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			SetDamage( 51 , 78 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Right Hand Blade)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsRightHandBlade : Item
	{
		public GrandMarshalsRightHandBlade() : base()
		{
			Id = 18843;
			Bonding = 1;
			SellPrice = 49339;
			AvailableClasses = 0x7FFF;
			Model = 32033;
			ObjectClass = 2;
			SubClass = 13;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Right Hand Blade";
			Name2 = "Grand Marshal's Right Hand Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 246698;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
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
*				(High Warlord's Right Claw)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsRightClaw : Item
	{
		public HighWarlordsRightClaw() : base()
		{
			Id = 18844;
			Bonding = 1;
			SellPrice = 49516;
			AvailableClasses = 0x7FFF;
			Model = 31754;
			ObjectClass = 2;
			SubClass = 13;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Right Claw";
			Name2 = "High Warlord's Right Claw";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 247584;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
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
*				(Grand Marshal's Left Hand Blade)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsLeftHandBlade : Item
	{
		public GrandMarshalsLeftHandBlade() : base()
		{
			Id = 18847;
			Bonding = 1;
			SellPrice = 50043;
			AvailableClasses = 0x7FFF;
			Model = 32032;
			ObjectClass = 2;
			SubClass = 13;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Left Hand Blade";
			Name2 = "Grand Marshal's Left Hand Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 250218;
			InventoryType = InventoryTypes.OffHand;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
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
*				(High Warlord's Left Claw)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsLeftClaw : Item
	{
		public HighWarlordsLeftClaw() : base()
		{
			Id = 18848;
			Bonding = 1;
			SellPrice = 50215;
			AvailableClasses = 0x7FFF;
			Model = 31752;
			ObjectClass = 2;
			SubClass = 13;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Left Claw";
			Name2 = "High Warlord's Left Claw";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 251079;
			InventoryType = InventoryTypes.OffHand;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
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
*				(Claw of the Black Drake)
*
***************************************************************/

namespace Server.Items
{
	public class ClawOfTheBlackDrake : Item
	{
		public ClawOfTheBlackDrake() : base()
		{
			Id = 19365;
			Bonding = 1;
			SellPrice = 136928;
			AvailableClasses = 0x7FFF;
			Model = 31880;
			ObjectClass = 2;
			SubClass = 13;
			Level = 75;
			ReqLevel = 60;
			Name = "Claw of the Black Drake";
			Name2 = "Claw of the Black Drake";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 684643;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			Durability = 75;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 102 , 191 , Resistances.Armor );
			StrBonus = 13;
			StaminaBonus = 7;
		}
	}
}


