/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:57 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Sparkmetal Coif)
*
***************************************************************/

namespace Server.Items
{
	public class SparkmetalCoif : Item
	{
		public SparkmetalCoif() : base()
		{
			Id = 1282;
			Resistance[0] = 168;
			Bonding = 1;
			SellPrice = 2825;
			AvailableClasses = 0x7FFF;
			Model = 15324;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			Name = "Sparkmetal Coif";
			Name2 = "Sparkmetal Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14125;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 9;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Skullsplitter Helm)
*
***************************************************************/

namespace Server.Items
{
	public class SkullsplitterHelm : Item
	{
		public SkullsplitterHelm() : base()
		{
			Id = 1624;
			Resistance[0] = 196;
			Bonding = 2;
			SellPrice = 6172;
			AvailableClasses = 0x7FFF;
			Model = 15340;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Skullsplitter Helm";
			Name2 = "Skullsplitter Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30862;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 12;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Helm of Narv)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfNarv : Item
	{
		public HelmOfNarv() : base()
		{
			Id = 2245;
			Resistance[0] = 309;
			Bonding = 2;
			SellPrice = 27636;
			AvailableClasses = 0x7FFF;
			Model = 15506;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Helm of Narv";
			Name2 = "Helm of Narv";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 138183;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			AgilityBonus = 13;
			IqBonus = 18;
			StaminaBonus = 32;
		}
	}
}


/**************************************************************
*
*				(Demon Hunter Blindfold)
*
***************************************************************/

namespace Server.Items
{
	public class DemonHunterBlindfold : Item
	{
		public DemonHunterBlindfold() : base()
		{
			Id = 3536;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 13564;
			ObjectClass = 4;
			SubClass = 3;
			Level = 1;
			ReqLevel = 1;
			Name = "Demon Hunter Blindfold";
			Name2 = "Demon Hunter Blindfold";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Green Iron Helm)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronHelm : Item
	{
		public GreenIronHelm() : base()
		{
			Id = 3836;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 3053;
			AvailableClasses = 0x7FFF;
			Model = 25658;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Green Iron Helm";
			Name2 = "Green Iron Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15268;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 11;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Coif)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleCoif : Item
	{
		public GoldenScaleCoif() : base()
		{
			Id = 3837;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 4405;
			AvailableClasses = 0x7FFF;
			Model = 15333;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Golden Scale Coif";
			Name2 = "Golden Scale Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22027;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Helm)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainHelm : Item
	{
		public AugmentedChainHelm() : base()
		{
			Id = 3891;
			Resistance[0] = 169;
			SellPrice = 2456;
			AvailableClasses = 0x7FFF;
			Model = 15318;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Helm";
			Name2 = "Augmented Chain Helm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12284;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Brigandine Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineHelm : Item
	{
		public BrigandineHelm() : base()
		{
			Id = 3894;
			Resistance[0] = 211;
			SellPrice = 5997;
			AvailableClasses = 0x7FFF;
			Model = 15320;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Helm";
			Name2 = "Brigandine Helm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 29986;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatHeadguard : Item
	{
		public MailCombatHeadguard() : base()
		{
			Id = 4077;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 3298;
			AvailableClasses = 0x7FFF;
			Model = 25825;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Mail Combat Headguard";
			Name2 = "Mail Combat Headguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16494;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Coif)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierCoif : Item
	{
		public ChiefBrigadierCoif() : base()
		{
			Id = 4078;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 4672;
			AvailableClasses = 0x7FFF;
			Model = 25904;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Chief Brigadier Coif";
			Name2 = "Chief Brigadier Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23364;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 11;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blackforge Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeCowl : Item
	{
		public BlackforgeCowl() : base()
		{
			Id = 4080;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 7469;
			AvailableClasses = 0x7FFF;
			Model = 15290;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Blackforge Cowl";
			Name2 = "Blackforge Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37346;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 12;
			SpiritBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sunblaze Coif)
*
***************************************************************/

namespace Server.Items
{
	public class SunblazeCoif : Item
	{
		public SunblazeCoif() : base()
		{
			Id = 5819;
			Resistance[0] = 185;
			Bonding = 2;
			SellPrice = 3201;
			AvailableClasses = 0x7FFF;
			Model = 15810;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Sunblaze Coif";
			Name2 = "Sunblaze Coif";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16009;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Coif)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailCoif : Item
	{
		public GlimmeringMailCoif() : base()
		{
			Id = 6389;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 2245;
			AvailableClasses = 0x7FFF;
			Model = 15517;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Glimmering Mail Coif";
			Name2 = "Glimmering Mail Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11229;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 7;
			AgilityBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tusken Helm)
*
***************************************************************/

namespace Server.Items
{
	public class TuskenHelm : Item
	{
		public TuskenHelm() : base()
		{
			Id = 6686;
			Resistance[0] = 168;
			Bonding = 1;
			SellPrice = 2627;
			AvailableClasses = 0x7FFF;
			Model = 15492;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Tusken Helm";
			Name2 = "Tusken Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13135;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Fire Hardened Coif)
*
***************************************************************/

namespace Server.Items
{
	public class FireHardenedCoif : Item
	{
		public FireHardenedCoif() : base()
		{
			Id = 6971;
			Resistance[0] = 163;
			Bonding = 1;
			SellPrice = 2221;
			AvailableClasses = 0x01;
			Model = 15327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			Name = "Fire Hardened Coif";
			Name2 = "Fire Hardened Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11105;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Brutal Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalHelm : Item
	{
		public BrutalHelm() : base()
		{
			Id = 7130;
			Resistance[0] = 163;
			Bonding = 1;
			SellPrice = 2328;
			AvailableClasses = 0x01;
			Model = 15288;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			Name = "Brutal Helm";
			Name2 = "Brutal Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11642;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Phalanx Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxHeadguard : Item
	{
		public PhalanxHeadguard() : base()
		{
			Id = 7420;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 2658;
			AvailableClasses = 0x7FFF;
			Model = 30091;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Phalanx Headguard";
			Name2 = "Phalanx Headguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 671;
			BuyPrice = 13290;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Knight's Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsHeadguard : Item
	{
		public KnightsHeadguard() : base()
		{
			Id = 7456;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 4139;
			AvailableClasses = 0x7FFF;
			Model = 30092;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Knight's Headguard";
			Name2 = "Knight's Headguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 673;
			BuyPrice = 20695;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Captain's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsCirclet : Item
	{
		public CaptainsCirclet() : base()
		{
			Id = 7488;
			Resistance[0] = 193;
			Bonding = 2;
			SellPrice = 6038;
			AvailableClasses = 0x7FFF;
			Model = 25824;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Captain's Circlet";
			Name2 = "Captain's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 674;
			BuyPrice = 30193;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Champion's Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsHelmet : Item
	{
		public ChampionsHelmet() : base()
		{
			Id = 7540;
			Resistance[0] = 210;
			Bonding = 2;
			SellPrice = 8845;
			AvailableClasses = 0x7FFF;
			Model = 26098;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Champion's Helmet";
			Name2 = "Champion's Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 676;
			BuyPrice = 44228;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Raging Berserker's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class RagingBerserkersHelm : Item
	{
		public RagingBerserkersHelm() : base()
		{
			Id = 7719;
			Resistance[0] = 213;
			Bonding = 1;
			SellPrice = 6863;
			AvailableClasses = 0x7FFF;
			Model = 15811;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Raging Berserker's Helm";
			Name2 = "Raging Berserker's Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34315;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Barbaric Iron Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricIronHelm : Item
	{
		public BarbaricIronHelm() : base()
		{
			Id = 7915;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 3337;
			AvailableClasses = 0x7FFF;
			Model = 16084;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Barbaric Iron Helm";
			Name2 = "Barbaric Iron Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16686;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 9;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Mithril Coif)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilCoif : Item
	{
		public MithrilCoif() : base()
		{
			Id = 7931;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 7955;
			AvailableClasses = 0x7FFF;
			Model = 16110;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Mithril Coif";
			Name2 = "Mithril Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39778;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			IqBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsHelm : Item
	{
		public MyrmidonsHelm() : base()
		{
			Id = 8131;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 10115;
			AvailableClasses = 0x7FFF;
			Model = 26115;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Myrmidon's Helm";
			Name2 = "Myrmidon's Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50576;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 7;
			SpiritBonus = 11;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Turtle Scale Helm)
*
***************************************************************/

namespace Server.Items
{
	public class TurtleScaleHelm : Item
	{
		public TurtleScaleHelm() : base()
		{
			Id = 8191;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 7780;
			AvailableClasses = 0x7FFF;
			Model = 16492;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Turtle Scale Helm";
			Name2 = "Turtle Scale Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38900;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 10;
			IqBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidHelm : Item
	{
		public ToughScorpidHelm() : base()
		{
			Id = 8208;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 10272;
			AvailableClasses = 0x7FFF;
			Model = 16520;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Tough Scorpid Helm";
			Name2 = "Tough Scorpid Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51360;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 14;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdHelmet : Item
	{
		public EbonholdHelmet() : base()
		{
			Id = 8270;
			Resistance[0] = 242;
			Bonding = 2;
			SellPrice = 14351;
			AvailableClasses = 0x7FFF;
			Model = 26220;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Ebonhold Helmet";
			Name2 = "Ebonhold Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71758;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Hero's Band)
*
***************************************************************/

namespace Server.Items
{
	public class HerosBand : Item
	{
		public HerosBand() : base()
		{
			Id = 8308;
			Resistance[0] = 262;
			Bonding = 2;
			SellPrice = 18703;
			AvailableClasses = 0x7FFF;
			Model = 26315;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Hero's Band";
			Name2 = "Hero's Band";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93517;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 9;
			StaminaBonus = 14;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Double Mail Coif)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailCoif : Item
	{
		public DoubleMailCoif() : base()
		{
			Id = 8748;
			Resistance[0] = 145;
			SellPrice = 774;
			AvailableClasses = 0x7FFF;
			Model = 28389;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Double Mail Coif";
			Name2 = "Double Mail Coif";
			AvailableRaces = 0x1FF;
			BuyPrice = 3874;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Overlinked Coif)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedCoif : Item
	{
		public OverlinkedCoif() : base()
		{
			Id = 8751;
			Resistance[0] = 179;
			SellPrice = 2618;
			AvailableClasses = 0x7FFF;
			Model = 28393;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Overlinked Coif";
			Name2 = "Overlinked Coif";
			AvailableRaces = 0x1FF;
			BuyPrice = 13091;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleCirclet : Item
	{
		public LaminatedScaleCirclet() : base()
		{
			Id = 8752;
			Resistance[0] = 214;
			SellPrice = 5217;
			AvailableClasses = 0x7FFF;
			Model = 28391;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Laminated Scale Circlet";
			Name2 = "Laminated Scale Circlet";
			AvailableRaces = 0x1FF;
			BuyPrice = 26086;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Renegade Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeCirclet : Item
	{
		public RenegadeCirclet() : base()
		{
			Id = 9870;
			Resistance[0] = 176;
			Bonding = 2;
			SellPrice = 3686;
			AvailableClasses = 0x7FFF;
			Model = 25991;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Renegade Circlet";
			Name2 = "Renegade Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 672;
			BuyPrice = 18430;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Helm)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintHelm : Item
	{
		public JazeraintHelm() : base()
		{
			Id = 9902;
			Resistance[0] = 190;
			Bonding = 2;
			SellPrice = 5357;
			AvailableClasses = 0x7FFF;
			Model = 27789;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Jazeraint Helm";
			Name2 = "Jazeraint Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 674;
			BuyPrice = 26786;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Brigade Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeCirclet : Item
	{
		public BrigadeCirclet() : base()
		{
			Id = 9932;
			Resistance[0] = 199;
			Bonding = 2;
			SellPrice = 6995;
			AvailableClasses = 0x7FFF;
			Model = 25937;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Brigade Circlet";
			Name2 = "Brigade Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 675;
			BuyPrice = 34977;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersCirclet : Item
	{
		public WarmongersCirclet() : base()
		{
			Id = 9963;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 9211;
			AvailableClasses = 0x7FFF;
			Model = 26200;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Warmonger's Circlet";
			Name2 = "Warmonger's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 676;
			BuyPrice = 46058;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Lord's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class LordsCrown : Item
	{
		public LordsCrown() : base()
		{
			Id = 10083;
			Resistance[0] = 226;
			Bonding = 2;
			SellPrice = 10745;
			AvailableClasses = 0x7FFF;
			Model = 26330;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Lord's Crown";
			Name2 = "Lord's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 677;
			BuyPrice = 53728;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ornate Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateCirclet : Item
	{
		public OrnateCirclet() : base()
		{
			Id = 10123;
			Resistance[0] = 250;
			Bonding = 2;
			SellPrice = 15239;
			AvailableClasses = 0x7FFF;
			Model = 26303;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Ornate Circlet";
			Name2 = "Ornate Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 679;
			BuyPrice = 76198;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Mercurial Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialCirclet : Item
	{
		public MercurialCirclet() : base()
		{
			Id = 10160;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 19948;
			AvailableClasses = 0x7FFF;
			Model = 26139;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Mercurial Circlet";
			Name2 = "Mercurial Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 681;
			BuyPrice = 99741;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Crusader's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersHelm : Item
	{
		public CrusadersHelm() : base()
		{
			Id = 10198;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 12167;
			AvailableClasses = 0x7FFF;
			Model = 26172;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Crusader's Helm";
			Name2 = "Crusader's Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 678;
			BuyPrice = 60837;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Engraved Helm)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedHelm : Item
	{
		public EngravedHelm() : base()
		{
			Id = 10235;
			Resistance[0] = 258;
			Bonding = 2;
			SellPrice = 16896;
			AvailableClasses = 0x7FFF;
			Model = 26274;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Engraved Helm";
			Name2 = "Engraved Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 680;
			BuyPrice = 84481;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Masterwork Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkCirclet : Item
	{
		public MasterworkCirclet() : base()
		{
			Id = 10272;
			Resistance[0] = 274;
			Bonding = 2;
			SellPrice = 20865;
			AvailableClasses = 0x7FFF;
			Model = 27804;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Masterwork Circlet";
			Name2 = "Masterwork Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 681;
			BuyPrice = 104328;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Banded Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BandedHelm : Item
	{
		public BandedHelm() : base()
		{
			Id = 10408;
			Resistance[0] = 166;
			Bonding = 2;
			SellPrice = 2390;
			AvailableClasses = 0x7FFF;
			Model = 27774;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Banded Helm";
			Name2 = "Banded Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 671;
			BuyPrice = 11951;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Goblin Mining Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinMiningHelmet : Item
	{
		public GoblinMiningHelmet() : base()
		{
			Id = 10542;
			Resistance[0] = 190;
			Bonding = 1;
			SellPrice = 5255;
			AvailableClasses = 0x7FFF;
			Model = 20813;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			Name = "Goblin Mining Helmet";
			Name2 = "Goblin Mining Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 26279;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 12560 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Drakefire Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class DrakefireHeadguard : Item
	{
		public DrakefireHeadguard() : base()
		{
			Id = 10743;
			Resistance[0] = 226;
			Bonding = 1;
			SellPrice = 10830;
			AvailableClasses = 0x7FFF;
			Model = 28143;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			Name = "Drakefire Headguard";
			Name2 = "Drakefire Headguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54150;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 5;
			SpiritBonus = 9;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Horns of Eranikus)
*
***************************************************************/

namespace Server.Items
{
	public class HornsOfEranikus : Item
	{
		public HornsOfEranikus() : base()
		{
			Id = 10833;
			Resistance[0] = 271;
			Bonding = 1;
			SellPrice = 8597;
			AvailableClasses = 0x7FFF;
			Model = 19838;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Horns of Eranikus";
			Name2 = "Horns of Eranikus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42986;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			IqBonus = 11;
			SpiritBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Helm of Exile)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfExile : Item
	{
		public HelmOfExile() : base()
		{
			Id = 11124;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 16980;
			AvailableClasses = 0x7FFF;
			Model = 28196;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			Name = "Helm of Exile";
			Name2 = "Helm of Exile";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84900;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			IqBonus = 18;
			SpiritBonus = 18;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Savage Gladiator Helm)
*
***************************************************************/

namespace Server.Items
{
	public class SavageGladiatorHelm : Item
	{
		public SavageGladiatorHelm() : base()
		{
			Id = 11729;
			Resistance[0] = 275;
			Bonding = 1;
			SellPrice = 19073;
			AvailableClasses = 0x7FFF;
			Model = 28826;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Savage Gladiator Helm";
			Name2 = "Savage Gladiator Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 95365;
			Sets = 1;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 28;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Clayridge Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ClayridgeHelm : Item
	{
		public ClayridgeHelm() : base()
		{
			Id = 11913;
			Resistance[0] = 242;
			Bonding = 1;
			SellPrice = 14044;
			AvailableClasses = 0x7FFF;
			Model = 28132;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			Name = "Clayridge Helm";
			Name2 = "Clayridge Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 70224;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Conservator Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ConservatorHelm : Item
	{
		public ConservatorHelm() : base()
		{
			Id = 12018;
			Resistance[0] = 238;
			Bonding = 1;
			SellPrice = 13842;
			AvailableClasses = 0x7FFF;
			Model = 28135;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			Name = "Conservator Helm";
			Name2 = "Conservator Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 69211;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Radiant Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantCirclet : Item
	{
		public RadiantCirclet() : base()
		{
			Id = 12417;
			Resistance[0] = 258;
			Bonding = 2;
			SellPrice = 17034;
			AvailableClasses = 0x7FFF;
			Model = 25826;
			Resistance[4] = 18;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Radiant Circlet";
			Name2 = "Radiant Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85174;
			Resistance[5] = 18;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Braincage)
*
***************************************************************/

namespace Server.Items
{
	public class Braincage : Item
	{
		public Braincage() : base()
		{
			Id = 12549;
			Resistance[0] = 253;
			Bonding = 2;
			SellPrice = 13669;
			AvailableClasses = 0x7FFF;
			Model = 15501;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Braincage";
			Name2 = "Braincage";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68349;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 25;
			IqBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Helm of the Great Chief)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfTheGreatChief : Item
	{
		public HelmOfTheGreatChief() : base()
		{
			Id = 12636;
			Resistance[0] = 292;
			Bonding = 2;
			SellPrice = 24285;
			AvailableClasses = 0x7FFF;
			Model = 22908;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Helm of the Great Chief";
			Name2 = "Helm of the Great Chief";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 121428;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 12;
			IqBonus = 30;
		}
	}
}


/**************************************************************
*
*				(Dragoneye Coif)
*
***************************************************************/

namespace Server.Items
{
	public class DragoneyeCoif : Item
	{
		public DragoneyeCoif() : base()
		{
			Id = 12953;
			Resistance[0] = 274;
			Bonding = 1;
			SellPrice = 21584;
			AvailableClasses = 0x7FFF;
			Model = 15327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Dragoneye Coif";
			Name2 = "Dragoneye Coif";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 107923;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Frostreaver Crown)
*
***************************************************************/

namespace Server.Items
{
	public class FrostreaverCrown : Item
	{
		public FrostreaverCrown() : base()
		{
			Id = 13127;
			Resistance[0] = 182;
			Bonding = 2;
			SellPrice = 3021;
			AvailableClasses = 0x7FFF;
			Model = 28440;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Frostreaver Crown";
			Name2 = "Frostreaver Crown";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15107;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 15;
			StrBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(High Bergg Helm)
*
***************************************************************/

namespace Server.Items
{
	public class HighBerggHelm : Item
	{
		public HighBerggHelm() : base()
		{
			Id = 13128;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 10543;
			AvailableClasses = 0x7FFF;
			Model = 28662;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "High Bergg Helm";
			Name2 = "High Bergg Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52717;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			IqBonus = 15;
			StaminaBonus = 10;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Crown of Tyranny)
*
***************************************************************/

namespace Server.Items
{
	public class CrownOfTyranny : Item
	{
		public CrownOfTyranny() : base()
		{
			Id = 13359;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 25336;
			AvailableClasses = 0x7FFF;
			Model = 24045;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Crown of Tyranny";
			Name2 = "Crown of Tyranny";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 126683;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			IqBonus = -10;
		}
	}
}


/**************************************************************
*
*				(Slayer's Skullcap)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersSkullcap : Item
	{
		public SlayersSkullcap() : base()
		{
			Id = 14753;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 2610;
			AvailableClasses = 0x7FFF;
			Model = 27191;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Slayer's Skullcap";
			Name2 = "Slayer's Skullcap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13052;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 9;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enduring Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringCirclet : Item
	{
		public EnduringCirclet() : base()
		{
			Id = 14765;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 4427;
			AvailableClasses = 0x7FFF;
			Model = 27052;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Enduring Circlet";
			Name2 = "Enduring Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22139;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 12;
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ravager's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersCrown : Item
	{
		public RavagersCrown() : base()
		{
			Id = 14774;
			Resistance[0] = 196;
			Bonding = 2;
			SellPrice = 6252;
			AvailableClasses = 0x7FFF;
			Model = 28175;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Ravager's Crown";
			Name2 = "Ravager's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31262;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 15;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Khan's Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class KhansHelmet : Item
	{
		public KhansHelmet() : base()
		{
			Id = 14785;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 9558;
			AvailableClasses = 0x7FFF;
			Model = 27151;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Khan's Helmet";
			Name2 = "Khan's Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47794;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 16;
			AgilityBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Protector Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorHelm : Item
	{
		public ProtectorHelm() : base()
		{
			Id = 14795;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 12690;
			AvailableClasses = 0x7FFF;
			Model = 26115;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Protector Helm";
			Name2 = "Protector Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63454;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 20;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustHelm : Item
	{
		public BloodlustHelm() : base()
		{
			Id = 14804;
			Resistance[0] = 254;
			Bonding = 2;
			SellPrice = 16296;
			AvailableClasses = 0x7FFF;
			Model = 30800;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Bloodlust Helm";
			Name2 = "Bloodlust Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81482;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 18;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Warstrike Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeHelmet : Item
	{
		public WarstrikeHelmet() : base()
		{
			Id = 14814;
			Resistance[0] = 274;
			Bonding = 2;
			SellPrice = 21593;
			AvailableClasses = 0x7FFF;
			Model = 28986;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Warstrike Helmet";
			Name2 = "Warstrike Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 107967;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 23;
			AgilityBonus = 10;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Helm)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidHelm : Item
	{
		public HeavyScorpidHelm() : base()
		{
			Id = 15080;
			Resistance[0] = 258;
			Bonding = 2;
			SellPrice = 18230;
			AvailableClasses = 0x7FFF;
			Model = 28976;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Heavy Scorpid Helm";
			Name2 = "Heavy Scorpid Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91152;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 20;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Sentry's Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysHeaddress : Item
	{
		public SentrysHeaddress() : base()
		{
			Id = 15533;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 2290;
			AvailableClasses = 0x7FFF;
			Model = 27083;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Sentry's Headdress";
			Name2 = "Sentry's Headdress";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 671;
			BuyPrice = 11450;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainHelmet : Item
	{
		public WickedChainHelmet() : base()
		{
			Id = 15540;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 2827;
			AvailableClasses = 0x7FFF;
			Model = 27042;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Wicked Chain Helmet";
			Name2 = "Wicked Chain Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 672;
			BuyPrice = 14139;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Crown)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleCrown : Item
	{
		public ThickScaleCrown() : base()
		{
			Id = 15550;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 3316;
			AvailableClasses = 0x7FFF;
			Model = 30091;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Thick Scale Crown";
			Name2 = "Thick Scale Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 672;
			BuyPrice = 16582;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Pillager's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersCrown : Item
	{
		public PillagersCrown() : base()
		{
			Id = 15558;
			Resistance[0] = 178;
			Bonding = 2;
			SellPrice = 4128;
			AvailableClasses = 0x7FFF;
			Model = 27073;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Pillager's Crown";
			Name2 = "Pillager's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 673;
			BuyPrice = 20643;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Marauder's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersCirclet : Item
	{
		public MaraudersCirclet() : base()
		{
			Id = 15572;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 4714;
			AvailableClasses = 0x7FFF;
			Model = 30092;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Marauder's Circlet";
			Name2 = "Marauder's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 673;
			BuyPrice = 23571;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Headwrap)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellHeadwrap : Item
	{
		public SparkleshellHeadwrap() : base()
		{
			Id = 15580;
			Resistance[0] = 187;
			Bonding = 2;
			SellPrice = 4871;
			AvailableClasses = 0x7FFF;
			Model = 15517;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Sparkleshell Headwrap";
			Name2 = "Sparkleshell Headwrap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 674;
			BuyPrice = 24357;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Steadfast Coronet)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastCoronet : Item
	{
		public SteadfastCoronet() : base()
		{
			Id = 15593;
			Resistance[0] = 193;
			Bonding = 2;
			SellPrice = 5532;
			AvailableClasses = 0x7FFF;
			Model = 27898;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Steadfast Coronet";
			Name2 = "Steadfast Coronet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 674;
			BuyPrice = 27663;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ancient Crown)
*
***************************************************************/

namespace Server.Items
{
	public class AncientCrown : Item
	{
		public AncientCrown() : base()
		{
			Id = 15602;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 7211;
			AvailableClasses = 0x7FFF;
			Model = 27124;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Ancient Crown";
			Name2 = "Ancient Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 675;
			BuyPrice = 36055;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Bonelink Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkHelmet : Item
	{
		public BonelinkHelmet() : base()
		{
			Id = 15615;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 7584;
			AvailableClasses = 0x7FFF;
			Model = 26098;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Bonelink Helmet";
			Name2 = "Bonelink Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 676;
			BuyPrice = 37920;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Crown)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailCrown : Item
	{
		public GryphonMailCrown() : base()
		{
			Id = 15623;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 10715;
			AvailableClasses = 0x7FFF;
			Model = 28977;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Gryphon Mail Crown";
			Name2 = "Gryphon Mail Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 677;
			BuyPrice = 53579;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Formidable Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableCirclet : Item
	{
		public FormidableCirclet() : base()
		{
			Id = 15634;
			Resistance[0] = 230;
			Bonding = 2;
			SellPrice = 11441;
			AvailableClasses = 0x7FFF;
			Model = 26330;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Formidable Circlet";
			Name2 = "Formidable Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 678;
			BuyPrice = 57208;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ironhide Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideHelmet : Item
	{
		public IronhideHelmet() : base()
		{
			Id = 15645;
			Resistance[0] = 242;
			Bonding = 2;
			SellPrice = 14577;
			AvailableClasses = 0x7FFF;
			Model = 27178;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Ironhide Helmet";
			Name2 = "Ironhide Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 679;
			BuyPrice = 72887;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Merciless Crown)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessCrown : Item
	{
		public MercilessCrown() : base()
		{
			Id = 15651;
			Resistance[0] = 246;
			Bonding = 2;
			SellPrice = 15785;
			AvailableClasses = 0x7FFF;
			Model = 27293;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Merciless Crown";
			Name2 = "Merciless Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 679;
			BuyPrice = 78925;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableHelmet : Item
	{
		public ImpenetrableHelmet() : base()
		{
			Id = 15664;
			Resistance[0] = 262;
			Bonding = 2;
			SellPrice = 19071;
			AvailableClasses = 0x7FFF;
			Model = 27306;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Impenetrable Helmet";
			Name2 = "Impenetrable Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 680;
			BuyPrice = 95355;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Magnificent Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentHelmet : Item
	{
		public MagnificentHelmet() : base()
		{
			Id = 15670;
			Resistance[0] = 266;
			Bonding = 2;
			SellPrice = 20455;
			AvailableClasses = 0x7FFF;
			Model = 27908;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Magnificent Helmet";
			Name2 = "Magnificent Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 681;
			BuyPrice = 102277;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Triumphant Skullcap)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantSkullcap : Item
	{
		public TriumphantSkullcap() : base()
		{
			Id = 15684;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 23178;
			AvailableClasses = 0x7FFF;
			Model = 27151;
			ObjectClass = 4;
			SubClass = 3;
			Level = 64;
			ReqLevel = 59;
			Name = "Triumphant Skullcap";
			Name2 = "Triumphant Skullcap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 682;
			BuyPrice = 115893;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Chain Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersChainHelmet : Item
	{
		public LieutenantCommandersChainHelmet() : base()
		{
			Id = 16428;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 12914;
			AvailableClasses = 0x04;
			Model = 31246;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Chain Helmet";
			Name2 = "Lieutenant Commander's Chain Helmet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64573;
			Sets = 362;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			AgilityBonus = 15;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Chain Helm)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsChainHelm : Item
	{
		public FieldMarshalsChainHelm() : base()
		{
			Id = 16465;
			Resistance[0] = 338;
			Bonding = 1;
			SellPrice = 18769;
			AvailableClasses = 0x04;
			Model = 32093;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Chain Helm";
			Name2 = "Field Marshal's Chain Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 93846;
			Sets = 395;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 27;
			AgilityBonus = 19;
			SpiritBonus = 17;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Champion's Mail Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsMailHelm : Item
	{
		public ChampionsMailHelm() : base()
		{
			Id = 16521;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 12572;
			AvailableClasses = 0x40;
			Model = 30072;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Mail Helm";
			Name2 = "Champion's Mail Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62862;
			Sets = 301;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			SpiritBonus = 9;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Champion's Chain Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsChainHeadguard : Item
	{
		public ChampionsChainHeadguard() : base()
		{
			Id = 16526;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 13154;
			AvailableClasses = 0x04;
			Model = 31184;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Chain Headguard";
			Name2 = "Champion's Chain Headguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65771;
			Sets = 361;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			AgilityBonus = 15;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warlord's Chain Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsChainHelmet : Item
	{
		public WarlordsChainHelmet() : base()
		{
			Id = 16566;
			Resistance[0] = 338;
			Bonding = 1;
			SellPrice = 19333;
			AvailableClasses = 0x04;
			Model = 32135;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Chain Helmet";
			Name2 = "Warlord's Chain Helmet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 96665;
			Sets = 396;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 27;
			AgilityBonus = 19;
			SpiritBonus = 17;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warlord's Mail Helm)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsMailHelm : Item
	{
		public WarlordsMailHelm() : base()
		{
			Id = 16578;
			Resistance[0] = 338;
			Bonding = 1;
			SellPrice = 18769;
			AvailableClasses = 0x40;
			Model = 32133;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Mail Helm";
			Name2 = "Warlord's Mail Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 93846;
			Sets = 386;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			SpiritBonus = 11;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Coif of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class CoifOfElements : Item
	{
		public CoifOfElements() : base()
		{
			Id = 16667;
			Resistance[0] = 297;
			Bonding = 1;
			SellPrice = 25778;
			AvailableClasses = 0x7FFF;
			Model = 31117;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Coif of Elements";
			Name2 = "Coif of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 128894;
			Sets = 187;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 23;
			StaminaBonus = 13;
			IqBonus = 12;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Cap)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersCap : Item
	{
		public BeaststalkersCap() : base()
		{
			Id = 16677;
			Resistance[0] = 297;
			Bonding = 1;
			SellPrice = 24868;
			AvailableClasses = 0x7FFF;
			Model = 31410;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Beaststalker's Cap";
			Name2 = "Beaststalker's Cap";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 124341;
			Sets = 186;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			AgilityBonus = 20;
			StaminaBonus = 20;
			SpiritBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Earthfury Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryHelmet : Item
	{
		public EarthfuryHelmet() : base()
		{
			Id = 16842;
			Resistance[0] = 343;
			Bonding = 1;
			SellPrice = 39111;
			AvailableClasses = 0x40;
			Model = 31835;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Helmet";
			Name2 = "Earthfury Helmet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 195557;
			Sets = 207;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 23;
			IqBonus = 13;
			StaminaBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersHelmet : Item
	{
		public GiantstalkersHelmet() : base()
		{
			Id = 16846;
			Resistance[0] = 343;
			Bonding = 1;
			SellPrice = 40759;
			AvailableClasses = 0x04;
			Model = 32028;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Helmet";
			Name2 = "Giantstalker's Helmet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 203796;
			Sets = 206;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 23;
			SpiritBonus = 15;
			IqBonus = 8;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersHelm : Item
	{
		public DragonstalkersHelm() : base()
		{
			Id = 16939;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 64672;
			AvailableClasses = 0x04;
			Model = 29817;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Helm";
			Name2 = "Dragonstalker's Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 323363;
			Sets = 215;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 27;
			SpiritBonus = 16;
			IqBonus = 8;
			StaminaBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Helmet of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class HelmetOfTenStorms : Item
	{
		public HelmetOfTenStorms() : base()
		{
			Id = 16947;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 68314;
			AvailableClasses = 0x40;
			Model = 29794;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Helmet of Ten Storms";
			Name2 = "Helmet of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 341572;
			Sets = 216;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 12;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Bloomsprout Headpiece)
*
***************************************************************/

namespace Server.Items
{
	public class BloomsproutHeadpiece : Item
	{
		public BloomsproutHeadpiece() : base()
		{
			Id = 17767;
			Resistance[0] = 249;
			Bonding = 1;
			SellPrice = 13610;
			AvailableClasses = 0x7FFF;
			Model = 29942;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloomsprout Headpiece";
			Name2 = "Bloomsprout Headpiece";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68052;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 14089 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Fervent Helm)
*
***************************************************************/

namespace Server.Items
{
	public class FerventHelm : Item
	{
		public FerventHelm() : base()
		{
			Id = 18319;
			Resistance[0] = 279;
			Bonding = 1;
			SellPrice = 20989;
			AvailableClasses = 0x7FFF;
			Model = 30680;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Fervent Helm";
			Name2 = "Fervent Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3441;
			BuyPrice = 104945;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 21601 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Backwood Helm)
*
***************************************************************/

namespace Server.Items
{
	public class BackwoodHelm : Item
	{
		public BackwoodHelm() : base()
		{
			Id = 18421;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 25741;
			AvailableClasses = 0x7FFF;
			Model = 30793;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			Name = "Backwood Helm";
			Name2 = "Backwood Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 128705;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 21;
			SpiritBonus = 9;
			IqBonus = 9;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Carrion Scorpid Helm)
*
***************************************************************/

namespace Server.Items
{
	public class CarrionScorpidHelm : Item
	{
		public CarrionScorpidHelm() : base()
		{
			Id = 18479;
			Resistance[0] = 262;
			Bonding = 1;
			SellPrice = 17791;
			AvailableClasses = 0x7FFF;
			Model = 30820;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Carrion Scorpid Helm";
			Name2 = "Carrion Scorpid Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 88957;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 18049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Infernal Headcage)
*
***************************************************************/

namespace Server.Items
{
	public class InfernalHeadcage : Item
	{
		public InfernalHeadcage() : base()
		{
			Id = 18546;
			Resistance[0] = 358;
			Bonding = 1;
			SellPrice = 48035;
			AvailableClasses = 0x7FFF;
			Model = 30889;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 69;
			ReqLevel = 60;
			Name = "Infernal Headcage";
			Name2 = "Infernal Headcage";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 240179;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 25;
			IqBonus = 14;
			StaminaBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Helm of Latent Power)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfLatentPower : Item
	{
		public HelmOfLatentPower() : base()
		{
			Id = 18807;
			Resistance[0] = 297;
			Bonding = 1;
			SellPrice = 25796;
			AvailableClasses = 0x7FFF;
			Model = 31268;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			Name = "Helm of Latent Power";
			Name2 = "Helm of Latent Power";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 128980;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			IqBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Crown of Destruction)
*
***************************************************************/

namespace Server.Items
{
	public class CrownOfDestruction : Item
	{
		public CrownOfDestruction() : base()
		{
			Id = 18817;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 63975;
			AvailableClasses = 0x7FFF;
			Model = 31286;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Crown of Destruction";
			Name2 = "Crown of Destruction";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 319878;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 1;
			Durability = 85;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15810 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			SpiritBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Helm of the Lifegiver)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfTheLifegiver : Item
	{
		public HelmOfTheLifegiver() : base()
		{
			Id = 18870;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 31384;
			AvailableClasses = 0x7FFF;
			Model = 31327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Helm of the Lifegiver";
			Name2 = "Helm of the Lifegiver";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 156920;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 18032 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 30;
			StaminaBonus = 14;
			IqBonus = 9;
		}
	}
}


