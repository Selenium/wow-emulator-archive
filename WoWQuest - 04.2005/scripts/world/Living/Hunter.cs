using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Hunter : UnitBase
	{
		public Hunter(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.FOCUS;
		}
	}
}
