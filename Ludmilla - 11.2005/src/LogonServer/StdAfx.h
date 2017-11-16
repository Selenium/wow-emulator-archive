//for RealmList.h
#include <map>
#include <string>

// for LogonSocket.h
#include <openssl/md5.h>
#include <vector>
#include <queue>
#define HAVE_OPENSSL
#define _THREADSAFE_SOCKETS
#undef IPPROTO_IPV6
#include <Sockets/TcpSocket.h>
#include <Sockets/SocketHandler.h>

//for  LogonSocket.cpp
#include <sstream>
#ifdef _WIN32
	#include <io.h>
#endif
