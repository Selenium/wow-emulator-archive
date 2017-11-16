//Character Stuff
/////////////////////////////////////////////////
#include "Character.h"
#include "UpdateMask.h"
#include "NetworkInterface.h"
#include "Quest.h"
#include "Opcodes.h"
#include "WorldServer.h"
#include "Timer.h"
#include "math.h"
#include "../wowpython/version.h"
extern int startzone;

#define world WorldServer::getSingleton()

Character::Character ( ): Unit()
{ 
    m_objectType |= TYPE_PLAYER;
    m_objectTypeId = 4;
    m_afk = 0;
    m_curTarget[ 0 ] = m_curTarget[ 1 ] = 0;
    m_curSelection[ 0 ] = m_curSelection[ 1 ] = 0;
    m_updateValues[ OBJECT_FIELD_TYPE ] = m_objectType;
    m_lootGuid[1] = 0;
    m_lootGuid[0] = 0;
	memset(m_guildname, 0, 22);
    m_guildId = 0;
    m_petInfoId = 0;
    m_petLevel = 0;
    m_petFamilyId = 0;

    m_regenTimer = 0;
    m_attackTimer = 0;

	m_healingDuration = m_healingTimer = 0;
	m_replenish_field = 0;
	m_replenish_value = 0;

    memset(m_items, 0, 8*39);

    // Init inventory slots...should they be set to 0?  Better than not initializing them at all I guess
    for (int i = 0; i < 20; i++) {
        m_inventory[i].displayId = 0;
        m_inventory[i].itemType = 0;
    }

    m_lastHpRegen = 0;
    m_lastManaRegen = 0;

	m_corpseDelay = 10000;
    m_respawnDelay = 20000;

	m_stat0=0;
	m_stat1=0;
	m_stat2=0;
	m_stat3=0;
	m_stat4=0;
	stat0=0;
	stat1=0;
	stat2=0;
	stat3=0;
	stat4=0;
	
	uint32 m_health=0;
	uint32 m_mana=0;
	m_timeToSave = 0;
	m_lastSavedTime = 0;

}


Character::~Character ( ) 
{ 

}


//====================================================================
//	Create
//	params: p_newChar
//	desc:	data form client to create a new character
//====================================================================
void Character::Create( uint32 guidlow, wowWData& data )//( uint8 * data, uint16 length )
{
    int i=0;
    uint8 race,class_,gender,skin,face,hairStyle,hairColor,facialHair,outfitId;
    uint16 displayId=0;
    uint32 baseattacktime[2];

    // Stats
    uint32 rage=0;

    Unit::Create(guidlow);
    m_guid[1] = 0;

    for (i = 0; i < 39; i++) {
        m_items[i].guid = 0;
        m_items[i].itemid = 0;
    }

    // unpack data into member variables
    data >> (char *)m_name;
    data >> race >> class_ >> gender >> skin >> face;
    data >> hairStyle >> hairColor >> facialHair >> outfitId;

    //////////  Constant for everyone  ////////////////
    /* Starting Locs
    Human: 0, -8949.95, -132.493, 83.5312
    Orc: 1, -618.518, -4251.67, 38.718
    Dwarf: 0, -6240.32, 331.033, 382.758
    Night Elf: 1, 10311.3, 832.463, 1326.41
    Undead: 0, 1676.35, 1677.45, 121.67
    Tauren: 1, -2917.58, -257.98, 52.9968
    Gnome: See Dwarf
    Troll: See Orc
    */
    baseattacktime[0] = 2000;
    baseattacktime[1] = 2000;

	// Start Human Zone Swich
	if (startzone == 1)
	{
		m_mapId = 0;
        m_zoneId = 12;
        m_positionX = -8897.50f;
        m_positionY = -173.480f;
        m_positionZ = 81.5775f;
	}
	    m_stat0 = 20;
        m_stat1 = 20;
        m_stat2 = 20;
        m_stat3 = 20;
        m_stat4 = 20;
	// End Human Zone Swich

	if (race == 1)  // Human
    {
        m_mapId = 0;
        m_zoneId = 12;
        m_positionX = -8897.50f;
        m_positionY = -173.480f;
        m_positionZ = 81.5775f;
        m_stat0 = 20;
        m_stat1 = 20;
        m_stat2 = 20;
        m_stat3 = 20;
        m_stat4 = 20;
        displayId = 49 + gender;
    }
    else if (race == 2) // orc
    {
        if (startzone == 0)
		{
		m_mapId = 1;
        m_zoneId = 14;
        m_positionX = -618.518f;
        m_positionY = -4251.67f;
        m_positionZ = 38.718f;
		}
        m_stat0 = 23;
        m_stat1 = 17;
        m_stat2 = 22;
        m_stat3 = 17;
        m_stat4 = 21;
		displayId = 51 + gender;
    }
    else if (race == 3) // dwarf
    {
        if (startzone == 0)
		{
		m_mapId = 0;
        m_zoneId = 1;
        m_positionX = -6240.32f;
        m_positionY = 331.033f;
        m_positionZ = 382.758f;
		}
		m_stat0 = 22;
        m_stat1 = 17;
        m_stat2 = 23;
        m_stat3 = 19;
        m_stat4 = 19;
        displayId = 53 + gender;
    }
    else if (race == 4) // night elf
    {
        if (startzone == 0)
		{
		m_mapId = 1;
        m_zoneId = 141;
        m_positionX = 10311.3f;
        m_positionY = 832.463f;
        m_positionZ = 1326.41f;
        }
		m_stat0 = 16;
        m_stat1 = 25;
        m_stat2 = 19;
        m_stat3 = 20;
        m_stat4 = 20;
        displayId = 55 + gender;
    }
    else if (race == 5) // undead
    {
        if (startzone == 0)
		{
		m_mapId = 0;
        m_zoneId = 85;
        m_positionX = 1676.35f;
        m_positionY = 1677.45f;
        m_positionZ = 121.67f;
        }
		m_stat0 = 19;
        m_stat1 = 18;
        m_stat2 = 21;
        m_stat3 = 17;
        m_stat4 = 25;
        displayId = 57 + gender;
    }
    else if (race == 6) // tauren
    {
        if (startzone == 0)
		{
		m_mapId = 1;
        m_zoneId = 215;
        m_positionX = -2917.58f;
        m_positionY = -257.98f;
        m_positionZ = 52.9968f;
        }
		m_stat0 = 25;
        m_stat1 = 16;
        m_stat2 = 22;
        m_stat3 = 16;
        m_stat4 = 21;
        displayId = 59 + gender;
    }   
    else if (race == 7) // gnome
    {
        if (startzone == 0)
		{
		m_mapId = 0;
        m_zoneId = 1;
        m_positionX = -6240.32f;
        m_positionY = 331.033f;
        m_positionZ = 382.758f;
		}
        m_stat0 = 15;
        m_stat1 = 23;
        m_stat2 = 19;
        m_stat3 = 23;
        m_stat4 = 20;
        displayId = 1563 + gender;
    }
    else if (race == 8)     // troll
    {
        if (startzone == 0)
		{
		m_mapId = 1;
        m_zoneId = 14;
        m_positionX = -618.518f;
        m_positionY = -4251.67f;
        m_positionZ = 38.718f;
		}
        m_stat0 = 20;
        m_stat1 = 22;
        m_stat2 = 21;
        m_stat3 = 16;
        m_stat4 = 21;
        displayId = 1478 + gender;
    }
		/*// SiTWulf Testing Custom Skins for Player Names
		if ( strstr( m_name, "Wolf" ) )
		{
		displayId = 644;
		setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.70f);
		}
		// End of SiTWulf Testing Custom Skins for Player Names*/

/*
LEFT SIDE
Head		0
Neck		1
Shoulders	2
Back		14
Chest		4
Shirt		3
Tabard		18
Wrists		8

RIGHT SIDE
Hands		9
Waist		5
Legs		6
Feet		7
Finger A	10
Finger B	11
Trinket A	12
Trinket B	13

WIELDED
Main hand	15
Offhand		16
Ranged		17
/**/

// slot 19 is invalid.

    // Adjust stats and items based on class
    // Starting stats from: http://wowvault.ign.com/?dir=characters&content=stats
    // Starting items from: www.gotwow.net -- M!lksJake
    if (class_ == WARRIOR)    // warrior
    {
        //abilities
        addSpell(0x19CB, 1);   //attack
 //     addSpell(2457, 1);     //battle stance		Dont work so i removed them -balko
        addSpell(107, 1);      //block
 //     addSpell(78, 0);       //Strike (Rank 1)	Dont work so i removed them -balko
        addSpell(81, 1);       //dodge

	    world.m_hiItemGuid++;	 
        
        if (race == 1) // Human
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 60;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);      // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);      // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);      // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);   // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);     // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);   // Darnassian Bleu
        }
        else if (race == 2) // Orc
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 80;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);      // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);      // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);      // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);   // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);     // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);    // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
        else if (race == 3) // Dwarf
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 90;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);       // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);       // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);       // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);    // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);      // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
        else if (race == 4) // Night Elf
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 50;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 6120);     // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);       // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);       // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);    // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);      // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
        else if (race == 5) // Undead
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 70;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);       // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);       // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);       // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);    // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);      // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
        }
        else if (race == 6) // Tauren
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 80;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);      // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);      // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);      // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);   // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);     // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);    // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);   // tough hunk of bread
        }
        else if (race == 7) // Gnome
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 50;
			rage        = 35;;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);      // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);      // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);      // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);   // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);     // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);    // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);   // tough hunk of bread
        }
        else if (race == 8) // Troll
        {
			// +3 strength
			// +2 Stamina
			m_stat0 += 3;
			m_stat2 += 2;

			m_health      = 70;
			rage        = 35;
			//POWER TYPE: USES RAGE

			AddItemToSlot(3, world.m_hiItemGuid++, 38);      // recruit's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 39);      // recruit's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 40);      // recruit's boots
			AddItemToSlot(16, world.m_hiItemGuid++, 2362);   // worn wooden shield
			AddItemToSlot(15, world.m_hiItemGuid++, 25);     // worn short sword
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);    // tough jerky
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);   // tough hunk of bread
        }
    }
    else if (class_ == PALADIN)   // Paladin
    {
        //spells
        addSpell(679, 1);     //holy strike
        addSpell(635, 2);     //holy light
        //abilities
        addSpell(0x19CB, 0);  //attack
        addSpell(107, 0);     //block
        //addSpell(81, 0);      //dodge

        world.m_hiItemGuid++;	

        if (race == 1) // Human
        {
			// +2 Strenght
			// +2 Stamina
			// +1 Spirit
			m_stat0 += 2;
			m_stat2 += 2;
			m_stat4 += 1;

			m_health      = 58;
			m_mana        = 84;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES MANA

			AddItemToSlot(3, world.m_hiItemGuid++, 45);       // squire's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 44);       // squire's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 43);       // squire's boots
			AddItemToSlot(15, world.m_hiItemGuid++, 2361);    // battleworn hammer
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
        }
        else if (race == 3) // Dwarfs
        {
			// +2 Strenght
			// +2 Stamina
			// +1 Spirit
			m_stat0 += 2;
			m_stat2 += 2;
			m_stat4 += 1;
        
			m_health      = 85;
			m_mana        = 83;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES MANA

			AddItemToSlot(3, world.m_hiItemGuid++, 45);       // squire's shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 44);       // squire's pants
			AddItemToSlot(7, world.m_hiItemGuid++, 43);       // squire's boots
			AddItemToSlot(15, world.m_hiItemGuid++, 2361);    // battleworn hammer
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
    }
    else if (class_ == HUNTER)   // Hunter
    {
        m_health      = 95;
        m_mana        = 0;

	    world.m_hiItemGuid++;	    
	    AddItemToSlot(3, world.m_hiItemGuid++, 38);       // recruit's shirt
        AddItemToSlot(6, world.m_hiItemGuid++, 39);       // recruit's pants
        AddItemToSlot(7, world.m_hiItemGuid++, 40);       // recruit's boots
        AddItemToSlot(16, world.m_hiItemGuid++, 2362);    // worn shield
        AddItemToSlot(15, world.m_hiItemGuid++, 2488);    // footman sword
        //AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
        //AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread

    }
    else if (class_ == ROGUE)   // Rogue
    {
        //abilities
        addSpell(0x19CB, 0); //attack
        //addSpell(1752, 1);      //sinister strike
       // addSpell(2764, 2);      //throw
        //addSpell(2098, 0);      //eviscrate
        //addSpell(81, 0);        //dodge
        
	    world.m_hiItemGuid++;	    

        if (race == 1) // Human
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 56;
			rage        = 84;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
        }
        else if (race == 2) // Orc
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 72;
			rage        = 83;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
        }
        else if (race == 3) // Dwarf
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 80;
			rage        = 84;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
        else if (race == 4) // Night Elf
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 48;
			rage        = 83;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
        }
        else if (race == 5) // Undead
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 64;
			rage        = 83;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: USES ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
        }
        else if (race == 7) // Gnome
        {
			// +2 Strenght
			m_stat0 += 2;
        
			m_health      = 48;
			rage        = 84;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
			//POWER TYPE: ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
			AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
			AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
        }
        else if (race == 8) // Troll
        {
			// +2 Strenght
			m_stat0 += 2;

			m_health      = 64;
			rage        = 83;
			baseattacktime[0] = 2900;
			baseattacktime[1] = 2000;
        //POWER TYPE: USES ENERGY

			AddItemToSlot(3, world.m_hiItemGuid++, 49);       // Footpad’s shirt
	        AddItemToSlot(6, world.m_hiItemGuid++, 48);       // Footpad’s Pants
	        AddItemToSlot(7, world.m_hiItemGuid++, 47);       // Footpad’s shoes
		    AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // Worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
        }

    }
    else if (class_ == PRIEST)   // Priest
    {
        //spells
        addSpell(585, 1); // holy smite 
        addSpell(2050, 2);       // lesser heal
        //abilities
        addSpell(0x19CB, 0); //attack
        //addSpell(5019, 0);       // shoot wands
        //addSpell(81, 0);         //dodge
        

        if (race == 1) // Human
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;

			m_health      = 52;
			m_mana        = 150;
			//POWER TYPE: USES MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 51);       // neophytes's boots
			AddItemToSlot(6, world.m_hiItemGuid++, 52);       // neophytes's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6098);     // neophyte's robe
			AddItemToSlot(3, world.m_hiItemGuid++, 53);       // neophyte's shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 8) // Troll
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;

			m_health      = 58;
			m_mana        = 128;
			//POWER TYPE: USES MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 51);       // neophytes's boots
			AddItemToSlot(6, world.m_hiItemGuid++, 52);       // neophytes's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6144);     // neophyte's robe
			AddItemToSlot(3, world.m_hiItemGuid++, 53);       // neophyte's shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 3) // Dwarf
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;

			m_health      = 76;
			m_mana        = 130;
			//POWER TYPE: USES MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 51);       // neophytes's boots
			AddItemToSlot(6, world.m_hiItemGuid++, 52);       // neophytes's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6098);     // neophyte's robe
			AddItemToSlot(3, world.m_hiItemGuid++, 53);       // neophyte's shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 4) // Night Elf
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;

			m_health      = 45;
			m_mana        = 160;
			//POWER TYPE: USES MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 51);       // neophytes's boots
			AddItemToSlot(6, world.m_hiItemGuid++, 52);       // neophytes's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6098);     // neophyte's robe
			AddItemToSlot(3, world.m_hiItemGuid++, 53);       // neophyte's shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 5) // Undead
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;

			m_health      = 58;
			m_mana        = 129;
			//POWER TYPE: USES MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 51);       // neophytes's boots
			AddItemToSlot(6, world.m_hiItemGuid++, 52);       // neophytes's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6144);     // neophyte's robe
			AddItemToSlot(3, world.m_hiItemGuid++, 53);       // neophyte's shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
        }
    }
    else if (class_ == SHAMAN)   // Shaman
    {
        //spells
        addSpell(403, 1);       // lightning bolt
        addSpell(331, 2);       // healing wave
        //abilities
        addSpell(0x19CB, 0);    //attack
        //addSpell(81, 0);        //dodge
        //addSpell(107, 0);       //block


	    world.m_hiItemGuid++;

        if (race == 2) // Orc
        {
			// +1 Strenght
			// +1 Stamina
			// +2 Intellect
			// +1 Spirit
			m_stat0 += 1;
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 1;

			m_health      = 72;
			m_mana        = 68;
			//POWER TYPE: MANA

//			AddItemToSlot(4, world.m_hiItemGuid++, 154);      // primitive mantel
//			AddItemToSlot(3, world.m_hiItemGuid++, 153);      // primitive kilt
            AddItemToSlot(4, world.m_hiItemGuid++, 6119);     // neophyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 6) // Tauren
        {
			// +1 Strenght
			// +1 Stamina
			// +2 Intellect
			// +1 Spirit
			m_stat0 += 1;
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 1;

			m_health      = 72;
			m_mana        = 67;
			//POWER TYPE: MANA

//			AddItemToSlot(4, world.m_hiItemGuid++, 154);      // primitive mantel
//			AddItemToSlot(3, world.m_hiItemGuid++, 153);      // primitive kilt
            AddItemToSlot(4, world.m_hiItemGuid++, 6119);     // neophyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 36);      // worn mace
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
		}
        else if (race == 8) // Troll
		{
			// +1 Strenght
			// +1 Stamina
			// +2 Intellect
			// +1 Spirit
			m_stat0 += 1;
			m_stat2 += 1;
			m_stat3 += 2; 
			m_stat4 += 1;
        
			m_health      = 64;
			m_mana        = 67;
			//POWER TYPE: MANA

			AddItemToSlot(4, world.m_hiItemGuid++, 154);      // primitive mantel
			AddItemToSlot(3, world.m_hiItemGuid++, 153);      // primitive kilt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
    }
    else if (class_ == MAGE)   // mage
    {
        //spells
        addSpell(0x0085, 1);    // firebolt
        //addSpell(168, 2);       // frost armor
        //abilities
        addSpell(0x19CB, 0);    //attack
        //addSpell(5019, 0);      //shoot wand
        //addSpell(81, 0);        //dodge


	    world.m_hiItemGuid++;	

        if (race == 1) //human
        {
			// +2 Intellect
			// +3 Spirit
			m_stat3 += 2;
			m_stat4 += 3;
          
			m_health      = 52;
			m_mana        = 150;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 55);       // Apprentice’s Boots
			AddItemToSlot(6, world.m_hiItemGuid++, 1395);     // Apprentice’s Pants
			AddItemToSlot(4, world.m_hiItemGuid++, 56);       // Apprentice’s Robe
			AddItemToSlot(3, world.m_hiItemGuid++, 6096);     // Apprentice’s Shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 8) // Troll
        {
			// +2 Intellect
			// +3 Spirit
			m_stat3 += 2;
			m_stat4 += 3;
         
			m_health      = 58;
			m_mana        = 128;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 55);       // Apprentice’s Boots
			AddItemToSlot(6, world.m_hiItemGuid++, 1395);     // Apprentice’s Pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6140);     // Apprentice’s Robe
			AddItemToSlot(3, world.m_hiItemGuid++, 6096);     // Apprentice’s Shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 3) // Dwarf
        {
			// +2 Intellect
			// +3 Spirit
			m_stat3 += 2;
			m_stat4 += 3;
         
			m_health      = 70;
			m_mana        = 140;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 55);       // Apprentice’s Boots
			AddItemToSlot(6, world.m_hiItemGuid++, 1395);     // Apprentice’s Pants
			AddItemToSlot(4, world.m_hiItemGuid++, 56);       // Apprentice’s Robe
			AddItemToSlot(3, world.m_hiItemGuid++, 6096);     // Apprentice’s Shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 5) // Undead
        {
			// +2 Intellect
			// +3 Spirit
			m_stat3 += 2;
			m_stat4 += 3;
         
			m_health      = 58;
			m_mana        = 129;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 55);       // Apprentice’s Boots
			AddItemToSlot(6, world.m_hiItemGuid++, 1395);     // Apprentice’s Pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6140);     // Apprentice’s Robe
			AddItemToSlot(3, world.m_hiItemGuid++, 6096);     // Apprentice’s Shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
        }
        else if (race == 7) // Gnome
        {
			// +2 Intellect
			// +3 Spirit
			m_stat3 += 2;
			m_stat4 += 3;
         
			m_health      = 51;
			m_mana        = 180;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 55);       // Apprentice’s Boots
			AddItemToSlot(6, world.m_hiItemGuid++, 1395);     // Apprentice’s Pants
			AddItemToSlot(4, world.m_hiItemGuid++, 56);       // Apprentice’s Robe
			AddItemToSlot(3, world.m_hiItemGuid++, 6096);     // Apprentice’s Shirt
			AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
        }
    }
    else if (class_ == WARLOCK)   // Warlock
    {
        //spells
        addSpell(686, 1);      //shadow bolt
        //addSpell(687, 2);      //demon skin
        //abilities
        addSpell(0x19CB, 0);   //attack
        //addSpell(5019, 0);     // shoot wands
        //addSpell(81, 0);       //dodge

	    world.m_hiItemGuid++;	

        if (race == 1) //human
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;
        
			m_health      = 54;
			m_mana        = 130;
			baseattacktime[0] = 1600;
			baseattacktime[1] = 2000;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 59);       // acolyte's shoes
			AddItemToSlot(6, world.m_hiItemGuid++, 1396);     // acolyte's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 57);       // acolyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(25, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 2070);    // Darnassian Bleu
        }
        else if (race == 2) // Orc
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;
        
			m_health      = 68;
			m_mana        = 109;
			baseattacktime[0] = 1600;
			baseattacktime[1] = 2000;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 59);       // acolyte's shoes
			AddItemToSlot(6, world.m_hiItemGuid++, 1396);     // acolyte's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6129);     // acolyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(25, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 7) // Gnome
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;
        
			m_health      = 47;
			m_mana        = 160;
			baseattacktime[0] = 1600;
			baseattacktime[1] = 2000;
			//POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 59);       // acolyte's shoes
			AddItemToSlot(6, world.m_hiItemGuid++, 1396);     // acolyte's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 57);       // acolyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);    // tough hunk of bread
			//AddItemToSlot(25, world.m_hiItemGuid++, 159);     // refreshing spring water
        }
        else if (race == 5) // Undead
        {
			// +1 Stamina
			// +2 Intellect
			// +2 Spirit
			m_stat2 += 1;
			m_stat3 += 2;
			m_stat4 += 2;
        
			m_health      = 61;
			m_mana        = 109;
			baseattacktime[0] = 1600;
			baseattacktime[1] = 2000;
        //POWER TYPE: MANA

			AddItemToSlot(7, world.m_hiItemGuid++, 59);       // acolyte's shoes
			AddItemToSlot(6, world.m_hiItemGuid++, 1396);     // acolyte's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6129);     // acolyte's robe
			AddItemToSlot(15, world.m_hiItemGuid++, 2092);    // worn dagger
			//AddItemToSlot(23, world.m_hiItemGuid++, 117);     // tough jerky
			//AddItemToSlot(25, world.m_hiItemGuid++, 159);     // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4604);    // forest mushroom cap
        }	    
    }
    else if (class_ == DRUID)  // druid
    {
        //spells
        addSpell(5176, 1);    // wrath
        addSpell(5185, 2);    // healing touch
        //addSpell(1126, 1);    // Mark of the Wild
        //abilities
        addSpell(0x19CB, 0);  //attack
        //addSpell(81, 0);      //dodge

	    world.m_hiItemGuid++;	    
		AddItemToSlot(15, world.m_hiItemGuid++, 35);      // bent staff
     
        if (race == 4) // Night Elf
        {
			// +1 Strenght
			// +1 Stamina
			// +1 Agility
			// +1 Intellect
			// +1 Spirit
			m_stat0 += 1;
			m_stat1 += 1;
			m_stat2 += 1;
			m_stat3 += 1;
			m_stat4 += 1;
        
			m_health      = 46;
			m_mana        = 105;
			//POWER TYPE: MANA
			//NOTE: USES RAGE IN BEAR FORM

//			AddItemToSlot(6, world.m_hiItemGuid++, 6124);    // Novice's pants
			AddItemToSlot(4, world.m_hiItemGuid++, 6123);    // Novice's Robe
//			AddItemToSlot(15, world.m_hiItemGuid++, 3661);   // Hand crafted staff
/*			AddItemToSlot(24, world.m_hiItemGuid++, 159);    // Refreshing spring water
			AddItemToSlot(23, world.m_hiItemGuid++, 4540);   // Tough hunk of bread*/
        }
		else if (race == 6) // Tauren
        {
			// +1 Strenght
			// +1 Stamina
			// +1 Agility
			// +1 Intellect
			// +1 Spirit
			m_stat0 += 1;
			m_stat1 += 1;
			m_stat2 += 1;
			m_stat3 += 1;
			m_stat4 += 1;
        
			m_health      = 68;
			m_mana        = 84;
			//POWER TYPE: MANA
			//NOTE: USES RAGE IN BEAR FORM

//			AddItemToSlot(6, world.m_hiItemGuid++, 6124);    // Novice's pants
//			AddItemToSlot(4, world.m_hiItemGuid++, 6139);    // Novice's Robe
//			AddItemToSlot(15, world.m_hiItemGuid++, 3661);   // bent staff
            AddItemToSlot(4, world.m_hiItemGuid++, 6119);     // neophyte's robe
			//AddItemToSlot(24, world.m_hiItemGuid++, 159);    // refreshing spring water
			//AddItemToSlot(23, world.m_hiItemGuid++, 4540);   // tough hunk of bread
        }     
    }
	
    // Set Starting stats for char
    setUpdateMaskBit(OBJECT_FIELD_GUID);          
    setUpdateMaskBit(OBJECT_FIELD_TYPE);
    //setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);         
    setUpdateValue(OBJECT_FIELD_PADDING, 0xeeeeeeee);        
    setUpdateValue(UNIT_FIELD_HEALTH, m_health);   
	if (rage)
		setUpdateValue(UNIT_FIELD_POWER1, 0 );        
	else
		setUpdateValue(UNIT_FIELD_POWER1, m_mana );        
    setUpdateValue(UNIT_FIELD_POWER2, 1000 );
    setUpdateValue(UNIT_FIELD_POWER3, 10 );        
    setUpdateValue(UNIT_FIELD_POWER4, 100 );
    setUpdateValue(UNIT_FIELD_POWER5, 0xeeeeeeee );        
    setUpdateValue(UNIT_FIELD_MAXHEALTH, m_health);
	if (rage)
	    setUpdateValue(UNIT_FIELD_MAXPOWER1, 0 );
	else
		setUpdateValue(UNIT_FIELD_MAXPOWER1, m_mana );
    setUpdateValue(UNIT_FIELD_MAXPOWER2, 1000 );
    setUpdateValue(UNIT_FIELD_MAXPOWER3, 10 );        
    setUpdateValue(UNIT_FIELD_MAXPOWER4, 100 );
    setUpdateValue(UNIT_FIELD_LEVEL, 1 );            
    setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE, 1 );
    setUpdateValue(UNIT_FIELD_BYTES_0, ( race ) + ( class_ << 8 ) + ( gender << 16 ) );          
    setUpdateValue(UNIT_FIELD_STAT0, m_stat0 );
    setUpdateValue(UNIT_FIELD_STAT1, m_stat1 );
    setUpdateValue(UNIT_FIELD_STAT2, m_stat2 );
    setUpdateValue(UNIT_FIELD_STAT3, m_stat3 );
    setUpdateValue(UNIT_FIELD_STAT4, m_stat4 );
	setUpdateValue(PLAYER_FIELD_POSSTAT0, 0  );        
    setUpdateValue(PLAYER_FIELD_POSSTAT1, 0 );
    setUpdateValue(PLAYER_FIELD_POSSTAT2, 0 );        
    setUpdateValue(PLAYER_FIELD_POSSTAT3, 0 );
    setUpdateValue(PLAYER_FIELD_POSSTAT4, 0 );        
    setUpdateValue(PLAYER_FIELD_NEGSTAT0, 0 );        
    setUpdateValue(PLAYER_FIELD_NEGSTAT1, 0 );
    setUpdateValue(PLAYER_FIELD_NEGSTAT2, 0 );        
    setUpdateValue(PLAYER_FIELD_NEGSTAT3, 0 );
    setUpdateValue(PLAYER_FIELD_NEGSTAT4, 0 );        
    setUpdateValue(PLAYER_FIELD_COINAGE, 0  );
    setUpdateValue(UNIT_FIELD_BASEATTACKTIME, baseattacktime[0] );   
    setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, baseattacktime[1]  );
    setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 0.388999998569489f );  
    setUpdateFloatValue(UNIT_FIELD_COMBATREACH, 1.5f   );
    setUpdateValue(UNIT_FIELD_DISPLAYID, displayId  );      
	setUpdateValue(UNIT_FIELD_NATIVEDISPLAYID, displayId ); 
    setUpdateValue(UNIT_FIELD_FLAGS, 0x00000008 );
    setUpdateValue(PLAYER_BYTES, ((uint32)skin) | ((uint32)face << 8) | ((uint32)hairStyle << 16) | (hairColor << 24));
    setUpdateValue(PLAYER_BYTES_2, (facialHair << 8) + (01 << 24) );
    setUpdateValue(PLAYER_XP, 0 );                 
    setUpdateValue(PLAYER_NEXT_LEVEL_XP, 400);
    setUpdateValue(PLAYER_REST_STATE_EXPERIENCE, 0 );
    setUpdateValue(PLAYER_CHARACTER_POINTS1, 0);
    setUpdateValue(UNIT_FIELD_AURALEVELS , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 1 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 2 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 3 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 4 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 5 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 6 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 7 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 8 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURALEVELS + 9 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 1 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 2 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 3 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 4 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 5 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 6 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 7 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 8 , 0xeeeeeeee);
    setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + 9 , 0xeeeeeeee);

		// SiTWulf Scale Races Fix
	if (race == 6)			// Taurent
		{
		setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.20f);
		}
    else if (race == 4)		// Night Elf
		{
		setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.85f);
		}
	else if (race == 8)     // Troll
		{
		setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.90f);
		}
	else
		{
		setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.00f);
		}	

	  //End SiTWulf Scale Races Fix
	  	  	  
	updateItemStats();

	// Init inventory slots...should they be set to 0?  Better than not initializing them at all I guess
    for (i = 0; i < 20; i++) {
        m_inventory[i].displayId = 0;
        m_inventory[i].itemType = 0;
    }

    // Not worrying about this stuff for now
    m_guildId = 0;
    m_petInfoId = 0;
    m_petLevel = 0;
    m_petFamilyId = 0;
}


// FvF
//void Character::Update( uint32 p_time )
void Character::Update( float p_time )
{
    if(m_regenTimer > 0)
    {
        if(p_time >= m_regenTimer)
            m_regenTimer = 0;
        else
            m_regenTimer -= p_time;
    }

    if(m_attackTimer > 0)
    {
        if(p_time >= m_attackTimer)
            m_attackTimer = 0;
        else
            m_attackTimer -= p_time;
    }

    if (m_state & UF_ATTACKING)
    {
        // In combat!
        if (isAttackReady())
        {
            Unit *pVictim = NULL;
            if (m_curSelection[1] == uint32(0)) 
            {   // player guid
                // player vs player not implemented

                // !! Bah, previously spawned creatures have guid[1] of 0
                if (world.mCreatures.find(m_curSelection[0]) != world.mCreatures.end()){
                    pVictim = world.mCreatures[m_curSelection[0]];
                }
            } 
            else if (m_curSelection[1] == 0xF0001000 || m_curSelection[1] == 0xF0003000)
            {   // monster
                if (world.mCreatures.find(m_curSelection[0]) != world.mCreatures.end()){
                    pVictim = world.mCreatures[m_curSelection[0]];
                }
            }

            if (!pVictim){
                printf("Character::Update:  No valid current selection to attack, stopping attack\n");
                clearStateFlag(UF_ATTACKING);
                world.mCombatHandler.smsg_AttackStop((Unit*)this, m_curSelection);
            }
            else
            {
                world.mCombatHandler.AttackerStateUpdate((Unit*)this, pVictim, 0);
                setAttackTimer();
            }
        }
    }
	//Hope it fixs the combat bug because if a attacker is out of range the attack will be
	//ignored and so any spells work because there is not creature id selection with mouse
	else if(m_state & !UF_ATTACKING)
	{
		if (isAttackReady())
        {
            Unit *pVictim = NULL;
            if (m_curSelection[1] == uint32(0)) 
            {   // player guid
                // player vs player not implemented

                // !! Bah, previously spawned creatures have guid[1] of 0
                if (world.mCreatures.find(m_curSelection[0]) != world.mCreatures.end()){
                    pVictim = world.mCreatures[m_curSelection[0]];
                }
            } 
            else if (m_curSelection[1] == 0xF0001000 || m_curSelection[1] == 0xF0003000)
            {   // monster
                if (world.mCreatures.find(m_curSelection[0]) != world.mCreatures.end()){
                    pVictim = world.mCreatures[m_curSelection[0]];
                }
            }

            if (!pVictim){
                printf("Character::Update:  No valid current selection to attack, stopping attack\n");
                clearStateFlag(UF_ATTACKING);
                world.mCombatHandler.smsg_AttackStop((Unit*)this, m_curSelection);
            }
			else
            {
                world.mCombatHandler.AttackerStateUpdate((Unit*)this, pVictim, 0);
                setAttackTimer();
            }
		}
	}
    // only regenerate if NOT in combat, and if alive
    if (isAlive() && !m_wport && !m_combat)
    {
        uint32 hp       = getUpdateValue(UNIT_FIELD_HEALTH);
        uint32 max_hp   = getUpdateValue(UNIT_FIELD_MAXHEALTH);

        uint32 mp       = getUpdateValue(UNIT_FIELD_POWER1);
        uint32 max_mp   = getUpdateValue(UNIT_FIELD_MAXPOWER1);

        // Regenerate health and mana if necessary
        hp = Regen(hp, max_hp, UNIT_FIELD_HEALTH, &m_lastHpRegen);
        mp = Regen(mp, max_mp, UNIT_FIELD_POWER1, &m_lastManaRegen);
    }
	else if (isAlive() && !m_wport && m_combat)
	{
		if  (getUpdateValue(UNIT_FIELD_MAXPOWER1) >0)
		{
		    uint32 mp       = getUpdateValue(UNIT_FIELD_POWER1);
	        uint32 max_mp   = getUpdateValue(UNIT_FIELD_MAXPOWER1);
	        mp = (Regen(mp, max_mp, UNIT_FIELD_POWER1, &m_lastManaRegen));
		}
	}
	// nothin changes start
	else if(m_healingDuration > 0) 
	{
		if(m_healingTimer > 0)
		{
			if(p_time >= m_healingTimer)
				m_healingTimer = 0;
			else
				m_healingTimer -= p_time;
		}
		if(m_healingTimer == 0)
		{
			if( getUpdateValue( m_replenish_field ) == getUpdateValue( m_replenish_field+6 && m_replenish_field == 20) )
			{
				wowWData data;
				data.clear();	
  				data.Initialise( 5, SMSG_CAST_RESULT );
  				data << m_spell << uint8( 0x02);
				data << uint8( 17 );
  				pClient->SendMsg( &data );
				printf("OK print message: You are too full to eat");
				m_healingDuration = 0;
			}
			else if( getUpdateValue( m_replenish_field ) == getUpdateValue( m_replenish_field+6 && m_replenish_field == 21) )
			{
				wowWData data;
				data.clear();	
  				data.Initialise( 5, SMSG_CAST_RESULT );
  				data << m_spell << uint8( 0x02);
				data << uint8( 17 );
  				pClient->SendMsg( &data );
				printf("OK print message: You can not drink any more yet");
				m_healingDuration = 0;
			}
			else
			{
				 m_healingDuration--;
				 m_healingTimer = 1000;
				 uint32 heal = getUpdateValue( m_replenish_field );
				 setUpdateValue( m_replenish_field, heal+m_replenish_value );
				 printf("Should heal here!\n");
			}
		}
	}
	/////////////////////////////////////////////////////////////////////
	////////////DAMAGE ABSORB TIMER - changed by nothin//////////////////
	if(m_absorbDuration > 0)
	{
		m_absorb = 1;
		if(m_absorbTimer > 0)
		{
			if(p_time >= m_absorbTimer)
				m_absorbTimer = 0;
			else
				m_absorbTimer -= p_time;
		}
		if(m_absorbTimer == 0)
		{
			m_absorbDuration--;
			m_absorbTimer = 1000;
			printf("Absorb Time: %u\n", m_absorbDuration);
		}
		if(m_absorbDuration == 0)
		{
			m_absorb = 0;
			printf("OK absorb time is up for now :(\n");
		}
	}


	////////////Aura TIMER - changed by nothin/////////////////////////////
	if(m_auraDuration > 0)
	{
		if(m_auraTimer > 0)
		{
			if(p_time >= m_auraTimer)
				m_auraTimer = 0;
			else
				m_auraTimer -= p_time;
		}
		if(m_auraTimer == 0)
		{
			m_auraDuration--;
			m_auraTimer = 1000;
			printf("Aura Time: %u\n", m_auraDuration);
		}
		if(m_auraDuration == 0)
		{
			setUpdateValue(UNIT_FIELD_AURALEVELS + m_aura_found, 0);
			setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + m_aura_found, 0);
			setUpdateValue(UNIT_FIELD_AURA + m_aura_found*4 + m_aura_found2, 0);
			printf("OK aura time is up for now Charhandler:(\n");
		}
	}
	///////////////////////////////////////////////////////////////////////

	////////////MANA SHIELD TIMER - changed by nothin//////////////////////
	if(m_shieldDuration > 0)
	{
		m_shield = 1;
		if(m_shieldTimer > 0)
		{
			if(p_time >= m_shieldTimer)
				m_shieldTimer = 0;
			else
				m_shieldTimer -= p_time;
		}
		if(m_shieldTimer == 0)
		{
			m_shieldDuration--;
			m_shieldTimer = 1000;
			printf("Shield Time: %u\n", m_shieldDuration);
		}
		if(m_shieldDuration == 0)
		{
			m_shield = 0;
			printf("OK shield time is up for now :(\n");
		}
	}
	///////////////////////////////////////////////////////////////////////


	//START OF LINA DEATH FIX
	if(m_deathState == JUST_DIED)
	{
		setUpdateValue( PLAYER_BYTES_2, 0x10 | getUpdateValue( PLAYER_BYTES_2 ) );
		setUpdateValue( UNIT_FIELD_FLAGS, 65536 | getUpdateValue( UNIT_FIELD_FLAGS ) );
        setDeathState(CORPSE);

		uint32 petGUID = getUpdateValue(UNIT_FIELD_SUMMON);

		if( petGUID != 0)
		{
			Unit* pet_caster = world.GetCreature(petGUID);
			if(pet_caster)
			{
				pet_caster->setDeathState(JUST_DIED);
				pet_caster->m_corpseDelay = 10000;
				pet_caster->m_respawnDelay = 30000;
			}
		}
		printf("Placing corpse...\n");
	}/*
	if(m_deathTimer > 0)
    {
        if(p_time >= m_deathTimer)
            m_deathTimer = 0;
        else
            m_deathTimer -= p_time;

        if (m_deathTimer <= 0)
        {
            m_respawnTimer = m_respawnDelay;
			setDeathState(ALIVE);
            printf("Removing corpse...\n");
        }
    }  
		else if (m_respawnTimer > 0)
    {
        if(p_time >= m_respawnTimer)
            m_respawnTimer = 0;
        else
            m_respawnTimer -= p_time;

        if(m_respawnTimer <= 0)
        {
            UpdateMask mask;
            wowWData data;
            WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(mask);
            uint32 max_health = getUpdateValue(UNIT_FIELD_MAXHEALTH);
            setUpdateValue(UNIT_FIELD_HEALTH, max_health);

			//maybe tale some xp away?
			//pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_FLAGS, 8 );
			setUpdateValue( UNIT_FIELD_FLAGS, (0xffffffff - 65536) & getUpdateValue( UNIT_FIELD_FLAGS ) );
			setUpdateValue( UNIT_FIELD_AURA +32, 0 );
			setUpdateValue( UNIT_FIELD_AURAFLAGS +4, 0 );
			setUpdateValue( UNIT_FIELD_AURASTATE, 0 );
			//pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, 16777984 );
			setUpdateValue( PLAYER_BYTES_2, (0xffffffff - 0x10) & pClient->getCurrentChar( )->getUpdateValue( PLAYER_BYTES_2 ) );
			//setDeathState(ALIVE);

			uint8 buf[256];

			uint32 xp = getUpdateValue(PLAYER_XP);
			uint32 xpt = (uint32)( 20 * (getLevel()/1.2));
			//uint32 xpt = (uint32)( 100 * getLevel() * (float) pow(getLevel(),1.2)); // Fixed float - Torg
			
			int32 newxp = xp - xpt;
			if(newxp < 0) 
			{
				sprintf((char*)buf,"You lose all of youre XP, be carefull.");
				setUpdateValue(PLAYER_XP, 0);
			}
			else 
			{
				sprintf((char*)buf,"You lose %u XP.", xpt);
				setUpdateValue(PLAYER_XP, newxp);
			}
			WorldServer::getSingleton().mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
			pClient->SendMsg( &data );
			printf("Take XP %i, so %i\n", xpt, newxp);
/*
			uint32 money = getUpdateValue(PLAYER_FIELD_COINAGE);
			uint32 moneyt = (uint32)(50 * (getLevel()/1.2));			
			//uint32 moneyt = (uint32)(100 * (float) pow(getLevel(),1.2)); // Fixed float - Torg
			
			int32 newmoney = money - moneyt;
			if(newmoney < 0) 
			{
				sprintf((char*)buf,"You lose all of youre coppers, be carefull.");
				setUpdateValue(PLAYER_FIELD_COINAGE, 0);
			}
			else 
			{
				sprintf((char*)buf,"You lose %u coppers.", moneyt);
				setUpdateValue(PLAYER_FIELD_COINAGE, newmoney);
			}
			WorldServer::getSingleton().mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
			pClient->SendMsg( &data );
			printf("Take Gold %i, so %i\n", moneyt, newmoney);

            printf("Respawning...\n");
        }
    }  
	//END OF LINA DEATH FIX*/
	//LeMMiNGS Auto Save each 5min
	if (m_timeToSave == 0) m_timeToSave = (uint32)time(NULL)+300;
	if ((uint32)time(NULL) > m_timeToSave) {
		m_timeToSave += 300;
		if  (pClient->IsInWorld()) {
			pClient->getDB()->setCharacter( pClient->getCurrentChar( ) );
			pClient->getCurrentChar()->setLastSavedTime((uint32)time(NULL));
			wowWData data;
			ChatHandler pChat;
			pChat.FillMessageData(&data, 0x09, pClient, (uint8*)"Character auto-saved");
			pClient->SendMsg( &data );
		}
	}
	if (((uint32)time(NULL) > m_taxi) && m_taxi) { //taxi dismount on destination by LeMMiNGS
		m_taxi = 0;
	    pClient->getCurrentChar( )->setUpdateValue(UNIT_FIELD_MOUNTDISPLAYID , 0);
		pClient->getCurrentChar( )->removeUnitFlag( 0x003000 );
		pClient->getCurrentChar( )->removeUnitFlag( 0x000004 );
		world.CheckForInRangeObjects(pClient->getCurrentChar()); //fix for sometimes range objects not showing.. (havent tested so much .. was fixed?)
		wowWData data;
		float x, y, z;
        DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		dbi->getTaxiDest(m_taxinode, x, y, z);
        Database::getSingleton( ).removeDatabaseInterface( dbi );
		pClient->getCurrentChar()->TeleportAck(&data, x, y, z);
		pClient->SendMsg(&data);
	}
    UpdateObject();
}

// Regenerates the regenField's curValue to the maxValue
// Right now, everything regenerates at the same rate
// A possible mod is to add another parameter, the stat regeneration is based off of (Intelligence for mana, Strength for HP)
// And build a regen rate based on that
// LeMMiNGS: Check for /sleep and itemstats
uint32 Character::Regen(uint32 curValue, uint32 maxValue, uint16 regenField, uint32* lastRegen)
{
    if (curValue < maxValue)
    {
	    uint32 regenDelay = 2; //standing
		if ((uint32)getUpdateValue(UNIT_FIELD_BYTES_1) == 1) regenDelay = 0.5; //sitting
		else if ((uint32)getUpdateValue(UNIT_FIELD_BYTES_1) == 3) regenDelay = 0.5; //sleeping

        // Cheap mod by mstic :)
        // Changes hp/Mana regen to a percent of Stamina / Spirit currently 15%
		//Follower: Say it with me people "code,test,Have other people test, then commit.
        // check if it's time to regen health
        if ((uint32)time(NULL) > *lastRegen + regenDelay)
        {
            *lastRegen = (time(NULL));
			uint32 stamina, spirit;
			stamina = getUpdateValue(UNIT_FIELD_STAT2) + getUpdateValue(PLAYER_FIELD_POSSTAT2) - getUpdateValue(PLAYER_FIELD_NEGSTAT2);
			spirit = getUpdateValue(UNIT_FIELD_STAT4) + getUpdateValue(PLAYER_FIELD_POSSTAT4) - getUpdateValue(PLAYER_FIELD_NEGSTAT4);
            switch (regenField)
            {
			case UNIT_FIELD_HEALTH : curValue+=uint32(stamina*.15);
                break;
            case UNIT_FIELD_POWER1 : curValue+=uint32(spirit*.15);
                break;
            default : curValue = 0;
                break;
            }
		}
		if (curValue > maxValue) curValue = maxValue;
		if (curValue < 0) curValue = 0;
	}
	setUpdateValue(regenField, curValue);
	return curValue;
}

/*uint32 Character::Regen(uint32 curValue, uint32 maxValue, uint16 regenField, uint32* lastRegen)
{
    if (curValue < maxValue)
    {
	    uint32 regenDelay = 6000; //standing
		if ((getUpdateValue(UNIT_FIELD_BYTES_1) & 0xff) == 1) regenDelay = 3000; //sitting
		else if ((getUpdateValue(UNIT_FIELD_BYTES_1) & 0xff) == 3) regenDelay = 1000; //sleeping
//        if ((getUpdateValue(UNIT_FIELD_BYTES_1) & 0xff) == 1) 
		{// sitting
            regenDelay = 3000;
        }

        // check if it's time to regen health
        if(m_regenTimer == 0)
        {
            m_regenTimer = regenDelay - 2 * getUpdateValue(UNIT_FIELD_STAT3);

            // Cheap mod by mstic :)
            // Changes hp/Mana regen to a percent of Stamina / Spirit currently 15%
			//Follower: Say it with me people "code,test,Have other people test, then commit.
            switch (regenField)
            {
            case UNIT_FIELD_HEALTH : 
				curValue+=uint32((getUpdateValue(UNIT_FIELD_STAT2) * .15)); 
                printf("Regenerating Life...\n");
                break;
            case UNIT_FIELD_POWER1 :
				curValue+=uint32((getUpdateValue(UNIT_FIELD_STAT4) * .15));
                printf("Regenerating Mana...\n");
                break;
            default : curValue = 2;
                printf("Regenerating Default...\n");
                break;
            }

            if (curValue > maxValue) curValue = maxValue;
            setUpdateValue(regenField, curValue);
        }
    }
	return curValue;
}
*/


void Character::SwapItemInSlot(int srcslot, int destslot)
{
    uint32 tempguid1, tempitemid;
    tempguid1 = this->m_items[srcslot].guid;
    tempitemid = this->m_items[srcslot].itemid;
    this->m_items[srcslot].guid = this->m_items[destslot].guid;
    this->m_items[srcslot].itemid = this->m_items[destslot].itemid;
    this->m_items[destslot].guid = tempguid1;
    this->m_items[destslot].itemid = tempitemid;
}

void Character::BuildEnumData( uint8 * data, uint8 * length )
{
    /*
    oint64      id; 
    char      Name[MAX_CHARACTER_NAME_SIZE]; 
    obyte      Race; 
    obyte      Class; 
    obyte      Gender; 
    obyte      Skin; 
    obyte      Face; 
    obyte      HairStyle; 
    obyte      HairColour; 
    obyte      FacialHair; 
    obyte      Level; 
    obyte      OutfitID; 
    oint32      ZoneID; 
    obyte      unknown1; 
    obyte      unknown2; 
    obyte      unknown3; 
    ofloat32   PositionX; 
    ofloat32   PositionY; 
    ofloat32   PositionZ; 
    oint32      GuildID; 
    oint32      unknown4; 
    obyte      rest; 
    oint32      PetDisplayInfoID; 
    oint32      PetExperienceLevel; 
    oint32      PetCreatureFamilyID; 
    InventoryItem_t      InventoryItem[20]; 
    */
    uint8 i = 0, doo = 0;
    assert(data);

    memcpy(data, &m_guid[0], 4);
    memcpy(data+4, &m_guid[1], 4);
    doo=8;

    // name
    uint16 name_size = 0;
    for (i=0; m_name[i] != 0; i++){
        name_size++;
        data[doo++] = m_name[i];
    }

    assert( name_size <= 21 );

    data[doo++] = 0x00;

    uint32 bytes = getUpdateValue(UNIT_FIELD_BYTES_0);
    data[doo++] = uint8(bytes & 0xff); // race
    data[doo++] = uint8((bytes >> 8) & 0xff); // class
    data[doo++] = uint8((bytes >> 16) & 0xff); // gender

    bytes = getUpdateValue(PLAYER_BYTES);
    data[doo++] = uint8(bytes & 0xff); //skin 
    data[doo++] = uint8((bytes >> 8) & 0xff); //face
    data[doo++] = uint8((bytes >> 16) & 0xff); //hairstyle
    data[doo++] = uint8((bytes >> 24) & 0xff); //haircolor

    bytes = getUpdateValue(PLAYER_BYTES_2);
    data[doo++] = uint8((bytes >> 8) & 0xff); //facialhair

    data[doo++] = uint8(getUpdateValue(UNIT_FIELD_LEVEL)); //level

    memcpy(data+doo, &m_zoneId, 2); // zoneid
    doo+=2;
    data[doo++] = 0x00;
    data[doo++] = 0x00;

    memcpy(data+doo, &m_mapId, 2); // mapid
    doo+=2;
    data[doo++] = 0x00;
    data[doo++] = 0x00;

    memcpy(data+doo, &m_positionX, 4); //x
    doo+=4;

    memcpy(data+doo, &m_positionY, 4); //y
    doo+=4;

    memcpy(data+doo, &m_positionZ, 4); //z
    doo+=4;

    int tempstor = 0xffffffff;
    memcpy(data+doo, &tempstor, 4); //guild
    doo+=4;
    tempstor = 0;
    memcpy(data+doo, &tempstor, 4); //unknown
    doo+=4;
    data[doo++] = 1; //rest state
    memcpy(data+doo, &m_petInfoId, 4); //pet info id
    doo+=4;
    memcpy(data+doo, &m_petLevel, 4); //pet info id
    doo+=4;
    memcpy(data+doo, &m_petFamilyId, 4); //pet info id
    doo+=4;



    Item *tempitem;
    for (i = 0; i < 20; i++) {
        tempitem = WorldServer::getSingleton().GetItem(m_items[i].itemid);
        if ((tempitem == NULL) && (m_items[i].guid != 0))
            return;
        if (m_items[i].guid != 0) {
            memcpy(data+doo, &tempitem->DisplayInfoID, 4);
            doo+=4;
            data[doo++] = uint8(tempitem->Inventorytype);
        }
        else {
            memcpy(data+doo, &m_inventory[i].displayId, 4);
            doo+=4;
            data[doo++] = i;
        }
    }
    // pad out the rest
    while (doo-name_size < 159){
        data[doo++] = 0x00;
    }

    assert( doo <= 176 );

    *length = name_size + 159;

}


void Character::BuildUpdateBlock(UpdateMask* updateMask, uint8 * data, int* length)
{
    Unit::BuildUpdateBlock(updateMask, data, length);
}



/////////////////////////////////// QUESTS ////////////////////////////////////////////
uint32 Character::getQuestStatus(uint32 quest_id)
{
    if( mQuestStatus.find( quest_id ) == mQuestStatus.end( ) ) return 0;
    return mQuestStatus[quest_id].status;
}

uint32 Character::addNewQuest(uint32 quest_id, uint32 status)
{ 
    quest_status qs;
    qs.quest_id = quest_id;
    qs.status = status;

    mQuestStatus[quest_id] = qs;
    return status; 
};

void Character::loadExistingQuest(quest_status qs)
{
    mQuestStatus[qs.quest_id] = qs;
}

void Character::setQuestStatus(uint32 quest_id, uint32 new_status)
{ 
    assert( mQuestStatus.find( quest_id ) != mQuestStatus.end( ) );
    mQuestStatus[quest_id].status = new_status; 
}

uint16 Character::getOpenQuestSlot() 
{ 
    int start = PLAYER_QUEST_LOG_1_1; 
   int end = PLAYER_QUEST_LOG_1_1 + 60; 
   for (int i = start; i <= end; i+=3) 
        if (m_updateValues[i] == 0) 
            return i; 

    return 0; 
} 

uint16 Character::getQuestSlot(uint32 quest_id) 
{ 
    int start = PLAYER_QUEST_LOG_1_1; 
   int end = PLAYER_QUEST_LOG_1_1 + 60; 
   for (int i = start; i <= end; i+=3) 
        if (m_updateValues[i] == quest_id) 
            return i; 

    return 0; 
}

void Character::setQuestLogBits(UpdateMask *updateMask)
{
    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i ) {
        if (i->second.status == 3){ // incomplete, put the quest in the log
            uint16 log_slot = getQuestSlot(i->second.quest_id);
            struct quest_status qs = i->second;
            if (log_slot == 0){ // in case this quest hasnt been added to the updateValues (but it shoudl have been!)
                log_slot = getOpenQuestSlot();
                setUpdateValue(log_slot, qs.quest_id);
                setUpdateValue(log_slot+1, 0x337);
            }

            updateMask->setBit(log_slot);
            updateMask->setBit(log_slot+1); 

            if (qs.m_questMobCount[0] > 0 || qs.m_questMobCount[1] > 0 ||
                qs.m_questMobCount[2] > 0 || qs.m_questMobCount[3] > 0)
            {
                updateMask->setBit(log_slot+2);
            }
        }
    }
}


void Character::KilledMonster(uint32 entry, uint32 guid)
{
    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i ) {
        if (i->second.status == 3){
            Quest *pQuest = WorldServer::getSingleton().getQuest(i->first);
            for (int j=0; j<4; j++)
            {
                if (pQuest->m_questMobId[j] == entry)
                {
                    if (i->second.m_questMobCount[j]+1 <= pQuest->m_questMobCount[j])
                    {
                        i->second.m_questMobCount[j]++ ;

                        // Send Update quest update kills message
                        wowWData data;
                        data.Initialise(24, SMSG_QUESTUPDATE_ADD_KILL);
                        data << pQuest->m_questId;
                        data << uint32(pQuest->m_questMobId[j]);
                        data << uint32(i->second.m_questMobCount[j]);
                        data << uint32(pQuest->m_questMobCount[j]);
                        data << guid << 0xF0001000;
                        WorldServer::getSingleton().SendMessageToPlayer(&data, m_name);

						// it's not so crazy if you know what you're doing... 
						uint16 log_slot = getQuestSlot(pQuest->m_questId); 
						uint32 kills = getUpdateValue(log_slot+1); 
						kills = kills + (1 << (6*j));   // 6 bits per mob counter 
						setUpdateValue(log_slot+1, kills);					
					
					}

                    checkQuestStatus(i->second.quest_id);
                    // Ehh, I think a packet should be sent here, but I havent found one in the official logs yet

                    return;
                } // end if mobId == entry
            } // end for each mobId
        } // end if status == 3
    } // end for each quest
}

//======================================================
//  Check to see if all the required monsters and items
//  have been killed and collected.
//======================================================
bool Character::checkQuestStatus(uint32 quest_id)
{
    WPAssert( mQuestStatus.find( quest_id ) != mQuestStatus.end( ) );
    quest_status qs = mQuestStatus[quest_id];
    Quest *pQuest = WorldServer::getSingleton().getQuest(quest_id);

	// TODO: magic numbers... again...
	for(int i = 0; i < 4; i++)
	{
		if(qs.m_questMobCount[i] != pQuest->m_questMobCount[i])
			return false;

		if(pQuest->m_questItemId[i])
		{
			uint32 amount = 0;
			// check item amounts
			for(int slot = 23; slot <= 38; slot++)
			{
				if(this->getGuidBySlot(slot) == pQuest->m_questItemId[i])
				{
					amount += static_cast<uint32>(this->getItemAmount(slot));
				}
			}
			if(amount < pQuest->m_questItemCount[i])
				return false;
		}
	}
    return true;
}


//  This function sends the message displaying the purple XP gain for the char
//  It assumes you will send out an UpdateObject packet at a later time.
void Character::giveXP(uint32 xp_to_give, uint32 guidlow, uint32 guidhi)
{
    wowWData data;
    if (guidlow != 0)
    {      
        // Send out purple XP gain message, but ONLY if a valid GUID was passed in
        // This message appear to be only for gaining XP from a death
        data.Initialise(17, SMSG_LOG_XPGAIN);
        data << uint32(guidlow) << uint32(guidhi);
        data << uint32(xp_to_give);
        data << uint8(0) << uint16(xp_to_give) << uint8(0);
        data << uint8(0);
        WorldServer::getSingleton().SendMessageToPlayer(&data, m_name);
    }

	if (xp_to_give == 0) return;

    uint32 xp           = getUpdateValue(PLAYER_XP);
    uint32 next_lvl_xp  = getUpdateValue(PLAYER_NEXT_LEVEL_XP);
    uint32 new_xp       = xp + xp_to_give;

    // Check for level-up
    if (new_xp >= next_lvl_xp)
    {
 
        uint32 health_gain=0, new_health=0, mana_gain=0, new_mana=0;
        new_xp = new_xp - next_lvl_xp;
        uint16 level = (uint16)getUpdateValue(UNIT_FIELD_LEVEL) + 1;
		next_lvl_xp = ((8*level*((level*5) + 45))/100)*100;
		//next_lvl_xp = level*level*400;

		health_gain = getUpdateValue(UNIT_FIELD_STAT2);
        new_health = getUpdateValue(UNIT_FIELD_MAXHEALTH) + health_gain;

        if (getUpdateValue(UNIT_FIELD_MAXPOWER1) > 0){
			mana_gain = getUpdateValue(UNIT_FIELD_STAT4);
            new_mana = getUpdateValue(UNIT_FIELD_MAXPOWER1) + mana_gain;
        }

		giveStat();

		updateItemStats();

        data.Initialise(48, SMSG_LEVELUP_INFO);

        data << uint32(level);
        data << uint32(health_gain);     // health gain
        data << uint32(mana_gain);       // mana gain
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);

        // 6 new fields
        data << uint32(0);  
        data << uint32(stat0);  //strength
        data << uint32(stat1);  //agility
        data << uint32(stat2);  //stamina
        data << uint32(stat3);  //intelect
        data << uint32(stat4);  //spirit

		setUpdateValue(UNIT_FIELD_STAT0,		m_stat0+stat0);
		setUpdateValue(UNIT_FIELD_STAT1,		m_stat1+stat1);
		setUpdateValue(UNIT_FIELD_STAT2,		m_stat2+stat2);
		setUpdateValue(UNIT_FIELD_STAT3,		m_stat3+stat3);
		setUpdateValue(UNIT_FIELD_STAT4,		m_stat4+stat4);
		setUpdateValue(UNIT_FIELD_MAXHEALTH,    new_health);
		setUpdateValue(UNIT_FIELD_HEALTH,       new_health);
		setUpdateValue(UNIT_FIELD_POWER1,       new_mana);
		setUpdateValue(UNIT_FIELD_MAXPOWER1,    new_mana);
		setUpdateValue(UNIT_FIELD_LEVEL,		level);
		setUpdateValue(PLAYER_NEXT_LEVEL_XP,	next_lvl_xp);

		if(level >= 10)
		{
			setUpdateValue(PLAYER_CHARACTER_POINTS1, getUpdateValue(PLAYER_CHARACTER_POINTS1) + 1);
		}
        WorldServer::getSingleton().SendMessageToPlayer(&data, m_name);
    }

    // Set the update bit
    setUpdateValue(PLAYER_XP, new_xp);
}

void Character::giveStat()
{
	uint16 level = getUpdateValue(UNIT_FIELD_LEVEL);

	switch( getClass() )
	{
	case SHAMAN:
	case PRIEST:
	case DRUID:
	case WARLOCK:
	case MAGE:
		{
			stat0 +=1;
			stat1 +=1;
			stat2 +=1;
			stat3 +=2;
			stat4 +=2;

			if(level > 30 )
			{
				stat3 +=1;
				stat4 +=1;
			}
		}break;

	case WARRIOR:
	case PALADIN:
	case HUNTER:
	case ROGUE:
		{
			stat0 +=2;
			stat1 +=1;
			stat2 +=2;
			stat3 +=1;
			stat4 +=1;

			if(level > 30 )
			{
				stat0 +=1;
				stat1 +=1;
			}
		}break;
	}
/*
	m_health = getUpdateValue(UNIT_FIELD_MAXHEALTH) + m_stat2 / 2;

	if (getUpdateValue(UNIT_FIELD_POWER1) > 0)
	{
		m_mana = getUpdateValue(UNIT_FIELD_POWER1) + m_stat4 / 2;
	}	
	setUpdateValue(UNIT_FIELD_MAXHEALTH,    m_health);
	setUpdateValue(UNIT_FIELD_HEALTH,       m_health);
	setUpdateValue(UNIT_FIELD_POWER1,       m_mana);
	setUpdateValue(UNIT_FIELD_MAXPOWER1,    m_mana);
*/
}

////////////////////////////////////////////////////////////////////////////////
//  Fill the object's Update Values from a space deliminated list of values.
////////////////////////////////////////////////////////////////////////////////
void Character::LoadUpdateValues(uint8* data)
{
    char* next = strtok((char*)data, " ");
    m_updateValues[0] = atol(next);
    for( uint16 index = 1; index < UPDATE_BLOCKS; index++)
    {
        char* next = strtok(NULL, " ");
        if (!next) continue;
        m_updateValues[index] = atol(next);
        assert(m_updateValues[index] != 0x7FFFFFFF);
    }
	m_updateValues[UNIT_FIELD_NATIVEDISPLAYID] = m_updateValues[UNIT_FIELD_DISPLAYID];
}


///////////////////////////////////////////////////////////////////////////////
//	Items Update
///////////////////////////////////////////////////////////////////////////////
void Character::updateItemStats()
{
	uint32 Stat;
	uint8 Amount;

	uint8 tMStat0=0;
	uint8 tMStat1=0;
	uint8 tMStat2=0;
	uint8 tMStat3=0;
	uint8 tMStat4=0;
	uint32 tRes1=0;
	uint32 tRes2=0;
	uint32 tRes3=0;
	uint32 tRes4=0;
	uint32 tRes5=0;
	uint32 tRes6=0;
	uint32 tArmor=0;
	uint32 tHealth=0;
	uint32 tMana=0; 

	for(int i=0; i < 20; i++) 
	{ 
		if (this->m_items[i].guid > 1 ) 
		{ 
			Stat = world.GetItem(m_items[i].itemid)->Resistances[0];
		    tArmor += Stat; 

			Stat = world.GetItem(m_items[i].itemid)->Resistances[1]; 
	  		tRes2 += Stat; 

			Stat = world.GetItem(m_items[i].itemid)->Resistances[2]; 
			tRes3 += Stat; 

			Stat = world.GetItem(m_items[i].itemid)->Resistances[3]; 
			tRes4 += Stat; 

			Stat = world.GetItem(m_items[i].itemid)->Resistances[4]; 
			tRes5 += Stat; 

			Stat = world.GetItem(m_items[i].itemid)->Resistances[5]; 
			tRes6 += Stat; 

			for(int j=0 ; j<5 ; j++)
			{
				Stat = world.GetItem(m_items[i].itemid)->BonusStat[j];
				Amount = world.GetItem(m_items[i].itemid)->BonusAmount[j];
				//printf("J: %u STAT %u, AMOUNT: %u\n", j, Stat, Amount);
				switch(Stat)
				{
				case 0: //MANA
					tMana += Amount;										
					break;
				case 1: //HEATLH
					tHealth += Amount;									
					break;
				case 3: //AGILITY
					tMStat1 += Amount;
					break;
				case 4: //STRENGTH
					tMStat0 += Amount;
					break;
				case 5: //INTELLECT
					tMStat3 += Amount;
					break;
				case 6: //SPIRIT
					tMStat4 += Amount;
					break;
				case 7: //STAMINA
					tMStat2 += Amount;
					break;
				//default:
					//printf("WRONG STAT %u\n",Stat);
				}
			}
		} 
	}

	setUpdateValue(UNIT_FIELD_RESISTANCES, tArmor);
	setUpdateValue(UNIT_FIELD_RESISTANCES+1,tRes1);
	setUpdateValue(UNIT_FIELD_RESISTANCES+2,tRes2);
	setUpdateValue(UNIT_FIELD_RESISTANCES+3,tRes3);
	setUpdateValue(UNIT_FIELD_RESISTANCES+4,tRes4);
	setUpdateValue(UNIT_FIELD_RESISTANCES+5,tRes5);
	setUpdateValue(UNIT_FIELD_RESISTANCES+6,tRes6);

	setUpdateValue(PLAYER_FIELD_POSSTAT0, tMStat0);
	setUpdateValue(PLAYER_FIELD_POSSTAT1, tMStat1);
	setUpdateValue(PLAYER_FIELD_POSSTAT2, tMStat2);
	setUpdateValue(PLAYER_FIELD_POSSTAT3, tMStat3);
	setUpdateValue(PLAYER_FIELD_POSSTAT4, tMStat4);
/*
	if(getUpdateValue(UNIT_FIELD_HEALTH)> m_health+tHealth+(tMStat2/2))
	{
		setUpdateValue(UNIT_FIELD_HEALTH,m_health+tHealth+(tMStat2/2));
	}
	setUpdateValue(UNIT_FIELD_MAXHEALTH,m_health+tHealth+(tMStat2/2));

	if (getUpdateValue(UNIT_FIELD_MAXPOWER1) > 0)
	{
		if(getUpdateValue(UNIT_FIELD_POWER1)> m_mana+tMana+(tMStat4/2))
		{
			setUpdateValue(UNIT_FIELD_POWER1,m_mana+tMana+(tMStat4/2));
		}
		setUpdateValue(UNIT_FIELD_MAXPOWER1,m_mana+tMana+(tMStat4/2));
	}
*/
/*
	UNIT_FIELD_POWER2
	UNIT_FIELD_POWER3
	UNIT_FIELD_POWER4
	UNIT_FIELD_POWER5
	UNIT_FIELD_MAXPOWER2
	UNIT_FIELD_MAXPOWER3
	UNIT_FIELD_MAXPOWER4
	UNIT_FIELD_MAXPOWER5
*/

	uint32 iMinDamage;
	uint32 iMaxDamage;
	uint32 baseattacktime;
    if (this->getGuidBySlot(15) == 0)
    {
        iMinDamage = (m_stat0+tMStat0)/10 - 1;
		iMaxDamage = (m_stat0+tMStat0)/10;
		baseattacktime = 5000;
    }
    else 
	{
		iMinDamage = (m_stat0+tMStat0)/6 + world.GetItem(this->getItemIdBySlot(15) )->MinimumDamage[0];
		iMaxDamage = (m_stat0+tMStat0)/6 + world.GetItem(this->getItemIdBySlot(15) )->MaximumDamage[0];
		baseattacktime = (uint32)world.GetItem(this->getItemIdBySlot(15))->Delay;
    }

	setUpdateValue(UNIT_FIELD_BASEATTACKTIME, baseattacktime );
	setUpdateFloatValue(UNIT_FIELD_MINDAMAGE, float(iMinDamage) );
	setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE, float(iMaxDamage) );
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_POS, 0);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, 0);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 1, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 2, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 3, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 4, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 5, 1);
	setUpdateFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + 6, 1);
				
	uint32 tmpAttackPower = ( iMinDamage + (iMaxDamage - iMinDamage) ) * 8 + 7;
	setUpdateValue(UNIT_FIELD_ATTACKPOWER, tmpAttackPower);
//	setUpdateValue(PLAYER_FIELD_ATTACKPOWERMODPOS, 0 );
//	setUpdateValue(PLAYER_FIELD_ATTACKPOWERMODNEG, 0 );
}


void Character::smsg_InitialSpells()
{
    wowWData data;
    uint16 spellCount = m_spells.size();

    data.Initialise(3+(4*spellCount), SMSG_INITIAL_SPELLS);
    data << uint8(0);
    data << uint16(spellCount); // spell count

    std::list<struct spells>::iterator itr;
    for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
    {
        data << uint16(itr->spellId); // spell id
        data << uint16(itr->slotId); // slot
    }

    world.SendMessageToPlayer(&data, m_name);
    printf( "CHARACTER: Sent Initial Spells\n" );
}

void Character::addSpell(uint16 spell_id, uint16 slot_id)
{
    struct spells newspell;
    newspell.spellId = spell_id;

    if (slot_id == 0xffff){
        uint16 maxid = 0;
        std::list<struct spells>::iterator itr;
        for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
        {
            if (itr->slotId > maxid) maxid = itr->slotId;
        }

        slot_id = maxid + 1;
    }

    newspell.slotId = slot_id;
    m_spells.push_back(newspell);
}


//START OF LINA LEARNED SPELL TEST
bool Character::isAllreadyLearned(uint16 spell_id)
{
	std::list<struct spells>::iterator itr;
	for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
	{
		if( itr->spellId == spell_id) return true;
	}
	return false;
}
//END OF LINA LEARNED SPELL TEST


//START OF LINA ACTION BAR
void Character::smsg_InitialActions()
{
    wowWData data;
    uint16 actionCount = m_actions.size();
	uint16 button=0;

    data.Initialise(480, SMSG_ACTION_BUTTONS);

    std::list<struct actions>::iterator itr;
    for (itr = m_actions.begin(); itr != m_actions.end();)
    {
		//printf("BUTTON: %u == %u\n", itr->button, button);
		if( itr->button == button)
		{
			data << uint16(itr->action);
			data << uint8(itr->type);
			data << uint8(itr->misc);
			//printf("SET: button %u action %u\n",button,itr->action);
			++itr;
		}
		else
		{
			data << uint32(0);
		}
		button++;
    }
	if(button < 120 )
	{
		for(int temp_counter=(120-button); temp_counter>0; temp_counter--)
		{
			data << uint32(0);
		}
	}
    world.SendMessageToPlayer(&data, m_name);
    printf( "CHARACTER: Sent Initial Actions\n" );
}

void Character::addAction(uint8 button, uint16 action, uint8 type, uint8 misc)
{
	bool isexist=false;

	std::list<struct actions>::iterator itr;
	for (itr = m_actions.begin(); itr != m_actions.end(); ++itr)
	{
		if (itr->button == button)
		{
			if(action==0)
			{
				//printf("ERASE: button %u action %u\n",itr->button,itr->action);
				m_actions.erase(itr);
			}
			else
			{
				//printf("OLD: button %u action %u\n",itr->button,itr->action);
				itr->button=button;
				itr->action=action;
				itr->type=type;
				itr->misc=misc;
				//printf("UPDATE: button %u action %u\n",itr->button,itr->action);
			}
			isexist=true;
			break;
		}
	}
	if( !isexist )
	{
		//printf("ADD: button %u action %u\n",button,action);
		struct actions newaction;
		newaction.button=button;
		newaction.action=action;
		newaction.type=type;
		newaction.misc=misc;
		m_actions.push_back(newaction);
	}
}
//END OF LINA ACTION BAR