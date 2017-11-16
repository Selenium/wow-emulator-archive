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
 
 
#ifndef WSDSERVER_ACCOUNTS_H
#define WSDSERVER_ACCOUNTS_H

#include "Common.h"
#include "Singleton.h"
#include "Log.h"

#define ACCOUNTS (Accounts::getSingleton ())

class Accounts : public Singleton< Accounts >
{
	private:
		FILE* fileHandler;

	public:

		Accounts();
		~Accounts();

		void uppercase(char *s, int l);
		int Initialize(const char*);
		int isInitialized();
		int login(const char*, char*);
};

#endif
