//	Script made by fulgas - 12/05/05 15:03:38
//      Changed Hunter items - fulgas 11/05/05
//	Script accepted by DrNexus - 11/05/05 23:36:05
//	Script made by pionere - 10/05/05 00:23:41
//	Script accepted by DrNexus - 08/05/05 16:36:17
//   DrNexus : I change the auto shot to shot because auto-shot is not working yet
//	Script modified by kroy - 08/05/05 15:47:49
//	Script accepted by DrNexus - 06/05/05 14:58:43
//	Script made by kroy - 06/05/05 11:17:13
//      Update by kroy: New skills/spells and comments. Recommended placement in a
//      new folder called Classes where all the class handlers will be stored.
//      modified by pionere: for the new levelup 
/*
 * Hunter.cs
 */

using System;
using Server.Items;

namespace Server.Scripts 
{

	/// <summary>
	/// Hunter specific:
	/// Starting stats, starting items and level progression.
	/// Hunter methods.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Kroy
	/// Created: 2005-05-06
	/// </summary>

	public class Hunter 
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

			/* In order: Attack, Shot, Unarmed. */
			//c.TrainAbility(new int[] {0x19CB, 5019, 203});
			c.TrainAbility(new int[] { 0x19CB, 203, 13795, 75, 266, 7918 });
			c.ActionBarAdd( 0x19CB );
			c.ActionBarAdd( 75 );

			/* Stats. */
			c.Agility = c.Agility + 3;
			c.Stamina = c.Stamina + 1;
			c.Spirit = c.Spirit + 1;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 46);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 85);
			c.Mana = c.BaseMana;
	
			/* Items. */
			if (c.Race == Races.Orc) 
			{ // Orc specific.

				/* In order: One-Handed Axes, Bows, Daggers.*/
				c.TrainAbility(new int[] {196, 264, 1180});
				c.Equip(new TrappersShirt(), Items.Slots.Shirt);
				c.Equip(new TrappersPants(), Items.Slots.Legs);
				c.Equip(new TrappersBoots(), Items.Slots.Feet);
				c.Equip(new WornAxe(), Items.Slots.MainHand);
				c.Equip(new WornShortbow(), Items.Slots.Ranged);
				c.PutObjectInBackpack( new RoughArrow(), 100, true );				
				c.CreateAndAddObject("LightQuiver", 1);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			} 
			else if (c.Race == Races.Dwarf) 
			{ // Dwarf specific.

				/* In order: One-Handed Axes, Guns, Daggers.*/
				c.TrainAbility(new int[] {196, 266, 1180});
				c.Equip(new RuggedTrappersShirt(), Items.Slots.Shirt);
				c.Equip(new RuggedTrappersPants(), Items.Slots.Legs);
				c.Equip(new RuggedTrappersBoots(), Items.Slots.Feet);
				c.Equip(new WornAxe(), Items.Slots.MainHand);
				c.Equip(new OldBlunderbuss(), Items.Slots.Ranged);
				c.PutObjectInBackpack( new LightShot(), 100, true );								
				c.CreateAndAddObject("SmallAmmoPouch", 1);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			} 
			else if (c.Race == Races.NightElf) 
			{ // Night Elf specific.

				/* In order: Bows, Daggers.*/
				c.TrainAbility(new int[] {264, 1180});
				c.Equip(new RuggedTrappersShirt(), Items.Slots.Shirt);
				c.Equip(new RuggedTrappersPants(), Items.Slots.Legs);
				c.Equip(new RuggedTrappersBoots(), Items.Slots.Feet);
				c.Equip(new WornDagger(), Items.Slots.MainHand);
				c.Equip(new WornShortbow(), Items.Slots.Ranged);
				c.PutObjectInBackpack( new RoughArrow(), 100, true );
				c.CreateAndAddObject("LightQuiver", 1);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );	
			} 
			
			else if (c.Race == Races.Tauren) 
			{ // Tauren specific.

				/* In order: One-Handed Axes, Guns. */
				c.TrainAbility(new int[] {196, 266});
				c.Equip(new TrappersShirt(), Items.Slots.Shirt);
				c.Equip(new TrappersPants(), Items.Slots.Legs);
				c.Equip(new WornAxe(), Items.Slots.MainHand);
				c.Equip(new OldBlunderbuss(), Items.Slots.Ranged);
				c.PutObjectInBackpack( new LightShot(), 100, true );
				c.CreateAndAddObject("SmallAmmoPouch", 1);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			} 
			else if (c.Race == Races.Troll) 
			{ // Troll specific.

				/* In order: One-Handed Axes, Bows, Daggers.*/
				c.TrainAbility(new int[] {196, 264, 1180});
				c.Equip(new TrappersShirt(), Items.Slots.Shirt);
				c.Equip(new TrappersPants(), Items.Slots.Legs);
				c.Equip(new WornAxe(), Items.Slots.MainHand);
				c.Equip(new WornShortbow(), Items.Slots.Ranged);
				c.PutObjectInBackpack( new RoughArrow(), 100, true );
				c.CreateAndAddObject("LightQuiver", 1);
				c.PutObjectInBackpack( new ForestMushroomCap(), 4, true );
			}// All hunters.
			c.PutObjectInBackpack( new RefreshingSpringWater(), 2, true );
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
			ref float gainStr, ref float gainAgi, ref float gainSta,
			ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 13) gainHp = 17;
			else gainHp = c.Level + 4;

			if (c.Level <= 27) gainMana = c.Level + 18; 
			else gainMana = 45;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000022, 0.001800, 0.407867, -0.550889);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000020, 0.003007, 0.505215, -0.500642);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000040, 0.007416, 1.125108, -1.003045);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000031, 0.004480, 0.780040, -0.800471);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000017, 0.003803, 0.536846, -0.490026);
		}
	}
}
