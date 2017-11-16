//	Script modified by kroy - 08/05/05 15:52:57
 //	Script made by kroy - 08/05/05 15:52:00
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.
/*
 * Dwarf.cs
 */

namespace Server
{

	/// <summary>
	/// Dwarf specific:
	/// Starting properties.
	/// Dwarf racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Dwarf 
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
			c.Str = 22;
			c.Agility = 16;
			c.Stamina = 23;
			c.Iq = 19;
			c.Spirit = 19;
			c.Size = 1.0f;
			c.Model = 53 + c.Gender;
			c.AllSkills.Add(lang = new CommonSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new DwarvenSkill(300, 300));   
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = -6240.32f;
			c.BindingPointY = 331.033f;
			c.BindingPointZ = 382.758f;
			c.BindingPointMapId = 0;
			/*
			 * In order: Find Treasure, Stoneform, Gun Specialization,
			 * Frost Resistance.
			 */
			c.TrainAbility(new int[] {2481, 20594, 20595, 20596});
		}
	}
}