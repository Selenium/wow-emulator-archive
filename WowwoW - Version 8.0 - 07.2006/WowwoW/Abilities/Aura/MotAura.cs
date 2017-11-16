using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DotAura.
	/// </summary>
	public class MotAura : Aura
	{
		int duration;
		int gain;
		Mobile from;
		Mobile target;
		int frequency;
		SpellTemplate spell;

		public MotAura( SpellTemplate st, Mobile c, Mobile t, int d, int dur, int freq )
		{
			if ( t.Dead )
				return;
			spell = st;
			from = c;
			target = t;
			gain = d;
			duration = dur;
			frequency = freq;
			PeriodicAura( new AuraPeriodicEffect( this.PeriodicManaRegen ), dur, freq );
		}

		public void PeriodicManaRegen()
		{
			target.GainMana( from, gain );
		}
	}
}
