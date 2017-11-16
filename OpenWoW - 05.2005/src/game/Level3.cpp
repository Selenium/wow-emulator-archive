//////////////////////////////////////////////////////////////////////
//  Admin Chat Commands
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
#include "GameObject.h"

bool ChatHandler::HandleSecurityCommand(uint8* args)
{
        char* pName = strtok((char*)args, " ");
        if (!pName)
                return false;

        char* pgm = strtok(NULL, " ");
        if (!pgm)
                return false;

	uint32 gm = atoi(pgm);
	if (!TestValue (gm, 5, 0))
		return true;

        Character *pChar = getCurrentCharByName((uint8*)pName);
        if (pChar)
        {
                if(m_pClient->getAccountLvl() < int (gm))
                {
                        Message(pChar, "try to lvl account");
                        return true;
                }

                Message(pChar, "lvl account", gm);

                pChar->pClient->setAccountLvl(gm);

                DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
                char sql[512];
                sprintf(sql, "update accounts set gm = '%i' where acct = '%u'", gm, pChar->pClient->getAccountID());
                dbi->doQuery(sql);
                DATABASE.removeDatabaseInterface(dbi);
        }

        return true;
}


bool ChatHandler::HandleWorldPortCommand(uint8* args)
{
        char* pContinent = strtok((char*)args, " ");
        if (!pContinent)
                return false;

        char* px = strtok(NULL, " ");
        char* py = strtok(NULL, " ");
        char* pz = strtok(NULL, " ");

        if (!px || !py || !pz)
                return false;

        smsg_NewWorld(m_pClient, atoi(pContinent), (float)atof(px), (float)atof(py), (float)atof(pz)); //LINA

        return true;
}


bool ChatHandler::HandleAddSpiritCommand(uint8* args)
{
	(void)args;
        printf("Spawning Spirit Healers\n");
        WorldServer::getSingletonPtr()->dbi->spawnSpiritHealers();

        return true;
}


bool ChatHandler::HandleMoveCommand(uint8* args)
{
        char* px = strtok((char*)args, " ");
        char* py = strtok(NULL, " ");
        char* pz = strtok(NULL, " ");

        if (!px || !py || !pz)
                return false;

        float x = (float)atof(px);
        float y = (float)atof(py);
        float z = (float)atof(pz);

        MovePlayer(m_pClient, x, y, z);

        return true;
}


bool ChatHandler::HandleLearnCommand(uint8* args)
{
        NetworkPacket data;

        if (!*args)
                return false;


        uint32 Spell = atol((char*)args);

        Character * pChar = getSelectedChar();
        if(pChar)
        {
                data.Clear();
                data.Initialize( 4, SMSG_LEARNED_SPELL );
                data << Spell;
                pChar->pClient->SendMsg( &data );
                pChar->pClient->getCurrentChar()->addSpell((uint16)Spell);
        }

        return true;
}

bool ChatHandler::HandleAnimFreqCommand(uint8* args)
{
        char* pAnimId = strtok((char*)args, " ");
        if (!pAnimId)
                return false;

        char* pFreq = strtok(NULL, " ");
        if (!pFreq)
                return false;

        uint32 anim_id = atoi(pAnimId);
        float freq = (float)atof(pFreq);


        Unit * pUnit = getSelectedNPC();
        if(pUnit) pUnit->setAnimFrequency( anim_id, freq );

        NetworkPacket data;
        uint8 buf[256];
        sprintf((char *)buf, "NPC UPDATED [%s]", args);
        FillMessageData(&data, 0x09, m_pClient, buf);
        m_pClient->SendMsg( &data );

        return true;
}

bool ChatHandler::HandleStandStateCommand(uint8* args)
{
        if (!*args)
                return false;

        uint32 anim_id = atoi((char*)args);
        m_pClient->getCurrentChar( )->setUpdateValue( UNIT_NPC_EMOTESTATE , anim_id );

        return true;
}

bool ChatHandler::HandleDieCommand(uint8* args)
{
	(void)args;
        // TODO: update other stats as well

        m_pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_HEALTH, 0 );
        m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, 0x10 );
        m_pClient->getCurrentChar( )->setUpdateMaskBit( UNIT_FIELD_MAXHEALTH ); // Ignatich: MAXHEALTH?
        m_pClient->getCurrentChar()->setDeathState(JUST_DIED);

        return true;
}


bool ChatHandler::HandleMorphCommand(uint8* args)
{
        if (!*args)
                return false;

        uint32 display_id = atoi((char*)args);

        // build mask
        UpdateMask updateMask;
        updateMask.SetLength (PLAYER_FIELDS);
        updateMask.SetBit (UNIT_FIELD_DISPLAYID);

        Character * pChar = getSelectedChar();
        if(pChar)
        {
                pChar->setUpdateValue(UNIT_FIELD_DISPLAYID, display_id);
                pChar->UpdateObject( );
                Message(pChar,"DISPLAY",display_id);
                //m_pClient->getCurrentChar()->SendMessageToSet(&data, true);
        }

        return true;
}


bool ChatHandler::HandleAuraCommand(uint8* args)
{
        if (!*args)
                return false;

        uint32 aura_id = atoi((char*)args);

        Character * pChar = getSelectedChar();
        if(pChar)
        {
                pChar->setUpdateValue( UNIT_FIELD_AURA, aura_id );
                pChar->setUpdateValue( UNIT_FIELD_AURAFLAGS, 0x0000000d );
                pChar->setUpdateValue( UNIT_FIELD_AURA+32, aura_id );
                pChar->setUpdateValue( UNIT_FIELD_AURALEVELS+8, 0xeeeeee00 );
                pChar->setUpdateValue( UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00 );
                pChar->setUpdateValue( UNIT_FIELD_AURAFLAGS+4, 0x0000000d );
                pChar->setUpdateValue( UNIT_FIELD_AURASTATE, 0x00000002 );
                pChar->UpdateObject( );
                Message(pChar,"AURA",aura_id);
        }

        return true;
}

/*
 //START OF LINA BAN/UNBAN COMMAND
 bool ChatHandler::HandleUnBanCommand(uint8* args)
 {
 if (!*args) return false;

 DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
 dbi->RemoveIP((char*)args); //FIX HOLE by lina
 DATABASE.removeDatabaseInterface(dbi);

 uint8 buf[256];
 NetworkPacket data;
 sprintf((char*)buf, "You unban IP: %s.", args);
 FillMessageData(&data, 0x09, m_pClient, buf);
 m_pClient->SendMsg( &data );
 return 1;
 }

 bool ChatHandler::HandleBanCommand(uint8* args)
 {
 NetworkPacket data;
 uint8 buf[256];

 if (!*args) return false;

 Character * pChar = getCurrentCharByName(args);
 if (pChar)
 {
 if(m_pClient->getAccountLvl() < pChar->pClient->getAccountLvl())
 {
 Message(pChar, "try to ban");
 return true;
 }
 Message(pChar, "ban");

 char IP[16];

 strcpy(IP,pChar->pClient->getNetwork()->getIP());

 sprintf((char*)buf, "You ban IP: %s.", IP);
 FillMessageData(&data, 0x09, m_pClient, buf);
 m_pClient->SendMsg( &data );

 WORLDSERVER.disconnect_client(reinterpret_cast < Server::nlink_client *> (pChar->pClient->GetNLink()));

 //so_close(chr->pClient->getNetwork()->GetHandle());

 DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
 dbi->BanIP((char*)IP);
 DATABASE.removeDatabaseInterface(dbi);
 }
 return true;
 }

 //END OF LINA BAN/UNBAN COMMAND
 */

bool ChatHandler::HandleIsleCommand(uint8* args)
{
	(void)args;
        smsg_NewWorld(m_pClient, 1, 16220.154297f, 16283.899414f, 13.174583f); //LINA
        return true;
}

bool ChatHandler::HandleUpdateCommand(uint8* args)
{

        NetworkPacket data;

        char* Opcode = strtok((char*)args, " ");
        char* value = strtok(NULL, " ");
        uint32 uOpcode = atoi(Opcode);
        uint32 uValue = atoi(value);

        m_pClient->getCurrentChar()->setUpdateValue(uOpcode,uValue);

        return true;
}
