using System;
using System.Collections;
using Server.Items;
using HelperTools;

using System.Reflection;
namespace Server
{
	public enum SpellDamage
	{
		TypeS1,
		TypeS2
	}

	public enum LastSpellState
	{
		Critical,
		Absorb,
		Block,
		Resist,
		Normal,
		None
	}


	#region DELEGATES

	#region attack speed spells
	public delegate void SingleTargetSpellEffectAttackSpeedMelee( BaseAbility ba, Mobile c, Mobile m );
	public delegate void SingleTargetSpellEffectAttackSpeedMeleeMultiple( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	#endregion

	#region attack speed spells with projectile
	public delegate void SingleTargetSpellEffectAttackSpeedRanged( BaseAbility ba, Mobile c, Mobile m );
	public delegate void SingleTargetSpellEffectAttackSpeedRangedMultiple( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	#endregion

	#region next attack spells
	public delegate bool NextAttackEffectDelegate( BaseAbility ba, Mobile c,Mobile target,int num);
	public delegate bool NextAttackEffectDelegateMultiple( BaseAbility ba, Mobile c,Mobile target,ArrayList add,int num);
	#endregion

	#region normal spells

	#region OnSelfSpellEffects
	public delegate void OnSelfSpellEffectMultipleFriend( BaseAbility ba, Mobile c,ArrayList targets );
	public delegate void OnSelfSpellEffectMultipleParty( BaseAbility ba, Mobile c,ArrayList targets );
	public delegate void OnSelfSpellEffectMultipleEnemy( BaseAbility ba, Mobile c,ArrayList targets );
	public delegate void OnSelfSpellEffectMultiple( BaseAbility ba, Mobile c,ArrayList targets );
	public delegate void OnSelfSpellEffect( BaseAbility ba, Mobile c );
	public delegate void OnSelfSpellEffectConeEnemy( BaseAbility ba, Mobile c,ArrayList targets );
	#endregion
	
	#region OnSingleTargetSpellEffects
	public delegate void SingleTargetSpellEffectMultipleFriend( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	public delegate void SingleTargetSpellEffectMultipleParty( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	public delegate void SingleTargetSpellEffectMultipleEnemy( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	public delegate void SingleTargetSpellEffectMultiple( BaseAbility ba, Mobile c, Mobile m ,ArrayList addTargets);
	public delegate void SingleTargetSpellEffect( BaseAbility ba, Mobile c, Mobile m );
	#endregion

	#region OnXYZSpells
	public delegate void TargetXYZSpellEffectEnemy(  BaseAbility ba, Mobile c,ArrayList addTargets );
	public delegate void TargetXYZSpellEffectFriend(  BaseAbility ba, Mobile c,ArrayList addTargets );
	public delegate void TargetXYZSpellEffectParty(  BaseAbility ba, Mobile c,ArrayList addTargets );
	public delegate void TargetXYZSpellEffect(  BaseAbility ba, Mobile c, float X, float Y, float Z );
	#endregion

	#region Permanent Spells
	public delegate void PermanentSpellEffect( BaseAbility ba, Mobile c);
	#endregion

	#endregion

	#region GameObjectSpells
	public delegate void GameObjectTargetSpellEffect( BaseAbility ba, Mobile c, GameObject go );
	#endregion
	
	#region SpellsOfItems
	public delegate void OnSelfItemSpellEffect( BaseAbility ba, Mobile c, Item.SpecialAbility sa, Item it );	
	public delegate void OnSingleTargetItemSpellEffect( BaseAbility ba, Mobile c, Mobile target, Item.SpecialAbility sa, Item it );	
	#endregion
	
	#endregion

	public class SpellTemplate : BaseAbility
	{
		#region TESTS AND CALCULATIONS
		
		public bool MissAndRessistTest(Object spellTarget,Mobile from)
		{	// return true if casters spell miss or target resist spell
			int roll;
			
			float resistChance = 0f;
			int hitChance = this.HitChanceCalculation(from,spellTarget as Mobile);
			if(this.IsBinary())
			{
				resistChance = this.ResistCalculation(from,spellTarget as Mobile);
			}
			else {resistChance = 0f;}
			roll = Utility.Random(100);
			
			if (roll > hitChance*(1f - resistChance))
			{
				from.SpellStateMSG(0,from.cast.id,from,spellTarget as Mobile,2);
				return true;	
			}
			return false;
		}

		public bool MissTest(Object spellTarget,Mobile from)
		{	// return true if casters spell miss target
			int roll;
			int hitChance = this.HitChanceCalculation(from,spellTarget as Mobile);
			roll = Utility.Random(100);
			if (roll > hitChance)
			{
				from.SpellStateMSG(0,from.cast.id,from,spellTarget as Mobile,2);
				return true;	
			}
			return false;
		}

		public float ResistCalculation(Mobile src, Mobile target)
		{	// calculate avarage resistance
			float avarageResistance = 0f;
			switch( this.resistance )
			{
				case Resistances.Fire:
					avarageResistance = (float)(((float)target.ResistFire/(src.Level*5))*0.75);
					break;
				case Resistances.Frost:
					avarageResistance = (float)(((float)target.ResistFrost/(src.Level*5))*0.75);
					break;
				case Resistances.Light:
					avarageResistance = (float)(((float)target.ResistHoly/(src.Level*5))*0.75);
					break;
				case Resistances.Arcane:
					avarageResistance = (float)(((float)target.ResistArcane/(src.Level*5))*0.75);
					if (src.HaveTalent(Talents.ArcaneFocus))
					{
						AuraEffect af = (AuraEffect)src.GetTalentEffect(Talents.ArcaneFocus);
						avarageResistance -=af.S1;
					}
					break;
				case Resistances.Shadow:
					avarageResistance = (float)(((float)target.ResistShadow/(src.Level*5))*0.75);
					break;
				case Resistances.Nature:
					avarageResistance = (float)(((float)target.ResistNature/(src.Level*5))*0.75);
					break;
			}
			if (avarageResistance > 0.75) avarageResistance = 0.75f;
			// suppression
			/*if (src.HaveTalent(Talents.Suppression))
			{
				AuraEffect af = (AuraEffect)src.GetTalentEffect(Talents.Suppression);
				avarageResistance -=af.S1;
			}*/
			return avarageResistance;
		}
		
		public int HitChanceCalculation(Mobile from, Mobile target)
		{ // calculate hitchance of caster
			int dif;
			int hitChance = 0;
			
			if(target is Character && from is Character)
			{
				dif =  target.Level - from.Level ;
				
				if(dif <= 0) hitChance = 96;
				else if(dif == 1) hitChance = 95;
				else hitChance = 94 - (dif-2)*7;
			}
			else 
			{
				dif = target.Level - from.Level ;
				
				if(dif <= 0) hitChance = 96;
				else if(dif == 1) hitChance = 95;
				else hitChance = 94 - (dif-2)*11;
			}
			hitChance += from.SpellHitBonus - from.SpellHitMalus;
			return hitChance;
		}
		
		public bool ImmuneCheck(Mobile target, SpellTemplate a)
		{// test for immunity for non auras spells
			if (target.ImmuneAllSpellsAndAbilites)
				return true;
			if (this.resistance == Resistances.Fire)
				if (target.ImmuneFireSpell) return true;
			if (this.resistance == Resistances.Frost)
				if (target.ImmuneFrostSpell) return true;
			if (this.resistance == Resistances.Armor)
				if (target.ImmunePhysicalDamage) return true;
		
			switch ( this.dispeltype)
			{
				case DispelType.Magic : if (target.ImmuneMagic)	return true;break;
				case DispelType.Disease: if (target.ImmuneDisease) return true;break;
				case DispelType.Poison: if (target.ImmunePoison) return true;break;
			}
			
			
			return false;
		}
		
		public bool ImmuneCheck(Mobile target, Aura a)
		{// test for immunity for auras spells
			if (target.ImmuneAllSpellsAndAbilites)
				return true;
			if (this.resistance == Resistances.Fire)
				if (target.ImmuneFireSpell) return true;
			if (this.resistance == Resistances.Frost)
				if (target.ImmuneFrostSpell) return true;
			if (this.resistance == Resistances.Armor)
				if (target.ImmunePhysicalDamage) return true;
			
			switch ( this.dispeltype)
			{
				case DispelType.Magic : if (target.ImmuneMagic)	return true;break;
				case DispelType.Disease: if (target.ImmuneDisease) return true;break;
				case DispelType.Poison: if (target.ImmunePoison) return true;break;
			}
			
			if(a.ForceFlee)
				{
					if (target.ImmuneToFear)
						return true;
				}

				if (a.ForceRoot || a.ForceStun)
				{
					if (target.ImmuneToImmobilization)
						return true;
				}
			
			
				/*
				if(a.ForceDisarm)
					{
						if(target.ImmuneToDisarm)
							return true;
					}
				*/
			
			return false;
		}
		
		public int ReflectCalculation(Mobile target)
		{// return chance in % to reflect spells granted by spells
			int reflect = 0;
			switch( this.resistance )
			{
				case Resistances.Fire:
					reflect = target.ReflectFireChance;
					break;
				case Resistances.Frost:
					reflect = target.ReflectFrostChance;
					break;
				case Resistances.Shadow:
					reflect = target.ReflectShadowChance;
					break;
			}
			reflect +=target.ReflectMagicChance;
			return reflect;
		}
	
		public static bool IsFrozen(Mobile c)
		{
			foreach( Mobile.AuraReleaseTimer art in c.Auras )
				if ( art.ae.resistance == Resistances.Frost) 
					if ( art.aura.ForceStun == true) return true;
			return false;
		}
		#endregion

		#region EFFECTS FCT
		#region DISPEL
		public void Dispel(DispelType type, int num,Mobile from)
		{
			int number = num;
			foreach( Mobile.AuraReleaseTimer art in from.Auras )
			{
				if (number < 1) return;
				if(art.ae.Dispeltype == type) art.aura.Release(from);
				number--;
				if (number < 1) return;
			}			
		}
		#endregion
		#region DOTS AURAS
		public void ApplyDot( Mobile c, ArrayList targets, int dmg, int freq, int duration )
		{
			foreach( Mobile m in targets )
				ApplyDot( c, m, dmg, freq, duration );
		}

		public void ApplyDot( Mobile c, Mobile target, int dmg, int freq, int duration )
		{
			if ( target.Dead )
				return;
			AuraEffect ae = null;
			if(this is AuraEffect)
			{
				ae = (AuraEffect)this;
			}
			else
			{
				ae = new AuraEffect( Id,0, 
					levelMin, levelMax, bonus1, bonus2, s1, s2, s3, 
					t1, t2, resistance,dispeltype, this.GetManaCost(c), (int)CastingTime( c ), range, duration, CoolDown( c ), 
					0, 0, classe );
		
				ae.Applications = 0x01010101;
			}
			Aura aura = new DotAura( this, c, target, dmg, duration, freq );
			target.AddAura( c,ae, aura, true );
		}
		
	
		#endregion
		#region DRAIN LIFE
		#region Drain life
		public void DrainLife( Mobile src, Mobile target, SpellDamage sd )
		{
			
			int basedmg = 1;
			int amount = 1;
			switch( sd )
			{
				case SpellDamage.TypeS1:
					basedmg = s1;
					amount = this.bonus1;
					break;
				case SpellDamage.TypeS2:
					basedmg = s2;
					amount = bonus2;
					break;
			}
			
			float dmg = (float)( basedmg + Utility.Random( 1, amount ) );
			if (dmg <= 0) dmg = 1;
			this.DrainLife(  src, target, dmg );
		}

		public void DrainLife( Mobile src, Mobile target, float dmg )
		{
			#region Warlock Improved Health Funnel
			if ( src.HaveTalent( Talents.ImprovedHealthFunnel ) && SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 755 ] )
			{
				AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedHealthFunnel );
				dmg += dmg * ( (float)ae.S1 ) / 100f;
			}
			#endregion
			int heal = MakeDamage( true, src, target, dmg, true );
			if ( src.HaveTalent( Talents.ImprovedDrainLife ) )
			{
				AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedDrainLife );
				float minus = (float)heal;
				minus += ( minus * (float)ae.S1 ) / 100f;
				heal = (int)minus;
			}
			src.GainHealth( target, heal );
		}
		#endregion
		#endregion
		#region DRAIN MANA
		#region Drain mana
		public void DrainMana( Mobile src, Mobile target, SpellDamage sd )
		{
			int heal = MakeManaDamage( src, target, sd );
			float damage = 0f;
			if ( src.HaveTalent( Talents.ImprovedDrainMana ) )
			{
				AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedDrainMana );
				if(src.TalentLevel(Talents.ImprovedDrainMana) == 1)
					damage = (float)(heal*0.15);
				else damage = (float)(heal*0.30);

			}
			if (damage > 0) this.MakeDamage(src,target,damage);
			src.GainMana( target, heal );
		}
		public void DrainMana( Mobile src, Mobile target, float dmg )
		{
			int heal = MakeManaDamage( src, target, dmg, true );
			float damage = 0f;
			if ( src.HaveTalent( Talents.ImprovedDrainMana ) )
			{
				AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedDrainMana );
				if(src.TalentLevel(Talents.ImprovedDrainMana) == 1)
					damage = (float)(heal*0.15);
				else damage = (float)(heal*0.30);

			}
			if (damage > 0) this.MakeDamage(src,target,damage);
			src.GainMana( target, heal );
		}
		#endregion
		#endregion
		#region HEAL
		public void Heal( Mobile src, Mobile target, SpellDamage d )
		{
			int basedmg = 1;
			int amount = 1;
			switch( d )
			{
				case SpellDamage.TypeS1:
					basedmg = s1;
					amount = this.bonus1;
					break;
				case SpellDamage.TypeS2:
					basedmg = s2;
					amount = bonus2;
					break;
			}
			float dmg = (float)( basedmg + Utility.Random( 1, amount ) );
			Heal( src,target,dmg );

		}
		public void Heal( Mobile src, Mobile target, int basedmg , int bonus )
		{
			float dmg = (float)( basedmg + Utility.Random( 1, bonus ) );	
			Heal( src,target,dmg );
		}
		public void Heal( Mobile src, Mobile target,float dmg )
		{
			float spellMod = 1.0f;
			dmg +=src.HealGiveIncrease - src.HealGiveDecrease;
			dmg *=src.HealGiveModifier;
			dmg +=src.HealTakeIncrease - src.HealTakeDecrease;
			dmg *=src.HealTakeModifier;
			switch( resistance )
			{
				case Resistances.Light:
					spellMod = LightSpellHealModifier( src );
					break;
				case Resistances.Nature:
					spellMod = NatureSpellHealModifier( src );
					break;					
			}
			dmg *= spellMod;
			if ( src.Classe == Classes.Warlock )
			{
				#region Warlock Improved HealthStone
				if ( src.HaveTalent( Talents.ImprovedHealthstone ) && SpellTemplate.SpellEffects[ 5720 ] == SpellTemplate.SpellEffects[ Id ] )
				{
					AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedHealthstone );
					dmg += dmg * (float)( ae.s1 ) / 100f;
				}
				#endregion
			}
			target.GainHealth( src, (int)dmg );
		}
		#endregion
		#region LIFE TAP
		public void LifeTap( Mobile src, Mobile target, SpellDamage sd )
		{
			int basedmg = 1;
			int amount = 1;
			switch( sd )
			{
				case SpellDamage.TypeS1:
					basedmg = s1;
					amount = this.bonus1;
					break;
				case SpellDamage.TypeS2:
					basedmg = s2;
					amount = bonus2;
					break;

			}
			
			float dmg = (float)( basedmg + Utility.Random( 1, amount ) );
			if (dmg <= 0) dmg = 1;
			LifeTap(src,target,dmg);

		}

		public void LifeTap( Mobile src, Mobile target, float dmg )
		{
			target.LooseHits(src,(int)dmg);
			if ( src.HaveTalent( Talents.ImprovedLifeTap ) )
			{
				AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedLifeTap );
				float minus = (float)dmg;
				minus += ( minus * (float)ae.S1 ) / 100f;
				target.GainMana( src, (int)minus);
			}
			src.GainMana( src, (int)dmg );
		}
		#endregion
		#region MAKE DAMAGE
		public int MakeDamage( Mobile src, Mobile target, float dmg )
		{
			return MakeDamage( false, src, target, dmg, true );
		}
		
		public int MakeDamage( Mobile src, Mobile target, float dmg, bool f )
		{
			return MakeDamage( false, src, target, dmg, true );
		}

		public int MakeDamage( bool forceDamage, Mobile src, Mobile target, float dmg )
		{
			return MakeDamage( forceDamage, src, target, dmg, true );
		}
		
		public int MakeDamage( Mobile src, Mobile target, SpellDamage sd )
		{
			return MakeDamage( false, src, target, sd );
		}

		public int MakeDamage( bool forceDamage, Mobile src, Mobile target, SpellDamage sd )
		{
			int basedmg = 1;
			int amount = 1;
			switch( sd )
			{
				case SpellDamage.TypeS1:
					basedmg = s1;
					amount = this.bonus1;
					break;
				case SpellDamage.TypeS2:
					basedmg = s2;
					amount = bonus2;
					break;
			}
			
			float dmg = (float)( basedmg + Utility.Random( 1, amount ) );
			if (dmg <= 0) dmg = 1;
			return MakeDamage( forceDamage, src, target, dmg );
		}
		public int MakeDamage( bool forceDamage, Mobile src, Mobile target, float dmg, bool f )
		{
			return MakeDamage(forceDamage,src,target,dmg,f,true, true );
		}
		public int MakeDamage( bool forceDamage, Mobile src, Mobile target, float dmg, bool f,bool showMSG,bool crit )
		{
			if ( target.Dead ) return 0;

			if(forceDamage)
			{
				this.SendDamageMessage(src,target,LastSpellState.Normal,(int)dmg,0,0,0,false);
				target.LooseHits( src, (int)dmg, false );
				return (int)dmg;
			}
			int absorb = 0;
			int resist = 0;
			LastSpellState state = LastSpellState.None;
			int realDamage = this.SpellDMG(src,target,dmg,ref absorb,ref resist,ref state,crit);
					
			if(showMSG)
			{
				this.SendDamageMessage(src,target,state,realDamage,resist,absorb,-1,false);				
			}
			if ( realDamage > target.HitPoints )
				realDamage = target.HitPoints;

			target.LooseHits( src, (int)realDamage, false );	
					
			
			MakeDMGSpellTriggers(src,target,state,realDamage);
			src.LastSpellStatus = AttackStatus.None;
			return 0;
		}
		#region When hitted trigerrs and talents
		public void MakeDMGSpellTriggers(Mobile src, Mobile target, LastSpellState state,int dmg)
		{
			int roll;
			#region Additional effects
			#region OnCriticalTalentsHandling
				if(state == LastSpellState.Critical)
				{
					if(src.Level > 9)
					{
						switch (src.Classe)
						{
							#region mage
							case Classes.Mage:
								// ignite 
								if ( resistance == Resistances.Fire)
								{
									if ( src.HaveTalent( Talents.Ignite ) )
									{
										AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Ignite );
										AuraEffect af = (AuraEffect)Abilities.abilities[12654];
										float modif = (float)ae.S1/100;
										af.ApplyDot(src, target, (int)(dmg*modif), af.T1, af.Duration(src));
									}
								}
								break;
								#endregion
							#region warrior
							case Classes.Warrior:
	
								break;
								#endregion
						}
					}
				
				}
				#endregion
			#region Other Spell effecting Talents
				switch (src.Classe)
				{
					#region mage
					case Classes.Mage:
						//Impact
						if (state == LastSpellState.Normal)
						{
							if (src.HaveTalent(Talents.Impact))
							{
								if (this.resistance == Resistances.Fire)
								{
									AuraEffect af = (AuraEffect)src.GetTalentEffect(Talents.Impact);
									roll = Utility.Random( 100 );
									if(roll < af.S1)
									{
										AuraEffect ef = (AuraEffect)Abilities.abilities[(int)af.AdditionalSpell];
										Aura aura = new Aura();
										aura.ForceStun = true;
										target.AddAura(src,ef,aura,true);
									}

								}
							}
						
							// Improved Scorch
							if ( src.HaveTalent( Talents.ImprovedScorch ) &&
								SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2948 ] )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedScorch);
								roll = Utility.Random( 100 );
								if(roll < ae.S1)
								{
									AuraEffect ef = (AuraEffect)Abilities.abilities[(int)ae.AdditionalSpell];
									Aura aura = new Aura();
									aura.FireDamageTakenModifier = 1 + (float)ef.S1/100;
									target.AddAura(src,ef,aura,true);
								}							
							}
							
							// Arcane Concentration
							int ClearingState = 0xd45a45;
							if ( src.HaveTalent( Talents.ArcaneConcentration ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ArcaneConcentration);
								roll = Utility.Random( 100 );
								if(roll < ae.H)
								{
									src.AdditionnalStates.Add(ClearingState);
								}
							}
						}

						break;
					#endregion
					#region Warlock 
					case Classes.Warlock:
						///aftewmatch
						if ( AbilityClasses.abilityClasses[ (int)Id ] == (int)ClassesOfSpells.Destruction )
							if ( src.HaveTalent( Talents.Aftermath ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Aftermath );
								if ( Utility.Random( 100 ) < ae.H )
								{
									Aura aura = new Aura();
									aura.SpeedModifier = ( -( (float)ae.S1 ) / 100.0f );
									aura.OnRelease = new Aura.AuraReleaseDelegate( SpellTemplate.OnCastSpeedModEnd );
									target.AddAura(src, ae, aura, true );
									target.ChangeRunSpeed( target.RunSpeed );
								}
							}
						// pyroclasm
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 1949 ] ||//Hell fire 
							SpellTemplate.SpellEffects[5740] == SpellTemplate.SpellEffects[ (int)Id ] )// Rain of fire
							if ( src.HaveTalent( Talents.Pyroclasm ) )
							{
								int prob = 0;
								if ( src.TalentLevel( Talents.Pyroclasm ) == 1 )
									prob = 13;
								else
									prob = 26;
								if ( Utility.Random( 100 ) < prob )
								{
									Aura aura = new Aura();
									aura.ForceStun = true;
									target.AddAura( (AuraEffect)Abilities.abilities[ 18093 ], aura, true );
								}
							}
						break;
					#endregion
				}
			#endregion
			#endregion
		}
		#endregion
		#region spell damage calculation
		public int SpellDMG(Mobile src, Mobile target, float basedmg,ref int absorbed ,ref int resisted, ref LastSpellState state,bool criticalTest)
		{
			state = LastSpellState.None;
			float dmg;
			float avarageResistance = this.ResistCalculation(src, target);
			
			

			dmg = SpellDamageCalculationBonus(basedmg,src,target);
			
			
			if(criticalTest)
			{
				float multipler = this.CriticalCalculationForSpells(src,target);
				dmg *= multipler;
				if(multipler > 1f)	state = LastSpellState.Critical;
			}
									
			float realDamage = AbsorbCalculation(dmg,src,target);
			absorbed = (int)(dmg - realDamage);
			if(realDamage <=0)
				state = LastSpellState.Absorb;
			
			resisted = (int)(realDamage);
			realDamage *= ResistanceMultiplerCalculation(avarageResistance, src, target);
			resisted -=(int)realDamage;
			if ( src.Level < target.Level - 7 )
				realDamage = -1;
			if(realDamage <=0)
				state = LastSpellState.Resist;

			realDamage = TargetsModificationOfDmg((int)realDamage,src,target);
			
			realDamage = target.ManaShieldLost(src, (int)realDamage);
			if(realDamage > 0) state = LastSpellState.Normal;
			return (int)realDamage;
		}
		#endregion
		#region SpellDamageCalculationBonus
		public int SpellDamageCalculationBonus(float damg, Mobile src, Mobile target)
		{
			float dmg = damg; 
			int damageTalentBonus = 0;
			float damageTalentModificator = 1f;
				
						
			#region talents handling bonuses
			if (src.Level > 9)
			{
				switch(src.Classe)
				{
					case Classes.Warlock:
						#region Warlock
						// emberstorm 
						if ( resistance == Resistances.Fire )
							if ( src.HaveTalent( Talents.Emberstorm ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Emberstorm );
								damageTalentModificator *=1 + ((float)ae.S1 / 100f );
							}
								
									
						// Improved Curse of Agony
						if ( src.HaveTalent( Talents.ImprovedCurseOfAgony ) && SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 980 ] )
						{
							AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedCurseOfAgony );
							damageTalentModificator *=1 + ( (float)ae.S1 / 100f );
						}
								
						// Shadow Mastery 
						if ( AbilityClasses.abilityClasses[ (int)Id ] == (int)ClassesOfSpells.ShadowMagic )
							if ( src.HaveTalent( Talents.ShadowMastery ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ShadowMastery );
								damageTalentModificator *=1 + ( (float)ae.S1/ 100f );
							}
						#endregion
						break;
					case Classes.Mage:
						#region Mage
						// Piercing Ice
						if ( resistance == Resistances.Frost )
							if ( src.HaveTalent( Talents.PiercingIce ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.PiercingIce );
								damageTalentModificator *=1 + ( (float)ae.S1/ 100f );
							}		
						// Firepower
						if ( resistance == Resistances.Fire)
							if ( src.HaveTalent( Talents.FirePower ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.FirePower );
								damageTalentModificator *=1 + ( (float)ae.S1/ 100f );
							}	
						// Improved Cone of Cold
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 120 ])//	Cone of Cold
							if ( src.HaveTalent( Talents.ImprovedConeOfCold ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedConeOfCold );
								damageTalentModificator *=1 + (float)ae.S1/100;
							}
						// ArcanePower
						if( src.HaveTalent(Talents.ArcanePower))
						{
							bool bonus = false;
							ArrayList al1 = new ArrayList();
							AuraEffect af = (AuraEffect)src.GetTalentEffect( Talents.ArcanePower );
							foreach( Mobile.AuraReleaseTimer art in src.Auras )
								if(art.aura.SpecialState == SpecialStates.ArcanePower)
								{
									bonus = true;
									al1.Add(art);
								}		

							if (bonus) 
							{
								damageTalentModificator *=1 + (float)af.S1/100;
							}
						}
						#endregion
						break;
					case Classes.Druid:
						#region Druid
							
						#endregion
						break;
					case Classes.Warrior:
						#region warrior
								
						#endregion
						break;
				}
			}
			#endregion

			dmg += damageTalentBonus;
			dmg *= damageTalentModificator;
		
			#region Magical damage boost
			switch (this.resistance)
			{
				case Resistances.Fire : dmg += src.FireDamageIncrease;  dmg *=(1 + (float)src.FirePercentDamageIncrease/100);break;
				case Resistances.Shadow : dmg += src.ShadowDamageIncrease;  dmg *=(1 + (float)src.ShadowPercentDamageIncrease/100);break;
				case Resistances.Frost : dmg += src.FrostDamageIncrease;  dmg *=(1 + (float)src.FrostPercentDamageIncrease/100);break;
				case Resistances.Nature : dmg += src.NatureDamageIncrease;  dmg *=(1 + (float)src.NaturePercentDamageIncrease/100);break;
				case Resistances.Light : dmg += src.HolyDamageIncrease;break;
				case Resistances.Armor : dmg += src.PhysicalDamageIncrease;  dmg *=(1 + (float)src.PhysicalPercentDamageIncrease/100);break;
				case Resistances.Arcane : dmg +=src.ArcaneDamageIncrease;break;
			}
			dmg = (dmg + src.AllDamageDoneBonus - src.AllDamageDoneMalus)*src.AllDamageDoneModifier;
			dmg = (dmg + src.AllMagicDamageIncrease);
			switch (target.NpcType)
			{
				case (int)NpcTypes.Demon : dmg += src.SpellDamageDoneAgainsDemonsBonus;break;
				case (int)NpcTypes.Undead : dmg += src.SpellDamageDoneAgainsUndeadBonus;break;
			}
		
			if (src.SummonedBy !=null)
			{
				dmg+= src.SummonedBy.PetDamageBonus - src.SummonedBy.PetDamageMalus;
			}
			#endregion
			return (int)dmg;
		}
		#endregion
		#region targets modificators
		public int TargetsModificationOfDmg(int realDamage, Mobile src, Mobile target)
		{
			realDamage += (target.DamageTakenBonus - target.DamageTakenMalus + target.SpellDamageTakenBonus - target.SpellDamageTakenMalus);
			realDamage = (int)(realDamage*target.DamageTakenModifier);
			switch(this.resistance)
			{
				case Resistances.Fire :realDamage += (target.FireDamageTakenBonus - target.FireDamageTakenMalus); realDamage = (int)(realDamage*target.FireDamageTakenModifier);break;
				case Resistances.Shadow : realDamage += (target.ShadowDamageTakenBonus - target.ShadowDamageTakenMalus); realDamage =(int)(realDamage*target.ShadowDamageTakenModifier);break;
				case Resistances.Frost : realDamage += (target.FrostDamageTakenBonus - target.FrostDamageTakenMalus); break;
				case Resistances.Nature : realDamage += (target.NatureDamageTakenBonus - target.NatureDamageTakenMalus); break;
				case Resistances.Light : realDamage += (target.HolyDamageTakenBonus - target.HolyDamageTakenMalus); break;
				case Resistances.Arcane :realDamage += (target.ArcaneDamageTakenBonus - target.ArcaneDamageTakenMalus); break;
				case Resistances.Armor:realDamage += (target.PhysicalDamageTakenBonus - target.PhysicalDamageTakenMalus); break;

			}
			return realDamage;
		}
		#endregion
		#region Resistance multipler calculation
		public float ResistanceMultiplerCalculation(float avarageResistance, Mobile src, Mobile target)
		{			
			float res = 0f;
			switch( resistance )
			{
				case Resistances.Armor:
					res = (float)target.Armor / ( (float)target.Armor + 400 + 85 * src.Level );
					break;
			}
			
			if (res == 0)
			{
				int roll = Utility.Random( 100 );
				if(roll < 5) res = (float)(avarageResistance - 0.50);
				else if(roll < 25) res = (float)(avarageResistance - 0.25);
				else if(roll < 75) res = (float)(avarageResistance);
				else if(roll < 95) res = (float)(avarageResistance + 0.25);
				else res = (float)(avarageResistance + 0.5);
				 
				if (res < 0) res = 0;
				if (res >1 ) res = 1;
				res = (float)((int)(res/0.25)*0.25);
			}
			return (1-res);
		}
		#endregion
		#region Absorb calculation
		public float AbsorbCalculation(float dmg, Mobile src, Mobile target)
		{			
			int realDamage = 0;
			switch( resistance )
			{
				case Resistances.Fire:
					realDamage = target.DiminishFireAbsordb( (int)dmg );
					if (dmg - realDamage > 0)
					{
						if (target.HaveTalent(Talents.ImprovedFireWard))
						{
							AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedFireWard );
							float modif = (float)ae.S1/100;
							bool haveFWSpell = false;
							foreach( Mobile.AuraReleaseTimer art in target.Auras )
								if ( art.ae == (AuraEffect)Abilities.abilities[10223])haveFWSpell = true;
							if (haveFWSpell) this.MakeDamage(target,src,(dmg - realDamage)*modif);
						}
					}
					realDamage = target.DiminishAbsordbAll( realDamage );					
					break;
				case Resistances.Frost:
					realDamage = target.DiminishFrostAbsordb( (int)dmg );
					// Improved frost ward
					if ( target.Classe == Classes.Mage )
						if ( target.HaveTalent( Talents.ImprovedFrostWard ) && 
							realDamage != dmg )
						{
							bool haveFWSpell = false;
							foreach( Mobile.AuraReleaseTimer art in target.Auras )
								if ( art.ae == (AuraEffect)Abilities.abilities[6143])haveFWSpell = true;
							if (haveFWSpell) target.GainMana( target, (int)(( dmg - realDamage ) / 2) );
						}
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Light:
					realDamage = target.DiminishHolyAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Arcane:
					realDamage = target.DiminishArcaneAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Shadow:
					realDamage = target.DiminishShadowAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Nature:
					realDamage = target.DiminishNatureAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Armor:
					realDamage = target.DiminishAbsorbPhysical( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
			}
			realDamage = target.DiminishAbsorbAllDamage(realDamage);
			return realDamage;							
		}
		#endregion
		#region SPELLNONMELEE for make dmg
		public void SendDamageMessage(Mobile src, Mobile target, LastSpellState state, int dmg, int resisted, int absorbed, int blocked,bool white)
		{
			int num10 = 4;
			Converter.ToBytes((ulong)target.Guid, target.tempBuff, ref num10);
			Converter.ToBytes((ulong)src.Guid, target.tempBuff, ref num10);
			Converter.ToBytes((uint)this.Id, target.tempBuff, ref num10);
			Converter.ToBytes((uint)dmg, target.tempBuff, ref num10);
			Converter.ToBytes((byte)this.resistance , target.tempBuff, ref num10);
			Converter.ToBytes(absorbed, target.tempBuff, ref num10);
			Converter.ToBytes(resisted, target.tempBuff, ref num10);
			if(blocked == -1 || white)
				Converter.ToBytes((byte)1, target.tempBuff, ref num10);
			else
				Converter.ToBytes((byte)0, target.tempBuff, ref num10);
			Converter.ToBytes((byte)0, target.tempBuff, ref num10);
			if(blocked == -1)
				Converter.ToBytes(0, target.tempBuff, ref num10);
			else
				Converter.ToBytes(blocked, target.tempBuff, ref num10);
			if(state == LastSpellState.Critical)
				Converter.ToBytes((byte)2, target.tempBuff, ref num10);
			else
				Converter.ToBytes((byte)0, target.tempBuff, ref num10);
			Converter.ToBytes(0, target.tempBuff, ref num10);
					
			src.ToAllPlayerNear(OpCodes.SMSG_SPELLNONMELEEDAMAGELOG, target.tempBuff, num10);
		//	HexViewer.View( target.tempBuff, 4, num10 - 4 );
		}
		#endregion
		
		#region Critical Spellcalculation
		public float CriticalCalculationForSpells(Mobile src,Mobile target)
		{
			#region critical chance + damage + test
			int roll = Utility.Random( 100 );
			int critical = 0;
			int critTalentBonus = 0;
			int criticalDamageTalentBonus = 0;
			float crit = 1f;
			critical = (int)(5 + (float)src.Iq/29) + (int)src.MagicalCriticalBonus;
			switch ( this.resistance)
			{
				case Resistances.Arcane: critical += src.ArcaneCriticalBonus; break;
				case Resistances.Frost: critical += src.FrostCriticalBonus; break;
				case Resistances.Fire: critical += src.FireCriticalBonus; break;
				case Resistances.Nature: critical += src.NatureCriticalBonus; break;
				case Resistances.Shadow: critical += src.ShadowCriticalBonus; break;
				case Resistances.Light: critical += src.HolyCriticalBonus; break;
			}
			#region CriticalChanceTalentsHandling
			if (src.Level > 9)
			{
				switch(src.Classe)
				{
					case Classes.Warlock:
						#region Warlock
						//devastation
						if ( AbilityClasses.abilityClasses[ (int)Id ] == (int)ClassesOfSpells.Destruction )
							if ( src.HaveTalent( Talents.Devastation) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Devastation );
								critTalentBonus +=ae.S1; 
							}
						// improved searing pain
						if ( src.HaveTalent( Talents.ImprovedSearingPain ) &&
							SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 5676 ] )
						{
							AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.MasterHealer );
							critTalentBonus += ae.S1;
						}
						#endregion
						break;
					case Classes.Mage:
						#region Mage
						// Incinerate
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2138 ] || // fire blast
							SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 10205 ])//	scorch
							if ( src.HaveTalent( Talents.Incinerate ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Incinerate );
								critTalentBonus += ae.S1;
							}
						// FlameStrike
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 10215 ])//	scorch
							if ( src.HaveTalent( Talents.ImprovedFlamestrike ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedFlamestrike );
								critTalentBonus += ae.S1;
							}
						// Combustion
						if( src.HaveTalent(Talents.Combustion))
						{
							if(this.resistance == Resistances.Fire)
							{
								bool bonus = false;
								ArrayList al1 = new ArrayList();
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Combustion );
								foreach( Mobile.AuraReleaseTimer art in src.Auras )
									if(art.aura.SpecialState == SpecialStates.Combustion)
									{
										bonus = true;
										al1.Add(art);
									}

								if (bonus) 
								{
									critTalentBonus +=100;
									foreach( Mobile.AuraReleaseTimer art in al1)
										src.ReleaseAura(art);
								}
							}
								
						}
						#endregion
						break;
					case Classes.Druid:
						#region Druid
						
						#endregion
						break;
					case Classes.Warrior:
						#region warrior
						// Improved Overpower
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 7384 ]) // overpower
							if ( src.HaveTalent( Talents.ImprovedOverpower ) )
							{
								AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.ImprovedOverpower);
								critTalentBonus += ae.S1;
							}
						#endregion
						break;
				}
			}
			#endregion
			critical +=critTalentBonus;
			if ( critical > roll )
			{
				src.LastSpellStatus = AttackStatus.Critical;
				#region CriticalDamageBonusHandling
				if (src.Level > 9)
				{
					switch(src.Classe)
					{
						case Classes.Warlock:
							#region Warlock
							// ruin
							if(src.HaveTalent( Talents.Ruin ) )
								if ( AbilityClasses.abilityClasses[ (int)Id ] == (int)ClassesOfSpells.Destruction )
								{
									AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Ruin );
									criticalDamageTalentBonus +=100;
								}
							#endregion
							break;
						case Classes.Mage:
							#region Mage
							// Ice shards
							if ( AbilityClasses.abilityClasses[this.Id] == (int)ClassesOfSpells.Frost)//	
								if ( src.HaveTalent( Talents.IceShards ) )
								{
									AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.IceShards );
									criticalDamageTalentBonus += ae.S1;
								}
							// Shatter
							if ( resistance == Resistances.Frost)
							{
								if ( src.HaveTalent( Talents.Shatter ) ) 
								{
									if (IsFrozen(target)) 
									{
										AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.Shatter );
										
										switch (ae.Id)
										{
											case 11170 :criticalDamageTalentBonus +=10;
												break;
											case 12982 :criticalDamageTalentBonus +=20;
												break;
											case 12983 :criticalDamageTalentBonus +=30;
												break;
											case 12984 :criticalDamageTalentBonus +=40;
												break;
											case 12985 :criticalDamageTalentBonus +=50;
												break;
										}
									}
								}
							}
							#endregion
							break;
						case Classes.Druid:
							#region Druid
						
							#endregion
							break;
						case Classes.Warrior:
							#region warrior
							
							#endregion
							break;
					}
				}
				#endregion
				crit = 1.5f + (float)criticalDamageTalentBonus/100;
			}	
			#endregion
			
			return crit;
		}		
		#endregion
		#endregion
		#region WEAPONDAMAGEPLUS
		public int WeaponDMGPlusSchool( Mobile src, Mobile target, float dmg,bool school )
		{
			if ( target.Dead ) return 0;

			
			int absorb = 0;
			int resist = 0;
			int absorbHit = 0;
			int blockHit = 0;
			LastSpellState state = LastSpellState.None;
			int weapondmg = src.Hit(target,ref blockHit,ref absorbHit);
			if(weapondmg > 0)
			{
				int realDamage = this.SpellDMG(src,target,dmg,ref absorb,ref resist,ref state,true);
					absorb +=absorbHit;
				realDamage +=weapondmg;
				if(state == LastSpellState.Critical || src.LastAttackStatus == AttackStatus.Critical)
					state = LastSpellState.Critical;
				if(school)
					this.SendDamageMessage(src,target,state,realDamage,resist,absorb,-1,false);
				else
					this.SendDamageMessage(src,target,state,realDamage,resist,absorb,blockHit,false);	
				
				if ( realDamage > target.HitPoints )
					realDamage = target.HitPoints;

				target.LooseHits( src, (int)realDamage, false );	
				if ( target.SummonedBy != src )
					target.OnGetHit( src, false, (int)realDamage );
		
				src.LastSpellStatus = AttackStatus.None;
				
				return realDamage;
			}
			else
			{
				return 0;
			}
		}
		
		#endregion
		#region MAKE MANA DAMAGE
		public int MakeManaDamage( Mobile src, Mobile target, float dmg )
		{
			return MakeManaDamage( src, target, dmg, true );
		}
		public int MakeManaDamage( Mobile src, Mobile target, float dmg, bool f )
		{
			if ( target.Dead )
				return 0;
			if (this.ImmuneCheck(target,this)) return 0;
			float roll2 = (float)Utility.RandomDouble();
			float avarageResistance = this.ResistCalculation(src, target);
			if (roll2 < avarageResistance)
				return 0;
			Console.WriteLine("MAGIC HIT damage: " + dmg);
		
			#region bovies hit chance calculation
			float dif = dif = (float)(5*src.Level - target.Level*5)/5;
			float hitChance = 0;
			if (src is Character && target is Character)
				hitChance = 95;
			else
			{
				if (dif > 0 ) hitChance = 95 + (int)dif;
				else if (target.Level > src.Level + 3) hitChance = 95 - (int)dif * 15;
				else hitChance = 95 - (int)dif * 10;
				if(hitChance >= 99) hitChance = 99;
				if(hitChance <= 1) hitChance = 1; 
			}
			int roll = Utility.Random( 100 );
			Console.WriteLine("hit chance =" + hitChance + " " + roll );
			if (roll >= hitChance)
			{
				return 0;
			}
			#endregion
			float res = 0f;
			float spellMod = 1.0f;
			switch( resistance )
			{
				case Resistances.Fire:
					res = (float)target.ResistFire / 200f;
					spellMod = FireSpellModifier( src );
					break;
				case Resistances.Frost:
					res = (float)target.ResistFrost / 200f;
					spellMod = FrostSpellModifier( src );					
					break;
				case Resistances.Light:
					res = (float)target.ResistHoly / 200f;
					spellMod = LightSpellModifier( src );
					break;
				case Resistances.Arcane:
					res = (float)target.ResistArcane / 200f;
					spellMod = ArcaneSpellModifier( src );
					break;
				case Resistances.Shadow:
					res = (float)target.ResistShadow / 200f;
					spellMod = ShadowSpellModifier( src );
					break;
				case Resistances.Nature:
					res = (float)target.ResistNature / 200f;
					spellMod = NatureSpellModifier( src );
					break;
				case Resistances.Armor:
					res = (float)target.Armor / 3000f;
					break;
			}
			if ( res == 0f && target is BaseCreature )
				res = ( target.Level * 3 ) / 200f;
			res = 1 - res;
			dmg *= res * spellMod;
			int realDamage = 0;
			switch( resistance )
			{
				case Resistances.Fire:
					realDamage = target.DiminishFireAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );					
					break;
				case Resistances.Frost:
					realDamage = target.DiminishFrostAbsordb( (int)dmg );	
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Light:
					realDamage = target.DiminishHolyAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Arcane:
					realDamage = target.DiminishArcaneAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Shadow:
					realDamage = target.DiminishShadowAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Nature:
					realDamage = target.DiminishNatureAbsordb( (int)dmg );
					realDamage = target.DiminishAbsordbAll( realDamage );	
					break;
				case Resistances.Armor:
					break;
			}

			if ( realDamage > target.Mana )
				realDamage = target.Mana;

			target.LooseMana( src, realDamage );
			return realDamage;
		}
	
		public int MakeManaDamage( Mobile src, Mobile target, SpellDamage sd )
		{
			int basedmg = 1;
			int amount = 1;
			switch( sd )
			{
				case SpellDamage.TypeS1:
					basedmg = s1;
					amount = this.bonus1;
					break;
				case SpellDamage.TypeS2:
					basedmg = s2;
					amount = bonus2;
					break;
			}
			float dmg = (float)( basedmg + Utility.Random( 1, amount ) );
			return MakeManaDamage( src, target, dmg );
		}
		#endregion
		#region MAKE AREA DAMAGE
		public ArrayList MakeAreaDamage( Mobile src, SpellDamage sd, float area, float X, float Y, float Z )
		{
			ArrayList targets = new ArrayList();
			float a = area * area;
			if ( src is Character )
			{
				foreach( Object o in ( src as Character ).KnownObjects )
				{
					if ( o is Mobile && o != src )
					{
						Mobile t = ( o as Mobile );
						//Console.WriteLine("Distance {0}", t.Distance( X, Y, Z ) );
						if ( t.Distance( X, Y, Z ) < area )
							targets.Add( t );
					}
				}
			}
			else
			{
				foreach( Mobile t in World.allMobiles )
				{
					if ( t.Distance( X, Y, Z ) < area )
						targets.Add( t );
				}
			}
			foreach( Mobile m in targets )
				MakeDamage( src, m, sd );
			return targets;
		}

	
		#endregion
		#region INTERUPT CASTING
		public int InterruptCasting(Mobile from, Mobile target)
		{
			float roll2 = (float)Utility.RandomDouble();
			float avarageResistance = this.ResistCalculation(from, target);
			if (roll2 < avarageResistance)
			{
				#region update
				if ( from is Character )
				{
					int offset = 4;
					Converter.ToBytes( target.Guid, target.tempBuff, ref offset );
					Converter.ToBytes( from.Guid, target.tempBuff, ref offset );
					Converter.ToBytes( (int)Id, target.tempBuff, ref offset );
					Converter.ToBytes( 0, target.tempBuff, ref offset );
					Converter.ToBytes( 0x2, target.tempBuff, ref offset );
					Converter.ToBytes( (ushort)0x100, target.tempBuff, ref offset );
					Converter.ToBytes( target.Guid, target.tempBuff, ref offset );
					//Converter.ToBytes( 0x0, target.tempBuff, ref offset );			
					( from as Character ).Send( OpCodes.SMSG_SPELLNONMELEEDAMAGELOG, target.tempBuff, offset );
				}
				#endregion
				return 0;
			}
		
			#region bovies hit chance calculation
			float dif = dif = (float)(5*from.Level - target.Level*5)/5;
			float hitChance = 0;
			if (from is Character && target is Character)
				hitChance = 95;
			else
			{
				if (dif > 0 ) hitChance = 95 + (int)dif;
				else if (target.Level > from.Level + 3) hitChance = 95 - (int)dif * 15;
				else hitChance = 95 - (int)dif * 10;
				if(hitChance >= 99) hitChance = 99;
				if(hitChance <= 1) hitChance = 1; 
			}
			int roll = Utility.Random( 100 );
			if (roll >= hitChance)
			{
				return 0;
			}
			#endregion
			return target.InterruptCasting();
		}
		#endregion
		#region RUN SPEED CHANGE
		public static void OnCastSpeedModEnd( Mobile m )
		{
			m.ChangeRunSpeed( m.RunSpeed );
		}
		#endregion
		#endregion

		#region PROPERTIES
		public static Hashtable SpellEffects = new Hashtable();
		int levelMin;
		int levelMax;
		DispelType dispeltype;
		//	int degatMin;
		int bonus1;
		int bonus2;
		Resistances resistance;
		int classe;
		int manaCost;
		int s1;
		int s2;
		int s3;
		int h;		
		int additionalSpell;

		int castingTime;
		byte range;
		int duration;
		
		int t1;
		int t2;

		int radius1;
		int radius2;
		int radius3;
		#endregion

		#region CONSTRUCTORS
		public SpellTemplate( ushort _id,int _customFlags1,  int _add,
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, 
			int _s1, int _s2, int _s3, 
			Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _h, int _radius1, int _radius2, int _radius3, int _classe	) : base( _id, _customFlags1,  _cooldown )
		{
			h = _h;
			additionalSpell = _add;
			levelMin = _levelMin;
			levelMax = _levelMax;
			resistance = _res;
			classe = _classe;
			manaCost = _manacost;
			castingTime = _castingtime;
			range = _range;
			duration = _duration;
			s1 = _s1;
			s2 = _s2;
			s3 = _s3;
			bonus1 = _bonus1;
			bonus2 = _bonus2;
			dispeltype = _dis;
		}
		public SpellTemplate( ushort _id,int _customFlags1,  int _add, 
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _h, int _radius1, int _radius2, int _radius3, int _classe	) : base( _id,_customFlags1,  _cooldown )
		{
			h = _h;
			additionalSpell = _add;
			levelMin = _levelMin;
			levelMax = _levelMax;
			resistance = _res;
			classe = _classe;
			manaCost = _manacost;
			castingTime = _castingtime;
			range = _range;
			duration = _duration;
			s1 = _s1;
			s2 = _s2;
			s3 = _s3;
			bonus1 = _bonus1;
			bonus2 = _bonus2;
			t1 = _t1;
			t2 = _t2;
			radius1 = _radius1;
			radius2 = _radius2;
			radius3 = _radius3;
			dispeltype = _dis;
		}
		public SpellTemplate( ushort _id,int _customFlags1,  
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, 
			int _s1, int _s2, int _s3, 
			Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _h, int _radius1, int _radius2, int _radius3, int _classe	) : base( _id,_customFlags1,  _cooldown )
		{
			h = _h;
			levelMin = _levelMin;
			levelMax = _levelMax;
			resistance = _res;
			classe = _classe;
			manaCost = _manacost;
			castingTime = _castingtime;
			range = _range;
			duration = _duration;
			s1 = _s1;
			s2 = _s2;
			s3 = _s3;
			bonus1 = _bonus1;
			bonus2 = _bonus2;
			radius1 = _radius1;
			radius2 = _radius2;
			radius3 = _radius3;
			dispeltype = _dis;
		}
		public SpellTemplate( ushort _id, int _customFlags1, 
			int _levelMin, int _levelMax, int _bonus1, int _bonus2, int _s1, int _s2, int _s3, 
			int _t1, int _t2, Resistances _res, DispelType _dis,
			int _manacost, int _castingtime, byte _range, int _duration, int _cooldown, 
			int _h, int _radius1, int _radius2, int _radius3, int _classe	) : base( _id,_customFlags1,  _cooldown )
		{
			h = _h;
			levelMin = _levelMin;
			levelMax = _levelMax;
			resistance = _res;
			dispeltype = _dis;
			classe = _classe;
			manaCost = _manacost;
			castingTime = _castingtime;
			range = _range;
			duration = _duration;
			s1 = _s1;
			s2 = _s2;
			s3 = _s3;
			bonus1 = _bonus1;
			bonus2 = _bonus2;
			t1 = _t1;
			t2 = _t2;
			radius1 = _radius1;
			radius2 = _radius2;
			radius3 = _radius3;
		}
		#endregion

		#region ACCESSORS
		//need modifications talents modif this too
		public int GetManaCost(Mobile c)
		{
			int mc = manaCost;
			switch (c.Classe)
			{
					#region mage
				case Classes.Mage:
					// frost channeling
					if ( resistance == Resistances.Frost )
					{
						if ( c.HaveTalent( Talents.FrostChanneling ) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.FrostChanneling );
							mc = (int)(mc * 1 + (float)ae.S1/100); 
						}
					}
					//arcane concentration
					int ClearingState = 0xd45a45;
					if ( c.AdditionnalStates.Contains(ClearingState))
					{
						AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.ArcaneConcentration);
						mc +=ae.S1;
						c.AdditionnalStates.Remove(ClearingState);
					}
					// ArcanePower
					if( c.HaveTalent(Talents.ArcanePower))
					{
						bool bonus = false;
						ArrayList al1 = new ArrayList();
						AuraEffect af = (AuraEffect)c.GetTalentEffect( Talents.ArcanePower );
						foreach( Mobile.AuraReleaseTimer art in c.Auras )
							if(art.aura.SpecialState == SpecialStates.ArcanePower)
							{
								bonus = true;
								al1.Add(art);
							}

						if (bonus) 
						{
							mc = (int)(mc * (1 + (float)af.S1/100));
						}
					}

					break;
					#endregion
					#region warrior
				case Classes.Warrior:
					// improved heroic strike
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 284 ] )//herroic strike
						if ( c.HaveTalent( Talents.ImprovedHeroicStrike) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.ImprovedHeroicStrike );
							mc += ae.S1; 
						}
					//improved thunder clap
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 6343 ] )//	Thunder clap
						if ( c.HaveTalent( Talents.ImprovedThunderClap ) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.ImprovedThunderClap );
							mc += ae.s1;
						}
					//improved sunder armor
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 11597 ] )//	Sunder aromr
						if ( c.HaveTalent( Talents.ImprovedSunderArmor ) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.ImprovedSunderArmor );
							mc += ae.s1;
						}
					// improved execute
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 5308 ] )//execute
						if ( c.HaveTalent( Talents.ImprovedExecute) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.ImprovedExecute );
							mc += ae.S1; 
						}

					break;
					#endregion
					#region Warlock
				case Classes.Warlock:
					if ( AbilityClasses.abilityClasses[ (int)Id ] == (int)ClassesOfSpells.Destruction )
						if ( c.HaveTalent( Talents.Cataclysm) )
						{
							AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.Cataclysm );
							mc = (int)(mc*(1 + (float)ae.S1/100)); 
						}
					// fel domination
					if( c.HaveTalent(Talents.FelDomination))
					{
						bool bonus = false;
						ArrayList al1 = new ArrayList();
						AuraEffect ae = (AuraEffect)c.GetTalentEffect( Talents.FelDomination );
						foreach( Mobile.AuraReleaseTimer art in c.Auras )
							if(art.aura.SpecialState == SpecialStates.FelDomination)
							{
								bonus = true;
								al1.Add(art);
							}
						if (bonus) 
						{
							mc = (int)(mc*0.5);
						}
					}
					break;
					#endregion
			}
			switch( this.resistance )
			{
				case Resistances.Fire:
					mc -= c.FireCostMalus;
					break;
				case Resistances.Frost:
					mc -= c.FrostCostMalus;
					break;
				case Resistances.Light:
					mc -= c.HolyCostMalus;
					break;
				case Resistances.Arcane:
					mc -= c.ArcaneCostMalus;
					break;
				case Resistances.Shadow:
					mc -= c.ShadowCostMalus;
					break;
				case Resistances.Nature:
					mc -= c.NatureCostMalus;
					break;
			}
			mc -=c.AllCostMalus;
			int val = 0;
			
			mc -= val;
			mc =(int)((float)mc * c.PowerCostModifier);
			
			#region Cost for ability
			foreach(Mobile.AuraReleaseTimer art in c.Auras)
			{
				if (art.aura.CostEffectedAbilityList != 0)
				{
					if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] != null)
					{
						if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] is ArrayList)
						{
							if((c.SpecialForAuras[art.aura.CostEffectedAbilityList] as ArrayList).Contains((int)this.Id))
								mc =(int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
						}
						if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] is int)
						{
							int list = (int)c.SpecialForAuras[art.aura.CostEffectedAbilityList];
							if( list == this.Id)
								mc = (int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
						}
					}

				}
				if (art.aura.CostEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CostEffectedAbilityClass )
					{
						mc = (int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
					}
				}
			}
			foreach(PermanentAura art in c.PermanentAuras)
			{
				if (art.aura.CostEffectedAbilityList != 0)
				{
					if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] != null)
					{
						if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] is ArrayList)
						{
							if((c.SpecialForAuras[art.aura.CostEffectedAbilityList] as ArrayList).Contains((int)this.Id))
							{
								mc =(int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
							}
						}
						if (c.SpecialForAuras[art.aura.CostEffectedAbilityList] is int)
						{
							int list = (int)c.SpecialForAuras[art.aura.CostEffectedAbilityList];
							if( list == this.Id)
								mc = (int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
						}
					}

				}
				if (art.aura.CostEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CostEffectedAbilityClass )
					{
						mc = (int)((mc + art.aura.CostBonusForAbility)*art.aura.CostModificatorForAbility);
					}
				}
			}
				
			#endregion
			
			if (mc <=0) mc = 0;
			return mc;
		}
		public virtual int Duration()
		{
			return this.duration;
		}
		public virtual int Duration( Mobile from )
		{
			int dur = duration;
			
			switch (from.Classe)
			{
				case Classes.Mage:
					// Permafrost
					if ( resistance == Resistances.Frost )
					{
						if ( from.HaveTalent( Talents.Permafrost ) &&  SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 12485 ]  )
						{
							AuraEffect ae = (AuraEffect)from.GetTalentEffect( Talents.Permafrost );
							return duration + ae.S1;
						}
					}
					break;
				case Classes.Warrior:
					// Improved shield block
					if ( from.HaveTalent( Talents.ImprovedShieldBlock ) &&  SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2565 ]  )
						{
							AuraEffect ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedShieldBlock );
							return duration + ae.S2;
						}
					// improved disarm
					if ( from.HaveTalent( Talents.ImprovedDisarm ) &&  SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 676 ]  )
					{
						AuraEffect ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedDisarm );
						return duration + ae.S2;
					}
					// improved shield wall
					if ( from.HaveTalent( Talents.ImprovedShieldWall ) &&  SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 871 ]  )
					{
						AuraEffect ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedShieldWall );
						return duration + ae.S2;
					}
					break;
			}
			
			#region Duration for ability
			foreach(Mobile.AuraReleaseTimer art in from.Auras)
			{
				if (art.aura.DurationEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.DurationEffectedAbilityList] as ArrayList).Contains((int)this.Id))
								dur =(int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
						}
						if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.DurationEffectedAbilityList];
							if( list == this.Id)
								dur = (int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
						}
					}

				}
				if (art.aura.DurationEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.DurationEffectedAbilityClass )
					{
						dur = (int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
					}
				}
			}
			foreach(PermanentAura art in from.PermanentAuras)
			{
				if (art.aura.DurationEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.DurationEffectedAbilityList] as ArrayList).Contains((int)this.Id))
							{
								dur =(int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
							}
						}
						if (from.SpecialForAuras[art.aura.DurationEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.DurationEffectedAbilityList];
							if( list == this.Id)
								dur = (int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
						}
					}

				}
				if (art.aura.DurationEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.DurationEffectedAbilityClass )
					{
						dur = (int)((dur + art.aura.DurationBonusForAbility)*art.aura.DurationModificatorForAbility);
					}
				}
			}
				
			#endregion
			return dur;
		}
		public int GetRadius(Mobile from, int number)
		{
			int rad = 0;
			switch (number)
			{
				case 1: rad = Radius1;break;
				case 2: rad = Radius2;break;
				case 3: rad = Radius3;break;
				default:return 0;
			}
			#region Radius for ability
			foreach(Mobile.AuraReleaseTimer art in from.Auras)
			{
				if (art.aura.RadiusEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] as ArrayList).Contains((int)this.Id))
								rad =(int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
						}
						if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.RadiusEffectedAbilityList];
							if( list == this.Id)
								rad = (int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
						}
					}

				}
				if (art.aura.RadiusEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.RadiusEffectedAbilityClass )
					{
						rad = (int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
					}
				}
			}
			foreach(PermanentAura art in from.PermanentAuras)
			{
				if (art.aura.RadiusEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] as ArrayList).Contains((int)this.Id))
							{
								rad =(int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
							}
						}
						if (from.SpecialForAuras[art.aura.RadiusEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.RadiusEffectedAbilityList];
							if( list == this.Id)
								rad = (int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
						}
					}

				}
				if (art.aura.RadiusEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.RadiusEffectedAbilityClass )
					{
						rad = (int)((rad + art.aura.RadiusBonusForAbility)*art.aura.RadiusModificatorForAbility);
					}
				}
			}
				
			#endregion
			return rad;

		}

		public override int CastingTime( Mobile from )
		{
			int ct = castingTime;
			AuraEffect ae = null;
			switch(from.Classe)
			{
				#region warrior
				case Classes.Warrior:
					// Improved Slam
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 1464 ] )//	Slam
						if ( from.HaveTalent( Talents.ImprovedSlam ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedSlam );
							ct += ae.S1;
						}
					break;
				#endregion
				#region warlock
				case Classes.Warlock:
					// bane
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 686 ] || // Shadow bolt
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 348 ] ) // Immolate
						if ( from.HaveTalent( Talents.Bane ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.Bane );
							ct += ae.S1;
						}
					//improved corruption
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 172 ] ) // Corruption
						if ( from.HaveTalent( Talents.ImprovedCorruption ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedCorruption );
							ct += ae.S1;
						}
					//master summoner
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 688 ] ||// summon imp
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 712 ] ||// succubus
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 691 ] ||// summon felhunter
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 597 ] ) // summon voidwalker
						if ( from.HaveTalent( Talents.MasterSummoner ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.MasterSummoner );
							ct += ae.S1;
						}
					// nightfall
					if ( from.ShadowTrance && SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 686 ] )
					{
						from.ReleaseAura( (AuraEffect)Abilities.abilities[ 17941 ] );
						return 10;
					}
					// fel domination
					if( from.HaveTalent(Talents.FelDomination))
					{
						bool bonus = false;
						ArrayList al1 = new ArrayList();
						AuraEffect af = (AuraEffect)from.GetTalentEffect( Talents.FelDomination );
						foreach( Mobile.AuraReleaseTimer art in from.Auras )
							if(art.aura.SpecialState == SpecialStates.FelDomination)
							{
								bonus = true;
								al1.Add(art);
							}
						if (bonus) 
						{
							ct += af.S1;
							foreach( Mobile.AuraReleaseTimer art in al1)
								from.ReleaseAura(art);
						}
					}
					break;
				#endregion
				#region shaman
				case Classes.Shaman:
					// lightining mastery
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 403] || //lightining bolt
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 421 ] )//chain lightining
						if ( from.HaveTalent( Talents.LightningMastery) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.LightningMastery );
							ct += ae.S1;
						}
					// improved healing wave
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 331 ] )//healing wave
						if ( from.HaveTalent( Talents.ImprovedHealingWave) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedHealingWave );
							ct += ae.S1;
						}
					// improved ghost wolf
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2645 ] )//ghost wolf
						if ( from.HaveTalent( Talents.ImprovedGhostWolf) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedGhostWolf );
							ct += ae.S1;
						}

					break;
				#endregion
				case Classes.Rogue:break;
				#region priest
				case Classes.Priest:
					// improved mana burn
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 8129 ] )//	Mana burn
						if ( from.HaveTalent( Talents.ImprovedManaBurn ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedManaBurn );
							ct += ae.S1;
						}
					// divine fury
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 585 ] ||//	Smite
							SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 14914 ] )// holy fire
						if ( from.HaveTalent( Talents.DivineFury ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.DivineFury );
							ct += ae.S1;
						}
					// master healer
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 6063 ] ||//	Heal
						SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2060 ] )//	Greater heal
						if ( from.HaveTalent( Talents.MasterHealer ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.MasterHealer );
							ct += ae.S1;
						}
					break;
				#endregion
				case Classes.Paladin:break;
				#region mage
				case Classes.Mage:
					// Improved fireball
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 133 ] )//	Fireball
						if ( from.HaveTalent( Talents.ImprovedFireball ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedFireball );
							ct += ae.S1;
						}
					// Improved FrostBolt
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 116 ] )//		FrostBolt
						if ( from.HaveTalent( Talents.ImprovedFrostbolt ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedFrostbolt );
							ct += ae.S1;
						}
					// Improved Arcane Explosion
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 1449 ] )//	Arcane explosion
						if ( from.HaveTalent( Talents.ImprovedArcaneExplosion ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedArcaneExplosion );
							ct += ae.S1;
						}
					// Presence of mind
					if( from.HaveTalent(Talents.PresenceOfMind))
					{
						bool bonus = false;
						ArrayList al1 = new ArrayList();
						AuraEffect af = (AuraEffect)from.GetTalentEffect( Talents.PresenceOfMind );
						foreach( Mobile.AuraReleaseTimer art in from.Auras )
							if(art.aura.SpecialState == SpecialStates.PresenceOfMind)
							{
								bonus = true;
								al1.Add(art);
							}

							if (bonus) 
							{
								foreach( Mobile.AuraReleaseTimer art in al1)
									from.ReleaseAura(art);
								return 0;
							}								
					}
					
					break;
				#endregion
				#region hunter
				case Classes.Hunter:
					// improved revive pet
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 982 ] )//revive pet
						if ( from.HaveTalent( Talents.ImprovedRevivePet) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedRevivePet );
							ct += ae.S1;
						}
					break;
				#endregion
				#region druid
				case Classes.Druid:
					// improved wrath
					if (SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 16814 ] )//wrath
						if ( from.HaveTalent( Talents.ImprovedWrath) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedWrath );
							ct += ae.S1;
						}
					break;
				#endregion
			}
			#region other - pets

			// improved firebolt
			if ( from.SummonedBy != null )
			{
				if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 3110 ] )//	Firebolt
					if ( from.SummonedBy.HaveTalent( Talents.ImprovedFirebolt ) )
					{
						ae = (AuraEffect)from.SummonedBy.GetTalentEffect( Talents.ImprovedFirebolt );
						ct += ae.S1;

					}
			}
			#endregion
			
			#region CastingTime for ability
			foreach(Mobile.AuraReleaseTimer art in from.Auras)
			{
				if (art.aura.CastingTimeEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] as ArrayList).Contains((int)this.Id))
								ct =(int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
						}
						if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList];
							if( list == this.Id)
								ct = (int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
						}
					}

				}
				if (art.aura.CastingTimeEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CastingTimeEffectedAbilityClass )
					{
						ct = (int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
					}
				}
			}
			foreach(PermanentAura art in from.PermanentAuras)
			{
				if (art.aura.CastingTimeEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] as ArrayList).Contains((int)this.Id))
							{
								ct =(int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
							}
						}
						if (from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.CastingTimeEffectedAbilityList];
							if( list == this.Id)
								ct = (int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
						}
					}

				}
				if (art.aura.CastingTimeEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CastingTimeEffectedAbilityClass )
					{
						ct = (int)((ct + art.aura.CastingTimeBonusForAbility)*art.aura.CastingTimeModificatorForAbility);
					}
				}
			}
				
			#endregion
			if (!(ct <=0))
			{
					ct = (int)((float)ct/from.CastingSpeed);
			}
			
			return ct; 
		}

		public int Range( Mobile from )
		{
			int rng = range;
			if ( from.Classe == Classes.Warlock && 
				( resistance == Resistances.Fire ||
				SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 686 ] ||
				SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 17877 ] ) )
				if ( from.HaveTalent( Talents.DestructiveReach ) )
				{
					AuraEffect ae = (AuraEffect)from.GetTalentEffect( Talents.DestructiveReach );
					float r = (float)range;
					r += r * -(float)( ae.S1 ) / 100f;
					rng = (int)r;
				}
		
			return rng;
		}
		
		public DispelType Dispeltype
		{
			get { return dispeltype; }
		}
		public int ManaCost
		{
			set { manaCost = value; }
		}   
		public int Radius1
		{
			get { return radius1; }
		}
		public int Radius2
		{
			get { return radius2; }
		}
		public int Radius3
		{
			get { return radius3; }
		}
	
		public int AdditionalSpell
		{
			get { return additionalSpell; }
		}  
		public int RequieredLevel
		{
			get { return levelMin; }
		}

		public int Bonus1
		{
			get { return bonus1; }
		}
		public int Bonus2
		{
			get { return bonus2; }
		}
		public int S1
		{
			get { return s1; }
		}
		public int S2
		{
			get { return s2; }
		}
		public int S3
		{
			get { return s3; }
		}
		public int H
		{
			get { return h; }
		}
		public int T1
		{
			get { return t1; }
		}
		public int T2
		{
			get { return t2; }
		}
		#endregion

		#region ASSIGN SPELLS
		public static void SetSpellEffects( int []ids, OnSelfSpellEffectMultiple st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, SingleTargetSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, PermanentSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, SingleTargetSpellEffectMultiple st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, GameObjectTargetSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, OnSelfSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, OnSelfItemSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		public static void SetSpellEffects( int []ids, TargetXYZSpellEffect st )
		{
			foreach( int i in ids )
			{
				if ( SpellEffects[ i ] != null )
					Console.WriteLine( "Spell id {0} already defined !!!", i );
				else
				{
					SpellEffects[ i ] = st;
				}
			}
		}
		#endregion

		#region SKILLS
		static ArcaneSkill arcaneSkill = new ArcaneSkill();
		static FireSkill fireSkill = new FireSkill();
		static Destruction destructionSkill = new Destruction();
		#endregion

		#region MODIFIERS
		#region Spells modifiers
		float FireSpellModifier( Mobile from )
		{
			float mod = 1.0f;
				
			return mod;
		}
		float FrostSpellModifier( Mobile from )
		{
			float mod = 1.0f;
			return mod;
		}
		float ShadowSpellModifier( Mobile from )
		{
			float mod = 1.0f;
			
			return mod;
		}
		float NatureSpellModifier( Mobile from )
		{
			float mod = 1.0f;
			AuraEffect ae = null;
			if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2606 ] )//	Shock
				if ( from.HaveTalent( Talents.Concussion ) )
				{
					ae = (AuraEffect)from.GetTalentEffect( Talents.Concussion );
					mod += (float)( ae.s1 ) / 100f;
				}
				else
					
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 324 ] )//	Lightning shield
					if ( from.HaveTalent( Talents.ImprovedLightningShield ) )
					{
						ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedLightningShield );
						mod += (float)( ae.s1 ) / 100f;
					}
			return mod;
		}
		float ArcaneSpellModifier( Mobile from )
		{
			float mod = 1.0f;
			return mod;
		}
		float LightSpellModifier( Mobile from )
		{
			float mod = 1.0f;
			return mod;
		}		
		#endregion
		#region Heal modifier
		public float LightSpellHealModifier( Mobile from )
		{
			float mod = 1.0f;
			AuraEffect ae = null;
			if ( from.HaveTalent( Talents.SpiritualHealing )  )
			{
				ae = (AuraEffect)from.GetTalentEffect( Talents.SpiritualHealing );
				mod += (float)( ae.s1 ) / 100f;
			}
			if ( from.HaveTalent( Talents.ImprovedHolyLight )  )
			{
				ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedHolyLight );
				mod += (float)( ae.s1 ) / 100f;
			}
			
			if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 6078 ] )//	Renew
				if ( from.HaveTalent( Talents.ImprovedRenew ) )
				{
					ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedRenew );
					mod += (float)( ae.s1 ) / 100f;
				}
			return mod;
		}
		public float NatureSpellHealModifier( Mobile from )
		{
			float mod = 1.0f;
			AuraEffect ae = null;
			if ( from.HaveTalent( Talents.SpiritualHealing )  )
			{
				ae = (AuraEffect)from.GetTalentEffect( Talents.SpiritualHealing );
				mod += (float)( ae.s1 ) / 100f;
			}
			if ( from.HaveTalent( Talents.ImprovedHolyLight )  )
			{
				ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedHolyLight );
				mod += (float)( ae.s1 ) / 100f;
			}
			if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 13542 ] )//	Mend pet
				if ( from.HaveTalent( Talents.ImprovedRenew ) )
				{
					ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedRenew );
					mod += (float)( ae.s1 ) / 100f;
				}
			return mod;
		}
		
		#endregion

		#endregion

		#region SPELL MANAGMENT
		public bool SkillCheck(Mobile.Casting cast, Mobile c )
		{
			if ( !( c is Character ) )
			{
				c.SpellSuccess();
				return false;
			}
			if ( resistance == Resistances.Arcane )
			{
				Skill sk = c.AllSkills[ (ushort)arcaneSkill.Id ];
				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					int rdiff = sk.CurrentVal(c);
					int res = sk.IqSkillCheck( c, rdiff );
					if ( c is Character && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, rdiff, 5 ) )
					{						
						sk.Current++;
						( c as Character ).SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[]{ (int)arcaneSkill.Id, (short)arcaneSkill.CurrentVal(c), (short)arcaneSkill.Cap( c ), (int)0 } );
					}
					if ( res > 25 )
						c.SpellSuccess();
					else
						c.SpellFaillure( SpellFailedReason.Fizzled );
				}
			}
			else
				if ( resistance == Resistances.Frost )
			{
				Skill sk = c.AllSkills[ (ushort)arcaneSkill.Id ];
				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					int rdiff = sk.CurrentVal(c);
					int res = sk.IqSkillCheck( c, rdiff );
					if ( c is Character && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, rdiff, 5 ) )
					{
						sk.Current++;
						( c as Character ).SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[]{ (int)arcaneSkill.Id, (short)arcaneSkill.CurrentVal(c), (short)arcaneSkill.Cap( c ), (int)0 } );
					}					
					
					c.SendSmallUpdateToPlayerNearMe( new int[]{ 23 + c.ManaType }, new object[] { c.Mana } );
					if ( res > -25 )
						c.SpellSuccess();
					else
						c.SpellFaillure( SpellFailedReason.Fizzled );
				}
			}
			else
				if ( resistance == Resistances.Fire && ( c as Character ).Classe == Classes.Warlock )
			{
				Skill sk = c.AllSkills[ (ushort)Destruction.SkillId ];
				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					int rdiff = sk.CurrentVal(c);
					int res = sk.SpiritSkillCheck( c, rdiff );
					if ( c is Character && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, rdiff, 5 ) )
					{
						sk.Current++;
						( c as Character ).SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[]{ (int)arcaneSkill.Id, (short)arcaneSkill.CurrentVal(c), (short)arcaneSkill.Cap( c ), (int)0 } );
					}					
					
					c.SendSmallUpdateToPlayerNearMe( new int[]{ 23 + c.ManaType }, new object[] { c.Mana } );
					if ( res > -25 )
						c.SpellSuccess();
					else
						c.SpellFaillure( SpellFailedReason.Fizzled );
				}
			}
			else
				if ( resistance == Resistances.Fire )
			{
				Skill sk = c.AllSkills[ (ushort)fireSkill.Id ];
				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					int rdiff = sk.CurrentVal(c);
					int res = sk.IqSkillCheck( c, rdiff );
					if ( c is Character && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, rdiff, 5 ) )
					{
						sk.Current++;
						( c as Character ).SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[]{ (int)arcaneSkill.Id, (short)arcaneSkill.CurrentVal(c), (short)arcaneSkill.Cap( c ), (int)0 } );
					}					
					
					c.SendSmallUpdateToPlayerNearMe( new int[]{ 23 + c.ManaType }, new object[] { c.Mana } );
					if ( res > -25 )
						c.SpellSuccess();
					else
						c.SpellFaillure( SpellFailedReason.Fizzled );
				}
			}
			else
				if ( resistance == Resistances.Shadow )
			{				
				Skill sk = c.AllSkills[ (ushort)Affliction.SkillId ];
				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					int rdiff = sk.CurrentVal(c);
					int res = sk.SpiritSkillCheck( c, rdiff );
					if ( c is Character && sk.Current < sk.Cap( c ) && c.SkillUp( sk.Current, rdiff, 5 ) )
					{
						sk.Current++;
						( c as Character ).SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[]{ (int)arcaneSkill.Id, (short)arcaneSkill.CurrentVal(c), (short)arcaneSkill.Cap( c ), (int)0 } );
					}					
					
					c.SendSmallUpdateToPlayerNearMe( new int[]{ 23 + c.ManaType }, new object[] { c.Mana } );
					if ( res > -25 )
						c.SpellSuccess();
					else
						c.SpellFaillure( SpellFailedReason.Fizzled );
				}
			}
			else
				c.SpellSuccess();
			return false;
		}

		public void SpellResult(int manacost,int id, Mobile c )
		{
			//AuraEffect ae = null;
			c.LooseMana(c,manacost);
		}
		
		public void SpellResult(int manacost,int id, Mobile c, Mobile t )
		{
			try
			{
				//SkillCheck(cast, c );
			}
			catch
			{
				Console.WriteLine("Spell error 0201: error in skillcheck");
			}
			/*		if ( c is Character )
						if ( ( c as Character ).Player.AccessLevel != AccessLevels.PlayerLevel )
							return;*/
			SpellResult( manacost,id, c );
		}
		
		public void SpellResult(int manacost,int id, Mobile c, Item i )
		{
			/*	if ( c is Character )
					if ( ( c as Character ).Player.AccessLevel != AccessLevels.PlayerLevel )
						return;*/
			SpellResult(manacost,id, c );
		}
		
		#endregion

	
		}
	}

