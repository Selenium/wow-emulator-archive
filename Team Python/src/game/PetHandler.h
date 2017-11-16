//////////////////////////////////////////////////////////////////////
//  Aura Handler
//
//  Addon to SpellHandler handles Auras and Seals
//////////////////////////////////////////////////////////////////////

#ifndef WOWPYTHONSERVER_PETHANDLER_H
#define WOWPYTHONSERVER_PETHANDLER_H

#include "MsgHandler.h"

#include "Spell.h"
#include "UpdateMask.h"

class Unit;
class GameClient;
class DatabaseInterface;

class PetHandler : public MsgHandler
{
public:
	PetHandler();
	~PetHandler();
	void HandleMsg( wowWData & recv_data, GameClient *pClient );
protected:

};

#endif

