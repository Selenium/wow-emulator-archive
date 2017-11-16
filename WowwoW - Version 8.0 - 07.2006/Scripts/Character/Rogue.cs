//	Script made by fulgas - 12/05/05 15:06:46
//      Script Changed by fulgas - 12/05/05 - Items
//	Script made by pionere - 10/05/05 00:27:59
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
	public class Rogue 
	{
		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			c.TrainAbility(new int[] { 0x19CB, 1180, 5009, 2764,
										 9078, 1752, 2098 }); 
			c.ActionBarAdd(0x19CB);
			

			/* Stats. */
			c.Str += 1;
			c.Stamina +=1;
			c.Agility += 3;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 45);
			c.HitPoints = c.BaseHitPoints;
			c.ManaType = 3;
	
			/* Items. */
			// Author: fulgas (fulgas@gmail.com)
			if ( c.Race == Races.Human || c.Race == Races.Dwarf
				|| c.Race == Races.NightElf || c.Race == Races.Gnome)
			{
				c.Equip(new FootpadsShirt(), Items.Slots.Shirt);
				c.Equip(new FootpadsPants(), Items.Slots.Legs);
				c.Equip(new FootpadsShoes(), Items.Slots.Feet);
				if (c.Race == Races.Human || c.Race == Races.NightElf
					|| c.Race == Races.Gnome)
				{
					c.PutObjectInBackpack( new SmallThrowingKnife(), 100, true );																		 
					if( c.Race == Races.Human )
						c.PutObjectInBackpack( new DarnassianBleu(), 4, true );
					else if (c.Race == Races.NightElf)
						c.PutObjectInBackpack( new ToughHunkOfBread(), 4, true );						
					else // gnome
						c.PutObjectInBackpack( new ToughJerky(), 4, true );												
				}
				else // Dwarf
				{
					c.PutObjectInBackpack( new CrudeThrowingAxe(), 100, true );
					c.PutObjectInBackpack( new ToughHunkOfBread(), 4, true );
				}				
			}
			else 
			{
				if ( c.Race == Races.Troll)
				{
					c.Equip(new TrollThugShirt(), Items.Slots.Shirt);
					c.Equip(new TrollThugPants(), Items.Slots.Legs);
					c.Equip(new TrollThugBoots(), Items.Slots.Feet);
				}
				else // orc
				{
					c.Equip(new ThugShirt(), Items.Slots.Shirt);
					c.Equip(new ThugPants(), Items.Slots.Legs);
					c.Equip(new ThugBoots(), Items.Slots.Feet);
				}
				if ( c.Race == Races.Orc || c.Race == Races.Troll)
				{
					c.PutObjectInBackpack( new CrudeThrowingAxe(), 100, true );
					c.PutObjectInBackpack( new ToughJerky(), 4, true );
				}
				else // undead
				{
					c.PutObjectInBackpack( new SmallThrowingKnife(), 100, true );
					c.PutObjectInBackpack( new ForestMushroomCap(), 4, true );
				}	
			}
			c.Equip(new WornDagger(), Items.Slots.MainHand);
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 15) gainHp = 17;
			else gainHp = c.Level+2;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000025, 0.004170, 0.654096, -0.601491);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000008, 0.001001, 0.163190, -0.064280);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000038, 0.007834, 1.191028, -1.203940);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000032, 0.003025, 0.615890, -0.640307);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000024, 0.000981, 0.364935, -0.570900);
		}
	}
}
