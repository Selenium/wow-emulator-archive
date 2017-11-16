// (c) AbyssX Group
#if !defined(COMMON_H)
#define COMMON_H

//! Our system-level includes.
#include <stdio.h>
#include <time.h>
#include <sys/timeb.h>
#include <string.h>
#include <stdarg.h>
#include <math.h>
#include <signal.h>

//! We of course need STL.
#include <string>
#include <list>
#include <map>
#include <vector>
//! To make using STL easier on da fingers.
using namespace std;

//! Conditionals for cross-platform zen.
#ifdef WIN32
#define I64FMT "%016I64X"
#define I64FMTD "%I64u"
#define SI64FMTD "%I64d"
#define snprintf _snprintf
#define atoll __atoi64
#else
#define stricmp strcasecmp
#define strnicmp strncasecmp
#define I64FMT "%016llX"
#define I64FMTD "%llu"
#define SI64FMTD "%lld"
#endif

//! Our own helpful things.
#include "Types.h"
#include "Constants.h"
#include "Singleton.h"

#endif
