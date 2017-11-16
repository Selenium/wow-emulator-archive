#include "ConsoleInterface.h"
#include "RealmServer.h"
#include "DataManager.h"
#include "stdafx.h"
#include "TownHall.h"
#include "Globals.h"

#ifdef WIN32
#define LINEEND "\r\n"
#else
#define LINEEND "\n"
#endif
int getargs(char *str, char** argv, int maxargs);

string ConCmdStop()
{
	RealmServer.Listener.Close();
	//RealmServer.RedirectListener.Close();
	//RealmServer.LoginListener.Close();
	RealmServer.MasterLists.Cleanup();
	RealmServer.MasterList.ShutDown();
	RealmServer.RealmThread.EndThread();
	DataManager.Cleanup();
#ifdef WIN32
	dlg->Btn_SendMail.EnableWindow(false);
	dlg->Btn_Save.EnableWindow(false);
	dlg->Btn_SendPacketDlg.EnableWindow(false);
	dlg->Btn_StartButton.SetBitmaps(IDB_BITMAP_START_NORMAL,IDB_BITMAP_START_OVER,IDB_BITMAP_START_PRESSED,IDB_BITMAP_START_DISABLED);
	dlg->Btn_StartButton.SetWindowText("&Start");
	dlg->Txt_Status.SetWindowText("Not Running");
	dlg->Txt_RLStatus.SetWindowText("Not Connected");
	dlg->Txt_Clients.SetWindowText("Not Running");
	dlg->rs_started=FALSE;
#endif
	return "SWemu Realm Server Stopped...";
}

string ConCmdQuit()
{
#ifdef WIN32
	dlg->OnOK();
#else
	ConCmdStop();
	exit(0);
#endif
	return "";
}

string ConCmdEcho(char *input)
{
	return input;
}

string ConCmdStart()
{
	if(RealmServer.RealmThread.bThreading) return "Already running.";
	RealmServer.Go();
	return "Started.";
}

string ConCmdRestart()
{
	ConCmdStop();
	ConCmdStart();
	return "Restarted.";
}

string ConCmdRehash()
{
	// rehash
	RealmServer.MasterLists.Cleanup();
	RealmServer.MasterLists.Resize(0);
	Settings.LoadSettings();
	RealmServer.UpdateMasterLists(0);
	return "Rehashing config files!";
}

string ConCmdSave()
{
	for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
	{
		if (CClient *pClient=RealmServer.Clients[i]) pClient->pAccount->Save();
	}
	return "Saving players.";
}

string ConCmdStatPlayers()
{
	char text[60];
	sprintf(text, "%u clients currently connected.", RealmServer.nClients);
	return text;
}

void WorldSave()
{
	// Save Spawn Code
	time_t starttime;
	time(&starttime);
	BroadcastMessage("World saving (saving spawns to file)...");

	// Code here

	char stext[60];

	FILE *f = fopen("data/spawns.sav","wb");

	int savedcreatures = 0;
	for(unsigned long i=1;i<=RealmServer.HighestSpawnID;i++)
	{
		CreatureSaveData temp = RealmServer.Spawns[i];
		if(temp.TemplateID)
		{
			fwrite(&temp,sizeof(temp),1,f);
			savedcreatures++;
		}
	}
	fclose(f);
	time_t endtime;
	time(&endtime);

	sprintf(stext,"%d creature spawns saved in %.3f seconds.", savedcreatures, difftime(endtime,starttime));
	BroadcastMessage(stext);
}

string ConCmdSaveSpawns()
{
	WorldSave();
	return "Worldsave: done.";
}

void BroadcastMessage(char *input)
{
	// Broadcast
	char buffer[2048];
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=CHAT_SYSTEM;
	c+=12;
	string input2;
	// input2 = "|cffff6060<";
	// input2+="ServerConsole";
	// input2+=">|r |c1f40af20";
	input2+="|c1f40af20";
	input2+="ServerConsole";
	//input2+="ServerAdmin";
	input2+=": |r|cffffffff";
	input2+=input;
	*(unsigned long*)&buffer[c]= strlen(input2.c_str())+1;
	c+=4;

	strcpy(&buffer[c],input2.c_str());
	c+=strlen(input2.c_str())+1;

	buffer[c++] = (char)0;
	RealmServer.BroadcastOutPacket(SMSG_MESSAGECHAT,buffer,c);
}

string ConCmdBroadcast(char *input)
{
	BroadcastMessage(input);
	string sbtext;
	sbtext = "Server: ";
	sbtext += input;
	return sbtext;
}

string ConCmdHelp();

string ConCmdShowPlayers()
{
	if(!RealmServer.nClients) return "No players to show!";
	string output;
	output = "Listing players: ";
	output+=LINEEND;
	char buffer[256];
	sprintf(buffer,"%-10s%-16s%-10s%-10s%-6s%-4s%-10s%-10s%-10s","guid","name","race","class","level","map","x","y","z");
	output+=buffer;
	output+=LINEEND;
	char *races[]={"Unknown","Human","Orc","Dwarf","Night Elf","Undead","Tauren","Gnome","Troll"};
	char *classes[]={"Unknown","Warrior","Paladin","Hunter","Rogue","Priest","Unknown","Shaman","Mage","Warlock","Unknown","Druid"};

	for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
	{
		if (CClient *pClient=RealmServer.Clients[i])
		{
			if (pClient->pPlayer)
			{
				PlayerData *pD=&(pClient->pPlayer->Data);
				sprintf(buffer,"%-10X%-16s%-10s%-10s%-6u%-4u%-10.2f%-10.2f%-10.2f",
					pClient->pPlayer->guid,pD->Name,
					(pD->Race<=RACE_TROLL)?races[pD->Race]:"Unknown",
					(pD->Class<=CLASS_DRUID)?classes[pD->Class]:"Unknown",
					pD->Level,pD->Continent,pD->Loc.X,pD->Loc.Y,pD->Loc.Z);
				output+=buffer;
				output+=LINEEND;
			}
		}
	}
	return output;
}

#ifdef WIN32
extern CConsoleDlg *Btn_ConsoleDlg;
string ConCmdClear()
{
	Btn_ConsoleDlg->Txt_Display.SetFont(Btn_ConsoleDlg->pCourier);
	int nSize = Btn_ConsoleDlg->Txt_Display.GetWindowTextLength();
	Btn_ConsoleDlg->Txt_Display.SetSel(0, nSize);
	Btn_ConsoleDlg->Txt_Display.ReplaceSel(_T(""));
	return "";
}
#endif

ConsoleCmdHandler ConsoleHandlers[] =
{
	{"help", (void*)ConCmdHelp, CMDFUNCTYPE_NONE, " - No arguments. Provides command descriptions."},
	{"?", (void*)ConCmdHelp, CMDFUNCTYPE_NONE, " - No arguments. Provides command descriptions."},
	{"stop", (void*)ConCmdStop, CMDFUNCTYPE_NONE, " - Shuts down Realm Server"},
	{"start", (void*)ConCmdStart, CMDFUNCTYPE_NONE, " - Starts Realm Server"},
	{"restart", (void*)ConCmdRestart, CMDFUNCTYPE_NONE, " - Restarts Realm Server"},
	{"rehash", (void*)ConCmdRehash, CMDFUNCTYPE_NONE, " - Reloads config files"},
	{"save", (void*)ConCmdSave, CMDFUNCTYPE_NONE, " - Saves all clients"},
	{"statplayers", (void*)ConCmdStatPlayers, CMDFUNCTYPE_NONE, " - Returns number of connected clients"},
	{"showplayers", (void*)ConCmdShowPlayers, CMDFUNCTYPE_NONE, " - Returns list of all connected players"},
	{"echo", (void*)ConCmdEcho, CMDFUNCTYPE_STRING, " <text> - Echos text back at you."},
	{"broadcast",(void*)ConCmdBroadcast, CMDFUNCTYPE_STRING, " <text> - Broadcasts text to server"},
	{"worldsave",(void*)ConCmdSaveSpawns, CMDFUNCTYPE_NONE, " - Saves all spawns to file."},
	{"exit",(void*)ConCmdQuit, CMDFUNCTYPE_NONE, " - Exits server safely"},
	{"quit",(void*)ConCmdQuit, CMDFUNCTYPE_NONE, " - Alias for exit"},
#ifdef WIN32
	{"clear",(void*)ConCmdClear, CMDFUNCTYPE_NONE, " - Clear the display"},
#endif
	{NULL, 0, 0},
};

string ConCmdHelp()
{
	string output = "Available commands: ";
	output+=LINEEND;
	for(int i = 0;ConsoleHandlers[i].cmd != NULL;i++)
	{
		output += ConsoleHandlers[i].cmd;
		output += ConsoleHandlers[i].description;
		output += LINEEND;
	}
	return output;
}
string CConsoleInterface::ParseCommand(char *command)
{
	if (!command)
		return false;
	char buffer[0x100];
	strncpy(buffer, command, 0xFF);
	buffer[0xFF] = 0;
	char *cmd = strtok(buffer, " ");
	char *input;
	if(cmd == NULL)
	{
		cmd = buffer;
		input = "";
	}
	else
		input = &buffer[strlen(cmd)+1];
	int i;
	for(i = 0;ConsoleHandlers[i].cmd != NULL;i++)
	{
		if(stricmp(ConsoleHandlers[i].cmd, cmd) == 0)
		{
			if(ConsoleHandlers[i].funcType == CMDFUNCTYPE_NONE)
			{
				return ((string (*) ())ConsoleHandlers[i].func)();
			}
			else if(ConsoleHandlers[i].funcType == CMDFUNCTYPE_STRING)
			{
				return ((string (*)(char* input))ConsoleHandlers[i].func)(input);
			}
			else if(ConsoleHandlers[i].funcType == CMDFUNCTYPE_ARGS)
			{
				char *argv[20];
				int argc = getargs(input, argv, 20);
				return ((string (*)(char** argv, int argc))ConsoleHandlers[i].func)(argv, argc);
			}
		}
	}
	return "Command not understood.";
}
