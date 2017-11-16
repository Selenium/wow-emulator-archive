//	Script made by kolkoo - 06/07/05 15:18:46

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class StorageChest : BaseChest
	{
		public StorageChest()
		{
			DefaultModel = 1560;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( AnUndeliveredLetter ), 99.91f)
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