/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:06:37 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Small Ammo Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class SmallAmmoPouch : Item
	{
		public SmallAmmoPouch() : base()
		{
			Id = 2102;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 1;
			ReqLevel = 1;
			Name = "Small Ammo Pouch";
			Name2 = "Small Ammo Pouch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 6;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ribbly's Bandolier)
*
***************************************************************/

namespace Server.Items
{
	public class RibblysBandolier : Item
	{
		public RibblysBandolier() : base()
		{
			Id = 2663;
			Bonding = 1;
			SellPrice = 8750;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Ribbly's Bandolier";
			Name2 = "Ribbly's Bandolier";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			SetSpell( 14828 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Hunting Ammo Sack)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingAmmoSack : Item
	{
		public HuntingAmmoSack() : base()
		{
			Id = 3574;
			Bonding = 1;
			SellPrice = 212;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 15;
			Name = "Hunting Ammo Sack";
			Name2 = "Hunting Ammo Sack";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 850;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 10;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bandolier of the Night Watch)
*
***************************************************************/

namespace Server.Items
{
	public class BandolierOfTheNightWatch : Item
	{
		public BandolierOfTheNightWatch() : base()
		{
			Id = 3604;
			Bonding = 1;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 2584;
			ObjectClass = 11;
			SubClass = 3;
			Level = 25;
			Name = "Bandolier of the Night Watch";
			Name2 = "Bandolier of the Night Watch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 12;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			SetSpell( 14825 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Small Shot Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class SmallShotPouch : Item
	{
		public SmallShotPouch() : base()
		{
			Id = 5441;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Small Shot Pouch";
			Name2 = "Small Shot Pouch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 8;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Small Leather Ammo Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class SmallLeatherAmmoPouch : Item
	{
		public SmallLeatherAmmoPouch() : base()
		{
			Id = 7279;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Small Leather Ammo Pouch";
			Name2 = "Small Leather Ammo Pouch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 8;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Heavy Leather Ammo Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLeatherAmmoPouch : Item
	{
		public HeavyLeatherAmmoPouch() : base()
		{
			Id = 7372;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 2585;
			ObjectClass = 11;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Heavy Leather Ammo Pouch";
			Name2 = "Heavy Leather Ammo Pouch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 14;
			Stackable = 1;
			Material = 8;
			SetSpell( 14826 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Thick Leather Ammo Pouch)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherAmmoPouch : Item
	{
		public ThickLeatherAmmoPouch() : base()
		{
			Id = 8218;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 1281;
			ObjectClass = 11;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Thick Leather Ammo Pouch";
			Name2 = "Thick Leather Ammo Pouch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			Material = 8;
			SetSpell( 14827 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Gnoll Skin Bandolier)
*
***************************************************************/

namespace Server.Items
{
	public class GnollSkinBandolier : Item
	{
		public GnollSkinBandolier() : base()
		{
			Id = 19320;
			Bonding = 1;
			SellPrice = 87500;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 11;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Gnoll Skin Bandolier";
			Name2 = "Gnoll Skin Bandolier";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 350000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Flags = 32768;
			SetSpell( 14829 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


