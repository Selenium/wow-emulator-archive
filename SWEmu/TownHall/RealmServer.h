#ifndef REALMSERVER_H
#define REALMSERVER_H

#include "stdafx.h"
#include "TCPSocket.h"
#include "UDPSocket.h"
#include "Index.h"
#include "Client.h"
#include <queue>
#include <list>

class CRegion;
class CCreature;
class CTaxiMob;

static _Origin RaceStartingPoints[]={
	{0,0,{0,0,0},0},
		//nneonneo: newest locations for 1.8.x
	{0,12,{-8949.95f, -132.493f, 83.5312f}, 3.055527f, 81},//HUMAN
	{1,14,{-618.518f, -4251.67f, 38.718f}, 4.845455f, 21},//ORC
	{0,1,{-6240.32f, 331.033f, 382.758f}, 2.786925f, 41},//DWARF
	{1,14,{10311.3f, 832.463f, 1326.41f}, 5.481625f, 61},//NIGHTELF
	{0,85,{1676.35f, 1677.45f, 121.67f}, 3.169415f, 2},//UNDEAD
	{1,215,{-2917.58f, -257.98f, 52.9968f}, 4.023132f, 141},//TAUREN
	{0,1,{-6240.32f, 331.033f, 382.758f}, 2.760215f, 101},//GNOME
	{1,14,{-618.518f, -4251.67f, 38.718f},3.424336f, 121}, //TROLL
	{0,12,{-8949.95f, -132.493f, 83.5312f}, 3.055527f, 81}, //GOBLIN; ASSUMED HUMAN STARTPOINT
	{0,12,{-8949.95f, -132.493f, 83.5312f}, 3.055527f, 162}, //BLOOD ELF; ASSUMED HUMAN STARTPOINT
	{0,12,{-8949.95f, -132.493f, 83.5312f}, 3.055527f, 163}, //DRAENEI; ASSUMED HUMAN STARTPOINT
};

struct RealmPacket
{
	unsigned short Port;
	char Name[64];
	char IPAddr[16];
	unsigned long nPlayers;
	unsigned short Icon;/// 0 - Normal, 1 - PvP, 2 - Offline
	unsigned short Language;/// 0,1 - English, 2 - German, 3 - French, 4 - Other
};

struct AreaTrigger
{
	unsigned long TargetMap;
	_Location TargetLoc;
	float TargetFacing;
};
struct Waypoint
{
	unsigned long PointID;
	_Location Point;
	unsigned long NextPoint;
};
struct _TrainerTempBinItem
{
	guid_t CreatureTemplateGuid;
	unsigned long SpellID;
	unsigned long SpellCost;
	unsigned long ReqSpell;
};

struct _SellTempBinItem
{
	guid_t CreatureTemplateGuid;
	unsigned long SellID;
};
class CRealmServer
{
public:
	CRealmServer(void);
	~CRealmServer(void);

	char Name[64];
	char IPAddr[16];

	TCPSocket Listener;
	//TCPSocket RedirectListener;
	//TCPSocket LoginListener;
	UDPSocket MasterList;
	CThread RealmThread;

	void Go();
	bool Initialize();

	unsigned char ThreadState;
	unsigned long MaxSent;
	CClient *pTempClient;// for debugging.
	CIndex <CClient*> Clients;
	std::vector<CClient *> ServerQueue;
	std::queue<CRegion *> ActiveRegionsCreatureMove; //long name: this is an object to process creature moves safely.
	std::map<unsigned long,AreaTrigger> AreaTriggers;
	std::map<unsigned long,Waypoint> Waypoints;
	map<unsigned long, unsigned long> SkillLines;
	std::map<unsigned long,CreatureSaveData> Spawns;
	unsigned long HighestSpawnID;
	unsigned long nClients;
	unsigned long nMaxClients;

	CIndex <Addr*> MasterLists;
	void UpdateMasterLists(int State=0);

	void BroadcastOutPacket(unsigned short OpCode, void *buffer, unsigned short Length);
	void ImportItems();
	void SetProgressBar (long progressPos, long progressTotal, char *label);
	void InitSkillLines();
	void SetStatusText(char newtext[]);
	void SpawnSpiritHealers(void);
	CCreature *GenerateCreature(unsigned long Model, const char *Name, unsigned long Continent,_Location Loc, float Facing);
	CTaxiMob  *GenerateTaxiMob (unsigned long Model, const char *Name, unsigned long Continent,_Location Loc, float Facing);
	CCreature *GenerateCreatureNew(CCreatureTemplate *pTemplate, unsigned long Continent, _Location Loc, float Facing);
	int SpawnSavedCreatures(void);
	int SpawnSavedGameObjects(void);
	void LoadTaxiData(void);
};

#endif // REALMSERVER_H
