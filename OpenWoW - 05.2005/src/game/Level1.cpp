//////////////////////////////////////////////////////////////////////
//  GM Chat Commands
//
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "WorldServer.h"
#include "Character.h"
#include "Opcodes.h"
#include "Database.h"

bool ChatHandler::HandleAnnounceCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	uint8 pAnnounce[256];
	sprintf((char*)pAnnounce, "BROADCAST: %s", args);   // Adds BROADCAST:
	WORLDSERVER.SendWorldText((uint8*)pAnnounce); // send message

	return true;
}


bool ChatHandler::HandleGMOnCommand(uint8* args)
{
	(void)args;
	uint32 newbytes = m_pClient->getCurrentChar( )->getUpdateValue(PLAYER_BYTES_2) | 0x8;
	m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, newbytes);

	return true;
}


bool ChatHandler::HandleGMOffCommand(uint8* args)
{
	(void)args;
	uint32 newbytes = m_pClient->getCurrentChar( )->getUpdateValue(PLAYER_BYTES_2) & ~(0x8);
	m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, newbytes);

	return true;
}


bool ChatHandler::HandleGPSCommand(uint8* args)
{
	(void)args;
	NetworkPacket data;
	Object *obj;

	guid cguid = m_pClient->getCurrentChar()->getSelection ();
	if (cguid.Assigned ())
	{
                if (!(obj = (Object*)WORLDSERVER.GetCreature (cguid.sno)))
		{
                        FillMessageData (&data, 0x09, m_pClient,
                                         (uint8*)"You should select a character or a creature.");
			m_pClient->SendMsg (&data);
			return true;
		}
	}
	else
		obj = (Object*)m_pClient->getCurrentChar();

	uint8 buf[256];
	sprintf((char*)buf, "X: %f Y: %f Z %f Orientation: %f",
		obj->getPositionX(), obj->getPositionY(), obj->getPositionZ(),
		obj->getOrientation());
	FillMessageData (&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );

	return true;
}

/*
 bool ChatHandler::HandleKickCommand(uint8* args)
 {
 NetworkPacket data;

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
 WORLDSERVER.disconnect_client(reinterpret_cast < Server::nlink_client *> (pChar->pClient->GetNLink()));
 }
 return true;
 }*/


bool ChatHandler::HandleSummonCommand(uint8* args)
{
	NetworkPacket data;

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
	NetworkPacket data;

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

	if (strncmp((char*)args,"sunr",5)==0)
		smsg_NewWorld(m_pClient, 1, -180.949f, -296.467f, 11.5384f);
	else if (strncmp((char*)args,"thun",5)==0)
		smsg_NewWorld(m_pClient, 1, -1196.22f, 29.0941f, 176.949f);
	else if (strncmp((char*)args,"cross",6)==0)
		smsg_NewWorld(m_pClient, 1, -443.128f, -2598.87f, 96.2114f);
	else if (strncmp((char*)args,"ogri",5)==0)
		smsg_NewWorld(m_pClient, 1, 1676.21f, -4315.29f, 61.5293f);
	else if (strncmp((char*)args,"neth",5)==0)
		smsg_NewWorld(m_pClient, 0, -10996.9f, -3427.67f, 61.996f);
	else if (strncmp((char*)args,"thel",5)==0)
		smsg_NewWorld(m_pClient, 0, -5395.57f, -3015.79f, 327.58f);
	else if (strncmp((char*)args,"storm",6)==0)
		smsg_NewWorld(m_pClient, 0, -8913.23f, 554.633f, 93.7944f);
	else if (strncmp((char*)args,"iron",5)==0)
		smsg_NewWorld(m_pClient, 0, -4981.25f, -881.542f, 501.66f);
	else if (strncmp((char*)args,"under",6)==0)
		smsg_NewWorld(m_pClient, 0, 1586.48f, 239.562f, -52.149f);
	else
		return false;

	return true;
}


bool ChatHandler::HandleModifyHPCommand(uint8* args)
{
	NetworkPacket data;

	// change level of char
	char* pHp = strtok((char*)args, " ");
	if (!pHp)
		return false;

	char* pHpMax = strtok(NULL, " ");
	if (!pHpMax)
		return false;

	uint32 Arg2 = atoi(pHpMax);
	uint32 Arg = atoi(pHp);

	ChangeSelectedChar(UNIT_FIELD_MAXHEALTH, Arg2, 65535, 1, "HPMAX");
	ChangeSelectedChar(UNIT_FIELD_HEALTH, Arg, Arg2, 1, "HP");

	return true;
}


bool ChatHandler::HandleModifyManaCommand(uint8* args)
{
	NetworkPacket data;

	char* pmana = strtok((char*)args, " ");
	if (!pmana)
		return false;

	char* pmanaMax = strtok(NULL, " ");
	if (!pmanaMax)
		return false;

	uint32 Arg2 = atoi(pmanaMax);
	uint32 Arg = atoi(pmana);

	ChangeSelectedChar(UNIT_FIELD_MAXPOWER1, Arg2, 65535, 1, "MANAMAX");
	ChangeSelectedChar(UNIT_FIELD_POWER1, Arg, Arg2, 1, "MANA");

	return true;
}


bool ChatHandler::HandleModifyLevelCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	uint32 Arg = atoi((char*)args);
	ChangeSelectedChar(UNIT_FIELD_LEVEL, Arg, 255, 1, "LVL");

	return true;
}


bool ChatHandler::HandleModifyExpCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	int Arg = atoi ((char*)args);

	Character * pChar = getSelectedChar();
	if(pChar)
	{
		int32 expuser =(pChar->pClient->getCurrentChar()->getUpdateValue(PLAYER_XP));

		if(Arg < 0)
		{
			int32 newexp = expuser + Arg;
			if(newexp < 0 )
			{
				ChangeSelectedChar(PLAYER_XP, (uint32)0, 1000000000, 0, "XP");
				return true;
			}
		}
		ChangeSelectedChar(PLAYER_XP, (uint32)expuser+Arg, 1000000000, 0, "XP");
	}
	return true;
}


bool ChatHandler::HandleModifySpeedCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	float Arg = (float)atof((char*)args);
	ChangeSelectedCharMsg(SMSG_FORCE_RUN_SPEED_CHANGE, (float)Arg, (float)30, (float)1, "WALK SPEED");
	return true;
}

bool ChatHandler::HandleModifyWaterSpeedCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	float Arg = (float)atof((char*)args);
	ChangeSelectedCharMsg(SMSG_FORCE_SWIM_SPEED_CHANGE, (float)Arg, (float)30, (float)1, "SWIM SPEED");
	return true;
}

bool ChatHandler::HandleModifyScaleCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	float Arg = (float)atof((char*)args);
	ChangeSelectedChar(OBJECT_FIELD_SCALE_X, (float)Arg, (float)4, (float)0.02, "SCALE");
	return true;
}


bool ChatHandler::HandleModifyMountCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	uint32 mId = 1147;
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

		ChangeSelectedCharMsg(SMSG_FORCE_RUN_SPEED_CHANGE, (float)30, 30, 1, "WALK SPEED");
		ChangeSelectedCharMsg(SMSG_FORCE_SWIM_SPEED_CHANGE, (float)30, 30, 1, "WATER SPEED");
	}

	return true;
}


bool ChatHandler::HandleModifyGoldCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	int Arg = atoi((char*)args);

	Character * pChar = getSelectedChar();
	if(pChar)
	{
		int32 moneyuser =(pChar->pClient->getCurrentChar()->getUpdateValue(PLAYER_FIELD_COINAGE));

		if (Arg < 0)
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
	(void)args;
	NetworkPacket data;
	uint8 buf[256];
	sprintf((char*)buf,"Characters saved: %i/%i\n", WORLDSERVER.Save(m_pClient->getCharacterName()),WORLDSERVER.GetClientsConnected());
	FillMessageData(&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );

	return true;
}
