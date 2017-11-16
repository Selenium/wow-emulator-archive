#ifndef _CHARACTER_H_
#define _CHARACTER_H_

#include "../Common.h"
#include "../NetCode/Packet.h"
#include "../IDList.h"
#include "Client.h"
#include "Unit.h"

const wxUint32          slotRightHand       = 0xd;
const wxUint32          slotLeftHand        = 0xf;
const wxUint32          NumActionButtons    = 120;

class Character : public Unit {
    void                CharConstructor (Client *, wxString);
    public:
                        Character       (Client *, wxString, wxLongLong);
                        Character       (Client *, wxString);
        virtual        ~Character       (void);

        wxInt32         FindFriend      (wxLongLong);
        void            GetCharUpdate   (wowPacket *, wxUint32, wxUint32);
        void            GetCharProps    (wowPacket *);
        void            EnterWorld      (void);

        void            AddFriend       (wowPacket *);
        void            DelFriend       (wowPacket *);
        void            ListFriends     (wowPacket *);

        void            MoveHeartbeat   (wowPacket *);
        
        void            LogoutRequest   (wowPacket *);
        void            CancelTrade     (wowPacket *);
        void            StandStateChange(wowPacket *);
        void            SelectionChange (wowPacket *);

        /* Below are UpdateObject setters/getters */

        void            SetSkin         (wxUint8);
        void            SetFace         (wxUint8);
        void            SetHairStyle    (wxUint8);
        void            SetHairColor    (wxUint8);
        void            SetFacialHair   (wxUint8);

        void            SetNextXP       (wxUint32);
        void            SetXP           (wxUint32);
        
        void            SetSelection    (wxLongLong);


        wxUint8         GetHairColor    (void);
        wxUint8         GetHairStyle    (void);
        wxUint8         GetFace         (void);
        wxUint8         GetSkin         (void);
        wxUint8         GetFacialHair   (void);

        wxUint32        GetNextXP       (void);
        wxUint32        GetXP           (void);

        wxLongLong      GetSelection    (void);

        wxUint8         Online; /* 1 / 0 -> Yes / No */
        wxUint8         HomeCity;   wxUint8     Realm;
        wxFloat32       Scale;      wxString    Name;

        wxUint32        ActionButtons[NumActionButtons];

        Client         *ControllingClient;
        GUIDList        Friends;
};

#endif
