using System;

namespace eWoW
{
	public class Script
	{
		public Script()
		{
		}


		public static uint GetNextLevelXP(Character c)
		{
			uint level = c.Level;
			return 300 + 80*level + 20 * level * level;
		}

	}
}
