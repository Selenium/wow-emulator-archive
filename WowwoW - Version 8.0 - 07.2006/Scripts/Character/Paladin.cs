//	Script made by fulgas - 12/05/05 15:04:54
//     Changed Items - fulgas 12/05/05
//	Script made by pionere - 10/05/05 00:25:23
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
	public class Paladin 
	{
		/* Starting stats, abilities, items and spells. */
		public static void Start(Character c) 
		{
			c.TrainAbility(new int[] { 0x19CB, 20154, 107, 635, 198, 199, 9078,
										 9077, 8737, 9116});
			c.ActionBarAdd(0x19CB);
			
			Item it = new ToughHunkOfBread();
			/* Stats. */
			c.Str += 2;
			c.Stamina +=2;
			c.Spirit += 1;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 38);
			c.HitPoints = c.BaseHitPoints;
			c.BaseMana = ClassHandlers.StartingMana(c, 80);
			c.Mana = c.BaseMana;
	
			/* Items. */
			// Author: fulgas ( fulgas@gmail.com)
			// 11-05-2005
			if (c.Race == Races.Human)
			{
				c.Equip(new SquiresPants(), Items.Slots.Legs); 
				c.Equip(new SquiresShirt(), Items.Slots.Shirt); 
				c.PutObjectInBackpack( new DarnassianBleu(), 2, true );			
			}
			if (c.Race == Races.Dwarf)
			{
				c.Equip(new DwarfSquiresShirt(), Items.Slots.Shirt); 
				c.Equip(new DwarfSquiresPants(), Items.Slots.Legs);
				c.PutObjectInBackpack( new ToughHunkOfBread(), 3, true );
			}
			c.Equip(new SquiresBoots(), Items.Slots.Feet); 
			c.Equip(new BattlewornHammer(), Items.Slots.MainHand);
			c.PutObjectInBackpack( new RefreshingSpringWater(), 2, true );
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 14) gainHp = 18;
			else gainHp = c.Level+4;
			if (c.Level <= 25) gainMana = c.Level + 17;
			else gainMana = 42;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000037, 0.005455, 0.940039, -1.000090);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000023, 0.003345, 0.560050, -0.562058);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000020, 0.003007, 0.505215, -0.500642);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000038, 0.005145, 0.871006, -0.832029);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000032, 0.003025, 0.615890, -0.640307);
		}
	}
}
