// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once


#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers

// TODO: reference additional headers your program requires here

#include <CXX/Objects.hxx>
#include <CXX/Extensions.hxx>

#include "../Shared/Common.h"
#include "../Shared/Log.h"

#include "../Game/Creature.h"
#include "../Game/Player.h"
#include "../Game/QuestPacketHandler.h"
#include "../Game/ObjectMgr.h"
#include "../Game/GameObject.h"
#include "../Game/WorldSession.h"

#include "../LudMilla/Version/version.h"

#include "PyCreature.h"
#include "Scripts.h"