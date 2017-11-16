
///////////////////////////////////////////////
//  Admin Movement Commands
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

/* bool ChatHandler::HandleGUIDCommand(uint8* args)
{
    wowWData data;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		char buf[256];
		sprintf(buf,"Guid: %i\nSkin: %i\nFaction: %i\nFlag: %i\nAggressive: %i\n", pUnit->getGUID(), pUnit->getUpdateValue(UNIT_FIELD_DISPLAYID), pUnit->getUpdateValue(UNIT_FIELD_FACTIONTEMPLATE), pUnit->getUpdateValue(UNIT_NPC_FLAGS), pUnit->getAggressive());
		SendMultilineMessage(buf);
	}

    return true;
} */

bool ChatHandler::HandleGUIDCommand(uint8* args) 
{ 
    wowWData data; 

   Unit * pUnit = getSelectedNPC(); 
   if(pUnit) 
   { 
      char buf[256]; 
      sprintf(buf,"Guid: %i\nSkin: %i\nFaction: %i\nFlag: %i\nAggressive: %i\nScale: %i\nHitPoints: %i\nMax HitPoints: %i\n", pUnit->getGUID(), pUnit->getUpdateValue(UNIT_FIELD_DISPLAYID), pUnit->getUpdateValue(UNIT_FIELD_FACTIONTEMPLATE), pUnit->getUpdateValue(UNIT_NPC_FLAGS), pUnit->getAggressive(), pUnit->getUpdateValue(OBJECT_FIELD_SCALE_X), pUnit->getUpdateValue(UNIT_FIELD_HEALTH), pUnit->getUpdateValue(UNIT_FIELD_MAXHEALTH)); 
      SendMultilineMessage(buf); 
   } 

    return true; 
}

bool ChatHandler::HandleNameCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    if(strlen((char*)args)>75)
	{
		uint8 buf[256];
        sprintf((char*)buf,"The name was too long by %i", strlen((char*)args)-75);
        FillMessageData(&data, 0x09, m_pClient, buf);
        m_pClient->SendMsg( &data );
        return true;
    }

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		pUnit->setCreatureName((char*)args);
		uint32 idname=WorldServer::getSingleton().addCreatureName((uint8*)pUnit->getCreatureName());
		ChangeSelectedNPC(OBJECT_FIELD_ENTRY, idname, 65535, 1);
	}
    return true;
}


bool ChatHandler::HandleProgCommand(uint8* args)
{
    smsg_NewWorld(m_pClient, 0, 16843.00f, 16308.00f, 94.00f); //LINA

    return true;
}


bool ChatHandler::HandleItemMoveCommand(uint8* args)
{
	uint8 srcslot, destslot;

    char* pParam1 = strtok((char*)args, " ");
    if (!pParam1)
        return false;

    char* pParam2 = strtok(NULL, " ");
    if (!pParam2)
        return false;

	srcslot = (uint8)atoi(pParam1);
	destslot = (uint8)atoi(pParam2);

    m_pClient->getCurrentChar()->SwapItemInSlot((int)srcslot, (int)destslot);
    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (destslot*2), m_pClient->getCurrentChar()->getGuidBySlot(destslot) );
    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (destslot*2)+1, m_pClient->getCurrentChar()->getGuidBySlot(destslot) == 0 ? 0 : 0x00000040 );

    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2), m_pClient->getCurrentChar()->getGuidBySlot(srcslot) );
    m_pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2)+1, m_pClient->getCurrentChar()->getGuidBySlot(srcslot) == 0 ? 0 : 0x00000040 );

    return true;
}


bool ChatHandler::HandleSpawnCommand(uint8* args)
{
    wowWData data;

    char* pEntry = strtok((char*)args, " ");
    if (!pEntry)
        return false;

/* Ignatich: not safe
    if (pEntry[1]=='x') {
        FillMessageData(&data, 0x09, m_pClient, (uint8*)"Please use decimal.");
        m_pClient->SendMsg( &data );
        return;
        }
*/
    char* pFlags = strtok(NULL, " ");
    if (!pFlags)
        return false;

        char* pFaction = strtok(NULL, " ");
    if (!pFaction)
        return false;

        char* pLevel = strtok(NULL, " ");
    if (!pLevel)
        return false;

        char* pName = strtok(NULL, "%");
    if (!pName)
        return false;

    uint32 npcFlags  = atoi(pFlags);
    uint32 faction_id  = atoi(pFaction);
    uint32 level  = atoi(pLevel);
    uint32 display_id = atoi(pEntry);

    SpawnCreature(m_pClient, pName, display_id, npcFlags, faction_id, level);

    return true;
}


bool ChatHandler::HandleDeleteCommand(uint8* args)
{
    wowWData data;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		const uint32 guid = pUnit->getGUID();
		const uint32 guidh = pUnit->getGUIDHigh();

        data.clear();
        data.Initialise(8, SMSG_DESTROY_OBJECT);
        data << guid << guidh;
		m_pClient->getCurrentChar()->SendMessageToSet(&data, true);

		std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(guid);

		for( WorldServer::CharacterMap::iterator iter = world.mCharacters.begin( ); iter != world.mCharacters.end( ); ++ iter )
			iter->second->RemoveInRangeObject( itr->second );
        
		delete itr->second;
		world.mCreatures.erase(itr);

        DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
        char sql[512];
        sprintf(sql, "DELETE FROM creatures WHERE id=%u", guid);
        dbi->doQuery(sql);
		sprintf(sql, "DELETE FROM creatures_mov WHERE creatureId=%u", guid);
		dbi->doQuery(sql);
		sprintf(sql, "DELETE FROM vendors WHERE vendorGuid=%u", guid);
		dbi->doQuery(sql);
		sprintf(sql, "DELETE FROM trainers WHERE trainerGuid=%u", guid);
		dbi->doQuery(sql);
		sprintf(sql, "DELETE FROM creaturequestrelation WHERE creatureId=%u", guid);
		dbi->doQuery(sql);
        Database::getSingleton( ).removeDatabaseInterface(dbi);
	}
    return true;
}


bool ChatHandler::HandleSpellCommand(uint8* args)
{
    wowWData data;

	char* pspell = strtok((char*)args, " ");
	if (!pspell)
		return false;

	char* pprice = strtok(NULL, " ");
	if (!pprice)
		return false;

	uint32 spell = atoi(pspell);
	uint32 price = atoi(pprice);

	if(price <= 0)
	{
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect price.");
		m_pClient->SendMsg( &data );
		return true;
	}

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		uint32 guid[2];
		guid[0]= pUnit->getGUID();
		guid[1]= pUnit->getGUIDHigh();

		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();
		dbi->addTrainerSpell ( guid, spell, price ); //add spell to trainer
		Database::getSingleton().removeDatabaseInterface( dbi ); //clean up

		uint8 buf[256];
		sprintf((char*)buf,"Spell %i added into trainers %i", spell, pUnit->getGUID());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}

    return true;
}


bool ChatHandler::HandleSpawnTaxiCommand(uint8* args)
{
    SpawnCreature(m_pClient, "Taxi", 20, 8, 1 , 1);

    return true;
}


bool ChatHandler::HandleItemCommand(uint8* args)
{
    wowWData data;

    char* pitem = strtok((char*)args, " ");
    if (!pitem)
        return false;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		const uint32 guid = pUnit->getGUID();

		uint32 item = atoi(pitem);;
		uint32 amount = 1;

		char* pamount = strtok(NULL, " ");
		if (pamount) amount = atoi(pamount);

		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );

		char sql[512];
		sprintf(sql, "insert into vendors values ('%u', '%i', '%i')", guid, (int) item, (int) amount);
		dbi->doQuery(sql);
        
		std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(guid);
		itr->second->setItemId(itr->second->getItemCount() , (int)item);
		itr->second->setItemAmount(itr->second->getItemCount() , (int)amount);
		itr->second->increaseItemCount();
        
		sprintf(sql,"Item %i added into vendors %i", item, pUnit->getGUID());
		FillMessageData(&data, 0x09, m_pClient, (uint8*)sql);
		m_pClient->SendMsg( &data );
	}
    return true;
}

        
bool ChatHandler::HandleAddMoveCommand(uint8* args)
{
    wowWData data;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		const uint32 guid = pUnit->getGUID();

		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		char sql[512];
			
		if(!pUnit->hasWaypoints())
		{
			sprintf(sql, "insert into creatures_mov (creatureId,X,Y,Z) values ('%u', '%f', '%f', '%f')", guid,
			pUnit->getPositionX(),
			pUnit->getPositionY(),
			pUnit->getPositionZ());
			dbi->doQuery(sql);

			pUnit->addWaypoint(pUnit->getPositionX(), pUnit->getPositionY(), pUnit->getPositionZ());
		}

		if (!pUnit->addWaypoint(m_pClient->getCurrentChar()->getPositionX(),
			m_pClient->getCurrentChar()->getPositionY(),
			m_pClient->getCurrentChar()->getPositionZ()))
		{
			FillMessageData(&data, 0x09, m_pClient, (uint8*)"You have allready set all points.");
			m_pClient->SendMsg( &data );

			Database::getSingleton( ).removeDatabaseInterface(dbi);
			return true;
		}

		sprintf(sql, "insert into creatures_mov (creatureId,X,Y,Z) values ('%u', '%f', '%f', '%f')", guid,
		m_pClient->getCurrentChar()->getPositionX(),
		m_pClient->getCurrentChar()->getPositionY(),
		m_pClient->getCurrentChar()->getPositionZ());

		dbi->doQuery(sql);

		Database::getSingleton( ).removeDatabaseInterface(dbi);

		uint8 syntaxError[] = "Waypoint added.";
		FillMessageData(&data, 0x09, m_pClient, syntaxError);
		m_pClient->SendMsg( &data );
	}

    return true;
}


bool ChatHandler::HandleRandomCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if (option != 0 && option != 1)
    {
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );
        FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0 or 1");
        m_pClient->SendMsg( &data );
        return true;
    }

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		char sql[512];
		sprintf(sql, "update creatures set moverandom = '%i' where id = '%u'", option, pUnit->getGUID());
		dbi->doQuery(sql);
		Database::getSingleton( ).removeDatabaseInterface(dbi);

		pUnit->setMoveRandomFlag(option > 0);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg( &data );
	}

    return true;
}


bool ChatHandler::HandleRunCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if(option != 0 && option != 1)
    {
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );
        FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0 or 1");
        m_pClient->SendMsg( &data );
        return true;
    }

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		char sql[512];		
		sprintf(sql, "update creatures set running = '%i' where id = '%u'", option, pUnit->getGUID());
		dbi->doQuery(sql);
		Database::getSingleton( ).removeDatabaseInterface(dbi);

		pUnit->setMoveRunFlag(option > 0);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg( &data );
	}
    return true;
}

//LINA
bool ChatHandler::HandleAggressiveCommand(uint8* args)
{
    wowWData data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if(option < 0 || option > 3)
    {
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );
        FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0, 1, 2, 3");
        m_pClient->SendMsg( &data );
        return true;
    }

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
		char sql[512];		
		sprintf(sql, "update creatures set aggressive = '%i' where id = '%u'", option, pUnit->getGUID());
		dbi->doQuery(sql);
		Database::getSingleton( ).removeDatabaseInterface(dbi);

		pUnit->setAggressive(option);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg( &data );
	}
    return true;
}

bool ChatHandler::HandleChangeLevelCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    uint8 Arg = (uint8) atoi((char*)args);
	ChangeSelectedNPC(UNIT_FIELD_MAXHEALTH, 300 + 20*Arg, 65535, 1);
	ChangeSelectedNPC(UNIT_FIELD_HEALTH, 30 + 20*Arg, 100 + 30*Arg, 1);
	ChangeSelectedNPC(UNIT_FIELD_LEVEL, Arg, 255, 1);

    return true;
}


bool ChatHandler::HandleNPCFlagCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    uint32 Arg = (uint32) atoi((char*)args);

	ChangeSelectedNPC(UNIT_NPC_FLAGS, Arg, 2048, 0);
	return true;
}


bool ChatHandler::HandleDisplayIdCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;
			
    uint32 Arg = (uint32) atoi((char*)args);
	ChangeSelectedNPC(UNIT_FIELD_DISPLAYID, Arg, 8192, 1);
	return true;
}

//THE_WIZARD 
bool ChatHandler::HandleNPChpminCommand(uint8* args) 
{ 
    wowWData data; 

    if (!*args) 
        return false; 
          
    uint32 Arg = (uint32) atoi((char*)args); 
   ChangeSelectedNPC(UNIT_FIELD_HEALTH, Arg, 10000, 1); 
   return true; 
} 

//THE_WIZARD 
bool ChatHandler::HandleNPChpmaxCommand(uint8* args) 
{ 
    wowWData data; 

    if (!*args) 
        return false; 
          
    uint32 Arg = (uint32) atoi((char*)args); 
   ChangeSelectedNPC(UNIT_FIELD_MAXHEALTH, Arg, 10000, 1); 
   return true; 
} 

//THE_WIZARD 
bool ChatHandler::HandleNPCScaleCommand(uint8* args) 
{ 
    wowWData data; 

    if (!*args) 
        return false; 

char scalebefore[256]; 
char scaleafter[256]; 

   Unit * pUnit = getSelectedNPC(); 
    float Arg = (uint32) atoi((char*)args); 
   sprintf(scalebefore,"Scale Before: %i\n", pUnit->getUpdateValue(OBJECT_FIELD_SCALE_X)); 
   ChangeSelectedNPC(OBJECT_FIELD_SCALE_X, (float)Arg, 1090000000, 1050000000);    
   sprintf(scaleafter,"Scale After: %i\n", pUnit->getUpdateValue(OBJECT_FIELD_SCALE_X)); 
   SendMultilineMessage(scalebefore); 
   SendMultilineMessage(scaleafter); 
   return true; 
}

bool ChatHandler::HandleFactionIdCommand(uint8* args)
{
    wowWData data;

    if (!*args)
        return false;

    uint32 Arg = (uint32) atoi((char*)args);
	ChangeSelectedNPC(UNIT_FIELD_FACTIONTEMPLATE, Arg, 32, 0);
	return true;
}


bool ChatHandler::HandleRemoveSpellCommand(uint8* args)
{
    wowWData data;

	char* pspell = strtok((char*)args, " ");
	if (!pspell)
		return false;

	uint32 spell = atoi(pspell);

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		uint8 buf[256];
		sprintf((char*)buf,"delete from trainers where (trainerGuid='%i') AND (spellGuid='%i')", pUnit->getGUID(), spell);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );

		sprintf((char*)buf,"Spell %i removed from vendors %i", spell, pUnit->getGUID());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
    return true;
}

bool ChatHandler::HandleRemoveItemCommand(uint8* args)
{
    wowWData data;

    char* pitem = strtok((char*)args, " ");
    if (!pitem)
        return false;

	uint32 item = atoi(pitem);

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		uint8 buf[256];
		sprintf((char*)buf,"delete from vendor where (vendorGuid='%i') AND (itemGuid='%i')", pUnit->getGUID(), item);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );

		sprintf((char*)buf,"Item %i removed from vendors %i", item, pUnit->getGUID());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
    return true;
}
    