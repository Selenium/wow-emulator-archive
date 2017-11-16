#include "DatabaseInterface.h"
#include "Database.h"
#include "mysql.h"
#include <time.h>

DatabaseInterface::DatabaseInterface (void * db) : mDatabaseConnection ((MYSQL *)db) { }

DatabaseInterface::~DatabaseInterface () {
   mysql_close ((MYSQL *)mDatabaseConnection);
}

int DatabaseInterface::doQuery (const char * pquery) {
//   LOG.outString ((std::string("SQL: ") + query).c_str ());
   mysql_query ((MYSQL *)mDatabaseConnection, pquery);

   const char *err = mysql_error((MYSQL*)mDatabaseConnection);
   if (err && *err)
   {
      LOG.outString ("SQL ERROR: %s", err);
	  delete [] err;
	  return 0; //error
   }
   else
	   return mysql_field_count ((MYSQL *)mDatabaseConnection);
}

uint64 DatabaseInterface::doQueryId (const char * query) 
{
#ifdef DEBUG_VERSION
   LOG.outString ((std::string("SQL: ") + query).c_str ());
#endif
   mysql_query ((MYSQL *)mDatabaseConnection, query);
   const char *err = mysql_error((MYSQL*)mDatabaseConnection);
   if (err && *err)
   {
      LOG.outString ("SQL ERROR: %s", err);
	  delete [] err;
	  return 0; //we had an error
   }
   else
       return mysql_insert_id ((MYSQL *)mDatabaseConnection);
}

//called by realmlist server to refresh it's realmlist
void DatabaseInterface::load_realm_list()
{
   //char query[300];
   //strcpy(query, "");
   sprintf(query, "SELECT realmtype,flags,colour,name,address,country,unk,online,id FROM realm");
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   while ((row = mysql_fetch_row(res)))
   {
      //get for this realm how many players are online
      sprintf(query, "SELECT count(character_instances.id) FROM account,character_instances where account.id=character_instances.account_id and account.online!='0' and character_instances.realm_id=%d",atoi(row[8])); // FIX ME
      doQuery(query);
      MYSQL_RES *t_res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
      MYSQL_ROW t_row = mysql_fetch_row(t_res);

	  //LOG.outDebug("Got Realmlist from DB:\nRealmType: %d\nFlags: %d\nColour: %d\nName: %s\nAdress: %s\nCountry: %d\nunk: %d\nOnline: %d\nPopulation: %d", (uint8)atoi(row[0]), (uint8)atoi(row[1]), (uint8)atoi(row[2]), row[3], row[4], (uint8)atoi(row[5]), (uint8)atoi(row[6]), (uint8)atoi(row[7]), (uint32)t_row[0]);
      
	  REALMLISTSRV.addRealm( (uint8)atoi(row[0]), // RealmType
							 (uint8)atoi(row[1]), // Flags
							 (uint8)atoi(row[2]), // Colour
							  row[3],			  // Name
							  row[4],			  // Address
							  (uint32)atoi(t_row[0]),   // population
							  (uint8)atoi(row[5]),// Country
							  (uint8)atoi(row[6]),// unk
							  (uint8)atoi(row[7]) // online
							  );
	  mysql_free_result (t_res);
   }
   mysql_free_result (res);
}

//called by realmlistserver to check if the given username state
//this should be moved elsewhere
int DatabaseInterface::challenge_account_login(const char* userName,const char* ip)
{
   //char query[300];
   int ret=0x04;
   if(strlen(userName)>=30)
      return LOGIN_UNKNOWN_ACCOUNT;
   for (uint16 i=0; userName[i]!=0; ++ i)
   {
      if (!(
            (userName[i]>='a' && userName[i]<='z')
            ||
            (userName[i]>='A' && userName[i]<='Z')
            ||
            (userName[i]>='0' && userName[i]<='9')
            ||
            (userName[i]=='_' && userName[i]=='-')
         ))
         return LOGIN_UNKNOWN_ACCOUNT;
   }
   sprintf(query, "SELECT state,online FROM account where username='%s'",userName);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   uint16 numrows = (uint16)mysql_num_rows (res);
   MYSQL_ROW row = mysql_fetch_row(res);
   if(numrows!=0)
   {
	   if(atoi(row[0])!=0) ret=atoi(row[0]);
	   else 
	   {
			ret=LOGIN_ALREADYONLINE;
			if(atoi(row[1])==0 || strcmp(row[1],ip)==0)ret=LOGIN_OK; //login ok
	   }
   }
   else ret=LOGIN_UNKNOWN_ACCOUNT;
   //free result
   mysql_free_result (res);
   return ret;
}

//at logonchallenge we need the password for the account
char * DatabaseInterface::get_account_password(const char* username)
{
   //char query[300];
	sprintf(query, "SELECT password FROM account where username='%s'",username);
	doQuery(query);
	MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
	uint16 numrows = (uint16)mysql_num_rows (res);
	MYSQL_ROW row = mysql_fetch_row(res);
	if(numrows!=0) 
	{ 
		char *p = strnew(row[0]);
		mysql_free_result (res);
		return p;
	}
	else 
	{
		mysql_free_result (res);
		return strnew("");
	}
}

//save hash and make player apear as online
void DatabaseInterface::set_account_online(const char* username,const char* ssh_hash,const char* ip)
{
   sprintf(query,"UPDATE account set ssh_hash='%s',online='%s' where username='%s'",ssh_hash,ip,username);
   doQuery(query);
}

//at logonchallenge we need the password for the account
int DatabaseInterface::check_ip_blocked(const char* ip)
{
   //char query[300];
   int ret=0;
   sprintf(query, "SELECT count(id) FROM firewall where ip='%s'",ip);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   uint16 numrows = (uint16)mysql_num_rows (res);
   MYSQL_ROW row = mysql_fetch_row(res);
   ret=(int)atoi(row[0]);
   mysql_free_result (res);
   return ret;
}

void DatabaseInterface::set_players_offline()
{
   //char query[300];
   sprintf(query, "UPDATE character_instances set online='0',time_logoff='%u'",(uint32)time(NULL));
   doQuery(query);
   sprintf(query, "UPDATE account set online='0'");
   doQuery(query);
}

