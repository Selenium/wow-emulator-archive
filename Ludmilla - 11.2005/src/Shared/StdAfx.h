#include "Common.h"

#include <stdlib.h>
#include <errno.h>
#include <assert.h>
#include <ctype.h>
#include <fcntl.h>
#include <stdio.h>
#include <string.h>
#include <stdarg.h>
#include <math.h>

#include <map>
#include <algorithm>

#include <openssl/bn.h>
                 
#include "ByteBuffer.h"
#include "Errors.h"
#include "Log.h"
#include "MemoryLeaks.h"
#include "Singleton.h"
#include "Timer.h"
#include "Util.h"
#include "WorldPacket.h"

#include "Auth/BigNumber.h"
#include "Auth/Sha1.h"

#include "Config/Config.h"
#include "Config/ConfigEnv.h"

#include "Database/DBC.h"
#include "Database/DBCStores.h"
#include "Database/DataStore.h"
#include "Database/Database.h"
#include "Database/DatabaseEnv.h"
#include "Database/DatabaseMysql.h"
#include "Database/DatabaseSqlite.h"
#include "Database/Field.h"
#include "Database/QueryResult.h"
#include "Database/QueryResultMysql.h"
#include "Database/QueryResultSqlite.h"

#define HAVE_OPENSSL
#define _THREADSAFE_SOCKETS
#undef IPPROTO_IPV6
#include <Sockets/Base64.h>
#include <Sockets/CircularBuffer.h>
#include <Sockets/ListenSocket.h>
#include <Sockets/Parse.h>
#include <Sockets/Socket.h>
#include <Sockets/SocketHandler.h>
#include <Sockets/StdLog.h>
#include <Sockets/TcpSocket.h>
#include <Sockets/UdpSocket.h>
#include <Sockets/Utility.h>
#include <Sockets/socket_include.h>
