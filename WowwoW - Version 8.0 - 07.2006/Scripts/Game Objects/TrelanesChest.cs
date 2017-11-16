//	Script made by kolkoo - 06/07/05 15:19:25

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class TrelanesChest : BaseChest
	{
		public TrelanesChest()
		{
			DefaultModel = 2716;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( TrelanesOrb ), 99.94f)
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