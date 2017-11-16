#include "../Common.h"
#include "ServerCore.h"
#include "../Core.h"
#define Log WorldserverLogMessage

void		ServerCore::InitWorldserver()
{
    mWorldServerAddress.AnyAddress();
    mWorldServerAddress.Service(mcfgWorldserverPort);
    mWorldServerSocket = new wxSocketServer(mWorldServerAddress);

    mWorldServerSocket->SetEventHandler(*this,EVENT_WORLDSERVERSOCKET);
    mWorldServerSocket->SetNotify(wxSOCKET_CONNECTION_FLAG);
    mWorldServerSocket->Notify(true);
    mWorldServerSocket->SetFlags(wxSOCKET_NOWAIT);
}

void        ServerCore::ShutdownWorldserver         ()
{
    if(mWorldServerSocket)mWorldServerSocket->Destroy() ;

    ConnectionHashMap::iterator it;
    for( it = Connections.begin(); it != Connections.end(); ++it )
        if(it->second) it->second->Destroy();
}

void        ServerCore::WorldserverLogMessage       (wxString msg)
{
    LOG(_T("[world] %s"),msg.c_str());
}

void        ServerCore::WorldServerSocketHandler    (wxSocketEvent& event)
{
    if(event.GetSocketEvent() == wxSOCKET_CONNECTION)
    {
        wxSocketBase *socket = new wxSocketBase();
        mWorldServerSocket->AcceptWith(*socket,false);
		ScratchPackets *Data = new ScratchPackets(socket);
		socket->SetClientData(Data);
		Connections[(wxUint32)socket] = socket;
        wxIPV4address peer;
        socket->GetPeer(peer);

        Log(wxString::Format(_T("new connection from '%s:%i'"),peer.IPAddress().c_str(),peer.Service()));
       

        socket->SetEventHandler(*this,EVENT_WORLDCLIENTSOCKETHANDLER);
        socket->SetNotify(wxSOCKET_INPUT_FLAG|wxSOCKET_LOST_FLAG);
        socket->Notify(true);
        socket->SetFlags(wxSOCKET_NOWAIT);

        //////////////////////////////////////////////////////////////////////////
        // send an auth_challenge
        wowPacket   *ClientConnected = new wowPacket(socket);
		ClientConnected->PutHeader(0xFFFE);
		ClientConnected->Finalize();
		Comm->ServerPost(ClientConnected);
        
    }
}

void        ServerCore::WorldServerClientSocketHandler(wxSocketEvent& event)
{
  
    wxSocketBase*	socket = event.GetSocket();
    wxASSERT(socket);

    switch(event.GetSocketEvent())
    {
    case wxSOCKET_INPUT:
        {
            socket->SetNotify(wxSOCKET_LOST_FLAG);
			wowPacket *packet;//
            
			while(socket && socket->IsConnected() && (packet = wowPacket::ReceivePacketFromSocket(socket)))
            	Comm->ServerPost(packet);
           

            socket->SetNotify(wxSOCKET_LOST_FLAG | wxSOCKET_INPUT_FLAG);
        } break;

    case wxSOCKET_LOST:
		{
			wowPacket *ClientLost = new wowPacket(socket);
			ClientLost->PutHeader(0xFFFF);
			ClientLost->Finalize();
			Comm->ServerPost(ClientLost);
			WorldKillConnection(socket);
			return;
		}break;
    }
}

void ServerCore::WorldServerSendPacketHandler(wxPacketsAvailable &evt)
{
	wowPacket *packet = Comm->ServerReceive();
	
	// there must at least be one packet otherwise there's a bug in world thread
	wxASSERT(packet); 

	bool ret = true;
	while(packet && ret)
	{
		ret = packet->Send(); // true if sent 
		packet = Comm->ServerReceive();
	}
	if (ret) return; //all packets sent or no packets to send (that's an error then);
	while(packet)
	{
		packet->Cue();
		packet = Comm->ServerReceive();
	}

}


void ServerCore::WorldKillConnection			(wxSocketBase* socket)
{
	wxIPV4address peer;
    socket->GetPeer(peer);
    Log(wxString::Format(_T("\'%s\' disconnected"),peer.Hostname().c_str()));
	Connections.erase((wxUint32)socket);
	delete ((ScratchPackets*)socket->GetClientData());
	socket->Destroy();
}
