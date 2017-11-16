#include "ObjPosition.h"
#include "../WorldThread.h"

/* note: this initialization is only valid for characters */
ObjPosition::ObjPosition(void) {
    PosX    = 0.0f; PosY    = 0.0f;
    PosZ    = 0.0f; Angle   = 0.0f;
    //MovementFlags = 0x08000000;
    MovementFlags = 0;

    WalkSpeed   = 2.5f;         RunSpeed = 7.0f;
    SwimSpeed   = 4.722223f;    TurnRate = 3.141592f; /* Pi! */
}

void ObjPosition::ObjPositionUpdate (wowPacket *packet, wxUint32 UpdateType, wxUint32 Self) {
    if (UpdateType == OBJUPD_CREATE) {
        packet->Putu32(MovementFlags); // Flags, we need to figure them out? --daxxar

        packet->Putf32(PosX);
        packet->Putf32(PosY);
        packet->Putf32(PosZ);
        packet->Putf32(Angle);

        if (MovementFlags & 0x20000000) { // Transport GUID + Location?
            packet->Putu32(0); packet->Putu32(0);
            packet->Putf32(0); packet->Putf32(0);
            packet->Putf32(0); packet->Putf32(0);
        }
        if (MovementFlags & 0x1000000) // Unknown.
            packet->Putf32(0);

        if (MovementFlags & 0x400000) { // Unknown.
            packet->Putu32(0);
            packet->Putf32(0); packet->Putf32(0);
            packet->Putf32(0); packet->Putf32(0);
        }

        packet->Putf32(WalkSpeed);
        packet->Putf32(RunSpeed);
        packet->Putf32(SwimSpeed);
        packet->Putf32(TurnRate);
        /*packet->Putf32(0.0f);
        packet->Putf32(0.0f);
        packet->Putf32(0.0f);
        packet->Putf32(0.0f);*/

        if (!(MovementFlags & 0x2000000))
            return;

        LOG(_T("WTF?"));
        /* NOT SELF, AFAIK */
        packet->Putu32(Self);
        if (Self & 0x10000) // Unknown.
            packet->Putf32(0);
        if (Self & 0x20000) { // Unknown.
            packet->Putu32(0); packet->Putu32(0);
        }
        if (Self & 0x40000) // Unknown.
            packet->Putf32(0);

        /* Unknown stuff. (I'm too lazy to add NULLs)
        int
        ulong
        uint Spline count
        if last uint != 0:
        6 bytes per spline point
        */
    } else 
        LOG(_T("[ObjPosition] Got unsupported type %d in ObjPositionUpdate."), UpdateType);
}
