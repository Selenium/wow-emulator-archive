//
// WorldSocketMgr.h
//

#ifndef __WORLDSOCKETMGR_H
#define __WORLDSOCKETMGR_H

class WorldSocket;

class WorldSocketMgr : public Singleton<WorldSocketMgr>
{
public:
    WorldSocketMgr();

    void AddSocket(WorldSocket *s);
    void RemoveSocket(WorldSocket *s);
    void Update(time_t diff);

private:
    typedef std::set<WorldSocket*> SocketSet;
    SocketSet m_sockets;
};

#define sWorldSocketMgr WorldSocketMgr::getSingleton()

#endif

