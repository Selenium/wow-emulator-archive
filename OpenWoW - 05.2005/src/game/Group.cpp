//////////////////////////////////////////////////////////////////////
//  Group
//
//  Provides basic Group functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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
	NetworkPacket data;
	strcpy(leadername, tname);
	tempClient = WORLDSERVER.GetClientByName(tname);
	leaderguid = tempClient->getCurrentChar()->getGUID().sno;
	for (i = 0; i < count; i++) {
		if (members[i].isleader == 1) {
			members[i].isleader = 0;
		}
	}
	for (i = 0; i < count; i++) {
		if (strcmp(members[i].name,tname) == 0) {
			members[i].isleader = 1;
		}
	}
	for (i = 0; i < count; i++) {
		tempClient = WORLDSERVER.GetClientByName(members[i].name);
		tempClient->getCurrentChar()->SetLeader(tname);
		data.Clear();
		data.Initialize (1+ strlen(tname), SMSG_GROUP_SET_LEADER);
		data.WriteData(tname, strlen(tname) + 1);
		tempClient->SendMsg (&data);
	}
	this->SendUpdate();
}


void Group::Disband()
{
	uint32 i;
	GameClient* tempClient;
	NetworkPacket data;

	for (i = 0; i < count; i++) {
		tempClient = WORLDSERVER.GetClientByName(members[i].name);
		tempClient->getCurrentChar()->UnSetInGroup();
		data.Clear();
		data.Initialize (0, SMSG_GROUP_DESTROYED);
		tempClient->SendMsg (&data);
	}

}


void Group::SendUpdate()
{
/*
SMSG_GROUP_LIST
2 bytes //spacer ??
1 byte //membercount-1
1 byte //spacer ??

//for each member but the one getting it
1 byte //slotnumber starting at 0 ??
1 byte //spacer ??
member name
1 byte //spacer ??
4 bytes //member guid
4 bytes //unk2.1 //spacer

1 byte //unk2.2 // always 1
1 byte //unk2.3
4 bytes //leader guid
4 bytes //unk3 spacer??
1 byte // lootmethord
4 bytes // lootmaster
4 bytes /unk4.1
1 byte //loot threshold
*/
	uint32 i ,j, slot;
	GameClient* tempClient;
	NetworkPacket data;
	int datalen;
	
	for (i = 0; i < count; i++)
	{
		slot = 0;
		datalen = 24 + 11*(count-1);
		tempClient = WORLDSERVER.GetClientByName(members[i].name);
		for (j = 0; j < count; j++) {
			if (strcmp(members[j].name, members[i].name) != 0) {
				datalen=datalen + strlen(members[j].name);
			}
		}
		data.Clear();
		data.Initialize(datalen, SMSG_GROUP_LIST);
		data << uint16(0); // 2 bytes spacer
		data << uint8(count - 1); //members Count -1
		data << uint8(0); // 1 byte spacer
		for (j = 0; j < count; j++) { //for each member
			if (strcmp(members[j].name, members[i].name) != 0) { //only if it's not the person getting the list
				data << uint8(slot); //slot number
				slot ++;
				data << uint8(0); //spacer
				data.WriteData(members[j].name, strlen(members[j].name) + 1); //members name + 1 byte spacer
				data << uint32(members[j].guid); //members guid
				data << uint32(0); // 4 bytes spacer
			}	
		}
		data << uint8(1); //unk but always 1 
		data << uint8(0); //spacer
		data << uint32(leaderguid); //leaderguid
		data << uint32(0); //spacer
		data << uint8(lootmethod); //loot methord
		data << uint32(looterguid); // lootmaster guid
		data << uint32(0); //spacer
		data << uint8(lootthreshold); //loot threshold is either 0, 2 or 4
		tempClient->SendMsg (&data);
	}
}

int Group::DelMember(char * tname) {
	uint32 i;
	uint32 j;
	int leaderflag = 0;
	for (i = 0; i < count; i++) {
		if (strcmp(members[i].name,tname) == 0) {
			leaderflag = members[i].isleader;
			for (j = i + 1; j < count; j++) {
				members [j - 1].isleader = members[j].isleader;
				members [j - 1].guid = members[j].guid;
				strcpy (members [j - 1].name, members [j].name);
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
