#ifndef SPELLHANDLER_H
#define SPELLHANDLER_H

#include "Client.h"

class CSpellHandler
{
public:
	static void MsgCastSpell(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgCancelCast(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgUseItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void CmdLearnSpells(CClient *pClient);
	static long getPower(unsigned long spell, unsigned long effect);
	static void HandleSpellEffects(CSpell *pSpell, CWoWObject *pObject, CWoWObject *pCaster);
};

#endif // SPELLHANDLER_H
