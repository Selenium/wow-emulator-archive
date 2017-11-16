using System;
using System.Collections;
using HelperTools;
using Server.Items;

namespace Server
{
	#region ENUMS
	public enum TrackableResources : int
	{
		ElvenGems = 7,
		GahzRidian = 15,
		Herbs = 2,
		Minerals = 3,
		Treasure = 6
	}
	public enum SpecialStates : int
	{
		Combustion = 1,
		PresenceOfMind = 2,
		ArcanePower = 3,
		Bloodthirst = 4,
		AmplifyCurse = 5,
		FelDomination = 6,
		WarlockFear = 7,
		WarlockCurse = 8,
		None = 0
	}
	public enum TrackableCreatures : int
	{
		Beast = 1,
		Dragonkin = 2,
		Demon = 3,
		Elemental = 4,
		Giant = 5,
		Undead = 6,
		Humanoid = 7,
		Critter = 8,
		Mechanical = 9,
		All = 128
	}

	public enum EffectTypes : int
	{
		// done
		#region absorb
		FireAbsorb, //done
		ManaShield, //done
		ArcaneAbsorb, //done
		FrostAbsorb, //done
		HolyAbsorb, //done
		ShadowAbsorb, //done
		NatureAbsorb, //done
		AbsorbAllMagic, //done
		PhysicalAbsorb, //done
		AllDamageAbsorb, //done 
		#endregion 

		#region shield
		ShieldBlockBonus, //done
		ShieldBlockModifier, //done
		#endregion 

		#region Block, Dodge, Parry, hit
		BlockBonus, //done
		BlockMalus,//done
		HitBonus,//done
		HitMalus,//done
		MeleeHitBonus,//done
		MeleeHitMalus,//done
		RangedHitBonus,//done not used
		RangedHitMalus,//done not used
		DodgeBonus,//done
		DodgeMalus,//done
		ParryBonus,//done
		ParryMalus,//done
		SpellHitBonus,
		SpellHitMalus,
		#endregion //done

		#region critical modificators
		PhysicalCriticalBonus, //done
		MagicalCriticalBonus, //done
		FireCriticalBonus, //done
		FrostCriticalBonus, //done
		HolyCriticalBonus, //done
		ShadowCriticalBonus, //done
		NatureCriticalBonus, //done
		ArcaneCriticalBonus, //done
		#endregion

		#region Damage Done
		//all
		AllDamageDoneBonus, //done
		AllDamageDoneMalus, //done
		AllDamageDoneModifier, //done
		//melee
		MeleeDamageBonus, //done
		MeleeDamageMalus, //done
		MeleePercentDamageMalus, //done
		MeleePercentDamageBonus, //done

		RangedDamageBonus, //done
		RangedDamageMalus, //done

		MeleeDamageDoneAgainsDemonsBonus,//done
		MeleeDamageDoneAgainsUndeadBonus,//done
		MeleeDamageDoneAgainsBeastBonus,//done
		MeleeDamageDoneAgainsDragonsBonus,//done
		MeleeDamageDoneAgainsElementalsBonus,//done
		MeleeDamageDoneAgainsGiantsBonus,//done
		//magic
		FirePercentDamageIncrease,//done
		ShadowPercentDamageIncrease,//done
		NaturePercentDamageIncrease,//done
		FrostPercentDamageIncrease,//done
		PhysicalPercentDamageIncrease,//done
		
		FireDamageIncrease,//done
		ShadowDamageIncrease,//done
		NatureDamageIncrease,//done
		FrostDamageIncrease,//done
		PhysicalDamageIncrease, //done
		HolyDamageIncrease,//done
		ArcaneDamageIncrease,//done
		AllMagicDamageIncrease,//done

		SpellDamageDoneAgainsDemonsBonus, //done
		SpellDamageDoneAgainsUndeadBonus, //done

		//other

		PetDamageBonus, //done
		PetDamageMalus, //done

		#endregion

		#region Damage Taken
		//all
		DamageTakenBonus, //done
		DamageTakenMalus, //done
		DamageTakenModifier, //done
		//melee
		MeleePercentDamageTakenIncrease, //done
		MeleePercentDamageTakenReduction, //done
		MeleeDamageTakenBonus, //done
		MeleeDamageTakenMalus,//done	
		//ranged
		RangedDamageTakenModifier, //done not used
		RangedDamageTakenBonus, // done not used
		RangedDamageTakenMalus,	// done not used
		//magic
		ShadowDamageTakenModifier,//done
		FireDamageTakenModifier,//done
		FireDamageTakenBonus,//done
		FireDamageTakenMalus,//done
		FrostDamageTakenBonus,//done
		FrostDamageTakenMalus,//done
		NatureDamageTakenBonus,//done
		NatureDamageTakenMalus,//done
		ShadowDamageTakenBonus,//done
		ShadowDamageTakenMalus,//done
		PhysicalDamageTakenBonus,//done
		PhysicalDamageTakenMalus,//done
		ArcaneDamageTakenBonus,//done
		ArcaneDamageTakenMalus,//done
		SpellDamageTakenBonus,//done
		SpellDamageTakenMalus,//done
		HolyDamageTakenBonus,//done
		HolyDamageTakenMalus,//done
		//Other

		#endregion

		#region Healing
		HealGiveIncrease, //done
		HealGiveDecrease, //done
		HealGiveModifier, //done
		HealTakeIncrease, //done
		HealTakeDecrease, //done
		HealTakeModifier, //done
		#endregion

		#region resistance
		//Armor
		ArmorBonus,//done
		ArmorMalus,//done
		ArmorPercentBonus,//done
		ArmorPercentMalus,//done
		ArmorFromItemsPercentIncrease,//done
		        
		//resistances
		FireResistanceBonus,//done
		ArcaneResistanceBonus,//done
		FrostResistanceBonus,//done
		HolyResistanceBonus,//done
		ShadowResistanceBonus,//done
		NatureResistanceBonus,//done

		FireResistanceMalus,//done
		ArcaneResistanceMalus,//done
		FrostResistanceMalus,//done
		HolyResistanceMalus,//done
		ShadowResistanceMalus,//done
		NatureResistanceMalus,//done

		AllResistanceBonus, //done
		AllResistanceMalus, //done
		AllResistancePercentBonus, //done
		AllResistancePercentMalus, //done
		#endregion

		#region AttackPower
		AttackPowerBonus, //done
		AttackPowerMalus, //done
		AttackPowerModifier, //done
		RangedAttackPowerBonus,//done
		RangedAttackPowerMalus,//done
		AttackPowerBonusAgainsGiants,//done
		AttackPowerMalusAgainsGiants,//done
		AttackPowerBonusAgainsUndead,//done
		AttackPowerMalusAgainsUndead,//done
		AttackPowerBonusAgainsBeast,//done
		AttackPowerMalusAgainsBeast,//done
		AttackPowerBonusAgainsDemons,//done
		AttackPowerMalusAgainsDemons,//done
		#endregion

		#region stats
		SwitchToRage,
		StrBonus, //done
		AgBonus, //done
		IQBonus, //done
		SpiritBonus, //done
		StaminaBonus, //done

		StrMalus, //done
		AgMalus, //done
		IQMalus, //done
		SpiritMalus, //done
		StaminaMalus, //done

		ManaBonus, //done
		HealthBonus, //done
		ManaPercentBonus, //done
		HealthPercentBonus, //done
		ManaMalus, //done
		HealthMalus, //done

		StrPercentBonus, //done
		AgPercentBonus,//done
		IQPercentBonus,//done
		SpiritPercentBonus, //done
		StaminaPercentBonus,//done

		StrPercentMalus, //done
		AgPercentMalus, //done
		IQPercentMalus, //done
		SpiritPercentMalus, //done
		StaminaPercentMalus,//done 

		AllAtributesBonus, //done
		AllAtributesMalus,//done
		AllAtributesPercentMalus,//done
		AllAtributesPercentBonus,//done
		#endregion

		#region immune
		// physiscal
		ImmunePhysicalDamage, //done 
		//magic
		ImmuneFireSpell, //done
		ImmuneFrostSpell, //done
		ImmuneAllSpellsAndAbilites, //done
		// attack
		ImmuneAttack, //done dont know if handled right not handled
		// dispelType
		ImmuneDisease, //done not handled need dispel type
		ImmunePoison, //done not handled need dispel type
		ImmuneMagic, //done not handled need dispel type
		// mechanic
		ImmuneToKnockBack, //done not handled
		ImmuneToFear, //done
		ImmuneToDisarm, //done
		ImmuneToImmobilization, //done
		#endregion

		#region regeneration
		ManaRegenerationModifier,
		HealthRegenerationModifier,
		ManaRegenWhileCastingPercent,
		HealthRegenWhileFightingPercent,
		InteruptRegeneration,
		RageGenerationModifier,
		#endregion

		#region triggers
		OnMeleeHit, //done
		OnSpellHit, //done
		OnCriticalHit, //done
		OnMeleeHitDone, //done
		OnSpellHitDone, //done
		OnCriticalHitDone, //done
		#endregion
		
		#region Spell and Ability power cost
		PowerCostModifier, //done
		ArcaneCostMalus,//done
		FireCostMalus,//done
		FrostCostMalus,//done
		ShadowCostMalus,//done
		HolyCostMalus,//done
		NatureCostMalus,//done
		AllCostMalus,//done
		#endregion

		#region Skills
		SkillBonus,
		SkillMalus,
		SkillId,
		#endregion

		#region Speed
		SpeedModifier, //done
		RunSpeedModifier,//done
		SpeedBonus,//done
		SpeedMalus,//done
		RunSpeedBonus,//done
		RunSpeedMalus,//done
		MountSpeedBonus, //not handled
		MountSpeedMalus, //not handled
		RangedAttackSpeedModifier, //done
		CastingSpeedModifier, //done
		MountSpeedModifier,// not handled
		SwimSpeedModifier,//done
		AttackSpeedModifier,//done
		#endregion

		

		#region other
		SpecialState,
		SpecialStateFrom,
		#endregion

		// working on

		#region Spell and Ability Cost
		CostModificatorForAbility,//done	
		CostBonusForAbility,//done
		CostEffectedAbilityList,//done
		CostEffectedAbilityClass,//done
		#endregion

		#region Spell and Ability CastingTime
		CastingTimeModificatorForAbility,//done
		CastingTimeBonusForAbility,//done
		CastingTimeEffectedAbilityList,//done
		CastingTimeEffectedAbilityClass,//done
		#endregion

		#region Spell and Ability Range 
		RangeModificatorForAbility,//done
		RangeBonusForAbility,//done
		RangeEffectedAbilityList,//done
		RangeEffectedAbilityClass,//done
		#endregion

		#region Spell and Ability Radius 
		RadiusModificatorForAbility,
		RadiusBonusForAbility,
		RadiusEffectedAbilityList,
		RadiusEffectedAbilityClass,
		#endregion

		#region Spell and Ability Duration 
		DurationModificatorForAbility,
		DurationBonusForAbility,
		DurationEffectedAbilityList,
		DurationEffectedAbilityClass,
		#endregion

		#region Spell and Ability Cooldown 
		CooldownModificatorForAbility,
		CooldownBonusForAbility,
		CooldownEffectedAbilityList,
		CooldownEffectedAbilityClass,
		#endregion

		#region Spell and Ability S1
		S1ModificatorForAbility,
		S1BonusForAbility,
		S1EffectedAbilityList,
		S1EffectedAbilityClass,
		#endregion

		#region Spell and Ability S2
		S2ModificatorForAbility,
		S2BonusForAbility,
		S2EffectedAbilityList,
		S2EffectedAbilityClass,
		#endregion

		#region Spell and Ability S3
		S3ModificatorForAbility,
		S3BonusForAbility,
		S3EffectedAbilityList,
		S3EffectedAbilityClass,
		#endregion

		#region Spell and Ability Bonus1 
		Bonus1ModificatorForAbility,
		Bonus1BonusForAbility,
		Bonus1EffectedAbilityList,
		Bonus1EffectedAbilityClass,
		#endregion

		ForceAttackTo,

		#region avoid cast skill
		AvoidCastMagicClass,
		#endregion

		#region reflection
		ReflectFireChance,
		ReflectFrostChance,
		ReflectShadowChance,
		ReflectMagicChance,
		#endregion

		#region find
		FindMineral = 25633,
		FindCreature = 25634,
		#endregion
		
		#region force XXX
		ForceFlee,//done
		ForceStun,//done
		ForceRoot,//done
		ForceSilence,//done
		ForceDisarm,
		ForceConfuse,
		ForceUnInteractible,
		ForcePacified,
		ForceTauntedBy,
		ForceUntrackable,
		#endregion

		// not done

		#region mechanic resistances
		
		CharmResistanceBonus,
		FearResistanceBonus,
		StunResistanceBonus,
		SilenceResistanceBonus,
		ImobilizationResistanceBonus,
		
		CharmResistanceMalus,
		FearResistanceMalus,
		StunResistanceMalus,
		SilenceResistanceMalus,
		ImobilizationResistanceMalus,
		#endregion

		#region Invisibility & Detections
		CanSeeLesserInvisibility,
		CanSeeMediumInvisibility,
		CanSeeGreaterInvisibility,

		LesserInvisibility,
		MediumInvisibility,
		GreaterInvisibility,
		DetectHumanoid,
		DetectBeast,
		DetectUndead,
		#endregion
		
		#region Threat(Hate)
		ThreathModifier,
		#endregion

		#region other
		ShadowTrance,
		WaterWalking,
		FeatherFall,
		ShareDamageWithPet,
		ShareDamageWithCaster,
		StealthModifier,
		WaterBreath,
		SafeFall,
		WaterBreathingDurationModifier,
		#endregion
		
		None = 0
	}

	#endregion

	/// <summary>
	/// Summary description for Aura.
	/// </summary>
	/// 
	public class Aura
	{
		int val;
		protected EffectTypes effect;

		#region ACCESSORS

		//done

		#region absorb
		public virtual int FireAbsorb
		{
			get
			{
				if ( effect == EffectTypes.FireAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireAbsorb;
				val = value;
			}
		}
		public virtual int ManaShield
		{
			get
			{
				if ( effect == EffectTypes.ManaShield )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ManaShield;
				val = value;
			}
		}
		public virtual int ArcaneAbsorb
		{
			get
			{
				if ( effect == EffectTypes.ArcaneAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneAbsorb;
				val = value;
			}
		}
		public virtual int FrostAbsorb
		{
			get
			{
				if ( effect == EffectTypes.FrostAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostAbsorb;
				val = value;
			}
		}
		public virtual int HolyAbsorb
		{
			get
			{
				if ( effect == EffectTypes.HolyAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyAbsorb;
				val = value;
			}
		}
		public virtual int ShadowAbsorb
		{
			get
			{
				if ( effect == EffectTypes.ShadowAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowAbsorb;
				val = value;
			}
		}
		public virtual int NatureAbsorb
		{
			get
			{
				if ( effect == EffectTypes.NatureAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureAbsorb;
				val = value;
			}
		}
		
		public virtual int AbsorbAllMagic
		{
			get
			{
				if ( effect == EffectTypes.AbsorbAllMagic )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AbsorbAllMagic;
				val = value;
			}
		}
		public virtual int AllDamageAbsorb
		{
			get
			{
				if ( effect == EffectTypes.AllDamageAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllDamageAbsorb;
				val = value;
			}
		}
		public virtual int PhysicalAbsorb
		{
			get
			{
				if ( effect == EffectTypes.PhysicalAbsorb )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PhysicalAbsorb;
				val = value;
			}
		}
		#endregion	

		#region shields
		public virtual int ShieldBlockBonus
		{
			get
			{
				if ( effect == EffectTypes.ShieldBlockBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShieldBlockBonus;
				val = value;
			}
		}
		public virtual float ShieldBlockModifier
		{
			get
			{
				if ( effect == EffectTypes.ShieldBlockModifier )
					return val;
				return 1f;
			}
			set
			{
				effect = EffectTypes.ShieldBlockModifier;
				val = (int)value*1000;
			}
		}
		#endregion
		
		#region Block, Dodge, Parry, hit
		public virtual int BlockBonus
		{
			get
			{
				if ( effect == EffectTypes.BlockBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.BlockBonus;
				val = value;
			}
		}
		public virtual int BlockMalus
		{
			get
			{
				if ( effect == EffectTypes.BlockMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.BlockMalus;
				val = value;
			}
		}
			
		public virtual int DodgeBonus
		{
			get
			{
				if ( effect == EffectTypes.DodgeBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DodgeBonus;
				val = value;
			}
		}
		public virtual int DodgeMalus
		{
			get
			{
				if ( effect == EffectTypes.DodgeMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DodgeMalus;
				val = value;
			}
		}
			
		public virtual int ParryBonus
		{
			get
			{
				if ( effect == EffectTypes.ParryBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ParryBonus;
				val = value;
			}
		}
		public virtual int ParryMalus
		{
			get
			{
				if ( effect == EffectTypes.ParryMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ParryMalus;
				val = value;
			}
		}
			
		public int HitBonus
		{
			get
			{
				if ( effect == EffectTypes.HitBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HitBonus;
				val = value;
			}
		}
		public int SpellHitBonus
		{
			get
			{
				if ( effect == EffectTypes.SpellHitBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellHitBonus;
				val = value;
			}
		}
		public int SpellHitMalus
		{
			get
			{
				if ( effect == EffectTypes.SpellHitMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellHitMalus;
				val = value;
			}
		}
		public int MeleeHitBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeHitBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeHitBonus;
				val = value;
			}
		}
		public int RangedHitBonus
		{
			get
			{
				if ( effect == EffectTypes.RangedHitBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedHitBonus;
				val = value;
			}
		}
		public int HitMalus
		{
			get
			{
				if ( effect == EffectTypes.HitMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HitMalus;
				val = value;
			}
		}
		public int MeleeHitMalus
		{
			get
			{
				if ( effect == EffectTypes.MeleeHitMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeHitMalus;
				val = value;
			}
		}
		public int RangedHitMalus
		{
			get
			{
				if ( effect == EffectTypes.RangedHitMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedHitMalus;
				val = value;
			}
		}
		#endregion

		#region critical modificators
		public virtual int MagicalCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.MagicalCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MagicalCriticalBonus;
				val = value;
			}
		}	
		public virtual int PhysicalCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.PhysicalCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PhysicalCriticalBonus;
				val = value;
			}
		}	
		public virtual int FireCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.FireCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireCriticalBonus;
				val = value;
			}
		}	
		public virtual int FrostCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.FrostCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostCriticalBonus;
				val = value;
			}
		}	
		public virtual int ShadowCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.ShadowCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowCriticalBonus;
				val = value;
			}
		}	
		public virtual int ArcaneCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneCriticalBonus;
				val = value;
			}
		}	
		public virtual int NatureCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.NatureCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureCriticalBonus;
				val = value;
			}
		}	
		public virtual int HolyCriticalBonus
		{
			get
			{
				if ( effect == EffectTypes.HolyCriticalBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyCriticalBonus;
				val = value;
			}
		}	
		#endregion

		#region damage done
		public virtual int RangedDamageMalus
		{
			get
			{
				if ( effect == EffectTypes.RangedDamageMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedDamageMalus;
				val = value;
			}
		}		
		public virtual int RangedDamageBonus
		{
			get
			{
				if ( effect == EffectTypes.RangedDamageBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedDamageBonus;
				val = value;
			}
		}	

		public virtual int MeleeDamageMalus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageMalus;
				val = value;
			}
		}		
		public virtual int MeleeDamageBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageBonus;
				val = value;
			}
		}	
		public virtual int AllDamageDoneBonus
		{
			get
			{
				if ( effect == EffectTypes.AllDamageDoneBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllDamageDoneBonus;
				val = value;
			}
		}	
		public virtual int AllDamageDoneMalus
		{
			get
			{
				if ( effect == EffectTypes.AllDamageDoneMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllDamageDoneMalus;
				val = value;
			}
		}	
		public virtual float MeleePercentDamageMalus
		{
			get
			{
				if ( effect == EffectTypes.MeleePercentDamageMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.MeleePercentDamageMalus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float AllDamageDoneModifier
		{
			get
			{
				if ( effect == EffectTypes.AllDamageDoneModifier )
					return (float)( val / 1000 );
				return 1f;
			}
			set
			{
				effect = EffectTypes.AllDamageDoneModifier;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float MeleePercentDamageBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleePercentDamageBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.MeleePercentDamageBonus;
				val = (int)( value * 1000 );
			}
		}	
		
		public virtual int MeleeDamageDoneAgainsDemonsBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsDemonsBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsDemonsBonus;
				val = value;
			}
		}	
		public virtual int MeleeDamageDoneAgainsUndeadBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsUndeadBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsUndeadBonus;
				val = value;
			}
		}	
		public virtual int MeleeDamageDoneAgainsBeastBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsBeastBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsBeastBonus;
				val = value;
			}
		}	
		public virtual int MeleeDamageDoneAgainsDragonsBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsDragonsBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsDragonsBonus;
				val = value;
			}
		}	
		public virtual int MeleeDamageDoneAgainsElementalsBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsElementalsBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsElementalsBonus;
				val = value;
			}
		}	
		public virtual int MeleeDamageDoneAgainsGiantsBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageDoneAgainsGiantsBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageDoneAgainsGiantsBonus;
				val = value;
			}
		}	

		public virtual float FirePercentDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.FirePercentDamageIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.FirePercentDamageIncrease;
				val = (int)( value * 1000f );
			}
		}
		public virtual float ShadowPercentDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.ShadowPercentDamageIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.ShadowPercentDamageIncrease;
				val = (int)( value * 1000f );
			}
		}
		public virtual float NaturePercentDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.NaturePercentDamageIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.NaturePercentDamageIncrease;
				val = (int)( value * 1000f );
			}
		}
		public virtual float FrostPercentDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.FrostPercentDamageIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.FrostPercentDamageIncrease;
				val = (int)( value * 1000f );
			}
		}
		public virtual float PhysicalPercentDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.PhysicalPercentDamageIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.PhysicalPercentDamageIncrease;
				val = (int)( value * 1000f );
			}
		}
		public virtual int FireDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.FireDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireDamageIncrease;
				val = value;
			}
		}
		public virtual int ShadowDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.ShadowDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowDamageIncrease;
				val = value;
			}
		}
		public virtual int NatureDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.NatureDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureDamageIncrease;
				val = value;
			}
		}
		public virtual int FrostDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.FrostDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostDamageIncrease;
				val = value;
			}
		}
		public virtual int ArcaneDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.ArcaneDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneDamageIncrease;
				val = value;
			}
		}
		public virtual int HolyDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.HolyDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyDamageIncrease;
				val = value;
			}
		}
		public virtual int PhysicalDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.PhysicalDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PhysicalDamageIncrease;
				val = value;
			}
		}
		public virtual int AllMagicDamageIncrease
		{
			get
			{
				if ( effect == EffectTypes.AllMagicDamageIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllMagicDamageIncrease;
				val = value;
			}
		}
		public virtual int SpellDamageDoneAgainsDemonsBonus
		{
			get
			{
				if ( effect == EffectTypes.SpellDamageDoneAgainsDemonsBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellDamageDoneAgainsDemonsBonus;
				val = value;
			}
		}
		public virtual int SpellDamageDoneAgainsUndeadBonus
		{
			get
			{
				if ( effect == EffectTypes.SpellDamageDoneAgainsUndeadBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellDamageDoneAgainsUndeadBonus;
				val = value;
			}
		}
		public virtual int PetDamageBonus
		{
			get
			{
				if ( effect == EffectTypes.PetDamageBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PetDamageBonus;
				val = value;
			}
		}
		public virtual int PetDamageMalus
		{
			get
			{
				if ( effect == EffectTypes.PetDamageMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PetDamageMalus;
				val = value;
			}
		}
		#endregion

		#region resistances
		//armor
		public virtual int ArmorBonus
		{
			get
			{
				if ( effect == EffectTypes.ArmorBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArmorBonus;
				val = value;
			}
		}
		public virtual int ArmorMalus
		{
			get
			{
				if ( effect == EffectTypes.ArmorMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArmorMalus;
				val = value;
			}
		}

		public virtual float ArmorPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.ArmorPercentBonus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.ArmorPercentBonus;
				val = (int)( value * 1000f );
			}
		}
		public virtual float ArmorPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.ArmorPercentMalus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.ArmorPercentMalus;
				val = (int)( value * 1000f );
			}
		}
		public virtual float ArmorFromItemsPercentIncrease
		{
			get
			{
				if ( effect == EffectTypes.ArmorFromItemsPercentIncrease )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.ArmorFromItemsPercentIncrease;
				val = (int)( value * 1000f );
			}
		}
		
		//magic
		public virtual int FireResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.FireResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireResistanceBonus;
				val = value;
			}
		}
		public virtual int ArcaneResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneResistanceBonus;
				val = value;
			}
		}
		public virtual int FrostResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.FrostResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostResistanceBonus;
				val = value;
			}
		}
		public virtual int HolyResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.HolyResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyResistanceBonus;
				val = value;
			}
		}
		public virtual int ShadowResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.ShadowResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowResistanceBonus;
				val = value;
			}
		}
		public virtual int NatureResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.NatureResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureResistanceBonus;
				val = value;
			}
		}
		
		
		public virtual int FireResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.FireResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireResistanceMalus;
				val = value;
			}
		}
		public virtual int ArcaneResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneResistanceMalus;
				val = value;
			}
		}
		public virtual int FrostResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.FrostResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostResistanceMalus;
				val = value;
			}
		}
		public virtual int HolyResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.HolyResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyResistanceMalus;
				val = value;
			}
		}
		public virtual int ShadowResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.ShadowResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowResistanceMalus;
				val = value;
			}
		}
		public virtual int NatureResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.NatureResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureResistanceMalus;
				val = value;
			}
		}
		
		
		public virtual int AllResistanceMalus
		{
			get
			{
				if ( effect == EffectTypes.AllResistanceMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllResistanceMalus;
				val = value;
			}
		}
		public virtual int AllResistanceBonus
		{
			get
			{
				if ( effect == EffectTypes.AllResistanceBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllResistanceBonus;
				val = value;
			}
		}
		
		public virtual float AllResistancePercentBonus
		{
			get
			{
				if ( effect == EffectTypes.AllResistancePercentBonus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AllResistancePercentBonus;
				val = (int)( value * 1000f );
			}
		}
		public virtual float AllResistancePercentMalus
		{
			get
			{
				if ( effect == EffectTypes.AllResistancePercentMalus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AllResistancePercentMalus;
				val = (int)( value * 1000f );
			}
		}
		#endregion

		#region damage taken
		//all
		public virtual int DamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.DamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DamageTakenMalus;
				val = value;
			}
		}		
		public virtual int DamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.DamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DamageTakenBonus;
				val = value;
			}
		}	
		public virtual float DamageTakenModifier
		{
			get
			{
				if ( effect == EffectTypes.DamageTakenModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.DamageTakenModifier;
				val = (int)( value * 1000 );
			}
		}	
		
		//melee
		public virtual int MeleeDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int MeleeDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.MeleeDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.MeleeDamageTakenBonus;
				val = value;
			}
		}	
		public virtual float MeleePercentDamageTakenReduction
		{
			get
			{
				if ( effect == EffectTypes.MeleePercentDamageTakenReduction )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.MeleePercentDamageTakenReduction;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float MeleePercentDamageTakenIncrease
		{
			get
			{
				if ( effect == EffectTypes.MeleePercentDamageTakenIncrease )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.MeleePercentDamageTakenIncrease;
				val = (int)( value * 1000 );
			}
		}	
		
		//ranged
		public virtual int RangedDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.RangedDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int RangedDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.RangedDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedDamageTakenBonus;
				val = value;
			}
		}	
		public virtual float RangedDamageTakenModifier
		{
			get
			{
				if ( effect == EffectTypes.RangedDamageTakenModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.RangedDamageTakenModifier;
				val = (int)( value * 1000 );
			}
		}	
		//magic
		public virtual int FireDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.FireDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int FireDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.FireDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireDamageTakenBonus;
				val = value;
			}
		}	
		public virtual float FireDamageTakenModifier
		{
			get
			{
				if ( effect == EffectTypes.FireDamageTakenModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.FireDamageTakenModifier;
				val = (int)( value * 1000 );
			}
		}	

		public virtual float ShadowDamageTakenModifier
		{
			get
			{
				if ( effect == EffectTypes.ShadowDamageTakenModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.ShadowDamageTakenModifier;
				val = (int)( value * 1000 );
			}
		}	

		public virtual int ShadowDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.ShadowDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int ShadowDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.ShadowDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int FrostDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.FrostDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int FrostDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.FrostDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int ArcaneDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int ArcaneDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int SpellDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.SpellDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int SpellDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.SpellDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpellDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int HolyDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.HolyDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int HolyDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.HolyDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int NatureDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.NatureDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int NatureDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.NatureDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureDamageTakenBonus;
				val = value;
			}
		}	
		public virtual int PhysicalDamageTakenMalus
		{
			get
			{
				if ( effect == EffectTypes.PhysicalDamageTakenMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PhysicalDamageTakenMalus;
				val = value;
			}
		}		
		public virtual int PhysicalDamageTakenBonus
		{
			get
			{
				if ( effect == EffectTypes.PhysicalDamageTakenBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.PhysicalDamageTakenBonus;
				val = value;
			}
		}	
		#endregion

		#region Healing
		public virtual int HealGiveIncrease
		{
			get
			{
				if ( effect == EffectTypes.HealGiveIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealGiveIncrease;
				val = value;
			}
		}
		public virtual int HealGiveDecrease
		{
			get
			{
				if ( effect == EffectTypes.HealGiveDecrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealGiveDecrease;
				val = value;
			}
		}

		public virtual float HealGiveModifier
		{
			get
			{
				if ( effect == EffectTypes.HealGiveModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.HealGiveModifier;
				val = (int)( value * 1000 );
			}
		}		
		
		public virtual int HealTakeIncrease
		{
			get
			{
				if ( effect == EffectTypes.HealTakeIncrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealTakeIncrease;
				val = value;
			}
		}
		public virtual int HealTakeDecrease
		{
			get
			{
				if ( effect == EffectTypes.HealTakeDecrease )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealTakeDecrease;
				val = value;
			}
		}

		public virtual float HealTakeModifier
		{
			get
			{
				if ( effect == EffectTypes.HealTakeModifier )
					return (float)( (float)val / 1000f ) ;
				return 1f;
			}
			set
			{
				effect = EffectTypes.HealTakeModifier;
				val = (int)( value * 1000 );
			}
		}		
		
		#endregion

		#region attack power
		public virtual float AttackPowerModifier
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerModifier )
					return (float)( val / 1000 );
				return 1f;
			}
			set
			{
				effect = EffectTypes.AttackPowerModifier;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int AttackPowerBonus
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerBonus;
				val = value;
			}
		}
		public virtual int AttackPowerMalus
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerMalus;
				val = value;
			}
		}	
			
		public virtual int RangedAttackPowerBonus
		{
			get
			{
				if ( effect == EffectTypes.RangedAttackPowerBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedAttackPowerBonus;
				val = value;
			}
		}
		public virtual int RangedAttackPowerMalus
		{
			get
			{
				if ( effect == EffectTypes.RangedAttackPowerMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangedAttackPowerMalus;
				val = value;
			}
		}	
			
		public virtual int AttackPowerBonusAgainsGiants
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerBonusAgainsGiants )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerBonusAgainsGiants;
				val = value;
			}
		}
		public virtual int AttackPowerMalusAgainsGiants
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerMalusAgainsGiants )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerMalusAgainsGiants;
				val = value;
			}
		}	
			
		public virtual int AttackPowerBonusAgainsUndead
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerBonusAgainsUndead )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerBonusAgainsUndead;
				val = value;
			}
		}
		public virtual int AttackPowerMalusAgainsUndead
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerMalusAgainsUndead )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerMalusAgainsUndead;
				val = value;
			}
		}	
			
		public virtual int AttackPowerBonusAgainsDemons
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerBonusAgainsDemons )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerBonusAgainsDemons;
				val = value;
			}
		}
		public virtual int AttackPowerMalusAgainsDemons
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerMalusAgainsDemons )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerMalusAgainsDemons;
				val = value;
			}
		}	
			
		public virtual int AttackPowerBonusAgainsBeast
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerBonusAgainsBeast )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerBonusAgainsBeast;
				val = value;
			}
		}
		public virtual int AttackPowerMalusAgainsBeast
		{
			get
			{
				if ( effect == EffectTypes.AttackPowerMalusAgainsBeast )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AttackPowerMalusAgainsBeast;
				val = value;
			}
		}	
		#endregion

		#region stats
		public virtual bool SwitchToRage
		{
			get
			{
				if ( effect == EffectTypes.SwitchToRage )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.SwitchToRage;
			}
		}
		public virtual int StrBonus
		{
			get
			{
				if ( effect == EffectTypes.StrBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.StrBonus;
				val = value;
			}
		}
		public virtual int AgBonus
		{
			get
			{
				if ( effect == EffectTypes.AgBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AgBonus;
				val = value;
			}
		}
		public virtual int IQBonus
		{
			get
			{
				if ( effect == EffectTypes.IQBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.IQBonus;
				val = value;
			}
		}
		public virtual int SpiritBonus
		{
			get
			{
				if ( effect == EffectTypes.SpiritBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpiritBonus;
				val = value;
			}
		}
		public virtual int StaminaBonus
		{
			get
			{
				if ( effect == EffectTypes.StaminaBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.StaminaBonus;
				val = value;
			}
		}	
		public virtual int StrMalus
		{
			get
			{
				if ( effect == EffectTypes.StrMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.StrMalus;
				val = value;
			}
		}
		public virtual int AgMalus
		{
			get
			{
				if ( effect == EffectTypes.AgMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AgMalus;
				val = value;
			}
		}
		public virtual int IQMalus
		{
			get
			{
				if ( effect == EffectTypes.IQMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.IQMalus;
				val = value;
			}
		}
		public virtual int SpiritMalus
		{
			get
			{
				if ( effect == EffectTypes.SpiritMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpiritMalus;
				val = value;
			}
		}
		public virtual int StaminaMalus
		{
			get
			{
				if ( effect == EffectTypes.StaminaMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.StaminaMalus;
				val = value;
			}
		}	
		public virtual int AllAtributesBonus
		{
			get
			{
				if ( effect == EffectTypes.AllAtributesBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllAtributesBonus;
				val = value;
			}
		}
		public virtual int AllAtributesMalus
		{
			get
			{
				if ( effect == EffectTypes.AllAtributesMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllAtributesMalus;
				val = value;
			}
		}
		public virtual float StrPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.StrPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.StrPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float StrPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.StrPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.StrPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		
		public virtual float StaminaPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.StaminaPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.StaminaPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float StaminaPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.StaminaPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.StaminaPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		
		public virtual float IQPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.IQPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.IQPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float IQPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.IQPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.IQPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float AgPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.AgPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AgPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float AgPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.AgPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AgPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float SpiritPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.SpiritPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.SpiritPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float SpiritPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.SpiritPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.SpiritPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		
		public virtual float AllAtributesPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.AllAtributesPercentBonus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AllAtributesPercentBonus;
				val = (int)( value * 1000 );
			}
		}	
		public virtual float AllAtributesPercentMalus
		{
			get
			{
				if ( effect == EffectTypes.AllAtributesPercentMalus )
					return (float)( (float)val / 1000f ) ;
				return 0f;
			}
			set
			{
				effect = EffectTypes.AllAtributesPercentMalus;
				val = (int)( value * 1000 );
			}
		}	
		
		public virtual int ManaBonus
		{
			get
			{
				if ( effect == EffectTypes.ManaBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ManaBonus;
				val = value;
			}
		}	
		public virtual int HealthBonus
		{
			get
			{
				if ( effect == EffectTypes.HealthBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealthBonus;
				val = value;
			}
		}
		public virtual float ManaPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.ManaPercentBonus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.ManaPercentBonus;
				val = (int)( value * 1000f );
			}
		}	
		public virtual float HealthPercentBonus
		{
			get
			{
				if ( effect == EffectTypes.HealthPercentBonus )
					return ( (float)val ) / 1000f;
				return 0f;
			}
			set
			{
				effect = EffectTypes.HealthPercentBonus;
				val = (int)( value * 1000f );
			}
		}	
		public virtual int ManaMalus
		{
			get
			{
				if ( effect == EffectTypes.ManaMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ManaMalus;
				val = value;
			}
		}	
		public virtual int HealthMalus
		{
			get
			{
				if ( effect == EffectTypes.HealthMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HealthMalus;
				val = value;
			}
		}
		#endregion

		#region Immune
		// mechanic
		public virtual bool ImmuneToFear
		{
			get
			{
				if ( effect == EffectTypes.ImmuneToFear )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneToFear;
			}
		}
		public virtual bool ImmuneToKnockBack
		{
			get
			{
				if ( effect == EffectTypes.ImmuneToKnockBack )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneToKnockBack;
			}
		}
			
		public virtual bool ImmuneToDisarm
		{
			get
			{
				if ( effect == EffectTypes.ImmuneToDisarm )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneToDisarm;
			}
		}
		public virtual bool ImmuneToImmobilization
		{
			get
			{
				if ( effect == EffectTypes.ImmuneToImmobilization )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneToImmobilization;
			}
		}
			
		// damage
		public virtual bool ImmunePhysicalDamage
		{
			get
			{
				if ( effect == EffectTypes.ImmunePhysicalDamage )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmunePhysicalDamage;
			}
		}
		//resistance
		public virtual bool ImmuneFireSpell
		{
			get
			{
				if ( effect == EffectTypes.ImmuneFireSpell )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneFireSpell;
			}
		}
		public virtual bool ImmuneFrostSpell
		{
			get
			{
				if ( effect == EffectTypes.ImmuneFrostSpell )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneFrostSpell;
			}
		}
		
		public virtual bool ImmuneAllSpellsAndAbilites
		{
			get
			{
				if ( effect == EffectTypes.ImmuneAllSpellsAndAbilites )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneAllSpellsAndAbilites;
			}
		}
		// attack
		public virtual bool ImmuneAttack
		{
			get
			{
				if ( effect == EffectTypes.ImmuneAttack )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneAttack;
			}
		}
		// dispel type
		public virtual bool ImmuneDisease
		 {
			 get
			 {
				 if ( effect == EffectTypes.ImmuneDisease )
					 return true;
				 return false;
			 }
			 set
			 {
				 effect = EffectTypes.ImmuneDisease;
			 }
		 }
		
		public virtual bool ImmunePoison
		{
			get
			{
				if ( effect == EffectTypes.ImmunePoison )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmunePoison;
			}
		}
		public virtual bool ImmuneMagic
		{
			get
			{
				if ( effect == EffectTypes.ImmuneMagic )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ImmuneMagic;
			}
		}
		#endregion
		
		#region regeneration
		public virtual float ManaRegenerationModifier
		{
			get
			{
				if ( effect == EffectTypes.ManaRegenerationModifier )
					return (float)( val / 1000 );
				return 0f;
			}
			set
			{
				effect = EffectTypes.ManaRegenerationModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual float HealthRegenerationModifier
		{
			get
			{
				if ( effect == EffectTypes.HealthRegenerationModifier )
					return (float)( val / 1000 );
				return 0f;
			}
			set
			{
				effect = EffectTypes.HealthRegenerationModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual float ManaRegenWhileCastingPercent
		{
			get
			{
				if ( effect == EffectTypes.ManaRegenWhileCastingPercent )
					return (float)( val / 1000 );
				return 0f;
			}
			set
			{
				effect = EffectTypes.ManaRegenWhileCastingPercent;
				val = (int)( value * 1000 );
			}
		}
		public virtual float HealthRegenWhileFightingPercent
		{
			get
			{
				if ( effect == EffectTypes.HealthRegenWhileFightingPercent )
					return (float)( val / 1000 );
				return 0f;
			}
			set
			{
				effect = EffectTypes.HealthRegenWhileFightingPercent;
				val = (int)( value * 1000 );
			}
		}

		public virtual float RageGenerationModifier
		{
			get
			{
				if ( effect == EffectTypes.RageGenerationModifier )
					return (float)( val / 1000 );
				return 0f;
			}
			set
			{
				effect = EffectTypes.RageGenerationModifier;
				val = (int)( value * 1000 );
			}
		}

		public virtual bool InteruptRegeneration
		{
			get
			{
				if ( effect == EffectTypes.InteruptRegeneration && val == 1)
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.InteruptRegeneration;
				if ( (bool)value )
					val = 1;
				else
					val = 0;
			}
		}
		#endregion

		#region triggers
		public virtual int OnMeleeHit
		{
			get
			{
				if ( effect == EffectTypes.OnMeleeHit )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnMeleeHit;
				val = value;
			}
		}			
		public virtual int OnSpellHit
		{
			get
			{
				if ( effect == EffectTypes.OnSpellHit )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnSpellHit;
				val = value;
			}
		}	
		public virtual int OnCriticalHit
		{
			get
			{
				if ( effect == EffectTypes.OnCriticalHit )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnCriticalHit;
				val = value;
			}
		}	
		public virtual int OnMeleeHitDone
		{
			get
			{
				if ( effect == EffectTypes.OnMeleeHitDone )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnMeleeHitDone;
				val = value;
			}
		}			
		public virtual int OnSpellHitDone
		{
			get
			{
				if ( effect == EffectTypes.OnSpellHitDone )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnSpellHitDone;
				val = value;
			}
		}	
		public virtual int OnCriticalHitDone
		{
			get
			{
				if ( effect == EffectTypes.OnCriticalHitDone )
					return val;
				return -1;
			}
			set
			{
				effect = EffectTypes.OnCriticalHitDone;
				val = value;
			}
		}	
		#endregion

		#region power cost modifs
		public virtual float PowerCostModifier
		{
			get
			{
				if ( effect == EffectTypes.PowerCostModifier )
					return (float)( val / 1000 );
				return 1f;
			}
			set
			{
				effect = EffectTypes.PowerCostModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual int ArcaneCostMalus
		{
			get
			{
				if ( effect == EffectTypes.ArcaneCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ArcaneCostMalus;
				val = value;
			}
		}	
		public virtual int FireCostMalus
		{
			get
			{
				if ( effect == EffectTypes.FireCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FireCostMalus;
				val = value;
			}
		}	
		public virtual int FrostCostMalus
		{
			get
			{
				if ( effect == EffectTypes.FrostCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.FrostCostMalus;
				val = value;
			}
		}	
		public virtual int ShadowCostMalus
		{
			get
			{
				if ( effect == EffectTypes.ShadowCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ShadowCostMalus;
				val = value;
			}
		}	
		public virtual int HolyCostMalus
		{
			get
			{
				if ( effect == EffectTypes.HolyCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.HolyCostMalus;
				val = value;
			}
		}	
		public virtual int NatureCostMalus
		{
			get
			{
				if ( effect == EffectTypes.NatureCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.NatureCostMalus;
				val = value;
			}
		}	
		public virtual int AllCostMalus
		{
			get
			{
				if ( effect == EffectTypes.AllCostMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AllCostMalus;
				val = value;
			}
		}	
		#endregion
	
		#region special for abilities

		#region Spell and Ability Cost
		public virtual float CostModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.CostModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.CostModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int CostBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.CostBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CostBonusForAbility;
				val = value;
			}
		}
		public virtual int CostEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.CostEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CostEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int CostEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.CostEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CostEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability CastingTime
		public virtual float CastingTimeModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.CastingTimeModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.CastingTimeModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int CastingTimeBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.CastingTimeBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CastingTimeBonusForAbility;
				val = value;
			}
		}
		public virtual int CastingTimeEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.CastingTimeEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CastingTimeEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int CastingTimeEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.CastingTimeEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CastingTimeEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability Range 
		public virtual float RangeModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.RangeModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.RangeModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int RangeBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.RangeBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangeBonusForAbility;
				val = value;
			}
		}
		public virtual int RangeEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.RangeEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangeEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int RangeEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.RangeEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RangeEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability Radius 
		public virtual float RadiusModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.RadiusModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.RadiusModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int RadiusBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.RadiusBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RadiusBonusForAbility;
				val = value;
			}
		}
		public virtual int RadiusEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.RadiusEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RadiusEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int RadiusEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.RadiusEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.RadiusEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability Duration 
		public virtual float DurationModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.DurationModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.DurationModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int DurationBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.DurationBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DurationBonusForAbility;
				val = value;
			}
		}
		public virtual int DurationEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.DurationEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DurationEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int DurationEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.DurationEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.DurationEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability Cooldown 
		public virtual float CooldownModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.CooldownModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.CooldownModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int CooldownBonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.CooldownBonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CooldownBonusForAbility;
				val = value;
			}
		}
		public virtual int CooldownEffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.CooldownEffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CooldownEffectedAbilityList;
				val = value;
			}
		}	
		public virtual int CooldownEffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.CooldownEffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.CooldownEffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability S1
		public virtual float S1ModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.S1ModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.S1ModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int S1BonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.S1BonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S1BonusForAbility;
				val = value;
			}
		}
		public virtual int S1EffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.S1EffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S1EffectedAbilityList;
				val = value;
			}
		}	
		public virtual int S1EffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.S1EffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S1EffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability S2
		public virtual float S2ModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.S2ModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.S2ModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int S2BonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.S2BonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S2BonusForAbility;
				val = value;
			}
		}
		public virtual int S2EffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.S2EffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S2EffectedAbilityList;
				val = value;
			}
		}	
		public virtual int S2EffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.S2EffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S2EffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability S3
		public virtual float S3ModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.S3ModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.S3ModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int S3BonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.S3BonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S3BonusForAbility;
				val = value;
			}
		}
		public virtual int S3EffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.S3EffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S3EffectedAbilityList;
				val = value;
			}
		}	
		public virtual int S3EffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.S3EffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.S3EffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#region Spell and Ability Bonus1 
		public virtual float Bonus1ModificatorForAbility
		{
			get
			{
				if ( effect == EffectTypes.Bonus1ModificatorForAbility )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.Bonus1ModificatorForAbility;
				val = (int)( value * 1000 );
			}
		}	
		public virtual int Bonus1BonusForAbility
		{
			get
			{
				if ( effect == EffectTypes.Bonus1BonusForAbility )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.Bonus1BonusForAbility;
				val = value;
			}
		}
		public virtual int Bonus1EffectedAbilityList
		{
			get
			{
				if ( effect == EffectTypes.Bonus1EffectedAbilityList )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.Bonus1EffectedAbilityList;
				val = value;
			}
		}	
		public virtual int Bonus1EffectedAbilityClass
		{
			get
			{
				if ( effect == EffectTypes.Bonus1EffectedAbilityClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.Bonus1EffectedAbilityClass;
				val = value;
			}
		}	
		#endregion

		#endregion
		

				#region skills adds
		public virtual int SkillBonus
		{
			get
			{
				if ( effect == EffectTypes.SkillBonus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SkillBonus;
				val = value;
			}
		}
		public virtual int SkillMalus
		{
			get
			{
				if ( effect == EffectTypes.SkillMalus )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SkillMalus;
				val = value;
			}
		}
		public virtual int SkillId
		{
			get
			{
				if ( effect == EffectTypes.SkillId )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SkillId;
				val = value;
			}
		}
		#endregion

		#region speed
		public virtual float SpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.SpeedModifier )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.SpeedModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual float RunSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.RunSpeedModifier )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.RunSpeedModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual float RunSpeedBonus
		{
			get
			{
				if ( effect == EffectTypes.RunSpeedBonus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.RunSpeedBonus;
				val = (int)( value * 1000 );
			}
		}
		
		public virtual float RunSpeedMalus
		{
			get
			{
				if ( effect == EffectTypes.RunSpeedMalus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.RunSpeedMalus;
				val = (int)( value * 1000 );
			}
		}
		 
		public virtual float AttackSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.AttackSpeedModifier )
					return (float)( val / 1000 );
				return 1f;
			}
			set
			{
				effect = EffectTypes.AttackSpeedModifier;
				val = (int)( value * 1000 );
			}
		}
		public virtual float SpeedBonus
		{
			get
			{
				if ( effect == EffectTypes.SpeedBonus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.SpeedBonus;
				val = (int)( value * 1000 );
			}
		}
		public virtual float SpeedMalus
		{
			get
			{
				if ( effect == EffectTypes.SpeedMalus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.SpeedMalus;
				val = (int)( value * 1000 );
			}
		}
		
		public virtual float MountSpeedBonus
		{
			get
			{
				if ( effect == EffectTypes.MountSpeedBonus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.MountSpeedBonus;
				val = (int)( value * 1000 );
			}
		}
		public virtual float MountSpeedMalus
		{
			get
			{
				if ( effect == EffectTypes.MountSpeedMalus )
					return (float)( (float)val / 1000.0f );
				return 0f;
			}
			set
			{
				effect = EffectTypes.MountSpeedMalus;
				val = (int)( value * 1000 );
			}
		}
		
		public virtual float RangedAttackSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.RangedAttackSpeedModifier )
					return (float)( val / 1000 );
				return 1f;
			}
			set
			{
				effect = EffectTypes.RangedAttackSpeedModifier;
				val = (int)( value * 1000 );
			}
		}

		public virtual float CastingSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.CastingSpeedModifier )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.CastingSpeedModifier;
				val = (int)( value * 1000 );
			}
		}
	
		public virtual float MountSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.MountSpeedModifier )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.MountSpeedModifier;
				val = (int)( value * 1000 );
			}
		}
	
		public virtual float SwimSpeedModifier
		{
			get
			{
				if ( effect == EffectTypes.SwimSpeedModifier )
					return (float)( (float)val / 1000.0f );
				return 1f;
			}
			set
			{
				effect = EffectTypes.SwimSpeedModifier;
				val = (int)( value * 1000 );
			}
		}
	
		#endregion

		#region other
		public virtual SpecialStates SpecialState
		{
			get
			{
				if ( effect == EffectTypes.SpecialState)
					return (SpecialStates)val;
				return SpecialStates.None;
			}
			set
			{
				effect = EffectTypes.SpecialState;
				val = (int)value;
			}
		}
		public virtual int SpecialStateFrom
		{
			get
			{
				if ( effect == EffectTypes.SpecialStateFrom)
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.SpecialStateFrom;
				val = (int)value;
			}
		}
		#endregion

		// working on

		#region force XXX
		public virtual bool ForceUnInteractible
		{
			get
			{
				if ( effect == EffectTypes.ForceUnInteractible )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ForceUnInteractible;
			}
		}

		#endregion
		public virtual Mobile ForceAttackTo
		{
			get
			{
				
 				if ( effect == EffectTypes.ForceAttackTo )
					return (Mobile)World.FindMobileByGUID((ulong)val);
				return null;
			}
			set 
			{
				foreach(Mobile.AuraReleaseTimer art in value.Auras)
				{
					if(art.aura.ForceAttackTo != null)
					{
						art.aura.Release(value);
					}
				}
				effect = EffectTypes.ForceAttackTo;
				val = (int)value.Guid;

			}
		}


		#region avoid cast
		public virtual int AvoidCastMagicClass
		{
			get
			{
				if ( effect == EffectTypes.AvoidCastMagicClass )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.AvoidCastMagicClass;
				val = value;
			}
		}	
		#endregion

		#region reflection
		public virtual int ReflectFireChance
		{
			get
			{
				if ( effect == EffectTypes.ReflectFireChance )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ReflectFireChance;
				val = value;
			}
		}
		public virtual int ReflectFrostChance
		{
			get
			{
				if ( effect == EffectTypes.ReflectFrostChance )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ReflectFrostChance;
				val = value;
			}
		}
		public virtual int ReflectShadowChance
		{
			get
			{
				if ( effect == EffectTypes.ReflectShadowChance )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ReflectShadowChance;
				val = value;
			}
		}
		public virtual int ReflectMagicChance
		{
			get
			{
				if ( effect == EffectTypes.ReflectMagicChance )
					return val;
				return 0;
			}
			set
			{
				effect = EffectTypes.ReflectMagicChance;
				val = value;
			}
		}
		#endregion

		// not done
		
		public virtual bool ShareDamageWithPet
		{
			get
			{
				if ( effect == EffectTypes.ShareDamageWithPet )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.ShareDamageWithPet;
			}
		}
		public virtual bool ForceSilence
			{
				get
				{
					if ( effect == EffectTypes.ForceSilence )
						return true;
					return false;
				}
				set
				{
					effect = EffectTypes.ForceSilence;
				}
			}

		public bool WaterWalking
					{
						get
						{
							if ( effect == EffectTypes.WaterWalking )
								return true;
							return false;
						}
						set
						{
							effect = EffectTypes.WaterWalking;
						}
					}
		public bool FeatherFall
					{
						get
						{
							if ( effect == EffectTypes.FeatherFall )
								return true;
							return false;
						}
						set
						{
							effect = EffectTypes.FeatherFall;
						}
					}
		public bool ShadowTrance
				{
					get
					{
						if ( effect == EffectTypes.ShadowTrance )
							return true;
						return false;
					}
					set
					{
						effect = EffectTypes.ShadowTrance;
					}
				}
		
		public virtual bool ForceFlee
				{
					get
					{
						if ( effect == EffectTypes.ForceFlee && val == 1)
							return true;
						return false;
					}
					set
					{
						effect = EffectTypes.ForceFlee;
						if ( (bool)value )
							val = 1;
						else
							val = 0;
					}
				}
		public virtual bool ForceStun
				{
					get
					{
						if ( effect == EffectTypes.ForceStun && val == 1)
							return true;
						return false;
					}
					set
					{
						effect = EffectTypes.ForceStun;
						if ( (bool)value )
							val = 1;
						else
							val = 0;
					}
				}
		public virtual bool ForceRoot
		{
					get
					{
						if ( effect == EffectTypes.ForceRoot )
							return true;
						return false;
					}
					set
					{
						effect = EffectTypes.ForceRoot;
					}
				}
			

		#region DETECTIONS
		public virtual bool DetectBeast
		{
			get
			{
				if ( effect == EffectTypes.DetectBeast )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.DetectBeast;
			}
		}
		public virtual bool DetectUndead
		{
			get
			{
				if ( effect == EffectTypes.DetectUndead )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.DetectUndead;
			}
		}
		public virtual bool DetectHumanoid
		{
			get
			{
				if ( effect == EffectTypes.DetectHumanoid )
					return true;
				return false;
			}
			set
			{
				effect = EffectTypes.DetectHumanoid;
			}
		}
			public virtual bool CanSeeLesserInvisibility
				{
					get
					{
						if ( effect == EffectTypes.CanSeeLesserInvisibility )
							return true;
						return false;
					}
					set
					{
						effect = EffectTypes.CanSeeLesserInvisibility;
					}
				}
			public virtual bool CanSeeMediumInvisibility
			{
				get
				{
					if ( effect == EffectTypes.CanSeeMediumInvisibility )
						return true;
					return false;
				}
				set
				{
					effect = EffectTypes.CanSeeMediumInvisibility;
				}
			}
			public virtual bool CanSeeGreaterInvisibility
			{
				get
				{
					if ( effect == EffectTypes.CanSeeGreaterInvisibility )
						return true;
					return false;
				}
				set
				{
					effect = EffectTypes.CanSeeGreaterInvisibility;
				}
			}
		#endregion
		
		#endregion
		
		public AuraPeriodicTimer auraPeriodicTimer;

		public delegate void AuraReleaseDelegate( Mobile m );
		public delegate void ItemAuraReleaseDelegate( Mobile m, Item i );		
		public delegate void AuraPeriodicEffect();
		public object OnRelease;

		public Aura()
		{
		}
		public Aura( EffectTypes et )
		{
		}
		public void PeriodicAura( AuraPeriodicEffect ape, int duration, int frequency )
		{
			auraPeriodicTimer = new AuraPeriodicTimer( ape, duration, frequency );
		}

		public class AuraPeriodicTimer : WowTimer
		{
			AuraPeriodicEffect auraPeriodicEffect;
			int duration;
			int frequency;

			public AuraPeriodicTimer( AuraPeriodicEffect ape, int dur, int freq ) : base( freq, "AuraPeriodicTimer" )
			{
				duration = dur;
				frequency = freq;
				auraPeriodicEffect = ape;
				Start();
			}
			public override void OnTick()
			{
				auraPeriodicEffect();	
				duration -= frequency;
				if ( duration <= 0 )
					Stop();
				base.OnTick();
			}
		}

		public virtual void HaveSpecialState(Mobile who,SpecialStates state)
		{
			foreach(Mobile.AuraReleaseTimer art in who.Auras)
			{

			}
		}
		public virtual void Release( Mobile m )
		{
			if ( effect != EffectTypes.None )
				m.CumulativeAuraEffects[ effect ] = null;
			if ( auraPeriodicTimer != null )
			{
				auraPeriodicTimer.Stop();
				auraPeriodicTimer = null;
			}
			effect = EffectTypes.None;
			val = 0;
			if ( OnRelease != null )
			{
				( OnRelease as AuraReleaseDelegate )( m );
			}
		}
		public static void SetDetectMineral(TrackableResources res, Mobile who)
		{
			if (who.CumulativeAuraEffects[EffectTypes.FindMineral] != null)
				who.CumulativeAuraEffects.Remove(EffectTypes.FindMineral);
			who.CumulativeAuraEffects.Add(EffectTypes.FindMineral,(int)res);

			if (who is Character)
			{
				switch( res )
				{
					case TrackableResources.Treasure:
						(who as Character).SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_TRACK_RESOURCES},new object[] { 0x1000 } );
						break;
					case TrackableResources.Herbs:
						(who as Character).SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_TRACK_RESOURCES},new object[] { 0x2 } );
						break;				
					case TrackableResources.Minerals:
						(who as Character).SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_TRACK_RESOURCES},new object[] { 0x4 } );
						break;
				}
			}

		}
		public static void SetDetectCreature(TrackableCreatures res, Mobile who)
		{			
			if (who.CumulativeAuraEffects[EffectTypes.FindCreature] != null)
				who.CumulativeAuraEffects.Remove(EffectTypes.FindCreature);
			who.CumulativeAuraEffects.Add(EffectTypes.FindCreature,(int)res);

			
			if (who is Character && res == TrackableCreatures.All )
			{			
				(who as Character).SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_END + 0x342},new object[] { 0x40 });// detect all kind of creatures !!!
			}
			else
			{
				foreach( Object obj in ( who as Character ).KnownObjects )
				{
					if ( obj is Mobile && ( obj as Mobile ).NpcType == (int)res )
						( obj as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS },new object[] { ( obj as Mobile ).DynFlags( who ) });
				}
			}
		}
		

		
	}
}

