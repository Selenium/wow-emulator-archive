/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:02 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Recipe: Elixir of Minor Agility)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfMinorAgility : Item
	{
		public RecipeElixirOfMinorAgility() : base()
		{
			Id = 2553;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 12;
			Name = "Recipe: Elixir of Minor Agility";
			Name2 = "Recipe: Elixir of Minor Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 171;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 2342 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Swiftness Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeSwiftnessPotion : Item
	{
		public RecipeSwiftnessPotion() : base()
		{
			Id = 2555;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 15;
			Name = "Recipe: Swiftness Potion";
			Name2 = "Recipe: Swiftness Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 60;
			Skill = 171;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 2364 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Minor Magic Resistance Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMinorMagicResistancePotion : Item
	{
		public RecipeMinorMagicResistancePotion() : base()
		{
			Id = 3393;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 22;
			Name = "Recipe: Minor Magic Resistance Potion";
			Name2 = "Recipe: Minor Magic Resistance Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 110;
			Skill = 171;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3180 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Poison Resistance)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfPoisonResistance : Item
	{
		public RecipeElixirOfPoisonResistance() : base()
		{
			Id = 3394;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 24;
			Name = "Recipe: Elixir of Poison Resistance";
			Name2 = "Recipe: Elixir of Poison Resistance";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 120;
			Skill = 171;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3182 , 0 , -1 , 0 , 79 , 0 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Limited Invulnerability Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeLimitedInvulnerabilityPotion : Item
	{
		public RecipeLimitedInvulnerabilityPotion() : base()
		{
			Id = 3395;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 50;
			Name = "Recipe: Limited Invulnerability Potion";
			Name2 = "Recipe: Limited Invulnerability Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 171;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3183 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Lesser Agility)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfLesserAgility : Item
	{
		public RecipeElixirOfLesserAgility() : base()
		{
			Id = 3396;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 28;
			Name = "Recipe: Elixir of Lesser Agility";
			Name2 = "Recipe: Elixir of Lesser Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 140;
			Skill = 171;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3187 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Fortitude)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfFortitude : Item
	{
		public RecipeElixirOfFortitude() : base()
		{
			Id = 3830;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 35;
			Name = "Recipe: Elixir of Fortitude";
			Name2 = "Recipe: Elixir of Fortitude";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3455 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Mighty Troll's Blood Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMightyTrollsBloodPotion : Item
	{
		public RecipeMightyTrollsBloodPotion() : base()
		{
			Id = 3831;
			SellPrice = 550;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 36;
			Name = "Recipe: Mighty Troll's Blood Potion";
			Name2 = "Recipe: Mighty Troll's Blood Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 180;
			Skill = 171;
			BuyPrice = 2200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3456 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Detect Lesser Invisibility)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfDetectLesserInvisibility : Item
	{
		public RecipeElixirOfDetectLesserInvisibility() : base()
		{
			Id = 3832;
			SellPrice = 550;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 39;
			Name = "Recipe: Elixir of Detect Lesser Invisibility";
			Name2 = "Recipe: Elixir of Detect Lesser Invisibility";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 195;
			Skill = 171;
			BuyPrice = 2200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3457 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Discolored Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeDiscoloredHealingPotion : Item
	{
		public RecipeDiscoloredHealingPotion() : base()
		{
			Id = 4597;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 10;
			Name = "Recipe: Discolored Healing Potion";
			Name2 = "Recipe: Discolored Healing Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 171;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 4509 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Lesser Stoneshield Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeLesserStoneshieldPotion : Item
	{
		public RecipeLesserStoneshieldPotion() : base()
		{
			Id = 4624;
			SellPrice = 550;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 43;
			Name = "Recipe: Lesser Stoneshield Potion";
			Name2 = "Recipe: Lesser Stoneshield Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 215;
			Skill = 171;
			BuyPrice = 2200;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 4943 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeRagePotion : Item
	{
		public RecipeRagePotion() : base()
		{
			Id = 5640;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 14;
			Name = "Recipe: Rage Potion";
			Name2 = "Recipe: Rage Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 60;
			Skill = 171;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6621 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Free Action Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFreeActionPotion : Item
	{
		public RecipeFreeActionPotion() : base()
		{
			Id = 5642;
			SellPrice = 450;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 30;
			Name = "Recipe: Free Action Potion";
			Name2 = "Recipe: Free Action Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 150;
			Skill = 171;
			BuyPrice = 1800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6625 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Great Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreatRagePotion : Item
	{
		public RecipeGreatRagePotion() : base()
		{
			Id = 5643;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 35;
			Name = "Recipe: Great Rage Potion";
			Name2 = "Recipe: Great Rage Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6622 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Holy Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeHolyProtectionPotion : Item
	{
		public RecipeHolyProtectionPotion() : base()
		{
			Id = 6053;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 20;
			Name = "Recipe: Holy Protection Potion";
			Name2 = "Recipe: Holy Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 171;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7260 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Shadow Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeShadowProtectionPotion : Item
	{
		public RecipeShadowProtectionPotion() : base()
		{
			Id = 6054;
			SellPrice = 225;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 27;
			Name = "Recipe: Shadow Protection Potion";
			Name2 = "Recipe: Shadow Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 135;
			Skill = 171;
			BuyPrice = 900;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7261 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Fire Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFireProtectionPotion : Item
	{
		public RecipeFireProtectionPotion() : base()
		{
			Id = 6055;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 33;
			Name = "Recipe: Fire Protection Potion";
			Name2 = "Recipe: Fire Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 165;
			Skill = 171;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7262 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Frost Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFrostProtectionPotion : Item
	{
		public RecipeFrostProtectionPotion() : base()
		{
			Id = 6056;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 38;
			Name = "Recipe: Frost Protection Potion";
			Name2 = "Recipe: Frost Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 190;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7263 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Nature Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeNatureProtectionPotion : Item
	{
		public RecipeNatureProtectionPotion() : base()
		{
			Id = 6057;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 38;
			Name = "Recipe: Nature Protection Potion";
			Name2 = "Recipe: Nature Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 190;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7264 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Shadow Oil)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeShadowOil : Item
	{
		public RecipeShadowOil() : base()
		{
			Id = 6068;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 33;
			Name = "Recipe: Shadow Oil";
			Name2 = "Recipe: Shadow Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 165;
			Skill = 171;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7280 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Ogre's Strength)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfOgresStrength : Item
	{
		public RecipeElixirOfOgresStrength() : base()
		{
			Id = 6211;
			SellPrice = 450;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 30;
			Name = "Recipe: Elixir of Ogre's Strength";
			Name2 = "Recipe: Elixir of Ogre's Strength";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 150;
			Skill = 171;
			BuyPrice = 1800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 3189 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Giant Growth)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfGiantGrowth : Item
	{
		public RecipeElixirOfGiantGrowth() : base()
		{
			Id = 6663;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 18;
			Name = "Recipe: Elixir of Giant Growth";
			Name2 = "Recipe: Elixir of Giant Growth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 90;
			Skill = 171;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8241 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Magic Resistance Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMagicResistancePotion : Item
	{
		public RecipeMagicResistancePotion() : base()
		{
			Id = 9293;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 42;
			Name = "Recipe: Magic Resistance Potion";
			Name2 = "Recipe: Magic Resistance Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 210;
			Skill = 171;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11503 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Wildvine Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeWildvinePotion : Item
	{
		public RecipeWildvinePotion() : base()
		{
			Id = 9294;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 45;
			Name = "Recipe: Wildvine Potion";
			Name2 = "Recipe: Wildvine Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11505 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Invisibility Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeInvisibilityPotion : Item
	{
		public RecipeInvisibilityPotion() : base()
		{
			Id = 9295;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 47;
			Name = "Recipe: Invisibility Potion";
			Name2 = "Recipe: Invisibility Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 235;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11506 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Gift of Arthas)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGiftOfArthas : Item
	{
		public RecipeGiftOfArthas() : base()
		{
			Id = 9296;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 6270;
			ObjectClass = 9;
			SubClass = 6;
			Level = 48;
			Name = "Recipe: Gift of Arthas";
			Name2 = "Recipe: Gift of Arthas";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 240;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11507 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Dream Vision)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfDreamVision : Item
	{
		public RecipeElixirOfDreamVision() : base()
		{
			Id = 9297;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 48;
			Name = "Recipe: Elixir of Dream Vision";
			Name2 = "Recipe: Elixir of Dream Vision";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 240;
			Skill = 171;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11508 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Giants)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfGiants : Item
	{
		public RecipeElixirOfGiants() : base()
		{
			Id = 9298;
			SellPrice = 2250;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 49;
			Name = "Recipe: Elixir of Giants";
			Name2 = "Recipe: Elixir of Giants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 245;
			Skill = 171;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11509 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Demonslaying)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfDemonslaying : Item
	{
		public RecipeElixirOfDemonslaying() : base()
		{
			Id = 9300;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 50;
			Name = "Recipe: Elixir of Demonslaying";
			Name2 = "Recipe: Elixir of Demonslaying";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 171;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11510 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Shadow Power)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfShadowPower : Item
	{
		public RecipeElixirOfShadowPower() : base()
		{
			Id = 9301;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 50;
			Name = "Recipe: Elixir of Shadow Power";
			Name2 = "Recipe: Elixir of Shadow Power";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 171;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11531 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Ghost Dye)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGhostDye : Item
	{
		public RecipeGhostDye() : base()
		{
			Id = 9302;
			SellPrice = 2250;
			AvailableClasses = 0x7FFF;
			Model = 6270;
			ObjectClass = 9;
			SubClass = 6;
			Level = 49;
			Name = "Recipe: Ghost Dye";
			Name2 = "Recipe: Ghost Dye";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 245;
			Skill = 171;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11530 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Philosophers' Stone)
*
***************************************************************/

namespace Server.Items
{
	public class RecipePhilosophersStone : Item
	{
		public RecipePhilosophersStone() : base()
		{
			Id = 9303;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 45;
			Name = "Recipe: Philosophers' Stone";
			Name2 = "Recipe: Philosophers' Stone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11529 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Iron to Gold)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteIronToGold : Item
	{
		public RecipeTransmuteIronToGold() : base()
		{
			Id = 9304;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 45;
			Name = "Recipe: Transmute Iron to Gold";
			Name2 = "Recipe: Transmute Iron to Gold";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11532 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Mithril to Truesilver)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteMithrilToTruesilver : Item
	{
		public RecipeTransmuteMithrilToTruesilver() : base()
		{
			Id = 9305;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 45;
			Name = "Recipe: Transmute Mithril to Truesilver";
			Name2 = "Recipe: Transmute Mithril to Truesilver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 171;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 11533 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Goblin Rocket Fuel)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGoblinRocketFuel : Item
	{
		public RecipeGoblinRocketFuel() : base()
		{
			Id = 10644;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 42;
			Name = "Recipe: Goblin Rocket Fuel";
			Name2 = "Recipe: Goblin Rocket Fuel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 210;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12706 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Arcanite)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteArcanite : Item
	{
		public RecipeTransmuteArcanite() : base()
		{
			Id = 12958;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Arcanite";
			Name2 = "Recipe: Transmute Arcanite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17188 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Mighty Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMightyRagePotion : Item
	{
		public RecipeMightyRagePotion() : base()
		{
			Id = 13476;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 51;
			Name = "Recipe: Mighty Rage Potion";
			Name2 = "Recipe: Mighty Rage Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 255;
			Skill = 171;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17582 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Superior Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeSuperiorManaPotion : Item
	{
		public RecipeSuperiorManaPotion() : base()
		{
			Id = 13477;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 52;
			Name = "Recipe: Superior Mana Potion";
			Name2 = "Recipe: Superior Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 260;
			Skill = 171;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17583 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Superior Defense)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfSuperiorDefense : Item
	{
		public RecipeElixirOfSuperiorDefense() : base()
		{
			Id = 13478;
			SellPrice = 3250;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 53;
			Name = "Recipe: Elixir of Superior Defense";
			Name2 = "Recipe: Elixir of Superior Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 265;
			Skill = 171;
			BuyPrice = 13000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17584 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of the Sages)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfTheSages : Item
	{
		public RecipeElixirOfTheSages() : base()
		{
			Id = 13479;
			SellPrice = 3500;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 54;
			Name = "Recipe: Elixir of the Sages";
			Name2 = "Recipe: Elixir of the Sages";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 270;
			Skill = 171;
			BuyPrice = 14000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17585 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Major Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMajorHealingPotion : Item
	{
		public RecipeMajorHealingPotion() : base()
		{
			Id = 13480;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Major Healing Potion";
			Name2 = "Recipe: Major Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17586 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Brute Force)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfBruteForce : Item
	{
		public RecipeElixirOfBruteForce() : base()
		{
			Id = 13481;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Elixir of Brute Force";
			Name2 = "Recipe: Elixir of Brute Force";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17587 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Air to Fire)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteAirToFire : Item
	{
		public RecipeTransmuteAirToFire() : base()
		{
			Id = 13482;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Air to Fire";
			Name2 = "Recipe: Transmute Air to Fire";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17588 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Fire to Earth)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteFireToEarth : Item
	{
		public RecipeTransmuteFireToEarth() : base()
		{
			Id = 13483;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Fire to Earth";
			Name2 = "Recipe: Transmute Fire to Earth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17589 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Earth to Water)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteEarthToWater : Item
	{
		public RecipeTransmuteEarthToWater() : base()
		{
			Id = 13484;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Earth to Water";
			Name2 = "Recipe: Transmute Earth to Water";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17590 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Water to Air)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteWaterToAir : Item
	{
		public RecipeTransmuteWaterToAir() : base()
		{
			Id = 13485;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Water to Air";
			Name2 = "Recipe: Transmute Water to Air";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17591 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Undeath to Water)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteUndeathToWater : Item
	{
		public RecipeTransmuteUndeathToWater() : base()
		{
			Id = 13486;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Undeath to Water";
			Name2 = "Recipe: Transmute Undeath to Water";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17592 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Water to Undeath)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteWaterToUndeath : Item
	{
		public RecipeTransmuteWaterToUndeath() : base()
		{
			Id = 13487;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Water to Undeath";
			Name2 = "Recipe: Transmute Water to Undeath";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17593 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Life to Earth)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteLifeToEarth : Item
	{
		public RecipeTransmuteLifeToEarth() : base()
		{
			Id = 13488;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Life to Earth";
			Name2 = "Recipe: Transmute Life to Earth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17594 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Transmute Earth to Life)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeTransmuteEarthToLife : Item
	{
		public RecipeTransmuteEarthToLife() : base()
		{
			Id = 13489;
			SellPrice = 3750;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 55;
			Name = "Recipe: Transmute Earth to Life";
			Name2 = "Recipe: Transmute Earth to Life";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 171;
			BuyPrice = 15000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17595 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Stoneshield Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterStoneshieldPotion : Item
	{
		public RecipeGreaterStoneshieldPotion() : base()
		{
			Id = 13490;
			SellPrice = 4000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 56;
			Name = "Recipe: Greater Stoneshield Potion";
			Name2 = "Recipe: Greater Stoneshield Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 280;
			Skill = 171;
			BuyPrice = 16000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17596 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of the Mongoose)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfTheMongoose : Item
	{
		public RecipeElixirOfTheMongoose() : base()
		{
			Id = 13491;
			SellPrice = 4000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 56;
			Name = "Recipe: Elixir of the Mongoose";
			Name2 = "Recipe: Elixir of the Mongoose";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 280;
			Skill = 171;
			BuyPrice = 16000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17597 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Purification Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipePurificationPotion : Item
	{
		public RecipePurificationPotion() : base()
		{
			Id = 13492;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 57;
			Name = "Recipe: Purification Potion";
			Name2 = "Recipe: Purification Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 285;
			Skill = 171;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17598 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Arcane Elixir)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterArcaneElixir : Item
	{
		public RecipeGreaterArcaneElixir() : base()
		{
			Id = 13493;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 57;
			Name = "Recipe: Greater Arcane Elixir";
			Name2 = "Recipe: Greater Arcane Elixir";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 285;
			Skill = 171;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17599 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Fire Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterFireProtectionPotion : Item
	{
		public RecipeGreaterFireProtectionPotion() : base()
		{
			Id = 13494;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 58;
			Name = "Recipe: Greater Fire Protection Potion";
			Name2 = "Recipe: Greater Fire Protection Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 171;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17600 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Frost Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterFrostProtectionPotion : Item
	{
		public RecipeGreaterFrostProtectionPotion() : base()
		{
			Id = 13495;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 58;
			Name = "Recipe: Greater Frost Protection Potion";
			Name2 = "Recipe: Greater Frost Protection Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 171;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17601 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Nature Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterNatureProtectionPotion : Item
	{
		public RecipeGreaterNatureProtectionPotion() : base()
		{
			Id = 13496;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 58;
			Name = "Recipe: Greater Nature Protection Potion";
			Name2 = "Recipe: Greater Nature Protection Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 171;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17602 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Arcane Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterArcaneProtectionPotion : Item
	{
		public RecipeGreaterArcaneProtectionPotion() : base()
		{
			Id = 13497;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 58;
			Name = "Recipe: Greater Arcane Protection Potion";
			Name2 = "Recipe: Greater Arcane Protection Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 171;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17603 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Greater Shadow Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeGreaterShadowProtectionPotion : Item
	{
		public RecipeGreaterShadowProtectionPotion() : base()
		{
			Id = 13499;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 58;
			Name = "Recipe: Greater Shadow Protection Potion";
			Name2 = "Recipe: Greater Shadow Protection Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 171;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17604 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Major Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMajorManaPotion : Item
	{
		public RecipeMajorManaPotion() : base()
		{
			Id = 13501;
			Bonding = 1;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 59;
			Name = "Recipe: Major Mana Potion";
			Name2 = "Recipe: Major Mana Potion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 295;
			Skill = 171;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17606 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Flask of Petrification)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFlaskOfPetrification : Item
	{
		public RecipeFlaskOfPetrification() : base()
		{
			Id = 13518;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Flask of Petrification";
			Name2 = "Recipe: Flask of Petrification";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17641 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Flask of the Titans)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFlaskOfTheTitans : Item
	{
		public RecipeFlaskOfTheTitans() : base()
		{
			Id = 13519;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Flask of the Titans";
			Name2 = "Recipe: Flask of the Titans";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17642 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Flask of Distilled Wisdom)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFlaskOfDistilledWisdom : Item
	{
		public RecipeFlaskOfDistilledWisdom() : base()
		{
			Id = 13520;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Flask of Distilled Wisdom";
			Name2 = "Recipe: Flask of Distilled Wisdom";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17643 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Flask of Supreme Power)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFlaskOfSupremePower : Item
	{
		public RecipeFlaskOfSupremePower() : base()
		{
			Id = 13521;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Flask of Supreme Power";
			Name2 = "Recipe: Flask of Supreme Power";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17644 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Flask of Chromatic Resistance)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFlaskOfChromaticResistance : Item
	{
		public RecipeFlaskOfChromaticResistance() : base()
		{
			Id = 13522;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Flask of Chromatic Resistance";
			Name2 = "Recipe: Flask of Chromatic Resistance";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17645 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Frost Oil)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeFrostOil : Item
	{
		public RecipeFrostOil() : base()
		{
			Id = 14634;
			SellPrice = 625;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 9;
			SubClass = 6;
			Level = 40;
			Name = "Recipe: Frost Oil";
			Name2 = "Recipe: Frost Oil";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 171;
			BuyPrice = 2500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 18667 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Elixir of Frost Power)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeElixirOfFrostPower : Item
	{
		public RecipeElixirOfFrostPower() : base()
		{
			Id = 17709;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 9;
			SubClass = 6;
			Level = 38;
			Name = "Recipe: Elixir of Frost Power";
			Name2 = "Recipe: Elixir of Frost Power";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 190;
			Skill = 171;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 21924 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Recipe: Major Rejuvenation Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RecipeMajorRejuvenationPotion : Item
	{
		public RecipeMajorRejuvenationPotion() : base()
		{
			Id = 18257;
			SellPrice = 50000;
			AvailableClasses = 0x7FFF;
			Model = 6270;
			ObjectClass = 9;
			SubClass = 6;
			Level = 60;
			Name = "Recipe: Major Rejuvenation Potion";
			Name2 = "Recipe: Major Rejuvenation Potion";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 171;
			BuyPrice = 200000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22733 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


