using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Druid : UnitBase
	{
		public Druid(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.MANA;
		}
	}
}
