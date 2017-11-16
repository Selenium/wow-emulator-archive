//	Script made by kolkoo - 06/07/05 15:15:11

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class MarvonsChest : BaseChest
	{
		public MarvonsChest()
		{
			DefaultModel = 149036;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( StoneCircle ), 89.59f)
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