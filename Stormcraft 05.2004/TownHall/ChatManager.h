#pragma once

#define FUNCTYPE_ARGS 1
#define FUNCTYPE_STRING 2
struct MsgHandler
{
	char *cmd;
	int Userlevel;
	void *func;
	unsigned long funcType;
};

typedef void (*MsgFuncArgs)(CClient *pClient, char** argv, int argc);
typedef void (*MsgFuncString)(CClient *pClient, char *input);

class CChatManager
{
public:
	map<string, unsigned long> Mounts;
	map<string, unsigned long> WeaponInvFilter;
	map<string, unsigned long> ArmourInvFilter;
	map<string, unsigned long> InvTypes;
	map<string, int> UserLevels;
	map<string, unsigned long> Cloaks;
	CChatManager(void);
	~CChatManager(void);

	static void InitCloaks();
	static void MsgChat(CClient *pClient, _InData *pData);
};
