//	Script modified by kolkoo - 09/05/05 18:38:39
 //	Script made by kolkoo - 09/05/05 18:25:26
using System;
using Server.Items;
using HelperTools;

namespace Server
{

	
	
	//Object: Rusty Chest	
	//Found in Zones:
	//# Ashenvale 
	//# The Barrens
	//Known Drops:
	//Wool Cloth	24.46%	(2073 in 8474)
	//Silk Cloth	9.70%	(822 in 8474)
	//Iron Pommel	13.09%	(1109 in 8474)
	//Practice Lock	5.26%	(446 in 8474)
	//Broken Lock	29.89%	(2533 in 8474)
	//Padded Lining	30.52%	(2586 in 8474)
	//Taken from wow.allakhazam.com
	public class RustyChest : BaseChest
	{
		public RustyChest()
		{
			DefaultModel = 19021;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( WoolCloth ), 24.46f ), 
							   new Loot( typeof( SilkCloth ), 9.70f ), 
							   new Loot( typeof( IronPommel ), 13.09f ),
							   new Loot( typeof( PracticeLock ), 5.26f ),
							   new Loot( typeof( BrokenLock ), 29.89f ),
							   new Loot( typeof( PaddedLining ), 30.52f)
						   },
				100.0f );
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