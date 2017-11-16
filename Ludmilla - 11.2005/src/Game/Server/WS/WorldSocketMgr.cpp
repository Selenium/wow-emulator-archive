#include "StdAfx.h"
#include "WorldSocket.h"
#include "WorldSocketMgr.h"

createFileSingleton( WorldSocketMgr );


WorldSocketMgr::WorldSocketMgr()
{
}

void WorldSocketMgr::AddSocket(WorldSocket *s)
{
	Log::getSingleton( ).outDebug("WorldSocketMgr:add %p wsock: %p", &s, s->GetSocket());
    m_sockets.insert(s);
}


void WorldSocketMgr::RemoveSocket(WorldSocket *s)
{
	Log::getSingleton( ).outDebug("WorldSocketMgr:del %p wsock: %p", &s, s->GetSocket());
    m_sockets.erase(s);
}


void WorldSocketMgr::Update(time_t diff)
{
    SocketSet::iterator i;
    for(i = m_sockets.begin(); i != m_sockets.end(); i++)
    {
        (*i)->Update(diff);
    }
}
