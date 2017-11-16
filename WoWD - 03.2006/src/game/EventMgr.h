// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef __EVENTMGR_H
#define __EVENTMGR_H

#include "CallBack.h"
#include "Common.h"

enum EventTypes
{
    EVENT_UNK = 0,
    EVENT_MAPMGR_UPDATEOBJECTS,
    EVENT_MAPCELL_UNLOAD,
    EVENT_WORLD_UPDATEAUCTIONS,
    EVENT_WORLD_UPDATESESSIONS,
    EVENT_CREATURE_UPDATE,
    EVENT_PLAYER_UPDATE,
    EVENT_PLAYER_UPDATEEXPLORATION,
    EVENT_PLAYER_UPDATEATTACK,
    EVENT_GAMEOBJECT_UPDATE,
	EVENT_PLAYER_STOPPVP,
    EVENT_CREATURE_JUSTDIED,
    EVENT_CREATURE_REMOVE_CORPSE,
    EVENT_CREATURE_RESPAWN,
    EVENT_MAPMGR_UNLOAD_CELL,
	EVENT_PLAYER_REST,
	EVENT_PLAYER_UNDERWATER,
	EVENT_PLAYER_REGENBREATH,
	EVENT_PLAYER_RESTSTART,
};

struct TimedEvent
{
    void *obj;
    CallbackBase *cb;
    uint32 eventFlags;
    time_t msTime;
    time_t currTime;
    uint32 repeats;
    bool deleted;
};

class EventMgr : public Singleton < EventMgr >
{
public:

    EventMgr() { }

    ~EventMgr() { }

    template <class Class>
    void AddEvent(Class *obj, void (Class::*method)(), uint32 flags, uint32 time, uint32 repeats)
    {
        CallbackP0<Class> *cb;
        cb = new CallbackP0<Class>(obj, method);

        TimedEvent* t = _makeEventStruct(cb, (void *)obj, flags, time, repeats);

        _addToLists(t);
    }

    template <class Class, typename P1>
    void AddEvent(Class *obj, void (Class::*method)(P1), P1 p1, uint32 flags, uint32 time, uint32 repeats)
    {
        CallbackP1<Class, P1> *cb;
        cb = new CallbackP1<Class, P1>(obj, method, p1);

        TimedEvent* t = _makeEventStruct(cb, (void *)obj, flags, time, repeats);

        _addToLists(t);
    }

    template <class Class, typename P1, typename P2>
    void AddEvent(Class *obj, void (Class::*method)(P1,P2), P1 p1, P2 p2, uint32 flags, uint32 time, uint32 repeats)
    {
        CallbackP2<Class, P1, P2> *cb;
        cb = new CallbackP1<Class, P1, P2>(obj, method, p1, p2);

        TimedEvent* t = _makeEventStruct(cb, (void *)obj, flags, time, repeats);

        _addToLists(t);
    }

    template <class Class, typename P1, typename P2, typename P3>
    void AddEvent(Class *obj,void (Class::*method)(P1,P2,P3), P1 p1, P2 p2, P3 p3, uint32 flags, uint32 time, uint32 repeats)
    {
        CallbackP3<Class, P1, P2, P3> *cb;
        cb = new CallbackP1<Class, P1, P2, P3>(obj, method, p1, p2, p3);

        TimedEvent* t = _makeEventStruct(cb, (void *)obj, flags, time, repeats);

        _addToLists(t);
    }

    template <class Class, typename P1, typename P2, typename P3, typename P4>
    void AddEvent(Class *obj, void (Class::*method)(P1,P2,P3,P4), P1 p1, P2 p2, P3 p3, P4 p4, uint32 flags, uint32 time, uint32 repeats)
    {
        CallbackP4<Class, P1, P2, P3, P4> *cb;
        cb = new CallbackP1<Class, P1, P2, P3, P4>(obj, method, p1, p2, p3, p4);

        TimedEvent* t = _makeEventStruct(cb, (void *)obj, flags, time, repeats);

        _addToLists(t);
    }

    void Update(uint32 diff);

    template <class Class>
    void RemoveEvents(Class *obj)
    {
        std::map<void*, EventList*>::iterator it;
        if ((it = _objectMap.find(obj)) == _objectMap.end())
            return;

        EventList::iterator itr;

        itr = it->second->begin();
        
        while(itr != it->second->end())
        {
            TimedEvent *ev = *itr;
            itr++;
            _markRemoval(ev);
        }
    }

    template <class Class>
    void RemoveEvents(Class *obj, uint32 type)
    {
        std::map<void*, EventList*>::iterator it;
        if ((it = _objectMap.find(obj)) == _objectMap.end())
            return;

        EventList::iterator itr;

        itr = it->second->begin();
        
        while(itr != it->second->end())
        {
            TimedEvent *ev = *itr;
            itr++;
            if (ev->eventFlags == type)
            {
                _markRemoval(ev);
            }
        }
    }

    template <class Class>
    void ModifyEventTimeLeft(Class *obj, uint32 type, uint32 time)
    {
        std::map<void*, EventList*>::iterator it;
        if ((it = _objectMap.find(obj)) == _objectMap.end())
            return;

        EventList::iterator itr;

        for(itr = it->second->begin(); itr != it->second->end(); itr++)
        {
            if ((*itr)->eventFlags == type)
            {
                (*itr)->currTime = time;
            }
        } 
    }
    
    template <class Class>
    void ModifyEventTime(Class *obj, uint32 type, uint32 time)
    {
        std::map<void*, EventList*>::iterator it;
        if ((it = _objectMap.find(obj)) == _objectMap.end())
            return;

        EventList::iterator itr;

        for(itr = it->second->begin(); itr != it->second->end(); itr++)
        {
            if ((*itr)->eventFlags == type)
            {
                (*itr)->msTime = time;
            }
        }
    }

private:

    void _addToLists(TimedEvent* t);
    void _removeFromLists(TimedEvent* t);
    void _removeEvent(TimedEvent* t);
    void _markRemoval(TimedEvent* t);
    TimedEvent* _makeEventStruct(CallbackBase *cb, void *obj, uint32 eventFlags, uint32 msTime, uint32 repeats);
    void _updateEvent(TimedEvent* t, uint32 diff);


    typedef std::list<TimedEvent*> EventList;

    EventList _list;
    EventList _deletionList;
    std::map<void*, EventList*> _objectMap;
};

#define sEventMgr EventMgr::getSingleton()

#endif
