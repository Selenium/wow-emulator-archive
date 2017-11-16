//	Script modified by nB3k - 17/08/05 00:04:30
//  Script modified by nB3k 15/08/05 - Rage 100, Removing gnomish racial skills, initial weapon skill by race
//	Script made by fulgas - 12/05/05 15:08:50
//      Script modified by fulgas - 12/05/05 - items
//	Script made by pionere - 10/05/05 00:31:56
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
	public class Warrior 
	{
		/* Starting stats, abilities, items and spells.
		 * Battle Stance, Battle Stance Passive, Heroic Strike, Parry, Block, Dodge,
		 * Cloth, Leather, Mail, Shield, Unarmed, Attack*/
		public static void Start(Character c) 
		{
			c.TrainAbility(new int[] { 0x0999, 0x52A4, 0xC37, 0x6B, 0x4E, 0x51, 
										 0x2376, 0x2375, 0x2221, 0x239C, 0xCB, 0x19CB,});
										/* Bows, Guns, Crossbows
										 * 0x108, 0x10A, 0x1393
										 * Shoot Bows 0x09B0, 
										 * Shoot Guns 0x1EEE, 
										 * Shoot Crossbows 0x1EEF,
										 * Auto Shot 0x4B,
										 * Throw(Thrown) 0xACC,
										 * Thrown 0xA07,
										 * Axes, Maces, Swords
										 * 0xC4, 0xC6, 0xC9,
										 * Two-Handed Axes 0xC5,
										 * Two-Handed Maces 0xC7,
										 * Two-Handed Swords 0xCA,
										 * Daggers 0x49C,
										 * Plate Mail 0x2EE,
										 * Train Plate Mail 0x3FC0,*/ 
			c.ActionBarAdd(0x19CB);
			
			/* Stats. */
			c.Str +=3;
			c.Stamina += 2;
			c.BaseHitPoints = ClassHandlers.StartingHP(c, 40);
			c.HitPoints = c.BaseHitPoints;
			c.BaseRage = 1000;
			c.Rage = 0;
	
			/* Items. */
			// Author: fulgas ( fulgas@gmail.com ) 10-05-2005
			// spell check Nigth => Night
			if ( c.Race == Races.Human ) // Human
			{
				c.TrainAbility(new int[] { 0xC4, 0xC6, 0xC9,}); // Axes, Maces, Swords
				c.Equip(new WornShortsword(), Items.Slots.MainHand);
				c.Equip(new WornWoodenShield(), Items.Slots.OffHand);
				c.Equip(new RecruitsShirt(), Items.Slots.Shirt);
				c.Equip(new RecruitsPants(), Items.Slots.Legs);
				c.Equip(new RecruitsBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			}
			else if ( c.Race == Races.NightElf ) // NightElf 
			{
				c.TrainAbility(new int[] { 0xC6, 0xC9, 0x49C,}); // Maces, Swords, Daggers
				c.Equip(new WornShortsword(), Items.Slots.MainHand);
				c.Equip(new WornWoodenShield(), Items.Slots.OffHand);
				c.Equip(new NightElfRecruitsShirt(), Items.Slots.Shirt);
				c.Equip(new NightElfRecruitsPants(), Items.Slots.Legs);
				c.Equip(new NightElfRecruitsBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			}
			else if ( (c.Race == Races.Dwarf) ) // Dwarf
			{
				c.TrainAbility(new int[] { 0xC4, 0xC5, 0xC6,}); // Axes, Two-Handed Axes, Maces
				c.Equip(new WornBattleaxe(), Items.Slots.MainHand);			
				c.Equip(new RecruitsShirt(), Items.Slots.Shirt);
				c.Equip(new RecruitsPants(), Items.Slots.Legs);
				c.Equip(new RecruitsBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			}
			else if ( c.Race == Races.Gnome ) // Gnome
			{
				c.TrainAbility(new int[] { 0xC6, 0xC9, 0x49C,}); // Maces, Swords, Daggers
				c.Equip(new WornShortsword(), Items.Slots.MainHand);
				c.Equip(new WornWoodenShield(), Items.Slots.OffHand);
				c.Equip(new RecruitsShirt(), Items.Slots.Shirt);
				c.Equip(new RecruitsPants(), Items.Slots.Legs);
				c.Equip(new RecruitsBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			}
			else if ( c.Race == Races.Orc ) // Orc
			{
				c.TrainAbility(new int[] { 0xC4, 0xC5, 0xC9,}); // Axes, Two-Handed Axes, Swords
				c.Equip(new WornBattleaxe(), Items.Slots.MainHand);
				c.Equip(new BrawlersHarness(), Items.Slots.Shirt);
				c.Equip(new BrawlersPants(), Items.Slots.Legs);						
				c.Equip(new BrawlersBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ToughJerky(), 4, true );
			}
			else if ( c.Race == Races.Undead ) // Undead
			{
				c.TrainAbility(new int[] { 0xC9, 0xCA, 0x49C,}); // Swords, Two-Handed Swords, Daggers
				c.Equip(new WornShortsword(), Items.Slots.MainHand);
				c.Equip(new WornWoodenShield(), Items.Slots.OffHand);
				c.Equip(new BrawlersHarness(), Items.Slots.Shirt);
				c.Equip(new BrawlersPants(), Items.Slots.Legs);
				c.Equip(new BrawlersBoots(), Items.Slots.Feet);
				c.PutObjectInBackpack( new ForestMushroomCap(), 4, true );	
			}
			else if ( c.Race == Races.Tauren ) //Tauren
			{
				c.TrainAbility(new int[] { 0xC4, 0xC6, 0xC7,}); // Axes, Maces, Two-Handed Maces
				c.Equip(new BattlewornHammer(), Items.Slots.MainHand);
				c.Equip(new BrawlersHarness(), Items.Slots.Shirt);
				c.Equip(new BrawlersPants(), Items.Slots.Legs);
				c.PutObjectInBackpack( new ToughHunkOfBread(), 4, true );
			}
			else if( c.Race == Races.Troll ) // Troll
			{
				c.TrainAbility(new int[] { 0xC4, 0x49C, 0xA07, 0xACC,}); // Axes, Daggers, Thrown, Throw(Thrown)
				c.Equip(new WornAxe(), Items.Slots.MainHand);
				c.Equip(new WornWoodenShield(), Items.Slots.OffHand);
				c.Equip(new BrawlersHarness(), Items.Slots.Shirt);
				c.Equip(new BrawlersPants(), Items.Slots.Legs);
				c.PutObjectInBackpack( new CrudeThrowingAxe(), 100, true );				
				c.PutObjectInBackpack( new ToughJerky(), 4, true );	
			}
			c.CreateAndAddObject("Hearthstone");
		}
	
		/* Level progression rules. */
		public static void LevelUp(Character c, ref int gainHp, ref int gainMana,
			ref float gainStr, ref float gainAgi,
			ref float gainSta, ref float gainInt, ref float gainSpi) 
		{
			if (c.Level <= 14) gainHp = 19;
			else gainHp = c.Level+10;

			gainStr = ClassHandlers.gainStat(c.Level, 0.000039, 0.006902, 1.080040, -1.051701);
			gainInt = ClassHandlers.gainStat(c.Level, 0.000002, 0.001003, 0.100890, -0.076055);
			gainAgi = ClassHandlers.gainStat(c.Level, 0.000022, 0.004600, 0.655333, -0.600356);
			gainSta = ClassHandlers.gainStat(c.Level, 0.000059, 0.004044, 1.040000, -1.488504);
			gainSpi = ClassHandlers.gainStat(c.Level, 0.000006, 0.002031, 0.278360, -0.340077);
		}
	}
}