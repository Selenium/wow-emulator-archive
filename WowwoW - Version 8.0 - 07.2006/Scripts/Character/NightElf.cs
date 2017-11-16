//	Script made by kroy - 08/05/05 15:54:16
// New class for Race specific stuff. Recommeded placement in a folder called Races
// where all the race handlers will be placed.

/*
 * NightElf.cs
 */

namespace Server
{

	/// <summary>
	/// Night Elf specific:
	/// Starting properties.
	/// Night Elf racial spells/abilities definitions.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-08
	/// </summary>

	public class NightElf 
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
			c.X = 10311.3f;
			c.Y = 832.463f;
			c.Z = 1326.41f;
			c.Str = 17;
			c.Agility = 25;
			c.Stamina = 19;
			c.Iq = 20;
			c.Spirit = 20;
			c.Size = 1.0f;
			c.Model = 55 + c.Gender;
			c.AllSkills.Add(lang = new CommonSkill(300, 300));
			c.TrainAbility(lang.SpellId);
			c.AllSkills.Add(lang = new DarnassianSkill(300, 300));      
			c.TrainAbility(lang.SpellId);
			c.BindingPointX = 10311.3f;
			c.BindingPointY = 832.463f;
			c.BindingPointZ = 1326.41f;
			c.BindingPointMapId = 1;
	
			/* In order: Shadowmeld, Quickness, Nature Resistance, Wisp Spirit. */
			c.TrainAbility(new int[] {20580, 20582, 20583, 20585});
		}
	
		/*
		 * Author: egoisto
		 * Modified by: Kroy
		 *
		 * Shadowmeld racial ability.
		 *
		 * Parameter ba BaseAbility.
		 * Parameter c Character to apply the ability on.
		 */
		public static void OnCastShadowmeld(BaseAbility ba, Mobile c) 
		{
			AuraEffect ae = (AuraEffect) ba;
			Aura aura = new Aura();
			aura.OnRelease = new Aura.AuraReleaseDelegate(OnCastShadowmeldEnded);
			c.Visible = InvisibilityLevel.Lesser;
			c.AddAura(ae, aura);
		}

		/*
		 * Author: egoisto
		 *
		 * Shadowmeld racial ability end.
		 *
		 * Parameter c Character to end the ability on.
		 */
		public static void OnCastShadowmeldEnded(Mobile c) 
		{
			c.Visible = InvisibilityLevel.Visible;
		} 
	}
}