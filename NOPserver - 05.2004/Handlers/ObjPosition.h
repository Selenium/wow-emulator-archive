#ifndef _OBJPOSITION_H_
#define _OBJPOSITION_H_

#include "../Common.h"
#include "../IDList.h"
#include "../NetCode/Packet.h"

class ObjPosition {
    public:
                    ObjPosition         (void);
        void        ObjPositionUpdate   (wowPacket *, wxUint32, wxUint32);

        wxFloat32   PosX;
        wxFloat32   PosY;
        wxFloat32   PosZ;
        wxFloat32   Angle;

        wxUint32    MovementFlags;

        wxFloat32   WalkSpeed;       // default : 2.5
        wxFloat32   RunSpeed;        // default : 7
        wxFloat32   SwimSpeed;       // default : 4.7222223
        wxFloat32   TurnRate;        // default : pi

};

#endif
