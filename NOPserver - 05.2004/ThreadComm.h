#ifndef __THREADCOMM_H
#define __THREADCOMM_H

#include "Misc.h"

//typedef ItemList<wowPacket> PacketList; <- is causing bugs
typedef SimpleItemList<wowPacket> PacketList;
typedef SimpleItemList<wxString> ScriptCommandList;
class ServerCore;

class ThreadComm
{
	ScriptCommandList CommandList;
	PacketList Incoming,Outgoing;
	ServerCore *server;
public:
	ServerCore *GetServer() {return server;}
	void SetServer(ServerCore *s) {server=s;}

	void ServerPost(wowPacket * packet)
	{
		Incoming.Attach(packet);
	}
	wowPacket *ServerReceive()
	{
		return Outgoing.Get();
	}
	void WorldPost(wowPacket * packet)
	{
		Outgoing.Attach(packet);
	}
	wowPacket *WorldReceive()
	{
		return Incoming.Get();
	}
	void PostCommand(wxString *command)
	{
		CommandList.Attach(command);
	}
	wxString *GetCommand()
	{
		return CommandList.Get();
	}

};

///////////////////////////////////////////////////////
// wxPacketsAvailable Event - sent by the WorldThread if there are packets to be sent
BEGIN_DECLARE_EVENT_TYPES()
	DECLARE_LOCAL_EVENT_TYPE(wxEVT_PACKETS_AVAILABLE,0)
	DECLARE_LOCAL_EVENT_TYPE(wxEVT_LOG_MESSAGE,1)
END_DECLARE_EVENT_TYPES()

class wxPacketsAvailable : public wxEvent
{
public:
	wxPacketsAvailable(int id=0)	: wxEvent(id, wxEVT_PACKETS_AVAILABLE)			{ }
	virtual wxEvent			*Clone() const { return new wxPacketsAvailable(*this); }
	virtual ~wxPacketsAvailable(){}
};

typedef void (wxEvtHandler::*wxPacketsAvailableEventFunction)(wxPacketsAvailable&);


#define EVT_PACKETS_AVAILABLE(id, fn)	DECLARE_EVENT_TABLE_ENTRY(wxEVT_PACKETS_AVAILABLE,          id, -1, (wxObjectEventFunction) (wxEventFunction) (wxPacketsAvailableEventFunction) & fn, (wxObject *) NULL ),
#define EVENT_PACKETHANDLER 3200

class wxLogEvent : public wxEvent
{
	wxString message;
public:
	wxLogEvent(wxString m,int id=0)	: wxEvent(id, wxEVT_LOG_MESSAGE)
	{
		message = m;
	}
	virtual wxEvent			*Clone() const { return new wxLogEvent(message,this->GetId()); }
	wxString &GetMessage()
	{
		return message;
	}
	virtual ~wxLogEvent() {}
};

typedef void (wxEvtHandler::*wxLogEventEventFunction)(wxLogEvent&);


#define EVT_LOG_MESSAGE(id, fn)	DECLARE_EVENT_TABLE_ENTRY(wxEVT_LOG_MESSAGE,          id, -1, (wxObjectEventFunction) (wxEventFunction) (wxLogEventEventFunction) & fn, (wxObject *) NULL ),
#define LOG_HANDLER 4500




#endif
