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

//////////////////////////////////////////////////////////////////////
//  MiscHandler
//
//  Temp home of all those opcodes that are in WorldServer.cpp
//////////////////////////////////////////////////////////////////////

#ifndef WOWPYTHONSERVER_MISCHANDLER_H
#define WOWPYTHONSERVER_MISCHANDLER_H

#include "MsgHandler.h"

struct SocialUserData
{
	uint32 guid;
	char *charname;
};

struct SocialData
{
	int pArraySize;
	SocialUserData *pSudata;
};

struct FriendData
{
	uint64 pGuid;
	unsigned char Status;
	uint32 tmpStatus;
    uint32 Level; 
	uint32 Class;
	uint32 Area;
};

class MiscHandler : public MsgHandler
{
	friend class WorldServer;
public:
	MiscHandler();
	~MiscHandler();

	void HandleMsg( wowWData & recv_data, GameClient *pClient );

protected:

};


#endif

