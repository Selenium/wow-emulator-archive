#include <winsock2.h>
#include "../Common.h"
#include "ServerCore.h"
#include "../Core.h"
#define Log LoginserverLogMessage

#ifdef _WIN32
#include "../WorldThread.h"
#include "../CallbackHandler.h"
#include "../Handlers/UserManager.h"

struct RealmPacket {
	unsigned short Port;
	char Name[64];
	char IPAddr[16];
	unsigned long nPlayers;

};

#endif

void		ServerCore::InitLoginserver()
{

    mLoginServerAddress.AnyAddress();
    mLoginServerAddress.Service(mcfgLoginserverPort);
    mLoginServerSocket = new wxSocketServer(mLoginServerAddress);

    mLoginServerSocket->SetEventHandler(*this,EVENT_LOGINSERVERSOCKET);
    mLoginServerSocket->SetNotify(wxSOCKET_CONNECTION_FLAG);
    mLoginServerSocket->Notify(true);
    mLoginServerSocket->SetFlags(wxSOCKET_NOWAIT);
}

void        ServerCore::ShutdownLoginserver         ()
{
    if (mLoginServerSocket) mLoginServerSocket->Destroy();
}

void        ServerCore::LoginserverLogMessage       (wxString msg)
{
    LOG(_T("[login] %s"),msg.c_str());
}

void        ServerCore::LoginServerSocketHandler    (wxSocketEvent& event)
{
    if(event.GetSocketEvent() == wxSOCKET_CONNECTION)
    {
        wxSocketBase* socket = mLoginServerSocket->Accept(false);

        wxIPV4address peer;
        socket->GetPeer(peer);

        Log(wxString::Format(_T("new connection from '%s:%i'"),peer.IPAddress().c_str(),peer.Service()));

        wowPacket       worldserver(socket);

        // need this for my router
        if (peer.IPAddress() != _T("127.0.0.1"))
            worldserver.Putcstr0(wxString::Format(_T("%s:%i"), mcfgExtAddress.c_str(), mcfgWorldserverPort));
        else
            worldserver.Putcstr0(wxString::Format(_T("127.0.0.1:%i"), mcfgWorldserverPort));       

        socket->Write(worldserver.GetData(), worldserver.GetSize());
        socket->Destroy();
    }
}

#ifdef _WIN32
long ServerCore::LoginServerAnnounce (void) {
    int ret;

    LPHOSTENT lpHostEntry = gethostbyname(mcfgRealmlist);
    if (!lpHostEntry)
        return mcfgRealmlistUpdate;

	SOCKET RealmAdd = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if (RealmAdd == INVALID_SOCKET) {
        LOG(_T("[Login-RList] Got INVALID_SOCKET, trying again in a bit.. (%d)"), mcfgRealmlistUpdate);
        return mcfgRealmlistUpdate;
    }
    
    SOCKADDR_IN RealmServer;
    RealmServer.sin_family = AF_INET;
    RealmServer.sin_addr = *((LPIN_ADDR)*lpHostEntry->h_addr_list);
    RealmServer.sin_port = htons(9111);
    
    RealmPacket packet = {0};
    strncpy(packet.IPAddr, mcfgExtAddress.c_str(), 16);
    strncpy(packet.Name, mcfgTitle.c_str(), 64);
    packet.nPlayers = WorldThread::GetThread()->GetUserManager()->GetClientCount();
    packet.Port = mcfgLoginserverPort;

    ret = sendto(RealmAdd, (char *)&packet, sizeof(packet), NULL, (LPSOCKADDR)&RealmServer, sizeof(struct sockaddr));
    if (ret == SOCKET_ERROR) {
        LOG(_T("[Login-RList] Got socket error on sendto, id %d"), WSAGetLastError());
        closesocket(RealmAdd);
        return mcfgRealmlistUpdate; 
    }

    ret = closesocket(RealmAdd);
    if (ret == SOCKET_ERROR) {
        LOG(_T("[Login-RList] Got socket error on closesocket, id %d"), WSAGetLastError());
        return mcfgRealmlistUpdate;
    }

    LOG(_T("[Login-RList] Packet sent to %s - recalling in %d"), mcfgRealmlist, mcfgRealmlistUpdate);
    LOG(_T("[Login-RList] IP: %s Port: %d Players: %d Name: %s"), packet.IPAddr, packet.Port, packet.nPlayers, packet.Name);
    return mcfgRealmlistUpdate;
}
#endif
