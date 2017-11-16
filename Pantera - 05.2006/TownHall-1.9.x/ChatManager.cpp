#include "stdafx.h"
#include "Globals.h"
#include "Client.h"
#include "UpdateBlock.h"
#include "ChatManager.h"
#include "Party.h"
#include "Guild.h"
#include "ItemTemplate.h"
#include "Item.h"
#include "Creature.h"
#include "Player.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "Settings.h"
#include "SpellHandler.h"
#include "GameObject.h"
#include "Quest.h"
#include "TrainerTemplate.h"
#include "Bag.h"
#include "ConsoleInterface.h"

map<string, CChannel*> CChannel::AllChannels;
int getargs(char *str, char** argv, int maxargs);
bool ProcessCommand(CClient *pClient, const char *command);
CChatManager ChatManager;
bool fileinuse = false;

CChatManager::CChatManager(void)
{
	Mounts["gryphon"] = 0x03A7;
	Mounts["gryphon2"] = 0x047B;
	Mounts["gryphon3"] = 0x047C;
	Mounts["gryphon4"] = 0x047D;

	Mounts["horse brown"] = 0x00E5;
	Mounts["horse brown2"] = 0x0492;
	Mounts["horse brown3"] = 0x0964;

	Mounts["horse white"] = 0x00EC;
	Mounts["horse white2"] = 0x096A;

	Mounts["horse black"] = 0x00EF;
	Mounts["horse black2"] = 0x0962;

	Mounts["horse chessnut"] = 0x038C;
	Mounts["horse chessnut2"] = 0x0915;
	Mounts["horse chessnut3"] = 0x0965;

	Mounts["horse palamino"] = 0x00ED;
	Mounts["horse palamino2"] = 0x0968;

	Mounts["horse pinto"] = 0x00EE;
	Mounts["horse pinto2"] = 0x0969;

	Mounts["nightmare"] = 0x092A;
	Mounts["horse evil"] = 0x00EB;
	Mounts["horse evil2"] = 0x079F;
	Mounts["horse evil3"] = 0x07A0;
	Mounts["horse evil4"] = 0x0966;
	Mounts["horse evil5"] = 0x0B0E;

	Mounts["hippogryph"] = 0x01DF;
	Mounts["hippogryph2"] = 0x0790;
	Mounts["hippogryph3"] = 0x0C8A;
	Mounts["hippogryph4"] = 0x0C8B;
	Mounts["hippogryph5"] = 0x0C8C;

	Mounts["zebra"] = 0x05FB;
	Mounts["zebra2"] = 0x0776;
	Mounts["zebra3"] = 0x0777;

	Mounts["ram grey"] = 0x0AB0;
	Mounts["ram black"] = 0x0AE0;
	Mounts["ram brown"] = 0x0AE1;
	Mounts["ram white"] = 0x0AE2;
	Mounts["ram blue"] = 0x0AE3;
	Mounts["dire black"] = 0x00CF;
	Mounts["dire black2"] = 0x02E5;
	Mounts["dire black3"] = 0x0930;

	Mounts["dire reddishbrown"] = 0x00F6;
	Mounts["dire reddishbrown2"] = 0x0916;
	Mounts["dire brown"] = 0x00F7;
	Mounts["dire blue"] = 0x02D0;
	Mounts["dire blue2"] = 0x0406;
	Mounts["dire blue3"] = 0x048E;
	Mounts["dire grey"] = 0x0910;
	Mounts["dire darkgrey"] = 0x0917;
	Mounts["dire darkbrown"] = 0x0918;


	ArmourInvFilter["generic"] = 1 << ARMOURSUBTYPE_GENERIC;
	ArmourInvFilter["cloth"] = 1 << ARMOURSUBTYPE_CLOTH;
	ArmourInvFilter["leather"] = 1 << ARMOURSUBTYPE_LEATHER;
	ArmourInvFilter["mail"] = 1 << ARMOURSUBTYPE_MAIL;
	ArmourInvFilter["plate"] = 1 << ARMOURSUBTYPE_PLATE;
	ArmourInvFilter["buckler"] = 1 << ARMOURSUBTYPE_BUCKLER;
	ArmourInvFilter["shield"] = 1 << ARMOURSUBTYPE_SHIELD;

	ArmourTypes["generic"] = ARMOURSUBTYPE_GENERIC;
	ArmourTypes["cloth"] = ARMOURSUBTYPE_CLOTH;
	ArmourTypes["leather"] = ARMOURSUBTYPE_LEATHER;
	ArmourTypes["mail"] = ARMOURSUBTYPE_MAIL;
	ArmourTypes["plate"] = ARMOURSUBTYPE_PLATE;
	ArmourTypes["buckler"] = ARMOURSUBTYPE_BUCKLER;
	ArmourTypes["shield"] = ARMOURSUBTYPE_SHIELD;

#define ADDSUBTYPE(string, val) WeaponInvFilter[string] = 1 << val;\
	WeaponTypes[string] = val;
	ADDSUBTYPE("1haxe", WEAPONSUBTYPE_ONEHANDAXE);
	ADDSUBTYPE("2haxe", WEAPONSUBTYPE_TWOHANDAXE);
	ADDSUBTYPE("1hsword", WEAPONSUBTYPE_ONEHANDSWORD);
	ADDSUBTYPE("2hsword", WEAPONSUBTYPE_TWOHANDSWORD);
	ADDSUBTYPE("bow", WEAPONSUBTYPE_BOW);
	ADDSUBTYPE("gun", WEAPONSUBTYPE_GUN);
	ADDSUBTYPE("1hblunt", WEAPONSUBTYPE_ONEHANDBLUNT);
	ADDSUBTYPE("2hblunt", WEAPONSUBTYPE_TWOHANDBLUNT);
	ADDSUBTYPE("polearm", WEAPONSUBTYPE_POLEARM);
	ADDSUBTYPE("staff", WEAPONSUBTYPE_STAFF);
	ADDSUBTYPE("1hexotic", WEAPONSUBTYPE_ONEHANDEXOTIC);
	ADDSUBTYPE("2hexotic", WEAPONSUBTYPE_TWOHANDEXOTIC);
	ADDSUBTYPE("unarmed", WEAPONSUBTYPE_UNARMED);
	ADDSUBTYPE("generic", WEAPONSUBTYPE_GENERIC);
	ADDSUBTYPE("dagger", WEAPONSUBTYPE_DAGGER);
	ADDSUBTYPE("thrown", WEAPONSUBTYPE_THROWN);
	ADDSUBTYPE("spear", WEAPONSUBTYPE_SPEAR);
	ADDSUBTYPE("crossbow", WEAPONSUBTYPE_CROSSBOW);
	ADDSUBTYPE("wand", WEAPONSUBTYPE_WAND);
#undef ADDSUBTYPE

	InvTypes["notworn"] = WORN_NONE;
	InvTypes["junk"] = WORN_JUNK;
	InvTypes["head"] = WORN_HEAD;
	InvTypes["shirt"] = WORN_SHIRT;
	InvTypes["chest"] = WORN_CHEST;
	InvTypes["neck"] = WORN_NECK;
	InvTypes["shoulder"] = WORN_SHOULDER;
	InvTypes["waist"] = WORN_WAIST;
	InvTypes["legs"] = WORN_PANTS;
	InvTypes["feet"] = WORN_BOOTS;
	InvTypes["wrists"] = WORN_BRACERS;
	InvTypes["hands"] = WORN_HAND;
	InvTypes["finger"] = WORN_FINGER;
	InvTypes["trinket"] = WORN_TRINKET;
	InvTypes["back"] = WORN_BACK;
	InvTypes["mainhand"] = WORN_MAINHAND;
	InvTypes["offhand"] = WORN_OFFHAND;

	UserLevels["admin"] = USER_ADMIN;
	UserLevels["supergm"] = USER_SUPERGM;
	UserLevels["gm"] = USER_GM;
	UserLevels["half-gm"] = USER_HALFGM;
	UserLevels["halfgm"] = USER_HALFGM;
	UserLevels["supermod"] = USER_SUPERMOD;
	UserLevels["moderator"] = USER_MODERATOR;
	UserLevels["mod"] = USER_MODERATOR;
	UserLevels["privledged"] = USER_PRIVLEDGED;
	UserLevels["normal"] = USER_NORMAL;
	UserLevels["ban"] = USER_BANNED;
	UserLevels["suspend"] = USER_SUSPENDED;
	UserLevels["delete"] = USER_DELETE;

	Races["human"] = RACE_HUMAN;
	Races["dwarf"] = RACE_DWARF;
	Races["gnome"] = RACE_GNOME;
	Races["nightelf"] = RACE_NIGHTELF;
	Races["orc"] = RACE_ORC;
	Races["troll"] = RACE_TROLL;
	Races["tauren"] = RACE_TAUREN;
	Races["undead"] = RACE_UNDEAD;
}

CChatManager::~CChatManager(void)
{
	for(map<string,CChannel *>::iterator i=CChannel::AllChannels.begin();i!=CChannel::AllChannels.end();i++)
	{
		if(i->second) delete i->second;
	}
}

void CChatManager::InitCloaks()
{
	ChatManager.Cloaks["aqua"] = 8126;
}

void CmdSpell(CClient *pClient, char *input)
{
	unsigned long ID=0;
	if(!sscanf(input, "0x%X", &ID) && !sscanf(input, "%u", &ID))
	{
		pClient->Echo("Invalid Spell ID. Prefix hex values with 0x.");
		return;
	}
	if (ID)
	{
		int i=0;
		while(pClient->pPlayer->Data.Spells[i])
		{
			if(ID == pClient->pPlayer->Data.Spells[i])
			{
				pClient->Echo("You already know spell %08X!",ID);
				return;
			}
			i++;
		}
		pClient->Echo("Learning spell %08X",ID);
		pClient->LearnedSpell(ID);
		pClient->pPlayer->Data.Spells[i]=ID;
	}
	else
		pClient->Echo("Syntax: !spell <spellid>");
}

void CmdAdmin(CClient *pClient, char *input)
{
	if (!strcmp(Settings.AdminPass,input))
	{
		pClient->pAccount->Data.UserLevel=USER_ADMIN;
		pClient->Echo("Your account has been given Administrator status.");
	}
}

void CmdMakeGM(CClient *pClient, char *input)
{
	if (Settings.AllowGMCommand == true)
	{
		if (!strcmp(Settings.GMPass,input))
		{
			pClient->pAccount->Data.UserLevel=USER_GM;
			pClient->Echo("Your account has been given GM status.");
		}
	}
	else {
		pClient->Echo("Command disabled on this server!");
	}
}

void CmdDemoteAll(CClient *pClient)
{
	CLock L(&RealmServer.Clients.CS); // exclusive lock on clients for this, not guaranteed to be in the realm server thread
	for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
	{
		if (CClient *pTargetClient=RealmServer.Clients[i])
		{
			if (pTargetClient->pAccount->Data.UserLevel>USER_NORMAL) //to avoid promoting bad people
				pTargetClient->pAccount->Data.UserLevel=USER_NORMAL;
		}
	}
	pClient->Echo("All people currently logged on have been demoted.");
}

void CmdAura(CClient *pClient, char **argv, int argc)
{
	long i1 = atoi(argv[0]);
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURA, i1 );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURAFLAGS, 9 );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURA+32, i1 );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURALEVELS+8, 0xeeeeee00 );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURAAPPLICATIONS+8, 6 );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURAFLAGS+4, 0x0000000d );
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_AURASTATE, 0x00000002 );
	pClient->UpdateObject();
}

void CmdMakeWaypoint(CClient *pClient, char **argv, int argc)
{
	// get creature
	CCreature *pCreature;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,pClient->pPlayer->TargetID))
	{
		pClient->Echo("Is either not a creature or an invalid target.");
		return;
	}

	_AIAction action;
	action.Command = CREATURE_AICMD_MOVETO;
	action.Location = pClient->pPlayer->Data.Loc;
	action.Data1 = 0;
	action.Data2 = 0;
	char filename[60];
	sprintf(filename,"data/scripts/%u.txt", pCreature->guid);
	bool createfile = false;
	if (!_FileExists(filename))
		createfile = true;

	FILE *f = fopen(filename, "a");
	char commandtext[300];
	char headertext[300];
	sprintf(headertext, "#Auto-Generated by Pantera Realm Server.\n#Script file for NPC %u, which is a %s\n#and resides at %.f %.f %.f\r\n", pCreature->guid, pCreature->pTemplate->Data.Name, pCreature->Data.Loc.X, pCreature->Data.Loc.Y, pCreature->Data.Loc.Z);
	sprintf(commandtext,"\nmoveto %f %f %f",action.Location.X,action.Location.Y,action.Location.Z);


	if (createfile)
		fwrite(headertext, 1, strlen(headertext), f);

	fwrite(commandtext,1,strlen(commandtext),f);
	fclose(f);

	pCreature->AI_ActionCount++;
	pCreature->AI_Actions[pCreature->AI_ActionCount] = action;

	pClient->Echo("Written to file and memory.");
	pClient->Echo("Saved to %s", filename);
}

void CmdAddScriptCommand(CClient *pClient, char *input)
{
	// get creature
	CCreature *pCreature;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,pClient->pPlayer->TargetID))
	{
		pClient->Echo("Is either not a creature or an invalid target.");
		return;
	}

	char filename[60];
	sprintf(filename,"data/scripts/%u.txt", pCreature->guid);
	bool createfile = false;
	if (!_FileExists(filename))
		createfile = true;

	FILE *f = fopen(filename, "a");
	char commandtext[300];
	char headertext[300];
	sprintf(headertext, "#Auto-Generated by Pantera Realm Server.\n#Script file for NPC %u, which is a %s\n#and resides at %.f %.f %.f\r\n", pCreature->guid, pCreature->pTemplate->Data.Name, pCreature->Data.Loc.X, pCreature->Data.Loc.Y, pCreature->Data.Loc.Z);
	sprintf(commandtext,"\n%s", input);

	if (createfile)
		fwrite(headertext, 1, strlen(headertext), f);

	fwrite(commandtext,1,strlen(commandtext),f);
	fclose(f);

	pClient->Echo("Written to file and memory.");
	pClient->Echo("Saved to %s", filename);
}

void CmdReport(CClient *pClient, char *input)
{
	if(input[0] == 0)
	{
		pClient->Echo("Syntax: !report <msg>");
		return;
	}
	FILE *file;
	struct tm * timeinfo;
	time_t aclock;
	file = fopen("data/report.log","a+");
	if (file!=NULL)
	{
		time(&aclock);
		timeinfo = localtime(&aclock);
		fprintf(file,"Character: %s     Time: %sReport : %s\n", pClient->pPlayer->Data.Name, asctime(timeinfo),input);
		fclose(file);
		pClient->Echo("Your report has been recorded into our log file.");
	}
	else {
		pClient->Echo("Problem opening log file.");
	}
}

void CmdTestBag(CClient *pClient, char **argv, int argc)
{
	unsigned long bagguid = pClient->pPlayer->Data.Bags[0];
	CBag *bag;
	if(DataManager.RetrieveObject((CWoWObject**)&bag,OBJ_CONTAINER,bagguid))
	{
		CItem *item = new CItem;
		item->New(DataManager.ItemTemplates[43],pClient->pPlayer->guid);
		DataManager.NewObject(*item);
		pClient->AddKnownItem(*item);
		bag->Data.Contents[0] = item->guid;
		bag->SendBagContents();
	}
}

void CmdWorldport(CClient *pClient, char **argv, int argc)
{
	if(argc != 4)
	{
		pClient->Echo("Syntax: !worldport <continent> <x> <y> <z>");
		return;
	}

	int Continent = atoi(argv[0]);
	pClient->pPlayer->Data.Loc.X = (float)atof(argv[1]);
	pClient->pPlayer->Data.Loc.Y = (float)atof(argv[2]);
	pClient->pPlayer->Data.Loc.Z = (float)atof(argv[3]);

	Packets::TeleportOrNewWorld(pClient,Continent);

	pClient->Echo("You have been WorldPorted!");
}

void CmdSaveMe(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !saveme");
		return;
	}
	_timeb now;
	_ftime(&now);
	if(EventManager.DiffTime(now, pClient->pPlayer->LastAttack) < 20000) // No regen for 20 secs after last attack
	{													// TODO: Add a general "lastincombat" time
		pClient->Echo("You cant be saved while in battle... sorry try again");
		return;
	}

	Packets::TeleportOrNewWorld(pClient,RaceStartingPoints[pClient->pPlayer->Data.Race].Continent,RaceStartingPoints[pClient->pPlayer->Data.Race].Loc);

	pClient->Echo("You have been Saved!");
}

void CmdSendTo(CClient *pClient, char **argv, int argc)
{
	if (argc != 2)
	{
		pClient->Echo("Locations are: Human, Dwarf, Gnome, NightElf, Orc, Troll, Tauren, Undead");
		pClient->Echo("Syntax: !sendto <player> <location>");
		return;
	}

	std::string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}

	if(pPlayer->pClient == NULL) {
		pClient->Echo("%s is not online.", pPlayer->Data.Name);
		return;
	}
	if((pPlayer->pClient->pAccount->Data.UserLevel >= pClient->pAccount->Data.UserLevel) ||
		(pPlayer == pClient->pPlayer))
	{
		pClient->Echo("You cannot send that player.");
		return;
	}
	int race=0;
	if(!stricmp(argv[1],"nightelf")) race=RACE_NIGHTELF;
	else if(!stricmp(argv[1],"tauren")) race=RACE_TAUREN;
	else if(!stricmp(argv[1],"troll")) race=RACE_TROLL;
	else if(!stricmp(argv[1],"orc")) race=RACE_ORC;
	else if(!stricmp(argv[1],"undead")) race=RACE_UNDEAD;
	else if(!stricmp(argv[1],"gnome")) race=RACE_GNOME;
	else if(!stricmp(argv[1],"dwarf")) race=RACE_DWARF;
	else if(!stricmp(argv[1],"human")) race=RACE_HUMAN;
	else
	{
		pClient->Echo("Locations are: Human, Dwarf, Gnome, NightElf, Orc, Troll, Tauren, Undead");
		pClient->Echo("Syntax: !sendto <player> <location>");
		return;
	}

	Packets::TeleportOrNewWorld(pPlayer->pClient,RaceStartingPoints[pClient->pPlayer->Data.Race].Continent,RaceStartingPoints[race].Loc);
	pPlayer->pClient->Echo("You have been sent to the world of the %s",argv[1]);
	pClient->Echo("%s has been sent to %s world",pPlayer->Data.Name,argv[1]);
	return;
}

void CmdDeathDurabilityLoss(CClient *pClient, char *input)
{
	pClient->pPlayer->DeathDurabilityLoss();
	return;
}

void CmdGoRace(CClient *pClient, char *input)
{
	if(input[0] == 0)
	{
		pClient->Echo("Locations are: Human, Dwarf, Gnome, NightElf, Orc, Troll, Tauren, Undead");
		pClient->Echo("Syntax: !gorace <race>");
		return;
	}
	string str = input;
	MakeLower(str);
	map<string, unsigned long>::iterator i = ChatManager.Races.find(str);
	if(i == ChatManager.Races.end())
	{
		pClient->Echo("Valid Locations are: Human, Dwarf, Gnome, NightElf, Orc, Troll, Tauren, Undead");
		pClient->Echo("Syntax: !gorace <race>");
		return;
	}

	Packets::TeleportOrNewWorld(pClient, RaceStartingPoints[i->second].Continent,RaceStartingPoints[i->second].Loc);

	pClient->Echo("You travel to the world of %s",input);
}

void CmdClients(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !clients");
		return;
	}
	pClient->Echo("There are %d users connected, and this server has handled up to %d simultaneous users this session.",RealmServer.nClients,RealmServer.nMaxClients);
}

void CmdGetMount(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !getmount");
		return;
	}
	if(pClient->pPlayer->Data.MountModel)
	{
		pClient->Echo("Please '!dismount' first!");
		return;
	}
	if(pClient->pPlayer->Data.Level < 10)
	{
		pClient->Echo("You need to be have atleast Level 10 to mount.");
		return;
	}

	pClient->pDataObject->SetMountModel(0x03A7);
	pClient->UpdateObject();
	pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED*2);

	pClient->Echo("You mount the beast.  Type '!dismount' to dismount.");
	return;
}

void CmdMount(CClient *pClient, char *input)
{
	if(pClient->pPlayer->Data.MountModel)
	{
		pClient->Echo("Please '!dismount' first!");
		return;
	}

	if(input[0] == 0)
	{
		pClient->Echo("Valid mounts for this demonstration are nightmare, gryphon[2-4] (ie: gryphon, gryphon2, ..), \
					  hippogryph[2-5], horse <type> (evil[2-5], white[2], black[2], brown[2-3], palamino[2], \
					  pinto[2], chessnut[2-3]), ram <color> (white, black, grey, brown, blue), ");
		pClient->Echo("dire <color> (black[2-3], grey, darkgrey, brown, zebra[2-3], darkbrown, reddishbrown[2], blue[2-3])");
		pClient->Echo("Syntax: !mount <mount>");
		return;
	}

	string lcase=input;
	MakeLower(lcase);
	map<string, unsigned long>::iterator mount = ChatManager.Mounts.find(lcase);
	if(mount == ChatManager.Mounts.end())
	{
		pClient->Echo("Unknown mount.");
		pClient->Echo("Valid mounts for this demonstration are nightmare, gryphon[2-4] (ie: gryphon, gryphon2, ..), \
					  hippogryph[2-5], horse <type> (evil[2-5], white[2], black[2], brown[2-3], palamino[2], \
					  pinto[2], chessnut[2-3]), ram <color> (white, black, grey, brown, blue), ");
		pClient->Echo("dire <color> (black[2-3], grey, darkgrey, brown, zebra[2-3], darkbrown, reddishbrown[2], blue[2-3])");
		pClient->Echo("Syntax: !mount <mount>");
		return;
	}

	pClient->pDataObject->SetMountModel(mount->second);
	pClient->UpdateObject();
	pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED*2);

	pClient->Echo("You mount the beast.  Type '!dismount' to dismount.");
}

void CmdUnmount(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !dismount");
		return;
	}
	if(pClient->pPlayer->Data.MountModel != 0 && !pClient->pPlayer->bIsFlying)
	{
		ForceDismount(pClient);
	}
	else
		pClient->Echo("You unmount thin air. Making a fool of yourself.");
}
void CmdDuel(CClient *pClient)
{
	//pClient->pPlayer->DuelPrepare(pClient->pPlayer->TargetID);
	pClient->pPlayer->TalentResetInitiate();
}
void CmdBind(CClient *pClient)
{
	//pClient->pPlayer->DuelPrepare(pClient->pPlayer->TargetID);
	pClient->pPlayer->BindInitiate();;
}
void CmdDist(CClient *pClient, char **argv, int argc)
{
	CWoWObject *pTarget=0;
	if(argc>0)
	{
	if(atoi(argv[0])==2)
	{
	if (DataManager.RetrieveObject(&pTarget,pClient->pPlayer->TargetID))
	{
		if(pTarget->type==OBJ_CREATURE) 
		{
			float A = pClient->pPlayer->Data.Loc.X - ((CCreature*)pTarget)->Data.Loc.X;
			float B = pClient->pPlayer->Data.Loc.Y - ((CCreature*)pTarget)->Data.Loc.Y;
			pClient->Echo("2D Distance: %f",sqrtf((A*A)+(B*B)));
		}
	}
	}
	else if(atoi(argv[0])==3)
	{
	if (DataManager.RetrieveObject(&pTarget,pClient->pPlayer->TargetID))
	{
		if(pTarget->type==OBJ_CREATURE) 
		{
			float A = pClient->pPlayer->Data.Loc.X - ((CCreature*)pTarget)->Data.Loc.X;
			float B = pClient->pPlayer->Data.Loc.Y - ((CCreature*)pTarget)->Data.Loc.Y;
			float C = pClient->pPlayer->Data.Loc.Z - ((CCreature*)pTarget)->Data.Loc.Z;
			pClient->Echo("2D Distance: %f",sqrtf((A*A)+(B*B)+(C*C)));
		}
	}
	}
	}

}
void CmdPkt(CClient *pClient, char **argv, int argc)
{
	if(!atoi(argv[0]))
	{
		CPacket pkg;
		pkg.Reset(SMSG_BINDPOINTUPDATE);
		pkg << pClient->pPlayer->Data.Loc.X;
		pkg << pClient->pPlayer->Data.Loc.Y;
		pkg << pClient->pPlayer->Data.Loc.Z;
		pkg << pClient->pPlayer->Data.Continent;
		pkg << pClient->pPlayer->Data.Zone;
		pClient->Send(&pkg);
	}
	else
	{
		CPacket pkg;
		pkg.Reset(SMSG_BINDPOINTUPDATE);
		pkg << pClient->pPlayer->Data.Loc.X;
		pkg << pClient->pPlayer->Data.Loc.Y;
		pkg << pClient->pPlayer->Data.Loc.Z;
		pkg << pClient->pPlayer->Data.Continent;
		pkg << atoi(argv[0]);
		pClient->Send(&pkg);
	}

}

void CmdTabard(CClient *pClient)
{
	if(pClient->pPlayer->Data.Items[SLOT_TABARD] != 0)
	{
		pClient->Echo("You already have a tabard!");
	}
	else
	{
		CItem *pItem=new CItem;
		pItem->New(STATICITEMS::GUILD_TABARD,pClient->pPlayer->guid);
		DataManager.NewObject(*pItem);

//		pClient->pDataObject->SetItem(SLOT_TABARD, pItem->guid);
		pClient->pDataObject->SetItem(SLOT_TABARD, pItem);
		pClient->UpdateObject();
		pClient->AddKnownItem(*pItem);
		pClient->Echo("You receive a tabard!");
	}
}

void CmdCreateGuild(CClient *pClient, char *input)
{
	if(pClient->pPlayer->Data.GuildID != 0)
	{
		pClient->Echo("You are already in a guild!");
		return;
	}
	if(input[0] == 0)
	{
		pClient->Echo("Syntax: !createguild <name>");
		return;
	}
	else if(strlen(input) > 63)
	{
		pClient->Echo("Guildname too long.");
		return;
	}
	string name = input;
	MakeLower(name);
	if(CGuild::AllGuilds.find(name) != CGuild::AllGuilds.end())
	{
		pClient->Echo("That guild already exists!");
		return;
	}
	if(name == "nneonneo" && pClient->pAccount->Data.UserLevel < USER_GM)
	{
		pClient->Echo("The nneonneo guild is reserved, thanks to the dev ^_^");
		return;
	}
	CGuild *pGuild = new CGuild();
	pGuild->New(input, pClient);
	DataManager.NewObject(*pGuild);
	CGuild::AllGuilds[name] = pGuild->guid;
	pClient->Echo("You created guild %s. Type '!tabard' to get your guild tabard.", input);
	pClient->Echo("As a guildmaster you can go to a tabard vendor and choose your guild emblem.");
}

void CmdSpawn(CClient *pClient, char *input)
{
	unsigned long Template = 0;
	string templatename;
	if(input[0] == 0)
	{
		pClient->Echo("Syntax: !spawn <creature name>");
		return;
	}
	templatename = input;
	MakeLower(templatename);
	Template = DataManager.CreatureTemplateNames[templatename];


	CCreatureTemplate *pTemplate;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Template))
	{
		pClient->Echo("Could not find creature template.");
		return;
	}

	CCreature *pCreature = RealmServer.GenerateCreatureNew(pTemplate,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Facing);
	if (!pCreature)
	{
		pClient->Echo("Creature failed spawning.");
		return;
	}
	pCreature->Data.Template = Template;
	RealmServer.HighestSpawnID++;
	pCreature->Data.SpawnID = RealmServer.HighestSpawnID;
	pCreature->Data.CurrentStats = pTemplate->Data.NormalStats;
	pCreature->FirstPoint = 0;
	CreatureSaveData temp;
	temp.Continent = pCreature->Data.Continent;
	temp.Facing = pCreature->Data.Facing;
	temp.FirstPoint = 0;
	temp.Loc = pCreature->Data.Loc;
	temp.TemplateID = Template;
	RealmServer.Spawns[pCreature->Data.SpawnID] = temp;
	RegionManager.ObjectNew(*pCreature,pCreature->Data.Continent,pCreature->Data.Loc.X,pCreature->Data.Loc.Y);
	pCreature->AI_Initialize();
	pClient->Echo("Spawned a %s. Use !worldsave/worldsave (console) to commit.", pCreature->pTemplate->Data.Name);
	return;


	/*
	#define HELPMSG pClient->Echo("Syntax: !spawn <model> [name] [level] [subtitle] [-[f|m|t|q|z]]");\
	pClient->Echo("Option -f will spawn a taxi merchant.");\
	pClient->Echo("Option -m will spawn an item merchant.");\
	pClient->Echo("Option -t will spawn a tabard vendor.");\
	pClient->Echo("Option -q will spawn a quest vendor.");\
	pClient->Echo("Option -z will spawn a trainer.");\
	pClient->Echo("You must have a subtitle if you want to use the - options.");\
	pClient->Echo("Prefix model with 0x to use hex value.");
	if(argc < 1)
	{
	HELPMSG
	return;
	}
	unsigned long model=0;
	if(sscanf(argv[0], "0x%X", &model) == 0 && sscanf(argv[0], "%u", &model) == 0)
	{
	pClient->Echo("Invalid model value...");
	HELPMSG
	return;
	}

	if(model == 0)
	{
	pClient->Echo("Invalid model value. Must not be 0...");
	HELPMSG
	return;
	}

	CRegion *pRegion = RegionManager.ObjectRegions[pClient->pPlayer->guid];
	if (!pRegion)
	{
	return;
	}
	if(pClient->pAccount->Data.UserLevel < USER_GM)
	{
	unsigned long nSpawns=0;
	RegionObjectNode *pNode=pRegion->pList;
	while(pNode)
	{
	if (pNode->pObject->type==OBJ_CREATURE)
	nSpawns++;
	pNode=pNode->pNext;
	}
	if (nSpawns>14)
	{
	pClient->Echo("I think there's enough spawns in this immediate area, venture a little bit");
	return;
	}
	}


	unsigned long Level=1;
	char *Name = NULL;
	char *Subtitle = NULL;
	bool isFlyPathMob = false;
	bool isTabardVendor = false;
	bool isItemMerchant = false;
	bool isQuestVendor = false;
	bool isTrainer = false;
	int i;
	if(argc > 1)
	{
	Name = argv[1];
	if(argc > 2)
	{
	if(sscanf(argv[2], "0x%X", &Level) == 0 && sscanf(argv[2], "%u", &Level) == 0)
	{
	pClient->Echo("Invalid level value...");
	HELPMSG
	return;
	}

	if(Level == 0)
	{
	pClient->Echo("Invalid level value. Must not be 0...");
	HELPMSG
	return;
	}

	if(argc > 3)
	{
	Subtitle = argv[3];
	if(argc > 4)
	{
	for(i = 4;i < argc;i++)
	{
	switch(argv[i][1])
	{
	case 'f':
	isFlyPathMob = true;
	break;
	case 'm':
	isItemMerchant = true;
	break;
	case 't':
	isTabardVendor = true;
	break;
	case 'q':
	isQuestVendor = true;
	break;
	case 'z':
	isTrainer = true;
	break;
	default:
	pClient->Echo("Unknown switch.");
	HELPMSG
	return;
	}
	}
	}
	}
	}
	}
	#undef HELPMSG

	char NameBuf[64];
	if(Name == NULL)
	{
	sprintf(NameBuf, "Creature %X", model);
	Name = NameBuf;
	}

	CCreature *pCreature = NULL;

	pCreature = RealmServer.GenerateCreature(model, Name, pClient->pPlayer->Data.Continent, pClient->pPlayer->Data.Loc, pClient->pPlayer->Data.Facing);
	if(isTabardVendor)
	{
	pCreature->Data.NPCType = NPCTYPE_TABARD;
	pCreature->Data.FactionTemplate = 5;
	}
	else if(isItemMerchant)
	{
	pCreature->Data.NPCType = NPCTYPE_MERCHANT;
	pCreature->Data.FactionTemplate = 5;
	}
	else if(isQuestVendor)
	{
	pCreature->Data.NPCType = NPCTYPE_QUESTGIVER;
	pCreature->Data.FactionTemplate = 5;
	}
	else if(isTrainer)
	{
	pCreature->Data.NPCType = NPCTYPE_TRAINER;
	pCreature->Data.FactionTemplate = 5;
	}
	else {
	pCreature->Data.FactionTemplate = 1;
	}

	if(Subtitle != NULL)
	{
	CCreatureTemplate *pTemplate = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, pCreature->Data.Template))
	{
	strncpy(pTemplate->Data.Guild, Subtitle, 63);
	pTemplate->Data.Guild[63] = 0;
	}
	}

	if(Level != 0)
	{
	pCreature->DataObject.SetHP(Level*65);
	pCreature->DataObject.SetMaxHP(Level*65);
	pCreature->Data.DamageMin=Level*1;
	pCreature->Data.DamageMax=Level*3;
	pCreature->Data.Exp=Level*200;
	pCreature->DataObject.SetLevel(Level);
	}

	RegionManager.ObjectNew(*pCreature, pCreature->Data.Continent, pCreature->Data.Loc.X, pCreature->Data.Loc.Y);
	//EventManager.AddEvent(*pCreature,30000,EVENT_CREATURE_WANDER,0,0);
	pClient->Echo("Ok. Spawned '%s' with model 0x%X.", pCreature->pTemplate->Data.Name, pCreature->Data.Model);
	*/
	pClient->Echo("Nag Burlex to repair this function :P");
}

void EditPlayer(CClient *pClient, CPlayer &Player, char **argv, int argc)
{
	if(argc < 2)
	{
		pClient->Echo("Syntax: !edit <attribute> <newvalue(s)>");
		pClient->Echo("Available attributes for that target is:");
		pClient->Echo("hps <hps>, dmg <min> <max>, size <size>, model <model>,");
		pClient->Echo("exp <exp>, level <level>, speed <speed>, money <money>");
		return;
	}
	if (!strnicmp(argv[0],"hps",3))
	{
		int val = atoi(argv[1]);
		Player.DataObject.SetHP(val);
		Player.DataObject.SetMaxHP(val);
		Player.UpdateObject();
		pClient->Echo("Player hps now: %d",val);
	}
	else if (!strnicmp(argv[0],"dmg",3))
	{
		float Val1,Val2;
		Val1=Val2=3;
		if (argc == 3 && sscanf(argv[1],"%g",&Val1) && sscanf(argv[2], "%g", &Val2))
		{
			Player.DataObject.SetMinDamage(Val1);
			Player.DataObject.SetMaxDamage(Val2);
			Player.UpdateObjectOnlyMe();
			pClient->Echo("Player dmg now: %d to %d",Val1,Val2);
		}
		else {
			pClient->Echo("Syntax: !edit dmg <min> <max>");
		}
	}
	else if (!strnicmp(argv[0],"size",4))
	{
		float val=0;
		if(sscanf(argv[1],"%g",&val))
		{
			if (val<3 && val>0) // we have to retrieve the real max model size, i can do cow x30 size, but dragon max is like x2
			{
				Player.DataObject.SetSize(val);
				Player.UpdateObject();
				pClient->Echo("Player size now: %g",val);
			}
			else pClient->Echo("Size must be between 0 and 3.");
		}
		else
		{
			pClient->Echo("Syntax: !edit size <size>");
		}
	}
	else if (!strnicmp(argv[0],"model",5))
	{
		unsigned long model=0;
		if(sscanf(argv[1], "0x%X", &model) || sscanf(argv[1], "%u", &model))
		{
			if(model)
			{
				Player.DataObject.SetModel(model);
				Player.UpdateObject();
				pClient->Echo("Player model now: 0x%X",model);
			}
			else pClient->Echo("Error: Model must not be 0.");
		}
		else {
			pClient->Echo("Syntax: !edit model <model>");
		}
	}
	else if (!strnicmp(argv[0],"exp",3))
	{
		Player.DataObject.SetXP(0);
		Player.AddExp(atoi(argv[1]));
		while(Player.Data.NextLevelExp < Player.Data.Exp) Player.AddExp(0);
		pClient->Echo("Player exp now: %d",atoi(argv[1]));
	}
	else if (!strnicmp(argv[0],"level",5))
	{
		Player.DataObject.SetLevel(atoi(argv[1]));
		Player.UpdateSkills(false);
		if(Player.Data.Level>9)
			Player.AddUpdateVal(PLAYER_CHARACTER_POINTS1, ((Player.Data.Level-9)-Player.Data.UsedTalentPoints)); // talent points
		else
			Player.AddUpdateVal(PLAYER_CHARACTER_POINTS1, 0); // talent points
		Player.UpdateObject();
		pClient->Echo("Player level now: %d",atoi(argv[1]));
	}
	else if (!strnicmp(argv[0],"speed",5))
	{
		float speed=0;
		sscanf(argv[1],"%g",&speed);
		if (speed < 250 && speed > 0)
		{
			pClient->pPlayer->SetSpeed(speed);
			pClient->Echo("Player speed now: %g",speed);
		}
		else {
			pClient->Echo("Syntax: !edit speed <speed>: speed must be between 0 and 250!");
		}
	}
	else if (!strnicmp(argv[0],"money",5))
	{
		int val = atoi(argv[1]);
		Player.DataObject.SetCoinage(val);
		Player.UpdateObject();
		pClient->Echo("Player money now: %d gold %d silver %d copper",val/10000,(val%10000)/100,val%100);
	}

	else if (!strnicmp(argv[0],"faction",7))
	{
		int val = atoi(argv[1]);
		Player.DataObject.SetFaction(val);
		Player.UpdateObject();
		pClient->Echo("Player faction now: %d",val);
	}
}

void EditCreature(CClient *pClient, CCreature &Creature, char **argv, int argc)
{
	pClient->Echo("Nag burlex to fix function");
	/*
	if(argc < 2)
	{
	pClient->Echo("Syntax: !edit <attribute> <newvalue>");
	pClient->Echo("Available attributes for that target is:");
	pClient->Echo("hps <hps>, dmg <min> <max>, size <size>, model <model>,");
	pClient->Echo("exp <exp>, level <level>, name <name>, vendor <type>,");
	pClient->Echo("faction <faction>, invfilter <invfilter flags>, item <model>");
	return;
	}
	if(!strnicmp(argv[0], "item",4))
	{
	if(argc != 6)
	{
	pClient->Echo("Syntax: !edit item <0-2> displayID <weapon/armour> <subclass> <invtype>");
	return;
	}
	int nItem = atoi(argv[1]);
	if(nItem < 0 || nItem > 2)
	{
	pClient->Echo("Item slot range is 0-2");
	return;
	}
	unsigned int displayID=0;
	if(!sscanf(argv[2], "0x%X", &displayID) && !sscanf(argv[2], "%d", &displayID))
	{
	pClient->Echo("Invalid displayID value. Prefix hex values with 0x.");
	return;
	}
	if(!displayID)
	{
	pClient->Echo("DisplayID must not be 0.");
	return;
	}
	bool isWeapon;
	if(!strnicmp(argv[3], "weapon", 6))
	isWeapon = true;
	else if(!strnicmp(argv[3], "armour", 6))
	isWeapon = false;
	else if(!strnicmp(argv[3], "armor", 5))
	isWeapon = false;
	else
	{
	pClient->Echo("You must choose either weapon or armour.");
	return;
	}
	string t = argv[4];
	MakeLower(t);
	map<string, unsigned long>::iterator i;
	if(isWeapon)
	{
	i = ChatManager.WeaponTypes.find(t);
	if(i == ChatManager.WeaponTypes.end())
	{
	t = "Available weapon types: ";
	i = ChatManager.WeaponTypes.begin();
	for(;i != ChatManager.WeaponTypes.end();i++)
	{
	t += i->first;
	t += ", ";
	}
	pClient->Echo(t.c_str());
	return;
	}
	}
	else
	{
	i = ChatManager.ArmourTypes.find(t);
	if(i == ChatManager.ArmourTypes.end())
	{
	t = "Available armour types: ";
	i = ChatManager.ArmourTypes.begin();
	for(;i != ChatManager.ArmourTypes.end();i++)
	{
	t += i->first;
	t += ", ";
	}
	pClient->Echo(t.c_str());
	return;
	}
	}
	unsigned long subClass = i->second;
	t = argv[5];
	MakeLower(t);
	i = ChatManager.InvTypes.find(t);
	if(i == ChatManager.InvTypes.end())
	{
	t = "Available inv types: ";
	i = ChatManager.InvTypes.begin();
	for(;i != ChatManager.InvTypes.end();i++)
	{
	t += i->first;
	t += ", ";
	}
	pClient->Echo(t.c_str());
	return;
	}
	unsigned long invtype = i->second;

	Creature.Data.virtualItemDisplay[nItem] = displayID;
	Creature.Data.virtualItemInfo[nItem].m_classID = (unsigned char)(isWeapon ? ITEMTYPE_WEAPON : ITEMTYPE_ARMOUR);
	Creature.Data.virtualItemInfo[nItem].m_subclassID = (unsigned char)subClass;
	Creature.Data.virtualItemInfo[nItem].m_inventoryType = (unsigned char)invtype;
	RegionManager.ObjectRemove(Creature);
	RegionManager.ObjectNew(Creature, Creature.Data.Continent, Creature.Data.Loc.X, Creature.Data.Loc.Y);
	// item <0-2> displayID <weapon/armour> <subclass> <invtype>
	pClient->Echo("Item assigned");
	}
	else if (!strnicmp(argv[0],"hps",3))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit hps <hps>");
	return;
	}
	int val = atoi(argv[1]);
	Creature.DataObject.SetHP(val);
	Creature.DataObject.SetMaxHP(val);
	Creature.UpdateObject();
	pClient->Echo("Creature hps now %d",val);
	return;
	}
	else if (!strnicmp(argv[0],"dmg",3))
	{
	if(argc != 3)
	{
	pClient->Echo("Syntax: !edit dmg <min> <max>");
	return;
	}
	unsigned long Val1,Val2;
	Val1=Val2=3;
	if (argc == 3 && sscanf(argv[1],"%u",&Val1) && sscanf(argv[2], "%u", &Val2))
	{
	Creature.Data.DamageMin=Val1;
	Creature.Data.DamageMax=Val2;
	pClient->Echo("Creature dmg now %d to %d",Val1,Val2);
	}
	else {
	pClient->Echo("Syntax: !edit dmg <min> <max>");
	}
	return;
	}
	else if (!strnicmp(argv[0],"size",4))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit size <size>");
	return;
	}
	float model_size=1;
	if (sscanf(argv[1],"%g",&model_size) && model_size<3 && model_size>0) // we have to retrieve the real max model size, i can do cow x30 size, but dragon max is like x2
	{
	Creature.DataObject.SetSize((float)atof(argv[1]));
	Creature.UpdateObject();
	pClient->Echo("Creature size now %g",(float)atof(argv[1]));
	}
	else {
	pClient->Echo("Syntax: !edit size <size>. Size must be between 0 and 3.");
	}
	return;
	}
	else if (!strnicmp(argv[0],"model",5))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit model <model>");
	return;
	}
	unsigned long val=0;
	if(!sscanf(argv[1],"0x%X",&val) && !sscanf(argv[1], "%u", &val))
	{
	pClient->Echo("Invalid model value. Prefix hex values with 0x.");
	return;
	}
	if(!val)
	{
	pClient->Echo("Model values cannot be 0.");
	return;
	}
	Creature.DataObject.SetModel(val);
	Creature.UpdateObject();
	pClient->Echo("Creature model now 0x%X",val);
	return;
	}
	else if (!strnicmp(argv[0],"exp",3))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit exp <exp>");
	return;
	}
	Creature.Data.Exp=atoi(argv[1]);
	pClient->Echo("Creature exp now %d",atoi(argv[1]));
	return;
	}
	else if (!strnicmp(argv[0],"level",5))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit level <level>");
	return;
	}
	Creature.DataObject.SetLevel(atoi(argv[1]));
	Creature.UpdateObject();
	pClient->Echo("Creature level now %d",atoi(argv[1]));
	return;
	}
	else if (!strnicmp(argv[0],"name",4))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit name <name>");
	return;
	}
	CCreatureTemplate *pTemplate;
	if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Creature.Data.Template))
	{
	pClient->Echo("Creature template '%s' renamed to '%s'.  This takes effect for any new retrievals of the template.",pTemplate->Data.Name,argv[1]);
	strncpy(pTemplate->Data.Name,argv[1],63);
	pTemplate->Data.Name[63]=0;
	//			strcpy(pTemplate->Data.Name1,pTemplate->Data.Name);
	//			strcpy(pTemplate->Data.Name2,pTemplate->Data.Name);
	//			strcpy(pTemplate->Data.Name3,pTemplate->Data.Name);
	}
	else {
	pClient->Echo("Couldnt find template");
	}
	return;
	}
	else if(!strnicmp(argv[0], "faction", 7))
	{
	if(argc != 2)
	{
	pClient->Echo("Syntax: !edit faction <faction>");
	return;
	}
	unsigned long val=0;
	if(sscanf(argv[1],"0x%X",&val) || sscanf(argv[1], "%u", &val))
	{
	if(val)
	{
	Creature.DataObject.SetFaction(val);
	Creature.UpdateObject();
	pClient->Echo("Creature faction now %u",val);
	}
	else
	{
	pClient->Echo("Faction must not be 0.");
	return;
	}
	}
	else {
	pClient->Echo("Syntax: !edit faction <faction>");
	return;
	}
	}
	*/
}

void CmdEdit(CClient *pClient, char **argv, int argc)
{
	CWoWObject *pTarget=0;
	if (DataManager.RetrieveObject(&pTarget,pClient->pPlayer->TargetID))
	{
		if (pTarget->type==OBJ_PLAYER)
		{
			if(pClient->pAccount->Data.UserLevel < ((CPlayer*)pTarget)->pClient->pAccount->Data.UserLevel)
			{
				pClient->Echo("You can only edit players that have lower userlevel than you.");
				return;
			}
			EditPlayer(pClient,*(CPlayer*)pTarget,argv,argc);
		}
		else if (pTarget->type==OBJ_CREATURE)
		{
			EditCreature(pClient,*(CCreature*)pTarget,argv, argc);
		}
		else
			pClient->Echo("You must select a valid target first.");
	}
	else
	{
		pClient->Echo("You must select a valid target first.");
	}
}

void CmdRehash(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !rehash");
		return;
	}
	Settings.LoadSettings();
	pClient->Echo("Server Settings Rehashed");
}

void CmdGet(CClient *pClient, char **argv, int argc)
{
	if(argc != 2)
	{
		pClient->Echo("Syntax: !get <type> <model>");
		pClient->Echo("Types for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger, trinket, back, mainhand, offhand");
		pClient->Echo("Prefix hex value with 0x.");
		return;
	}
	string type = argv[0];
	MakeLower(type);
	map<string, unsigned long>::iterator i = ChatManager.InvTypes.find(type);
	if(i == ChatManager.InvTypes.end())
	{
		pClient->Echo("Syntax: !get <type> <model>");
		pClient->Echo("Types for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger, trinket, back, mainhand, offhand");
		return;
	}
	unsigned long model=0;
	if(!sscanf(argv[1], "0x%X", &model) && !sscanf(argv[1], "%u", &model) && !model)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	int newSlot=pClient->pPlayer->GetOpenBackpackSlot();
	if(newSlot == -1)
	{
		pClient->Echo("Backpack full.");
		return;
	}
	CItemTemplate* pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->Data.InventoryType = i->second;
	pTemplate->Data.DisplayID = model;
	sprintf(pTemplate->Data.Name, "Item 0x%X", model);
	DataManager.NewObject(*pTemplate);
	CItem *pItem = new CItem;
	pItem->New(pTemplate->guid, pClient->pPlayer->guid);
	DataManager.NewObject(*pItem);
	pClient->AddKnownItem(*pItem);
//	pClient->pDataObject->SetItem(newSlot, pItem->guid);
	pClient->pDataObject->SetItem(newSlot, pItem);
	pClient->UpdateObject();
	pClient->Echo("Item received...");
}

void CmdMorph(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !morph <model>");
		return;
	}
	unsigned long model=0;
	if(!sscanf(argv[0], "0x%X", &model) && !sscanf(argv[0], "%u", &model))
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x");
		return;
	}
	if(model == 0)
		return;
	pClient->pDataObject->SetModel(model);
	pClient->UpdateObject();
	pClient->Echo("You have morphed into model: %X",model);
}

void CmdUber(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !uber");
		return;
	}
	if (pClient->pPlayer->Data.StatusFlags & STATUS_GM)
	{
		pClient->pDataObject->ClearFlag(STATUS_GM);
		pClient->pDataObject->SetHP(200);
		pClient->pDataObject->SetMaxHP(200);
		pClient->pDataObject->SetMana(500);
		pClient->pDataObject->SetMaxMana(500);
		pClient->pDataObject->SetRage(1000);
		pClient->pDataObject->SetMaxRage(1000);
		pClient->pDataObject->SetFocus(100);
		pClient->pDataObject->SetMaxFocus(100);
		pClient->pDataObject->SetEnergy(100);
		pClient->pDataObject->SetMaxEnergy(100);
		pClient->pDataObject->SetLevel(5);
		pClient->pDataObject->SetXP(0);
	}
	else
	{
		pClient->pDataObject->SetFlag(STATUS_GM);
		pClient->pDataObject->SetHP(100000);
		pClient->pDataObject->SetMaxHP(100000);
		pClient->pDataObject->SetMana(100000);
		pClient->pDataObject->SetMaxMana(100000);
		pClient->pDataObject->SetRage(100000);
		pClient->pDataObject->SetMaxRage(100000);
		pClient->pDataObject->SetFocus(100000);
		pClient->pDataObject->SetMaxFocus(100000);
		pClient->pDataObject->SetEnergy(100000);
		pClient->pDataObject->SetMaxEnergy(100000);
		pClient->pDataObject->SetMinDamage(1000);
		pClient->pDataObject->SetMaxDamage(1000);
		pClient->pDataObject->SetCoinage(1000000);
		pClient->pDataObject->SetLevel(255);
	}
	pClient->UpdateObject();
	pClient->Echo("GM status %s",pClient->pPlayer->Data.StatusFlags & STATUS_GM ? "Enabled" : "Disabled");
}

void CmdDeathtouch(CClient *pClient, char **argv, int argc)
{
	if (argc > 1) {
		pClient->Echo("Syntax: !deathtouch [player]");
		return;
	}
	if(argc == 1)
	{
		string Who=argv[0];
		MakeLower(Who);
		unsigned long PlayerID=DataManager.PlayerNames[Who];
		if (!PlayerID)
		{
			pClient->Echo("Player '%s' does not exist.",argv[0]);
			return;
		}
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
		{
			if (!pTarget->pClient)
			{
				pClient->Echo("Player '%s' not online.",argv[0]);
				return;
			}
			/*
			unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00,
			0x07, 0x00, 0x00, 0x00, 0x82, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x42, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB8, 0x1A, 0x1A, 0x46, 0x29, 0x2C,
			0x6E, 0x44, 0xD5, 0x50, 0xA3, 0x44};
			*/
			unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00,
				0x49, 0x02, 0x00, 0x00, 0x00, 0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
			pTarget->pClient->Echo("You have been touched with death!");
			*(unsigned long*)&packet[0x17]=pTarget->pClient->pPlayer->guid;
			*(unsigned long*)&packet[0x22]=pTarget->pClient->pPlayer->guid;
			pTarget->pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
			pTarget->DataObject.AddHP(-1337);
			CRegion *pPlayerRegion=RegionManager.ObjectRegions[pTarget->pClient->pPlayer->guid];
			if (!pPlayerRegion)
				return;
			pClient->RegionOutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
			if (pTarget->pClient->pPlayer->Data.CurrentStats.HitPoints <= 0)
			{
				pTarget->pClient->pPlayer->ClearEvents();
			}
			pTarget->UpdateObject();
			pClient->Echo("Player %s has been touched with death",pTarget->Data.Name);
		}
	}
	else
	{
		// This should probably be a function, feel free to relocate ;)
		/*
		unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00,
		0x07, 0x00, 0x00, 0x00, 0x82, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
		0x42, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB8, 0x1A, 0x1A, 0x46, 0x29, 0x2C,
		0x6E, 0x44, 0xD5, 0x50, 0xA3, 0x44};
		*/
		unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00,
			0x49, 0x02, 0x00, 0x00, 0x00, 0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		*(unsigned long*)&packet[0x00]=pClient->pPlayer->guid;
		*(unsigned long*)&packet[0x08]=pClient->pPlayer->guid;

		CRegion *pPlayerRegion=RegionManager.ObjectRegions[pClient->pPlayer->guid];
		if (!pPlayerRegion)
			return;
		for (int i = 0 ; i < 3 ; i++)
			for (int j = 0 ; j < 3 ; j++)
			{
				if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
				{
					RegionObjectNode *pNode=pRegion->pList;
					while(pNode)
					{
						switch(pNode->pObject->type)
						{
						case OBJ_PLAYER:
							CPlayer *pPlayer = (CPlayer*)pNode->pObject;
							if (pPlayer->pClient!=pClient && pPlayer->pClient->pAccount->Data.UserLevel<USER_GM)
							{
								pPlayer->pClient->Echo("You have been touched with death!");
								*(unsigned long*)&packet[0x17]=pPlayer->guid;
								*(unsigned long*)&packet[0x22]=pPlayer->guid;
								pPlayer->pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
								pPlayer->DataObject.AddHP(-1337);
								if (pPlayer->Data.CurrentStats.HitPoints <= 0)
								{
									pPlayer->ClearEvents();
								}
								pPlayer->UpdateObject();
							}
							pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
							break;
						}
						pNode=pNode->pNext;
					}
				}
			}
			pClient->Echo("Surrounding players killed");
	}
}

void CmdMaxsent(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !maxsent");
		return;
	}
	pClient->Echo("MaxSent=%d",RealmServer.MaxSent);
}

void CmdBroadcast(CClient *pClient, char *input)
{
	if(input[0] == 0)
	{
		pClient->Echo("Syntax: !broadcast <msg>");
		return;
	}
	if (strlen(input)>2)
	{
		char buffer[2048];
		memset(buffer,0,2048);
		int c = 0;
		buffer[c++]=CHAT_SYSTEM;
		/* memset eliminates the need to write these
		*(unsigned long*)&buffer[c]=0;	// language
		c+=4;
		*(unsigned long*)&buffer[c]=0;
		c+=4;
		*(unsigned long*)&buffer[c]=0;  // guid high
		c+=4;
		*/
		c+=12;
		string input2;
		input2 = "|cffff6060<";
		if (pClient->pAccount->Data.UserLevel == USER_ADMIN)
			input2+="Admin";
		else
			input2+="GM";
		input2+=">|r |c1f40af20";
		input2+=pClient->pPlayer->Data.Name;
		input2+="|r|cffffffff announces: |r";
		input2+=input;
		*(unsigned long*)&buffer[c]= strlen(input2.c_str())+1;
		c+=4;

		strcpy(&buffer[c],input2.c_str());
		c+=strlen(input2.c_str())+1;

		buffer[c++] = (char)pClient->pPlayer->Data.StatusFlags;
		RealmServer.BroadcastOutPacket(SMSG_MESSAGECHAT,buffer,c);
	}
}
#ifndef ACCOUNTLESS
void CmdUserLevel(CClient *pClient, char **argv, int argc)
{
	if(argc != 2)
	{
		pClient->Echo("Syntax: !userlevel <account/player name> <userlevel>");
		return;
	}

	CAccount *pAccount = NULL;
	string name = argv[0];
	MakeLower(name);
	if(name == "admin")
		return;
	map<string, unsigned long>::iterator i = DataManager.AccountNames.find(name);
	unsigned long AccountID = 0;
	if(i == DataManager.AccountNames.end())
	{
		i = DataManager.PlayerNames.find(name);
		if(i == DataManager.PlayerNames.end())
		{
			pClient->Echo("Unable to find account or player.");
			return;
		}
		else
		{
			CPlayer *pPlayer = NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
			{
				pClient->Echo("Internal error: Unable to retrieve player.");
				return;
			}
			AccountID = pPlayer->AccountID;
		}
	}
	else
	{
		AccountID = i->second;
	}


	if(AccountID == pClient->pAccount->guid)
	{
		pClient->Echo("Can't change userlevel on your own account.");
		return;
	}

	if(!DataManager.RetrieveObject((CWoWObject**)&pAccount, OBJ_ACCOUNT, AccountID))
	{
		pClient->Echo("Internal error: Unable to retrieve account.");
		return;
	}

	string lvl = argv[1];
	MakeLower(lvl);
	map<string, int>::iterator lev = ChatManager.UserLevels.find(lvl);
	if(lev == ChatManager.UserLevels.end())
	{
		pClient->Echo("Invalid userlevel.");
		return;
	}
	int newLevel = lev->second;
	int oldLevel = pAccount->Data.UserLevel;
	int userLevel = pClient->pAccount->Data.UserLevel;
	if(oldLevel == newLevel)
	{
		pClient->Echo("User already has that level.");
		return;
	}
	if (newLevel > USER_NORMAL) {
		if (userLevel < USER_SUPERGM) {
			pClient->Echo("Only Admins can promote higher than USERLEVEL NORMAL.");
			return;
		}
	}
	if(newLevel > userLevel)
	{
		pClient->Echo("Cannot promote beyond your userlevel.");
		return;
	}
	if(oldLevel > userLevel)
	{
		pClient->Echo("Cannot change account status of a higher ranking user.");
		return;
	}
	if (newLevel<oldLevel && oldLevel<USER_ADMIN)// demotion...
	{
		if ( (userLevel<USER_ADMIN && (oldLevel==USER_GM))  ||
			(userLevel<USER_GM && (oldLevel==USER_MODERATOR || oldLevel==USER_HALFGM))
			)
		{
			pClient->Echo("Insufficient user level to demote user.");
			return;
		}
	}

	bool notifyUser = pAccount->pClient != NULL && pAccount->pClient->pPlayer != NULL;
	switch(newLevel)
	{
	case USER_ADMIN:
		if (pClient->pAccount->Data.UserLevel<USER_ADMIN)
		{
			pClient->Echo("Only Administrators can assign other administrators.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_ADMIN;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Administrator status.");
			pClient->Echo("%s has been given Administrator status.",pAccount->Data.Name);
		}
		break;
	case USER_SUPERGM:
		if (pClient->pAccount->Data.UserLevel<USER_ADMIN)
		{
			pClient->Echo("Only Administrators can assign GMs.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_SUPERGM;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given SUPERGM status.");
			pClient->Echo("%s has been given SUPERGM status.",pAccount->Data.Name);
		}
		break;
	case USER_GM:
		if (pClient->pAccount->Data.UserLevel<USER_ADMIN)
		{
			pClient->Echo("Only Administrators can assign GMs.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_GM;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given GM status.");
			pClient->Echo("%s has been given GM status.",pAccount->Data.Name);
		}
		break;
	case USER_HALFGM:
		if (pClient->pAccount->Data.UserLevel<USER_GM)
		{
			pClient->Echo("Only GM or greater can assign Half-GMs.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_HALFGM;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Half-GM status.");
			pClient->Echo("%s has been given Half-GM status.",pAccount->Data.Name);
		}
		break;
	case USER_SUPERMOD:
		if (pClient->pAccount->Data.UserLevel<USER_GM)
		{
			pClient->Echo("Only GM or greater can assign Super Moderators.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_SUPERMOD;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Super Moderator status.");
			pClient->Echo("%s has been given Super Moderator status.",pAccount->Data.Name);
		}
		break;
	case USER_MODERATOR:
		if (pClient->pAccount->Data.UserLevel<USER_GM)
		{
			pClient->Echo("Only GM or greater can assign Moderators.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_MODERATOR;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Moderator status.");
			pClient->Echo("%s has been given Moderator status.",pAccount->Data.Name);
		}
		break;
	case USER_PRIVLEDGED:
		if (pClient->pAccount->Data.UserLevel<USER_GM)
		{
			pClient->Echo("Only GM or greater can assign PRIVLEDGED.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_PRIVLEDGED;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given PRIVLEDGED status.");
			pClient->Echo("%s has been given PRIVLEDGED status.",pAccount->Data.Name);
		}
		break;
	case USER_NORMAL:
		if (pClient->pAccount->Data.UserLevel<USER_MODERATOR)
		{
			pClient->Echo("Only Moderator or greater can assign Normal-User status.");
		}
		else
		{
			pAccount->Data.UserLevel=USER_NORMAL;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Normal status.");
			pClient->Echo("%s has been given Normal status.",pAccount->Data.Name);
		}
		break;
	case USER_SUSPENDED:
		pAccount->Data.UserLevel=USER_SUSPENDED;
		if(notifyUser)
			pAccount->pClient->Echo("Your account has been given Suspended status.");
		pClient->Echo("%s has been given Suspended status.",pAccount->Data.Name);
		pAccount->Data.SuspendedUntil=time(0)+3600*24*7; //one week
		break;
	case USER_BANNED:
		{
			pAccount->Data.UserLevel=USER_BANNED;
			if(notifyUser)
				pAccount->pClient->Echo("Your account has been given Banned status.");
			unsigned char ip1,ip2,ip3,ip4;
			unsigned long ip=pAccount->Data.ip;
			ip4=(unsigned char)(ip & 0xff);
			ip3=(unsigned char)((ip>>8) & 0xff);
			ip2=(unsigned char)((ip>>16) & 0xff);
			ip1=(unsigned char)((ip>>24) & 0xff);
			pClient->Echo("%s has been given Banned status. Account IP: %i.%i.%i.%i",pAccount->Data.Name,ip1,ip2,ip3,ip4);
			Settings.Banned[ip]=1; //only temporary!
		}
		break;
	case USER_DELETE: //ok, next time the server tries to load the account from file it will be deleted FOREVER! Mwahaha!
		pAccount->Data.UserLevel=USER_DELETE;
		if(notifyUser)
			pAccount->pClient->Echo("Your account has been given Pending Delete status.");
		pClient->Echo("%s has been given Pending Delete status.",pAccount->Data.Name);
		pAccount->Save(); //so that this is recorded
		break;
	}
	DataManager.StoreObject(*pAccount);
}
#endif // ACCOUNTLESS

void CmdResetPlayer(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !resetplayer <player>");
		return;
	}
	string Who=argv[0];
	MakeLower(Who);
	unsigned long PlayerID=DataManager.PlayerNames[Who];
	if (!PlayerID)
	{
		pClient->Echo("Player '%s' does not exist.",argv[0]);
		return;
	}
	CPlayer *pTarget=0;
	if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
	{
		if(!pTarget->pClient)
		{
			pClient->Echo("Player %s is not online.",pTarget->Data.Name);
			return;
		}
		if(pTarget->Data.ResurrectionSickness)
		{
			pTarget->ClearEvents(EVENT_PLAYER_REZSICKNESS);
			pTarget->Data.ResurrectionSickness = false;
		}
		pTarget->Data.PvP = true;
		pTarget->DataObject.TogglePVP();
		pTarget->Data.RecentPvP = false;
		pTarget->DataObject.SetHP(pTarget->Data.NormalStats.HitPoints);
		pTarget->DataObject.SetMana(pTarget->Data.NormalStats.Mana);
		pTarget->UpdateObject();
		pClient->Echo("Player %s reset",pTarget->Data.Name);
	}
	else {
		pClient->Echo("Player %s not found.",pTarget->Data.Name);
		return;
	}
}

void CmdKickPlayer(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !kickplayer <name>");
		return;
	}
	string Who=argv[0];
	MakeLower(Who);
	unsigned long PlayerID=DataManager.PlayerNames[Who];
	if (!PlayerID)
	{
		pClient->Echo("Player '%s' does not exist.",argv[0]);
		return;
	}
	CPlayer *pTarget=0;
	if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
	{
		if (pTarget->pClient)
		{
			pClient->Echo("Player %s kicked",pTarget->Data.Name);
			pTarget->pClient->DestroyMe=true;
		}
		else
		{
			pClient->Echo("Player %s not online",pTarget->Data.Name);
		}
	}
	else {
		pClient->Echo("Player %s not found.",pTarget->Data.Name);
		return;
	}
}

void CmdGive(CClient *pClient, char **argv, int argc)
{
	if(argc == 2)
	{
		string name = argv[0];
		MakeLower(name);
		map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
		if(i == DataManager.PlayerNames.end())
		{
			pClient->Echo("Unable to find player '%s'.", argv[0]);
			return;
		}
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, i->second))
		{
			pClient->Echo("Internal error: Unable to get player.");
			return;
		}

		if(pPlayer->pClient == NULL)
		{
			pClient->Echo("Player not online.");
		}

		int newSlot = pPlayer->GetOpenBackpackSlot();
		if(newSlot == -1)
		{
			pClient->Echo("%s backpack is full!", pPlayer->Data.Name);
			return;
		}
		unsigned long ItemID;
		if(!sscanf(argv[1], "0x%X", &ItemID) && !sscanf(argv[1], "%u", &ItemID))
		{
			pClient->Echo("Invalid Item ID. Prefix hex values with 0x.");
			return;
		}
		unsigned long TemplateID=DataManager.ItemTemplates[ItemID];
		if(!TemplateID)
		{
			pClient->Echo("Item not found.");
			return;
		}
		CItem *pItem = new CItem;
		pItem->New(TemplateID, pPlayer->guid);
		DataManager.NewObject(*pItem);
		//RegionManager.ObjectNew(*pItem, pPlayer->Data.Continent, pPlayer->Data.Loc.X, pPlayer->Data.Loc.Y);

		pClient->AddKnownItem(*pItem);
		pPlayer->DataObject.SetItem(newSlot, pItem);
//		pPlayer->DataObject.SetItem(newSlot, pItem->guid);
		pPlayer->UpdateObject();

		pClient->Echo("You gave %s to %s.", pItem->pTemplateData->Name, pPlayer->Data.Name);
		pPlayer->pClient->Echo("%s gave you %s. It has been automatically stored into your backpack.",
			pClient->pPlayer->Data.Name, argv[1]);
		return;
	}
	if(argc != 4)
	{
		pClient->Echo("Syntax: !give <player> <itemname> <worntype> <model>\nor !give <player> <item id>");
		return;
	}
	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, i->second))
	{
		pClient->Echo("Internal error: Unable to get player.");
		return;
	}

	if(pPlayer->pClient == NULL)
	{
		pClient->Echo("Player not online.");
	}

	int newSlot = pPlayer->GetOpenBackpackSlot();
	if(newSlot == -1)
	{
		pClient->Echo("%s backpack is full!", pPlayer->Data.Name);
		return;
	}
	name = argv[2];
	MakeLower(name);
	i = ChatManager.InvTypes.find(name);
	if(i == ChatManager.InvTypes.end())
	{
		name = "Valid worn types are: ";
		for(i = ChatManager.InvTypes.begin();i != ChatManager.InvTypes.end();i++)
		{
			name += i->first;
			name += ", ";
		}
		pClient->Echo(name.c_str());
		return;
	}
	unsigned long model=0;
	if(!sscanf(argv[3], "0x%X", &model) && !sscanf(argv[3], "%u", &model))
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	if(!model)
	{
		pClient->Echo("Error: Model must not be 0.");
		return;
	}
	CItemTemplate *pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->Data.DisplayID = model;
	pTemplate->Data.InventoryType = i->second;
	strncpy(pTemplate->Data.Name, argv[1], 63);
	pTemplate->Data.Name[63] = 0;
	DataManager.NewObject(*pTemplate);
	CItem *pItem = new CItem;
	pItem->New(pTemplate->guid, pPlayer->guid);
	DataManager.NewObject(*pItem);
	//RegionManager.ObjectNew(*pItem, pPlayer->Data.Continent, pPlayer->Data.Loc.X, pPlayer->Data.Loc.Y);

	pClient->AddKnownItem(*pItem);
//	pPlayer->DataObject.SetItem(newSlot, pItem->guid);
	pPlayer->DataObject.SetItem(newSlot, pItem);
	pPlayer->UpdateObject();

	pClient->Echo("You gave %s to %s.", argv[1], pPlayer->Data.Name);
	pPlayer->pClient->Echo("%s gave you %s. It has been automatically stored into your backpack.",
		pClient->pPlayer->Data.Name, argv[1]);
}

void CmdFind(CClient *pClient)
{
	pClient->Echo("-------------------------------------------------");
	map<string, unsigned long>::iterator i;
	for (i=DataManager.PlayerNames.begin(); i!=DataManager.PlayerNames.end();i++) {
		CPlayer *pPlayer = NULL;
		if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, i->second))
		{
			if(pPlayer->pClient != NULL)
			{
				if (pPlayer->pClient->pAccount->Data.UserLevel == USER_ADMIN) {
					if (pPlayer->pClient->pDataObject->GetStatusFlags() & STATUS_GM)
						pClient->Echo("ADMIN: %s",pPlayer->Data.Name);
				}
				else if (pPlayer->pClient->pAccount->Data.UserLevel == USER_SUPERGM) {
					if (pPlayer->pClient->pDataObject->GetStatusFlags() & STATUS_GM)
						pClient->Echo("GM: %s",pPlayer->Data.Name);
				}
				else if (pPlayer->pClient->pAccount->Data.UserLevel == USER_GM) {
					if (pPlayer->pClient->pDataObject->GetStatusFlags() & STATUS_GM)
						pClient->Echo("GM: %s",pPlayer->Data.Name);
				}
				else if (pPlayer->pClient->pAccount->Data.UserLevel == USER_HALFGM) {
					if (pPlayer->pClient->pDataObject->GetStatusFlags() & STATUS_GM)
						pClient->Echo("GM: %s",pPlayer->Data.Name);
				}
				else if (pPlayer->pClient->pAccount->Data.UserLevel == USER_SUPERMOD) {
					pClient->Echo("MOD: %s",pPlayer->Data.Name);
				}
				else if (pPlayer->pClient->pAccount->Data.UserLevel == USER_MODERATOR) {
					pClient->Echo("MOD: %s",pPlayer->Data.Name);
				}
			}
		}
	}
	pClient->Echo("-------------------------------------------------");
}

void CmdStrip(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !strip <player>");
		return;
	}
	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, i->second))
	{
		pClient->Echo("Internal error: Unable to get player.");
		return;
	}

	if(pPlayer->pClient == NULL)
	{
		pClient->Echo("Player not online.");
	}

	for(int i = 0;i < 0x45;i++)
	{
		if(CItem *pItem = pPlayer->Data.Items[i])
		{
//			unsigned long temp = pPlayer->Data.Items[i];
//			pPlayer->DataObject.SetItem(i, 0);
			pPlayer->DataObject.SetItem(i, NULL);
//			CItem *pItem = NULL;
//			if(DataManager.RetrieveObject((CWoWObject**)&pItem, temp))
			{
				RegionManager.ObjectRemove(*pItem);
				pItem->Delete();
			}
		}
	}
	if(pPlayer->UpdateDirty())
	{
		pPlayer->UpdateObject();
		pClient->Echo("Ok. Stripped %s items.", pPlayer->Data.Name);
	}
	else
		pClient->Echo("No items stripped from %s.", pPlayer->Data.Name);
}


void CmdKillSpawn(CClient *pClient, char *input)
{
	if(input[0] != 0)
	{
		pClient->Echo("Syntax: !killspawn");
		return;
	}
	if(pClient->pPlayer->TargetID == 0)
	{
		pClient->Echo("You must select a creature to despawn.");
		return;
	}
	CCreature *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature, pClient->pPlayer->TargetID))
	{
		pClient->Echo("You must select a creature to despawn.");
		return;
	}
	pCreature->DataObject.SetHP(0);
	//if (pCreature->Data.isSaved)
	//	pClient->Echo("This is a static spawn and will be recreated when the server starts.");
	// pCreature->Delete();
	// pClient->Echo("Spawn killed.");
}

void CmdMorphTarget(CClient *pClient, char **argv, int argc)
{
	return;	// needs fixing
	/*
	if(argc < 1)
	{
	pClient->Echo("Syntax: !morphtarget <model> [playername]");
	pClient->Echo("If player name is not supplied it will morph the player/creature you are selecting.");
	}

	unsigned long model=0;
	if(!sscanf(argv[0], "0x%X", &model) && !sscanf(argv[0], "%u", &model))
	{
	pClient->Echo("Invalid model value. Prefix hex values with 0x.");
	return;
	}
	if(!model)
	{
	pClient->Echo("Error: Model must not be 0.");
	return;
	}
	unsigned long target;
	if(argc >= 2)
	{
	string name = argv[1];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
	pClient->Echo("Unable to find '%s'.", argv[1]);
	return;
	}
	target = i->second;
	}
	else
	{
	target = pClient->pPlayer->TargetID;
	if(target == 0)
	{
	pClient->Echo("Select a target first.");
	return;
	}
	}
	CPlayer *pPlayer = NULL;
	CCreature *pCreature = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, target))
	{
	if(pPlayer->pClient == NULL)
	{
	pClient->Echo("That player is not online.");
	return;
	}
	pPlayer->DataObject.SetModel(model);
	pPlayer->UpdateObject();
	pClient->Echo("You morphed %s into 0x%X.", pPlayer->Data.Name, pPlayer->Data.Model);
	pPlayer->pClient->Echo("You morph into 0x%X.", pPlayer->Data.Model);
	}
	else if(DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, target))
	{
	pCreature->DataObject.SetModel(model);
	pCreature->UpdateObject();
	pClient->Echo("You morphed %s into 0x%X.", pCreature->pTemplate->Data.Name, pCreature->Data.Model);
	}
	else
	{
	pClient->Echo("Unknown target.");
	}*/
}

void CmdMountModel(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !mountmodel <model>");
		return;
	}
	unsigned long model=0;
	if(!sscanf(argv[0], "0x%X", &model) && !sscanf(argv[0], "%u", &model))
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	if(!model)
	{
		pClient->Echo("Error: Model must not be 0.");
		return;
	}
	if(pClient->pPlayer->Data.MountModel != 0)
	{
		pClient->Echo("You need to dismount first.");
		return;
	}
	pClient->pDataObject->SetMountModel(model);
	pClient->UpdateObject();
	pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED*2);
	pClient->Echo("Mount model set to 0x%X.", model);
}

void CmdGetPosition(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !getposition <player>");
		return;
	}

	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}

	pClient->Echo("%s is at %d %f, %f, %f.", pPlayer->Data.Name,
		pPlayer->Data.Continent,pPlayer->Data.Loc.X, pPlayer->Data.Loc.Y, pPlayer->Data.Loc.Z);
}

void CmdGoto(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !goto <player>");
		return;
	}

	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}
	Packets::TeleportOrNewWorld(pClient, pPlayer->Data.Continent,pPlayer->Data.Loc);

	pClient->Echo("You have Been Teleported to Player: [ %s ]", pPlayer->Data.Name);
}

void CmdSummon(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !summon <player>");
		return;
	}
	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}

	if(pPlayer->pClient == NULL)
	{
		pClient->Echo("%s is not online.", pPlayer->Data.Name);
		return;
	}

	if(pPlayer->pClient->pAccount->Data.UserLevel >= pClient->pAccount->Data.UserLevel ||
		pPlayer == pClient->pPlayer)
	{
		pClient->Echo("You cannot summon that player.");
		return;
	}

	pPlayer->summonedCont = pPlayer->Data.Continent;
	pPlayer->summonedLoc = pPlayer->Data.Loc;
	pPlayer->Data.bSummoned = true;

	Packets::TeleportOrNewWorld(pPlayer->pClient, pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc);

	Packets::Root(pPlayer->pClient);

	pPlayer->pClient->Echo("You have been summoned by Player: %s.", pClient->pPlayer->Data.Name);
	pClient->Echo("You have summoned Player: %s.", pPlayer->Data.Name);
}

void CmdRelease(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !release <player>");
		return;
	}
	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}
	if(pPlayer->Data.bSummoned == false)
	{
		pClient->Echo("That player has not been summoned.");
		return;
	}
	pPlayer->Data.bSummoned = false;
	pClient->Echo("You released Player %s.", pPlayer->Data.Name);
	if(pPlayer->pClient)
	{
		Packets::UnRoot(pPlayer->pClient);
		pPlayer->pClient->Echo("You have been released.");
	}
}

void CmdReturn(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: !return <player>");
		return;
	}
	string name = argv[0];
	MakeLower(name);
	map<string, unsigned long>::iterator i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		pClient->Echo("Unable to find player '%s'.", argv[0]);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		pClient->Echo("Internal error: Unable to retrieve player.");
		return;
	}
	if (pPlayer->summonedLoc.X)
	{
		pPlayer->Data.bSummoned = false;
		Packets::TeleportOrNewWorld(pPlayer->pClient, pPlayer->summonedCont, pPlayer->summonedLoc);
		pClient->Echo("You return %s.", pPlayer->Data.Name);
		if(pPlayer->pClient)
			pPlayer->pClient->Echo("You have been returned to your last position.");
	}
	else
		pClient->Echo("This Player Haven't Been Summoned Before...");
}


void CmdCape(CClient *pClient, char **argv, int argc)
{
	map<string, unsigned long>::iterator i;
	if(argc == 1)
	{
		string name = argv[0];
		MakeLower(name);
		i = ChatManager.Cloaks.find(name);
	}
	if(argc != 1 || i == ChatManager.Cloaks.end())
	{
		pClient->Echo("Syntax: !cape <color>");
		string output = "Available cloak colors are: ";
		for(i = ChatManager.Cloaks.begin();i != ChatManager.Cloaks.end();i++)
		{
			output += i->first;
			output += ", ";
		}
		pClient->Echo(output.c_str());
		return;
	}
	CItem *pItem=new CItem;
	pItem->New(i->second,pClient->pPlayer->guid);
	DataManager.NewObject(*pItem);

	if(pClient->pPlayer->Data.Items[SLOT_BACK] != 0)
		pClient->pPlayer->DestroyItem(SLOT_BACK);
//	pClient->pDataObject->SetItem(SLOT_BACK, pItem->guid);
	pClient->pDataObject->SetItem(SLOT_BACK, pItem);
	pClient->AddKnownItem(*pItem);
	pClient->Echo("You receive a cape!");
}

void CmdSetVal(CClient *pClient, char **argv, int argc)
{
	if(argc != 2)
	{
		pClient->Echo("Syntax: !setval <field> <val>");
		return;
	}
	unsigned int field, val;
	field=val=0;
	if(!sscanf(argv[0], "0x%X", &field) && !sscanf(argv[0], "%u", &field))
	{
		pClient->Echo("Invalid field value. Prefix hex values with 0x.");
		return;
	}
	if(!sscanf(argv[1], "0x%X", &val) && !sscanf(argv[1], "%u", &val))
	{
		pClient->Echo("Invalid val value. Prefix hex values with 0x.");
		return;
	}
	if(pClient->pPlayer->TargetID == 0)
	{
		pClient->Echo("You have no target.");
		return;
	}
	CCreature *pCreature;
	CPlayer *pPlayer;
	if(DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, pClient->pPlayer->TargetID))
	{
		if(field < 194)
		{
			pCreature->AddUpdateVal(field, val);
			pCreature->UpdateObject();
			pClient->Echo("Ok. Update field %d with value 0x%X on %s.", field, val, pCreature->pTemplate->Data.Name);
			return;
		}
		pClient->Echo("Invalid field.");
		return;
	}
	else if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, pClient->pPlayer->TargetID))
	{
		if(field < NUM_PLAYER_FIELDS)
		{
			pPlayer->AddUpdateVal(field, val);
			pPlayer->UpdateObjectOnlyMe();
			pClient->Echo("Ok. Update field %d with value 0x%X on %s.", field, val, pPlayer->Data.Name);
			return;
		}
		pClient->Echo("Invalid field.");
		return;
	}
	pClient->Echo("Selected object invalid.");
	return;
}

void BroadCastMsg(char *output)
{
	char buffer[2048];
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=0;
	c+=12;
	*(unsigned long*)&buffer[c] = strlen(output)+1;
	c+=4;
	strcpy(&buffer[c],output);
	c+=strlen(output)+2;
	RealmServer.BroadcastOutPacket(SMSG_MESSAGECHAT,buffer,c);
}

map<unsigned long, bool> votes;
bool VoteInProgress = false;
void CmdCallVote(CClient *pClient, char *input)
{
	if (input[0] == 0) {
		pClient->Echo("Syntax: !callvote <msg>");
		return;
	}
	if(VoteInProgress)
	{
		pClient->Echo("A vote is already in progress. Use 'tally' to end it.");
		return;
	}
	char temp[2048];
	sprintf(temp, "%s starts a vote on whether or not:", pClient->pPlayer->Data.Name);
	BroadCastMsg(temp);
	BroadCastMsg(input);
	BroadCastMsg("Type 'vote yes' if you agree or 'vote no' if you disagree");
	VoteInProgress = true;
}

void CmdVote(CClient *pClient, char *input)
{
	if (input[0] == 0) {
		pClient->Echo("Syntax: !vote <yes/no>");
		return;
	}
	if(!VoteInProgress)
	{
		pClient->Echo("There's no vote in progress.");
		return;
	}
	bool vote;
	if(!stricmp(input, "yes"))
	{
		vote = true;
	}
	else if(!stricmp(input, "no"))
	{
		vote = false;
	}
	else
	{
		pClient->Echo("Please vote 'yes' or 'no'");
		return;
	}
	map<unsigned long, bool>::iterator i = votes.find(pClient->pAccount->guid);
	if(i != votes.end())
	{
		pClient->Echo("You have already voted on this issue.");
		return;
	}
	pClient->Echo("You voted %s.", input);
	votes[pClient->pAccount->guid] = vote;
}

void CmdTally(CClient *pClient, char *input)
{
	if (input[0] != 0) {
		pClient->Echo("Syntax: !tally");
		return;
	}
	if(!VoteInProgress)
	{
		pClient->Echo("There's no vote in progress.");
		return;
	}
	int yes = 0, no = 0;
	map<unsigned long, bool>::iterator i = votes.begin();
	for(;i != votes.end();i++)
	{
		if(i->second)
			yes++;
		else
			no++;
	}
	char temp[50];
	BroadCastMsg("Tallying up the votes...");
	BroadCastMsg("End score:");
	sprintf(temp, "Yes: %d", yes);
	BroadCastMsg(temp);
	sprintf(temp, "No: %d", no);
	BroadCastMsg(temp);
	votes.clear();
	VoteInProgress = false;
}

void CmdShowStats(CClient *pClient, char** argv, int argc)
{
	return;	// bur: this is broken anyways.. needs FIXING!
	/*
	bool showhps = false;
	bool showlevel = false;
	bool showexp = false;
	bool showloc = false;
	bool showdmg = false;
	bool showsize = false;
	bool showname = false;
	bool showfaction = false;
	bool showtype = false;
	bool showmodel = false;
	bool foundplayer = false;

	if(argc > 1)
	{
	pClient->Echo("Syntax: !showstats <arg>");
	pClient->Echo("Syntax: Valid values for <arg> are: [all], hps, level, exp, loc, dmg, size, name, faction, type, model");
	return;
	}

	if(pClient->pPlayer->TargetID == 0)
	{
	pClient->Echo("You must select a Creature or Player to get info.");
	return;
	}

	if (argc == 0 || !strnicmp(argv[0],"all",3))
	{
	showhps = true;
	showlevel = true;
	showexp = true;
	showloc = true;
	showdmg = true;
	showsize = true;
	showname = true;
	showfaction = true;
	showtype = true;
	showmodel = true;
	}
	else if (!strnicmp(argv[0],"hps",3)) showhps = true;
	else if (!strnicmp(argv[0],"level",5)) showlevel = true;
	else if (!strnicmp(argv[0],"exp",3)) showexp = true;
	else if (!strnicmp(argv[0],"loc",3)) showloc = true;
	else if (!strnicmp(argv[0],"dmg",3)) showdmg = true;
	else if (!strnicmp(argv[0],"size",4)) showsize = true;
	else if (!strnicmp(argv[0],"name",4)) showname = true;
	else if (!strnicmp(argv[0],"faction",7)) showfaction = true;
	else if (!strnicmp(argv[0],"type",4)) showtype = true;
	else if (!strnicmp(argv[0],"model",5)) showmodel = true;
	else
	{
	pClient->Echo("Syntax: !showstats <arg>");
	pClient->Echo("Syntax: Valid values for <arg> are: all, hps, level, exp, loc, dmg, size, name, faction, type, model");
	return;
	}

	CPlayer *pPlayer;
	CCreature *pCreature;
	if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, pClient->pPlayer->TargetID))
	{
	if (showname) pClient->Echo("Name: %s",pPlayer->Data.Name);
	if (showmodel) pClient->Echo("Model: %d",pPlayer->Data.Model);
	if (showloc)
	pClient->Echo("Location: %d %f,%f,%f %f",pPlayer->Data.Continent,
	pPlayer->Data.Loc.X,pPlayer->Data.Loc.Y,pPlayer->Data.Loc.Z,pPlayer->Data.Facing);
	if (showlevel) pClient->Echo("Level: %d",pPlayer->Data.Level);
	if (showexp) pClient->Echo("Exp: %d",pPlayer->Data.Exp);
	if (showhps) pClient->Echo("HP: %d",pPlayer->Data.NormalStats.HitPoints);
	if (showdmg) pClient->Echo("DMG: %d to %d",pPlayer->Data.DamageMin,pPlayer->Data.DamageMax);
	if (showsize) pClient->Echo("Size: %f",pPlayer->Data.Size);
	}
	else if(DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, pClient->pPlayer->TargetID))
	{
	if (showname) pClient->Echo("Name: %s",pCreature->pTemplate->Data.Name);
	if (showtype) pClient->Echo("Type: %d",pCreature->Data.NPCType);
	if (showmodel) pClient->Echo("Model: 0x%X",pCreature->Data.Model);
	if (showloc)
	pClient->Echo("Location: %d %f,%f,%f %f",pCreature->Data.Continent,
	pCreature->Data.Loc.X,pCreature->Data.Loc.Y,pCreature->Data.Loc.Z,pCreature->Data.Facing);
	if (showlevel) pClient->Echo("Level: %d",pCreature->Data.Level);
	if (showexp) pClient->Echo("Exp: %d",pCreature->Data.Exp);
	if (showhps) pClient->Echo("HP: %d",pCreature->Data.NormalStats.HitPoints);
	if (showdmg) pClient->Echo("DMG: %d to %d",pCreature->Data.DamageMin,pCreature->Data.DamageMax);
	if (showsize) pClient->Echo("Size: %f",pCreature->Data.Size);
	if (showfaction) pClient->Echo("Faction: %d",pCreature->Data.FactionTemplate);
	}
	else
	{
	pClient->Echo("You must select a Creature or Player to get info.");
	return;
	}*/
}

void CmdDeleteSpawn(CClient *pClient)
{
	if(pClient->pPlayer->TargetID == 0)
	{
		pClient->Echo("You must select a creature to delete.");
		return;
	}
	CCreature *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature, pClient->pPlayer->TargetID))
	{
		pClient->Echo("You must select a creature to delete.");
		return;
	}
	// Find spawn id and mark it as one to be deleted
	RealmServer.Spawns[pCreature->Data.SpawnID].TemplateID = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].Continent = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].Facing = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].FirstPoint = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].Loc.X = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].Loc.Y = 0;
	RealmServer.Spawns[pCreature->Data.SpawnID].Loc.Z = 0;

	// Delete creature
	pCreature->Delete();
	pClient->Echo("Spawn deleted. Use !worldsave or worldsave (console).");
}

void CmdWorldSave(CClient *pClient, char *input)
{
	pClient->Echo("Worldsave initiated.");
	WorldSave();
	return;
}
void CmdLevel(CClient *pClient, char** argv, int argc) {
	if(argc != 1)
	{
		pClient->Echo("Syntax: !level <level>");
		return;
	}
	unsigned long level=0;
	if(sscanf(argv[0], "0x%X", &level) == 0 && sscanf(argv[0], "%u", &level) == 0)
	{
		pClient->Echo("Invalid level value. Prefix hex values with 0x.");
		return;
	}
	if(!level)
	{
		pClient->Echo("Error: Level must not be 0.");
		return;
	}
	if(pClient->pPlayer->TargetID == 0)
	{
		pClient->Echo("You must select a creature to save.");
		return;
	}
	CCreature *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature, pClient->pPlayer->TargetID))
	{
		pClient->Echo("You must select a creature to save.");
		return;
	}
	CCreatureTemplate *pTemplate;
	if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,pCreature->Data.Template))
	{
		pClient->Echo("Couldnt find creature template");
		return;
	}

	pCreature->DataObject.SetHP(level*65);
	pCreature->DataObject.SetMaxHP(level*65);
	//	pCreature->Data.DamageMin=level*1;
	//	pCreature->Data.DamageMax=level*3;
	//	pCreature->Data.Exp=level*200;
	//	pCreature->DataObject.SetLevel(level);
	pCreature->UpdateObject();
	pClient->Echo("Creature now level %d",level);
}

void CmdDisableRegion(CClient *pClient, char** argv, int argc)
{
	CRegion *pRegion = RegionManager.ObjectRegions[pClient->pPlayer->guid];
	if (!pRegion)
	{
		pClient->Echo("Unknown Region");
		return;
	}
	pRegion->isDisabled = true;
	pClient->Echo("This Region is now disabled - no fighting will be allowed");
}

void CmdEnableRegion(CClient *pClient)
{
	CRegion *pRegion = RegionManager.ObjectRegions[pClient->pPlayer->guid];
	if (!pRegion)
	{
		pClient->Echo("Unknown Region");
		return;
	}
	pRegion->isDisabled = false;
	pClient->Echo("This Region is now enabled - fighting may commence");
}

void CmdHover(CClient *pClient, char *input)
{
	CPacket pkg;
	if(strncmp(input, "stop", 4) == 0)
	{
		pClient->Echo("Admin hover disabled.");
		pkg.Reset(SMSG_MOVE_UNSET_HOVER);
	}
	else
	{
		pClient->Echo("Admin hover enabled.  Use '!hover stop' to disable.");
		pkg.Reset(SMSG_MOVE_SET_HOVER);
	}
	pkg << pClient->pPlayer->guid << 0;
	pClient->Send(&pkg);
}

void CmdFeatherFall(CClient *pClient, char *input)
{
	CPacket pkg;
	if(strncmp(input, "stop", 4) == 0)
	{
		pClient->Echo("Admin feather fall disabled.");
		pkg.Reset(SMSG_MOVE_NORMAL_FALL);
	}
	else
	{
		pClient->Echo("Admin feather fall enabled.  Use '!featherfall stop' to disable.");
		pkg.Reset(SMSG_MOVE_FEATHER_FALL);
	}
	pkg << pClient->pPlayer->guid << 0;
	pClient->Send(&pkg);
}

void CmdWaterWalk(CClient *pClient, char *input)
{
	CPacket pkg;
	if(strncmp(input, "stop", 4) == 0)
	{
		pClient->Echo("Admin water walk disabled.");
		pkg.Reset(SMSG_MOVE_LAND_WALK);
	}
	else
	{
		pClient->Echo("Admin watter walk enabled. Use '!waterwalk stop' to disable.");
		pkg.Reset(SMSG_MOVE_WATER_WALK);
	}
	//pkg << (unsigned char)0xFF << pClient->pPlayer->guid << 0;
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	pClient->Send(&pkg);
}

void MsgTrainerBuySpell(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
void CmdTest(CClient *pClient, char** argv, int argc) {
	if (argc != 1) {
		pClient->Echo("Syntax: !test <0xFlags>");
		return;
	}
	unsigned long value1;
	sscanf(argv[0], "0x%X", &value1);
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_FLAGS,value1);
	pClient->pPlayer->UpdateObject();
	/*
	CPacket pkg;
	pkg.Reset(SMSG_AI_REACTION);
	pkg << pClient->pPlayer->guid << 0;  // target
	pkg << (long)0x02;
	pClient->Send(&pkg);
	*/
	/*
	CPacket pkg;
	pkg.Reset(SMSG_SET_PROFICIENCY);
	unsigned long value1;
	sscanf(argv[0], "0x%X", &value1);
	unsigned long value2;
	sscanf(argv[1], "0x%X", &value2);
	pkg << (short)value1;
	pkg << (short)value2;
	pkg << (char) 0x00;
	pClient->Send(&pkg);
	*/
	/*
	CPacket pkg;
	pkg.Reset(SMSG_PERIODICAURALOG);
	pkg << pClient->pPlayer->guid << 0;
	pkg << pClient->pPlayer->guid << 0;
	pkg << (long)0x85;  // id of auro
	pkg << (long)0x01;
	pkg << (long)0x03;
	pkg << (long)0x01;  // number above head
	pkg << (long)0x02;
	pkg << (long)0x00;
	pClient->Send(&pkg);
	*/
	pClient->Echo("Testing");
}

void CmdWander(CClient * pClient) {
	if(pClient->pPlayer->TargetID==0)
	{
		pClient->Echo("You must select a creature...");
		return;
	}
	CCreature *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature, pClient->pPlayer->TargetID))
	{
		pClient->Echo("You must select a creature...");
		return;
	}
	CCreatureTemplate *pTemplate;
	if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,pCreature->Data.Template))
	{
		pClient->Echo("Couldnt find creature template");
		return;
	}

	pCreature->Wander();
}

void CmdKillme(CClient * pClient)
{
	pClient->pPlayer->DataObject.SetHP(0);
	pClient->pPlayer->dead = true;
	pClient->UpdateObject();
}

void CmdSkill(CClient * pClient, char** argv, int argc)
{
	unsigned long skillid,curlvl,maxlvl;
	if(argc==0){
		pClient->Echo("Syntax: !skill <skillid> [curprof] [maxprof]");
		return;
	}
	if(argc==1){
		skillid=atoi(argv[0]);
		curlvl=1;
		maxlvl=1;
	}
	else if(argc==2) {
		skillid=atoi(argv[0]);
		curlvl=atoi(argv[1]);
		maxlvl=curlvl;
	}
	else if(argc>=3) {
		skillid=atoi(argv[0]);
		curlvl=atoi(argv[1]);
		maxlvl=atoi(argv[2]);
	}
	pClient->pPlayer->AddSkill(skillid,(short)curlvl,(short)maxlvl,true);
}

void CmdObject(CClient * pClient, char** argv, int argc)
{
	if(argc==1)
	{
		unsigned long templateid=atoi(argv[0]);
		CGameObject *pObject = new CGameObject;
		pObject->New(templateid | (OBJ_GAMEOBJECTTEMPLATE << 24));
		pObject->Data.Facing	= pClient->pPlayer->Data.Facing;
		pObject->Data.Loc		= pClient->pPlayer->Data.Loc;
		pObject->Data.Continent	= pClient->pPlayer->Data.Continent;
		// pObject->Data.Owner		= pClient->pPlayer->guid;
		RegionManager.ObjectNew(*pObject,pObject->Data.Continent,pObject->Data.Loc.X,pObject->Data.Loc.Y);
		DataManager.NewObject(*pObject);
		return;
	}
	if(argc!=3)
	{
		pClient->Echo("Syntax: !object <Model ID> <Flags> <Type>\nor !object <Object ID>");
		return;
	}
	unsigned long modelid, flags, type;
	modelid=atoi(argv[0]);
	flags=atoi(argv[1]);
	type=atoi(argv[2]);
	CGameObject *pObject = new CGameObject;
	pObject->New(pClient->pPlayer,modelid,flags,type);
	pClient->Echo("Model: %d, Flags: %d, Type: %d", modelid, flags, type);
	DataManager.NewObject(*pObject);
}

void CmdEnableAllQuests(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pPlayer->EnableAllQuests = true;
	pClient->Echo("All quests have been enabled for you! Go talk to a questgiver to check it out.");
	return;
}

void MakeMount(CClient *pClient)
{
	CItemTemplate *pItemTemplate;
	pItemTemplate = new CItemTemplate;
	pItemTemplate->New();
	pItemTemplate->Data.DisplayID = 25132;
	pItemTemplate->Data.Class = 15;
	pItemTemplate->Data.Flags = 64;
	pItemTemplate->Data.BuyPrice = 125000;
	pItemTemplate->Data.SellPrice = 10000000;
	pItemTemplate->Data.InventoryType = 0;
	pItemTemplate->Data.AllowableClass = 32767;
	pItemTemplate->Data.AllowableRace = 77;
	pItemTemplate->Data.ItemLevel = 60;
	pItemTemplate->Data.RequiredLevel = 60;
	pItemTemplate->Data.RequiredSkill = 148;
	pItemTemplate->Data.RequiredSkillRank = 1;
	pItemTemplate->Data.RequiredSpell = 0;
	pItemTemplate->Data.RequiredFaction = 0;
	pItemTemplate->Data.RequiredFactionLvL = 0;
	pItemTemplate->Data.RequiredPVPRank = 0;
	pItemTemplate->Data.MaxStack = 1;
	pItemTemplate->Data.ContainerSlots = 0;
	DataManager.NewObject(*pItemTemplate);
}

void CmdCommands(CClient *pClient);
void CmdHelpWad(CClient *pClient, char *input)
{
	pClient->Echo("Used to WadEmu? Commands here start with '!' instead. Good luck and have fun.");
}

MsgHandler Handlers[] =
{

	{"!distance", USER_NORMAL, (void*)CmdDist, FUNCTYPE_ARGS},
	{"!bind", USER_NORMAL, (void*)CmdBind, FUNCTYPE_NONE},
	{"!resetdlg", USER_NORMAL, (void*)CmdDuel, FUNCTYPE_NONE},
	{"!sendpkt", USER_NORMAL, (void*)CmdPkt, FUNCTYPE_ARGS},
	// {"!report", USER_NORMAL, (void*)CmdReport, FUNCTYPE_STRING},
	// {"!clients", USER_NORMAL, (void*)CmdClients, FUNCTYPE_STRING},
	//{"!tabard", USER_NORMAL, (void*)CmdTabard, FUNCTYPE_NONE},
	{"!vote", USER_NORMAL, (void*)CmdVote, FUNCTYPE_STRING},
	{"!help", USER_NORMAL, (void*)CmdCommands, FUNCTYPE_STRING},
	// {".help",USER_NORMAL, (void*)CmdHelpWad, FUNCTYPE_STRING}, //help for braindead wowemu users xD
	{"!commands", USER_NORMAL, (void*)CmdCommands, FUNCTYPE_NONE}, //alias
	{"!admin", USER_NORMAL, (void*)CmdAdmin, FUNCTYPE_STRING},
	{"!gm", USER_NORMAL, (void*)CmdMakeGM, FUNCTYPE_STRING},
	// {"!demoteall", USER_NORMAL, (void*)CmdDemoteAll, FUNCTYPE_NONE}, //should now work
	//{"!saveme", USER_NORMAL, (void*)CmdSaveMe, FUNCTYPE_STRING},
	{"!createguild", USER_MODERATOR, (void*)CmdCreateGuild, FUNCTYPE_STRING},
	//{"!getmount", USER_NORMAL, (void*)CmdGetMount, FUNCTYPE_STRING},
	// {"!find", USER_NORMAL, (void*)CmdFind, FUNCTYPE_NONE},
	{"!learn", USER_MODERATOR, (void*)CmdSpell, FUNCTYPE_STRING},
	{"!worldport", USER_MODERATOR, (void*)CmdWorldport, FUNCTYPE_ARGS},
	//{"!mount", USER_MODERATOR, (void*)CmdMount, FUNCTYPE_STRING},
	//{"!unmount", USER_NORMAL, (void*)CmdUnmount, FUNCTYPE_STRING}, //alias
	{"!dismount", USER_NORMAL, (void*)CmdUnmount, FUNCTYPE_STRING},
	//{"!morph", USER_MODERATOR, (void*)CmdMorph, FUNCTYPE_ARGS},
#ifndef ACCOUNTLESS
	//{"!userlevel", USER_MODERATOR, (void*)CmdUserLevel, FUNCTYPE_ARGS},
#endif
	//{"!cape", USER_MODERATOR, (void*)CmdCape, FUNCTYPE_ARGS},
	//{"!cloak", USER_MODERATOR, (void*)CmdCape, FUNCTYPE_ARGS}, //alias
	//{"!showstats", USER_MODERATOR, (void*)CmdShowStats, FUNCTYPE_ARGS},
	{"!goplayer", USER_MODERATOR, (void*)CmdGoto, FUNCTYPE_ARGS},
	//{"!disableregion", USER_MODERATOR, (void*)CmdDisableRegion, FUNCTYPE_NONE},
	//{"!enableregion", USER_MODERATOR, (void*)CmdEnableRegion, FUNCTYPE_NONE},
	//{"!getposition", USER_MODERATOR, (void*)CmdGetPosition, FUNCTYPE_ARGS},
	{"!spawn", USER_HALFGM, (void*)CmdSpawn, FUNCTYPE_STRING},
	{"!modify", USER_HALFGM, (void*)CmdEdit, FUNCTYPE_ARGS},
	{"!edit", USER_HALFGM, (void*)CmdEdit, FUNCTYPE_ARGS},
	//{"!level", USER_HALFGM, (void*)CmdLevel, FUNCTYPE_ARGS},
	//{"!uber", USER_HALFGM, (void*)CmdUber, FUNCTYPE_STRING},
	{"!kill", USER_HALFGM, (void*)CmdKillSpawn, FUNCTYPE_STRING},
	// {"!deathtouch", USER_GM, (void*)CmdDeathtouch, FUNCTYPE_ARGS},
	// {"!maxsent", USER_GM, (void*)CmdMaxsent, FUNCTYPE_STRING},
	{"!broadcast", USER_GM, (void*)CmdBroadcast, FUNCTYPE_STRING},
	//{"!resetplayer", USER_GM, (void*)CmdResetPlayer, FUNCTYPE_ARGS},
	{"!kickplayer", USER_GM, (void*)CmdKickPlayer, FUNCTYPE_ARGS},
	{"!strip", USER_GM, (void*)CmdStrip, FUNCTYPE_ARGS},
	//{"!morphtarget", USER_GM, (void*)CmdMorphTarget, FUNCTYPE_ARGS},
	//{"!mountmodel", USER_GM, (void*)CmdMountModel, FUNCTYPE_ARGS},
	{"!summon", USER_GM, (void*)CmdSummon, FUNCTYPE_ARGS},
	//FYI: Summon is to force "naughty" players to come to you and get a spanking ;) They should be kept frozen during this.
	{"!release", USER_GM, (void*)CmdRelease, FUNCTYPE_ARGS},
	{"!return", USER_GM, (void*)CmdReturn, FUNCTYPE_ARGS},
	{"!callvote", USER_GM, (void*)CmdCallVote, FUNCTYPE_STRING},
	{"!tally", USER_GM, (void*)CmdTally, FUNCTYPE_STRING},
	{"!deletespawn", USER_GM, (void*)CmdDeleteSpawn, FUNCTYPE_NONE},
	{"!give", USER_GM, (void*)CmdGive, FUNCTYPE_ARGS},
	//{"!get", USER_GM, (void*)CmdGet, FUNCTYPE_ARGS},
	{"!gorace", USER_GM, (void*)CmdGoRace, FUNCTYPE_STRING},
	{"!sendto", USER_GM, (void*)CmdSendTo, FUNCTYPE_ARGS},
	{"!setval", USER_ADMIN, (void*)CmdSetVal, FUNCTYPE_ARGS},
	//{"!rehash", USER_ADMIN, (void*)CmdRehash, FUNCTYPE_STRING},
	//{"!hover", USER_ADMIN, (void*)CmdHover, FUNCTYPE_STRING},
	{"!featherfall", USER_ADMIN, (void*)CmdFeatherFall, FUNCTYPE_STRING},
	{"!waterwalk", USER_ADMIN, (void*)CmdWaterWalk, FUNCTYPE_STRING},
	//{"!test", USER_ADMIN, (void*)CmdTest, FUNCTYPE_ARGS},
	//{"!wander", USER_GM, (void*)CmdWander, FUNCTYPE_NONE},
	{"!killme", USER_ADMIN, (void*)CmdKillme, FUNCTYPE_NONE},
	//{"!learnspells", USER_ADMIN, (void*)CSpellHandler::CmdLearnSpells, FUNCTYPE_NONE},
	{"!skill", USER_ADMIN, (void*)CmdSkill, FUNCTYPE_ARGS},
	{"!object",USER_ADMIN, (void*)CmdObject, FUNCTYPE_ARGS},
	{"!allquests", USER_ADMIN, (void*)CmdEnableAllQuests, FUNCTYPE_NONE},
	//{"!deathdurabilityloss", USER_ADMIN, (void*)CmdDeathDurabilityLoss, FUNCTYPE_NONE},
	{"!aura", USER_ADMIN, (void*)CmdAura, FUNCTYPE_ARGS},
	{"!makewaypoint", USER_ADMIN, (void*)CmdMakeWaypoint, FUNCTYPE_ARGS},
	{"!addscriptcommand", USER_ADMIN, (void*)CmdAddScriptCommand, FUNCTYPE_STRING},
	{"!bagtest",USER_ADMIN,(void*)CmdTestBag,FUNCTYPE_STRING},
	{"!worldsave",USER_HALFGM,(void*)CmdWorldSave,FUNCTYPE_STRING},
	{NULL, 0, 0},
};

void CmdCommands(CClient *pClient)
{
	string output = "Available commands: (|c1f40af20Normal|r, GM|r, |cffff6060Admin|r)\n\n";
	int count = 0;
	for(int i = 0;Handlers[i].cmd != NULL;i++)
	{
		if(Handlers[i].Userlevel > pClient->pAccount->Data.UserLevel)
			continue;
		// hide the admin commands
		if(!strcmp(Handlers[i].cmd,"!admin")) continue;
		if(!strcmp(Handlers[i].cmd,"!gm")) continue;
		switch(Handlers[i].Userlevel)
		{
		case USER_ADMIN:
			{
				output+="|cffff6060";
				output+=Handlers[i].cmd;
				output+="|r, ";
			}
			break;
		case USER_GM:
		case USER_HALFGM:
		case USER_MODERATOR:
			{
				output+="|r";
				output+=Handlers[i].cmd;
				output+=", ";
			}
			break;
		case USER_NORMAL:
			{
				output+="|c1f40af20";
				output+=Handlers[i].cmd;
				output+="|r, ";
			}
			break;
		}

		//output += Handlers[i].cmd;
		//output += ", ";
		count++;
		if(count == 10)
		{
			pClient->Echo(output.c_str());
			output = "";
			count = 0;
		}
	}
	if(count)
		pClient->Echo(output.c_str());
}

void CChatManager::MsgChat(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	switch(Data.Buffer()[0])
	{
	case CHAT_SAY:
		if(!ProcessCommand(pClient, &Data.Buffer()[8]))
			pClient->ChatSay(*(unsigned long*)&Data.Buffer()[4],&Data.Buffer()[8]);
		break;
	case CHAT_PARTY:
		{
			CParty *pParty = CParty::GetParty(pClient, true);
			if(pParty != NULL)
				pParty->PartyChannel(pClient, &Data.Buffer()[0x08]);
		}
		break;
	case CHAT_GUILD:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->GuildChannel(pClient, &Data.Buffer()[0x08]);
		}
		break;
	case CHAT_OFFICER:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->OfficerChannel(pClient, &Data.Buffer()[0x08]);
		}
		break;
	case CHAT_YELL:
		pClient->ChatYell(*(unsigned long*)&Data.Buffer()[4],&Data.Buffer()[8]);
		break;
	case CHAT_CHANNEL:
		{
			std::string channel = "", msg = "";
			unsigned long type,lang;
			Data >> type >> lang;
			Data >> channel;
			Data >> msg;
			CChannel *chn = CChannel::AllChannels[channel];
			if(chn && pClient->pPlayer) chn->Say(pClient->pPlayer,msg.c_str());
		} break;
	case CHAT_WHISPER:
		{
			unsigned long Language=*(unsigned long*)&Data.Buffer()[4];
			string Who=&Data.Buffer()[8];
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",&Data.Buffer()[8]);
				return;
			}
			CPlayer *pTo=0;
			if (!DataManager.RetrieveObject((CWoWObject**)&pTo,OBJ_PLAYER,PlayerID))
			{
				pClient->Echo("Player '%s' does not exist (error: exists in name cache but not in database).",&Data.Buffer()[8]);
				return;
			}
			if (!pTo->pClient)
			{
				pClient->Echo("Player '%s' not online",&Data.Buffer()[8]);
				return;
			}
			int count=0;
			while(pTo->Data.Ignore[count])
			{
				if(pTo->Data.Ignore[count]==(unsigned long)pClient->pPlayer->guid)
				{
					pClient->ChannelMessage(CHAT_IGNORED,"",pClient->pPlayer->guid,0,0);
					return;
				}
				count++;
			}
			pTo->pClient->ChannelMessage(CHAT_WHISPER,&Data.Buffer()[8+strlen(&Data.Buffer()[8])+1],pClient->pPlayer->guid,0,Language);
			pClient->ChannelMessage(CHAT_WHISPER_INFORM,&Data.Buffer()[8+strlen(&Data.Buffer()[8])+1],pTo->guid,0,Language);
			if (pTo->Data.StatusFlags & STATUS_AFK) pClient->ChannelMessage(CHAT_AFK,pTo->Data.StatusReason,pClient->pPlayer->guid,0,0);
			if (pTo->Data.StatusFlags & STATUS_DND) pClient->ChannelMessage(CHAT_DND,pTo->Data.StatusReason,pClient->pPlayer->guid,0,0);
		}
		break;
	case CHAT_EMOTE:
		{
			unsigned long Language=*(unsigned long*)&Data.Buffer()[4];
			pClient->ChannelMessage(CHAT_EMOTE,&Data.Buffer()[8],pClient->pPlayer->guid,0,Language);
		}
		break;
	case CHAT_SYSTEM:
		break;
	case CHAT_AFK:
		{
			char *msg=&Data.Buffer()[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}

			if (pClient->pPlayer->Data.StatusFlags & STATUS_AFK)
			{
				//if the reason is present and different, then client is only trying to change existing reason.
				if(msg[0] && !strcmp(pClient->pPlayer->Data.StatusReason,msg))
					strcpy(pClient->pPlayer->Data.StatusReason, msg);
				else
				{
					pClient->pDataObject->ClearFlag(STATUS_AFK);
					strcpy(pClient->pPlayer->Data.StatusReason, "");
				}
			}
			else
			{
				pClient->pDataObject->SetFlag(STATUS_AFK);
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			pClient->UpdateObject();
		}
		break;
	case CHAT_DND:
		{
			char *msg=&Data.Buffer()[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}
			if (pClient->pPlayer->Data.StatusFlags & STATUS_DND)
			{
				//if the reason is present and different, then client is only trying to change existing reason.
				if(msg[0] && !strcmp(pClient->pPlayer->Data.StatusReason,msg))
					strcpy(pClient->pPlayer->Data.StatusReason, msg);
				else
				{
					pClient->pDataObject->ClearFlag(STATUS_DND);
					strcpy(pClient->pPlayer->Data.StatusReason, "");
				}
			}
			else
			{
				pClient->pDataObject->SetFlag(STATUS_DND);
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			pClient->UpdateObject();
		}
		break;
	default:
		pClient->Echo("This type of chat or emote is not yet implemented.");
		break;
	}
}


int getargs(char *str, char** argv, int maxargs)
{
	int argc = 0;
	char *ptr = str;
	bool inquote = false;
	if (ptr == 0)
		return 0;
	while(str[0] != 0 && argc < maxargs)
	{
		if(str[0] == '"')
		{
			if(inquote)
			{
				str[0] = 0;
				argv[argc] = ptr;
				argc++;
				inquote = false;
			}
			else
				inquote = true;
			ptr = &str[1];
		}
		else if(!inquote && str[0] == ' ')
		{
			str[0] = 0;
			if(ptr[0] != 0)
			{
				argv[argc] = ptr;
				argc++;
			}
			ptr = &str[1];
		}
		str++;
	}
	if(strlen(ptr))
	{
		argv[argc] = ptr;
		argc++;
	}
	return argc;
}

extern void ProcessGMCommand(CClient *pClient, const char *command);
bool ProcessCommand(CClient *pClient, const char *command)
{
	if (command == NULL)
		return false;
	char buffer[0x100];
	strncpy(buffer, command, 0xFF);
	buffer[0xFF] = 0;
	char *cmd = strtok(buffer, " ");
	char *input;
	int argc = 0;
	char *argv[20];
	if(cmd == NULL)
	{
		cmd = buffer;
		input = "";
	}
	else
		input = &buffer[strlen(cmd)+1];
	int i;
	for(i = 0;Handlers[i].cmd != NULL;i++)
	{
		if(stricmp(Handlers[i].cmd, cmd) == 0)
		{
			if(pClient->pAccount->Data.UserLevel < Handlers[i].Userlevel)
			{
				pClient->Echo("You don't have access to this command.");
				return true;
			}
			FILE *file;
			file = fopen("data/chatcmd.log","a+");
			if (file)
			{
				struct tm *now;
				time_t cur=time(0);
				char tmpbuf[80];
				now = localtime(&cur);
				strftime( tmpbuf, 70, "%Y/%m/%d %H:%M:%S", now );
				fprintf(file,"[%s] at %s : %s\n",pClient->pPlayer->Data.Name,tmpbuf,command);
				fclose(file);
			}
			if(Handlers[i].funcType == FUNCTYPE_NONE)
			{
				((MsgFuncNone)Handlers[i].func)(pClient);
			}
			if(Handlers[i].funcType == FUNCTYPE_STRING)
			{
				((MsgFuncString)Handlers[i].func)(pClient, input);
			}
			else if(Handlers[i].funcType == FUNCTYPE_ARGS)
			{
				argc = getargs(input, argv, 20);
				((MsgFuncArgs)Handlers[i].func)(pClient, argv, argc);
			}
			return true;
		}
	}
	return false;
}

void CChannel::Join(CPlayer *p, const char *pass)
{
	CPacket data;
	if(IsOn(p))
	{
		MakeAlreadyOn(&data,p);
		SendToOne(&data,p);
	}
	else if(IsBanned(p->guid))
	{
		MakeYouAreBanned(&data);
		SendToOne(&data,p);
	}
	else if(password.length() > 0 && strcmp(pass,password.c_str()))
	{
		MakeWrongPass(&data);
		SendToOne(&data,p);
	}
	else
	{
		PlayerInfo pinfo;
		pinfo.player = p;
		pinfo.muted = false;
		pinfo.owner = false;
		pinfo.moderator = false;

		MakeJoined(&data,p);
		p->JoinedChannel(this);
		if(announce)
			SendToAll(&data);

		data.Clear();
		players[p] = pinfo;

		MakeYouJoined(&data);
		SendToOne(&data,p);

		if(!constant && owner == NULL)
		{
			SetOwner(p);
			players[p].moderator = true;
		}
	}
}

void CChannel::Leave(CPlayer *p, bool send)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		if(send) SendToOne(&data,p);
	}
	else
	{
		bool changeowner = (owner == p);

		MakeYouLeft(&data);
		if(send)
		{
			SendToOne(&data,p);
			p->LeftChannel(this);
		}
		data.Clear();

		players.erase(p);
		MakeLeft(&data,p);
		if(announce)
			SendToAll(&data);

		if(changeowner)
		{
			CPlayer *newowner = players.size() > 0 ? players.begin()->second.player : NULL;
			SetOwner(newowner);
		}
	}
}

void CChannel::KickOrBan(CPlayer *good, const char *badname, bool ban)
{
	CPacket data;
	if(!IsOn(good))
	{
		MakeNotOn(&data);
		SendToOne(&data,good);
	}
	else if(!players[good].moderator && good->pClient && good->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,good);
	}
	else
	{
		CPlayer *bad = NULL;
		unsigned long badguid;
		badguid = DataManager.PlayerNames[badname];
		if(!badguid)
		{
			MakeNotOn(&data,badname);
			SendToOne(&data,good);
		}
		bool result=DataManager.RetrieveObject((CWoWObject **)&bad,OBJ_PLAYER,badguid);
		if(!result || !IsOn(bad))
		{
			MakeNotOn(&data,badname);
			SendToOne(&data,good);
		}
		else if(good->pClient && good->pClient->pAccount->Data.UserLevel < USER_GM && bad == owner && good != owner)
		{
			MakeNotOwner(&data);
			SendToOne(&data,good);
		}
		else
		{
			bool changeowner = (owner == bad);

			if(ban && !IsBanned(bad->guid))
			{
				banned.push_back(bad->guid);
				MakeBanned(&data,good,bad);
			}
			else
				MakeKicked(&data,good,bad);

			SendToAll(&data);
			players.erase(bad);

			if(changeowner)
			{
				CPlayer *newowner = players.size() > 0 ? good : NULL;
				SetOwner(newowner);
			}
		}
	}
}
void CChannel::UnBan(CPlayer *good, const char *badname)
{
	CPacket data;
	if(!IsOn(good))
	{
		MakeNotOn(&data);
		SendToOne(&data,good);
	}
	else if(!players[good].moderator && good->pClient && good->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,good);
	}
	else
	{
		CPlayer *bad = NULL;
		unsigned long badguid;
		badguid = DataManager.PlayerNames[badname];
		if(!badguid)
		{
			MakeNotOn(&data,badname);
			SendToOne(&data,good);
		}
		bool result=DataManager.RetrieveObject((CWoWObject **)&bad,OBJ_PLAYER,badguid);
		if(!result || !IsBanned(bad->guid))
		{
			MakeNotOn(&data,badname);
			SendToOne(&data,good);
		}
		else
		{
			banned.remove(bad->guid);
			MakeUnbanned(&data,good,bad);
			SendToAll(&data);
		}
	}
}
void CChannel::Password(CPlayer *p, const char *pass)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(!players[p].moderator && p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,p);
	}
	else
	{
		password = pass;
		MakeSetPassword(&data,p);
		SendToAll(&data);
	}
}
void CChannel::SetMode(CPlayer *p, const char *p2n, bool mod, bool set)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(!players[p].moderator && p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,p);
	}
	else
	{
		CPlayer *newp = NULL;
		unsigned long myguid = DataManager.PlayerNames[p2n];
		if(!myguid)
		{
			MakeNotOn(&data,p2n);
			SendToOne(&data,p);
		}
		bool result=DataManager.RetrieveObject((CWoWObject **)&newp,OBJ_PLAYER,myguid);
		if(!result || !IsOn(newp))
		{
			MakeNotOn(&data,p2n);
			SendToOne(&data,p);
		}
		PlayerInfo inf = players[newp];
		if(p == owner && newp == owner && mod)
			return;
		if(owner == newp && owner != p)
		{
			MakeNotOwner(&data);
			SendToOne(&data,p);
		}
		else
		{
			if(mod)
				SetModerator(newp,set);
			else
				SetMute(newp,set);
		}
	}
}
void CChannel::SetOwner(CPlayer *p, const char *newname)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM && p != owner)
	{
		MakeNotOwner(&data);
		SendToOne(&data,p);
	}
	else
	{
		CPlayer *newp = NULL;
		unsigned long myguid = DataManager.PlayerNames[newname];
		if(!myguid)
		{
			MakeNotOn(&data,newname);
			SendToOne(&data,p);
			return;
		}
		bool result=DataManager.RetrieveObject((CWoWObject **)&newp,OBJ_PLAYER,myguid);
		if(!result || !IsOn(newp))
		{
			MakeNotOn(&data,newname);
			SendToOne(&data,p);
		}
		else
		{
			MakeChangeOwner(&data,newp);
			SendToAll(&data);

			SetModerator(newp,true);
			owner = newp;
		}
	}
}
void CChannel::GetOwner(CPlayer *p)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else
	{
		MakeWhoOwner(&data);
		SendToOne(&data,p);
	}
}
void CChannel::List(CPlayer *p)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else
	{
		data.Reset(SMSG_CHANNEL_LIST);
		data << (unsigned char)3 << (unsigned long)players.size();

		PlayerList::iterator i;
		for(i = players.begin(); i!=players.end(); i++)
		{
			data << i->first->guid;
			unsigned char mode = 0x00;
			if(i->second.muted)
				mode |= 0x04;
			if(i->second.moderator)
				mode |= 0x02;
			data << mode;
		}
		SendToOne(&data,p);
	}
}
void CChannel::Announce(CPlayer *p)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(!players[p].moderator && p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,p);
	}
	else
	{
		announce = !announce;
		MakeAnnounce(&data,p,announce);
		SendToAll(&data);
	}
}
void CChannel::Moderate(CPlayer *p)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(!players[p].moderator && p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,p);
	}
	else
	{
		moderate = !moderate;
		MakeModerate(&data,p,moderate);
		SendToAll(&data);
	}
}
void CChannel::Say(CPlayer *p, const char *what)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else if(players[p].muted)
	{
		MakeYouCantSpeak(&data);
		SendToOne(&data,p);
	}
	else if(moderate && !players[p].moderator && p->pClient && p->pClient->pAccount->Data.UserLevel < USER_GM)
	{
		MakeNotModerator(&data);
		SendToOne(&data,p);
	}
	else
	{
		//Packet structure
		//unsigned char      type;
		//unsigned long     language;
		//unsigned long     PVP rank
		//uint64     guid;
		//unsigned long      len_of_text;
		//char       text[];
		//unsigned char      afk_state;

		unsigned long messageLength = strlen((char*)what) + 1;

		data.Reset(SMSG_MESSAGECHAT);
		data << (unsigned char)14; // CHAT_MESSAGE_CHANNEL
		data << (unsigned long)0; // Universal lang
		data << name.c_str();
		data << (unsigned long)0; // pvp ranks
		data << p->guid << PLAYERGUID_HIGH;
		data << messageLength;
		data << what;
		data << (unsigned char)((p->Data.StatusFlags & STATUS_AFK)?1:0);

		SendToAll(&data);
		// Send the actual talking stuff.
	}
}

void CChannel::Invite(CPlayer *p, const char *newname)
{
	CPacket data;
	if(!IsOn(p))
	{
		MakeNotOn(&data);
		SendToOne(&data,p);
	}
	else
	{
		CPlayer *newp = NULL;
		unsigned long myguid = DataManager.PlayerNames[newname];
		if(!myguid)
		{
			MakeNotOn(&data,newname);
			SendToOne(&data,p);
		}
		bool result=DataManager.RetrieveObject((CWoWObject **)&newp,OBJ_PLAYER,myguid);
		if(!result || !IsOn(newp))
		{
			MakeNotOn(&data,newname);
			SendToOne(&data,p);
		}
		else if(IsOn(newp))
		{
			MakeAlreadyOn(&data,newp);
			SendToOne(&data,p);
		}
		else
		{
			MakeInvited(&data,p);
			SendToOne(&data,newp);
			data.Clear();
			MakeYouInvited(&data,newp);
			SendToOne(&data,p);
		}
	}
}
