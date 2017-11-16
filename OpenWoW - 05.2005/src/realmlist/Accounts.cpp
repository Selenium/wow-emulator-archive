/************************************************************************************
 * Accounts file parser                                                             *
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
char *index(char *s, int c);
#endif
*/

#include "Accounts.h"
#include "RealmList.h"
#include "Log.h"

#undef MSG_HANDLERS
#define MSG_HANDLERS 512

createFileSingleton( Accounts );

Accounts::Accounts()
{
}

Accounts::~Accounts()
{
	if (fileHandler!=NULL)
		fclose(fileHandler);
}

void Accounts::uppercase(char *s, int l)
{
	int i;
	for(i=0; i<l; i++)
		s[i]=toupper(s[i]);
}

int Accounts::isInitialized()
{
	if (fileHandler==NULL)
		return 0;
	return 1;
}

int Accounts::Initialize(const char* file)
{
	fileHandler=fopen(file, "r");
	if (fileHandler==NULL)
	{
		LOG.outError("You must give correct accounts file.");
		return 0;
	}
	return 1;
}

int Accounts::login(const char* userName, /*char* salt,*/ char* passwd)
{
    if (fileHandler==NULL)
	{
		LOG.outError("You must give correct accounts file.");
		return -2;
	}
			
	char line[MSG_HANDLERS];
	char *u, /**s,*/ *p;

	rewind(fileHandler);
	while( fgets(line, MSG_HANDLERS, fileHandler) != NULL )
	{
		if( *line == '#')
			continue;
		char *end=strchr(line, '\n');
		if (end)
			*end='\0';
		u = strtok(line, ":");
		if (!u)
		{
			LOG.outError("Accounts file parse error.");
			return -2;
		}
		uppercase(u, strlen(u));
		if (!strcmp(userName, u))
		{
//			s = strtok(NULL, ":");
			p = strtok(NULL, "\0");
			if (/*s &&*/ p)
			{
				uppercase(p, strlen(p));
				strcpy(passwd, p);
				return 1;
				/*
				if(!strcmp(hash, h))
				{
					LOG.outString("User: %s authenticated", userName);
					return 1;
				}
				//wrong login
				return -1;
				*/
			}
			LOG.outError("Accounts file parse error.");
			return -2;
		}
	}
	LOG.outString("User: %s not found in the accounts file.", userName);
	return -3;
}
