//	Script made by pionere - 10/05/05 00:22:24
//	Script made by kroy - 08/05/05 15:53:52
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.
//  modified by pionere: Added LevelUp method
/*
 * Human.cs
 */

namespace Server
{

	/// <summary>
	/// Human specific:
	/// Starting properties.
	/// Human racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Human 
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
			c.X = -8949.95f;
			c.Y = -132.493f;
			c.Z = 83.5312f;
			c.Spirit = 21;
			c.Size = 1.0f;
			c.Model = 0x31 + c.Gender;
			c.MapId = 0;
			c.ZoneId = 12;
			c.AllSkills.Add(lang = new CommonSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = -8949.95f;
			c.BindingPointY = -132.493f;
			c.BindingPointZ = 83.5312f;
			c.BindingPointMapId = 0;
	
			/*
			 * In order: Sword Specialization, The Human Spirit, Diplomacy,
			 * Perception, Mace Specialization.
			 */
			c.TrainAbility(new int[] {20597, 20598, 20599, 20600, 20864});
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
			int pervIntWithoutBonus = (int)System.Math.Round((double)c.Spirit/1.05);
			int nextLevelWithBonus = (int)System.Math.Round(( pervIntWithoutBonus + gainSpi)*1.05);
			gainSpi = nextLevelWithBonus - c.Spirit;
		}
	}
}