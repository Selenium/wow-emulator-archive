using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DotAura.
	/// </summary>
	public class DrainHealthAura : Aura
	{
		int duration;
		float dmg;
		Mobile from;
		Mobile target;
		int frequency;
		SpellTemplate spell;

		public DrainHealthAura( SpellTemplate st, Mobile c, Mobile t, int d, int dur, int freq )
		{
			if ( t.Dead )
				return;
			spell = st;
			from = c;
			target = t;
			dmg = (float)d;
			duration = dur;
			frequency = freq;
			PeriodicAura( new AuraPeriodicEffect( this.PeriodicDrainHealth ), dur, freq );
		}

		public void PeriodicDrainHealth()
		{
			spell.DrainLife( from, target, dmg );
		}
	}
}
