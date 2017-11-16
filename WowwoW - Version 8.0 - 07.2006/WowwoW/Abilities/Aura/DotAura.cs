using System;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for DotAura.
	/// </summary>
	public class DotAura : Aura
	{
		int duration;
		float dmg;
		Mobile from;
		Mobile target;
		int frequency;
		SpellTemplate spell;

		public DotAura( SpellTemplate st, Mobile c, Mobile t, int d, int dur, int freq )
		{
			
			if ( t.Dead )
				return;
			spell = st;
			from = c;
			target = t;
			dmg = (float)d;
			duration = dur;
			frequency = freq;
			PeriodicAura( new AuraPeriodicEffect( this.PeriodicDamage ), dur, freq );
		}

		public void PeriodicDamage()
		{
			spell.MakeDamage( from, target, dmg, false );
		}
	}
}
