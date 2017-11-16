using System;

namespace Server
{
	public class TauntAura : Aura
	{
		public TauntAura(Mobile _target)
		{
			foreach(Mobile.AuraReleaseTimer art in _target.Auras)
			{
				if(art.aura is TauntAura)
				{
					art.aura.Release(_target);
				}
			}
		}
	}
}

