#include "Settings.h"
#include "Globals.h"
#include "TCPSocket.h"

CSettings::CSettings(void)
{
	DefaultSettings();
}

CSettings::~CSettings(void)
{
	//Free all to avoid any warning
	if (server_welcome_message)
		free((void *)server_welcome_message);
	if (server_owner)
		free((void *)server_owner);
	if (dbc_path)
		free((void *)dbc_path);
	if (admin_password)
		free((void *)admin_password);
}

void CSettings::DefaultSettings()
{
	//Default settings (will be overridden in the loading of settings)
	max_connections = 10;
	server_welcome_message = strdup("Welcome to StormCraft Town Hall");
	server_owner = strdup("someone");
	dbc_path = strdup("data/dbc/");
	AllowNewAccounts=true;
	MinUserLevel=USER_NORMAL;
	admin_password = strdup("*admin_stormcraft*");
	UserLevels.Rehash=USER_ADMIN;
	UserLevels.Spawn=USER_MODERATOR;
	UserLevels.Item=USER_GM;
}

//Added method to Class so we can handle all settings populating in 1 section
//instead of scrolling through a huge section in LoadSettings method.
//EveOfDestruxtion 1/25/2004
void CSettings::Handle_Setting(char const *setting, char const *value)
{
#define CopyString(destvar) {if (destvar) free((void *)destvar); destvar = strdup(value);}
	if(stricmp(setting,"maxallowconnections") == 0)
		max_connections = atoi(value);
	else if(stricmp(setting,"server_welcome_message") == 0)
	{
		CopyString(server_welcome_message);
	}
	else if(stricmp(setting,"server_owner_name")==0)
	{
		CopyString(server_owner);
	}
	else if(stricmp(setting,"realmlist")==0)
	{
		// add realm list
		char IPAddr[16];
		if (TCPSocket::GetHostByName(value,IPAddr))
		{
			Addr *MainList=new Addr;
			memset(MainList,0,sizeof(Addr));
			MainList->sa_family=2;
			MainList->IP=inet_addr(IPAddr);
			MainList->Port=htons(9111);
			RealmServer.MasterLists+=MainList;
		}
	}
	else if(stricmp(setting,"server_address") == 0)
	{
		TCPSocket::GetHostByName(value,RealmServer.IPAddr);
	}
	else if(stricmp(setting,"server_name") == 0)
	{
		strncpy(RealmServer.Name,value,64);
		RealmServer.Name[63]=0;
	}
	else if(stricmp(setting,"dbc_path") == 0)
	{
		CopyString(dbc_path);
	}
	else if(!stricmp(setting,"allow_new_accounts"))
	{
		AllowNewAccounts=(atoi(value)!=0);
	}
	else if (!stricmp(setting,"min_user_level"))
	{
		MinUserLevel=atoi(value);
	}
	else if (!stricmp(setting,"gmlevel_spawn"))
	{
		UserLevels.Spawn=atoi(value);
	}
	else if (!stricmp(setting,"admin_password"))
	{
		CopyString(admin_password);
	}
	else if(Storage.Handle_Setting(setting,value))
	{	
		// specialized storage settings. if return value is true,
		// the setting has been processed.
	}


#undef CopyString
}


void CSettings::LoadSettings()

{

	FILE *file;
	char *       buff;
	char *       cp;
	char *       temp;
	unsigned int currline;
	unsigned int j;
	char const * directive;
	char const * value;
	char *       rawvalue;

	if(!(file = fopen("Conf/TownHall.conf",_FO_READ)))
		return;

	// Read the configuration file 
	for (currline=1; (buff = File_GetLine(file)); currline++)
	{
	    cp = buff;
	    
        while (*cp=='\t' || *cp==' ') cp++;
	    if (*cp=='\0' || *cp=='#')
	    {
		free(buff);
		continue;
	    }
	    temp = cp;
	    while (*cp!='\t' && *cp!=' ' && *cp!='\0') cp++;
	    if (*cp!='\0')
	    {
		*cp = '\0';
		cp++;
	    }
	    if (!(directive = strdup(temp)))
	    {
		free(buff);
		continue;
	    }
        while (*cp=='\t' || *cp==' ') cp++;
	    if (*cp!='=')
	    {
		free((void *)directive); /* avoid warning */
		free(buff);
		continue;
	    }
	    cp++;
	    while (*cp=='\t' || *cp==' ') cp++;
	    if (*cp=='\0')
	    {
		free((void *)directive); /* avoid warning */
		free(buff);
		continue;
	    }
	    if (!(rawvalue = strdup(cp)))
	    {
		free((void *)directive); /* avoid warning */
		free(buff);
		continue;
	    }
    
	    if (rawvalue[0]=='"')
	    {
		char prev;
		
		for (j=1,prev='\0'; rawvalue[j]!='\0'; j++)
		{
		    switch (rawvalue[j])
		    {
		    case '"':
			if (prev!='\\')
			    break;
			prev = '"';
			continue;
		    case '\\':
			if (prev=='\\')
			    prev = '\0';
			else
			    prev = '\\';
			continue;
		    default:
			prev = rawvalue[j];
			continue;
		    }
		    break;
		}
		if (rawvalue[j]!='"')
		{
		    free(rawvalue);
		    free((void *)directive); /* avoid warning */
		    free(buff);
		    continue;
		}
		rawvalue[j] = '\0';
		if (rawvalue[j+1]!='\0' && rawvalue[j+1]!='#')
		{
		    free(rawvalue);
		    free((void *)directive); /* avoid warning */
		    free(buff);
		    continue;
		}
		value = &rawvalue[1];
		}
	    else
	    {
		unsigned int k;
		
		for (j=0; rawvalue[j]!='\0' && rawvalue[j]!=' ' && rawvalue[j]!='\t'; j++);
		k = j;
		while (rawvalue[k]==' ' || rawvalue[k]=='\t') k++;
		if (rawvalue[k]!='\0' && rawvalue[k]!='#')
		{
		    free(rawvalue);
		    free((void *)directive); /* avoid warning */
		    free(buff);
		    continue;
		}
		rawvalue[j] = '\0';
		value = rawvalue;
	    }
            
		// Check directive and populate proper setting value
		Handle_Setting(directive,value);

	    free(rawvalue);
	    free((void *)directive); /* avoid warning */
	    free(buff);
	}

	fclose(file);

}






char * CSettings::File_GetLine(FILE *fp)
{
	char *       line;
    char *       newline;
    unsigned int len=64;
    unsigned int pos=0;
    int          prev_char,curr_char;
   
	if (!(line = (char *) malloc(64)))
		return NULL;
    
    prev_char = '\0';
    
	while ((curr_char = fgetc(fp))!=EOF)
    {
	if (((char)curr_char)=='\r')
	    continue; /* make DOS line endings look Unix-like */
	if (((char)curr_char)=='\n')
	{
	    if (pos<1 || ((char)prev_char)!='\\')
		break;
	    pos--; /* throw away the backslash */
	    prev_char = '\0';
	    continue;
	}
	prev_char = curr_char;
	
	line[pos++] = (char)curr_char;
	if ((pos+1)>=len)
	{
	    len += 16;
		if (!(newline = (char *) realloc(line,len)))
	    {
		free(line);
		return NULL;
	    }
	    line = newline;
	}
    }
    
    if (curr_char==EOF && pos<1) /* not even an empty line */
    {
	free(line);
	return NULL;
    }
    
    if (pos+1<len)

	if ((newline = (char *) realloc(line,pos+1)))
	    line = newline; /* if it fails just ignore it */   
   
	line[pos] = '\0';
    
    return line;
}
