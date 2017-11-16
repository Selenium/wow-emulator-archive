/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:21 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Martin Thunder)
*
***************************************************************/

namespace Server.Items
{
	public class MartinThunder : Item
	{
		public MartinThunder() : base()
		{
			Id = 192;
			Resistance[0] = 100;
			SellPrice = 54274;
			AvailableClasses = 0x7FFF;
			Model = 5279;
			Resistance[2] = 110;
			Resistance[4] = 100;
			ObjectClass = 2;
			SubClass = 14;
			Level = 75;
			Name = "Martin Thunder";
			Name2 = "Martin Thunder";
			Resistance[3] = 100;
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 271373;
			Resistance[5] = 100;
			InventoryType = InventoryTypes.OneHand;
			Delay = 500;
			Stackable = 1;
			Material = 6;
			Sheath = 3;
			SetSpell( 265 , 0 , 0 , -1 , 0 , -1 );
			SetDamage( 51 , 63 , Resistances.Armor );
			SetDamage( 5 , 10 , Resistances.Fire );
			SetDamage( 6 , 60 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Dull Frenzy Scale)
*
***************************************************************/

namespace Server.Items
{
	public class DullFrenzyScale : Item
	{
		public DullFrenzyScale() : base()
		{
			Id = 537;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 6629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dull Frenzy Scale";
			Name2 = "Dull Frenzy Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Rough Vulture Feathers)
*
***************************************************************/

namespace Server.Items
{
	public class RoughVultureFeathers : Item
	{
		public RoughVultureFeathers() : base()
		{
			Id = 555;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 11206;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			Name = "Rough Vulture Feathers";
			Name2 = "Rough Vulture Feathers";
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Buzzard Beak)
*
***************************************************************/

namespace Server.Items
{
	public class BuzzardBeak : Item
	{
		public BuzzardBeak() : base()
		{
			Id = 556;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 6625;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Buzzard Beak";
			Name2 = "Buzzard Beak";
			AvailableRaces = 0x1FF;
			BuyPrice = 425;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Melted Candle)
*
***************************************************************/

namespace Server.Items
{
	public class MeltedCandle : Item
	{
		public MeltedCandle() : base()
		{
			Id = 755;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6677;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Melted Candle";
			Name2 = "Melted Candle";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pointy Crocolisk Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class PointyCrocoliskTooth : Item
	{
		public PointyCrocoliskTooth() : base()
		{
			Id = 770;
			SellPrice = 316;
			AvailableClasses = 0x7FFF;
			Model = 6630;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Pointy Crocolisk Tooth";
			Name2 = "Pointy Crocolisk Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 1265;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chipped Boar Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedBoarTusk : Item
	{
		public ChippedBoarTusk() : base()
		{
			Id = 771;
			SellPrice = 38;
			AvailableClasses = 0x7FFF;
			Model = 1225;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chipped Boar Tusk";
			Name2 = "Chipped Boar Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 155;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Prowler Teeth)
*
***************************************************************/

namespace Server.Items
{
	public class ProwlerTeeth : Item
	{
		public ProwlerTeeth() : base()
		{
			Id = 777;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Prowler Teeth";
			Name2 = "Prowler Teeth";
			AvailableRaces = 0x1FF;
			BuyPrice = 86;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Shiny Seashell)
*
***************************************************************/

namespace Server.Items
{
	public class ShinySeashell : Item
	{
		public ShinySeashell() : base()
		{
			Id = 779;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 7714;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shiny Seashell";
			Name2 = "Shiny Seashell";
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pound of Flesh)
*
***************************************************************/

namespace Server.Items
{
	public class PoundOfFlesh : Item
	{
		public PoundOfFlesh() : base()
		{
			Id = 887;
			SellPrice = 82;
			AvailableClasses = 0x7FFF;
			Model = 6680;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "Pound of Flesh";
			Name2 = "Pound of Flesh";
			AvailableRaces = 0x1FF;
			BuyPrice = 330;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dire Wolf Fang)
*
***************************************************************/

namespace Server.Items
{
	public class DireWolfFang : Item
	{
		public DireWolfFang() : base()
		{
			Id = 893;
			SellPrice = 137;
			AvailableClasses = 0x7FFF;
			Model = 959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dire Wolf Fang";
			Name2 = "Dire Wolf Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Horn of the Black Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheBlackWolf : Item
	{
		public HornOfTheBlackWolf() : base()
		{
			Id = 1041;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Black Wolf";
			Name2 = "Horn of the Black Wolf";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 578 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Hard Spider Leg Tip)
*
***************************************************************/

namespace Server.Items
{
	public class HardSpiderLegTip : Item
	{
		public HardSpiderLegTip() : base()
		{
			Id = 1074;
			SellPrice = 491;
			AvailableClasses = 0x7FFF;
			Model = 6619;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hard Spider Leg Tip";
			Name2 = "Hard Spider Leg Tip";
			AvailableRaces = 0x1FF;
			BuyPrice = 1965;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Horn of the Timber Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheTimberWolf : Item
	{
		public HornOfTheTimberWolf() : base()
		{
			Id = 1132;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Timber Wolf";
			Name2 = "Horn of the Timber Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 580 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Winter Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheWinterWolf : Item
	{
		public HornOfTheWinterWolf() : base()
		{
			Id = 1133;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Winter Wolf";
			Name2 = "Horn of the Winter Wolf";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 581 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Gray Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheGrayWolf : Item
	{
		public HornOfTheGrayWolf() : base()
		{
			Id = 1134;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Gray Wolf";
			Name2 = "Horn of the Gray Wolf";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 459 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(A Gold Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class AGoldTooth : Item
	{
		public AGoldTooth() : base()
		{
			Id = 1175;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 6659;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Gold Tooth";
			Name2 = "A Gold Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 115;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
		}
	}
}


/**************************************************************
*
*				(Gnoll Spittle)
*
***************************************************************/

namespace Server.Items
{
	public class GnollSpittle : Item
	{
		public GnollSpittle() : base()
		{
			Id = 1212;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 2637;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Gnoll Spittle";
			Name2 = "Gnoll Spittle";
			AvailableRaces = 0x1FF;
			BuyPrice = 85;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Buzzard Talon)
*
***************************************************************/

namespace Server.Items
{
	public class BuzzardTalon : Item
	{
		public BuzzardTalon() : base()
		{
			Id = 1464;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 6627;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Buzzard Talon";
			Name2 = "Buzzard Talon";
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Snapped Spider Limb)
*
***************************************************************/

namespace Server.Items
{
	public class SnappedSpiderLimb : Item
	{
		public SnappedSpiderLimb() : base()
		{
			Id = 1476;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6619;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Snapped Spider Limb";
			Name2 = "Snapped Spider Limb";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Troll Sweat)
*
***************************************************************/

namespace Server.Items
{
	public class TrollSweat : Item
	{
		public TrollSweat() : base()
		{
			Id = 1520;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 1656;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Troll Sweat";
			Name2 = "Troll Sweat";
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Electro-lantern)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenElectroLantern : Item
	{
		public BrokenElectroLantern() : base()
		{
			Id = 1630;
			SellPrice = 66;
			AvailableClasses = 0x7FFF;
			Model = 6552;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Electro-lantern";
			Name2 = "Broken Electro-lantern";
			AvailableRaces = 0x1FF;
			BuyPrice = 265;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bristly Whisker)
*
***************************************************************/

namespace Server.Items
{
	public class BristlyWhisker : Item
	{
		public BristlyWhisker() : base()
		{
			Id = 1686;
			SellPrice = 733;
			AvailableClasses = 0x7FFF;
			Model = 18096;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bristly Whisker";
			Name2 = "Bristly Whisker";
			AvailableRaces = 0x1FF;
			BuyPrice = 2935;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Retractable Claw)
*
***************************************************************/

namespace Server.Items
{
	public class RetractableClaw : Item
	{
		public RetractableClaw() : base()
		{
			Id = 1687;
			SellPrice = 243;
			AvailableClasses = 0x7FFF;
			Model = 1496;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Retractable Claw";
			Name2 = "Retractable Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 975;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Long Soft Tail)
*
***************************************************************/

namespace Server.Items
{
	public class LongSoftTail : Item
	{
		public LongSoftTail() : base()
		{
			Id = 1688;
			SellPrice = 806;
			AvailableClasses = 0x7FFF;
			Model = 18092;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Long Soft Tail";
			Name2 = "Long Soft Tail";
			AvailableRaces = 0x1FF;
			BuyPrice = 3225;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Curved Raptor Talon)
*
***************************************************************/

namespace Server.Items
{
	public class CurvedRaptorTalon : Item
	{
		public CurvedRaptorTalon() : base()
		{
			Id = 1696;
			SellPrice = 606;
			AvailableClasses = 0x7FFF;
			Model = 1498;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Curved Raptor Talon";
			Name2 = "Curved Raptor Talon";
			AvailableRaces = 0x1FF;
			BuyPrice = 2425;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Keen Raptor Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class KeenRaptorTooth : Item
	{
		public KeenRaptorTooth() : base()
		{
			Id = 1697;
			SellPrice = 445;
			AvailableClasses = 0x7FFF;
			Model = 6630;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Keen Raptor Tooth";
			Name2 = "Keen Raptor Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 1780;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Curved Basilisk Claw)
*
***************************************************************/

namespace Server.Items
{
	public class CurvedBasiliskClaw : Item
	{
		public CurvedBasiliskClaw() : base()
		{
			Id = 1701;
			SellPrice = 376;
			AvailableClasses = 0x7FFF;
			Model = 1498;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Curved Basilisk Claw";
			Name2 = "Curved Basilisk Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 1505;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Intact Basilisk Spine)
*
***************************************************************/

namespace Server.Items
{
	public class IntactBasiliskSpine : Item
	{
		public IntactBasiliskSpine() : base()
		{
			Id = 1702;
			SellPrice = 320;
			AvailableClasses = 0x7FFF;
			Model = 6349;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Intact Basilisk Spine";
			Name2 = "Intact Basilisk Spine";
			AvailableRaces = 0x1FF;
			BuyPrice = 1280;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Azuredeep Shards)
*
***************************************************************/

namespace Server.Items
{
	public class AzuredeepShards : Item
	{
		public AzuredeepShards() : base()
		{
			Id = 1706;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 6614;
			ObjectClass = 15;
			SubClass = 0;
			Level = 36;
			Name = "Azuredeep Shards";
			Name2 = "Azuredeep Shards";
			AvailableRaces = 0x1FF;
			BuyPrice = 344;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chunk of Flesh)
*
***************************************************************/

namespace Server.Items
{
	public class ChunkOfFlesh : Item
	{
		public ChunkOfFlesh() : base()
		{
			Id = 2085;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 1116;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Chunk of Flesh";
			Name2 = "Chunk of Flesh";
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The Story of Morgan Ladimore)
*
***************************************************************/

namespace Server.Items
{
	public class TheStoryOfMorganLadimore : Item
	{
		public TheStoryOfMorganLadimore() : base()
		{
			Id = 2154;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 1143;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "The Story of Morgan Ladimore";
			Name2 = "The Story of Morgan Ladimore";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 64;
		}
	}
}


/**************************************************************
*
*				(Large Boar Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBoarTusk : Item
	{
		public LargeBoarTusk() : base()
		{
			Id = 2295;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 1225;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Boar Tusk";
			Name2 = "Large Boar Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Black Stallion Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class BlackStallionBridle : Item
	{
		public BlackStallionBridle() : base()
		{
			Id = 2411;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Black Stallion Bridle";
			Name2 = "Black Stallion Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 470 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Palomino)
*
***************************************************************/

namespace Server.Items
{
	public class Palomino : Item
	{
		public Palomino() : base()
		{
			Id = 2413;
			Bonding = 3;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Palomino";
			Name2 = "Palomino";
			Quality = 1;
			AvailableRaces = 0x19F;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 471 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Pinto Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class PintoBridle : Item
	{
		public PintoBridle() : base()
		{
			Id = 2414;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Pinto Bridle";
			Name2 = "Pinto Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 472 , 0 , 0 , -1 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(White Stallion)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteStallion : Item
	{
		public WhiteStallion() : base()
		{
			Id = 2415;
			Bonding = 3;
			SellPrice = 125000;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "White Stallion";
			Name2 = "White Stallion";
			Quality = 1;
			AvailableRaces = 0x19F;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 468 , 0 , 0 , -1 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Forest Spider Webbing)
*
***************************************************************/

namespace Server.Items
{
	public class ForestSpiderWebbing : Item
	{
		public ForestSpiderWebbing() : base()
		{
			Id = 2590;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 18597;
			ObjectClass = 15;
			SubClass = 0;
			Level = 5;
			Name = "Forest Spider Webbing";
			Name2 = "Forest Spider Webbing";
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Dirty Trogg Cloth)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyTroggCloth : Item
	{
		public DirtyTroggCloth() : base()
		{
			Id = 2591;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 1329;
			ObjectClass = 15;
			SubClass = 0;
			Level = 9;
			Name = "Dirty Trogg Cloth";
			Name2 = "Dirty Trogg Cloth";
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Threshadon Ambergris)
*
***************************************************************/

namespace Server.Items
{
	public class ThreshadonAmbergris : Item
	{
		public ThreshadonAmbergris() : base()
		{
			Id = 2608;
			SellPrice = 63;
			AvailableClasses = 0x7FFF;
			Model = 6703;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			Name = "Threshadon Ambergris";
			Name2 = "Threshadon Ambergris";
			AvailableRaces = 0x1FF;
			BuyPrice = 255;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
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
	public class TorchOfHolyFlame : Item
	{
		public TorchOfHolyFlame() : base()
		{
			Id = 2808;
			Bonding = 1;
			SellPrice = 2364;
			AvailableClasses = 0x7FFF;
			Model = 3947;
			ObjectClass = 2;
			SubClass = 14;
			Level = 29;
			ReqLevel = 19;
			Name = "Torch of Holy Flame";
			Name2 = "Torch of Holy Flame";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11820;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 7;
			SetDamage( 26 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mining Pick)
*
***************************************************************/

namespace Server.Items
{
	public class MiningPick : Item
	{
		public MiningPick() : base()
		{
			Id = 2901;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Description = "Miners need a mining pick for digging.";
			Model = 6568;
			ObjectClass = 2;
			SubClass = 14;
			Level = 4;
			ReqLevel = 1;
			Name = "Mining Pick";
			Name2 = "Mining Pick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 81;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloody Bear Paw)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyBearPaw : Item
	{
		public BloodyBearPaw() : base()
		{
			Id = 2940;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 1769;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bloody Bear Paw";
			Name2 = "Bloody Bear Paw";
			AvailableRaces = 0x1FF;
			BuyPrice = 175;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fine Sand)
*
***************************************************************/

namespace Server.Items
{
	public class FineSand : Item
	{
		public FineSand() : base()
		{
			Id = 3010;
			SellPrice = 101;
			AvailableClasses = 0x7FFF;
			Model = 6371;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fine Sand";
			Name2 = "Fine Sand";
			AvailableRaces = 0x1FF;
			BuyPrice = 405;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thick Spider Hair)
*
***************************************************************/

namespace Server.Items
{
	public class ThickSpiderHair : Item
	{
		public ThickSpiderHair() : base()
		{
			Id = 3167;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 6699;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thick Spider Hair";
			Name2 = "Thick Spider Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 275;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chipped Bear Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedBearTooth : Item
	{
		public ChippedBearTooth() : base()
		{
			Id = 3169;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chipped Bear Tooth";
			Name2 = "Chipped Bear Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Bear Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBearTooth : Item
	{
		public LargeBearTooth() : base()
		{
			Id = 3170;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 6666;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Bear Tooth";
			Name2 = "Large Bear Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 190;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Boar Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenBoarTusk : Item
	{
		public BrokenBoarTusk() : base()
		{
			Id = 3171;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 3429;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Boar Tusk";
			Name2 = "Broken Boar Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ruined Dragonhide)
*
***************************************************************/

namespace Server.Items
{
	public class RuinedDragonhide : Item
	{
		public RuinedDragonhide() : base()
		{
			Id = 3175;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 11164;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ruined Dragonhide";
			Name2 = "Ruined Dragonhide";
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Small Claw)
*
***************************************************************/

namespace Server.Items
{
	public class SmallClaw : Item
	{
		public SmallClaw() : base()
		{
			Id = 3176;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 3307;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Claw";
			Name2 = "Small Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tiny Fang)
*
***************************************************************/

namespace Server.Items
{
	public class TinyFang : Item
	{
		public TinyFang() : base()
		{
			Id = 3177;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 6651;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Tiny Fang";
			Name2 = "Tiny Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cracked Dragon Molting)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedDragonMolting : Item
	{
		public CrackedDragonMolting() : base()
		{
			Id = 3179;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 28257;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cracked Dragon Molting";
			Name2 = "Cracked Dragon Molting";
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Flecked Raptor Scale)
*
***************************************************************/

namespace Server.Items
{
	public class FleckedRaptorScale : Item
	{
		public FleckedRaptorScale() : base()
		{
			Id = 3180;
			SellPrice = 168;
			AvailableClasses = 0x7FFF;
			Model = 6658;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Flecked Raptor Scale";
			Name2 = "Flecked Raptor Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 675;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Partially Digested Meat)
*
***************************************************************/

namespace Server.Items
{
	public class PartiallyDigestedMeat : Item
	{
		public PartiallyDigestedMeat() : base()
		{
			Id = 3181;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 6678;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Partially Digested Meat";
			Name2 = "Partially Digested Meat";
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fractured Canine)
*
***************************************************************/

namespace Server.Items
{
	public class FracturedCanine : Item
	{
		public FracturedCanine() : base()
		{
			Id = 3299;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fractured Canine";
			Name2 = "Fractured Canine";
			AvailableRaces = 0x1FF;
			BuyPrice = 195;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rabbit's Foot)
*
***************************************************************/

namespace Server.Items
{
	public class RabbitsFoot : Item
	{
		public RabbitsFoot() : base()
		{
			Id = 3300;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 6682;
			ObjectClass = 15;
			SubClass = 0;
			Level = 5;
			Name = "Rabbit's Foot";
			Name2 = "Rabbit's Foot";
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Sharp Canine)
*
***************************************************************/

namespace Server.Items
{
	public class SharpCanine : Item
	{
		public SharpCanine() : base()
		{
			Id = 3301;
			SellPrice = 102;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sharp Canine";
			Name2 = "Sharp Canine";
			AvailableRaces = 0x1FF;
			BuyPrice = 410;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Vulture Talon)
*
***************************************************************/

namespace Server.Items
{
	public class VultureTalon : Item
	{
		public VultureTalon() : base()
		{
			Id = 3399;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 6627;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Vulture Talon";
			Name2 = "Vulture Talon";
			AvailableRaces = 0x1FF;
			BuyPrice = 325;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rough Crocolisk Scale)
*
***************************************************************/

namespace Server.Items
{
	public class RoughCrocoliskScale : Item
	{
		public RoughCrocoliskScale() : base()
		{
			Id = 3401;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 6628;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Rough Crocolisk Scale";
			Name2 = "Rough Crocolisk Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 325;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Soft Patch of Fur)
*
***************************************************************/

namespace Server.Items
{
	public class SoftPatchOfFur : Item
	{
		public SoftPatchOfFur() : base()
		{
			Id = 3402;
			SellPrice = 602;
			AvailableClasses = 0x7FFF;
			Model = 6691;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Soft Patch of Fur";
			Name2 = "Soft Patch of Fur";
			AvailableRaces = 0x1FF;
			BuyPrice = 2410;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ivory Boar Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class IvoryBoarTusk : Item
	{
		public IvoryBoarTusk() : base()
		{
			Id = 3403;
			SellPrice = 321;
			AvailableClasses = 0x7FFF;
			Model = 1225;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ivory Boar Tusk";
			Name2 = "Ivory Boar Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 1285;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Gelatinous Goo)
*
***************************************************************/

namespace Server.Items
{
	public class GelatinousGoo : Item
	{
		public GelatinousGoo() : base()
		{
			Id = 3669;
			SellPrice = 195;
			AvailableClasses = 0x7FFF;
			Model = 2637;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gelatinous Goo";
			Name2 = "Gelatinous Goo";
			AvailableRaces = 0x1FF;
			BuyPrice = 780;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Slimy Bone)
*
***************************************************************/

namespace Server.Items
{
	public class LargeSlimyBone : Item
	{
		public LargeSlimyBone() : base()
		{
			Id = 3670;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 6668;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Slimy Bone";
			Name2 = "Large Slimy Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lifeless Skull)
*
***************************************************************/

namespace Server.Items
{
	public class LifelessSkull : Item
	{
		public LifelessSkull() : base()
		{
			Id = 3671;
			SellPrice = 201;
			AvailableClasses = 0x7FFF;
			Model = 7102;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Lifeless Skull";
			Name2 = "Lifeless Skull";
			AvailableRaces = 0x1FF;
			BuyPrice = 805;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenArrow : Item
	{
		public BrokenArrow() : base()
		{
			Id = 3673;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 6616;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Arrow";
			Name2 = "Broken Arrow";
			AvailableRaces = 0x1FF;
			BuyPrice = 180;
			InventoryType = InventoryTypes.None;
			Stackable = 100;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Decomposed Boot)
*
***************************************************************/

namespace Server.Items
{
	public class DecomposedBoot : Item
	{
		public DecomposedBoot() : base()
		{
			Id = 3674;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 6638;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Decomposed Boot";
			Name2 = "Decomposed Boot";
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Extinguished Torch)
*
***************************************************************/

namespace Server.Items
{
	public class ExtinguishedTorch : Item
	{
		public ExtinguishedTorch() : base()
		{
			Id = 3675;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 12994;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Extinguished Torch";
			Name2 = "Extinguished Torch";
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Slimy Ichor)
*
***************************************************************/

namespace Server.Items
{
	public class SlimyIchor : Item
	{
		public SlimyIchor() : base()
		{
			Id = 3676;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 6690;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Slimy Ichor";
			Name2 = "Slimy Ichor";
			AvailableRaces = 0x1FF;
			BuyPrice = 425;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bear Gall Bladder)
*
***************************************************************/

namespace Server.Items
{
	public class BearGallBladder : Item
	{
		public BearGallBladder() : base()
		{
			Id = 3702;
			SellPrice = 498;
			AvailableClasses = 0x7FFF;
			Model = 4045;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bear Gall Bladder";
			Name2 = "Bear Gall Bladder";
			AvailableRaces = 0x1FF;
			BuyPrice = 1995;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Familiar Hide)
*
***************************************************************/

namespace Server.Items
{
	public class FamiliarHide : Item
	{
		public FamiliarHide() : base()
		{
			Id = 3722;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 6655;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Familiar Hide";
			Name2 = "Familiar Hide";
			AvailableRaces = 0x1FF;
			BuyPrice = 855;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Familiar Fang)
*
***************************************************************/

namespace Server.Items
{
	public class FamiliarFang : Item
	{
		public FamiliarFang() : base()
		{
			Id = 3723;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 6630;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Familiar Fang";
			Name2 = "Familiar Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 275;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Familiar Claw)
*
***************************************************************/

namespace Server.Items
{
	public class FamiliarClaw : Item
	{
		public FamiliarClaw() : base()
		{
			Id = 3724;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 6651;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Familiar Claw";
			Name2 = "Familiar Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 325;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Familiar Horn)
*
***************************************************************/

namespace Server.Items
{
	public class FamiliarHorn : Item
	{
		public FamiliarHorn() : base()
		{
			Id = 3725;
			SellPrice = 166;
			AvailableClasses = 0x7FFF;
			Model = 6656;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Familiar Horn";
			Name2 = "Familiar Horn";
			AvailableRaces = 0x1FF;
			BuyPrice = 666;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Gryphon Feather Quill)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonFeatherQuill : Item
	{
		public GryphonFeatherQuill() : base()
		{
			Id = 3766;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 19569;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gryphon Feather Quill";
			Name2 = "Gryphon Feather Quill";
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fine Parchment)
*
***************************************************************/

namespace Server.Items
{
	public class FineParchment : Item
	{
		public FineParchment() : base()
		{
			Id = 3767;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 4110;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fine Parchment";
			Name2 = "Fine Parchment";
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Wand)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenWand : Item
	{
		public BrokenWand() : base()
		{
			Id = 3769;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 6620;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Wand";
			Name2 = "Broken Wand";
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Buzzard Feather)
*
***************************************************************/

namespace Server.Items
{
	public class BuzzardFeather : Item
	{
		public BuzzardFeather() : base()
		{
			Id = 3882;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 19531;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Buzzard Feather";
			Name2 = "Buzzard Feather";
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Legends of the Gurubashi, Volume 3)
*
***************************************************************/

namespace Server.Items
{
	public class LegendsOfTheGurubashiVolume3 : Item
	{
		public LegendsOfTheGurubashiVolume3() : base()
		{
			Id = 3899;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Description = "Stone of the Tides";
			Model = 6672;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Legends of the Gurubashi, Volume 3";
			Name2 = "Legends of the Gurubashi, Volume 3";
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 286;
		}
	}
}


/**************************************************************
*
*				(Poisoned Spider Fang)
*
***************************************************************/

namespace Server.Items
{
	public class PoisonedSpiderFang : Item
	{
		public PoisonedSpiderFang() : base()
		{
			Id = 3931;
			SellPrice = 185;
			AvailableClasses = 0x7FFF;
			Model = 959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Poisoned Spider Fang";
			Name2 = "Poisoned Spider Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 740;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Prismatic Basilisk Scale)
*
***************************************************************/

namespace Server.Items
{
	public class PrismaticBasiliskScale : Item
	{
		public PrismaticBasiliskScale() : base()
		{
			Id = 4092;
			SellPrice = 1296;
			AvailableClasses = 0x7FFF;
			Model = 4433;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Prismatic Basilisk Scale";
			Name2 = "Prismatic Basilisk Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 5185;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Basilisk Tail)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBasiliskTail : Item
	{
		public LargeBasiliskTail() : base()
		{
			Id = 4093;
			SellPrice = 713;
			AvailableClasses = 0x7FFF;
			Model = 6665;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Basilisk Tail";
			Name2 = "Large Basilisk Tail";
			AvailableRaces = 0x1FF;
			BuyPrice = 2855;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Coarse Gorilla Hair)
*
***************************************************************/

namespace Server.Items
{
	public class CoarseGorillaHair : Item
	{
		public CoarseGorillaHair() : base()
		{
			Id = 4096;
			SellPrice = 608;
			AvailableClasses = 0x7FFF;
			Model = 18096;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Coarse Gorilla Hair";
			Name2 = "Coarse Gorilla Hair";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2435;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chipped Gorilla Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedGorillaTooth : Item
	{
		public ChippedGorillaTooth() : base()
		{
			Id = 4097;
			SellPrice = 305;
			AvailableClasses = 0x7FFF;
			Model = 6630;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chipped Gorilla Tooth";
			Name2 = "Chipped Gorilla Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 1220;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tuft of Gorilla Hair)
*
***************************************************************/

namespace Server.Items
{
	public class TuftOfGorillaHair : Item
	{
		public TuftOfGorillaHair() : base()
		{
			Id = 4099;
			SellPrice = 1131;
			AvailableClasses = 0x7FFF;
			Model = 29087;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Tuft of Gorilla Hair";
			Name2 = "Tuft of Gorilla Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 4525;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Crumpled Note)
*
***************************************************************/

namespace Server.Items
{
	public class CrumpledNote : Item
	{
		public CrumpledNote() : base()
		{
			Id = 4100;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 3093;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crumpled Note";
			Name2 = "Crumpled Note";
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			PageText = 308;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Ripped Note)
*
***************************************************************/

namespace Server.Items
{
	public class RippedNote : Item
	{
		public RippedNote() : base()
		{
			Id = 4101;
			SellPrice = 26;
			AvailableClasses = 0x7FFF;
			Model = 3093;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ripped Note";
			Name2 = "Ripped Note";
			AvailableRaces = 0x1FF;
			BuyPrice = 105;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			PageText = 309;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Torn Note)
*
***************************************************************/

namespace Server.Items
{
	public class TornNote : Item
	{
		public TornNote() : base()
		{
			Id = 4102;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 3093;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Torn Note";
			Name2 = "Torn Note";
			AvailableRaces = 0x1FF;
			BuyPrice = 135;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			PageText = 310;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Spider Palp)
*
***************************************************************/

namespace Server.Items
{
	public class SpiderPalp : Item
	{
		public SpiderPalp() : base()
		{
			Id = 4428;
			SellPrice = 331;
			AvailableClasses = 0x7FFF;
			Model = 6699;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Spider Palp";
			Name2 = "Spider Palp";
			AvailableRaces = 0x1FF;
			BuyPrice = 1325;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Brittle Dragon Bone)
*
***************************************************************/

namespace Server.Items
{
	public class BrittleDragonBone : Item
	{
		public BrittleDragonBone() : base()
		{
			Id = 4459;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 18072;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Brittle Dragon Bone";
			Name2 = "Brittle Dragon Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ripped Wing Webbing)
*
***************************************************************/

namespace Server.Items
{
	public class RippedWingWebbing : Item
	{
		public RippedWingWebbing() : base()
		{
			Id = 4460;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 568;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ripped Wing Webbing";
			Name2 = "Ripped Wing Webbing";
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Smooth Stone Chip)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothStoneChip : Item
	{
		public SmoothStoneChip() : base()
		{
			Id = 4552;
			SellPrice = 530;
			AvailableClasses = 0x7FFF;
			Model = 4719;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Smooth Stone Chip";
			Name2 = "Smooth Stone Chip";
			AvailableRaces = 0x1FF;
			BuyPrice = 2120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Jagged Piece of Stone)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedPieceOfStone : Item
	{
		public JaggedPieceOfStone() : base()
		{
			Id = 4553;
			SellPrice = 411;
			AvailableClasses = 0x7FFF;
			Model = 4722;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Jagged Piece of Stone";
			Name2 = "Jagged Piece of Stone";
			AvailableRaces = 0x1FF;
			BuyPrice = 1645;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Shiny Polished Stone)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyPolishedStone : Item
	{
		public ShinyPolishedStone() : base()
		{
			Id = 4554;
			SellPrice = 708;
			AvailableClasses = 0x7FFF;
			Model = 4721;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shiny Polished Stone";
			Name2 = "Shiny Polished Stone";
			AvailableRaces = 0x1FF;
			BuyPrice = 2835;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thick Scaly Tail)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScalyTail : Item
	{
		public ThickScalyTail() : base()
		{
			Id = 4555;
			SellPrice = 155;
			AvailableClasses = 0x7FFF;
			Model = 20915;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thick Scaly Tail";
			Name2 = "Thick Scaly Tail";
			AvailableRaces = 0x1FF;
			BuyPrice = 620;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Speckled Shell Fragment)
*
***************************************************************/

namespace Server.Items
{
	public class SpeckledShellFragment : Item
	{
		public SpeckledShellFragment() : base()
		{
			Id = 4556;
			SellPrice = 903;
			AvailableClasses = 0x7FFF;
			Model = 20914;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Speckled Shell Fragment";
			Name2 = "Speckled Shell Fragment";
			AvailableRaces = 0x1FF;
			BuyPrice = 3615;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fiery Gland)
*
***************************************************************/

namespace Server.Items
{
	public class FieryGland : Item
	{
		public FieryGland() : base()
		{
			Id = 4557;
			SellPrice = 225;
			AvailableClasses = 0x7FFF;
			Model = 28258;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fiery Gland";
			Name2 = "Fiery Gland";
			AvailableRaces = 0x1FF;
			BuyPrice = 900;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Empty Barrel)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyBarrel : Item
	{
		public EmptyBarrel() : base()
		{
			Id = 4558;
			SellPrice = 1565;
			AvailableClasses = 0x7FFF;
			Model = 8381;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Empty Barrel";
			Name2 = "Empty Barrel";
			AvailableRaces = 0x1FF;
			BuyPrice = 6260;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Sabertooth Fang)
*
***************************************************************/

namespace Server.Items
{
	public class SabertoothFang : Item
	{
		public SabertoothFang() : base()
		{
			Id = 4580;
			SellPrice = 787;
			AvailableClasses = 0x7FFF;
			Model = 959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sabertooth Fang";
			Name2 = "Sabertooth Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 3150;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Patch of Fine Fur)
*
***************************************************************/

namespace Server.Items
{
	public class PatchOfFineFur : Item
	{
		public PatchOfFineFur() : base()
		{
			Id = 4581;
			SellPrice = 862;
			AvailableClasses = 0x7FFF;
			Model = 6679;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Patch of Fine Fur";
			Name2 = "Patch of Fine Fur";
			AvailableRaces = 0x1FF;
			BuyPrice = 3450;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Soft Bushy Tail)
*
***************************************************************/

namespace Server.Items
{
	public class SoftBushyTail : Item
	{
		public SoftBushyTail() : base()
		{
			Id = 4582;
			SellPrice = 745;
			AvailableClasses = 0x7FFF;
			Model = 18095;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Soft Bushy Tail";
			Name2 = "Soft Bushy Tail";
			AvailableRaces = 0x1FF;
			BuyPrice = 2980;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thick Furry Mane)
*
***************************************************************/

namespace Server.Items
{
	public class ThickFurryMane : Item
	{
		public ThickFurryMane() : base()
		{
			Id = 4583;
			SellPrice = 812;
			AvailableClasses = 0x7FFF;
			Model = 6698;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thick Furry Mane";
			Name2 = "Thick Furry Mane";
			AvailableRaces = 0x1FF;
			BuyPrice = 3250;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Trophy Paw)
*
***************************************************************/

namespace Server.Items
{
	public class LargeTrophyPaw : Item
	{
		public LargeTrophyPaw() : base()
		{
			Id = 4584;
			SellPrice = 937;
			AvailableClasses = 0x7FFF;
			Model = 6669;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Trophy Paw";
			Name2 = "Large Trophy Paw";
			AvailableRaces = 0x1FF;
			BuyPrice = 3750;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dripping Spider Mandible)
*
***************************************************************/

namespace Server.Items
{
	public class DrippingSpiderMandible : Item
	{
		public DrippingSpiderMandible() : base()
		{
			Id = 4585;
			SellPrice = 583;
			AvailableClasses = 0x7FFF;
			Model = 6619;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dripping Spider Mandible";
			Name2 = "Dripping Spider Mandible";
			AvailableRaces = 0x1FF;
			BuyPrice = 2335;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Smooth Raptor Skin)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothRaptorSkin : Item
	{
		public SmoothRaptorSkin() : base()
		{
			Id = 4586;
			SellPrice = 713;
			AvailableClasses = 0x7FFF;
			Model = 6628;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Smooth Raptor Skin";
			Name2 = "Smooth Raptor Skin";
			AvailableRaces = 0x1FF;
			BuyPrice = 2855;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tribal Raptor Feathers)
*
***************************************************************/

namespace Server.Items
{
	public class TribalRaptorFeathers : Item
	{
		public TribalRaptorFeathers() : base()
		{
			Id = 4587;
			SellPrice = 807;
			AvailableClasses = 0x7FFF;
			Model = 11208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Tribal Raptor Feathers";
			Name2 = "Tribal Raptor Feathers";
			AvailableRaces = 0x1FF;
			BuyPrice = 3230;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pristine Raptor Skull)
*
***************************************************************/

namespace Server.Items
{
	public class PristineRaptorSkull : Item
	{
		public PristineRaptorSkull() : base()
		{
			Id = 4588;
			SellPrice = 900;
			AvailableClasses = 0x7FFF;
			Model = 4807;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Pristine Raptor Skull";
			Name2 = "Pristine Raptor Skull";
			AvailableRaces = 0x1FF;
			BuyPrice = 3600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Long Elegant Feather)
*
***************************************************************/

namespace Server.Items
{
	public class LongElegantFeather : Item
	{
		public LongElegantFeather() : base()
		{
			Id = 4589;
			SellPrice = 530;
			AvailableClasses = 0x7FFF;
			Model = 11207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Long Elegant Feather";
			Name2 = "Long Elegant Feather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Curved Yellow Bill)
*
***************************************************************/

namespace Server.Items
{
	public class CurvedYellowBill : Item
	{
		public CurvedYellowBill() : base()
		{
			Id = 4590;
			SellPrice = 655;
			AvailableClasses = 0x7FFF;
			Model = 6636;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Curved Yellow Bill";
			Name2 = "Curved Yellow Bill";
			AvailableRaces = 0x1FF;
			BuyPrice = 2620;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Eagle Eye)
*
***************************************************************/

namespace Server.Items
{
	public class EagleEye : Item
	{
		public EagleEye() : base()
		{
			Id = 4591;
			SellPrice = 413;
			AvailableClasses = 0x7FFF;
			Model = 6492;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Eagle Eye";
			Name2 = "Eagle Eye";
			AvailableRaces = 0x1FF;
			BuyPrice = 1655;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ryedol's Lucky Pick)
*
***************************************************************/

namespace Server.Items
{
	public class RyedolsLuckyPick : Item
	{
		public RyedolsLuckyPick() : base()
		{
			Id = 4616;
			Bonding = 4;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6589;
			ObjectClass = 2;
			SubClass = 14;
			Level = 1;
			Name = "Ryedol's Lucky Pick";
			Name2 = "Ryedol's Lucky Pick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Flags = 2048;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ornate Bronze Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBronzeLockbox : Item
	{
		public OrnateBronzeLockbox() : base()
		{
			Id = 4632;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Ornate Bronze Lockbox";
			Name2 = "Ornate Bronze Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 5;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Heavy Bronze Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyBronzeLockbox : Item
	{
		public HeavyBronzeLockbox() : base()
		{
			Id = 4633;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "Heavy Bronze Lockbox";
			Name2 = "Heavy Bronze Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 23;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Iron Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class IronLockbox : Item
	{
		public IronLockbox() : base()
		{
			Id = 4634;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Iron Lockbox";
			Name2 = "Iron Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 24;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Strong Iron Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class StrongIronLockbox : Item
	{
		public StrongIronLockbox() : base()
		{
			Id = 4636;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Strong Iron Lockbox";
			Name2 = "Strong Iron Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 440;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 60;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Steel Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class SteelLockbox : Item
	{
		public SteelLockbox() : base()
		{
			Id = 4637;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Steel Lockbox";
			Name2 = "Steel Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 61;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Reinforced Steel Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedSteelLockbox : Item
	{
		public ReinforcedSteelLockbox() : base()
		{
			Id = 4638;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Reinforced Steel Lockbox";
			Name2 = "Reinforced Steel Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 62;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Cracked Egg Shells)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedEggShells : Item
	{
		public CrackedEggShells() : base()
		{
			Id = 4757;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 18053;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cracked Egg Shells";
			Name2 = "Cracked Egg Shells";
			AvailableRaces = 0x1FF;
			BuyPrice = 19;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Cracked Bill)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedBill : Item
	{
		public CrackedBill() : base()
		{
			Id = 4775;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 6633;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cracked Bill";
			Name2 = "Cracked Bill";
			AvailableRaces = 0x1FF;
			BuyPrice = 115;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ruffled Feather)
*
***************************************************************/

namespace Server.Items
{
	public class RuffledFeather : Item
	{
		public RuffledFeather() : base()
		{
			Id = 4776;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 19567;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ruffled Feather";
			Name2 = "Ruffled Feather";
			AvailableRaces = 0x1FF;
			BuyPrice = 165;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dull Kodo Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class DullKodoTooth : Item
	{
		public DullKodoTooth() : base()
		{
			Id = 4779;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 6652;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dull Kodo Tooth";
			Name2 = "Dull Kodo Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Kodo Horn Fragment)
*
***************************************************************/

namespace Server.Items
{
	public class KodoHornFragment : Item
	{
		public KodoHornFragment() : base()
		{
			Id = 4780;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 6664;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Kodo Horn Fragment";
			Name2 = "Kodo Horn Fragment";
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lifeless Stone)
*
***************************************************************/

namespace Server.Items
{
	public class LifelessStone : Item
	{
		public LifelessStone() : base()
		{
			Id = 4784;
			SellPrice = 360;
			AvailableClasses = 0x7FFF;
			Model = 4719;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Lifeless Stone";
			Name2 = "Lifeless Stone";
			AvailableRaces = 0x1FF;
			BuyPrice = 1440;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Burning Pitch)
*
***************************************************************/

namespace Server.Items
{
	public class BurningPitch : Item
	{
		public BurningPitch() : base()
		{
			Id = 4787;
			SellPrice = 577;
			AvailableClasses = 0x7FFF;
			Model = 22927;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Burning Pitch";
			Name2 = "Burning Pitch";
			AvailableRaces = 0x1FF;
			BuyPrice = 2310;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Small Leather Collar)
*
***************************************************************/

namespace Server.Items
{
	public class SmallLeatherCollar : Item
	{
		public SmallLeatherCollar() : base()
		{
			Id = 4813;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 15593;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Leather Collar";
			Name2 = "Small Leather Collar";
			AvailableRaces = 0x1FF;
			BuyPrice = 135;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Discolored Fang)
*
***************************************************************/

namespace Server.Items
{
	public class DiscoloredFang : Item
	{
		public DiscoloredFang() : base()
		{
			Id = 4814;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 7048;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Discolored Fang";
			Name2 = "Discolored Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Glistening Frenzy Scale)
*
***************************************************************/

namespace Server.Items
{
	public class GlisteningFrenzyScale : Item
	{
		public GlisteningFrenzyScale() : base()
		{
			Id = 4860;
			SellPrice = 741;
			AvailableClasses = 0x7FFF;
			Model = 4433;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Glistening Frenzy Scale";
			Name2 = "Glistening Frenzy Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 2965;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ruined Pelt)
*
***************************************************************/

namespace Server.Items
{
	public class RuinedPelt : Item
	{
		public RuinedPelt() : base()
		{
			Id = 4865;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 7086;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ruined Pelt";
			Name2 = "Ruined Pelt";
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Broken Scorpid Leg)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenScorpidLeg : Item
	{
		public BrokenScorpidLeg() : base()
		{
			Id = 4867;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 6619;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Scorpid Leg";
			Name2 = "Broken Scorpid Leg";
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Dry Scorpid Eye)
*
***************************************************************/

namespace Server.Items
{
	public class DryScorpidEye : Item
	{
		public DryScorpidEye() : base()
		{
			Id = 4872;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dry Scorpid Eye";
			Name2 = "Dry Scorpid Eye";
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Dry Hardened Barnacle)
*
***************************************************************/

namespace Server.Items
{
	public class DryHardenedBarnacle : Item
	{
		public DryHardenedBarnacle() : base()
		{
			Id = 4873;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 4714;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dry Hardened Barnacle";
			Name2 = "Dry Hardened Barnacle";
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Clean Fishbones)
*
***************************************************************/

namespace Server.Items
{
	public class CleanFishbones : Item
	{
		public CleanFishbones() : base()
		{
			Id = 4874;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 6631;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Clean Fishbones";
			Name2 = "Clean Fishbones";
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Slimy Bone)
*
***************************************************************/

namespace Server.Items
{
	public class SlimyBone : Item
	{
		public SlimyBone() : base()
		{
			Id = 4875;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 6668;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Slimy Bone";
			Name2 = "Slimy Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Bloody Leather Boot)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyLeatherBoot : Item
	{
		public BloodyLeatherBoot() : base()
		{
			Id = 4876;
			SellPrice = 78;
			AvailableClasses = 0x7FFF;
			Model = 6615;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bloody Leather Boot";
			Name2 = "Bloody Leather Boot";
			AvailableRaces = 0x1FF;
			BuyPrice = 315;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Stone Arrowhead)
*
***************************************************************/

namespace Server.Items
{
	public class StoneArrowhead : Item
	{
		public StoneArrowhead() : base()
		{
			Id = 4877;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 6701;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Stone Arrowhead";
			Name2 = "Stone Arrowhead";
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Broken Bloodstained Bow)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenBloodstainedBow : Item
	{
		public BrokenBloodstainedBow() : base()
		{
			Id = 4878;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 6617;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Bloodstained Bow";
			Name2 = "Broken Bloodstained Bow";
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Squashed Rabbit Carcass)
*
***************************************************************/

namespace Server.Items
{
	public class SquashedRabbitCarcass : Item
	{
		public SquashedRabbitCarcass() : base()
		{
			Id = 4879;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6700;
			ObjectClass = 15;
			SubClass = 0;
			Level = 5;
			Name = "Squashed Rabbit Carcass";
			Name2 = "Squashed Rabbit Carcass";
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Broken Spear)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenSpear : Item
	{
		public BrokenSpear() : base()
		{
			Id = 4880;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 2868;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Spear";
			Name2 = "Broken Spear";
			AvailableRaces = 0x1FF;
			BuyPrice = 345;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Unconscious Dig Rat)
*
***************************************************************/

namespace Server.Items
{
	public class UnconsciousDigRat : Item
	{
		public UnconsciousDigRat() : base()
		{
			Id = 5052;
			AvailableClasses = 0x7FFF;
			Model = 6705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Unconscious Dig Rat";
			Name2 = "Unconscious Dig Rat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 5161 , 0 , -1 , 1000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Mark of the Syndicate)
*
***************************************************************/

namespace Server.Items
{
	public class MarkOfTheSyndicate : Item
	{
		public MarkOfTheSyndicate() : base()
		{
			Id = 5113;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 6565;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Mark of the Syndicate";
			Name2 = "Mark of the Syndicate";
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Severed Talon)
*
***************************************************************/

namespace Server.Items
{
	public class SeveredTalon : Item
	{
		public SeveredTalon() : base()
		{
			Id = 5114;
			SellPrice = 96;
			AvailableClasses = 0x7FFF;
			Model = 6627;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Severed Talon";
			Name2 = "Severed Talon";
			AvailableRaces = 0x1FF;
			BuyPrice = 385;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Wishbone)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenWishbone : Item
	{
		public BrokenWishbone() : base()
		{
			Id = 5115;
			SellPrice = 101;
			AvailableClasses = 0x7FFF;
			Model = 18072;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Wishbone";
			Name2 = "Broken Wishbone";
			AvailableRaces = 0x1FF;
			BuyPrice = 405;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Vibrant Plume)
*
***************************************************************/

namespace Server.Items
{
	public class VibrantPlume : Item
	{
		public VibrantPlume() : base()
		{
			Id = 5117;
			SellPrice = 825;
			AvailableClasses = 0x7FFF;
			Model = 19570;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Vibrant Plume";
			Name2 = "Vibrant Plume";
			AvailableRaces = 0x1FF;
			BuyPrice = 3300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Flat Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class LargeFlatTooth : Item
	{
		public LargeFlatTooth() : base()
		{
			Id = 5118;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 6657;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Flat Tooth";
			Name2 = "Large Flat Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Fine Loose Hair)
*
***************************************************************/

namespace Server.Items
{
	public class FineLooseHair : Item
	{
		public FineLooseHair() : base()
		{
			Id = 5119;
			SellPrice = 118;
			AvailableClasses = 0x7FFF;
			Model = 18095;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fine Loose Hair";
			Name2 = "Fine Loose Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 475;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Long Tail Hair)
*
***************************************************************/

namespace Server.Items
{
	public class LongTailHair : Item
	{
		public LongTailHair() : base()
		{
			Id = 5120;
			SellPrice = 193;
			AvailableClasses = 0x7FFF;
			Model = 18096;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Long Tail Hair";
			Name2 = "Long Tail Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 775;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Dirty Kodo Scale)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyKodoScale : Item
	{
		public DirtyKodoScale() : base()
		{
			Id = 5121;
			SellPrice = 162;
			AvailableClasses = 0x7FFF;
			Model = 6646;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dirty Kodo Scale";
			Name2 = "Dirty Kodo Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 650;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thick Kodo Hair)
*
***************************************************************/

namespace Server.Items
{
	public class ThickKodoHair : Item
	{
		public ThickKodoHair() : base()
		{
			Id = 5122;
			SellPrice = 287;
			AvailableClasses = 0x7FFF;
			Model = 6702;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thick Kodo Hair";
			Name2 = "Thick Kodo Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 1150;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Steel Arrowhead)
*
***************************************************************/

namespace Server.Items
{
	public class SteelArrowhead : Item
	{
		public SteelArrowhead() : base()
		{
			Id = 5123;
			SellPrice = 117;
			AvailableClasses = 0x7FFF;
			Model = 6701;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Steel Arrowhead";
			Name2 = "Steel Arrowhead";
			AvailableRaces = 0x1FF;
			BuyPrice = 470;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Small Raptor Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class SmallRaptorTooth : Item
	{
		public SmallRaptorTooth() : base()
		{
			Id = 5124;
			SellPrice = 117;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Raptor Tooth";
			Name2 = "Small Raptor Tooth";
			AvailableRaces = 0x1FF;
			BuyPrice = 470;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Charged Scale)
*
***************************************************************/

namespace Server.Items
{
	public class ChargedScale : Item
	{
		public ChargedScale() : base()
		{
			Id = 5125;
			SellPrice = 155;
			AvailableClasses = 0x7FFF;
			Model = 6628;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Charged Scale";
			Name2 = "Charged Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 620;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Shed Lizard Skin)
*
***************************************************************/

namespace Server.Items
{
	public class ShedLizardSkin : Item
	{
		public ShedLizardSkin() : base()
		{
			Id = 5128;
			SellPrice = 202;
			AvailableClasses = 0x7FFF;
			Model = 568;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shed Lizard Skin";
			Name2 = "Shed Lizard Skin";
			AvailableRaces = 0x1FF;
			BuyPrice = 810;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Seeping Gizzard)
*
***************************************************************/

namespace Server.Items
{
	public class SeepingGizzard : Item
	{
		public SeepingGizzard() : base()
		{
			Id = 5133;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 1438;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Seeping Gizzard";
			Name2 = "Seeping Gizzard";
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Small Furry Paw)
*
***************************************************************/

namespace Server.Items
{
	public class SmallFurryPaw : Item
	{
		public SmallFurryPaw() : base()
		{
			Id = 5134;
			SellPrice = 92;
			AvailableClasses = 0x7FFF;
			Model = 7231;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Furry Paw";
			Name2 = "Small Furry Paw";
			AvailableRaces = 0x1FF;
			BuyPrice = 370;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thin Black Claw)
*
***************************************************************/

namespace Server.Items
{
	public class ThinBlackClaw : Item
	{
		public ThinBlackClaw() : base()
		{
			Id = 5135;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 6651;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thin Black Claw";
			Name2 = "Thin Black Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 570;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Torn Furry Ear)
*
***************************************************************/

namespace Server.Items
{
	public class TornFurryEar : Item
	{
		public TornFurryEar() : base()
		{
			Id = 5136;
			SellPrice = 177;
			AvailableClasses = 0x7FFF;
			Model = 6704;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Torn Furry Ear";
			Name2 = "Torn Furry Ear";
			AvailableRaces = 0x1FF;
			BuyPrice = 710;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bright Eyeball)
*
***************************************************************/

namespace Server.Items
{
	public class BrightEyeball : Item
	{
		public BrightEyeball() : base()
		{
			Id = 5137;
			SellPrice = 217;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bright Eyeball";
			Name2 = "Bright Eyeball";
			AvailableRaces = 0x1FF;
			BuyPrice = 870;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pocket Lint)
*
***************************************************************/

namespace Server.Items
{
	public class PocketLint : Item
	{
		public PocketLint() : base()
		{
			Id = 5263;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6238;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Pocket Lint";
			Name2 = "Pocket Lint";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cracked Silithid Shell)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedSilithidShell : Item
	{
		public CrackedSilithidShell() : base()
		{
			Id = 5268;
			SellPrice = 218;
			AvailableClasses = 0x7FFF;
			Model = 16363;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cracked Silithid Shell";
			Name2 = "Cracked Silithid Shell";
			AvailableRaces = 0x1FF;
			BuyPrice = 875;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Silithid Ichor)
*
***************************************************************/

namespace Server.Items
{
	public class SilithidIchor : Item
	{
		public SilithidIchor() : base()
		{
			Id = 5269;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Silithid Ichor";
			Name2 = "Silithid Ichor";
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Cat Figurine)
*
***************************************************************/

namespace Server.Items
{
	public class CatFigurine : Item
	{
		public CatFigurine() : base()
		{
			Id = 5329;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 8289;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cat Figurine";
			Name2 = "Cat Figurine";
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Glowing Cat Figurine)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingCatFigurine : Item
	{
		public GlowingCatFigurine() : base()
		{
			Id = 5332;
			Bonding = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 8289;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Glowing Cat Figurine";
			Name2 = "Glowing Cat Figurine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 6084 , 0 , -1 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(A Sack of Coins)
*
***************************************************************/

namespace Server.Items
{
	public class ASackOfCoins : Item
	{
		public ASackOfCoins() : base()
		{
			Id = 5335;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 1183;
			ObjectClass = 15;
			SubClass = 0;
			Level = 18;
			Name = "A Sack of Coins";
			Name2 = "A Sack of Coins";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Fishbone Toothpick)
*
***************************************************************/

namespace Server.Items
{
	public class FishboneToothpick : Item
	{
		public FishboneToothpick() : base()
		{
			Id = 5361;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 6651;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fishbone Toothpick";
			Name2 = "Fishbone Toothpick";
			AvailableRaces = 0x1FF;
			BuyPrice = 65;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chew Toy)
*
***************************************************************/

namespace Server.Items
{
	public class ChewToy : Item
	{
		public ChewToy() : base()
		{
			Id = 5362;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chew Toy";
			Name2 = "Chew Toy";
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Folded Handkerchief)
*
***************************************************************/

namespace Server.Items
{
	public class FoldedHandkerchief : Item
	{
		public FoldedHandkerchief() : base()
		{
			Id = 5363;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 7717;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Folded Handkerchief";
			Name2 = "Folded Handkerchief";
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Dry Salt Lick)
*
***************************************************************/

namespace Server.Items
{
	public class DrySaltLick : Item
	{
		public DrySaltLick() : base()
		{
			Id = 5364;
			SellPrice = 27;
			AvailableClasses = 0x7FFF;
			Model = 4718;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dry Salt Lick";
			Name2 = "Dry Salt Lick";
			AvailableRaces = 0x1FF;
			BuyPrice = 110;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Primitive Rock Tool)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveRockTool : Item
	{
		public PrimitiveRockTool() : base()
		{
			Id = 5367;
			SellPrice = 22;
			AvailableClasses = 0x7FFF;
			Model = 4717;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Primitive Rock Tool";
			Name2 = "Primitive Rock Tool";
			AvailableRaces = 0x1FF;
			BuyPrice = 90;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Empty Wallet)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyWallet : Item
	{
		public EmptyWallet() : base()
		{
			Id = 5368;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 7718;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Empty Wallet";
			Name2 = "Empty Wallet";
			AvailableRaces = 0x1FF;
			BuyPrice = 195;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Gnawed Bone)
*
***************************************************************/

namespace Server.Items
{
	public class GnawedBone : Item
	{
		public GnawedBone() : base()
		{
			Id = 5369;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 7251;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gnawed Bone";
			Name2 = "Gnawed Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 130;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Bent Spoon)
*
***************************************************************/

namespace Server.Items
{
	public class BentSpoon : Item
	{
		public BentSpoon() : base()
		{
			Id = 5370;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 7716;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bent Spoon";
			Name2 = "Bent Spoon";
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Piece of Coral)
*
***************************************************************/

namespace Server.Items
{
	public class PieceOfCoral : Item
	{
		public PieceOfCoral() : base()
		{
			Id = 5371;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 7713;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Piece of Coral";
			Name2 = "Piece of Coral";
			AvailableRaces = 0x1FF;
			BuyPrice = 195;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lucky Charm)
*
***************************************************************/

namespace Server.Items
{
	public class LuckyCharm : Item
	{
		public LuckyCharm() : base()
		{
			Id = 5373;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 15026;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Lucky Charm";
			Name2 = "Lucky Charm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 290;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Small Pocket Watch)
*
***************************************************************/

namespace Server.Items
{
	public class SmallPocketWatch : Item
	{
		public SmallPocketWatch() : base()
		{
			Id = 5374;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 7719;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Pocket Watch";
			Name2 = "Small Pocket Watch";
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Scratching Stick)
*
***************************************************************/

namespace Server.Items
{
	public class ScratchingStick : Item
	{
		public ScratchingStick() : base()
		{
			Id = 5375;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 8119;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Scratching Stick";
			Name2 = "Scratching Stick";
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Broken Mirror)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenMirror : Item
	{
		public BrokenMirror() : base()
		{
			Id = 5376;
			SellPrice = 66;
			AvailableClasses = 0x7FFF;
			Model = 7268;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Mirror";
			Name2 = "Broken Mirror";
			AvailableRaces = 0x1FF;
			BuyPrice = 265;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Scallop Shell)
*
***************************************************************/

namespace Server.Items
{
	public class ScallopShell : Item
	{
		public ScallopShell() : base()
		{
			Id = 5377;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 7714;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Scallop Shell";
			Name2 = "Scallop Shell";
			AvailableRaces = 0x1FF;
			BuyPrice = 230;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Crude Pocket Watch)
*
***************************************************************/

namespace Server.Items
{
	public class CrudePocketWatch : Item
	{
		public CrudePocketWatch() : base()
		{
			Id = 5427;
			SellPrice = 147;
			AvailableClasses = 0x7FFF;
			Model = 8118;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crude Pocket Watch";
			Name2 = "Crude Pocket Watch";
			AvailableRaces = 0x1FF;
			BuyPrice = 590;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(An Exotic Cookbook)
*
***************************************************************/

namespace Server.Items
{
	public class AnExoticCookbook : Item
	{
		public AnExoticCookbook() : base()
		{
			Id = 5428;
			SellPrice = 322;
			AvailableClasses = 0x7FFF;
			Description = "How To Serve Man";
			Model = 8117;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "An Exotic Cookbook";
			Name2 = "An Exotic Cookbook";
			AvailableRaces = 0x1FF;
			BuyPrice = 1290;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
			PageText = 410;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(A Pretty Rock)
*
***************************************************************/

namespace Server.Items
{
	public class APrettyRock : Item
	{
		public APrettyRock() : base()
		{
			Id = 5429;
			SellPrice = 137;
			AvailableClasses = 0x7FFF;
			Model = 8121;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Pretty Rock";
			Name2 = "A Pretty Rock";
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Intricate Bauble)
*
***************************************************************/

namespace Server.Items
{
	public class IntricateBauble : Item
	{
		public IntricateBauble() : base()
		{
			Id = 5430;
			SellPrice = 277;
			AvailableClasses = 0x7FFF;
			Model = 8120;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Intricate Bauble";
			Name2 = "Intricate Bauble";
			AvailableRaces = 0x1FF;
			BuyPrice = 1110;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Empty Hip Flask)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyHipFlask : Item
	{
		public EmptyHipFlask() : base()
		{
			Id = 5431;
			SellPrice = 155;
			AvailableClasses = 0x7FFF;
			Model = 18058;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Empty Hip Flask";
			Name2 = "Empty Hip Flask";
			AvailableRaces = 0x1FF;
			BuyPrice = 620;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Hickory Pipe)
*
***************************************************************/

namespace Server.Items
{
	public class HickoryPipe : Item
	{
		public HickoryPipe() : base()
		{
			Id = 5432;
			SellPrice = 330;
			AvailableClasses = 0x7FFF;
			Model = 8114;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hickory Pipe";
			Name2 = "Hickory Pipe";
			AvailableRaces = 0x1FF;
			BuyPrice = 1320;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Rag Doll)
*
***************************************************************/

namespace Server.Items
{
	public class RagDoll : Item
	{
		public RagDoll() : base()
		{
			Id = 5433;
			SellPrice = 138;
			AvailableClasses = 0x7FFF;
			Model = 6358;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Rag Doll";
			Name2 = "Rag Doll";
			AvailableRaces = 0x1FF;
			BuyPrice = 555;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Shiny Dinglehopper)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyDinglehopper : Item
	{
		public ShinyDinglehopper() : base()
		{
			Id = 5435;
			SellPrice = 272;
			AvailableClasses = 0x7FFF;
			Model = 8115;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shiny Dinglehopper";
			Name2 = "Shiny Dinglehopper";
			AvailableRaces = 0x1FF;
			BuyPrice = 1090;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Beady Eye Stalk)
*
***************************************************************/

namespace Server.Items
{
	public class BeadyEyeStalk : Item
	{
		public BeadyEyeStalk() : base()
		{
			Id = 5506;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Beady Eye Stalk";
			Name2 = "Beady Eye Stalk";
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Small Barnacled Clam)
*
***************************************************************/

namespace Server.Items
{
	public class SmallBarnacledClam : Item
	{
		public SmallBarnacledClam() : base()
		{
			Id = 5523;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 7177;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			Name = "Small Barnacled Clam";
			Name2 = "Small Barnacled Clam";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Thick-shelled Clam)
*
***************************************************************/

namespace Server.Items
{
	public class ThickShelledClam : Item
	{
		public ThickShelledClam() : base()
		{
			Id = 5524;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 16212;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Thick-shelled Clam";
			Name2 = "Thick-shelled Clam";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 85;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Broken Antler)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenAntler : Item
	{
		public BrokenAntler() : base()
		{
			Id = 5566;
			SellPrice = 105;
			AvailableClasses = 0x7FFF;
			Model = 8232;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Antler";
			Name2 = "Broken Antler";
			AvailableRaces = 0x1FF;
			BuyPrice = 420;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Silver Hook)
*
***************************************************************/

namespace Server.Items
{
	public class SilverHook : Item
	{
		public SilverHook() : base()
		{
			Id = 5567;
			SellPrice = 196;
			AvailableClasses = 0x7FFF;
			Model = 8233;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Silver Hook";
			Name2 = "Silver Hook";
			AvailableRaces = 0x1FF;
			BuyPrice = 785;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Seaweed)
*
***************************************************************/

namespace Server.Items
{
	public class Seaweed : Item
	{
		public Seaweed() : base()
		{
			Id = 5569;
			SellPrice = 203;
			AvailableClasses = 0x7FFF;
			Model = 7415;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Seaweed";
			Name2 = "Seaweed";
			AvailableRaces = 0x1FF;
			BuyPrice = 815;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Hatched Egg Sac)
*
***************************************************************/

namespace Server.Items
{
	public class HatchedEggSac : Item
	{
		public HatchedEggSac() : base()
		{
			Id = 5601;
			SellPrice = 22;
			AvailableClasses = 0x7FFF;
			Model = 18053;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hatched Egg Sac";
			Name2 = "Hatched Egg Sac";
			AvailableRaces = 0x1FF;
			BuyPrice = 90;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Sticky Spider Webbing)
*
***************************************************************/

namespace Server.Items
{
	public class StickySpiderWebbing : Item
	{
		public StickySpiderWebbing() : base()
		{
			Id = 5602;
			SellPrice = 63;
			AvailableClasses = 0x7FFF;
			Model = 18597;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sticky Spider Webbing";
			Name2 = "Sticky Spider Webbing";
			AvailableRaces = 0x1FF;
			BuyPrice = 255;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chestnut Mare Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class ChestnutMareBridle : Item
	{
		public ChestnutMareBridle() : base()
		{
			Id = 5655;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Chestnut Mare Bridle";
			Name2 = "Chestnut Mare Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6648 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Brown Horse Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class BrownHorseBridle : Item
	{
		public BrownHorseBridle() : base()
		{
			Id = 5656;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Brown Horse Bridle";
			Name2 = "Brown Horse Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 458 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Red Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheRedWolf : Item
	{
		public HornOfTheRedWolf() : base()
		{
			Id = 5663;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Red Wolf";
			Name2 = "Horn of the Red Wolf";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 579 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Dire Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheDireWolf : Item
	{
		public HornOfTheDireWolf() : base()
		{
			Id = 5665;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Dire Wolf";
			Name2 = "Horn of the Dire Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6653 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Brown Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheBrownWolf : Item
	{
		public HornOfTheBrownWolf() : base()
		{
			Id = 5668;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Brown Wolf";
			Name2 = "Horn of the Brown Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6654 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Covert Ops Pack)
*
***************************************************************/

namespace Server.Items
{
	public class CovertOpsPack : Item
	{
		public CovertOpsPack() : base()
		{
			Id = 5738;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 8631;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Covert Ops Pack";
			Name2 = "Covert Ops Pack";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Rock Chip)
*
***************************************************************/

namespace Server.Items
{
	public class RockChip : Item
	{
		public RockChip() : base()
		{
			Id = 5741;
			SellPrice = 111;
			AvailableClasses = 0x7FFF;
			Model = 4719;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Rock Chip";
			Name2 = "Rock Chip";
			AvailableRaces = 0x1FF;
			BuyPrice = 445;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mithril Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilLockbox : Item
	{
		public MithrilLockbox() : base()
		{
			Id = 5758;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Mithril Lockbox";
			Name2 = "Mithril Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 62;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Thorium Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumLockbox : Item
	{
		public ThoriumLockbox() : base()
		{
			Id = 5759;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "Thorium Lockbox";
			Name2 = "Thorium Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 62;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Eternium Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class EterniumLockbox : Item
	{
		public EterniumLockbox() : base()
		{
			Id = 5760;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 9632;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			Name = "Eternium Lockbox";
			Name2 = "Eternium Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 62;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Razor-sharp Beak)
*
***************************************************************/

namespace Server.Items
{
	public class RazorSharpBeak : Item
	{
		public RazorSharpBeak() : base()
		{
			Id = 5829;
			SellPrice = 804;
			AvailableClasses = 0x7FFF;
			Model = 6633;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Razor-sharp Beak";
			Name2 = "Razor-sharp Beak";
			AvailableRaces = 0x1FF;
			BuyPrice = 3216;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Journal Page)
*
***************************************************************/

namespace Server.Items
{
	public class JournalPage : Item
	{
		public JournalPage() : base()
		{
			Id = 5839;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9135;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Journal Page";
			Name2 = "Journal Page";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 443;
			Language = 2;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Guild Charter)
*
***************************************************************/

namespace Server.Items
{
	public class GuildCharter : Item
	{
		public GuildCharter() : base()
		{
			Id = 5863;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16161;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Guild Charter";
			Name2 = "Guild Charter";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 8192;
		}
	}
}


/**************************************************************
*
*				(Gray Ram)
*
***************************************************************/

namespace Server.Items
{
	public class GrayRam : Item
	{
		public GrayRam() : base()
		{
			Id = 5864;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Gray Ram";
			Name2 = "Gray Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6777 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Large Hoof)
*
***************************************************************/

namespace Server.Items
{
	public class LargeHoof : Item
	{
		public LargeHoof() : base()
		{
			Id = 5871;
			SellPrice = 318;
			AvailableClasses = 0x7FFF;
			Model = 7296;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Hoof";
			Name2 = "Large Hoof";
			AvailableRaces = 0x1FF;
			BuyPrice = 1275;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Brown Ram)
*
***************************************************************/

namespace Server.Items
{
	public class BrownRam : Item
	{
		public BrownRam() : base()
		{
			Id = 5872;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Brown Ram";
			Name2 = "Brown Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6899 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(White Ram)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteRam : Item
	{
		public WhiteRam() : base()
		{
			Id = 5873;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "White Ram";
			Name2 = "White Ram";
			Quality = 1;
			AvailableRaces = 0x14D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6898 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Harness: Black Ram)
*
***************************************************************/

namespace Server.Items
{
	public class HarnessBlackRam : Item
	{
		public HarnessBlackRam() : base()
		{
			Id = 5874;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Harness: Black Ram";
			Name2 = "Harness: Black Ram";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 6896 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Harness: Blue Ram)
*
***************************************************************/

namespace Server.Items
{
	public class HarnessBlueRam : Item
	{
		public HarnessBlueRam() : base()
		{
			Id = 5875;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Harness: Blue Ram";
			Name2 = "Harness: Blue Ram";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 6897 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Blacksmith Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BlacksmithHammer : Item
	{
		public BlacksmithHammer() : base()
		{
			Id = 5956;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 8568;
			ObjectClass = 2;
			SubClass = 14;
			Level = 1;
			ReqLevel = 1;
			Name = "Blacksmith Hammer";
			Name2 = "Blacksmith Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 18;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			SetDamage( 2 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(A Frayed Knot)
*
***************************************************************/

namespace Server.Items
{
	public class AFrayedKnot : Item
	{
		public AFrayedKnot() : base()
		{
			Id = 6150;
			SellPrice = 22;
			AvailableClasses = 0x7FFF;
			Model = 10301;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Frayed Knot";
			Name2 = "A Frayed Knot";
			AvailableRaces = 0x1FF;
			BuyPrice = 90;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Arclight Spanner)
*
***************************************************************/

namespace Server.Items
{
	public class ArclightSpanner : Item
	{
		public ArclightSpanner() : base()
		{
			Id = 6219;
			SellPrice = 144;
			AvailableClasses = 0x7FFF;
			Model = 7494;
			ObjectClass = 2;
			SubClass = 14;
			Level = 10;
			Name = "Arclight Spanner";
			Name2 = "Arclight Spanner";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 202;
			BuyPrice = 721;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			SetDamage( 5 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(10 Pound Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class _10PoundMudSnapper : Item
	{
		public _10PoundMudSnapper() : base()
		{
			Id = 6292;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 24701;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "10 Pound Mud Snapper";
			Name2 = "10 Pound Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 34;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dried Bat Blood)
*
***************************************************************/

namespace Server.Items
{
	public class DriedBatBlood : Item
	{
		public DriedBatBlood() : base()
		{
			Id = 6293;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 11199;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dried Bat Blood";
			Name2 = "Dried Bat Blood";
			AvailableRaces = 0x1FF;
			BuyPrice = 135;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(12 Pound Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class _12PoundMudSnapper : Item
	{
		public _12PoundMudSnapper() : base()
		{
			Id = 6294;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24701;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "12 Pound Mud Snapper";
			Name2 = "12 Pound Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(15 Pound Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class _15PoundMudSnapper : Item
	{
		public _15PoundMudSnapper() : base()
		{
			Id = 6295;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 24701;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "15 Pound Mud Snapper";
			Name2 = "15 Pound Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Patch of Bat Hair)
*
***************************************************************/

namespace Server.Items
{
	public class PatchOfBatHair : Item
	{
		public PatchOfBatHair() : base()
		{
			Id = 6296;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 6691;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Patch of Bat Hair";
			Name2 = "Patch of Bat Hair";
			AvailableRaces = 0x1FF;
			BuyPrice = 115;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Old Skull)
*
***************************************************************/

namespace Server.Items
{
	public class OldSkull : Item
	{
		public OldSkull() : base()
		{
			Id = 6297;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 7741;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Old Skull";
			Name2 = "Old Skull";
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bloody Bat Fang)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyBatFang : Item
	{
		public BloodyBatFang() : base()
		{
			Id = 6298;
			SellPrice = 130;
			AvailableClasses = 0x7FFF;
			Model = 6666;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bloody Bat Fang";
			Name2 = "Bloody Bat Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 520;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Husk Fragment)
*
***************************************************************/

namespace Server.Items
{
	public class HuskFragment : Item
	{
		public HuskFragment() : base()
		{
			Id = 6300;
			SellPrice = 443;
			AvailableClasses = 0x7FFF;
			Model = 6628;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Husk Fragment";
			Name2 = "Husk Fragment";
			AvailableRaces = 0x1FF;
			BuyPrice = 1775;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Old Teamster's Skull)
*
***************************************************************/

namespace Server.Items
{
	public class OldTeamstersSkull : Item
	{
		public OldTeamstersSkull() : base()
		{
			Id = 6301;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Description = "Looks like someone didn't like this guy.";
			Model = 6375;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Old Teamster's Skull";
			Name2 = "Old Teamster's Skull";
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Delicate Insect Wing)
*
***************************************************************/

namespace Server.Items
{
	public class DelicateInsectWing : Item
	{
		public DelicateInsectWing() : base()
		{
			Id = 6302;
			SellPrice = 628;
			AvailableClasses = 0x7FFF;
			Model = 4433;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Delicate Insect Wing";
			Name2 = "Delicate Insect Wing";
			AvailableRaces = 0x1FF;
			BuyPrice = 2515;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Damp Diary Page (Day 4))
*
***************************************************************/

namespace Server.Items
{
	public class DampDiaryPageDay4 : Item
	{
		public DampDiaryPageDay4() : base()
		{
			Id = 6304;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Damp Diary Page (Day 4)";
			Name2 = "Damp Diary Page (Day 4)";
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 696;
			Language = 7;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Damp Diary Page (Day 87))
*
***************************************************************/

namespace Server.Items
{
	public class DampDiaryPageDay87 : Item
	{
		public DampDiaryPageDay87() : base()
		{
			Id = 6305;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Damp Diary Page (Day 87)";
			Name2 = "Damp Diary Page (Day 87)";
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 1251;
			Language = 7;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Damp Diary Page (Day 512))
*
***************************************************************/

namespace Server.Items
{
	public class DampDiaryPageDay512 : Item
	{
		public DampDiaryPageDay512() : base()
		{
			Id = 6306;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Damp Diary Page (Day 512)";
			Name2 = "Damp Diary Page (Day 512)";
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 697;
			Language = 7;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Message in a Bottle)
*
***************************************************************/

namespace Server.Items
{
	public class MessageInABottle : Item
	{
		public MessageInABottle() : base()
		{
			Id = 6307;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18113;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Message in a Bottle";
			Name2 = "Message in a Bottle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(17 Pound Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class _17PoundCatfish : Item
	{
		public _17PoundCatfish() : base()
		{
			Id = 6309;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 24712;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "17 Pound Catfish";
			Name2 = "17 Pound Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(19 Pound Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class _19PoundCatfish : Item
	{
		public _19PoundCatfish() : base()
		{
			Id = 6310;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 24712;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "19 Pound Catfish";
			Name2 = "19 Pound Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(22 Pound Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class _22PoundCatfish : Item
	{
		public _22PoundCatfish() : base()
		{
			Id = 6311;
			SellPrice = 187;
			AvailableClasses = 0x7FFF;
			Model = 24712;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "22 Pound Catfish";
			Name2 = "22 Pound Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 750;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dented Crate)
*
***************************************************************/

namespace Server.Items
{
	public class DentedCrate : Item
	{
		public DentedCrate() : base()
		{
			Id = 6351;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Description = "Venture Company Supplies";
			Model = 9151;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Dented Crate";
			Name2 = "Dented Crate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Waterlogged Crate)
*
***************************************************************/

namespace Server.Items
{
	public class WaterloggedCrate : Item
	{
		public WaterloggedCrate() : base()
		{
			Id = 6352;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Description = "Venture Company Supplies";
			Model = 9822;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "Waterlogged Crate";
			Name2 = "Waterlogged Crate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Small Chest)
*
***************************************************************/

namespace Server.Items
{
	public class SmallChest : Item
	{
		public SmallChest() : base()
		{
			Id = 6353;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Small Chest";
			Name2 = "Small Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Small Locked Chest)
*
***************************************************************/

namespace Server.Items
{
	public class SmallLockedChest : Item
	{
		public SmallLockedChest() : base()
		{
			Id = 6354;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12332;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Small Locked Chest";
			Name2 = "Small Locked Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 5;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sturdy Locked Chest)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyLockedChest : Item
	{
		public SturdyLockedChest() : base()
		{
			Id = 6355;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Sturdy Locked Chest";
			Name2 = "Sturdy Locked Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 24;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Battered Chest)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredChest : Item
	{
		public BatteredChest() : base()
		{
			Id = 6356;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 8;
			Name = "Battered Chest";
			Name2 = "Battered Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sealed Crate)
*
***************************************************************/

namespace Server.Items
{
	public class SealedCrate : Item
	{
		public SealedCrate() : base()
		{
			Id = 6357;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Description = "Venture Company Supplies";
			Model = 8928;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Sealed Crate";
			Name2 = "Sealed Crate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(26 Pound Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class _26PoundCatfish : Item
	{
		public _26PoundCatfish() : base()
		{
			Id = 6363;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 24712;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "26 Pound Catfish";
			Name2 = "26 Pound Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(32 Pound Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class _32PoundCatfish : Item
	{
		public _32PoundCatfish() : base()
		{
			Id = 6364;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 24712;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "32 Pound Catfish";
			Name2 = "32 Pound Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Dull Elemental Bracer)
*
***************************************************************/

namespace Server.Items
{
	public class DullElementalBracer : Item
	{
		public DullElementalBracer() : base()
		{
			Id = 6438;
			SellPrice = 362;
			AvailableClasses = 0x7FFF;
			Model = 11791;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dull Elemental Bracer";
			Name2 = "Dull Elemental Bracer";
			AvailableRaces = 0x1FF;
			BuyPrice = 1450;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Binding Bracer)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenBindingBracer : Item
	{
		public BrokenBindingBracer() : base()
		{
			Id = 6439;
			SellPrice = 237;
			AvailableClasses = 0x7FFF;
			Model = 11791;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Binding Bracer";
			Name2 = "Broken Binding Bracer";
			AvailableRaces = 0x1FF;
			BuyPrice = 950;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Forked Tongue)
*
***************************************************************/

namespace Server.Items
{
	public class ForkedTongue : Item
	{
		public ForkedTongue() : base()
		{
			Id = 6444;
			SellPrice = 228;
			AvailableClasses = 0x7FFF;
			Model = 11889;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Forked Tongue";
			Name2 = "Forked Tongue";
			AvailableRaces = 0x1FF;
			BuyPrice = 915;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Brittle Molting)
*
***************************************************************/

namespace Server.Items
{
	public class BrittleMolting : Item
	{
		public BrittleMolting() : base()
		{
			Id = 6445;
			SellPrice = 88;
			AvailableClasses = 0x7FFF;
			Model = 6629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Brittle Molting";
			Name2 = "Brittle Molting";
			AvailableRaces = 0x1FF;
			BuyPrice = 352;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Old Wagonwheel)
*
***************************************************************/

namespace Server.Items
{
	public class OldWagonwheel : Item
	{
		public OldWagonwheel() : base()
		{
			Id = 6455;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 18706;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Old Wagonwheel";
			Name2 = "Old Wagonwheel";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Acidic Slime)
*
***************************************************************/

namespace Server.Items
{
	public class AcidicSlime : Item
	{
		public AcidicSlime() : base()
		{
			Id = 6456;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Acidic Slime";
			Name2 = "Acidic Slime";
			AvailableRaces = 0x1FF;
			BuyPrice = 12;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rusted Engineering Parts)
*
***************************************************************/

namespace Server.Items
{
	public class RustedEngineeringParts : Item
	{
		public RustedEngineeringParts() : base()
		{
			Id = 6457;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 3257;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Rusted Engineering Parts";
			Name2 = "Rusted Engineering Parts";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Practice Lock)
*
***************************************************************/

namespace Server.Items
{
	public class PracticeLock : Item
	{
		public PracticeLock() : base()
		{
			Id = 6712;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 12925;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Practice Lock";
			Name2 = "Practice Lock";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 5;
			Material = 1;
		}
	}
}


/**************************************************************
*
*				(A Small Container of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class ASmallContainerOfGems : Item
	{
		public ASmallContainerOfGems() : base()
		{
			Id = 6755;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 12991;
			ObjectClass = 15;
			SubClass = 0;
			Level = 25;
			Name = "A Small Container of Gems";
			Name2 = "A Small Container of Gems";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Brilliant Scale)
*
***************************************************************/

namespace Server.Items
{
	public class BrilliantScale : Item
	{
		public BrilliantScale() : base()
		{
			Id = 6826;
			SellPrice = 548;
			AvailableClasses = 0x7FFF;
			Model = 6658;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Brilliant Scale";
			Name2 = "Brilliant Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 2195;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Box of Supplies)
*
***************************************************************/

namespace Server.Items
{
	public class BoxOfSupplies : Item
	{
		public BoxOfSupplies() : base()
		{
			Id = 6827;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 13110;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Box of Supplies";
			Name2 = "Box of Supplies";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Hearthstone)
*
***************************************************************/

namespace Server.Items
{
	public class Hearthstone : Item
	{
		public Hearthstone() : base()
		{
			Id = 6948;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6418;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hearthstone";
			Name2 = "Hearthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8690 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Skinning Knife)
*
***************************************************************/

namespace Server.Items
{
	public class SkinningKnife : Item
	{
		public SkinningKnife() : base()
		{
			Id = 7005;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 6440;
			ObjectClass = 2;
			SubClass = 14;
			Level = 4;
			ReqLevel = 1;
			Name = "Skinning Knife";
			Name2 = "Skinning Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Broken Fang)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenFang : Item
	{
		public BrokenFang() : base()
		{
			Id = 7073;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Fang";
			Name2 = "Broken Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Chipped Claw)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedClaw : Item
	{
		public ChippedClaw() : base()
		{
			Id = 7074;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 7048;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chipped Claw";
			Name2 = "Chipped Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Plucked Feather)
*
***************************************************************/

namespace Server.Items
{
	public class PluckedFeather : Item
	{
		public PluckedFeather() : base()
		{
			Id = 7096;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 19573;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Plucked Feather";
			Name2 = "Plucked Feather";
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Splintered Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class SplinteredTusk : Item
	{
		public SplinteredTusk() : base()
		{
			Id = 7098;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 3429;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Splintered Tusk";
			Name2 = "Splintered Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Severed Pincer)
*
***************************************************************/

namespace Server.Items
{
	public class SeveredPincer : Item
	{
		public SeveredPincer() : base()
		{
			Id = 7099;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 13713;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Severed Pincer";
			Name2 = "Severed Pincer";
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Sticky Ichor)
*
***************************************************************/

namespace Server.Items
{
	public class StickyIchor : Item
	{
		public StickyIchor() : base()
		{
			Id = 7100;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 13715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sticky Ichor";
			Name2 = "Sticky Ichor";
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Bug Eye)
*
***************************************************************/

namespace Server.Items
{
	public class BugEye : Item
	{
		public BugEye() : base()
		{
			Id = 7101;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 13714;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bug Eye";
			Name2 = "Bug Eye";
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Broken Dragonmaw Shinbone)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenDragonmawShinbone : Item
	{
		public BrokenDragonmawShinbone() : base()
		{
			Id = 7135;
			AvailableClasses = 0x7FFF;
			Model = 13806;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Dragonmaw Shinbone";
			Name2 = "Broken Dragonmaw Shinbone";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
		}
	}
}


/**************************************************************
*
*				(Scorched Rocket Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ScorchedRocketBoots : Item
	{
		public ScorchedRocketBoots() : base()
		{
			Id = 7190;
			AvailableClasses = 0x7FFF;
			Model = 20623;
			ObjectClass = 15;
			SubClass = 0;
			Level = 26;
			Name = "Scorched Rocket Boots";
			Name2 = "Scorched Rocket Boots";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Tazan's Satchel)
*
***************************************************************/

namespace Server.Items
{
	public class TazansSatchel : Item
	{
		public TazansSatchel() : base()
		{
			Id = 7209;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 13884;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Tazan's Satchel";
			Name2 = "Tazan's Satchel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			LockId = 319;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Chest of Containment Coffers)
*
***************************************************************/

namespace Server.Items
{
	public class ChestOfContainmentCoffers : Item
	{
		public ChestOfContainmentCoffers() : base()
		{
			Id = 7247;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 11449;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chest of Containment Coffers";
			Name2 = "Chest of Containment Coffers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 9082 , 0 , 10 , 8000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Black Whelp Scale)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWhelpScale : Item
	{
		public BlackWhelpScale() : base()
		{
			Id = 7286;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6646;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Black Whelp Scale";
			Name2 = "Black Whelp Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Red Whelp Scale)
*
***************************************************************/

namespace Server.Items
{
	public class RedWhelpScale : Item
	{
		public RedWhelpScale() : base()
		{
			Id = 7287;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Red Whelp Scale";
			Name2 = "Red Whelp Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Extinguished Torch)
*
***************************************************************/

namespace Server.Items
{
	public class ExtinguishedTorch7296 : Item
	{
		public ExtinguishedTorch7296() : base()
		{
			Id = 7296;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 14019;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Extinguished Torch";
			Name2 = "Extinguished Torch";
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Green Whelp Scale)
*
***************************************************************/

namespace Server.Items
{
	public class GreenWhelpScale : Item
	{
		public GreenWhelpScale() : base()
		{
			Id = 7392;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 6646;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Green Whelp Scale";
			Name2 = "Green Whelp Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bloodstained Journal)
*
***************************************************************/

namespace Server.Items
{
	public class BloodstainedJournal : Item
	{
		public BloodstainedJournal() : base()
		{
			Id = 7668;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 4049;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bloodstained Journal";
			Name2 = "Bloodstained Journal";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
			PageText = 951;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Certificate of Thievery)
*
***************************************************************/

namespace Server.Items
{
	public class CertificateOfThievery : Item
	{
		public CertificateOfThievery() : base()
		{
			Id = 7907;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16065;
			ObjectClass = 15;
			SubClass = 0;
			Level = 16;
			Name = "Certificate of Thievery";
			Name2 = "Certificate of Thievery";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 992;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Big-mouth Clam)
*
***************************************************************/

namespace Server.Items
{
	public class BigMouthClam : Item
	{
		public BigMouthClam() : base()
		{
			Id = 7973;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 16211;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Big-mouth Clam";
			Name2 = "Big-mouth Clam";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sample of Zanzil's Altered Mixture)
*
***************************************************************/

namespace Server.Items
{
	public class SampleOfZanzilsAlteredMixture : Item
	{
		public SampleOfZanzilsAlteredMixture() : base()
		{
			Id = 8087;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 9731;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Sample of Zanzil's Altered Mixture";
			Name2 = "Sample of Zanzil's Altered Mixture";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Scorpid Scale)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpidScale : Item
	{
		public ScorpidScale() : base()
		{
			Id = 8154;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 2874;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Scorpid Scale";
			Name2 = "Scorpid Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Worn Dragonscale)
*
***************************************************************/

namespace Server.Items
{
	public class WornDragonscale : Item
	{
		public WornDragonscale() : base()
		{
			Id = 8165;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 22838;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Worn Dragonscale";
			Name2 = "Worn Dragonscale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Plain Letter)
*
***************************************************************/

namespace Server.Items
{
	public class PlainLetter : Item
	{
		public PlainLetter() : base()
		{
			Id = 8383;
			AvailableClasses = 0x7FFF;
			Model = 7798;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Plain Letter";
			Name2 = "Plain Letter";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Parrot Droppings)
*
***************************************************************/

namespace Server.Items
{
	public class ParrotDroppings : Item
	{
		public ParrotDroppings() : base()
		{
			Id = 8425;
			AvailableClasses = 0x7FFF;
			Model = 6703;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Parrot Droppings";
			Name2 = "Parrot Droppings";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Ruffled Feather)
*
***************************************************************/

namespace Server.Items
{
	public class LargeRuffledFeather : Item
	{
		public LargeRuffledFeather() : base()
		{
			Id = 8426;
			AvailableClasses = 0x7FFF;
			Model = 19570;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Ruffled Feather";
			Name2 = "Large Ruffled Feather";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mutilated Rat Carcass)
*
***************************************************************/

namespace Server.Items
{
	public class MutilatedRatCarcass : Item
	{
		public MutilatedRatCarcass() : base()
		{
			Id = 8427;
			AvailableClasses = 0x7FFF;
			Model = 16860;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "Mutilated Rat Carcass";
			Name2 = "Mutilated Rat Carcass";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Punctured Dew Gland)
*
***************************************************************/

namespace Server.Items
{
	public class PuncturedDewGland : Item
	{
		public PuncturedDewGland() : base()
		{
			Id = 8429;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 6703;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Punctured Dew Gland";
			Name2 = "Punctured Dew Gland";
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Empty Dew Gland)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyDewGland : Item
	{
		public EmptyDewGland() : base()
		{
			Id = 8430;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 18071;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Empty Dew Gland";
			Name2 = "Empty Dew Gland";
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Wastewander Water Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class WastewanderWaterPouch : Item
	{
		public WastewanderWaterPouch() : base()
		{
			Id = 8483;
			SellPrice = 171;
			AvailableClasses = 0x7FFF;
			Model = 18085;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Wastewander Water Pouch";
			Name2 = "Wastewander Water Pouch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 685;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Gadgetzan Water Co. Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class GadgetzanWaterCoCarePackage : Item
	{
		public GadgetzanWaterCoCarePackage() : base()
		{
			Id = 8484;
			Bonding = 1;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Description = "Model 103-XB!";
			Model = 18574;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gadgetzan Water Co. Care Package";
			Name2 = "Gadgetzan Water Co. Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 275;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Bombay))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierBombay : Item
	{
		public CatCarrierBombay() : base()
		{
			Id = 8485;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Bombay)";
			Name2 = "Cat Carrier (Bombay)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10673 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Cornish Rex))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierCornishRex : Item
	{
		public CatCarrierCornishRex() : base()
		{
			Id = 8486;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Cornish Rex)";
			Name2 = "Cat Carrier (Cornish Rex)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10674 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Orange Tabby))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierOrangeTabby : Item
	{
		public CatCarrierOrangeTabby() : base()
		{
			Id = 8487;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Orange Tabby)";
			Name2 = "Cat Carrier (Orange Tabby)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10676 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Silver Tabby))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierSilverTabby : Item
	{
		public CatCarrierSilverTabby() : base()
		{
			Id = 8488;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Silver Tabby)";
			Name2 = "Cat Carrier (Silver Tabby)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (White Kitten))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierWhiteKitten : Item
	{
		public CatCarrierWhiteKitten() : base()
		{
			Id = 8489;
			Bonding = 3;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (White Kitten)";
			Name2 = "Cat Carrier (White Kitten)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Siamese))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierSiamese : Item
	{
		public CatCarrierSiamese() : base()
		{
			Id = 8490;
			Bonding = 3;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Siamese)";
			Name2 = "Cat Carrier (Siamese)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cat Carrier (Black Tabby))
*
***************************************************************/

namespace Server.Items
{
	public class CatCarrierBlackTabby : Item
	{
		public CatCarrierBlackTabby() : base()
		{
			Id = 8491;
			Bonding = 3;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Cat Carrier (Black Tabby)";
			Name2 = "Cat Carrier (Black Tabby)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10675 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Parrot Cage (Green Wing Macaw))
*
***************************************************************/

namespace Server.Items
{
	public class ParrotCageGreenWingMacaw : Item
	{
		public ParrotCageGreenWingMacaw() : base()
		{
			Id = 8492;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 17292;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Parrot Cage (Green Wing Macaw)";
			Name2 = "Parrot Cage (Green Wing Macaw)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10683 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Parrot Cage (Hyacinth Macaw))
*
***************************************************************/

namespace Server.Items
{
	public class ParrotCageHyacinthMacaw : Item
	{
		public ParrotCageHyacinthMacaw() : base()
		{
			Id = 8494;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 17292;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Parrot Cage (Hyacinth Macaw)";
			Name2 = "Parrot Cage (Hyacinth Macaw)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10682 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Parrot Cage (Senegal))
*
***************************************************************/

namespace Server.Items
{
	public class ParrotCageSenegal : Item
	{
		public ParrotCageSenegal() : base()
		{
			Id = 8495;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 17292;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Parrot Cage (Senegal)";
			Name2 = "Parrot Cage (Senegal)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10684 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Parrot Cage (Cockatiel))
*
***************************************************************/

namespace Server.Items
{
	public class ParrotCageCockatiel : Item
	{
		public ParrotCageCockatiel() : base()
		{
			Id = 8496;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 17292;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Parrot Cage (Cockatiel)";
			Name2 = "Parrot Cage (Cockatiel)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Rabbit Crate (Snowshoe))
*
***************************************************************/

namespace Server.Items
{
	public class RabbitCrateSnowshoe : Item
	{
		public RabbitCrateSnowshoe() : base()
		{
			Id = 8497;
			Bonding = 3;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 17284;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Rabbit Crate (Snowshoe)";
			Name2 = "Rabbit Crate (Snowshoe)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10711 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tiny Emerald Whelpling)
*
***************************************************************/

namespace Server.Items
{
	public class TinyEmeraldWhelpling : Item
	{
		public TinyEmeraldWhelpling() : base()
		{
			Id = 8498;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 20655;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Tiny Emerald Whelpling";
			Name2 = "Tiny Emerald Whelpling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10698 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tiny Crimson Whelpling)
*
***************************************************************/

namespace Server.Items
{
	public class TinyCrimsonWhelpling : Item
	{
		public TinyCrimsonWhelpling() : base()
		{
			Id = 8499;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 20655;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Tiny Crimson Whelpling";
			Name2 = "Tiny Crimson Whelpling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10697 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Great Horned Owl)
*
***************************************************************/

namespace Server.Items
{
	public class GreatHornedOwl : Item
	{
		public GreatHornedOwl() : base()
		{
			Id = 8500;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19091;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Great Horned Owl";
			Name2 = "Great Horned Owl";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10707 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Hawk Owl)
*
***************************************************************/

namespace Server.Items
{
	public class HawkOwl : Item
	{
		public HawkOwl() : base()
		{
			Id = 8501;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19091;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Hawk Owl";
			Name2 = "Hawk Owl";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10706 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Large Fin)
*
***************************************************************/

namespace Server.Items
{
	public class LargeFin : Item
	{
		public LargeFin() : base()
		{
			Id = 8508;
			SellPrice = 178;
			AvailableClasses = 0x7FFF;
			Model = 11863;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Fin";
			Name2 = "Large Fin";
			AvailableRaces = 0x1FF;
			BuyPrice = 715;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Red Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class RedMechanostrider : Item
	{
		public RedMechanostrider() : base()
		{
			Id = 8563;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Red Mechanostrider";
			Name2 = "Red Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10873 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Skeletal Mount)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheSkeletalMount : Item
	{
		public HornOfTheSkeletalMount() : base()
		{
			Id = 8583;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Skeletal Mount";
			Name2 = "Horn of the Skeletal Mount";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8980 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Whistle of the Mottled Red Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheMottledRedRaptor : Item
	{
		public WhistleOfTheMottledRedRaptor() : base()
		{
			Id = 8586;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Whistle of the Mottled Red Raptor";
			Name2 = "Whistle of the Mottled Red Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16084 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Whistle of the Emerald Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheEmeraldRaptor : Item
	{
		public WhistleOfTheEmeraldRaptor() : base()
		{
			Id = 8588;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Whistle of the Emerald Raptor";
			Name2 = "Whistle of the Emerald Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8395 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Old Whistle of the Ivory Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class OldWhistleOfTheIvoryRaptor : Item
	{
		public OldWhistleOfTheIvoryRaptor() : base()
		{
			Id = 8589;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Old Whistle of the Ivory Raptor";
			Name2 = "Old Whistle of the Ivory Raptor";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 10795 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Old Whistle of the Obsidian Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class OldWhistleOfTheObsidianRaptor : Item
	{
		public OldWhistleOfTheObsidianRaptor() : base()
		{
			Id = 8590;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Old Whistle of the Obsidian Raptor";
			Name2 = "Old Whistle of the Obsidian Raptor";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 10798 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Whistle of the Turquoise Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheTurquoiseRaptor : Item
	{
		public WhistleOfTheTurquoiseRaptor() : base()
		{
			Id = 8591;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Whistle of the Turquoise Raptor";
			Name2 = "Whistle of the Turquoise Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10796 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Whistle of the Violet Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheVioletRaptor : Item
	{
		public WhistleOfTheVioletRaptor() : base()
		{
			Id = 8592;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Whistle of the Violet Raptor";
			Name2 = "Whistle of the Violet Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10799 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Blue Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class BlueMechanostrider : Item
	{
		public BlueMechanostrider() : base()
		{
			Id = 8595;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Blue Mechanostrider";
			Name2 = "Blue Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10969 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Night saber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheNightSaber : Item
	{
		public ReinsOfTheNightSaber() : base()
		{
			Id = 8627;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17606;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Night saber";
			Name2 = "Reins of the Night saber";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 10787 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Spotted Nightsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheSpottedNightsaber : Item
	{
		public ReinsOfTheSpottedNightsaber() : base()
		{
			Id = 8628;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17606;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Spotted Nightsaber";
			Name2 = "Reins of the Spotted Nightsaber";
			Quality = 1;
			AvailableRaces = 0xDF;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10792 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Striped Nightsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheStripedNightsaber : Item
	{
		public ReinsOfTheStripedNightsaber() : base()
		{
			Id = 8629;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17606;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Striped Nightsaber";
			Name2 = "Reins of the Striped Nightsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10793 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Striped Frostsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheStripedFrostsaber : Item
	{
		public ReinsOfTheStripedFrostsaber() : base()
		{
			Id = 8631;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Striped Frostsaber";
			Name2 = "Reins of the Striped Frostsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8394 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Spotted Frostsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheSpottedFrostsaber : Item
	{
		public ReinsOfTheSpottedFrostsaber() : base()
		{
			Id = 8632;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Spotted Frostsaber";
			Name2 = "Reins of the Spotted Frostsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 10789 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Ancient Tablet)
*
***************************************************************/

namespace Server.Items
{
	public class AncientTablet : Item
	{
		public AncientTablet() : base()
		{
			Id = 9242;
			SellPrice = 2421;
			AvailableClasses = 0x7FFF;
			Model = 18204;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ancient Tablet";
			Name2 = "Ancient Tablet";
			AvailableRaces = 0x1FF;
			BuyPrice = 9685;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 1091;
		}
	}
}


/**************************************************************
*
*				(Troll Tribal Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class TrollTribalNecklace : Item
	{
		public TrollTribalNecklace() : base()
		{
			Id = 9259;
			SellPrice = 64;
			AvailableClasses = 0x7FFF;
			Model = 9860;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Troll Tribal Necklace";
			Name2 = "Troll Tribal Necklace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 258;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pirate's Footlocker)
*
***************************************************************/

namespace Server.Items
{
	public class PiratesFootlocker : Item
	{
		public PiratesFootlocker() : base()
		{
			Id = 9276;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 12332;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Pirate's Footlocker";
			Name2 = "Pirate's Footlocker";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Security DELTA Data Access Card)
*
***************************************************************/

namespace Server.Items
{
	public class SecurityDELTADataAccessCard : Item
	{
		public SecurityDELTADataAccessCard() : base()
		{
			Id = 9327;
			SellPrice = 625;
			AvailableClasses = 0x7FFF;
			Model = 7356;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Security DELTA Data Access Card";
			Name2 = "Security DELTA Data Access Card";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 202;
			BuyPrice = 2500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Crusted Bandages)
*
***************************************************************/

namespace Server.Items
{
	public class CrustedBandages : Item
	{
		public CrustedBandages() : base()
		{
			Id = 9332;
			SellPrice = 38;
			AvailableClasses = 0x7FFF;
			Model = 18170;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crusted Bandages";
			Name2 = "Crusted Bandages";
			AvailableRaces = 0x1FF;
			BuyPrice = 155;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Cracked Pottery)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedPottery : Item
	{
		public CrackedPottery() : base()
		{
			Id = 9334;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 18173;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cracked Pottery";
			Name2 = "Cracked Pottery";
			AvailableRaces = 0x1FF;
			BuyPrice = 190;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Broken Obsidian Club)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenObsidianClub : Item
	{
		public BrokenObsidianClub() : base()
		{
			Id = 9335;
			SellPrice = 52;
			AvailableClasses = 0x7FFF;
			Model = 7161;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Obsidian Club";
			Name2 = "Broken Obsidian Club";
			AvailableRaces = 0x1FF;
			BuyPrice = 210;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Gold-capped Troll Tusk)
*
***************************************************************/

namespace Server.Items
{
	public class GoldCappedTrollTusk : Item
	{
		public GoldCappedTrollTusk() : base()
		{
			Id = 9336;
			SellPrice = 1288;
			AvailableClasses = 0x7FFF;
			Model = 18174;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gold-capped Troll Tusk";
			Name2 = "Gold-capped Troll Tusk";
			AvailableRaces = 0x1FF;
			BuyPrice = 5155;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Hoop Earring)
*
***************************************************************/

namespace Server.Items
{
	public class HoopEarring : Item
	{
		public HoopEarring() : base()
		{
			Id = 9355;
			SellPrice = 376;
			AvailableClasses = 0x7FFF;
			Model = 9835;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hoop Earring";
			Name2 = "Hoop Earring";
			AvailableRaces = 0x1FF;
			BuyPrice = 1505;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(A Wooden Leg)
*
***************************************************************/

namespace Server.Items
{
	public class AWoodenLeg : Item
	{
		public AWoodenLeg() : base()
		{
			Id = 9356;
			SellPrice = 217;
			AvailableClasses = 0x7FFF;
			Model = 18192;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Wooden Leg";
			Name2 = "A Wooden Leg";
			AvailableRaces = 0x1FF;
			BuyPrice = 870;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(A Parrot Skeleton)
*
***************************************************************/

namespace Server.Items
{
	public class AParrotSkeleton : Item
	{
		public AParrotSkeleton() : base()
		{
			Id = 9357;
			SellPrice = 227;
			AvailableClasses = 0x7FFF;
			Model = 3233;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Parrot Skeleton";
			Name2 = "A Parrot Skeleton";
			AvailableRaces = 0x1FF;
			BuyPrice = 910;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(A Head Rag)
*
***************************************************************/

namespace Server.Items
{
	public class AHeadRag : Item
	{
		public AHeadRag() : base()
		{
			Id = 9358;
			SellPrice = 228;
			AvailableClasses = 0x7FFF;
			Model = 18193;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Head Rag";
			Name2 = "A Head Rag";
			AvailableRaces = 0x1FF;
			BuyPrice = 915;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Sparklematic-Wrapped Box)
*
***************************************************************/

namespace Server.Items
{
	public class SparklematicWrappedBox : Item
	{
		public SparklematicWrappedBox() : base()
		{
			Id = 9363;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18499;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sparklematic-Wrapped Box";
			Name2 = "Sparklematic-Wrapped Box";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Used Monster Sample)
*
***************************************************************/

namespace Server.Items
{
	public class UsedMonsterSample : Item
	{
		public UsedMonsterSample() : base()
		{
			Id = 9443;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6703;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Used Monster Sample";
			Name2 = "Used Monster Sample";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Box of Rations)
*
***************************************************************/

namespace Server.Items
{
	public class BoxOfRations : Item
	{
		public BoxOfRations() : base()
		{
			Id = 9539;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 12925;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Box of Rations";
			Name2 = "Box of Rations";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Box of Spells)
*
***************************************************************/

namespace Server.Items
{
	public class BoxOfSpells : Item
	{
		public BoxOfSpells() : base()
		{
			Id = 9540;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 14006;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Box of Spells";
			Name2 = "Box of Spells";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Box of Goodies)
*
***************************************************************/

namespace Server.Items
{
	public class BoxOfGoodies : Item
	{
		public BoxOfGoodies() : base()
		{
			Id = 9541;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 16028;
			ObjectClass = 15;
			SubClass = 0;
			Level = 47;
			Name = "Box of Goodies";
			Name2 = "Box of Goodies";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Monster - Item, Sparkler Blue)
*
***************************************************************/

namespace Server.Items
{
	public class MonsterItemSparklerBlue : Item
	{
		public MonsterItemSparklerBlue() : base()
		{
			Id = 9700;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 18633;
			ObjectClass = 2;
			SubClass = 14;
			Level = 1;
			ReqLevel = 1;
			Name = "Monster - Item, Sparkler Blue";
			Name2 = "Monster - Item, Sparkler Blue";
			AvailableRaces = 0x1FF;
			BuyPrice = 11;
			InventoryType = InventoryTypes.MainGauche;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			SetDamage( 5 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Monster - Item, Sparkler Red)
*
***************************************************************/

namespace Server.Items
{
	public class MonsterItemSparklerRed : Item
	{
		public MonsterItemSparklerRed() : base()
		{
			Id = 9701;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 18634;
			ObjectClass = 2;
			SubClass = 14;
			Level = 1;
			ReqLevel = 1;
			Name = "Monster - Item, Sparkler Red";
			Name2 = "Monster - Item, Sparkler Red";
			AvailableRaces = 0x1FF;
			BuyPrice = 11;
			InventoryType = InventoryTypes.MainGauche;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			SetDamage( 5 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Kingsnake)
*
***************************************************************/

namespace Server.Items
{
	public class BlackKingsnake : Item
	{
		public BlackKingsnake() : base()
		{
			Id = 10360;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19089;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Black Kingsnake";
			Name2 = "Black Kingsnake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10714 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Brown Snake)
*
***************************************************************/

namespace Server.Items
{
	public class BrownSnake : Item
	{
		public BrownSnake() : base()
		{
			Id = 10361;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19089;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Brown Snake";
			Name2 = "Brown Snake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10716 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Crimson Snake)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSnake : Item
	{
		public CrimsonSnake() : base()
		{
			Id = 10392;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19089;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Crimson Snake";
			Name2 = "Crimson Snake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10717 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cockroach)
*
***************************************************************/

namespace Server.Items
{
	public class Cockroach : Item
	{
		public Cockroach() : base()
		{
			Id = 10393;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 19092;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Cockroach";
			Name2 = "Cockroach";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10688 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Prairie Dog Whistle)
*
***************************************************************/

namespace Server.Items
{
	public class PrairieDogWhistle : Item
	{
		public PrairieDogWhistle() : base()
		{
			Id = 10394;
			Bonding = 3;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 15798;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Prairie Dog Whistle";
			Name2 = "Prairie Dog Whistle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10709 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mechanical Chicken)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicalChicken : Item
	{
		public MechanicalChicken() : base()
		{
			Id = 10398;
			Bonding = 3;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 19115;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Mechanical Chicken";
			Name2 = "Mechanical Chicken";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 12243 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(A Bulging Coin Purse)
*
***************************************************************/

namespace Server.Items
{
	public class ABulgingCoinPurse : Item
	{
		public ABulgingCoinPurse() : base()
		{
			Id = 10456;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 2588;
			ObjectClass = 15;
			SubClass = 0;
			Level = 15;
			Name = "A Bulging Coin Purse";
			Name2 = "A Bulging Coin Purse";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Empty Sea Snail Shell)
*
***************************************************************/

namespace Server.Items
{
	public class EmptySeaSnailShell : Item
	{
		public EmptySeaSnailShell() : base()
		{
			Id = 10457;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 19284;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Empty Sea Snail Shell";
			Name2 = "Empty Sea Snail Shell";
			AvailableRaces = 0x1FF;
			BuyPrice = 570;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Sheath = 1;
		}
	}
}


/**************************************************************
*
*				(Trader's Satchel)
*
***************************************************************/

namespace Server.Items
{
	public class TradersSatchel : Item
	{
		public TradersSatchel() : base()
		{
			Id = 10467;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Description = "Full of trade goods.";
			Model = 1283;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Trader's Satchel";
			Name2 = "Trader's Satchel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Kovic's Trading Satchel)
*
***************************************************************/

namespace Server.Items
{
	public class KovicsTradingSatchel : Item
	{
		public KovicsTradingSatchel() : base()
		{
			Id = 10479;
			Bonding = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 1283;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Kovic's Trading Satchel";
			Name2 = "Kovic's Trading Satchel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Hoard of the Black Dragonflight)
*
***************************************************************/

namespace Server.Items
{
	public class HoardOfTheBlackDragonflight : Item
	{
		public HoardOfTheBlackDragonflight() : base()
		{
			Id = 10569;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Bears the mark of Kalaran the Deceiver";
			Model = 14006;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Hoard of the Black Dragonflight";
			Name2 = "Hoard of the Black Dragonflight";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Black Dragonflight Molt)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonflightMolt : Item
	{
		public BlackDragonflightMolt() : base()
		{
			Id = 10575;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "A dull and gray patch of black dragon skin";
			Model = 19502;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Black Dragonflight Molt";
			Name2 = "Black Dragonflight Molt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Kum'sha's Junk)
*
***************************************************************/

namespace Server.Items
{
	public class KumshasJunk : Item
	{
		public KumshasJunk() : base()
		{
			Id = 10595;
			AvailableClasses = 0x7FFF;
			Description = "A chest full of junk";
			Model = 16190;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Kum'sha's Junk";
			Name2 = "Kum'sha's Junk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Box of Empty Vials)
*
***************************************************************/

namespace Server.Items
{
	public class BoxOfEmptyVials : Item
	{
		public BoxOfEmptyVials() : base()
		{
			Id = 10695;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 12925;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Box of Empty Vials";
			Name2 = "Box of Empty Vials";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Emerald Encrusted Chest)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldEncrustedChest : Item
	{
		public EmeraldEncrustedChest() : base()
		{
			Id = 10752;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 19745;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "Emerald Encrusted Chest";
			Name2 = "Emerald Encrusted Chest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Hakkar'i Urn)
*
***************************************************************/

namespace Server.Items
{
	public class HakkariUrn : Item
	{
		public HakkariUrn() : base()
		{
			Id = 10773;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15692;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hakkar'i Urn";
			Name2 = "Hakkar'i Urn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Dark Whelpling)
*
***************************************************************/

namespace Server.Items
{
	public class DarkWhelpling : Item
	{
		public DarkWhelpling() : base()
		{
			Id = 10822;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 20655;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Dark Whelpling";
			Name2 = "Dark Whelpling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10695 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Felhound Tracker Kit)
*
***************************************************************/

namespace Server.Items
{
	public class FelhoundTrackerKit : Item
	{
		public FelhoundTrackerKit() : base()
		{
			Id = 10834;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "FRAGILE - Handle With Care";
			Model = 15692;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Felhound Tracker Kit";
			Name2 = "Felhound Tracker Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Delay = 500;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Crystallized Note)
*
***************************************************************/

namespace Server.Items
{
	public class CrystallizedNote : Item
	{
		public CrystallizedNote() : base()
		{
			Id = 10839;
			AvailableClasses = 0x7FFF;
			Description = "A note encased in azsharite crystal.";
			Model = 16062;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crystallized Note";
			Name2 = "Crystallized Note";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1311;
		}
	}
}


/**************************************************************
*
*				(Crystallized Note)
*
***************************************************************/

namespace Server.Items
{
	public class CrystallizedNote10840 : Item
	{
		public CrystallizedNote10840() : base()
		{
			Id = 10840;
			AvailableClasses = 0x7FFF;
			Description = "A note encased in azsharite crystal.";
			Model = 16062;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crystallized Note";
			Name2 = "Crystallized Note";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1313;
		}
	}
}


/**************************************************************
*
*				(Un'Goro Soil)
*
***************************************************************/

namespace Server.Items
{
	public class UnGoroSoil : Item
	{
		public UnGoroSoil() : base()
		{
			Id = 11018;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 2480;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Un'Goro Soil";
			Name2 = "Un'Goro Soil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 585;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ancona Chicken)
*
***************************************************************/

namespace Server.Items
{
	public class AnconaChicken : Item
	{
		public AnconaChicken() : base()
		{
			Id = 11023;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 17284;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Ancona Chicken";
			Name2 = "Ancona Chicken";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10685 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tree Frog Box)
*
***************************************************************/

namespace Server.Items
{
	public class TreeFrogBox : Item
	{
		public TreeFrogBox() : base()
		{
			Id = 11026;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 17284;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Tree Frog Box";
			Name2 = "Tree Frog Box";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10704 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Wood Frog Box)
*
***************************************************************/

namespace Server.Items
{
	public class WoodFrogBox : Item
	{
		public WoodFrogBox() : base()
		{
			Id = 11027;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 17284;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Wood Frog Box";
			Name2 = "Wood Frog Box";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 10703 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Chicken Egg)
*
***************************************************************/

namespace Server.Items
{
	public class ChickenEgg : Item
	{
		public ChickenEgg() : base()
		{
			Id = 11110;
			Bonding = 1;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 18047;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chicken Egg";
			Name2 = "Chicken Egg";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 13548 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(A Mangled Journal)
*
***************************************************************/

namespace Server.Items
{
	public class AMangledJournal : Item
	{
		public AMangledJournal() : base()
		{
			Id = 11116;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Property of Williden Marshal";
			Model = 1317;
			ObjectClass = 15;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "A Mangled Journal";
			Name2 = "A Mangled Journal";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 3884;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Broken Basilisk Teeth)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenBasiliskTeeth : Item
	{
		public BrokenBasiliskTeeth() : base()
		{
			Id = 11384;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 7350;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Basilisk Teeth";
			Name2 = "Broken Basilisk Teeth";
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Basilisk Scale)
*
***************************************************************/

namespace Server.Items
{
	public class BasiliskScale : Item
	{
		public BasiliskScale() : base()
		{
			Id = 11385;
			SellPrice = 145;
			AvailableClasses = 0x7FFF;
			Model = 21363;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Basilisk Scale";
			Name2 = "Basilisk Scale";
			AvailableRaces = 0x1FF;
			BuyPrice = 580;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Squishy Basilisk Eye)
*
***************************************************************/

namespace Server.Items
{
	public class SquishyBasiliskEye : Item
	{
		public SquishyBasiliskEye() : base()
		{
			Id = 11386;
			SellPrice = 676;
			AvailableClasses = 0x7FFF;
			Model = 9292;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Squishy Basilisk Eye";
			Name2 = "Squishy Basilisk Eye";
			AvailableRaces = 0x1FF;
			BuyPrice = 2705;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Basilisk Heart)
*
***************************************************************/

namespace Server.Items
{
	public class BasiliskHeart : Item
	{
		public BasiliskHeart() : base()
		{
			Id = 11387;
			SellPrice = 1013;
			AvailableClasses = 0x7FFF;
			Model = 3422;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Basilisk Heart";
			Name2 = "Basilisk Heart";
			AvailableRaces = 0x1FF;
			BuyPrice = 4055;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Basilisk Venom)
*
***************************************************************/

namespace Server.Items
{
	public class BasiliskVenom : Item
	{
		public BasiliskVenom() : base()
		{
			Id = 11388;
			SellPrice = 1563;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Basilisk Venom";
			Name2 = "Basilisk Venom";
			AvailableRaces = 0x1FF;
			BuyPrice = 6255;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Shimmering Basilisk Skin)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringBasiliskSkin : Item
	{
		public ShimmeringBasiliskSkin() : base()
		{
			Id = 11389;
			SellPrice = 2163;
			AvailableClasses = 0x7FFF;
			Model = 21364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shimmering Basilisk Skin";
			Name2 = "Shimmering Basilisk Skin";
			AvailableRaces = 0x1FF;
			BuyPrice = 8655;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Broken Bat Fang)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenBatFang : Item
	{
		public BrokenBatFang() : base()
		{
			Id = 11390;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 6002;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Bat Fang";
			Name2 = "Broken Bat Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 320;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Spined Bat Wing)
*
***************************************************************/

namespace Server.Items
{
	public class SpinedBatWing : Item
	{
		public SpinedBatWing() : base()
		{
			Id = 11391;
			SellPrice = 205;
			AvailableClasses = 0x7FFF;
			Model = 18517;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Spined Bat Wing";
			Name2 = "Spined Bat Wing";
			AvailableRaces = 0x1FF;
			BuyPrice = 820;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Severed Bat Claw)
*
***************************************************************/

namespace Server.Items
{
	public class SeveredBatClaw : Item
	{
		public SeveredBatClaw() : base()
		{
			Id = 11392;
			SellPrice = 403;
			AvailableClasses = 0x7FFF;
			Model = 3307;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Severed Bat Claw";
			Name2 = "Severed Bat Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 1612;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Small Bat Skull)
*
***************************************************************/

namespace Server.Items
{
	public class SmallBatSkull : Item
	{
		public SmallBatSkull() : base()
		{
			Id = 11393;
			SellPrice = 780;
			AvailableClasses = 0x7FFF;
			Model = 7103;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Bat Skull";
			Name2 = "Small Bat Skull";
			AvailableRaces = 0x1FF;
			BuyPrice = 3120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bat Heart)
*
***************************************************************/

namespace Server.Items
{
	public class BatHeart : Item
	{
		public BatHeart() : base()
		{
			Id = 11394;
			SellPrice = 580;
			AvailableClasses = 0x7FFF;
			Model = 1438;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bat Heart";
			Name2 = "Bat Heart";
			AvailableRaces = 0x1FF;
			BuyPrice = 2320;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bat Ear)
*
***************************************************************/

namespace Server.Items
{
	public class BatEar : Item
	{
		public BatEar() : base()
		{
			Id = 11395;
			SellPrice = 830;
			AvailableClasses = 0x7FFF;
			Model = 21365;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bat Ear";
			Name2 = "Bat Ear";
			AvailableRaces = 0x1FF;
			BuyPrice = 3320;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Sleek Bat Pelt)
*
***************************************************************/

namespace Server.Items
{
	public class SleekBatPelt : Item
	{
		public SleekBatPelt() : base()
		{
			Id = 11402;
			SellPrice = 1205;
			AvailableClasses = 0x7FFF;
			Model = 21366;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sleek Bat Pelt";
			Name2 = "Sleek Bat Pelt";
			AvailableRaces = 0x1FF;
			BuyPrice = 4820;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Large Bat Fang)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBatFang : Item
	{
		public LargeBatFang() : base()
		{
			Id = 11403;
			SellPrice = 1592;
			AvailableClasses = 0x7FFF;
			Model = 6651;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Large Bat Fang";
			Name2 = "Large Bat Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 6370;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Evil Bat Eye)
*
***************************************************************/

namespace Server.Items
{
	public class EvilBatEye : Item
	{
		public EvilBatEye() : base()
		{
			Id = 11404;
			SellPrice = 2080;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Evil Bat Eye";
			Name2 = "Evil Bat Eye";
			AvailableRaces = 0x1FF;
			BuyPrice = 8320;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rotting Bear Carcass)
*
***************************************************************/

namespace Server.Items
{
	public class RottingBearCarcass : Item
	{
		public RottingBearCarcass() : base()
		{
			Id = 11406;
			SellPrice = 168;
			AvailableClasses = 0x7FFF;
			Model = 8794;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Rotting Bear Carcass";
			Name2 = "Rotting Bear Carcass";
			AvailableRaces = 0x1FF;
			BuyPrice = 675;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Torn Bear Pelt)
*
***************************************************************/

namespace Server.Items
{
	public class TornBearPelt : Item
	{
		public TornBearPelt() : base()
		{
			Id = 11407;
			SellPrice = 108;
			AvailableClasses = 0x7FFF;
			Model = 7170;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Torn Bear Pelt";
			Name2 = "Torn Bear Pelt";
			AvailableRaces = 0x1FF;
			BuyPrice = 435;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bear Jaw)
*
***************************************************************/

namespace Server.Items
{
	public class BearJaw : Item
	{
		public BearJaw() : base()
		{
			Id = 11408;
			SellPrice = 898;
			AvailableClasses = 0x7FFF;
			Model = 21368;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bear Jaw";
			Name2 = "Bear Jaw";
			AvailableRaces = 0x1FF;
			BuyPrice = 3595;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bear Flank)
*
***************************************************************/

namespace Server.Items
{
	public class BearFlank : Item
	{
		public BearFlank() : base()
		{
			Id = 11409;
			SellPrice = 503;
			AvailableClasses = 0x7FFF;
			Model = 2376;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Bear Flank";
			Name2 = "Bear Flank";
			AvailableRaces = 0x1FF;
			BuyPrice = 2015;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Savage Bear Claw)
*
***************************************************************/

namespace Server.Items
{
	public class SavageBearClaw : Item
	{
		public SavageBearClaw() : base()
		{
			Id = 11410;
			SellPrice = 578;
			AvailableClasses = 0x7FFF;
			Model = 1496;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Savage Bear Claw";
			Name2 = "Savage Bear Claw";
			AvailableRaces = 0x1FF;
			BuyPrice = 2315;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Grizzled Mane)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzledMane : Item
	{
		public GrizzledMane() : base()
		{
			Id = 11414;
			SellPrice = 1828;
			AvailableClasses = 0x7FFF;
			Model = 7354;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Grizzled Mane";
			Name2 = "Grizzled Mane";
			AvailableRaces = 0x1FF;
			BuyPrice = 7315;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Delicate Ribcage)
*
***************************************************************/

namespace Server.Items
{
	public class DelicateRibcage : Item
	{
		public DelicateRibcage() : base()
		{
			Id = 11416;
			SellPrice = 328;
			AvailableClasses = 0x7FFF;
			Model = 6631;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Delicate Ribcage";
			Name2 = "Delicate Ribcage";
			AvailableRaces = 0x1FF;
			BuyPrice = 1315;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Feathery Wing)
*
***************************************************************/

namespace Server.Items
{
	public class FeatheryWing : Item
	{
		public FeatheryWing() : base()
		{
			Id = 11417;
			SellPrice = 1204;
			AvailableClasses = 0x7FFF;
			Model = 4433;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Feathery Wing";
			Name2 = "Feathery Wing";
			AvailableRaces = 0x1FF;
			BuyPrice = 4816;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Hollow Wing Bone)
*
***************************************************************/

namespace Server.Items
{
	public class HollowWingBone : Item
	{
		public HollowWingBone() : base()
		{
			Id = 11418;
			SellPrice = 604;
			AvailableClasses = 0x7FFF;
			Model = 7251;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Hollow Wing Bone";
			Name2 = "Hollow Wing Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 2416;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mysterious Unhatched Egg)
*
***************************************************************/

namespace Server.Items
{
	public class MysteriousUnhatchedEgg : Item
	{
		public MysteriousUnhatchedEgg() : base()
		{
			Id = 11419;
			SellPrice = 1900;
			AvailableClasses = 0x7FFF;
			Model = 18047;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Mysterious Unhatched Egg";
			Name2 = "Mysterious Unhatched Egg";
			AvailableRaces = 0x1FF;
			BuyPrice = 7600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Elegant Writing Tool)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantWritingTool : Item
	{
		public ElegantWritingTool() : base()
		{
			Id = 11420;
			SellPrice = 1712;
			AvailableClasses = 0x7FFF;
			Model = 21370;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Elegant Writing Tool";
			Name2 = "Elegant Writing Tool";
			AvailableRaces = 0x1FF;
			BuyPrice = 6850;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Goblin Engineer's Renewal Gift)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinEngineersRenewalGift : Item
	{
		public GoblinEngineersRenewalGift() : base()
		{
			Id = 11422;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21374;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Goblin Engineer's Renewal Gift";
			Name2 = "Goblin Engineer's Renewal Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Gnome Engineer's Renewal Gift)
*
***************************************************************/

namespace Server.Items
{
	public class GnomeEngineersRenewalGift : Item
	{
		public GnomeEngineersRenewalGift() : base()
		{
			Id = 11423;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21375;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Gnome Engineer's Renewal Gift";
			Name2 = "Gnome Engineer's Renewal Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sprite Darter Egg)
*
***************************************************************/

namespace Server.Items
{
	public class SpriteDarterEgg : Item
	{
		public SpriteDarterEgg() : base()
		{
			Id = 11474;
			Bonding = 1;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 18047;
			ObjectClass = 15;
			SubClass = 0;
			Level = 47;
			Name = "Sprite Darter Egg";
			Name2 = "Sprite Darter Egg";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 15067 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Torwa's Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class TorwasPouch : Item
	{
		public TorwasPouch() : base()
		{
			Id = 11568;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 8631;
			ObjectClass = 15;
			SubClass = 0;
			Level = 48;
			Name = "Torwa's Pouch";
			Name2 = "Torwa's Pouch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Fel Salve)
*
***************************************************************/

namespace Server.Items
{
	public class FelSalve : Item
	{
		public FelSalve() : base()
		{
			Id = 11582;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Use on Grol, Sevine, and Allistarj to break Razelikh's Ward.";
			Model = 21531;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fel Salve";
			Name2 = "Fel Salve";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12938 , 0 , -5 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(A Dingy Fanny Pack)
*
***************************************************************/

namespace Server.Items
{
	public class ADingyFannyPack : Item
	{
		public ADingyFannyPack() : base()
		{
			Id = 11883;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 1281;
			ObjectClass = 15;
			SubClass = 0;
			Level = 56;
			Name = "A Dingy Fanny Pack";
			Name2 = "A Dingy Fanny Pack";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Cenarion Circle Cache)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionCircleCache : Item
	{
		public CenarionCircleCache() : base()
		{
			Id = 11887;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 20709;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Cenarion Circle Cache";
			Name2 = "Cenarion Circle Cache";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Package of Empty Ooze Containers)
*
***************************************************************/

namespace Server.Items
{
	public class PackageOfEmptyOozeContainers : Item
	{
		public PackageOfEmptyOozeContainers() : base()
		{
			Id = 11912;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 8928;
			ObjectClass = 15;
			SubClass = 0;
			Level = 48;
			Name = "Package of Empty Ooze Containers";
			Name2 = "Package of Empty Ooze Containers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Fat Sack of Coins)
*
***************************************************************/

namespace Server.Items
{
	public class FatSackOfCoins : Item
	{
		public FatSackOfCoins() : base()
		{
			Id = 11937;
			SellPrice = 187;
			AvailableClasses = 0x7FFF;
			Model = 1168;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fat Sack of Coins";
			Name2 = "Fat Sack of Coins";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 749;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class SackOfGems : Item
	{
		public SackOfGems() : base()
		{
			Id = 11938;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 4056;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sack of Gems";
			Name2 = "Sack of Gems";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 854;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Shiny Bracelet)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyBracelet : Item
	{
		public ShinyBracelet() : base()
		{
			Id = 11939;
			SellPrice = 671;
			AvailableClasses = 0x7FFF;
			Model = 14432;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shiny Bracelet";
			Name2 = "Shiny Bracelet";
			AvailableRaces = 0x1FF;
			BuyPrice = 2684;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Sparkly Necklace)
*
***************************************************************/

namespace Server.Items
{
	public class SparklyNecklace : Item
	{
		public SparklyNecklace() : base()
		{
			Id = 11940;
			SellPrice = 389;
			AvailableClasses = 0x7FFF;
			Model = 9657;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sparkly Necklace";
			Name2 = "Sparkly Necklace";
			AvailableRaces = 0x1FF;
			BuyPrice = 1558;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(False Documents)
*
***************************************************************/

namespace Server.Items
{
	public class FalseDocuments : Item
	{
		public FalseDocuments() : base()
		{
			Id = 11941;
			SellPrice = 5896;
			AvailableClasses = 0x7FFF;
			Model = 7798;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "False Documents";
			Name2 = "False Documents";
			AvailableRaces = 0x1FF;
			BuyPrice = 23584;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Legal Documents)
*
***************************************************************/

namespace Server.Items
{
	public class LegalDocuments : Item
	{
		public LegalDocuments() : base()
		{
			Id = 11942;
			SellPrice = 5303;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Legal Documents";
			Name2 = "Legal Documents";
			AvailableRaces = 0x1FF;
			BuyPrice = 21215;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Deed to Thandol Span)
*
***************************************************************/

namespace Server.Items
{
	public class DeedToThandolSpan : Item
	{
		public DeedToThandolSpan() : base()
		{
			Id = 11943;
			SellPrice = 21485;
			AvailableClasses = 0x7FFF;
			Model = 7744;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Deed to Thandol Span";
			Name2 = "Deed to Thandol Span";
			AvailableRaces = 0x1FF;
			BuyPrice = 85941;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Baby Booties)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronBabyBooties : Item
	{
		public DarkIronBabyBooties() : base()
		{
			Id = 11944;
			SellPrice = 8821;
			AvailableClasses = 0x7FFF;
			Model = 21970;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Dark Iron Baby Booties";
			Name2 = "Dark Iron Baby Booties";
			AvailableRaces = 0x1FF;
			BuyPrice = 35284;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Bag of Empty Ooze Containers)
*
***************************************************************/

namespace Server.Items
{
	public class BagOfEmptyOozeContainers : Item
	{
		public BagOfEmptyOozeContainers() : base()
		{
			Id = 11955;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 21977;
			ObjectClass = 15;
			SubClass = 0;
			Level = 48;
			Name = "Bag of Empty Ooze Containers";
			Name2 = "Bag of Empty Ooze Containers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Small Sack of Coins)
*
***************************************************************/

namespace Server.Items
{
	public class SmallSackOfCoins : Item
	{
		public SmallSackOfCoins() : base()
		{
			Id = 11966;
			SellPrice = 164;
			AvailableClasses = 0x7FFF;
			Model = 1168;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Small Sack of Coins";
			Name2 = "Small Sack of Coins";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 658;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Thaurissan Family Jewels)
*
***************************************************************/

namespace Server.Items
{
	public class ThaurissanFamilyJewels : Item
	{
		public ThaurissanFamilyJewels() : base()
		{
			Id = 12033;
			AvailableClasses = 0x7FFF;
			Model = 22020;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			Name = "Thaurissan Family Jewels";
			Name2 = "Thaurissan Family Jewels";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 600;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Kum'isha's Junk)
*
***************************************************************/

namespace Server.Items
{
	public class KumishasJunk : Item
	{
		public KumishasJunk() : base()
		{
			Id = 12122;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "A chest full of junk";
			Model = 2593;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Kum'isha's Junk";
			Name2 = "Kum'isha's Junk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Worg Carrier)
*
***************************************************************/

namespace Server.Items
{
	public class WorgCarrier : Item
	{
		public WorgCarrier() : base()
		{
			Id = 12264;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 59;
			Name = "Worg Carrier";
			Name2 = "Worg Carrier";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 15999 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Frostsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheFrostsaber : Item
	{
		public ReinsOfTheFrostsaber() : base()
		{
			Id = 12302;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Frostsaber";
			Name2 = "Reins of the Frostsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16056 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Nightsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheNightsaber : Item
	{
		public ReinsOfTheNightsaber() : base()
		{
			Id = 12303;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Nightsaber";
			Name2 = "Reins of the Nightsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16055 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Red Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheRedWolf12330 : Item
	{
		public HornOfTheRedWolf12330() : base()
		{
			Id = 12330;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Horn of the Red Wolf";
			Name2 = "Horn of the Red Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16080 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Arctic Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheArcticWolf : Item
	{
		public HornOfTheArcticWolf() : base()
		{
			Id = 12351;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Horn of the Arctic Wolf";
			Name2 = "Horn of the Arctic Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16081 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(White Stallion Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteStallionBridle : Item
	{
		public WhiteStallionBridle() : base()
		{
			Id = 12353;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 13108;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "White Stallion Bridle";
			Name2 = "White Stallion Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16083 , 0 , 0 , -1 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Palomino Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class PalominoBridle : Item
	{
		public PalominoBridle() : base()
		{
			Id = 12354;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 25132;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Palomino Bridle";
			Name2 = "Palomino Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16082 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Smolderweb Carrier)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderwebCarrier : Item
	{
		public SmolderwebCarrier() : base()
		{
			Id = 12529;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 22717;
			ObjectClass = 15;
			SubClass = 0;
			Level = 59;
			Name = "Smolderweb Carrier";
			Name2 = "Smolderweb Carrier";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 16450 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Winna's Kitten Carrier)
*
***************************************************************/

namespace Server.Items
{
	public class WinnasKittenCarrier : Item
	{
		public WinnasKittenCarrier() : base()
		{
			Id = 12565;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 20629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 5;
			Name = "Winna's Kitten Carrier";
			Name2 = "Winna's Kitten Carrier";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 15647 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Brilliant Chromatic Scale)
*
***************************************************************/

namespace Server.Items
{
	public class BrilliantChromaticScale : Item
	{
		public BrilliantChromaticScale() : base()
		{
			Id = 12607;
			SellPrice = 8048;
			AvailableClasses = 0x7FFF;
			Model = 22838;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Brilliant Chromatic Scale";
			Name2 = "Brilliant Chromatic Scale";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32195;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chromatic Carapace)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticCarapace : Item
	{
		public ChromaticCarapace() : base()
		{
			Id = 12871;
			Bonding = 1;
			SellPrice = 8048;
			AvailableClasses = 0x7FFF;
			Model = 23332;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chromatic Carapace";
			Name2 = "Chromatic Carapace";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 32195;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Reins of the Winterspring Frostsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheWinterspringFrostsaber : Item
	{
		public ReinsOfTheWinterspringFrostsaber() : base()
		{
			Id = 13086;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 23606;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Winterspring Frostsaber";
			Name2 = "Reins of the Winterspring Frostsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17229 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Quartermaster Zigris' Footlocker)
*
***************************************************************/

namespace Server.Items
{
	public class QuartermasterZigrisFootlocker : Item
	{
		public QuartermasterZigrisFootlocker() : base()
		{
			Id = 13247;
			Bonding = 1;
			SellPrice = 5837;
			AvailableClasses = 0x7FFF;
			Model = 12333;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			Name = "Quartermaster Zigris' Footlocker";
			Name2 = "Quartermaster Zigris' Footlocker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23350;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Whistle of the Ivory Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheIvoryRaptor : Item
	{
		public WhistleOfTheIvoryRaptor() : base()
		{
			Id = 13317;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Whistle of the Ivory Raptor";
			Name2 = "Whistle of the Ivory Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17450 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Green Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class GreenMechanostrider : Item
	{
		public GreenMechanostrider() : base()
		{
			Id = 13321;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Green Mechanostrider";
			Name2 = "Green Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17453 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Unpainted Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class UnpaintedMechanostrider : Item
	{
		public UnpaintedMechanostrider() : base()
		{
			Id = 13322;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Unpainted Mechanostrider";
			Name2 = "Unpainted Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17454 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(White Mechanostrider Mod A)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteMechanostriderModA : Item
	{
		public WhiteMechanostriderModA() : base()
		{
			Id = 13326;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "White Mechanostrider Mod A";
			Name2 = "White Mechanostrider Mod A";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 15779 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Icy Blue Mechanostrider Mod A)
*
***************************************************************/

namespace Server.Items
{
	public class IcyBlueMechanostriderModA : Item
	{
		public IcyBlueMechanostriderModA() : base()
		{
			Id = 13327;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Icy Blue Mechanostrider Mod A";
			Name2 = "Icy Blue Mechanostrider Mod A";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17459 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Black Ram)
*
***************************************************************/

namespace Server.Items
{
	public class BlackRam : Item
	{
		public BlackRam() : base()
		{
			Id = 13328;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Black Ram";
			Name2 = "Black Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17461 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Frost Ram)
*
***************************************************************/

namespace Server.Items
{
	public class FrostRam : Item
	{
		public FrostRam() : base()
		{
			Id = 13329;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Frost Ram";
			Name2 = "Frost Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17460 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Red Skeletal Horse)
*
***************************************************************/

namespace Server.Items
{
	public class RedSkeletalHorse : Item
	{
		public RedSkeletalHorse() : base()
		{
			Id = 13331;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Red Skeletal Horse";
			Name2 = "Red Skeletal Horse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17462 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Blue Skeletal Horse)
*
***************************************************************/

namespace Server.Items
{
	public class BlueSkeletalHorse : Item
	{
		public BlueSkeletalHorse() : base()
		{
			Id = 13332;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Blue Skeletal Horse";
			Name2 = "Blue Skeletal Horse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17463 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Brown Skeletal Horse)
*
***************************************************************/

namespace Server.Items
{
	public class BrownSkeletalHorse : Item
	{
		public BrownSkeletalHorse() : base()
		{
			Id = 13333;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Brown Skeletal Horse";
			Name2 = "Brown Skeletal Horse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17464 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Green Skeletal Warhorse)
*
***************************************************************/

namespace Server.Items
{
	public class GreenSkeletalWarhorse : Item
	{
		public GreenSkeletalWarhorse() : base()
		{
			Id = 13334;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Green Skeletal Warhorse";
			Name2 = "Green Skeletal Warhorse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17465 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Deathcharger's Reins)
*
***************************************************************/

namespace Server.Items
{
	public class DeathchargersReins : Item
	{
		public DeathchargersReins() : base()
		{
			Id = 13335;
			Bonding = 1;
			SellPrice = 250000;
			AvailableClasses = 0x7FFF;
			Model = 24011;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Deathcharger's Reins";
			Name2 = "Deathcharger's Reins";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17481 , 0 , 0 , -1 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Letter from the Front)
*
***************************************************************/

namespace Server.Items
{
	public class LetterFromTheFront : Item
	{
		public LetterFromTheFront() : base()
		{
			Id = 13362;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 3024;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Letter from the Front";
			Name2 = "Letter from the Front";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Municipal Proclamation)
*
***************************************************************/

namespace Server.Items
{
	public class MunicipalProclamation : Item
	{
		public MunicipalProclamation() : base()
		{
			Id = 13363;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Municipal Proclamation";
			Name2 = "Municipal Proclamation";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fras Siabi's Advertisement)
*
***************************************************************/

namespace Server.Items
{
	public class FrasSiabisAdvertisement : Item
	{
		public FrasSiabisAdvertisement() : base()
		{
			Id = 13364;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 4110;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fras Siabi's Advertisement";
			Name2 = "Fras Siabi's Advertisement";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Town Meeting Notice)
*
***************************************************************/

namespace Server.Items
{
	public class TownMeetingNotice : Item
	{
		public TownMeetingNotice() : base()
		{
			Id = 13365;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 24051;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Town Meeting Notice";
			Name2 = "Town Meeting Notice";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ingenious Toy)
*
***************************************************************/

namespace Server.Items
{
	public class IngeniousToy : Item
	{
		public IngeniousToy() : base()
		{
			Id = 13366;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 24052;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ingenious Toy";
			Name2 = "Ingenious Toy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Zergling Leash)
*
***************************************************************/

namespace Server.Items
{
	public class ZerglingLeash : Item
	{
		public ZerglingLeash() : base()
		{
			Id = 13582;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24252;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Zergling Leash";
			Name2 = "Zergling Leash";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 17709 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Panda Collar)
*
***************************************************************/

namespace Server.Items
{
	public class PandaCollar : Item
	{
		public PandaCollar() : base()
		{
			Id = 13583;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24251;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Panda Collar";
			Name2 = "Panda Collar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 17707 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Diablo Stone)
*
***************************************************************/

namespace Server.Items
{
	public class DiabloStone : Item
	{
		public DiabloStone() : base()
		{
			Id = 13584;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6689;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Diablo Stone";
			Name2 = "Diablo Stone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 17708 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Monster - Item, Glass - Purple Wine)
*
***************************************************************/

namespace Server.Items
{
	public class MonsterItemGlassPurpleWine : Item
	{
		public MonsterItemGlassPurpleWine() : base()
		{
			Id = 13612;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 24296;
			ObjectClass = 2;
			SubClass = 14;
			Level = 1;
			ReqLevel = 1;
			Name = "Monster - Item, Glass - Purple Wine";
			Name2 = "Monster - Item, Glass - Purple Wine";
			AvailableRaces = 0x1FF;
			BuyPrice = 11;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			SetDamage( 7 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Crate)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyCrate : Item
	{
		public HeavyCrate() : base()
		{
			Id = 13874;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Description = "Venture Company Supplies";
			Model = 8928;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Heavy Crate";
			Name2 = "Heavy Crate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Ironbound Locked Chest)
*
***************************************************************/

namespace Server.Items
{
	public class IronboundLockedChest : Item
	{
		public IronboundLockedChest() : base()
		{
			Id = 13875;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "Ironbound Locked Chest";
			Name2 = "Ironbound Locked Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 61;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(40 Pound Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class _40PoundGrouper : Item
	{
		public _40PoundGrouper() : base()
		{
			Id = 13876;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "40 Pound Grouper";
			Name2 = "40 Pound Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(47 Pound Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class _47PoundGrouper : Item
	{
		public _47PoundGrouper() : base()
		{
			Id = 13877;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "47 Pound Grouper";
			Name2 = "47 Pound Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(53 Pound Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class _53PoundGrouper : Item
	{
		public _53PoundGrouper() : base()
		{
			Id = 13878;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "53 Pound Grouper";
			Name2 = "53 Pound Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 130;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(59 Pound Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class _59PoundGrouper : Item
	{
		public _59PoundGrouper() : base()
		{
			Id = 13879;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "59 Pound Grouper";
			Name2 = "59 Pound Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(68 Pound Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class _68PoundGrouper : Item
	{
		public _68PoundGrouper() : base()
		{
			Id = 13880;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "68 Pound Grouper";
			Name2 = "68 Pound Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(42 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _42PoundRedgill : Item
	{
		public _42PoundRedgill() : base()
		{
			Id = 13882;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "42 Pound Redgill";
			Name2 = "42 Pound Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 240;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(45 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _45PoundRedgill : Item
	{
		public _45PoundRedgill() : base()
		{
			Id = 13883;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "45 Pound Redgill";
			Name2 = "45 Pound Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 240;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(49 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _49PoundRedgill : Item
	{
		public _49PoundRedgill() : base()
		{
			Id = 13884;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "49 Pound Redgill";
			Name2 = "49 Pound Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(34 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _34PoundRedgill : Item
	{
		public _34PoundRedgill() : base()
		{
			Id = 13885;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "34 Pound Redgill";
			Name2 = "34 Pound Redgill";
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
*				(37 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _37PoundRedgill : Item
	{
		public _37PoundRedgill() : base()
		{
			Id = 13886;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "37 Pound Redgill";
			Name2 = "37 Pound Redgill";
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
*				(52 Pound Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class _52PoundRedgill : Item
	{
		public _52PoundRedgill() : base()
		{
			Id = 13887;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 16364;
			ObjectClass = 15;
			SubClass = 0;
			Level = 45;
			Name = "52 Pound Redgill";
			Name2 = "52 Pound Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(15 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _15PoundSalmon : Item
	{
		public _15PoundSalmon() : base()
		{
			Id = 13901;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "15 Pound Salmon";
			Name2 = "15 Pound Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(18 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _18PoundSalmon : Item
	{
		public _18PoundSalmon() : base()
		{
			Id = 13902;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "18 Pound Salmon";
			Name2 = "18 Pound Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(22 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _22PoundSalmon : Item
	{
		public _22PoundSalmon() : base()
		{
			Id = 13903;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "22 Pound Salmon";
			Name2 = "22 Pound Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(25 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _25PoundSalmon : Item
	{
		public _25PoundSalmon() : base()
		{
			Id = 13904;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "25 Pound Salmon";
			Name2 = "25 Pound Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(29 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _29PoundSalmon : Item
	{
		public _29PoundSalmon() : base()
		{
			Id = 13905;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "29 Pound Salmon";
			Name2 = "29 Pound Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(32 Pound Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class _32PoundSalmon : Item
	{
		public _32PoundSalmon() : base()
		{
			Id = 13906;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 18705;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "32 Pound Salmon";
			Name2 = "32 Pound Salmon";
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
*				(7 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _7PoundLobster : Item
	{
		public _7PoundLobster() : base()
		{
			Id = 13907;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "7 Pound Lobster";
			Name2 = "7 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(9 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _9PoundLobster : Item
	{
		public _9PoundLobster() : base()
		{
			Id = 13908;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "9 Pound Lobster";
			Name2 = "9 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 220;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(12 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _12PoundLobster : Item
	{
		public _12PoundLobster() : base()
		{
			Id = 13909;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "12 Pound Lobster";
			Name2 = "12 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 220;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(15 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _15PoundLobster : Item
	{
		public _15PoundLobster() : base()
		{
			Id = 13910;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "15 Pound Lobster";
			Name2 = "15 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(19 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _19PoundLobster : Item
	{
		public _19PoundLobster() : base()
		{
			Id = 13911;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "19 Pound Lobster";
			Name2 = "19 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 320;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(21 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _21PoundLobster : Item
	{
		public _21PoundLobster() : base()
		{
			Id = 13912;
			SellPrice = 90;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "21 Pound Lobster";
			Name2 = "21 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 360;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(22 Pound Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class _22PoundLobster : Item
	{
		public _22PoundLobster() : base()
		{
			Id = 13913;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "22 Pound Lobster";
			Name2 = "22 Pound Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(70 Pound Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class _70PoundMightfish : Item
	{
		public _70PoundMightfish() : base()
		{
			Id = 13914;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 24715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "70 Pound Mightfish";
			Name2 = "70 Pound Mightfish";
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
*				(85 Pound Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class _85PoundMightfish : Item
	{
		public _85PoundMightfish() : base()
		{
			Id = 13915;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 24715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "85 Pound Mightfish";
			Name2 = "85 Pound Mightfish";
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
*				(92 Pound Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class _92PoundMightfish : Item
	{
		public _92PoundMightfish() : base()
		{
			Id = 13916;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 24715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "92 Pound Mightfish";
			Name2 = "92 Pound Mightfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(103 Pound Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class _103PoundMightfish : Item
	{
		public _103PoundMightfish() : base()
		{
			Id = 13917;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 24715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "103 Pound Mightfish";
			Name2 = "103 Pound Mightfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Reinforced Locked Chest)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLockedChest : Item
	{
		public ReinforcedLockedChest() : base()
		{
			Id = 13918;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "Reinforced Locked Chest";
			Name2 = "Reinforced Locked Chest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 599;
			Material = 2;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Kodo Mount)
*
***************************************************************/

namespace Server.Items
{
	public class KodoMount : Item
	{
		public KodoMount() : base()
		{
			Id = 14062;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Kodo Mount";
			Name2 = "Kodo Mount";
			Quality = 1;
			AvailableRaces = 0xFF;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18363 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Un'Goro Tested Sample)
*
***************************************************************/

namespace Server.Items
{
	public class UnGoroTestedSample : Item
	{
		public UnGoroTestedSample() : base()
		{
			Id = 15102;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Un'Goro Tested Sample";
			Name2 = "Un'Goro Tested Sample";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Corrupt Tested Sample)
*
***************************************************************/

namespace Server.Items
{
	public class CorruptTestedSample : Item
	{
		public CorruptTestedSample() : base()
		{
			Id = 15103;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Corrupt Tested Sample";
			Name2 = "Corrupt Tested Sample";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Gray Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class GrayKodo : Item
	{
		public GrayKodo() : base()
		{
			Id = 15277;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29448;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Gray Kodo";
			Name2 = "Gray Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18989 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Brown Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class BrownKodo : Item
	{
		public BrownKodo() : base()
		{
			Id = 15290;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29447;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Brown Kodo";
			Name2 = "Brown Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 800000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18990 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Green Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class GreenKodo : Item
	{
		public GreenKodo() : base()
		{
			Id = 15292;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29449;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Green Kodo";
			Name2 = "Green Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18991 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Teal Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class TealKodo : Item
	{
		public TealKodo() : base()
		{
			Id = 15293;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29449;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Teal Kodo";
			Name2 = "Teal Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18992 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Scale)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidScale : Item
	{
		public HeavyScorpidScale() : base()
		{
			Id = 15408;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 568;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "Heavy Scorpid Scale";
			Name2 = "Heavy Scorpid Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Green Dragonscale)
*
***************************************************************/

namespace Server.Items
{
	public class GreenDragonscale : Item
	{
		public GreenDragonscale() : base()
		{
			Id = 15412;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 21363;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Green Dragonscale";
			Name2 = "Green Dragonscale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Red Dragonscale)
*
***************************************************************/

namespace Server.Items
{
	public class RedDragonscale : Item
	{
		public RedDragonscale() : base()
		{
			Id = 15414;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 26374;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			Name = "Red Dragonscale";
			Name2 = "Red Dragonscale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Blue Dragonscale)
*
***************************************************************/

namespace Server.Items
{
	public class BlueDragonscale : Item
	{
		public BlueDragonscale() : base()
		{
			Id = 15415;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 26375;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Blue Dragonscale";
			Name2 = "Blue Dragonscale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Black Dragonscale)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonscale : Item
	{
		public BlackDragonscale() : base()
		{
			Id = 15416;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 20914;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "Black Dragonscale";
			Name2 = "Black Dragonscale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Small Brown-wrapped Package)
*
***************************************************************/

namespace Server.Items
{
	public class SmallBrownWrappedPackage : Item
	{
		public SmallBrownWrappedPackage() : base()
		{
			Id = 15699;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 26420;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Small Brown-wrapped Package";
			Name2 = "Small Brown-wrapped Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(A Chewed Bone)
*
***************************************************************/

namespace Server.Items
{
	public class AChewedBone : Item
	{
		public AChewedBone() : base()
		{
			Id = 15793;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 26474;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Chewed Bone";
			Name2 = "A Chewed Bone";
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Chipped Ogre Teeth)
*
***************************************************************/

namespace Server.Items
{
	public class ChippedOgreTeeth : Item
	{
		public ChippedOgreTeeth() : base()
		{
			Id = 15798;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 7054;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Chipped Ogre Teeth";
			Name2 = "Chipped Ogre Teeth";
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(A Crazy Grab Bag)
*
***************************************************************/

namespace Server.Items
{
	public class ACrazyGrabBag : Item
	{
		public ACrazyGrabBag() : base()
		{
			Id = 15902;
			Bonding = 1;
			SellPrice = 20000;
			AvailableClasses = 0x7FFF;
			Model = 12333;
			ObjectClass = 15;
			SubClass = 0;
			Level = 55;
			Name = "A Crazy Grab Bag";
			Name2 = "A Crazy Grab Bag";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 1)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage1 : Item
	{
		public ShredderOperatingManualPage1() : base()
		{
			Id = 16645;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 1";
			Name2 = "Shredder Operating Manual - Page 1";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20529 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 2)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage2 : Item
	{
		public ShredderOperatingManualPage2() : base()
		{
			Id = 16646;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 2";
			Name2 = "Shredder Operating Manual - Page 2";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20529 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 3)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage3 : Item
	{
		public ShredderOperatingManualPage3() : base()
		{
			Id = 16647;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 3";
			Name2 = "Shredder Operating Manual - Page 3";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20529 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 4)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage4 : Item
	{
		public ShredderOperatingManualPage4() : base()
		{
			Id = 16648;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 4";
			Name2 = "Shredder Operating Manual - Page 4";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20529 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 5)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage5 : Item
	{
		public ShredderOperatingManualPage5() : base()
		{
			Id = 16649;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 5";
			Name2 = "Shredder Operating Manual - Page 5";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20530 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 6)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage6 : Item
	{
		public ShredderOperatingManualPage6() : base()
		{
			Id = 16650;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 6";
			Name2 = "Shredder Operating Manual - Page 6";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20530 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 7)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage7 : Item
	{
		public ShredderOperatingManualPage7() : base()
		{
			Id = 16651;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 7";
			Name2 = "Shredder Operating Manual - Page 7";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20530 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 8)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage8 : Item
	{
		public ShredderOperatingManualPage8() : base()
		{
			Id = 16652;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 8";
			Name2 = "Shredder Operating Manual - Page 8";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20530 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 9)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage9 : Item
	{
		public ShredderOperatingManualPage9() : base()
		{
			Id = 16653;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 9";
			Name2 = "Shredder Operating Manual - Page 9";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20531 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 10)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage10 : Item
	{
		public ShredderOperatingManualPage10() : base()
		{
			Id = 16654;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 10";
			Name2 = "Shredder Operating Manual - Page 10";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20531 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 11)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage11 : Item
	{
		public ShredderOperatingManualPage11() : base()
		{
			Id = 16655;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 11";
			Name2 = "Shredder Operating Manual - Page 11";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20531 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Manual - Page 12)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingManualPage12 : Item
	{
		public ShredderOperatingManualPage12() : base()
		{
			Id = 16656;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shredder Operating Manual - Page 12";
			Name2 = "Shredder Operating Manual - Page 12";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 20531 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Broken Lock)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenLock : Item
	{
		public BrokenLock() : base()
		{
			Id = 16747;
			SellPrice = 27;
			AvailableClasses = 0x7FFF;
			Model = 7842;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken Lock";
			Name2 = "Broken Lock";
			AvailableRaces = 0x1FF;
			BuyPrice = 110;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Padded Lining)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedLining : Item
	{
		public PaddedLining() : base()
		{
			Id = 16748;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 7418;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Padded Lining";
			Name2 = "Padded Lining";
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Damp Note)
*
***************************************************************/

namespace Server.Items
{
	public class DampNote : Item
	{
		public DampNote() : base()
		{
			Id = 16790;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24153;
			ObjectClass = 15;
			SubClass = 0;
			Level = 17;
			ReqLevel = 17;
			Name = "Damp Note";
			Name2 = "Damp Note";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 6564;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Battered Junkbox)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredJunkbox : Item
	{
		public BatteredJunkbox() : base()
		{
			Id = 16882;
			AvailableClasses = 0x7FFF;
			Model = 15692;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			Name = "Battered Junkbox";
			Name2 = "Battered Junkbox";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 5;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Worn Junkbox)
*
***************************************************************/

namespace Server.Items
{
	public class WornJunkbox : Item
	{
		public WornJunkbox() : base()
		{
			Id = 16883;
			AvailableClasses = 0x7FFF;
			Model = 15692;
			ObjectClass = 15;
			SubClass = 0;
			Level = 30;
			Name = "Worn Junkbox";
			Name2 = "Worn Junkbox";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 24;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sturdy Junkbox)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyJunkbox : Item
	{
		public SturdyJunkbox() : base()
		{
			Id = 16884;
			AvailableClasses = 0x7FFF;
			Model = 15590;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Sturdy Junkbox";
			Name2 = "Sturdy Junkbox";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 61;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Heavy Junkbox)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyJunkbox : Item
	{
		public HeavyJunkbox() : base()
		{
			Id = 16885;
			AvailableClasses = 0x7FFF;
			Model = 15590;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Heavy Junkbox";
			Name2 = "Heavy Junkbox";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			LockId = 599;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Feralas Ahi)
*
***************************************************************/

namespace Server.Items
{
	public class FeralasAhi : Item
	{
		public FeralasAhi() : base()
		{
			Id = 16967;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 24715;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			Name = "Feralas Ahi";
			Name2 = "Feralas Ahi";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Small Scroll)
*
***************************************************************/

namespace Server.Items
{
	public class SmallScroll : Item
	{
		public SmallScroll() : base()
		{
			Id = 17008;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The scroll bears an insignia foreign to you.";
			Model = 1301;
			ObjectClass = 15;
			SubClass = 0;
			Level = 28;
			ReqLevel = 28;
			Name = "Small Scroll";
			Name2 = "Small Scroll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 6522;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Light Feather)
*
***************************************************************/

namespace Server.Items
{
	public class LightFeather : Item
	{
		public LightFeather() : base()
		{
			Id = 17056;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 28877;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Light Feather";
			Name2 = "Light Feather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Shiny Fish Scales)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyFishScales : Item
	{
		public ShinyFishScales() : base()
		{
			Id = 17057;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 28878;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Shiny Fish Scales";
			Name2 = "Shiny Fish Scales";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Fish Oil)
*
***************************************************************/

namespace Server.Items
{
	public class FishOil : Item
	{
		public FishOil() : base()
		{
			Id = 17058;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 15773;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Fish Oil";
			Name2 = "Fish Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Mistletoe)
*
***************************************************************/

namespace Server.Items
{
	public class Mistletoe : Item
	{
		public Mistletoe() : base()
		{
			Id = 17195;
			AvailableClasses = 0x7FFF;
			Model = 29165;
			ObjectClass = 15;
			SubClass = 0;
			Level = 5;
			Name = "Mistletoe";
			Name2 = "Mistletoe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Smokywood Pastures Sampler)
*
***************************************************************/

namespace Server.Items
{
	public class SmokywoodPasturesSampler : Item
	{
		public SmokywoodPasturesSampler() : base()
		{
			Id = 17685;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 29692;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Smokywood Pastures Sampler";
			Name2 = "Smokywood Pastures Sampler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Winter Veil Disguise Kit)
*
***************************************************************/

namespace Server.Items
{
	public class WinterVeilDisguiseKit : Item
	{
		public WinterVeilDisguiseKit() : base()
		{
			Id = 17712;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "For when the weather outside is frightful...";
			Model = 29903;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Winter Veil Disguise Kit";
			Name2 = "Winter Veil Disguise Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 21848 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Smokywood Pastures Special Gift)
*
***************************************************************/

namespace Server.Items
{
	public class SmokywoodPasturesSpecialGift : Item
	{
		public SmokywoodPasturesSpecialGift() : base()
		{
			Id = 17726;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 29902;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Smokywood Pastures Special Gift";
			Name2 = "Smokywood Pastures Special Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Smokywood Pastures Gift Pack)
*
***************************************************************/

namespace Server.Items
{
	public class SmokywoodPasturesGiftPack : Item
	{
		public SmokywoodPasturesGiftPack() : base()
		{
			Id = 17727;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 24053;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Smokywood Pastures Gift Pack";
			Name2 = "Smokywood Pastures Gift Pack";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(The Feast of Winter Veil)
*
***************************************************************/

namespace Server.Items
{
	public class TheFeastOfWinterVeil : Item
	{
		public TheFeastOfWinterVeil() : base()
		{
			Id = 17735;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 1103;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "The Feast of Winter Veil";
			Name2 = "The Feast of Winter Veil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2571;
		}
	}
}


/**************************************************************
*
*				(Blue Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class BlueSackOfGems : Item
	{
		public BlueSackOfGems() : base()
		{
			Id = 17962;
			SellPrice = 4762;
			AvailableClasses = 0x7FFF;
			Model = 2588;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Blue Sack of Gems";
			Name2 = "Blue Sack of Gems";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19050;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Green Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class GreenSackOfGems : Item
	{
		public GreenSackOfGems() : base()
		{
			Id = 17963;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 3568;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Green Sack of Gems";
			Name2 = "Green Sack of Gems";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 854;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Gray Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class GraySackOfGems : Item
	{
		public GraySackOfGems() : base()
		{
			Id = 17964;
			SellPrice = 5512;
			AvailableClasses = 0x7FFF;
			Model = 1282;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gray Sack of Gems";
			Name2 = "Gray Sack of Gems";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22050;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Yellow Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class YellowSackOfGems : Item
	{
		public YellowSackOfGems() : base()
		{
			Id = 17965;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 1168;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Yellow Sack of Gems";
			Name2 = "Yellow Sack of Gems";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 854;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Red Sack of Gems)
*
***************************************************************/

namespace Server.Items
{
	public class RedSackOfGems : Item
	{
		public RedSackOfGems() : base()
		{
			Id = 17969;
			SellPrice = 4773;
			AvailableClasses = 0x7FFF;
			Model = 4056;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Red Sack of Gems";
			Name2 = "Red Sack of Gems";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19095;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Thorny Vine)
*
***************************************************************/

namespace Server.Items
{
	public class ThornyVine : Item
	{
		public ThornyVine() : base()
		{
			Id = 18222;
			SellPrice = 3070;
			AvailableClasses = 0x7FFF;
			Model = 30600;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Thorny Vine";
			Name2 = "Thorny Vine";
			AvailableRaces = 0x1FF;
			BuyPrice = 12280;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Serrated Petal)
*
***************************************************************/

namespace Server.Items
{
	public class SerratedPetal : Item
	{
		public SerratedPetal() : base()
		{
			Id = 18223;
			SellPrice = 6142;
			AvailableClasses = 0x7FFF;
			Model = 30601;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Serrated Petal";
			Name2 = "Serrated Petal";
			AvailableRaces = 0x1FF;
			BuyPrice = 24568;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lasher Root)
*
***************************************************************/

namespace Server.Items
{
	public class LasherRoot : Item
	{
		public LasherRoot() : base()
		{
			Id = 18224;
			SellPrice = 1728;
			AvailableClasses = 0x7FFF;
			Model = 6501;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Lasher Root";
			Name2 = "Lasher Root";
			AvailableRaces = 0x1FF;
			BuyPrice = 6912;
			InventoryType = InventoryTypes.None;
			Stackable = 40;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Worn Running Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class WornRunningShoes : Item
	{
		public WornRunningShoes() : base()
		{
			Id = 18225;
			AvailableClasses = 0x7FFF;
			Model = 30602;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Worn Running Shoes";
			Name2 = "Worn Running Shoes";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(A Sealed Pact)
*
***************************************************************/

namespace Server.Items
{
	public class ASealedPact : Item
	{
		public ASealedPact() : base()
		{
			Id = 18226;
			AvailableClasses = 0x7FFF;
			Model = 18010;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Sealed Pact";
			Name2 = "A Sealed Pact";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Nubless Pacifier)
*
***************************************************************/

namespace Server.Items
{
	public class NublessPacifier : Item
	{
		public NublessPacifier() : base()
		{
			Id = 18227;
			AvailableClasses = 0x7FFF;
			Description = "This item has seen much use.";
			Model = 20628;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Nubless Pacifier";
			Name2 = "Nubless Pacifier";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Autographed Picture of Foror & Tigule)
*
***************************************************************/

namespace Server.Items
{
	public class AutographedPictureOfFororTigule : Item
	{
		public AutographedPictureOfFororTigule() : base()
		{
			Id = 18228;
			AvailableClasses = 0x7FFF;
			Description = "The mystery remains unsolved.";
			Model = 30603;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Autographed Picture of Foror & Tigule";
			Name2 = "Autographed Picture of Foror & Tigule";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Nat Pagle's Guide to Extreme Anglin')
*
***************************************************************/

namespace Server.Items
{
	public class NatPaglesGuideToExtremeAnglin : Item
	{
		public NatPaglesGuideToExtremeAnglin() : base()
		{
			Id = 18229;
			AvailableClasses = 0x7FFF;
			Description = "This book is missing every page but the last.";
			Model = 12547;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Nat Pagle's Guide to Extreme Anglin'";
			Name2 = "Nat Pagle's Guide to Extreme Anglin'";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			PageText = 2611;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Broken I.W.I.N. Button)
*
***************************************************************/

namespace Server.Items
{
	public class BrokenIWINButton : Item
	{
		public BrokenIWINButton() : base()
		{
			Id = 18230;
			AvailableClasses = 0x7FFF;
			Description = "If only it worked.";
			Model = 12410;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Broken I.W.I.N. Button";
			Name2 = "Broken I.W.I.N. Button";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Sleeveless T-Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class SleevelessTShirt : Item
	{
		public SleevelessTShirt() : base()
		{
			Id = 18231;
			AvailableClasses = 0x7FFF;
			Description = "On the inside collar it reads, Inspected by Earl Z. Moade.";
			Model = 30605;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sleeveless T-Shirt";
			Name2 = "Sleeveless T-Shirt";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Tear Stained Handkerchief)
*
***************************************************************/

namespace Server.Items
{
	public class TearStainedHandkerchief : Item
	{
		public TearStainedHandkerchief() : base()
		{
			Id = 18233;
			AvailableClasses = 0x7FFF;
			Description = "The owner of this item could have probably used a hug.";
			Model = 18170;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Tear Stained Handkerchief";
			Name2 = "Tear Stained Handkerchief";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Document from Boomstick Imports)
*
***************************************************************/

namespace Server.Items
{
	public class DocumentFromBoomstickImports : Item
	{
		public DocumentFromBoomstickImports() : base()
		{
			Id = 18234;
			AvailableClasses = 0x7FFF;
			Description = "You think that you can make out some numbers. This appears to be a repair bill.";
			Model = 24154;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Document from Boomstick Imports";
			Name2 = "Document from Boomstick Imports";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Gordok Chew Toy)
*
***************************************************************/

namespace Server.Items
{
	public class GordokChewToy : Item
	{
		public GordokChewToy() : base()
		{
			Id = 18236;
			SellPrice = 2716;
			AvailableClasses = 0x7FFF;
			Model = 13433;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gordok Chew Toy";
			Name2 = "Gordok Chew Toy";
			AvailableRaces = 0x1FF;
			BuyPrice = 10864;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mastiff Jawbone)
*
***************************************************************/

namespace Server.Items
{
	public class MastiffJawbone : Item
	{
		public MastiffJawbone() : base()
		{
			Id = 18237;
			SellPrice = 1622;
			AvailableClasses = 0x7FFF;
			Model = 21368;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Mastiff Jawbone";
			Name2 = "Mastiff Jawbone";
			AvailableRaces = 0x1FF;
			BuyPrice = 6490;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Black War Steed Bridle)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWarSteedBridle : Item
	{
		public BlackWarSteedBridle() : base()
		{
			Id = 18241;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 30608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Black War Steed Bridle";
			Name2 = "Black War Steed Bridle";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22717 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Black War Tiger)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheBlackWarTiger : Item
	{
		public ReinsOfTheBlackWarTiger() : base()
		{
			Id = 18242;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17606;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Black War Tiger";
			Name2 = "Reins of the Black War Tiger";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22723 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Black Battlestrider)
*
***************************************************************/

namespace Server.Items
{
	public class BlackBattlestrider : Item
	{
		public BlackBattlestrider() : base()
		{
			Id = 18243;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Black Battlestrider";
			Name2 = "Black Battlestrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22719 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Black War Ram)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWarRam : Item
	{
		public BlackWarRam() : base()
		{
			Id = 18244;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Black War Ram";
			Name2 = "Black War Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22720 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Black War Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheBlackWarWolf : Item
	{
		public HornOfTheBlackWarWolf() : base()
		{
			Id = 18245;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Horn of the Black War Wolf";
			Name2 = "Horn of the Black War Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22724 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Whistle of the Black War Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class WhistleOfTheBlackWarRaptor : Item
	{
		public WhistleOfTheBlackWarRaptor() : base()
		{
			Id = 18246;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Whistle of the Black War Raptor";
			Name2 = "Whistle of the Black War Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22721 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Black War Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWarKodo : Item
	{
		public BlackWarKodo() : base()
		{
			Id = 18247;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 29447;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Black War Kodo";
			Name2 = "Black War Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22718 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Red Skeletal Warhorse)
*
***************************************************************/

namespace Server.Items
{
	public class RedSkeletalWarhorse : Item
	{
		public RedSkeletalWarhorse() : base()
		{
			Id = 18248;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Red Skeletal Warhorse";
			Name2 = "Red Skeletal Warhorse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22722 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Gordok Shackle Key)
*
***************************************************************/

namespace Server.Items
{
	public class GordokShackleKey : Item
	{
		public GordokShackleKey() : base()
		{
			Id = 18250;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Used with Gordok ogre shackles.";
			Model = 22071;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Gordok Shackle Key";
			Name2 = "Gordok Shackle Key";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Crystallized Mana Shard)
*
***************************************************************/

namespace Server.Items
{
	public class CrystallizedManaShard : Item
	{
		public CrystallizedManaShard() : base()
		{
			Id = 18285;
			SellPrice = 4558;
			AvailableClasses = 0x7FFF;
			Model = 2516;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Crystallized Mana Shard";
			Name2 = "Crystallized Mana Shard";
			AvailableRaces = 0x1FF;
			BuyPrice = 18234;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Condensed Mana Fragment)
*
***************************************************************/

namespace Server.Items
{
	public class CondensedManaFragment : Item
	{
		public CondensedManaFragment() : base()
		{
			Id = 18286;
			SellPrice = 2953;
			AvailableClasses = 0x7FFF;
			Model = 30634;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Condensed Mana Fragment";
			Name2 = "Condensed Mana Fragment";
			AvailableRaces = 0x1FF;
			BuyPrice = 11812;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Garona: A Study on Stealth and Treachery)
*
***************************************************************/

namespace Server.Items
{
	public class GaronaAStudyOnStealthAndTreachery : Item
	{
		public GaronaAStudyOnStealthAndTreachery() : base()
		{
			Id = 18356;
			AvailableClasses = 0x08;
			Description = "The tome is magically sealed.";
			Model = 1246;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "Garona: A Study on Stealth and Treachery";
			Name2 = "Garona: A Study on Stealth and Treachery";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7498;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Codex of Defense)
*
***************************************************************/

namespace Server.Items
{
	public class CodexOfDefense : Item
	{
		public CodexOfDefense() : base()
		{
			Id = 18357;
			AvailableClasses = 0x01;
			Description = "The tome is magically sealed.";
			Model = 1103;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "Codex of Defense";
			Name2 = "Codex of Defense";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7499;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The Arcanist's Cookbook)
*
***************************************************************/

namespace Server.Items
{
	public class TheArcanistsCookbook : Item
	{
		public TheArcanistsCookbook() : base()
		{
			Id = 18358;
			AvailableClasses = 0x80;
			Description = "The tome is magically sealed.";
			Model = 7139;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "The Arcanist's Cookbook";
			Name2 = "The Arcanist's Cookbook";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7500;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The Light and How to Swing It)
*
***************************************************************/

namespace Server.Items
{
	public class TheLightAndHowToSwingIt : Item
	{
		public TheLightAndHowToSwingIt() : base()
		{
			Id = 18359;
			AvailableClasses = 0x02;
			Description = "-By Uther";
			Model = 1317;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "The Light and How to Swing It";
			Name2 = "The Light and How to Swing It";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7501;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Harnessing Shadows)
*
***************************************************************/

namespace Server.Items
{
	public class HarnessingShadows : Item
	{
		public HarnessingShadows() : base()
		{
			Id = 18360;
			AvailableClasses = 0x100;
			Description = "Tales from the Blasted Lands as told by Lady Sevine.";
			Model = 8093;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "Harnessing Shadows";
			Name2 = "Harnessing Shadows";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7502;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The Greatest Race of Hunters)
*
***************************************************************/

namespace Server.Items
{
	public class TheGreatestRaceOfHunters : Item
	{
		public TheGreatestRaceOfHunters() : base()
		{
			Id = 18361;
			AvailableClasses = 0x04;
			Description = "A Tale of a Female Troll and Her Tiger";
			Model = 12547;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "The Greatest Race of Hunters";
			Name2 = "The Greatest Race of Hunters";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7503;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Holy Bologna: What the Light Won't Tell You)
*
***************************************************************/

namespace Server.Items
{
	public class HolyBolognaWhatTheLightWontTellYou : Item
	{
		public HolyBolognaWhatTheLightWontTellYou() : base()
		{
			Id = 18362;
			AvailableClasses = 0x10;
			Description = "-By Shadow Priest Allister";
			Model = 1155;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "Holy Bologna: What the Light Won't Tell You";
			Name2 = "Holy Bologna: What the Light Won't Tell You";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7504;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Frost Shock and You)
*
***************************************************************/

namespace Server.Items
{
	public class FrostShockAndYou : Item
	{
		public FrostShockAndYou() : base()
		{
			Id = 18363;
			AvailableClasses = 0x40;
			Description = "-By Drek'Thar";
			Model = 6672;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "Frost Shock and You";
			Name2 = "Frost Shock and You";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7505;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(The Emerald Dream)
*
***************************************************************/

namespace Server.Items
{
	public class TheEmeraldDream : Item
	{
		public TheEmeraldDream() : base()
		{
			Id = 18364;
			AvailableClasses = 0x400;
			Description = "Fact or Carefully Planned Out Farce Perpetrated By My Brother -By Illidan";
			Model = 1134;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 54;
			Name = "The Emerald Dream";
			Name2 = "The Emerald Dream";
			Quality = 3;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7506;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(A Thoroughly Read Copy of "Nat Pagle's Extreme' Anglin.")
*
***************************************************************/

namespace Server.Items
{
	public class AThoroughlyReadCopyOfNatPaglesExtremeAnglin : Item
	{
		public AThoroughlyReadCopyOfNatPaglesExtremeAnglin() : base()
		{
			Id = 18365;
			AvailableClasses = 0x7FFF;
			Description = "Someone really loves to fish.";
			Model = 5780;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "A Thoroughly Read Copy of Nat Pagle's Extreme' Anglin.";
			Name2 = "A Thoroughly Read Copy of Nat Pagle's Extreme' Anglin.";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Foror's Compendium of Dragon Slaying)
*
***************************************************************/

namespace Server.Items
{
	public class FororsCompendiumOfDragonSlaying : Item
	{
		public FororsCompendiumOfDragonSlaying() : base()
		{
			Id = 18401;
			AvailableClasses = 0x03;
			Description = "Several pages are blank.";
			Model = 1317;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Foror's Compendium of Dragon Slaying";
			Name2 = "Foror's Compendium of Dragon Slaying";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7507;
			MaxCount = 1;
			Material = -1;
			PageText = 2637;
			PageMaterial = 3;
		}
	}
}


/**************************************************************
*
*				(Bindings of the Windseeker)
*
***************************************************************/

namespace Server.Items
{
	public class BindingsOfTheWindseeker : Item
	{
		public BindingsOfTheWindseeker() : base()
		{
			Id = 18563;
			Bonding = 1;
			AvailableClasses = 0x0F;
			Description = "The Left Half of Thunderaan's Eternal Prison";
			Model = 30912;
			ObjectClass = 15;
			SubClass = 0;
			Level = 70;
			Name = "Bindings of the Windseeker";
			Name2 = "Bindings of the Windseeker";
			Quality = 5;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Bindings of the Windseeker)
*
***************************************************************/

namespace Server.Items
{
	public class BindingsOfTheWindseeker18564 : Item
	{
		public BindingsOfTheWindseeker18564() : base()
		{
			Id = 18564;
			Bonding = 1;
			AvailableClasses = 0x0F;
			Description = "The Right Half of Thunderaan's Eternal Prison";
			Model = 30912;
			ObjectClass = 15;
			SubClass = 0;
			Level = 70;
			Name = "Bindings of the Windseeker";
			Name2 = "Bindings of the Windseeker";
			Quality = 5;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Orcish Orphan Whistle)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishOrphanWhistle : Item
	{
		public OrcishOrphanWhistle() : base()
		{
			Id = 18597;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 30959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			Name = "Orcish Orphan Whistle";
			Name2 = "Orcish Orphan Whistle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23012 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Human Orphan Whistle)
*
***************************************************************/

namespace Server.Items
{
	public class HumanOrphanWhistle : Item
	{
		public HumanOrphanWhistle() : base()
		{
			Id = 18598;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 30959;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			Name = "Human Orphan Whistle";
			Name2 = "Human Orphan Whistle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23013 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(A Treatise on Military Ranks)
*
***************************************************************/

namespace Server.Items
{
	public class ATreatiseOnMilitaryRanks : Item
	{
		public ATreatiseOnMilitaryRanks() : base()
		{
			Id = 18664;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 31095;
			ObjectClass = 15;
			SubClass = 0;
			Name = "A Treatise on Military Ranks";
			Name2 = "A Treatise on Military Ranks";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 2654;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Military Ranks of the Horde & Alliance)
*
***************************************************************/

namespace Server.Items
{
	public class MilitaryRanksOfTheHordeAlliance : Item
	{
		public MilitaryRanksOfTheHordeAlliance() : base()
		{
			Id = 18675;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 4742;
			ObjectClass = 15;
			SubClass = 0;
			Name = "Military Ranks of the Horde & Alliance";
			Name2 = "Military Ranks of the Horde & Alliance";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 2661;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Reins of the Swift Frostsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheSwiftFrostsaber : Item
	{
		public ReinsOfTheSwiftFrostsaber() : base()
		{
			Id = 18766;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Swift Frostsaber";
			Name2 = "Reins of the Swift Frostsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23221 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Swift Mistsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheSwiftMistsaber : Item
	{
		public ReinsOfTheSwiftMistsaber() : base()
		{
			Id = 18767;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Swift Mistsaber";
			Name2 = "Reins of the Swift Mistsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23219 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Green Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftGreenMechanostrider : Item
	{
		public SwiftGreenMechanostrider() : base()
		{
			Id = 18772;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Green Mechanostrider";
			Name2 = "Swift Green Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23225 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift White Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftWhiteMechanostrider : Item
	{
		public SwiftWhiteMechanostrider() : base()
		{
			Id = 18773;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift White Mechanostrider";
			Name2 = "Swift White Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23223 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Yellow Mechanostrider)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftYellowMechanostrider : Item
	{
		public SwiftYellowMechanostrider() : base()
		{
			Id = 18774;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17785;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Yellow Mechanostrider";
			Name2 = "Swift Yellow Mechanostrider";
			Quality = 1;
			AvailableRaces = 0x44;
			SkillRank = 1;
			Skill = 553;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23222 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Palomino)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftPalomino : Item
	{
		public SwiftPalomino() : base()
		{
			Id = 18776;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 25132;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Palomino";
			Name2 = "Swift Palomino";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23227 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Brown Steed)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftBrownSteed : Item
	{
		public SwiftBrownSteed() : base()
		{
			Id = 18777;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 25132;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Brown Steed";
			Name2 = "Swift Brown Steed";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23229 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift White Steed)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftWhiteSteed : Item
	{
		public SwiftWhiteSteed() : base()
		{
			Id = 18778;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 25132;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift White Steed";
			Name2 = "Swift White Steed";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 148;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23228 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift White Ram)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftWhiteRam : Item
	{
		public SwiftWhiteRam() : base()
		{
			Id = 18785;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift White Ram";
			Name2 = "Swift White Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23240 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Brown Ram)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftBrownRam : Item
	{
		public SwiftBrownRam() : base()
		{
			Id = 18786;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Brown Ram";
			Name2 = "Swift Brown Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23238 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Gray Ram)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftGrayRam : Item
	{
		public SwiftGrayRam() : base()
		{
			Id = 18787;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Gray Ram";
			Name2 = "Swift Gray Ram";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 152;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23239 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Blue Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftBlueRaptor : Item
	{
		public SwiftBlueRaptor() : base()
		{
			Id = 18788;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Blue Raptor";
			Name2 = "Swift Blue Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23241 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Olive Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftOliveRaptor : Item
	{
		public SwiftOliveRaptor() : base()
		{
			Id = 18789;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Olive Raptor";
			Name2 = "Swift Olive Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23242 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swift Orange Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftOrangeRaptor : Item
	{
		public SwiftOrangeRaptor() : base()
		{
			Id = 18790;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17494;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Swift Orange Raptor";
			Name2 = "Swift Orange Raptor";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 533;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23243 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Purple Skeletal Warhorse)
*
***************************************************************/

namespace Server.Items
{
	public class PurpleSkeletalWarhorse : Item
	{
		public PurpleSkeletalWarhorse() : base()
		{
			Id = 18791;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17786;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Purple Skeletal Warhorse";
			Name2 = "Purple Skeletal Warhorse";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 554;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23246 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Great White Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class GreatWhiteKodo : Item
	{
		public GreatWhiteKodo() : base()
		{
			Id = 18793;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29448;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Great White Kodo";
			Name2 = "Great White Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23247 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Great Brown Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class GreatBrownKodo : Item
	{
		public GreatBrownKodo() : base()
		{
			Id = 18794;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29447;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Great Brown Kodo";
			Name2 = "Great Brown Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23249 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Great Gray Kodo)
*
***************************************************************/

namespace Server.Items
{
	public class GreatGrayKodo : Item
	{
		public GreatGrayKodo() : base()
		{
			Id = 18795;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 29448;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Great Gray Kodo";
			Name2 = "Great Gray Kodo";
			Quality = 1;
			AvailableRaces = 0xB2;
			SkillRank = 1;
			Skill = 713;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23248 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Swift Brown Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheSwiftBrownWolf : Item
	{
		public HornOfTheSwiftBrownWolf() : base()
		{
			Id = 18796;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16208;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Horn of the Swift Brown Wolf";
			Name2 = "Horn of the Swift Brown Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23250 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Swift Timber Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheSwiftTimberWolf : Item
	{
		public HornOfTheSwiftTimberWolf() : base()
		{
			Id = 18797;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Horn of the Swift Timber Wolf";
			Name2 = "Horn of the Swift Timber Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23251 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Swift Gray Wolf)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheSwiftGrayWolf : Item
	{
		public HornOfTheSwiftGrayWolf() : base()
		{
			Id = 18798;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 16207;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Horn of the Swift Gray Wolf";
			Name2 = "Horn of the Swift Gray Wolf";
			Quality = 1;
			AvailableRaces = 0x92;
			SkillRank = 1;
			Skill = 149;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23252 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Swift Stormsaber)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheSwiftStormsaber : Item
	{
		public ReinsOfTheSwiftStormsaber() : base()
		{
			Id = 18902;
			Bonding = 3;
			AvailableClasses = 0x7FFF;
			Model = 17608;
			ObjectClass = 15;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Reins of the Swift Stormsaber";
			Name2 = "Reins of the Swift Stormsaber";
			Quality = 1;
			AvailableRaces = 0x4D;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 10000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23338 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Horn of the Frostwolf Howler)
*
***************************************************************/

namespace Server.Items
{
	public class HornOfTheFrostwolfHowler : Item
	{
		public HornOfTheFrostwolfHowler() : base()
		{
			Id = 19029;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31511;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Horn of the Frostwolf Howler";
			Name2 = "Horn of the Frostwolf Howler";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23509 , 0 , 0 , -1 , 330 , -1 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Battle Charger)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeBattleCharger : Item
	{
		public StormpikeBattleCharger() : base()
		{
			Id = 19030;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 17343;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Stormpike Battle Charger";
			Name2 = "Stormpike Battle Charger";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23510 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Lard's Special Picnic Basket)
*
***************************************************************/

namespace Server.Items
{
	public class LardsSpecialPicnicBasket : Item
	{
		public LardsSpecialPicnicBasket() : base()
		{
			Id = 19035;
			Bonding = 1;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 12333;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			Name = "Lard's Special Picnic Basket";
			Name2 = "Lard's Special Picnic Basket";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Ace of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class AceOfBeasts : Item
	{
		public AceOfBeasts() : base()
		{
			Id = 19227;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ace of Beasts";
			Name2 = "Ace of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Beasts Deck)
*
***************************************************************/

namespace Server.Items
{
	public class BeastsDeck : Item
	{
		public BeastsDeck() : base()
		{
			Id = 19228;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Description = "Property of the Darkmoon Faire.";
			Model = 31755;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Beasts Deck";
			Name2 = "Beasts Deck";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7907;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #1)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune1 : Item
	{
		public SaygesFortune1() : base()
		{
			Id = 19229;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Never eat beef with a tauren.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #1";
			Name2 = "Sayge's Fortune #1";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Two of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class TwoOfBeasts : Item
	{
		public TwoOfBeasts() : base()
		{
			Id = 19230;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Two of Beasts";
			Name2 = "Two of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Three of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class ThreeOfBeasts : Item
	{
		public ThreeOfBeasts() : base()
		{
			Id = 19231;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Three of Beasts";
			Name2 = "Three of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Four of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class FourOfBeasts : Item
	{
		public FourOfBeasts() : base()
		{
			Id = 19232;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Four of Beasts";
			Name2 = "Four of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Five of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class FiveOfBeasts : Item
	{
		public FiveOfBeasts() : base()
		{
			Id = 19233;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Five of Beasts";
			Name2 = "Five of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Six of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class SixOfBeasts : Item
	{
		public SixOfBeasts() : base()
		{
			Id = 19234;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Six of Beasts";
			Name2 = "Six of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Seven of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class SevenOfBeasts : Item
	{
		public SevenOfBeasts() : base()
		{
			Id = 19235;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Seven of Beasts";
			Name2 = "Seven of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eight of Beasts)
*
***************************************************************/

namespace Server.Items
{
	public class EightOfBeasts : Item
	{
		public EightOfBeasts() : base()
		{
			Id = 19236;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31756;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Eight of Beasts";
			Name2 = "Eight of Beasts";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23677 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #19)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune19 : Item
	{
		public SaygesFortune19() : base()
		{
			Id = 19237;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The Forsaken are up to something.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #19";
			Name2 = "Sayge's Fortune #19";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #3)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune3 : Item
	{
		public SaygesFortune3() : base()
		{
			Id = 19238;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "An enemy from your past will soon become an ally.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #3";
			Name2 = "Sayge's Fortune #3";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #4)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune4 : Item
	{
		public SaygesFortune4() : base()
		{
			Id = 19239;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "You will be fortunate in everything you put your hands to.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #4";
			Name2 = "Sayge's Fortune #4";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #5)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune5 : Item
	{
		public SaygesFortune5() : base()
		{
			Id = 19240;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Someone is speaking well of you.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #5";
			Name2 = "Sayge's Fortune #5";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #6)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune6 : Item
	{
		public SaygesFortune6() : base()
		{
			Id = 19241;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Be cautious when landing in unfamiliar territory.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #6";
			Name2 = "Sayge's Fortune #6";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #7)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune7 : Item
	{
		public SaygesFortune7() : base()
		{
			Id = 19242;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Avoid taking unnecessary gambles.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #7";
			Name2 = "Sayge's Fortune #7";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #8)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune8 : Item
	{
		public SaygesFortune8() : base()
		{
			Id = 19243;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "You will receive a fortune.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #8";
			Name2 = "Sayge's Fortune #8";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #9)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune9 : Item
	{
		public SaygesFortune9() : base()
		{
			Id = 19244;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Your first love and last love is self-love.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #9";
			Name2 = "Sayge's Fortune #9";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #10)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune10 : Item
	{
		public SaygesFortune10() : base()
		{
			Id = 19245;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Rest is a good thing, but boredom is its brother.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #10";
			Name2 = "Sayge's Fortune #10";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #11)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune11 : Item
	{
		public SaygesFortune11() : base()
		{
			Id = 19246;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Those with simple tastes are always satisfied with the best.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #11";
			Name2 = "Sayge's Fortune #11";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #12)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune12 : Item
	{
		public SaygesFortune12() : base()
		{
			Id = 19247;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Let not the tides of war wash you away.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #12";
			Name2 = "Sayge's Fortune #12";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #13)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune13 : Item
	{
		public SaygesFortune13() : base()
		{
			Id = 19248;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "You leave your adversaries speechless.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #13";
			Name2 = "Sayge's Fortune #13";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #14)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune14 : Item
	{
		public SaygesFortune14() : base()
		{
			Id = 19249;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "You have a good eye for spotting hypocrisy.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #14";
			Name2 = "Sayge's Fortune #14";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #15)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune15 : Item
	{
		public SaygesFortune15() : base()
		{
			Id = 19250;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "One learns most when teaching others.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #15";
			Name2 = "Sayge's Fortune #15";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #16)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune16 : Item
	{
		public SaygesFortune16() : base()
		{
			Id = 19251;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "The time will soon come for you to make a choice in a pressing matter.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #16";
			Name2 = "Sayge's Fortune #16";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #18)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune18 : Item
	{
		public SaygesFortune18() : base()
		{
			Id = 19252;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Accept the next proposition you hear.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #18";
			Name2 = "Sayge's Fortune #18";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #17)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune17 : Item
	{
		public SaygesFortune17() : base()
		{
			Id = 19253;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Never punt a gnome without due cause.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #17";
			Name2 = "Sayge's Fortune #17";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #21)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune21 : Item
	{
		public SaygesFortune21() : base()
		{
			Id = 19254;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Divine Shields and Hearthstones do not make a hero heroic.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #21";
			Name2 = "Sayge's Fortune #21";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #22)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune22 : Item
	{
		public SaygesFortune22() : base()
		{
			Id = 19255;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "An answer in blue is always true.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #22";
			Name2 = "Sayge's Fortune #22";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #2)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune2 : Item
	{
		public SaygesFortune2() : base()
		{
			Id = 19256;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "You will find something wonderful tomorrow.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #2";
			Name2 = "Sayge's Fortune #2";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Warlords Deck)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsDeck : Item
	{
		public WarlordsDeck() : base()
		{
			Id = 19257;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Description = "Property of the Darkmoon Faire.";
			Model = 31755;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Warlords Deck";
			Name2 = "Warlords Deck";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7928;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ace of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class AceOfWarlords : Item
	{
		public AceOfWarlords() : base()
		{
			Id = 19258;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ace of Warlords";
			Name2 = "Ace of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Two of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class TwoOfWarlords : Item
	{
		public TwoOfWarlords() : base()
		{
			Id = 19259;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Two of Warlords";
			Name2 = "Two of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Three of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class ThreeOfWarlords : Item
	{
		public ThreeOfWarlords() : base()
		{
			Id = 19260;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Three of Warlords";
			Name2 = "Three of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Four of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class FourOfWarlords : Item
	{
		public FourOfWarlords() : base()
		{
			Id = 19261;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Four of Warlords";
			Name2 = "Four of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Five of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class FiveOfWarlords : Item
	{
		public FiveOfWarlords() : base()
		{
			Id = 19262;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Five of Warlords";
			Name2 = "Five of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Six of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class SixOfWarlords : Item
	{
		public SixOfWarlords() : base()
		{
			Id = 19263;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Six of Warlords";
			Name2 = "Six of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Seven of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class SevenOfWarlords : Item
	{
		public SevenOfWarlords() : base()
		{
			Id = 19264;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Seven of Warlords";
			Name2 = "Seven of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eight of Warlords)
*
***************************************************************/

namespace Server.Items
{
	public class EightOfWarlords : Item
	{
		public EightOfWarlords() : base()
		{
			Id = 19265;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31760;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Eight of Warlords";
			Name2 = "Eight of Warlords";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23678 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #20)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune20 : Item
	{
		public SaygesFortune20() : base()
		{
			Id = 19266;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Many a false step is made by standing still.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #20";
			Name2 = "Sayge's Fortune #20";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Elementals Deck)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalsDeck : Item
	{
		public ElementalsDeck() : base()
		{
			Id = 19267;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Description = "Property of the Darkmoon Faire.";
			Model = 31755;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Elementals Deck";
			Name2 = "Elementals Deck";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7929;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ace of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class AceOfElementals : Item
	{
		public AceOfElementals() : base()
		{
			Id = 19268;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ace of Elementals";
			Name2 = "Ace of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Two of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class TwoOfElementals : Item
	{
		public TwoOfElementals() : base()
		{
			Id = 19269;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Two of Elementals";
			Name2 = "Two of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Three of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class ThreeOfElementals : Item
	{
		public ThreeOfElementals() : base()
		{
			Id = 19270;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Three of Elementals";
			Name2 = "Three of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Four of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class FourOfElementals : Item
	{
		public FourOfElementals() : base()
		{
			Id = 19271;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Four of Elementals";
			Name2 = "Four of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Five of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class FiveOfElementals : Item
	{
		public FiveOfElementals() : base()
		{
			Id = 19272;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Five of Elementals";
			Name2 = "Five of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Six of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class SixOfElementals : Item
	{
		public SixOfElementals() : base()
		{
			Id = 19273;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Six of Elementals";
			Name2 = "Six of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Seven of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class SevenOfElementals : Item
	{
		public SevenOfElementals() : base()
		{
			Id = 19274;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Seven of Elementals";
			Name2 = "Seven of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eight of Elementals)
*
***************************************************************/

namespace Server.Items
{
	public class EightOfElementals : Item
	{
		public EightOfElementals() : base()
		{
			Id = 19275;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31762;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Eight of Elementals";
			Name2 = "Eight of Elementals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23679 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ace of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class AceOfPortals : Item
	{
		public AceOfPortals() : base()
		{
			Id = 19276;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Ace of Portals";
			Name2 = "Ace of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Portals Deck)
*
***************************************************************/

namespace Server.Items
{
	public class PortalsDeck : Item
	{
		public PortalsDeck() : base()
		{
			Id = 19277;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Description = "Property of the Darkmoon Faire.";
			Model = 31755;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Portals Deck";
			Name2 = "Portals Deck";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7927;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Two of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class TwoOfPortals : Item
	{
		public TwoOfPortals() : base()
		{
			Id = 19278;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Two of Portals";
			Name2 = "Two of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Three of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class ThreeOfPortals : Item
	{
		public ThreeOfPortals() : base()
		{
			Id = 19279;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Three of Portals";
			Name2 = "Three of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Four of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class FourOfPortals : Item
	{
		public FourOfPortals() : base()
		{
			Id = 19280;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Four of Portals";
			Name2 = "Four of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Five of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class FiveOfPortals : Item
	{
		public FiveOfPortals() : base()
		{
			Id = 19281;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Five of Portals";
			Name2 = "Five of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Six of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class SixOfPortals : Item
	{
		public SixOfPortals() : base()
		{
			Id = 19282;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Six of Portals";
			Name2 = "Six of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Seven of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class SevenOfPortals : Item
	{
		public SevenOfPortals() : base()
		{
			Id = 19283;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Seven of Portals";
			Name2 = "Seven of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Eight of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class EightOfPortals : Item
	{
		public EightOfPortals() : base()
		{
			Id = 19284;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31767;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Eight of Portals";
			Name2 = "Eight of Portals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 23680 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Card: Heroism)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonCardHeroism : Item
	{
		public DarkmoonCardHeroism() : base()
		{
			Id = 19287;
			Bonding = 1;
			SellPrice = 100000;
			AvailableClasses = 0x7FFF;
			Model = 31768;
			ObjectClass = 15;
			SubClass = 0;
			Level = 66;
			ReqLevel = 60;
			Name = "Darkmoon Card: Heroism";
			Name2 = "Darkmoon Card: Heroism";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 400000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23689 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Greater Darkmoon Prize)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterDarkmoonPrize : Item
	{
		public GreaterDarkmoonPrize() : base()
		{
			Id = 19296;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Description = "Guaranteed to contain an item of value!";
			Model = 31783;
			ObjectClass = 15;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Greater Darkmoon Prize";
			Name2 = "Greater Darkmoon Prize";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Lesser Darkmoon Prize)
*
***************************************************************/

namespace Server.Items
{
	public class LesserDarkmoonPrize : Item
	{
		public LesserDarkmoonPrize() : base()
		{
			Id = 19297;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Description = "Guaranteed to contain an item of value!";
			Model = 1283;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Lesser Darkmoon Prize";
			Name2 = "Lesser Darkmoon Prize";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 440;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Minor Darkmoon Prize)
*
***************************************************************/

namespace Server.Items
{
	public class MinorDarkmoonPrize : Item
	{
		public MinorDarkmoonPrize() : base()
		{
			Id = 19298;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Description = "Guaranteed to contain an item of value!";
			Model = 8270;
			ObjectClass = 15;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Minor Darkmoon Prize";
			Name2 = "Minor Darkmoon Prize";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Darkmoon Faire Fortune)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonFaireFortune : Item
	{
		public DarkmoonFaireFortune() : base()
		{
			Id = 19422;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31961;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Darkmoon Faire Fortune";
			Name2 = "Darkmoon Faire Fortune";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #23)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune23 : Item
	{
		public SaygesFortune23() : base()
		{
			Id = 19423;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Your fortune awaits you in Eastvale.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			ReqLevel = 10;
			Name = "Sayge's Fortune #23";
			Name2 = "Sayge's Fortune #23";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7937;
			MaxCount = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #24)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune24 : Item
	{
		public SaygesFortune24() : base()
		{
			Id = 19424;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Your fortune awaits you inside the Deadmines.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			ReqLevel = 10;
			Name = "Sayge's Fortune #24";
			Name2 = "Sayge's Fortune #24";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7938;
			MaxCount = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #25)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune25 : Item
	{
		public SaygesFortune25() : base()
		{
			Id = 19443;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Your fortune awaits you inside Wailing Caverns.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			ReqLevel = 10;
			Name = "Sayge's Fortune #25";
			Name2 = "Sayge's Fortune #25";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7944;
			MaxCount = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(A Jubling's Tiny Home)
*
***************************************************************/

namespace Server.Items
{
	public class AJublingsTinyHome : Item
	{
		public AJublingsTinyHome() : base()
		{
			Id = 19450;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18173;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "A Jubling's Tiny Home";
			Name2 = "A Jubling's Tiny Home";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23811 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #26)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune26 : Item
	{
		public SaygesFortune26() : base()
		{
			Id = 19451;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Time is nothing; timing is everything.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #26";
			Name2 = "Sayge's Fortune #26";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #27)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune27 : Item
	{
		public SaygesFortune27() : base()
		{
			Id = 19452;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Your fortune awaits you outside Palemoon Cave.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 10;
			ReqLevel = 10;
			Name = "Sayge's Fortune #27";
			Name2 = "Sayge's Fortune #27";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 7945;
			MaxCount = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #28)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune28 : Item
	{
		public SaygesFortune28() : base()
		{
			Id = 19453;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Hunters who specialize in survival are not guaranteed to survive.";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #28";
			Name2 = "Sayge's Fortune #28";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Sayge's Fortune #29)
*
***************************************************************/

namespace Server.Items
{
	public class SaygesFortune29 : Item
	{
		public SaygesFortune29() : base()
		{
			Id = 19454;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Look out!";
			Model = 3331;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Sayge's Fortune #29";
			Name2 = "Sayge's Fortune #29";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Unhatched Jubling Egg)
*
***************************************************************/

namespace Server.Items
{
	public class UnhatchedJublingEgg : Item
	{
		public UnhatchedJublingEgg() : base()
		{
			Id = 19462;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18051;
			ObjectClass = 15;
			SubClass = 0;
			Level = 35;
			Name = "Unhatched Jubling Egg";
			Name2 = "Unhatched Jubling Egg";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 23851 , 0 , -1 , -1 , 1071 , -1 );
		}
	}
}


/**************************************************************
*
*				(Peeling the Onion)
*
***************************************************************/

namespace Server.Items
{
	public class PeelingTheOnion : Item
	{
		public PeelingTheOnion() : base()
		{
			Id = 19483;
			AvailableClasses = 0x7FFF;
			Description = "The How to Guide On Dismantling the Stormpike - By Drek'Thar";
			Model = 1103;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "Peeling the Onion";
			Name2 = "Peeling the Onion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			PageText = 2771;
		}
	}
}


/**************************************************************
*
*				(The Frostwolf Artichoke)
*
***************************************************************/

namespace Server.Items
{
	public class TheFrostwolfArtichoke : Item
	{
		public TheFrostwolfArtichoke() : base()
		{
			Id = 19484;
			AvailableClasses = 0x7FFF;
			Description = "Tales of Stormpike Glory - By Vanndar Stormpike";
			Model = 6672;
			ObjectClass = 15;
			SubClass = 0;
			Level = 1;
			Name = "The Frostwolf Artichoke";
			Name2 = "The Frostwolf Artichoke";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			PageText = 2779;
		}
	}
}


