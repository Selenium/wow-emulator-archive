// (c) AbyssX Group
#if !defined(NETWORKENVIRONMENT_H)
#define NETWORKENVIRONMENT_H

//! Other libs we depend on.
#include "../Common/Common.h"
#include "../LogLibrary/LogEnvironment.h"
#include "Zlib/CompressionEnvironment.h"

//! Our own includes.
#ifdef WIN32
#include <winsock2.h>
#else
#include <unistd.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <sys/ioctl.h>
#include <netdb.h>
#define SOCKET int
#define INVALID_SOCKET (-1)
#define SOCKET_ERROR (-1)
#endif

#include "Client.h"
#include "ObjectUpdate.h"
#include "Packet.h"
#include "Lpacket.h"
#include "Server.h"

enum REALMLISTOPCODE
	{
	CHALLENGE = 0,
	PROOF = 1,
	RECODE_CHALLENGE = 2,
	RECODE_PROOF = 3,
	PLAYERS_UPDATE = 9,
	REALMLIST_REQUEST = 16,
};

#endif
