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

///////////////////////////////////////////////
//  Waypoint Commands
//

#include "Common.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Opcodes.h"
#include "Chat.h"
#include "Log.h"
#include "Unit.h"
#include "Creature.h"
#include "UpdateData.h"

bool ChatHandler::HandleWPAddCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }
    AIInterface* ai = NULL;
    Creature * pCreature = NULL;
    Player* p = m_session->GetPlayer();
    if(p->waypointunit != NULL)
    {
        FillSystemMessageData(&data, m_session, "Using Previous Unit.");
        m_session->SendPacket( &data );
        ai = p->waypointunit;
        pCreature = (Creature*)ai->GetUnit();
    }
    else
    {
        pCreature = objmgr.GetObject<Creature>(guid);
        if(!pCreature)
        {
            FillSystemMessageData(&data, m_session, "You should select a creature.");
            m_session->SendPacket( &data );
            return true;
        }
        ai = pCreature->GetAIInterface();
    }

    char* pWaitTime = strtok((char*)args, " ");
	uint32 WaitTime = (pWaitTime)? atoi(pWaitTime) : 10000;
	char* pFlags = strtok(NULL, " ");
	uint32 Flags = (pFlags)? atoi(pFlags) : 0 ;
	char* pForwardEmoteId = strtok(NULL, " ");
	uint32 ForwardEmoteId = (pForwardEmoteId)? atoi(pForwardEmoteId) : 0;
	char* pBackwardEmoteId = strtok(NULL, " ");
	uint32 BackwardEmoteId = (pBackwardEmoteId)? atoi(pBackwardEmoteId) : 0;
	char* pForwardSkinId = strtok(NULL, " ");
	uint32 ForwardSkinId = (pForwardSkinId)? atoi(pForwardSkinId) : pCreature->GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID);
	char* pBackwardSkinId = strtok(NULL, " ");
	uint32 BackwardSkinId = (pBackwardSkinId)? atoi(pBackwardSkinId) : pCreature->GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID);
    char* pForwardEmoteOneShot = strtok(NULL, " ");
	uint32 ForwardEmoteOneShot = (pForwardEmoteOneShot)? atoi(pForwardEmoteOneShot) : 1;
    char* pBackwardEmoteOneShot = strtok(NULL, " ");
	uint32 BackwardEmoteOneShot = (pBackwardEmoteOneShot)? atoi(pBackwardEmoteOneShot) : 1;

	WayPoint* wp = new WayPoint;
	wp->id = ai->m_nWaypoints+1;
	wp->x = p->GetPositionX();
	wp->y = p->GetPositionY();
	wp->z = p->GetPositionZ();
	wp->waittime = WaitTime;
    wp->flags = Flags;
    wp->forwardemoteoneshot = ForwardEmoteOneShot;
	wp->forwardemoteid = ForwardEmoteId;
    wp->backwardemoteoneshot = BackwardEmoteOneShot;
	wp->backwardemoteid = BackwardEmoteId;
	wp->forwardskinid = ForwardSkinId;
	wp->backwardskinid = BackwardSkinId;
	ai->addWayPoint(wp);
	ai->saveWayPoints(wp->id);
    if(ai->m_WayPointsShowing == true)
    {
      ai->showWayPoints(wp->id,p,ai->m_WayPointsShowBackwards);
    }

    std::stringstream ss;
    ss << "Waypoint " << wp->id << " added.";
    FillSystemMessageData(&data, m_session, ss.str().c_str());
    m_session->SendPacket( &data );

    return true;
}

bool ChatHandler::HandleWPShowCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a Creature.");
        m_session->SendPacket( &data );
        return true;
    }

    char* pBackwards = strtok((char*)args, " ");
	bool Backwards = (pBackwards)? atoi(pBackwards) : false;

    AIInterface* ai = pCreature->GetAIInterface();
    Player* pPlayer = m_session->GetPlayer();

    
    if(pPlayer->waypointunit != ai)
    {
      if(ai->m_WayPointsShowing == true) 
      {
        FillSystemMessageData(&data, m_session, "Some one else is also Viewing this Creatures WayPoints.");
        m_session->SendPacket( &data );
        data.clear();
        FillSystemMessageData(&data, m_session, "Viewing WayPoints at the same time as some one else can cause undesireble results.");
        m_session->SendPacket( &data );
      }

      if(pPlayer->waypointunit != NULL)
      {
        pPlayer->waypointunit->hideWayPoints(NULL,pPlayer);
      }
      pPlayer->waypointunit = ai;
      ai->showWayPoints(NULL,pPlayer,Backwards);
      ai->m_WayPointsShowBackwards = Backwards;
    }
    else
    {
      if(ai->m_WayPointsShowing == true) 
      {
        FillSystemMessageData(&data, m_session, "Waypoints Already Showing.");
        m_session->SendPacket( &data );
        return true;
      }
    }

    std::stringstream ss;
    ss << "Showing Waypoints for " << pCreature->GetGUIDLow();
    data.clear();
    FillSystemMessageData(&data, m_session, ss.str().c_str());
    m_session->SendPacket( &data );

    return true;
}

bool ChatHandler::HandleWPDeleteCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      //Refresh client
      //Hide all
      bool show = ai->m_WayPointsShowing;
      if(show == true)
      {
        ai->hideWayPoints(NULL,pPlayer);
      }
      ai->deleteWayPoint(wpid);
      //Show All again after delete
      if(show == true)
      {
        ai->showWayPoints(NULL,pPlayer,ai->m_WayPointsShowBackwards);
      }
      
      ss << "Waypoint " << wpid << " Deleted.";
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPChangeNoCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    std::stringstream ss;

    //get newid
    char* pNewID = strtok((char*)args, " ");
	uint32 NewID = (pNewID)? atoi(pNewID) : 0;

    uint32 wpid = GUID_LOPART(guid);
    if(NewID == wpid) return false;
    if((wpid > 0) && (wpid <= ai->m_nWaypoints) && (NewID > 0) && (NewID <= ai->m_nWaypoints))
    {
      //Refresh client
      //Hide all
      
      bool show = ai->m_WayPointsShowing;
      if(show == true)
      {
        ai->hideWayPoints(NULL,pPlayer);
      }

      //update to new id
      ai->changeWayPointID(wpid,NewID);

      //Show All again after update
      if(show == true)
      {
        ai->showWayPoints(NULL,pPlayer,ai->m_WayPointsShowBackwards);
      }
      
      ss << "Waypoint " << wpid << " changed to Waypoint " << NewID << ".";
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPFlagsCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      uint32 flags = wp->flags;
      
      char* pNewFlags = strtok((char*)args, " ");
	  uint32 NewFlags = (pNewFlags)? atoi(pNewFlags) : 0;

      wp->flags = NewFlags;
      
      //save wp
      ai->saveWayPoints(wpid);

      ss << "Waypoint " << wpid << " flags changed from " << flags << " to " << NewFlags;
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPMoveHereCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      if(wp)
      {
        wp->x = pPlayer->GetPositionX();
        wp->y = pPlayer->GetPositionY();
        wp->z = pPlayer->GetPositionZ();

        //save wp
        ai->saveWayPoints(wpid);
      }
      //Refresh client
      if(ai->m_WayPointsShowing == true)
      {
        ai->hideWayPoints(wpid,pPlayer);
        ai->showWayPoints(wpid,pPlayer,ai->m_WayPointsShowBackwards);
      }

      ss << "Waypoint " << wpid << " has been moved.";
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPWaitCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    uint32 Wait = 10000;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      if(wp)
      {
        char* pWait = strtok((char*)args, " ");
	    Wait = (pWait)? atoi(pWait) : 10000;

        if(Wait < 5000)
        {
          FillSystemMessageData(&data, m_session, "A Wait Time of less then 5000ms can cause lag, consider extending it.");
          m_session->SendPacket( &data );
        }
        wp->waittime = Wait;

        //save wp
        ai->saveWayPoints(wpid);
      }

      ss << "Wait Time for Waypoint " << wpid << " is now " << Wait << "ms.";
      data.clear();
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPEmoteCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    uint32 EmoteId = 0;
    bool OneShot = true;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      if(wp)
      {
        char* pBackwards = strtok((char*)args, " ");
	    uint32 Backwards = (pBackwards)? atoi(pBackwards) : 0;
        char* pEmoteId = strtok(NULL, " ");
	    EmoteId = (pEmoteId)? atoi(pEmoteId) : 0;
        char* pOneShot = strtok(NULL, " ");
	    OneShot = (pOneShot)? atoi(pOneShot) : 1;
        if(Backwards)
        {
          wp->backwardemoteid = EmoteId;
          wp->backwardemoteoneshot = OneShot;
        }
        else
        {
          wp->forwardemoteid = EmoteId;
          wp->forwardemoteoneshot = OneShot;
        }

        //save wp
        ai->saveWayPoints(wpid);
      }

      ss << "EmoteID for Waypoint " << wpid << " is now " << EmoteId << " and oneshot is " << (OneShot == true)? "Enabled." : "Disabled.";
      data.clear();
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPSkinCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    uint32 SkinId = 0;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      if(wp)
      {
        char* pBackwards = strtok((char*)args, " ");
	    uint32 Backwards = (pBackwards)? atoi(pBackwards) : 0;
        char* pSkinId = strtok(NULL, " ");
	    SkinId = (pSkinId)? atoi(pSkinId) : 0;
        if(Backwards)
        {
          wp->backwardskinid = SkinId;
        }
        else
        {
          wp->forwardskinid = SkinId;
        }

        //save wp
        ai->saveWayPoints(wpid);
      }

      ss << "SkinID for Waypoint " << wpid << " is now " << SkinId;
      data.clear();
      FillSystemMessageData(&data, m_session, ss.str().c_str());
      m_session->SendPacket( &data );
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPInfoCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    if(GUID_HIPART(guid) != HIGHGUID_WAYPOINT)
    {
      FillSystemMessageData(&data, m_session, "You should select a Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }

    Player* pPlayer = m_session->GetPlayer();
    AIInterface* ai = pPlayer->waypointunit;
    std::stringstream ss;
    
    uint32 wpid = GUID_LOPART(guid);
    if((wpid > 0) && (wpid <= ai->m_nWaypoints))
    {
      WayPoint* wp = ai->getWayPoint(wpid);
      if(wp)
      {
          ss << "Waypoint Number " << wp->id << ":\n";
          ss << "WaitTime: " << wp->waittime << "\n";
          ss << "Flags: " << wp->flags;
          if(wp->flags == 768)
            ss << " (Fly)\n";
          else if(wp->flags == 256)
            ss << " (Run)\n";
          else
            ss << " (Walk)\n";
          ss << "Backwards\n";
          ss << "   emoteid: " << wp->backwardemoteid << "\n";
          ss << "   oneshot: " << ((wp->backwardemoteoneshot == 1)? "Yes" : "No") << "\n";
          ss << "   skinid: " << wp->backwardskinid << "\n";
          ss << "Forwards\n";
          ss << "   emoteid: " << wp->forwardemoteid << "\n";
          ss << "   oneshot: " << ((wp->forwardemoteoneshot == 1)? "Yes" : "No") << "\n";
          ss << "   skinid: " << wp->forwardskinid << "\n";
          SendMultilineMessage(ss.str().c_str());
      }
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Invalid Waypoint.");
      m_session->SendPacket( &data );
      return true;
    }
    return true;
}

bool ChatHandler::HandleWPHideCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a Creature.");
        m_session->SendPacket( &data );
        return true;
    }

    AIInterface* ai = pCreature->GetAIInterface();
    Player* pPlayer = m_session->GetPlayer();

    
    if(pPlayer->waypointunit == ai)
    {
      if(ai->m_WayPointsShowing == true)
      {
        pPlayer->waypointunit->hideWayPoints(NULL,pPlayer);
        pPlayer->waypointunit = NULL;
      }
    }
    else
    {
      FillSystemMessageData(&data, m_session, "Waypoints for that Unit are not Visible.");
      m_session->SendPacket( &data );
        return true;
    }

    std::stringstream ss;
    ss << "Hiding Waypoints for " << pCreature->GetGUIDLow();
    FillSystemMessageData(&data, m_session, ss.str().c_str());
    m_session->SendPacket( &data );

    return true;
}