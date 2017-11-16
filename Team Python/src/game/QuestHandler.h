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

#ifndef WOWPYTHONSERVER_QUESTHANDLER_H
#define WOWPYTHONSERVER_QUESTHANDLER_H

#include "MsgHandler.h"

class Quest;
class QuestHandler : public MsgHandler
{
public:
	QuestHandler();
	~QuestHandler();

	void HandleMsg( wowWData & recv_data, GameClient *pClient );
    void addQuest(Quest *pQuest);
    Quest* getQuest(uint32 quest_id);
    void SetNpcFlagsForTalkToQuest(GameClient* pClient, uint32 guid1, uint32 targetGuid);
protected:
    // Quest data 
    typedef std::map<uint32, Quest*> QuestMap;
    QuestMap mQuests;
};


#endif

