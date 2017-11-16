//////////////////////////////////////////////////////////////////////
//  Spell Handler
//
//  Receives all messages with spell management opcodes
//////////////////////////////////////////////////////////////////////

#ifndef WOWPYTHONSERVER_SPELLHANDLER_H
#define WOWPYTHONSERVER_SPELLHANDLER_H

#include "MsgHandler.h"

#include "Spell.h" //angelic|999
#include "UpdateMask.h" //angelic|999
#include <iostream> 
#include <cstdlib> 


class Unit;
class GameClient;
class DatabaseInterface;

class SpellHandler : public MsgHandler
{
public:
	SpellHandler();
	~SpellHandler();
	void HandleMsg( wowWData & recv_data, GameClient *pClient );
	int applySpell( GameClient *pClient, Unit* target, uint32 spell, SpellInformation spellInfo);
	int usePotion(GameClient *pClient, uint32 spell, SpellInformation spellInfo, uint32 targets);
	int setAura(Unit *pUnit, uint32 spell);
	float CalcDistance(float sx, float sy, float sz, float dx, float dy, float dz);

	uint32 PetCreature(GameClient *pClient, char* pName); 
    
	float lrand, rrand; 
	float abstand, winkel; 
	float CalcDistance2d( float xe, float ye, float xz, float yz ); 
	bool inbogen( float radius,  float xM, float yM,float zM, float offnung, float drehung, float xP, float yP,float zP ); 
	float geteinfachererwinkel( float winkel ); 
	float getwinkel( float xe, float ye, float xz, float yz ); 


protected:

};

#endif
