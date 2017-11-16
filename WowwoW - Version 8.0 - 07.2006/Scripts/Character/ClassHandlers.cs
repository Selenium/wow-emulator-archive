//	Script made by pionere - 10/05/05 00:15:22
//	Script modified by kroy - 08/05/05 15:45:16
 //	Script accepted by DrNexus - 06/05/05 11:17:03
//	Script made by kroy - 06/05/05 11:15:56
//      Update by kroy: Just new comments. Recommended placement in a new folder
//      called Classes where all the class handlers will be stored.
//      Update by pionere: Added gainStat function
/*
 * ClassHandlers.cs
 */

using System;

namespace Server.Scripts 
{

	/// <summary>
	/// Methods for all classes.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-06
	/// </summary>
    
	public class ClassHandlers 
	{

		/*
		 * Author: Kroy
		 *
		 * Calculate starting HP for character c.
		 *
		 * Parameter c Character to set starting HP on.
		 * Parameter baseHP Base HP of character.
		 * Return starting HP.
		 */
		public static int StartingHP(Character c, int baseHP) 
		{
			if (c.Stamina < 20) 
			{
				return baseHP + (c.Stamina - 20);
			} 
			else 
			{
				if (c.Race == Races.Tauren) 
				{
					return Convert.ToInt32(1.05 * (baseHP + 10 * (c.Stamina - 20)));
				}
				return baseHP + 10 * (c.Stamina - 20);
			}
		}

		/*
		 * Author: Kroy
		 *
		 * Calculate starting mana for character c.
		 *
		 * Parameter c Character to set starting mana on.
		 * Parameter baseMana Base mana of character.
		 * Return starting mana.
		 */
		public static int StartingMana(Character c, int baseMana) 
		{
			if (c.Iq < 20) 
			{
				return baseMana + (c.Iq - 20);
			} 
			else 
			{
				return baseMana + 15 * (c.Iq - 20);
			}
		}

		/*
		 * Author: pionere
		 *
		 * Calculate the stat increase. Using 3rd grade polynome.
		 *
		 * Parameter level The level the character reached.
		 * Parameter a3 The factor for x^3.
		 * Parameter a2 The factor for x^2.
		 * Parameter a1 The factor for x^1.
		 * Parameter a0 The constant factor for the polynome.
		 * Return starting mana.
		 */
		public static int gainStat(int level, double a3, 
			double a2, double a1, double a0) 
		{
			return 
				(int)System.Math.Round(	a3*level*level*level +
				a2*level*level +
				a1*level +
				a0) -
				(int)System.Math.Round(	a3*(level-1)*(level-1)*(level-1) +
				a2*(level-1)*(level-1) +
				a1*(level-1) +
				a0);
		}

	
	}
}