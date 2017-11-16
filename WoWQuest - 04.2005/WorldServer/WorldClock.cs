using System;
using System.Collections;
using WoWDaemon.Common;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for WorldClock.
	/// </summary>
	public class WorldClock
	{
		
		public DateTime time;
		public DateTime FirstLaunch = DateTime.Now;
		public int SpeedRatio;

		public WorldClock()
		{
			time = DateTime.Now;

			SpeedRatio = 1;
			if(SpeedRatio==0) SpeedRatio = 1;
			EventManager.AddEvent(new WorldClockEvent(this));
		}
		public WorldClock(DateTime mTime,int ratio)
		{
			time = mTime;
			SpeedRatio = ratio;
			if(SpeedRatio==0) SpeedRatio = 1;
			EventManager.AddEvent(new WorldClockEvent(this));
		}
		public WorldClock(int ratio)
		{
			time = DateTime.Now;
			SpeedRatio = ratio;
			if(SpeedRatio==0) SpeedRatio = 1;
			EventManager.AddEvent(new WorldClockEvent(this));
		}

		public static uint GetTimeStamp()
		{
			DateTime time = WorldServer.m_clock.time;
			//			DateTime clocktime = this.time;
			uint timeSeq = 0;
			
			// 4 bytes of packed time data.  the bits are:
			// high 2 bits - unknown
			timeSeq|=(uint)0;
			// next 5 bits - year
			timeSeq<<=5;
			timeSeq|=(uint)1;
			// next 4 bits - month
			timeSeq<<=4;
			timeSeq|=(uint)time.Month;
			// next 7 bits - day of month
			timeSeq<<=7;
			timeSeq|=(uint)time.Day;
			// next 3 bits - day of week
			timeSeq<<=3;
			timeSeq|=(uint)time.DayOfWeek;
			// next 5 bits - hours
			timeSeq<<=5;
			timeSeq|=(uint)((time.Hour==0) ? 24 : time.Hour );
			// low 6 bits  - minutes
			timeSeq<<=6;
			timeSeq|=(uint)time.Minute;

			return timeSeq;
		}

	}
	public class WorldClockEvent : WorldEvent
	{
		WorldClock m_clock;
		
		public WorldClockEvent(WorldClock clock) : base(TimeSpan.FromMilliseconds(0))
		{
            m_clock = clock;
		}
		public override void FireEvent()
		{
			m_clock.time = m_clock.time.AddMinutes(1);

			// Temp massive update, when I could change speed time client based, 
			// we just have to sync it with save char.
			System.Collections.IDictionaryEnumerator EnumClients;
			EnumClients = WorldServer.GetClientsEnum();
			while(EnumClients.MoveNext())
			{
				if(((WorldClient)(EnumClients.Value)).Player.InWorld)
				{
					((WorldClient)(EnumClients.Value)).Player.updateTime();
				}
			}
			eventTime = DateTime.Now.AddSeconds(60/m_clock.SpeedRatio);
			EventManager.AddEvent(this);
		}

	}
}
