//	Script made by pionere - 10/05/05 00:30:03
//	Script modified by kroy - 08/05/05 15:55:30
 //	Script made by kroy - 08/05/05 15:54:46
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.
// modified by pionere: For new LevelUP

/*
 * Tauren.cs
 */

namespace Server
{

	/// <summary>
	/// Tauren specific:
	/// Starting properties.
	/// Tauren racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Tauren 
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
			c.MapId = 1;
			c.ZoneId = 215;
			c.X = -2917.58f;
			c.Y = -257.98f;
			c.Z = 52.9968f;
			c.Str = 25;
			c.Agility = 15;
			c.Stamina = 22;
			c.Iq = 15;
			c.Spirit = 22;
			c.Size = 1.0f;
			c.Model = 59 + c.Gender;
			c.AllSkills.Add(lang = new OrcishSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new TauraneSkill(300, 300));            
			c.TrainAbility(lang.SpellId);
	
			/* In order: War Stomp, Endurance, Cultivation, Nature Resistance. */
			c.TrainAbility(new int[] {20549, 20550, 20552, 20583});
			c.BindingPointX = -2917.58f;
			c.BindingPointY = -257.98f;
			c.BindingPointMapId = 1;
			c.BindingPointZ = 52.9968f;
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
			int pervLevelWithoutBonus = (int)System.Math.Round((double)c.BaseHitPoints/1.05);
			int nextLevelWithBonus = (int)System.Math.Round(( pervLevelWithoutBonus + gainHp)*1.05);
			gainHp = nextLevelWithBonus - c.BaseHitPoints;
		}

	}
}