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

#ifndef WOWPYTHONSERVER_GROUP_H
#define WOWPYTHONSERVER_GROUP_H

#define MAXGROUPSIZE 5

class Group 
{
	public:
		Group() {
			count = 0;
			leaderguid = 0;
			lootmethod = 0;
			looterguid = 0;
			memset(members, 0 ,MAXGROUPSIZE * (22 + sizeof(int) + 4));
		}
		~Group() {
//			delete [] members;
		}
		void Create(char * tleadername, uint32 tleaderguid) {
			leaderguid = tleaderguid;
			strcpy(leadername,tleadername);
		}
		void AddMember(char * tname, uint32 tguid, int tisleader) {
			members[count].isleader = tisleader;
			members[count].guid = tguid;
			strcpy(members[count].name,tname);
			count++;	
		}
		void ChangeLeader(char * tname);
		int DelMember(char * tname);
		int IsFull() {
			return count == MAXGROUPSIZE ? 1 : 0;
		}
		
		void SendUpdate();
		void Disband();

		uint32 leaderguid;
		char leadername[22];

		typedef struct {
			char name[22];
			uint32 guid;
			int isleader;
		} MemberSlot;

		MemberSlot members[MAXGROUPSIZE];
		
		uint32 count;

		uint32 lootmethod;
		uint32 looterguid;

};



#endif
