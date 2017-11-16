#ifndef _USERMANAGER_H_
#define _USERMANAGER_H_

#include "../Common.h"
#include "../PacketHandler.h"
#include "Object.h"
#include "ObjPosition.h"
#include "Client.h"

class UserManager {
    ClientHashMap   Clients;
    ObjectManager   *objman;
    public:
                        UserManager         (void);
                       ~UserManager         (void);
        void            StatusMsg           (wxSocketBase *, wxString);

        Client         *GetClientByPacket   (wowPacket *);
        Character      *GetCharByPacket     (wowPacket *packet);
        ObjectManager  *GetObjectManagerByPacket (wowPacket *);
        wxUint32        GetClientCount      (void);

        void            VicinityBroadcast   (ObjPosition *, wowPacket *);
        void            VicinityBroadcast   (ObjPosition *, wowPacket *, wxLongLong);

        void            NewPlayer           (Character *, wxUint8);
        void            UpdatePlayer        (Character *);

        void            Connect             (wowPacket *); 
        void            Kill                (wowPacket *);

        void            Ping                (wowPacket *);
        void            AuthSession         (wowPacket *);
        void            MoveHandler         (wowPacket *);

        void            ChatMessage         (wowPacket *);
        void            TextEmote           (wowPacket *);
};

#endif
