//	Script made by kroy - 08/05/05 15:55:53
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.

/*
 * Troll.cs
 */

namespace Server
{

	/// <summary>
	/// Troll specific:
	/// Starting properties.
	/// Troll racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class Troll 
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
			c.ZoneId = 14;
			c.X = -618.518f;
			c.Y = -4251.67f;
			c.Z = 38.718f;
			c.Str = 21;
			c.Agility = 22;
			c.Stamina = 21;
			c.Iq = 16;
			c.Spirit = 21;
			c.Size = 1.0f;
			c.Model = 1478 + c.Gender;
			c.AllSkills.Add(lang = new OrcishSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new TrollishSkill(300, 300));      
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = -618.518f;
			c.BindingPointY = -4251.67f;
			c.BindingPointZ = 38.718f;
			c.BindingPointMapId = 1;
	
			/* 
			 * In order: Berserking, Regeneration, Beast Slaying, Throwing
			 * Specialization.
			 */
			c.TrainAbility(new int[] {20554, 20555, 20557, 20558});
		}
	}
}