using System;
using WoWDaemon.Common;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
namespace WorldScripts.Living
{
	public class Mage : UnitBase
	{
		public Mage(DBCreature creature) : base(creature)
		{
			PowerType = POWERTYPE.MANA;
		}
	}
}
