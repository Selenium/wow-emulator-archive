#include "Client.h"
#include "Packets.h"
#include "Globals.h"
#include "Quest.h"
#include "QuestFunctions.h"

void Packets::TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent)
{
	if(pClient->pPlayer->Data.Continent == NewContinent)
	{
		RegionManager.ObjectMovement(*pClient->pPlayer,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		SendTeleport(pClient);
	}
	else
	{
		RegionManager.ObjectRemove(*pClient->pPlayer);
		pClient->pPlayer->Data.Continent = NewContinent;
		RegionManager.ObjectNew(*pClient->pPlayer,NewContinent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
		SendNewWorld(pClient);
	}
}

void Packets::TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent, _Location&NewLoc, float facing)
{
	pClient->pPlayer->Data.Loc = NewLoc;
	pClient->pPlayer->Data.Facing = facing;
	TeleportOrNewWorld(pClient, NewContinent);
}

void Packets::TeleportOrNewWorld(CClient *pClient, unsigned int NewContinent, _Location &NewLoc)
{
	pClient->pPlayer->Data.Loc = NewLoc;
	TeleportOrNewWorld(pClient, NewContinent);
}

void Packets::SendNewWorld(CClient *pClient)
{
	CPacket pkg(SMSG_NEW_WORLD, 26);// header(6), continent(4), location(12), facing(4)
	pkg.Write(pClient->pPlayer->Data.Continent);
	pkg.Write(pClient->pPlayer->Data.Loc);
	pkg.Write(pClient->pPlayer->Data.Facing);
	pClient->Send(&pkg);
	// packet gets automaticly deleted
}

void Packets::SendTeleport(CClient *pClient)
{
	CPacket pkg(MSG_MOVE_TELEPORT);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	pkg << 0 << 0;
	pkg << pClient->pPlayer->Data.Loc << pClient->pPlayer->Data.Facing;
	/*pkg.Write((unsigned char)0xFF);
	pkg.Write(pClient->pPlayer->guid);
	pkg.Write(PLAYERGUID_HIGH);*/
	/*
	pkg.Write(0x00);
	pkg.Write(0x00);
	pkg.Write(pClient->pPlayer->Data.Loc);
	pkg.Write(pClient->pPlayer->Data.Facing);
	*/
	pClient->SendRegion(&pkg);
}

void Packets::Root(CClient *pClient)
{
	CPacket pkg(SMSG_FORCE_MOVE_ROOT);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	pClient->Send(&pkg);
}

void Packets::UnRoot(CClient *pClient)
{
	CPacket pkg(SMSG_FORCE_MOVE_UNROOT);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	pClient->Send(&pkg);
}

void Packets::AttackStop(CClient *pClient, unsigned long guid, unsigned long guidhigh)
{
	CPacket pkg;
	pkg.Reset(SMSG_ATTACKSTOP);
	// why is this packed when the other is not?
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,guid,guidhigh);
	pkg << (unsigned long)1;
	pClient->pPlayer->ClearEvents(EVENT_PLAYER_END_ATTACK);
	pClient->SendRegion(&pkg);
	pClient->pPlayer->bIsInCombat = false;
}

void Packets::AttackStart(CClient *pClient, unsigned long guid, unsigned long guidhigh)
{
	CPacket pkg;
	pkg.Reset(SMSG_ATTACKSTART);
	// this is an "unpacked" packet...
	pkg << (unsigned long)pClient->pPlayer->guid << PLAYERGUID_HIGH;
	pkg << (unsigned long)guid << (unsigned long)guidhigh;
	pClient->SendRegion(&pkg);
}

void Packets::LogGainXP(CClient *pClient, unsigned long creatureguid, unsigned long OrigExp, unsigned long XP)
{
	CPacket pkg;
	pkg.Reset(SMSG_LOG_XPGAIN);
	pkg << creatureguid << CREATUREGUID_HIGH;
	pkg << (long)XP << (char)0;
	pkg << (long)OrigExp << (float)1.0;
	if(pClient) pClient->Send(&pkg);
}

void Packets::LevelUp(CPlayer *pPlayer, PlayerStats OldStats)
{
	CPacket pkg;
	pkg.Reset(SMSG_LEVELUP_INFO);
	pkg << (unsigned long)pPlayer->Data.Level;
	pkg << (unsigned long)(pPlayer->Data.NormalStats.HitPoints-OldStats.HitPoints);
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Mana-OldStats.Mana);
	pkg << (unsigned long)0 << (unsigned long)0 << (unsigned long)0 << (unsigned long)0;
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Strength-OldStats.Strength);
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Agility-OldStats.Agility);
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Stamina-OldStats.Stamina);
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Intellect-OldStats.Intellect);
	pkg << (unsigned long)(pPlayer->Data.NormalStats.Spirit-OldStats.Spirit);
	pPlayer->pClient->Send(&pkg);
}

guid_t Packets::ReadGuid(CDataBuffer &Data)
{
	unsigned char guidmask=0;
	guid_t shiftedbyte; // so it can be shifted
	unsigned char guidbyte;
	unsigned char shiftdata=0x1;
	guid_t guid=0;
	Data >> guidmask;
	for(int i=0;i<8;i++)
	{
		if(guidmask & shiftdata)
		{
			Data >> guidbyte;
			if (i<sizeof(guid_t))
			{
				shiftedbyte=guidbyte;
				guid |= (shiftedbyte << (i << 3));
			}
		}
		shiftdata<<=1;
	}
	return guid;
}
#define FULLPACK 1 // if 0, lazily chops the guidhigh off (if 0)
int Packets::PackGuidBuffer(char *buffer,guid_t guid,guidhigh_t guidhigh)
{
#if FULLPACK
	int c=1;
	unsigned char mask=0;

	char *cLow=(char*)&guid;

	for(int i=0;i<sizeof(guid_t);i++)
	{
		if(cLow[i])
		{
			mask|=(1<<i);
			buffer[c++]=cLow[i];
		}
	}
	if(guidhigh)
	{
		char *cHigh=(char*)&guidhigh;
		for(int i=0;i<sizeof(guidhigh_t);i++)
		{
			if(cHigh[i])
			{
				mask|=(1<<(i+(sizeof(guid_t))));
				buffer[c++]=cHigh[i];
			}
		}
	}
	buffer[0]=mask;
	return c;
#else
	if(guidhigh)
	{
		buffer[0]=0xFF;
		*(guid_t*)&buffer[1]=guid;
		*(guidhigh_t*)&buffer[1+sizeof(guid_t)]=guidhigh;
		return 9;
	}
	else
	{
		buffer[0]=0x0F;
		*(guid_t*)&buffer[1]=guid;
		return 5;
	}
#endif
}

void Packets::PackGuid(CPacket &pkg,guid_t guid,guidhigh_t guidhigh)
{
	char buffer[9];

	pkg.Write(buffer,PackGuidBuffer(buffer,guid,guidhigh));
}

void Packets::CloseGossip(CClient *pClient)
{
	CPacket pkg;
	pkg.Reset(SMSG_GOSSIP_COMPLETE);
	pClient->Send(&pkg);
}

void Packets::SendRegion(CPacket &pkg, CWoWObject *pObject)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pObject->guid];
	if (!pPlayerRegion)
	{
		if(pObject->type == OBJ_PLAYER && ((CPlayer*)pObject)->pClient)
			((CPlayer*)pObject)->pClient->Send(&pkg);
		return;
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
						// if (((CPlayer*)pNode->pObject)->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
						((CPlayer*)pNode->pObject)->pClient->Send(&pkg);
						// }
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
}

void Packets::DefaultGossipMenu(CClient *pClient, guid_t creatureguid)
{
	CCreature *pCreature;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,creatureguid))
	{
		pClient->Echo("Can't find creature");
		return;
	}
	CPacket pkg;
	pkg.Reset(SMSG_GOSSIP_MESSAGE);
	pkg << creatureguid << CREATUREGUID_HIGH;
	pkg << (unsigned long)((pCreature->pTemplate->Data.TextID)?pCreature->pTemplate->Data.TextID:999999);
	pkg << (unsigned long)pCreature->GossipMenuItems.size()+1;
	//pkg << (unsigned long)2;
	for(std::list<unsigned long>::iterator i=pCreature->GossipMenuItems.begin();i!=pCreature->GossipMenuItems.end();i++)
	{
		switch(*i)
		{
		case GOSSIPTYPE_QUEST:
			pkg << (unsigned long)0;
			pkg << (unsigned short)0;
			pkg << "Quests are above!";
			break;
		case GOSSIPTYPE_TRADE:
			pkg << (unsigned long)90;		// 90 = trade
			pkg << (unsigned short)1;
			pkg << "Items for Sale";
			break;
		case GOSSIPTYPE_TRAIN:
			pkg << (unsigned long)91;		// 91 = train
			pkg << (unsigned short)3;
			pkg << "Train me";
			break;
		case GOSSIPTYPE_TAXI:
			pkg << (unsigned long)92;		// 92 = taxi
			pkg << (unsigned short)4;
			pkg << "Flight Destinations";
			break;
		case GOSSIPTYPE_GUILD:
			pkg << (unsigned long)93;		// 93 = Guild Master
			pkg << (unsigned short)5;
			pkg << "Guild Management";
			break;
		case GOSSIPTYPE_TABARD:
			pkg << (unsigned long)94;		// 94 = Tabard Vendor
			pkg << (unsigned short)6;
			pkg << "Buy Guild Tabard";
			break;
		case GOSSIPTYPE_BINDER:
			pkg << (unsigned long)95;		// 95 = Binder
			pkg << (unsigned short)5; // CHECKME
			pkg << "Make this inn your home.";
			break;
		default:
			pkg << (unsigned long)0;
			pkg << (unsigned short)0;
			pkg << "No option";
			break;
		}
	}

	pkg << (unsigned long)100;
	pkg << (unsigned short)0;
	pkg << "I'm done talking to you.";
	// Quests! Fixed by nneonneo ^_^
	std::list<unsigned long> Quests;

	if(DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].size() > 0)
	{
		// we have quests
		for(std::list<unsigned long>::iterator l=DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].begin();l!=DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].end();l++)
		{
			if (CanTakeQuest(pClient,(*l)))
				Quests.push_back((*l));
		}
	}

	if(DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].size() > 0)
	{
		// we have involvers
		for(std::list<unsigned long>::iterator l=DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].begin();l!=DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].end();l++)
		{
			if (GetQuestStatus(pClient, (*l)) == QUEST_STATUS_COMPLETE)
				Quests.push_back((*l)|0x80000000); // clandestine involved flag
		}
	}

	if(Quests.size() > 0)
	{
		CQuestInfo *pQuest;
		pkg << (unsigned long)Quests.size();		// Number of quests
		for(std::list<unsigned long>::iterator q=Quests.begin();q!=Quests.end();q++)
		{
			unsigned long qid=(*q)&0x7FFFFFFF; // byebye hidden flag
			pkg << (unsigned long)qid;
			if((*q)&0x80000000)
				pkg << (unsigned long)0x03; // Icon
			else
				pkg << (unsigned long)0x05; // Icon
			pkg << (unsigned long)0; // Current
			if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, qid))
				pkg << "Quest not found in DB!";
			else
				pkg << pQuest->Data.title;
		}
	}
	pClient->Send(&pkg);
}
