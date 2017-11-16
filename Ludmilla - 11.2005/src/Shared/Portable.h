//
// (c) PavkaM. For LudMilla Project
//     All right reserved.
//
// Contains all portable definitions

#ifndef _PORTABLE_H_
#define _PORTABLE_H_


// current platform and compiler
#define PLATFORM_WIN32 0
#define PLATFORM_UNIX  1
#define PLATFORM_APPLE 2

#if defined( __WIN32__ ) || defined( WIN32 ) || defined( _WIN32 )
#  define PLATFORM__ PLATFORM_WIN32
#elif defined( __APPLE_CC__ )
#  define PLATFORM__ PLATFORM_APPLE
#else
#  define PLATFORM__ PLATFORM_UNIX
#endif

#if PLATFORM__ == PLATFORM_WIN32
#  include <dotconfpp/dotconfpp.h>
#  include <dotconfpp/mempool.h>
#  include <sqlite3/sqlite3.h>
#  include <zlib/zlib.h>
#  include <winsock2.h>
#  include <ws2tcpip.h>
#  include <io.h>
#  include <hash_map>
#  include <python/Python.h>
#else
#  include <sys/types.h>
#  include <sys/ioctl.h>
#  include <sys/socket.h>
#  include <netinet/in.h>
#  include <netinet/tcp.h>
#  include <unistd.h>
#  include <signal.h>
#  include <netdb.h>
#  include <dotconf++/dotconfpp.h>
#  include <dotconf++/dotconfpp.h>
#  include <sqlite3.h>
#  include <zlib.h>
#  include <termios.h>
#  include <ext/hash_map>
#  include <set>
#  include <Python.h>

// -- Specific TCP shutdown option
#  define SD_RECEIVE SHUT_RD

#endif

#define COMPILER_MICROSOFT 0
#define COMPILER_GNU       1
#define COMPILER_BORLAND   2

#undef COMPILER
#undef PLATFORM
#define PLATFORM PLATFORM__

#ifdef _MSC_VER
#  define COMPILER COMPILER_MICROSOFT
#elif defined( __BORLANDC__ )
#  define COMPILER COMPILER_BORLAND
#elif defined( __GNUC__ )
#  define COMPILER COMPILER_GNU
#else
#  pragma error "FATAL ERROR: Unknown compiler."
#endif

#if COMPILER == COMPILER_MICROSOFT
#  pragma warning( disable : 4267 ) // conversion from 'size_t' to 'int', possible loss of data
#  pragma warning( disable : 4786 ) // identifier was truncated to '255' characters in the debug information
#endif


#if COMPILER == COMPILER_GNU

//  Min/Max

#define min(x,y) (x<y)?x:y
#define max(x,y) (x>y)?x:y

//  Str Funcs 

#define strcmpi strcasecmp
#define stricmp strcasecmp
#define strnicmp strncasecmp
// --------

#define __fastcall __attribute__((__fastcall__))
#else

# define MIN min
# define MAX max

#endif



// ------> Linux/Win32 specifics <---------- 

#ifdef _WIN32
#pragma warning(disable:4786)

#define STRCASECMP stricmp

#ifndef strcasecmp
#  define strcasecmp stricmp
#endif

#else

#define STRCASECMP strcasecmp

#endif


#include "OurDefs.h"

#ifdef _WIN32
	#define snprintf _snprintf
	#define atoll __atoi64
#endif


#ifdef _WIN32
# define _MTRAND_ 0xFFFFFFFFFFFFFFFFUL
#else
# define _MTRAND_ 0xFFFFFFFF
#endif

#ifdef _WIN32
# define __getpacktime __getpacktime_win32
uint32 __getpacktime_win32();
#else
# define __getpacktime __getpacktime_unix
uint32 __getpacktime_unix();
#endif


#ifndef _WIN32
 char *strlwr(char *a);
#endif


#endif