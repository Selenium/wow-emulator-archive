/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:18:25 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Earthfury Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryVestments : Item
	{
		public EarthfuryVestments() : base()
		{
			Id = 16841;
			Resistance[0] = 422;
			Bonding = 1;
			SellPrice = 51956;
			AvailableClasses = 0x40;
			Model = 31832;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Vestments";
			Name2 = "Earthfury Vestments";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 259783;
			Sets = 207;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 5;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 13;
			StaminaBonus = 17;
		}
	}
}


