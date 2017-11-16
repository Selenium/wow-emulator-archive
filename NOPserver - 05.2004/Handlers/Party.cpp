#include "Party.h"

Party::Party (Character *Creator) {
    Leader = Creator->GetGUID();
    Members.Append(Creator);
    LootType = NULL;
}

