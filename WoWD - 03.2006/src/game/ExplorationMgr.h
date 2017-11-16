// Copyright (C) 2004 WoW Daemon
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

#ifndef __EXPLORATIONMGR_H
#define __EXPLORATIONMGR_H

#include "Common.h"
#include "ObjectMgr.h"

#define MAP_IMAGE_WIDTH 1000
#define MAP_IMAGE_HEIGHT 666

typedef struct
{
    uint32 areaId;
    uint32 mapId;
    uint32 zoneId;
    std::string name;
    uint32 areaFlag;
    double x1, x2;
    double y1, y2;
    uint32 xp;
} Area;

class Player;

class ExplorationMgr :  public Singleton < ExplorationMgr >
{
public:
    ExplorationMgr();
    ~ExplorationMgr();

    void Init();

    Area * GetArea(float x, float y, uint32 mapid);
    void SetArea(Player *plr, Area *area);
    bool PlayerHasArea(Player *plr, Area *area);
    void Update(Player *plr);
    void OnExplore(Player *plr, Area *area);

    WorldPacket BuildExplorationExperiance(Area *area);

private:

    std::map<uint32, Area*> m_areas;
};

#define sExplorationMgr ExplorationMgr::getSingleton()

#endif
