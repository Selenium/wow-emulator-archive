/*
 * Copyright (C) 2006 by !PiCaSsO!-Team
 */

using System;

namespace Database
{
    public class DataClass
    {
        public static Int32 NPC_Count = 14; //number of NPCs declarated
        public static Int32 Item_Count = 3; //number of Items declarated
        public static Int32 GameObject_Count = 0; //number of Gameobjects declarated
        public static Int32 Spell_Count = 0; //number of Spells declarated
        public struct NPCs
        {
            public string name;            //It's name
            public string guild;           //It's guild
            public Int32 ID;               //It's ID
            public Int32 faction;          //It's faction
            public Int32 family;           //Beast family
            public Int32 minLevel;         //Min level
            public Int32 maxLevel;         //Max level
            public Int32 minMoney;         //Min copper drop
            public Int32 maxMoney;         //Max copper drop
            public Int32 attackMin;        //Dunno
            public Int32 attackMax;        //Dunno
            public Double boundingRadius;  //How far away can you hit it
            public Double combatReach;     //How far will attack you
            public Int32 damageMin;        //Min attack damage of the mob
            public Int32 damageMax;        //Max attack damage of the mob
            public Int32 health;           //It's health
            public Int32 model;            //It's model
            public Double size;            //Size  1 = normal
            public Int32 type;             //Type of the NPC
            public Int32 mana;             //How many mana does it have
            public Double speed;           //Speed 1 = normal
        }
        public struct Items
        {
            public string name;           //Item's name
            public string description;    //Item's description
            public Int32 ID;              //Item's ID
            public Int32 itemclass;       //Item's class
            public Int32 durability;      //Item's durability
            public Int32 requiredlevel;   //Required level to use the item
            public Int32 quality;         //It's quality| 0 = Uncommon, 1 = Common, 2 = Green, 3 = Blue, 4 = Epic, 5 = Legendary, 6 = Artifact
            public Int32 buyprice;        //The price you can buy it from a vendor
            public Int32 sellprice;       //The price you can sell it to a cendor
            public Int32 bonding;         // 0 = No Bonding, 1 = Bind on Equipped, 2 = Bind of picked up, 3 = Soulbound(Quest rewards)
            public bool forWarrior;       //Warrior can use it
            public bool forPriest;        //Priest can use it
            public bool forPaladin;       //Paladin can use it
            public bool forShaman;        //Shaman can use it
            public bool forMage;          //Mage can use it
            public bool forHunter;        //Hunter can use it
            public bool forWarlock;       //Warlock can use it
            public bool forDruid;         //Druid can use it
            public bool forRogue;         //Rouge can use it
            public Int32 model;           //It's icon
            public Int32 level;           //It's level
            public bool forHuman;         //Human can use it
            public bool forDwarf;         //Dwarf can use it
            public bool forGnome;         //Gnome can use it
            public bool forNightElf;      //Night Elf can use it
            public bool forDraenei;       //Draenei can use it
            public bool forTroll;         //Troll can use it
            public bool forUndead;        //Undead can use it
            public bool forTauren;        //Tauren can use it
            public bool forOrc;           //Orc can use it
            public bool forBloodElf;      //Blood Elf can use it
            public Int32 stackcount;      //Noumber of the item that can be in 1 slot in the bag
            public Int32 maxcount;        //Noumber of the item that can be at your character
            public Int32 material;        //If the item starts a quest, the background page's material
            public Int32 pagetext;        //Page's Text
            public Int32 language;        //It's Language
        }
        public struct GameObjects
        {
            public string name;           //Name of Gameobject
            public string description;    //Description of Gameobject
            public Int32 model;           //Model of Gameobject
            public Int32 size;            //Size of Gameobject
            public Int32 type;            //Type of Gameobject
        }
        public struct Spells
        {
            public string name;           //Name of the Spell
            public string ID;             //ID of the Spell
            public string description;    //Description of the Spell
            public Int32 requiredspell;    //Required Spell to learn the Spell
            public Int32 rank;            //Rank of the Spell
        }
        public struct Quests
        {
            public Int32 ID;
            public string name;
            public string description;
            public Int32 requiredquest;
            public Int32 minLevel;
            public Int32 maxLevel;
            public string completion;
            public string details;
            public string incomplete;
            public Int32 reputation;
            public Int32 rewardxp;
            public Int32[] rewarditemids;
        } 
        public static NPCs[] NPC;
        public static GameObjects[] GO;
        public static Items[] Item;
        public static Spells[] Spell;
        public static Quests[] Quest; 

        public static void Declarations()
        {
            NPC = new NPCs[NPC_Count];
            GO = new GameObjects[GameObject_Count];
            Item = new Items[Item_Count];
            Spell = new Spells[Spell_Count];

            //Created by Blumster
            Item[0].name = "1 Gold";
            Item[0].description = "You get 1 Gold if you sell this.";
            Item[0].ID = 1;
            Item[0].level = 0;
            Item[0].model = 11766;
            Item[0].requiredlevel = 0;
            Item[0].sellprice = 10000;
            Item[0].stackcount = 5;
            Item[0].quality = 2;
            Item[0].buyprice = 30000;

            //Created by Blumster
            Item[1].name = "10 Gold";
            Item[1].description = "You get 10 Gold if you sell this.";
            Item[1].ID = 2;
            Item[1].level = 0;
            Item[1].model = 11766;
            Item[1].requiredlevel = 0;
            Item[1].sellprice = 100000;
            Item[1].stackcount = 5;
            Item[1].quality = 3;
            Item[1].buyprice = 300000;

            //Created by Blumster
            Item[2].name = "100 Gold";
            Item[2].description = "You get 100 Gold if you sell this.";
            Item[2].ID = 3;
            Item[2].level = 0;
            Item[2].model = 11766;
            Item[2].requiredlevel = 0;
            Item[2].sellprice = 1000000;
            Item[2].stackcount = 5;
            Item[2].quality = 4;
            Item[2].buyprice = 3000000;

            //Created by Blumster
            NPC[0].name = "Armored Scorpid";
            NPC[0].ID = 1;
            NPC[0].minLevel = 9;
            NPC[0].maxLevel = 10;
            NPC[0].size = 0.87;
            NPC[0].type = 1;
            //NPC[0].guild = "";
            NPC[0].faction = 413;
            NPC[0].family = 20;
            NPC[0].health = 213;
            NPC[0].mana = 0;
            NPC[0].minMoney = 0;
            NPC[0].maxMoney = 0;
            NPC[0].model = 2487;
            NPC[0].damageMax = 14;
            NPC[0].damageMin = 9;
            NPC[0].combatReach = 2.25;
            NPC[0].attackMax = 2101;
            NPC[0].attackMin = 1910;
            NPC[0].boundingRadius = 0.638;
            NPC[0].speed = 1;

            //Created by Blumster
            NPC[1].name = "Bloodtalon Scythemaw";
            NPC[1].ID = 2;
            NPC[1].minLevel = 9;
            NPC[1].maxLevel = 10;
            NPC[1].size = 0.7;
            NPC[1].type = 1;
            //NPC[1].guild = "";
            NPC[1].faction = 48;
            NPC[1].family = 11;
            NPC[1].health = 237;
            NPC[1].mana = 240;
            NPC[1].minMoney = 0;
            NPC[1].maxMoney = 0;
            NPC[1].model = 1959;
            NPC[1].damageMax = 15;
            NPC[1].damageMin = 11;
            NPC[1].combatReach = 2.25;
            NPC[1].attackMax = 2090;
            NPC[1].attackMin = 1900;
            NPC[1].boundingRadius = 1.127;
            NPC[1].speed = 0.68;

            //Created by Blumster
            NPC[2].name = "Corrupted Bloodtalon Scythemaw";
            NPC[2].ID = 3;
            NPC[2].minLevel = 10;
            NPC[2].maxLevel = 11;
            NPC[2].size = 0.7;
            NPC[2].type = 1;
            //NPC[2].guild = "";
            NPC[2].faction = 48;
            NPC[2].family = 11;
            NPC[2].health = 264;
            NPC[2].mana = 0;
            NPC[2].minMoney = 0;
            NPC[2].maxMoney = 0;
            NPC[2].model = 787;
            NPC[2].damageMax = 16;
            NPC[2].damageMin = 12;
            NPC[2].combatReach = 2.25;
            NPC[2].attackMax = 2079;
            NPC[2].attackMin = 1890;
            NPC[2].boundingRadius = 1.127;
            NPC[2].speed = 0.68;

            //Created by Blumster
            NPC[3].name = "Dustwind Harpy";
            NPC[3].ID = 4;
            NPC[3].minLevel = 7;
            NPC[3].maxLevel = 8;
            NPC[3].size = 0.85;
            NPC[3].type = 7;
            //NPC[3].guild = "";
            NPC[3].faction = 514;
            NPC[3].health = 213;
            NPC[3].mana = 220;
            NPC[3].minMoney = 7;
            NPC[3].maxMoney = 17;
            NPC[3].model = 3012;
            NPC[3].damageMax = 14;
            NPC[3].damageMin = 9;
            NPC[3].combatReach = 2.25;
            NPC[3].attackMax = 2101;
            NPC[3].attackMin = 1910;
            NPC[3].boundingRadius = 0.607;
            NPC[3].speed = 0.82;

            //Created by Blumster
            NPC[4].name = "Dustwind Pillanger";
            NPC[4].ID = 5;
            NPC[4].minLevel = 7;
            NPC[4].maxLevel = 8;
            NPC[4].size = 0.85;
            NPC[4].type = 7;
            //NPC[4].guild = "";
            NPC[4].faction = 514;
            NPC[4].health = 213;
            NPC[4].mana = 220;
            NPC[4].minMoney = 7;
            NPC[4].maxMoney = 17;
            NPC[4].model = 6814;
            NPC[4].damageMax = 14;
            NPC[4].damageMin = 9;
            NPC[4].combatReach = 2.25;
            NPC[4].attackMax = 2101;
            NPC[4].attackMin = 1910;
            NPC[4].boundingRadius = 0.607;
            NPC[4].speed = 0.82;

            //Created by Blumster
            NPC[5].name = "Dustwind Savage";
            NPC[5].ID = 6;
            NPC[5].minLevel = 10;
            NPC[5].maxLevel = 11;
            NPC[5].size = 0.85;
            NPC[5].type = 7;
            //NPC[5].guild = "";
            NPC[5].faction = 514;
            NPC[5].health = 213;
            NPC[5].mana = 220;
            NPC[5].minMoney = 10;
            NPC[5].maxMoney = 25;
            NPC[5].model = 2166;
            NPC[5].damageMax = 14;
            NPC[5].damageMin = 9;
            NPC[5].combatReach = 2.25;
            NPC[5].attackMax = 2101;
            NPC[5].attackMin = 1910;
            NPC[5].boundingRadius = 0.714;
            NPC[5].speed = 0.96;

            //Created by Blumster
            NPC[6].name = "Dustwind Storm Witch";
            NPC[6].ID = 7;
            NPC[6].minLevel = 10;
            NPC[6].maxLevel = 11;
            NPC[6].size = 0.85;
            NPC[6].type = 7;
            //NPC[6].guild = "";
            NPC[6].faction = 22;
            NPC[6].health = 349;
            NPC[6].mana = 0;
            NPC[6].minMoney = 10;
            NPC[6].maxMoney = 25;
            NPC[6].model = 6815;
            NPC[6].damageMax = 22;
            NPC[6].damageMin = 15;
            NPC[6].combatReach = 2.25;
            NPC[6].attackMax = 2046;
            NPC[6].attackMin = 1860;
            NPC[6].boundingRadius = 0.714;
            NPC[6].speed = 0.99;

            //Created by Blumster
            NPC[7].name = "Kolkar Drudge";
            NPC[7].ID = 8;
            NPC[7].minLevel = 6;
            NPC[7].maxLevel = 7;
            NPC[7].size = 0.85;
            NPC[7].type = 7;
            //NPC[7].guild = "";
            NPC[7].faction = 130;
            NPC[7].health = 213;
            NPC[7].mana = 220;
            NPC[7].minMoney = 6;
            NPC[7].maxMoney = 14;
            NPC[7].model = 9442;
            NPC[7].damageMax = 14;
            NPC[7].damageMin = 9;
            NPC[7].combatReach = 2.25;
            NPC[7].attackMax = 2101;
            NPC[7].attackMin = 1910;
            NPC[7].boundingRadius = 0.905;
            NPC[7].speed = 0.82;

            //Created by Blumster
            NPC[8].name = "Kolkar Outrunner";
            NPC[8].ID = 9;
            NPC[8].minLevel = 7;
            NPC[8].maxLevel = 8;
            NPC[8].size = 0.85;
            NPC[8].type = 7;
            //NPC[8].guild = "";
            NPC[8].faction = 130;
            NPC[8].health = 213;
            NPC[8].mana = 220;
            NPC[8].minMoney = 7;
            NPC[8].maxMoney = 17;
            NPC[8].model = 9443;
            NPC[8].damageMax = 14;
            NPC[8].damageMin = 9;
            NPC[8].combatReach = 2.25;
            NPC[8].attackMax = 2101;
            NPC[8].attackMin = 1910;
            NPC[8].boundingRadius = 0.446;
            NPC[8].speed = 0.82;

            //Created by Blumster
            NPC[9].name = "Durotar Tiger";
            NPC[9].ID = 10;
            NPC[9].minLevel = 7;
            NPC[9].maxLevel = 8;
            NPC[9].size = 0.85;
            NPC[9].type = 1;
            //NPC[9].guild = "";
            NPC[9].faction = 14;
            NPC[9].family = 2;
            NPC[9].health = 213;
            NPC[9].mana = 220;
            NPC[9].minMoney = 0;
            NPC[9].maxMoney = 0;
            NPC[9].model = 598;
            NPC[9].damageMax = 14;
            NPC[9].damageMin = 9;
            NPC[9].combatReach = 2.25;
            NPC[9].attackMax = 2101;
            NPC[9].attackMin = 1910;
            NPC[9].boundingRadius = 1.014;
            NPC[9].speed = 0.82;

            //Created by Blumster
            NPC[10].name = "Bloodtalon Taillasher";
            NPC[10].ID = 11;
            NPC[10].minLevel = 8;
            NPC[10].maxLevel = 9;
            NPC[10].size = 0.55;
            NPC[10].type = 1;
            //NPC[10].guild = "";
            NPC[10].faction = 48;
            NPC[10].family = 11;
            NPC[10].health = 213;
            NPC[10].mana = 220;
            NPC[10].minMoney = 0;
            NPC[10].maxMoney = 0;
            NPC[10].model = 1960;
            NPC[10].damageMax = 14;
            NPC[10].damageMin = 9;
            NPC[10].combatReach = 2.25;
            NPC[10].attackMax = 2101;
            NPC[10].attackMin = 1910;
            NPC[10].boundingRadius = 0.885;
            NPC[10].speed = 0.53;

            //Created by St.Jimmy, edited by Blumster
            NPC[11].name = "Bom'bay";
            NPC[11].ID = 12;
            NPC[11].minLevel = 8;
            NPC[11].maxLevel = 8;
            NPC[11].size = 0.85;
            NPC[11].type = 7;
            NPC[11].guild = "Witch Doctor in Training";
            NPC[11].faction = 126;
            NPC[11].health = 261;
            NPC[11].mana = 180;
            NPC[11].minMoney = 7;
            NPC[11].maxMoney = 17;
            NPC[11].model = 9911;
            NPC[11].damageMax = 14;
            NPC[11].damageMin = 9;
            NPC[11].combatReach = 2.25;
            NPC[11].attackMax = 2123;
            NPC[11].attackMin = 1930;
            NPC[11].boundingRadius = 0.306;
            NPC[11].speed = 0.95;

            //Created by Bramhawk
            NPC[12].name = "Burning Blade Thug";
            NPC[12].ID = 13;
            NPC[12].minLevel = 7;
            NPC[12].maxLevel = 9;
            NPC[12].type = 7;
            //NPC[12].guild = "";
            NPC[12].faction = 554;
            NPC[12].health = 213;
            NPC[12].mana = 0;
            NPC[12].minMoney = 7;
            NPC[12].maxMoney = 17;
            NPC[12].model = 4189;
            NPC[12].damageMax = 14;
            NPC[12].damageMin = 9;
            NPC[12].combatReach = 2.25;
            NPC[12].attackMax = 1910;
            NPC[12].attackMin = 2101;
            NPC[12].boundingRadius = 1.127;
            NPC[12].speed = 0.96; 
            NPC[13].name = "Clattering Scorpid"; 
            NPC[13].ID = 16; 
            NPC[13].minLevel = 8; 
            NPC[13].maxLevel = 12; 
            NPC[13].size = 0.85; 
            NPC[13].type = 1; 
            //NPC[13].guild = " 
            NPC[13].faction = 126; 
            NPC[13].family = 20; 
            NPC[13].health = 334; 
            NPC[13].mana = 220; 
            NPC[13].minMoney = 4000; 
            NPC[13].maxMoney = 4000; 
            NPC[13].model = 2486; 
            NPC[13].damageMax = 12; 
            NPC[13].damageMin = 8; 
            NPC[13].combatReach = 2.42; 
            NPC[13].attackMax = 2101;

            Server.ColoredConsole.ConsoleWriteWhiteWithOut("Loaded " + NPC_Count + " NPCs, " + Item_Count + " Items, " + GameObject_Count + " GameObjects and " + Spell_Count + " Spells!");
        }
    }
} 