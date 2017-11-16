#include "StdAfx.h"

#ifdef _WIN32
uint32 __getpacktime_win32()
{
	SYSTEMTIME	sysT;

	GetSystemTime (&sysT);
	DWORD t = (DWORD)(sysT.wMilliseconds << 16) 
			+ (WORD)(sysT.wSecond * sysT.wMinute * 60 
			+ sysT.wHour * 3600);
	return t;
}
#else
uint32 __getpacktime_unix()
{
	uint32 t = (uint32)time(NULL);
	return t;
}
#endif


#ifndef _WIN32
char *strlwr(char *a) {
	char *b=a;
	while (*a) { *a = tolower(*a); a++; }
	return b;
}
#endif
