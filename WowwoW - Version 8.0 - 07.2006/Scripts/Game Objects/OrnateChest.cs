//	Script made by kolkoo - 06/07/05 15:16:39

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class OrnateChest : BaseChest
	{
		public OrnateChest()
		{
			DefaultModel = 164910;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( GoldenFlame ), 91.60f)
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