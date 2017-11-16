/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:01 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Light Shot)
*
***************************************************************/

namespace Server.Items
{
	public class LightShot : Item
	{
		public LightShot() : base()
		{
			Id = 2516;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Light Shot";
			Name2 = "Light Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Shot)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyShot : Item
	{
		public HeavyShot() : base()
		{
			Id = 2519;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Heavy Shot";
			Name2 = "Heavy Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 3 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Solid Shot)
*
***************************************************************/

namespace Server.Items
{
	public class SolidShot : Item
	{
		public SolidShot() : base()
		{
			Id = 3033;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Solid Shot";
			Name2 = "Solid Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 7 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Exploding Shot)
*
***************************************************************/

namespace Server.Items
{
	public class ExplodingShot : Item
	{
		public ExplodingShot() : base()
		{
			Id = 3465;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 36;
			Name = "Exploding Shot";
			Name2 = "Exploding Shot";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 9 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flash Pellet)
*
***************************************************************/

namespace Server.Items
{
	public class FlashPellet : Item
	{
		public FlashPellet() : base()
		{
			Id = 4960;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 7;
			Name = "Flash Pellet";
			Name2 = "Flash Pellet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 2 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Smooth Pebble)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothPebble : Item
	{
		public SmoothPebble() : base()
		{
			Id = 5568;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Smooth Pebble";
			Name2 = "Smooth Pebble";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 4 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crafted Light Shot)
*
***************************************************************/

namespace Server.Items
{
	public class CraftedLightShot : Item
	{
		public CraftedLightShot() : base()
		{
			Id = 8067;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Crafted Light Shot";
			Name2 = "Crafted Light Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 2 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crafted Heavy Shot)
*
***************************************************************/

namespace Server.Items
{
	public class CraftedHeavyShot : Item
	{
		public CraftedHeavyShot() : base()
		{
			Id = 8068;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Crafted Heavy Shot";
			Name2 = "Crafted Heavy Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 4 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crafted Solid Shot)
*
***************************************************************/

namespace Server.Items
{
	public class CraftedSolidShot : Item
	{
		public CraftedSolidShot() : base()
		{
			Id = 8069;
			AvailableClasses = 0x7FFF;
			Model = 5998;
			ObjectClass = 6;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Crafted Solid Shot";
			Name2 = "Crafted Solid Shot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 8 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hi-Impact Mithril Slugs)
*
***************************************************************/

namespace Server.Items
{
	public class HiImpactMithrilSlugs : Item
	{
		public HiImpactMithrilSlugs() : base()
		{
			Id = 10512;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 19422;
			ObjectClass = 6;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Hi-Impact Mithril Slugs";
			Name2 = "Hi-Impact Mithril Slugs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 12 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mithril Gyro-Shot)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilGyroShot : Item
	{
		public MithrilGyroShot() : base()
		{
			Id = 10513;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 19422;
			ObjectClass = 6;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Mithril Gyro-Shot";
			Name2 = "Mithril Gyro-Shot";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 15 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Accurate Slugs)
*
***************************************************************/

namespace Server.Items
{
	public class AccurateSlugs : Item
	{
		public AccurateSlugs() : base()
		{
			Id = 11284;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 19422;
			ObjectClass = 6;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Accurate Slugs";
			Name2 = "Accurate Slugs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 13 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rockshard Pellets)
*
***************************************************************/

namespace Server.Items
{
	public class RockshardPellets : Item
	{
		public RockshardPellets() : base()
		{
			Id = 11630;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 2418;
			ObjectClass = 6;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Rockshard Pellets";
			Name2 = "Rockshard Pellets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 18 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Miniature Cannon Balls)
*
***************************************************************/

namespace Server.Items
{
	public class MiniatureCannonBalls : Item
	{
		public MiniatureCannonBalls() : base()
		{
			Id = 13377;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 2418;
			ObjectClass = 6;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Miniature Cannon Balls";
			Name2 = "Miniature Cannon Balls";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 20 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thorium Shells)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumShells : Item
	{
		public ThoriumShells() : base()
		{
			Id = 15997;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 26613;
			ObjectClass = 6;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Thorium Shells";
			Name2 = "Thorium Shells";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 17 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ice Threaded Bullet)
*
***************************************************************/

namespace Server.Items
{
	public class IceThreadedBullet : Item
	{
		public IceThreadedBullet() : base()
		{
			Id = 19317;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 31813;
			ObjectClass = 6;
			SubClass = 3;
			Level = 54;
			ReqLevel = 51;
			Name = "Ice Threaded Bullet";
			Name2 = "Ice Threaded Bullet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 16 , 17 , Resistances.Armor );
		}
	}
}


