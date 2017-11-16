#ifndef _BG_SETUP_H
#define _BG_SETUP_H

#include "StdAfx.h"
#include "CustomClass.h"
#include "HookMgr.h"

/* A hook defined to ALL_MAPS will be called regardless of the Map ID */
#define ALL_MAPS 0xFFFFFFFF

void RegisterMasterHooks(ScriptMgr * mgr);

#endif

