/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:46 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Tablet of Serpent Totem)
*
***************************************************************/

namespace Server.Items
{
	public class TabletOfSerpentTotem : Item
	{
		public TabletOfSerpentTotem() : base()
		{
			Id = 1029;
			SellPrice = 20;
			AvailableClasses = 0x7A40;
			Model = 5563;
			ObjectClass = 9;
			SubClass = 0;
			Level = 4;
			ReqLevel = 4;
			Name = "Tablet of Serpent Totem";
			Name2 = "Tablet of Serpent Totem";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 3731 , 0 , -1 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Tablet of Restoration III)
*
***************************************************************/

namespace Server.Items
{
	public class TabletOfRestorationIII : Item
	{
		public TabletOfRestorationIII() : base()
		{
			Id = 1057;
			SellPrice = 450;
			AvailableClasses = 0x7A40;
			Model = 5563;
			ObjectClass = 9;
			SubClass = 0;
			Level = 16;
			ReqLevel = 16;
			Name = "Tablet of Restoration III";
			Name2 = "Tablet of Restoration III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 565 , 0 , -1 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Libram: Resurrection)
*
***************************************************************/

namespace Server.Items
{
	public class LibramResurrection : Item
	{
		public LibramResurrection() : base()
		{
			Id = 1146;
			Bonding = 1;
			AvailableClasses = 0x7A02;
			Model = 1155;
			ObjectClass = 9;
			SubClass = 0;
			Level = 12;
			ReqLevel = 12;
			Name = "Libram: Resurrection";
			Name2 = "Libram: Resurrection";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 96;
			SetSpell( 7330 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Tongues)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfTongues : Item
	{
		public RecipeElixirOfTongues() : base()
		{
			Id = 2556;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 6270;
			ObjectClass = 9;
			SubClass = 0;
			Level = 15;
			Name = "Recipe: Elixir of Tongues";
			Name2 = "Recipe: Elixir of Tongues";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 70;
			Skill = 171;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 2365 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Burning Spirit II)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBurningSpiritII : Item
	{
		public GrimoireOfBurningSpiritII() : base()
		{
			Id = 3144;
			SellPrice = 450;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 16;
			ReqLevel = 16;
			Name = "Grimoire of Burning Spirit II";
			Name2 = "Grimoire of Burning Spirit II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3096 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tome of Conjure Food II)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfConjureFoodII : Item
	{
		public TomeOfConjureFoodII() : base()
		{
			Id = 4143;
			SellPrice = 125;
			AvailableClasses = 0x7A80;
			Model = 1103;
			ObjectClass = 9;
			SubClass = 0;
			Level = 12;
			ReqLevel = 12;
			Name = "Tome of Conjure Food II";
			Name2 = "Tome of Conjure Food II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 619 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Doom)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfDoom : Item
	{
		public GrimoireOfDoom() : base()
		{
			Id = 4213;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Grimoire of Doom";
			Name2 = "Grimoire of Doom";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 1123 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Codex of Heal)
*
***************************************************************/

namespace Server.Items
{
	public class CodexOfHeal : Item
	{
		public CodexOfHeal() : base()
		{
			Id = 4273;
			SellPrice = 450;
			AvailableClasses = 0x7A10;
			Model = 1143;
			ObjectClass = 9;
			SubClass = 0;
			Level = 16;
			ReqLevel = 16;
			Name = "Codex of Heal";
			Name2 = "Codex of Heal";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3810 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Book of Healing Touch III)
*
***************************************************************/

namespace Server.Items
{
	public class BookOfHealingTouchIII : Item
	{
		public BookOfHealingTouchIII() : base()
		{
			Id = 5150;
			SellPrice = 225;
			AvailableClasses = 0x7E00;
			Model = 1317;
			ObjectClass = 9;
			SubClass = 0;
			Level = 14;
			ReqLevel = 14;
			Name = "Book of Healing Touch III";
			Name2 = "Book of Healing Touch III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 900;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 5295 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Instant Toxin)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeInstantToxin : Item
	{
		public RecipeInstantToxin() : base()
		{
			Id = 5657;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 6270;
			ObjectClass = 9;
			SubClass = 0;
			Level = 24;
			Name = "Recipe: Instant Toxin";
			Name2 = "Recipe: Instant Toxin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 120;
			Skill = 40;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6652 , 0 , -1 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Libram: Seal of Righteousness)
*
***************************************************************/

namespace Server.Items
{
	public class LibramSealOfRighteousness : Item
	{
		public LibramSealOfRighteousness() : base()
		{
			Id = 5660;
			SellPrice = 325;
			AvailableClasses = 0x7A02;
			Model = 1155;
			ObjectClass = 9;
			SubClass = 0;
			Level = 16;
			ReqLevel = 16;
			Name = "Libram: Seal of Righteousness";
			Name2 = "Libram: Seal of Righteousness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1300;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 864 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Formula: Imbue Chest - Spirit)
*
***************************************************************/

namespace Server.Items
{
	public class FormulaImbueChestSpirit : Item
	{
		public FormulaImbueChestSpirit() : base()
		{
			Id = 6343;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 11431;
			ObjectClass = 9;
			SubClass = 0;
			Level = 14;
			Name = "Formula: Imbue Chest - Spirit";
			Name2 = "Formula: Imbue Chest - Spirit";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 60;
			Skill = 333;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 7462 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Formula: Imbue Cloak - Protection)
*
***************************************************************/

namespace Server.Items
{
	public class FormulaImbueCloakProtection : Item
	{
		public FormulaImbueCloakProtection() : base()
		{
			Id = 6345;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 11431;
			ObjectClass = 9;
			SubClass = 0;
			Level = 18;
			Name = "Formula: Imbue Cloak - Protection";
			Name2 = "Formula: Imbue Cloak - Protection";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 90;
			Skill = 333;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 7772 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Formula: Enchant Boots - Minor Stamina)
*
***************************************************************/

namespace Server.Items
{
	public class FormulaEnchantBootsMinorStamina : Item
	{
		public FormulaEnchantBootsMinorStamina() : base()
		{
			Id = 6376;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 11431;
			ObjectClass = 9;
			SubClass = 0;
			Level = 25;
			Name = "Formula: Enchant Boots - Minor Stamina";
			Name2 = "Formula: Enchant Boots - Minor Stamina";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 333;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 80;
			SetSpell( 7864 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Manual: The Path of Defense)
*
***************************************************************/

namespace Server.Items
{
	public class ManualThePathOfDefense : Item
	{
		public ManualThePathOfDefense() : base()
		{
			Id = 6619;
			Bonding = 1;
			AvailableClasses = 0x7A01;
			Model = 12547;
			ObjectClass = 9;
			SubClass = 0;
			Level = 10;
			ReqLevel = 10;
			Name = "Manual: The Path of Defense";
			Name2 = "Manual: The Path of Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 96;
			SetSpell( 8121 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Herb Baked Egg)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeHerbBakedEgg : Item
	{
		public RecipeHerbBakedEgg() : base()
		{
			Id = 6891;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 811;
			ObjectClass = 9;
			SubClass = 0;
			Level = 5;
			Name = "Recipe: Herb Baked Egg";
			Name2 = "Recipe: Herb Baked Egg";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 185;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8605 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Plans: Goblin Rocket Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PlansGoblinRocketBoots : Item
	{
		public PlansGoblinRocketBoots() : base()
		{
			Id = 7192;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 1102;
			ObjectClass = 9;
			SubClass = 0;
			Level = 26;
			Name = "Plans: Goblin Rocket Boots";
			Name2 = "Plans: Goblin Rocket Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 130;
			Skill = 202;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8896 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Kearnen's Journal)
*
***************************************************************/

namespace Server.Items
{
	public class KearnensJournal : Item
	{
		public KearnensJournal() : base()
		{
			Id = 8046;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6672;
			ObjectClass = 9;
			SubClass = 0;
			Level = 1;
			Name = "Kearnen's Journal";
			Name2 = "Kearnen's Journal";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1051;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Grimoire of Inferno)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfInferno : Item
	{
		public GrimoireOfInferno() : base()
		{
			Id = 9214;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Grimoire of Inferno";
			Name2 = "Grimoire of Inferno";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20799 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Libram of Rumination)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfRumination : Item
	{
		public LibramOfRumination() : base()
		{
			Id = 11732;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Rumination";
			Name2 = "Libram of Rumination";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1611;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Constitution)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfConstitution : Item
	{
		public LibramOfConstitution() : base()
		{
			Id = 11733;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 7139;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Constitution";
			Name2 = "Libram of Constitution";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1631;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Tenacity)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfTenacity : Item
	{
		public LibramOfTenacity() : base()
		{
			Id = 11734;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 1103;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Tenacity";
			Name2 = "Libram of Tenacity";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1633;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Resilience)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfResilience : Item
	{
		public LibramOfResilience() : base()
		{
			Id = 11736;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 8093;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Resilience";
			Name2 = "Libram of Resilience";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1632;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Voracity)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfVoracity : Item
	{
		public LibramOfVoracity() : base()
		{
			Id = 11737;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 1134;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Voracity";
			Name2 = "Libram of Voracity";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 1634;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank2 : Item
	{
		public GrimoireOfFireboltRank2() : base()
		{
			Id = 16302;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 8;
			ReqLevel = 8;
			Name = "Grimoire of Firebolt (Rank 2)";
			Name2 = "Grimoire of Firebolt (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20270 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank3 : Item
	{
		public GrimoireOfFireboltRank3() : base()
		{
			Id = 16316;
			Bonding = 1;
			SellPrice = 375;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 18;
			ReqLevel = 18;
			Name = "Grimoire of Firebolt (Rank 3)";
			Name2 = "Grimoire of Firebolt (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20312 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank4 : Item
	{
		public GrimoireOfFireboltRank4() : base()
		{
			Id = 16317;
			Bonding = 1;
			SellPrice = 1250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 28;
			ReqLevel = 28;
			Name = "Grimoire of Firebolt (Rank 4)";
			Name2 = "Grimoire of Firebolt (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20313 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank5 : Item
	{
		public GrimoireOfFireboltRank5() : base()
		{
			Id = 16318;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Grimoire of Firebolt (Rank 5)";
			Name2 = "Grimoire of Firebolt (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20314 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 6))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank6 : Item
	{
		public GrimoireOfFireboltRank6() : base()
		{
			Id = 16319;
			Bonding = 1;
			SellPrice = 3500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Grimoire of Firebolt (Rank 6)";
			Name2 = "Grimoire of Firebolt (Rank 6)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20315 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Firebolt (Rank 7))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireboltRank7 : Item
	{
		public GrimoireOfFireboltRank7() : base()
		{
			Id = 16320;
			Bonding = 1;
			SellPrice = 6000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 58;
			ReqLevel = 58;
			Name = "Grimoire of Firebolt (Rank 7)";
			Name2 = "Grimoire of Firebolt (Rank 7)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20316 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Blood Pact (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBloodPactRank1 : Item
	{
		public GrimoireOfBloodPactRank1() : base()
		{
			Id = 16321;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 4;
			ReqLevel = 4;
			Name = "Grimoire of Blood Pact (Rank 1)";
			Name2 = "Grimoire of Blood Pact (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20397 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Blood Pact (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBloodPactRank2 : Item
	{
		public GrimoireOfBloodPactRank2() : base()
		{
			Id = 16322;
			Bonding = 1;
			SellPrice = 225;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 14;
			ReqLevel = 14;
			Name = "Grimoire of Blood Pact (Rank 2)";
			Name2 = "Grimoire of Blood Pact (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 900;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20318 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Blood Pact (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBloodPactRank3 : Item
	{
		public GrimoireOfBloodPactRank3() : base()
		{
			Id = 16323;
			Bonding = 1;
			SellPrice = 1000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 26;
			ReqLevel = 26;
			Name = "Grimoire of Blood Pact (Rank 3)";
			Name2 = "Grimoire of Blood Pact (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20319 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Blood Pact (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBloodPactRank4 : Item
	{
		public GrimoireOfBloodPactRank4() : base()
		{
			Id = 16324;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Grimoire of Blood Pact (Rank 4)";
			Name2 = "Grimoire of Blood Pact (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20320 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Blood Pact (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfBloodPactRank5 : Item
	{
		public GrimoireOfBloodPactRank5() : base()
		{
			Id = 16325;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Grimoire of Blood Pact (Rank 5)";
			Name2 = "Grimoire of Blood Pact (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20321 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Fire Shield (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireShieldRank1 : Item
	{
		public GrimoireOfFireShieldRank1() : base()
		{
			Id = 16326;
			Bonding = 1;
			SellPrice = 225;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 14;
			ReqLevel = 14;
			Name = "Grimoire of Fire Shield (Rank 1)";
			Name2 = "Grimoire of Fire Shield (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 900;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20322 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Fire Shield (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireShieldRank2 : Item
	{
		public GrimoireOfFireShieldRank2() : base()
		{
			Id = 16327;
			Bonding = 1;
			SellPrice = 750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 24;
			ReqLevel = 24;
			Name = "Grimoire of Fire Shield (Rank 2)";
			Name2 = "Grimoire of Fire Shield (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20323 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Fire Shield (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireShieldRank3 : Item
	{
		public GrimoireOfFireShieldRank3() : base()
		{
			Id = 16328;
			Bonding = 1;
			SellPrice = 2000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 34;
			ReqLevel = 34;
			Name = "Grimoire of Fire Shield (Rank 3)";
			Name2 = "Grimoire of Fire Shield (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20324 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Fire Shield (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireShieldRank4 : Item
	{
		public GrimoireOfFireShieldRank4() : base()
		{
			Id = 16329;
			Bonding = 1;
			SellPrice = 3000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 44;
			ReqLevel = 44;
			Name = "Grimoire of Fire Shield (Rank 4)";
			Name2 = "Grimoire of Fire Shield (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20326 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Fire Shield (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfFireShieldRank5 : Item
	{
		public GrimoireOfFireShieldRank5() : base()
		{
			Id = 16330;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 54;
			ReqLevel = 54;
			Name = "Grimoire of Fire Shield (Rank 5)";
			Name2 = "Grimoire of Fire Shield (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20327 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Phase Shift)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfPhaseShift : Item
	{
		public GrimoireOfPhaseShift() : base()
		{
			Id = 16331;
			Bonding = 1;
			SellPrice = 150;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 12;
			ReqLevel = 12;
			Name = "Grimoire of Phase Shift";
			Name2 = "Grimoire of Phase Shift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20329 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Torment (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTormentRank2 : Item
	{
		public GrimoireOfTormentRank2() : base()
		{
			Id = 16346;
			Bonding = 1;
			SellPrice = 500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 20;
			ReqLevel = 20;
			Name = "Grimoire of Torment (Rank 2)";
			Name2 = "Grimoire of Torment (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20317 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Torment (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTormentRank3 : Item
	{
		public GrimoireOfTormentRank3() : base()
		{
			Id = 16347;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 30;
			ReqLevel = 30;
			Name = "Grimoire of Torment (Rank 3)";
			Name2 = "Grimoire of Torment (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20377 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Torment (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTormentRank4 : Item
	{
		public GrimoireOfTormentRank4() : base()
		{
			Id = 16348;
			Bonding = 1;
			SellPrice = 2750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Grimoire of Torment (Rank 4)";
			Name2 = "Grimoire of Torment (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20378 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Torment (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTormentRank5 : Item
	{
		public GrimoireOfTormentRank5() : base()
		{
			Id = 16349;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Grimoire of Torment (Rank 5)";
			Name2 = "Grimoire of Torment (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20379 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Torment (Rank 6))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTormentRank6 : Item
	{
		public GrimoireOfTormentRank6() : base()
		{
			Id = 16350;
			Bonding = 1;
			SellPrice = 6500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Grimoire of Torment (Rank 6)";
			Name2 = "Grimoire of Torment (Rank 6)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20380 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank1 : Item
	{
		public GrimoireOfSacrificeRank1() : base()
		{
			Id = 16351;
			Bonding = 1;
			SellPrice = 300;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 16;
			ReqLevel = 16;
			Name = "Grimoire of Sacrifice (Rank 1)";
			Name2 = "Grimoire of Sacrifice (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20381 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank2 : Item
	{
		public GrimoireOfSacrificeRank2() : base()
		{
			Id = 16352;
			Bonding = 1;
			SellPrice = 750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 24;
			ReqLevel = 24;
			Name = "Grimoire of Sacrifice (Rank 2)";
			Name2 = "Grimoire of Sacrifice (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20382 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank3 : Item
	{
		public GrimoireOfSacrificeRank3() : base()
		{
			Id = 16353;
			Bonding = 1;
			SellPrice = 1750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 32;
			ReqLevel = 32;
			Name = "Grimoire of Sacrifice (Rank 3)";
			Name2 = "Grimoire of Sacrifice (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20383 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank4 : Item
	{
		public GrimoireOfSacrificeRank4() : base()
		{
			Id = 16354;
			Bonding = 1;
			SellPrice = 2750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Grimoire of Sacrifice (Rank 4)";
			Name2 = "Grimoire of Sacrifice (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20384 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank5 : Item
	{
		public GrimoireOfSacrificeRank5() : base()
		{
			Id = 16355;
			Bonding = 1;
			SellPrice = 3500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Grimoire of Sacrifice (Rank 5)";
			Name2 = "Grimoire of Sacrifice (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20385 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Sacrifice (Rank 6))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSacrificeRank6 : Item
	{
		public GrimoireOfSacrificeRank6() : base()
		{
			Id = 16356;
			Bonding = 1;
			SellPrice = 5500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 56;
			ReqLevel = 56;
			Name = "Grimoire of Sacrifice (Rank 6)";
			Name2 = "Grimoire of Sacrifice (Rank 6)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20386 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank1 : Item
	{
		public GrimoireOfConsumeShadowsRank1() : base()
		{
			Id = 16357;
			Bonding = 1;
			SellPrice = 375;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 18;
			ReqLevel = 18;
			Name = "Grimoire of Consume Shadows (Rank 1)";
			Name2 = "Grimoire of Consume Shadows (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20387 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank2 : Item
	{
		public GrimoireOfConsumeShadowsRank2() : base()
		{
			Id = 16358;
			Bonding = 1;
			SellPrice = 1000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 26;
			ReqLevel = 26;
			Name = "Grimoire of Consume Shadows (Rank 2)";
			Name2 = "Grimoire of Consume Shadows (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20388 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank3 : Item
	{
		public GrimoireOfConsumeShadowsRank3() : base()
		{
			Id = 16359;
			Bonding = 1;
			SellPrice = 2000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 34;
			ReqLevel = 34;
			Name = "Grimoire of Consume Shadows (Rank 3)";
			Name2 = "Grimoire of Consume Shadows (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20389 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank4 : Item
	{
		public GrimoireOfConsumeShadowsRank4() : base()
		{
			Id = 16360;
			Bonding = 1;
			SellPrice = 2750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 42;
			ReqLevel = 42;
			Name = "Grimoire of Consume Shadows (Rank 4)";
			Name2 = "Grimoire of Consume Shadows (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20390 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank5 : Item
	{
		public GrimoireOfConsumeShadowsRank5() : base()
		{
			Id = 16361;
			Bonding = 1;
			SellPrice = 3750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Grimoire of Consume Shadows (Rank 5)";
			Name2 = "Grimoire of Consume Shadows (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20391 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Consume Shadows (Rank 6))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfConsumeShadowsRank6 : Item
	{
		public GrimoireOfConsumeShadowsRank6() : base()
		{
			Id = 16362;
			Bonding = 1;
			SellPrice = 6000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 58;
			ReqLevel = 58;
			Name = "Grimoire of Consume Shadows (Rank 6)";
			Name2 = "Grimoire of Consume Shadows (Rank 6)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20392 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Suffering (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSufferingRank1 : Item
	{
		public GrimoireOfSufferingRank1() : base()
		{
			Id = 16363;
			Bonding = 1;
			SellPrice = 750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 24;
			ReqLevel = 24;
			Name = "Grimoire of Suffering (Rank 1)";
			Name2 = "Grimoire of Suffering (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20393 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Suffering (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSufferingRank2 : Item
	{
		public GrimoireOfSufferingRank2() : base()
		{
			Id = 16364;
			Bonding = 1;
			SellPrice = 2250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 36;
			ReqLevel = 36;
			Name = "Grimoire of Suffering (Rank 2)";
			Name2 = "Grimoire of Suffering (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20394 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Suffering (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSufferingRank3 : Item
	{
		public GrimoireOfSufferingRank3() : base()
		{
			Id = 16365;
			Bonding = 1;
			SellPrice = 3500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Grimoire of Suffering (Rank 3)";
			Name2 = "Grimoire of Suffering (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20395 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Suffering (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSufferingRank4 : Item
	{
		public GrimoireOfSufferingRank4() : base()
		{
			Id = 16366;
			Bonding = 1;
			SellPrice = 6500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Grimoire of Suffering (Rank 4)";
			Name2 = "Grimoire of Suffering (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20396 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lash of Pain (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLashOfPainRank2 : Item
	{
		public GrimoireOfLashOfPainRank2() : base()
		{
			Id = 16368;
			Bonding = 1;
			SellPrice = 1250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 28;
			ReqLevel = 28;
			Name = "Grimoire of Lash of Pain (Rank 2)";
			Name2 = "Grimoire of Lash of Pain (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20398 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lash of Pain (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLashOfPainRank3 : Item
	{
		public GrimoireOfLashOfPainRank3() : base()
		{
			Id = 16371;
			Bonding = 1;
			SellPrice = 2250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 36;
			ReqLevel = 36;
			Name = "Grimoire of Lash of Pain (Rank 3)";
			Name2 = "Grimoire of Lash of Pain (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20399 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lash of Pain (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLashOfPainRank4 : Item
	{
		public GrimoireOfLashOfPainRank4() : base()
		{
			Id = 16372;
			Bonding = 1;
			SellPrice = 3000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 44;
			ReqLevel = 44;
			Name = "Grimoire of Lash of Pain (Rank 4)";
			Name2 = "Grimoire of Lash of Pain (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20400 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lash of Pain (Rank 5))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLashOfPainRank5 : Item
	{
		public GrimoireOfLashOfPainRank5() : base()
		{
			Id = 16373;
			Bonding = 1;
			SellPrice = 4500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 52;
			ReqLevel = 52;
			Name = "Grimoire of Lash of Pain (Rank 5)";
			Name2 = "Grimoire of Lash of Pain (Rank 5)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 18000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20401 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lash of Pain (Rank 6))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLashOfPainRank6 : Item
	{
		public GrimoireOfLashOfPainRank6() : base()
		{
			Id = 16374;
			Bonding = 1;
			SellPrice = 6500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Grimoire of Lash of Pain (Rank 6)";
			Name2 = "Grimoire of Lash of Pain (Rank 6)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20402 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Soothing Kiss (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSoothingKissRank1 : Item
	{
		public GrimoireOfSoothingKissRank1() : base()
		{
			Id = 16375;
			Bonding = 1;
			SellPrice = 625;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 22;
			ReqLevel = 22;
			Name = "Grimoire of Soothing Kiss (Rank 1)";
			Name2 = "Grimoire of Soothing Kiss (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20403 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Soothing Kiss (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSoothingKissRank2 : Item
	{
		public GrimoireOfSoothingKissRank2() : base()
		{
			Id = 16376;
			Bonding = 1;
			SellPrice = 2000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 34;
			ReqLevel = 34;
			Name = "Grimoire of Soothing Kiss (Rank 2)";
			Name2 = "Grimoire of Soothing Kiss (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20404 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Soothing Kiss (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSoothingKissRank3 : Item
	{
		public GrimoireOfSoothingKissRank3() : base()
		{
			Id = 16377;
			Bonding = 1;
			SellPrice = 3250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 46;
			ReqLevel = 46;
			Name = "Grimoire of Soothing Kiss (Rank 3)";
			Name2 = "Grimoire of Soothing Kiss (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20405 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Soothing Kiss (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSoothingKissRank4 : Item
	{
		public GrimoireOfSoothingKissRank4() : base()
		{
			Id = 16378;
			Bonding = 1;
			SellPrice = 6000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 58;
			ReqLevel = 58;
			Name = "Grimoire of Soothing Kiss (Rank 4)";
			Name2 = "Grimoire of Soothing Kiss (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20406 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Seduction)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSeduction : Item
	{
		public GrimoireOfSeduction() : base()
		{
			Id = 16379;
			Bonding = 1;
			SellPrice = 1000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 26;
			ReqLevel = 26;
			Name = "Grimoire of Seduction";
			Name2 = "Grimoire of Seduction";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20407 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Lesser Invisibility)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfLesserInvisibility : Item
	{
		public GrimoireOfLesserInvisibility() : base()
		{
			Id = 16380;
			Bonding = 1;
			SellPrice = 1750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 32;
			ReqLevel = 32;
			Name = "Grimoire of Lesser Invisibility";
			Name2 = "Grimoire of Lesser Invisibility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20408 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Devour Magic (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfDevourMagicRank2 : Item
	{
		public GrimoireOfDevourMagicRank2() : base()
		{
			Id = 16381;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Grimoire of Devour Magic (Rank 2)";
			Name2 = "Grimoire of Devour Magic (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20426 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Devour Magic (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfDevourMagicRank3 : Item
	{
		public GrimoireOfDevourMagicRank3() : base()
		{
			Id = 16382;
			Bonding = 1;
			SellPrice = 3250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 46;
			ReqLevel = 46;
			Name = "Grimoire of Devour Magic (Rank 3)";
			Name2 = "Grimoire of Devour Magic (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20427 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Devour Magic (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfDevourMagicRank4 : Item
	{
		public GrimoireOfDevourMagicRank4() : base()
		{
			Id = 16383;
			Bonding = 1;
			SellPrice = 5000;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 54;
			ReqLevel = 54;
			Name = "Grimoire of Devour Magic (Rank 4)";
			Name2 = "Grimoire of Devour Magic (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20428 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Tainted Blood (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTaintedBloodRank1 : Item
	{
		public GrimoireOfTaintedBloodRank1() : base()
		{
			Id = 16384;
			Bonding = 1;
			SellPrice = 1750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 32;
			ReqLevel = 32;
			Name = "Grimoire of Tainted Blood (Rank 1)";
			Name2 = "Grimoire of Tainted Blood (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20429 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Tainted Blood (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTaintedBloodRank2 : Item
	{
		public GrimoireOfTaintedBloodRank2() : base()
		{
			Id = 16385;
			Bonding = 1;
			SellPrice = 2750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Grimoire of Tainted Blood (Rank 2)";
			Name2 = "Grimoire of Tainted Blood (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20430 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Tainted Blood (Rank 3))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTaintedBloodRank3 : Item
	{
		public GrimoireOfTaintedBloodRank3() : base()
		{
			Id = 16386;
			Bonding = 1;
			SellPrice = 3500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Grimoire of Tainted Blood (Rank 3)";
			Name2 = "Grimoire of Tainted Blood (Rank 3)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20431 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Tainted Blood (Rank 4))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfTaintedBloodRank4 : Item
	{
		public GrimoireOfTaintedBloodRank4() : base()
		{
			Id = 16387;
			Bonding = 1;
			SellPrice = 5500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 56;
			ReqLevel = 56;
			Name = "Grimoire of Tainted Blood (Rank 4)";
			Name2 = "Grimoire of Tainted Blood (Rank 4)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20432 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Spell Lock (Rank 1))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSpellLockRank1 : Item
	{
		public GrimoireOfSpellLockRank1() : base()
		{
			Id = 16388;
			Bonding = 1;
			SellPrice = 2250;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 36;
			ReqLevel = 36;
			Name = "Grimoire of Spell Lock (Rank 1)";
			Name2 = "Grimoire of Spell Lock (Rank 1)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20433 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Spell Lock (Rank 2))
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfSpellLockRank2 : Item
	{
		public GrimoireOfSpellLockRank2() : base()
		{
			Id = 16389;
			Bonding = 1;
			SellPrice = 4500;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 52;
			ReqLevel = 52;
			Name = "Grimoire of Spell Lock (Rank 2)";
			Name2 = "Grimoire of Spell Lock (Rank 2)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 18000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20434 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Grimoire of Paranoia)
*
***************************************************************/

namespace Server.Items
{
	public class GrimoireOfParanoia : Item
	{
		public GrimoireOfParanoia() : base()
		{
			Id = 16390;
			Bonding = 1;
			SellPrice = 2750;
			AvailableClasses = 0x7B00;
			Model = 1246;
			ObjectClass = 9;
			SubClass = 0;
			Level = 42;
			ReqLevel = 42;
			Name = "Grimoire of Paranoia";
			Name2 = "Grimoire of Paranoia";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 20435 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tome of Tranquilizing Shot)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfTranquilizingShot : Item
	{
		public TomeOfTranquilizingShot() : base()
		{
			Id = 16665;
			Bonding = 1;
			AvailableClasses = 0x7A04;
			Model = 1317;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Tome of Tranquilizing Shot";
			Name2 = "Tome of Tranquilizing Shot";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 19877 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Codex: Prayer of Fortitude)
*
***************************************************************/

namespace Server.Items
{
	public class CodexPrayerOfFortitude : Item
	{
		public CodexPrayerOfFortitude() : base()
		{
			Id = 17413;
			SellPrice = 7750;
			AvailableClasses = 0x7A10;
			Model = 1143;
			ObjectClass = 9;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Codex: Prayer of Fortitude";
			Name2 = "Codex: Prayer of Fortitude";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 21568 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Codex: Prayer of Fortitude II)
*
***************************************************************/

namespace Server.Items
{
	public class CodexPrayerOfFortitudeII : Item
	{
		public CodexPrayerOfFortitudeII() : base()
		{
			Id = 17414;
			SellPrice = 14750;
			AvailableClasses = 0x7A10;
			Model = 1143;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Codex: Prayer of Fortitude II";
			Name2 = "Codex: Prayer of Fortitude II";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 21569 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Book: Gift of the Wild)
*
***************************************************************/

namespace Server.Items
{
	public class BookGiftOfTheWild : Item
	{
		public BookGiftOfTheWild() : base()
		{
			Id = 17682;
			SellPrice = 8750;
			AvailableClasses = 0x7E00;
			Model = 1317;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Book: Gift of the Wild";
			Name2 = "Book: Gift of the Wild";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 21851 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Book: Gift of the Wild II)
*
***************************************************************/

namespace Server.Items
{
	public class BookGiftOfTheWildII : Item
	{
		public BookGiftOfTheWildII() : base()
		{
			Id = 17683;
			SellPrice = 14750;
			AvailableClasses = 0x7E00;
			Model = 1317;
			ObjectClass = 9;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Book: Gift of the Wild II";
			Name2 = "Book: Gift of the Wild II";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 21852 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Libram of Rapidity)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfRapidity : Item
	{
		public LibramOfRapidity() : base()
		{
			Id = 18332;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 12547;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Rapidity";
			Name2 = "Libram of Rapidity";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2635;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Focus)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfFocus : Item
	{
		public LibramOfFocus() : base()
		{
			Id = 18333;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 6672;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Focus";
			Name2 = "Libram of Focus";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2631;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Libram of Protection)
*
***************************************************************/

namespace Server.Items
{
	public class LibramOfProtection : Item
	{
		public LibramOfProtection() : base()
		{
			Id = 18334;
			AvailableClasses = 0x7FFF;
			Description = "Dark runes skitter across the surface.";
			Model = 1317;
			ObjectClass = 9;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Libram of Protection";
			Name2 = "Libram of Protection";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2633;
			PageMaterial = 4;
		}
	}
}


/**************************************************************
*
*				(Tome of Arcane Brilliance)
*
***************************************************************/

namespace Server.Items
{
	public class TomeOfArcaneBrilliance : Item
	{
		public TomeOfArcaneBrilliance() : base()
		{
			Id = 18600;
			SellPrice = 12000;
			AvailableClasses = 0x7A80;
			Model = 1103;
			ObjectClass = 9;
			SubClass = 0;
			Level = 56;
			ReqLevel = 56;
			Name = "Tome of Arcane Brilliance";
			Name2 = "Tome of Arcane Brilliance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 23030 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


