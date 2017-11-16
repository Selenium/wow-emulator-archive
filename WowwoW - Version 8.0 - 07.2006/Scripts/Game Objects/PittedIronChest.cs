//	Script made by kolkoo - 06/07/05 15:17:42

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class PittedIronChest : BaseChest
	{
		public PittedIronChest()
		{
			DefaultModel = 13949;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( LorgalisManuscript ), 99.44f),
							   new Loot( typeof( TangyClamMeat ), 0.16f)
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