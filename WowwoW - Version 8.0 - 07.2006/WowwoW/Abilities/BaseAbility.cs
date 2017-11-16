using System;
using System.Collections;
using HelperTools;

namespace Server
{
	public delegate SpellFailedReason SingleTargetSpellCheck( BaseAbility ba, Mobile c, Object m );
	public delegate SpellFailedReason OnSelfSpellCheck(BaseAbility ba, Mobile c);
	

	/// <summary>
	/// Summary description for BaseAbility.
	/// </summary>
	public class BaseAbility
	{
		public static Hashtable SpellCheck = new Hashtable();
		ushort id;
		int customFlags1;
		int cooldown = 2000;	
		public BaseAbility( ushort i, int c )
		{
			id = i;
			cooldown = c;
		}
		public BaseAbility(  ushort i,int _customFlags1, int c )
		{
			id = i;
			cooldown = c;
			customFlags1 = _customFlags1; 
		}
		 
		public BaseAbility()
		{
		}
		public virtual ushort Id
		{
			get { return id; }
		}
		public virtual int CustomFlags1
		{
			get { return customFlags1; }
		}
		public virtual int CastingTime( Mobile from )
		{
			return 0;
		}
		public bool IsBinary()
		{
			return true;
		}
		
		public byte GetPureBin()
		{
			byte flag = 0;
			byte res = 0;
			res = (byte)((0xff000000 & customFlags1) >> 24);
			flag = (byte)((res & 0xc0) >> 6);
			return flag;
		}
		public bool IsType(int Eff)
		{
			const int AuraEf = 6;
			const int AuraArea = 35;
			const int AuraPer = 27;
			byte[] eff = new byte[3];
			byte[] au = new byte[3];
			byte[] flag = new byte[4];
			byte[] res = new byte[4];
			res[0] = (byte)(0x000000ff & customFlags1);
			res[1] = (byte)((0x0000ff00 & customFlags1) >> 8);
			res[2] = (byte)((0x00ff0000 & customFlags1) >> 16);
			res[3] = (byte)((0xff000000 & customFlags1) >> 24);
			flag[0] = (byte)(res[3] & 0x03);
			flag[1] = (byte)((res[3] & 0x0c) >> 2);
			flag[2] = (byte)((res[3] & 0x30) >> 4);
			int i = 0;
			while(i<3)
			{
				if(flag[i] == 0)
				{
					eff[i] = res[i];
					au[i] = 0;
				}
				else if(flag[i] == 1)
				{
					eff[i] = AuraEf;
					au[i] = res[i];
				}
				else if(flag[i] == 2)
				{
					eff[i] = AuraArea;
					au[i] = res[i];
				}
				else
				{
					eff[i] = AuraPer;
					au[i] = res[i];
				}
				i++;
			}
			foreach(byte ef in eff)
			{
				if(ef == Eff)
					return true;
			}
			return false;
		}
		public virtual int CoolDown( Mobile from )
		{
			
			int coldwn = cooldown;
			AuraEffect ae = null;
			if(this is SpellTemplate)
			{
				switch(from.Classe)
				{
					#region mage
					case Classes.Mage:
						// improved fireblast
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 2136 ] )//	FireBlast
							if ( from.HaveTalent( Talents.ImprovedFireBlast ) )
							{
								ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedFireBlast );
								coldwn += ae.S1;
							}
						// improved frost nova
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 6131 ] )//	FireBlast
							if ( from.HaveTalent( Talents.ImprovedFrostNova ) )
							{
								ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedFrostNova );
								coldwn += ae.S1;
							}
					break;
					#endregion
					#region warrior
					case Classes.Warrior:
						//improved taunt
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 355 ] )//	Taunt
						if ( from.HaveTalent( Talents.ImprovedTaunt ) )
						{
							ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedTaunt );
							coldwn += ae.S1;
						}
						//improved intercept
						if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 20252 ] )//	intercept
							if ( from.HaveTalent( Talents.ImprovedIntercept ) )
							{
								ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedIntercept );
								coldwn += ae.S1;
							}
					break;
					#endregion
					#region warlock
					case Classes.Warlock:

					break;
					#endregion
				}
				if(from.SummonedBy != null)
					if ( SpellTemplate.SpellEffects[ (int)Id ] == SpellTemplate.SpellEffects[ 4388] )
					if(from.SummonedBy.HaveTalent(Talents.ImprovedLashOfPain))
					{
						ae = (AuraEffect)from.GetTalentEffect( Talents.ImprovedLashOfPain );
						coldwn += ae.S1;
					}
			}	
			int cooldwn = coldwn;
			#region Cooldown for ability
			foreach(Mobile.AuraReleaseTimer art in from.Auras)
			{
				if (art.aura.CooldownEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] as ArrayList).Contains((int)this.Id))
									cooldwn =(int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
						}
						if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.CooldownEffectedAbilityList];
							if( list == this.Id)
								cooldwn = (int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
						}
					}

				}
				if (art.aura.CooldownEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CooldownEffectedAbilityClass )
					{
						cooldwn = (int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
					}
				}
			}
			foreach(PermanentAura art in from.PermanentAuras)
			{
				if (art.aura.CooldownEffectedAbilityList != 0)
				{
					if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] != null)
					{
						if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] is ArrayList)
						{
							if((from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] as ArrayList).Contains((int)this.Id))
							{
								cooldwn =(int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
							}
						}
						if (from.SpecialForAuras[art.aura.CooldownEffectedAbilityList] is int)
						{
							int list = (int)from.SpecialForAuras[art.aura.CooldownEffectedAbilityList];
							if( list == this.Id)
								cooldwn = (int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
						}
					}

				}
				if (art.aura.CooldownEffectedAbilityClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.CooldownEffectedAbilityClass )
					{
						cooldwn = (int)((cooldwn + art.aura.CooldownBonusForAbility)*art.aura.CooldownModificatorForAbility);
					}
				}
			}
				
			#endregion
		
			return cooldwn;
		}

		public virtual void SendCooldown(Mobile.Casting cast, Mobile c )
		{
			if ( c is Character )
			{
			
				int offset = 4;
				Converter.ToBytes((uint) cast.id, c.tempBuff, ref offset );
				Converter.ToBytes((ulong) c.Guid, c.tempBuff, ref offset );
				Converter.ToBytes((ushort)cast.cool, c.tempBuff, ref offset );
				( c as Character ).Send( OpCodes.SMSG_SPELL_COOLDOWN, c.tempBuff, offset );
			}
		}
		public virtual void SendCooldownEvent(int spell,Mobile c)
		{
			if ( c is Character )
			{
			
				int offset = 4;
				Converter.ToBytes((uint) spell, c.tempBuff, ref offset );
				Converter.ToBytes((ulong) c.Guid, c.tempBuff, ref offset );
				( c as Character ).Send( OpCodes.SMSG_COOLDOWN_EVENT, c.tempBuff, offset );
			}
		}
		public virtual void SendCooldown(int spell, Mobile c )
		{
			if ( c is Character )
			{
			
				int offset = 4;
				Converter.ToBytes((uint) spell, c.tempBuff, ref offset );
				Converter.ToBytes((ulong) c.Guid, c.tempBuff, ref offset );
				Converter.ToBytes((ushort)Abilities.abilities[spell].CoolDown(c), c.tempBuff, ref offset );
				( c as Character ).Send( OpCodes.SMSG_SPELL_COOLDOWN, c.tempBuff, offset );
			}
		}
	
		public bool CheckSpellCaster(Mobile from)
		{
			if (this is SpellTemplate || this is AuraEffect)
			{
			#region silence test
			if ( from.ForceSilence )
			{
				from.SpellFaillure( SpellFailedReason.CanDoWhileSilenced );
				return false;
			}
			#endregion
			#region avoid cast
			foreach( Mobile.AuraReleaseTimer art in from.Auras )
				if(art.aura.AvoidCastMagicClass != 0)
				{
					if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.AvoidCastMagicClass )
					{
						from.SpellFaillure( SpellFailedReason.YouCantDoThatYet );
						return false;
					}
				}
					
			#endregion
			#region Mana test
			if ( !( from is Character ) || ( from as Character ).Player.AccessLevel == AccessLevels.PlayerLevel )
			{
				if ((this as SpellTemplate).GetManaCost(from) > from.Mana )
				{
					from.SpellFaillure( SpellFailedReason.NotEnoughMana );
					return false;
				}
			}
			#endregion
			#region Standing
			if ( from is Character)
			{
				int st = (int)from.StandState;
				st = st & 0xffff;
				StandStates s = (StandStates)st;
				if ( s != StandStates.Standing )
				{
					from.SpellFaillure( SpellFailedReason.YouHaveToStandingToDoThat );
					return false;
				}
			}
			#endregion
			#region caster is dead
			if (from.Dead == true)
			{
				from.SpellFaillure( SpellFailedReason.YouAreDead );
				return false;
			}
			#endregion
			#region have spell
			if (!from.HaveSpell(this.Id))
			{
				from.SpellFaillure( SpellFailedReason.SpellNotLearned );
				return false;
			}
			#endregion
			#region level test
			
				if (this is SpellTemplate || this is AuraEffect)
				{
					if (from.Level < (this as SpellTemplate).RequieredLevel)
					{
						from.SpellFaillure( SpellFailedReason.YouAreNotEnoughLevel );
						return false;
					}
				}
			
			#endregion
			}
			else Console.WriteLine("Ability/Teach spell casted - Id: " + this.Id);
			return true;
		}
		public bool CheckSpellTarget(Mobile from, Object target)
		{
			if (this is SpellTemplate || this is AuraEffect)
		{
			#region multiple auras
			if (this is AuraEffect && target is Mobile)
			{
				AuraEffect ae = (AuraEffect)this;
				byte purebin = ae.GetPureBin();
				Console.WriteLine(purebin);
				//if(ae.Unpure == true) return true;
				ArrayList al1 = new ArrayList(); 
				foreach(Mobile.AuraReleaseTimer art1 in (target as Mobile).Auras)
				{
					AuraEffect af = art1.ae;
					if (af.Aura == ae.Aura)
					{
						 
						if(af.Id > ae.Id) 
						{
							(from as Character).SpellFaillure(SpellFailedReason.AMorePowerfulSpellAlreadyActive);
							return false;
						}
						else al1.Add(art1);
					}
				}
				foreach(Mobile.AuraReleaseTimer art2 in al1)
				{
					(target as Mobile).ReleaseAura(art2);
				}
					

			}
			#endregion
			#region invalid target
			if ( (SpellTemplate.SpellEffects[ this.Id] is SingleTargetSpellEffect) && !(target is Mobile || target is Character))
			{
				from.SpellFaillure( SpellFailedReason.InvalidTarget );
				return false;
			}
			if ( (SpellTemplate.SpellEffects[ this.Id] is OnSingleTargetItemSpellEffect) && !(target is Items.Item))
			{
				from.SpellFaillure( SpellFailedReason.InvalidTarget );
				return false;
			}
			if ( (SpellTemplate.SpellEffects[ this.Id] is TargetXYZSpellEffect) && !(target == null))
			{
				from.SpellFaillure( SpellFailedReason.InvalidTarget );
				return false;
			}
			if ( (SpellTemplate.SpellEffects[ this.Id] is OnSelfSpellEffect) && target != from)
			{
				from.SpellFaillure( SpellFailedReason.InvalidTarget );
				return false;
			}
			if ( (SpellTemplate.SpellEffects[ this.Id] is GameObjectTargetSpellEffect) && target is GameObject)
			{
				from.SpellFaillure( SpellFailedReason.InvalidTarget );
				return false;
			}
			#endregion
			#region target is dead
			if(target is Mobile)
			if ((target as Mobile).Dead == true)
			{
				from.SpellFaillure( SpellFailedReason.YouAreDead );
				return false;
			}
			#endregion
		}

		else Console.WriteLine("Ability/Teach spell casted - Id: " + this.Id);
		return true;
		}
		public bool CheckSpellTargetMultiple(Mobile from, Object target)
		{
			if (this is SpellTemplate || this is AuraEffect)
			{
				#region multiple auras
				if (this is AuraEffect && target is Mobile)
				{
					AuraEffect ae = (AuraEffect)this;
					byte purebin = ae.GetPureBin();
					Console.WriteLine(purebin);
					//if(ae.Unpure == true) return true;
					ArrayList al1 = new ArrayList(); 
					foreach(Mobile.AuraReleaseTimer art1 in (target as Mobile).Auras)
					{
						AuraEffect af = art1.ae;
						if (af.Aura == ae.Aura)
						{
						 
							if(af.Id > ae.Id) 
							{
								return false;
							}
							else al1.Add(art1);
						}
					}
					foreach(Mobile.AuraReleaseTimer art2 in al1)
					{
						(target as Mobile).ReleaseAura(art2);
					}
					

				}
				#endregion
				
				#region target is dead
				if(target is Mobile)
					if ((target as Mobile).Dead == true)
					{
						return false;
					}
				#endregion
			}

			else Console.WriteLine("Ability/Teach spell casted - Id: " + this.Id);
			return true;
		}

		public bool CheckSpell(Mobile from, Object target)
		{
			if (this is SpellTemplate || this is AuraEffect)
			{
				#region multiple auras
				if (this is AuraEffect && target is Mobile)
				{
					AuraEffect ae = (AuraEffect)this;
					byte purebin = ae.GetPureBin();
					Console.WriteLine(purebin);
					//if(ae.Unpure == true) return true;
					ArrayList al1 = new ArrayList(); 
					foreach(Mobile.AuraReleaseTimer art1 in (target as Mobile).Auras)
					{
						AuraEffect af = art1.ae;
						if (af.Aura == ae.Aura)
						{
						 
							if(af.Id > ae.Id) 
							{
									(from as Character).SpellFaillure(SpellFailedReason.AMorePowerfulSpellAlreadyActive);
									return false;
							}
							else al1.Add(art1);
						}
					}
					foreach(Mobile.AuraReleaseTimer art2 in al1)
					{
						(target as Mobile).ReleaseAura(art2);
					}
					

				}
				#endregion
				#region silence test
				if ( from.ForceSilence )
				{
					from.SpellFaillure( SpellFailedReason.CanDoWhileSilenced );
					return false;
				}
				#endregion
				#region avoid cast
				foreach( Mobile.AuraReleaseTimer art in from.Auras )
					if(art.aura.AvoidCastMagicClass != 0)
					{
						if ( AbilityClasses.abilityClasses[ (int)Id ] == art.aura.AvoidCastMagicClass )
						{
							from.SpellFaillure( SpellFailedReason.YouCantDoThatYet );
							return false;
						}
					}
					
				#endregion
				#region Mana test
				if ( !( from is Character ) || ( from as Character ).Player.AccessLevel == AccessLevels.PlayerLevel )
				{
					if ((this as SpellTemplate).GetManaCost(from) > from.Mana )
					{
						from.SpellFaillure( SpellFailedReason.NotEnoughMana );
						return false;
					}
				}
				#endregion
				#region invalid target
				if ( (SpellTemplate.SpellEffects[ this.Id] is SingleTargetSpellEffect) && !(target is Mobile || target is Character))
				{
					from.SpellFaillure( SpellFailedReason.InvalidTarget );
					return false;
				}
				if ( (SpellTemplate.SpellEffects[ this.Id] is OnSingleTargetItemSpellEffect) && !(target is Items.Item))
				{
					from.SpellFaillure( SpellFailedReason.InvalidTarget );
					return false;
				}
				if ( (SpellTemplate.SpellEffects[ this.Id] is TargetXYZSpellEffect) && !(target == null))
				{
					from.SpellFaillure( SpellFailedReason.InvalidTarget );
					return false;
				}
				if ( (SpellTemplate.SpellEffects[ this.Id] is OnSelfSpellEffect) && target != from)
				{
					from.SpellFaillure( SpellFailedReason.InvalidTarget );
					return false;
				}
				if ( (SpellTemplate.SpellEffects[ this.Id] is GameObjectTargetSpellEffect) && target is GameObject)
				{
					from.SpellFaillure( SpellFailedReason.InvalidTarget );
					return false;
				}
				#endregion
				#region Standing
				if ( from is Character)
				{
					int st = (int)from.StandState;
					st = st & 0xffff;
					StandStates s = (StandStates)st;
					if ( s != StandStates.Standing )
					{
						from.SpellFaillure( SpellFailedReason.YouHaveToStandingToDoThat );
						return false;
					}
				}
				#endregion
				#region caster is dead
				if (from.Dead == true)
				{
					from.SpellFaillure( SpellFailedReason.YouAreDead );
					return false;
				}
				#endregion
				#region have spell
				if (!from.HaveSpell(this.Id))
				{
					from.SpellFaillure( SpellFailedReason.SpellNotLearned );
					return false;
				}
				#endregion
				#region level test
				if (from is Character)
				{
					if(!((from as Character).AccountLevel == AccessLevels.Admin || (from as Character).AccountLevel == AccessLevels.GM)) 
					{
						
					
						if (from.Level < (this as SpellTemplate).RequieredLevel)
						{
							from.SpellFaillure( SpellFailedReason.YouAreNotEnoughLevel );
							return false;
						}
					
				
					}
				}
				else 
				{
					if (this is SpellTemplate || this is AuraEffect)
					{
						if (from.Level < (this as SpellTemplate).RequieredLevel)
						{
							from.SpellFaillure( SpellFailedReason.YouAreNotEnoughLevel );
							return false;
						}
					}
				}
				#endregion
				#region target type
				if(SpecificSpellTargets.specificSpellTargets[(int)this.Id] != 0 && target is Mobile)
				{
					int k = (int)SpecificSpellTargets.specificSpellTargets[(int)this.Id] ;
					int j = k;
					Mobile mob = (Mobile)target;
					Console.WriteLine(" " + j + " " );
					 j &= mob.NpcType ;
					Console.WriteLine(" " + j + " " + mob.NpcType);
					if(( j == 0))
					{
						
						from.SpellFaillure( SpellFailedReason.RequiredExoticAmno );
						Console.WriteLine("upppppps");
						return false;
					}

				}
				#endregion
			}
			else Console.WriteLine("Ability/Teach spell casted - Id: " + this.Id);
			return true;

		}
	}
}
