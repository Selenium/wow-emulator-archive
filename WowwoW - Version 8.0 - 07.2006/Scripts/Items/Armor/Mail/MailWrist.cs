/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:51 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Brass-studded Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrassStuddedBracers : Item
	{
		public BrassStuddedBracers() : base()
		{
			Id = 1182;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 6852;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Brass-studded Bracers";
			Name2 = "Brass-studded Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 222;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Worn Mail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WornMailBracers : Item
	{
		public WornMailBracers() : base()
		{
			Id = 1732;
			Resistance[0] = 54;
			SellPrice = 73;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Worn Mail Bracers";
			Name2 = "Worn Mail Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 368;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailBracers : Item
	{
		public LacedMailBracers() : base()
		{
			Id = 1740;
			Resistance[0] = 60;
			SellPrice = 97;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "Laced Mail Bracers";
			Name2 = "Laced Mail Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 487;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainBracers : Item
	{
		public LinkedChainBracers() : base()
		{
			Id = 1748;
			Resistance[0] = 68;
			SellPrice = 232;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Linked Chain Bracers";
			Name2 = "Linked Chain Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 1160;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainBracers : Item
	{
		public ReinforcedChainBracers() : base()
		{
			Id = 1756;
			Resistance[0] = 76;
			SellPrice = 438;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Reinforced Chain Bracers";
			Name2 = "Reinforced Chain Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 2190;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Chainmail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChainmailBracers : Item
	{
		public ChainmailBracers() : base()
		{
			Id = 1846;
			Resistance[0] = 66;
			SellPrice = 176;
			AvailableClasses = 0x7FFF;
			Model = 13617;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Chainmail Bracers";
			Name2 = "Chainmail Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 880;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Scalemail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ScalemailBracers : Item
	{
		public ScalemailBracers() : base()
		{
			Id = 1852;
			Resistance[0] = 72;
			SellPrice = 336;
			AvailableClasses = 0x7FFF;
			Model = 6985;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Scalemail Bracers";
			Name2 = "Scalemail Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1684;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Polished Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedScaleBracers : Item
	{
		public PolishedScaleBracers() : base()
		{
			Id = 2150;
			Resistance[0] = 79;
			SellPrice = 586;
			AvailableClasses = 0x7FFF;
			Model = 6973;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Polished Scale Bracers";
			Name2 = "Polished Scale Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2930;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Tarnished Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedChainBracers : Item
	{
		public TarnishedChainBracers() : base()
		{
			Id = 2384;
			Resistance[0] = 29;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Tarnished Chain Bracers";
			Name2 = "Tarnished Chain Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 37;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Rusted Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RustedChainBracers : Item
	{
		public RustedChainBracers() : base()
		{
			Id = 2390;
			Resistance[0] = 29;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6953;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Rusted Chain Bracers";
			Name2 = "Rusted Chain Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Light Mail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LightMailBracers : Item
	{
		public LightMailBracers() : base()
		{
			Id = 2396;
			Resistance[0] = 45;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Mail Bracers";
			Name2 = "Light Mail Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 215;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Light Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LightChainBracers : Item
	{
		public LightChainBracers() : base()
		{
			Id = 2402;
			Resistance[0] = 45;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 6953;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Chain Bracers";
			Name2 = "Light Chain Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 219;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainBracers : Item
	{
		public AugmentedChainBracers() : base()
		{
			Id = 2421;
			Resistance[0] = 91;
			SellPrice = 1590;
			AvailableClasses = 0x7FFF;
			Model = 6821;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Bracers";
			Name2 = "Augmented Chain Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7952;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brigandine Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineBracers : Item
	{
		public BrigandineBracers() : base()
		{
			Id = 2427;
			Resistance[0] = 113;
			SellPrice = 4029;
			AvailableClasses = 0x7FFF;
			Model = 6855;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Bracers";
			Name2 = "Brigandine Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20146;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainBracers : Item
	{
		public LooseChainBracers() : base()
		{
			Id = 2643;
			Resistance[0] = 42;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Loose Chain Bracers";
			Name2 = "Loose Chain Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 144;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainBracers : Item
	{
		public FlimsyChainBracers() : base()
		{
			Id = 2651;
			Resistance[0] = 25;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 4;
			ReqLevel = 1;
			Name = "Flimsy Chain Bracers";
			Name2 = "Flimsy Chain Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Copper Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CopperBracers : Item
	{
		public CopperBracers() : base()
		{
			Id = 2853;
			Resistance[0] = 35;
			SellPrice = 17;
			AvailableClasses = 0x7FFF;
			Model = 6966;
			ObjectClass = 4;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Copper Bracers";
			Name2 = "Copper Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 85;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Runed Copper Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RunedCopperBracers : Item
	{
		public RunedCopperBracers() : base()
		{
			Id = 2854;
			Resistance[0] = 68;
			SellPrice = 225;
			AvailableClasses = 0x7FFF;
			Model = 25851;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Runed Copper Bracers";
			Name2 = "Runed Copper Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1127;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Patterned Bronze Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PatternedBronzeBracers : Item
	{
		public PatternedBronzeBracers() : base()
		{
			Id = 2868;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 807;
			AvailableClasses = 0x7FFF;
			Model = 23533;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Patterned Bronze Bracers";
			Name2 = "Patterned Bronze Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4035;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Burnished Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedBracers : Item
	{
		public BurnishedBracers() : base()
		{
			Id = 3211;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 373;
			AvailableClasses = 0x7FFF;
			Model = 25766;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Burnished Bracers";
			Name2 = "Burnished Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1865;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleBracers : Item
	{
		public LambentScaleBracers() : base()
		{
			Id = 3212;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 929;
			AvailableClasses = 0x7FFF;
			Model = 25779;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Lambent Scale Bracers";
			Name2 = "Lambent Scale Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4645;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 4;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Veteran Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranBracers : Item
	{
		public VeteranBracers() : base()
		{
			Id = 3213;
			Resistance[0] = 54;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 6953;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Veteran Bracers";
			Name2 = "Veteran Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 447;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Warrior's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsBracers : Item
	{
		public WarriorsBracers() : base()
		{
			Id = 3214;
			Resistance[0] = 42;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 22674;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Warrior's Bracers";
			Name2 = "Warrior's Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 169;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Jimmied Handcuffs)
*
***************************************************************/

namespace Server.Items
{
	public class JimmiedHandcuffs : Item
	{
		public JimmiedHandcuffs() : base()
		{
			Id = 3228;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 1098;
			AvailableClasses = 0x7FFF;
			Model = 10402;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Jimmied Handcuffs";
			Name2 = "Jimmied Handcuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5492;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 3;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainBracers : Item
	{
		public BattleChainBracers() : base()
		{
			Id = 3280;
			Resistance[0] = 42;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 26928;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Battle Chain Bracers";
			Name2 = "Battle Chain Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 165;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Brackwater Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterBracers : Item
	{
		public BrackwaterBracers() : base()
		{
			Id = 3303;
			Resistance[0] = 51;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 26945;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Brackwater Bracers";
			Name2 = "Brackwater Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 353;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Double Mail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailBracers : Item
	{
		public DoubleMailBracers() : base()
		{
			Id = 3810;
			Resistance[0] = 88;
			SellPrice = 1145;
			AvailableClasses = 0x7FFF;
			Model = 6904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Double Mail Bracers";
			Name2 = "Double Mail Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 5728;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Green Iron Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronBracers : Item
	{
		public GreenIronBracers() : base()
		{
			Id = 3835;
			Resistance[0] = 86;
			SellPrice = 1106;
			AvailableClasses = 0x7FFF;
			Model = 9417;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Green Iron Bracers";
			Name2 = "Green Iron Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5532;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleBracers : Item
	{
		public LaminatedScaleBracers() : base()
		{
			Id = 3994;
			Resistance[0] = 123;
			SellPrice = 4404;
			AvailableClasses = 0x7FFF;
			Model = 6948;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Laminated Scale Bracers";
			Name2 = "Laminated Scale Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 22023;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainBracers : Item
	{
		public OverlinkedChainBracers() : base()
		{
			Id = 4002;
			Resistance[0] = 104;
			SellPrice = 2463;
			AvailableClasses = 0x7FFF;
			Model = 6966;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Overlinked Chain Bracers";
			Name2 = "Overlinked Chain Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 12315;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Poobah's Nose Ring)
*
***************************************************************/

namespace Server.Items
{
	public class PoobahsNoseRing : Item
	{
		public PoobahsNoseRing() : base()
		{
			Id = 4118;
			Resistance[0] = 119;
			Bonding = 1;
			SellPrice = 7313;
			AvailableClasses = 0x7FFF;
			Model = 6976;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			Name = "Poobah's Nose Ring";
			Name2 = "Poobah's Nose Ring";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36567;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Darkspear Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class DarkspearArmsplints : Item
	{
		public DarkspearArmsplints() : base()
		{
			Id = 4132;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 2681;
			AvailableClasses = 0x7FFF;
			Model = 6884;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			Name = "Darkspear Armsplints";
			Name2 = "Darkspear Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13408;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Pugilist Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PugilistBracers : Item
	{
		public PugilistBracers() : base()
		{
			Id = 4438;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 1692;
			AvailableClasses = 0x7FFF;
			Model = 6977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Pugilist Bracers";
			Name2 = "Pugilist Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8464;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Steel-clasped Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SteelClaspedBracers : Item
	{
		public SteelClaspedBracers() : base()
		{
			Id = 4534;
			Resistance[0] = 85;
			Bonding = 1;
			SellPrice = 1173;
			AvailableClasses = 0x7FFF;
			Model = 6996;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			Name = "Steel-clasped Bracers";
			Name2 = "Steel-clasped Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5868;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 6;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(War Rider Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WarRiderBracers : Item
	{
		public WarRiderBracers() : base()
		{
			Id = 4745;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 3230;
			AvailableClasses = 0x7FFF;
			Model = 7005;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			Name = "War Rider Bracers";
			Name2 = "War Rider Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16153;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fortified Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedBindings : Item
	{
		public FortifiedBindings() : base()
		{
			Id = 4969;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 42;
			AvailableClasses = 0x7FFF;
			Model = 6915;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Fortified Bindings";
			Name2 = "Fortified Bindings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 210;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Rift Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RiftBracers : Item
	{
		public RiftBracers() : base()
		{
			Id = 5943;
			Resistance[0] = 80;
			Bonding = 1;
			SellPrice = 840;
			AvailableClasses = 0x7FFF;
			Model = 9378;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Rift Bracers";
			Name2 = "Rift Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4202;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleBracers : Item
	{
		public GoldenScaleBracers() : base()
		{
			Id = 6040;
			Resistance[0] = 91;
			SellPrice = 1649;
			AvailableClasses = 0x7FFF;
			Model = 9634;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Golden Scale Bracers";
			Name2 = "Golden Scale Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8247;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Graystone Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GraystoneBracers : Item
	{
		public GraystoneBracers() : base()
		{
			Id = 6061;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 9644;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			Name = "Graystone Bracers";
			Name2 = "Graystone Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 116;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ironwrought Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IronwroughtBracers : Item
	{
		public IronwroughtBracers() : base()
		{
			Id = 6177;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 69;
			AvailableClasses = 0x7FFF;
			Model = 6934;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			Name = "Ironwrought Bracers";
			Name2 = "Ironwrought Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 348;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailBracers : Item
	{
		public GlimmeringMailBracers() : base()
		{
			Id = 6387;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 1228;
			AvailableClasses = 0x7FFF;
			Model = 25800;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Glimmering Mail Bracers";
			Name2 = "Glimmering Mail Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6141;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatArmguards : Item
	{
		public MailCombatArmguards() : base()
		{
			Id = 6403;
			Resistance[0] = 91;
			Bonding = 2;
			SellPrice = 1771;
			AvailableClasses = 0x7FFF;
			Model = 25808;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Mail Combat Armguards";
			Name2 = "Mail Combat Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8859;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 6;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierBracers : Item
	{
		public ChiefBrigadierBracers() : base()
		{
			Id = 6413;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 2497;
			AvailableClasses = 0x7FFF;
			Model = 25886;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Chief Brigadier Bracers";
			Name2 = "Chief Brigadier Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12487;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 7;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Blackforge Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeBracers : Item
	{
		public BlackforgeBracers() : base()
		{
			Id = 6426;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 4162;
			AvailableClasses = 0x7FFF;
			Model = 26073;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Blackforge Bracers";
			Name2 = "Blackforge Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20811;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 8;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Infantry Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryBracers : Item
	{
		public InfantryBracers() : base()
		{
			Id = 6507;
			Resistance[0] = 45;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 22679;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Infantry Bracers";
			Name2 = "Infantry Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 223;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Soldier's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersWristguards : Item
	{
		public SoldiersWristguards() : base()
		{
			Id = 6550;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 204;
			AvailableClasses = 0x7FFF;
			Model = 25758;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Soldier's Wristguards";
			Name2 = "Soldier's Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1085;
			BuyPrice = 1024;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Defender Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderBracers : Item
	{
		public DefenderBracers() : base()
		{
			Id = 6574;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 568;
			AvailableClasses = 0x7FFF;
			Model = 12456;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Defender Bracers";
			Name2 = "Defender Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1088;
			BuyPrice = 2840;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Battleforge Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeWristguards : Item
	{
		public BattleforgeWristguards() : base()
		{
			Id = 6591;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 1007;
			AvailableClasses = 0x7FFF;
			Model = 25797;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Battleforge Wristguards";
			Name2 = "Battleforge Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1089;
			BuyPrice = 5039;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Hexed Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HexedBracers : Item
	{
		public HexedBracers() : base()
		{
			Id = 6665;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 895;
			AvailableClasses = 0x7FFF;
			Model = 12783;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			Name = "Hexed Bracers";
			Name2 = "Hexed Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4477;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Tempered Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TemperedBracers : Item
	{
		public TemperedBracers() : base()
		{
			Id = 6675;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 1048;
			AvailableClasses = 0x7FFF;
			Model = 12804;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			Name = "Tempered Bracers";
			Name2 = "Tempered Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5244;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Beastial Manacles)
*
***************************************************************/

namespace Server.Items
{
	public class BeastialManacles : Item
	{
		public BeastialManacles() : base()
		{
			Id = 6722;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 1331;
			AvailableClasses = 0x7FFF;
			Model = 12935;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			Name = "Beastial Manacles";
			Name2 = "Beastial Manacles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6657;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 1;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Auric Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class AuricBracers : Item
	{
		public AuricBracers() : base()
		{
			Id = 6793;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 3157;
			AvailableClasses = 0x7FFF;
			Model = 13053;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			Name = "Auric Bracers";
			Name2 = "Auric Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15786;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 8;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Beetle Clasps)
*
***************************************************************/

namespace Server.Items
{
	public class BeetleClasps : Item
	{
		public BeetleClasps() : base()
		{
			Id = 7003;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 981;
			AvailableClasses = 0x7FFF;
			Model = 13508;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			Name = "Beetle Clasps";
			Name2 = "Beetle Clasps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4906;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Phalanx Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxBracers : Item
	{
		public PhalanxBracers() : base()
		{
			Id = 7416;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 1442;
			AvailableClasses = 0x7FFF;
			Model = 26032;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Phalanx Bracers";
			Name2 = "Phalanx Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1091;
			BuyPrice = 7213;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Knight's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsBracers : Item
	{
		public KnightsBracers() : base()
		{
			Id = 7461;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 2429;
			AvailableClasses = 0x7FFF;
			Model = 25861;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Knight's Bracers";
			Name2 = "Knight's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1092;
			BuyPrice = 12149;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Captain's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsBracers : Item
	{
		public CaptainsBracers() : base()
		{
			Id = 7493;
			Resistance[0] = 101;
			Bonding = 2;
			SellPrice = 3268;
			AvailableClasses = 0x7FFF;
			Model = 25818;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Captain's Bracers";
			Name2 = "Captain's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1094;
			BuyPrice = 16344;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Champion's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsBracers : Item
	{
		public ChampionsBracers() : base()
		{
			Id = 7545;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 4658;
			AvailableClasses = 0x7FFF;
			Model = 26088;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Champion's Bracers";
			Name2 = "Champion's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1095;
			BuyPrice = 23290;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mithril Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilScaleBracers : Item
	{
		public MithrilScaleBracers() : base()
		{
			Id = 7924;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 4103;
			AvailableClasses = 0x7FFF;
			Model = 6985;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Mithril Scale Bracers";
			Name2 = "Mithril Scale Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20516;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsBracers : Item
	{
		public MyrmidonsBracers() : base()
		{
			Id = 8125;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 6367;
			AvailableClasses = 0x7FFF;
			Model = 26103;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Myrmidon's Bracers";
			Name2 = "Myrmidon's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31837;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 5;
			SpiritBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Turtle Scale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TurtleScaleBracers : Item
	{
		public TurtleScaleBracers() : base()
		{
			Id = 8198;
			Resistance[0] = 204;
			Bonding = 2;
			SellPrice = 4013;
			AvailableClasses = 0x7FFF;
			Model = 16506;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Turtle Scale Bracers";
			Name2 = "Turtle Scale Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20068;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidBracers : Item
	{
		public ToughScorpidBracers() : base()
		{
			Id = 8205;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 4346;
			AvailableClasses = 0x7FFF;
			Model = 16516;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Tough Scorpid Bracers";
			Name2 = "Tough Scorpid Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21734;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdWristguards : Item
	{
		public EbonholdWristguards() : base()
		{
			Id = 8264;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 7857;
			AvailableClasses = 0x7FFF;
			Model = 28451;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Ebonhold Wristguards";
			Name2 = "Ebonhold Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39287;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 11;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hero's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HerosBracers : Item
	{
		public HerosBracers() : base()
		{
			Id = 8302;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 11060;
			AvailableClasses = 0x7FFF;
			Model = 26313;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Hero's Bracers";
			Name2 = "Hero's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55301;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 4;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Revelosh's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class ReveloshsArmguards : Item
	{
		public ReveloshsArmguards() : base()
		{
			Id = 9388;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 3196;
			AvailableClasses = 0x7FFF;
			Model = 18427;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Revelosh's Armguards";
			Name2 = "Revelosh's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1094;
			BuyPrice = 15981;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ironaya's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IronayasBracers : Item
	{
		public IronayasBracers() : base()
		{
			Id = 9409;
			Resistance[0] = 165;
			Bonding = 1;
			SellPrice = 4490;
			AvailableClasses = 0x7FFF;
			Model = 18352;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Ironaya's Bracers";
			Name2 = "Ironaya's Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1096;
			BuyPrice = 22450;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Fire-welded Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FireWeldedBracers : Item
	{
		public FireWeldedBracers() : base()
		{
			Id = 9535;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 1406;
			AvailableClasses = 0x7FFF;
			Model = 28169;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			Name = "Fire-welded Bracers";
			Name2 = "Fire-welded Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7034;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 1;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Chelonian Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class ChelonianCuffs : Item
	{
		public ChelonianCuffs() : base()
		{
			Id = 9638;
			Resistance[0] = 119;
			Bonding = 1;
			SellPrice = 6875;
			AvailableClasses = 0x7FFF;
			Model = 28118;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			Name = "Chelonian Cuffs";
			Name2 = "Chelonian Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34376;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 4;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cadet Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CadetBracers : Item
	{
		public CadetBracers() : base()
		{
			Id = 9760;
			Resistance[0] = 51;
			SellPrice = 73;
			AvailableClasses = 0x7FFF;
			Model = 22685;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Cadet Bracers";
			Name2 = "Cadet Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 367;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Raider's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersBracers : Item
	{
		public RaidersBracers() : base()
		{
			Id = 9785;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 268;
			AvailableClasses = 0x7FFF;
			Model = 25776;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Raider's Bracers";
			Name2 = "Raider's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1086;
			BuyPrice = 1344;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Fortified Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedBracers : Item
	{
		public FortifiedBracers() : base()
		{
			Id = 9811;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 725;
			AvailableClasses = 0x7FFF;
			Model = 25772;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Fortified Bracers";
			Name2 = "Fortified Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1088;
			BuyPrice = 3628;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Banded Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BandedBracers : Item
	{
		public BandedBracers() : base()
		{
			Id = 9837;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 1287;
			AvailableClasses = 0x7FFF;
			Model = 27783;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Banded Bracers";
			Name2 = "Banded Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1090;
			BuyPrice = 6436;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Renegade Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeBracers : Item
	{
		public RenegadeBracers() : base()
		{
			Id = 9865;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 1942;
			AvailableClasses = 0x7FFF;
			Model = 25786;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Renegade Bracers";
			Name2 = "Renegade Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1092;
			BuyPrice = 9711;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintBracers : Item
	{
		public JazeraintBracers() : base()
		{
			Id = 9896;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 2913;
			AvailableClasses = 0x7FFF;
			Model = 27788;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Jazeraint Bracers";
			Name2 = "Jazeraint Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1093;
			BuyPrice = 14567;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brigade Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeBracers : Item
	{
		public BrigadeBracers() : base()
		{
			Id = 9927;
			Resistance[0] = 104;
			Bonding = 2;
			SellPrice = 3927;
			AvailableClasses = 0x7FFF;
			Model = 25931;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Brigade Bracers";
			Name2 = "Brigade Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1094;
			BuyPrice = 19638;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersBracers : Item
	{
		public WarmongersBracers() : base()
		{
			Id = 9956;
			Resistance[0] = 111;
			Bonding = 2;
			SellPrice = 5130;
			AvailableClasses = 0x7FFF;
			Model = 26181;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Warmonger's Bracers";
			Name2 = "Warmonger's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1096;
			BuyPrice = 25650;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Lord's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class LordsArmguards : Item
	{
		public LordsArmguards() : base()
		{
			Id = 10076;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 6571;
			AvailableClasses = 0x7FFF;
			Model = 19725;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Lord's Armguards";
			Name2 = "Lord's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1097;
			BuyPrice = 32855;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ornate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBracers : Item
	{
		public OrnateBracers() : base()
		{
			Id = 10126;
			Resistance[0] = 128;
			Bonding = 2;
			SellPrice = 8865;
			AvailableClasses = 0x7FFF;
			Model = 26289;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Ornate Bracers";
			Name2 = "Ornate Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1098;
			BuyPrice = 44327;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mercurial Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialBracers : Item
	{
		public MercurialBracers() : base()
		{
			Id = 10156;
			Resistance[0] = 141;
			Bonding = 2;
			SellPrice = 12794;
			AvailableClasses = 0x7FFF;
			Model = 26122;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Mercurial Bracers";
			Name2 = "Mercurial Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1100;
			BuyPrice = 63973;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Crusader's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersArmguards : Item
	{
		public CrusadersArmguards() : base()
		{
			Id = 10191;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 7777;
			AvailableClasses = 0x7FFF;
			Model = 26155;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Crusader's Armguards";
			Name2 = "Crusader's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1097;
			BuyPrice = 38887;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Engraved Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedBracers : Item
	{
		public EngravedBracers() : base()
		{
			Id = 10229;
			Resistance[0] = 132;
			Bonding = 2;
			SellPrice = 10331;
			AvailableClasses = 0x7FFF;
			Model = 26265;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Engraved Bracers";
			Name2 = "Engraved Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1099;
			BuyPrice = 51657;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Masterwork Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkBracers : Item
	{
		public MasterworkBracers() : base()
		{
			Id = 10265;
			Resistance[0] = 145;
			Bonding = 2;
			SellPrice = 13904;
			AvailableClasses = 0x7FFF;
			Model = 26239;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Masterwork Bracers";
			Name2 = "Masterwork Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1101;
			BuyPrice = 69523;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Scarlet Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletWristguards : Item
	{
		public ScarletWristguards() : base()
		{
			Id = 10333;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 2314;
			AvailableClasses = 0x7FFF;
			Model = 28382;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Scarlet Wristguards";
			Name2 = "Scarlet Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11574;
			Sets = 163;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Duracin Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DuracinBracers : Item
	{
		public DuracinBracers() : base()
		{
			Id = 10358;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 2421;
			AvailableClasses = 0x7FFF;
			Model = 28156;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			Name = "Duracin Bracers";
			Name2 = "Duracin Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12107;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 3;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Slimescale Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SlimescaleBracers : Item
	{
		public SlimescaleBracers() : base()
		{
			Id = 10632;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 7624;
			AvailableClasses = 0x7FFF;
			Model = 28711;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Slimescale Bracers";
			Name2 = "Slimescale Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38124;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			IqBonus = 13;
			SpiritBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Rubicund Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class RubicundArmguards : Item
	{
		public RubicundArmguards() : base()
		{
			Id = 11679;
			Resistance[0] = 130;
			Bonding = 1;
			SellPrice = 9781;
			AvailableClasses = 0x7FFF;
			Model = 28820;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Rubicund Armguards";
			Name2 = "Rubicund Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48908;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 11;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Pyremail Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class PyremailWristguards : Item
	{
		public PyremailWristguards() : base()
		{
			Id = 11765;
			Resistance[0] = 148;
			Bonding = 1;
			SellPrice = 12525;
			AvailableClasses = 0x7FFF;
			Model = 28806;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Pyremail Wristguards";
			Name2 = "Pyremail Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1101;
			BuyPrice = 62625;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Rustmetal Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RustmetalBracers : Item
	{
		public RustmetalBracers() : base()
		{
			Id = 11849;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 9644;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Rustmetal Bracers";
			Name2 = "Rustmetal Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Crypt Demon Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CryptDemonBracers : Item
	{
		public CryptDemonBracers() : base()
		{
			Id = 12112;
			Resistance[0] = 132;
			Bonding = 1;
			SellPrice = 10406;
			AvailableClasses = 0x7FFF;
			Model = 28139;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			Name = "Crypt Demon Bracers";
			Name2 = "Crypt Demon Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52034;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Yorgen Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class YorgenBracers : Item
	{
		public YorgenBracers() : base()
		{
			Id = 13012;
			Resistance[0] = 91;
			Bonding = 2;
			SellPrice = 1241;
			AvailableClasses = 0x7FFF;
			Model = 28596;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Yorgen Bracers";
			Name2 = "Yorgen Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6208;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 6;
			AgilityBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lordly Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class LordlyArmguards : Item
	{
		public LordlyArmguards() : base()
		{
			Id = 13135;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 14001;
			AvailableClasses = 0x7FFF;
			Model = 28668;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Lordly Armguards";
			Name2 = "Lordly Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70008;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 7;
			IqBonus = 8;
			StaminaBonus = 8;
			SpiritBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Brazecore Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class BrazecoreArmguards : Item
	{
		public BrazecoreArmguards() : base()
		{
			Id = 13179;
			Resistance[0] = 155;
			Bonding = 1;
			SellPrice = 14916;
			AvailableClasses = 0x7FFF;
			Model = 23730;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Brazecore Armguards";
			Name2 = "Brazecore Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 74583;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SpiritBonus = 7;
			StaminaBonus = 10;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Crushridge Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class CrushridgeBindings : Item
	{
		public CrushridgeBindings() : base()
		{
			Id = 13199;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 4398;
			AvailableClasses = 0x7FFF;
			Model = 28436;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Crushridge Bindings";
			Name2 = "Crushridge Bindings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21994;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 5;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Slashclaw Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SlashclawBracers : Item
	{
		public SlashclawBracers() : base()
		{
			Id = 13211;
			Resistance[0] = 141;
			Bonding = 1;
			SellPrice = 12062;
			AvailableClasses = 0x7FFF;
			Model = 23769;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Slashclaw Bracers";
			Name2 = "Slashclaw Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60311;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 7;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Twilight Void Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightVoidBracers : Item
	{
		public TwilightVoidBracers() : base()
		{
			Id = 13528;
			Resistance[0] = 145;
			Bonding = 1;
			SellPrice = 13198;
			AvailableClasses = 0x7FFF;
			Model = 24180;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Twilight Void Bracers";
			Name2 = "Twilight Void Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65993;
			Resistance[5] = 15;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Loomguard Armbraces)
*
***************************************************************/

namespace Server.Items
{
	public class LoomguardArmbraces : Item
	{
		public LoomguardArmbraces() : base()
		{
			Id = 13969;
			Resistance[0] = 157;
			Bonding = 1;
			SellPrice = 16019;
			AvailableClasses = 0x7FFF;
			Model = 24793;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Loomguard Armbraces";
			Name2 = "Loomguard Armbraces";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 80097;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cavedweller Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CavedwellerBracers : Item
	{
		public CavedwellerBracers() : base()
		{
			Id = 14147;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 311;
			AvailableClasses = 0x7FFF;
			Model = 24982;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Cavedweller Bracers";
			Name2 = "Cavedweller Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1559;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 1;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(War Paint Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintBindings : Item
	{
		public WarPaintBindings() : base()
		{
			Id = 14723;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 290;
			AvailableClasses = 0x7FFF;
			Model = 26982;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "War Paint Bindings";
			Name2 = "War Paint Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1450;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hulking Bands)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingBands : Item
	{
		public HulkingBands() : base()
		{
			Id = 14743;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 583;
			AvailableClasses = 0x7FFF;
			Model = 27007;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Hulking Bands";
			Name2 = "Hulking Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2916;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Slayer's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersCuffs : Item
	{
		public SlayersCuffs() : base()
		{
			Id = 14750;
			Resistance[0] = 84;
			Bonding = 2;
			SellPrice = 1068;
			AvailableClasses = 0x7FFF;
			Model = 27026;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Slayer's Cuffs";
			Name2 = "Slayer's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5340;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Enduring Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringBracers : Item
	{
		public EnduringBracers() : base()
		{
			Id = 14759;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 2009;
			AvailableClasses = 0x7FFF;
			Model = 27048;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Enduring Bracers";
			Name2 = "Enduring Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10049;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			StrBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ravager's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersArmguards : Item
	{
		public RavagersArmguards() : base()
		{
			Id = 14770;
			Resistance[0] = 101;
			Bonding = 2;
			SellPrice = 3172;
			AvailableClasses = 0x7FFF;
			Model = 27091;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Ravager's Armguards";
			Name2 = "Ravager's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15864;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Khan's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class KhansBindings : Item
	{
		public KhansBindings() : base()
		{
			Id = 14778;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 4933;
			AvailableClasses = 0x7FFF;
			Model = 21756;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Khan's Bindings";
			Name2 = "Khan's Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24666;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			IqBonus = 5;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Protector Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorArmguards : Item
	{
		public ProtectorArmguards() : base()
		{
			Id = 14788;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 6408;
			AvailableClasses = 0x7FFF;
			Model = 27154;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Protector Armguards";
			Name2 = "Protector Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32042;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 11;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustBracelets : Item
	{
		public BloodlustBracelets() : base()
		{
			Id = 14807;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 8211;
			AvailableClasses = 0x7FFF;
			Model = 27193;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Bloodlust Bracelets";
			Name2 = "Bloodlust Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41058;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Warstrike Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeArmsplints : Item
	{
		public WarstrikeArmsplints() : base()
		{
			Id = 14810;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 11669;
			AvailableClasses = 0x7FFF;
			Model = 27136;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Warstrike Armsplints";
			Name2 = "Warstrike Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58345;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 13;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidBracers : Item
	{
		public HeavyScorpidBracers() : base()
		{
			Id = 15077;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 7615;
			AvailableClasses = 0x7FFF;
			Model = 25720;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Heavy Scorpid Bracers";
			Name2 = "Heavy Scorpid Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38077;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Clamshell Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ClamshellBracers : Item
	{
		public ClamshellBracers() : base()
		{
			Id = 15400;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 109;
			AvailableClasses = 0x7FFF;
			Model = 28130;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			Name = "Clamshell Bracers";
			Name2 = "Clamshell Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 545;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Grimtoll Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class GrimtollWristguards : Item
	{
		public GrimtollWristguards() : base()
		{
			Id = 15459;
			Resistance[0] = 84;
			Bonding = 1;
			SellPrice = 1142;
			AvailableClasses = 0x7FFF;
			Model = 28275;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			Name = "Grimtoll Wristguards";
			Name2 = "Grimtoll Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5712;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 5;
			StaminaBonus = 2;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Charger's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersBindings : Item
	{
		public ChargersBindings() : base()
		{
			Id = 15474;
			Resistance[0] = 39;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 26938;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			ReqLevel = 3;
			Name = "Charger's Bindings";
			Name2 = "Charger's Bindings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 119;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(War Torn Bands)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornBands : Item
	{
		public WarTornBands() : base()
		{
			Id = 15482;
			Resistance[0] = 48;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 26952;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "War Torn Bands";
			Name2 = "War Torn Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 271;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredWristbands : Item
	{
		public BloodspatteredWristbands() : base()
		{
			Id = 15495;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 220;
			AvailableClasses = 0x7FFF;
			Model = 27005;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Bloodspattered Wristbands";
			Name2 = "Bloodspattered Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1085;
			BuyPrice = 1100;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersCuffs : Item
	{
		public OutrunnersCuffs() : base()
		{
			Id = 15499;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 307;
			AvailableClasses = 0x7FFF;
			Model = 26993;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Outrunner's Cuffs";
			Name2 = "Outrunner's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1086;
			BuyPrice = 1535;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Grunt's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsBracers : Item
	{
		public GruntsBracers() : base()
		{
			Id = 15507;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 364;
			AvailableClasses = 0x7FFF;
			Model = 26971;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Grunt's Bracers";
			Name2 = "Grunt's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1087;
			BuyPrice = 1820;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainWristbands : Item
	{
		public SpikedChainWristbands() : base()
		{
			Id = 15517;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 850;
			AvailableClasses = 0x7FFF;
			Model = 24793;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Spiked Chain Wristbands";
			Name2 = "Spiked Chain Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1089;
			BuyPrice = 4254;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sentry's Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysArmsplints : Item
	{
		public SentrysArmsplints() : base()
		{
			Id = 15532;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 944;
			AvailableClasses = 0x7FFF;
			Model = 27074;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Sentry's Armsplints";
			Name2 = "Sentry's Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1089;
			BuyPrice = 4722;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainBracers : Item
	{
		public WickedChainBracers() : base()
		{
			Id = 15535;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 1270;
			AvailableClasses = 0x7FFF;
			Model = 27038;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Wicked Chain Bracers";
			Name2 = "Wicked Chain Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1090;
			BuyPrice = 6352;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleBracelets : Item
	{
		public ThickScaleBracelets() : base()
		{
			Id = 15545;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 1348;
			AvailableClasses = 0x7FFF;
			Model = 27017;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Thick Scale Bracelets";
			Name2 = "Thick Scale Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1090;
			BuyPrice = 6740;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Pillager's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersBracers : Item
	{
		public PillagersBracers() : base()
		{
			Id = 15556;
			Resistance[0] = 89;
			Bonding = 2;
			SellPrice = 1697;
			AvailableClasses = 0x7FFF;
			Model = 27066;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Pillager's Bracers";
			Name2 = "Pillager's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1091;
			BuyPrice = 8485;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Marauder's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersBracers : Item
	{
		public MaraudersBracers() : base()
		{
			Id = 15566;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 2178;
			AvailableClasses = 0x7FFF;
			Model = 27058;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Marauder's Bracers";
			Name2 = "Marauder's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1092;
			BuyPrice = 10894;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellBracers : Item
	{
		public SparkleshellBracers() : base()
		{
			Id = 15577;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 2317;
			AvailableClasses = 0x7FFF;
			Model = 27111;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Sparkleshell Bracers";
			Name2 = "Sparkleshell Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1092;
			BuyPrice = 11587;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Steadfast Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastBracelets : Item
	{
		public SteadfastBracelets() : base()
		{
			Id = 15590;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 2674;
			AvailableClasses = 0x7FFF;
			Model = 27895;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Steadfast Bracelets";
			Name2 = "Steadfast Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1093;
			BuyPrice = 13373;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ancient Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class AncientVambraces : Item
	{
		public AncientVambraces() : base()
		{
			Id = 15600;
			Resistance[0] = 104;
			Bonding = 2;
			SellPrice = 3787;
			AvailableClasses = 0x7FFF;
			Model = 27122;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Ancient Vambraces";
			Name2 = "Ancient Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1094;
			BuyPrice = 18938;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bonelink Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkBracers : Item
	{
		public BonelinkBracers() : base()
		{
			Id = 15610;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 4354;
			AvailableClasses = 0x7FFF;
			Model = 27324;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Bonelink Bracers";
			Name2 = "Bonelink Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1095;
			BuyPrice = 21770;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailBracelets : Item
	{
		public GryphonMailBracelets() : base()
		{
			Id = 15620;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 5564;
			AvailableClasses = 0x7FFF;
			Model = 27128;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Gryphon Mail Bracelets";
			Name2 = "Gryphon Mail Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1096;
			BuyPrice = 27824;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Formidable Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableBracers : Item
	{
		public FormidableBracers() : base()
		{
			Id = 15629;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 6374;
			AvailableClasses = 0x7FFF;
			Model = 27208;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Formidable Bracers";
			Name2 = "Formidable Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1096;
			BuyPrice = 31871;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ironhide Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideBracers : Item
	{
		public IronhideBracers() : base()
		{
			Id = 15639;
			Resistance[0] = 119;
			Bonding = 2;
			SellPrice = 7040;
			AvailableClasses = 0x7FFF;
			Model = 27170;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Ironhide Bracers";
			Name2 = "Ironhide Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1097;
			BuyPrice = 35200;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Merciless Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessBracers : Item
	{
		public MercilessBracers() : base()
		{
			Id = 15649;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 7808;
			AvailableClasses = 0x7FFF;
			Model = 27286;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Merciless Bracers";
			Name2 = "Merciless Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1097;
			BuyPrice = 39041;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableBindings : Item
	{
		public ImpenetrableBindings() : base()
		{
			Id = 15659;
			Resistance[0] = 130;
			Bonding = 2;
			SellPrice = 9508;
			AvailableClasses = 0x7FFF;
			Model = 27296;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Impenetrable Bindings";
			Name2 = "Impenetrable Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1099;
			BuyPrice = 47540;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Magnificent Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentBracers : Item
	{
		public MagnificentBracers() : base()
		{
			Id = 15668;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 11697;
			AvailableClasses = 0x7FFF;
			Model = 27314;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Magnificent Bracers";
			Name2 = "Magnificent Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1100;
			BuyPrice = 58488;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Triumphant Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantBracers : Item
	{
		public TriumphantBracers() : base()
		{
			Id = 15679;
			Resistance[0] = 143;
			Bonding = 2;
			SellPrice = 13108;
			AvailableClasses = 0x7FFF;
			Model = 27307;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Triumphant Bracers";
			Name2 = "Triumphant Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1101;
			BuyPrice = 65540;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Seaspray Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SeasprayBracers : Item
	{
		public SeasprayBracers() : base()
		{
			Id = 15796;
			Resistance[0] = 139;
			Bonding = 1;
			SellPrice = 12063;
			AvailableClasses = 0x7FFF;
			Model = 26475;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			Name = "Seaspray Bracers";
			Name2 = "Seaspray Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60317;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 12;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Mail Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsMailWristguards : Item
	{
		public FirstSergeantsMailWristguards() : base()
		{
			Id = 16532;
			Resistance[0] = 162;
			Bonding = 1;
			SellPrice = 8960;
			AvailableClasses = 0x44;
			Model = 27277;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "First Sergeant's Mail Wristguards";
			Name2 = "First Sergeant's Mail Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44802;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			StaminaBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Bindings of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class BindingsOfElements : Item
	{
		public BindingsOfElements() : base()
		{
			Id = 16671;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 12586;
			AvailableClasses = 0x7FFF;
			Model = 31411;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Bindings of Elements";
			Name2 = "Bindings of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62932;
			Sets = 187;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SpiritBonus = 10;
			IqBonus = 10;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersBindings : Item
	{
		public BeaststalkersBindings() : base()
		{
			Id = 16681;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 13055;
			AvailableClasses = 0x7FFF;
			Model = 31405;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Beaststalker's Bindings";
			Name2 = "Beaststalker's Bindings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65275;
			Sets = 186;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			AgilityBonus = 15;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Gripsteel Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class GripsteelWristguards : Item
	{
		public GripsteelWristguards() : base()
		{
			Id = 16794;
			Resistance[0] = 98;
			Bonding = 1;
			SellPrice = 2705;
			AvailableClasses = 0x7FFF;
			Model = 23729;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			Name = "Gripsteel Wristguards";
			Name2 = "Gripsteel Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13525;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 5;
			StrBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Earthfury Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryBracers : Item
	{
		public EarthfuryBracers() : base()
		{
			Id = 16840;
			Resistance[0] = 185;
			Bonding = 2;
			SellPrice = 25879;
			AvailableClasses = 0x40;
			Model = 31831;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Bracers";
			Name2 = "Earthfury Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 129398;
			Sets = 207;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 9396 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 11;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersBracers : Item
	{
		public GiantstalkersBracers() : base()
		{
			Id = 16850;
			Resistance[0] = 185;
			Bonding = 2;
			SellPrice = 27564;
			AvailableClasses = 0x04;
			Model = 32021;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Bracers";
			Name2 = "Giantstalker's Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 137824;
			Sets = 206;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 20;
			SpiritBonus = 6;
			IqBonus = 5;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersBracers : Item
	{
		public DragonstalkersBracers() : base()
		{
			Id = 16935;
			Resistance[0] = 211;
			Bonding = 1;
			SellPrice = 42481;
			AvailableClasses = 0x04;
			Model = 29810;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Bracers";
			Name2 = "Dragonstalker's Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 212405;
			Sets = 215;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 23;
			SpiritBonus = 6;
			IqBonus = 6;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bracers of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfTenStorms : Item
	{
		public BracersOfTenStorms() : base()
		{
			Id = 16943;
			Resistance[0] = 211;
			Bonding = 1;
			SellPrice = 44904;
			AvailableClasses = 0x40;
			Model = 29787;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Bracers of Ten Storms";
			Name2 = "Bracers of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 224522;
			Sets = 216;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 18379 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
			IqBonus = 9;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bracers of the Stone Princess)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfTheStonePrincess : Item
	{
		public BracersOfTheStonePrincess() : base()
		{
			Id = 17714;
			Resistance[0] = 141;
			Bonding = 1;
			SellPrice = 10225;
			AvailableClasses = 0x7FFF;
			Model = 29890;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Bracers of the Stone Princess";
			Name2 = "Bracers of the Stone Princess";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51128;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Marksman Bands)
*
***************************************************************/

namespace Server.Items
{
	public class MarksmanBands : Item
	{
		public MarksmanBands() : base()
		{
			Id = 18296;
			Resistance[0] = 146;
			Bonding = 1;
			SellPrice = 11489;
			AvailableClasses = 0x7FFF;
			Model = 30643;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Marksman Bands";
			Name2 = "Marksman Bands";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57448;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 7570 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22811 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7582 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 12;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Demon Howl Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class DemonHowlWristguards : Item
	{
		public DemonHowlWristguards() : base()
		{
			Id = 18394;
			Resistance[0] = 160;
			Bonding = 1;
			SellPrice = 17133;
			AvailableClasses = 0x7FFF;
			Model = 30753;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Demon Howl Wristguards";
			Name2 = "Demon Howl Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85666;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 9142 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Mail Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsMailWristguards18432 : Item
	{
		public FirstSergeantsMailWristguards18432() : base()
		{
			Id = 18432;
			Resistance[0] = 131;
			Bonding = 1;
			SellPrice = 4348;
			AvailableClasses = 0x44;
			Model = 27277;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "First Sergeant's Mail Wristguards";
			Name2 = "First Sergeant's Mail Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21742;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Chain Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsChainArmguards : Item
	{
		public SergeantMajorsChainArmguards() : base()
		{
			Id = 18448;
			Resistance[0] = 162;
			Bonding = 1;
			SellPrice = 8801;
			AvailableClasses = 0x04;
			Model = 31248;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant Major's Chain Armguards";
			Name2 = "Sergeant Major's Chain Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44007;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			StaminaBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Chain Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsChainArmguards18449 : Item
	{
		public SergeantMajorsChainArmguards18449() : base()
		{
			Id = 18449;
			Resistance[0] = 131;
			Bonding = 1;
			SellPrice = 4301;
			AvailableClasses = 0x04;
			Model = 31248;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant Major's Chain Armguards";
			Name2 = "Sergeant Major's Chain Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21507;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Modest Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class ModestArmguards : Item
	{
		public ModestArmguards() : base()
		{
			Id = 18458;
			Resistance[0] = 141;
			Bonding = 1;
			SellPrice = 12212;
			AvailableClasses = 0x7FFF;
			Model = 26103;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Modest Armguards";
			Name2 = "Modest Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61064;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Swift Flight Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftFlightBracers : Item
	{
		public SwiftFlightBracers() : base()
		{
			Id = 18508;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 17194;
			AvailableClasses = 0x7FFF;
			Model = 30848;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Swift Flight Bracers";
			Name2 = "Swift Flight Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85970;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 21442 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Arena Bands)
*
***************************************************************/

namespace Server.Items
{
	public class ArenaBands : Item
	{
		public ArenaBands() : base()
		{
			Id = 18711;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 8700;
			AvailableClasses = 0x7FFF;
			Model = 31160;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Arena Bands";
			Name2 = "Arena Bands";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43502;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Wristguards of True Flight)
*
***************************************************************/

namespace Server.Items
{
	public class WristguardsOfTrueFlight : Item
	{
		public WristguardsOfTrueFlight() : base()
		{
			Id = 18812;
			Resistance[0] = 198;
			Bonding = 1;
			SellPrice = 32458;
			AvailableClasses = 0x7FFF;
			Model = 31280;
			ObjectClass = 4;
			SubClass = 3;
			Level = 71;
			ReqLevel = 60;
			Name = "Wristguards of True Flight";
			Name2 = "Wristguards of True Flight";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 162290;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 19;
			StaminaBonus = 11;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Windtalker's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class WindtalkersWristguards : Item
	{
		public WindtalkersWristguards() : base()
		{
			Id = 19582;
			Resistance[0] = 182;
			Bonding = 1;
			SellPrice = 24220;
			AvailableClasses = 0x7FFF;
			Model = 32089;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Windtalker's Wristguards";
			Name2 = "Windtalker's Wristguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 121103;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 15808 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			IqBonus = 7;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Windtalker's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class WindtalkersWristguards19583 : Item
	{
		public WindtalkersWristguards19583() : base()
		{
			Id = 19583;
			Resistance[0] = 156;
			Bonding = 1;
			SellPrice = 14452;
			AvailableClasses = 0x7FFF;
			Model = 32089;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Windtalker's Wristguards";
			Name2 = "Windtalker's Wristguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 72262;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 15806 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Windtalker's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class WindtalkersWristguards19584 : Item
	{
		public WindtalkersWristguards19584() : base()
		{
			Id = 19584;
			Resistance[0] = 130;
			Bonding = 1;
			SellPrice = 7418;
			AvailableClasses = 0x7FFF;
			Model = 32089;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Windtalker's Wristguards";
			Name2 = "Windtalker's Wristguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 37090;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 5;
			StaminaBonus = 6;
		}
	}
}


