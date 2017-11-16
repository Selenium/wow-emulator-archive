using System;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for ItemAura.
	/// </summary>
	public class NextAttackEffect 
	{
		public int number;
		public BaseAbility spell;
		public object onEffect;
		
		public NextAttackEffect( BaseAbility af, NextAttackEffectDelegate OnEffect  )
		{
			this.number = 0;
			this.spell = af;
			this.onEffect = OnEffect;
		}
		public NextAttackEffect( BaseAbility af, NextAttackEffectDelegateMultiple OnEffect  )
		{
			this.number = 0;
			this.spell = af;
			this.onEffect = OnEffect;
		}
	}
}
