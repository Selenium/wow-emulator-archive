#include <signal.h>

#include <openssl/md5.h>

#include "../Shared/Common.h"
#include "../Shared/Portable.h"

#include "../Shared/Log.h"
#include "../Shared/Timer.h"

#include "../Shared/Config/ConfigEnv.h"

#include "../Shared/Database/DatabaseEnv.h"

#define HAVE_OPENSSL
#define _THREADSAFE_SOCKETS
#undef IPPROTO_IPV6
#include <Sockets/SocketHandler.h>
#include <Sockets/ListenSocket.h>
#include <Sockets/TcpSocket.h>

#include "../Game/World.h"

#include "../Spells/Spells.h"

extern void InitScripting();

#include "Version/version.h"
#include "Master.h"
#include "WorldRunnable.h"
#include "ConsoleCommands/AConsole.h"
#include "ConsoleCommands/ConsoleCmds.h"
