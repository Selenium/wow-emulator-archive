//	Script made by fulgas - 12/05/05 15:08:07
//      Script modified by fulgas - 12/05/05 - Items
//	Script accepted by DrNexus - 11/05/05 23:37:21
//	Script modified by pionere - 11/05/05 22:16:51
 //	Script made by pionere - 10/05/05 00:31:03
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
	public class Warlock 
	{
		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			c.TrainAbility(new int[] { 0x19CB, 5019, 686, 687, 1180, 5009,
										 9078}); 
			c.ActionBarAdd(0x19CB);
			
			/* Stats. */
			c.Stamina +=1;
			c.Iq +=2;
			c.Spirit += 2;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 43);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 110);
			c.Mana = c.BaseMana;
	
			/* Items. */
			// Author: fulgas ( fulgas@gmail.com )
			if ( (c.Race == Races.Human) || (c.Race == Races.Gnome) ) // human and gnome
			{
				c.Equip(new AcolytesRobe(), Items.Slots.Chest);
				c.Equip(new AcolytesShirt(), Items.Slots.Shirt);
				c.PutObjectInBackpack( new ForestMushroomCap(), 2, true );
			}
			else 
			{
				c.Equip(new HordeAcolytesRobe(), Items.Slots.Chest);
				if ( c.Race == Races.Orc ) // orc
				{
					c.PutObjectInBackpack( new ToughJerky(), 2, true );					
				}
				else // Undead
				{
					c.PutObjectInBackpack( new ForestMushroomCap(), 2, true );					
				}
			}
			c.Equip(new AcolytesPants(), Items.Slots.Legs);
			c.Equip(new AcolytesShoes(), Items.Slots.Feet);
			c.Equip(new WornDagger(), Items.Slots.MainHand);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 4, true );
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 17) gainHp = 15;
			else gainHp = c.Level-2;
			if (c.Level <= 30) gainMana = c.Level + 21;
			else gainMana = 51;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000006, 0.002031, 0.278360, -0.340077);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000059, 0.004044, 1.040000, -1.488504);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000024, 0.000981, 0.364935, -0.570900);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000021, 0.003009, 0.486493, -0.400003);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000040, 0.006404, 1.038791, -1.039076);
		}
	}
}
