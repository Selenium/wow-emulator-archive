//	Script made by pionere - 12/05/05 22:06:46
//	Script accepted by DrNexus - 12/05/05 17:19:53
//	Script made by fulgas - 12/05/05 15:04:19
// Changed Items - fulgas 12/05/05
// Merged fulgas, and pionere changes

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
	public class Mage 
	{

		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			c.TrainAbility(new int[] {0x19CB, 133, 168, 1459, 5504,
										 587});
			c.ActionBarAdd(0x19CB);

			/* Stats. */
			c.Iq = c.Iq + 3;
			c.Spirit = c.Spirit + 2;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 52);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 120);
			c.Mana = c.BaseMana;
	
			/* Items. */
			// Author: fulgas (fulgas@gmail.com)
			if ( (c.Race == Races.Human)||(c.Race == Races.Dwarf) || c.Race == Races.Gnome ) 
			{
				if( c.Race == Races.Human || (c.Race == Races.Gnome))
				{
					c.Equip(new ApprenticesRobe(), Items.Slots.Chest);
					if( c.Race == Races.Human ) // human
					{
						c.PutObjectInBackpack( new DarnassianBleu(), 2, true );

					}
					else // gnome
					{
						c.PutObjectInBackpack( new ShinyRedApple(), 2, true );
					}
				}
				else if (c.Race == Races.Dwarf) // Dwarf
				{
					c.Equip(new DwarfApprenticesRobe(), Items.Slots.Chest);
					c.PutObjectInBackpack( new ToughHunkOfBread(), 2, true );
				}
			}
			else
			{
				c.Equip(new HordeApprenticesRobe(), Items.Slots.Chest);
				if( c.Race == Races.Undead ) // undead
				{
					c.PutObjectInBackpack( new ForestMushroomCap(), 2, true );					
				} 
				else // troll
				{
					c.PutObjectInBackpack( new ToughJerky(), 2, true );										
				}
			}
			c.Equip( new ApprenticesShirt(), Items.Slots.Shirt);
			c.Equip( new ApprenticesPants(), Items.Slots.Legs);
			c.Equip( new ApprenticesBoots(), Items.Slots.Feet);
			c.Equip( new BentStaff(), Items.Slots.MainHand);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 4, true );													
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 25) gainHp = 15; // HP below level 25.
			else gainHp = c.Level-8; // HP above level 25.
			if (c.Level <= 27) gainMana = c.Level + 23; // Mana at level 27 and below.
			else gainMana = 51; // Mana above level 27.
            
			gainStr = ClassHandlers.gainStat(c.Level, 0.000002, 0.001003, 0.100890, -0.076055);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000040, 0.007416, 1.125108, -1.003045);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000008, 0.001001, 0.163190, -0.064280);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000006, 0.002031, 0.278360, -0.340077);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000039, 0.006981, 1.090090, -1.006070);
		}
	}
}