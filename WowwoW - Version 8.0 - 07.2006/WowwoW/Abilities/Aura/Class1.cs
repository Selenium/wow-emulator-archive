using System;

namespace Server
{
	/// <summary>
	/// Summary description for FrostArmorAura.
	/// </summary>
	public class SkillBonusAura : Aura
	{
		int skillBonus;
		int skillId;
		AuraEffect auraEffect;

		public SkillBonusAura()
		{
		}
		public override int SkillBonus
		{
			get
			{
				return skillBonus;
			}
			set
			{
				skillBonus = value;
			}
		}
		public override int SkillId
		{
			get
			{
				return skillId;
			}
			set
			{
				skillId = value;
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
	public class SkillMalusAura : Aura
	{
		int skillMalus;
		int skillId;
		AuraEffect auraEffect;

		public SkillMalusAura()
		{
		}
		public override int SkillMalus
		{
			get
			{
				return skillMalus;
			}
			set
			{
				skillMalus = value;
			}
		}
		public override int SkillId
		{
			get
			{
				return skillId;
			}
			set
			{
				skillId = value;
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
