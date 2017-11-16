//	Script made by pionere - 12/05/05 22:08:03
//	Script accepted by DrNexus - 12/05/05 17:19:08
//	Script made by fulgas - 12/05/05 15:02:48
//      Script modified by fulgas - 10/05/05
//	Script modified by kroy - 08/05/05 17:09:08
 //	Script modified by kroy - 08/05/05 17:07:51

//	Script made by kroy - 08/05/05 15:58:04
//      Update by kroy: New skills/spells and comments. Recommended placement in a

// merged fulgas and pionere changes
/*
 * Druid.cs
 */

using System;
using Server.Items;

namespace Server.Scripts 
{

	/// <summary>
	/// Druid specific:
	/// Starting stats, starting items and level progression.
	/// Druid methods.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-06
	/// </summary>
    
	public class Druid 
	{

		/*
		 * Author: Kroy
		 *
		 * Starting stats, abilities, items and spells.
		 *
		 * Paramter c Character to set class specific starting properties on.
		 */
		public static void Start(Character c) 
		{

			/* In order: Attack, Unarmed, Staves, Wrath, Healing Touch. */
			c.TrainAbility(new int[] {0x19CB, 203, 227, 5176, 5185});
			c.ActionBarAdd(0x19CB);

			/* Stats. */
			c.Str = c.Str + 1;
			c.Iq = c.Iq + 2;
			c.Spirit = c.Spirit + 2;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 54);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 70);
			c.Mana = c.BaseMana;
	
			/* Items. */
			if (c.Race == Races.NightElf) 
			{ // Night Elf specific.
				c.Equip( new NovicesRobe(), Items.Slots.Chest); 
				c.Equip( new HandcraftedStaff(), Items.Slots.MainHand);
			} 
			else if (c.Race == Races.Tauren) 
			{ // Tauren specific.
				c.Equip( new TaurenNovicesRobe(), Items.Slots.Chest);
				c.Equip( new BentStaff(), Items.Slots.MainHand); 
			} // All druids.
			c.Equip( new NovicesPants(), Items.Slots.Legs);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 2, true );
			c.PutObjectInBackpack( new ShinyRedApple(), 4, true );
			c.CreateAndAddObject("Hearthstone"); 
		}
	
		/*
		 * Author: Kroy
		 * 
		 * Level progression rules.
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
			if (c.Level <= 17) gainHp = 17;
			else gainHp = c.Level;
			if (c.Level <= 25) gainMana = c.Level + 20;
			else gainMana = 45;
			gainStr = ClassHandlers.gainStat(c.Level, 0.000021, 0.003009, 0.486493, -0.400003);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000038, 0.005145, 0.871006, -0.832029);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000041, 0.000440, 0.512076, -1.000317);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000023, 0.003345, 0.560050, -0.562058);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000059, 0.004044, 1.040000, -1.488504);
		}
	}
}