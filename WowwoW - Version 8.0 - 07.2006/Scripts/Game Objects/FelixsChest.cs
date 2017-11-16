//	Script made by kolkoo - 06/07/05 15:13:37

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class FelixsChest : BaseChest
	{
		public FelixsChest()
		{
			DefaultModel = 178084;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( FelixsChest ), 99.90f)
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