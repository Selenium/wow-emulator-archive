#include "DataBuffer.h"

#ifndef PACKETS_H
#define PACKETS_H

class Packets
{
public:
	static void SendNewWorld(CClient *pClient);
	static void SendTeleport(CClient *pClient);
	static void TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent);
	static void TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent, _Location &NewLoc, float facing);
	static void TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent, _Location &NewLoc);
	static void Root(CClient *pClient);
	static void UnRoot(CClient *pClient);
	static void AttackStop(CClient *pClient, unsigned long guid, unsigned long guidhigh);
	static void AttackStart(CClient *pClient, unsigned long guid, unsigned long guidhigh);
	static void LogGainXP(CClient *pClient, unsigned long creatureguid, unsigned long OrigExp, unsigned long XP);
	static void LevelUp(CPlayer *pPlayer, PlayerStats OldStats);
	static unsigned long ReadGuid(CDataBuffer &Data);
	static int PackGuidBuffer(char *buffer,unsigned long guid,unsigned long guidhigh);
	static void PackGuid(CPacket &pkg,unsigned long guid,unsigned long guidhigh);
	static void CloseGossip(CClient *pClient);
	static void DefaultGossipMenu(CClient *pClient, unsigned long creatureguid);
	static void SendRegion(CPacket &pkg, CWoWObject *pObject);
};

#endif // PACKETS_H
