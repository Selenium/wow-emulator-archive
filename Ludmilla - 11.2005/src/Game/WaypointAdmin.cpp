#include "StdAfx.h"

//-----------------------------------------------------------------------------
WaypointIndicator *ChatHandler::SpawnWaypointIndicator (float x, float y, float z, uint32 index)
{
    WorldPacket data;
	Player *chr = m_session->GetPlayer();

    // Create the requested monster
    WaypointIndicator* pWP = new WaypointIndicator();
	
	uint32 displayId = 6271;	// Goblin Land Mine model

	char name[64];
	sprintf (name, "Waypoint #%d", index);

	pWP->Create (objmgr.GenerateLowGuid(HIGHGUID_UNIT), name, chr->GetMapId(), x, y, z, 0);
    pWP->SetZoneId (chr->GetZoneId());
    pWP->SetUInt32Value (OBJECT_FIELD_ENTRY, WAYPOINT_NPC_ID + index);
    pWP->SetFloatValue (OBJECT_FIELD_SCALE_X, 0.3f);
    pWP->SetUInt32Value (UNIT_FIELD_DISPLAYID, displayId);
    pWP->SetUInt32Value (UNIT_NPC_FLAGS, 0);
    pWP->SetUInt32Value (UNIT_FIELD_FACTIONTEMPLATE, 35);
    
	pWP->SetHealth (1);
    pWP->SetMaxHealth (1);
    pWP->SetLevel (1);
	pWP->SetUInt32Value (UNIT_FIELD_FLAGS, UNIT_FLAG_NOT_ATTACKABLE_1);

	pWP->SetFloatValue (UNIT_FIELD_BOUNDINGRADIUS, 0.1f);
	pWP->SetFloatValue (UNIT_FIELD_COMBATREACH, 0.1f);
    pWP->SetMinDamage (0);
	pWP->SetMaxDamage (0);
    pWP->SetUInt32Value (UNIT_FIELD_BASEATTACKTIME, 2000);
    pWP->SetUInt32Value (UNIT_FIELD_BASEATTACKTIME+1, 2000);
    pWP->SetFloatValue (UNIT_FIELD_BOUNDINGRADIUS, 0.2f);

    objmgr.AddObject ((Creature *)pWP);
    pWP->PlaceOnMap();
	pWP->AddToWorld();
	m_wpIndicators.push_back (pWP);

	return pWP;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Info (const char *args)
{
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select mob first.");
		return true;
	}

	Creature *pCreature = objmgr.GetObject<Creature>(guid);

	if (IS_WAYPOINT (pCreature)) {
		// Waypoint information
		//
		WaypointIndicator	*wpi = (WaypointIndicator *)pCreature;
		Waypoint &wp = wpi->m_wpOwner->m_waypoints[wpi->m_wpIndex];

		m_session->SystemMessage ("Selected waypoint #%d, wait time: %d..%d",
			wpi->m_wpIndex, wp.Wait1, wp.Wait2);
	} else {
		// Creature information
		//
		char movement[64];
		
		switch (pCreature->m_movementType) 
		{
		case Creature::FLAT_RANDOM_ROAM:
			strcpy (movement, "Flat Random roam");
			break;
		case Creature::RANDOM_ROAM:
			strcpy (movement, "Random roam");
			break;
		case Creature::FOLLOW_PATH_FORTH:
			strcpy (movement, "Follow path");
			break;
		case Creature::FOLLOW_PATH_BACK:
			strcpy (movement, "Follow path back");
			break;
		case Creature::LOOP_PATH_FORTH:
			strcpy (movement, "Loop path forward");
			break;
		case Creature::LOOP_PATH_BACK:
			strcpy (movement, "Loop path backward");
			break;
		default:
			sprintf (movement, "Unknown (%d)", pCreature->m_movementType);
		}

		m_session->SystemMessage ("Selected mob GUID=%X has %d waypoint(s), movement type: %s",
			pCreature->GetGUIDLow(), pCreature->m_waypoints.size(), movement);
	}

	return true;
}

//-----------------------------------------------------------------------------
void ChatHandler::_recreateCreatureWaypointIndicators (Creature *cr)
{
	if (cr == NULL) return;
	if (cr->m_waypoints.empty()) return;

	for (uint32 i = 0; i < cr->m_waypoints.size(); i++)
	{
		Waypoint &wp = cr->m_waypoints[i];
		WaypointIndicator *wpobj = SpawnWaypointIndicator (wp.x, wp.y, wp.z, i);

		// Store waypoint owner Creature and its index
		wpobj->m_wpOwner = cr;
		wpobj->m_wpIndex = i;
	}
}

//-----------------------------------------------------------------------------
void ChatHandler::_resaveWaypoints (Creature *cr) 
{
	uint64 guid = cr->GetGUID();

	std::stringstream	ss1, ss2;

	// creatureId meant to be GUID
	ss1 << "DELETE FROM creatures_mov WHERE creatureId=" << GUID_LOPART (guid);
	sDatabase.Execute (ss1.str().c_str());

	ss2 << "INSERT INTO creatures_mov (id, creatureId, X, Y, Z, WaitTime1, WaitTime2) VALUES ";
	Player *player = m_session->GetPlayer();
	for (uint32 i = 0; i < cr->m_waypoints.size(); i++)
	{
		ss2 << "(NULL, " << GUID_LOPART (guid) << ", " << cr->m_waypoints[i].x
			<< ", " << cr->m_waypoints[i].y << ", " << cr->m_waypoints[i].z
			<< ", " << (uint32)cr->m_waypoints[i].Wait1 << ", "
			<< (uint32)cr->m_waypoints[i].Wait2 << ")";

		if (i < cr->m_waypoints.size() - 1)
			ss2 << ", ";
	}

	sDatabase.Execute (ss2.str().c_str());
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Show (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select NPC first.");
		return true;
	}

	Creature *pCreature = objmgr.GetObject<Creature>(guid);

	if (pCreature == NULL) {
		m_session->SystemMessage ("No selection, select NPC first.");
		return true;
	}
	if (IS_WAYPOINT (pCreature))
	//if (pCreature->GetUInt32Value (UNIT_NPC_FLAGS) & WAYPOINT_NPC_FLAG != 0)
	{
		pCreature = ((WaypointIndicator *)pCreature)->m_wpOwner;
	}

	Command_WP_Hide (NULL);
	_recreateCreatureWaypointIndicators (pCreature);

	if (args != NULL)
		m_session->SystemMessage ("Turned on display of waypoints for selected NPC");

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Hide (const char *args)
{
	// Clean old WP names and clean old WP markup
	std::stringstream ss;
	ss << "DELETE FROM creature_names WHERE displayId=0";
	sDatabase.Execute (ss.str().c_str());

	WaypointIndicatorList::iterator	iter;

	while (!m_wpIndicators.empty()) {
		WaypointIndicator *wpi = *(m_wpIndicators.begin());
		m_wpIndicators.pop_front();

		wpi->RemoveFromMap();
		wpi->RemoveFromWorld();
		objmgr.RemoveObject_Free ((Creature *)wpi);
		//delete wpi;
	}

	if (args != NULL)
		m_session->SystemMessage ("Removed waypoint indicators from the world");

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Come (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select waypoint first.");
		return true;
	}

	// Find selected waypoint and calculate its owner
	WaypointIndicator *wpi = (WaypointIndicator *)objmgr.GetObject<Creature>(guid);
	if (wpi == NULL || !IS_WAYPOINT (wpi))
	{
		m_session->SystemMessage ("You must select waypoint to move it.");
		return true;
	}

	Player *player = m_session->GetPlayer();

	wpi->AI_SendMoveToPacket (player->GetPositionX(), player->GetPositionY(),
		player->GetPositionZ(), 500, true);
	
	wpi->m_wpOwner->m_waypoints[wpi->m_wpIndex].x = player->GetPositionX();
	wpi->m_wpOwner->m_waypoints[wpi->m_wpIndex].y = player->GetPositionY();
	wpi->m_wpOwner->m_waypoints[wpi->m_wpIndex].z = player->GetPositionZ();

	// Bind spawn location to waypoint #0
	//
	if (wpi->m_wpIndex == 0) {
		wpi->m_wpOwner->respawn_cord[0] = player->GetPositionX();
		wpi->m_wpOwner->respawn_cord[1] = player->GetPositionY();
		wpi->m_wpOwner->respawn_cord[2] = player->GetPositionZ();
		wpi->m_wpOwner->respawn_angle = player->GetOrientation();

		m_session->SystemMessage ("Moved waypoint #0 and mob respawn point to player location.");
	} else {
		m_session->SystemMessage ("Moved waypoint #%d to player location.", wpi->m_wpIndex);
	}

	wpi->m_wpOwner->SaveToDB();
	_resaveWaypoints (wpi->m_wpOwner);

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Delete (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select waypoint first.");
		return true;
	}

	// Find selected waypoint and calculate its owner
	WaypointIndicator *wpi = (WaypointIndicator *)objmgr.GetObject<Creature> (guid);
	if (wpi == NULL || !IS_WAYPOINT (wpi)) {
		m_session->SystemMessage ("You must select waypoint to delete.");
		return true;
	}

	Creature	*pCreature = wpi->m_wpOwner;

	if (!pCreature->m_waypoints.empty()) {
		for (uint32 i = wpi->m_wpIndex; i < pCreature->m_waypoints.size()-1; i++)
		{
			pCreature->m_waypoints[i] = pCreature->m_waypoints[i+1];
		}
		pCreature->m_waypoints.resize (pCreature->m_waypoints.size()-1);
	}

	if (wpi->m_wpIndex == 0 && ! pCreature->m_waypoints.empty())
	{
		// Move spawn point to next waypoint if zeroth deleted
		pCreature->respawn_cord[0] = pCreature->m_waypoints[0].x;
		pCreature->respawn_cord[1] = pCreature->m_waypoints[0].y;
		pCreature->respawn_cord[2] = pCreature->m_waypoints[0].z;
	}

	wpi->m_wpOwner->SaveToDB();
	_resaveWaypoints (wpi->m_wpOwner);

	m_wpIndicators.remove (wpi);
	wpi->RemoveFromMap();
	objmgr.RemoveObject_Free ((Creature *)wpi);
	//delete wpi;

	m_session->SystemMessage ("Waypoint deleted.");
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Clear (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select mob or waypoint first.");
		return true;
	}

	Creature *pCreature = objmgr.GetObject<Creature>(guid);
	if (pCreature == NULL) {
		m_session->SystemMessage ("You must select mob or waypoint to clear waypoints.");
		return true;
	}

	if (IS_WAYPOINT (pCreature))
	//if (pCreature->GetUInt32Value (UNIT_NPC_FLAGS) & WAYPOINT_NPC_FLAG != 0)
	{
		pCreature = ((WaypointIndicator *)pCreature)->m_wpOwner;
	}

	pCreature->m_currentWaypoint = 0;
	pCreature->m_creatureState = AI_STATE_STOPPED;
	pCreature->m_waypoints.clear();
	pCreature->SaveToDB();
	_resaveWaypoints (pCreature);

	pCreature->AI_SendMoveToPacket (pCreature->respawn_cord[0], pCreature->respawn_cord[1],
		pCreature->respawn_cord[2], 500, true);

	Command_WP_Hide (NULL);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Add (const char* args)
{
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("Please select mob or waypoint to add new waypoint.");
		return true;
	}

	uint32 index = *args? atoi((char*)args): -1;

	// Try to classify selection - is it real Creature or Waypoint
	// In latter case we get owner Creature from Waypoint and proceed with adding
	Creature *pCreature = objmgr.GetObject<Creature>(guid);
	if (pCreature == NULL) {
		m_session->SystemMessage ("Please select mob or waypoint to add new waypoint.");
		return true;
	}

	if (IS_WAYPOINT (pCreature))
	//if (pCreature->GetUInt32Value (UNIT_NPC_FLAGS) & WAYPOINT_NPC_FLAG != 0)
	{
		pCreature = ((WaypointIndicator *)pCreature)->m_wpOwner;
	}

	// If no waypoints, we add first at creature location
	//
	if(!pCreature->hasWaypoints())
	{
		std::stringstream	ss;
		ss << "INSERT INTO creatures_mov (creatureId,X,Y,Z) VALUES ('"
			<< GUID_LOPART(guid) << ", " << pCreature->GetPositionX() << ", "
			<< pCreature->GetPositionY() << ", " << pCreature->GetPositionZ() << ")";
		sDatabase.Execute(ss.str().c_str());

		pCreature->addWaypoint(pCreature->GetPositionX(), pCreature->GetPositionY(), pCreature->GetPositionZ());
	}

	// Then we add requested waypoint at player location
	//
	if (index == -1) {
		if (pCreature->addWaypoint(m_session->GetPlayer()->GetPositionX(),
				m_session->GetPlayer()->GetPositionY(),
				m_session->GetPlayer()->GetPositionZ()))
		{
			std::stringstream	ss;
			ss << "INSERT INTO creatures_mov (creatureId,X,Y,Z) VALUES ('"
				<< GUID_LOPART(guid) << ", " << m_session->GetPlayer()->GetPositionX()
				<< ", " << m_session->GetPlayer()->GetPositionY() << ", "
				<< m_session->GetPlayer()->GetPositionZ();
			pCreature->SaveToDB();
			_resaveWaypoints (pCreature);

			sDatabase.Execute (ss.str().c_str());
			m_session->SystemMessage ("Waypoint added.");
		}
	}
	else 
	// Index not -1 means that user wants to insert point
	//
	{
		if (index >= pCreature->m_waypoints.size())
			index = pCreature->m_waypoints.size();

		pCreature->insertWaypoint (m_session->GetPlayer()->GetPositionX(),
			m_session->GetPlayer()->GetPositionY(),
			m_session->GetPlayer()->GetPositionZ(), index);
		
		pCreature->SaveToDB();
		_resaveWaypoints (pCreature);
		m_session->SystemMessage ("Waypoint inserted at position %d.", index);
	}

	Command_WP_Show (NULL);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Turn (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select mob first.");
		return true;
	}

	Creature *pCreature = objmgr.GetObject<Creature>(guid);
	if (pCreature == NULL) {
		m_session->SystemMessage ("Select mob to turn.");
		return true;
	}

	if (IS_WAYPOINT (pCreature)) {
		pCreature = ((WaypointIndicator *)pCreature)->m_wpOwner;
	}

	Player *player = m_session->GetPlayer();
	pCreature->LookAt (player);

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Come (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select mob first.");
		return true;
	}

	Creature *pCreature = objmgr.GetObject<Creature>(guid);
	if (pCreature == NULL) {
		m_session->SystemMessage ("Select mob to move spawn point.");
		return true;
	}

	if (IS_WAYPOINT (pCreature)) {
		pCreature = ((WaypointIndicator *)pCreature)->m_wpOwner;
	}

	Player *player = m_session->GetPlayer();

	pCreature->AI_MoveTo (player, 1, 0);

	pCreature->respawn_cord[0] = player->GetPositionX();
	pCreature->respawn_cord[1] = player->GetPositionY();
	pCreature->respawn_cord[2] = player->GetPositionZ();
	pCreature->respawn_angle = player->GetOrientation();
	pCreature->SaveToDB();

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_WP_Wait (const char *args)
{
	// Find GUID for current selection
	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection, select waypoint first.");
		return true;
	}

	uint32	wait1 = 3,
			wait2 = 10;

	if (*args) {
		char args1[512];
		strncpy (args1, args, sizeof (args1)-1); args1[sizeof (args1)-1] = '\x00';

		// read argument 1
		char *p = strtok (args1, " ");
		wait1 = *p? atoi(p): wait1;
		
		// read if exists - argument2, or else arg2 = arg1
		p = strtok (NULL, " ");
		wait2 = p && *p? atoi(p): wait1;

		// Make arg1 always <= arg2
		if (wait1 > wait2) {
			int t = wait1; wait1 = wait2; wait2 = t;
		}
	}

	// Find selected waypoint and calculate its owner
	Creature *pCreature = objmgr.GetObject<Creature> (guid);
	if (pCreature == NULL) {
		m_session->SystemMessage ("You must select waypoint to set wait times.");
		return true;
	}

	if (! IS_WAYPOINT (pCreature)) {
		m_session->SystemMessage ("You must select waypoint to set wait times.");
		return true;
	}
	
	WaypointIndicator *wpi = (WaypointIndicator *)pCreature;
	Waypoint &wp = wpi->m_wpOwner->m_waypoints[wpi->m_wpIndex];

	uint8 wait1old = wp.Wait1;
	uint8 wait2old = wp.Wait2;
	wp.Wait1 = (uint8)wait1;
	wp.Wait2 = (uint8)wait2;
	_resaveWaypoints (wpi->m_wpOwner);

	if (wait1old != wait1 || wait2old != wait2) {
		m_session->SystemMessage ("Waypoint wait times changed from %d..%d to new values %d..%d.",
			wait1old, wait2old, wait1, wait2);
	} else {
		m_session->SystemMessage ("Waypoint wait times not changed, you provided the same numbers.");
	}
	return true;
}

//--- END ---