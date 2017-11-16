#ifndef _OBJECTMANAGER_H_
#define _OBJECTMANAGER_H_

#include "../Common.h"
#include "../WorldThread.h"
#include "Object.h"

class ObjectManager {
    public:
                        ObjectManager   (void);
        wxString        GetObjName      (wxLongLong);
        void            NameQuery       (wowPacket *);

        ObjHashMap      Objects;
        ObjReverseMap   ReverseObj;
};

#endif
