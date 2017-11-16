#ifndef _PARTY_H_
#define _PARTY_H_

#include "../Common.h"
#include "../WorldThread.h"
#include "Character.h"

class Party {
    public:
                    Party           (Character *);

        CharList    Members;
        CharList    PendingInvites;
        wxLongLong  Leader;
        wxUint32    LootType;
};

#endif
