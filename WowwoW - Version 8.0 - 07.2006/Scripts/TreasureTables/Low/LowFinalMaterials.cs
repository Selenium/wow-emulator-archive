//////////////////////////////////////////////////////////
// DrNexus Low FinalMaterials Treasure list
//////////////////////////////////////////////////////////
using Server;
namespace Server.Items
{
	public class LowFinalMaterialsDrops
	{
		public static Loot[]LowFinalMaterials = new Loot[]
		{
			new Loot( typeof( TargetDummy ), 40f )
				, new Loot( typeof( MechanicalSquirrelBox ), 20f )
				, new Loot( typeof( AquadynamicFishAttractor ), 50f )
				, new Loot( typeof( RuinedJumperCables ), 83f )
				, new Loot( typeof( GoblinJumperCables ), 83f )
		};
	}
}
