/////////////////////////////////////////////////
//  Admin Chat Commands
//

#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "WorldServer.h"
#include "Character.h"
#include "Opcodes.h"
#include "Database.h"
#include "GameObject.h"

#define world WorldServer::getSingleton()


bool ChatHandler::HandleSecurityCommand(uint8* args)
{
    char* pName = strtok((char*)args, " ");
    if (!pName)
        return false;
		
	char* pgm = strtok(NULL, " ");
    if (!pgm)
        return false;
		
	uint32 gm = static_cast<uint32>(atoi(pgm));
    if(!TestValue(gm, 5, 0))
		return true;

	Character *pChar = getCurrentCharByName(reinterpret_cast<uint8*>(pName));
	if (pChar)
	{
		
		if(static_cast<uint32>(m_pClient->getAccountLvl()) < gm)
		{
			Message(pChar, "try to lvl account");
			return true;
		}

		Message(pChar,"lvl account",gm);

		pChar->pClient->setAccountLvl(gm);
	
		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		char sql[512];
		sprintf(sql, "update accounts set gm = '%i' where acct = '%u'", gm, pChar->pClient->getAccountID());
		dbi->doQuery(sql);
		Database::getSingleton( ).removeDatabaseInterface(dbi);			
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


/*bool ChatHandler::HandleAddSpiritCommand(uint8* args)
{
	Log::getSingleton() << "Spawning Spirit Healers" << std::endl;
    world.dbi->spawnSpiritHealers();
    return true;
}
*/

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
    wowWData data;

    if (!*args)
        return false;


    uint32 Spell = atol((char*)args);

	Character * pChar = getSelectedChar();
	if(pChar) 
	{
		data.clear();
		data.Initialise( 4, SMSG_LEARNED_SPELL );
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

	wowWData data;
	uint8 buf[256];
	sprintf((char*)buf, "NPC UPDATED", args);
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
    // TODO: update other stats as well
	Character * pChar = getSelectedChar();
	if(pChar)
	{
		pChar->setUpdateValue( UNIT_FIELD_HEALTH, 0 );
		pChar->setUpdateValue( PLAYER_BYTES_2, 0x10 );
		pChar->setUpdateMaskBit( UNIT_FIELD_MAXHEALTH ); // Ignatich: MAXHEALTH?
		pChar->setDeathState(JUST_DIED);
	}
    return true;
}

bool ChatHandler::HandleReviveCommand(uint8* args)
{
	Character * pChar = getSelectedChar();
	if(pChar)
	{
		pChar->setUpdateValue( UNIT_FIELD_FLAGS, (0xffffffff - 65536) & m_pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_FLAGS ) );
		pChar->setUpdateValue( UNIT_FIELD_AURA +32, 0 );
		pChar->setUpdateValue( UNIT_FIELD_AURAFLAGS +4, 0 );
		pChar->setUpdateValue( UNIT_FIELD_AURASTATE, 0 );
		pChar->setUpdateValue( PLAYER_BYTES_2, (0xffffffff - 0x10) & m_pClient->getCurrentChar( )->getUpdateValue( PLAYER_BYTES_2 ) );
		pChar->UpdateObject( );
		pChar->setDeathState(ALIVE);
		pChar->setUpdateValue(UNIT_FIELD_HEALTH, (uint32)pChar->getUpdateValue(UNIT_FIELD_MAXHEALTH)/2 );
		if (pChar->getUpdateValue(UNIT_FIELD_MAXPOWER1) >0)
			pChar->setUpdateValue(UNIT_FIELD_POWER1, (uint32)pChar->getUpdateValue(UNIT_FIELD_MAXPOWER1)/2 );
	}
	return true;
}


bool ChatHandler::HandleMorphCommand(uint8* args)
{
    if (!*args)
        return false;

    uint32 display_id = atoi((char*)args);

	// build mask
	UpdateMask updateMask;
	updateMask.setCount(PLAYER_BLOCKS);
	updateMask.setBit(UNIT_FIELD_DISPLAYID );
	
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

//START OF LINA BAN/UNBAN COMMAND
bool ChatHandler::HandleUnBanCommand(uint8* args)
{              
	if (!*args) return false;

	DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
	dbi->RemoveIP((char*)args); //FIX HOLE by lina
	Database::getSingleton( ).removeDatabaseInterface(dbi);
	
	uint8 buf[256];
	wowWData data;
	sprintf((char*)buf, "You unban IP: %s.", args);
	FillMessageData(&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );
	return 1;
}

bool ChatHandler::HandleBanCommand(uint8* args)
{
	wowWData data;
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

		WorldServer::getSingleton().disconnect_client(reinterpret_cast < Server::nlink_client *> (pChar->pClient->GetNLink())); 
		
		//closesocket(chr->pClient->getNetwork()->getSocketID());

		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
		dbi->BanIP((char*)IP);
		Database::getSingleton( ).removeDatabaseInterface(dbi);
	}				
	return true;
}

//END OF LINA BAN/UNBAN COMMAND

bool ChatHandler::HandleIsleCommand(uint8* args)
{
    smsg_NewWorld(m_pClient, 1, 16220.154297f, 16283.899414f, 13.174583f); //LINA
    return true;
}

bool ChatHandler::HandleUpdateCommand(uint8* args) 
{ 
  
	wowWData data; 
    
	char* Opcode = strtok((char*)args, " "); 
	char* value = strtok(NULL, " "); 
	uint32 uOpcode = atoi(Opcode); 
	uint32 uValue = atoi(value); 
    
	m_pClient->getCurrentChar()->setUpdateValue(uOpcode,uValue); 
    
	return true; 
} 
