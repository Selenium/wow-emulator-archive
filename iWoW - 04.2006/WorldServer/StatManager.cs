using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for StatManager.
	/// </summary>
	public class StatManager
	{
		public StatManager()
		{}

		#region BaseStat Class
		public class BaseStats {
			public int Strength = 0;
			public int Agility = 0;
			public int Stamina = 0;
			public int Intellect = 0;
			public int Spirit = 0;
			public int Health = 0;
			public int Power = 0;

			private static int[] m_basestrengtharray = new int[9] {0, 20, 23, 22, 16, 19, 25, 15, 20 };
			private static int[] m_baseagilityarray = new int[9] {0, 20, 17, 17, 25, 18, 16, 23, 22 };
			private static int[] m_basestaminaarray = new int[9] {0, 20, 22, 23, 19, 21, 22, 19, 21 };
			private static int[] m_baseintellectarray = new int[9] {0, 20, 17, 19, 20, 17, 16, 23, 16 };
			private static int[] m_basespiritarray = new int[9] {0, 20, 21, 19, 20, 25, 21, 20, 21 };

			public static BaseStats GetBaseStats(PlayerObject pobj) {
				int basestrength = m_basestrengtharray[(int)pobj.Race] ;
				int baseagility = m_baseagilityarray[(int)pobj.Race] ;
				int basestamina = m_basestaminaarray[(int)pobj.Race] ;
				int baseintellect = m_baseintellectarray[(int)pobj.Race];
				int basespirit = m_basespiritarray[(int)pobj.Race];
				int basehealth = 0;
				int basehealthmod = 0;
				int basepower = 0;
				int basepowermod = 0;
				int strengthmod = 0;
				int agilitymod = 0;
				int staminamod = 0;
				int intellectmod = 0;
				int spiritmod = 0;
				switch(pobj.Class)
				{
					case CLASS.WARRIOR:
						basestrength += 3;
						basestamina += 2;
						basehealth = 40;
						basehealthmod = 10;
						// str & sta
						if (pobj.Level >= 2 && pobj.Level <= 24) {
							strengthmod = pobj.Level - 1;
							staminamod = pobj.Level - 1;
						} else if (pobj.Level >= 25) {
							strengthmod = 23 + ((pobj.Level - 24) * 2);
							staminamod = 23 + ((pobj.Level - 24) * 2);
						}
						// agi
						if (pobj.Level >= 7) {
							agilitymod = ((pobj.Level - 6) + ((pobj.Level - 6) % 2)) / 2;
						}
						// int & spi
						if (pobj.Level >= 10) {
							intellectmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
							spiritmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						break;
					case CLASS.PALADIN:
						basestrength += 2;
						basestamina += 2;
						basespirit += 1;
						basehealth = 40;
						basehealthmod = 9;
						basepower = 84;
						basepowermod = 9;
						// str
						if (pobj.Level >= 5) {
							strengthmod = pobj.Level - 4;
						}
						// sta
						if (pobj.Level >= 3) {
							staminamod = pobj.Level - 2;
						}
						// agi
						if (pobj.Level >= 9) {
							agilitymod = ((pobj.Level - 8) + ((pobj.Level - 8) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 8) {
							intellectmod = ((pobj.Level - 7) + ((pobj.Level - 7) % 2)) / 2;
						}
						// spi
						if (pobj.Level >= 6) {
							spiritmod = pobj.Level - 5;
						}
						break;
					case CLASS.HUNTER:
						basestrength += 1;
						baseagility += 1;
						basestamina += 1;
						baseintellect += 1;
						basespirit += 1;
						basehealth = 48;
						basehealthmod = 8;
						// str
						if (pobj.Level >= 5) {
							strengthmod = pobj.Level - 4;
						}
						// sta
						if (pobj.Level >= 3) {
							staminamod = pobj.Level - 2;
						}
						// agi
						if (pobj.Level >= 9) {
							agilitymod = ((pobj.Level - 8) + ((pobj.Level - 8) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 8) {
							intellectmod = ((pobj.Level - 7) + ((pobj.Level - 7) % 2)) / 2;
						}
						// spi
						if (pobj.Level >= 6) {
							spiritmod = pobj.Level - 5;
						}
						break;
					case CLASS.ROGUE:
						basestrength += 1;
						baseagility += 3;
						basestamina += 1;
						basehealth = 48;
						basehealthmod = 8;
						// str
						if (pobj.Level >= 6) {
							strengthmod = pobj.Level - 5;
						}
						// sta
						if (pobj.Level >= 5) {
							staminamod = pobj.Level - 4;
						}
						// agi
						if (pobj.Level >= 2) {
							agilitymod = pobj.Level - 1;
						}
						// int
						if (pobj.Level >= 9) {
							intellectmod = ((pobj.Level - 8) + ((pobj.Level - 8) % 2)) / 2;
						}
						// spi
						if (pobj.Level >= 10) {
							spiritmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						break;
					case CLASS.PRIEST:
						basestamina += 1;
						baseintellect += 2;
						basespirit += 2;
						basehealth = 46;
						basehealthmod = 6;
						basepower = 130;
						basepowermod = 10;
						// str
						if (pobj.Level >= 10) {
							strengthmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						// sta
						if (pobj.Level >= 6) {
							staminamod = pobj.Level - 5;
						}
						// agi
						if (pobj.Level >= 9) {
							agilitymod = ((pobj.Level - 8) + ((pobj.Level - 8) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 2 && pobj.Level <= 24) {
							intellectmod = pobj.Level - 1;
						} else if (pobj.Level >= 25) {
							intellectmod = 23 + ((pobj.Level - 24) * 2);
						}
						// spi
						if (pobj.Level >= 4) {
							spiritmod = pobj.Level - 3;
						}
						break;
					case CLASS.SHAMAN:
						basestrength += 1;
						basestamina += 1;
						baseintellect += 2;
						basespirit += 1;
						basehealth = 48;
						basehealthmod = 8;
						basepower = 69;
						basepowermod = 9;
						// str
						if (pobj.Level >= 7) {
							strengthmod = ((pobj.Level - 6) + ((pobj.Level - 6) % 2)) / 2;
						}
						// sta
						if (pobj.Level >= 5) {
							staminamod = pobj.Level - 4;
						}
						// agi
						if (pobj.Level >= 8) {
							agilitymod = ((pobj.Level - 7) + ((pobj.Level - 7) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 6) {
							intellectmod = pobj.Level - 5;
						}
						// spi
						if (pobj.Level >= 5) {
							spiritmod = pobj.Level - 4;
						}
						break;
					case CLASS.MAGE:
						baseintellect += 2;
						basespirit += 3;
						basehealth = 52;
						basehealthmod = 6;
						basepower = 130;
						basepowermod = 10;
						// str
						if (pobj.Level >= 10) {
							strengthmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						// sta
						if (pobj.Level >= 6) {
							staminamod = pobj.Level - 5;
						}
						// agi
						if (pobj.Level >= 10) {
							agilitymod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 2 && pobj.Level <= 24) {
							intellectmod = pobj.Level - 1;
						} else if (pobj.Level >= 25) {
							intellectmod = 23 + ((pobj.Level - 24) * 2);
						}
						// spi
						if (pobj.Level >= 3 && pobj.Level <= 34) {
							spiritmod = pobj.Level - 2;
						} else if (pobj.Level >= 35) {
							spiritmod = 32 + ((pobj.Level - 34) * 2);
						}
						break;
					case CLASS.WARLOCK:
						basestamina += 1;
						baseintellect += 2;
						basespirit += 2;
						basehealth = 47;
						basehealthmod = 7;
						basepower = 110;
						basepowermod = 10;
						// str
						if (pobj.Level >= 10) {
							strengthmod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						// sta
						if (pobj.Level >= 4) {
							staminamod = pobj.Level - 3;
						}
						// agi
						if (pobj.Level >= 10) {
							agilitymod = ((pobj.Level - 9) + ((pobj.Level - 9) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 3 && pobj.Level <= 34) {
							intellectmod = pobj.Level - 2;
						} else if (pobj.Level >= 35) {
							intellectmod = 32 + ((pobj.Level - 34) * 2);
						}
						// spi
						if (pobj.Level >= 4) {
							spiritmod = pobj.Level - 3;
						}
						break;
					case CLASS.DRUID:
						basestrength += 1;
						baseagility += 1;
						basestamina += 1;
						baseintellect += 1;
						basespirit += 1;
						basehealth = 47;
						basehealthmod = 7;
						basepower = 87;
						basepowermod = 9;
						// str
						if (pobj.Level >= 7) {
							strengthmod = ((pobj.Level - 6) + ((pobj.Level - 6) % 2)) / 2;
						}
						// sta
						if (pobj.Level >= 4) {
							staminamod = pobj.Level - 3;
						}
						// agi
						if (pobj.Level >= 9) {
							agilitymod = ((pobj.Level - 8) + ((pobj.Level - 8) % 2)) / 2;
						}
						// int
						if (pobj.Level >= 5) {
							intellectmod = pobj.Level - 4;
						}
						// spi
						if (pobj.Level >= 6) {
							spiritmod = pobj.Level - 5;
						}
						break;
				}
				BaseStats stats = new BaseStats();
				stats.Strength = basestrength + strengthmod;
				stats.Stamina = basestamina + staminamod;
				stats.Agility = baseagility + agilitymod;
				stats.Intellect = baseintellect + intellectmod;
				stats.Spirit = basespirit + spiritmod;

				stats.Health = 0;
				stats.Power = 0;
				if (basestamina < 20)
					stats.Health = basehealth + (20 - basestamina);
				else
					stats.Health = basehealth + (basehealthmod * (basestamina - 20));
				stats.Health += (staminamod * 10);

				if (baseintellect < 20)
					stats.Power = basepower + (20 - baseintellect);
				else
					stats.Power = basepower + (basepowermod * (baseintellect - 20));
				stats.Power += (intellectmod * 10);

				return stats;
			}
		}
		#endregion

		#region Stats calculation
		public static void CalculateNewStats(LivingObject lobj)
		{
			if (lobj.ObjectType == OBJECTTYPE.PLAYER)
			{
				PlayerObject pobj = (PlayerObject)lobj;
				BaseStats stats = BaseStats.GetBaseStats(pobj);
				
				pobj.MaxHealth = stats.Health;
				pobj.MaxPower = stats.Power;

				pobj.BaseStrength = stats.Strength;
				pobj.BaseStamina = stats.Stamina;
				pobj.BaseAgility = stats.Agility;
				pobj.BaseIntellect = stats.Intellect;
				pobj.BaseSpirit = stats.Spirit;
				
				CalculateInvStats(pobj);
			}
			else if (lobj.ObjectType == OBJECTTYPE.UNIT)
			{
				UnitBase uobj = (UnitBase)lobj;
				int basehealth = 60;
				int basestamina = Convert.ToInt32(((float)lobj.Level * ((float)lobj.Level * 0.2f)) - 1);
				if (basestamina < (uobj.Level - 1))
					basestamina = uobj.Level - 1;
				int health = basehealth + (basestamina * 10);

				if (uobj.Level < 10) {
					switch(uobj.Level) {
						case 1:
							uobj.BaseAttackTime = 2000;
							uobj.MinDamage = (float)2.0;
							uobj.MaxDamage = (float)4.0;
							break;
						case 2:
							uobj.BaseAttackTime = 2600;
							uobj.MinDamage = (float)3.0;
							uobj.MaxDamage = (float)6.0;
							break;
						case 3:
							uobj.BaseAttackTime = 2200;
							uobj.MinDamage = (float)3.0;
							uobj.MaxDamage = (float)6.0;
							break;
						case 4:
							uobj.BaseAttackTime = 2000;
							uobj.MinDamage = (float)3.0;
							uobj.MaxDamage = (float)6.0;
							break;
						case 5:
							uobj.BaseAttackTime = 1800;
							uobj.MinDamage = (float)3.0;
							uobj.MaxDamage = (float)6.0;
							break;
						case 6:
							uobj.BaseAttackTime = 2100;
							uobj.MinDamage = (float)4.0;
							uobj.MaxDamage = (float)8.0;
							break;
						case 7:
							uobj.BaseAttackTime = 1950;
							uobj.MinDamage = (float)4.0;
							uobj.MaxDamage = (float)8.0;
							break;
						case 8:
							uobj.BaseAttackTime = 1800;
							uobj.MinDamage = (float)4.0;
							uobj.MaxDamage = (float)8.0;
							break;
						case 9:
							uobj.BaseAttackTime = 2200;
							uobj.MinDamage = (float)5.0;
							uobj.MaxDamage = (float)10.0;
							break;
					}
				} else {
					uobj.BaseAttackTime = 2000;
					uobj.MinDamage = (float)uobj.Level / (float)2.0;
					uobj.MaxDamage = (float)uobj.Level;
				}
				uobj.MaxHealth = health;
				uobj.MaxPower = 0;
			}
		}

		public static void CalculateInvStats(PlayerObject pobj) {
			int physical = 0;
			int holy = 0;
			int fire = 0;
			int nature = 0;
			int frost = 0;
			int shadow = 0;
			int strength = 0;
			int agility = 0;
			int stamina = 0;
			int intellect = 0;
			int spirit = 0;
			int health = 0;
			int power = 0;
			float mindamage = 2.0f;
			float maxdamage = 4.0f;
			int baseattacktime = 2000;

			for (int i = 0; i < 18; i++) {
				ItemObject item = pobj.Inventory[i];
				if (item != null && item.Template != null) {
					DBItemTemplate template = item.Template;
					physical += template.Resists.Physical;
					holy += template.Resists.Holy;
					fire += template.Resists.Fire;
					nature += template.Resists.Nature;
					frost += template.Resists.Frost;
					shadow += template.Resists.Shadow;
					for (int bonus = 0; bonus < 10; bonus++) {
						ItemBonus itembonus = template.getItemBonus(bonus);
						if (itembonus.Stat >= 0 && itembonus.Bonus != 0) {
							
							Console.WriteLine("itembonusstat: " + itembonus.Stat);
							Console.WriteLine("itembonusstatbonus: " + itembonus.Bonus);

							if (itembonus.Stat == 0)
								power += itembonus.Bonus;
							else if (itembonus.Stat == 1)
								health += itembonus.Bonus;
							else if (itembonus.Stat == 3)
								agility += itembonus.Bonus;
							else if (itembonus.Stat == 4)
								strength += itembonus.Bonus;
							else if (itembonus.Stat == 5)
								intellect += itembonus.Bonus;
							else if (itembonus.Stat == 6)
								spirit += itembonus.Bonus;
							else if (itembonus.Stat == 7)
								stamina += itembonus.Bonus;
						} else
							break;
					}

					if (i == (int)INVSLOT.MAINHAND){
						DamageStat damagestat = template.getDamageStat(0);
						mindamage = (float)damagestat.Min;
						maxdamage = (float)damagestat.Max;
						baseattacktime = template.WeaponSpeed;
					}

					if (i == (int)INVSLOT.OFFHAND) {
						if (template.SubClass == 5 || template.SubClass == 6)
							pobj.HasShield = true;
						else
							pobj.HasShield = false;
					}
				}
			}
						
			pobj.MaxHealth += health;
			pobj.MaxPower += power;

			pobj.MaxHealth += (stamina * 10);
			pobj.MaxPower += (intellect * 10);

			pobj.BaseStrength += strength;
			
            pobj.BaseStamina += stamina;

			pobj.BaseAgility += agility;

			pobj.BaseIntellect += intellect;

			pobj.BaseSpirit += spirit;
			
			pobj.Resist_Physical = physical;
			pobj.Resist_Holy = holy;
			pobj.Resist_Fire = fire;
			pobj.Resist_Nature = nature;
			pobj.Resist_Frost = frost;
			pobj.Resist_Shadow = shadow;

			pobj.MinDamage = mindamage;
			pobj.MaxDamage = maxdamage;
			pobj.BaseAttackTime = baseattacktime;//baseattacktime;

			if (pobj.Health > pobj.MaxHealth)
			    pobj.Health = pobj.MaxHealth;
			if (pobj.Power > pobj.MaxPower)
				pobj.Power = pobj.MaxPower;			

		}
		#endregion

		#region Exp calculation
		public static void CalculateNextLevelExp(PlayerObject pobj) {
			pobj.NextLevelExp = pobj.Level * 1000;
		}

		public static int CalculateExp(UnitBase uobj,PlayerObject player)
		{
			double exp = (200 * uobj.Level);
			// TODO: Have to modify this so its on each person that hits the mob not just the killer.
			/*double mod = 1f;
			if (Math.Abs(uobj.Level - player.Level) < 5)
 				mod = (5-(player.Level-uobj.Level))*0.2;
			else if (uobj.Level > player.Level)
				mod = 2;
			else
 				mod = 0;
			exp *= mod;*/
			return (int)exp;
		}
		#endregion

		#region Damage calculation
		private static Random m_damagerandom = new Random();
		public static void CalculateMeleeDamage(LivingObject attacker, LivingObject target,
			out uint hitflag, out uint victimstate, out int damage, out int blocked)
		{
			blocked = 0;
			if (attacker.ObjectType == OBJECTTYPE.PLAYER) {
				float basedps = 0.15f;
				float basestrength = (float)attacker.BaseStrength;
				float baseattacktime = (float)attacker.BaseAttackTime / 1000.0f;
				int dps = Convert.ToInt32(basedps * basestrength * baseattacktime);

				hitflag = 2;
				victimstate =(uint)VICTIMSTATE.WOUND;
				damage = m_damagerandom.Next((int)attacker.MinDamage,(int)(attacker.MaxDamage+1));
				damage += dps;

				// Targets Dodge %
				float basedodge = (20.0f + ((float)target.Level / 3.0f)) * 0.25f;
				// Soft cap on 25%
				if (basedodge > 25.0f)
					basedodge = 25.0f;

				int hit = m_damagerandom.Next(100);
				if (hit <= (int)basedodge) {
					hitflag = 1;
					victimstate = (uint)VICTIMSTATE.DODGE;
					damage = 0;
				} else {
					// Critical hit %
					float basecritical = (float)attacker.BaseAgility * 0.25f;
					// Soft cap on 25%
					if (basecritical > 25.0f)
						basecritical = 25.0f;
					hit = m_damagerandom.Next(100);
					if (hit <= (int)basecritical) {
						hitflag = 10;
						damage += (int)attacker.MaxDamage;
					}
				}
			} else {
				float basedps = 0.1f;
				float basestrength = 20.0f + ((float)attacker.Level * (float)1.1);
				float baseattacktime = (float)attacker.BaseAttackTime / 1000.0f;
				int dps = Convert.ToInt32(basedps * basestrength * baseattacktime);

				hitflag = 2;
				victimstate =(uint)VICTIMSTATE.WOUND;
				damage = m_damagerandom.Next((int)attacker.MinDamage,(int)(attacker.MaxDamage+1));
				damage += dps;

				// Target AC
				float damagereduction = (0.3f * (float)(target.Resist_Physical - 1) / (10.0f * (float)target.Level + 89.0f));
				damage -= Convert.ToInt32((float)damage * damagereduction);

				// Targets Dodge %
                float basedodge = (float)target.BaseAgility * 0.25f;
				// Soft cap on 25%
				if (basedodge > 25.0f)
					basedodge = 25.0f;

				int hit = m_damagerandom.Next(100);
				if (hit <= (int)basedodge) {
					hitflag = 1;
					victimstate = (uint)VICTIMSTATE.DODGE;
					damage = 0;
				} else {
					PlayerObject pobj = (PlayerObject)target;
					if (pobj.HasShield) {
						int baseblock = 25;
						hit = m_damagerandom.Next(100);
						if (hit < baseblock) {
							blocked = Convert.ToInt32((float)damage * 0.2f);
							damage -= blocked;
						}
					}
				}
			}
		}

		public static void CalculateSpellDamage(LivingObject attacker, LivingObject target, DBSpell spell, out int damage)
		{
			damage = 0;
			if (attacker.ObjectType == OBJECTTYPE.PLAYER) {
				float basedps = 0.10f;
				float baseintellect = (float)attacker.BaseIntellect;
				float baseattacktime = (float)spell.CastTime / 1000.0f;
				int dps = Convert.ToInt32(basedps * baseintellect * baseattacktime);

				int minDmg = (int)spell.Damage;
				int maxDmg = (int)minDmg + (int)spell.RandomPercentageDamage;
				damage = m_damagerandom.Next(minDmg, (maxDmg + 1));
				//damage += dps;

				if (target != null) {

				}
			}
		}
		#endregion

		#region Regen calculation
		public static void CalculateRegenTick(LivingObject lobj)
		{
			if (lobj.ObjectType == OBJECTTYPE.PLAYER) {
				PlayerObject pobj = (PlayerObject)lobj;

				float ticktime = 3.0f;
				float baseregenpower = 0.1f;
				float baseregenhealth = 0.1f;
				float powerregen = pobj.BaseSpirit * baseregenpower * ticktime;
				float healthregen = pobj.BaseSpirit * baseregenhealth * ticktime;

				if (pobj.StandState != UNITSTANDSTATE.SITTING) {
					healthregen = healthregen / 3;
					powerregen = powerregen / 3;
				}

				pobj.Health += (int)healthregen;
				if (pobj.Health > pobj.MaxHealth)
					pobj.Health = pobj.MaxHealth;

				pobj.Power += (int)powerregen;
				if (pobj.Power > pobj.MaxPower)
					pobj.Power = pobj.MaxPower;
			} else {
				UnitBase uobj = (UnitBase)lobj;

				float ticktime = 3.0f;
				float baseregenhealth = 0.1f;
				float healthregen = (20.0f + ((float)uobj.Level / 3.0f)) * baseregenhealth * ticktime;

				if (uobj.Attacking) {
					healthregen = healthregen / 3;
				}

				uobj.Health += (int)healthregen;
				if (uobj.Health > uobj.MaxHealth)
					uobj.Health = uobj.MaxHealth;
			}
		}
		#endregion
	}
}
