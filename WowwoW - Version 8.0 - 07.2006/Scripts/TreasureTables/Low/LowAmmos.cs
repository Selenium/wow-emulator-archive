//////////////////////////////////////////////////////////
// DrNexus Low Ammos Treasure list
//////////////////////////////////////////////////////////
using Server;
namespace Server.Items
{
	public class LowAmmosDrops
	{
		public static Loot[]LowAmmos = new Loot[]
		{
			new Loot( typeof( Doomshot ), 50f )
				, new Loot( typeof( SolidShot ), 40f )
				, new Loot( typeof( CraftedSolidShot ), 40f )
		};
	}
}
