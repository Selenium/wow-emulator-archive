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

#include "ExplorationMgr.h"
#include "Database/DBCStores.h"

initialiseSingleton( ExplorationMgr );


ExplorationMgr::ExplorationMgr()
{
    Init();
}


ExplorationMgr::~ExplorationMgr()
{
    map<uint32, Area*>::iterator it;

    for(it = m_areas.begin(); it != m_areas.end(); it++)
    {
        delete it->second;
    }

    m_areas.clear();
}


void ExplorationMgr::Init()
{
    uint32 i;

    for(i = 0; i < sWorldMapOverlayStore.GetNumRows(); i++)
    {
        WorldMapOverlay *worldMapOverlay = sWorldMapOverlayStore.LookupEntry(i);
        if (worldMapOverlay)
        {
            WorldMapArea *worldMapArea = sWorldMapAreaStore.LookupEntry( worldMapOverlay->worldMapAreaID );
            
            if (!worldMapArea)
                continue;

            if (!worldMapArea->zoneId)
                continue;
            
            AreaTable *areaTable = sAreaStore.LookupEntry( worldMapOverlay->areaTableID );
            
            Area *tmpArea = new Area;
            tmpArea->areaId = worldMapOverlay->areaTableID;
            tmpArea->zoneId = worldMapOverlay->worldMapAreaID;
            tmpArea->mapId = worldMapArea->mapId;
            tmpArea->areaFlag = areaTable->explorationFlag;
            //This is wrong. We need to get the real values somehow, but
            //I doubt we'll find them in the client.
            //tmpArea->xp = areaTable->EXP;
            tmpArea->xp = 150;

            //Blizz's axis are fucked up.
            //X goes up, Y goes left.
            // - Doron
            float zoneWidth = abs(worldMapArea->y2 - worldMapArea->y1);
            float zoneHeight = abs(worldMapArea->x2 - worldMapArea->x1);

            float widthPercentX1 = float(worldMapOverlay->areaX) / MAP_IMAGE_WIDTH;
            float widthPercentY1 = float(worldMapOverlay->areaY) / MAP_IMAGE_HEIGHT;
            float widthPercentX2 = (float(worldMapOverlay->areaX) + float(worldMapOverlay->areaW)) / MAP_IMAGE_WIDTH;
            float widthPercentY2 = (float(worldMapOverlay->areaY) + float(worldMapOverlay->areaH)) / MAP_IMAGE_HEIGHT;

            //Just to make it clear, worldMapArea->x1/y1 are in the blizzardian
            //axis system, and widthPercentY1/X1 are in the normal one.
            // - Doron
            tmpArea->x2 = worldMapArea->x1 - (widthPercentY1 * zoneHeight);
            tmpArea->x1 = worldMapArea->x1 - (widthPercentY2 * zoneHeight);
            tmpArea->y2 = worldMapArea->y1 - (widthPercentX1 * zoneWidth);
            tmpArea->y1 = worldMapArea->y1 - (widthPercentX2 * zoneWidth); 

            m_areas.insert(std::map<uint32,Area*>::value_type(tmpArea->areaId, tmpArea));
        }
    }
}


Area * ExplorationMgr::GetArea(float x, float y, uint32 mapid)
{
    map<uint32, Area*>::iterator it;

    double curDstSqr, minDstSqr = -1;
    Area *area = NULL;
    
    double cX, cY;

    for(it = m_areas.begin(); it != m_areas.end(); it++)
    {
        if (it->second->mapId == mapid)
        {
            if (((x >= it->second->x1) && (x < it->second->x2)) &&
                ((y >= it->second->y1) && (y < it->second->y2)))
            {
                cX = (it->second->x1 + it->second->x2) / 2;
                cY = (it->second->y1 + it->second->y2) / 2;

                curDstSqr = (cX - x)*(cX - x) + (cY - y)*(cY - y);
                
                if ((curDstSqr < minDstSqr) || (minDstSqr < 0))
                {
                    area = it->second;
                    minDstSqr = curDstSqr;
                }
            }
        }
    }

    return area;
}


void ExplorationMgr::SetArea(Player *plr, Area *area)
{
    ASSERT(area);

    uint32 flags = area->areaFlag;
    uint16 offset = (uint16)(flags / 32);
    uint32 value = (uint32)(1 << (flags % 32));
    
    uint32 currValue = plr->GetUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset);
    plr->SetUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset, currValue | value);
    plr->SetBaseUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset, currValue | value);
}


bool ExplorationMgr::PlayerHasArea(Player *plr, Area *area)
{
    ASSERT(area);

    uint32 flags = area->areaFlag;
    uint16 offset = (uint16)(flags / 32);
    uint32 value = (uint32)(1 << (flags % 32));
    
    uint32 currValue = plr->GetUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset);
    
    if (currValue & value)
        return true;
    else
        return false;
}


void ExplorationMgr::Update(Player *plr)
{
    ASSERT(plr);

    Area *area = GetArea(plr->GetPositionX(), plr->GetPositionY(), plr->GetMapId());

    if (!area)
        return;

	//PVP
	plr->UpdatePVPStatus(area->areaId);

    if (!PlayerHasArea(plr, area))
    {
        OnExplore(plr, area);
    }
}


void ExplorationMgr::OnExplore(Player *plr, Area *area)
{
    //Set player's bitmask
    SetArea(plr, area);
    
	//Send exp packet
    plr->GetSession()->SendPacket(&BuildExplorationExperiance(area));

    //Set exp
    plr->GiveXP(area->xp, plr->GetGUID());

    //TODO:
    //Quest code checks
}


WorldPacket ExplorationMgr::BuildExplorationExperiance(Area *area)
{
    WorldPacket data;

    data.Initialize(SMSG_EXPLORATION_EXPERIENCE);
    data << area->areaId;
    data << area->xp;
    
    return data;    
}
