/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:08:23 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Target Dummy)
*
***************************************************************/

namespace Server.Items
{
	public class TargetDummy : Item
	{
		public TargetDummy() : base()
		{
			Id = 4366;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 26633;
			ObjectClass = 7;
			SubClass = 3;
			Level = 17;
			Name = "Target Dummy";
			Name2 = "Target Dummy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 85;
			Skill = 202;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			SetSpell( 4071 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Flame Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class FlameDeflector : Item
	{
		public FlameDeflector() : base()
		{
			Id = 4376;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 7841;
			ObjectClass = 7;
			SubClass = 3;
			Level = 25;
			ReqLevel = 15;
			Name = "Flame Deflector";
			Name2 = "Flame Deflector";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 4057 , 0 , -5 , 900000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Minor Recombobulator)
*
***************************************************************/

namespace Server.Items
{
	public class MinorRecombobulator : Item
	{
		public MinorRecombobulator() : base()
		{
			Id = 4381;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 22293;
			ObjectClass = 7;
			SubClass = 3;
			Level = 28;
			Name = "Minor Recombobulator";
			Name2 = "Minor Recombobulator";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 140;
			Skill = 202;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 18805 , 0 , -10 , 300000 , 28 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Ice Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class IceDeflector : Item
	{
		public IceDeflector() : base()
		{
			Id = 4386;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 7841;
			ObjectClass = 7;
			SubClass = 3;
			Level = 31;
			ReqLevel = 21;
			Name = "Ice Deflector";
			Name2 = "Ice Deflector";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 4077 , 0 , -5 , 900000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Discombobulator Ray)
*
***************************************************************/

namespace Server.Items
{
	public class DiscombobulatorRay : Item
	{
		public DiscombobulatorRay() : base()
		{
			Id = 4388;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 7358;
			ObjectClass = 7;
			SubClass = 3;
			Level = 32;
			Name = "Discombobulator Ray";
			Name2 = "Discombobulator Ray";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 160;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 4060 , 0 , -5 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Compact Harvest Reaper Kit)
*
***************************************************************/

namespace Server.Items
{
	public class CompactHarvestReaperKit : Item
	{
		public CompactHarvestReaperKit() : base()
		{
			Id = 4391;
			SellPrice = 4000;
			AvailableClasses = 0x7FFF;
			Model = 21652;
			ObjectClass = 7;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Compact Harvest Reaper Kit";
			Name2 = "Compact Harvest Reaper Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 202;
			BuyPrice = 16000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			SetSpell( 4078 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Advanced Target Dummy)
*
***************************************************************/

namespace Server.Items
{
	public class AdvancedTargetDummy : Item
	{
		public AdvancedTargetDummy() : base()
		{
			Id = 4392;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 26632;
			ObjectClass = 7;
			SubClass = 3;
			Level = 37;
			Name = "Advanced Target Dummy";
			Name2 = "Advanced Target Dummy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 185;
			Skill = 202;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			SetSpell( 4072 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Mechanical Dragonling)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicalDragonling : Item
	{
		public MechanicalDragonling() : base()
		{
			Id = 4396;
			Bonding = 2;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 21632;
			ObjectClass = 7;
			SubClass = 3;
			Level = 40;
			ReqLevel = 30;
			Name = "Mechanical Dragonling";
			Name2 = "Mechanical Dragonling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 202;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 23076 , 0 , 0 , 3600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Cloaking Device)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishCloakingDevice : Item
	{
		public GnomishCloakingDevice() : base()
		{
			Id = 4397;
			Bonding = 2;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 7841;
			ObjectClass = 7;
			SubClass = 3;
			Level = 40;
			Name = "Gnomish Cloaking Device";
			Name2 = "Gnomish Cloaking Device";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 202;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 4079 , 0 , 0 , 3600000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Mechanical Squirrel Box)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicalSquirrelBox : Item
	{
		public MechanicalSquirrelBox() : base()
		{
			Id = 4401;
			Bonding = 3;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 16536;
			ObjectClass = 7;
			SubClass = 3;
			Level = 15;
			Name = "Mechanical Squirrel Box";
			Name2 = "Mechanical Squirrel Box";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 4055 , 0 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Portable Bronze Mortar)
*
***************************************************************/

namespace Server.Items
{
	public class PortableBronzeMortar : Item
	{
		public PortableBronzeMortar() : base()
		{
			Id = 4403;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 7397;
			ObjectClass = 7;
			SubClass = 3;
			Level = 33;
			Name = "Portable Bronze Mortar";
			Name2 = "Portable Bronze Mortar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 165;
			Skill = 202;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 4067 , 0 , -8 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Crude Scope)
*
***************************************************************/

namespace Server.Items
{
	public class CrudeScope : Item
	{
		public CrudeScope() : base()
		{
			Id = 4405;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 12;
			ReqLevel = 5;
			Name = "Crude Scope";
			Name2 = "Crude Scope";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 3974 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Standard Scope)
*
***************************************************************/

namespace Server.Items
{
	public class StandardScope : Item
	{
		public StandardScope() : base()
		{
			Id = 4406;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 22;
			ReqLevel = 10;
			Name = "Standard Scope";
			Name2 = "Standard Scope";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 3975 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Accurate Scope)
*
***************************************************************/

namespace Server.Items
{
	public class AccurateScope : Item
	{
		public AccurateScope() : base()
		{
			Id = 4407;
			SellPrice = 1200;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 36;
			ReqLevel = 20;
			Name = "Accurate Scope";
			Name2 = "Accurate Scope";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 3976 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ornate Spyglass)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateSpyglass : Item
	{
		public OrnateSpyglass() : base()
		{
			Id = 5507;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 7365;
			ObjectClass = 7;
			SubClass = 3;
			Level = 27;
			Name = "Ornate Spyglass";
			Name2 = "Ornate Spyglass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 12883 , 0 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Aquadynamic Fish Attractor)
*
***************************************************************/

namespace Server.Items
{
	public class AquadynamicFishAttractor : Item
	{
		public AquadynamicFishAttractor() : base()
		{
			Id = 6533;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 12425;
			ObjectClass = 7;
			SubClass = 3;
			Level = 30;
			Name = "Aquadynamic Fish Attractor";
			Name2 = "Aquadynamic Fish Attractor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 356;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 8089 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ruined Jumper Cables)
*
***************************************************************/

namespace Server.Items
{
	public class RuinedJumperCables : Item
	{
		public RuinedJumperCables() : base()
		{
			Id = 6715;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 7064;
			ObjectClass = 7;
			SubClass = 3;
			Level = 33;
			Name = "Ruined Jumper Cables";
			Name2 = "Ruined Jumper Cables";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 85;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Goblin Jumper Cables)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinJumperCables : Item
	{
		public GoblinJumperCables() : base()
		{
			Id = 7148;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 31201;
			ObjectClass = 7;
			SubClass = 3;
			Level = 33;
			Name = "Goblin Jumper Cables";
			Name2 = "Goblin Jumper Cables";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 165;
			Skill = 202;
			BuyPrice = 85;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 8342 , 0 , 0 , 0 , 1051 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Universal Remote)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishUniversalRemote : Item
	{
		public GnomishUniversalRemote() : base()
		{
			Id = 7506;
			Bonding = 2;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 15150;
			ObjectClass = 7;
			SubClass = 3;
			Level = 25;
			Name = "Gnomish Universal Remote";
			Name2 = "Gnomish Universal Remote";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 125;
			Skill = 202;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 8344 , 0 , 0 , 180000 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Deadly Scope)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyScope : Item
	{
		public DeadlyScope() : base()
		{
			Id = 10546;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 42;
			ReqLevel = 30;
			Name = "Deadly Scope";
			Name2 = "Deadly Scope";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 12459 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sniper Scope)
*
***************************************************************/

namespace Server.Items
{
	public class SniperScope : Item
	{
		public SniperScope() : base()
		{
			Id = 10548;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 48;
			ReqLevel = 40;
			Name = "Sniper Scope";
			Name2 = "Sniper Scope";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 12460 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mithril Mechanical Dragonling)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilMechanicalDragonling : Item
	{
		public MithrilMechanicalDragonling() : base()
		{
			Id = 10576;
			Bonding = 2;
			SellPrice = 6000;
			AvailableClasses = 0x7FFF;
			Model = 21632;
			ObjectClass = 7;
			SubClass = 3;
			Level = 50;
			ReqLevel = 40;
			Name = "Mithril Mechanical Dragonling";
			Name2 = "Mithril Mechanical Dragonling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 202;
			BuyPrice = 24000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 23075 , 0 , 0 , 3600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Mortar)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinMortar : Item
	{
		public GoblinMortar() : base()
		{
			Id = 10577;
			Bonding = 2;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 7397;
			ObjectClass = 7;
			SubClass = 3;
			Level = 41;
			Name = "Goblin Mortar";
			Name2 = "Goblin Mortar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 13237 , 0 , 6 , 600000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Bomb Dispenser)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinBombDispenser : Item
	{
		public GoblinBombDispenser() : base()
		{
			Id = 10587;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 20627;
			ObjectClass = 7;
			SubClass = 3;
			Level = 46;
			Name = "Goblin Bomb Dispenser";
			Name2 = "Goblin Bomb Dispenser";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 230;
			Skill = 202;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 23134 , 0 , 0 , 1800000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Death Ray)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishDeathRay : Item
	{
		public GnomishDeathRay() : base()
		{
			Id = 10645;
			Bonding = 1;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Description = "Death or Serious Injury may result from use of this device.";
			Model = 20626;
			ObjectClass = 7;
			SubClass = 3;
			Level = 48;
			Name = "Gnomish Death Ray";
			Name2 = "Gnomish Death Ray";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 240;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 13278 , 0 , 0 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Shrink Ray)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishShrinkRay : Item
	{
		public GnomishShrinkRay() : base()
		{
			Id = 10716;
			Bonding = 2;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 20625;
			ObjectClass = 7;
			SubClass = 3;
			Level = 41;
			Name = "Gnomish Shrink Ray";
			Name2 = "Gnomish Shrink Ray";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 13006 , 0 , 0 , 300000 , 36 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Net-o-Matic Projector)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishNetOMaticProjector : Item
	{
		public GnomishNetOMaticProjector() : base()
		{
			Id = 10720;
			Bonding = 2;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 19662;
			ObjectClass = 7;
			SubClass = 3;
			Level = 42;
			Name = "Gnomish Net-o-Matic Projector";
			Name2 = "Gnomish Net-o-Matic Projector";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 210;
			Skill = 202;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 13120 , 0 , 0 , 600000 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Battle Chicken)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishBattleChicken : Item
	{
		public GnomishBattleChicken() : base()
		{
			Id = 10725;
			Bonding = 1;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 19666;
			ObjectClass = 7;
			SubClass = 3;
			Level = 46;
			Name = "Gnomish Battle Chicken";
			Name2 = "Gnomish Battle Chicken";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 230;
			Skill = 202;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 23133 , 0 , 0 , 1800000 , 94 , 0 );
		}
	}
}


/**************************************************************
*
*				(Goblin Dragon Gun)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinDragonGun : Item
	{
		public GoblinDragonGun() : base()
		{
			Id = 10727;
			Bonding = 1;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 20539;
			ObjectClass = 7;
			SubClass = 3;
			Level = 48;
			Name = "Goblin Dragon Gun";
			Name2 = "Goblin Dragon Gun";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 240;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 13183 , 0 , 0 , 300000 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Mechanical Repair Kit)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicalRepairKit : Item
	{
		public MechanicalRepairKit() : base()
		{
			Id = 11590;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 21556;
			ObjectClass = 7;
			SubClass = 3;
			Level = 40;
			Name = "Mechanical Repair Kit";
			Name2 = "Mechanical Repair Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 200;
			Skill = 202;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Flags = 64;
			SetSpell( 15057 , 0 , -1 , 0 , 30 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Pet Bombling)
*
***************************************************************/

namespace Server.Items
{
	public class PetBombling : Item
	{
		public PetBombling() : base()
		{
			Id = 11825;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 21833;
			ObjectClass = 7;
			SubClass = 3;
			Level = 30;
			Name = "Pet Bombling";
			Name2 = "Pet Bombling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 15048 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Lil' Smoky)
*
***************************************************************/

namespace Server.Items
{
	public class LilSmoky : Item
	{
		public LilSmoky() : base()
		{
			Id = 11826;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 9730;
			ObjectClass = 7;
			SubClass = 3;
			Level = 30;
			Name = "Lil' Smoky";
			Name2 = "Lil' Smoky";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 15049 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Salt Shaker)
*
***************************************************************/

namespace Server.Items
{
	public class SaltShaker : Item
	{
		public SaltShaker() : base()
		{
			Id = 15846;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 18632;
			ObjectClass = 7;
			SubClass = 3;
			Level = 50;
			Name = "Salt Shaker";
			Name2 = "Salt Shaker";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 165;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 1088;
			SetSpell( 19566 , 0 , 0 , 0 , 791 , 259200000 );
		}
	}
}


/**************************************************************
*
*				(Lifelike Mechanical Toad)
*
***************************************************************/

namespace Server.Items
{
	public class LifelikeMechanicalToad : Item
	{
		public LifelikeMechanicalToad() : base()
		{
			Id = 15996;
			Bonding = 3;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 26612;
			ObjectClass = 7;
			SubClass = 3;
			Level = 53;
			Name = "Lifelike Mechanical Toad";
			Name2 = "Lifelike Mechanical Toad";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 19772 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Arcanite Dragonling)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaniteDragonling : Item
	{
		public ArcaniteDragonling() : base()
		{
			Id = 16022;
			Bonding = 2;
			SellPrice = 40000;
			AvailableClasses = 0x7FFF;
			Model = 21632;
			ObjectClass = 7;
			SubClass = 3;
			Level = 60;
			ReqLevel = 50;
			Name = "Arcanite Dragonling";
			Name2 = "Arcanite Dragonling";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 202;
			BuyPrice = 160000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 23074 , 0 , 0 , 3600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Masterwork Target Dummy)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkTargetDummy : Item
	{
		public MasterworkTargetDummy() : base()
		{
			Id = 16023;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 26631;
			ObjectClass = 7;
			SubClass = 3;
			Level = 55;
			Name = "Masterwork Target Dummy";
			Name2 = "Masterwork Target Dummy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 202;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			SetSpell( 19805 , 0 , -1 , 0 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(SnowMaster 9000)
*
***************************************************************/

namespace Server.Items
{
	public class SnowMaster9000 : Item
	{
		public SnowMaster9000() : base()
		{
			Id = 17716;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Model = 29895;
			ObjectClass = 7;
			SubClass = 3;
			Level = 38;
			Name = "SnowMaster 9000";
			Name2 = "SnowMaster 9000";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 190;
			Skill = 202;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 1088;
			SetSpell( 21935 , 0 , 0 , 0 , 991 , 86400000 );
		}
	}
}


/**************************************************************
*
*				(Field Repair Bot 74A)
*
***************************************************************/

namespace Server.Items
{
	public class FieldRepairBot74A : Item
	{
		public FieldRepairBot74A() : base()
		{
			Id = 18232;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 19503;
			ObjectClass = 7;
			SubClass = 3;
			Level = 60;
			Name = "Field Repair Bot 74A";
			Name2 = "Field Repair Bot 74A";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 202;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 22700 , 0 , -1 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Biznicks 247x128 Accurascope)
*
***************************************************************/

namespace Server.Items
{
	public class Biznicks247x128Accurascope : Item
	{
		public Biznicks247x128Accurascope() : base()
		{
			Id = 18283;
			SellPrice = 25000;
			AvailableClasses = 0x7FFF;
			Model = 7326;
			ObjectClass = 7;
			SubClass = 3;
			Level = 60;
			ReqLevel = 50;
			Name = "Biznicks 247x128 Accurascope";
			Name2 = "Biznicks 247x128 Accurascope";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 8;
			Flags = 64;
			SetSpell( 22779 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Goblin Jumper Cables XL)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinJumperCablesXL : Item
	{
		public GoblinJumperCablesXL() : base()
		{
			Id = 18587;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 31203;
			ObjectClass = 7;
			SubClass = 3;
			Level = 53;
			Name = "Goblin Jumper Cables XL";
			Name2 = "Goblin Jumper Cables XL";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 265;
			Skill = 202;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 22999 , 0 , 0 , 0 , 1051 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Gyrofreeze Ice Reflector)
*
***************************************************************/

namespace Server.Items
{
	public class GyrofreezeIceReflector : Item
	{
		public GyrofreezeIceReflector() : base()
		{
			Id = 18634;
			Bonding = 2;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31199;
			Resistance[4] = 15;
			ObjectClass = 7;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Gyrofreeze Ice Reflector";
			Name2 = "Gyrofreeze Ice Reflector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 260;
			Skill = 202;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 23131 , 0 , 0 , 300000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Ruined Jumper Cables XL)
*
***************************************************************/

namespace Server.Items
{
	public class RuinedJumperCablesXL : Item
	{
		public RuinedJumperCablesXL() : base()
		{
			Id = 18636;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 7064;
			ObjectClass = 7;
			SubClass = 3;
			Level = 53;
			Name = "Ruined Jumper Cables XL";
			Name2 = "Ruined Jumper Cables XL";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Major Recombobulator)
*
***************************************************************/

namespace Server.Items
{
	public class MajorRecombobulator : Item
	{
		public MajorRecombobulator() : base()
		{
			Id = 18637;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 31204;
			ObjectClass = 7;
			SubClass = 3;
			Level = 55;
			Name = "Major Recombobulator";
			Name2 = "Major Recombobulator";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 275;
			Skill = 202;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 23064 , 0 , -10 , 300000 , 28 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Hyper-Radiant Flame Reflector)
*
***************************************************************/

namespace Server.Items
{
	public class HyperRadiantFlameReflector : Item
	{
		public HyperRadiantFlameReflector() : base()
		{
			Id = 18638;
			Bonding = 2;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31198;
			Resistance[2] = 18;
			ObjectClass = 7;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Hyper-Radiant Flame Reflector";
			Name2 = "Hyper-Radiant Flame Reflector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 290;
			Skill = 202;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 23097 , 0 , 0 , 300000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Ultra-Flash Shadow Reflector)
*
***************************************************************/

namespace Server.Items
{
	public class UltraFlashShadowReflector : Item
	{
		public UltraFlashShadowReflector() : base()
		{
			Id = 18639;
			Bonding = 2;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31200;
			ObjectClass = 7;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Ultra-Flash Shadow Reflector";
			Name2 = "Ultra-Flash Shadow Reflector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 202;
			BuyPrice = 50000;
			Resistance[5] = 20;
			InventoryType = InventoryTypes.Trinket1;
			Stackable = 1;
			Material = 8;
			SetSpell( 23132 , 0 , 0 , 300000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Alarm-O-Bot)
*
***************************************************************/

namespace Server.Items
{
	public class AlarmOBot : Item
	{
		public AlarmOBot() : base()
		{
			Id = 18645;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 31202;
			ObjectClass = 7;
			SubClass = 3;
			Level = 53;
			Name = "Alarm-O-Bot";
			Name2 = "Alarm-O-Bot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 265;
			Skill = 202;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 23004 , 0 , -1 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(World Enlarger)
*
***************************************************************/

namespace Server.Items
{
	public class WorldEnlarger : Item
	{
		public WorldEnlarger() : base()
		{
			Id = 18660;
			SellPrice = 7500;
			AvailableClasses = 0x7FFF;
			Description = "Only Gnomish Technology could invent a device that affects the entire world!";
			Model = 31205;
			ObjectClass = 7;
			SubClass = 3;
			Level = 50;
			Name = "World Enlarger";
			Name2 = "World Enlarger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 250;
			Skill = 202;
			SpellReq = 20219;
			BuyPrice = 30000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 1088;
			SetSpell( 23126 , 0 , 0 , 3600000 , 0 , 0 );
		}
	}
}


