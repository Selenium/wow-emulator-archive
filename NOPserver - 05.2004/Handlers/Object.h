#ifndef _OBJECT_H_
#define _OBJECT_H_

#include "../Common.h"
#include "../NetCode/OpCodes.h"
#include "../NetCode/Packet.h"
#include "../WorldThread.h"
#include "ObjPosition.h"

/* RIP TEH VOLKMEISTER */
#define SETMASK(array,x)                    \
        array[x/32] |= 1 << (x & 31)        \

#define ISSET(array,x)                      \
        array[x/32] & (1 << (x & 31))       \

#pragma pack(push,1)
union UpdateData {
    wxFloat32   fpoint;
    wxUint32    uint32;
    short       uint16[2];
    wxUint8     uint8[4];
};
#pragma pack(pop)

enum GetSetValueParam {
    BYTE_ONE    = 0,    BYTE_TWO    = 1,
    BYTE_THREE  = 2,    BYTE_FOUR   = 3,
    SHORT_ONE   = 0,    SHORT_TWO   = 1,
};

class Object {
    /* Damn this! */
    void                ObjConstructor  (wxLongLong id);
    public:
        static wxUint32 LastLow;

                        Object          (wxLongLong);
                        Object          (wxUint8, wxString name);
virtual                ~Object          (void);

        void            GetObjectUpdate (wowPacket *, wxUint32, wxUint32);
        void            GetObjectProps  (wowPacket *);
        void            ClearUpdateMasks(void);
        
        void            SetValueInt64   (wxUint32, wxLongLong);
        void            SetValue        (wxUint32, wxUint32);
        void            SetValueFloat   (wxUint32, wxFloat32);
        void            SetValueShort   (wxUint32, wxUint8, wxUint16);
        void            SetValueByte    (wxUint32, wxUint8, wxUint8);

        wxLongLong      GetValueInt64   (wxUint32);
        wxUint32        GetValue        (wxUint32);
        wxFloat32       GetValueFloat   (wxUint32);
        wxUint16        GetValueShort   (wxUint32, wxUint8);
        wxUint8         GetValueByte    (wxUint32, wxUint8);

virtual void            SetName         (wxString);
        void            SetScale        (wxFloat32);
        void            SetType         (wxUint32);
        void            SetGUID         (wxLongLong);
        void            SetPosition     (wxFloat32, wxFloat32, wxFloat32);

virtual const wxChar   *GetName         (void);
        wxLongLong      GetGUID         (void);
        wxUint32        GetType         (void);
        wxFloat32       GetScale        (void);

        UpdateData     *PropertyMap;
        wxUint32        NumProperties;
        wxUint32       *UpdateMasks;
        wxUint32        NumMasks;
        ObjPosition     Position;
        wxUint8         Type;

        wxUint32        unk5;
        wxUint32        unk6;
        wxUint32        unk7;
        wxLongLong      unk8;
};

#endif
