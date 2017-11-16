//	Script modified by kolkoo - 07/05/05 10:56:43
 //	Script made by kolkoo - 06/05/05 13:13:34
using System;
using Server.Items;
using HelperTools;

namespace Server
{

	
	//	Object: Chest of the Sky	
	//Found in Zones:
	//# Teldrassil
	//Known Drops:
	//Sapphire of Sky	100.00%	(2871 in 2871
	//Taken from wow.allakhazam.com
	public class ChestofSky : BaseChest
	{
		public ChestofSky()
		{
			DefaultModel = 2741;
			BaseTreasure tempTreasure = new BaseTreasure( new Loot[] { new Loot( typeof( SapphireOfSky ), 100.0f ) }, 100.0f );
			Loots = new BaseTreasure[] { tempTreasure };
			Charge = 1;//	one use before vanishing
		}
		public override bool OnUse( Mobile from )
		{
			return base.OnUse( from );
		}

		public override bool OnRelease( Mobile from )
		{
			return base.OnRelease( from );
		}
	}
} 