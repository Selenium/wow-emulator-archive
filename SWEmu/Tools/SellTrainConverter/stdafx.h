// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once


#include <iostream>
#include <tchar.h>
#include <io.h>
#include <string>

struct _TrainerItem
{
	unsigned long CreatureTemplateGuid;
	unsigned long SpellID;
};

struct _SellItem
{
	unsigned long CreatureTemplateGuid;
	unsigned long SellID;
};

// TODO: reference additional headers your program requires here
