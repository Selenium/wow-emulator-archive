//	Script made by fulgas - 12/05/05 15:06:10
//     Script Change by fulgas - 12/05/05 - Items
//	Script made by pionere - 10/05/05 00:26:22
using System;
using Server.Items;

//	Script made by pionere - 08/05/05 12:53:24
/////////////////////////////////////////////
namespace Server.Scripts
{

	/*
	 * Author: pionere modified Kroy's Druid class
	 * Date: 2005-05-07.
	 * Mage methods.
	 * Called from CustomHandlers.cs.
	 * Currently starting stats, starting items and level progression. 
	 */
	public class Priest 
	{
		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			// Somebody please fill
			c.TrainAbility(new int[] {0x19CB,81,5019,585,2050});
			c.ActionBarAdd(0x19CB);

			/* Stats. */
			c.Iq += 2;
			c.Spirit += 3;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 52);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 130);
			c.Mana = c.BaseMana;
	
			/* Items. */
			// Author: fulgas (fulgas@gmail.com)
			if (c.Race == Races.Human || c.Race == Races.Dwarf
				|| c.Race == Races.NightElf)
			{
				if( c.Race == Races.NightElf)
				{
					c.Equip(new NightElfNeophytesRobe(), Items.Slots.Chest);
				}
				else // Human and Dwarf
				{
					c.Equip(new NeophytesRobe(), Items.Slots.Chest);
				}
				if (c.Race == Races.Human || c.Race == Races.NightElf)
				{
					c.PutObjectInBackpack( new DarnassianBleu(), 4, true );	
				}
				else // Dwarf
				{
					
					c.PutObjectInBackpack( new ToughHunkOfBread(), 4, true );
				}
				c.Equip(new NeophytesBoots(), Items.Slots.Feet);
			}
			else
			{
				c.Equip(new HordeNeophytesRobe(), Items.Slots.Chest);
				if (c.Race == Races.Undead)
				{
					c.Equip(new NeophytesBoots(), Items.Slots.Feet);
					c.PutObjectInBackpack( new ForestMushroomCap(), 4, true );
				}
				else // Troll
				{
					c.PutObjectInBackpack( new ToughHunkOfBread(), 4, true );
				}	
			}
			c.Equip(new NeophytesShirt(), Items.Slots.Shirt);
			c.Equip(new NeophytesPants(), Items.Slots.Legs);
			c.Equip(new WornMace(), Items.Slots.MainHand);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 2, true );
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 22) gainHp = 15;
			else gainHp = c.Level-6;
			if (c.Level <= 33) gainMana = c.Level + 22;
			else gainMana = 54;
			if (c.Level==34) gainMana+=15;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000008, 0.001001, 0.163190, -0.064280);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000039, 0.006981, 1.090090, -1.006070);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000022, 0.000022, 0.260756, -0.494000);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000024, 0.000981, 0.364935, -0.570900);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000040, 0.007416, 1.125108, -1.003045);
		}
	}
}
