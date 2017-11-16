using System;

namespace Server
{
	/// <summary>
	/// Summary description for FrostArmorAura.
	/// </summary>
	public class FrostArmorAura : Aura
	{
		int armorBonus;
		int onMeleeHit;
		AuraEffect auraEffect;

		public FrostArmorAura()
		{
		}
		public override int ArmorBonus
		{
			get
			{
				return armorBonus;
			}
			set
			{
				armorBonus = value;
			}
		}
		public override int OnMeleeHit
		{
			get
			{
				return onMeleeHit;
			}
			set
			{
				onMeleeHit = value;
			}
		}
		public AuraEffect Effect
		{
			get
			{
				return auraEffect;
			}
			set
			{
				auraEffect = value;
			}
		}
	}
}
