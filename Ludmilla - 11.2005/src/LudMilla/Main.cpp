#include "StdAfx.h"
// Copyright (C) 2005 WDDG

#ifdef _WIN32

	#ifdef _DEBUG
		#pragma comment(lib, "zlib1d.lib")		// zlib1d.dll
		#pragma comment(lib, "ZThread.lib")		// ZThread.dll
		#pragma comment(lib, "python24_d.lib")	// python24_d.dll
		#pragma comment(lib, "PyCXX.lib")		// static lib
		#pragma comment(lib, "dotconfpp.lib")	// static lib
		#pragma comment(lib, "libeay32.lib")	// libeay32.dll
		#pragma comment(lib, "ssleay32.lib")	// ssleay32.dll
		#pragma comment(lib, "Sockets.lib")		// static lib
		#pragma comment(lib, "sqlite3.lib")		// sqlite3.dll
		#pragma comment(lib, "libmysql.lib")	// libmysql.dll
	#else
		#pragma comment(lib, "zlib.lib")		// static lib
		#pragma comment(lib, "ZThread.lib")		// static lib
		#pragma comment(lib, "python24.lib")	// static lib
		#pragma comment(lib, "PyCXX.lib")		// static lib
		#pragma comment(lib, "dotconfpp.lib")	// static lib
		#pragma comment(lib, "libeay32.lib")	// static lib
		#pragma comment(lib, "ssleay32.lib")	// static lib
		#pragma comment(lib, "Sockets.lib")		// static lib
		#pragma comment(lib, "sqlite3.lib")		// static lib
		#pragma comment(lib, "libmysql.lib")	// libmysql.dll
	#endif

#endif

uint8 loglevel = DEFAULT_LOG_LEVEL;

int main( void )
{
	Master::getSingleton().Run();
    return 0;
}
