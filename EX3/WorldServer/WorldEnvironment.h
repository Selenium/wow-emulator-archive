// (c) AbyssX Group
#if !defined(WORLDENVIRONMENT_H)
#define WORLDENVIRONMENT_H

//! Other libs we depend on.
#include "../Common/Common.h"
#include "../ConfigLibrary/ConfigEnvironment.h"
#include "../LogLibrary/LogEnvironment.h"
#include "../NetworkLibrary/NetworkEnvironment.h"
#include "../DatabaseLibrary/DatabaseEnvironment.h"

//! CROSS DEPENDENCY - Region needs Object, and Object needs Region
class Object;
class Groups;
class GroupsData;
class Combat;
class Player;
class VENDOR;
class VENDOR_DB;
class EventSystem;
class Timer;
class Player_Item;
class Item;
class TaxiNodes;
class TaxiPaths;
class TaxiPathNodes;
class Spell;

#define GROUPS
#define COMBAT
#define MOBS
#define IRCBOT
#define NPCS
#define EVENTSYSTEM
#define ITEMS
#define CHANNELS
//#define SPELLS
#define WORLDPORTS
#define CHAMPIOSHIP


//! For Channels cross-dependancy
class Channel;
class ChannelManager;
class ChannelHandler;

#define CM_CHANNEL_ANNOUNCE 1
#define CM_CHANNEL_PASSWORDED 2
#define CM_CHANNEL_MODERATED 4

#define CM_PLAYER_OWNER 1
#define CM_PLAYER_MUTED 2
#define CM_PLAYER_MODERATOR 4

//! IRCBot
#ifdef IRCBOT
#include "IRCBot/IRCBot.h"
#endif

//! Regions
#include "Regions/Region.h"
#include "Regions/RegionList.h"
#include "Regions/RegionManager.h"

//! Objects
#include "Objects/Object.h"
#include "Objects/GameObject.h"
#include "Objects/Unit.h"
#include "Objects/Mob.h"
#include "Objects/Player.h"
#include "Objects/ObjectManager.h"

//! Groups
#ifdef GROUPS
#include "Groups/GroupsHandler.h"
#include "Groups/GroupData.h"
#endif

//! Combat
#ifdef COMBAT
#include "Combat/MeleeHandler.h"
#endif

//! Monster Database & Handler
#ifdef MOBS
#include "Mobs/mob_db.h"
#include "Mobs/population.h"
#include "Mobs/MonsterHandler.h"
#endif

//! Players
#include "Players/PlayersHandler.h"

//! NPCS
#ifdef NPCS
#include "npcs/npcs.h"
#include "npcs/VendorsHandler.h"
#include "npcs/vendor_items_db.h"
#include "npcs/TaxiHandler.h"
#include "npcs/TaxiNodes.h"
#include "npcs/TaxiPaths.h"
#include "npcs/TaxiPathNodes.h"
#endif

//! EVENT SYSTEM
#ifdef EVENTSYSTEM
#include "EventSystem/eventsystem.h"
#include "EventSystem/Timer.h"
#endif

//! WorldPorts
#ifdef WORLDPORTS
#include "WorldPorts/WorldPort.h"
#include "WorldPorts/WorldPort_db.h"
#endif

#ifdef ITEMS
//! Items
#include "Items/Item.h"
#include "Items/Items_Handler.h"
#include "Items/Player_Items.h"
#endif

//! Packets
#include "../NetworkLibrary/Packets.h"

#ifdef CHANNELS
//! Channels
#include "Channels/Channel.h"
#include "Channels/ChannelManager.h"
#include "Channels/ChannelHandler.h"
#endif

//! Spells
#ifdef SPELLS
#include "Spells/spellhandler.h"
#include "Spells/Spell.h"
#endif

//! Champioship
#ifdef CHAMPIOSHIP
#include "Champioship/ChampioshipHandler.h"
#endif

//! WorldServer
#include "WorldServer.h"

#endif
