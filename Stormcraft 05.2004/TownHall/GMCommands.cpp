#include "Defines.h"
#include "Globals.h"
#include "Client.h"
#include "CreatureTemplate.h"
#include "Creature.h"
#include "DBCHandler.h"
#include "EventManager.h"



CFlyPathMob* GenerateFlyPathMob(unsigned long Model, const char *Name, 
	unsigned long Continent,_Location Loc, float Facing);
/*
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
}*/

void EditPlayer(CClient *pClient, CPlayer &Player, const char *attribute, const char *newvalue)
{

}

void EditCreature(CClient *pClient, CCreature &Creature, const char *attribute, const char *newvalue)
{
	if (!strnicmp(attribute,"hps",3))
	{
		Creature.Data.NormalStats.HitPoints=Creature.Data.CurrentStats.HitPoints=atoi(newvalue);
		RegionManager.ObjectResend(Creature);
		return;
	}
	if (!strnicmp(attribute,"dmg",3))
	{
		unsigned long Val1,Val2;
		if (sscanf(newvalue,"%d-%d",&Val1,&Val2)==2)
		{
			Creature.Data.DamageMin=Val1;
			Creature.Data.DamageMax=Val2;
		}
		return;
	}
	if (!strnicmp(attribute,"size",4))
	{
		unsigned long model_size;
		sscanf(newvalue,"%d",&model_size);
		if (model_size<3) // we have to retrieve the real max model size, i can do cow x30 size, but dragon max is like x2
		{
		sscanf(newvalue,"%g",&Creature.Data.Size);
		RegionManager.ObjectResend(Creature);
		}
		return;
	}
	if (!strnicmp(attribute,"model",5))
	{
		sscanf(newvalue,"%X",&Creature.Data.Model);
		RegionManager.ObjectResend(Creature);
		return;
	}
	if (!strnicmp(attribute,"exp",3))
	{
		Creature.Data.Exp=atoi(newvalue);
		return;
	}
	if (!strnicmp(attribute,"level",5))
	{
		Creature.Data.Level=atoi(newvalue);
		return;
	}
	if (!strnicmp(attribute,"name",4))
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
	}
	if(!strnicmp(attribute,"vendor",4))
	{
		unsigned long type = 0;
		if(!strnicmp(newvalue,"merchant", 8))
			type = NPCTYPE_MERCHANT;
		else if(!strnicmp(newvalue, "questgiver", 10))
			type = NPCTYPE_QUESTGIVER;
		else if(!strnicmp(newvalue, "taxi", 4))
			type = NPCTYPE_TAXI;
		else if(!strnicmp(newvalue, "trainer", 7))
			type = NPCTYPE_TRAINER;
		else if(!strnicmp(newvalue, "binder", 6))
			type = NPCTYPE_BINDER;
		else if(!strnicmp(newvalue, "banker", 6))
			type = NPCTYPE_BANKER;
		else if(!strnicmp(newvalue, "petitioner", 11))
			type = NPCTYPE_PETITION;
		else if(!strnicmp(newvalue, "tabard", 6))
			type = NPCTYPE_TABARD;
		else if(!strnicmp(newvalue, "none", 4))
			type = NPCTYPE_NONE;
		else
		{
			pClient->Echo("Valid vendor types are: none, merchant, questgiver, taxi, trainer, binder, banker, petitioner and tabard");
			return;
		}
		Creature.Data.NPCType = type;
		RegionManager.ObjectResend(Creature);
		pClient->Echo("Ok. Vendor type set to: %s", newvalue);
	}
	else if(!strnicmp(attribute, "faction", 7))
	{
		unsigned long val;
		if(sscanf(newvalue,"%X",&val))
		{
			Creature.Data.FactionTemplate = val;
			RegionManager.ObjectResend(Creature);
		}
	}	
}

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
	if (UserLevel>=Settings.UserLevels.Spawn && !strnicmp(command,"spawn ",6))
	{
		CRegion *pRegion = RegionManager.ObjectRegions[pClient->pPlayer->guid];
		if (!pRegion)
		{
			return;
		}
		unsigned long nSpawns=0;
		RegionObjectNode *pNode=pRegion->pList;
		while(pNode)
		{
			if (pNode->pObject->type==OBJ_CREATURE)
				nSpawns++;
			pNode=pNode->pNext;
		}
		if (UserLevel < USER_GM && nSpawns>14)
		{
			pClient->Echo("I think there's enough spawns in this immediate area, venture a little bit");
			return;
		}

		unsigned long Model=0;
		char Name[256];
		// need to be before the others otherwise it will parse "f" as model
		if (sscanf(command,"spawn flypathmob %X %[^¦]",&Model,Name)==2 && Model)
		{
			Name[63]=0;
			pClient->Echo("Spawning FlyPathMob with model %X named '%s'",Model,Name);
			
			CCreature *pCreature=GenerateFlyPathMob(Model,Name,pClient->pPlayer->Data.Continent,
					pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Facing);
			RegionManager.ObjectNew(*pCreature,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		} else if(sscanf(command, "spawn flypathmob %X", &Model) && Model)
		{
			pClient->Echo("Spawning FlyPathMob with model %X",Model);

			sprintf(Name,"FlyPathMob %X",Model);
			CCreature *pCreature=GenerateFlyPathMob(Model,Name,pClient->pPlayer->Data.Continent,
					pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Facing);
			RegionManager.ObjectNew(*pCreature,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		}
		else if (sscanf(command,"spawn %X %[^¦]",&Model,Name)==2 && Model)
		{
			//Name[63]=0;
			char *name = strtok(Name, " ");
			char *guild = NULL;
			if(name != NULL)
				guild = &Name[strlen(name)+1];
			else
				name = &Name[0];
			if(strlen(name) > 63)
				name[63] = 0;
			pClient->Echo("Spawning creature with model %X named '%s'",Model,Name);
			
			CCreature *pCreature=RealmServer.GenerateCreature(Model,name,pClient->pPlayer->Data.Continent,
					pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Facing);
			if(guild != NULL)
			{
				CCreatureTemplate *p=0;
				if (DataManager.RetrieveObject((CWoWObject**)&p,OBJ_CREATURETEMPLATE,pCreature->Data.Template))
				{
					strncpy(p->Data.Guild, guild, 63);
					p->Data.Guild[63] = 0;
				}
			}
			RegionManager.ObjectNew(*pCreature,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		} else if (sscanf(command,"spawn %X",&Model) && Model)
		{
			pClient->Echo("Spawning creature with model %X",Model);

			sprintf(Name,"Creature %X",Model);
			CCreature *pCreature=RealmServer.GenerateCreature(Model,Name,pClient->pPlayer->Data.Continent,
					pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Facing);
			RegionManager.ObjectNew(*pCreature,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		}
	}
	else if (UserLevel>=Settings.UserLevels.Spawn && !stricmp(command,"spawn"))
	{
			pClient->Echo("Syntax: spawn [model] [name]");
			pClient->Echo("Syntax: spawn flypathmob [model] [name]");
	}
	else if(UserLevel>=USER_HALFGM && !strnicmp(command,"edit ",5))
	{
		if (!strchr(&command[5],' '))
		{
			pClient->Echo("Syntax: edit [attribute] [new value]");
			pClient->Echo("Current attributes are: hps, dmg (min-max), size (0.01 to 2), model, exp, level, name");
			return;
		}
		char temp[2048];
		memset(temp,0,2048);
		strcpy(temp,&command[5]);
		strtok(temp," ");
		char *newvalue=&temp[strlen(temp)+1];
		
		CWoWObject *pTarget=0;
		if (DataManager.RetrieveObject(&pTarget,pClient->pPlayer->TargetID))
		{
			if (pTarget->type==OBJ_PLAYER)
			{
				EditPlayer(pClient,*(CPlayer*)pTarget,&command[5],newvalue);
			}
			else if (pTarget->type==OBJ_CREATURE)
			{
				EditCreature(pClient,*(CCreature*)pTarget,&command[5],newvalue);
			}
		}
	}
	else if (UserLevel>=USER_HALFGM && !stricmp(command,"edit"))
	{
			pClient->Echo("Syntax: edit [attribute] [new value]");
			pClient->Echo("Current attributes are: hps, dmg (min-max), size (0.01 to 2), model, exp, level, speed (0 to 50), name");
	}
	else if(UserLevel>=Settings.UserLevels.Rehash && !strnicmp(command,"rehash",15))
	{
		Settings.LoadSettings();
		pClient->Echo("Server Settings Rehashed");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"get ",4))
	{
		unsigned long Model=0;
		char Slot[256];
		unsigned long iSlot=0;
		// create an item template
		if (sscanf(command,"get %s %X",&Slot,&Model)==2 && Model)
		{
			CItemTemplate* pTemplate = new CItemTemplate;
			pTemplate->New();
			string sSlot=Slot;
			MakeLower(sSlot);
			if (sSlot == "head") {
				pTemplate->Data.InvType=WORN_HEAD;
				iSlot = SLOT_HEAD;
			}
			else if (sSlot == "shirt") {
				pTemplate->Data.InvType=WORN_SHIRT;
				iSlot = SLOT_SHIRT;
			}
			else if (sSlot == "chest") {
				pTemplate->Data.InvType=WORN_CHEST;
				iSlot = SLOT_CHEST;
			}
			else if (sSlot == "neck") {
				pTemplate->Data.InvType=WORN_NECK;
				iSlot = SLOT_NECK;
			}
			else if (sSlot == "shoulder") {
				pTemplate->Data.InvType=WORN_SHOULDER;
				iSlot = SLOT_SHOULDERS;
			}
			else if (sSlot == "waist") {
				pTemplate->Data.InvType=WORN_WAIST;
				iSlot = SLOT_WAIST;
			}
			else if (sSlot == "legs") {
				pTemplate->Data.InvType=WORN_PANTS;
				iSlot = SLOT_LEGS;
			}
			else if (sSlot == "feet") {
				pTemplate->Data.InvType=WORN_BOOTS;
				iSlot = SLOT_FEET;
			}
			else if (sSlot == "wrists") {
				pTemplate->Data.InvType=WORN_BRACERS;
				iSlot = SLOT_WRISTS;
			}
			else if (sSlot == "hands") {
				pTemplate->Data.InvType=WORN_HAND;
				iSlot = SLOT_HANDS;
			}
			else if (sSlot == "finger1") {
				pTemplate->Data.InvType=WORN_FINGER;
				iSlot = SLOT_FINGERL;
			}
			else if (sSlot == "finger2") {
				pTemplate->Data.InvType=WORN_FINGER;
				iSlot = SLOT_FINGERR;
			}
			else if (sSlot == "trinket1") {
				pTemplate->Data.InvType=WORN_TRINKET;
				iSlot = SLOT_TRINKETL;
			}
			else if (sSlot == "trinket2") {
				pTemplate->Data.InvType=WORN_TRINKET;
				iSlot = SLOT_TRINKETR;
			}
			else if (sSlot == "back") {
				pTemplate->Data.InvType=WORN_BACK;
				iSlot = SLOT_BACK;
			}
			else if (sSlot == "weapon1") {
				pTemplate->Data.InvType=WORN_MAINHAND;
				iSlot = SLOT_MAINHAND;
			}
			else if (sSlot == "weapon2") {
				pTemplate->Data.InvType=WORN_OFFHAND;
				iSlot = SLOT_OFFHAND;
			}
			else {
				pClient->Echo("Unknown location");
				return;
			}

			pTemplate->Data.DisplayID=Model; 
			DataManager.NewObject(*pTemplate);
			sprintf(pTemplate->Data.Name,"model %X (template %X)",Model,pTemplate->guid);
			DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;


			CItem *pItem = new CItem;
			pItem->New(pTemplate->guid,pClient->pPlayer->guid);
			DataManager.NewObject(*pItem);
			// Todo: What do we do if there is already an item in the slot??
			pClient->pPlayer->Data.Items[iSlot]=pItem->guid;
			RegionManager.ObjectNew(*pItem,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
			pClient->SendPlayerData();
			RegionManager.ObjectResend(*pClient->pPlayer);
			pClient->Echo("You have received item: %X",Model);
		}
		else {
			pClient->Echo("get <loc> <code>: locations for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger1, finger2, trinket1, trinket2, back, weapon1, weapon2");
		}
	}
	else if (UserLevel>=USER_GM && !stricmp(command,"get"))
	{
		pClient->Echo("get <loc> <code>: locations for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger1, finger2, trinket1, trinket2, back, weapon1, weapon2");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"item ",5))
	{
		unsigned long Model=0;
		unsigned long Slot=0;
		// create an item template
		if (sscanf(command,"item %X %X",&Slot,&Model)==2 && Model)
		{
			CItemTemplate* pTemplate = new CItemTemplate;
			pTemplate->New();
			switch(Slot)
			{
			case SLOT_HEAD:
				pTemplate->Data.InvType=WORN_HEAD;
				break;
			case SLOT_SHIRT:
				pTemplate->Data.InvType=WORN_SHIRT;
				break;
			case SLOT_CHEST:
				pTemplate->Data.InvType=WORN_CHEST;
				break;
			case SLOT_NECK:
				pTemplate->Data.InvType=WORN_NECK;
				break;
			case SLOT_SHOULDERS:
				pTemplate->Data.InvType=WORN_SHOULDER;
				break;
			case SLOT_WAIST:
				pTemplate->Data.InvType=WORN_WAIST;
				break;
			case SLOT_LEGS:
				pTemplate->Data.InvType=WORN_PANTS;
				break;
			case SLOT_FEET:
				pTemplate->Data.InvType=WORN_BOOTS;
				break;
			case SLOT_WRISTS:
				pTemplate->Data.InvType=WORN_BRACERS;
				break;
			case SLOT_HANDS:
				pTemplate->Data.InvType=WORN_HAND;
				break;
			case SLOT_FINGERL:
			case SLOT_FINGERR:
				pTemplate->Data.InvType=WORN_FINGER;
				break;
			case SLOT_TRINKETL:
			case SLOT_TRINKETR:
				pTemplate->Data.InvType=WORN_TRINKET;
				break;
			case SLOT_BACK:
				pTemplate->Data.InvType=WORN_BACK;
				break;
			case SLOT_MAINHAND:
				pTemplate->Data.InvType=WORN_MAINHAND;
				break;
			case SLOT_OFFHAND:
				pTemplate->Data.InvType=WORN_OFFHAND;
				break;
			default:
				pTemplate->Data.InvType=WORN_SHIRT;
				break;
			}
			pTemplate->Data.DisplayID=Model; 
			DataManager.NewObject(*pTemplate);
			sprintf(pTemplate->Data.Name,"model %X (template %X)",Model,pTemplate->guid);
			DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;


			CItem *pItem = new CItem;
			pItem->New(pTemplate->guid,pClient->pPlayer->guid);
			DataManager.NewObject(*pItem);
			pClient->pPlayer->Data.Items[Slot]=pItem->guid;

			pClient->SendPlayerData();
			pClient->Echo("You have received item: %X in slot %X",Model, Slot);
		}
	}
	else if (!strnicmp(command,"morph ",6))
	{
		unsigned long Model=0;
		if (sscanf(command,"morph %X",&Model)==1 && Model)
		{
			pClient->pPlayer->Data.Model = Model;

			pClient->SendPlayerData();
			RegionManager.ObjectResend(*pClient->pPlayer);
			pClient->Echo("You have morphed into model: %X",Model);
		}
	}
	else if (UserLevel>=USER_HALFGM && !stricmp(command,"uber"))
	{
		if (pClient->pPlayer->Data.StatusFlags >= STATUS_GM) 
		{
			// TODO: reload stat from Datamanager 
			pClient->pPlayer->Data.StatusFlags = STATUS_NORMAL;

			pClient->pPlayer->Data.NormalStats.HitPoints = 200;
			pClient->pPlayer->Data.NormalStats.Mana = 500;
			pClient->pPlayer->Data.NormalStats.Focus = 100;
			pClient->pPlayer->Data.NormalStats.Energy = 1000;
			pClient->pPlayer->Data.NormalStats.Rage = 10;

			pClient->pPlayer->Data.CurrentStats.HitPoints = 200;
			pClient->pPlayer->Data.CurrentStats.Mana = 500;
			pClient->pPlayer->Data.CurrentStats.Focus = 100;
			pClient->pPlayer->Data.CurrentStats.Energy = 1000;
			pClient->pPlayer->Data.CurrentStats.Rage = 10;

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

		pClient->SendPlayerData();
		RegionManager.ObjectResend(*(pClient->pPlayer));
		pClient->Echo("GM status %s",pClient->pPlayer->Data.StatusFlags >= STATUS_GM ? "Enabled" : "Disabled");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"deathtouch ",11))
	{
		char name[256];
		if (sscanf(command,"deathtouch %s",name)==1)
		{
			string Who=name;
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
				return;
			}
			CPlayer *pTarget=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
			{
				if (!pTarget->pClient)
				{
					pClient->Echo("Player '%s' not online.",name);
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
								((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO, packet, sizeof(packet));
							break;
							}
							pNode=pNode->pNext;
						}
					}
				}
				if (pTarget->pClient->pPlayer->Data.CurrentStats.HitPoints <= 0)
				{
					pTarget->pClient->pPlayer->ClearEvents();
				}
				RegionManager.ObjectResend(*(pTarget->pClient->pPlayer));
				pTarget->pClient->SendPlayerData();
				pClient->Echo("Player %s has been touched with death",pTarget->Data.Name);
			}
		}
	}
	else if (UserLevel>=USER_GM && !stricmp(command,"deathtouch"))
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
							RegionManager.ObjectResend(*(((CPlayer*)pNode->pObject)->pClient->pPlayer));
							((CPlayer*)pNode->pObject)->pClient->SendPlayerData();
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
	else if (!stricmp(command,"maxsent"))
	{
		pClient->Echo("MaxSent=%d",RealmServer.MaxSent);
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"broadcast ",10))
	{
		if (strlen(&command[10])>2)
		{
			char temp[2048];
			sprintf(temp,"<GM-%s BROADCAST> %s",pClient->pPlayer->Data.Name,&command[10]);
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
	else if (!strnicmp(command,"userlevel ",10))
	{
		char name[256];
		char InputLevel[256];
		unsigned long PlayerID;
		if (sscanf(command,"userlevel %s %s",name, InputLevel)==2)
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
			pClient->Echo("Syntax: userlevel <name> <user level>");
			return;
		}
		
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
		{
			if (pTarget==pClient->pPlayer)
			{
				pClient->Echo("Cannot change your own account status");
				return;
			}
			if (!pTarget->pClient)
			{
				pClient->Echo("Player %s not online",pTarget->Data.Name);
				return;
			}
			long OldLevel=pTarget->pClient->pAccount->Data.UserLevel;
			if (OldLevel>UserLevel)
			{
				pClient->Echo("Cannot change account status of higher ranking users.");
				return;
			}

			char NewLevel=0;
			if (!stricmp(InputLevel,"admin"))
				NewLevel=USER_ADMIN;
			else if (!stricmp(InputLevel,"GM"))
				NewLevel=USER_GM;
			else if (!stricmp(InputLevel,"half-GM"))
				NewLevel=USER_HALFGM;
			else if (!stricmp(InputLevel,"halfGM"))
				NewLevel=USER_HALFGM;
			else if (!stricmp(InputLevel,"supermod"))
				NewLevel=USER_SUPERMOD;
			else if (!stricmp(InputLevel,"moderator"))
				NewLevel=USER_MODERATOR;
			else if (!stricmp(InputLevel,"mod"))
				NewLevel=USER_MODERATOR;
			else if (!stricmp(InputLevel,"normal"))
				NewLevel=USER_NORMAL;
			else if (!stricmp(InputLevel,"ban"))
				NewLevel=USER_BANNED;
			else if (!stricmp(InputLevel,"suspend"))
				NewLevel=USER_SUSPENDED;
			else if (!stricmp(InputLevel,"delete"))
				NewLevel=USER_DELETE;
			else
			{
				pClient->Echo("Unknown userlevel '%s'",InputLevel);
				return;
			}

			if (NewLevel>UserLevel)
			{
				pClient->Echo("Cannot promote users beyond your own user level.");
			}
			if (NewLevel<OldLevel && OldLevel<USER_ADMIN)// demotion...
			{
				if ( (UserLevel<USER_ADMIN && (OldLevel==USER_GM))  ||
					 (UserLevel<USER_GM && (OldLevel==USER_MODERATOR || OldLevel==USER_HALFGM))
					)
				{
					pClient->Echo("Insufficient user level to demote user.");
					return;
				}
			}
			switch(NewLevel)
			{
			case USER_ADMIN:
				if (pClient->pAccount->Data.UserLevel<USER_ADMIN)
				{
					pClient->Echo("Only Administrators can assign other administrators.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_ADMIN;
					pTarget->pClient->Echo("Your account has been given Administrator status.");
					pClient->Echo("%s has been given Administrator status.",pTarget->Data.Name);
				}
				break;
			case USER_GM:
				if (pClient->pAccount->Data.UserLevel<USER_ADMIN)
				{
					pClient->Echo("Only Administrators can assign GMs.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_GM;
					pTarget->pClient->Echo("Your account has been given GM status.");
					pClient->Echo("%s has been given GM status.",pTarget->Data.Name);
				}
				break;
			case USER_HALFGM:
				if (pClient->pAccount->Data.UserLevel<USER_GM)
				{
					pClient->Echo("Only GM or greater can assign Half-GMs.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_HALFGM;
					pTarget->pClient->Echo("Your account has been given Half-GM status.");
					pClient->Echo("%s has been given Half-GM status.",pTarget->Data.Name);
				}
				break;
			case USER_SUPERMOD:
				if (pClient->pAccount->Data.UserLevel<USER_GM)
				{
					pClient->Echo("Only GM or greater can assign Super Moderators.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_SUPERMOD;
					pTarget->pClient->Echo("Your account has been given Super Moderator status.");
					pClient->Echo("%s has been given Super Moderator status.",pTarget->Data.Name);
				}
				break;
			case USER_MODERATOR:
				if (pClient->pAccount->Data.UserLevel<USER_GM)
				{
					pClient->Echo("Only GM or greater can assign Moderators.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_MODERATOR;
					pTarget->pClient->Echo("Your account has been given Moderator status.");
					pClient->Echo("%s has been given Moderator status.",pTarget->Data.Name);
				}
				break;
			case USER_NORMAL:
				if (pClient->pAccount->Data.UserLevel<USER_MODERATOR)
				{
					pClient->Echo("Only Moderator or greater can assign Normal-User status.",InputLevel);
				}
				else
				{
					pTarget->pClient->pAccount->Data.UserLevel=USER_NORMAL;
					pTarget->pClient->Echo("Your account has been given Normal status.");
					pClient->Echo("%s has been given Normal status.",pTarget->Data.Name);
				}
				break;
			case USER_SUSPENDED:
				pTarget->pClient->pAccount->Data.UserLevel=USER_SUSPENDED;
				pTarget->pClient->Echo("Your account has been given Suspended status.");
				pClient->Echo("%s has been given Suspended status.",pTarget->Data.Name);
				break;
			case USER_BANNED:
				pTarget->pClient->pAccount->Data.UserLevel=USER_BANNED;
				pTarget->pClient->Echo("Your account has been given Banned status.");
				pClient->Echo("%s has been given Banned status.",pTarget->Data.Name);
				break;
			case USER_DELETE:
				pTarget->pClient->pAccount->Data.UserLevel=USER_DELETE;
				pTarget->pClient->Echo("Your account has been given Pending Delete status.");
				pClient->Echo("%s has been given Pending Delete status.",pTarget->Data.Name);
				break;
			}
			DataManager.StoreObject(*pTarget->pClient->pAccount);
		}
		else
		{
			pClient->Echo("Invalid target for gm command");
			return;
		}
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"resetplayer ",12))
	{
		char name[256];
		if (sscanf(command,"resetplayer %s",name)==1)
		{
			string Who=name;
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
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
					pTarget->pClient->SendPlayerData();
					RegionManager.ObjectResend(*pTarget);
				}
				pClient->Echo("Player %s reset",pTarget->Data.Name);
			}
		}
	}
/**
	else if (!strnicmp(command,"resetplayer",11))
	{
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,TargetID))
		{
			pTarget->Data.ResurrectionSickness = false;
			pTarget->Data.PvP = false;
			pTarget->Data.RecentPvP = false;
			pTarget->Data.CurrentStats.HitPoints = pTarget->Data.NormalStats.HitPoints;
			pTarget->Data.CurrentStats.Mana = pTarget->Data.NormalStats.Mana;

			pTarget->pClient->SendPlayerData();
			RegionManager.ObjectResend(*pTarget->pClient->pPlayer);
			pClient->Echo("Player %s reset",pTarget->Data.Name);
		}
	}
**/
	else if (UserLevel>=USER_GM && !strnicmp(command,"killplayer ",11))
	{
		char name[256];
		if (sscanf(command,"killplayer %s",name)==1)
		{
			string Who=name;
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
				return;
			}
			CPlayer *pTarget=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
			{
				if (pTarget->pClient)
				{
					pClient->Echo("Player %s killed",pTarget->Data.Name);
					pTarget->pClient->DestroyMe=true;
				}
				else
				{
					pClient->Echo("Player %s not online",pTarget->Data.Name);
				}
			}
		}
	}
/*
	else if (!strnicmp(command,"killplayer",10))
	{
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,TargetID))
		{
			pTarget->pClient->DestroyMe=true;
			pClient->Echo("Player %s killed",pTarget->Data.Name);
		}
	}
*/
	else if (UserLevel>=USER_GM && !strnicmp(command,"give ",5))
	{
		char name[256];
		unsigned long Model=0;
		char Slot[256];
		unsigned long iSlot=0;
		unsigned long PlayerID;
		if (sscanf(command,"give %s %s %X",name,&Slot,&Model)==3 && Model && Model != 0x78B)
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
			pClient->Echo("Syntax: give <name> <slot> <item model>");
			return;
		}
		
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
		{
			if (!pTarget->pClient)
			{
				pClient->Echo("Player '%s' not online.",name);
				return;
			}
			if ((pTarget->guid == pClient->pPlayer->guid || pTarget->pClient->pAccount->Data.UserLevel >= USER_MODERATOR) && UserLevel <= USER_SUPERMOD)
			{
				pClient->Echo("This command is meant for giving out quest rewards.");
				return;
			}
			// create an item template
			if (Model && Model != 0x78B)
			{
				CItemTemplate* pTemplate = new CItemTemplate;
				pTemplate->New();
				string sSlot=Slot;
				MakeLower(sSlot);
				if (sSlot == "head") {
					pTemplate->Data.InvType=WORN_HEAD;
					iSlot = SLOT_HEAD;
				}
				else if (sSlot == "shirt") {
					pTemplate->Data.InvType=WORN_SHIRT;
					iSlot = SLOT_SHIRT;
				}
				else if (sSlot == "chest") {
					pTemplate->Data.InvType=WORN_CHEST;
					iSlot = SLOT_CHEST;
				}
				else if (sSlot == "neck") {
					pTemplate->Data.InvType=WORN_NECK;
					iSlot = SLOT_NECK;
				}
				else if (sSlot == "shoulder") {
					pTemplate->Data.InvType=WORN_SHOULDER;
					iSlot = SLOT_SHOULDERS;
				}
					else if (sSlot == "waist") {
					pTemplate->Data.InvType=WORN_WAIST;
					iSlot = SLOT_WAIST;
				}
				else if (sSlot == "legs") {
					pTemplate->Data.InvType=WORN_PANTS;
					iSlot = SLOT_LEGS;
				}
				else if (sSlot == "feet") {
					pTemplate->Data.InvType=WORN_BOOTS;
					iSlot = SLOT_FEET;
				}
				else if (sSlot == "wrists") {
					pTemplate->Data.InvType=WORN_BRACERS;
					iSlot = SLOT_WRISTS;
				}
				else if (sSlot == "hands") {
					pTemplate->Data.InvType=WORN_HAND;
					iSlot = SLOT_HANDS;
				}
				else if (sSlot == "finger1") {
					pTemplate->Data.InvType=WORN_FINGER;
					iSlot = SLOT_FINGERL;
				}
				else if (sSlot == "finger2") {
					pTemplate->Data.InvType=WORN_FINGER;
					iSlot = SLOT_FINGERR;
				}
				else if (sSlot == "trinket1") {
					pTemplate->Data.InvType=WORN_TRINKET;
					iSlot = SLOT_TRINKETL;
				}
				else if (sSlot == "trinket2") {
					pTemplate->Data.InvType=WORN_TRINKET;
					iSlot = SLOT_TRINKETR;
				}
				else if (sSlot == "back") {
					pTemplate->Data.InvType=WORN_BACK;
					iSlot = SLOT_BACK;
				}
				else if (sSlot == "weapon1") {
					pTemplate->Data.InvType=WORN_MAINHAND;
					iSlot = SLOT_MAINHAND;
				}
				else if (sSlot == "weapon2") {
					pTemplate->Data.InvType=WORN_OFFHAND;
					iSlot = SLOT_OFFHAND;
				}
				else {
					pClient->Echo("Unknown location");
					return;
				}

				pTemplate->Data.DisplayID=Model; 
				DataManager.NewObject(*pTemplate);
				sprintf(pTemplate->Data.Name,"model %X (template %X)",Model,pTemplate->guid);
				DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;


				CItem *pItem = new CItem;
				pItem->New(pTemplate->guid,pTarget->guid);
				DataManager.NewObject(*pItem);
				// Todo: What do we do if there is already an item in the slot??
				pTarget->Data.Items[iSlot]=pItem->guid;

				RegionManager.ObjectNew(*pItem,pTarget->pClient->pPlayer->Data.Continent,pTarget->pClient->pPlayer->Data.Loc.X,pTarget->pClient->pPlayer->Data.Loc.Y);
				pTarget->pClient->SendPlayerData();
				RegionManager.ObjectResend(*pTarget);
				pTarget->pClient->Echo("You have received a new item.");
				pClient->Echo("Player %s received item %X",pTarget->Data.Name,Model);
			}
			else
			{
				pClient->Echo("give <name> <loc> <code>: locations for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger1, finger2, trinket1, trinket2, back, weapon1, weapon2");
				return;
			}
		}
		else
		{
			pClient->Echo("Invalid target for gm command");
			return;
		}

	}
	else if (UserLevel>=USER_GM && !stricmp(command,"give"))
	{
		pClient->Echo("give <name> <loc> <code>: locations for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger1, finger2, trinket1, trinket2, back, weapon1, weapon2");
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"strip ",6))
	{
		char name[256];
		char Slot[256];
		unsigned long iSlot=0;
		unsigned long PlayerID;
		if (sscanf(command,"strip %s %s",name,&Slot)==2)
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
			pClient->Echo("Syntax: strip <name> <slot>");
			return;
		}
		
		CPlayer *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,PlayerID))
		{
			if (!pTarget->pClient)
			{
				pClient->Echo("Player '%s' not online.",name);
				return;
			}
			else {
				string sSlot=Slot;
				MakeLower(sSlot);
				if (sSlot == "head") {
					iSlot = SLOT_HEAD;
				}
				else if (sSlot == "shirt") {
					iSlot = SLOT_SHIRT;
				}
				else if (sSlot == "chest") {
					iSlot = SLOT_CHEST;
				}
				else if (sSlot == "neck") {
					iSlot = SLOT_NECK;
				}
				else if (sSlot == "shoulder") {
					iSlot = SLOT_SHOULDERS;
				}
				else if (sSlot == "waist") {
					iSlot = SLOT_WAIST;
				}
				else if (sSlot == "legs") {
					iSlot = SLOT_LEGS;
				}
				else if (sSlot == "feet") {
					iSlot = SLOT_FEET;
				}
				else if (sSlot == "wrists") {
					iSlot = SLOT_WRISTS;
				}
				else if (sSlot == "hands") {
					iSlot = SLOT_HANDS;
				}
				else if (sSlot == "finger1") {
					iSlot = SLOT_FINGERL;
				}
				else if (sSlot == "finger2") {
					iSlot = SLOT_FINGERR;
				}
				else if (sSlot == "trinket1") {
					iSlot = SLOT_TRINKETL;
				}
				else if (sSlot == "trinket2") {
					iSlot = SLOT_TRINKETR;
				}
				else if (sSlot == "back") {
					iSlot = SLOT_BACK;
				}
				else if (sSlot == "weapon1") {
					iSlot = SLOT_MAINHAND;
				}
				else if (sSlot == "weapon2") {
					iSlot = SLOT_OFFHAND;
				}
				else {
					pClient->Echo("Unknown location");
					return;
				}

				// Todo: What do we do if there is already an item in the slot??
				pTarget->Data.Items[iSlot]=0x00;
	
				pTarget->pClient->SendPlayerData();
				RegionManager.ObjectResend(*pTarget);
				pTarget->pClient->Echo("Your %s item was removed",Slot);
				pClient->Echo("The %s item was removed from player %s ",Slot,pTarget->Data.Name);
			}
		}
		else
		{
			pClient->Echo("Invalid target for gm command");
			return;
		}

	}
	else if (UserLevel>=USER_GM && !stricmp(command,"strip"))
	{
		pClient->Echo("strip <name> <loc>: locations for this demonstration are head, shirt, chest, neck, shoulder, waist, legs, feet, wrists, hands, finger1, finger2, trinket1, trinket2, back, weapon1, weapon2");
	}
	else if (UserLevel>=USER_HALFGM && !strnicmp(command,"killspawn",9))
	{
		CCreature *pTarget=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_CREATURE,pClient->pPlayer->TargetID))
		{
			pTarget->Delete();
			pClient->Echo("Spawn killed");
		}
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"morphtarget ",12))
	{
		unsigned long Model=0;
		char name[256];
		
		if (sscanf(command,"morphtarget %s %X",name,&Model)==2 && Model)
		{
			string Who=name;
			MakeLower(Who);
			unsigned long PlayerID=DataManager.PlayerNames[Who];
			if (!PlayerID)
			{
				pClient->Echo("Player '%s' does not exist.",name);
				return;
			}
			CPlayer *pTarget2=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pTarget2,OBJ_PLAYER,PlayerID))
			{
				if (!pTarget2->pClient)
				{
					pClient->Echo("Player '%s' not online.",name);
					return;
				}
				pTarget2->Data.Model = Model;
				pTarget2->pClient->SendPlayerData();
				RegionManager.ObjectResend(*pTarget2);
				pClient->Echo("Player morphed into model: %X",Model);
				return;
			}
		}
		else if (sscanf(command,"morphtarget %X",&Model)==1 && Model)
		{
			CCreature *pTarget=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_CREATURE,pClient->pPlayer->TargetID))
			{
				pTarget->Data.Model = Model;
				RegionManager.ObjectResend(*pTarget);
				pClient->Echo("Creature morphed into model: %X",Model);
				return;
			}
		}
	}
	else if (UserLevel>=USER_GM && !strnicmp(command,"mountmodel ",11))
	{
		unsigned long Model=0;
		if (sscanf(command,"mountmodel %X",&Model)==1 && Model)
		{
			pClient->pPlayer->Data.MountModel = Model;

			if (pClient->pPlayer->Data.MountModel)
			{
				pClient->pPlayer->Data.MountModel = 0;
				pClient->SendPlayerData();
				RegionManager.ObjectResend(*pClient->pPlayer);
			}

			pClient->SendPlayerData();
			RegionManager.ObjectResend(*pClient->pPlayer);
			pClient->Echo("You have mounted model: %X",Model);
		}
	}
	else if (UserLevel>=USER_SUPERMOD && !strnicmp(command,"getposition ",12)) {
		char name[256];
		unsigned long PlayerID;
		if (sscanf(command,"getposition %s",name)==1)
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
			pClient->Echo("Syntax: getposition <name>");
			return;
		}
		
		CPlayer *pPlayer=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,PlayerID))
		{
			if (!pPlayer->pClient)
			{
				pClient->Echo("Player '%s' not online.",name);
				return;
			}
			pClient->Echo("%s is at continent %d (%.2f,%.2f,%.2f)",name,pPlayer->Data.Continent,pPlayer->Data.Loc.X,pPlayer->Data.Loc.Y,pPlayer->Data.Loc.Z);
		}
	}
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
