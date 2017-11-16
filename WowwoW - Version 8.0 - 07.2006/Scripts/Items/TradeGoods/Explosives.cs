/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:08:22 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Rough Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class RoughDynamite : Item
	{
		public RoughDynamite() : base()
		{
			Id = 4358;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 10;
			Name = "Rough Dynamite";
			Name2 = "Rough Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 202;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 4054 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Rough Copper Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class RoughCopperBomb : Item
	{
		public RoughCopperBomb() : base()
		{
			Id = 4360;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 25483;
			ObjectClass = 7;
			SubClass = 2;
			Level = 14;
			Name = "Rough Copper Bomb";
			Name2 = "Rough Copper Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 30;
			Skill = 202;
			BuyPrice = 240;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4064 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Coarse Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class CoarseDynamite : Item
	{
		public CoarseDynamite() : base()
		{
			Id = 4365;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 20;
			Name = "Coarse Dynamite";
			Name2 = "Coarse Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 75;
			Skill = 202;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 4061 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Small Seaforium Charge)
*
***************************************************************/

namespace Server.Items
{
	public class SmallSeaforiumCharge : Item
	{
		public SmallSeaforiumCharge() : base()
		{
			Id = 4367;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 6393;
			ObjectClass = 7;
			SubClass = 2;
			Level = 20;
			Name = "Small Seaforium Charge";
			Name2 = "Small Seaforium Charge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 202;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 4;
			Flags = 64;
			SetSpell( 4056 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Large Copper Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class LargeCopperBomb : Item
	{
		public LargeCopperBomb() : base()
		{
			Id = 4370;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 7624;
			ObjectClass = 7;
			SubClass = 2;
			Level = 26;
			Name = "Large Copper Bomb";
			Name2 = "Large Copper Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 105;
			Skill = 202;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4065 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Small Bronze Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class SmallBronzeBomb : Item
	{
		public SmallBronzeBomb() : base()
		{
			Id = 4374;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 25483;
			ObjectClass = 7;
			SubClass = 2;
			Level = 29;
			Name = "Small Bronze Bomb";
			Name2 = "Small Bronze Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 120;
			Skill = 202;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4066 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Heavy Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyDynamite : Item
	{
		public HeavyDynamite() : base()
		{
			Id = 4378;
			SellPrice = 350;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 30;
			Name = "Heavy Dynamite";
			Name2 = "Heavy Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 202;
			BuyPrice = 1400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 4062 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Big Bronze Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class BigBronzeBomb : Item
	{
		public BigBronzeBomb() : base()
		{
			Id = 4380;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 7626;
			ObjectClass = 7;
			SubClass = 2;
			Level = 33;
			Name = "Big Bronze Bomb";
			Name2 = "Big Bronze Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 140;
			Skill = 202;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4067 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Explosive Sheep)
*
***************************************************************/

namespace Server.Items
{
	public class ExplosiveSheep : Item
	{
		public ExplosiveSheep() : base()
		{
			Id = 4384;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 7361;
			ObjectClass = 7;
			SubClass = 2;
			Level = 30;
			Name = "Explosive Sheep";
			Name2 = "Explosive Sheep";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 150;
			Skill = 202;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			SetSpell( 4074 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Iron Grenade)
*
***************************************************************/

namespace Server.Items
{
	public class IronGrenade : Item
	{
		public IronGrenade() : base()
		{
			Id = 4390;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 25482;
			ObjectClass = 7;
			SubClass = 2;
			Level = 35;
			Name = "Iron Grenade";
			Name2 = "Iron Grenade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 202;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4068 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Big Iron Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class BigIronBomb : Item
	{
		public BigIronBomb() : base()
		{
			Id = 4394;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 7624;
			ObjectClass = 7;
			SubClass = 2;
			Level = 43;
			Name = "Big Iron Bomb";
			Name2 = "Big Iron Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 190;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4069 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Land Mine)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinLandMine : Item
	{
		public GoblinLandMine() : base()
		{
			Id = 4395;
			SellPrice = 1600;
			AvailableClasses = 0x7FFF;
			Model = 7367;
			ObjectClass = 7;
			SubClass = 2;
			Level = 39;
			Name = "Goblin Land Mine";
			Name2 = "Goblin Land Mine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 195;
			Skill = 202;
			BuyPrice = 6400;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			SetSpell( 4100 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Large Seaforium Charge)
*
***************************************************************/

namespace Server.Items
{
	public class LargeSeaforiumCharge : Item
	{
		public LargeSeaforiumCharge() : base()
		{
			Id = 4398;
			SellPrice = 900;
			AvailableClasses = 0x7FFF;
			Model = 6393;
			ObjectClass = 7;
			SubClass = 2;
			Level = 40;
			Name = "Large Seaforium Charge";
			Name2 = "Large Seaforium Charge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 202;
			BuyPrice = 3600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 4;
			Flags = 64;
			SetSpell( 4075 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Flash Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class FlashBomb : Item
	{
		public FlashBomb() : base()
		{
			Id = 4852;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 6378;
			ObjectClass = 7;
			SubClass = 2;
			Level = 37;
			ReqLevel = 27;
			Name = "Flash Bomb";
			Name2 = "Flash Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Flags = 64;
			SetSpell( 5134 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Ez-Thro Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class EzThroDynamite : Item
	{
		public EzThroDynamite() : base()
		{
			Id = 6714;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 25;
			ReqLevel = 10;
			Name = "Ez-Thro Dynamite";
			Name2 = "Ez-Thro Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 8331 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Solid Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class SolidDynamite : Item
	{
		public SolidDynamite() : base()
		{
			Id = 10507;
			SellPrice = 350;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 35;
			Name = "Solid Dynamite";
			Name2 = "Solid Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 202;
			BuyPrice = 1400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 12419 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Mithril Frag Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilFragBomb : Item
	{
		public MithrilFragBomb() : base()
		{
			Id = 10514;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 7889;
			ObjectClass = 7;
			SubClass = 2;
			Level = 43;
			Name = "Mithril Frag Bomb";
			Name2 = "Mithril Frag Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 12421 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Hi-Explosive Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class HiExplosiveBomb : Item
	{
		public HiExplosiveBomb() : base()
		{
			Id = 10562;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 25484;
			ObjectClass = 7;
			SubClass = 2;
			Level = 47;
			Name = "Hi-Explosive Bomb";
			Name2 = "Hi-Explosive Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 235;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 12543 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(The Big One)
*
***************************************************************/

namespace Server.Items
{
	public class TheBigOne : Item
	{
		public TheBigOne() : base()
		{
			Id = 10586;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 7888;
			ObjectClass = 7;
			SubClass = 2;
			Level = 45;
			Name = "The Big One";
			Name2 = "The Big One";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 12562 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Sapper Charge)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinSapperCharge : Item
	{
		public GoblinSapperCharge() : base()
		{
			Id = 10646;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 20535;
			ObjectClass = 7;
			SubClass = 2;
			Level = 41;
			Name = "Goblin Sapper Charge";
			Name2 = "Goblin Sapper Charge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			SetSpell( 13241 , 0 , -1 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Thorium Grenade)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumGrenade : Item
	{
		public ThoriumGrenade() : base()
		{
			Id = 15993;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 25482;
			ObjectClass = 7;
			SubClass = 2;
			Level = 52;
			Name = "Thorium Grenade";
			Name2 = "Thorium Grenade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 260;
			Skill = 202;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 19769 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Dark Iron Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronBomb : Item
	{
		public DarkIronBomb() : base()
		{
			Id = 16005;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 7626;
			ObjectClass = 7;
			SubClass = 2;
			Level = 57;
			Name = "Dark Iron Bomb";
			Name2 = "Dark Iron Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 285;
			Skill = 202;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 19784 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Arcane Bomb)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneBomb : Item
	{
		public ArcaneBomb() : base()
		{
			Id = 16040;
			SellPrice = 4000;
			AvailableClasses = 0x7FFF;
			Model = 27453;
			ObjectClass = 7;
			SubClass = 2;
			Level = 60;
			Name = "Arcane Bomb";
			Name2 = "Arcane Bomb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 202;
			BuyPrice = 16000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 19821 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Ez-Thro Dynamite II)
*
***************************************************************/

namespace Server.Items
{
	public class EzThroDynamiteII : Item
	{
		public EzThroDynamiteII() : base()
		{
			Id = 18588;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Description = "The dynamite for Non-Engineers that rarely* blows up in your hand with over twice the blasting power of standard EZ-Thro.";
			Model = 18063;
			ObjectClass = 7;
			SubClass = 2;
			Level = 40;
			ReqLevel = 30;
			Name = "Ez-Thro Dynamite II";
			Name2 = "Ez-Thro Dynamite II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 23000 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Powerful Seaforium Charge)
*
***************************************************************/

namespace Server.Items
{
	public class PowerfulSeaforiumCharge : Item
	{
		public PowerfulSeaforiumCharge() : base()
		{
			Id = 18594;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 30999;
			ObjectClass = 7;
			SubClass = 2;
			Level = 55;
			Name = "Powerful Seaforium Charge";
			Name2 = "Powerful Seaforium Charge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 202;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 4;
			Flags = 64;
			SetSpell( 23008 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dense Dynamite)
*
***************************************************************/

namespace Server.Items
{
	public class DenseDynamite : Item
	{
		public DenseDynamite() : base()
		{
			Id = 18641;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 18062;
			ObjectClass = 7;
			SubClass = 2;
			Level = 45;
			Name = "Dense Dynamite";
			Name2 = "Dense Dynamite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 202;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			Flags = 64;
			SetSpell( 23063 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


