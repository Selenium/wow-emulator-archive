/************************************************************************************
 * RealmList file parser                                                             *
 ************************************************************************************/

// Copyright (C) 2005 Team WSD
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


#include <cstdlib>
#include <cstring>

/*
#if PLATFORM == PLATFORM_WIN32
char *index(char *s, int c)
{
	if(!s)
		return NULL;
	for(;*s!='\0';s++)
		if(*s==c)
			return s;
	return NULL;
}
#endif
*/

#include "RealmList.h"
#include "Log.h"

#undef MSG_HANDLERS
#define MSG_HANDLERS 512

createFileSingleton( RealmList );

RealmList::RealmList()
{
}

RealmList::~RealmList()
{
	if (fileHandler!=NULL)
		fclose(fileHandler);
}

int RealmList::isInitialized()
{
	if (fileHandler==NULL)
		return 0;
	return 1;
}

int RealmList::Initialize(const char* file)
{
	fileHandler=fopen(file, "r");
	if (fileHandler==NULL)
	{
		LOG.outError("You must give correct realmlist file.");
		return 0;
	}
	return 1;
}

int RealmList::getRealm(char* name, char* address, int* icon, int* color)
{
	if (fileHandler==NULL)
	{
		LOG.outError("You must give correct realmlist file.");
		return 0;
	}

	char line[MSG_HANDLERS];
	char *n, *a, *p, *i, *c;

	if( fgets(line, MSG_HANDLERS, fileHandler) != NULL )
	{
		if( *line == '#')
			return -1;
		char *end=strchr(line, '\n');
		if (end)
			*end='\0';
		n = strtok(line, ":");
		a = strtok(NULL, ":");
		p = strtok(NULL, ":");
		i = strtok(NULL, ":");
		c = strtok(NULL, "\0");
		if (!n || !a || !p || !i || !c)
		{
			LOG.outError("Realmlist file parse error.");
			return -1;
		}
		strcpy(name, n);
		strcpy(address, a);
		strcat(address, ":");
		strcat(address, p);
		*icon=atoi(i);
		*color=atoi(c);
		LOG.outString("Realm added: %s %s %d %d", name, address, *icon, *color);
		return 1;
	}
	else
	{
		rewind(fileHandler);
		return 0;
	}
}
