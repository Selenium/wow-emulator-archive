#include "../Common.h"
#include "ServerCore.h"

DEFINE_LOCAL_EVENT_TYPE(wxEVT_PACKETS_AVAILABLE)


BEGIN_EVENT_TABLE(ServerCore, wxEvtHandler)
    EVT_SOCKET(EVENT_LOGINSERVERSOCKET,     ServerCore::LoginServerSocketHandler)
    EVT_SOCKET(EVENT_WORLDSERVERSOCKET,     ServerCore::WorldServerSocketHandler)
    EVT_SOCKET(EVENT_WORLDCLIENTSOCKETHANDLER,ServerCore::WorldServerClientSocketHandler)
	EVT_PACKETS_AVAILABLE(EVENT_PACKETHANDLER,  ServerCore::WorldServerSendPacketHandler)
END_EVENT_TABLE()

//DEFINE_LOCAL_EVENT_TYPE(wxEVT_UINOTIFY)

