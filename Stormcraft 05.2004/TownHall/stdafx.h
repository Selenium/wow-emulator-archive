// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently,
// but are changed infrequently
#pragma warning(disable:4786)

#pragma once
#include "Defines.h"
#include "Structs.h"

#include <math.h>
#define Random(_min_,_range_) ((rand()%_range_)+_min_)

// WINDOWS/MFC
#ifdef WIN32
#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#include <io.h>
#include <stdio.h>
#include <tchar.h>
#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
#endif

#include <afx.h>
#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <iostream>
//#include <afxmt.h>
#include "WinThreading.h"
#include "winsock2.h"
#pragma comment(lib,"ws2_32.lib")
#define _FO_READ "rt"
#define _FO_WRITE "wt"
#define _FO_APPEND "at"
#define _FO_READB "rb"
#define _FO_WRITEB "wb"
#define _FO_APPENDB "ab"
#define socklen_t int
#define _FileExists(filename) ( (_access( filename, 0 )) != -1 )
#define MSG_NOSIGNAL 0

#else
// NON-WIN32 -- UNIX STUFF
#define WINAPI
#define LPVOID void *
#define DWORD unsigned long
#define UINT unsigned long
#define CHAR char
#define VOID void
#define ZeroMemory(_ptr_,_size_) memset(_ptr_,0,_size_)
#define stricmp strcasecmp
#define strnicmp strncasecmp
#include <netdb.h>
#include <netinet/in.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <sys/ioctl.h>
#include <memory.h>
#include <arpa/inet.h>
#include <errno.h>
#include <unistd.h>
#include <ctype.h>
#define SOCKET int
#define INVALID_SOCKET (-1)
#define SD_BOTH SHUT_RDWR
#define SOCKET_ERROR (-1)

#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>
#include "UnixThreading.h"
#define _FO_READ "r"
#define _FO_WRITE "w"
#define _FO_APPEND "a"
#define _FO_READB "r"
#define _FO_WRITEB "w"
#define _FO_APPENDB "a"
#define closesocket close
#define ioctlsocket ioctl
#define SOCKADDR sockaddr
#define SOCKADDR_IN sockaddr
#define LPHOSTENT hostent*
#define LPIN_ADDR in_addr*
#define TRUE 1
#define FALSE 0
#define WSAGetLastError() errno
#define WSAEISCONN EISCONN
#define WSAENOTCONN ENOTCONN
#define WSAECONNRESET ECONNRESET
#define WSAEWOULDBLOCK EWOULDBLOCK
#define WSAENETRESET ENETRESET
#define WSAENOTSOCK ENOTSOCK
#define WSAESHUTDOWN ESHUTDOWN
#define WSAEINVAL EINVAL
#define WSAECONNABORTED ECONNABORTED
#define BYTE unsigned char
#define _timeb timeb
#define _ftime ftime

#define _FileExists(thefilename) ( (access( thefilename, 0 )) != -1 )
#endif

// default storage system
#include "DefStorage.h"

