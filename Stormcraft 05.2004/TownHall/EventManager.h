#pragma once
#include <map>
#include <sys/timeb.h>
using namespace std;
#include "Globals.h"
#include "WoWObject.h"

// The actual event structure.
struct WoWEvent
{
	unsigned long EventID;		// Used for O(1) removal from the main list, since it can be huge
	CWoWObject *pObject;		// The object receiving the event
	_timeb EventTime;			// The scheduled time for the event
	unsigned long EventType;	// Object-specific event code for the event
	void *pEventData;			// Data associated with the event (we keep our own copy)
};

// the node structure for the linked list 
struct WoWEventNode
{
	WoWEvent *pEvent;
	WoWEventNode *pLast;// we need random access to this list for removal.
	WoWEventNode *pNext;
};

class CEventManager
{
public:
	CEventManager(void);
	~CEventManager(void);

	void ProcessReadyEvents();	// called only by the RealmServer Thread

	// Add an event (automatically adds to object's list also)
	// msWait is the amount of time in milliseconds from this moment to excute the event
	// EventType depends on the object's ProcessEvent
	// pEventData is a pointer to the data to associate (can be NULL/0)
	// DataSize is the size of the data to associate (can be NULL/0)
	// The data will be *copied* into an allocated memory block within the Event.
	void AddEvent(CWoWObject &Object, unsigned long msWait, unsigned long EventType, void *pEventData, unsigned long DataSize);

	// Effectively cancels an event (does NOT remove from the object's list, but the memory will be freed *caution*)
	inline void RemoveEvent(unsigned long EventID)
	{
		WoWEventNode *pNode = EventMap[EventID];
		if (!pNode)
		{
			Debug.Logf("Cannot remove event #%u\n",EventID);
			return;
		}
/*
	char buf[256];
	sprintf(buf,"Removed %d\n",pNode->pEvent->EventType);
	OutputDebugString(buf);
*/
		EventMap[EventID]=0;
		if (pNode->pLast)
			pNode->pLast->pNext=pNode->pNext;
		else
			pEvents=pNode->pNext;

		if (pNode->pNext)
			pNode->pNext->pLast=pNode->pLast;

		if (pNode->pEvent->pEventData)
			free(pNode->pEvent->pEventData);
		delete pNode->pEvent;
		delete pNode;
		//pNode->pEvent->pObject->RemoveEvent(pNode->pEvent->EventID);
	}

	// used to determine the amount of time in millisecond between two "timeb"'s :)
	// static function so it can be used elsewhere like so: CEventManager::DiffTime(x,y)
	static inline long DiffTime(_timeb &Last, _timeb &First)
	{
		return ((Last.time-First.time)*1000)+(Last.millitm-First.millitm);
	}

	// used to add a number of milliseconds to a timeb
	// ... also static ;)
	static inline void AddTime(_timeb &Now, unsigned long ms)
	{
		unsigned long temp=Now.millitm+ms;
		Now.time+=temp/1000;
		Now.millitm=(unsigned short)temp%1000;
	}

private:
	// inserts the event into our linked list, sorted.
	// note that this is O(N), we can make it O(N log N) or whatnot later, that
	// may become very important when hundreds, or thousands, of events are in the
	// queue at any given moment.
	inline void InsertSorted(WoWEvent &Event)
	{
		WoWEventNode *pNode = new WoWEventNode;
		pNode->pEvent=&Event;
		EventMap[Event.EventID]=pNode;

		WoWEventNode *pCurrent=pEvents;
		// new head
		if (!pCurrent)
		{
			pNode->pLast=0;
			pNode->pNext=0;
			pEvents=pNode;
			return;
		}
		WoWEventNode *pLast=0;
		do
		{
			// determine if the event comes AFTER this new one
			if (DiffTime(pCurrent->pEvent->EventTime,Event.EventTime)>0)
			{
				// pLast <=> pNode <=> pCurrent

				// it does, insert our new event here.
				pNode->pNext=pCurrent;
				pCurrent->pLast=pNode;
				pNode->pLast=pLast;

				if (pLast)
					pLast->pNext=pNode;
				else
					pEvents=pNode; // new head
				return;// done.
			}
			pLast=pCurrent;
		} while(pCurrent=pCurrent->pNext);
		// new tail, insert after pLast
		pLast->pNext=pNode;
		pNode->pLast=pLast;
		pNode->pNext=0;
	}
	
	WoWEventNode *pEvents;
	map<unsigned long,WoWEventNode*> EventMap;
};

// Event Types
// EVENT TYPES ARE OBJECT-SPECIFIC! THE SAME # CAN BE USED IN TWO OBJECTS FOR 
// DIFFERENT EVENTS.
#define EVENT_PLAYER_GAINEXP				1
#define EVENT_PLAYER_REGENERATE				2
#define EVENT_PLAYER_REZSICKNESS			3
#define EVENT_PLAYER_REMOVE_AURA			4
#define EVENT_PLAYER_PVP					5
#define EVENT_PLAYER_DOTTED					6
#define EVENT_PLAYER_END_ATTACK				7
#define EVENT_PLAYER_TAXI_END				8

#define EVENT_CREATURE_DESPAWN				1
#define EVENT_CREATURE_REGENERATE			2
#define EVENT_CREATURE_ATTACK				3
#define EVENT_CREATURE_FOLLOW_TARGET		4
#define EVENT_CREATURE_RESPAWN				5
#define EVENT_CREATURE_UPDATELOC			6
#define EVENT_CREATURE_DOTTED				7

#define EVENT_SPAWNPOINT_SPAWN				1
#define EVENT_SPAWNPOINT_DESPAWN			2

#define EVENT_GUILD_DESTROY					1
#define EVENT_GUILD_CLEANUP					2

#define EVENT_PARTY_DESTROY					1
#define EVENT_PARTY_CLEANUP					2
