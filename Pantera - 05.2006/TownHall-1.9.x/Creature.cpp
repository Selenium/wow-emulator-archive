#include "Creature.h"
#include "Globals.h"
#include "UpdateBlock.h"
#include "Party.h"
#include "Spell.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "MsgHandlers.h"
#include "DataManager.h"
#include "Quest.h"
#include "Player.h"
#include "QuestFunctions.h"
#include "dbc_structs.h"

CCreature::CCreature(void):CWoWObject(OBJ_CREATURE), CUpdateObject(NUM_UNIT_FIELDS)
{
	DataObject.pObject = this;
	AI_Initialized = false;
	pTemplate=0;
	bIsTaxi=false;
	bIsSummon = false;
	PetAction1 = 0;
	PetAction2 = 0;
	PetAction3 = 0;
	AI_HasCalledForHelp = 0;
	AI_Hostile = 0;
	ResetAllAuras();
}

CCreature::~CCreature(void)
{
	//	RegionManager.ObjectRemove(*this);
	CCreature::Delete();
}
// AI FRAMEWORK: Burlex

void CCreature::AI_Initialize()
{
	// here, load points and scripts from files.

	AI_CurrentPoint = 0;
	AI_Busy = false;
	// AI_GossipType = 0;
	AI_Moving = false;
	AI_ActionCount = 0;
	AI_ScriptPresent = false;
	AI_CreatureMoveSpeed = 2.5f;
	//	AI_TalkText = "";
	AI_AgroScale = 0;
	AI_CanTalk = 0;
	AI_TalkEmote = 0;
	AI_Activated = false;
	AI_UpdateFrequency = 2000;	// 2 seconds update freqency

	// open and parse file
	char filetoopen[96];
	sprintf(filetoopen, "data/scripts/%u.txt", guid);
	FILE *file=NULL;
	if(_FileExists(filetoopen)) file=fopen(filetoopen, "rt"); // open it *only if* we can find the file

	if (!file)
	{
		// try other
		sprintf(filetoopen, "data/scripts/%s.txt", pTemplate->Data.Name);
		if(!_FileExists(filetoopen))
			return; // oops, we just lost the last file, good bye!
		if (!(file=fopen(filetoopen, "rt")))
			return;		// creature has no script.
	}

	_AIAction action;

	// we have the script file, so loop it and add actions
	char LogText[100];
	sprintf(LogText, "AI: Processing script for NPC %u (%s)                ", guid, pTemplate->Data.Name);
	Debug.Logf(LogText);
	char commandtext[64];
	while (fgets(commandtext,60,file))
	{
		commandtext[strlen(commandtext)-1]=0;
		// process
		char *command = strtok(commandtext, " ");
		char *arguments = &commandtext[strlen(command)+1];
		action.Command = 0;

		if (!strncmp(command,"wait",4))
		{
			action.Command = CREATURE_AICMD_WAIT;
			action.Data1 = atoi(arguments);
		}
		else if (!strncmp(command,"say",4))
		{
			action.Command = CREATURE_AICMD_SAY;
			action.Text = arguments;
		}
		else if (!strncmp(command,"emote",4))
		{
			action.Command = CREATURE_AICMD_EMOTE;
			action.Emote = atoi(arguments);
		}
		else if (!strncmp(command,"sayemote",4))
		{
			action.Command = CREATURE_AICMD_SAYEMOTE;
			char *text = strtok(arguments, ",");
			char *emotenumber = &commandtext[strlen(text)+1];
			// strncpy(action.Text,text,59);
			action.Text = text;
			action.Data1 = atoi(emotenumber);
		}
		else if (!strncmp(command,"moveto",6))
		{
			action.Command = CREATURE_AICMD_MOVETO;
			float xpos = (float)atof(strtok(arguments, " "));
			float ypos = (float)atof(strtok(NULL, " "));
			float zpos = (float)atof(strtok(NULL, " "));
			action.Location.X = xpos;
			action.Location.Y = ypos;
			action.Location.Z = zpos;
		}
		else if (!strncmp(command,"repeatemote",11))
		{
			action.Command = CREATURE_AICMD_REPEATEMOTE;
			action.Emote = atoi(strtok(arguments, " "));
			action.Data1 = atoi(strtok(NULL, " "));
			action.Data2 = atoi(strtok(NULL, " "));
		}
		else if (!strncmp(command,"setmovespeed",12))
		{
			AI_CreatureMoveSpeed = (float)atof(arguments);
		}
		else if (!strncmp(command,"settalktext",11))
		{
			// set talk text
			//strncpy(AI_TalkText,arguments,79);
			AI_TalkText = arguments;
			AI_CanTalk = true;
		}
		else if (!strncmp(command,"settalkemote",12))
		{
			// talking emote
			AI_TalkEmote = atoi(arguments);
			AI_CanTalk = true;
		}
		else if (!strncmp(command,"hardagro",8))
		{
			// set easyness-to-agro to full
			AI_AgroScale = 100;
		}
		else if (!strncmp(command,"noagro",6))
		{
			// non-aggressive creature
			AI_AgroScale = 0;
		}
		else if (!strncmp(command,"setagro",7))
		{
			// set agro
			AI_AgroScale = atoi(arguments);
		}
		else if (!strncmp(command, "#",1))
		{
			continue; // ignore commented lines
		}
		else if (!strncmp(command, "addmenuitem",11))
		{
			_GossipItem gossipitem;
			gossipitem.Icon = atoi(strtok(arguments, "|"));
			gossipitem.Inputbox = atoi(strtok(NULL, "|"));
			gossipitem.HandlerID = atoi(strtok(NULL, "|"));
			gossipitem.Data1 = atoi(strtok(NULL, "|"));
			gossipitem.Data2 = atoi(strtok(NULL, "|"));
			strncpy(gossipitem.Message, strtok(NULL, "|"),59);
			gossipitem.Message[60] = 0;
		}
		else
		{
			Debug.Logf("AI Engine: Creature %s: Unknown Command %s in Script File %s!",pTemplate->Data.Name,command,filetoopen);
		}
		if (action.Command)
		{
			AI_Actions[AI_ActionCount++] = action;
		}
	}
	fclose(file);
	AI_ScriptPresent = true;
	AI_Busy = false;
	ResetAllAuras();

	return;
}

bool CCreature::AI_KeepActive()
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient))
					{
						return true;
					}
					pNode=pNode->pNext;
				}
			}
		}
		AI_Activated = false;
		return false;
}
void CCreature::AI_Activate()
{
	AI_Activated = true;
	EventManager.AddEvent(*this, 10000, EVENT_CREATURE_AIUPDATE, 0,0);
}

void CCreature::AI_Deactivate()
{
	AI_Activated = false;
}

bool CCreature::AI_Update()
{
	// check for nearby players
	AI_WalkInProximity(NULL);

	// waypoints
	if(FirstPoint && !CurrentPoint)
	{
		std::map<unsigned long,Waypoint>::iterator i;
		i=RealmServer.Waypoints.find(FirstPoint);
		if(i==RealmServer.Waypoints.end())
		{
			Debug.Logf("Creature %i [%s] tried move to a nonexistant waypoint (%i)!",guid,pTemplate->Data.Name,FirstPoint);
			return true; // don't want you to wander anyway
		}
		//Debug.Logf("Moving to first point = %d, location = %f %f %f from %f %f %f",FirstPoint,i->second.Point.X,i->second.Point.Y,i->second.Point.Z,Data.Loc.X,Data.Loc.Y,Data.Loc.Z);
		Move(&(i->second.Point),AI_CreatureMoveSpeed);
		CurrentPoint = (i->second).NextPoint;
		return true;
	}
	if(CurrentPoint)
	{
		std::map<unsigned long,Waypoint>::iterator i;
		i=RealmServer.Waypoints.find(CurrentPoint);
		if(i==RealmServer.Waypoints.end())
		{
			Debug.Logf("Creature %i [%s] tried move to nonexistant waypoint (%i)!",guid,pTemplate->Data.Name,FirstPoint);
			return true; // don't want you to wander anyway
		}
		//Debug.Logf("Moving to point = %d, location = %f %f %f from %f %f %f",CurrentPoint,i->second.Point.X,i->second.Point.Y,i->second.Point.Z,Data.Loc.X,Data.Loc.Y,Data.Loc.Z);
		Move(&(i->second.Point),AI_CreatureMoveSpeed);
		CurrentPoint = (i->second).NextPoint;
		return true;
	}

	//if (!AI_Activated)
	//	return false;

	if(bIsSummon)
	{
		// Is pet, handle AI here.
		if(PetAction1 == 1)
		{
			// Attack.. meh
			return true;
		}
		if(PetAction1 == 2)
		{
			// Follow
			if(summoner)
			{
				Move(&summoner->Data.Loc,3.0f);
				Debug.Log("AI: Moving pet/following player");
			}
			return true;
		}
		if(PetAction3 == 3)
		{
			// Stay.. do nothing I guess
			return true;
		}
	}

	if (AI_Actions.size() < 1)	// this stuff is only if it has a script file.. ;)
		return false;

	// called on regular intervals, would be good to check for nearby players and if so attack them ^^
	unsigned char curpos = AI_CurrentPoint;
	if (AI_CurrentPoint >= AI_ActionCount)
	{
		curpos = AI_ActionCount;
		AI_CurrentPoint = 0;
	}

	// move to next point

	if (!AI_Busy)
	{
		AI_CurrentPoint++;
		// do next action
		if (curpos > AI_Actions.size())
		{
			AI_CurrentPoint = 1;
			curpos = 1;
		}
		switch (AI_Actions[curpos].Command)
		{
		case CREATURE_AICMD_WAIT:
			{
				// Wait..
				Debug.Log("AI: Waiting.");
				EventManager.AddEvent(*this, AI_Actions[curpos].Data1, EVENT_CREATURE_AIUNBUSY, NULL, 0);
				AI_Busy = true;
				return true;
			}
			break;

		case CREATURE_AICMD_MOVETO:
			{
				// Move to location
				char debugtext[150];
				sprintf(debugtext, "AI: %s - CREATURE_AICMD_MOVETO (Action %d) moving to %f %f %f", pTemplate->Data.Name, curpos, AI_Actions[curpos].Location.X, AI_Actions[curpos].Location.Y, AI_Actions[curpos].Location.Z);
				Debug.Log(debugtext);
				Move(&AI_Actions[curpos].Location, AI_CreatureMoveSpeed);
				CheckTravelDistance();
				return true;
			}
			break;
		case CREATURE_AICMD_SAY:
			{
				// say
				char debugtext[150];
				sprintf(debugtext, "AI: %s - CREATURE_AICMD_SAY (Action %d) says %s", pTemplate->Data.Name, curpos, AI_Actions[curpos].Text.c_str());
				Debug.Log(debugtext);
				CRegion *pCreatureRegion=RegionManager.ObjectRegions[guid];
				if (!pCreatureRegion)
					return true;
				for (int i = 0 ; i < 3 ; i++)
					for (int j = 0 ; j < 3 ; j++)
					{
						if (CRegion *pRegion=pCreatureRegion->Adjacent[i][j])
						{
							RegionObjectNode *pNode=pRegion->pList;
							while(pNode)
							{
								if (pNode->pObject->type == OBJ_PLAYER && ((CPlayer*)pNode->pObject)->pClient)
									((CPlayer*)pNode->pObject)->pClient->ChannelMessage(CHAT_MONSTER_SAY,AI_Actions[curpos].Text.c_str(),guid,0,0,CREATUREGUID_HIGH);
								pNode=pNode->pNext;
							}
						}
					}
					// Move(&AI_Actions[curpos].Location, 5.0f);
					return true;
			}
			break;
		case CREATURE_AICMD_EMOTE:
			{
				// emotes! xD
				char debugtext[150];
				sprintf(debugtext, "AI: %s - CREATURE_AICMD_EMOTE (Action %u) emotes with %u", pTemplate->Data.Name, curpos, AI_Actions[curpos].Emote);
				Debug.Log(debugtext);
				AI_Emote(NULL, AI_Actions[curpos].Emote);
				return true;
			}
			break;
		case CREATURE_AICMD_REPEATEMOTE:
			{
				// repeated emotes, 1st parameter - emote, 2nd parameter - no. of times, 3rd parameter, frequency
				char debugtext[150];
				sprintf(debugtext, "AI: %s - CREATURE_AICMD_REPEATEMOTE (Action %u) emotes with %u, count: %u, frequency: %u", pTemplate->Data.Name, curpos, AI_Actions[curpos].Emote, AI_Actions[curpos].Data1, AI_Actions[curpos].Data2);
				Debug.Log(debugtext);
				EventManager.AddEvent(*this,AI_Actions[curpos].Data1 * AI_Actions[curpos].Data2,EVENT_CREATURE_REPEATEMOTE,NULL,0);
				AddUpdateVal(UNIT_NPC_EMOTESTATE, AI_Actions[curpos].Emote);
				UpdateObject();
			}
			break;
		}
	} else {
		// creature is busy, ignore.
	}

	// RegionManager.

	return false;
}
void CCreature::AI_Aggro(CClient *pClient)
{
	// makes the creature aggro and atack that player!
}

void CCreature::AI_Attack(CClient *pClient)
{
	// attacks player
}

void CCreature::AI_Emote(CClient *pClient, unsigned long emote)
{
	// emotes!
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient))
					{
						((CPlayer*)pNode->pObject)->pClient->EmoteAnim(emote, guid, CREATUREGUID_HIGH);
						//((CPlayer*)pNode->pObject)->pClient->EmoteText(who, PLAYERGUID_HIGH, target, targettype, code, name);
					}
					pNode=pNode->pNext;
				}
			}
		}
}

void CCreature::AI_Say(CClient *pClient, char *msg, bool OnlyToThatPlayer)
{
	string output;
	output+="|c1f40af20";
	output+=pTemplate->Data.Name;
	output+="|r|cffffffff says: |r";
	output+=msg;
	pClient->Echo(output.c_str());
}

void CCreature::AI_WalkInProximity(CClient *pClient)
{/*
	// Ceck if creature is hated
	unsigned long hated;
	hated = 0;
	if (AI_Hostile && !bAttacking && !AI_Busy) {
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[this->guid];
	for (int i = 0 ; i < 3 ; i++)
	for (int j = 0 ; j < 3 ; j++)
	{
	if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
	{
	RegionObjectNode *pNode=pRegion->pList;
	while(pNode)
	{
	if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient))
	{
	unsigned long distancetoplayer = ((CPlayer*)pNode->pObject)->Distance(*this);
	if(distancetoplayer<7.5f)
	if (!TargetID)
	{
	TargetID = ((CPlayer*)pNode->pObject)->guid;
	Debug.Log("AI: Attacking");
	Attack();
	}
	}
	pNode=pNode->pNext;
	}
	}
	}
	}*/
}


void CCreature::AI_Protect(CClient *pClient)
{
	// protect the player!
}

void CCreature::AI_TalkHandler(CClient *pClient, char *msg)
{
	// handle when npc is talked to
}

bool CCreature::AI_IsHostile(CWoWObject *pP)
{
	return true;
}

void CCreature::AI_SetFaction()
{
	FactionTemplateRec i;
	if(DBCManager.FactionTemplate.fetchRow(this->pTemplate->Data.Faction, &i))
		AI_Hostile = i.hostile;
}
void CCreature::AI_ProcessEvent(CWoWObject *pSource, int MessageID, unsigned long Param1, unsigned long Param2)
{
	Debug.Logf("Recieved AI Process Event for %s", this->pTemplate->Data.Name);
	switch(MessageID)
	{
	case AIEVENT_NONE:
		{
			// nothing..
		}break;
	case AIEVENT_ATTACK:
		{
			if(AI_HasCalledForHelp || !AI_Hostile) return;
			AI_HasCalledForHelp = 1;
			// we are being attacked. call for help from any nearby mobs and get them to help your sorry ass
			Debug.Log("Event Type: Attack");
			// Check creature types.
			if(this->pTemplate->Data.Type != CREATURE_TYPE_CRITTER)
			{
				// look for nearby mobs
				CRegion *pPlayerRegion=RegionManager.ObjectRegions[this->guid];
				for (int i = 0 ; i < 3 ; i++)
					for (int j = 0 ; j < 3 ; j++)
					{
						if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
						{
							RegionObjectNode *pNode=pRegion->pList;
							while(pNode)
							{
								if(pNode->pObject->type == OBJ_CREATURE && pNode->pObject != ((CWoWObject*)this))		// nearby must be creature.. will check factions later.
								{
									if(((CCreature*)pNode->pObject)->Distance(this->Data.Loc) <= 30.0f && (((CCreature*)pNode->pObject)->pTemplate->Data.Type) == pTemplate->Data.Type)		// we don't want EVERYBODY to help, only the ones nearby
										((CCreature*)pNode->pObject)->AI_ProcessEvent(this, AIEVENT_CALLFORHELP, this->TargetID, 0);
								}
								pNode=pNode->pNext;
							}
						}
					}
			}
		

		}break;
	case AIEVENT_CALLFORHELP:
		{
			// we have been asked for help by another npc or player. help them if we're not busy.
			Debug.Log("Event Type: Call for help");
			switch(pSource->type)
			{
			case OBJ_PLAYER:
				{
					// TODO
				}break;
			case OBJ_CREATURE:
				{
					if(!AI_Busy && !bAttacking)
					{
						// Find their target
						CCreature *pCreature = ((CCreature*)pSource);
						if(pCreature)
						{
							CWoWObject *pTarget;
							if(DataManager.RetrieveObject(&pTarget, Param1))
							{
								if(pTarget)
								{
									// Find target location
									if(pTarget->type == OBJ_PLAYER)
									{
										Move(&((CPlayer*)pTarget)->Data.Loc, 7.0f);
										TargetID = pTarget->guid;
										Attack();
									} else {
										Move(&((CCreature*)pTarget)->Data.Loc, 7.0f);
										TargetID = pTarget->guid;
										Attack();
									}
								}
							}
						}
					}
				}break;
			}
		}break;
	case AIEVENT_TARGETDIED:
		{
			Move(&Data.SpawnLoc, 2.5f);
			AI_Busy = false;
		}break;
	default:
		{
		}break;
	}

}


void CCreature::Clear()
{
	CWoWObject::Clear();
	pTemplate=0;
	TargetID=0;
	memset(&Data,0,sizeof(CreatureData));
	bMoving = false;
	bAttacking = false;
	bLooted = false;
	dead = false;
	bIsSummon = false;
	LootedItems.clear();
	memset(&XP,0,sizeof(XP));
	CurrentPoint = 0;
}

void CCreature::Delete()
{
	RegionManager.ObjectRemove(*this);
	LootedItems.clear();
	CWoWObject::Delete();
}

void CCreature::New(unsigned long nTemplate)
{
	Clear();
	CWoWObject::New();
	Data.Template=nTemplate;
	//	Data.Size=1.0f;
	EventsEligible=true;
	AI_Tagger = 0;
	bIsSummon = false;
}

void CCreature::New(CCreatureTemplate &NewTemplate)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
	Data.Template=NewTemplate.guid;
	//	Data.Size=NewTemplate.Data.Size;
	//	Data.NormalStats=NewTemplate.Data.NormalStats;
	Data.CurrentStats=NewTemplate.Data.NormalStats;
	//	strcpy(Data.Name,NewTemplate.Data.Name);
	/*	Data.DamageMax=NewTemplate.Data.DamageMax;
	Data.DamageMin=NewTemplate.Data.DamageMin;
	Data.Model=NewTemplate.Data.Model;
	Data.Level=NewTemplate.Data.Level;
	Data.Exp=NewTemplate.Data.Exp;
	Data.RegenPeriodicity=NewTemplate.Data.RegenPeriodicity;
	Data.RegenPerTick=NewTemplate.Data.RegenPerTick;
	Data.NPCType = 0;
	Data.FactionTemplate = 0x1F;*/
	// set up lootable items (TEMPLATES UNTIL LOOTED)
	//NewTemplate.Data.LootTable;
	AI_Tagger = 0;
	bIsSummon = false;
	// Sort out gossip menus
	/*		if(pTemplate->Data.NPCFlags == 16388)		// Repairer/armorer
	{
	block.Add(UNIT_NPC_FLAGS,16388);
	return block.GetSize() + c;
	}

	*/	
	DefaultGossip = -1;

	if(bIsTaxi)	// taxi
	{
		DefaultGossip = GOSSIPTYPE_TAXI;
		GossipMenuItems.push_back(GOSSIPTYPE_TAXI);
	}

	if(DataManager.TrainerTemplates[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_TRAIN;
		GossipMenuItems.push_back(GOSSIPTYPE_TRAIN);
	}

	if (DataManager.SellTemplates[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_TRADE;
		GossipMenuItems.push_back(GOSSIPTYPE_TRADE);
	}

	if (DataManager.CreatureQuestRelation[Data.Template].size() > 0 || DataManager.CreatureInvolvedRelation[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_QUEST;
		GossipMenuItems.push_back(GOSSIPTYPE_QUEST);
	}
	if(!strncmp(NewTemplate.Data.Guild,"Guild Master",12))
	{
		DefaultGossip = GOSSIPTYPE_GUILD;
		GossipMenuItems.push_back(11);
		GossipMenuItems.push_back(GOSSIPTYPE_GUILD);
	}
	if(!strncmp(NewTemplate.Data.Guild,"Tabard",6))
	{
		DefaultGossip = 11;
		GossipMenuItems.push_back(11);
	}
}

unsigned long CCreature::AddCreateObjectData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	Add(unsigned long,guid);
	Add(unsigned long,CREATUREGUID_HIGH);
	Add(unsigned char,ID_UNIT);// "unit"
	Add(unsigned long, 0);
	Add(_Location,Data.Loc);
	Add(float,Data.Facing);
	Add(unsigned long, 0);
	Add(float,2.5f); //walk
	Add(float,8.0f); //run
	Add(float,4.7222223f); //swim
	Add(float,3.141593f); //turn
	Add(unsigned long,0);
	Add(unsigned long,0x1);
	Add(unsigned long,0);
	Add(unsigned long,0);
	Add(unsigned long,0);
#undef Fill
#undef Add
	return c;
}

void CCreature::PreCreateObject()
{
	AddUpdateVal(OBJECT_FIELD_GUID, guid, CREATUREGUID_HIGH);
	AddUpdateVal(OBJECT_FIELD_TYPE, HIER_TYPE_UNIT); // 1 << UnitType(0x03) | 1 << ObjectType(0x00)
	AddUpdateVal(OBJECT_FIELD_ENTRY, Data.Template);
	AddUpdateVal(OBJECT_FIELD_SCALE_X, pTemplate->Data.Size);
	AddUpdateVal(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
	AddUpdateVal(UNIT_FIELD_MAXHEALTH, pTemplate->Data.NormalStats.HitPoints);
	AddUpdateVal(UNIT_FIELD_LEVEL, pTemplate->Data.Level);
	AddUpdateVal(UNIT_FIELD_FACTIONTEMPLATE, pTemplate->Data.Faction); // FactionTemplate
	AddUpdateVal(UNIT_FIELD_BYTES_0, 0x20100);
	AddUpdateVal(UNIT_FIELD_BASEATTACKTIME, 0x7D0); // attack speed
	AddUpdateVal(UNIT_FIELD_BASEATTACKTIME+1, 0x7D0); // probably other hand attack speed
	AddUpdateVal(UNIT_FIELD_DISPLAYID,pTemplate->Data.Model);
	AddUpdateVal(UNIT_NPC_FLAGS,pTemplate->Data.NPCFlags);
}

unsigned long CCreature::GetCreatureInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	// 0x70, 0x800000
	Skip(Packets::PackGuidBuffer(buffer,guid,CREATUREGUID_HIGH));
	/*
	Add(unsigned char,0xFF);
	Add(unsigned long,guid);
	Add(unsigned long,CREATUREGUID_HIGH);
	*/
	if (Create)
	{
		Add(unsigned char, 0x03);
		Add(unsigned char, 0x70);

		Add(unsigned long, 0x800000);
		Add(unsigned long, 0xB5771D7F);
		Add(_Location, Data.Loc);
		Add(float, Data.Facing);
		Add(float, 0);
		Add(float,2.5f); //walk
		Add(float,8.0f); //run
		Add(float,8.0f); //backswim
		Add(float,4.7222223f); //swim
		Add(float,4.7222223f); //backwalk
		Add(float,3.141593f); //turn
		unsigned long flags2 = 0x800000;
		unsigned char poscount = 0;

		if(flags2 & 0x400000){
			Add(unsigned long, 0x0);
			Add(unsigned long, 0x659);
			Add(unsigned long, 0xB7B);
			Add(unsigned long, 0xFDA0B4);
			Add(unsigned long, poscount);
			for(int i=0;i<poscount+1;i++){
				Add(float,0);
				Add(float,0);
				Add(float,0);
			}
		}

		Add(unsigned long, (unsigned long)0x6297848C);
	}

	/*
	*data << (uint32)flags2;
	*data << (uint32)0xB5771D7F;
	*data << (float)m_positionX;
	*data << (float)m_positionY;
	*data << (float)m_positionZ;
	*data << (float)m_orientation;
	*data << (float)0;
	*data << m_walkSpeed;
	*data << m_runSpeed;
	*data << m_backSwimSpeed;
	*data << m_swimSpeed;
	*data << m_backWalkSpeed;
	*data << m_turnRate;
	*//*
	if (Create)
	{
	Add(unsigned char,0x03);// "unit"
	Add(unsigned long, 0);
	Add(unsigned long, 0);
	Add(_Location,Data.Loc);
	Add(float,Data.Facing);
	Add(unsigned long, 0);
	Add(float,2.5f); //walk
	Add(float,8.0f); //run
	Add(float,8.0f); //run again (?)
	Add(float,4.7222223f); //swim
	Add(float,4.7222223f); //swim again (?)
	Add(float,3.141593f); //turn
	Skip(0x4);
	Add(unsigned long,0x1);
	Skip(0xC);
	}*/
#undef Fill
#undef Skip
#undef Add

	CUpdateBlock block(&buffer[c], NUM_UNIT_FIELDS);
	block.Add(OBJECT_FIELD_GUID, guid, CREATUREGUID_HIGH);
	block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_UNIT);
	block.Add(OBJECT_FIELD_ENTRY, Data.Template);
	block.Add(OBJECT_FIELD_SCALE_X, pTemplate->Data.Size);
	if(!bIsSummon)
	{
		// UNIT_FIELD_BOUNDINGRADIUS	bounding_radius	0.69999999	float
		// UNIT_FIELD_COMBATREACH 	combat_reach	0.60000002	float
		// UNIT_FIELD_NATIVEDISPLAYID
		// UNIT_DYNAMIC_FLAGS
		// UNIT_FIELD_BASE_HEALTH
		// UNIT_FIELD_BASE_MANA
		// UNIT_FIELD_RANGEDATTACKTIME
		// UNIT_FIELD_MINRANGEDDAMAGE
		// UNIT_FIELD_MAXRANGEDDAMAGE
		// UNIT_FIELD_MINDAMAGE
		// UNIT_FIELD_MAXDAMAGE

		block.Add(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
		block.Add(UNIT_FIELD_POWER1, Data.CurrentStats.Mana);
		block.Add(UNIT_FIELD_POWER2, Data.CurrentStats.Rage);
		block.Add(UNIT_FIELD_POWER3, 0);	// was focus
		block.Add(UNIT_FIELD_POWER4, Data.CurrentStats.Energy);

		block.Add(UNIT_FIELD_MAXHEALTH, pTemplate->Data.NormalStats.HitPoints);
		block.Add(UNIT_FIELD_MAXPOWER1, pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_MAXPOWER2, pTemplate->Data.NormalStats.Rage);
		block.Add(UNIT_FIELD_MAXPOWER3, 0);
		block.Add(UNIT_FIELD_MAXPOWER4, pTemplate->Data.NormalStats.Energy);

		block.Add(UNIT_FIELD_LEVEL, pTemplate->Data.Level);
		block.Add(UNIT_FIELD_FACTIONTEMPLATE, pTemplate->Data.Faction); // FactionTemplate

		/*
		if(pTemplate->Data.Type == 1)
		{
		block.Add(UNIT_FIELD_FLAGS,0x0008);
		}
		*/

		// block.Add(UNIT_FIELD_BYTES_0, 0x20100);

		/*		if(pTemplate->Data.virtualItemDisplay[0])
		block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, DataManager.ItemTemplates[pTemplate->Data.virtualItemDisplay[0]]);
		if(pTemplate->Data.virtualItemDisplay[1])
		block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+1, DataManager.ItemTemplates[pTemplate->Data.virtualItemDisplay[1]]);
		if(pTemplate->Data.virtualItemDisplay[2])
		block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+2, DataManager.ItemTemplates[pTemplate->Data.virtualItemDisplay[2]]);

		if(pTemplate->Data.virtualItemDisplay[0])
		{
		block.Add(UNIT_VIRTUAL_ITEM_INFO, 0);
		block.Add(UNIT_VIRTUAL_ITEM_INFO+1, 0);
		}
		if(pTemplate->Data.virtualItemDisplay[1])
		{
		block.Add(UNIT_VIRTUAL_ITEM_INFO+2, 0);
		block.Add(UNIT_VIRTUAL_ITEM_INFO+3, 0);
		}
		if(pTemplate->Data.virtualItemDisplay[2])
		{
		block.Add(UNIT_VIRTUAL_ITEM_INFO+4, 0);
		block.Add(UNIT_VIRTUAL_ITEM_INFO+5, 0);
		}*/
		// This will be returning later.
		if(pTemplate->guid == 0x0800195b)
		{
			block.Add(UNIT_FIELD_FLAGS,UNIT_FLAG_SPIRITHEALER);
		} else {
			block.Add(UNIT_FIELD_FLAGS,0);
		}
		//block.Add(UNIT_FIELD_FLAGS,0);

		//block.Add(34, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);

		block.Add(UNIT_FIELD_BASEATTACKTIME, 2000); // attack speed
		block.Add(UNIT_FIELD_BASEATTACKTIME+1, 2000); // probably other hand attack speed
		block.Add(UNIT_FIELD_RANGEDATTACKTIME,2000);

		/*block.Add(UNIT_FIELD_BOUNDINGRADIUS,1.0f);
		block.Add(UNIT_FIELD_COMBATREACH,1.0f);*/
		block.Add(UNIT_FIELD_BOUNDINGRADIUS, (float)0.69999999);
		block.Add(UNIT_FIELD_COMBATREACH,(float)0.60000002);
		block.Add(UNIT_FIELD_DISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_NATIVEDISPLAYID,pTemplate->Data.Model);
		if(pTemplate->Data.Mount > 0)
			block.Add(UNIT_FIELD_MOUNTDISPLAYID,pTemplate->Data.Mount);
		block.Add(UNIT_FIELD_MINDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXDAMAGE,pTemplate->Data.DamageMax);

		block.Add(UNIT_DYNAMIC_FLAGS,0);

		/*unsigned long npcflags = 0x00;

		if(pTemplate->Data.NPCFlags == NPCTYPE_QUESTGIVER)
		npcflags = NPCTYPE_QUESTGIVER;
		else
		npcflags = pTemplate->Data.NPCFlags;

		if(GossipMenuItems.size() > 0)
		npcflags = NPCTYPE_INFO;
		*/
		block.Add(UNIT_NPC_FLAGS,pTemplate->Data.NPCFlags);
		block.Add(UNIT_FIELD_BASE_MANA,pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_BASE_HEALTH,pTemplate->Data.NormalStats.HitPoints);

		block.Add(UNIT_FIELD_MINRANGEDDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXRANGEDDAMAGE,pTemplate->Data.DamageMax);
		return block.GetSize() + c;
	} else {
		block.Add(UNIT_FIELD_SUMMONEDBY,Data.Summoner,PLAYERGUID_HIGH);
		block.Add(UNIT_FIELD_HEALTH, 28+30*pTemplate->Data.Level);
		block.Add(UNIT_FIELD_POWER1, Data.CurrentStats.Mana);
		block.Add(UNIT_FIELD_POWER2, Data.CurrentStats.Rage);
		block.Add(UNIT_FIELD_POWER3, 0);		// focus
		block.Add(UNIT_FIELD_POWER4, Data.CurrentStats.Energy);

		block.Add(UNIT_FIELD_MAXHEALTH, 28+30*pTemplate->Data.Level);
		block.Add(UNIT_FIELD_MAXPOWER1, pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_MAXPOWER2, pTemplate->Data.NormalStats.Rage);
		block.Add(UNIT_FIELD_MAXPOWER3, 0);
		block.Add(UNIT_FIELD_MAXPOWER4, pTemplate->Data.NormalStats.Energy);

		block.Add(UNIT_FIELD_LEVEL, pTemplate->Data.Level);
		block.Add(UNIT_FIELD_FACTIONTEMPLATE, pTemplate->Data.Faction); // FactionTemplate

		block.Add(UNIT_FIELD_BYTES_0, 2048);

		block.Add(UNIT_FIELD_FLAGS,0);

		block.Add(UNIT_FIELD_BASEATTACKTIME, 2000); // attack speed
		block.Add(UNIT_FIELD_BASEATTACKTIME+1, 2000); // probably other hand attack speed
		block.Add(UNIT_FIELD_RANGEDATTACKTIME,2000);


		block.Add(UNIT_FIELD_BOUNDINGRADIUS, (float)0.69999999);
		block.Add(UNIT_FIELD_COMBATREACH,(float)0.60000002);
		block.Add(UNIT_FIELD_DISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_NATIVEDISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_MINDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXDAMAGE,pTemplate->Data.DamageMax);

		block.Add(UNIT_FIELD_PETNUMBER,guid);
		block.Add(UNIT_FIELD_PET_NAME_TIMESTAMP,1000);
		block.Add(UNIT_FIELD_PETEXPERIENCE,0);
		block.Add(UNIT_FIELD_PETNEXTLEVELEXP,1000);
		block.Add(UNIT_CREATED_BY_SPELL, Data.SourceSpell);
		block.Add(UNIT_FIELD_STAT0,22);
		block.Add(UNIT_FIELD_STAT1,22);
		block.Add(UNIT_FIELD_STAT4,27);
		block.Add(UNIT_FIELD_RESISTANCES+0,0);
		block.Add(UNIT_FIELD_RESISTANCES+1,0);
		block.Add(UNIT_FIELD_RESISTANCES+2,0);
		block.Add(UNIT_FIELD_RESISTANCES+3,0);
		block.Add(UNIT_FIELD_RESISTANCES+4,0);
		block.Add(UNIT_FIELD_RESISTANCES+5,0);
		block.Add(UNIT_FIELD_RESISTANCES+6,0);
		block.Add(UNIT_FIELD_BASE_MANA,0);
		block.Add(UNIT_FIELD_ATTACKPOWER,24);
		return block.GetSize() + c;
	}
}

long CCreature::GetHitListGuid() {
	int hitlist = 0;
	for (int i = 0 ; i < 10 ; i++)
	{
		if (XP[hitlist].dmg < XP[i + 1].dmg)
		{
			hitlist = i + 1;
		}
	}
	return XP[hitlist].hitguid;
}

void CCreature::AddToHitList(CWoWObject *pObject, int dmg) {
	// BURLEX TODO: FIX

	int hitlist = 0;
	for (int i = 0 ; i < 10 ; i++)
	{
		if (XP[i].hitguid == 0) {
			hitlist = i;
			if(pObject->type == OBJ_PLAYER)
			{
				if (((CPlayer*)pObject)->Data.PartyID != 0)
				{
					XP[hitlist].hitguid = ((CPlayer*)pObject)->Data.PartyID;
				} else {
					XP[hitlist].hitguid = pObject->guid;
				}
			} else {
				XP[hitlist].hitguid = pObject->guid;
			}
			break;
		}
		if (pObject->type == OBJ_PLAYER)
		{
			if(XP[i].hitguid == ((CPlayer*)pObject)->Data.PartyID)
			{
				hitlist = i;
				break;
			} else if(XP[i].hitguid == pObject->guid)
			{
				hitlist = i;
				break;
			}
		} else {
			if (XP[i].hitguid == pObject->guid)
			{
				hitlist = i;
				break;
			}
		}
	}
	XP[hitlist].dmg += dmg;
}

void CCreature::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_CREATURE_DESPAWN:
		// note: this cant/wont free the memory but once we start using CSpawnPoint,
		// we can actually use delete pCreature;
		RegionManager.ObjectRemove(*this);
		AI_Tagger = 0;
		EventManager.AddEvent(*this,60000,EVENT_CREATURE_RESPAWN,0,0);
		break;
	case EVENT_CREATURE_REGENERATE:
		Regenerate();
		break;
	case EVENT_CREATURE_ATTACK:
		Attack();
		break;
	case EVENT_CREATURE_FOLLOW_TARGET:
		FollowTarget();
		break;
	case EVENT_CREATURE_RESPAWN:
		ReSpawn();
		break;
	case EVENT_CREATURE_WANDER:
		Wander();
		break;
	case EVENT_CREATURE_REPEATEMOTE:
		{
			AI_Busy = false;
			AddUpdateVal(UNIT_NPC_EMOTESTATE, 0);
			UpdateObject();
		}
		break;
	case EVENT_CREATURE_AIUNBUSY:
		{
			AI_Busy = false;
		}
		break;
	case EVENT_CREATURE_UPDATELOC:
		{
			long remaining = UpdateLoc();
			if (remaining > 0) {
				EventManager.AddEvent(*this,remaining,EVENT_CREATURE_UPDATELOC,0,0);
			}
		}
		break;
	case EVENT_CREATURE_AIUPDATE:
		{
			AI_Update();
			if (AI_KeepActive())
				EventManager.AddEvent(*this, AI_UpdateFrequency, EVENT_CREATURE_AIUPDATE, 0,0);
		}
	case EVENT_CREATURE_DOTTED:
		{


		}
		break;
	case EVENT_CREATURE_REMOVE_AURA:			
		{
			long aura_value;
			memcpy(&aura_value, Event.pEventData, sizeof(aura_value));
			// Remove the aura
			RemoveAura(aura_value);
		}break;

	}
}

void CCreature::SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target)
{
	CPacket pkg;
	pkg.Reset(SMSG_PERIODICAURALOG);
	Packets::PackGuid(pkg,Target->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,Caster->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)spellid;
	pkg << (unsigned long)0x00000001;
	pkg << (unsigned long)EffectID;
	switch(EffectID)
	{
	case 3: { pkg<<power<<School<<(unsigned long)0;break; }
	case 8: {pkg<<power;break;}
	case 24: {pkg<<((CPlayer*)Target)->Data.ManaType;pkg<< power<<(char)00;break;}
	}
	Packets::SendRegion(pkg,this);
}
void CCreature::SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state)
{
	AddUpdateVal(UNIT_FIELD_AURA+slot, auraid );
	Field_Aura[slot] = auraid;
	unsigned long flagslot = slot >> 3;
	unsigned long value = Field_AuraFlags[flagslot];
	value |= 0xFFFFFFFF & (9 << ((slot & 7) << 2));
	AddUpdateVal(UNIT_FIELD_AURAFLAGS + flagslot, value);
	Field_AuraFlags[flagslot] = value;
	UpdateObject();
}
void CCreature::ResetAllAuras()
{
	for(int l=0;l<64;l++)
		Field_Aura[l] = 0xFFFFFFFF;
	for(int l=0;l<8;l++)
	{
		Field_AuraFlags[l] = 0;
		Field_AuraLevels[l] = 0;
	}
	for(int l=0;l<16;l++)
		Field_AuraApplications[l] = 0;
	Field_AuraState = 0;
	for(int l=0;l<5;l++)
	{
		RestoreAuras[l].SpellID = 0;
		RestoreAuras[l].PerTick = 0;
		RestoreAuras[l].RemainingTicks = 0;
		RestoreAuras[l].Type = 0;
		RestoreAuras[l].FrequencyID = 0;
	}
}
void CCreature::RemoveAura(unsigned long slot)
{
	AddUpdateVal(UNIT_FIELD_AURA + slot, 0);
	Field_Aura[slot] = 0xFFFFFFFF;

	unsigned char flagslot = slot >> 3; // get high bits

	unsigned long value = Field_AuraFlags[flagslot];
	value &= 0xFFFFFFFF ^ (0xF << ((slot & 7) << 2));
	AddUpdateVal(UNIT_FIELD_AURAFLAGS + flagslot, value);
	Field_AuraFlags[flagslot] = value;
	UpdateObject();
	for(int i=0;i<64;i++)
	{
		if(avent[i])
		{
			if(avent[i]->Slot == slot)
			{
				avent[i]->ClearEvents();
				delete avent[i];
				avent[i] = NULL;
				return;
			}
		}
	}
}
void CCreature::InitAEvents()
{
	for(int i=0;i<64;i++)
	{
		avent[i]=NULL;
	}
}
unsigned long CCreature::FindFreeAuraSlot(bool positive)
{
	int i;
	if(positive)
	{
		for(i=0;i<32;i++)
		{
			if (Field_Aura[i] == 0xFFFFFFFF)
				return i;
		}
	}
	else
	{
		for(i=32;i<64;i++)
		{
			if (Field_Aura[i] == 0xFFFFFFFF)
				return i;
		}
	}
	return 0;
}
long CCreature::FindFreeRestoreAuraSlot()
{
	for(int i=0;i<5;i++)
	{
		if (RestoreAuras[i].SpellID == 0)
			return i;
	}
	return -1;
}
void CCreature::Regenerate()
{
	if (bAttacking) {
		Data.isRegenning = true;
		EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
		return;
	}
	bool regenning = false;
	if (Data.CurrentStats.HitPoints < pTemplate->Data.NormalStats.HitPoints) {
		DataObject.AddHP(CREATURE_REGEN_HPS);
		regenning = true;
	}
	if (Data.CurrentStats.Energy < pTemplate->Data.NormalStats.Energy) {
		DataObject.AddEnergy(CREATURE_REGEN_ENERGY);
		regenning = true;
	}
	if (UpdateDirty()) {
		UpdateObject();
	}
	if (regenning) {
		Data.isRegenning = true;
		EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
	}
	else {
		Data.isRegenning = false;
	}
}

float CCreature::Distance(_Location Loc)
{
	float A=Loc.X-Data.Loc.X;
	float B=Loc.Y-Data.Loc.Y;
	float C=Loc.Z-Data.Loc.Z;
	return sqrtf((A*A)+(B*B)+(C*C));
}

void CCreature::FaceObject(CWoWObject *pObject)
{
	float angle = 0.0f;
	float x2;
	float y2;
	float z;
	if(pObject->type == OBJ_PLAYER)
	{
		float x1;
		float y1;

		x1 = Data.Loc.X;
		y1 = Data.Loc.Y;
		z = ((CPlayer*)pObject)->Data.Loc.Z;
		x2 = ((CPlayer*)pObject)->Data.Loc.X;
		y2 = ((CPlayer*)pObject)->Data.Loc.Y;
		angle = atan2f (y2 - y1, x2 - x1);
		Data.Facing = angle;
	} else {
		float x1;
		float y1;

		x1 = Data.Loc.X;
		y1 = Data.Loc.Y;
		z = ((CCreature*)pObject)->Data.Loc.Z;
		x2 = ((CCreature*)pObject)->Data.Loc.X;
		y2 = ((CCreature*)pObject)->Data.Loc.Y;
		angle = atan2f (y2 - y1, x2 - x1);
		Data.Facing = angle;
	}
	return;		// TODO
}
void CCreature::FacePlayer(CPlayer *player)
{
	float x1;
	float x2;
	float y1;
	float y2;

	x1 = Data.Loc.X;
	y1 = Data.Loc.Y;
	x2 = player->Data.Loc.X;
	y2 = player->Data.Loc.Y;
	float angle = atan2f (y2 - y1, x2 - x1);
	Data.Facing = angle;

	CPacket pkg(SMSG_MONSTER_MOVE);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	pkg.Write(Data.Loc);
	pkg << (unsigned long)0;
	pkg << (unsigned char)3;
	Packets::PackGuid(pkg,player->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;
	pkg << (unsigned long)1;
	pkg.Write(Data.Loc);

	if (player->pClient)
		player->pClient->SendRegion(&pkg);
}

#define ATTACK_DISTANCE 5.0f
#define CREATURE_WANDER_SPEED 2.5f //3.0
#define CREATURE_RUN_SPEED 7.0f //9.0

void CCreature::Attack()
{
	bool bspell = false;
	bool bmelee = false;
	bool bmove = false;
	int dmg = 0;

	if (Data.CurrentStats.HitPoints <= 0)
		return;

	CPlayer *pPlayer=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
		if (pPlayer->pClient == NULL)
			return;
		if(pPlayer->pClient->LoggingOut) //you cannot logout anymore!
		{
			Packets::UnRoot(pPlayer->pClient);
			pPlayer->pClient->pDataObject->SetStandState(UNIT_STANDING);
			pPlayer->pClient->UpdateObject();
			pPlayer->pClient->pPlayer->ClearEvents(EVENT_PLAYER_LOGOUT);
			pPlayer->pClient->LoggingOut=false;
			pPlayer->pClient->OutPacket(SMSG_LOGOUT_CANCEL_ACK,0,0);
			pPlayer->pClient->OutPacket(SMSG_LOGOUT_RESPONSE,"\x01\x00\x00\x00\x00",5); //you can't log out now!
		}
		if (!bAttacking) {
			EventManager.AddEvent(*this,1000,EVENT_CREATURE_FOLLOW_TARGET,0,0);
			bAttacking = true;
		}
		// Now we must decide what to do...
		/*
		if (!(rand() % 8))
		bspell = true;
		else
		*/
		bmelee = true;

		if (bspell) {
			dmg = CastSpell(pPlayer,0x193);
		}
		else if (bmelee) {

			float dist = Distance(pPlayer->Data.Loc);
			if (dist < ATTACK_DISTANCE)
				dmg = MeleeAttack(pPlayer);
			else
			{
				if (!bMoving)
				{
					if (Distance(pPlayer->Data.Loc)>ATTACK_DISTANCE)
					{
						_Location loc = pPlayer->Data.Loc;

						FaceObject(pPlayer);
						/*
						float dist = Distance(pPlayer->Data.Loc)-1.5f;
						loc.X = Data.Loc.X + (dist *  sin(Data.Facing+1.5));
						loc.Y = Data.Loc.Y + (dist * -cos(Data.Facing+1.5));*/

						loc.X -= 1.5f;
						loc.Y -= 1.5f;
						Move(&loc,CREATURE_RUN_SPEED);
						CheckTravelDistance();
					}
				}
				bmove = true;
			}
		}
		if(dmg > 0)
		{
			pPlayer->DataObject.AddHP(-dmg);
			if (!pPlayer->isregenning) {
				EventManager.AddEvent(*(pPlayer),2000,EVENT_PLAYER_REGENERATE,0,0);
				pPlayer->isregenning = true;
			}
			pPlayer->UpdateObject();
		}
		if ((long)(pPlayer->Data.CurrentStats.HitPoints) <= 0) {
			pPlayer->ClearEvents();
			bMoving = false;
			bAttacking = false;
			bLooted = false;
			ClearEvents();
			Data.isRegenning = true;
			EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
			// bur: return to orig. spawn
			AI_ProcessEvent(((CWoWObject*)pPlayer), AIEVENT_TARGETDIED, pPlayer->guid, 0);

		}
		else {
			EventManager.AddEvent(*this,2000,EVENT_CREATURE_ATTACK,0,0);
		}
	}
	else {
		TargetID = 0;
		bAttacking = false;
		bMoving = false;
	}
}

void CCreature::ObjectFades(CWoWObject &Object)
{
	if (Object.guid==TargetID) {
		TargetID=0;
		bAttacking = false;
		bMoving = false;
		bLooted = false;
	}
}

int CCreature::CastSpell(CPlayer *pPlayer, unsigned short spell)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return -1;
	if (pPlayer->pClient == NULL)
		return -1;

	FaceObject(pPlayer);

	int flag=0;
	int victimflags=0;
	long dmg = pPlayer->CalculateDmg(DMGTYPE_SPELL,spell, flag,victimflags);
	unsigned char buffer[0x2A];
	unsigned char buffer2[0x2C];

	memset(buffer,0,0x2A);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;  // who is dishing out dmg
	*(unsigned long*)&buffer[0x08]=guid;
	*(unsigned long*)&buffer[0x0C]=CREATUREGUID_HIGH;  // who is dishing out dmg
	*(unsigned long*)&buffer[0x10]=spell; // spell
	*(unsigned char*)&buffer[0x14]=0x00;
	*(unsigned char*)&buffer[0x15]=0x01;
	*(unsigned char*)&buffer[0x16]=0x01;
	*(unsigned long*)&buffer[0x17]=pPlayer->guid;
	*(unsigned char*)&buffer[0x1F]=0x00;
	*(unsigned char*)&buffer[0x20]=0x02;
	*(unsigned char*)&buffer[0x21]=0x00;
	*(unsigned long*)&buffer[0x22]=pPlayer->guid;
	//*(_Location*)&buffer[0x2A]=Data.Loc;

	memset(buffer2,0,0x2C);
	*(unsigned long*)&buffer2[0x00]=0x11;
	*(unsigned long*)&buffer2[0x04]=guid;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x08]=CREATUREGUID_HIGH;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x0C]=pPlayer->guid;  // to whom
	*(unsigned short*)&buffer2[0x14]=spell; // spell
	*(unsigned long*)&buffer2[0x18]=0x0C;
	*(unsigned char*)&buffer2[0x1E]=0x40;
	*(unsigned char*)&buffer2[0x1F]=0x41;
	*(unsigned long*)&buffer2[0x24]=dmg;   // how much dmg

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		//pPlayer->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x2A);
		//		pPlayer->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
		return dmg;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if (pPlayer->pClient->pPlayer->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
							//((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x2A);
							//((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return dmg;
}
void CCreature::TakeDamage(CWoWObject *pObject, unsigned long dmg, bool spelldmg)
{
	if (pObject->type == OBJ_PLAYER&&((CPlayer*)pObject)->duelpartner)
	{
		if((((CPlayer*)pObject)->Data.CurrentStats.HitPoints - dmg) < 2)
		{
			((CPlayer*)pObject)->DataObject.SetHP(1);
			((CPlayer*)pObject)->UpdateObject();
			((CPlayer*)pObject)->EndDuel();	// Send winner and complete and despawn packets
			return;
		}
	}
	else
	{
		if (!dead)
		{
			// *** Regenning *** // Spacey: Does this happen?
			if (!Data.isRegenning) {
				Data.isRegenning = true;
				EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
			}

			// *** Mob Tagging *** //
			if (!AI_Tagger)
				if(pObject->type == OBJ_PLAYER)
					AI_Tagger = pObject->guid;

			// *** Make creature go RED if it should *** //
			/*if (Data.CurrentStats.HitPoints == pTemplate->Data.NormalStats.HitPoints)
				AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_ATTACKABLE);*/

			// *** Subtract HP *** //
			DataObject.AddHP(-((long)dmg));
			AddToHitList(pObject,dmg);

			// *** Check for death *** //
			if (Data.CurrentStats.HitPoints <= 0)
			{
				if(pObject->type == OBJ_PLAYER)
					Packets::AttackStop(((CPlayer*)pObject)->pClient, guid, CREATUREGUID_HIGH);
				pObject->bIsInCombat = false;
				Death();	// Me dead. :(
				UpdateObject();
				return;
			}

			FaceObject(pObject);
			TargetID = pObject->guid;
			UpdateObject();
			// Calculate if we should attack back.. we'll assume yes.
			if (!bAttacking) Attack();
			if(!AI_Busy)
				AI_ProcessEvent(((CWoWObject*)this), AIEVENT_ATTACK, this->TargetID,0);
			return;
		}

		if (pObject->type == OBJ_PLAYER)
			Packets::AttackStop(((CPlayer*)pObject)->pClient,guid,CREATUREGUID_HIGH);
		return;
	}
}

int CCreature::MeleeAttack(CWoWObject *pObject)
{

	if (Data.CurrentStats.HitPoints <= 0)
		return -1;

	FaceObject(pObject);
	if (AI_Tagger == 0)
		if(pObject->type == OBJ_PLAYER)
			AI_Tagger = pObject->guid;

	GameMechanics::AttackSwing((CWoWObject*)this,pObject);

	return 0;

	long dmg=0;
	int flag=0;
	int victimflags=0;
	if (pTemplate->Data.DamageMin == 4 && pTemplate->Data.Level != 1)
	{
		// For now we'll assume it's player
		if(pObject->type == OBJ_PLAYER)		// no casting without checking
			dmg = ((CPlayer*)pObject)->CalculateDmg(DMGTYPE_WEAPON,0, flag,victimflags);
	}
	else
	{
		dmg = CalculateDmg(DMGTYPE_WEAPON,0, flag);
	}
	float DamageReduction = 0;

	pObject->bIsInCombat = true;
	// damage to player, increase their defence skill level ;) (but make sure player first >.>), same thing for rage.
	if(pObject->type == OBJ_PLAYER)
	{
		((CPlayer*)pObject)->CheckForSkillUpdate(true);
		GameMechanics::RageForGettingHit(((CPlayer*)pObject),(CCreature*)this,dmg);
		((CPlayer*)pObject)->InCombat = true;
		unsigned long totalArmor=((CPlayer*)pObject)->Data.CurrentStats.Armor + 2*((CPlayer*)pObject)->Data.CurrentStats.Agility;
		DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*pTemplate->Data.Level);
		DamageReduction = (DamageReduction >= 0.75f)?0.75f:DamageReduction;
		dmg=(long)(dmg*(1.0f-DamageReduction));
	}
	CPacket pkg;
	pkg.Reset(SMSG_ATTACKERSTATEUPDATE);
	pkg << flag;
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	//pkg << (unsigned char)0xFF << guid << CREATUREGUID_HIGH;
	if(pObject->type == OBJ_PLAYER)
	{
		Packets::PackGuid(pkg,pObject->guid,PLAYERGUID_HIGH);
		//pkg << (unsigned char)0xFF << pObject->guid << PLAYERGUID_HIGH;
	} else {
		Packets::PackGuid(pkg,pObject->guid,CREATUREGUID_HIGH);
		//pkg << (unsigned char)0xFF << pObject->guid << CREATUREGUID_HIGH;
	}
	pkg << dmg;
	pkg << (char)1; //Damage Count

	pkg << (long)0; //Damage Type
	pkg << (float)dmg; // Damage Float
	pkg << dmg; // Damage in Rt. Window
	pkg << (long)(dmg*DamageReduction); // Damage Absorbed
	pkg << (long)0; // Spell Link
	pkg << (long)1; // 2 dodge, 3 parry, 4 interrupt, 5 block, 6 evade, 7 immune, 8 deflect
	pkg << (unsigned long)0xFFFFFFFF;		// if blocked damage, this is 0
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	/*
	pkg << (long)0; //0x3E8; // victimRoundDuration
	pkg << (long)0; // "spellDamageAdded"
	pkg << (long)0;  // "spellAddedDamage" if not 0 (then spell dmg) and dont show - assumes 1D will show
	pkg << (long)0;   // new val
	*/

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pObject->guid];
	if (!pPlayerRegion && pObject->type == OBJ_PLAYER)
	{
		((CPlayer*)pObject)->pClient->Send(&pkg);
		return dmg;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if (((CPlayer*)pNode->pObject)->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
							((CPlayer*)pNode->pObject)->pClient->Send(&pkg);
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return dmg;
}

// This doesnt work - Tamino please take a look
#define MOVE_DISTANCE 7.0f

void CCreature::FollowTarget()
{
	if ((long)Data.CurrentStats.HitPoints <= 0)
		return;

	CPlayer *pPlayer=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
		if (pPlayer->pClient == NULL)
			return;

		if (bMoving) {
			if ((pPlayer->Data.Loc.X != MovingDestLoc.X) ||
				(pPlayer->Data.Loc.Y != MovingDestLoc.Y) ||
				(pPlayer->Data.Loc.Z != MovingDestLoc.Z)) {
					UpdateLoc();
					ClearEvents(EVENT_CREATURE_UPDATELOC);
					_Location loc = pPlayer->Data.Loc;
					loc.X -= 1.5f;
					loc.Y -= 1.5f;
					Move(&loc,CREATURE_RUN_SPEED);
					CheckTravelDistance();
				}
		}
		else {
			float dist = Distance(pPlayer->Data.Loc);
			if (dist >= ATTACK_DISTANCE) {
				_Location loc = pPlayer->Data.Loc;
				loc.X -= 1.5f;
				loc.Y -= 1.5f;
				Move(&loc,CREATURE_RUN_SPEED);
				CheckTravelDistance();
			}
		}
		EventManager.AddEvent(*this,1000,EVENT_CREATURE_FOLLOW_TARGET,0,0);
	}
}

#define WANDER_DISTANCE 20
#define MAX_HEIGHT_CHANGE 20.0f

void CCreature::Wander()
{
	if (AI_Update())
		return;	// AI before everything else
	if (bIsTaxi)
		return;	// we don't want taxis wandering
	if (!strncmp(pTemplate->Data.Name,"Spirit Healer",13))
		return;
	if (pTemplate->Data.NPCFlags != NPCTYPE_NONE)
		return;	// bur: stops npcs that you can interact with from wandering
	if (pTemplate->Data.Type == 10)
		return;	// bur: hopefully this should stop horses wandering....
	if (!strncmp(pTemplate->Data.Name,"Horse",5))
		return;
	// if (pTemplate->Data.Type == 8 || pTemplate->Data.Faction == 7)
	//	return; // bur: more horses..		// bur: removed because it affected too many other mobs

	if ((long)Data.CurrentStats.HitPoints <= 0)
	{
		//EventManager.AddEvent(*this,30000,EVENT_CREATURE_WANDER,0,0);
		return;
	}
	if (bMoving)
	{
		UpdateLoc();
		return;
	}
	if(bAttacking) return; //we can't move while attacking!
	for(int i=0;i<5;i++)
	{
		_Location newloc;
		int change = rand() % WANDER_DISTANCE;
		if (rand()&1)//%2)
			change = -change;
		newloc.X = Data.Loc.X + change;

		change = rand() % WANDER_DISTANCE;
		if (rand()&1)//%2)
			change = -change;
		newloc.Y = Data.Loc.Y + change;

		newloc.Z = Data.Loc.Z;
		CContinent *pContinent=RegionManager.Continents[Data.Continent];
		if(pContinent)
		{
			float Z=pContinent->HeightAt(newloc.X,newloc.Y);
			if(Z)
			{
				if(fabs(Z-Data.Loc.Z)>MAX_HEIGHT_CHANGE) continue; //sorry...try again. 20 height diff. too much.
				newloc.Z=Z;
			}
		}
		Move(&newloc,CREATURE_WANDER_SPEED);
		CheckTravelDistance();
		return;
	}
}

void CCreature::CheckTravelDistance()
{
	if (Distance(Data.SpawnLoc) > 50.0f)
	{
		// STOP attacking, and return to your position maggot!
		CPlayer *pPlayer;
		if (DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, TargetID))
		{
			pPlayer->ClearEvents();
			TargetID = 0;
			bMoving = false;
			bAttacking = false;
			bLooted = false;
			ClearEvents();
			Data.isRegenning = true;
			EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
			Move(&Data.Loc,CREATURE_RUN_SPEED);
			UpdateLoc();
			Debug.Log("AI: Returning to original spawn.");
		}
		return;
	}
}

void CCreature::ReSpawn()
{
	EventsEligible=true;
	bMoving = false;
	bAttacking = false;
	bLooted=false;
	dead = false;
	AI_Tagger = 0;
	Data.Loc.X = Data.SpawnLoc.X;
	Data.Loc.Y = Data.SpawnLoc.Y;
	Data.Loc.Z = Data.SpawnLoc.Z;
	Data.Facing = Data.SpawnFacing;
	Data.CurrentStats.HitPoints = pTemplate->Data.NormalStats.HitPoints;
	RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
	//EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
	//if(!Data.NPCType) EventManager.AddEvent(*this,30000,EVENT_CREATURE_WANDER,0,0);
}

void CCreature::ApplySpellEffect(unsigned long SpellID, unsigned long Effect){}
void CCreature::HandleSpellEffects(CSpell *pSpell,unsigned long Effect)
{
	if (pTemplate->Data.NPCFlags) {
		return;
	}

	TargetID=pCaster->guid;

	unsigned long EffectID = DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_EFFECT(Effect));

	// DO NOT ADD SWITCH ITEMS THAT DO NOT WORK AS THIS IS IN USE NOW
	switch(EffectID)
	{
	case SPELL_EFFECT_WEAPON_DAMAGE:
		{
			long power=DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_POWER));

			pSpell->SendNonMeleeDamageLog(power);
			sendSpellMsg(power, pSpell->SpellID, false);
			DataObject.AddHP(-power);
			UpdateObject();
		}
		break;
	case SPELL_EFFECT_SCHOOL_DAMAGE:
		{
			long data[2] = {getPower(pSpell->SpellID, Effect),pSpell->SpellID};
			/*DataObject.AddHP(-power);
			UpdateObject();
			AddToHitList((CPlayer *)pCaster,power);
			pSpell->SendNonMeleeDamageLog(power);*/
			/*if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
			Death();
			}
			else
			{
			if (!bAttacking)
			Attack();
			}*/
			// '*50' below means /20*1000. That's a shortcut ;)
			// 20 yards = one second of delay
			EventManager.AddEvent(*this,(unsigned long)(((CPlayer*)pCaster)->Distance(*this)*50),EVENT_CREATURE_DOTTED,data,2*sizeof(long));
		}
		break;

	case SPELL_EFFECT_AURA: // Apply Aura (Buffs, DoT)
		{
			long data[2] = {getPower(pSpell->SpellID, Effect),pSpell->SpellID};
			long type = DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long aura = DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_AURA));

			switch(type)
			{
			case 6:  // school dmg
				{
					switch(aura)
					{
					case 3: // Damage Over Time (DoT)
						{
							long periodicity = DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_PERIODICITY));
							long durationID = DBCManager.Spell.getValue(pSpell->SpellID, DBC_SPELL_DURATION_ID);
							//long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);
							if (periodicity)// TODO
							{
								unsigned long dmg_tick = (maxtime / periodicity); // Guessing tick wont be float putting it in sec
								for (unsigned long i = 0 ; i < dmg_tick ; i++) {
									EventManager.AddEvent(*this, (i * periodicity),EVENT_CREATURE_DOTTED,data,2*sizeof(long));
								}
							}
						}
						break;
					} // switch aura
				} // case 6
				break;
			}
		}
		break;

	case SPELL_EFFECT_HEAL: // heals
		{
			long power = getPower(pSpell->SpellID, Effect);

			if ((Data.CurrentStats.HitPoints + power) >= pTemplate->Data.NormalStats.HitPoints)
			{
				power = pTemplate->Data.NormalStats.HitPoints - Data.CurrentStats.HitPoints;
			}
			DataObject.AddHP(power);
			UpdateObject();
			sendSpellMsg(power, pSpell->SpellID, true);
			//pSpell->SendNonMeleeDamageLog(power);
		}
		break;

	case 36: // ranged shots // ?? yeah right
		{
			long power = getPower(pSpell->SpellID, Effect);
			if (power <= 0)
				power = 12;

			DataObject.AddHP(-power);
			UpdateObject();
			AddToHitList((CPlayer *)pCaster,power);
			//sendSpellMsg(power, SpellID, false);
			pSpell->SendNonMeleeDamageLog(power);

			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				Death();
			}
			else
			{
				if (!bAttacking)
					Attack();
			}
		}
		break;

	case 58: // additional ranged shots // not likely
		{
			long power = getPower(pSpell->SpellID, Effect);
			if (power <= 0)
				power = 12;

			DataObject.AddHP(-power);
			UpdateObject();
			AddToHitList((CPlayer *)pCaster,power);
			//sendSpellMsg(power, SpellID, false);
			pSpell->SendNonMeleeDamageLog(power);

			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				Death();
			}
			else
			{
				if (!bAttacking)
					Attack();
			}
		}
		break;

	default:
		break;
	}
}

void CCreature::sendSpellMsg(long damage, unsigned long spell, bool heal)
{
	if (pCaster->type != OBJ_PLAYER)
		return;

	CPacket pkg;
	pkg.Reset(SMSG_SPELLNONMELEEDAMAGELOG);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH); // target
	Packets::PackGuid(pkg,pCaster->guid,PLAYERGUID_HIGH); // caster
	pkg << (long)spell;  // spell
	pkg << (long)damage;  //dmg
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;

	if(pCaster->type == OBJ_PLAYER)
	{
		((CPlayer*)pCaster)->pClient->SendRegion(&pkg);
	}
}
/*
void CCreature::MoveToPPoint(const int pPointID)
{
	PPoint point;

	if (PPoints.GetPPoint(pPointID, point))
	{
		_Location loc;

		loc.X = point.x;
		loc.Y = point.y;
		loc.Z = point.z;

		Move(&loc, CREATURE_RUN_SPEED-6.0f);
	}
}
*/
long CCreature::Move(_Location *loc, float speed)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;

	/*
	Walking
	DIRECTION UNKNOWN Data len=0035 op=00DA int=0000 msglen=0031 -- MonsterMoveEvent

	0000:  60 65 00 00-00 10 00 F0-B4 A6 0A 45-49 C4 C5 43  `e.....=¦ª.EI-+C
	0010:  40 3E 2E 42-67 BA 06 00-00 00 00 00-00 DC 23 00  @>.Bg¦......._#.
	0020:  00 01 00 00-00 74 4B 0B-45 92 53 C0-43 FB CF 21  .....tK.EÆS+Cv-!
	0030:  42         -           -           -             B

	Running
	DIRECTION UNKNOWN Data len=0035 op=00DA int=0000 msglen=0031 -- MonsterMoveEvent

	0000:  45 6A 00 00-00 10 00 F0-E0 FB 08 45-80 93 CA 43  Ej.....=av.EÇô-C
	0010:  4F 38 64 42-E3 B6 06 00-00 00 00 00-00 C7 04 00  O8dBp¦.......¦..
	0020:  00 01 00 00-00 90 21 09-45 91 8C CB-43 42 0C 64  .....É!.Eæî-CB.d
	0030:  42         -           -           -             B
	*/
	unsigned long timet;
	float distance = Distance(*loc);
	timet = (unsigned long)((distance*1000)/speed);
	unsigned long time_in_ms = 0;

	struct timeb tp;
	ftime(&tp);

	time_in_ms = tp.time * 1000 + tp.millitm;

	CPacket pkg;
	pkg.Reset(SMSG_MONSTER_MOVE);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	pkg << (float)Data.Loc.X;
	pkg << (float)Data.Loc.Y;
	pkg << (float)Data.Loc.Z;
	pkg << (unsigned long)time_in_ms;
	pkg << (unsigned char)0;
	if (speed>=CREATURE_RUN_SPEED)
	{
		pkg << (unsigned long)0x00000100;	// run, walk = 0x00000000
	} else {
		pkg << (unsigned long)0x00000000;	// walk, run = 0x00000100
	}
	pkg << (unsigned long)timet;
	pkg << (unsigned long)1;
	pkg << (float)loc->X;
	pkg << (float)loc->Y;
	pkg << (float)loc->Z;

	/*
	timet = (unsigned long)((distance*1000)/speed);
	memset(buffer,0,sizeof(buffer));
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;
	*(_Location*)&buffer[0x08]=Data.Loc;
	*(unsigned char*)&buffer[0x14]=0xE3;  // no idea
	*(unsigned char*)&buffer[0x15]=0xB6;  // no idea
	*(unsigned char*)&buffer[0x16]=0x06;  // no idea
	if(speed>=CREATURE_RUN_SPEED) *(unsigned long*)&buffer[0x19]=0x00000100;  // run flag
	*(unsigned long*)&buffer[0x1D]=timet;  // believe this is speed (possibly time in millisecs)
	*(unsigned long*)&buffer[0x21]=0x01;
	*(_Location*)&buffer[0x25]=*loc;

	*/
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if (!pPlayerRegion)
	{
		return timet;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER && ((CPlayer*)pNode->pObject)->pClient)
					{
						// ((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_MONSTER_MOVE,buffer,sizeof(buffer));
						((CPlayer*)pNode->pObject)->pClient->Send(&pkg);
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	bMoving = true;
	_ftime(&(MovingStart));
	MovingDestLoc = *loc;
	MovingSpeed = speed;
	MovingDistance = distance;
	EventManager.AddEvent(*this,timet,EVENT_CREATURE_UPDATELOC,0,0);
	return timet;
}

long CCreature::UpdateLoc()
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;

	if (!bMoving)
		return 0;

	_timeb now;
	_ftime(&now);
	long elapsed = CEventManager::DiffTime(now,MovingStart);
	float final_distance = MovingDistance;
	long required_time = (long)(final_distance/MovingSpeed);

	if (elapsed >= required_time) {
		Data.Loc.X = MovingDestLoc.X;
		Data.Loc.Y = MovingDestLoc.Y;
		Data.Loc.Z = MovingDestLoc.Z;
		bMoving = false;
		MovingSpeed = 0;
		MovingDistance = 0;
		RegionManager.ObjectMovement(*this,Data.Loc.X,Data.Loc.Y);
		return 0;
	}
	else {
		// we didnt reach our endpt yet... so calculate partial
		float dist = (float)elapsed * (float)MovingSpeed;
		float x = MovingDestLoc.X - Data.Loc.X;
		float xbar = fabs(x);
		float y = MovingDestLoc.Y - Data.Loc.Y;
		float ybar = fabs(y);
		float z = MovingDestLoc.Z - Data.Loc.Z;
		float zbar = fabs(z);

		Data.Loc.X += (x/(xbar+ybar+zbar))*dist;
		Data.Loc.Y += (y/(xbar+ybar+zbar))*dist;
		Data.Loc.Z += (z/(xbar+ybar+zbar))*dist;
		RegionManager.ObjectMovement(*this,Data.Loc.X,Data.Loc.Y);
		return required_time - elapsed;
	}
}


bool CCreature::StoringData(ObjectStorage &Storage)
{
	if (!guid || !Data.SpawnPoint)
		return false;
	Storage.Allocate(sizeof(AccountData));
	memcpy(Storage.Data,&Data,sizeof(AccountData));
	return true;
}

bool CCreature::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(CreatureTemplateData));
	return true;
}

void CCreature::ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown)
{
	// hate AI could be done per effect later but we'll just use this for now
	if (Caster.type==OBJ_PLAYER)
	{
		FaceObject(&Caster);
		TargetID=Caster.guid;
	}
	CWoWObject::ApplySpell(Caster,SpellID,Unknown);
}

void CCreature::SendLootablePacket(CPlayer *pPlayer, bool lootable)
{
	DataObject.SetHP(0);
	if (lootable) {
		DataObject.SetFlags(0xE0000);
		DataObject.SetDynamicFlags(1);
		Data.LootMoney = (rand()%(10*pTemplate->Data.Level));
	}
	else {
		DataObject.SetFlags(0x00000);
		DataObject.SetDynamicFlags(0);
		Data.LootMoney = 0;
	}
	UpdateObject();
}

long CCreature::CalculateDmg(int type, short id, int &flag)
{
	// miss
	if (!(rand() % 4))
	{
		flag |= 0x01;
		return 0;
	}

	if (type == DMGTYPE_SPELL)
	{
		long min_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MINDMG) + 1;
		long max_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MAXDMG);

		if (!max_dmg)
			max_dmg=1;
		long rv = min_dmg + (rand() % max_dmg);
		if (!min_dmg)
			return 0;
		return rv;
	}
	else if (type == DMGTYPE_WEAPON)
	{
		long diff = pTemplate->Data.DamageMax - pTemplate->Data.DamageMin;
		long rv;
		if (diff)
		{
			rv = pTemplate->Data.DamageMin + (rand() % diff);
		}
		else
			rv = pTemplate->Data.DamageMin;

		flag |= 0x02;

		if ((rand() % 100) < 3) //critical hit!
		{
			flag |= 0x08;
			//rv += rv + (Data.Level * 2);
			rv += (rv >> 1); // rv >> 1 = rv/2
		}
		return rv;
	}

	return 0;
}
/*
DDWORD Guid
BYTE Count
if(Count == 0)
{
BYTE Error;
Errors:
0 - Vendor has no Inventory
1 - I don't think he likes you very much.
2 - You are too far away
3 - Vendor is dead
4 - You can't shop while dead.
}
else
{
for Count
DWORD Unknown
DWORD Cache Entry
DWORD DisplayID
DWORD Count
DWORD Value
DWORD Unknown
DWORD Unknown // Value shown in left corner of Icon
}
*/
void CCreature::ListInventory(CClient *pClient)
{
	DWORD count = DataManager.SellTemplates[pTemplate->guid].size();
	if(count == 0)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 0; // Error - Vendor has no inventory
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 3; // Error - Vendor is dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(pClient->pPlayer->dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 4; // Error - Can't shop while dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	int bufsize = 0x8+1+(0x4*7*count);
	char* buffer = (char*)malloc(bufsize);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;
	buffer[0x08] = (unsigned char)count;

	char *ptr = &buffer[0x09];
	for(list<unsigned long>::iterator i = DataManager.SellTemplates[pTemplate->guid].begin();i != DataManager.SellTemplates[pTemplate->guid].end();i++)
	{
		CItemTemplate *pTemplate;
		if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, *i))
		{
			*(unsigned long*)&ptr[0x00]=1; // Some kind of flag that makes it buyable?
			*(unsigned long*)&ptr[0x04]=pTemplate->guid;
			*(unsigned long*)&ptr[0x08]=pTemplate->Data.DisplayID;
			*(unsigned long*)&ptr[0x0C]=pTemplate->Data.MaxStack; // Count
			*(unsigned long*)&ptr[0x10]=pTemplate->Data.BuyPrice; // Value
			*(unsigned long*)&ptr[0x14]=0;
			*(unsigned long*)&ptr[0x18]=0;
			ptr += 0x1C;
		}
		else
		{
			pClient->Echo("Internal error: Unable to find merchant item template.");
			return;
		}
	}
	pClient->OutPacket(SMSG_LIST_INVENTORY, buffer, bufsize);
	free(buffer);
}

void CCreature::BuyItem(CClient *pClient, unsigned long nItem, unsigned long nStacked)
{
	// should check if the merchant has the item but whateve

	CItemTemplate *pTemplate;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, nItem))
	{
		pClient->OutPacket(SMSG_BUY_FAILED,0,0);
		return;
	}

	if ((nStacked*pTemplate->Data.BuyPrice) > pClient->pPlayer->Data.Copper)
	{
		SendInventoryFailure(pClient,BAG_NOT_ENOUGH_GOLD+1,0,0,0,0);
		//pClient->Echo("You don't have enough money to buy that item");
		return;
	}
	unsigned int buyedcount = nStacked - pClient->pPlayer->AddSetItem(pTemplate, nStacked);
	if (buyedcount == 0) return; //nothing buyed
/*
	int newSlot = pClient->pPlayer->GetOpenBackpackSlot();
	if(newSlot == -1)
	{
		SendInventoryFailure(pClient,BAG_FULL,0,0,0,0);
		//pClient->Echo("Your backpack is full.");
		return;
	}

	CItem *pItem = new CItem;
	pItem->New(pTemplate, pClient->pPlayer->guid);
	pItem->Data.Count=nStacked;
	DataManager.NewObject(*pItem);
	//RegionManager.ObjectNew(*pItem, pClient->pPlayer->Data.Continent, pClient->pPlayer->Data.Loc.X, pClient->pPlayer->Data.Loc.Y);
	pClient->AddKnownItem(*pItem);
	pClient->pPlayer->DataObject.SetItem(newSlot, pItem);
	*/
//	pClient->pPlayer->Data.Copper -= nStacked*(pTemplate->Data.BuyPrice);
	pClient->pPlayer->Data.Copper -= buyedcount*(pTemplate->Data.BuyPrice);
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
	pClient->pPlayer->UpdateObject();
}

void CCreature::Death(void)
{
	if (!dead) {
		ClearEvents();
		bAttacking = false;
		bMoving = false;
		bLooted = false;
		dead = true;
		EventManager.AddEvent(*this,60000,EVENT_CREATURE_DESPAWN,0,0);
		CParty *pParty = NULL;
		if (DataManager.RetrieveObject((CWoWObject**)&pParty, OBJ_PARTY,  GetHitListGuid()))
		{
			pParty->PartyExp(this);
			CPlayer *pLooter = pParty->GetLooter();
			if (pLooter)
				SendLootablePacket(pLooter);
		}
		else
		{
			CPlayer *pPlayer=NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,GetHitListGuid())) {
				// bur: mob tagging
				if (AI_Tagger != pPlayer->guid)
				{
					dead = true;
					AI_Tagger = 0;
					return;
				}
				AI_Tagger = 0;
				// bur: quest mob kill checker
				AddCreatureKill(pPlayer, guid);
				// burlex: xp generation formula
				long OrigExp;
				long Exp=GameMechanics::CalculateKillXP((CCreature*)this, pPlayer,&OrigExp);
				Packets::LogGainXP(pPlayer->pClient,guid,OrigExp,Exp);
				GameMechanics::GiveXP(pPlayer,Exp);
				SendLootablePacket(pPlayer,true);
			}
		}
		memset(&XP,0,sizeof(XP));
	}
	dead = true;
}

void CCreature::ShowQuestStatus(CClient * pClient)
{
	/*
	structure of SMSG_QUESTGIVER_STATUS:
	uint64 VendorGUID
	ulong questid
	*/
	/*	unsigned char buffer[0x0C];

	memset(buffer,0,0x0C);
	*(unsigned long*)&buffer[0x00]=guid;  // Vendor GUID
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;  // Vendor GUID
	*(unsigned long*)&buffer[0x08]=0x01; // Number of items
	pClient->OutPacket(SMSG_QUESTGIVER_STATUS, buffer, 0x0C);
	*/
	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_STATUS);
	pkg << guid << CREATUREGUID_HIGH;
	// pkg << 5;
	unsigned long dialogstatus;
	unsigned long finalstatus = 0;
	unsigned long questguid;
	CQuestInfo *pQuest;

	for(std::list<unsigned long>::iterator i=DataManager.CreatureQuestRelation[Data.Template].begin();i!=DataManager.CreatureQuestRelation[Data.Template].end();i++)
	{
		questguid = (*i);
		if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
		{
			// quest not found
			continue;
		}
		dialogstatus = GetDialogStatus(this, pClient, questguid);
		if (dialogstatus == DIALOG_STATUS_REWARD)
		{
			pkg << (unsigned long)dialogstatus;
			pClient->Send(&pkg);
			return;
		}
		if (dialogstatus == DIALOG_STATUS_INCOMPLETE)
		{
			pkg << (unsigned long)dialogstatus;
			pClient->Send(&pkg);
			return;
		}
		if (dialogstatus > 0)
			if (finalstatus != DIALOG_STATUS_AVAILABLE)
				finalstatus = dialogstatus;
	}
	pkg << (unsigned long)finalstatus;
	pClient->Send(&pkg);
}

void CCreature::ShowQuestHello(CClient * pClient)
{
	/*
	structure of SMSG_QUESTGIVER_QUEST_DETAILS:
	uint64 VendorGUID
	ulong questid
	string(null) title
	string(null) description
	string(null) objectives
	ulong value 1
	ulong number of choice rewards (pick one of these...)
	for each choice:
	{
	ulong item id
	ulong item count
	ulong item model
	}
	ulong number of item rewards (all the items that will automatically be rewarded)
	for each item:
	{
	ulong item id
	ulong item count
	ulong item model
	}
	ulong gold reward
	ulong spell reward
	ulong num of emotes (emotes performed by the questgiver?)
	for each emote:
	{
	ulong delay (msecs)
	ulong emote
	}
	*/
	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_QUEST_LIST);
	pkg << guid << CREATUREGUID_HIGH;
	// look up text!
	if (pTemplate->Data.QuestGiverText)
		pkg << pTemplate->Data.QuestGiverText;
	else
		pkg << "Greetings, $N. Here are your quests!";
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	CQuestInfo *pQuest;
	unsigned long counter = 0;
	unsigned long questguid = 0;
	unsigned long questid;
	unsigned long questcount;
	unsigned long creaturetemplate=Data.Template;
	questcount = (unsigned char)DataManager.CreatureQuestRelation[creaturetemplate].size();

	std::list<unsigned long>::iterator i;

	for(i=DataManager.CreatureQuestRelation[creaturetemplate].begin();i!=DataManager.CreatureQuestRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (!CanTakeQuest(pClient, questguid))
			questcount--;
	}

	for(i=DataManager.CreatureInvolvedRelation[creaturetemplate].begin();i!=DataManager.CreatureInvolvedRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (GetQuestStatus(pClient, questguid) == QUEST_STATUS_COMPLETE)
			questcount++;
	}

	pkg << (unsigned char)questcount;
	if(questcount == 1)
	{
		// Don't bother showing a menu go straight to the details.
		std::list<unsigned long>::iterator b;
		b = DataManager.CreatureQuestRelation[creaturetemplate].begin();
		SendSmallQuestDetails(pClient,this->guid,(*b));
		return;
	}

	for(i=DataManager.CreatureQuestRelation[creaturetemplate].begin();i!=DataManager.CreatureQuestRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (CanTakeQuest(pClient, questguid))
		{
			questid = (*i);
			pkg << (unsigned long)questguid;
			pkg << (unsigned long)0x05;
			pkg << (unsigned long)0x00;
			if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
				pkg << "Quest not found in DB!";
			else
				pkg << pQuest->Data.title;
		}
		counter++;
	}

	for(i=DataManager.CreatureInvolvedRelation[creaturetemplate].begin();i!=DataManager.CreatureInvolvedRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (GetQuestStatus(pClient, questguid) == QUEST_STATUS_COMPLETE)
		{
			questid = (*i);
			pkg << (unsigned long)questguid;
			pkg << (unsigned long)0x03;
			pkg << (unsigned long)0x00;
			if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
				pkg << "Quest not found in DB!";
			else
				pkg << pQuest->Data.title;
		}
		counter++;
	}


	pClient->Send(&pkg);

	/*
	CPacket pkg(SMSG_QUESTGIVER_QUEST_DETAILS);
	pkg << guid << CREATUREGUID_HIGH;
	pkg << (unsigned long)33;  // Quest ID
	pkg << "Wolves Across the Border";		// title
	pkg << "Bring 8 pieces of Tough Wolf Meat to Eagan Peltskinner outside Northshire Abbey.";		// objectives
	pkg << "I hate those nasty timber wolves!  But I sure like eating wolf steaks...  Bring me tough wolf meat and I will exchange it for something you'll find useful.$B$BTough wolf meat is gathered from hunting the timber wolves and young wolves wandering the Northshire countryside.";	// details
	pkg << (unsigned long)0x01;					// Accept active?
	pkg << (unsigned long)2;					// No. of rewards
	// loop this:
	pkg << (unsigned long)1;				// no of items
	pkg << (unsigned long)6070;				// item id
	// end loop
	pkg << (unsigned long)1;
	pkg << (unsigned long)80;

	pkg << (unsigned long)0;			// item rewards;
	pkg << (unsigned long)0;			// reward gold
	pkg << (unsigned long)0;			// unknown
	pkg << (unsigned long)0;			// no. of mobs

	pClient->Send(&pkg);*/
	/*
	if (questinfo.title != NULL)
	pkg << questinfo.title;
	else
	pkg << "No Title";
	if (questinfo.description != NULL)
	pkg << questinfo.description;
	else
	pkg << "No Description";
	if (questinfo.objective != NULL)
	pkg << questinfo.objective;
	else
	pkg << "No Objective";
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x04;
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pClient->Send(&pkg);*/
}

unsigned long CTaxiMob::Mask[8];
