using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for SmallChest.
	/// </summary>
	public class CheapChest : BaseChest, IInitialize
	{

		public CheapChest()
		{			
			Loots = new BaseTreasure[]{ 
				new BaseTreasure( Drops.MoneyB, 100.0f ),
				new BaseTreasure( Drops.MoneyC, 10.0f ),
				new BaseTreasure( Drops.RaggedLeatherArmor, 60.0f ),
				new BaseTreasure( Drops.ChainArmor, 60.0f ) };
			Charge = 1;
		}
		public static void Initialize()
		{
			World.GameObjectsAssociated[ 32 ] = typeof( CheapChest );
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

