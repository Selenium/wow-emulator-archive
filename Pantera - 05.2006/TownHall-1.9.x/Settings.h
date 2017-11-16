#ifndef SETTINGS_H
#define SETTINGS_H

#include "stdafx.h"
#define DEF_VAL 0

struct _UserLevelSettings
{
	char Spawn;
	char Rehash;
	char Item;
	char Morph;
};

class CSettings
{
public:
	CSettings(void);
	~CSettings(void);
	void DefaultSettings();
	void LoadSettings();
	void StoreSettings();

	_UserLevelSettings UserLevels;

	unsigned int max_connections;
	char const *server_welcome_message;
	char const *server_owner;
	char const *admin_password;
	const char *dbc_path;
	const char *accounts_path;
	bool AllowNewAccounts;
	bool PvPServer;
	unsigned long MinUserLevel;
	bool AllowGMCommand;
	char const *AdminPass;
	char const *GMPass;
	map<unsigned long,char> Banned;
	unsigned long Port_Realm,/*Port_Redirect,*/Port_Masterlist,Port_Sessionkey;

private:

	char *File_GetLine(FILE *fp);
	void Handle_Setting(char const * setting, char const * value);
};

#endif // SETTINGS_H
