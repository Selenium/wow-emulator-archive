//	Script modified by kolkoo - 07/05/05 10:57:27
 //	Script made by kolkoo - 06/05/05 13:22:07
using System;
using Server.Items;
using HelperTools;

namespace Server
{

	
	
	//	Object: Alexston's Chest	
	//Found in Zones:
	//# Westfall - (View Map)
	//Known Drops:
	//A Simple Compass	100.00%	(1843 in 1843)
	//Taken from wow.allakhazam.com
	public class AlexstonChest : BaseChest
	{
		public AlexstonChest()
		{
			DefaultModel = 1166;
			BaseTreasure tempTreasure = new BaseTreasure( new Loot[] { new Loot( typeof( ASimpleCompass ), 100.0f ) }, 100.0f );
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