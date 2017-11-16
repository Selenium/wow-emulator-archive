using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ChannelReleaseTimer : WowTimer
	{
		Mobile caster;

		public ChannelReleaseTimer( Mobile _caster, long _duration )
			: base(Priorities.Milisec100, _duration, "ChannelReleaseTimer" )
		{
			this.caster = _caster;
		}

		public override void OnTick()
		{
			caster.SendSmallUpdateToPlayerNearMe(new int[] { 20, 21, 149 }, new object[] { (uint)0, (uint)0, (uint)0 });
			Stop();
		}
	}
}
