//
// WorldSocketMgr.cpp
//

#include "Common.h"
#include "WorldSocket.h"
#include "WorldSocketMgr.h"


createFileSingleton( WorldSocketMgr );


WorldSocketMgr::WorldSocketMgr()
{
}

void WorldSocketMgr::AddSocket(WorldSocket *s)
{
    m_sockets.insert(s);
}


void WorldSocketMgr::RemoveSocket(WorldSocket *s)
{
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
