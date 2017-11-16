using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Rogue : UnitBase
	{
		public Rogue(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.ENERGY;
		}
	}
}
