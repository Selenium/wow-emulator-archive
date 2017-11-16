//	Script made by pionere - 10/05/05 00:21:33
//	Script made by kroy - 08/05/05 15:53:30
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.
// modified by pionere added LevelUp method
/*
 * Gnome.cs
 */

namespace Server
{

	/// <summary>
	/// Gnome specific:
	/// Starting properties.
	/// Gnome racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Gnome 
	{

		/*
		 * Author: DrNexus
		 * Modified by: Kroy
		 *
		 * Sets starting position, stats, size, gender, languages, faction and
		 * racial abilities.
		 *
		 * Parameter c Character to set starting stuff on.
		 */
		public static void Start(Character c) 
		{
			Skill lang = null;
			c.MapId = 0;
			c.ZoneId = 1;
			c.X = -6240.32f;
			c.Y = 331.033f;
			c.Z = 382.758f;
			c.BoundingRadius = 0.3f;
			c.Str = 15;
			c.Agility = 23;
			c.Stamina = 19;
			c.Iq = 24;
			c.Spirit = 20;
			c.Size = 1.0f;
			c.Model = 0x61B + c.Gender;
			c.AllSkills.Add(lang = new CommonSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new GnomishSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = -6240.32f;
			c.BindingPointY = 331.033f;
			c.BindingPointZ = 382.758f;
			c.BindingPointMapId = 0;
			/* 
			 * In order: Escape Artist, Expansive Mind, Arcane Resistance,
			 * Engineering Specialization.
			 */
			c.TrainAbility(new int[] {20589, 20591, 20592, 20593});
		}

		/*
		 * Author: pionere
		 * 
		 * Level progression rules for Race
		 *
		 * Parameter c Character to level up.
		 * Parameter gainHP Hit points to gain on level up.
		 * Parameter gainMana Mana to gain on level up.
		 * Parameter gainStr Strength to gain on level up.
		 * Parameter gainAgi Agility to gain on level up.
		 * Parameter gainSta Stamina to gain on level up.
		 * Parameter gainInt Intellect to gain on level up.
		 * Parameter gainSpi Spirit to gain on level up.
		 */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{	
			int pervLevelWithoutBonus = (int)System.Math.Round((double)c.Iq/1.05);
			int nextLevelWithBonus = (int)System.Math.Round((pervLevelWithoutBonus + gainInt)*1.05);
			int diffWithBonus = nextLevelWithBonus - c.Iq;
			if (diffWithBonus!=gainInt) 
			{
				gainMana += 15*(diffWithBonus - (int)gainInt);
			}
			gainInt = (float)diffWithBonus;
		}
	}
}