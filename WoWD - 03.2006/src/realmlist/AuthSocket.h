#ifndef _AUTHSOCKET_H
#define _AUTHSOCKET_H

#include "Common.h"
#include "Auth/BigNumber.h"
#include "Auth/Sha1.h"
#include "Network/TcpSocket.h"

class SocketHandler;

class AuthSocket: public TcpSocket
{
public:
    const static int N_BYTE_SIZE = 32;
    const static int s_BYTE_SIZE = 32;

    AuthSocket(SocketHandler& h);
    ~AuthSocket();

    void OnAccept();
    void OnRead();

private:
    enum eAuthCmd
    {
        AUTH_NO_CMD                 = 0xFF,
        AUTH_LOGON_CHALLENGE        = 0x00,
        AUTH_LOGON_PROOF            = 0x01,
        AUTH_RECONNECT_CHALLENGE    = 0x02,
        AUTH_RECONNECT_PROOF        = 0x03,
        REALM_LIST                  = 0x10,
        XFER_INITIATE               = 0x30, // from server
        XFER_DATA                   = 0x31, // from server
        XFER_UNK1                   = 0x32, // from client, thanks to wad for those
        XFER_UNK2                   = 0x33, // from client
        XFER_UNK3                   = 0x34  // from client
    };

    enum eStatus
    {
        STATUS_CONNECTED = 0,
        STATUS_AUTHED
    };

    struct AuthHandler
    {
        eAuthCmd cmd;
        uint32 status;
        bool (AuthSocket::*handler)(void);
    };

    AuthHandler* _GetHandlerTable() const;

    bool _HandleLogonChallenge();
    bool _HandleLogonProof();
    bool _HandleRealmList();
    bool _HandleXferInitiate();
    bool _HandleXferData();

    BigNumber N, s, g, v;
    BigNumber b, B;
    BigNumber rs;

    // mighty session key.
    // one should keep this in some other place,
    // we will use it from other AuthSocket object (upon reconnect)
    BigNumber K;

    eAuthCmd _cmd;
    bool _authed;

    std::string _login;
};

#endif
