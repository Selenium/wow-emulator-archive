#ifndef EVENTMANAGER_H
#define EVENTMANAGER_H

#include <map>
#include <sys/timeb.h>
using namespace std;
#include "Globals.h"
#include "WoWObject.h"

// The actual event structure.
struct WoWEvent
{
	CWoWObject *pObject;			// The object receiving the event
	void *pEventData;				// Data associated with the event (we keep our own copy)
	UINT64 EventTime;				// The scheduled time for the event
	unsigned long RepeatTime:24;	// The event will be repeat every RepeatTime in ms   
	unsigned char RepeatCount;
	unsigned long EventType;		// Object-specific event code for the event
};

// the node structure for the linked list
struct WoWEventNode
{
	WoWEvent *pEvent;
	WoWEventNode *pLast;// we need random access to this list for removal.
	WoWEventNode *pNext;
};
UINT64 timebtoms(_timeb &intime);
UINT64 nowinms(void);

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
	// The event will be repeated RepeatCount times. If u set it to 1 it will be done 2times!
	void AddEvent(CWoWObject &Object, unsigned long msWait, unsigned long EventType, void *pEventData, unsigned long DataSize
		, unsigned long RepeatTime=0, unsigned char RepeatCount=0);


	// Effectively cancels an event (does NOT remove from the object's list, but the memory will be freed *caution*)
	inline void RemoveEvent(WoWEvent *const RemovedEvent)
	{
		multimap<UINT64, WoWEvent*>::iterator itr = FindInTimeList(RemovedEvent);
		delete itr->second;
		EventTimeMap.erase(itr);
	}

	inline multimap<UINT64, WoWEvent*>::iterator FindInTimeList(WoWEvent *const RemovedEvent)
	{
		multimap<UINT64, WoWEvent*>::iterator itr = EventTimeMap.find(RemovedEvent->EventTime);
		while(itr->second != RemovedEvent) 
		{
			itr++;
			if (itr->first != RemovedEvent->EventTime)
			{
				Debug.Logf("CEventManager::RemoveEvent() - Cannot remove event #%u\n", RemovedEvent->EventType);
				return EventTimeMap.end();
			}
		}
		return itr;
	}

	//change time of event and reshedule it
	void ChangeEventTime(WoWEvent *const Event, const long timems);

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
	// note that this is O(log N)
	inline void InsertSorted(WoWEvent &Event)
	{
		EventTimeMap.insert(pair<UINT64, WoWEvent*>(Event.EventTime, &Event));
	}

	multimap<UINT64, WoWEvent*> EventTimeMap;// key is time in ms
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
#define EVENT_PLAYER_SAVE					9
#define EVENT_PLAYER_LOGOUT					10
#define EVENT_PLAYER_REST					11
#define EVENT_PLAYER_DUEL					12
#define EVENT_PLAYER_RAGEDEGENERATE			13
#define EVENT_PLAYER_DISMOUNT				14
#define EVENT_PLAYER_REGENERATESPELL		15
#define EVENT_PLAYER_REDUCEBREATH			16
#define EVENT_PLAYER_REDUCEHPBREATH			17
#define EVENT_PLAYER_DUELFLEE				18
#define EVENT_PLAYER_HOTTED					19
#define EVENT_CREATURE_DESPAWN				1
#define EVENT_CREATURE_REGENERATE			2
#define EVENT_CREATURE_ATTACK				3
#define EVENT_CREATURE_FOLLOW_TARGET		4
#define EVENT_CREATURE_RESPAWN				5
#define EVENT_CREATURE_UPDATELOC			6
#define EVENT_CREATURE_DOTTED				7
#define EVENT_CREATURE_WANDER				8
#define EVENT_CREATURE_AIUNBUSY				9
#define EVENT_CREATURE_REPEATEMOTE			10
#define EVENT_CREATURE_AIUPDATE				11
#define EVENT_CREATURE_REMOVE_AURA			12
#define EVENT_SPAWNPOINT_SPAWN				1
#define EVENT_SPAWNPOINT_DESPAWN			2

#define EVENT_GUILD_DESTROY					1
#define EVENT_GUILD_CLEANUP					2

#define EVENT_GAMEOBJECT_RESPAWN			1

#define EVENT_PARTY_DESTROY					1
#define EVENT_PARTY_CLEANUP					2

#define EVENT_SPELL_CASTSPELL				1
#define EVENT_SPELL_CHANNEL					2
#define EVENT_SPELL_CANCEL					3
#define EVENT_SPELL_EFFECTS					4

#define EVENT_CORPSE_DESTROY				1

#define EVENT_MAIL_EXPIRE_CHECK				1
#define EVENT_MAIL_DELIVER					2

#endif // EVENTMANAGER_H
