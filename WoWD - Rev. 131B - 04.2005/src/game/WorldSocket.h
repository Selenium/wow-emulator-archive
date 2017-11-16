//
// WorldSocket.h
//

#ifndef __WORLDSOCKET_H
#define __WORLDSOCKET_H

#include "Network/TcpSocket.h"
#include "Auth/BigNumber.h"
#include "Auth/WowCrypt.h"

class WorldPacket;
class SocketHandler;
class WorldSession;

class WorldSocket : public TcpSocket
{
public:
    WorldSocket(SocketHandler&);
    ~WorldSocket();

    void SendPacket(WorldPacket* packet);

    void OnAccept();
    void OnRead();
    void OnDelete();

    void Update(time_t diff);

protected:
    void _HandleAuthSession(WorldPacket& recvPacket);
    void _HandlePing(WorldPacket& recvPacket);

    static uint32 _GetSeed();

private:
    WowCrypt _crypt;
    uint32 _seed;
    uint32 _cmd;
    uint16 _remaining;
    WorldSession* _session;

    ZThread::LockedQueue<WorldPacket*,ZThread::FastMutex> _sendQueue;
};

#endif
