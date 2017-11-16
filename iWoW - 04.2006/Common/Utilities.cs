using System;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Utilities
	/// </summary>
	public class Const
	{
		public static Random rand = new Random();

		static int  tick=0;
		static int  tickLast=Environment.TickCount;
		public static int Tick 
		{
			get 
			{
				return tick;
			}
		}

		public static void SyncTick()
		{
			int t=Environment.TickCount;
			if(tickLast>t)tickLast=t;
			tick+=Environment.TickCount - tickLast;
			tickLast=t;
		}

		public static uint GetTimeStamp()
		{
			DateTime n=DateTime.Now;

			return (uint)( n.Minute | (n.Hour<<6) | ((int)n.DayOfWeek << 11) | ((n.Day-1)<<14) | ((n.Year-2000)<<18) | ((n.Month-1)<<20) );
		}
	}
}
