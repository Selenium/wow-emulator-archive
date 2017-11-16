//	Script made by kolkoo - 06/07/05 15:12:52

using System;
using Server.Items;
using HelperTools;

namespace Server
{

	public class DocumentChest : BaseChest
	{
		public DocumentChest()
		{
			DefaultModel = 176344;
			BaseTreasure tempTreasure = new BaseTreasure( 
				new Loot[] { 
							   new Loot( typeof( SecretNote1 ), 33.72f ), 
							   new Loot( typeof( SecretNote2 ), 32.45f ), 
							   new Loot( typeof( SecretNote3 ), 33.69f )
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