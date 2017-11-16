using System;

namespace Server
{
	public class XpTable : IInitialize
	{
		public static int xpMultiplicator; 
		public static void Initialize() 
		{ 
			//XP Table, according to http://www.wowwiki.com/Formulas:XP_To_Level 
			for(int t = 0;t < 61;t++ ) 
			{ 
				Mobile.mobXp[ t ] = ( ( t * 5 ) + 45 ); 
				if ( t > 0 ) 
					Mobile.xpNeeded[ t ] = Mobile.xpNeeded[ t - 1 ] + (int)(((8 * t + Diff_CL(t)) * Mobile.mobXp[ t ] ) / 100 ) * 100; 
				else 
					Mobile.xpNeeded[ t ] = 0; 
				Mobile.mobXp[ t ] *= xpMultiplicator; 
			}             
		} 

		static int Diff_CL(int level) 
		{ 
			// Diff_CL is used in the formula for XP needed to level up 
			if (level <= 28) 
			{ 
				return 0; 
			} 
			else if (level == 29) 
			{ 
				return 1; 
			} 
			else if (level == 30) 
			{ 
				return 2; 
			} 
			else if (level == 31) 
			{ 
				return 3; 
			} 
			else 
			{ 
				return (5 * (level - 30)); 
			} 
		} 
	}
}