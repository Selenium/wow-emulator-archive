/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:06:03 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Pearl-encrusted Spear)
*
***************************************************************/

namespace Server.Items
{
	public class PearlEncrustedSpear : Item
	{
		public PearlEncrustedSpear() : base()
		{
			Id = 1406;
			Bonding = 2;
			SellPrice = 2079;
			AvailableClasses = 0x7FFF;
			Model = 5638;
			ObjectClass = 2;
			SubClass = 6;
			Level = 21;
			ReqLevel = 20;
			Name = "Pearl-encrusted Spear";
			Name2 = "Pearl-encrusted Spear";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10398;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 65;
			SetDamage( 35 , 53 , Resistances.Armor );
			StaminaBonus = 3;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Pitchfork)
*
***************************************************************/

namespace Server.Items
{
	public class Pitchfork : Item
	{
		public Pitchfork() : base()
		{
			Id = 1485;
			SellPrice = 1410;
			AvailableClasses = 0x7FFF;
			Model = 7464;
			ObjectClass = 2;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Pitchfork";
			Name2 = "Pitchfork";
			AvailableRaces = 0x1FF;
			BuyPrice = 7053;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 29 , 45 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Headhunting Spear)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntingSpear : Item
	{
		public HeadhuntingSpear() : base()
		{
			Id = 1522;
			Bonding = 2;
			SellPrice = 10224;
			AvailableClasses = 0x7FFF;
			Model = 22239;
			ObjectClass = 2;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Headhunting Spear";
			Name2 = "Headhunting Spear";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51121;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 85;
			SetDamage( 63 , 95 , Resistances.Armor );
			AgilityBonus = 11;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Poison-tipped Bone Spear)
*
***************************************************************/

namespace Server.Items
{
	public class PoisonTippedBoneSpear : Item
	{
		public PoisonTippedBoneSpear() : base()
		{
			Id = 1726;
			Bonding = 2;
			SellPrice = 12183;
			AvailableClasses = 0x7FFF;
			Model = 20749;
			ObjectClass = 2;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Poison-tipped Bone Spear";
			Name2 = "Poison-tipped Bone Spear";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60915;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 16401 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 87 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Impaling Harpoon)
*
***************************************************************/

namespace Server.Items
{
	public class ImpalingHarpoon : Item
	{
		public ImpalingHarpoon() : base()
		{
			Id = 5200;
			Bonding = 1;
			SellPrice = 2323;
			AvailableClasses = 0x7FFF;
			Model = 5949;
			ObjectClass = 2;
			SubClass = 6;
			Level = 22;
			ReqLevel = 20;
			Name = "Impaling Harpoon";
			Name2 = "Impaling Harpoon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11615;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 70;
			SetDamage( 27 , 42 , Resistances.Armor );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Armor Piercer)
*
***************************************************************/

namespace Server.Items
{
	public class ArmorPiercer : Item
	{
		public ArmorPiercer() : base()
		{
			Id = 6679;
			Bonding = 1;
			SellPrice = 4852;
			AvailableClasses = 0x7FFF;
			Model = 22241;
			ObjectClass = 2;
			SubClass = 6;
			Level = 29;
			ReqLevel = 24;
			Name = "Armor Piercer";
			Name2 = "Armor Piercer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24264;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 85;
			SetDamage( 41 , 62 , Resistances.Armor );
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ruthless Shiv)
*
***************************************************************/

namespace Server.Items
{
	public class RuthlessShiv : Item
	{
		public RuthlessShiv() : base()
		{
			Id = 7758;
			Bonding = 2;
			SellPrice = 15074;
			AvailableClasses = 0x7FFF;
			Model = 22238;
			ObjectClass = 2;
			SubClass = 6;
			Level = 39;
			ReqLevel = 34;
			Name = "Ruthless Shiv";
			Name2 = "Ruthless Shiv";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75370;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 75 , 113 , Resistances.Armor );
			StaminaBonus = 8;
			StrBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Blight)
*
***************************************************************/

namespace Server.Items
{
	public class Blight : Item
	{
		public Blight() : base()
		{
			Id = 7959;
			Bonding = 2;
			SellPrice = 33857;
			AvailableClasses = 0x7FFF;
			Model = 22234;
			ObjectClass = 2;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Blight";
			Name2 = "Blight";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 169289;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 9796 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 93 , 141 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Grimlok's Charge)
*
***************************************************************/

namespace Server.Items
{
	public class GrimloksCharge : Item
	{
		public GrimloksCharge() : base()
		{
			Id = 9416;
			Bonding = 1;
			SellPrice = 28218;
			AvailableClasses = 0x7FFF;
			Model = 22233;
			ObjectClass = 2;
			SubClass = 6;
			Level = 47;
			ReqLevel = 42;
			Name = "Grimlok's Charge";
			Name2 = "Grimlok's Charge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 141092;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 88 , 133 , Resistances.Armor );
			AgilityBonus = 15;
			StrBonus = 10;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Diabolic Skiver)
*
***************************************************************/

namespace Server.Items
{
	public class DiabolicSkiver : Item
	{
		public DiabolicSkiver() : base()
		{
			Id = 9475;
			Bonding = 1;
			SellPrice = 33346;
			AvailableClasses = 0x7FFF;
			Model = 22209;
			ObjectClass = 2;
			SubClass = 6;
			Level = 49;
			ReqLevel = 44;
			Name = "Diabolic Skiver";
			Name2 = "Diabolic Skiver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 166732;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 18206 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 99 , 149 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Eyegouger)
*
***************************************************************/

namespace Server.Items
{
	public class Eyegouger : Item
	{
		public Eyegouger() : base()
		{
			Id = 9480;
			Bonding = 2;
			SellPrice = 31725;
			AvailableClasses = 0x7FFF;
			Model = 22235;
			ObjectClass = 2;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Eyegouger";
			Name2 = "Eyegouger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 158625;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 100 , 151 , Resistances.Armor );
			AgilityBonus = 23;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Headspike)
*
***************************************************************/

namespace Server.Items
{
	public class Headspike : Item
	{
		public Headspike() : base()
		{
			Id = 10799;
			Bonding = 1;
			SellPrice = 39288;
			AvailableClasses = 0x7FFF;
			Model = 22242;
			ObjectClass = 2;
			SubClass = 6;
			Level = 51;
			ReqLevel = 46;
			Name = "Headspike";
			Name2 = "Headspike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 196442;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 106 , 159 , Resistances.Armor );
			StaminaBonus = 18;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Flame Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class FlameWrath : Item
	{
		public FlameWrath() : base()
		{
			Id = 11809;
			Bonding = 1;
			SellPrice = 51287;
			AvailableClasses = 0x7FFF;
			Model = 22031;
			ObjectClass = 2;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Flame Wrath";
			Name2 = "Flame Wrath";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 256435;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 16559 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 127 , 191 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(White Bone Spear)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteBoneSpear : Item
	{
		public WhiteBoneSpear() : base()
		{
			Id = 11864;
			Bonding = 1;
			SellPrice = 34108;
			AvailableClasses = 0x7FFF;
			Model = 25632;
			ObjectClass = 2;
			SubClass = 6;
			Level = 52;
			Name = "White Bone Spear";
			Name2 = "White Bone Spear";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 170542;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 85;
			SetDamage( 87 , 131 , Resistances.Armor );
			StaminaBonus = 21;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Smoldering Claw)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingClaw : Item
	{
		public SmolderingClaw() : base()
		{
			Id = 12243;
			Bonding = 1;
			SellPrice = 45980;
			AvailableClasses = 0x7FFF;
			Model = 5290;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 6;
			Level = 54;
			ReqLevel = 49;
			Name = "Smoldering Claw";
			Name2 = "Smoldering Claw";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 229901;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 15662 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 108 , 162 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blackhand Doomsaw)
*
***************************************************************/

namespace Server.Items
{
	public class BlackhandDoomsaw : Item
	{
		public BlackhandDoomsaw() : base()
		{
			Id = 12583;
			Bonding = 1;
			SellPrice = 74346;
			AvailableClasses = 0x7FFF;
			Model = 22792;
			ObjectClass = 2;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Blackhand Doomsaw";
			Name2 = "Blackhand Doomsaw";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 371731;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 16549 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 151 , 227 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gargoyle's Bite)
*
***************************************************************/

namespace Server.Items
{
	public class GargoylesBite : Item
	{
		public GargoylesBite() : base()
		{
			Id = 12989;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 2854;
			AvailableClasses = 0x7FFF;
			Model = 28758;
			ObjectClass = 2;
			SubClass = 6;
			Level = 22;
			ReqLevel = 20;
			Name = "Gargoyle's Bite";
			Name2 = "Gargoyle's Bite";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14271;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 80;
			SetDamage( 44 , 66 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Grim Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class GrimReaper : Item
	{
		public GrimReaper() : base()
		{
			Id = 13054;
			Bonding = 2;
			SellPrice = 15805;
			AvailableClasses = 0x7FFF;
			Model = 28764;
			ObjectClass = 2;
			SubClass = 6;
			Level = 40;
			ReqLevel = 35;
			Name = "Grim Reaper";
			Name2 = "Grim Reaper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79026;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 14126 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bonechewer)
*
***************************************************************/

namespace Server.Items
{
	public class Bonechewer : Item
	{
		public Bonechewer() : base()
		{
			Id = 13055;
			Bonding = 2;
			SellPrice = 29367;
			AvailableClasses = 0x7FFF;
			Model = 18388;
			ObjectClass = 2;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Bonechewer";
			Name2 = "Bonechewer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 146838;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 94 , 141 , Resistances.Armor );
			StrBonus = 23;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Frenzied Striker)
*
***************************************************************/

namespace Server.Items
{
	public class FrenziedStriker : Item
	{
		public FrenziedStriker() : base()
		{
			Id = 13056;
			Bonding = 2;
			SellPrice = 48330;
			AvailableClasses = 0x7FFF;
			Model = 12562;
			ObjectClass = 2;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Frenzied Striker";
			Name2 = "Frenzied Striker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 241653;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 108 , 162 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodpike)
*
***************************************************************/

namespace Server.Items
{
	public class Bloodpike : Item
	{
		public Bloodpike() : base()
		{
			Id = 13057;
			Bonding = 2;
			SellPrice = 5382;
			AvailableClasses = 0x7FFF;
			Model = 25630;
			ObjectClass = 2;
			SubClass = 6;
			Level = 28;
			ReqLevel = 23;
			Name = "Bloodpike";
			Name2 = "Bloodpike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26911;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 95;
			SetSpell( 18202 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 59 , 89 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Khoo's Point)
*
***************************************************************/

namespace Server.Items
{
	public class KhoosPoint : Item
	{
		public KhoosPoint() : base()
		{
			Id = 13058;
			Bonding = 2;
			SellPrice = 21833;
			AvailableClasses = 0x7FFF;
			Model = 28790;
			ObjectClass = 2;
			SubClass = 6;
			Level = 44;
			ReqLevel = 39;
			Name = "Khoo's Point";
			Name2 = "Khoo's Point";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 109167;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 77 , 117 , Resistances.Armor );
			StaminaBonus = 20;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stoneraven)
*
***************************************************************/

namespace Server.Items
{
	public class Stoneraven : Item
	{
		public Stoneraven() : base()
		{
			Id = 13059;
			Bonding = 2;
			SellPrice = 38719;
			AvailableClasses = 0x7FFF;
			Model = 25633;
			ObjectClass = 2;
			SubClass = 6;
			Level = 52;
			ReqLevel = 47;
			Name = "Stoneraven";
			Name2 = "Stoneraven";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 193598;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetDamage( 118 , 178 , Resistances.Armor );
			StrBonus = 13;
			AgilityBonus = 13;
			StaminaBonus = 15;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(The Needler)
*
***************************************************************/

namespace Server.Items
{
	public class TheNeedler : Item
	{
		public TheNeedler() : base()
		{
			Id = 13060;
			Bonding = 2;
			SellPrice = 60784;
			AvailableClasses = 0x7FFF;
			Model = 28672;
			ObjectClass = 2;
			SubClass = 6;
			Level = 60;
			ReqLevel = 55;
			Name = "The Needler";
			Name2 = "The Needler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 303923;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 16405 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 90 , 136 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Chillpike)
*
***************************************************************/

namespace Server.Items
{
	public class Chillpike : Item
	{
		public Chillpike() : base()
		{
			Id = 13148;
			Bonding = 1;
			SellPrice = 62629;
			AvailableClasses = 0x7FFF;
			Model = 25631;
			ObjectClass = 2;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Chillpike";
			Name2 = "Chillpike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 313145;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 100;
			SetSpell( 19260 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 117 , 176 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Short Spear)
*
***************************************************************/

namespace Server.Items
{
	public class ShortSpear : Item
	{
		public ShortSpear() : base()
		{
			Id = 15810;
			SellPrice = 2029;
			AvailableClasses = 0x7FFF;
			Model = 26500;
			ObjectClass = 2;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Short Spear";
			Name2 = "Short Spear";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10145;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 40 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Spear)
*
***************************************************************/

namespace Server.Items
{
	public class HeavySpear : Item
	{
		public HeavySpear() : base()
		{
			Id = 15811;
			SellPrice = 5426;
			AvailableClasses = 0x7FFF;
			Model = 5636;
			ObjectClass = 2;
			SubClass = 6;
			Level = 35;
			ReqLevel = 30;
			Name = "Heavy Spear";
			Name2 = "Heavy Spear";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27132;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 68 , 102 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shadowstrike)
*
***************************************************************/

namespace Server.Items
{
	public class Shadowstrike : Item
	{
		public Shadowstrike() : base()
		{
			Id = 17074;
			Bonding = 1;
			SellPrice = 98514;
			AvailableClasses = 0x7FFF;
			Model = 29176;
			ObjectClass = 2;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Shadowstrike";
			Name2 = "Shadowstrike";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 492571;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 120;
			Flags = 1088;
			SetSpell( 21170 , 2 , 0 , -1 , 0 , -1 );
			SetSpell( 21180 , 0 , 0 , 60000 , 0 , -1 );
			SetDamage( 147 , 221 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thunderstrike)
*
***************************************************************/

namespace Server.Items
{
	public class Thunderstrike : Item
	{
		public Thunderstrike() : base()
		{
			Id = 17223;
			Bonding = 1;
			SellPrice = 97074;
			AvailableClasses = 0x7FFF;
			Model = 29191;
			ObjectClass = 2;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Thunderstrike";
			Name2 = "Thunderstrike";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 485373;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 120;
			Flags = 1088;
			SetSpell( 21179 , 2 , 0 , -1 , 0 , -1 );
			SetSpell( 21181 , 0 , 0 , 60000 , 0 , -1 );
			SetDamage( 147 , 221 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Monstrous Glaive)
*
***************************************************************/

namespace Server.Items
{
	public class MonstrousGlaive : Item
	{
		public MonstrousGlaive() : base()
		{
			Id = 18502;
			Bonding = 1;
			SellPrice = 70127;
			AvailableClasses = 0x7FFF;
			Model = 30836;
			ObjectClass = 2;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Monstrous Glaive";
			Name2 = "Monstrous Glaive";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 350636;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 123 , 185 , Resistances.Armor );
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Peacemaker)
*
***************************************************************/

namespace Server.Items
{
	public class Peacemaker : Item
	{
		public Peacemaker() : base()
		{
			Id = 18725;
			Bonding = 1;
			SellPrice = 59927;
			AvailableClasses = 0x7FFF;
			Model = 31174;
			ObjectClass = 2;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Peacemaker";
			Name2 = "Peacemaker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 299636;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 2;
			Durability = 100;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15814 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 137 , 206 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Glaive)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsGlaive : Item
	{
		public GrandMarshalsGlaive() : base()
		{
			Id = 18869;
			Bonding = 1;
			SellPrice = 56993;
			AvailableClasses = 0x7FFF;
			Model = 31761;
			ObjectClass = 2;
			SubClass = 6;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Glaive";
			Name2 = "Grand Marshal's Glaive";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 284969;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
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
*				(High Warlord's Pig Sticker)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsPigSticker : Item
	{
		public HighWarlordsPigSticker() : base()
		{
			Id = 18871;
			Bonding = 1;
			SellPrice = 59017;
			AvailableClasses = 0x7FFF;
			Model = 31766;
			ObjectClass = 2;
			SubClass = 6;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Pig Sticker";
			Name2 = "High Warlord's Pig Sticker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 295085;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 120;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 235 , 353 , Resistances.Armor );
			StaminaBonus = 41;
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Ice Barbed Spear)
*
***************************************************************/

namespace Server.Items
{
	public class IceBarbedSpear : Item
	{
		public IceBarbedSpear() : base()
		{
			Id = 19106;
			Bonding = 1;
			SellPrice = 73353;
			AvailableClasses = 0x7FFF;
			Model = 31613;
			ObjectClass = 2;
			SubClass = 6;
			Level = 63;
			Name = "Ice Barbed Spear";
			Name2 = "Ice Barbed Spear";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 366765;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 155 , 233 , Resistances.Armor );
			AgilityBonus = 21;
			StrBonus = 13;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Blackfury)
*
***************************************************************/

namespace Server.Items
{
	public class Blackfury : Item
	{
		public Blackfury() : base()
		{
			Id = 19167;
			Bonding = 1;
			SellPrice = 116531;
			AvailableClasses = 0x7FFF;
			Model = 31720;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 6;
			Level = 66;
			ReqLevel = 60;
			Name = "Blackfury";
			Name2 = "Blackfury";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 582655;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 2;
			Durability = 120;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 105 , 158 , Resistances.Armor );
			StrBonus = 35;
			StaminaBonus = 15;
		}
	}
}


