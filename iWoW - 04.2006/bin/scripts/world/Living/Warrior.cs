using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Warrior : UnitBase
	{
		public Warrior(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.RAGE;
		}
	}
}
