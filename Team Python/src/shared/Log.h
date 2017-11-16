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

class Log : public Singleton< Log > {
public:
  void outString( const char * str, ... );
  void outError( const char * err, ... );
  bool bLoggingScr;
  //Start M4rku5 Code
  inline bool IsLoggingScreen() { return bLoggingScr; };
  inline void toggleScreenLogging() { bLoggingScr = !bLoggingScr; };
  //End M4rku5 Code
};

template<class T>
inline Log& operator<<(Log& log, const T& obj)
{
	if(log.IsLoggingScreen())
		std::cout << obj;

	return log;
}

//necessary for std::endl
inline Log& operator<<(Log& log, std::ostream& (*obj)(std::ostream&))
{
	if(log.IsLoggingScreen())
		std::cout << obj;

	return log;
}

#endif