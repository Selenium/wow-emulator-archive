using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DotAura.
	/// </summary>
	public class HotAura : Aura
	{
		int duration;
		int heal;
		Mobile from;
		Mobile target;
		int frequency;
		SpellTemplate spell;

		public HotAura( SpellTemplate st, Mobile c, Mobile t, int d, int dur, int freq )
		{
			if ( t.Dead )
				return;
			spell = st;
			from = c;
			target = t;
			heal = d;
			duration = dur;
			frequency = freq;
			PeriodicAura( new AuraPeriodicEffect( this.PeriodicDamage ), dur, freq );
		}

		public void PeriodicDamage()
		{
			target.GainHealth( from, heal );
		}
	}
}
