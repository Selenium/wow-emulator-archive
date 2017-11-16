/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:17:46 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Expert Fishing - The Bass and You)
*
***************************************************************/

namespace Server.Items
{
	public class ExpertFishingTheBassAndYou : Item
	{
		public ExpertFishingTheBassAndYou() : base()
		{
			Id = 16083;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 1155;
			ObjectClass = 9;
			SubClass = 9;
			Level = 30;
			ReqLevel = 20;
			Name = "Expert Fishing - The Bass and You";
			Name2 = "Expert Fishing - The Bass and You";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 356;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 19889 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


