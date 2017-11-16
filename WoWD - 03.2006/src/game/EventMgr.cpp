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

#include "EventMgr.h"

initialiseSingleton( EventMgr );

void EventMgr::_addToLists(TimedEvent* t)
{
    //First add to main list
    _list.push_back(t);

    //Then add to the object sorted map
    std::map<void*, EventList*>::iterator it;

    //If object doesn't have a list yet
    if ((it = _objectMap.find(t->obj)) == _objectMap.end())
    {
        EventList *el = new EventList;
        _objectMap.insert(std::map<void*, EventList*>::value_type(t->obj, el));

        el->push_back(t);
    }
    else
    {
        it->second->push_back(t);
    }
}

void EventMgr::_removeFromLists(TimedEvent* t)
{
    std::map<void*, EventList*>::iterator it;

    _list.remove(t);

    ASSERT((it = _objectMap.find(t->obj)) != _objectMap.end());

    it->second->remove(t);
    
    //If object list it empty lets just remove it
    if (it->second->size() == 0)
    { 
        delete it->second;
        _objectMap.erase(t->obj);
    }
}

void EventMgr::_removeEvent(TimedEvent* t)
{
    //Remove from all lists
    _removeFromLists(t);
    
    //Delete from memory
    delete t->cb;
    delete t;
}

void EventMgr::_markRemoval(TimedEvent* t)
{
    if (t->deleted)
        return;

    t->deleted = true;
    _deletionList.push_back(t);
}

TimedEvent* EventMgr::_makeEventStruct(CallbackBase *cb, void *obj, uint32 eventFlags, 
                                      uint32 msTime, uint32 repeats)
{
    TimedEvent* t = new TimedEvent;
    
    t->cb = cb;
    t->obj = obj;
    t->eventFlags = eventFlags;
    t->msTime = msTime;
    t->currTime = msTime;
    t->repeats = repeats;
    t->deleted = false;

    return t;
}

void EventMgr::_updateEvent(TimedEvent* t, uint32 diff)
{
    t->currTime -= diff;

    //Time's up
    if (t->currTime <= 0)
    {
        while (t->currTime <= 0)
            t->currTime += t->msTime;

        //Execute callback
        t->cb->execute();

        //If this was the last repeat remove the event
        if (t->repeats == 1)
        {
            _markRemoval(t);
        }
        else if (t->repeats > 1)
        {
            t->repeats -= 1;
        }
    }
}

void EventMgr::Update(uint32 diff)
{
    EventList::iterator it, lend;
    
    lend = _list.end();
    it = _list.begin();

    while(it != lend)
    {
        TimedEvent *t = *it;
        it++;
        if (!t->deleted)
            _updateEvent(t, diff);
    }

    while(_deletionList.size())
    {
        TimedEvent *t = _deletionList.front();
        _deletionList.remove(t);
        _removeEvent(t);
    }
}
