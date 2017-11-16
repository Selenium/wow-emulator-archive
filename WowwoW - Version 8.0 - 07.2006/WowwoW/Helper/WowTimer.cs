using System;
using HelperTools;
using System.Threading;
using System.Collections;
using Server;

namespace HelperTools
{
	/// <summary>
	/// Summary description for WowTimer.
	/// </summary>
	public class WowTimer
	{
		long lastCall;
		int delay;
		States state;
		Priorities priority;
		public string name = "";

		public enum Priorities
		{
			Milisec1 = 0,
			Milisec = 3,
			Milisec10 = 1,
			Milisec100 = 2,
			Milisec500 = 3,
			Second = 4,
			Second5 = 5,
			Second30 = 6,
			Minute = 7,
			Hour = 8
		}

		public enum States
		{
			Started = 0,
			Paused = 1
		}
		public WowTimer( Priorities p, double d )
		{
			state = States.Paused;
			delay = (int)d;
			priority = p;
			TimeSpan ts = DateTime.Now.Subtract( World.startingTime );
			lastCall = (long)ts.TotalMilliseconds;	
		}
		public WowTimer( Priorities p, double d, string a )
		{
			name = a;
			state = States.Paused;
			delay = (int)d;
			priority = p;
			TimeSpan ts = DateTime.Now.Subtract( World.startingTime );
			lastCall = (long)ts.TotalMilliseconds;			
		}
		public WowTimer( double d )
		{
			state = States.Paused;
			delay = (int)d;
			if ( d <= 10 )
				priority = Priorities.Milisec1;
			else
			if ( d <= 100 )
				priority = Priorities.Milisec10;
			else
				if ( d <= 500 )
				priority = Priorities.Milisec100;
			else
				if ( d <= 1000 )
				priority = Priorities.Milisec500;
			else
				if ( d <= 5000 )
				priority = Priorities.Second;
			else
				if ( d <= 10000 )
				priority = Priorities.Second5;
			else
				if ( d > 60 * 60 * 1000 )
				priority = Priorities.Hour;
			else
				priority = Priorities.Second30;

			TimeSpan ts = DateTime.Now.Subtract( World.startingTime );
			lastCall = (long)ts.TotalMilliseconds;			
		}
		public WowTimer( double d, string a )
		{
			name = a;
			state = States.Paused;
			delay = (int)d;
			if ( d <= 10 )
				priority = Priorities.Milisec1;
			else
				if ( d <= 100 )
				priority = Priorities.Milisec10;
			else
				if ( d <= 500 )
				priority = Priorities.Milisec100;
			else
				if ( d <= 1000 )
				priority = Priorities.Milisec500;
			else
				if ( d <= 5000 )
				priority = Priorities.Second;
			else
				if ( d <= 10000 )
				priority = Priorities.Second5;
			else
				if ( d > 60 * 60 * 1000 )
				priority = Priorities.Hour;
			else
				priority = Priorities.Second30;

			TimeSpan ts = DateTime.Now.Subtract( World.startingTime );
			lastCall = (long)ts.TotalMilliseconds;			
		}

		public virtual void OnTick()
		{			
		}
		public int Delay
		{
			get 
		{ 
			return delay;
		}
			set 
			{ 
				delay = value;
			}
		}
		public void Start()
		{
				lastCall = (long)DateTime.Now.Ticks;
				state = States.Started;
				World.timers[ (int)priority ].Enqueue( this );
		}
		public void Restart()
		{
			//TimeSpan ts = DateTime.Now.Subtract( World.startingTime );
			lastCall = (long)DateTime.Now.Ticks;//ts.TotalMilliseconds;	
		}
		public bool Slice( long now )
		{
			if ( State == States.Paused )
				return false;
			int ts = (int)( now - lastCall );
			ts /= 10000;
			if ( ts > delay )
			{
				lastCall = now;
			//	Console.WriteLine("EnterTimer {0}", name );
				OnTick();
			//	Console.WriteLine("EndTimer {0}", name );
				if ( State == States.Paused )
					return false;
			}
			return true;
		}
		public void Stop()
		{
			state = States.Paused;			
		}
		public States State
		{
			get { return state; }
			set { state = value; }
		}
	}
}
