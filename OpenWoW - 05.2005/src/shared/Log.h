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

#ifndef WOWPYTHONSERVER_LOG_H
#define WOWPYTHONSERVER_LOG_H

#include "Common.h"
#include "Singleton.h"
#include <iostream>

#define LOG (Log::getSingleton ())

class Log : public Singleton <Log>
{
	bool ScreenLogging;
public:
	Log()
	{ ScreenLogging = false; }
	~Log()
	{ }

	inline void SetScreenLogging (bool Enable)
	{ ScreenLogging = Enable; };
	inline bool GetScreenLogging ()
	{ return ScreenLogging; };

	void outString (const char * str, ...);
	void outError (const char * err, ...);

	template<class T> inline Log& operator << (const T& obj)
	{
		if (ScreenLogging)
			std::cout << obj;

		return *this;
	}

	//necessary for std::endl
	inline Log& operator << (std::ostream& (*obj)(std::ostream&))
	{
		if (ScreenLogging)
			std::cout << obj;

		return *this;
	}
};

#endif
