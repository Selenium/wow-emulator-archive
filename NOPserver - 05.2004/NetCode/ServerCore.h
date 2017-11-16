#ifndef _SERVERCORE_H_
#define _SERVERCORE_H_

#include "Packet.h"
#include "../ThreadComm.h"


//////////////////////////////////////////////////////////////////////////
// SERVERCORE 
WX_DECLARE_HASH_MAP( wxUint32,wxSocketBase*,wxIntegerHash,wxIntegerEqual,ConnectionHashMap );
class ServerCore : public wxEvtHandler
{


public:
	ServerCore(ThreadComm* comm)
        :mLoginServerSocket(NULL)
        ,mWorldServerSocket(NULL)
		,Comm(comm)
	{
        // init everything
        InitConfig();
        InitLoginserver();
        InitWorldserver();
		Comm->SetServer(this);
	}

	~ServerCore(void) 
	{
        // kill everything
        ShutdownWorldserver();
        ShutdownLoginserver();
        ShutdownConfig();
	}

	//////////////////////////////////////////////////////////////////////////
	// static part
//	DECLARE_SINGLETON(ServerCore);

	//////////////////////////////////////////////////////////////////////////
	// Generic Stuff
private:
	DECLARE_EVENT_TABLE()

	enum EventIDs
	{

        EVENT_LOGINSERVERSOCKET         =  2000,


        EVENT_WORLDSERVERSOCKET         =  3000,

        EVENT_WORLDCLIENTSOCKETHANDLER  =  3100,

		//EVENT_PACKETHANDLER			=  3200 defined in ThreadComm.h
	};


    //////////////////////////////////////////////////////////////////////////
    // Loginserver
public:
    void                        InitLoginserver             ();
    void                        ShutdownLoginserver         ();
    void                        LoginserverLogMessage       (wxString msg);

    wxIPV4address				mLoginServerAddress;
    wxSocketServer*				mLoginServerSocket;

    void                        LoginServerSocketHandler    (wxSocketEvent& evt);
#ifdef _WIN32
    long                        LoginServerAnnounce         (void);
#endif

    //////////////////////////////////////////////////////////////////////////
    // Worldserver
public:
    void                        InitWorldserver             ();
    void                        ShutdownWorldserver         ();
    void                        WorldserverLogMessage       (wxString msg);

    wxIPV4address				mWorldServerAddress;
    wxSocketServer*				mWorldServerSocket;

    void                        WorldServerSocketHandler    (wxSocketEvent& evt);
    void                        WorldServerClientSocketHandler(wxSocketEvent& evt);

	void						WorldServerSendPacketHandler(wxPacketsAvailable &evt);

	ConnectionHashMap			Connections;
    void                        WorldKillConnection			    (wxSocketBase*);
 
	//////////////////////////////////////////////////////////////////////////  
    // Thread Comunication object
	ThreadComm *Comm;
	//////////////////////////////////////////////////////////////////////////
	// Config
public:
    void						InitConfig					();
    void						ShutdownConfig				();
    void						ConfigLogMessage			(wxString msg);

	// /

	// /global
	wxString					mcfgTitle;	
	wxString					mcfgMotd;	

    // /net
    wxString                    mcfgExtAddress;

	// /net/worldserver
    wxUint32					mcfgWorldserverPort;

    // /net/loginserver
    wxUint32                    mcfgLoginserverPort;
    wxUint32                    mcfgRealmlistUpdate;
    wxString                    mcfgRealmlist;
};


#endif//_SERVERCORE_H_
