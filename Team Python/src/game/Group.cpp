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

#include "Character.h"
#include "WorldServer.h"
#include "Group.h"
#include "Opcodes.h"

void Group::ChangeLeader(char *tname)
{
	uint32 i;
	GameClient* tempClient;
    wowWData data;
	strcpy(leadername, tname);
	tempClient = WorldServer::getSingleton().GetClientByName(tname);
	leaderguid = tempClient->getCurrentChar()->getGUID();
	for(i=0;i<count;i++) {
		if (members[i].isleader == 1) {
			members[i].isleader = 0;
		}
	}
	for(i=0;i<count;i++) {
		if (strcmp(members[i].name,tname) == 0) {
			members[i].isleader = 1;
		}
	}
	for(i=0;i<count;i++) {
		tempClient = WorldServer::getSingleton().GetClientByName(members[i].name);
		tempClient->getCurrentChar()->SetLeader(tname);
		data.clear();
		data.Initialise( 1+ strlen(tname), SMSG_GROUP_SET_LEADER);
		data.writeData(tname, strlen(tname) + 1);
		tempClient->SendMsg( &data );
	}
	this->SendUpdate();
}


void Group::Disband()
{
	uint32 i;
	GameClient* tempClient;
    wowWData data;

	for(i=0;i<count;i++) {
		tempClient = WorldServer::getSingleton().GetClientByName(members[i].name);
		tempClient->getCurrentChar()->UnSetInGroup();
		data.clear();
		data.Initialise( 0, SMSG_GROUP_DESTROYED);
		tempClient->SendMsg( &data );
	}

}


void Group::SendUpdate()
{
	uint32 i ,j;
	GameClient* tempClient;
    wowWData data;
	int datalen;
	
	for(i=0;i<count;i++) {
		//datalen = 21 + 10*(count-1);
		datalen = 16 + 10*(count-1);
		tempClient = WorldServer::getSingleton().GetClientByName(members[i].name);
		for(j=0;j<count;j++) {
			if (strcmp(members[j].name, members[i].name) != 0) {
				datalen=datalen + strlen(members[j].name);
			}
		}
		data.clear();
		data.Initialise(datalen, SMSG_GROUP_LIST);
		data << uint32(count);
		for(j=0;j<count;j++) {
			if (strcmp(members[j].name, members[i].name) != 0) {
				data.writeData(members[j].name, strlen(members[j].name) + 1);
				data << uint32(members[j].guid) << uint32(0);
				if (members[j].isleader == 1) {
					data << uint8(0x01);
				}
				else {
					data << uint8(0x00);
			
				}
			}
		}
		//data << uint32(leaderguid) << uint32(0) << uint64(0) << uint8(0);
		data << uint16(0) << uint64(leaderguid) << uint8(0) << uint8(1);
		tempClient->SendMsg( &data );
	}

}

int Group::DelMember(char * tname) {
	uint32 i;
	uint32 j;
	int leaderflag = 0;
	for(i=0;i<count;i++) {
		if (strcmp(members[i].name,tname) == 0) {
			leaderflag = members[i].isleader;
			for(j=i+1;j<count;j++) {
				members[j-1].isleader = members[j].isleader;
				members[j-1].guid = members[j].guid;
				strcpy(members[j-1].name,members[j].name);
			}
			break;
		}
	}
	count--;	
	if ((count > 1) && (leaderflag)) {
		this->ChangeLeader(members[0].name);
	}
	return count; 
}
