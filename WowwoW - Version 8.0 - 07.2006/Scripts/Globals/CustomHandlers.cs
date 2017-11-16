//	Script made by pionere - 10/05/05 00:13:55
//	Script modified by kroy - 08/05/05 15:50:06
//	Script accepted by DrNexus - 06/05/05 14:58:51
//	Script made by kroy - 06/05/05 13:51:37
//      Update by kroy: New stucture and comments.
//      Update by pionere: Leveling, and starting
/*
 * CustomHandlers.cs
 */

using System;
using Server;
using Server.Items;
using Server.Creatures;


namespace Server.Scripts 
{
	/// <summary>
	/// General global methods.
	/// 
	/// Version: 1.00, 2005-05-08
	/// Author: Dr Nexus
	/// Modified by: Kroy
	/// Created: N/A
	/// </summary>
	public class CustomHandlers 
	{ 

		/*
		 * Author: Dr Nexus
		 *
		 * Default constructor.
		 */
		public CustomHandlers() 
		{
			Character.onCreateCharacter = new CharacterHandler(OnCreateCharacter);
			Character.onCharacterChooseRace = new CharacterChooseRace(
				OnCharacterChooseRace);
			Character.onLogin = new CharacterHandler(OnLogin);
			Character.onLogout = new CharacterHandler(OnLogout);
			Character.onCommand = new CharacterCommandHandler(OnCommand);		
			Character.onTrainningAck = new CharacterHandler(OnTrainningAck);
			Character.onLearn = new LearnProfession(OnLearnProfession);
			Character.onLevelUp = new LevelUp(OnLevelUp);
			Character.onHeartBeat = new EveryHeartBeat(OnHeartBeat);
			Character.onSpellPrice = new SpellPrice(OnSpellPrice);
			Character.onCraftLevelRequesite = new CraftLevelRequesite(
				OnCraftLevelRequesite);
			Character.onCraftSkillPrerequesite = new CraftSkillPrerequesite(
				OnCraftSkillPrerequesite);
			Character.onSkillProgressFactor = new SkillProgressFactorHandler( OnSkillProgressFactor );
			Character.onCharacterReclaimCorps = new CharacterReclaimCorps( OnCharacterReclaimCorps );
			Character.onCharacterRepop = new CharacterReclaimCorps( OnCharacterRepop );
			Character.onAreaTrigger = new AreaTrigger( OnAreaTrigger );

		}

		//	Called when the character enter a new area
		public void OnAreaTrigger( Character ch, int areaId )
		{
			try
			{
				if ( ch != null && ch.GetActiveQuests != null )
				{
 
					ActiveQuest[] list = ch.GetActiveQuests;
					for ( int i=0; i<list.Length; i++ )
					{
						if ( list[i]!= null ) 
							list[i].CheckAreaId( areaId );
					}
					//for debug only
					//ch.SendMessage( "AreaId: "+areaId.ToString() );
				}
				AreaTriggers.Start( ch, areaId ); 
			}
			catch( Exception e )
			{
				Console.WriteLine("AreaTrigger exception !" );
				Console.WriteLine( e.Message );
				Console.WriteLine( e.Source );
				Console.WriteLine( e.StackTrace );
			}
		}

		//	Script made by fen4o - 10/06/05 11:56:37
		//Insert into CustomHandlers.cs . Special thanks to Dr.Nexus
		public void OnCharacterReclaimCorps( Character ch )
		{
			if (ch.Race == Races.NightElf)
			{
				AuraEffect af = (AuraEffect)Abilities.abilities[ 20585 ];
				ch.ReleaseAura( af );// release the wisp aura
				ch.CancelPolymorph();
			}
		}

		public void OnCharacterRepop( Character ch )
		{
			if (ch.Race == Races.NightElf )
			{
				AuraEffect af = (AuraEffect)Abilities.abilities[ 20585 ];
				Aura aura = new Aura();
				aura.SpeedModifier = 1.5f;
				aura.OnRelease = new Aura.AuraReleaseDelegate( OnReleaseWispForm );// <- to tell to the client the speed change
				ch.AddAura( af, aura, true ); // <--- BEFORE THE CHANGERUNSPEED
				ch.ChangeRunSpeed( ch.RunSpeed);
				ch.Polymorph( 10045 );
			}
		}
		public void OnReleaseWispForm( Mobile c )
		{
			c.ChangeRunSpeed( c.RunSpeed);
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On character login.
		 *
		 * Parameter c Character to do something with.
		 * Return true when done.
		 */
		public bool OnLogin(Character ch ) 
		{
			// Made by SneakerXZ ;) 
			ch.SendMessage("Welcome to [|cff2020ff"+World.ServerName+"|r], [|cffff2020"+ch.Name+"|r] !"); 
			ch.SendMessage("Server version: |c8f20ff20WowwoW " + World.Version + "|r"); 
			Console.WriteLine( "Login : " + ch.Name + " joined on the server in: " + DateTime.Now ); 
			return true; // execute the caller code
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On character logout.
		 *
		 * Parameter c Character to do something with.
		 * Return true when done.
		 */    
		public bool OnLogout(Character c ) 
		{
			Console.WriteLine( "Logout : " + c.Name + " leave on the server in: " + DateTime.Now ); 
			return true; // execute the caller code
		}

		/*
		 * Author: Dr Nexus
		 *
		 * Every second.
		 *
		 * Parameter c Character to do something with.
		 * Return true when done.
		 */   
		public bool OnHeartBeat(Character c) 
		{ // call every second
			return true; // execute the caller code
		}		

		/*
		 * Author: Dr Nexus
		 *
		 * On character creation.
		 * 
		 * Parameter c Character to create.
		 * Return the default code.
		 */
		public bool OnCreateCharacter(Character c) 
		{
			if ((c.Player != null) &&
				(c.Player.AccessLevel != AccessLevels.PlayerLevel)) 
			{
				c.Copper = 100000;
			} 
			else 
			{
				c.Copper = 10000;
			}
			return true; // execute the caller code
		}

		/*
		 * Author: Dr Nexus
		 * Modified by: Kroy
		 *
		 * Choose the race and set race specific attributes, for character c.
		 *
		 * Parameter c Character to set.
		 * Parameter race of the character.
		 * Return create basic stats.
		 */ 
		public bool OnCharacterChooseRace(Character c, Races race) 
		{
			//Skill lang = null;
			if (race == Races.Dwarf) 
			{
				Dwarf.Start(c);
			} 
			else if (race == Races.Gnome) 
			{
				Gnome.Start(c);
			} 
			else if (race == Races.Human) 
			{
				Human.Start(c); 
			} 
			else if (race == Races.NightElf) 
			{
				NightElf.Start(c);
			} 
			else if (race == Races.Orc) 
			{
				Orc.Start(c); 
			} 
			else if (race == Races.Tauren) 
			{
				Tauren.Start(c);
			} 
			else if (race == Races.Troll) 
			{
				Troll.Start(c);
			} 
			else if (race == Races.Undead) 
			{
				Undead.Start(c);      
			} 
			ChooseClass(c); // Coose class after race.
			return true; // execute the caller code
		}

		/*
		 * Author: Kroy
		 *
		 * Choose the class and set class specific attributes, for character c.
		 *
		 * Parameter c Character to set.
		 */
		public void ChooseClass(Character c) 
		{
			if (c.Classe == Classes.Druid) 
			{
				Druid.Start(c);
			} 
			else if (c.Classe == Classes.Hunter) 
			{
				Hunter.Start(c);
			} 
			else if (c.Classe == Classes.Mage) 
			{ // Dr Nexus:
				Mage.Start(c);
			} 
			else if (c.Classe == Classes.Paladin) 
			{ // MaXXiN:
				Paladin.Start(c);
			} 
			else if (c.Classe == Classes.Priest) 
			{
				Priest.Start(c);
			} 
			else if (c.Classe == Classes.Rogue) 
			{ // Dr Nexus:
				Rogue.Start(c);
			} 
			else if (c.Classe == Classes.Shaman) 
			{
				Shaman.Start(c);
			} 
			else if (c.Classe == Classes.Warlock) 
			{ // MaXXiN:
				Warlock.Start(c);
			} 
			else if (c.Classe == Classes.Warrior) 
			{ // Dr Nexus:
				Warrior.Start(c);
			}
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On professions trainning.
		 * 
		 * Parameter c Character who has number of professions.
		 * Return true if less than four profession, otherwise false.
		 */
		public bool OnTrainningAck(Character c) 
		{
			if ( c.nProfessions > 4 ) 
			{
				return false; // Set the max prof to 4, abort
			}
			return true; // continue, let the player learn the profession
		}


		public bool OnCommand(Character c, string cmd) 
		{
			if ( c.Selection is Mobile && Commands.Commands.Handle( c, ( c.Selection as Mobile ), cmd, false)) 
				return false;
			return true; // execute the caller code
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On learning professions.
		 *
		 * Parameter c Character to learn profession on.
		 * Paramter level Profession level.
		 * Return learn profession or default code.
		 */
		public bool OnLearnProfession(Character c, ProfessionLevels level,
			Professions type) 
		{
			if (level == ProfessionLevels.Apprentice) 
			{
				if (type == Professions.Miner) 
				{
					c.LearnSpell(2580);
					c.LearnSpell(2577);
					c.LearnSpell(2657);				
					c.LearnSpell(2656);
					c.Copper-=100;
					return false; // do not add the default learning list
				}
				if (type == Professions.Herborist) 
				{
					c.LearnSpell( 3570 );			
					return false; // do not add the default learning list
				}
				if (type == Professions.Blacksmith) 
				{
					c.LearnSpell(2738); // copper axe		
					c.LearnSpell(2739); // copper sword		
					c.LearnSpell(2737); // copper mace		
					c.LearnSpell(3293); // copper battle axe		
					c.LearnSpell(3292); // copper heavy broadsword		
					return false; // do not add the default learning list
				}
				if (type == Professions.LeatherWorker) 
				{


					return false; // do not add the default learning list
				}
			}
			return true; // execute the default code
		}

		/*
		 * Author: Dr Nexus
		 * Modified by: Kroy
		 *
		 * Call the level up method for the corresponding class.
		 *
		 * Parameter c Character to level up.
		 * Parameter level Current level.
		 * Parameter gainHP Hit points to gain on level up.
		 * Parameter gainMana Mana to gain on level up.
		 * Parameter gainStrength Strength to gain on level up.
		 * Parameter gainAgility Agility to gain on level up.
		 * Parameter gainStamina Stamina to gain on level up.
		 * Parameter gainInt Intellect to gain on level up.
		 * Parameter gainSpirit Spirit to gain on level up.
		 * Return level up or default code.
		 */
		bool OnLevelUp(Character c, int level, ref int gainHp, ref int gainMana,
			ref float gainStrength, ref float gainAgility,
			ref float gainStamina, ref float gainInt, ref float gainSpirit) 
		{
			/* Class specific level up */
			switch (c.Classe) 
			{
				case Classes.Druid:
					Druid.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Hunter:
					Hunter.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Mage:
					Mage.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Priest:
					Priest.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Paladin:
					Paladin.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Rogue:
					Rogue.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Shaman:
					Shaman.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Warrior:
					Warrior.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Classes.Warlock:
					Warlock.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				default:
					Console.WriteLine("LevelUP wrong Classe:" + c.Classe);
					break;
			}
			/* If we have racial bonus */
			switch (c.Race) 
			{
				case Races.Gnome:
					Gnome.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Races.Human:
					Human.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				case Races.Tauren:
					Tauren.LevelUp(c, ref gainHp, ref gainMana, ref gainStrength,
						ref gainAgility, ref gainStamina, ref gainInt,
						ref gainSpirit);
					break;
				default:
					break;
			} 
			/* Penalty for low stat classes */
			if ( ((c.Iq + gainInt)<=20) &&
				(gainInt>0) ) 
			{
				// Before 20 int point you not gain that much mana
				gainMana-=14;
				if (gainMana<0) 
				{
					gainMana=0;
				}
			}
			if ( ((c.Stamina + gainStamina)<=20) &&
				(gainStamina>0) )
			{
				// Before 20 stamina point you not gain that much hp
				gainHp-=9;
			}
			return true; // execute the default code
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On spell price.
		 * 
		 * Parameter c Character.
		 * Parameter id spell id.
		 * Return 0.
		 */
		int OnSpellPrice(Character c, int spellId) 
		{
			return 0; // let the core make the decision
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On crafting skill level requestite.
		 * 
		 * Parameter c Character.
		 * Parameter id Craft spell id.
		 * Return 0.
		 */
		int OnCraftLevelRequesite(Character c, int id) 
		{
			return 0; // let the core make the decision
		}

		/*
		 * Author: Dr Nexus
		 *
		 * On crafting skill prerequesite.
		 * 
		 * Parameter c Character.
		 * Parameter id Craft spell id.
		 * Return 0.
		 */
		int OnCraftSkillPrerequesite(Character c, int id) 
		{
			return 0; // let the core make the decision
		}

		public float OnSkillProgressFactor( Mobile from, int skillValue, int skillId )
		{//	the growing skill factor
			//	the higher is the return value the faster is the skill growing rate
			return 5f;
		}
	}
}




