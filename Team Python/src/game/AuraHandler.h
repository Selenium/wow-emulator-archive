//////////////////////////////////////////////////////////////////////
//  Aura Handler
//
//  Addon to SpellHandler handles Auras and Seals
//////////////////////////////////////////////////////////////////////

#ifndef WOWPYTHONSERVER_AURAHANDLER_H
#define WOWPYTHONSERVER_AURAHANDLER_H

#include "MsgHandler.h"

#include "Spell.h"
#include "UpdateMask.h"

class Unit;
class GameClient;
class DatabaseInterface;

class AuraHandler : public MsgHandler
{
public:
	AuraHandler();
	~AuraHandler();
	void HandleMsg( wowWData & recv_data, GameClient *pClient );
	int setAura(Unit *pUnit, uint32 spell);
	
protected:

};

#endif
