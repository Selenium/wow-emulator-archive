#ifndef MSGHANDLERS_H
#define MSGHANDLERS_H
#include "Creature.h"

#include "DataBuffer.h"
class CClient;
//struct _InData;
//typedef void (*fMessageHandler)(class CClient *pClient, _InData *pData);
typedef void (*fMessageHandler)(class CClient *pClient, unsigned int msgID, class CDataBuffer &Data);
extern void InstallMessageHandlers(fMessageHandler *handlers);
extern void InstallGameMessageHandlers(fMessageHandler *handlers);
void ClearTradeSettings(CClient *pClient, bool meonly=false);
void SendInventoryFailure(CClient *pClient, int result, unsigned long itemguid1, unsigned long itemguid2, int bagslot, int levelError);
void ForceDismount(CClient *pClient);
void SendTaxiNodes(CClient *pClient, CTaxiMob *pCreature);
void MsgAttackOn(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
void SendTrainerList(CClient *pClient, CCreature *pCreature, unsigned long CreatureGuid);

#endif // MSGHANDLERS_H
