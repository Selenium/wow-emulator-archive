using System;
using System.Text.RegularExpressions;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for CharCreate.
	/// </summary>
	[LoginPacketHandler()]
	public class CharCreate
	{
		static Regex nameCheck = new Regex(@"[^a-z]", RegexOptions.Compiled);
		static int[] male_models = {0, 49, 51, 53, 55, 57, 59, 1563, 1478};
		static int[] female_models = {0, 50, 52, 54, 56, 58, 60, 1564, 1479};

		static void AddSpell(uint SpellID,DBCharacter c)
		{
			try
			{
				DBSpell targetSpell = (DBSpell)DataServer.Database.FindObjectByKey(typeof(DBSpell), SpellID);
				DBKnownSpell newSpell = new DBKnownSpell();
				newSpell.Spell_Id = SpellID;
				if (c.Spells==null||c.Spells.Length==0)
					newSpell.Slot=1;
				else
					newSpell.Slot=(uint)c.Spells.Length+1;
				newSpell.CharacterID=c.ObjectId;
				newSpell.SpellLevel=1;
				DataServer.Database.AddNewObject(newSpell);
				DataServer.Database.FillObjectRelations(c);
				DataServer.Database.FillObjectRelations(c.Spells[newSpell.Slot-1]);
			}
			catch(Exception e)
			{
				Console.WriteLine("Adding Spell Exception: "+e.Message);
			}
		}

		[LoginPacketDelegate(CMSG.CHAR_CREATE)]
		static bool HandleCharCreate(LoginClient client, CMSG msgID, BinReader data)
		{
			string name = data.ReadString();
			string name2 = name.ToLower();
			
			BinWriter w = LoginClient.NewPacket(SMSG.CHAR_CREATE);

			if(name2 != nameCheck.Replace(name2, ""))
			{
				w.Write((byte)0x30);
				client.Send(w);
				return true;
			}

			DBCharacter c = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name2);
			if(c != null)
			{
				w.Write((byte)0x30);
				client.Send(w);
				return true;
			}
			if(client.Account.Characters != null && client.Account.Characters.Length == 8)
			{
				w.Write((byte)0x33);
				client.Send(w);
				return true;
			}
			c = new DBCharacter();
			c.Name = name;
			c.AccountID = client.Account.ObjectId;
			c.Race = (RACE)data.ReadByte();
			c.Class = (CLASS)data.ReadByte();
			c.Gender = data.ReadByte();
			c.Skin = data.ReadByte();
			c.Face = data.ReadByte();
			c.HairStyle = data.ReadByte();
			c.HairColor = data.ReadByte();
			c.FacialHairStyle = data.ReadByte();
			if(c.Gender == 0)
				c.DisplayID = male_models[(byte)c.Race];
			else
				c.DisplayID = female_models[(byte)c.Race];

			c.Money = 100;
			c.Exp = 0;
			c.Resist_Physical = 0;
			c.Resist_Holy = 0;
			c.Resist_Fire = 0;
			c.Resist_Nature = 0;
			c.Resist_Frost = 0;
			c.Resist_Shadow = 0;
			c.AttackPower = 11;
			c.AttackPowerModifier = 1;
			c.Level = 1;
			c.Facing = 0.0f;
			c.Scale = 1.0f;
			c.MaxHealth = 100;
			c.Health = 100;
			c.MaxPower = 100;
			c.Power = 100;

			#region Start point

			switch((RACE)c.Race)
			{
				case RACE.HUMAN:
					c.Faction = 1;
					c.Position = new Vector(-8898.118f, -173.2708f, 81.57769f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 0;
					c.BaseStrength = c.Strength = 20;
					c.BaseAgility = c.Agility = 20;
					c.BaseStamina = c.Stamina = 20;
					c.BaseIntellect = c.Intellect = 20;
					c.BaseSpirit = c.Spirit = 20;
					break;

				case RACE.ORC:
					c.Faction = 2;
					c.Position = new Vector(-601.8857f, -4250.712f, 38.95608f);//c.Position = new Vector(-622.79303f, -4284.720215f, 39.543598f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 23;
					c.BaseAgility = c.Agility = 17;
					c.BaseStamina = c.Stamina = 22;
					c.BaseIntellect = c.Intellect = 17;
					c.BaseSpirit = c.Spirit = 21;
					break;

				case RACE.DWARF:
					c.Faction = 3;
					c.Position = new Vector(-6102.929f, 395.7565f, 395.5409f);//c.Position = new Vector(-6237.830078f, 311.192993f, 383.7818f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 0;
					c.BaseStrength = c.Strength = 22;
					c.BaseAgility = c.Agility = 17;
					c.BaseStamina = c.Stamina = 23;
					c.BaseIntellect = c.Intellect = 19;
					c.BaseSpirit = c.Spirit = 19;
					break;

				case RACE.NIGHTELF:
					c.Faction = 4;
					c.Position = new Vector(10479.66f,811.8455f,1322.744f);//c.Position = new Vector(10313f, 830.203979f, 1326.400024f);
					c.Zone = 90;
					c.WorldMapID = 2;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 16;
					c.BaseAgility = c.Agility = 25;
					c.BaseStamina = c.Stamina = 19;
					c.BaseIntellect = c.Intellect = 20;
					c.BaseSpirit = c.Spirit = 20;
					break;

				case RACE.UNDEAD:
					c.Faction = 5;
					c.Position = new Vector(1676.458f, 1678.227f, 121.6705f);//c.Position = new Vector(1671.310059f, 1678.369995f, 120.719002f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 0;
					c.BaseStrength = c.Strength = 19;
					c.BaseAgility = c.Agility = 18;
					c.BaseStamina = c.Stamina = 21;
					c.BaseIntellect = c.Intellect = 17;
					c.BaseSpirit = c.Spirit = 25;
					break;

				case RACE.TAUREN:
					c.Faction = 6;
					c.Position = new Vector(-2873.756f, -218.8642f, 54.77188f);//c.Position = new Vector(-2920.649902f, -258.485992f, 52.994900f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 25;
					c.BaseAgility = c.Agility = 16;
					c.BaseStamina = c.Stamina = 22;
					c.BaseIntellect = c.Intellect = 16;
					c.BaseSpirit = c.Spirit = 21;
					break;

				case RACE.GNOME:
					c.Faction = 3;
					c.Position = new Vector(-6102.929f, 395.7565f, 395.5409f);//c.Position = new Vector(-6237.830078f, 311.192993f, 383.7818f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 0;
					c.BaseStrength = c.Strength = 15;
					c.BaseAgility = c.Agility = 23;
					c.BaseStamina = c.Stamina = 19;
					c.BaseIntellect = c.Intellect = 23;
					c.BaseSpirit = c.Spirit = 20;
					break;

				case RACE.TROLL:
					c.Faction = 2;
					c.Position = new Vector(-601.8857f, -4250.712f, 38.95608f);//c.Position = new Vector(-626.210999f, -4252.870117f, 38.425900f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 20;
					c.BaseAgility = c.Agility = 22;
					c.BaseStamina = c.Stamina = 21;
					c.BaseIntellect = c.Intellect = 16;
					c.BaseSpirit = c.Spirit = 21;
					break;

				case RACE.MAX:
					c.Faction = 0;
					c.Position = new Vector(10479.66f,811.8455f,1322.744f);//c.Position = new Vector(-89, 208.5f, 53.3f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 20;
					c.BaseAgility = c.Agility = 20;
					c.BaseStamina = c.Stamina = 20;
					c.BaseIntellect = c.Intellect = 20;
					c.BaseSpirit = c.Spirit = 20;
					break;

				default:
					c.Faction = 0;
					c.Position = new Vector(-601.8857f, -4250.712f, 38.95608f);//c.Position = new Vector(-89, 208.5f, 53.3f);
					c.Zone = 90;
					c.WorldMapID = 1;
					c.Continent = 1;
					c.BaseStrength = c.Strength = 20;
					c.BaseAgility = c.Agility = 20;
					c.BaseStamina = c.Stamina = 20;
					c.BaseIntellect = c.Intellect = 20;
					c.BaseSpirit = c.Spirit = 20;
					break;					
			}
			#endregion

			#region LegoDB
			switch((CLASS)c.Class)
			{
				case CLASS.WARRIOR:
					c.PowerType = POWERTYPE.RAGE;
					c.BaseStrength += 3;
					c.Strength += 3;					
					c.BaseStamina += 2;
					c.Stamina += 2;
					//NEWBIE ITENS DATABASE FOR WARRIORS
					DataServer.Database.AddNewObject(c);
					
					GiveStartItem(c, 0x0F, 1);	//Worn Shortsword
					GiveStartItem(c, 0x10, 2);	// Worn Wooden Shield 

					
				switch((RACE)c.Race)
				{
					case RACE.DWARF:
					case RACE.GNOME:
					case RACE.HUMAN:	//Warrior Good
						GiveStartItem(c, 0x03, 10);	//Recruit's Shirt
						GiveStartItem(c, 0x06, 11);	//Recruit's Pants
						GiveStartItem(c, 0x07, 12);	//Recruit's Boots
						break;
					
					case RACE.NIGHTELF:
						GiveStartItem(c, 0x03, 16);	//Shirt
						GiveStartItem(c, 0x06, 17);	//Pants
						GiveStartItem(c, 0x07, 18);	//Boots
						break;

					case RACE.ORC:
					case RACE.UNDEAD:	//Warrior Evil
						GiveStartItem(c, 0x03, 13);	//Shirt
						GiveStartItem(c, 0x06, 14);	//Pants
						GiveStartItem(c, 0x07, 15);	//Boots
						break;						

					case RACE.TROLL:
					case RACE.TAUREN:
						GiveStartItem(c, 0x03, 13);	//Shirt
						GiveStartItem(c, 0x06, 14);	//Pants
						break;
	
				}
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED WARRIOR EQUIP
					break;
				
				case CLASS.PALADIN:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStrength += 2;
					c.Strength += 2;					
					c.BaseStamina += 2;
					c.Stamina += 2;					
					c.BaseSpirit += 1;
					c.Spirit += 1;

					//NEWBIE ITENS DATABASE FOR PALADIN
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 6);	//Newbie Hammer  (I liked Battleword better personally :P )

				switch((RACE)c.Race)
				{
					case RACE.DWARF:
						GiveStartItem(c, 0x03, 37);	//Shirt
						GiveStartItem(c, 0x06, 38);	//Pants
						GiveStartItem(c, 0x07, 39);	//Boots
						break;						
						
					case RACE.HUMAN:	
						GiveStartItem(c, 0x03, 34);	//Shirt
						GiveStartItem(c, 0x06, 35);	//Pants
						GiveStartItem(c, 0x07, 36);	//Boots
						break;						
				}

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED PALADIN
					break;

				case CLASS.ROGUE:
					c.PowerType = POWERTYPE.ENERGY;
					c.BaseStrength += 1;
					c.Strength += 1;					
					c.BaseAgility += 3;
					c.Agility += 3;					
					c.BaseStamina += 1;
					c.Stamina += 1;

					//NEWBIE ITENS DATABASE FOR ROGUE
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 3);	//Worn Dagger

				switch((RACE)c.Race)
				{
					case RACE.DWARF:
					case RACE.GNOME:
					case RACE.HUMAN:
					case RACE.NIGHTELF://Rogue Good
						GiveStartItem(c, 0x03, 19);	//Shirt
						GiveStartItem(c, 0x06, 20);	//Pants
						GiveStartItem(c, 0x07, 21);	//Boots
						break;						

					case RACE.ORC:
					case RACE.UNDEAD:
						GiveStartItem(c, 0x03, 22);	//Shirt
						GiveStartItem(c, 0x06, 23);	//Pants
						GiveStartItem(c, 0x07, 24);	//Boots
						break;						

					case RACE.TROLL:
						GiveStartItem(c, 0x03, 25);	//Shirt
						GiveStartItem(c, 0x06, 26);	//Pants
						GiveStartItem(c, 0x07, 27);	//Boots
						break;						
				}
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED ROUGE
					break;

				case CLASS.PRIEST:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 2;
					c.Spirit += 2;					

					//NEWBIE ITENS DATABASE FOR PRIEST
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 7);	//Worn Mace
					
				switch((RACE)c.Race)
				{
					case RACE.DWARF:
					case RACE.GNOME:
					case RACE.HUMAN:
						GiveStartItem(c, 0x03, 43);	//Shirt
						GiveStartItem(c, 0x04, 40);	//Robe
						GiveStartItem(c, 0x07, 45);	//Boots
						break;
					case RACE.NIGHTELF:
						GiveStartItem(c, 0x03, 43);	//Shirt
						GiveStartItem(c, 0x04, 42);	//Robe
						GiveStartItem(c, 0x07, 45);	//Boots
						break;

					case RACE.TAUREN:
					case RACE.ORC:
					case RACE.TROLL:
					case RACE.UNDEAD:
						GiveStartItem(c, 0x03, 43);	//Shirt
						GiveStartItem(c, 0x04, 41);	//Robe
						GiveStartItem(c, 0x06, 44);	//Pants
						break;
				}	
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED PRIEST
					break;

				case CLASS.MAGE:
					c.PowerType = POWERTYPE.MANA;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 3;
					c.Spirit += 3;					

					//NEWBIE ITENS DATABASE FOR MAGE
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 4);	//Bent Staff
					GiveStartItem(c, 0x03, 31);	//Shirt
					GiveStartItem(c, 0x06, 32);	//Pants
					GiveStartItem(c, 0x07, 33);	//Boots

				switch((RACE)c.Race)
				{
					case RACE.DWARF:
						GiveStartItem(c, 0x04, 30);	//Robe
						break;
					case RACE.GNOME:
					case RACE.HUMAN:
					case RACE.NIGHTELF:
						GiveStartItem(c, 0x04, 28);	//Robe
						break;

					case RACE.TAUREN:
					case RACE.ORC:
					case RACE.TROLL:
					case RACE.UNDEAD:
						GiveStartItem(c, 0x04, 29);	//Robe
						break;
				}					
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					break;
			
				case CLASS.WARLOCK:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 2;
					c.Spirit += 2;					

					//NEWBIE ITENS DATABASE FOR WARLOCK
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 3);	//Bent Staff
					GiveStartItem(c, 0x06, 49);	//Pants
					GiveStartItem(c, 0x07, 50);	//Boots

				switch((RACE)c.Race)
				{
					case RACE.DWARF:
					case RACE.GNOME:
					case RACE.HUMAN:
					case RACE.NIGHTELF:

						GiveStartItem(c, 0x03, 48);	//Shirt
						GiveStartItem(c, 0x04, 46);	//Robe
						break;

					case RACE.TAUREN:
					case RACE.ORC:
					case RACE.TROLL:
					case RACE.UNDEAD:
						GiveStartItem(c, 0x04, 47);	//Robe
						break;
				}										
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED WARLOCK
					break;

				case CLASS.HUNTER:
					c.PowerType = POWERTYPE.FOCUS;

					//NEWBIE ITENS DATABASE FOR HUNTER
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 8);	//Bent Staff

				switch((RACE)c.Race)
				{
					case RACE.DWARF:
					case RACE.GNOME:
					case RACE.HUMAN:
					case RACE.NIGHTELF:
						GiveStartItem(c, 0x03, 54);	//Shirt
						GiveStartItem(c, 0x06, 55);	//Pants
						GiveStartItem(c, 0x07, 56);	//Boots
						break;

					case RACE.TAUREN:
					case RACE.UNDEAD:
					case RACE.ORC:
						GiveStartItem(c, 0x03, 51);	//Shirt
						GiveStartItem(c, 0x06, 52);	//Pants
						GiveStartItem(c, 0x07, 53);	//Boots
						break;

					case RACE.TROLL:
						GiveStartItem(c, 0x03, 57);	//Shirt
						GiveStartItem(c, 0x06, 58);	//Pants
						break;

				}
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					break;
				
				case CLASS.SHAMAN:
					c.PowerType = POWERTYPE.FOCUS;
					c.BaseStrength += 1;
					c.Strength += 1;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 1;
					c.Spirit += 1;					

					//NEWBIE ITENS DATABASE FOR SHAMAN
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x0F, 7);	//Bent Staff
				switch((RACE)c.Race)
				{
					case RACE.TAUREN:
					case RACE.ORC:
						GiveStartItem(c, 0x03, 59);	//Shirt
						GiveStartItem(c, 0x06, 60);	//Pants
						break;

					case RACE.TROLL:
						GiveStartItem(c, 0x03, 61);	//Shirt
						GiveStartItem(c, 0x06, 62);	//Pants
						break;
				}
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);

					//FINISHED
					break;
					
				case CLASS.DRUID:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStrength += 1;
					c.Strength += 1;
					c.BaseAgility += 1;
					c.Agility += 1;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 1;
					c.Intellect += 1;					
					c.BaseSpirit += 1;
					c.Spirit += 1;					

					//NEWBIE ITENS DATABASE FOR DRUID
					DataServer.Database.AddNewObject(c);

					GiveStartItem(c, 0x03, 5);	//Shirt
					GiveStartItem(c, 0x06, 65);	//Pants
					
				switch((RACE)c.Race)
				{
					case RACE.NIGHTELF:

						GiveStartItem(c, 0x0F, 9);	//Staff
						GiveStartItem(c, 0x04, 63);	//Robe
						break;

					case RACE.TAUREN:

						GiveStartItem(c, 0x0F, 4);	//Shirt
						GiveStartItem(c, 0x04, 64);	//Pants
						break;
				}

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED
					break;
			}
			#endregion
	
			#region AdorycitemDB
			/*
			switch((CLASS)c.Class)
			{
				case CLASS.WARRIOR:
					c.PowerType = POWERTYPE.RAGE;
					c.BaseStrength += 3;
					c.Strength += 3;					
					c.BaseStamina += 2;
					c.Stamina += 2;
					//NEWBIE ITENS DATABASE FOR WARRIORS
					DataServer.Database.AddNewObject(c);
					
					//Worn Shortsword
					DBItemTemplate templateWarriorWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)25);
					DBItem ItemWarriorWeapon = new DBItem();
					ItemWarriorWeapon.TemplateID = templateWarriorWeapon.ObjectId;
					ItemWarriorWeapon.OwnerID = c.ObjectId;
					ItemWarriorWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemWarriorWeapon);
					DataServer.Database.FillObjectRelations(ItemWarriorWeapon);
								
					// Worn Wooden Shield 
					DBItemTemplate templateWarriorShield = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)2362);
					DBItem itemWarriorShield = new DBItem();
					itemWarriorShield.TemplateID = templateWarriorShield.ObjectId;
					itemWarriorShield.OwnerID = c.ObjectId;
					itemWarriorShield.OwnerSlot = 0x10;
					DataServer.Database.AddNewObject(itemWarriorShield);
					DataServer.Database.FillObjectRelations(itemWarriorShield);
					
					//Recruit's Shirt
					DBItemTemplate templateWarriorCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)38);
					DBItem itemWarriorCloth = new DBItem();
					itemWarriorCloth.TemplateID = templateWarriorCloth.ObjectId;
					itemWarriorCloth.OwnerID = c.ObjectId;
					itemWarriorCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemWarriorCloth);
					DataServer.Database.FillObjectRelations(itemWarriorCloth);
													
					//Recruit's Pants
					DBItemTemplate templateWarriorPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)39);
					DBItem itemWarriorPants = new DBItem();
					itemWarriorPants.TemplateID = templateWarriorPants.ObjectId;
					itemWarriorPants.OwnerID = c.ObjectId;
					itemWarriorPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemWarriorPants);
					DataServer.Database.FillObjectRelations(itemWarriorPants);
					
					//Recruit's Boots
					DBItemTemplate templateWarriorBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)40);
					DBItem itemWarriorBoots = new DBItem();
					itemWarriorBoots.TemplateID = templateWarriorBoots.ObjectId;
					itemWarriorBoots.OwnerID = c.ObjectId;
					itemWarriorBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemWarriorBoots);
					DataServer.Database.FillObjectRelations(itemWarriorBoots);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED WARRIOR EQUIP
					break;
				
				case CLASS.PALADIN:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStrength += 2;
					c.Strength += 2;					
					c.BaseStamina += 2;
					c.Stamina += 2;					
					c.BaseSpirit += 1;
					c.Spirit += 1;

					//NEWBIE ITENS DATABASE FOR PALADIN
					DataServer.Database.AddNewObject(c);

					//Battleworn Hammer
					DBItemTemplate templatePaladinWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)2361);
					DBItem ItemPaladinWeapon = new DBItem();
					ItemPaladinWeapon.TemplateID = templatePaladinWeapon.ObjectId;
					ItemPaladinWeapon.OwnerID = c.ObjectId;
					ItemPaladinWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemPaladinWeapon);
					DataServer.Database.FillObjectRelations(ItemPaladinWeapon);

					//Squire's Shirt
					DBItemTemplate templateDPaladinCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)45);
					DBItem itemDPaladinCloth = new DBItem();
					itemDPaladinCloth.TemplateID = templateDPaladinCloth.ObjectId;
					itemDPaladinCloth.OwnerID = c.ObjectId;
					itemDPaladinCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemDPaladinCloth);
					DataServer.Database.FillObjectRelations(itemDPaladinCloth);
				
					//Squire's Pants
					DBItemTemplate templateDPaladinPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)44);
					DBItem itemDPaladinPants = new DBItem();
					itemDPaladinPants.TemplateID = templateDPaladinPants.ObjectId;
					itemDPaladinPants.OwnerID = c.ObjectId;
					itemDPaladinPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemDPaladinPants);
					DataServer.Database.FillObjectRelations(itemDPaladinPants);

					//Squire's Boots
					DBItemTemplate templateDPaladinBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)43);
					DBItem itemDPaladinBoots = new DBItem();
					itemDPaladinBoots.TemplateID = templateDPaladinBoots.ObjectId;
					itemDPaladinBoots.OwnerID = c.ObjectId;
					itemDPaladinBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemDPaladinBoots);
					DataServer.Database.FillObjectRelations(itemDPaladinBoots);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED PALADIN
					break;

				case CLASS.ROGUE:
					c.PowerType = POWERTYPE.ENERGY;
					c.BaseStrength += 1;
					c.Strength += 1;					
					c.BaseAgility += 3;
					c.Agility += 3;					
					c.BaseStamina += 1;
					c.Stamina += 1;

					//NEWBIE ITENS DATABASE FOR ROGUE
					DataServer.Database.AddNewObject(c);

					//Worn Dagger
					DBItemTemplate templateRogueWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)2092);
					DBItem ItemRogueWeapon = new DBItem();
					ItemRogueWeapon.TemplateID = templateRogueWeapon.ObjectId;
					ItemRogueWeapon.OwnerID = c.ObjectId;
					ItemRogueWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemRogueWeapon);
					DataServer.Database.FillObjectRelations(ItemRogueWeapon);

					//Footpad's Shirt
					DBItemTemplate templateRogueCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)49);
					DBItem itemRogueCloth = new DBItem();
					itemRogueCloth.TemplateID = templateRogueCloth.ObjectId;
					itemRogueCloth.OwnerID = c.ObjectId;
					itemRogueCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemRogueCloth);
					DataServer.Database.FillObjectRelations(itemRogueCloth);
								
					//Footpad's Pants
					DBItemTemplate templateRoguePants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)48);
					DBItem itemRoguePants = new DBItem();
					itemRoguePants.TemplateID = templateRoguePants.ObjectId;
					itemRoguePants.OwnerID = c.ObjectId;
					itemRoguePants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemRoguePants);
					DataServer.Database.FillObjectRelations(itemRoguePants);
				
					//Footpad's Shoes
					DBItemTemplate templateRogueBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)47);
					DBItem itemRogueBoots = new DBItem();
					itemRogueBoots.TemplateID = templateRogueBoots.ObjectId;
					itemRogueBoots.OwnerID = c.ObjectId;
					itemRogueBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemRogueBoots);
					DataServer.Database.FillObjectRelations(itemRogueBoots);						
					
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED ROUGE
					break;

				case CLASS.PRIEST:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 2;
					c.Spirit += 2;					

					//NEWBIE ITENS DATABASE FOR PRIEST
					DataServer.Database.AddNewObject(c);

					//Worn Mace
					DBItemTemplate templatePriestWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)36);
					DBItem ItemPriestWeapon = new DBItem();
					ItemPriestWeapon.TemplateID = templatePriestWeapon.ObjectId;
					ItemPriestWeapon.OwnerID = c.ObjectId;
					ItemPriestWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemPriestWeapon);
					DataServer.Database.FillObjectRelations(ItemPriestWeapon);
					
					//Neophyte's Shirt
					DBItemTemplate templatePriestCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)53);
					DBItem itemPriestCloth = new DBItem();
					itemPriestCloth.TemplateID = templatePriestCloth.ObjectId;
					itemPriestCloth.OwnerID = c.ObjectId;
					itemPriestCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemPriestCloth);
					DataServer.Database.FillObjectRelations(itemPriestCloth);
				
					//Neophyte's Robe
					DBItemTemplate templatePriestRobe = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6119);
					DBItem itemPriestRobe = new DBItem();
					itemPriestRobe.TemplateID = templatePriestRobe.ObjectId;
					itemPriestRobe.OwnerID = c.ObjectId;
					itemPriestRobe.OwnerSlot = 0x04;
					DataServer.Database.AddNewObject(itemPriestRobe);
					DataServer.Database.FillObjectRelations(itemPriestRobe);

					//Neophyte's Pants
					DBItemTemplate templatePriestPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)52);
					DBItem itemPriestPants = new DBItem();
					itemPriestPants.TemplateID = templatePriestPants.ObjectId;
					itemPriestPants.OwnerID = c.ObjectId;
					itemPriestPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemPriestPants);
					DataServer.Database.FillObjectRelations(itemPriestPants);

					//Neophyte's Boots
					DBItemTemplate templatePriestBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)51);
					DBItem itemPriestBoots = new DBItem();
					itemPriestBoots.TemplateID = templatePriestBoots.ObjectId;
					itemPriestBoots.OwnerID = c.ObjectId;
					itemPriestBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemPriestBoots);
					DataServer.Database.FillObjectRelations(itemPriestBoots);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					
					//FINISHED PRIEST
					break;

				case CLASS.MAGE:
					c.PowerType = POWERTYPE.MANA;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 3;
					c.Spirit += 3;					

					//NEWBIE ITENS DATABASE FOR MAGE
					DataServer.Database.AddNewObject(c);
					
					//Bent Staff
					DBItemTemplate templateMageWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)35);
					DBItem ItemMageWeapon = new DBItem();
					ItemMageWeapon.TemplateID = templateMageWeapon.ObjectId;
					ItemMageWeapon.OwnerID = c.ObjectId;
					ItemMageWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemMageWeapon);
					DataServer.Database.FillObjectRelations(ItemMageWeapon);
					
					//Apprentice's Shirt
					DBItemTemplate templateMageCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6096);
					DBItem itemMageCloth = new DBItem();
					itemMageCloth.TemplateID = templateMageCloth.ObjectId;
					itemMageCloth.OwnerID = c.ObjectId;
					itemMageCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemMageCloth);
					DataServer.Database.FillObjectRelations(itemMageCloth);

					//Apprentice's Robe
					DBItemTemplate templateMageRobe = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)56);
					DBItem itemMageRobe = new DBItem();
					itemMageRobe.TemplateID = templateMageRobe.ObjectId;
					itemMageRobe.OwnerID = c.ObjectId;
					itemMageRobe.OwnerSlot = 0x04;
					DataServer.Database.AddNewObject(itemMageRobe);
					DataServer.Database.FillObjectRelations(itemMageRobe);
									
					//Apprentice's Pants
					DBItemTemplate templateMagePants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)1395);
					DBItem itemMagePants = new DBItem();
					itemMagePants.TemplateID = templateMagePants.ObjectId;
					itemMagePants.OwnerID = c.ObjectId;
					itemMagePants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemMagePants);
					DataServer.Database.FillObjectRelations(itemMagePants);

					//Apprentice's Boots
					DBItemTemplate templateMageBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)55);
					DBItem itemMageBoots = new DBItem();
					itemMageBoots.TemplateID = templateMageBoots.ObjectId;
					itemMageBoots.OwnerID = c.ObjectId;
					itemMageBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemMageBoots);
					DataServer.Database.FillObjectRelations(itemMageBoots);
					
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					break;

				case CLASS.WARLOCK:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 2;
					c.Spirit += 2;					

					//NEWBIE ITENS DATABASE FOR WARLOCK
					DataServer.Database.AddNewObject(c);

					//Worn Dagger
					DBItemTemplate templateWarlockWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)2092);
					DBItem ItemWarlockWeapon = new DBItem();
					ItemWarlockWeapon.TemplateID = templateWarlockWeapon.ObjectId;
					ItemWarlockWeapon.OwnerID = c.ObjectId;
					ItemWarlockWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemWarlockWeapon);
					DataServer.Database.FillObjectRelations(ItemWarlockWeapon);
									
					//Acolyte's Shirt
					DBItemTemplate templateWarlockCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6097);
					DBItem itemWarlockCloth = new DBItem();
					itemWarlockCloth.TemplateID = templateWarlockCloth.ObjectId;
					itemWarlockCloth.OwnerID = c.ObjectId;
					itemWarlockCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemWarlockCloth);
					DataServer.Database.FillObjectRelations(itemWarlockCloth);

					//Acolyte's Robe
					DBItemTemplate templateWarlockRobe = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6129);
					DBItem itemWarlockRobe = new DBItem();
					itemWarlockRobe.TemplateID = templateWarlockRobe.ObjectId;
					itemWarlockRobe.OwnerID = c.ObjectId;
					itemWarlockRobe.OwnerSlot = 0x04;
					DataServer.Database.AddNewObject(itemWarlockRobe);
					DataServer.Database.FillObjectRelations(itemWarlockRobe);

					//Acolyte's Pants 
					DBItemTemplate templateGGWarlockPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)1396);
					DBItem itemGGWarlockPants = new DBItem();
					itemGGWarlockPants.TemplateID = templateGGWarlockPants.ObjectId;
					itemGGWarlockPants.OwnerID = c.ObjectId;
					itemGGWarlockPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemGGWarlockPants);
					DataServer.Database.FillObjectRelations(itemGGWarlockPants);

					//Acolyte's Shoes
					DBItemTemplate templateWarlockBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)59);
					DBItem itemWarlockBoots = new DBItem();
					itemWarlockBoots.TemplateID = templateWarlockBoots.ObjectId;
					itemWarlockBoots.OwnerID = c.ObjectId;
					itemWarlockBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemWarlockBoots);
					DataServer.Database.FillObjectRelations(itemWarlockBoots);
										
					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED WARLOCK
					break;

				case CLASS.HUNTER:
					c.PowerType = POWERTYPE.FOCUS;

					//NEWBIE ITENS DATABASE FOR HUNTER
					DataServer.Database.AddNewObject(c);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					break;
				
				case CLASS.SHAMAN:
					c.PowerType = POWERTYPE.FOCUS;
					c.BaseStrength += 1;
					c.Strength += 1;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 2;
					c.Intellect += 2;					
					c.BaseSpirit += 1;
					c.Spirit += 1;					

					//NEWBIE ITENS DATABASE FOR SHAMAN
					DataServer.Database.AddNewObject(c);

					//Worn Mace
					DBItemTemplate templateShamanWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)36);
					DBItem ItemShamanWeapon = new DBItem();
					ItemShamanWeapon.TemplateID = templateShamanWeapon.ObjectId;
					ItemShamanWeapon.OwnerID = c.ObjectId;
					ItemShamanWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemShamanWeapon);
					DataServer.Database.FillObjectRelations(ItemShamanWeapon);

					//Neophyte's Shirt
					DBItemTemplate templateShamanCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)53);
					DBItem itemShamanCloth = new DBItem();
					itemShamanCloth.TemplateID = templateShamanCloth.ObjectId;
					itemShamanCloth.OwnerID = c.ObjectId;
					itemShamanCloth.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemShamanCloth);
					DataServer.Database.FillObjectRelations(itemShamanCloth);
								
					//Neophyte's Robe
					DBItemTemplate templateShamanRobe = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6119);
					DBItem itemShamanRobe = new DBItem();
					itemShamanRobe.TemplateID = templateShamanRobe.ObjectId;
					itemShamanRobe.OwnerID = c.ObjectId;
					itemShamanRobe.OwnerSlot = 0x04;
					DataServer.Database.AddNewObject(itemShamanRobe);
					DataServer.Database.FillObjectRelations(itemShamanRobe);

					//Neophyte's Pants
					DBItemTemplate templateShamanPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)52);
					DBItem itemShamanPants = new DBItem();
					itemShamanPants.TemplateID = templateShamanPants.ObjectId;
					itemShamanPants.OwnerID = c.ObjectId;
					itemShamanPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemShamanPants);
					DataServer.Database.FillObjectRelations(itemShamanPants);

					//Neophyte's Boots
					DBItemTemplate templateShamanBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)51);
					DBItem itemShamanBoots = new DBItem();
					itemShamanBoots.TemplateID = templateShamanBoots.ObjectId;
					itemShamanBoots.OwnerID = c.ObjectId;
					itemShamanBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemShamanBoots);
					DataServer.Database.FillObjectRelations(itemShamanBoots);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);

					//FINISHED
					break;
					
				case CLASS.DRUID:
					c.PowerType = POWERTYPE.MANA;
					c.BaseStrength += 1;
					c.Strength += 1;
					c.BaseAgility += 1;
					c.Agility += 1;
					c.BaseStamina += 1;
					c.Stamina += 1;
					c.BaseIntellect += 1;
					c.Intellect += 1;					
					c.BaseSpirit += 1;
					c.Spirit += 1;					

					//NEWBIE ITENS DATABASE FOR DRUID
					DataServer.Database.AddNewObject(c);
					
					//Bent Staff
					DBItemTemplate templateDruidWeapon = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)35);
					DBItem ItemDruidWeapon = new DBItem();
					ItemDruidWeapon.TemplateID = templateDruidWeapon.ObjectId;
					ItemDruidWeapon.OwnerID = c.ObjectId;
					ItemDruidWeapon.OwnerSlot = 0x0F;
					DataServer.Database.AddNewObject(ItemDruidWeapon);
					DataServer.Database.FillObjectRelations(ItemDruidWeapon);
				
					//Neophyte's Shirt
					DBItemTemplate templateDruidshirt = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)53);
					DBItem itemDruidshirt = new DBItem();
					itemDruidshirt.TemplateID = templateDruidshirt.ObjectId;
					itemDruidshirt.OwnerID = c.ObjectId;
					itemDruidshirt.OwnerSlot = 0x03;
					DataServer.Database.AddNewObject(itemDruidshirt);
					DataServer.Database.FillObjectRelations(itemDruidshirt);

					//Neophyte's Robe
					DBItemTemplate templateDruidCloth = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)6119);
					DBItem itemDruidCloth = new DBItem();
					itemDruidCloth.TemplateID = templateDruidCloth.ObjectId;
					itemDruidCloth.OwnerID = c.ObjectId;
					itemDruidCloth.OwnerSlot = 0x04;
					DataServer.Database.AddNewObject(itemDruidCloth);
					DataServer.Database.FillObjectRelations(itemDruidCloth);
				
					//Neophyte's Pants 
					DBItemTemplate templateDruidPants = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)52);
					DBItem itemDruidPants = new DBItem();
					itemDruidPants.TemplateID = templateDruidPants.ObjectId;
					itemDruidPants.OwnerID = c.ObjectId;
					itemDruidPants.OwnerSlot = 0x06;
					DataServer.Database.AddNewObject(itemDruidPants);
					DataServer.Database.FillObjectRelations(itemDruidPants);

					//Neophyte's Boots
					DBItemTemplate templateDruidBoots = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), (uint)51);
					DBItem itemDruidBoots = new DBItem();
					itemDruidBoots.TemplateID = templateDruidBoots.ObjectId;
					itemDruidBoots.OwnerID = c.ObjectId;
					itemDruidBoots.OwnerSlot = 0x07;
					DataServer.Database.AddNewObject(itemDruidBoots);
					DataServer.Database.FillObjectRelations(itemDruidBoots);

					DataServer.Database.FillObjectRelations(c);
					DataServer.Database.FillObjectRelations(client.Account);
					//FINISHED
					break;
			}
			*/
			#endregion


			w.Write((byte)0x2D);
			client.Send(w);
			return true;

		}
	
		public static void GiveStartItem(DBCharacter c, byte slot, uint templateID)
		{
			
			DBItemTemplate targetItem = (DBItemTemplate)DataServer.Database.FindObjectByKey(typeof(DBItemTemplate), templateID);
			if (targetItem==null) return;

			DBItem newItem = new DBItem();
			newItem.TemplateID = templateID;
			newItem.OwnerID = c.ObjectId;
			newItem.OwnerSlot = slot;  //should really put a check here to be sure the item is supposed to go in that slot.
			DataServer.Database.AddNewObject(newItem);
			DataServer.Database.FillObjectRelations(newItem);
			return;

		}
	}
}
