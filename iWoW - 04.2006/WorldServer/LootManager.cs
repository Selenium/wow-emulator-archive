using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for StatManager.
	/// </summary>
	public class LootManager
	{
		public LootManager()
		{}

		private static Random m_lootrandom = new Random();
		public static void GenerateMobLoot(UnitBase uobj) {
			uobj.Money =  m_lootrandom.Next((int)1 + uobj.Level, (int)10 + uobj.Level * 3);
		}
	}
}
