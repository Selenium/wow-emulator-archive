using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Paladin : UnitBase
	{
		public Paladin(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.MANA;
		}
	}
}
