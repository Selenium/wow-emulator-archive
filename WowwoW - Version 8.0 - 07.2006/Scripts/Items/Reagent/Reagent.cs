/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:55 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Linen Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class LinenBandage : Item
	{
		public LinenBandage() : base()
		{
			Id = 1251;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 11907;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Linen Bandage";
			Name2 = "Linen Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 129;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 746 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Heavy Linen Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLinenBandage : Item
	{
		public HeavyLinenBandage() : base()
		{
			Id = 2581;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 11908;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Heavy Linen Bandage";
			Name2 = "Heavy Linen Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 20;
			Skill = 129;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 1159 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Stormwind Seasoning Herbs)
*
***************************************************************/

namespace Server.Items
{
	public class StormwindSeasoningHerbs : Item
	{
		public StormwindSeasoningHerbs() : base()
		{
			Id = 2665;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 6396;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Stormwind Seasoning Herbs";
			Name2 = "Stormwind Seasoning Herbs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Wool Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class WoolBandage : Item
	{
		public WoolBandage() : base()
		{
			Id = 3530;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 11909;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Wool Bandage";
			Name2 = "Wool Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 129;
			BuyPrice = 115;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 3267 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Heavy Wool Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWoolBandage : Item
	{
		public HeavyWoolBandage() : base()
		{
			Id = 3531;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 11910;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Heavy Wool Bandage";
			Name2 = "Heavy Wool Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 75;
			Skill = 129;
			BuyPrice = 230;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 3268 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Simple Wood)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleWood : Item
	{
		public SimpleWood() : base()
		{
			Id = 4470;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 21102;
			ObjectClass = 5;
			SubClass = 0;
			Level = 5;
			Name = "Simple Wood";
			Name2 = "Simple Wood";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Flint and Tinder)
*
***************************************************************/

namespace Server.Items
{
	public class FlintAndTinder : Item
	{
		public FlintAndTinder() : base()
		{
			Id = 4471;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 4720;
			ObjectClass = 5;
			SubClass = 0;
			Level = 5;
			Name = "Flint and Tinder";
			Name2 = "Flint and Tinder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 135;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Blue Pearl)
*
***************************************************************/

namespace Server.Items
{
	public class BluePearl : Item
	{
		public BluePearl() : base()
		{
			Id = 4611;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 13103;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Blue Pearl";
			Name2 = "Blue Pearl";
			Quality = 1;
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
*				(Frost Vial)
*
***************************************************************/

namespace Server.Items
{
	public class FrostVial : Item
	{
		public FrostVial() : base()
		{
			Id = 5024;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 6340;
			ObjectClass = 5;
			SubClass = 0;
			Level = 15;
			Name = "Frost Vial";
			Name2 = "Frost Vial";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Explosive Shell)
*
***************************************************************/

namespace Server.Items
{
	public class ExplosiveShell : Item
	{
		public ExplosiveShell() : base()
		{
			Id = 5105;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 7300;
			ObjectClass = 5;
			SubClass = 0;
			Level = 20;
			Name = "Explosive Shell";
			Name2 = "Explosive Shell";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Long Tail Feather)
*
***************************************************************/

namespace Server.Items
{
	public class LongTailFeather : Item
	{
		public LongTailFeather() : base()
		{
			Id = 5116;
			SellPrice = 303;
			AvailableClasses = 0x7FFF;
			Model = 19571;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Long Tail Feather";
			Name2 = "Long Tail Feather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1215;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Flash Powder)
*
***************************************************************/

namespace Server.Items
{
	public class FlashPowder : Item
	{
		public FlashPowder() : base()
		{
			Id = 5140;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6379;
			ObjectClass = 5;
			SubClass = 0;
			Level = 20;
			Name = "Flash Powder";
			Name2 = "Flash Powder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Earth Totem)
*
***************************************************************/

namespace Server.Items
{
	public class EarthTotem : Item
	{
		public EarthTotem() : base()
		{
			Id = 5175;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7299;
			ObjectClass = 5;
			SubClass = 0;
			Level = 4;
			Name = "Earth Totem";
			Name2 = "Earth Totem";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32;
		}
	}
}


/**************************************************************
*
*				(Fire Totem)
*
***************************************************************/

namespace Server.Items
{
	public class FireTotem : Item
	{
		public FireTotem() : base()
		{
			Id = 5176;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7299;
			ObjectClass = 5;
			SubClass = 0;
			Level = 10;
			Name = "Fire Totem";
			Name2 = "Fire Totem";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32;
		}
	}
}


/**************************************************************
*
*				(Water Totem)
*
***************************************************************/

namespace Server.Items
{
	public class WaterTotem : Item
	{
		public WaterTotem() : base()
		{
			Id = 5177;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7299;
			ObjectClass = 5;
			SubClass = 0;
			Level = 20;
			Name = "Water Totem";
			Name2 = "Water Totem";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32;
		}
	}
}


/**************************************************************
*
*				(Air Totem)
*
***************************************************************/

namespace Server.Items
{
	public class AirTotem : Item
	{
		public AirTotem() : base()
		{
			Id = 5178;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7299;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Air Totem";
			Name2 = "Air Totem";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 32;
		}
	}
}


/**************************************************************
*
*				(Tiny Bronze Key)
*
***************************************************************/

namespace Server.Items
{
	public class TinyBronzeKey : Item
	{
		public TinyBronzeKey() : base()
		{
			Id = 5517;
			SellPrice = 50;
			AvailableClasses = 0x80;
			Description = "A reagent for mage spells.";
			Model = 16454;
			ObjectClass = 5;
			SubClass = 0;
			Level = 18;
			Name = "Tiny Bronze Key";
			Name2 = "Tiny Bronze Key";
			Quality = 1;
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
*				(Tiny Iron Key)
*
***************************************************************/

namespace Server.Items
{
	public class TinyIronKey : Item
	{
		public TinyIronKey() : base()
		{
			Id = 5518;
			SellPrice = 150;
			AvailableClasses = 0x80;
			Description = "A reagent for mage spells.";
			Model = 8902;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Tiny Iron Key";
			Name2 = "Tiny Iron Key";
			Quality = 1;
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
*				(Tomb Dust)
*
***************************************************************/

namespace Server.Items
{
	public class TombDust : Item
	{
		public TombDust() : base()
		{
			Id = 5529;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 6371;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Tomb Dust";
			Name2 = "Tomb Dust";
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Blinding Powder)
*
***************************************************************/

namespace Server.Items
{
	public class BlindingPowder : Item
	{
		public BlindingPowder() : base()
		{
			Id = 5530;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 8052;
			ObjectClass = 5;
			SubClass = 0;
			Level = 34;
			ReqLevel = 34;
			Name = "Blinding Powder";
			Name2 = "Blinding Powder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(The Lay of Ameth'Aran)
*
***************************************************************/

namespace Server.Items
{
	public class TheLayOfAmethAran : Item
	{
		public TheLayOfAmethAran() : base()
		{
			Id = 5562;
			AvailableClasses = 0x7FFF;
			Model = 5562;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "The Lay of Ameth'Aran";
			Name2 = "The Lay of Ameth'Aran";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			PageText = 953;
		}
	}
}


/**************************************************************
*
*				(The Fall of Ameth'Aran)
*
***************************************************************/

namespace Server.Items
{
	public class TheFallOfAmethAran : Item
	{
		public TheFallOfAmethAran() : base()
		{
			Id = 5563;
			AvailableClasses = 0x7FFF;
			Model = 5563;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "The Fall of Ameth'Aran";
			Name2 = "The Fall of Ameth'Aran";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			PageText = 954;
		}
	}
}


/**************************************************************
*
*				(Infernal Stone)
*
***************************************************************/

namespace Server.Items
{
	public class InfernalStone : Item
	{
		public InfernalStone() : base()
		{
			Id = 5565;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 6504;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Infernal Stone";
			Name2 = "Infernal Stone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Delicate Feather)
*
***************************************************************/

namespace Server.Items
{
	public class DelicateFeather : Item
	{
		public DelicateFeather() : base()
		{
			Id = 5636;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 19568;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Delicate Feather";
			Name2 = "Delicate Feather";
			Quality = 1;
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
*				(Soul Shard)
*
***************************************************************/

namespace Server.Items
{
	public class SoulShard : Item
	{
		public SoulShard() : base()
		{
			Id = 6265;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6689;
			ObjectClass = 5;
			SubClass = 0;
			Level = 10;
			Name = "Soul Shard";
			Name2 = "Soul Shard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Oily Blackmouth)
*
***************************************************************/

namespace Server.Items
{
	public class OilyBlackmouth : Item
	{
		public OilyBlackmouth() : base()
		{
			Id = 6358;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 9150;
			ObjectClass = 5;
			SubClass = 0;
			Level = 15;
			Name = "Oily Blackmouth";
			Name2 = "Oily Blackmouth";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Firefin Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class FirefinSnapper : Item
	{
		public FirefinSnapper() : base()
		{
			Id = 6359;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 11451;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Firefin Snapper";
			Name2 = "Firefin Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Blackmouth Oil)
*
***************************************************************/

namespace Server.Items
{
	public class BlackmouthOil : Item
	{
		public BlackmouthOil() : base()
		{
			Id = 6370;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 18114;
			ObjectClass = 5;
			SubClass = 0;
			Level = 15;
			Name = "Blackmouth Oil";
			Name2 = "Blackmouth Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Fire Oil)
*
***************************************************************/

namespace Server.Items
{
	public class FireOil : Item
	{
		public FireOil() : base()
		{
			Id = 6371;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 15771;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Fire Oil";
			Name2 = "Fire Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Silk Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class SilkBandage : Item
	{
		public SilkBandage() : base()
		{
			Id = 6450;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 8603;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Silk Bandage";
			Name2 = "Silk Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 129;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 7926 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Heavy Silk Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class HeavySilkBandage : Item
	{
		public HeavySilkBandage() : base()
		{
			Id = 6451;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 11926;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Heavy Silk Bandage";
			Name2 = "Heavy Silk Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 129;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 7927 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Anti-Venom)
*
***************************************************************/

namespace Server.Items
{
	public class AntiVenom : Item
	{
		public AntiVenom() : base()
		{
			Id = 6452;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 5;
			SubClass = 0;
			Level = 16;
			Name = "Anti-Venom";
			Name2 = "Anti-Venom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 115;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 7932 , 0 , -1 , 60000 , 150 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Strong Anti-Venom)
*
***************************************************************/

namespace Server.Items
{
	public class StrongAntiVenom : Item
	{
		public StrongAntiVenom() : base()
		{
			Id = 6453;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 2885;
			ObjectClass = 5;
			SubClass = 0;
			Level = 26;
			Name = "Strong Anti-Venom";
			Name2 = "Strong Anti-Venom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 7933 , 0 , -1 , 60000 , 150 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Deviate Scale)
*
***************************************************************/

namespace Server.Items
{
	public class DeviateScale : Item
	{
		public DeviateScale() : base()
		{
			Id = 6470;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 8913;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Deviate Scale";
			Name2 = "Deviate Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Perfect Deviate Scale)
*
***************************************************************/

namespace Server.Items
{
	public class PerfectDeviateScale : Item
	{
		public PerfectDeviateScale() : base()
		{
			Id = 6471;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 3668;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Perfect Deviate Scale";
			Name2 = "Perfect Deviate Scale";
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
*				(Deviate Fish)
*
***************************************************************/

namespace Server.Items
{
	public class DeviateFish : Item
	{
		public DeviateFish() : base()
		{
			Id = 6522;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 11451;
			ObjectClass = 5;
			SubClass = 0;
			Level = 15;
			Name = "Deviate Fish";
			Name2 = "Deviate Fish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 8063 , 0 , -1 , 10000 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Elemental Earth)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalEarth : Item
	{
		public ElementalEarth() : base()
		{
			Id = 7067;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 13686;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Elemental Earth";
			Name2 = "Elemental Earth";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Elemental Fire)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalFire : Item
	{
		public ElementalFire() : base()
		{
			Id = 7068;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 20874;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Elemental Fire";
			Name2 = "Elemental Fire";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Elemental Air)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalAir : Item
	{
		public ElementalAir() : base()
		{
			Id = 7069;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 23755;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Elemental Air";
			Name2 = "Elemental Air";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Elemental Water)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalWater : Item
	{
		public ElementalWater() : base()
		{
			Id = 7070;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 4136;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Elemental Water";
			Name2 = "Elemental Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Iron Buckle)
*
***************************************************************/

namespace Server.Items
{
	public class IronBuckle : Item
	{
		public IronBuckle() : base()
		{
			Id = 7071;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 13692;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Iron Buckle";
			Name2 = "Iron Buckle";
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
*				(Naga Scale)
*
***************************************************************/

namespace Server.Items
{
	public class NagaScale : Item
	{
		public NagaScale() : base()
		{
			Id = 7072;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 3668;
			ObjectClass = 5;
			SubClass = 0;
			Level = 25;
			Name = "Naga Scale";
			Name2 = "Naga Scale";
			Quality = 1;
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
*				(Core of Earth)
*
***************************************************************/

namespace Server.Items
{
	public class CoreOfEarth : Item
	{
		public CoreOfEarth() : base()
		{
			Id = 7075;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 8560;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Core of Earth";
			Name2 = "Core of Earth";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Essence of Earth)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfEarth : Item
	{
		public EssenceOfEarth() : base()
		{
			Id = 7076;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 23754;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Essence of Earth";
			Name2 = "Essence of Earth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Heart of Fire)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfFire : Item
	{
		public HeartOfFire() : base()
		{
			Id = 7077;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 21583;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Heart of Fire";
			Name2 = "Heart of Fire";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Essence of Fire)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfFire : Item
	{
		public EssenceOfFire() : base()
		{
			Id = 7078;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 23287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Essence of Fire";
			Name2 = "Essence of Fire";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Globe of Water)
*
***************************************************************/

namespace Server.Items
{
	public class GlobeOfWater : Item
	{
		public GlobeOfWater() : base()
		{
			Id = 7079;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 8025;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Globe of Water";
			Name2 = "Globe of Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Essence of Water)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfWater : Item
	{
		public EssenceOfWater() : base()
		{
			Id = 7080;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 13689;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Essence of Water";
			Name2 = "Essence of Water";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Breath of Wind)
*
***************************************************************/

namespace Server.Items
{
	public class BreathOfWind : Item
	{
		public BreathOfWind() : base()
		{
			Id = 7081;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 13687;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Breath of Wind";
			Name2 = "Breath of Wind";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Essence of Air)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfAir : Item
	{
		public EssenceOfAir() : base()
		{
			Id = 7082;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 23284;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Essence of Air";
			Name2 = "Essence of Air";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ichor of Undeath)
*
***************************************************************/

namespace Server.Items
{
	public class IchorOfUndeath : Item
	{
		public IchorOfUndeath() : base()
		{
			Id = 7972;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 16210;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Ichor of Undeath";
			Name2 = "Ichor of Undeath";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tiny Copper Key)
*
***************************************************************/

namespace Server.Items
{
	public class TinyCopperKey : Item
	{
		public TinyCopperKey() : base()
		{
			Id = 8147;
			SellPrice = 100;
			AvailableClasses = 0x80;
			Description = "A reagent for mage spells.";
			Model = 16453;
			ObjectClass = 5;
			SubClass = 0;
			Level = 42;
			Name = "Tiny Copper Key";
			Name2 = "Tiny Copper Key";
			Quality = 1;
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
*				(Jet Black Feather)
*
***************************************************************/

namespace Server.Items
{
	public class JetBlackFeather : Item
	{
		public JetBlackFeather() : base()
		{
			Id = 8168;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 19531;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Jet Black Feather";
			Name2 = "Jet Black Feather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mageweave Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class MageweaveBandage : Item
	{
		public MageweaveBandage() : base()
		{
			Id = 8544;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 17457;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Mageweave Bandage";
			Name2 = "Mageweave Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 150;
			Skill = 129;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 10838 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Heavy Mageweave Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMageweaveBandage : Item
	{
		public HeavyMageweaveBandage() : base()
		{
			Id = 8545;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 17458;
			ObjectClass = 5;
			SubClass = 0;
			Level = 1;
			Name = "Heavy Mageweave Bandage";
			Name2 = "Heavy Mageweave Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 129;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 10839 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Inlaid Mithril Cylinder)
*
***************************************************************/

namespace Server.Items
{
	public class InlaidMithrilCylinder : Item
	{
		public InlaidMithrilCylinder() : base()
		{
			Id = 9060;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Description = "Used by Gnomish Engineers to reinforce their creations";
			Model = 7397;
			ObjectClass = 5;
			SubClass = 0;
			Level = 42;
			Name = "Inlaid Mithril Cylinder";
			Name2 = "Inlaid Mithril Cylinder";
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
*				(Goblin Rocket Fuel)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinRocketFuel : Item
	{
		public GoblinRocketFuel() : base()
		{
			Id = 9061;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Description = "Used by Goblin Engineers to power their creations";
			Model = 7921;
			ObjectClass = 5;
			SubClass = 0;
			Level = 42;
			Name = "Goblin Rocket Fuel";
			Name2 = "Goblin Rocket Fuel";
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
*				(Heart of the Wild)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfTheWild : Item
	{
		public HeartOfTheWild() : base()
		{
			Id = 10286;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 18953;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Heart of the Wild";
			Name2 = "Heart of the Wild";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Star Wood)
*
***************************************************************/

namespace Server.Items
{
	public class StarWood : Item
	{
		public StarWood() : base()
		{
			Id = 11291;
			SellPrice = 1125;
			AvailableClasses = 0x7FFF;
			Model = 7290;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Star Wood";
			Name2 = "Star Wood";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Living Essence)
*
***************************************************************/

namespace Server.Items
{
	public class LivingEssence : Item
	{
		public LivingEssence() : base()
		{
			Id = 12803;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 23285;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Living Essence";
			Name2 = "Living Essence";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Essence of Undeath)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfUndeath : Item
	{
		public EssenceOfUndeath() : base()
		{
			Id = 12808;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 23291;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Essence of Undeath";
			Name2 = "Essence of Undeath";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Stonescale Eel)
*
***************************************************************/

namespace Server.Items
{
	public class StonescaleEel : Item
	{
		public StonescaleEel() : base()
		{
			Id = 13422;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24131;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Stonescale Eel";
			Name2 = "Stonescale Eel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Stonescale Oil)
*
***************************************************************/

namespace Server.Items
{
	public class StonescaleOil : Item
	{
		public StonescaleOil() : base()
		{
			Id = 13423;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 24132;
			ObjectClass = 5;
			SubClass = 0;
			Level = 50;
			Name = "Stonescale Oil";
			Name2 = "Stonescale Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lightning Eel)
*
***************************************************************/

namespace Server.Items
{
	public class LightningEel : Item
	{
		public LightningEel() : base()
		{
			Id = 13757;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24522;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			Name = "Lightning Eel";
			Name2 = "Lightning Eel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Plated Armorfish)
*
***************************************************************/

namespace Server.Items
{
	public class PlatedArmorfish : Item
	{
		public PlatedArmorfish() : base()
		{
			Id = 13890;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 4823;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Plated Armorfish";
			Name2 = "Plated Armorfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Runecloth Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothBandage : Item
	{
		public RuneclothBandage() : base()
		{
			Id = 14529;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 25146;
			ObjectClass = 5;
			SubClass = 0;
			Level = 52;
			Name = "Runecloth Bandage";
			Name2 = "Runecloth Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 129;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 18608 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Heavy Runecloth Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyRuneclothBandage : Item
	{
		public HeavyRuneclothBandage() : base()
		{
			Id = 14530;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 25147;
			ObjectClass = 5;
			SubClass = 0;
			Level = 58;
			Name = "Heavy Runecloth Bandage";
			Name2 = "Heavy Runecloth Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 129;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 18610 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Ironfeather)
*
***************************************************************/

namespace Server.Items
{
	public class Ironfeather : Item
	{
		public Ironfeather() : base()
		{
			Id = 15420;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 19572;
			ObjectClass = 5;
			SubClass = 0;
			Level = 50;
			Name = "Ironfeather";
			Name2 = "Ironfeather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 50;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Demonic Figurine)
*
***************************************************************/

namespace Server.Items
{
	public class DemonicFigurine : Item
	{
		public DemonicFigurine() : base()
		{
			Id = 16583;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 27454;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Demonic Figurine";
			Name2 = "Demonic Figurine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Fiery Core)
*
***************************************************************/

namespace Server.Items
{
	public class FieryCore : Item
	{
		public FieryCore() : base()
		{
			Id = 17010;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 28840;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Fiery Core";
			Name2 = "Fiery Core";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lava Core)
*
***************************************************************/

namespace Server.Items
{
	public class LavaCore : Item
	{
		public LavaCore() : base()
		{
			Id = 17011;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 28841;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Lava Core";
			Name2 = "Lava Core";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Arcane Dust)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneDust : Item
	{
		public ArcaneDust() : base()
		{
			Id = 17019;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 13123;
			ObjectClass = 5;
			SubClass = 0;
			Level = 42;
			Name = "Arcane Dust";
			Name2 = "Arcane Dust";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Arcane Powder)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanePowder : Item
	{
		public ArcanePowder() : base()
		{
			Id = 17020;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 28854;
			ObjectClass = 5;
			SubClass = 0;
			Level = 56;
			Name = "Arcane Powder";
			Name2 = "Arcane Powder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Wild Berries)
*
***************************************************************/

namespace Server.Items
{
	public class WildBerries : Item
	{
		public WildBerries() : base()
		{
			Id = 17021;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 28855;
			ObjectClass = 5;
			SubClass = 0;
			Level = 50;
			Name = "Wild Berries";
			Name2 = "Wild Berries";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Wild Root)
*
***************************************************************/

namespace Server.Items
{
	public class WildRoot : Item
	{
		public WildRoot() : base()
		{
			Id = 17024;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 28857;
			ObjectClass = 5;
			SubClass = 0;
			Level = 50;
			Name = "Wild Root";
			Name2 = "Wild Root";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Wild Thornroot)
*
***************************************************************/

namespace Server.Items
{
	public class WildThornroot : Item
	{
		public WildThornroot() : base()
		{
			Id = 17026;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 28858;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Wild Thornroot";
			Name2 = "Wild Thornroot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Scented Candle)
*
***************************************************************/

namespace Server.Items
{
	public class ScentedCandle : Item
	{
		public ScentedCandle() : base()
		{
			Id = 17027;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 28859;
			ObjectClass = 5;
			SubClass = 0;
			Level = 36;
			Name = "Scented Candle";
			Name2 = "Scented Candle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Holy Candle)
*
***************************************************************/

namespace Server.Items
{
	public class HolyCandle : Item
	{
		public HolyCandle() : base()
		{
			Id = 17028;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 28860;
			ObjectClass = 5;
			SubClass = 0;
			Level = 48;
			Name = "Holy Candle";
			Name2 = "Holy Candle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Sacred Candle)
*
***************************************************************/

namespace Server.Items
{
	public class SacredCandle : Item
	{
		public SacredCandle() : base()
		{
			Id = 17029;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 28861;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Sacred Candle";
			Name2 = "Sacred Candle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Ankh)
*
***************************************************************/

namespace Server.Items
{
	public class Ankh : Item
	{
		public Ankh() : base()
		{
			Id = 17030;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 18725;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Ankh";
			Name2 = "Ankh";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Rune of Teleportation)
*
***************************************************************/

namespace Server.Items
{
	public class RuneOfTeleportation : Item
	{
		public RuneOfTeleportation() : base()
		{
			Id = 17031;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 20984;
			ObjectClass = 5;
			SubClass = 0;
			Level = 20;
			Name = "Rune of Teleportation";
			Name2 = "Rune of Teleportation";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Rune of Portals)
*
***************************************************************/

namespace Server.Items
{
	public class RuneOfPortals : Item
	{
		public RuneOfPortals() : base()
		{
			Id = 17032;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 28862;
			ObjectClass = 5;
			SubClass = 0;
			Level = 40;
			Name = "Rune of Portals";
			Name2 = "Rune of Portals";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Symbol of Divinity)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolOfDivinity : Item
	{
		public SymbolOfDivinity() : base()
		{
			Id = 17033;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 28863;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Symbol of Divinity";
			Name2 = "Symbol of Divinity";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Maple Seed)
*
***************************************************************/

namespace Server.Items
{
	public class MapleSeed : Item
	{
		public MapleSeed() : base()
		{
			Id = 17034;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 7287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 20;
			Name = "Maple Seed";
			Name2 = "Maple Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Stranglethorn Seed)
*
***************************************************************/

namespace Server.Items
{
	public class StranglethornSeed : Item
	{
		public StranglethornSeed() : base()
		{
			Id = 17035;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 7287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 30;
			Name = "Stranglethorn Seed";
			Name2 = "Stranglethorn Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Ashwood Seed)
*
***************************************************************/

namespace Server.Items
{
	public class AshwoodSeed : Item
	{
		public AshwoodSeed() : base()
		{
			Id = 17036;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 7287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 40;
			Name = "Ashwood Seed";
			Name2 = "Ashwood Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Hornbeam Seed)
*
***************************************************************/

namespace Server.Items
{
	public class HornbeamSeed : Item
	{
		public HornbeamSeed() : base()
		{
			Id = 17037;
			SellPrice = 350;
			AvailableClasses = 0x7FFF;
			Model = 7287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 50;
			Name = "Hornbeam Seed";
			Name2 = "Hornbeam Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Ironwood Seed)
*
***************************************************************/

namespace Server.Items
{
	public class IronwoodSeed : Item
	{
		public IronwoodSeed() : base()
		{
			Id = 17038;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 7287;
			ObjectClass = 5;
			SubClass = 0;
			Level = 60;
			Name = "Ironwood Seed";
			Name2 = "Ironwood Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 2;
		}
	}
}


/**************************************************************
*
*				(Larval Acid)
*
***************************************************************/

namespace Server.Items
{
	public class LarvalAcid : Item
	{
		public LarvalAcid() : base()
		{
			Id = 18512;
			SellPrice = 4000;
			AvailableClasses = 0x7FFF;
			Model = 30852;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			Name = "Larval Acid";
			Name2 = "Larval Acid";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 16000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Runecloth Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchRuneclothBandage : Item
	{
		public WarsongGulchRuneclothBandage() : base()
		{
			Id = 19066;
			Bonding = 1;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 25147;
			ObjectClass = 5;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Warsong Gulch Runecloth Bandage";
			Name2 = "Warsong Gulch Runecloth Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 129;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 23567 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Mageweave Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchMageweaveBandage : Item
	{
		public WarsongGulchMageweaveBandage() : base()
		{
			Id = 19067;
			Bonding = 1;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 17458;
			ObjectClass = 5;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Warsong Gulch Mageweave Bandage";
			Name2 = "Warsong Gulch Mageweave Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 129;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 23568 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Silk Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchSilkBandage : Item
	{
		public WarsongGulchSilkBandage() : base()
		{
			Id = 19068;
			Bonding = 1;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 11926;
			ObjectClass = 5;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Warsong Gulch Silk Bandage";
			Name2 = "Warsong Gulch Silk Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 129;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 64;
			SetSpell( 23569 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Alterac Heavy Runecloth Bandage)
*
***************************************************************/

namespace Server.Items
{
	public class AlteracHeavyRuneclothBandage : Item
	{
		public AlteracHeavyRuneclothBandage() : base()
		{
			Id = 19307;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Description = "May only be used in Alterac Valley.";
			Model = 25147;
			ObjectClass = 5;
			SubClass = 0;
			Level = 58;
			Name = "Alterac Heavy Runecloth Bandage";
			Name2 = "Alterac Heavy Runecloth Bandage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 129;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 100;
			Material = 7;
			Flags = 64;
			SetSpell( 23696 , 0 , -1 , 0 , 150 , 0 );
		}
	}
}


/**************************************************************
*
*				(Powerful Anti-Venom)
*
***************************************************************/

namespace Server.Items
{
	public class PowerfulAntiVenom : Item
	{
		public PowerfulAntiVenom() : base()
		{
			Id = 19440;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 21845;
			ObjectClass = 5;
			SubClass = 0;
			Level = 58;
			Name = "Powerful Anti-Venom";
			Name2 = "Powerful Anti-Venom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 129;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 7;
			Flags = 64;
			SetSpell( 23786 , 0 , -1 , 60000 , 150 , 60000 );
		}
	}
}


