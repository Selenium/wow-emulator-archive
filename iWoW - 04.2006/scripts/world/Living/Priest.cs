using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Priest : UnitBase
	{
		public Priest(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.MANA;
		}
	}
}
