#ifndef _WORLDTHREAD_H
#define _WORLDTHREAD_H

#include "Common.h"
#include "HandlerTemplates.h"
#include "ThreadComm.h"
#include "NetCode/Packet.h"
#include "Core.h"
#include "Handlers/ObjectManager.h"

class LuaScriptHandler;
class PacketHandler;
class CallbackHandler;
class UserManager;
class WorldThread :
	public wxThread
{
static WorldThread *TheThread;
	LuaScriptHandler *mScriptHandler;
	PacketHandler    *mPacketHandler;
	CallbackHandler  *mCallbackHandler;
	UserManager		 *mUserManager;
    ObjectManager    *mObjectManager;
	ThreadComm *Comm;
	wxStopWatch GlobalStopWatch;
	bool mPostedPackets;
	unsigned long CycleCount;
	void DoMainLoop();

	
public:
	WorldThread(ThreadComm *comm) :Comm(comm),mPostedPackets(false){}
	wxStopWatch &GetStopWatch(){return GlobalStopWatch;}
	void *Entry();
	void OnExit();
	LuaScriptHandler *GetScriptHandler(){return mScriptHandler;}
	PacketHandler    *GetPacketHandler(){return mPacketHandler;}
	CallbackHandler  *GetCallbackHandler(){return mCallbackHandler;}
	void PostPacket(wowPacket *packet)
	{
		if(packet->GetSocket())
		{
			Comm->WorldPost(packet);
			mPostedPackets = true;
		} else
		{
			LOG("Packet with NULL socket was being sent! Deleting!");
			delete packet;
		}
		
	}
	void PostPacket(wowPacket &packet)
	{
		PostPacket(new wowPacket(packet));
	}
	void PCC()
	{
		LOG(_T("CycleCount : %ld in %ldms"),CycleCount,GlobalStopWatch.Time());
	}
    ObjectManager   *GetObjectManager   (void)  { return mObjectManager; }
    UserManager     *GetUserManager     (void)  { return mUserManager; }
static WorldThread  *GetThread          (void)  { return TheThread; }
};

#endif
