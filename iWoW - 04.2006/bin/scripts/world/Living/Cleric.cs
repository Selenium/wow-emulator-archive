using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Cleric : UnitBase
	{
		public Cleric(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.MANA;
		}
	}
}
