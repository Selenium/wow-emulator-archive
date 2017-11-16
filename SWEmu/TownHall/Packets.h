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
	static void AttackStop(CClient *pClient, guid_t guid, guidhigh_t guidhigh);
	static void AttackStart(CClient *pClient, guid_t guid, guidhigh_t guidhigh);
	static void LogGainXP(CClient *pClient, guid_t creatureguid, unsigned long OrigExp, unsigned long XP);
	static void LevelUp(CPlayer *pPlayer, PlayerStats OldStats);
	static guid_t ReadGuid(CDataBuffer &Data);
	static int PackGuidBuffer(char *buffer,guid_t guid,guidhigh_t guidhigh);
	static void PackGuid(CPacket &pkg,guid_t guid,guidhigh_t guidhigh);
	static void CloseGossip(CClient *pClient);
	static void DefaultGossipMenu(CClient *pClient, guid_t creatureguid);
	static void SendRegion(CPacket &pkg, CWoWObject *pObject);
};

#endif // PACKETS_H
