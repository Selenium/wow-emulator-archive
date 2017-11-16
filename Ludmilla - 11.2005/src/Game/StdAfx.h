#pragma once

#include <list>
#include <vector>
#include <map>
#include <sstream>
#include <string>

#include <zthread/Task.h>
#include <zthread/ZThread.h>

#include "../LudMilla/Version/version.h"

#include "../Shared/Common.h"
#include "../Shared/WorldPacket.h"
#include "../Shared/Log.h"
#include "../Shared/Util.h"
#include "../Shared/ByteBuffer.h"

#include "../Shared/Config/ConfigEnv.h"

#define HAVE_OPENSSL
#define _THREADSAFE_SOCKETS
#undef IPPROTO_IPV6
#include <Sockets/Utility.h>
#include <Sockets/TcpSocket.h>

#include "../Shared/Database/DatabaseEnv.h"
#include "../Shared/Database/DBCStores.h"
#include "../Shared/FactionTemplates.h"

#include "../Shared/Auth/BigNumber.h"
#include "../Shared/Auth/Sha1.h"
#include "../Shared/MersenneTwister.h"

#include "../Spells/Spells.h"

#include "Affect.h"
#include "Channel.h"
#include "ChannelMgr.h"
#include "Chat.h"
#include "Corpse.h"
#include "Creature.h"
#include "DynamicObject.h"
#include "GameObject.h"
#include "Group.h"
#include "Item.h"
#include "ItemPrototype.h"
#include "Mail.h"
#include "MapCell.h"
#include "MapMgr.h"
#include "MiscHandler.h"
#include "NPCHandler.h"
#include "NameTables.h"
#include "Object.h"
#include "ObjectMgr.h"
#include "Opcodes.h"
#include "Path.h"
#include "Player.h"
#include "Quest.h"
#include "Spell.h"
#include "Stats.h"
#include "Unit.h"
#include "UpdateData.h"
#include "UpdateFields.h"
#include "UpdateMask.h"
#include "World.h"
#include "WorldSession.h"
#include "QuestPacketHandler.h"
#include "QuestScriptBackend.h"

// Auto-Generated definition files
#include "Skill_Auto.h"

#ifdef WIN32
#	define CRTDBG_MAP_ALLOC
#	include <stdlib.h>
#	include <crtdbg.h>
#endif

#include "../Scripts/Scripts.h"

