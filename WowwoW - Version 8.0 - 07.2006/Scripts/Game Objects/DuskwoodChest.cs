//	Script made by kolkoo - 06/07/05 15:13:14

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class DuskwoodChest : BaseChest
	{
		public DuskwoodChest()
		{
			DefaultModel = 123214;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( KlavenMortwakesJournal	 ), 100.00f)
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