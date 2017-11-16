/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:31 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Big Voodoo Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BigVoodooRobe : Item
	{
		public BigVoodooRobe() : base()
		{
			Id = 8200;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 7275;
			AvailableClasses = 0x7FFF;
			Model = 16508;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Big Voodoo Robe";
			Name2 = "Big Voodoo Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36378;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 8;
			SpiritBonus = 14;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Flamestrider Robes)
*
***************************************************************/

namespace Server.Items
{
	public class FlamestriderRobes : Item
	{
		public FlamestriderRobes() : base()
		{
			Id = 11747;
			Resistance[0] = 153;
			Bonding = 1;
			SellPrice = 16659;
			AvailableClasses = 0x7FFF;
			Model = 21719;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Flamestrider Robes";
			Name2 = "Flamestrider Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83298;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 8;
			IqBonus = 25;
			StaminaBonus = 5;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cenarion Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionVestments : Item
	{
		public CenarionVestments() : base()
		{
			Id = 16833;
			Resistance[0] = 200;
			Bonding = 1;
			SellPrice = 46439;
			AvailableClasses = 0x400;
			Model = 31797;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Vestments";
			Name2 = "Cenarion Vestments";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 232195;
			Sets = 205;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 8;
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 16;
			StaminaBonus = 23;
		}
	}
}


