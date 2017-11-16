#pragma once
#include "stdafx.h"
#include "TCPSocket.h"
#include "UDPSocket.h"
#include "Index.h"
#include "Client.h"

static _Origin RaceStartingPoints[]={
	{0,0,{0,0,0},0},
	/* Psycho: Everyone back at the original since worldport is enabled */
	{0,0x9,{-8897.70f,-173.28f,82.0f},0.0f},//HUMAN
	{1,0x16A,{307.88f,-4724.13f,10.05f},0.0f},//ORC
	{0,0x83,{-5639.30f,-493.65f,396.66f},0.0f},//DWARF
	{1,0xBA,{9862.68f,952.69f,1306.53f},0.0f},//NIGHTELF
	{0,0x55,{2037.08f,74.16f,33.98f},0.0f},//UNDEAD
	{1,0x1D6,{-1015.32f,-45.61f,69.31f},0.0f},//TAUREN
	{0,0x83,{-5639.30f,-493.65f,396.66f},0.0f},//GNOME
	{1,0x16A,{307.88f,-4724.13f,10.05f},0.0f} //TROLL

	/* Psycho: Starting everyone at the same spot since worldport is disabled for now */
	/* The Crossroad loc
	{1,0x9,{-450.3f,-2639.7f,98.615f},0.0f},//HUMAN
	{1,0x16A,{-451.3f,-2639.7f,98.615f},0.0f},//ORC
	{1,0x83,{-452.3f,-2639.7f,98.615f},0.0f},//DWARF
	{1,0xBA,{-453.3f,-2639.7f,98.615f},0.0f},//NIGHTELF
	{1,0x55,{-454.3f,-2639.7f,98.615f},0.0f},//UNDEAD
	{1,0x1D6,{-453.3f,-2639.7f,98.615f},0.0f},//TAUREN
	{1,0x83,{-452.3f,-2639.7f,98.615f},0.0f},//GNOME
	{1,0x16A,{-450.3f,-2639.7f,198.615f},0.0f} //TROLL
	*/
};

struct RealmPacket
{
	unsigned short Port;
	char Name[64];
	char IPAddr[16];
	unsigned long nPlayers;
};

class CRealmServer
{
public:
	CRealmServer(void);
	~CRealmServer(void);

	char Name[64];
	char IPAddr[16];


	TCPSocket Listener;
	TCPSocket RedirectListener;
	UDPSocket MasterList;
	CThread RealmThread;

	void Go();
	bool Initialize();
	
	unsigned char ThreadState;
	unsigned long MaxSent;
	CClient *pTempClient;// for debugging.
	CIndex <CClient*> Clients;
	unsigned long nClients;
	unsigned long nMaxClients;

	CIndex <Addr*> MasterLists;
	void UpdateMasterLists(int State=0);

	void BroadcastOutPacket(unsigned short OpCode, void *buffer, unsigned short Length);
	void CreateTestData();
  class CCreature *GenerateCreature(unsigned long Model, const char *Name, unsigned long Continent,_Location Loc, float Facing);
};



