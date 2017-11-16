#ifndef SPELL_H
#define SPELL_H

#include "stdafx.h"
#include "WoWObject.h"
#include "DataBuffer.h"
#include "Client.h"
#include "dbc_structs.h"
#include "Packets.h"

enum SPELLSTATES
{
	SPELL_STATE_NULL      = 0,
	SPELL_STATE_PREPARING = 1,
	SPELL_STATE_CASTING   = 2,
	SPELL_STATE_FINISHED  = 3,
	SPELL_STATE_IDLE      = 4
};

enum SPELLTARGETS
{
	TARGET_FLAG_SELF             = 0x0,
	TARGET_FLAG_UNIT             = 0x0002,
	TARGET_FLAG_OBJECT           = 0x0800,
	TARGET_FLAG_ITEM             = 0x1010,
	TARGET_FLAG_SOURCE_LOCATION  = 0x20,
	TARGET_FLAG_DEST_LOCATION    = 0x40,
	TARGET_FLAG_STRING           = 0x2000
};

struct guid_struct
{
	guid_t guid;
	guidhigh_t guidhigh;
};

class CSpell: public CWoWObject
{
public:
	CSpell(unsigned long SpellID);
	~CSpell(void);

	guid_t Caster;
	unsigned long CastTime;
	unsigned long SpellID;
	guid_t Target;
	guidhigh_t TargetType;
	unsigned short TargetFlag;
	guid_struct TargetMap[200]; // maximum of 8*25 targets
	unsigned char TargetCount;
	long NextAttackBaseDmg;
	_Location SrcLoc;
	_Location DestLoc;
	string strTarget;
	SpellRec SpellInfo;

	CClient *pClient;

	void Clear();
	void New();

	void CastSpellStart(CDataBuffer &Data);
	void CastSpell();

	void SendStartSpell(CDataBuffer &Data);
	void SendSpellResult();
	void SendSpellGo();
	void SpellFail();
	void SpellFail(unsigned char reason);
	void SpellFail(unsigned char reason, char *msg);
	void SendSpellEffects(guid_t target);
	long SendChannelStart();
	void SendNonMeleeDamageLog(long damage);

	void Cancel();
	void ProcessEvent(WoWEvent &Event);
	int GetTargets(_Location &Loc);

	long getPower(unsigned long spell, unsigned long effect);
	long getComboPower(unsigned long spell, unsigned long effect,unsigned long combopts);
	bool ValidateAction();
	void SpellDelay(void);
};

#endif // SPELL_H
