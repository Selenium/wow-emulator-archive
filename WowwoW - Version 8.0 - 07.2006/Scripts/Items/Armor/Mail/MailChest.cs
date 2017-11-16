/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:24 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Scalemail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ScalemailVest : Item
	{
		public ScalemailVest() : base()
		{
			Id = 285;
			Resistance[0] = 165;
			SellPrice = 711;
			AvailableClasses = 0x7FFF;
			Model = 16101;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Scalemail Vest";
			Name2 = "Scalemail Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3555;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Chainmail Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ChainmailArmor : Item
	{
		public ChainmailArmor() : base()
		{
			Id = 847;
			Resistance[0] = 151;
			SellPrice = 349;
			AvailableClasses = 0x7FFF;
			Model = 1019;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Chainmail Armor";
			Name2 = "Chainmail Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1749;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Large Ogre Chain Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LargeOgreChainArmor : Item
	{
		public LargeOgreChainArmor() : base()
		{
			Id = 914;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 2669;
			AvailableClasses = 0x7FFF;
			Model = 2829;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Large Ogre Chain Armor";
			Name2 = "Large Ogre Chain Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13347;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 10;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Forest Chain)
*
***************************************************************/

namespace Server.Items
{
	public class ForestChain : Item
	{
		public ForestChain() : base()
		{
			Id = 1273;
			Resistance[0] = 183;
			Bonding = 1;
			SellPrice = 1656;
			AvailableClasses = 0x7FFF;
			Model = 12723;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Forest Chain";
			Name2 = "Forest Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8282;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StaminaBonus = 2;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Deputy Chain Coat)
*
***************************************************************/

namespace Server.Items
{
	public class DeputyChainCoat : Item
	{
		public DeputyChainCoat() : base()
		{
			Id = 1275;
			Resistance[0] = 183;
			Bonding = 1;
			SellPrice = 1668;
			AvailableClasses = 0x7FFF;
			Model = 1019;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Deputy Chain Coat";
			Name2 = "Deputy Chain Coat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8342;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StaminaBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Avenger's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class AvengersArmor : Item
	{
		public AvengersArmor() : base()
		{
			Id = 1488;
			Resistance[0] = 221;
			Bonding = 2;
			SellPrice = 3379;
			AvailableClasses = 0x7FFF;
			Model = 12960;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Avenger's Armor";
			Name2 = "Avenger's Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16899;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StrBonus = 15;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Drake-scale Vest)
*
***************************************************************/

namespace Server.Items
{
	public class DrakeScaleVest : Item
	{
		public DrakeScaleVest() : base()
		{
			Id = 1677;
			Resistance[0] = 254;
			Bonding = 2;
			SellPrice = 10093;
			AvailableClasses = 0x7FFF;
			Model = 8678;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Drake-scale Vest";
			Name2 = "Drake-scale Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50466;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 15;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Polished Jazeraint Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedJazeraintArmor : Item
	{
		public PolishedJazeraintArmor() : base()
		{
			Id = 1715;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 10301;
			AvailableClasses = 0x7FFF;
			Model = 8683;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Polished Jazeraint Armor";
			Name2 = "Polished Jazeraint Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51509;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			IqBonus = 17;
			StaminaBonus = 10;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Double Link Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleLinkTunic : Item
	{
		public DoubleLinkTunic() : base()
		{
			Id = 1717;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 3108;
			AvailableClasses = 0x7FFF;
			Model = 12960;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Double Link Tunic";
			Name2 = "Double Link Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15540;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 18369 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Worn Mail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WornMailVest : Item
	{
		public WornMailVest() : base()
		{
			Id = 1737;
			Resistance[0] = 123;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Worn Mail Vest";
			Name2 = "Worn Mail Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 698;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailVest : Item
	{
		public LacedMailVest() : base()
		{
			Id = 1745;
			Resistance[0] = 136;
			SellPrice = 198;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "Laced Mail Vest";
			Name2 = "Laced Mail Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 992;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainVest : Item
	{
		public LinkedChainVest() : base()
		{
			Id = 1753;
			Resistance[0] = 156;
			SellPrice = 439;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Linked Chain Vest";
			Name2 = "Linked Chain Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 2196;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainVest : Item
	{
		public ReinforcedChainVest() : base()
		{
			Id = 1761;
			Resistance[0] = 173;
			SellPrice = 892;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Reinforced Chain Vest";
			Name2 = "Reinforced Chain Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 4463;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Icemail Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class IcemailJerkin : Item
	{
		public IcemailJerkin() : base()
		{
			Id = 1981;
			Resistance[0] = 294;
			Bonding = 2;
			SellPrice = 14113;
			AvailableClasses = 0x7FFF;
			Model = 8668;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Icemail Jerkin";
			Name2 = "Icemail Jerkin";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 70566;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			IqBonus = 24;
			StaminaBonus = 15;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Dusty Chain Armor)
*
***************************************************************/

namespace Server.Items
{
	public class DustyChainArmor : Item
	{
		public DustyChainArmor() : base()
		{
			Id = 2016;
			Resistance[0] = 208;
			Bonding = 2;
			SellPrice = 1769;
			AvailableClasses = 0x7FFF;
			Model = 1727;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Dusty Chain Armor";
			Name2 = "Dusty Chain Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8847;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			StrBonus = 8;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Frostmane Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneChainVest : Item
	{
		public FrostmaneChainVest() : base()
		{
			Id = 2109;
			Resistance[0] = 67;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Frostmane Chain Vest";
			Name2 = "Frostmane Chain Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Polished Scale Vest)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedScaleVest : Item
	{
		public PolishedScaleVest() : base()
		{
			Id = 2153;
			Resistance[0] = 179;
			SellPrice = 1185;
			AvailableClasses = 0x7FFF;
			Model = 8683;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Polished Scale Vest";
			Name2 = "Polished Scale Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5927;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 95;
		}
	}
}


/**************************************************************
*
*				(Tarnished Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedChainVest : Item
	{
		public TarnishedChainVest() : base()
		{
			Id = 2379;
			Resistance[0] = 67;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2215;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Tarnished Chain Vest";
			Name2 = "Tarnished Chain Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Rusted Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RustedChainVest : Item
	{
		public RustedChainVest() : base()
		{
			Id = 2386;
			Resistance[0] = 67;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2222;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Rusted Chain Vest";
			Name2 = "Rusted Chain Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 77;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Light Mail Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LightMailArmor : Item
	{
		public LightMailArmor() : base()
		{
			Id = 2392;
			Resistance[0] = 102;
			SellPrice = 82;
			AvailableClasses = 0x7FFF;
			Model = 2265;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Mail Armor";
			Name2 = "Light Mail Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 413;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Light Chain Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LightChainArmor : Item
	{
		public LightChainArmor() : base()
		{
			Id = 2398;
			Resistance[0] = 102;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 2269;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Chain Armor";
			Name2 = "Light Chain Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 434;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainVest : Item
	{
		public AugmentedChainVest() : base()
		{
			Id = 2417;
			Resistance[0] = 208;
			SellPrice = 3134;
			AvailableClasses = 0x7FFF;
			Model = 8634;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Vest";
			Name2 = "Augmented Chain Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15673;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Brigandine Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineVest : Item
	{
		public BrigandineVest() : base()
		{
			Id = 2423;
			Resistance[0] = 259;
			SellPrice = 8554;
			AvailableClasses = 0x7FFF;
			Model = 8642;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Vest";
			Name2 = "Brigandine Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 42770;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainVest : Item
	{
		public LooseChainVest() : base()
		{
			Id = 2648;
			Resistance[0] = 97;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 2215;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Loose Chain Vest";
			Name2 = "Loose Chain Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 293;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainVest : Item
	{
		public FlimsyChainVest() : base()
		{
			Id = 2656;
			Resistance[0] = 63;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 2215;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Flimsy Chain Vest";
			Name2 = "Flimsy Chain Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Runed Copper Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class RunedCopperBreastplate : Item
	{
		public RunedCopperBreastplate() : base()
		{
			Id = 2864;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 630;
			AvailableClasses = 0x7FFF;
			Model = 25848;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Runed Copper Breastplate";
			Name2 = "Runed Copper Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3150;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 80;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rough Bronze Cuirass)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBronzeCuirass : Item
	{
		public RoughBronzeCuirass() : base()
		{
			Id = 2866;
			Resistance[0] = 168;
			SellPrice = 752;
			AvailableClasses = 0x7FFF;
			Model = 23530;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Rough Bronze Cuirass";
			Name2 = "Rough Bronze Cuirass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3764;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
		}
	}
}


/**************************************************************
*
*				(Silvered Bronze Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SilveredBronzeBreastplate : Item
	{
		public SilveredBronzeBreastplate() : base()
		{
			Id = 2869;
			Resistance[0] = 186;
			Bonding = 2;
			SellPrice = 1831;
			AvailableClasses = 0x7FFF;
			Model = 9403;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Silvered Bronze Breastplate";
			Name2 = "Silvered Bronze Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9155;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 95;
			StrBonus = 5;
			StaminaBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Shining Silver Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ShiningSilverBreastplate : Item
	{
		public ShiningSilverBreastplate() : base()
		{
			Id = 2870;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 2935;
			AvailableClasses = 0x7FFF;
			Model = 23540;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Shining Silver Breastplate";
			Name2 = "Shining Silver Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14677;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StrBonus = 14;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Mountaineer Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class MountaineerChestpiece : Item
	{
		public MountaineerChestpiece() : base()
		{
			Id = 2898;
			Resistance[0] = 81;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 2967;
			ObjectClass = 4;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Mountaineer Chestpiece";
			Name2 = "Mountaineer Chestpiece";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 162;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Warrior's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsTunic : Item
	{
		public WarriorsTunic() : base()
		{
			Id = 2965;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 189;
			AvailableClasses = 0x7FFF;
			Model = 22677;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Warrior's Tunic";
			Name2 = "Warrior's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 948;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Veteran Armor)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranArmor : Item
	{
		public VeteranArmor() : base()
		{
			Id = 2977;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 476;
			AvailableClasses = 0x7FFF;
			Model = 22689;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "Veteran Armor";
			Name2 = "Veteran Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2382;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Burnished Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedTunic : Item
	{
		public BurnishedTunic() : base()
		{
			Id = 2989;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 1001;
			AvailableClasses = 0x7FFF;
			Model = 25769;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Burnished Tunic";
			Name2 = "Burnished Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5009;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleBreastplate : Item
	{
		public LambentScaleBreastplate() : base()
		{
			Id = 3049;
			Resistance[0] = 189;
			Bonding = 2;
			SellPrice = 2119;
			AvailableClasses = 0x7FFF;
			Model = 25780;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Lambent Scale Breastplate";
			Name2 = "Lambent Scale Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10595;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 95;
			StaminaBonus = 8;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Humbert's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class HumbertsChestpiece : Item
	{
		public HumbertsChestpiece() : base()
		{
			Id = 3053;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 2140;
			AvailableClasses = 0x7FFF;
			Model = 3293;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Humbert's Chestpiece";
			Name2 = "Humbert's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10703;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Siege Brigade Vest)
*
***************************************************************/

namespace Server.Items
{
	public class SiegeBrigadeVest : Item
	{
		public SiegeBrigadeVest() : base()
		{
			Id = 3151;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 3293;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Siege Brigade Vest";
			Name2 = "Siege Brigade Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 437;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Ironheart Chain)
*
***************************************************************/

namespace Server.Items
{
	public class IronheartChain : Item
	{
		public IronheartChain() : base()
		{
			Id = 3166;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 407;
			AvailableClasses = 0x7FFF;
			Model = 12965;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			Name = "Ironheart Chain";
			Name2 = "Ironheart Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2039;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Rugged Mail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedMailVest : Item
	{
		public RuggedMailVest() : base()
		{
			Id = 3273;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2967;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Rugged Mail Vest";
			Name2 = "Rugged Mail Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 77;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainTunic : Item
	{
		public BattleChainTunic() : base()
		{
			Id = 3283;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 295;
			AvailableClasses = 0x7FFF;
			Model = 26933;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Battle Chain Tunic";
			Name2 = "Battle Chain Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1476;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 2;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Brackwater Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterVest : Item
	{
		public BrackwaterVest() : base()
		{
			Id = 3306;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 653;
			AvailableClasses = 0x7FFF;
			Model = 26949;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Brackwater Vest";
			Name2 = "Brackwater Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3269;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 80;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dargol's Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class DargolsHauberk : Item
	{
		public DargolsHauberk() : base()
		{
			Id = 3330;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 281;
			AvailableClasses = 0x7FFF;
			Model = 12971;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Dargol's Hauberk";
			Name2 = "Dargol's Hauberk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1405;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Martyr's Chain)
*
***************************************************************/

namespace Server.Items
{
	public class MartyrsChain : Item
	{
		public MartyrsChain() : base()
		{
			Id = 3416;
			Resistance[0] = 204;
			Bonding = 2;
			SellPrice = 2213;
			AvailableClasses = 0x7FFF;
			Model = 12971;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Martyr's Chain";
			Name2 = "Martyr's Chain";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11069;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 110;
			IqBonus = 5;
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Copper Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CopperChainVest : Item
	{
		public CopperChainVest() : base()
		{
			Id = 3471;
			Resistance[0] = 108;
			Bonding = 2;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 13090;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Copper Chain Vest";
			Name2 = "Copper Chain Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 712;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Orcish War Chain)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishWarChain : Item
	{
		public OrcishWarChain() : base()
		{
			Id = 3733;
			Resistance[0] = 177;
			Bonding = 1;
			SellPrice = 1269;
			AvailableClasses = 0x7FFF;
			Model = 4085;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			Name = "Orcish War Chain";
			Name2 = "Orcish War Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6347;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Double Mail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailVest : Item
	{
		public DoubleMailVest() : base()
		{
			Id = 3815;
			Resistance[0] = 186;
			SellPrice = 1475;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Double Mail Vest";
			Name2 = "Double Mail Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 7377;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Green Iron Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronHauberk : Item
	{
		public GreenIronHauberk() : base()
		{
			Id = 3844;
			Resistance[0] = 358;
			Bonding = 2;
			SellPrice = 5658;
			AvailableClasses = 0x7FFF;
			Model = 13088;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Green Iron Hauberk";
			Name2 = "Green Iron Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28293;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StaminaBonus = 11;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Cuirass)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleCuirass : Item
	{
		public GoldenScaleCuirass() : base()
		{
			Id = 3845;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 6558;
			AvailableClasses = 0x7FFF;
			Model = 9425;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Golden Scale Cuirass";
			Name2 = "Golden Scale Cuirass";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32794;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 14;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleArmor : Item
	{
		public LaminatedScaleArmor() : base()
		{
			Id = 3999;
			Resistance[0] = 264;
			SellPrice = 7109;
			AvailableClasses = 0x7FFF;
			Model = 8672;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Laminated Scale Armor";
			Name2 = "Laminated Scale Armor";
			AvailableRaces = 0x1FF;
			BuyPrice = 35547;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Armor)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainArmor : Item
	{
		public OverlinkedChainArmor() : base()
		{
			Id = 4007;
			Resistance[0] = 224;
			SellPrice = 3696;
			AvailableClasses = 0x7FFF;
			Model = 11565;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Overlinked Chain Armor";
			Name2 = "Overlinked Chain Armor";
			AvailableRaces = 0x1FF;
			BuyPrice = 18480;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailBreastplate : Item
	{
		public GlimmeringMailBreastplate() : base()
		{
			Id = 4071;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 2939;
			AvailableClasses = 0x7FFF;
			Model = 25801;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Glimmering Mail Breastplate";
			Name2 = "Glimmering Mail Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14695;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 11;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Armor)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatArmor : Item
	{
		public MailCombatArmor() : base()
		{
			Id = 4074;
			Resistance[0] = 216;
			Bonding = 2;
			SellPrice = 4785;
			AvailableClasses = 0x7FFF;
			Model = 25809;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Mail Combat Armor";
			Name2 = "Mail Combat Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23928;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 13;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Blackforge Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeBreastplate : Item
	{
		public BlackforgeBreastplate() : base()
		{
			Id = 4082;
			Resistance[0] = 258;
			Bonding = 2;
			SellPrice = 11699;
			AvailableClasses = 0x7FFF;
			Model = 26074;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Blackforge Breastplate";
			Name2 = "Blackforge Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58495;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			AgilityBonus = 14;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Blackwater Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BlackwaterTunic : Item
	{
		public BlackwaterTunic() : base()
		{
			Id = 4138;
			Resistance[0] = 248;
			Bonding = 1;
			SellPrice = 10140;
			AvailableClasses = 0x7FFF;
			Model = 8638;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			Name = "Blackwater Tunic";
			Name2 = "Blackwater Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50704;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 7;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Husk of Naraxis)
*
***************************************************************/

namespace Server.Items
{
	public class HuskOfNaraxis : Item
	{
		public HuskOfNaraxis() : base()
		{
			Id = 4448;
			Resistance[0] = 189;
			Bonding = 2;
			SellPrice = 1991;
			AvailableClasses = 0x7FFF;
			Model = 4723;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Husk of Naraxis";
			Name2 = "Husk of Naraxis";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9959;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 95;
			StrBonus = 5;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Blood-tinged Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BloodTingedArmor : Item
	{
		public BloodTingedArmor() : base()
		{
			Id = 4508;
			Resistance[0] = 238;
			Bonding = 1;
			SellPrice = 7793;
			AvailableClasses = 0x7FFF;
			Model = 8639;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			Name = "Blood-tinged Armor";
			Name2 = "Blood-tinged Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38965;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 5;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Jagged Chain Vest)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedChainVest : Item
	{
		public JaggedChainVest() : base()
		{
			Id = 4922;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2967;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Jagged Chain Vest";
			Name2 = "Jagged Chain Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 76;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Onyx Shredder Plate)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxShredderPlate : Item
	{
		public OnyxShredderPlate() : base()
		{
			Id = 5755;
			Resistance[0] = 213;
			Bonding = 2;
			SellPrice = 4127;
			AvailableClasses = 0x7FFF;
			Model = 8719;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Onyx Shredder Plate";
			Name2 = "Onyx Shredder Plate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20638;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 8;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Slarkskin)
*
***************************************************************/

namespace Server.Items
{
	public class Slarkskin : Item
	{
		public Slarkskin() : base()
		{
			Id = 6180;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 423;
			AvailableClasses = 0x7FFF;
			Model = 11563;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Slarkskin";
			Name2 = "Slarkskin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2119;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 2;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wax-polished Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WaxPolishedArmor : Item
	{
		public WaxPolishedArmor() : base()
		{
			Id = 6195;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 416;
			AvailableClasses = 0x7FFF;
			Model = 12944;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Wax-polished Armor";
			Name2 = "Wax-polished Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2080;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 2;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Infantry Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryTunic : Item
	{
		public InfantryTunic() : base()
		{
			Id = 6336;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 305;
			AvailableClasses = 0x7FFF;
			Model = 3057;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Infantry Tunic";
			Name2 = "Infantry Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 497;
			BuyPrice = 1526;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierArmor : Item
	{
		public ChiefBrigadierArmor() : base()
		{
			Id = 6411;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 7268;
			AvailableClasses = 0x7FFF;
			Model = 25882;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Chief Brigadier Armor";
			Name2 = "Chief Brigadier Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36343;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			IqBonus = 4;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Violet Scale Armor)
*
***************************************************************/

namespace Server.Items
{
	public class VioletScaleArmor : Item
	{
		public VioletScaleArmor() : base()
		{
			Id = 6502;
			Resistance[0] = 174;
			Bonding = 1;
			SellPrice = 1140;
			AvailableClasses = 0x7FFF;
			Model = 12282;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			Name = "Violet Scale Armor";
			Name2 = "Violet Scale Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5701;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			StaminaBonus = 6;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Soldier's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersArmor : Item
	{
		public SoldiersArmor() : base()
		{
			Id = 6545;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 675;
			AvailableClasses = 0x7FFF;
			Model = 25755;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Soldier's Armor";
			Name2 = "Soldier's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 498;
			BuyPrice = 3379;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Defender Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderTunic : Item
	{
		public DefenderTunic() : base()
		{
			Id = 6580;
			Resistance[0] = 177;
			Bonding = 2;
			SellPrice = 1312;
			AvailableClasses = 0x7FFF;
			Model = 25763;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Defender Tunic";
			Name2 = "Defender Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 500;
			BuyPrice = 6562;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
		}
	}
}


/**************************************************************
*
*				(Battleforge Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeArmor : Item
	{
		public BattleforgeArmor() : base()
		{
			Id = 6592;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 2447;
			AvailableClasses = 0x7FFF;
			Model = 25798;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Battleforge Armor";
			Name2 = "Battleforge Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 502;
			BuyPrice = 12239;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Mutant Scale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MutantScaleBreastplate : Item
	{
		public MutantScaleBreastplate() : base()
		{
			Id = 6627;
			Resistance[0] = 211;
			Bonding = 1;
			SellPrice = 2620;
			AvailableClasses = 0x7FFF;
			Model = 12595;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Mutant Scale Breastplate";
			Name2 = "Mutant Scale Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13104;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StrBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Phantom Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PhantomArmor : Item
	{
		public PhantomArmor() : base()
		{
			Id = 6642;
			Resistance[0] = 201;
			Bonding = 1;
			SellPrice = 1880;
			AvailableClasses = 0x7FFF;
			Model = 12632;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Phantom Armor";
			Name2 = "Phantom Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9402;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			IqBonus = 5;
			StaminaBonus = 11;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Chestplate of Kor)
*
***************************************************************/

namespace Server.Items
{
	public class ChestplateOfKor : Item
	{
		public ChestplateOfKor() : base()
		{
			Id = 6721;
			Resistance[0] = 180;
			Bonding = 1;
			SellPrice = 1418;
			AvailableClasses = 0x7FFF;
			Model = 12934;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			Name = "Chestplate of Kor";
			Name2 = "Chestplate of Kor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7094;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 4;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ironforge Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class IronforgeBreastplate : Item
	{
		public IronforgeBreastplate() : base()
		{
			Id = 6731;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 871;
			AvailableClasses = 0x7FFF;
			Model = 12945;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Ironforge Breastplate";
			Name2 = "Ironforge Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4358;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 80;
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gelkis Marauder Chain)
*
***************************************************************/

namespace Server.Items
{
	public class GelkisMarauderChain : Item
	{
		public GelkisMarauderChain() : base()
		{
			Id = 6773;
			Resistance[0] = 238;
			Bonding = 1;
			SellPrice = 7366;
			AvailableClasses = 0x7FFF;
			Model = 13011;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			Name = "Gelkis Marauder Chain";
			Name2 = "Gelkis Marauder Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36831;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 14;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Tortoise Armor)
*
***************************************************************/

namespace Server.Items
{
	public class TortoiseArmor : Item
	{
		public TortoiseArmor() : base()
		{
			Id = 6907;
			Resistance[0] = 311;
			Bonding = 1;
			SellPrice = 1872;
			AvailableClasses = 0x7FFF;
			Model = 16903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Tortoise Armor";
			Name2 = "Tortoise Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9364;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 105;
		}
	}
}


/**************************************************************
*
*				(Fire Hardened Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class FireHardenedHauberk : Item
	{
		public FireHardenedHauberk() : base()
		{
			Id = 6972;
			Resistance[0] = 218;
			Bonding = 1;
			SellPrice = 3242;
			AvailableClasses = 0x01;
			Model = 22480;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			Name = "Fire Hardened Hauberk";
			Name2 = "Fire Hardened Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16213;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 9174 , 0 , 0 , 3600000 , 28 , 300000 );
			StaminaBonus = 14;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Brutal Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalHauberk : Item
	{
		public BrutalHauberk() : base()
		{
			Id = 7133;
			Resistance[0] = 218;
			Bonding = 1;
			SellPrice = 3098;
			AvailableClasses = 0x01;
			Model = 13011;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			Name = "Brutal Hauberk";
			Name2 = "Brutal Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15493;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 9174 , 0 , 0 , 3600000 , 28 , 300000 );
			StaminaBonus = 14;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Explorer's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ExplorersVest : Item
	{
		public ExplorersVest() : base()
		{
			Id = 7229;
			Resistance[0] = 129;
			Bonding = 1;
			SellPrice = 285;
			AvailableClasses = 0x7FFF;
			Model = 11563;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			Name = "Explorer's Vest";
			Name2 = "Explorer's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1427;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 2;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Wildwood Chain)
*
***************************************************************/

namespace Server.Items
{
	public class WildwoodChain : Item
	{
		public WildwoodChain() : base()
		{
			Id = 7336;
			Resistance[0] = 180;
			Bonding = 1;
			SellPrice = 1509;
			AvailableClasses = 0x7FFF;
			Model = 14069;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			Name = "Wildwood Chain";
			Name2 = "Wildwood Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7548;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 8;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Phalanx Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxBreastplate : Item
	{
		public PhalanxBreastplate() : base()
		{
			Id = 7418;
			Resistance[0] = 213;
			Bonding = 2;
			SellPrice = 4256;
			AvailableClasses = 0x7FFF;
			Model = 26034;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Phalanx Breastplate";
			Name2 = "Phalanx Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 504;
			BuyPrice = 21280;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Knight's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsBreastplate : Item
	{
		public KnightsBreastplate() : base()
		{
			Id = 7454;
			Resistance[0] = 227;
			Bonding = 2;
			SellPrice = 5915;
			AvailableClasses = 0x7FFF;
			Model = 25862;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Knight's Breastplate";
			Name2 = "Knight's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 505;
			BuyPrice = 29575;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Captain's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsBreastplate : Item
	{
		public CaptainsBreastplate() : base()
		{
			Id = 7486;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 9325;
			AvailableClasses = 0x7FFF;
			Model = 22559;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Captain's Breastplate";
			Name2 = "Captain's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 507;
			BuyPrice = 46628;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Champion's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsArmor : Item
	{
		public ChampionsArmor() : base()
		{
			Id = 7538;
			Resistance[0] = 263;
			Bonding = 2;
			SellPrice = 12322;
			AvailableClasses = 0x7FFF;
			Model = 26087;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Champion's Armor";
			Name2 = "Champion's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 508;
			BuyPrice = 61612;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Ironspine's Ribcage)
*
***************************************************************/

namespace Server.Items
{
	public class IronspinesRibcage : Item
	{
		public IronspinesRibcage() : base()
		{
			Id = 7688;
			Resistance[0] = 235;
			Bonding = 1;
			SellPrice = 5320;
			AvailableClasses = 0x7FFF;
			Model = 15731;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Ironspine's Ribcage";
			Name2 = "Ironspine's Ribcage";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26602;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StaminaBonus = 17;
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Archon Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class ArchonChestpiece : Item
	{
		public ArchonChestpiece() : base()
		{
			Id = 7759;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 6723;
			AvailableClasses = 0x7FFF;
			Model = 15897;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Archon Chestpiece";
			Name2 = "Archon Chestpiece";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 33619;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StrBonus = 12;
			IqBonus = 8;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Barbaric Iron Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricIronBreastplate : Item
	{
		public BarbaricIronBreastplate() : base()
		{
			Id = 7914;
			Resistance[0] = 204;
			SellPrice = 3330;
			AvailableClasses = 0x7FFF;
			Model = 16080;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Barbaric Iron Breastplate";
			Name2 = "Barbaric Iron Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16654;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Steel Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SteelBreastplate : Item
	{
		public SteelBreastplate() : base()
		{
			Id = 7963;
			Resistance[0] = 381;
			Bonding = 2;
			SellPrice = 6488;
			AvailableClasses = 0x7FFF;
			Model = 16184;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Steel Breastplate";
			Name2 = "Steel Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32440;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsBreastplate : Item
	{
		public MyrmidonsBreastplate() : base()
		{
			Id = 8126;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 15656;
			AvailableClasses = 0x7FFF;
			Model = 26105;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Myrmidon's Breastplate";
			Name2 = "Myrmidon's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78284;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 19;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Turtle Scale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class TurtleScaleBreastplate : Item
	{
		public TurtleScaleBreastplate() : base()
		{
			Id = 8189;
			Resistance[0] = 238;
			Bonding = 2;
			SellPrice = 7567;
			AvailableClasses = 0x7FFF;
			Model = 11598;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Turtle Scale Breastplate";
			Name2 = "Turtle Scale Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37838;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 9;
			IqBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidBreastplate : Item
	{
		public ToughScorpidBreastplate() : base()
		{
			Id = 8203;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 8628;
			AvailableClasses = 0x7FFF;
			Model = 16513;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Tough Scorpid Breastplate";
			Name2 = "Tough Scorpid Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43140;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			AgilityBonus = 15;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Armor)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdArmor : Item
	{
		public EbonholdArmor() : base()
		{
			Id = 8265;
			Resistance[0] = 303;
			Bonding = 2;
			SellPrice = 19914;
			AvailableClasses = 0x7FFF;
			Model = 26204;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Ebonhold Armor";
			Name2 = "Ebonhold Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 99571;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 22;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hero's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class HerosBreastplate : Item
	{
		public HerosBreastplate() : base()
		{
			Id = 8303;
			Resistance[0] = 332;
			Bonding = 2;
			SellPrice = 26989;
			AvailableClasses = 0x7FFF;
			Model = 26314;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Hero's Breastplate";
			Name2 = "Hero's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 134948;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 7;
			IqBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Dragonscale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class DragonscaleBreastplate : Item
	{
		public DragonscaleBreastplate() : base()
		{
			Id = 8367;
			Resistance[0] = 306;
			Bonding = 2;
			SellPrice = 18455;
			AvailableClasses = 0x7FFF;
			Model = 16729;
			Resistance[2] = 13;
			Resistance[4] = 13;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Dragonscale Breastplate";
			Name2 = "Dragonscale Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 92276;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 10618 , 0 , 0 , 3600000 , 0 , 600000 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gahz'rilla Scale Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GahzrillaScaleArmor : Item
	{
		public GahzrillaScaleArmor() : base()
		{
			Id = 9469;
			Resistance[0] = 290;
			Bonding = 1;
			SellPrice = 14634;
			AvailableClasses = 0x7FFF;
			Model = 18382;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Gahz'rilla Scale Armor";
			Name2 = "Gahz'rilla Scale Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 73171;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StaminaBonus = 10;
			IqBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Honorguard Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class HonorguardChestpiece : Item
	{
		public HonorguardChestpiece() : base()
		{
			Id = 9650;
			Resistance[0] = 298;
			Bonding = 1;
			SellPrice = 18016;
			AvailableClasses = 0x7FFF;
			Model = 28279;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			Name = "Honorguard Chestpiece";
			Name2 = "Honorguard Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 90081;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 22;
			StaminaBonus = 3;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dawnrider's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class DawnridersChestpiece : Item
	{
		public DawnridersChestpiece() : base()
		{
			Id = 9663;
			Resistance[0] = 248;
			Bonding = 1;
			SellPrice = 9969;
			AvailableClasses = 0x7FFF;
			Model = 28315;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			Name = "Dawnrider's Chestpiece";
			Name2 = "Dawnrider's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49848;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			AgilityBonus = 16;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Cadet Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CadetVest : Item
	{
		public CadetVest() : base()
		{
			Id = 9765;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 406;
			AvailableClasses = 0x7FFF;
			Model = 22688;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Cadet Vest";
			Name2 = "Cadet Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 497;
			BuyPrice = 2034;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Raider's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersChestpiece : Item
	{
		public RaidersChestpiece() : base()
		{
			Id = 9783;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 811;
			AvailableClasses = 0x7FFF;
			Model = 13011;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Raider's Chestpiece";
			Name2 = "Raider's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 499;
			BuyPrice = 4059;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Fortified Chain)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedChain : Item
	{
		public FortifiedChain() : base()
		{
			Id = 9818;
			Resistance[0] = 183;
			Bonding = 2;
			SellPrice = 1682;
			AvailableClasses = 0x7FFF;
			Model = 1019;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Fortified Chain";
			Name2 = "Fortified Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 501;
			BuyPrice = 8410;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
		}
	}
}


/**************************************************************
*
*				(Banded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BandedArmor : Item
	{
		public BandedArmor() : base()
		{
			Id = 9836;
			Resistance[0] = 207;
			Bonding = 2;
			SellPrice = 3677;
			AvailableClasses = 0x7FFF;
			Model = 27769;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Banded Armor";
			Name2 = "Banded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 503;
			BuyPrice = 18387;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Renegade Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeChestguard : Item
	{
		public RenegadeChestguard() : base()
		{
			Id = 9866;
			Resistance[0] = 223;
			Bonding = 2;
			SellPrice = 5605;
			AvailableClasses = 0x7FFF;
			Model = 25787;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Renegade Chestguard";
			Name2 = "Renegade Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 505;
			BuyPrice = 28025;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintChestguard : Item
	{
		public JazeraintChestguard() : base()
		{
			Id = 9897;
			Resistance[0] = 238;
			Bonding = 2;
			SellPrice = 7368;
			AvailableClasses = 0x7FFF;
			Model = 27784;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Jazeraint Chestguard";
			Name2 = "Jazeraint Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 506;
			BuyPrice = 36842;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Brigade Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeBreastplate : Item
	{
		public BrigadeBreastplate() : base()
		{
			Id = 9928;
			Resistance[0] = 248;
			Bonding = 2;
			SellPrice = 9930;
			AvailableClasses = 0x7FFF;
			Model = 25932;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Brigade Breastplate";
			Name2 = "Brigade Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 507;
			BuyPrice = 49654;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersChestpiece : Item
	{
		public WarmongersChestpiece() : base()
		{
			Id = 9957;
			Resistance[0] = 273;
			Bonding = 2;
			SellPrice = 13753;
			AvailableClasses = 0x7FFF;
			Model = 26183;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Warmonger's Chestpiece";
			Name2 = "Warmonger's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 509;
			BuyPrice = 68766;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Lord's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LordsBreastplate : Item
	{
		public LordsBreastplate() : base()
		{
			Id = 10077;
			Resistance[0] = 288;
			Bonding = 2;
			SellPrice = 16968;
			AvailableClasses = 0x7FFF;
			Model = 26327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Lord's Breastplate";
			Name2 = "Lord's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 510;
			BuyPrice = 84841;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Ornate Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBreastplate : Item
	{
		public OrnateBreastplate() : base()
		{
			Id = 10118;
			Resistance[0] = 313;
			Bonding = 2;
			SellPrice = 23381;
			AvailableClasses = 0x7FFF;
			Model = 26291;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Ornate Breastplate";
			Name2 = "Ornate Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 512;
			BuyPrice = 116909;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Mercurial Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialBreastplate : Item
	{
		public MercurialBreastplate() : base()
		{
			Id = 10157;
			Resistance[0] = 342;
			Bonding = 2;
			SellPrice = 31216;
			AvailableClasses = 0x7FFF;
			Model = 26123;
			ObjectClass = 4;
			SubClass = 3;
			Level = 64;
			ReqLevel = 59;
			Name = "Mercurial Breastplate";
			Name2 = "Mercurial Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 514;
			BuyPrice = 156081;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Crusader's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersArmor : Item
	{
		public CrusadersArmor() : base()
		{
			Id = 10193;
			Resistance[0] = 298;
			Bonding = 2;
			SellPrice = 19775;
			AvailableClasses = 0x7FFF;
			Model = 26156;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Crusader's Armor";
			Name2 = "Crusader's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 511;
			BuyPrice = 98879;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Engraved Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedBreastplate : Item
	{
		public EngravedBreastplate() : base()
		{
			Id = 10230;
			Resistance[0] = 322;
			Bonding = 2;
			SellPrice = 25686;
			AvailableClasses = 0x7FFF;
			Model = 26267;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Engraved Breastplate";
			Name2 = "Engraved Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 512;
			BuyPrice = 128433;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Masterwork Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkBreastplate : Item
	{
		public MasterworkBreastplate() : base()
		{
			Id = 10266;
			Resistance[0] = 347;
			Bonding = 2;
			SellPrice = 32310;
			AvailableClasses = 0x7FFF;
			Model = 26241;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Masterwork Breastplate";
			Name2 = "Masterwork Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 514;
			BuyPrice = 161552;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Scarlet Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletChestpiece : Item
	{
		public ScarletChestpiece() : base()
		{
			Id = 10328;
			Resistance[0] = 250;
			Bonding = 2;
			SellPrice = 6992;
			AvailableClasses = 0x7FFF;
			Model = 19049;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Scarlet Chestpiece";
			Name2 = "Scarlet Chestpiece";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34964;
			Sets = 163;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			StaminaBonus = 19;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rough Copper Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RoughCopperVest : Item
	{
		public RoughCopperVest() : base()
		{
			Id = 10421;
			Resistance[0] = 81;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Rough Copper Vest";
			Name2 = "Rough Copper Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 161;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Barkmail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BarkmailVest : Item
	{
		public BarkmailVest() : base()
		{
			Id = 10656;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 28069;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Barkmail Vest";
			Name2 = "Barkmail Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 73;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Deathchill Armor)
*
***************************************************************/

namespace Server.Items
{
	public class DeathchillArmor : Item
	{
		public DeathchillArmor() : base()
		{
			Id = 10764;
			Resistance[0] = 270;
			Bonding = 1;
			SellPrice = 10434;
			AvailableClasses = 0x7FFF;
			Model = 28710;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Deathchill Armor";
			Name2 = "Deathchill Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52173;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			IqBonus = 20;
			SpiritBonus = 9;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Atal'ai Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class AtalaiBreastplate : Item
	{
		public AtalaiBreastplate() : base()
		{
			Id = 10784;
			Resistance[0] = 311;
			Bonding = 1;
			SellPrice = 18432;
			AvailableClasses = 0x7FFF;
			Model = 19793;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Atal'ai Breastplate";
			Name2 = "Atal'ai Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 512;
			BuyPrice = 92164;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Prismscale Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class PrismscaleHauberk : Item
	{
		public PrismscaleHauberk() : base()
		{
			Id = 11194;
			Resistance[0] = 307;
			Bonding = 1;
			SellPrice = 20404;
			AvailableClasses = 0x7FFF;
			Model = 28237;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			Name = "Prismscale Hauberk";
			Name2 = "Prismscale Hauberk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 102024;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 3;
			SpiritBonus = 4;
			IqBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Mail)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronMail : Item
	{
		public DarkIronMail() : base()
		{
			Id = 11606;
			Resistance[0] = 433;
			Bonding = 2;
			SellPrice = 19255;
			AvailableClasses = 0x7FFF;
			Model = 21577;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Dark Iron Mail";
			Name2 = "Dark Iron Mail";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 96279;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Savage Gladiator Chain)
*
***************************************************************/

namespace Server.Items
{
	public class SavageGladiatorChain : Item
	{
		public SavageGladiatorChain() : base()
		{
			Id = 11726;
			Resistance[0] = 369;
			Bonding = 1;
			SellPrice = 33533;
			AvailableClasses = 0x7FFF;
			Model = 28724;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Savage Gladiator Chain";
			Name2 = "Savage Gladiator Chain";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 167666;
			Sets = 1;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			SetSpell( 14249 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Royal Decorated Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalDecoratedArmor : Item
	{
		public RoyalDecoratedArmor() : base()
		{
			Id = 11820;
			Resistance[0] = 313;
			Bonding = 1;
			SellPrice = 22301;
			AvailableClasses = 0x7FFF;
			Model = 28819;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Royal Decorated Armor";
			Name2 = "Royal Decorated Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 111507;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 7;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Deathdealer Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class DeathdealerBreastplate : Item
	{
		public DeathdealerBreastplate() : base()
		{
			Id = 11926;
			Resistance[0] = 338;
			Bonding = 1;
			SellPrice = 24590;
			AvailableClasses = 0x7FFF;
			Model = 28712;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Deathdealer Breastplate";
			Name2 = "Deathdealer Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122952;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Splintsteel Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SplintsteelArmor : Item
	{
		public SplintsteelArmor() : base()
		{
			Id = 12049;
			Resistance[0] = 288;
			Bonding = 1;
			SellPrice = 16850;
			AvailableClasses = 0x7FFF;
			Model = 28244;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			Name = "Splintsteel Armor";
			Name2 = "Splintsteel Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84251;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 12;
			StaminaBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Basaltscale Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BasaltscaleArmor : Item
	{
		public BasaltscaleArmor() : base()
		{
			Id = 12108;
			Resistance[0] = 313;
			Bonding = 1;
			SellPrice = 23054;
			AvailableClasses = 0x7FFF;
			Model = 28070;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			Name = "Basaltscale Armor";
			Name2 = "Basaltscale Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 115274;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			IqBonus = 21;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Radiant Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantBreastplate : Item
	{
		public RadiantBreastplate() : base()
		{
			Id = 12415;
			Resistance[0] = 293;
			Bonding = 2;
			SellPrice = 17003;
			AvailableClasses = 0x7FFF;
			Model = 25742;
			Resistance[4] = 16;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Radiant Breastplate";
			Name2 = "Radiant Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85018;
			Resistance[5] = 16;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Wildthorn Mail)
*
***************************************************************/

namespace Server.Items
{
	public class WildthornMail : Item
	{
		public WildthornMail() : base()
		{
			Id = 12624;
			Resistance[0] = 322;
			Bonding = 2;
			SellPrice = 20642;
			AvailableClasses = 0x7FFF;
			Model = 25754;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Wildthorn Mail";
			Name2 = "Wildthorn Mail";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 103212;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 16638 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Invulnerable Mail)
*
***************************************************************/

namespace Server.Items
{
	public class InvulnerableMail : Item
	{
		public InvulnerableMail() : base()
		{
			Id = 12641;
			Resistance[0] = 554;
			Bonding = 2;
			SellPrice = 43836;
			AvailableClasses = 0x7FFF;
			Model = 25748;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 57;
			Name = "Invulnerable Mail";
			Name2 = "Invulnerable Mail";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 219182;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			SetSpell( 16620 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14249 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Breastplate of the Chosen)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfTheChosen : Item
	{
		public BreastplateOfTheChosen() : base()
		{
			Id = 13090;
			Resistance[0] = 446;
			Bonding = 1;
			SellPrice = 35955;
			AvailableClasses = 0x7FFF;
			Model = 23605;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Breastplate of the Chosen";
			Name2 = "Breastplate of the Chosen";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 179777;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			StaminaBonus = 14;
			StrBonus = 14;
			IqBonus = 14;
			SpiritBonus = 14;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Dreamwalker Armor)
*
***************************************************************/

namespace Server.Items
{
	public class DreamwalkerArmor : Item
	{
		public DreamwalkerArmor() : base()
		{
			Id = 13123;
			Resistance[0] = 365;
			Bonding = 2;
			SellPrice = 33387;
			AvailableClasses = 0x7FFF;
			Model = 28663;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Dreamwalker Armor";
			Name2 = "Dreamwalker Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 166939;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			IqBonus = 20;
			StaminaBonus = 17;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Bonebrace Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class BonebraceHauberk : Item
	{
		public BonebraceHauberk() : base()
		{
			Id = 14536;
			Resistance[0] = 360;
			Bonding = 1;
			SellPrice = 32271;
			AvailableClasses = 0x5FF;
			Model = 25157;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Bonebrace Hauberk";
			Name2 = "Bonebrace Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 161356;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 15814 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 4;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bloodmail Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class BloodmailHauberk : Item
	{
		public BloodmailHauberk() : base()
		{
			Id = 14611;
			Resistance[0] = 360;
			Bonding = 1;
			SellPrice = 32509;
			AvailableClasses = 0x7FFF;
			Model = 25222;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Bloodmail Hauberk";
			Name2 = "Bloodmail Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 162547;
			Sets = 123;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 10;
			IqBonus = 10;
			SpiritBonus = 15;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(War Paint Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintChestpiece : Item
	{
		public WarPaintChestpiece() : base()
		{
			Id = 14730;
			Resistance[0] = 177;
			Bonding = 2;
			SellPrice = 1223;
			AvailableClasses = 0x7FFF;
			Model = 26984;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "War Paint Chestpiece";
			Name2 = "War Paint Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6119;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 6;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hulking Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingChestguard : Item
	{
		public HulkingChestguard() : base()
		{
			Id = 14744;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 2310;
			AvailableClasses = 0x7FFF;
			Model = 27010;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Hulking Chestguard";
			Name2 = "Hulking Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11551;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 8;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Slayer's Surcoat)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersSurcoat : Item
	{
		public SlayersSurcoat() : base()
		{
			Id = 14751;
			Resistance[0] = 207;
			Bonding = 2;
			SellPrice = 3454;
			AvailableClasses = 0x7FFF;
			Model = 27034;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Slayer's Surcoat";
			Name2 = "Slayer's Surcoat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17271;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 10;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enduring Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringBreastplate : Item
	{
		public EnduringBreastplate() : base()
		{
			Id = 14760;
			Resistance[0] = 227;
			Bonding = 2;
			SellPrice = 6263;
			AvailableClasses = 0x7FFF;
			Model = 27049;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Enduring Breastplate";
			Name2 = "Enduring Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31318;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 12;
			StaminaBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ravager's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersArmor : Item
	{
		public RavagersArmor() : base()
		{
			Id = 14768;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 8566;
			AvailableClasses = 0x7FFF;
			Model = 27092;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Ravager's Armor";
			Name2 = "Ravager's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42834;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 4;
			StaminaBonus = 10;
			IqBonus = 10;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Khan's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class KhansChestpiece : Item
	{
		public KhansChestpiece() : base()
		{
			Id = 14779;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 13347;
			AvailableClasses = 0x7FFF;
			Model = 27147;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Khan's Chestpiece";
			Name2 = "Khan's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 66738;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 17;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Protector Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorBreastplate : Item
	{
		public ProtectorBreastplate() : base()
		{
			Id = 14789;
			Resistance[0] = 293;
			Bonding = 2;
			SellPrice = 17541;
			AvailableClasses = 0x7FFF;
			Model = 27155;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Protector Breastplate";
			Name2 = "Protector Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87708;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 21;
			IqBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustBreastplate : Item
	{
		public BloodlustBreastplate() : base()
		{
			Id = 14798;
			Resistance[0] = 317;
			Bonding = 2;
			SellPrice = 24037;
			AvailableClasses = 0x7FFF;
			Model = 27194;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Bloodlust Breastplate";
			Name2 = "Bloodlust Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 120185;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StrBonus = 9;
			StaminaBonus = 20;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warstrike Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeChestguard : Item
	{
		public WarstrikeChestguard() : base()
		{
			Id = 14811;
			Resistance[0] = 342;
			Bonding = 2;
			SellPrice = 29898;
			AvailableClasses = 0x7FFF;
			Model = 27138;
			ObjectClass = 4;
			SubClass = 3;
			Level = 64;
			ReqLevel = 59;
			Name = "Warstrike Chestguard";
			Name2 = "Warstrike Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 149491;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 10;
			IqBonus = 23;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Green Dragonscale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GreenDragonscaleBreastplate : Item
	{
		public GreenDragonscaleBreastplate() : base()
		{
			Id = 15045;
			Resistance[0] = 311;
			Bonding = 2;
			SellPrice = 19938;
			AvailableClasses = 0x7FFF;
			Model = 25671;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Green Dragonscale Breastplate";
			Name2 = "Green Dragonscale Breastplate";
			Resistance[3] = 11;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 99692;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			IqBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Red Dragonscale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class RedDragonscaleBreastplate : Item
	{
		public RedDragonscaleBreastplate() : base()
		{
			Id = 15047;
			Resistance[0] = 360;
			Bonding = 2;
			SellPrice = 29836;
			AvailableClasses = 0x7FFF;
			Model = 25675;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Red Dragonscale Breastplate";
			Name2 = "Red Dragonscale Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 149181;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 18041 , 1 , 0 , 3600000 , 0 , 600000 );
		}
	}
}


/**************************************************************
*
*				(Blue Dragonscale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BlueDragonscaleBreastplate : Item
	{
		public BlueDragonscaleBreastplate() : base()
		{
			Id = 15048;
			Resistance[6] = 8;
			Resistance[0] = 338;
			Bonding = 2;
			SellPrice = 24409;
			AvailableClasses = 0x7FFF;
			Model = 25676;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Blue Dragonscale Breastplate";
			Name2 = "Blue Dragonscale Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122046;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SpiritBonus = 28;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Black Dragonscale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonscaleBreastplate : Item
	{
		public BlackDragonscaleBreastplate() : base()
		{
			Id = 15050;
			Resistance[0] = 344;
			Bonding = 2;
			SellPrice = 26071;
			AvailableClasses = 0x7FFF;
			Model = 27943;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Black Dragonscale Breastplate";
			Name2 = "Black Dragonscale Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 130357;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 14056 , 1 , 0 , 3600000 , 0 , 600000 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Vest)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidVest : Item
	{
		public HeavyScorpidVest() : base()
		{
			Id = 15076;
			Resistance[0] = 288;
			Bonding = 2;
			SellPrice = 16604;
			AvailableClasses = 0x7FFF;
			Model = 25710;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Heavy Scorpid Vest";
			Name2 = "Heavy Scorpid Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 83020;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Charger's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersArmor : Item
	{
		public ChargersArmor() : base()
		{
			Id = 15479;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 179;
			AvailableClasses = 0x7FFF;
			Model = 26936;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Charger's Armor";
			Name2 = "Charger's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 496;
			BuyPrice = 897;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(War Torn Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornTunic : Item
	{
		public WarTornTunic() : base()
		{
			Id = 15487;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 479;
			AvailableClasses = 0x7FFF;
			Model = 26957;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "War Torn Tunic";
			Name2 = "War Torn Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 498;
			BuyPrice = 2395;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Surcoat)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredSurcoat : Item
	{
		public BloodspatteredSurcoat() : base()
		{
			Id = 15488;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 967;
			AvailableClasses = 0x7FFF;
			Model = 27004;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Bloodspattered Surcoat";
			Name2 = "Bloodspattered Surcoat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 499;
			BuyPrice = 4836;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersChestguard : Item
	{
		public OutrunnersChestguard() : base()
		{
			Id = 15500;
			Resistance[0] = 180;
			Bonding = 2;
			SellPrice = 1377;
			AvailableClasses = 0x7FFF;
			Model = 26990;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Outrunner's Chestguard";
			Name2 = "Outrunner's Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 500;
			BuyPrice = 6889;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 90;
		}
	}
}


/**************************************************************
*
*				(Grunt's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsChestpiece : Item
	{
		public GruntsChestpiece() : base()
		{
			Id = 15514;
			Resistance[0] = 186;
			Bonding = 2;
			SellPrice = 1902;
			AvailableClasses = 0x7FFF;
			Model = 26972;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Grunt's Chestpiece";
			Name2 = "Grunt's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 501;
			BuyPrice = 9514;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 95;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainBreastplate : Item
	{
		public SpikedChainBreastplate() : base()
		{
			Id = 15518;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 2825;
			AvailableClasses = 0x7FFF;
			Model = 26961;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Spiked Chain Breastplate";
			Name2 = "Spiked Chain Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 502;
			BuyPrice = 14128;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Sentry's Surcoat)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysSurcoat : Item
	{
		public SentrysSurcoat() : base()
		{
			Id = 15524;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 2876;
			AvailableClasses = 0x7FFF;
			Model = 27081;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Sentry's Surcoat";
			Name2 = "Sentry's Surcoat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 503;
			BuyPrice = 14383;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainChestpiece : Item
	{
		public WickedChainChestpiece() : base()
		{
			Id = 15536;
			Resistance[0] = 210;
			Bonding = 2;
			SellPrice = 4107;
			AvailableClasses = 0x7FFF;
			Model = 27039;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Wicked Chain Chestpiece";
			Name2 = "Wicked Chain Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 504;
			BuyPrice = 20537;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleBreastplate : Item
	{
		public ThickScaleBreastplate() : base()
		{
			Id = 15546;
			Resistance[0] = 216;
			Bonding = 2;
			SellPrice = 4793;
			AvailableClasses = 0x7FFF;
			Model = 27018;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Thick Scale Breastplate";
			Name2 = "Thick Scale Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 504;
			BuyPrice = 23969;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Pillager's Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersChestguard : Item
	{
		public PillagersChestguard() : base()
		{
			Id = 15557;
			Resistance[0] = 219;
			Bonding = 2;
			SellPrice = 5486;
			AvailableClasses = 0x7FFF;
			Model = 27067;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Pillager's Chestguard";
			Name2 = "Pillager's Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 505;
			BuyPrice = 27430;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Marauder's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersTunic : Item
	{
		public MaraudersTunic() : base()
		{
			Id = 15567;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 6666;
			AvailableClasses = 0x7FFF;
			Model = 27063;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Marauder's Tunic";
			Name2 = "Marauder's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 506;
			BuyPrice = 33333;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellBreastplate : Item
	{
		public SparkleshellBreastplate() : base()
		{
			Id = 15578;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 6962;
			AvailableClasses = 0x7FFF;
			Model = 27112;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Sparkleshell Breastplate";
			Name2 = "Sparkleshell Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 506;
			BuyPrice = 34814;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Steadfast Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastBreastplate : Item
	{
		public SteadfastBreastplate() : base()
		{
			Id = 15591;
			Resistance[0] = 242;
			Bonding = 2;
			SellPrice = 8739;
			AvailableClasses = 0x7FFF;
			Model = 27889;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Steadfast Breastplate";
			Name2 = "Steadfast Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 507;
			BuyPrice = 43699;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Ancient Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class AncientChestpiece : Item
	{
		public AncientChestpiece() : base()
		{
			Id = 15601;
			Resistance[0] = 254;
			Bonding = 2;
			SellPrice = 10345;
			AvailableClasses = 0x7FFF;
			Model = 27118;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Ancient Chestpiece";
			Name2 = "Ancient Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 508;
			BuyPrice = 51726;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Bonelink Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkArmor : Item
	{
		public BonelinkArmor() : base()
		{
			Id = 15609;
			Resistance[0] = 258;
			Bonding = 2;
			SellPrice = 11806;
			AvailableClasses = 0x7FFF;
			Model = 27322;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Bonelink Armor";
			Name2 = "Bonelink Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 508;
			BuyPrice = 59033;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailBreastplate : Item
	{
		public GryphonMailBreastplate() : base()
		{
			Id = 15622;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 14834;
			AvailableClasses = 0x7FFF;
			Model = 27129;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Gryphon Mail Breastplate";
			Name2 = "Gryphon Mail Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 509;
			BuyPrice = 74173;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Formidable Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableChestpiece : Item
	{
		public FormidableChestpiece() : base()
		{
			Id = 15631;
			Resistance[0] = 283;
			Bonding = 2;
			SellPrice = 16672;
			AvailableClasses = 0x7FFF;
			Model = 27212;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Formidable Chestpiece";
			Name2 = "Formidable Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 510;
			BuyPrice = 83363;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Ironhide Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideBreastplate : Item
	{
		public IronhideBreastplate() : base()
		{
			Id = 15640;
			Resistance[0] = 303;
			Bonding = 2;
			SellPrice = 20233;
			AvailableClasses = 0x7FFF;
			Model = 27171;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Ironhide Breastplate";
			Name2 = "Ironhide Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 511;
			BuyPrice = 101168;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Merciless Surcoat)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessSurcoat : Item
	{
		public MercilessSurcoat() : base()
		{
			Id = 15650;
			Resistance[0] = 307;
			Bonding = 2;
			SellPrice = 22230;
			AvailableClasses = 0x7FFF;
			Model = 27290;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Merciless Surcoat";
			Name2 = "Merciless Surcoat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 511;
			BuyPrice = 111154;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableBreastplate : Item
	{
		public ImpenetrableBreastplate() : base()
		{
			Id = 15660;
			Resistance[0] = 327;
			Bonding = 2;
			SellPrice = 26315;
			AvailableClasses = 0x7FFF;
			Model = 27297;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Impenetrable Breastplate";
			Name2 = "Impenetrable Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 513;
			BuyPrice = 131577;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Magnificent Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentBreastplate : Item
	{
		public MagnificentBreastplate() : base()
		{
			Id = 15669;
			Resistance[0] = 332;
			Bonding = 2;
			SellPrice = 28538;
			AvailableClasses = 0x7FFF;
			Model = 27315;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Magnificent Breastplate";
			Name2 = "Magnificent Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 513;
			BuyPrice = 142694;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Triumphant Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantChestpiece : Item
	{
		public TriumphantChestpiece() : base()
		{
			Id = 15680;
			Resistance[0] = 347;
			Bonding = 2;
			SellPrice = 31983;
			AvailableClasses = 0x7FFF;
			Model = 27308;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Triumphant Chestpiece";
			Name2 = "Triumphant Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 514;
			BuyPrice = 159918;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
		}
	}
}


/**************************************************************
*
*				(Willow Band Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class WillowBandHauberk : Item
	{
		public WillowBandHauberk() : base()
		{
			Id = 15787;
			Resistance[0] = 317;
			Bonding = 1;
			SellPrice = 22592;
			AvailableClasses = 0x7FFF;
			Model = 26467;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			Name = "Willow Band Hauberk";
			Name2 = "Willow Band Hauberk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 112961;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			SpiritBonus = 6;
			StaminaBonus = 10;
			AgilityBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Jadescale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class JadescaleBreastplate : Item
	{
		public JadescaleBreastplate() : base()
		{
			Id = 15827;
			Resistance[0] = 317;
			Bonding = 1;
			SellPrice = 22592;
			AvailableClasses = 0x7FFF;
			Model = 26515;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			Name = "Jadescale Breastplate";
			Name2 = "Jadescale Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 112961;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			StaminaBonus = 23;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Chain Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsChainHauberk : Item
	{
		public KnightCaptainsChainHauberk() : base()
		{
			Id = 16425;
			Resistance[0] = 370;
			Bonding = 1;
			SellPrice = 16571;
			AvailableClasses = 0x04;
			Model = 31241;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Chain Hauberk";
			Name2 = "Knight-Captain's Chain Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82858;
			Sets = 362;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 120;
			Flags = 32768;
			SetSpell( 9334 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Chain Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsChainBreastplate : Item
	{
		public FieldMarshalsChainBreastplate() : base()
		{
			Id = 16466;
			Resistance[0] = 416;
			Bonding = 1;
			SellPrice = 25119;
			AvailableClasses = 0x04;
			Model = 32094;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Chain Breastplate";
			Name2 = "Field Marshal's Chain Breastplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 125598;
			Sets = 395;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 140;
			Flags = 32768;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			AgilityBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Mail Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesMailChestpiece : Item
	{
		public LegionnairesMailChestpiece() : base()
		{
			Id = 16522;
			Resistance[0] = 370;
			Bonding = 1;
			SellPrice = 16827;
			AvailableClasses = 0x40;
			Model = 31185;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Mail Chestpiece";
			Name2 = "Legionnaire's Mail Chestpiece";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84136;
			Sets = 301;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Chain Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesChainBreastplate : Item
	{
		public LegionnairesChainBreastplate() : base()
		{
			Id = 16525;
			Resistance[0] = 370;
			Bonding = 1;
			SellPrice = 17475;
			AvailableClasses = 0x04;
			Model = 31048;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Chain Breastplate";
			Name2 = "Legionnaire's Chain Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87375;
			Sets = 361;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 120;
			Flags = 32768;
			SetSpell( 9334 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Warlord's Chain Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsChainChestpiece : Item
	{
		public WarlordsChainChestpiece() : base()
		{
			Id = 16565;
			Resistance[0] = 416;
			Bonding = 1;
			SellPrice = 25683;
			AvailableClasses = 0x04;
			Model = 32122;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Chain Chestpiece";
			Name2 = "Warlord's Chain Chestpiece";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 128417;
			Sets = 396;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 140;
			Flags = 32768;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			AgilityBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Warlord's Mail Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsMailArmor : Item
	{
		public WarlordsMailArmor() : base()
		{
			Id = 16577;
			Resistance[0] = 416;
			Bonding = 1;
			SellPrice = 24934;
			AvailableClasses = 0x40;
			Model = 32103;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Mail Armor";
			Name2 = "Warlord's Mail Armor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 124671;
			Sets = 386;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 140;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Vest of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class VestOfElements : Item
	{
		public VestOfElements() : base()
		{
			Id = 16666;
			Resistance[0] = 370;
			Bonding = 1;
			SellPrice = 35962;
			AvailableClasses = 0x7FFF;
			Model = 31416;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Vest of Elements";
			Name2 = "Vest of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 179813;
			Sets = 187;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SpiritBonus = 20;
			IqBonus = 20;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersTunic : Item
	{
		public BeaststalkersTunic() : base()
		{
			Id = 16674;
			Resistance[0] = 370;
			Bonding = 1;
			SellPrice = 34435;
			AvailableClasses = 0x7FFF;
			Model = 31402;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Beaststalker's Tunic";
			Name2 = "Beaststalker's Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 172177;
			Sets = 186;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			AgilityBonus = 21;
			StaminaBonus = 16;
			SpiritBonus = 13;
			IqBonus = 6;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersBreastplate : Item
	{
		public GiantstalkersBreastplate() : base()
		{
			Id = 16845;
			Resistance[0] = 422;
			Bonding = 1;
			SellPrice = 54148;
			AvailableClasses = 0x04;
			Model = 32022;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Breastplate";
			Name2 = "Giantstalker's Breastplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 270742;
			Sets = 206;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 26;
			SpiritBonus = 11;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersBreastplate : Item
	{
		public DragonstalkersBreastplate() : base()
		{
			Id = 16942;
			Resistance[0] = 482;
			Bonding = 1;
			SellPrice = 89496;
			AvailableClasses = 0x04;
			Model = 29807;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Breastplate";
			Name2 = "Dragonstalker's Breastplate";
			Resistance[3] = 10;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 447482;
			Sets = 215;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 34;
			SpiritBonus = 14;
			IqBonus = 6;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Breastplate of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfTenStorms : Item
	{
		public BreastplateOfTenStorms() : base()
		{
			Id = 16950;
			Resistance[0] = 482;
			Bonding = 1;
			SellPrice = 83355;
			AvailableClasses = 0x7FFF;
			Model = 29785;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Breastplate of Ten Storms";
			Name2 = "Breastplate of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 416775;
			Sets = 216;
			Resistance[5] = 3;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 140;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9404 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 31;
			IqBonus = 20;
			StaminaBonus = 17;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Relentless Chain)
*
***************************************************************/

namespace Server.Items
{
	public class RelentlessChain : Item
	{
		public RelentlessChain() : base()
		{
			Id = 17777;
			Resistance[0] = 258;
			Bonding = 1;
			SellPrice = 10815;
			AvailableClasses = 0x7FFF;
			Model = 29953;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			Name = "Relentless Chain";
			Name2 = "Relentless Chain";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54078;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ogre Forged Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class OgreForgedHauberk : Item
	{
		public OgreForgedHauberk() : base()
		{
			Id = 18530;
			Resistance[0] = 365;
			Bonding = 1;
			SellPrice = 31331;
			AvailableClasses = 0x7FFF;
			Model = 30866;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Ogre Forged Hauberk";
			Name2 = "Ogre Forged Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 156657;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 120;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			StaminaBonus = 13;
			SpiritBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Seared Mail Vest)
*
***************************************************************/

namespace Server.Items
{
	public class SearedMailVest : Item
	{
		public SearedMailVest() : base()
		{
			Id = 19128;
			Resistance[0] = 273;
			Bonding = 1;
			SellPrice = 13358;
			AvailableClasses = 0x7FFF;
			Model = 31641;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			Name = "Seared Mail Vest";
			Name2 = "Seared Mail Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 66790;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 5;
			Durability = 100;
			AgilityBonus = 11;
			SpiritBonus = 11;
			StaminaBonus = 11;
		}
	}
}


