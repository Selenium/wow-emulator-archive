//////////////////////////////////////////////////////////
// DrNexus Low ThrowingWeapons Treasure list
//////////////////////////////////////////////////////////
using Server;
namespace Server.Items
{
	public class LowThrowingWeaponsDrops
	{
		public static Loot[]LowThrowingWeapons = new Loot[]
		{
			new Loot( typeof( KeenThrowingKnife ), 85f )
				, new Loot( typeof( HeavyThrowingDagger ), 60f )
				, new Loot( typeof( SharpThrowingAxe ), 85f )
				, new Loot( typeof( DeadlyThrowingAxe ), 60f )
		};
	}
}
