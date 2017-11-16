/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:26 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Light Plate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateBracers : Item
	{
		public LightPlateBracers() : base()
		{
			Id = 8083;
			Resistance[0] = 199;
			SellPrice = 2261;
			AvailableClasses = 0x7FFF;
			Model = 9388;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Light Plate Bracers";
			Name2 = "Light Plate Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 11308;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Platemail Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailBracers : Item
	{
		public PlatemailBracers() : base()
		{
			Id = 8090;
			Resistance[0] = 200;
			SellPrice = 2687;
			AvailableClasses = 0x7FFF;
			Model = 25829;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Bracers";
			Name2 = "Platemail Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13439;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Chromite Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteBracers : Item
	{
		public ChromiteBracers() : base()
		{
			Id = 8137;
			Resistance[0] = 167;
			Bonding = 2;
			SellPrice = 2807;
			AvailableClasses = 0x7FFF;
			Model = 27329;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Chromite Bracers";
			Name2 = "Chromite Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14035;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 8;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Jouster's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersWristguards : Item
	{
		public JoustersWristguards() : base()
		{
			Id = 8156;
			Resistance[0] = 116;
			Bonding = 2;
			SellPrice = 2219;
			AvailableClasses = 0x7FFF;
			Model = 27345;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Jouster's Wristguards";
			Name2 = "Jouster's Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11099;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 8;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Valorous Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousWristguards : Item
	{
		public ValorousWristguards() : base()
		{
			Id = 8273;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 3574;
			AvailableClasses = 0x7FFF;
			Model = 27373;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Valorous Wristguards";
			Name2 = "Valorous Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17871;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateVambraces : Item
	{
		public AlabasterPlateVambraces() : base()
		{
			Id = 8311;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 5844;
			AvailableClasses = 0x7FFF;
			Model = 27394;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Alabaster Plate Vambraces";
			Name2 = "Alabaster Plate Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29224;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 3;
			StaminaBonus = 12;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Field Plate Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateVambraces : Item
	{
		public FieldPlateVambraces() : base()
		{
			Id = 9285;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 2388;
			AvailableClasses = 0x7FFF;
			Model = 27362;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Field Plate Vambraces";
			Name2 = "Field Plate Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1115;
			BuyPrice = 11943;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Skullplate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SkullplateBracers : Item
	{
		public SkullplateBracers() : base()
		{
			Id = 9432;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 3027;
			AvailableClasses = 0x7FFF;
			Model = 18378;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Skullplate Bracers";
			Name2 = "Skullplate Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15135;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 9;
			StrBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateBracers : Item
	{
		public EmbossedPlateBracers() : base()
		{
			Id = 9972;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 2475;
			AvailableClasses = 0x7FFF;
			Model = 27350;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Embossed Plate Bracers";
			Name2 = "Embossed Plate Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1115;
			BuyPrice = 12378;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateVambraces : Item
	{
		public GothicPlateVambraces() : base()
		{
			Id = 10094;
			Resistance[0] = 191;
			Bonding = 2;
			SellPrice = 3311;
			AvailableClasses = 0x7FFF;
			Model = 27368;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Gothic Plate Vambraces";
			Name2 = "Gothic Plate Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1116;
			BuyPrice = 16557;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Revenant Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantBracers : Item
	{
		public RevenantBracers() : base()
		{
			Id = 10127;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 4350;
			AvailableClasses = 0x7FFF;
			Model = 27426;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Revenant Bracers";
			Name2 = "Revenant Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1118;
			BuyPrice = 21752;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Templar Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarBracers : Item
	{
		public TemplarBracers() : base()
		{
			Id = 10171;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 6018;
			AvailableClasses = 0x7FFF;
			Model = 27406;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Templar Bracers";
			Name2 = "Templar Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1119;
			BuyPrice = 30090;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Overlord's Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsVambraces : Item
	{
		public OverlordsVambraces() : base()
		{
			Id = 10202;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 3988;
			AvailableClasses = 0x7FFF;
			Model = 27402;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Overlord's Vambraces";
			Name2 = "Overlord's Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1117;
			BuyPrice = 19943;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarVambraces : Item
	{
		public HeavyLamellarVambraces() : base()
		{
			Id = 10239;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 4962;
			AvailableClasses = 0x7FFF;
			Model = 27385;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Heavy Lamellar Vambraces";
			Name2 = "Heavy Lamellar Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1118;
			BuyPrice = 24811;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Emerald Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldVambraces : Item
	{
		public EmeraldVambraces() : base()
		{
			Id = 10282;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 6712;
			AvailableClasses = 0x7FFF;
			Model = 27420;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Emerald Vambraces";
			Name2 = "Emerald Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1120;
			BuyPrice = 33561;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateVambraces : Item
	{
		public ImbuedPlateVambraces() : base()
		{
			Id = 10375;
			Resistance[0] = 237;
			Bonding = 2;
			SellPrice = 7116;
			AvailableClasses = 0x7FFF;
			Model = 26363;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Imbued Plate Vambraces";
			Name2 = "Imbued Plate Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35582;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 12;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Commander's Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersVambraces : Item
	{
		public CommandersVambraces() : base()
		{
			Id = 10377;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 7978;
			AvailableClasses = 0x7FFF;
			Model = 26362;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Commander's Vambraces";
			Name2 = "Commander's Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1121;
			BuyPrice = 39891;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Hyperion Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionVambraces : Item
	{
		public HyperionVambraces() : base()
		{
			Id = 10391;
			Resistance[0] = 249;
			Bonding = 2;
			SellPrice = 8193;
			AvailableClasses = 0x7FFF;
			Model = 26360;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Hyperion Vambraces";
			Name2 = "Hyperion Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1121;
			BuyPrice = 40966;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Runesteel Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class RunesteelVambraces : Item
	{
		public RunesteelVambraces() : base()
		{
			Id = 10746;
			Resistance[0] = 210;
			Bonding = 1;
			SellPrice = 4549;
			AvailableClasses = 0x7FFF;
			Model = 28343;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			Name = "Runesteel Vambraces";
			Name2 = "Runesteel Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22748;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 2;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Emberplate Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class EmberplateArmguards : Item
	{
		public EmberplateArmguards() : base()
		{
			Id = 11767;
			Resistance[0] = 261;
			Bonding = 1;
			SellPrice = 8637;
			AvailableClasses = 0x7FFF;
			Model = 21754;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Emberplate Armguards";
			Name2 = "Emberplate Armguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1122;
			BuyPrice = 43188;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Thorium Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumBracers : Item
	{
		public ThoriumBracers() : base()
		{
			Id = 12408;
			Resistance[6] = 5;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 4998;
			AvailableClasses = 0x7FFF;
			Model = 25753;
			Resistance[2] = 5;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Thorium Bracers";
			Name2 = "Thorium Bracers";
			Resistance[3] = 5;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24991;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateBracers : Item
	{
		public ImperialPlateBracers() : base()
		{
			Id = 12425;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 6044;
			AvailableClasses = 0x7FFF;
			Model = 24511;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Imperial Plate Bracers";
			Name2 = "Imperial Plate Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30221;
			Sets = 321;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 9;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Runed Golem Shackles)
*
***************************************************************/

namespace Server.Items
{
	public class RunedGolemShackles : Item
	{
		public RunedGolemShackles() : base()
		{
			Id = 12550;
			Resistance[0] = 244;
			Bonding = 2;
			SellPrice = 6464;
			AvailableClasses = 0x7FFF;
			Model = 28824;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Runed Golem Shackles";
			Name2 = "Runed Golem Shackles";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32324;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7517 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Jade Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class JadeBracers : Item
	{
		public JadeBracers() : base()
		{
			Id = 12866;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 3590;
			AvailableClasses = 0x7FFF;
			Model = 26794;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Jade Bracers";
			Name2 = "Jade Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1117;
			BuyPrice = 17950;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Battleborn Armbraces)
*
***************************************************************/

namespace Server.Items
{
	public class BattlebornArmbraces : Item
	{
		public BattlebornArmbraces() : base()
		{
			Id = 12936;
			Resistance[0] = 287;
			Bonding = 1;
			SellPrice = 11640;
			AvailableClasses = 0x7FFF;
			Model = 22752;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Battleborn Armbraces";
			Name2 = "Battleborn Armbraces";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58203;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Giantslayer Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GiantslayerBracers : Item
	{
		public GiantslayerBracers() : base()
		{
			Id = 13076;
			Resistance[0] = 223;
			Bonding = 2;
			SellPrice = 4715;
			AvailableClasses = 0x7FFF;
			Model = 28357;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Giantslayer Bracers";
			Name2 = "Giantslayer Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23579;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 10;
			AgilityBonus = 5;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Vambraces of the Sadist)
*
***************************************************************/

namespace Server.Items
{
	public class VambracesOfTheSadist : Item
	{
		public VambracesOfTheSadist() : base()
		{
			Id = 13400;
			Resistance[0] = 270;
			Bonding = 1;
			SellPrice = 9296;
			AvailableClasses = 0x7FFF;
			Model = 24110;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Vambraces of the Sadist";
			Name2 = "Vambraces of the Sadist";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46482;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Vigorsteel Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class VigorsteelVambraces : Item
	{
		public VigorsteelVambraces() : base()
		{
			Id = 13951;
			Resistance[0] = 283;
			Bonding = 1;
			SellPrice = 11005;
			AvailableClasses = 0x7FFF;
			Model = 24749;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Vigorsteel Vambraces";
			Name2 = "Vigorsteel Vambraces";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55026;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 17;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Symbolic Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicVambraces : Item
	{
		public SymbolicVambraces() : base()
		{
			Id = 14832;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 2363;
			AvailableClasses = 0x7FFF;
			Model = 26815;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Symbolic Vambraces";
			Name2 = "Symbolic Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11819;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsArmguards : Item
	{
		public TyrantsArmguards() : base()
		{
			Id = 14834;
			Resistance[0] = 167;
			Bonding = 2;
			SellPrice = 2777;
			AvailableClasses = 0x7FFF;
			Model = 26685;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Tyrant's Armguards";
			Name2 = "Tyrant's Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13889;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 7;
			IqBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sunscale Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleWristguards : Item
	{
		public SunscaleWristguards() : base()
		{
			Id = 14853;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 4174;
			AvailableClasses = 0x7FFF;
			Model = 26821;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Sunscale Wristguards";
			Name2 = "Sunscale Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20870;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 8;
			StrBonus = 6;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Vanguard Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardVambraces : Item
	{
		public VanguardVambraces() : base()
		{
			Id = 14861;
			Resistance[0] = 218;
			Bonding = 2;
			SellPrice = 5045;
			AvailableClasses = 0x7FFF;
			Model = 19760;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Vanguard Vambraces";
			Name2 = "Vanguard Vambraces";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25227;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			IqBonus = 4;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Warleader's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersBracers : Item
	{
		public WarleadersBracers() : base()
		{
			Id = 14869;
			Resistance[0] = 241;
			Bonding = 2;
			SellPrice = 7577;
			AvailableClasses = 0x7FFF;
			Model = 26878;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Warleader's Bracers";
			Name2 = "Warleader's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37886;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 13;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Saltstone Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneArmsplints : Item
	{
		public SaltstoneArmsplints() : base()
		{
			Id = 14903;
			Resistance[0] = 116;
			Bonding = 2;
			SellPrice = 2173;
			AvailableClasses = 0x7FFF;
			Model = 26646;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Saltstone Armsplints";
			Name2 = "Saltstone Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1115;
			BuyPrice = 10866;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Brutish Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishArmguards : Item
	{
		public BrutishArmguards() : base()
		{
			Id = 14910;
			Resistance[0] = 187;
			Bonding = 2;
			SellPrice = 3033;
			AvailableClasses = 0x7FFF;
			Model = 27903;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Brutish Armguards";
			Name2 = "Brutish Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1116;
			BuyPrice = 15168;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Jade Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class JadeBracers14914 : Item
	{
		public JadeBracers14914() : base()
		{
			Id = 14914;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 3590;
			AvailableClasses = 0x7FFF;
			Model = 26794;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Jade Bracers";
			Name2 = "Jade Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1117;
			BuyPrice = 17950;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Lofty Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyArmguards : Item
	{
		public LoftyArmguards() : base()
		{
			Id = 14923;
			Resistance[0] = 210;
			Bonding = 2;
			SellPrice = 4604;
			AvailableClasses = 0x7FFF;
			Model = 26869;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Lofty Armguards";
			Name2 = "Lofty Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1118;
			BuyPrice = 23024;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heroic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicBracers : Item
	{
		public HeroicBracers() : base()
		{
			Id = 14938;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 6470;
			AvailableClasses = 0x7FFF;
			Model = 27933;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Heroic Bracers";
			Name2 = "Heroic Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1120;
			BuyPrice = 32350;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersArmsplints : Item
	{
		public WarbringersArmsplints() : base()
		{
			Id = 14941;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 2515;
			AvailableClasses = 0x7FFF;
			Model = 26454;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Warbringer's Armsplints";
			Name2 = "Warbringer's Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1115;
			BuyPrice = 12576;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedBindings : Item
	{
		public BloodforgedBindings() : base()
		{
			Id = 14956;
			Resistance[0] = 191;
			Bonding = 2;
			SellPrice = 3108;
			AvailableClasses = 0x7FFF;
			Model = 26837;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Bloodforged Bindings";
			Name2 = "Bloodforged Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1116;
			BuyPrice = 15543;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(High Chief's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsBindings : Item
	{
		public HighChiefsBindings() : base()
		{
			Id = 14965;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 4450;
			AvailableClasses = 0x7FFF;
			Model = 26829;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "High Chief's Bindings";
			Name2 = "High Chief's Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1118;
			BuyPrice = 22252;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Glorious Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousBindings : Item
	{
		public GloriousBindings() : base()
		{
			Id = 14974;
			Resistance[0] = 229;
			Bonding = 2;
			SellPrice = 6009;
			AvailableClasses = 0x7FFF;
			Model = 26857;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Glorious Bindings";
			Name2 = "Glorious Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1120;
			BuyPrice = 30045;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Exalted Armsplints)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedArmsplints : Item
	{
		public ExaltedArmsplints() : base()
		{
			Id = 14983;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 7985;
			AvailableClasses = 0x7FFF;
			Model = 26887;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Exalted Armsplints";
			Name2 = "Exalted Armsplints";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1121;
			BuyPrice = 39927;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Shining Armplates)
*
***************************************************************/

namespace Server.Items
{
	public class ShiningArmplates : Item
	{
		public ShiningArmplates() : base()
		{
			Id = 15797;
			Resistance[0] = 245;
			Bonding = 1;
			SellPrice = 7530;
			AvailableClasses = 0x7FFF;
			Model = 26476;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			Name = "Shining Armplates";
			Name2 = "Shining Armplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37653;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 13;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Blinkstrike Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class BlinkstrikeArmguards : Item
	{
		public BlinkstrikeArmguards() : base()
		{
			Id = 15860;
			Resistance[0] = 249;
			Bonding = 1;
			SellPrice = 7907;
			AvailableClasses = 0x7FFF;
			Model = 26542;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			Name = "Blinkstrike Armguards";
			Name2 = "Blinkstrike Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39535;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lightforge Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeBracers : Item
	{
		public LightforgeBracers() : base()
		{
			Id = 16722;
			Resistance[0] = 261;
			Bonding = 2;
			SellPrice = 8105;
			AvailableClasses = 0x7FFF;
			Model = 29968;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Lightforge Bracers";
			Name2 = "Lightforge Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40528;
			Sets = 188;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 10;
			IqBonus = 8;
			StrBonus = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bracers of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfValor : Item
	{
		public BracersOfValor() : base()
		{
			Id = 16735;
			Resistance[0] = 261;
			Bonding = 2;
			SellPrice = 8738;
			AvailableClasses = 0x7FFF;
			Model = 29961;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Bracers of Valor";
			Name2 = "Bracers of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43690;
			Sets = 189;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 14;
			StrBonus = 7;
			AgilityBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerBracers : Item
	{
		public LawbringerBracers() : base()
		{
			Id = 16857;
			Resistance[0] = 328;
			Bonding = 2;
			SellPrice = 17054;
			AvailableClasses = 0x02;
			Model = 31509;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Bracers";
			Name2 = "Lawbringer Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85270;
			Sets = 208;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			IqBonus = 11;
			StaminaBonus = 11;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bracers of Might)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfMight : Item
	{
		public BracersOfMight() : base()
		{
			Id = 16861;
			Resistance[0] = 328;
			Bonding = 2;
			SellPrice = 17786;
			AvailableClasses = 0x01;
			Model = 31020;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Bracers of Might";
			Name2 = "Bracers of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88932;
			Sets = 209;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 23;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Judgement Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementBindings : Item
	{
		public JudgementBindings() : base()
		{
			Id = 16951;
			Resistance[0] = 375;
			Bonding = 1;
			SellPrice = 27889;
			AvailableClasses = 0x02;
			Model = 29876;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Bindings";
			Name2 = "Judgement Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139446;
			Sets = 217;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SpiritBonus = 13;
			IqBonus = 9;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Bracelets of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class BraceletsOfWrath : Item
	{
		public BraceletsOfWrath() : base()
		{
			Id = 16959;
			Resistance[0] = 375;
			Bonding = 1;
			SellPrice = 29507;
			AvailableClasses = 0x01;
			Model = 29859;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Bracelets of Wrath";
			Name2 = "Bracelets of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 147539;
			Sets = 218;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 27;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronBracers : Item
	{
		public DarkIronBracers() : base()
		{
			Id = 17014;
			Resistance[0] = 394;
			Bonding = 2;
			SellPrice = 12637;
			AvailableClasses = 0x7FFF;
			Model = 28844;
			Resistance[2] = 18;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Dark Iron Bracers";
			Name2 = "Dark Iron Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 63189;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Noxxion's Shackles)
*
***************************************************************/

namespace Server.Items
{
	public class NoxxionsShackles : Item
	{
		public NoxxionsShackles() : base()
		{
			Id = 17746;
			Resistance[0] = 235;
			Bonding = 1;
			SellPrice = 5723;
			AvailableClasses = 0x7FFF;
			Model = 29925;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Noxxion's Shackles";
			Name2 = "Noxxion's Shackles";
			Resistance[3] = 15;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28618;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Magically Sealed Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MagicallySealedBracers : Item
	{
		public MagicallySealedBracers() : base()
		{
			Id = 18351;
			Resistance[0] = 383;
			Bonding = 1;
			SellPrice = 8740;
			AvailableClasses = 0x7FFF;
			Model = 30704;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Magically Sealed Bracers";
			Name2 = "Magically Sealed Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43702;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 7516 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Plate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsPlateBracers : Item
	{
		public FirstSergeantsPlateBracers() : base()
		{
			Id = 18429;
			Resistance[0] = 287;
			Bonding = 1;
			SellPrice = 5889;
			AvailableClasses = 0x01;
			Model = 27273;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "First Sergeant's Plate Bracers";
			Name2 = "First Sergeant's Plate Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29447;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			StaminaBonus = 17;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Plate Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsPlateBracers18430 : Item
	{
		public FirstSergeantsPlateBracers18430() : base()
		{
			Id = 18430;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 2878;
			AvailableClasses = 0x01;
			Model = 27273;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "First Sergeant's Plate Bracers";
			Name2 = "First Sergeant's Plate Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14391;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			StaminaBonus = 14;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Plate Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsPlateWristguards : Item
	{
		public SergeantMajorsPlateWristguards() : base()
		{
			Id = 18445;
			Resistance[0] = 287;
			Bonding = 1;
			SellPrice = 5804;
			AvailableClasses = 0x03;
			Model = 27223;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant Major's Plate Wristguards";
			Name2 = "Sergeant Major's Plate Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29021;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			StaminaBonus = 17;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Plate Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsPlateWristguards18447 : Item
	{
		public SergeantMajorsPlateWristguards18447() : base()
		{
			Id = 18447;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 2847;
			AvailableClasses = 0x03;
			Model = 27223;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant Major's Plate Wristguards";
			Name2 = "Sergeant Major's Plate Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14235;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			StaminaBonus = 14;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Gallant's Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class GallantsWristguards : Item
	{
		public GallantsWristguards() : base()
		{
			Id = 18459;
			Resistance[0] = 249;
			Bonding = 1;
			SellPrice = 7907;
			AvailableClasses = 0x7FFF;
			Model = 30807;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Gallant's Wristguards";
			Name2 = "Gallant's Wristguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39536;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 9316 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Gordok Bracers of Power)
*
***************************************************************/

namespace Server.Items
{
	public class GordokBracersOfPower : Item
	{
		public GordokBracersOfPower() : base()
		{
			Id = 18533;
			Resistance[0] = 287;
			Bonding = 1;
			SellPrice = 10984;
			AvailableClasses = 0x7FFF;
			Model = 30869;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Gordok Bracers of Power";
			Name2 = "Gordok Bracers of Power";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54922;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 17;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Arena Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class ArenaVambraces : Item
	{
		public ArenaVambraces() : base()
		{
			Id = 18712;
			Resistance[0] = 371;
			Bonding = 2;
			SellPrice = 5821;
			AvailableClasses = 0x7FFF;
			Model = 31161;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Arena Vambraces";
			Name2 = "Arena Vambraces";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29105;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Morlune's Bracer)
*
***************************************************************/

namespace Server.Items
{
	public class MorlunesBracer : Item
	{
		public MorlunesBracer() : base()
		{
			Id = 18741;
			Resistance[0] = 279;
			Bonding = 1;
			SellPrice = 9963;
			AvailableClasses = 0x7FFF;
			Model = 31193;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Morlune's Bracer";
			Name2 = "Morlune's Bracer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49816;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SpiritBonus = 12;
			IqBonus = 11;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Fel Hardened Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FelHardenedBracers : Item
	{
		public FelHardenedBracers() : base()
		{
			Id = 18754;
			Resistance[0] = 283;
			Bonding = 1;
			SellPrice = 10461;
			AvailableClasses = 0x7FFF;
			Model = 31213;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Fel Hardened Bracers";
			Name2 = "Fel Hardened Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52306;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7516 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Frozen Steel Vambraces)
*
***************************************************************/

namespace Server.Items
{
	public class FrozenSteelVambraces : Item
	{
		public FrozenSteelVambraces() : base()
		{
			Id = 19112;
			Resistance[0] = 287;
			Bonding = 1;
			SellPrice = 10984;
			AvailableClasses = 0x7FFF;
			Model = 31619;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Frozen Steel Vambraces";
			Name2 = "Frozen Steel Vambraces";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54922;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			AgilityBonus = 11;
			StaminaBonus = 7;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Berserker Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BerserkerBracers : Item
	{
		public BerserkerBracers() : base()
		{
			Id = 19578;
			Resistance[0] = 323;
			Bonding = 1;
			SellPrice = 17699;
			AvailableClasses = 0x7FFF;
			Model = 32088;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Berserker Bracers";
			Name2 = "Berserker Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88497;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			StrBonus = 19;
			AgilityBonus = 8;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Berserker Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BerserkerBracers19580 : Item
	{
		public BerserkerBracers19580() : base()
		{
			Id = 19580;
			Resistance[0] = 275;
			Bonding = 1;
			SellPrice = 9635;
			AvailableClasses = 0x7FFF;
			Model = 32088;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Berserker Bracers";
			Name2 = "Berserker Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 48175;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			StrBonus = 17;
			AgilityBonus = 7;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Berserker Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BerserkerBracers19581 : Item
	{
		public BerserkerBracers19581() : base()
		{
			Id = 19581;
			Resistance[0] = 229;
			Bonding = 1;
			SellPrice = 4945;
			AvailableClasses = 0x7FFF;
			Model = 32088;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Berserker Bracers";
			Name2 = "Berserker Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 24727;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			StrBonus = 14;
			AgilityBonus = 6;
			StaminaBonus = 8;
		}
	}
}


