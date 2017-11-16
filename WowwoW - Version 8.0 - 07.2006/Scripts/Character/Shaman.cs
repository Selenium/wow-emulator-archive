//	Script made by fulgas - 12/05/05 15:07:22
//      Script Changed by fulgas - 12/05/05 - Items
//	Script made by pionere - 10/05/05 00:29:15
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
	public class Shaman 
	{
		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			// Somebody please fill corectly
			c.TrainAbility(new int[] { 0x19CB});
			c.ActionBarAdd(0x19CB);
			
			/* Stats. */
			c.Str += 1;
			c.Stamina +=1;
			c.Iq +=1;
			c.Spirit += 2;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 47);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 75);
			c.Mana = c.BaseMana;
	
			/* Items. */
			// Author: fulgas (fulgas@gmail.com)
			if( (c.Race == Races.Orc) || (c.Race == Races.Tauren) )
			{
				c.Equip(new PrimitiveMantle(), Items.Slots.Shirt);
				c.Equip(new PrimitiveKilt(), Items.Slots.Legs);
				if( c.Race == Races.Orc )
				{
					c.PutObjectInBackpack( new ToughJerky(), 2, true );
				}
				else
				{
					c.PutObjectInBackpack( new ForestMushroomCap(), 2, true );
				}
			}
			else // troll
			{
				c.Equip(new TrollPrimitiveMantle(), Items.Slots.Shirt);
				c.Equip(new TrollPrimitiveKilt(), Items.Slots.Legs);
				c.PutObjectInBackpack( new ToughJerky(), 2, true );		
			}
			c.Equip(new WornMace(), Items.Slots.MainHand);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 4, true );
			c.CreateAndAddObject("Hearthstone");
			
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 16) gainHp = 17;
			else gainHp = c.Level+1;
			if (c.Level <= 32) gainMana = c.Level + 19;
			else gainMana = 52;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000035, 0.003641, 0.734310, -0.800626);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000031, 0.004480, 0.780040, -0.800471);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000022, 0.001800, 0.407867, -0.550889);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000020, 0.006030, 0.809570, -0.809220);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000038, 0.005145, 0.871006, -0.832029);
		}
	}
}
