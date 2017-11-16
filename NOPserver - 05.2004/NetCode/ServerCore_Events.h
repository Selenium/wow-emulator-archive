#ifndef _SERVERCORE_EVENTS_H_
#define _SERVERCORE_EVENTS_H_

//////////////////////////////////////////////////////////////////////////
// Server core event types
BEGIN_DECLARE_EVENT_TYPES()
	DECLARE_LOCAL_EVENT_TYPE(wxEVT_DATA_AVAILABLE,0)
END_DECLARE_EVENT_TYPES()

class wxDataAvailable : public wxEvent
{
public:
	wxDataAvailable(int id=0)	: wxEvent(id, wxEVT_DATA_AVAILABLE)			{ }
	virtual wxEvent			*Clone() const { return new wxDataAvailable(*this); }
};

typedef void (wxEvtHandler::*wxDataAvailableEventFunction)(wxDataAvailable&);


#define EVT_DATA_AVAILABLE(id, fn)	DECLARE_EVENT_TABLE_ENTRY(wxEVT_DATA_AVAILABLE,          id, -1, (wxObjectEventFunction) (wxEventFunction) (wxDataAvailableEventFunction) & fn, (wxObject *) NULL ),
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////

#endif//_SERVERCORE_EVENTS_H_