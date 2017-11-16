//	Script made by kolkoo - 06/07/05 15:19:09

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class SunkenChest : BaseChest
	{
		public SunkenChest()
		{
			DefaultModel = 32;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( OslowsToolbox ), 99.97f),
							   new Loot( typeof( ClamMeat ), 0.02f)
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