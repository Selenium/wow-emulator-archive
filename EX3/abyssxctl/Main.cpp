#include "CommonEnvironment.h"
#include "DatabaseEnvironment.h"
#include "ConfigEnvironment.h"

const char usage[] = "usage: abyssxctl start|stop|restart|zap|status|dbsetup|dbswitch|configtest\n"

void op_start();
void op_stop();
void op_restart();
void op_zap();
void op_status();
void op_dbsetup();
void op_dbswitch();
void op_configtest();

int main(int argc, char *argv[])
{
	new Config();
	if (!Config::GetSingleton().SetSource("AbyssX.conf"))
	{
		fprintf(stderr, "Could not open AbyssX.conf\n");
		delete Config::GetSingletonPtr();
		return 0;
	}
	if (argc < 2)
		printf(usage);
	else if (stricmp(argv[1], "start"))
		op_start();
	else if (stricmp(argv[1], "stop"))
		op_stop();
	else if (stricmp(argv[1], "restart"))
		op_restart();
	else if (stricmp(argv[1], "zap"))
		op_zap();
	else if (stricmp(argv[1], "status"))
		op_status();
	else if (stricmp(argv[1], "dbsetup"))
		op_dbsetup();
	else if (stricmp(argv[1], "dbswitch"))
		op_dbswitch();
	else if (stricmp(argv[1], "configtest"))
		op_configtest();
	else
		printf(usage);
	return 0;
}

void op_start()
{
}

void op_stop()
{
}

void op_restart()
{
}

void op_zap()
{
}

void op_status()
{
}

void op_dbsetup()
{
	Database *db;
	if (CONFIG(Database.DatabaseModule) == Config::DbMysql)
		new DatabaseMysql(CONFIG(Database.InfoString));
	if (CONFIG(Database.DatabaseModule) == Config::DbSqlite)
		new DatabaseSqlite(CONFIG(Database.InfoString));
	db = Database::GetSingletonPtr();
}

void op_dbswitch()
{
}

void op_configtest()
{
}


