// Copyright (C) 2004 Team Python
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef WOWPYTHON_OBJECTMGR_H
#define WOWPYTHON_OBJECTMGR_H

#include "Common.h"

struct UpdateMask;
struct wowWData;
class Character;
class Unit;
class ObjectMgr
{
public:
    ObjectMgr() {};
    ~ObjectMgr(){};

    void BuildAndSendCreatePlayer(Character *pNewChar, uint32 createflag, Character *pReceiver);
    void BuildCreatePlayerMsg(Character *pNewChar, std::list<wowWData*>* msglist, uint32 createflag=0);
    void SetCreatePlayerBits(UpdateMask *updateMask);

    void BuildCreateUnitMsg(Unit *pNewUnit, wowWData* data, Character *pPlayer);
    void SetCreateUnitBits(UpdateMask &updateMask);


protected:
};

#endif


