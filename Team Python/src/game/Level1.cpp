
/////////////////////////////////////////////////
//  GM Chat Commands
//

#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "WorldServer.h"
#include "Character.h"
#include "Opcodes.h"
#include "Database.h"

#define world WorldServer::getSingleton()

bool ChatHandler::HandleAnnounceCommand(uint8* args)
{
        wowWData data;

    if(!*args)
        return false;

    uint8 pAnnounce[256];
    sprintf((char*)pAnnounce, "BROADCAST: %s", args);   // Adds BROADCAST:
    WorldServer::getSingleton().SendWorldText((uint8*)pAnnounce); // send message

    return true;
}


bool ChatHandler::HandleGMOnCommand(uint8* args)
{
    uint32 newbytes = m_pClient->getCurrentChar( )->getUpdateValue(PLAYER_BYTES_2) | 0x8;
    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, newbytes);

    return true;
}


bool ChatHandler::HandleGMOffCommand(uint8* args)
{
    uint32 newbytes = m_pClient->getCurrentChar( )->getUpdateValue(PLAYER_BYTES_2) & ~(0x8);
    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, newbytes);

    return true;
}


bool ChatHandler::HandleGPSCommand(uint8* args)
{
    wowWData data;
    Object *obj;

    const uint32 *guid = m_pClient->getCurrentChar()->getSelectionPtr();
    if (guid[0] != 0)
    {
        if(!(obj = (Object*)WorldServer::getSingleton().GetCreature(guid[0])) && !(obj = (Object*)WorldServer::getSingleton().GetCharacter(guid[0])))
 	    {
            FillMessageData(&data, 0x09, m_pClient, (uint8*)"You should select a character or a creature.");
            m_pClient->SendMsg( &data );
            return true;
 	    }
    }
    else
        obj = (Object*)m_pClient->getCurrentChar();

	uint8 buf[256];
	sprintf((char*)buf, "X: %f Y: %f Z %f Orientation: %f Zone: %u",
	obj->getPositionX(), obj->getPositionY(), obj->getPositionZ(),
	obj->getOrientation(), obj->getZone());
    FillMessageData(&data, 0x09, m_pClient, buf);
    m_pClient->SendMsg( &data );

	return true;
}


bool ChatHandler::HandleKickCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

	Character *pChar = getCurrentCharByName(args);
	if (pChar)
	{		
		if(m_pClient->getAccountLvl() < pChar->pClient->getAccountLvl())
		{
			Message(pChar, "try kicking");
			return true;
		}
		Message(pChar, "kick");
		WorldServer::getSingleton().disconnect_client(reinterpret_cast < Server::nlink_client *> (pChar->pClient->GetNLink())); 
	}
    return true;
}


bool ChatHandler::HandleSummonCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

	Character *pChar = getCurrentCharByName(args);
	if (pChar)
	{	
		uint16 c=m_pClient->getCurrentChar()->getMapId();
		float x=m_pClient->getCurrentChar()->getPositionX();
		float y=m_pClient->getCurrentChar()->getPositionY();
		float z=m_pClient->getCurrentChar()->getPositionZ();

		Message(pChar,"summon");	

		smsg_NewWorld(pChar->pClient, c,x,y,z);
					  
	}	

    return true;
}


bool ChatHandler::HandleAppearCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

	Character *pChar = getCurrentCharByName(args);
	if (pChar)
	{
		uint16 c=pChar->getMapId();
		float x=pChar->getPositionX();
		float y=pChar->getPositionY();
		float z=pChar->getPositionZ();
		Message(pChar,"appear to");

		smsg_NewWorld(m_pClient, c,x,y,z);
	}

    return true;
}


bool ChatHandler::HandleRecallCommand(uint8* args)
{
    if(!*args)
        return false;

    if (strncmp((char*)args,"sunr",5)==0)							// to Malaka´jin (Stonetalon)
        smsg_NewWorld(m_pClient, 1, -180.949f, -296.467f, 11.5384f);
    else if (strncmp((char*)args,"thun",5)==0)						//to Thunderbluff Taxi Spot
        smsg_NewWorld(m_pClient, 1, -1196.22f, 29.0941f, 176.949f);
    else if (strncmp((char*)args,"cross",6)==0)						//to X-Roads Taxi Spot
        smsg_NewWorld(m_pClient, 1, -443.128f, -2598.87f, 96.2114f);
    else if (strncmp((char*)args,"ogri",5)==0)						//to Ogrimmar Taxi Spot
        smsg_NewWorld(m_pClient, 1, 1676.21f, -4315.29f, 61.5293f);
    else if (strncmp((char*)args,"neth",5)==0)						//to Nehtergarde Keep
        smsg_NewWorld(m_pClient, 0, -10996.9f, -3427.67f, 61.996f);
    else if (strncmp((char*)args,"thel",5)==0)						//to Thelsamar inside Hut
        smsg_NewWorld(m_pClient, 0, -5395.57f, -3015.79f, 327.58f);
    else if (strncmp((char*)args,"storm",6)==0)						//to Stormwind entrance
        smsg_NewWorld(m_pClient, 0, -8913.23f, 554.633f, 93.7944f);
    else if (strncmp((char*)args,"iron",5)==0)						//to Ironforge entrance
        smsg_NewWorld(m_pClient, 0, -4981.25f, -881.542f, 501.66f);
    else if (strncmp((char*)args,"under",6)==0)						//to Undercity entrance
        smsg_NewWorld(m_pClient, 0, 1883.19f, 236.66f, 58.71f);
//balko start --New Ports (as ship replacement)
	else if (strncmp((char*)args,"darn",5)==0)						//to Darnassus (pink Energyefield)
        smsg_NewWorld(m_pClient, 1, 9942.95f, 2606.23f, 1316.32f);
	else if (strncmp((char*)args,"auber",6)==0)						//to Auberdeen Taxi Spot
        smsg_NewWorld(m_pClient, 1, 6344.38f, 557.63f, 16.22f);
	else if (strncmp((char*)args,"rat",4)==0)						//to Ratchet Key
        smsg_NewWorld(m_pClient, 1, -997.00f, -3821.11f, 5.34f);
	else if (strncmp((char*)args,"mene",5)==0)						//to Menethil Taxi Spot
        smsg_NewWorld(m_pClient, 0, -3790.51f, -781.64f, 9.36f);
	else if (strncmp((char*)args,"booty",6)==0)						//to Booty Bay Key
        smsg_NewWorld(m_pClient, 0, -14288.00f, 551.74f, 8.90f);
	else if (strncmp((char*)args,"thera",6)==0)						//to Theramore Key
        smsg_NewWorld(m_pClient, 1, -4001.16f, -4727.15f, 4.97f);
	else if (strncmp((char*)args,"ston",5)==0)						//to Stonard Taxi Spot (SoS)
        smsg_NewWorld(m_pClient, 0, -10455.63f, -3277.92f, 21.43f);
	else if (strncmp((char*)args,"grosh",6)==0)						//to Grosh´gok (Deadwind Pass)
        smsg_NewWorld(m_pClient, 0, -10891.97f, -2046.83f, 115.58f);
	else if (strncmp((char*)args,"dark",5)==0)						//to Darkshire Taxi Spot (SoS)
        smsg_NewWorld(m_pClient, 0, -10523.36f, -1258.47f, 44.44f);
	else if (strncmp((char*)args,"strang",7)==0)					//to Rebel Camp (Stranglethorn)
        smsg_NewWorld(m_pClient, 0, -11311.77f, -202.58f, 75.24f);
	else if (strncmp((char*)args,"west",5)==0)						//to Westfall Taxi Spot
        smsg_NewWorld(m_pClient, 0, -10612.27f, 1031.04f, 34.13f);
	else if (strncmp((char*)args,"gold",5)==0)						//to Goldshire  
        smsg_NewWorld(m_pClient, 0, -9487.23f, 62.74f, 56.08f);
	else if (strncmp((char*)args,"red",4)==0)						//to Redridge Mountains Taxi Spot
        smsg_NewWorld(m_pClient, 0, -9427.62f, -32242.00f, 68.56f);
	else if (strncmp((char*)args,"stepp",6)==0)						//to Burning Steppes (foot of Bridge)
        smsg_NewWorld(m_pClient, 0, -8014.32f, -1200.76f, 145.71f);
	else if (strncmp((char*)args,"gorge",6)==0)						//to Searing Gorge
        smsg_NewWorld(m_pClient, 0, -7195.04f, -1075.50f, 241.62f);
	else if (strncmp((char*)args,"bad",4)==0)						//to Badlands
        smsg_NewWorld(m_pClient, 0, -6510.24f, -3281.51f, 241.66f);
	else if (strncmp((char*)args,"ara",4)==0)						//to Arathi Highlands (Ref.Pointe)
        smsg_NewWorld(m_pClient, 0, -10455.63f, -3277.92f, 21.43f);
	else if (strncmp((char*)args,"south",6)==0)						//to Southshore Taxi Spot (Hillsbrad)
        smsg_NewWorld(m_pClient, 0, -711.75f, -519.66f, 25.14f);
	else if (strncmp((char*)args,"sepu",5)==0)						//to Sepulcher Taxi Spot (Silverpine)
        smsg_NewWorld(m_pClient, 0, 479.72f, 1529.85f, 131.46f);
	else if (strncmp((char*)args,"heart",6)==0)						//to Hearthglen (W.Plague)
        smsg_NewWorld(m_pClient, 0, 2912.72f, -1446.67f, 148.90f);
	else if (strncmp((char*)args,"north",6)==0)						//to Northpass Tower (E.Plague)
        smsg_NewWorld(m_pClient, 0, 3167.07f, -4354.45f, 138.53f);
	else if (strncmp((char*)args,"free",5)==0)						//to Freewind Post Taxi Spot (TN)
        smsg_NewWorld(m_pClient, 1, -5406.10f, -2421.63f, 89.34f);
	else if (strncmp((char*)args,"gad",4)==0)						//to Gadgetzan (Tanaris)
        smsg_NewWorld(m_pClient, 1, -7175.57f, -3775.94f, 8.37f);
		else if (strncmp((char*)args,"ungoro",7)==0)				//to Un´Goro Crater (lower ramp)
        smsg_NewWorld(m_pClient, 1, -7871.49f, -2110.87f, -269.57f);
	else if (strncmp((char*)args,"sili",5)==0)						//to Silithus
        smsg_NewWorld(m_pClient, 1, -6932.50f, 411.90f, 5.81f);
	else if (strncmp((char*)args,"stone",6)==0)						//to Stonetalon Mountains
        smsg_NewWorld(m_pClient, 1, 726.32f, 345.18f, 64.41f);	
	else if (strncmp((char*)args,"astra",6)==0)						//to Astranaar (Ashenvale)
        smsg_NewWorld(m_pClient, 1, 2823.02f, -286.33f, 107.42f);	
	else if (strncmp((char*)args,"fel",4)==0)						//to Felwood
        smsg_NewWorld(m_pClient, 1, 6809.45f, -2092.51f, 625.05f);	
	else if (strncmp((char*)args,"winter",7)==0)					//to Winterspring
        smsg_NewWorld(m_pClient, 1, 6658.94f, -3655.87f, 695.88f);	
	else if (strncmp((char*)args,"hyjal",6)==0)						//to Hyjal
        smsg_NewWorld(m_pClient, 1, 4489.32f, -2485.44f, 1129.61f);	
	else if (strncmp((char*)args,"azsh",5)==0)						//to Temple of Zin-Malor (Azshara)
        smsg_NewWorld(m_pClient, 1, 3547.77f, -5358.05f, 107.48f);	
	else if (strncmp((char*)args,"fera",5)==0)						//to Camp Mojache (Feralas)
        smsg_NewWorld(m_pClient, 1, -4418.47f, 199.21f, 25.04f);	
	else if (strncmp((char*)args,"deso",5)==0)						//to Desolace 
        smsg_NewWorld(m_pClient, 1, -1254.55f, 1687.95f, 90.58f);	
//balko end
	else
		return false;

    return true;
}


bool ChatHandler::HandleModifyHPCommand(uint8* args)
{
    wowWData data;

    // change level of char
    char* pHp = strtok((char*)args, " ");
    if (!pHp)
        return false;

	char* pHpMax = strtok(NULL, " ");
    if (!pHpMax)
        return false;

	uint32 Arg2 = atoi(pHpMax);
	uint32 Arg = atoi(pHp);

	ChangeSelectedChar(UNIT_FIELD_MAXHEALTH, Arg2, Arg2, 1, "HPMAX");
	ChangeSelectedChar(UNIT_FIELD_HEALTH, Arg, Arg2, 1, "HP");

    return true;
}


bool ChatHandler::HandleModifyManaCommand(uint8* args)
{
    wowWData data;

    char* pmana = strtok((char*)args, " ");
    if (!pmana)
        return false;

	char* pmanaMax = strtok(NULL, " ");
    if (!pmanaMax)
        return false;

	uint32 Arg2 = atoi(pmanaMax);
	uint32 Arg = atoi(pmana);

	ChangeSelectedChar(UNIT_FIELD_MAXPOWER1, Arg2, Arg2, 1, "MANAMAX");
	ChangeSelectedChar(UNIT_FIELD_POWER1, Arg, Arg2, 1, "MANA");

    return true;
}


bool ChatHandler::HandleModifyLevelCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    uint32 Arg = atoi((char*)args);
	ChangeSelectedChar(UNIT_FIELD_LEVEL, Arg, 255, 1, "LVL");

    return true;
}


bool ChatHandler::HandleModifySpeedCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    float Arg = (float)atof((char*)args);
	ChangeSelectedCharMsg(SMSG_FORCE_SPEED_CHANGE, (float)Arg, (float)30, (float)1, "WALK SPEED");
	return true;
}

bool ChatHandler::HandleModifyWaterSpeedCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    float Arg = (float)atof((char*)args);
	ChangeSelectedCharMsg(SMSG_FORCE_SWIM_SPEED_CHANGE, (float)Arg, (float)30, (float)1, "SWIM SPEED");
	return true;
}

bool ChatHandler::HandleModifyScaleCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    float Arg = (float)atof((char*)args);
	ChangeSelectedChar(OBJECT_FIELD_SCALE_X, (float)Arg, (float)4, (float)0.02, "SCALE");
    return true;
}


bool ChatHandler::HandleModifyMountCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    uint32 mId = 1147;
	float speed = (float)30;
    uint32 num = 0;

    num = atoi((char*)args);
	switch(num)
    {
	case 1:
		mId=1147;	//GRYPHON
		break;
	case 2: 
		mId=479;	//HYPOGRYPH
		break;
	case 3:
		mId=235;	//EVIL HORSE
		break;
	case 4:
		mId=236;	//WHITE HORSE
		break;
	case 5:
		mId=237;	//PALOMINO HORSE
		break;
	case 6:
		mId=238;	//PINTO HORSE
		break;
	case 7:
		mId=239;	//BLACK HORSE
		break;
	case 8:
		mId=908;	//CHESNUT HORSE
		break;
	case 9:
		mId=1531;	//ZEBRA
		break;
	case 10: 
		mId=2346;	//NIGHTMARE HORSE
		break;
	case 11:
		mId=5050;	//UNDEAD STEED
		break;
	case 12:
		mId=2784;	//BLACK RAMS
		break;
	case 13:
		mId=2787;	//BLUE RAMS
		break;
	case 14:
		mId=2785;	//BROWN RAMS
		break;
	case 15:
		mId=2736;	//GREY RAMS
		break;
	case 16:
		mId=2786;	//WHITE RAMS
		break;
	case 17:
		mId=180;	//ORANGE RAPTOR
		break;
	case 18:
		mId=322;	//DARK GREEN RAPTOR
		break;
	case 19:
		mId=675;	//BLUE RAPTOR
		break;
	case 20:
		mId=787;	//YELLOW RAPTOR
		break;
	case 21:
		mId=960;	//PURPLE RAPTOR
		break;
	case 22:
		mId=1960;	//RED RAPTOR
		break;
	case 23:
		mId=1337;	//DARK GREY RAPTOR
		break;
	case 24:
		mId=1041;	//BROWN STRIDER
		break;
	case 25:
		mId=1220;	//GREY STRIDER
		break;
	case 26:
		mId=1221;	//IVORY STRIDER
		break;
	case 27:		
		mId=1961;	//PING STRIDER
		break;
	case 28:
		mId=1281;	//PURPLE STRIDER
		break;
	case 29:
		mId=1040;	//TEAL STRIDER
		break;
	case 30:
		mId=321;	//BLACK TIGER
		break;
	case 31:
		mId=1056;	//BROWN TIGER
		break;
	case 32:
		mId=3029;	//DARK TIGER
		break;
	case 33:
		mId=320;	//RED TIGER
		break;
	case 34:
		mId=748;	//SNOW TIGER
		break;
	case 35:
		mId=616;	//WHITE TIGER
		break;
	case 36:
		mId=632;	//YELLOW TIGER
		break;
	case 37:
		mId=2187;	//STRIPED UNICORN
		break;
	case 38:
		mId=2185;	//EVIL UNICORN
		break;
	case 39:
		mId=2186;	//IVORY UNICORN
		break;
	case 40:
		mId=2189;	//BLAC STRIPES UNICORN
		break;
	case 41:
		mId=207;	//DARK BLACK WOLF
		break;
	case 42:
		mId=246;	//REDDISH BROWN WOLF
		break;
	case 43:
		mId=247;	//BROWN WOLF
		break;
	case 44:
		mId=720;	//LIGHT BLUE WOLF
		break;
	case 45:
		mId=2320;	//GREY WOLF
		break;
	case 46:
		mId=2327;	//DARK GREY WOLF
		break;
	case 47:
		mId=2328;	//DARK BROWN WOLF
		break;
	case 48:
		mId=295;	//WYVERN
		break;
	case 49:
		mId=6544;	//GRAY ROBOT STRIDER
		break;
	case 50:
		mId=6569;	//BROWN ROBOT STRIDER
		break;
	case 51:
		mId=6369;	//DARK BROWN DRAGON
		break;
	case 52:
		mId=6370;	//LIGHT BROWN DRAGON
		break;
	case 53:
		mId=6371;	//CHAMPAGNE DRAGON
		break;
	case 54:
		mId=6372;	//SNOW DRAGON
		break;
	case 55:
		mId=6373;	//BLUE DRAGON
		break;
	case 56:
		mId=6374;	//DARK BROWN DRAGON 2
		break;
	case 57:
		mId=6375;	//GREEN DRAGON
		break;
	case 58:
		mId=6376;	//CHAMPAGNE DRAGON 2
		break;
	case 59:
		mId=6377;	//DARK BROWN DRAGON 3
		break;
	case 60:
		mId=6378;	//DARK BROWN DRAGON 4
		break;
	case 61:
		mId=6379;	//LIGHT GREEN DRAGON
		break;
	case 62:
		mId=5145;	//BLOOD DRAGON
		break;
	case 63:	
		mId=1340;	//STRIDER
		break;
	case 64:	
		mId=1566;	//BAT
		break;
	default:		//NO ERROR OF MOUNT ;)
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no such mount.");
		m_pClient->SendMsg( &data );
        return true;
	}

	Character *pChar=getSelectedChar();
	if(pChar)
	{
		pChar->setUpdateValue( UNIT_FIELD_FLAGS , 0x001000 );
		ChangeSelectedChar(UNIT_FIELD_MOUNTDISPLAYID, mId, 8192, 1, "MOUNT");
		pChar->setUpdateValue( UNIT_FIELD_FLAGS , 0x003000 );

		ChangeSelectedCharMsg(SMSG_FORCE_SPEED_CHANGE, (float)30, 30, 1, "WALK SPEED");
		ChangeSelectedCharMsg(SMSG_FORCE_SWIM_SPEED_CHANGE, (float)30, 30, 1, "WATER SPEED");
	}

    return true;
}
                    

bool ChatHandler::HandleModifyGoldCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

	uint32 Arg = atoi((char*)args);
		
	Character * pChar = getSelectedChar();
	if(pChar)
	{
		int32 moneyuser =(pChar->pClient->getCurrentChar()->getUpdateValue(PLAYER_FIELD_COINAGE));
								
		if(Arg<0)
		{
			int32 newmoney = moneyuser + Arg;
			if(newmoney < 0 )
			{
				ChangeSelectedChar(PLAYER_FIELD_COINAGE, (uint32)0, 1000000000, 0, "COPPER");
				return true;
			}
		}
		ChangeSelectedChar(PLAYER_FIELD_COINAGE, (uint32)moneyuser+Arg, 1000000000, 0, "COPPER");
	}
    return true;
}

bool ChatHandler::HandleSaveAllCommand(uint8* args)
{
    wowWData data;
	uint8 buf[256];
	sprintf((char*)buf,"Characters saved: %i/%i\n", WorldServer::getSingleton().Save(m_pClient->getCharacterName()),WorldServer::getSingleton().GetClientsConnected());
	FillMessageData(&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );

	return true;
}