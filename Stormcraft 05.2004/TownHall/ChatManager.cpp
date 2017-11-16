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

int getargs(char *str, char** argv, int maxargs);
bool ProcessCommand(CClient *pClient, const char *command);
CChatManager ChatManager;

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

#define ADDSUBTYPE(string, val) WeaponInvFilter[string] = 1 << val;
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
	UserLevels["gm"] = USER_GM;
	UserLevels["half-gm"] = USER_HALFGM;
	UserLevels["halfgm"] = USER_HALFGM;
	UserLevels["supermod"] = USER_SUPERMOD;
	UserLevels["moderator"] = USER_MODERATOR;
	UserLevels["mod"] = USER_MODERATOR;
	UserLevels["normal"] = USER_NORMAL;
	UserLevels["ban"] = USER_BANNED;
	UserLevels["suspend"] = USER_SUSPENDED;
	UserLevels["delete"] = USER_DELETE;


}

CChatManager::~CChatManager(void)
{
}

void CChatManager::InitCloaks()
{
	CItemTemplate *pTemplate;

#define ADDCLOAK(str, name, displayid) \
	pTemplate = new CItemTemplate; \
	pTemplate->New(); \
	pTemplate->CreateCloak(name, displayid); \
	DataManager.NewObject(*pTemplate);\
	ChatManager.Cloaks[str] = pTemplate->guid;\

	ADDCLOAK("aqua", "Aqua Colored Cape", 13983);
	ADDCLOAK("black", "Black Colored Cape", 15039);
	ADDCLOAK("blue", "Blue Colored Cape", 13984);
	ADDCLOAK("brown", "Brown Colored Cape", 15035);
	ADDCLOAK("burgundy", "Burgundy Colored Cape", 15162);
	ADDCLOAK("cyan", "Cyan Colored Cape", 14794);
	ADDCLOAK("green", "Green Colored Cape", 15159);
	ADDCLOAK("grey", "Grey Colored Cape", 15164);
	ADDCLOAK("olive", "Olive Colored Cape", 13985);
	ADDCLOAK("orange", "Orange Colored Cape", 15271);
	ADDCLOAK("purple", "Purple Colored Cape", 15041);
	ADDCLOAK("red", "Red Colored Cape", 13986);
	ADDCLOAK("white", "White Colored Cape", 15149);
	ADDCLOAK("violet", "Violet Colored Cape", 15145);
	ADDCLOAK("yellow", "Yellow Colored Cape", 15153);
#undef ADDCLOAK

}

void CmdSpell(CClient *pClient, char *input)
{
	unsigned long ID=0;
	if (sscanf(input,"%X",&ID) && ID)
	{
		pClient->Echo("Learning spell %08X",ID);
		pClient->LearnedSpell(ID);
	}
}

void CmdReport(CClient *pClient, char *input)
{
	if(input[0] == 0)
	{
		pClient->Echo("Syntax: report <msg>");
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
}

void CmdWorldport(CClient *pClient, char **argv, int argc)
{
	if(argc != 4)
	{
		pClient->Echo("Syntax: worldport <continent> <x> <y> <z>");
		return;
	}
	/*
	wtf is this?
	float cont=0;
	string x = argv[1];
	string y = argv[2];
	string z = argv[3];
	sscanf(argv[0],"%f", &cont);
	buf[0x00]=(char)cont;
	buf[0x04]=*x.c_str();
	buf[0x08]=*y.c_str();
	buf[0x0C]=*z.c_str();
	*/
	char buf[0x11];
	pClient->pPlayer->Data.Continent=buf[0x00]=(char)atoi(argv[0]);
	*(float*)&buf[0x01] = pClient->pPlayer->Data.Loc.X=(float)atof(argv[1]);
	*(float*)&buf[0x05] = pClient->pPlayer->Data.Loc.Y=(float)atof(argv[2]);
	*(float*)&buf[0x09] = pClient->pPlayer->Data.Loc.Z=(float)atof(argv[3]);
	*(float*)&buf[0x0D] = pClient->pPlayer->Data.Facing;
	pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
	RegionManager.ObjectRemove(*pClient->pPlayer);
}

void CmdClients(CClient *pClient, char *input)
{
	pClient->Echo("There are %d users connected, and this server has handled up to %d simultaneous users this session.",RealmServer.nClients,RealmServer.nMaxClients);
}

void CmdPvp(CClient *pClient, char *input)
{
	if (pClient->pPlayer->Data.RecentPvP) {
		pClient->Echo("PvP was %s recently.  You have to wait 30 seconds to change it's setting",pClient->pPlayer->Data.PvP ? "Enabled" : "Disabled");
	}
	else {
		pClient->pPlayer->Data.PvP = !pClient->pPlayer->Data.PvP;
		pClient->pPlayer->Data.RecentPvP = true;
		RegionManager.ObjectResend(*(pClient->pPlayer));
		pClient->Echo("PvP %s",pClient->pPlayer->Data.PvP ? "Enabled" : "Disabled");
		EventManager.AddEvent(*(pClient->pPlayer),30000,EVENT_PLAYER_PVP,0,0);
	}
}
void CmdMount(CClient *pClient, char *input)
{
	if(pClient->pPlayer->Data.MountModel)
	{
		pClient->Echo("Please 'dismount' first!");
		return;
	}

	if(input[0] == 0)
	{
		pClient->Echo("Valid mounts for this demonstration are nightmare, gryphon[2-4] (ie: gryphon, gryphon2, ..), \
							  hippogryph[2-5], horse <type> (evil[2-5], white[2], black[2], brown[2-3], palamino[2], \
							  pinto[2], chessnut[2-3]), ram <color> (white, black, grey, brown, blue), ");
		pClient->Echo("dire <color> (black[2-3], grey, darkgrey, brown, zebra[2-3], darkbrown, reddishbrown[2], blue[2-3])");
		return;
	}

	string lcase=input;
	MakeLower(lcase);
	map<string, unsigned long>::iterator mount = ChatManager.Mounts.find(lcase);
	if(mount == ChatManager.Mounts.end())
	{
		pClient->Echo("Unknown mount.");
		return;
	}
	pClient->pPlayer->Data.MountModel = (short)mount->second;
	pClient->pPlayer->Data.runspeed=DEFAULT_PLAYER_RUN_SPEED*2; // double
	pClient->UpdateRunSpeed(*pClient->pPlayer);
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_MOUNT_DISPLAYID, pClient->pPlayer->Data.MountModel);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	pClient->Echo("You mount the beast.  Type 'unmount' or 'dismount' to dismount.");
}

void CmdUnmount(CClient *pClient, char *input)
{
	if(pClient->pPlayer->Data.MountModel != 0)
	{
		pClient->pPlayer->Data.MountModel = 0;
		pClient->pPlayer->Data.runspeed=DEFAULT_PLAYER_RUN_SPEED; // standard
		pClient->UpdateRunSpeed(*pClient->pPlayer);
		CUpdateBlock block;
		char buffer[0x90];
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(UNIT_MOUNT_DISPLAYID, pClient->pPlayer->Data.MountModel);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		pClient->Echo("You unmount the beast");
	}
	else
		pClient->Echo("You unmount thin air. Making a fool of yourself.");
}

void CmdTabard(CClient *pClient, char *input)
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

		pClient->pPlayer->Data.Items[SLOT_TABARD]=pItem->guid;
		CUpdateBlock block;
		char buffer[0x90];
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+2*SLOT_TABARD, pClient->pPlayer->Data.Items[SLOT_TABARD], ITEMGUID_HIGH);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		RegionManager.ObjectNew(*pItem,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
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
		pClient->Echo("Syntax: createguild <name>");
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
	if(name == "stormcraft" && pClient->pAccount->Data.UserLevel < USER_GM)
	{
		pClient->Echo("The StormCraft Guild is reserved.");
		return;
	}
	CGuild *pGuild = new CGuild();
	pGuild->New(input, pClient);
	DataManager.NewObject(*pGuild);
	CGuild::AllGuilds[name] = pGuild->guid;
	pClient->Echo("You created guild %s. Type 'tabard' to get your guild tabard.", input);
	pClient->Echo("As a guildmaster you can go to a tabard vendor and choose your guild emblem.");
}


CFlyPathMob* GenerateFlyPathMob(unsigned long Model, const char *Name, 
	unsigned long Continent,_Location Loc, float Facing)
{
	CCreatureTemplate *CreatureTemplate = new CCreatureTemplate;
	CFlyPathMob *Creature = new CFlyPathMob;
	CreatureTemplate->New(Name);
	CreatureTemplate->Generated=true;
	Creature->New(CreatureTemplate->guid);
	strcpy(Creature->Data.Name,Name);
	Creature->Data.CurrentStats.HitPoints=200;
	Creature->Data.Level=1;
	Creature->Data.Model=Model;
	Creature->Data.NormalStats.HitPoints=200;
	Creature->Data.DamageMax=6;
	Creature->Data.DamageMin=4;
	Creature->Data.Exp = 100;
	Creature->Data.Continent=Continent;
	Creature->Data.SpawnLoc=Loc;
	Creature->Data.Loc=Loc;
	Creature->Data.SpawnFacing=Facing;
	Creature->Data.Facing=Facing;
	DataManager.NewObject(*CreatureTemplate);
	DataManager.NewObject(*Creature);
	
	// lets make him despawn.
	// creatures will live for 300 seconds  (5 minutes)
	//EventManager.AddEvent(*Creature,300000,EVENT_CREATURE_DESPAWN,0,0);
	EventManager.AddEvent(*Creature,10000,EVENT_CREATURE_REGENERATE,0,0);
	return Creature;
}

void CmdSpawn(CClient *pClient, char** argv, int argc)
{
	if(argc < 1)
	{
		pClient->Echo("Syntax: spawn <model> [name] [subtitle] [-[f|m|t]]");
		pClient->Echo("Option -f will spawn a flypath merchant.");
		pClient->Echo("Option -m will spawn an item merchant.");
		pClient->Echo("Option -t will spawn a tabard vendor.");
		pClient->Echo("You must have a subtitle if you want to use the - options.");
		pClient->Echo("Prefix model with 0x to use hex value.");
		return;
	}
	unsigned long model;
	if(sscanf(argv[0], "0x%X", &model) == 0 && sscanf(argv[0], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x");
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


	char *Name = NULL;
	char *Subtitle = NULL;
	bool isFlyPathMob = false;
	bool isTabardVendor = false;
	bool isItemMerchant = false;
	int i;
	if(argc > 1)
	{
		Name = argv[1];
		if(argc > 2)
		{
			Subtitle = argv[2];
			if(argc > 3)
			{
				for(i = 3;i < argc;i++)
				{
					if(argv[i][0] != '-')
					{
						pClient->Echo("Unknown switch.");
						return;
					}
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
					default:
						pClient->Echo("Unknown switch.");
						return;
					}
				}
			}
		}
	}

	char NameBuf[64];
	if(Name == NULL)
	{
		sprintf(NameBuf, "Creature %X", model);
		Name = NameBuf;
	}

	CCreature *pCreature = NULL;
	if(isFlyPathMob)
		pCreature = GenerateFlyPathMob(model, Name, pClient->pPlayer->Data.Continent, pClient->pPlayer->Data.Loc, pClient->pPlayer->Data.Facing);
	else
	{
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
	RegionManager.ObjectNew(*pCreature, pCreature->Data.Continent, pCreature->Data.Loc.X, pCreature->Data.Loc.Y);
	pClient->Echo("Ok. Spawned '%s' with model 0x%X.", Name, model);
}

void EditPlayer(CClient *pClient, CPlayer &Player, char **argv, int argc)
{
	CUpdateBlock block;
	char buffer[0x100];

	if(argc < 2)
	{
		pClient->Echo("Syntax: edit <attribute> <newvalue>");
		pClient->Echo("Available attributes for that target is:");
		pClient->Echo("hps, dmg(min-max), size, model, exp, level, speed");
		return;
	}
	if (!strnicmp(argv[0],"hps",3))
	{
		Player.Data.NormalStats.HitPoints=Player.Data.CurrentStats.HitPoints=atoi(argv[1]);
		block.ResetBlock(buffer, 0x100);
		block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
		block.Add(UNIT_HEALTH, Player.Data.CurrentStats.HitPoints);
		block.Add(UNIT_MAX_HEALTH, Player.Data.NormalStats.HitPoints);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);		return;
	}
	if (!strnicmp(argv[0],"dmg",3))
	{
		unsigned long Val1,Val2;
		if (argc == 3 && sscanf(argv[1],"%u",&Val1) && sscanf(argv[2], "%u", &Val2))
		{
			Player.Data.DamageMin=Val1;
			Player.Data.DamageMax=Val2;
			block.ResetBlock(buffer, 0x100);
			block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
			block.Add(UNIT_MIN_DAMAGE, Player.Data.DamageMin);
			block.Add(UNIT_MAX_DAMAGE, Player.Data.DamageMax);
			int size;
			char *ptr = block.GetCompressedData(size);
			if(size)
				Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		}
		return;
	}
	if (!strnicmp(argv[0],"size",4))
	{
		unsigned long model_size;
		sscanf(argv[1],"%d",&model_size);
		if (model_size<3) // we have to retrieve the real max model size, i can do cow x30 size, but dragon max is like x2
		{
			sscanf(argv[1],"%g",&Player.Data.Size);
			block.ResetBlock(buffer, 0x90);
			block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
			block.Add(OBJECT_SCALE, Player.Data.Size);
			int size;
			char *ptr = block.GetCompressedData(size);
			if(size)
				Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		}
		return;
	}
	if (!strnicmp(argv[0],"model",5))
	{
		sscanf(argv[1],"%X",&Player.Data.Model);
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
		block.Add(UNIT_DISPLAYID, Player.Data.Model);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		return;
	}
	if (!strnicmp(argv[0],"exp",3))
	{
		Player.Data.Exp=atoi(argv[1]);
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_XP, Player.Data.Exp);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		return;
	}
	if (!strnicmp(argv[0],"level",5))
	{
		Player.Data.Level=atoi(argv[1]);
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, Player.guid, PLAYERGUID_HIGH);
		block.Add(UNIT_LEVEL, Player.Data.Level);
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			Player.pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		return;
	}
	if (!strnicmp(argv[0],"speed",5))
	{
		sscanf(argv[1],"%g",&Player.Data.runspeed);
		if (Player.Data.runspeed < 51 && Player.Data.runspeed > 0)
		{
			pClient->UpdateRunSpeed(Player);
		}
		return;
	}

}

void EditCreature(CClient *pClient, CCreature &Creature, char **argv, int argc)
{
	if(argc < 2)
	{
		pClient->Echo("Syntax: edit <attribute> <newvalue>");
		pClient->Echo("Available attributes for that target is:");
		pClient->Echo("hps, dmg(min-max), size, model, exp, level, name, vendor, faction, invfilter");
		return;
	}
	if (!strnicmp(argv[0],"hps",3))
	{
		Creature.Data.NormalStats.HitPoints=Creature.Data.CurrentStats.HitPoints=atoi(argv[1]);
		RegionManager.ObjectResend(Creature);
		return;
	}
	if (!strnicmp(argv[0],"dmg",3))
	{
		unsigned long Val1,Val2;
		if (argc == 3 && sscanf(argv[1],"%u",&Val1) && sscanf(argv[2], "%u", &Val2))
		{
			Creature.Data.DamageMin=Val1;
			Creature.Data.DamageMax=Val2;
		}
		return;
	}
	if (!strnicmp(argv[0],"size",4))
	{
		unsigned long model_size;
		sscanf(argv[1],"%d",&model_size);
		if (model_size<3) // we have to retrieve the real max model size, i can do cow x30 size, but dragon max is like x2
		{
		sscanf(argv[1],"%g",&Creature.Data.Size);
		RegionManager.ObjectResend(Creature);
		}
		return;
	}
	if (!strnicmp(argv[0],"model",5))
	{
		sscanf(argv[1],"%X",&Creature.Data.Model);
		RegionManager.ObjectResend(Creature);
		return;
	}
	if (!strnicmp(argv[0],"exp",3))
	{
		Creature.Data.Exp=atoi(argv[1]);
		return;
	}
	if (!strnicmp(argv[0],"level",5))
	{
		Creature.Data.Level=atoi(argv[1]);
		return;
	}
	if (!strnicmp(argv[0],"name",4))
	{
		CCreatureTemplate *pTemplate;
		if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Creature.Data.Template))
		{
			pClient->Echo("Creature template '%s' renamed to '%s'.  This takes effect for any new retrievals of the template.",pTemplate->Data.Name,argv[1]);
			strncpy(pTemplate->Data.Name,argv[1],63);
			pTemplate->Data.Name[63]=0;
			strcpy(pTemplate->Data.Name1,pTemplate->Data.Name);
			strcpy(pTemplate->Data.Name2,pTemplate->Data.Name);
			strcpy(pTemplate->Data.Name3,pTemplate->Data.Name);
		}
		return;
	}
	if(!strnicmp(argv[0],"vendor",4))
	{
		unsigned long type = 0;
		if(!strnicmp(argv[1],"merchant", 8))
			type = NPCTYPE_MERCHANT;
		else if(!strnicmp(argv[1], "questgiver", 10))
			type = NPCTYPE_QUESTGIVER;
		else if(!strnicmp(argv[1], "taxi", 4))
			type = NPCTYPE_TAXI;
		else if(!strnicmp(argv[1], "trainer", 7))
			type = NPCTYPE_TRAINER;
		else if(!strnicmp(argv[1], "binder", 6))
			type = NPCTYPE_BINDER;
		else if(!strnicmp(argv[1], "banker", 6))
			type = NPCTYPE_BANKER;
		else if(!strnicmp(argv[1], "petitioner", 11))
			type = NPCTYPE_PETITION;
		else if(!strnicmp(argv[1], "tabard", 6))
			type = NPCTYPE_TABARD;
		else if(!strnicmp(argv[1], "none", 4))
			type = NPCTYPE_NONE;
		else
		{
			pClient->Echo("Valid vendor types are: none, merchant, questgiver, taxi, trainer, binder, banker, petitioner and tabard");
			return;
		}
		Creature.Data.NPCType = type;
		RegionManager.ObjectResend(Creature);
		pClient->Echo("Ok. Vendor type set to: %s", argv[1]);
	}
	else if(!strnicmp(argv[0], "faction", 7))
	{
		unsigned long val;
		if(sscanf(argv[1],"%X",&val))
		{
			Creature.Data.FactionTemplate = val;
			RegionManager.ObjectResend(Creature);
		}
	}
	else if(!strnicmp(argv[0], "invfilter", 9))
	{
		if(!strnicmp(argv[1], "allitems", 8))
		{
			memset(&Creature.Data.MerchantFilter.subtype, -1, NUM_ITEMTYPES*4);
			pClient->Echo("Ok. added filter for all items.");
			return;
		}
		else if(!strnicmp(argv[1], "armour", 6) || !strnicmp(argv[1], "armor",5))
		{
			if(argc == 2)
			{
				Creature.Data.MerchantFilter.subtype[ITEMTYPE_ARMOUR] = 0xFFFFFFFF;
				pClient->Echo("Ok. Added filter for all armour types.");
			}
			else if(argc == 3)
			{
				string subtype = argv[2];
				MakeLower(subtype);
				map<string, unsigned long>::iterator i = ChatManager.ArmourInvFilter.find(subtype);
				if(i == ChatManager.ArmourInvFilter.end())
				{
					string output = "Available armour sub types are: ";
					for(i = ChatManager.ArmourInvFilter.begin(); i != ChatManager.ArmourInvFilter.end();i++)
					{
						output += i->first;
						output += ", ";
					}
					pClient->Echo(output.c_str());
					return;
				}
				Creature.Data.MerchantFilter.subtype[ITEMTYPE_ARMOUR] |= i->second;
				pClient->Echo("Ok. Added subtype %s to armour filter.", argv[2]);
			}
			return;
		}
		else if(!strnicmp(argv[1], "weapon", 6))
		{
			if(argc == 2)
			{
				Creature.Data.MerchantFilter.subtype[ITEMTYPE_WEAPON] = 0xFFFFFFFF;
				pClient->Echo("Ok. Added filter for all weapon types.");
			}
			else if(argc == 3)
			{
				string subtype = argv[2];
				MakeLower(subtype);
				map<string, unsigned long>::iterator i = ChatManager.WeaponInvFilter.find(subtype);
				if(i == ChatManager.WeaponInvFilter.end())
				{
					string output = "Available Weapon sub types are: ";
					for(i = ChatManager.WeaponInvFilter.begin(); i != ChatManager.WeaponInvFilter.end();i++)
					{
						output += i->first;
						output += ", ";
					}
					pClient->Echo(output.c_str());
					return;
				}
				Creature.Data.MerchantFilter.subtype[ITEMTYPE_WEAPON] |= i->second;
				pClient->Echo("Ok. Added subtype %s to weapon filter.", argv[2]);
			}
			return;
		}
		else if(!strnicmp(argv[1], "minlevel", 8))
		{
			if(argc == 2)
			{
				pClient->Echo("Syntax: edit invfilter minlevel <level>");
				pClient->Echo("Set minlevel 0 to turn it off.");
				return;
			}
			sscanf(argv[2], "%u", &Creature.Data.MerchantFilter.minlevel);
		}
		else if(!strnicmp(argv[1], "maxlevel", 8))
		{
			if(argc == 2)
			{
				pClient->Echo("Syntax: edit invfilter maxlevel <level>");
				pClient->Echo("Set maxlevel 0 to turn it off.");
				return;
			}
			sscanf(argv[2], "%u", &Creature.Data.MerchantFilter.maxlevel);
		}
		else if(!strnicmp(argv[1], "reset", 5))
		{
			memset(&Creature.Data.MerchantFilter, 0, sizeof(MerchantFilter_t));
			pClient->Echo("Ok. Merchant filter reset.");
		}
		else if(!strnicmp(argv[1], "update", 6))
		{
			Creature.MerchantInv.clear();
			CItemTemplate *pTemplate = NULL;
			for(unsigned long nTemplate = STATICITEMS::ITEMWDB_FIRST;
				nTemplate < STATICITEMS::ITEMWDB_FIRST+STATICITEMS::ITEMWDB_COUNT;nTemplate++)
			{
				if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, nTemplate))
				{
					if(!(Creature.Data.MerchantFilter.subtype[pTemplate->Data.Type]
						& (1 << pTemplate->Data.Subtype)))
						continue;
					if(Creature.Data.MerchantFilter.minlevel && pTemplate->Data.LevelReq < Creature.Data.MerchantFilter.minlevel)
						continue;
					if(Creature.Data.MerchantFilter.maxlevel && pTemplate->Data.LevelReq > Creature.Data.MerchantFilter.maxlevel)
						continue;
					Creature.AddMerchantItem(pTemplate->guid);
					if(Creature.MerchantInv.size() == MAX_MERCHANTITEMS)
						break;
				}
			}
			pClient->Echo("Ok. Added %d of %d items to merchant.", Creature.MerchantInv.size(), STATICITEMS::ITEMWDB_COUNT);
		}
		else
		{
			pClient->Echo("Valid sub commands for invfilter are: allitems, armour/armor, weapon, minlevel, maxlevel, reset, update");
		}
	}
	
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
	Settings.LoadSettings();
	pClient->Echo("Server Settings Rehashed");
}

void CmdGet(CClient *pClient, char **argv, int argc)
{
	if(argc != 2)
	{
		pClient->Echo("Syntax: get <type> <model>");
		pClient->Echo("Types for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger, trinket, back, mainhand, offhand");
		pClient->Echo("Prefix hex value with 0x.");
		return;
	}
	string type = argv[0];
	MakeLower(type);
	map<string, unsigned long>::iterator i = ChatManager.InvTypes.find(type);
	if(i == ChatManager.InvTypes.end())
	{
		pClient->Echo("Syntax: get <type> <model>");
		pClient->Echo("Types for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger, trinket, back, mainhand, offhand");
		return;
	}
	unsigned long model;
	if(sscanf(argv[1], "0x%X", &model) == 0 && sscanf(argv[1], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	int newSlot = -1;
	for(int s = SLOT_INBACKPACK;s < SLOT_INBACKPACK+16;s++)
	{
		if(pClient->pPlayer->Data.Items[s] == 0)
		{
			newSlot = s;
			break;
		}
	}
	if(newSlot == -1)
	{
		pClient->Echo("Backpack full.");
		return;
	}
	CItemTemplate* pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->Data.InvType = i->second;
	pTemplate->Data.DisplayID = model;
	sprintf(pTemplate->Data.Name, "Item 0x%X", model);
	DataManager.NewObject(*pTemplate);
	CItem *pItem = new CItem;
	pItem->New(pTemplate->guid, pClient->pPlayer->guid);
	DataManager.NewObject(*pItem);
	RegionManager.ObjectNew(*pItem, pClient->pPlayer->Data.Continent,
		pClient->pPlayer->Data.Loc.X, pClient->pPlayer->Data.Loc.Y);

	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	pClient->pPlayer->Data.Items[newSlot] = pItem->guid;
	block.Add(PLAYER_INV_SLOTS+newSlot*2, pItem->guid, ITEMGUID_HIGH);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void CmdMorph(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: morph <model>");
		return;
	}
	unsigned long model;
	if(sscanf(argv[0], "0x%X", &model) == 0 && sscanf(argv[0], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x");
		return;
	}
	if(model == 0)
		return;
	pClient->pPlayer->Data.Model = model;
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_DISPLAYID, pClient->pPlayer->Data.Model);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	pClient->Echo("You have morphed into model: %X",model);
}

void CmdUber(CClient *pClient, char *input)
{
	if (pClient->pPlayer->Data.StatusFlags >= STATUS_GM) 
	{
		// TODO: reload stat from Datamanager 
		pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;

		pClient->pPlayer->Data.NormalStats.HitPoints = 200;
		pClient->pPlayer->Data.NormalStats.Mana = 500;
		pClient->pPlayer->Data.NormalStats.Focus = 100;
		pClient->pPlayer->Data.NormalStats.Energy = 100;
		pClient->pPlayer->Data.NormalStats.Rage = 1000;

		pClient->pPlayer->Data.CurrentStats.HitPoints = 200;
		pClient->pPlayer->Data.CurrentStats.Mana = 500;
		pClient->pPlayer->Data.CurrentStats.Focus = 100;
		pClient->pPlayer->Data.CurrentStats.Energy = 100;
		pClient->pPlayer->Data.CurrentStats.Rage = 1000;

		pClient->pPlayer->Data.DamageMin = 20;
		pClient->pPlayer->Data.DamageMax = 35;

		pClient->pPlayer->Data.Level = 5;
	}
	else
	{
		pClient->pPlayer->Data.StatusFlags ^= STATUS_GM;

		pClient->pPlayer->Data.NormalStats.HitPoints = 100000;
		pClient->pPlayer->Data.NormalStats.Mana = 100000;
		pClient->pPlayer->Data.NormalStats.Focus = 100000;
		pClient->pPlayer->Data.NormalStats.Energy = 100000;
		pClient->pPlayer->Data.NormalStats.Rage = 100000;

		pClient->pPlayer->Data.CurrentStats.HitPoints = 100000;
		pClient->pPlayer->Data.CurrentStats.Mana = 100000;
		pClient->pPlayer->Data.CurrentStats.Focus = 100000;
		pClient->pPlayer->Data.CurrentStats.Energy = 100000;
		pClient->pPlayer->Data.CurrentStats.Rage = 100000;

		pClient->pPlayer->Data.DamageMin = 9999;
		pClient->pPlayer->Data.DamageMax = 9999;

		pClient->pPlayer->Data.Level = 255;
	}
	CUpdateBlock block;
	char buffer[0x120];
	block.ResetBlock(buffer, 0x120);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_HEALTH, pClient->pPlayer->Data.CurrentStats.HitPoints);
	block.Add(UNIT_MANA, pClient->pPlayer->Data.CurrentStats.Mana);
	block.Add(UNIT_RAGE, pClient->pPlayer->Data.CurrentStats.Rage);
	block.Add(UNIT_FOCUS, pClient->pPlayer->Data.CurrentStats.Focus);
	block.Add(UNIT_ENERGY, pClient->pPlayer->Data.CurrentStats.Energy);
	block.Add(UNIT_MAX_HEALTH, pClient->pPlayer->Data.NormalStats.HitPoints);
	block.Add(UNIT_MAX_MANA, pClient->pPlayer->Data.NormalStats.Mana);
	block.Add(UNIT_MAX_RAGE, pClient->pPlayer->Data.NormalStats.Rage);
	block.Add(UNIT_MAX_FOCUS, pClient->pPlayer->Data.NormalStats.Focus);
	block.Add(UNIT_MAX_ENERGY, pClient->pPlayer->Data.NormalStats.Energy);
	block.Add(UNIT_LEVEL, pClient->pPlayer->Data.Level);
	block.Add(UNIT_MIN_DAMAGE, pClient->pPlayer->Data.DamageMin);
	block.Add(UNIT_MAX_DAMAGE, pClient->pPlayer->Data.DamageMax);
	block.Add(PLAYER_BYTES_2,pClient->pPlayer->Data.StatusFlags | (pClient->pPlayer->Data.Appearance[4] << 24));
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);

	pClient->Echo("GM status %s",pClient->pPlayer->Data.StatusFlags >= STATUS_GM ? "Enabled" : "Disabled");
}

void CmdDeathtouch(CClient *pClient, char **argv, int argc)
{
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
			unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 
									  0x07, 0x00, 0x00, 0x00, 0x82, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
									  0x42, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB8, 0x1A, 0x1A, 0x46, 0x29, 0x2C, 
									  0x6E, 0x44, 0xD5, 0x50, 0xA3, 0x44};
				pTarget->pClient->Echo("You have been touched with death!");
			*(unsigned long*)&packet[0x17]=pTarget->pClient->pPlayer->guid;
			*(unsigned long*)&packet[0x22]=pTarget->pClient->pPlayer->guid;
			pTarget->pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
			pTarget->pClient->pPlayer->Data.CurrentStats.HitPoints -= 1337;
			CRegion *pPlayerRegion=RegionManager.ObjectRegions[pTarget->pClient->pPlayer->guid];
			if (!pPlayerRegion)
				return;
			pClient->RegionOutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
			if (pTarget->pClient->pPlayer->Data.CurrentStats.HitPoints <= 0)
			{
					pTarget->pClient->pPlayer->ClearEvents();
			}
			pTarget->UpdateHP();
			pClient->Echo("Player %s has been touched with death",pTarget->Data.Name);
		}
	}
	else
	{
		// This should probably be a function, feel free to relocate ;)
		unsigned char packet[] = {0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x07, 0x40, 0x00, 0x00, 0x00, 0x00, 
								  0x07, 0x00, 0x00, 0x00, 0x82, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
								  0x42, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB8, 0x1A, 0x1A, 0x46, 0x29, 0x2C, 
								  0x6E, 0x44, 0xD5, 0x50, 0xA3, 0x44};

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
						if (((CPlayer*)pNode->pObject)->pClient!=pClient && ((CPlayer*)pNode->pObject)->pClient->pAccount->Data.UserLevel<USER_GM)
						{
							((CPlayer*)pNode->pObject)->pClient->Echo("You have been touched with death!");
							*(unsigned long*)&packet[0x17]=((CPlayer*)pNode->pObject)->pClient->pPlayer->guid;
							*(unsigned long*)&packet[0x22]=((CPlayer*)pNode->pObject)->pClient->pPlayer->guid;
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
							((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.CurrentStats.HitPoints -= 1337;
							if (((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.CurrentStats.HitPoints <= 0)
							{
								((CPlayer*)pNode->pObject)->pClient->pPlayer->ClearEvents();
							}
							((CPlayer*)pNode)->UpdateHP();
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
	pClient->Echo("MaxSent=%d",RealmServer.MaxSent);
}

void CmdBroadcast(CClient *pClient, char *input)
{
	if (strlen(input)>2)
	{
		char temp[2048];
		sprintf(temp,"<GM-%s BROADCAST> %s",pClient->pPlayer->Data.Name,input);
		char buffer[2048];
		memset(buffer,0,2048);
		int c = 0;
		buffer[c++]=9;
		*(unsigned long*)&buffer[c]=0;
		// unknown
		c+=4;
		*(unsigned long*)&buffer[c]=pClient->pPlayer->guid;
		c+=4;
		// Hmm I wonder what this is? - Fnag
		//	*(unsigned long*)&buffer[c]=????;  // unknown
		c+=4;
		strcpy(&buffer[c],temp);
		c+=strlen(temp)+1;
		// unknown single byte
		c++;
		RealmServer.BroadcastOutPacket(SMSG_MESSAGECHAT,buffer,c);
	}
}

void CmdUserLevel(CClient *pClient, char **argv, int argc)
{
	if(argc != 2)
	{
		pClient->Echo("Syntax: userlevel <account/player name> <userlevel>");
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
		break;
	case USER_BANNED:
		pAccount->Data.UserLevel=USER_BANNED;
		if(notifyUser)
			pAccount->pClient->Echo("Your account has been given Banned status.");
		pClient->Echo("%s has been given Banned status.",pAccount->Data.Name);
		break;
	case USER_DELETE:
		pAccount->Data.UserLevel=USER_DELETE;
		if(notifyUser)
			pAccount->pClient->Echo("Your account has been given Pending Delete status.");
		pClient->Echo("%s has been given Pending Delete status.",pAccount->Data.Name);
		break;
	}
	DataManager.StoreObject(*pAccount);
}

void CmdResetPlayer(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: resetplayer <player>");
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
		pTarget->Data.ResurrectionSickness = false;
		pTarget->Data.PvP = false;
		pTarget->Data.RecentPvP = false;
		pTarget->Data.CurrentStats.HitPoints = pTarget->Data.NormalStats.HitPoints;
		pTarget->Data.CurrentStats.Mana = pTarget->Data.NormalStats.Mana;
		if (pTarget->pClient)
		{
			pTarget->UpdateHPMP();
		}
		pClient->Echo("Player %s reset",pTarget->Data.Name);
	}
}

void CmdKickPlayer(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: kickplayer <name>");
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
}

void CmdGive(CClient *pClient, char **argv, int argc)
{
	if(argc != 4)
	{
		pClient->Echo("Syntax: give <player> <itemname> <worntype> <model>");
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

	int newSlot = -1;
	for(int s = SLOT_INBACKPACK;s < SLOT_INBACKPACK+16;s++)
	{
		if(pPlayer->Data.Items[s] == 0)
		{
			newSlot = s;
		}
	}
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
	unsigned long model;
	if(sscanf(argv[3], "0x%X", &model) == 0 && sscanf(argv[3], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	CItemTemplate *pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->Data.DisplayID = model;
	pTemplate->Data.InvType = i->second;
	strncpy(pTemplate->Data.Name, argv[1], 63);
	pTemplate->Data.Name[63] = 0;
	DataManager.NewObject(*pTemplate);
	CItem *pItem = new CItem;
	pItem->New(pTemplate->guid, pPlayer->guid);
	DataManager.NewObject(*pItem);
	RegionManager.ObjectNew(*pItem, pPlayer->Data.Continent, pPlayer->Data.Loc.X, pPlayer->Data.Loc.Y);

	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
	pPlayer->Data.Items[newSlot] = pItem->guid;
	block.Add(PLAYER_INV_SLOTS+newSlot*2, pItem->guid, ITEMGUID_HIGH);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);

	pClient->Echo("You gave %s to %s.", argv[1], pPlayer->Data.Name);
	pPlayer->pClient->Echo("%s gave you %s. It has been automaticly stored into your backpack.",
		pClient->pPlayer->Data.Name, argv[1]);
}

void CmdStrip(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: strip <player> [slot]");
		pClient->Echo("Todo: by slot stripping");
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

	CUpdateBlock block;
	char buffer[0x80+0x45*4];
	block.ResetBlock(buffer, 0x80+0x45*4);
	block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
	bool send = false;
	for(int i = 0;i < 0x45;i++)
	{
		if(pPlayer->Data.Items[i])
		{
			send = true;
			unsigned long temp = pPlayer->Data.Items[i];
			pPlayer->Data.Items[i] = 0;
			block.Add(PLAYER_INV_SLOTS+i*2, temp, ITEMGUID_HIGH);
			CItem *pItem = NULL;
			if(DataManager.RetrieveObject((CWoWObject**)pItem, temp))
			{
				RegionManager.ObjectRemove(*pItem);
				pItem->Delete();
			}
		}
	}
	if(send)
	{
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		pClient->Echo("Ok. Stripped %s items.", pPlayer->Data.Name);
	}
	else
		pClient->Echo("No items stripped from %s.", pPlayer->Data.Name);
}


void CmdKillSpawn(CClient *pClient, char *input)
{
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
	pCreature->Delete();
	pClient->Echo("Spawn killed.");
}

void CmdMorphTarget(CClient *pClient, char **argv, int argc)
{
	if(argc < 1)
	{
		pClient->Echo("Syntax: morphtarget <model> [playername]");
		pClient->Echo("If player name is not supplied it will morph the player/creature you are selecting.");
	}

	unsigned long model;
	if(sscanf(argv[0], "0x%X", &model) == 0 && sscanf(argv[0], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	unsigned long target;
	if(argc == 2)
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
	CUpdateBlock block;
	char buffer[0x90];
	int size;
	char *ptr;
	block.ResetBlock(buffer, 0x90);
	if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, target))
	{
		if(pPlayer->pClient == NULL)
		{
			pClient->Echo("That player is not online.");
			return;
		}
		pPlayer->Data.Model = model;
		block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(UNIT_DISPLAYID, model);
		ptr = block.GetCompressedData(size);
		if(size)
		{
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
			pClient->Echo("You morphed %s into 0x%X.", pPlayer->Data.Name, pPlayer->Data.Model);
		}
	}
	else if(DataManager.RetrieveObject((CWoWObject**)pCreature, OBJ_CREATURE, target))
	{
		pCreature->Data.Model = model;
		block.AddDataUpdate(UNIT_MAX_BITS, pCreature->guid, CREATUREGUID_HIGH);
		block.Add(UNIT_DISPLAYID, model);
		ptr = block.GetCompressedData(size);
		if(size)
		{
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
			pClient->Echo("You morphed %s into 0x%X.", pCreature->Data.Name, pPlayer->Data.Model);
		}
	}
	else
	{
		pClient->Echo("Unknown target.");
	}
}

void CmdMountModel(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: mountmodel <model>");
		return;
	}
	unsigned long model;
	if(sscanf(argv[0], "0x%X", &model) == 0 && sscanf(argv[0], "%u", &model) == 0)
	{
		pClient->Echo("Invalid model value. Prefix hex values with 0x.");
		return;
	}
	if(pClient->pPlayer->Data.MountModel != 0)
	{
		pClient->Echo("You need to dismount first.");
		return;
	}
	pClient->pPlayer->Data.MountModel = model;
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_MOUNT_DISPLAYID, pClient->pPlayer->Data.MountModel);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	pClient->Echo("Mount model set to 0x%X.", model);
}

void CmdGetPosition(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: getposition <player>");
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

	pClient->Echo("%s is at %f, %f, %f.", pPlayer->Data.Name,
		pPlayer->Data.Loc.X, pPlayer->Data.Loc.Y, pPlayer->Data.Loc.Z);
	if(pPlayer->pClient == NULL)
		pClient->Echo("%s is not online.", pPlayer->Data.Name);
}

void CmdSummon(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: summon <player>");
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

	char buf[0x11];
	pPlayer->Data.Continent=buf[0]=pClient->pPlayer->Data.Continent;
	memcpy(&buf[1], &pClient->pPlayer->Data.Loc, sizeof(_Location));
	*(float*)&buf[0x0D] = pClient->pPlayer->Data.Facing;
	pPlayer->pClient->OutPacket(SMSG_NEW_WORLD, buf, 0x11);
	RegionManager.ObjectRemove(*pPlayer);
	pPlayer->Data.bSummoned = true;
	pPlayer->Data.Loc = pClient->pPlayer->Data.Loc;
	pPlayer->Data.Facing = pClient->pPlayer->Data.Facing;
	pPlayer->pClient->Echo("You have been summoned by %s.", pClient->pPlayer->Data.Name);
	pClient->Echo("You have summoned %s.", pPlayer->Data.Name);
}

void CmdRelease(CClient *pClient, char **argv, int argc)
{
	if(argc != 1)
	{
		pClient->Echo("Syntax: release <player>");
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
	pClient->Echo("You released %s.", pPlayer->Data.Name);
	if(pPlayer->pClient)
		pPlayer->pClient->Echo("You have been released.");
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
		pClient->Echo("Syntax: cape <color>");
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
	pClient->pPlayer->Data.Items[SLOT_BACK]=pItem->guid;
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_INV_SLOTS+2*SLOT_BACK, pClient->pPlayer->Data.Items[SLOT_BACK], ITEMGUID_HIGH);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	RegionManager.ObjectNew(*pItem,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
}

void CmdCommands(CClient *pClient, char *input);
MsgHandler Handlers[] =
{
	{"spell", USER_NORMAL, (void*)CmdSpell, FUNCTYPE_STRING},
	{"report", USER_NORMAL, (void*)CmdReport, FUNCTYPE_STRING},
	{"worldport", USER_NORMAL, (void*)CmdWorldport, FUNCTYPE_ARGS},
	{"clients", USER_NORMAL, (void*)CmdClients, FUNCTYPE_STRING},
	{"pvp", USER_NORMAL, (void*)CmdPvp, FUNCTYPE_STRING},
	{"mount", USER_NORMAL, (void*)CmdMount, FUNCTYPE_STRING},
	{"unmount", USER_NORMAL, (void*)CmdUnmount, FUNCTYPE_STRING},
	{"dismount", USER_NORMAL, (void*)CmdUnmount, FUNCTYPE_STRING},
	{"tabard", USER_NORMAL, (void*)CmdTabard, FUNCTYPE_STRING},
	{"createguild", USER_NORMAL, (void*)CmdCreateGuild, FUNCTYPE_STRING},
	{"spawn", USER_HALFGM, (void*)CmdSpawn, FUNCTYPE_ARGS},
	{"edit", USER_HALFGM, (void*)CmdEdit, FUNCTYPE_ARGS},
	{"rehash", USER_ADMIN, (void*)CmdRehash, FUNCTYPE_STRING},
	{"get", USER_GM, (void*)CmdGet, FUNCTYPE_ARGS},
	{"morph", USER_MODERATOR, (void*)CmdMorph, FUNCTYPE_ARGS},
	{"uber", USER_HALFGM, (void*)CmdUber, FUNCTYPE_STRING},
	{"deathtouch", USER_GM, (void*)CmdDeathtouch, FUNCTYPE_ARGS},
	{"maxsent", USER_GM, (void*)CmdMaxsent, FUNCTYPE_STRING},
	{"broadcast", USER_GM, (void*)CmdBroadcast, FUNCTYPE_STRING},
	{"userlevel", USER_MODERATOR, (void*)CmdUserLevel, FUNCTYPE_ARGS},
	{"resetplayer", USER_GM, (void*)CmdResetPlayer, FUNCTYPE_ARGS},
	{"kickplayer", USER_GM, (void*)CmdKickPlayer, FUNCTYPE_ARGS},
	{"give", USER_GM, (void*)CmdGive, FUNCTYPE_ARGS},
	{"strip", USER_GM, (void*)CmdStrip, FUNCTYPE_ARGS},
	{"killspawn", USER_HALFGM, (void*)CmdKillSpawn, FUNCTYPE_STRING},
	{"morphtarget", USER_GM, (void*)CmdMorphTarget, FUNCTYPE_ARGS},
	{"mountmodel", USER_GM,(void*) CmdMountModel, FUNCTYPE_ARGS},
	{"getposition", USER_SUPERMOD,(void*) CmdGetPosition, FUNCTYPE_ARGS},
	{"summon", USER_GM,(void*) CmdSummon, FUNCTYPE_ARGS},
	{"release", USER_GM, (void*)CmdRelease, FUNCTYPE_ARGS},
	{"cape", USER_NORMAL,(void*) CmdCape, FUNCTYPE_ARGS},
	{"cloak", USER_NORMAL, (void*)CmdCape, FUNCTYPE_ARGS},
	{"commands", USER_NORMAL, (void*)CmdCommands, FUNCTYPE_STRING},
	{NULL, 0, 0},
};

void CmdCommands(CClient *pClient, char *input)
{
	string output = "Available commands: ";
	for(int i = 0;Handlers[i].cmd != NULL;i++)
	{
		if(Handlers[i].Userlevel > pClient->pAccount->Data.UserLevel)
			continue;
		output += Handlers[i].cmd;
		output += ", ";
	}
	pClient->Echo(output.c_str());
}

void CChatManager::MsgChat(CClient *pClient, _InData *pData)
{
	bool updateStatusFlags = false;
	switch(pData->Data[0])
	{
	case CHAT_SAY:
		if(!ProcessCommand(pClient, &pData->Data[8]))
			pClient->ChatSay(*(unsigned long*)&pData->Data[4],&pData->Data[8]);
		break;
	case CHAT_PARTY:
		{
			CParty *pParty = CParty::GetParty(pClient, true);
			if(pParty != NULL)
				pParty->PartyChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_GUILD:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->GuildChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_OFFICER:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->OfficerChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_YELL:
		pClient->ChatYell(*(unsigned long*)&pData->Data[4],&pData->Data[8]);
		break;
	case CHAT_WHISPER:
		{
			string Who=&pData->Data[8];
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",&pData->Data[8]);
				return;
			}
			CPlayer *pTo=0;
			if (!DataManager.RetrieveObject((CWoWObject**)&pTo,OBJ_PLAYER,PlayerID))
			{
				pClient->Echo("Player '%s' does not exist (error: exists in name cache but not in database).",&pData->Data[8]);
				return;
			}
			if (!pTo->pClient)
			{
				pClient->Echo("Player '%s' not online",&pData->Data[8]);
				return;
			}
			pTo->pClient->ChannelMessage(CHAT_WHISPER,&pData->Data[8+strlen(&pData->Data[8])+1],pClient->pPlayer->guid,0,0);
			pClient->Echo("You whisper to %s : %s",pTo->Data.Name,&pData->Data[8+strlen(&pData->Data[8])+1]);
			if (pTo->Data.StatusFlags == STATUS_AFK) {
				pClient->Echo("Player is AFK: %s", pTo->Data.StatusReason);
			}
			if (pTo->Data.StatusFlags == STATUS_DND) {
				pClient->Echo("Player Do Not Disturb: %s", pTo->Data.StatusReason);
			}
		}
		break;
	case CHAT_EMOTE:
		break;
	case CHAT_MOTD:
		break;
	case CHAT_AFK:
		{
			char *msg=&pData->Data[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}

			if (!pClient->pPlayer->Data.StatusFlags)
			{	
				pClient->pPlayer->Data.StatusFlags ^= STATUS_AFK;
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			else
			{
				pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;
				strcpy(pClient->pPlayer->Data.StatusReason, "");
			}
			updateStatusFlags = true;
		}
		break;
	case CHAT_DND:
		{
			char *msg=&pData->Data[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}

			if (!pClient->pPlayer->Data.StatusFlags)
			{
				pClient->pPlayer->Data.StatusFlags ^= STATUS_DND;
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			else
			{
				pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;
				strcpy(pClient->pPlayer->Data.StatusReason, "");
			}
			updateStatusFlags = true;
		}
		break;
	default:
		pClient->Echo("This type of chat or emote is not yet implemented.");
		break;
	}
	if(updateStatusFlags)
	{
		CUpdateBlock block;
		char buffer[0x90];
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_BYTES_2,pClient->pPlayer->Data.StatusFlags | (pClient->pPlayer->Data.Appearance[4] << 24));
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	}
}



/*
bool ResetModerators(unsigned long ID)
{
	CAccount *pAccount;
	if (DataManager.RetrieveObject((CWoWObject**)&pAccount,OBJ_ACCOUNT,ID))
	{
		if (pAccount->Data.UserLevel>USER_NORMAL && pAccount->Data.UserLevel<USER_GM)
			pAccount->Data.UserLevel=USER_NORMAL;
		DataManager.StoreObject(*pAccount);
	}
	return true;
}

void ProcessGMCommand(CClient *pClient, const char *command)
{
#ifdef ACCOUNTLESS
	char UserLevel=USER_ADMIN;
#else
	char UserLevel=pClient->pAccount->Data.UserLevel;
#endif

	else if (UserLevel>=USER_GM && !strnicmp(command,"summon ",7)) {
		char name[256];
		unsigned long PlayerID;
		if (sscanf(command,"summon %s",name)==1)
		{
			string Who=name;
			MakeLower(Who);
			PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
				return;
			}
		}
		else
		{
			pClient->Echo("Syntax: summon <name>");
			return;
		}
		
		CPlayer *pPlayer=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,PlayerID))
		{
			if (pPlayer==pClient->pPlayer)
			{
				pClient->Echo("Cannot lock yourself");
				return;
			}
			if (!pPlayer->pClient)
			{
				pClient->Echo("Player '%s' not online.",name);
				return;
			}

			long OldLevel=pPlayer->pClient->pAccount->Data.UserLevel;
			if (OldLevel>=UserLevel)
			{
				pClient->Echo("I dont think it would be wise to summon a higher ranking person than yourself...");
				return;
			}

			pPlayer->Data.bSummoned = true;
			char buf[0x11];
			memset(buf,0,0x11);
			pPlayer->Data.Continent=buf[0]=pClient->pPlayer->Data.Continent;
			memcpy(&buf[1],&pClient->pPlayer->Data.Loc,0x0C);
			pPlayer->pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
			memcpy(&pPlayer->Data.Loc,&buf[1],sizeof(_Location));
			RegionManager.ObjectRemove(*pPlayer);
			pPlayer->pClient->Echo("You have been SUMMONED");
			pClient->Echo("%s has been SUMMONED",name);
		}
	}
	else if (UserLevel>=USER_ADMIN && !stricmp(command,"resetmoderators"))
	{
		Storage.EnumObjectIDs(OBJ_ACCOUNT,ResetModerators);
		pClient->Echo("Done.");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"release ",8)) {
		char name[256];
		unsigned long PlayerID;
		if (sscanf(command,"release %s",name)==1)
		{
			string Who=name;
			MakeLower(Who);
			PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
				return;
			}
		}
		else
		{
			pClient->Echo("Syntax: release <name>");
			return;
		}
		
		CPlayer *pPlayer=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,PlayerID))
		{
			if (pPlayer==pClient->pPlayer)
			{
				pClient->Echo("Cannot release yourself");
				return;
			}
			if (!pPlayer->pClient)
			{
				pClient->Echo("Player '%s' not online.",name);
				return;
			}
			if (!pPlayer->Data.bSummoned) {
				pClient->Echo("Player wasn't summoned");
				return;
			}

			pPlayer->Data.bSummoned = false;
			pPlayer->pClient->Echo("You have been RELEASED");
			pClient->Echo("%s has been RELEASED",name);
		}
	}
	else if (UserLevel>=USER_MODERATOR && !stricmp(command,"help"))
	{
			switch(UserLevel)
			{
			case USER_ADMIN:
				pClient->Echo("spawn, edit, rehash, get, item, morph, uber, deathtouch, maxsent, broadcast, userlevel, resetplayer, \
							  killplayer, give, strip, killspawn, morphtarget, mountmodel, getposition, summon, release, resetmoderators.");
				break;
			case USER_GM:
				pClient->Echo("spawn, edit, get, item, morph, uber, deathtouch, maxsent, broadcast, userlevel, resetplayer, \
							  killplayer, give, strip, killspawn, morphtarget, mountmodel, getposition, summon, release, resetmoderators.");
				break;
			case USER_HALFGM:
				pClient->Echo("spawn, morph, uber, maxsent, userlevel, killspawn, getposition");
				break;
			case USER_SUPERMOD:
				pClient->Echo("spawn, morph, uber, maxsent, userlevel, killspawn, getposition");
				break;
			case USER_MODERATOR:
				pClient->Echo("spawn, morph, uber, maxsent, userlevel, killspawn");
				break;
			}
	}
	else
	{
		pClient->Echo("Invalid command or insufficient access level");
	}
}
*/

/*
	else if (UserLevel>=USER_GM && !stricmp(command,"ppoint") || !stricmp(command,"ppoint help"))
	{
		pClient->Echo("Syntax ppoint <command> <option>");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"ppoint ",7))
	{
		const char *args;
		args = command + 7;
		char buf[32];
		int i;

		if (!stricmp(args, "edit"))
		{
			if (PPoints.editMode = !PPoints.editMode)
			{
				pClient->Echo("Spawning pathpoints...");
				PPoints.SpawnPathPoints();
			}
			else
			{
				pClient->Echo("Despawning pathpoints...");
				// TODO: despawn
			}
		}
		else if (!PPoints.editMode)
		{
			pClient->Echo("Set edit mode first. '%ppoint edit'");
			return;
		}
		else if (!stricmp(args, "add"))
		{
			if (PPoints.editType && PPoints.editGroup)
			{
				pClient->Echo("Adding pathpoint...");

				PPoints.AddPoint(pClient);
			}
			else
				pClient->Echo("You must set group and type before adding pathpoints");
		}
		else if (!stricmp(args, "delete"))
		{
			pClient->Echo("Deleting pathpoint...");
			// TODO delete
		}
		else if (sscanf(args,"group %d",&PPoints.editGroup)==1)
		{
			pClient->Echo("Now editing group %d", PPoints.editGroup);
		}
		else if (sscanf(args,"type %[^¦]",buf)==1)
		{
			map<string,int>types;
			types["open"]  = 1;
			types["land"]  = 2;
			types["water"] = 3;
			types["air"]   = 4;

			PPoints.editType = types[buf];

			if (PPoints.editType)
				pClient->Echo("Now editing type %s", buf);
			else
				pClient->Echo("Unknown type. Try open, land, water or air.");
		}
		else if (sscanf(args,"testmove %d",&i)==1)
		{
			pClient->Echo("Testing movement");

			CCreature *pTarget = NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_CREATURE,pClient->pPlayer->TargetID))
			{
				pTarget->MoveToPPoint(i);
			}
		}
		else
			pClient->Echo("Invalid command");
	}
/**/
/*	if (!strnicmp(attribute,"name",4))
	{
		CCreatureTemplate *pTemplate;
		if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Creature.Data.Template))
		{
			pClient->Echo("Creature template '%s' renamed to '%s'.  This takes effect for any new retrievals of the template.",pTemplate->Data.Name,newvalue);
			strncpy(pTemplate->Data.Name,newvalue,63);
			pTemplate->Data.Name[63]=0;
			strcpy(pTemplate->Data.Name1,pTemplate->Data.Name);
			strcpy(pTemplate->Data.Name2,pTemplate->Data.Name);
			strcpy(pTemplate->Data.Name3,pTemplate->Data.Name);
		}
		return;
	}*/

int getargs(char *str, char** argv, int maxargs)
{
	int argc = 0;
	char *ptr = str;
	bool inquote = false;
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
	if(command[0] == '%')
	{
		if(pClient->pAccount->Data.UserLevel>USER_NORMAL)
			ProcessGMCommand(pClient, &command[1]);
		else
			pClient->Echo("You do not have permission to use %% commands");
		return true;
	}
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

/*


void MsgChat(CClient *pClient, _InData *pData)
{
/*
______________________________________________________________
Outgoing Data :8086 len=0010 op=0095 int=0000 msglen=000C -- script_sendchatmessage

0000:  00 00 00 00-07 00 00 00-73 61 79 00-             ........say.    
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
Outgoing Data :8086 len=0012 op=0095 int=0000 msglen=000E -- script_sendchatmessage

0000:  01 00 00 00-07 00 00 00-70 61 72 74-79 00        ........party.  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
Outgoing Data :8086 len=0012 op=0095 int=0000 msglen=000E -- script_sendchatmessage

0000:  02 00 00 00-07 00 00 00-67 75 69 6C-64 00        ........guild.  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
Outgoing Data :8086 len=0011 op=0095 int=0000 msglen=000D -- script_sendchatmessage

0000:  04 00 00 00-07 00 00 00-79 65 6C 6C-00           ........yell.   
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
whisper:
______________________________________________________________
Outgoing Data :8086 len=0013 op=0095 int=0000 msglen=000F -- script_sendchatmessage

0000:  05 00 00 00-07 00 00 00-4C 61 78 00-68 69 00     ........Lax.hi. 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
Outgoing Data :8086 len=0012 op=0095 int=0000 msglen=000E -- script_sendchatmessage

0000:  07 00 00 00-07 00 00 00-65 6D 6F 74-65 00        ........emote.  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/
/*
	char updateBuffer[0x70];
	CUpdateBlock block;
	int outSize;
	char *ptr;

	switch(*(unsigned long*)&pData->Data[0])
	{
	case CHAT_SAY:
		{
			if (pData->Data[8]=='%')
			{
#ifndef ACCOUNTLESS
				if (pClient->pAccount->Data.UserLevel>USER_NORMAL)
				{
#endif
					ProcessGMCommand(pClient,&pData->Data[9]);// skip the %
#ifndef ACCOUNTLESS
				}
				else
				{
					pClient->Echo("You do not have permission to use %% commands");
				}
#endif
				return;
			}

			char *msg=&pData->Data[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->ChatSay(*(unsigned long*)&pData->Data[4],&pData->Data[8]);
				return;
			}
			else if (!strnicmp(&pData->Data[0x8],"weapon ",7))
			{
				char Name[256];
				if (sscanf(&pData->Data[0x8],"weapon %[^¦]",Name))
				{
					Name[63]=0;
					string lcase=Name;
					MakeLower(lcase);
					unsigned long Template=DataManager.ItemTemplates[lcase];
					if (!Template)
					{
						pClient->Echo("Unknown weapon");
						return;
					}

					CItemTemplate *pTemplate=0;
					if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,Template))
					{
						pClient->Echo("Unknown weapon");
						return;
					}

					if (pTemplate->Data.InvType!=WORN_1H && pTemplate->Data.InvType!=WORN_2H)
					{
						pClient->Echo("Unknown weapon");
						return;
					}

					{
						CItem *pItem=new CItem;
						pItem->New(Template,pClient->pPlayer->guid);
						DataManager.NewObject(*pItem);
						
						if (lcase == "rifle" || lcase == "wand" || lcase == "throwing knife")
						{
							pClient->pPlayer->Data.Items[SLOT_MAINHAND]=pItem->guid;
							pClient->pPlayer->Data.Items[SLOT_OFFHAND]=0;
							pClient->pPlayer->Data.Items[SLOT_RANGED]=pItem->guid;
						}
						else if (lcase == "bow")
						{
							pClient->pPlayer->Data.Items[SLOT_MAINHAND]=0;
							pClient->pPlayer->Data.Items[SLOT_OFFHAND]=pItem->guid;
							pClient->pPlayer->Data.Items[SLOT_RANGED]=pItem->guid;
						}
						else
						{
							pClient->pPlayer->Data.Items[SLOT_MAINHAND]=pItem->guid;
							pClient->pPlayer->Data.Items[SLOT_OFFHAND]=0;
							pClient->pPlayer->Data.Items[SLOT_RANGED]=0;
						}
						RegionManager.ObjectNew(*pItem,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
						block.ResetBlock(updateBuffer, 0x70);
						block.Add(PLAYER_INV_SLOTS+SLOT_MAINHAND*2, pClient->pPlayer->Data.Items[SLOT_MAINHAND], ITEMGUID_HIGH);
						block.Add(PLAYER_INV_SLOTS+SLOT_OFFHAND*2, pClient->pPlayer->Data.Items[SLOT_OFFHAND], ITEMGUID_HIGH);
						block.Add(PLAYER_INV_SLOTS+SLOT_RANGED*2, pClient->pPlayer->Data.Items[SLOT_RANGED], ITEMGUID_HIGH);
						ptr = block.GetCompressedData(outSize);
						if(outSize)
							pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, outSize);
					}
				}

			}
			else if (!stricmp(&pData->Data[0x8],"weapon"))
			{
				pClient->Echo("Valid weapons for this demonstration are quarterstaff, sword, axe, hammer, pick, mace, halberd, wand, flowers, bow, dirk, rifle, throwing knife, spear");
			}
			else if (!strnicmp(&pData->Data[0x8],"chest ",6))
			{
				char Name[256];
				if (sscanf(&pData->Data[0x8],"chest %[^¦]",Name))
				{
					Name[63]=0;
					string lcase=Name;
					MakeLower(lcase);
					unsigned long Template=DataManager.ItemTemplates[lcase];
					if (!Template)
					{
						pClient->Echo("Unknown chest item");
						return;
					}

					CItemTemplate *pTemplate=0;
					if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,Template))
					{
						pClient->Echo("Unknown chest item");
						return;
					}
					
					if (pTemplate->Data.InvType!=WORN_CHEST && pTemplate->Data.InvType!=WORN_ROBE)
					{
						pClient->Echo("Unknown chest item");
						return;
					}
					

					{
						CItem *pItem=new CItem;
						pItem->New(Template,pClient->pPlayer->guid);
						DataManager.NewObject(*pItem);
						
						pClient->pPlayer->Data.Items[SLOT_CHEST]=pItem->guid;
						block.ResetBlock(updateBuffer, 0x70);
						block.Add(PLAYER_INV_SLOTS+SLOT_CHEST*2, pClient->pPlayer->Data.Items[SLOT_CHEST], ITEMGUID_HIGH);
						ptr = block.GetCompressedData(outSize);
						if(outSize)
							pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, outSize);
					}
				}

			}
			else if (!stricmp(&pData->Data[0x8],"chest"))
			{
				pClient->Echo("Valid chest items for this demonstration are chainmail tunic, scalemail tunic, plate breastplate, gold plate breastplate, hawk tunic, samurai tunic, red robe");
			}
			else if (!stricmp(&pData->Data[0x8],"mount"))
			{
			}
			else if(!stricmp(&pData->Data[0x8],"createguild"))
			{
				pClient->Echo("Syntax: createguild <name>");
			}
			else
				pClient->ChatSay(*(unsigned long*)&pData->Data[4],&pData->Data[8]);
		}
		break;
	case CHAT_PARTY:
		{
			CParty *pParty = CParty::GetParty(pClient, true);
			if(pParty != NULL)
				pParty->PartyChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_GUILD:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->GuildChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_OFFICER:
		{
			CGuild *pGuild = CGuild::GetGuild(pClient);
			if(pGuild != NULL)
				pGuild->OfficerChannel(pClient, &pData->Data[0x08]);
		}
		break;
	case CHAT_YELL:
		pClient->ChatYell(*(unsigned long*)&pData->Data[4],&pData->Data[8]);
		break;
	case CHAT_WHISPER:
		{
			string Who=&pData->Data[8];
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",&pData->Data[8]);
				return;
			}
			CPlayer *pTo=0;
			if (!DataManager.RetrieveObject((CWoWObject**)&pTo,OBJ_PLAYER,PlayerID))
			{
				pClient->Echo("Player '%s' does not exist (error: exists in name cache but not in database).",&pData->Data[8]);
				return;
			}
			if (!pTo->pClient)
			{
				pClient->Echo("Player '%s' not online",&pData->Data[8]);
				return;
			}
			pTo->pClient->ChannelMessage(CHAT_WHISPER,&pData->Data[8+strlen(&pData->Data[8])+1],pClient->pPlayer->guid,0,0);
			pClient->Echo("You whisper to %s : %s",pTo->Data.Name,&pData->Data[8+strlen(&pData->Data[8])+1]);
			if (pTo->Data.StatusFlags == STATUS_AFK) {
				pClient->Echo("Player is AFK: %s", pTo->Data.StatusReason);
			}
			if (pTo->Data.StatusFlags == STATUS_DND) {
				pClient->Echo("Player Do Not Disturb: %s", pTo->Data.StatusReason);
			}
		}
		break;
	case CHAT_EMOTE:
		break;
	case CHAT_MOTD:
		break;
	case CHAT_AFK:
		{
			char *msg=&pData->Data[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}

			if (!pClient->pPlayer->Data.StatusFlags)
			{	
				pClient->pPlayer->Data.StatusFlags ^= STATUS_AFK;
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			else
			{
				pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;
				strcpy(pClient->pPlayer->Data.StatusReason, "");
			}
			pClient->SendPlayerData();
			RegionManager.ObjectResend(*(pClient->pPlayer));
		}
		break;
	case CHAT_DND:
		{
			char *msg=&pData->Data[0x8];
			if (strlen(msg)>100) // prevent buffer overflow from long names..
			{
				pClient->Echo("Reason message too long.");
				return;
			}

			if (!pClient->pPlayer->Data.StatusFlags)
			{
				pClient->pPlayer->Data.StatusFlags ^= STATUS_DND;
				strcpy(pClient->pPlayer->Data.StatusReason, msg);
			}
			else
			{
				pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;
				strcpy(pClient->pPlayer->Data.StatusReason, "");
			}
			pClient->SendPlayerData();
			RegionManager.ObjectResend(*(pClient->pPlayer));

		}
		break;
	default:
		pClient->Echo("This type of chat or emote is not yet implemented.");
		break;
	}
*/
/*
			else if (!strnicmp(msg,"warp ",5))
			{
				float X=0.0f, Y=0.0f, Z=0.0f;
				if (sscanf(msg,"warp %f %f %f",&X,&Y,&Z)==3)
				{
					char out[256];
					sprintf(out,"Warping to %.2f %.2f %.2f",X,Y,Z);
					pClient->ChannelMessage(9,out,0,0,*(unsigned long*)&pData->Data[4]);
					unsigned char buf[0x30]=
					{
 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x49,0x57,0x70,0x41,0x2C,0x19,0x00,0x42
,0x54,0x17,0x71,0x42,0x3C,0x27,0x99,0x3F,0x49,0x57,0x70,0x41,0x2C,0x19,0x00,0x42
,0x54,0x17,0x71,0x42,0x3C,0x27,0x99,0x3F,0x00,0x00,0x00,0x00,0x01,0x02,0x80,0x00
					};
					*(float*)&buf[0x08]=X;
					*(float*)&buf[0x0c]=Y;
					*(float*)&buf[0x10]=Z;
					// heading
					*(float*)&buf[0x18]=X;
					*(float*)&buf[0x1c]=Y;
					*(float*)&buf[0x20]=Z;
					// heading
					pClient->pPlayer->Data.Loc.X=X;
					pClient->pPlayer->Data.Loc.Y=Y;
					pClient->pPlayer->Data.Loc.Z=Z;
					pClient->OutPacket(MSG_MOVE_TELEPORT_ACK,buf,0x30);
				}
			}
			else
			{
			}
/**/
//}
