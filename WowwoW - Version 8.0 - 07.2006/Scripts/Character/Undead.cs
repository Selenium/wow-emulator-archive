//	Script made by kroy - 08/05/05 15:56:34
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.

/*
 * Undead.cs
 */

namespace Server
{

	/// <summary>
	/// Undead specific:
	/// Starting properties.
	/// Undead racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Undead 
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
			c.ZoneId = 85;
			c.X = 1676.35f;
			c.Y = 1677.45f;
			c.Z = 121.67f;
			c.Str = 19;
			c.Agility = 18;
			c.Stamina = 21;
			c.Iq = 18;
			c.Spirit = 25;
			c.Size = 1.0f;
			c.Model = 57 + c.Gender;
			c.AllSkills.Add(lang = new OrcishSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new GutterspeakSkill(300, 300));         
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = 1676.35f;
			c.BindingPointY = 1677.45f;
			c.BindingPointZ = 121.67f;
			c.BindingPointMapId = 0;
			/* 
			 * In order: Underwater Breathing, Will of the Forsaken, Cannibalize,
			 * Shadow Resistance.
			 */
			c.TrainAbility(new int[] {5227, 7744, 20577, 20579});
		}
	}
}
