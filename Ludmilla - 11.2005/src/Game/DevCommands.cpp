#include "StdAfx.h"
#include "../Shared/PacketBuilder.h"

/////////////////////////////////////////////////
//  GM Chat Commands -- Development Section
//
//-----------------------------------------------------------------------------

bool ChatHandler::Command_Debug_Flags (const char* args)
{
	WorldPacket data;
	uint32 flags = hex_or_decimal (args);
	uint64 selected = m_session->GetPlayer()->GetSelection();
	
	Unit * u = Unit::WorldGetUnit (selected);
	if (u == NULL) {
		m_session->SystemMessage ("No creature or player selected");
		return true;
	}
	u->SetUInt32Value (UNIT_FIELD_FLAGS, flags);
	m_session->SystemMessage ("Modified UNIT_FIELD_FLAGS to %d (0x%X)", flags, flags);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_DynamicFlags (const char* args)
{
	WorldPacket data;
	uint32 flags = hex_or_decimal (args);
	uint64 selected = m_session->GetPlayer()->GetSelection();
	
	Unit * u = Unit::WorldGetUnit (selected);
	if (u == NULL) {
		m_session->SystemMessage ("No creature or player selected");
		return true;
	}

	u->SetUInt32Value (UNIT_DYNAMIC_FLAGS, flags);
	m_session->SystemMessage ("Modified UNIT_DYNAMIC_FLAGS to %d (0x%X)", flags, flags);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_Bytes0 (const char* args)
{
	WorldPacket data;
	uint32 flags = hex_or_decimal (args);
	uint64 selected = m_session->GetPlayer()->GetSelection();
	
	Unit * u = Unit::WorldGetUnit (selected);
	if (u == NULL) {
		m_session->SystemMessage ("No creature or player selected");
		return true;
	}
	u->SetUInt32Value (UNIT_FIELD_BYTES_0, flags);
	m_session->SystemMessage ("Modified UNIT_FIELD_BYTES_0 to %d (0x%X)", flags, flags);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_Bytes1 (const char* args)
{
	WorldPacket data;
	uint32 flags = hex_or_decimal (args);
	uint64 selected = m_session->GetPlayer()->GetSelection();
	
	Unit * u = Unit::WorldGetUnit (selected);
	if (u == NULL) {
		m_session->SystemMessage ("No creature or player selected");
		return true;
	}
	u->SetUInt32Value (UNIT_FIELD_BYTES_1, flags);
	m_session->SystemMessage ("Modified UNIT_FIELD_BYTES_1 to %d (0x%X)", flags, flags);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_Bytes2 (const char* args)
{
	WorldPacket data;
	uint32 flags = hex_or_decimal (args);
	uint64 selected = m_session->GetPlayer()->GetSelection();
	
	Unit * u = Unit::WorldGetUnit (selected);
	if (u == NULL) {
		m_session->SystemMessage ("No creature or player selected");
		return true;
	}
	u->SetUInt32Value (UNIT_FIELD_BYTES_2, flags);
	m_session->SystemMessage ("Modified UNIT_FIELD_BYTES_2 to %d (0x%X)", flags, flags);
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_QInv (const char* args)
{
	uint32 reason = hex_or_decimal (args);
	QuestPacketHandler::getSingleton().SendQuestInvalid( m_session, reason );

	return true;
}
//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_QFailed (const char* args)
{
	uint32 reason = hex_or_decimal (args);
	QuestPacketHandler::getSingleton().SendQuestFailedToPlayer( m_session, reason );

	return true;
}

//-----------------------------------------------------------------------------
extern bool g_restartScripting;

bool ChatHandler::Command_Debug_ReloadScripts (const char* args)
{
	//g_restartScripting = true;
	RestartScripting();
	m_session->SystemMessage ("[Python] Scripts reloaded...");
	return true;
}
//-----------------------------------------------------------------------------
bool ChatHandler::Command_Debug_Errors (const char* args)
{
	WorldPacket data;
	uint32 code = hex_or_decimal (args);
	Make_INVENTORY_CHANGE_FAILURE (&data, (uint8)code, 0, 0);
	m_session->SendPacket( &data );
	return true;
}

//--- END ---