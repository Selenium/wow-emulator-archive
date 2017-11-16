using System;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for ItemAura.
	/// </summary>
	public class ItemAura : Aura
	{
		Item item; 

		public ItemAura( Item it )
		{
			item = it;
		}

		public override void Release( Mobile m )
		{
			if ( effect != EffectTypes.None )
				m.CumulativeAuraEffects[ effect ] = null;
			if ( auraPeriodicTimer != null )
			{
				auraPeriodicTimer.Stop();
				auraPeriodicTimer = null;
			}
			if ( OnRelease != null )
			{
				( OnRelease as ItemAuraReleaseDelegate )( m, item );
			}
		}
	}
}
