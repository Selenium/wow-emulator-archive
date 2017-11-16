#include "ThreadComm.h"
#include "WorldThread.h"
#include "Core.h"
#include "ScriptHandler.h"
#include "PacketHandler.h"
#include "CallbackHandler.h"
#include "NetCode/ServerCore.h"
#include "Handlers/UserManager.h"


WorldThread *WorldThread::TheThread;

void WorldThread::DoMainLoop()
{
	// parse all the script commands left in the cue
	CycleCount++;
	wxString *command;
	while((command = Comm->GetCommand())) 
	{
		mScriptHandler->ParseCommand(command);
		delete command;
	}
	mCallbackHandler->DoCallbackLoop();
	wowPacket *packet = Comm->WorldReceive();
	while(packet)
	{
		mPacketHandler->HandlePacket(packet);
		packet = Comm->WorldReceive();
	}
	if(mPostedPackets)
	{
		wxPacketsAvailable evt(EVENT_PACKETHANDLER);
		::wxPostEvent(Comm->GetServer(),evt);
		mPostedPackets = false;
	}
	
}


void *WorldThread::Entry(void) {
	TheThread = this;
	CycleCount = 0;
	mScriptHandler = new LuaScriptHandler(this);
	mCallbackHandler = new CallbackHandler(this);
	mPacketHandler = new PacketHandler(this);
	mObjectManager =  new ObjectManager;
	mUserManager =  new UserManager;
   
#ifdef _WIN32
    WORD wVersionRequested = MAKEWORD(1,1);
    WSADATA wsaData;
    
    WSAStartup(wVersionRequested, &wsaData);

	if (wsaData.wVersion == wVersionRequested) 
        mCallbackHandler->RegisterCallback(Comm->GetServer(), &ServerCore::LoginServerAnnounce);
#endif

	//MAIN LOOP
	while (!TestDestroy())
		DoMainLoop();		

	return 0;
}

void WorldThread::OnExit(void) {

#ifdef _WIN32
    WSACleanup();
#endif

    delete mUserManager;
	delete mPacketHandler;
	delete mCallbackHandler;
	delete mScriptHandler;
}
