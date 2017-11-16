/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:09:52 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class FishingPole : Item
	{
		public FishingPole() : base()
		{
			Id = 6256;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 20730;
			ObjectClass = 2;
			SubClass = 20;
			Level = 1;
			Name = "Fishing Pole";
			Name2 = "Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 23;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 16;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Strong Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class StrongFishingPole : Item
	{
		public StrongFishingPole() : base()
		{
			Id = 6365;
			SellPrice = 180;
			AvailableClasses = 0x7FFF;
			Model = 20618;
			ObjectClass = 2;
			SubClass = 20;
			Level = 10;
			ReqLevel = 5;
			Name = "Strong Fishing Pole";
			Name2 = "Strong Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 10;
			Skill = 356;
			BuyPrice = 901;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = -1;
			Sheath = 1;
			Durability = 25;
			SetSpell( 7823 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 13 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Darkwood Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class DarkwoodFishingPole : Item
	{
		public DarkwoodFishingPole() : base()
		{
			Id = 6366;
			SellPrice = 1066;
			AvailableClasses = 0x7FFF;
			Model = 20731;
			ObjectClass = 2;
			SubClass = 20;
			Level = 20;
			ReqLevel = 15;
			Name = "Darkwood Fishing Pole";
			Name2 = "Darkwood Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 356;
			BuyPrice = 5330;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = -1;
			Sheath = 1;
			SetSpell( 7825 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 28 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Big Iron Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class BigIronFishingPole : Item
	{
		public BigIronFishingPole() : base()
		{
			Id = 6367;
			SellPrice = 3378;
			AvailableClasses = 0x7FFF;
			Model = 20619;
			ObjectClass = 2;
			SubClass = 20;
			Level = 30;
			ReqLevel = 25;
			Name = "Big Iron Fishing Pole";
			Name2 = "Big Iron Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 356;
			BuyPrice = 16892;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = -1;
			Sheath = 1;
			Durability = 55;
			SetSpell( 7826 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 45 , 69 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blump Family Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class BlumpFamilyFishingPole : Item
	{
		public BlumpFamilyFishingPole() : base()
		{
			Id = 12225;
			Bonding = 1;
			SellPrice = 187;
			AvailableClasses = 0x7FFF;
			Model = 20618;
			ObjectClass = 2;
			SubClass = 20;
			Level = 10;
			Name = "Blump Family Fishing Pole";
			Name2 = "Blump Family Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 356;
			BuyPrice = 939;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = -1;
			Sheath = 1;
			Durability = 25;
			SetSpell( 15956 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 13 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Nat Pagle's Extreme Angler FC-5000)
*
***************************************************************/

namespace Server.Items
{
	public class NatPaglesExtremeAnglerFC5000 : Item
	{
		public NatPaglesExtremeAnglerFC5000() : base()
		{
			Id = 19022;
			Bonding = 4;
			SellPrice = 27861;
			AvailableClasses = 0x7FFF;
			Description = "Limited Edition";
			Model = 20619;
			ObjectClass = 2;
			SubClass = 20;
			Level = 50;
			Name = "Nat Pagle's Extreme Angler FC-5000";
			Name2 = "Nat Pagle's Extreme Angler FC-5000";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 356;
			BuyPrice = 139307;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 1;
			Durability = 55;
			SetSpell( 8082 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 93 , 140 , Resistances.Armor );
		}
	}
}


