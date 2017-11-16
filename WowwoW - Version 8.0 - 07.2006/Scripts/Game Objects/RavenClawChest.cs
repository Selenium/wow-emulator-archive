//	Script made by kolkoo - 06/07/05 15:18:02

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class RavenClawChest : BaseChest
	{
		public RavenClawChest()
		{
			DefaultModel = 2740;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							
							   new Loot( typeof( RavenClawTalisman	 ), 99.98f)
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