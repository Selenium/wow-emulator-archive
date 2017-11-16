/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:42 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Reins of the Bengal Tiger)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheBengalTiger : Item
	{
		public ReinsOfTheBengalTiger() : base()
		{
			Id = 8630;
			Bonding = 3;
			SellPrice = 250000;
			AvailableClasses = 0x7FFF;
			Model = 17607;
			ObjectClass = 14;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Bengal Tiger";
			Name2 = "Reins of the Bengal Tiger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 10790 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Reins of the Leopard)
*
***************************************************************/

namespace Server.Items
{
	public class ReinsOfTheLeopard : Item
	{
		public ReinsOfTheLeopard() : base()
		{
			Id = 8633;
			Bonding = 3;
			SellPrice = 250000;
			AvailableClasses = 0x7FFF;
			Model = 17607;
			ObjectClass = 14;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Reins of the Leopard";
			Name2 = "Reins of the Leopard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 150;
			BuyPrice = 1000000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 10788 , 0 , 0 , 0 , 330 , 3000 );
		}
	}
}


