#include "StdAfx.h"

// Copyright (C) 2004 WoW Daemon
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

#include "../Shared/PacketBuilder.h"

/////////////////////////////////////////////////
//  Admin Chat Commands
//

//-----------------------------------------------------------------------------
bool ChatHandler::HandleSecurityCommand(const char* args)
{
    WorldPacket data;

    char* pName = strtok((char*)args, " ");
    if (!pName)
        return false;

    char* pgm = strtok(NULL, " ");
    if (!pgm)
        return false;

    int8 gm = (uint8) hex_or_decimal(pgm);
    if ( gm < 0 || gm > 5)
    {
        FillSystemMessageData(&data, m_session, "Incorrect value.");
        m_session->SendPacket( &data );
        return true;
    }

    char buf[256];

    Player *chr = objmgr.GetPlayer(args);
    if (chr)
    {
        // send message to user
        sprintf((char*)buf,"You change security level of %s to %i.", chr->GetName(), gm);
        FillSystemMessageData(&data, m_session, buf);
        m_session->SendPacket( &data );

        // send message to player
        sprintf((char*)buf,"%s changed your security level to %i.", m_session->GetPlayer()->GetName(), gm);
        FillSystemMessageData(&data, m_session, buf);

        chr->GetSession()->SendPacket(&data);
        chr->GetSession()->SetSecurity(gm);

        char sql[512];
        sprintf(sql, "UPDATE accounts SET gm = '%i' WHERE acct = '%u'", gm, chr->GetSession()->GetAccountId());
        sDatabase.Execute( sql );
    }
    else
    {
        sprintf((char*)buf,"Player (%s) does not exist or is not logged in.", pName);
        FillSystemMessageData(&data, m_session, buf);
        m_session->SendPacket( &data );
    }

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleWorldPortCommand(const char* args)
{
    char* pContinent = strtok((char*)args, " ");
    if (!pContinent)
        return false;

    char* px = strtok(NULL, " ");
    char* py = strtok(NULL, " ");
    char* pz = strtok(NULL, " ");

    if (!px || !py || !pz)
        return false;

    m_session->GetPlayer()->TeleportFar (atoi(pContinent),
		(float)atof(px), (float)atof(py), (float)atof(pz));

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleAddSpiritCommand(const char* args)
{/*
    Log::getSingleton( ).outDetail("Spawning Spirit Healers\n");

    std::stringstream query;
    Creature* pCreature;
    UpdateMask unitMask;
    WorldPacket data;

    query << "select X,Y,Z,F,name_id,mapId,zoneId,faction_id from spirithealers";
    QueryResult *result = sDatabase.Query( query.str( ).c_str( ) );

    if(!result)
    {
        FillSystemMessageData(&data, m_session, "No spirit healers in db, exiting.");
        m_session->SendPacket( &data );

        return true;
    }

    uint32 name;
    do
    {
        Field* fields = result->Fetch();

        name = fields[4].GetUInt32();
        Log::getSingleton( ).outDetail("%s name is %d\n", fields[4].GetString(), name);

        pCreature = new Creature();

		CreatureTemplate *ct = objmgr.GetCreatureName(name);
        pCreature->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), ct->Name.c_str(), fields[5].GetUInt16(),
            fields[0].GetFloat(), fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat());

        pCreature->SetZoneId( fields[6].GetUInt16() );
        pCreature->SetUInt32Value( OBJECT_FIELD_ENTRY, name );
        pCreature->SetFloatValue( OBJECT_FIELD_SCALE_X, 1.0f );
        pCreature->SetUInt32Value( UNIT_FIELD_DISPLAYID, 5233 );
        pCreature->SetUInt32Value( UNIT_NPC_FLAGS , 1 );
        pCreature->SetUInt32Value( UNIT_FIELD_FACTIONTEMPLATE , fields[7].GetUInt32() );
        pCreature->SetUInt32Value( UNIT_FIELD_HEALTH, 100 + 30*(60) );
        pCreature->SetUInt32Value( UNIT_FIELD_MAXHEALTH, 100 + 30*(60) );
        pCreature->SetUInt32Value( UNIT_FIELD_LEVEL , 60 );
        pCreature->SetFloatValue( UNIT_FIELD_COMBATREACH , 1.5f );
        pCreature->SetUInt32Value( UNIT_FIELD_MAXDAMAGE ,  5.0f );
        pCreature->SetUInt32Value( UNIT_FIELD_MINDAMAGE , 8.0f );
        pCreature->SetUInt32Value( UNIT_FIELD_BASEATTACKTIME, 1900 );
        pCreature->SetUInt32Value( UNIT_FIELD_BASEATTACKTIME+1, 2000 );
        pCreature->SetFloatValue( UNIT_FIELD_BOUNDINGRADIUS, 2.0f );

        objmgr.AddObject(pCreature);
        pCreature->PlaceOnMap();

        pCreature->SaveToDB();
    }
    while( result->NextRow() );

    delete result;
*/
    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleMoveCommand(const char* args)
{
    char* px = strtok((char*)args, " ");
    char* py = strtok(NULL, " ");
    char* pz = strtok(NULL, " ");

    if (!px || !py || !pz)
        return false;

    float x = (float)atof(px);
    float y = (float)atof(py);
    float z = (float)atof(pz);

    //MovePlayer(m_session, x, y, z);
	m_session->GetPlayer()->TeleportNear (x, y, z);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_GoGUID (const char* args)
{
	uint64	guid = hex2guid (args);

	Object * o = objmgr.GetObject<Creature> (guid /*+ uint64 (HIGHGUID_UNIT) << 32*/);
	if (o == NULL) o = objmgr.GetObject<GameObject> (guid /*+ uint64 (HIGHGUID_GAMEOBJECT) << 32*/);
	if (o == NULL) o = objmgr.GetObject<Corpse> (guid /*+ uint64 (HIGHGUID_CORPSE) << 32*/);
	if (o == NULL) o = objmgr.GetObject<Player> (guid);

	if (o == NULL)
	{
		m_session->SystemMessage (".GOGUID %I64X - Unit, GameObj, Player or Corpse doesn't exist", guid);
		return true;
	}

	m_session->GetPlayer()->TeleportFar (o->GetMapId(),
		o->GetPositionX(), o->GetPositionY(), o->GetPositionZ());

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Modify_Spell (const char* args)
{
	WorldPacket data;

	if (!*args) return false;

	int32 spell = atol((char*)args);
	uint64 guid = m_session->GetPlayer()->GetSelection();

	Player * target = objmgr.GetObject<Player>(guid);
	Player * player = m_session->GetPlayer();

	if (target == NULL)
	{
		FillSystemMessageData(&data, m_session, "You should select player to teach spell.");
		m_session->SendPacket( &data );
		return true;
	}

	// Add or remove player spell
	//
	if (spell > 0) {
		if (target != NULL) {
			if (target->AddSpell (spell)) {
				data.Initialize (SMSG_LEARNED_SPELL);
				data << (uint32)spell;
				target->GetSession()->SendPacket( &data );

				Make_SMSG_SPELL_GO (&data, 476, player, target);
				player->SendMessageToSet (&data, true);
			}
			else {
				target->GetSession()->SystemMessage ("Can't teach already known spell %d", spell);
			}
		}
	}
	else
	{
		spell = -spell;

		if (target->RemoveSpell (spell)) {
			data.Initialize( SMSG_SUPERCEDED_SPELL );
			data << (uint32)spell;
			m_session->SendPacket( &data );
			m_session->SystemMessage ("Unlearned spell %d", spell);

			Make_SMSG_SPELL_GO (&data, 476, player, target);
			player->SendMessageToSet (&data, true);
		}
		else {
			m_session->SystemMessage ("Can't unlearn unknown spell %d", spell);
		}
	}

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Modify_Skill (const char* args)
{
    WorldPacket data;

    if (!*args) return false;

    int32	skill = 0;
	uint16	level = 0;
	char	args1[512];
	strcpy (args1, args);

	char	* p = strtok (args1, " ");
	if (p != NULL)
	{
		skill = atol (p);
		p = strtok (NULL, " ");
		if (p != NULL) {
			level = atoi (p);
		}
	}

	if (skill == 0) {
		m_session->SystemMessage ("Please specify skill id to learn and (not mandatory) skill mastery level parameter.");
		return true;
	}
	if (level == 0) level = 1;

	uint64 guid = m_session->GetPlayer()->GetSelection();

	Player * target = objmgr.GetObject<Player>(guid);
	Player * player = m_session->GetPlayer();

	if (target == NULL)
	{
		m_session->SystemMessage ("You should select player to teach skill.");
		return true;
	}

	// Add or remove player spell
	//
	if (skill > 0) {
		if (target != NULL) {
			if (target->AddSkill (skill, level)) 
			{
				Make_SMSG_SPELL_GO (&data, 476, player, target);
				player->SendMessageToSet (&data, true);
			}
			else {
				target->GetSession()->SystemMessage ("Can't teach already known skill %d", skill);
			}
		}
	}
	else
	{
		skill = -skill;

		if (target->RemoveSkill (skill)) {
			m_session->SystemMessage ("Unlearned skill %d", skill);

			Make_SMSG_SPELL_GO (&data, 476, player, target);
			player->SendMessageToSet (&data, true);
		}
		else {
			m_session->SystemMessage ("Can't unlearn unknown skill %d", skill);
		}
	}

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleObjectCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint32 entry = hex_or_decimal((char*)args);
	char* safe = strtok((char*)args, " ");

	// Get gameobject template from database
	//
	std::stringstream query;
	query << "SELECT model, faction, gtype, size FROM gameobj_def WHERE obj_id=" << entry;
	
	QueryResult* result = sDatabase.Query( query.str().c_str() );
	if (!result) {
		m_session->SystemMessage ("Gameobject template %d not found.", entry);
		return true;
	}

	uint32	model = (*result)[0].GetUInt32();
	uint16	faction = (*result)[1].GetUInt16();
	uint16	gtype = (*result)[2].GetUInt16();
	float	size = (*result)[3].GetFloat();
	delete result;

	//Get player location
	//
    Player *chr = m_session->GetPlayer();
    float x = chr->GetPositionX();
    float y = chr->GetPositionY();
    float z = chr->GetPositionZ();
    float o = chr->GetOrientation();

    GameObject* pGameObj = new GameObject();

    // uint32 guidlow, uint16 display_id, float x, float y, float z, float ang
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT),
		model,
		1,					// uint8 state
		entry,				// uint32 obj_field_entry
		size,				// uint8 scale
		gtype,				// uint16 type
		faction,			// uint16 faction
		chr->GetMapId(), x, y, z, o );


    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    if(strcmp(safe,"true") == 0)
        pGameObj->SaveToDB();

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleAnimCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint32 anim_id = hex_or_decimal((char*)args);

    data.Initialize( SMSG_EMOTE );
    data << anim_id << m_session->GetPlayer( )->GetGUID();
    WPAssert(data.size() == 12);
    m_session->GetPlayer()->SendMessageToSet(&data, true);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleStandStateCommand(const char* args)
{
    if (!*args)
        return false;

    uint32 anim_id = hex_or_decimal((char*)args);
    m_session->GetPlayer( )->SetUInt32Value( UNIT_NPC_EMOTESTATE , anim_id );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleDieCommand(const char* args)
{
    // TODO: update other stats as well

    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_HEALTH, 0 );
    m_session->GetPlayer( )->SetUInt32Value( PLAYER_BYTES_2, 0x10 );
    m_session->GetPlayer()->setDeathState(JUST_DIED);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleReviveCommand(const char* args)
{
    // Just for testing
	Player * plr = m_session->GetPlayer();

    plr->SetUInt32Value( UNIT_FIELD_FLAGS, (0xffffffff - 65536) & plr->GetUInt32Value( UNIT_FIELD_FLAGS ) );
    plr->SetUInt32Value( UNIT_FIELD_AURA +32, 0 );
    plr->SetUInt32Value( UNIT_FIELD_AURAFLAGS +4, 0 );
    plr->SetUInt32Value( UNIT_FIELD_AURASTATE, 0 );
    plr->SetUInt32Value( PLAYER_BYTES_2, (0xffffffff - 0x10) & plr->GetUInt32Value( PLAYER_BYTES_2 ) );
    //plr->UpdateObject( );

	plr->setDeathState(ALIVE);
	plr->RemoveFlag (PLAYER_FLAGS, PLAYER_FLAG_DEAD);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleMorphCommand(const char* args)
{
    if (!*args)
        return false;

    uint16 display_id = (uint16)hex_or_decimal((char*)args);

    m_session->GetPlayer()->SetUInt32Value(UNIT_FIELD_DISPLAYID, display_id);
    //m_session->GetPlayer()->UpdateObject( );
    //m_session->GetPlayer()->SendMessageToSet(&data, true);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleAuraCommand(const char* args)
{
    if (!*args)
        return false;

    uint32 aura_id = hex_or_decimal((char*)args);

    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURA, aura_id );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURAFLAGS, 0x0000000d );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURA+32, aura_id );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURALEVELS+8, 0xeeeeee00 );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00 );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURAFLAGS+4, 0x0000000d );
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_AURASTATE, 0x00000002 );
    //m_session->GetPlayer()->UpdateObject( );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleAddGraveCommand(const char* args)
{
    QueryResult *result;
    std::stringstream ss;
    GraveyardTeleport *pGrave;

    ss.rdbuf()->str("");
    pGrave = new GraveyardTeleport;

    result = sDatabase.Query( "SELECT MAX(ID) FROM graveyards" );
    if( result )
    {
        pGrave->ID = (*result)[0].GetUInt32()+1;

        delete result;
    }
    pGrave->X = m_session->GetPlayer()->GetPositionX();
    pGrave->Y = m_session->GetPlayer()->GetPositionY();
    pGrave->Z = m_session->GetPlayer()->GetPositionZ();
    pGrave->O = m_session->GetPlayer()->GetOrientation();
    pGrave->ZoneId = m_session->GetPlayer()->GetZoneId();
    pGrave->MapId = m_session->GetPlayer()->GetMapId();
    pGrave->FactionID = 0;

    ss << "INSERT INTO graveyards ( X, Y, Z, O, zoneId, mapId) VALUES ("
        << pGrave->X << ", "
        << pGrave->Y << ", "
        << pGrave->Z << ", "
        << pGrave->O<< ", "
        << pGrave->ZoneId << ", "
        << pGrave->MapId << ")";

    sDatabase.Execute( ss.str( ).c_str( ) );

    objmgr.AddGraveyard(pGrave);
    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleAddSHCommand(const char *args)
{/*
    WorldPacket data;

    // Create the requested monster
    Player *chr = m_session->GetPlayer();
    float x = chr->GetPositionX();
    float y = chr->GetPositionY();
    float z = chr->GetPositionZ();
    float o = chr->GetOrientation();

    Creature* pCreature = new Creature();

    pCreature->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), "Spirit Healer", chr->GetMapId(), x, y, z, o);
    pCreature->SetZoneId(chr->GetZoneId());
    pCreature->SetUInt32Value(OBJECT_FIELD_ENTRY, objmgr.AddCreatureName(pCreature->GetName(), 5233));
    pCreature->SetFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
    pCreature->SetUInt32Value(UNIT_FIELD_DISPLAYID, 5233);
    pCreature->SetUInt32Value(UNIT_NPC_FLAGS, 33);
    pCreature->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE , 35);
    pCreature->SetUInt32Value(UNIT_FIELD_HEALTH, 100);
    pCreature->SetUInt32Value(UNIT_FIELD_MAXHEALTH, 100);
    pCreature->SetUInt32Value(UNIT_FIELD_LEVEL, 60);
    pCreature->SetUInt32Value(UNIT_FIELD_FLAGS, 768);
    pCreature->SetUInt32Value(UNIT_FIELD_AURA+0, 10848);
    pCreature->SetUInt32Value(UNIT_FIELD_AURALEVELS+0, 0xEEEEEE3C);
    pCreature->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+0, 0xEEEEEE00);
    pCreature->SetUInt32Value(UNIT_FIELD_AURAFLAGS+0, 0x00000009);
    pCreature->SetFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
    pCreature->SetFloatValue(UNIT_FIELD_MAXDAMAGE ,  5.0f);
    pCreature->SetFloatValue(UNIT_FIELD_MINDAMAGE , 8.0f);
    pCreature->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, 1900);
    pCreature->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, 2000);
    pCreature->SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);
    objmgr.AddObject(pCreature);
	pCreature->PlaceOnMap();
    pCreature->SaveToDB();
*/
    return true;
}


//-----------------------------------------------------------------------------
bool ChatHandler::HandleSpawnTransportCommand(const char* args)
{
    GameObject* pGameObj = new GameObject();
    // uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction, uint32 mapid, float x, float y, float z, float ang
    // Freewind Post Elevators
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 11898, 1, 11, 1, 1, float(-5399.188477), float(-2504.615967), float(89.021133), float(2.609266) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 11899, 1, 11, 1, 1, float(-5382.495605), float(-2489.417480), float(-40.528416), float(2.364921) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    // Undercity Elevators and Doors
    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20657, 1, 11, 1, 0, float(1533.879395), float(240.823593), float(-32.347244), float(3.132866) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20656, 1, 11, 1, 0, float(1553.299194), float(240.654114), float(55.395279), float(-0.008727) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 455, 1, 20655, 1, 11, 1, 0, float(1544.237183), float(240.770660), float(-40.783455), float(-0.008727) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20654, 1, 11, 1, 0, float(1595.213013), float(178.691315), float(-40.522171), float(-1.579524) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20653, 1, 11, 1, 0, float(1595.379028), float(197.704514), float(55.395279), float(1.562070) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 455, 1, 20652, 1, 11, 1, 0, float(1595.262451), float(188.642441), float(-40.783455), float(1.562070) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20651, 1, 11, 1, 0, float(1596.209961), float(302.398712), float(-40.664421), float(1.562070) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 462, 1, 20650, 1, 11, 1, 0, float(1596.038452), float(282.735748), float(55.395290), float(-1.579524) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 455, 1, 20649, 1, 11, 1, 0, float(1596.209961), float(291.797821), float(14.682331), float(-1.579524) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    // The Great Lift Elevators
    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 11899, 1, 11, 1, 1, float(-4670.772461), float(-1849.608398), float(-44.144260), float(-0.183260) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 11898, 1, 11, 1, 1, float(-4665.432617), float(-1827.673706), float(85.405289), float(0.061086) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    // Thunderbluff Elevators
    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 47297, 1, 11, 1, 1, float(-1037.266113), float(-49.235500), float(140.494644), float(3.071780) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 47296, 1, 11, 1, 1, float(-1028.043335), float(-28.356815), float(69.022560), float(2.914700) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 4171, 1, 11, 1, 1, float(-1308.377075), float(185.288116), float(68.585815), float(-0.270525) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 360, 1, 4170, 1, 11, 1, 1, float(-1286.240723), float(189.718201), float(130.079819), float(-1.073379) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();
    pGameObj->SaveToDB();

    // Tram
    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176080, 1, 11, 1, 369, float(4.580645), float(28.209660), float(6.905265), float(1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176081, 1, 11, 1, 369, float(4.528066), float(8.435292), float(6.905265), float(1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176082, 1, 11, 1, 369, float(-45.400524), float(2492.792236), float(6.905265), float(1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176083, 1, 11, 1, 369, float(-45.400742), float(2512.148193), float(6.905265), float(1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176084, 1, 11, 1, 369, float(-45.393375), float(2472.930908), float(6.905265), float(1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    pGameObj = new GameObject();
    pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), 3831, 1, 176085, 1, 11, 1, 369, float(4.498831), float(-11.347507), float(6.905265), float(-1.570796) );
    pGameObj->SetUInt32Value(GAMEOBJECT_FLAGS,40);
    objmgr.AddObject(pGameObj);
    pGameObj->PlaceOnMap();

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleInvisCommand (const char* args) 
{
	Player *p = m_session->GetPlayer();
	if (p->m_gmInvisible) {
		p->m_gmInvisible = false;
		m_session->SystemMessage ("You are visible now");
		
		// Send special update packet to appear
		//p->BuildCreateUpdateBlockForPlayer();
	} 
	else {
		p->m_gmInvisible = true;
		m_session->SystemMessage ("You are invisible now");
		
		// TODO: Send special cleanup packet to hide
		//p->HideFromPlayers();
	}
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_ImportWorld (const char* args) 
{
	//-----------------------------------------------
	//Log::getSingleton().outDetail ("Clearing world out of creatures and gameobjects");
	//objmgr.InstantBlankWorld();

	//-----------------------------------------------
	Log::getSingleton().outDetail ("Importing NPC list '%s'", args);

	char buff[2048];
	FILE *f = fopen ("world_spawns.txt", "rt");
	if (f == NULL) {
		m_session->SystemMessage ("Can't open creature spawns file 'world_spawns.txt'");
		return true;
	}

	m_session->SystemMessage ("Creature spawns import started, please wait... "
		"(Server may crash at the end of import - this is known bug and no threat to world database)");

	// skip 1st line
	fgets (buff, sizeof (buff)-1, f);

	char	*p;
	uint32	Entry, MapId;
	uint16	SpawnT[2];
	float	X, Y, Z, Orient, SpawnD[2];
	uint32	count = 0;

	CreatureTemplate	*ct;
	Creature			*pCreature;

#define NEXTFIELD p = strtok (NULL, ";"); if (p == NULL) continue

	while (!feof (f)) {
		if (fgets (buff, sizeof (buff)-1, f) == NULL) break;

		// Entry;MapId,X,Y,Z,Orientation,SpawnTime1,2,SpawnDist1,2
		p = strtok (buff, ";");
		if (p == NULL) continue;
		Entry = atoi (p);

		NEXTFIELD; MapId = atoi (p);
		NEXTFIELD; X = (float)atof (p);
		NEXTFIELD; Y = (float)atof (p);
		NEXTFIELD; Z = (float)atof (p);
		NEXTFIELD; Orient = (float)atof (p);
		NEXTFIELD; SpawnT[0] = atoi (p);
		NEXTFIELD; SpawnT[1] = atoi (p);
		NEXTFIELD; SpawnD[0] = (float)atof (p);
		NEXTFIELD; SpawnD[1] = (float)atof (p);

#undef NEXTFIELD

		if (MapId <= 1) {	// Import only for major continents, no instances
			// Check XY range for new creature
			MapMgr *mapMgr = sWorld.GetMap (MapId);

			if (X > mapMgr->_maxX || X < mapMgr->_minX ||
				Y > mapMgr->_maxY || Y < mapMgr->_minY)
			{
				Log::getSingleton().outDetail ("ERR: Skipped creature out of map at (%.1f, %.1f) mapid=%d",
					X, Y, MapId);
				continue;
			}

			ct = objmgr.GetCreatureTemplate (Entry, false);
			if (ct == NULL) {
				Log::getSingleton().outError ("Erm... can't find creature template %d -- skipped", Entry);
				continue;
			}

			pCreature = SpawnCreature (m_session, ct, MapId, X, Y, Z, Orient);
			pCreature->m_spawnTime[0] = SpawnT[0];
			pCreature->m_spawnTime[1] = SpawnT[1];
			pCreature->m_spawnDist = SpawnD[1];
			pCreature->SaveToDB();
		}

		count++;
		if (count % 5000 == 0) {
			m_session->SystemMessage ("  -> importing... %d spawns processed", count);
		}
	}

	fclose(f);

	//-----------------------------------------------
	m_session->SystemMessage ("World import finished - %d spawns", count);

	Log::getSingleton().outDetail ("Finished");
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_ImportGameobj (const char* args) 
{
	//-----------------------------------------------
	Log::getSingleton().outDetail ("Importing Gameobjects list '%s'", args);

	char buff[2048];
	FILE *f = fopen ("world_gameobj.txt", "rt");
	if (f == NULL) {
		m_session->SystemMessage ("Can't open import file 'world_gameobj.txt'");
		return true;
	}

	m_session->SystemMessage ("Gameobjects Import started, please wait... "
		"(Server may crash at the end of import - this is known bug and no threat to world database)");

	// skip 1st line
	fgets (buff, sizeof (buff)-1, f);

	char	*p;
	uint32	Entry, MapId;
	uint16	SpawnT[2];
	float	X, Y, Z, Orient, SpawnD[2];
	uint32	count = 0;

	//GameObject	*gobj;

#define NEXTFIELD p = strtok (NULL, ";"); if (p == NULL) continue

	while (!feof (f)) {
		if (fgets (buff, sizeof (buff)-1, f) == NULL) break;

		// Entry;MapId,X,Y,Z,Orientation,SpawnTime1,2,SpawnDist1,2
		p = strtok (buff, ";");
		if (p == NULL) continue;
		Entry = atoi (p);

		NEXTFIELD; MapId = atoi (p);
		NEXTFIELD; X = (float)atof (p);
		NEXTFIELD; Y = (float)atof (p);
		NEXTFIELD; Z = (float)atof (p);
		NEXTFIELD; Orient = (float)atof (p);
		NEXTFIELD; SpawnT[0] = atoi (p);
		NEXTFIELD; SpawnT[1] = atoi (p);
		NEXTFIELD; SpawnD[0] = (float)atof (p);
		NEXTFIELD; SpawnD[1] = (float)atof (p);

#undef NEXTFIELD

		if (MapId <= 1)	// Import only for major continents, no instances
		{	
			// Get gameobject template from database
			//
			std::stringstream query;
			query << "SELECT model, faction, gtype, size FROM gameobj_def WHERE obj_id=" << Entry;

			QueryResult* result = sDatabase.Query( query.str().c_str() );
			if (!result) {
				m_session->SystemMessage ("Gameobject template %d not found.", Entry);
				continue;
			}

			uint32	model = (*result)[0].GetUInt32();
			uint16	faction = (*result)[1].GetUInt16();
			uint16	gtype = (*result)[2].GetUInt16();
			float	size = (*result)[3].GetFloat();
			delete result;
			
			// Check XY range for new gameobject
			MapMgr *mapMgr = sWorld.GetMap (MapId);

			if (X > mapMgr->_maxX || X < mapMgr->_minX ||
				Y > mapMgr->_maxY || Y < mapMgr->_minY)
			{
				Log::getSingleton().outDetail ("ERR: Skipped gameobject out of map at (%.1f, %.1f) mapid=%d",
					X, Y, MapId);
				continue;
			}
			
			GameObject* pGameObj = new GameObject();

			// uint32 guidlow, uint16 display_id, float x, float y, float z, float ang
			pGameObj->Create (objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT),
				model,
				1,					// uint8 state
				Entry,				// uint32 obj_field_entry
				size,				// uint8 scale
				gtype,				// uint16 type
				faction,			// uint16 faction
				MapId, X, Y, Z, Orient );

			//pGameObj->SetZoneId (objmgr.LookupZoneId (MapId, X, Y));
			objmgr.AddObject(pGameObj);
			pGameObj->PlaceOnMap();
			pGameObj->SaveToDB();
		}

		count++;
		if (count % 5000 == 0) {
			m_session->SystemMessage ("  -> importing... %d gameobjects processed", count);
		}
	}

	fclose(f);

	//-----------------------------------------------
	m_session->SystemMessage ("Gameobjects import finished - %d gameobjects", count);

	Log::getSingleton().outDetail ("Finished");
	return true;
}

//--- END ---