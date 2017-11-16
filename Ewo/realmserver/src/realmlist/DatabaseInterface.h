#ifndef WOWPYTHONSERVER_DATABASEINTERFACE_H
#define WOWPYTHONSERVER_DATABASEINTERFACE_H 1

#include "RealmListSrv.h"
#include "Log.h"
#include "opcodes_realm.h"
#include "StringFun.h"

struct NetworkPacket;

class DatabaseInterface
{
	friend class Database;
public:
	int doQuery (const char * query);
	uint64 doQueryId (const char * query);

////////////////////////////////// BEGIN Realm Server interface ///////////////////////////////////
	//called by realmlist server to refresh it's realmlist
	void load_realm_list();
	//check if login is possible
	int challenge_account_login(const char* userName,const char* ip);
	char * get_account_password(const char* username);
	//save hash and make player apear as online
	void set_account_online(const char* username,const char* ssh_hash,const char* ip);
	//check if ip exists in firewall table
	int check_ip_blocked(const char* ip);
	//set all players offline (be carefull with this. If someone is online and you set it offline)
	void set_players_offline();
////////////////////////////////// END Realm Server interface /////////////////////////////////////
protected:
	char query[500];
	DatabaseInterface (void * handle);
	~DatabaseInterface ();
	/// Handle to the database connection represented by this object
	void * mDatabaseConnection;
};

#endif
