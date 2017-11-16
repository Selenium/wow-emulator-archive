#include "Client.h"
#include "Packets.h"
#include "Globals.h"
#include "Quest.h"

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

unsigned long Packets::ReadGuid(CDataBuffer &Data)
{
	unsigned char guidmask=0;
	unsigned long shiftedbyte;
	unsigned char guidbyte;
	unsigned char shiftdata=0x1;
	unsigned long guid=0;
	Data >> guidmask;
	for(int i=0;i<8;i++)
	{
		if(guidmask & shiftdata)
		{
			Data >> guidbyte;
			if (i<4)
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
int Packets::PackGuidBuffer(char *buffer,unsigned long guid,unsigned long guidhigh)
{
#if FULLPACK
	int c=1;
	unsigned char mask=0;

	char *cLow=(char*)&guid;

	for(int i=0;i<4;i++)
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
		for(int i=0;i<4;i++)
		{
			if(cHigh[i])
			{
				mask|=(1<<(i+4));
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
		*(unsigned long*)&buffer[1]=guid;
		*(unsigned long*)&buffer[5]=guidhigh;
		return 9;
	}
	else
	{
		buffer[0]=0x0F;
		*(unsigned long*)&buffer[1]=guid;
		return 5;
	}
#endif
}

void Packets::PackGuid(CPacket &pkg,unsigned long guid,unsigned long guidhigh)
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
	/*if (!pPlayerRegion && pObject->type == OBJ_PLAYER)
	{
	((CPlayer*)pObject)->pClient->Send(&pkg);
	return dmg;
	}*/
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

void Packets::DefaultGossipMenu(CClient *pClient, unsigned long creatureguid)
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
	pkg << (unsigned long)999999;
	pkg << (unsigned long)pCreature->GossipMenuItems.size()+1;
	//pkg << (unsigned long)2;
	for(std::list<unsigned long>::iterator i=pCreature->GossipMenuItems.begin();i!=pCreature->GossipMenuItems.end();i++)
	{
		if((*i) == GOSSIPTYPE_TRADE)
		{
			pkg << (unsigned long)90;		// 90 = trade
			pkg << (unsigned char)1;
			pkg << (unsigned char)0;
			pkg << "I would like to buy something off you";
		} else if ((*i) == GOSSIPTYPE_TRAIN) {
			pkg << (unsigned long)91;		// 91 = train
			pkg << (unsigned char)3;
			pkg << (unsigned char)0;
			pkg << "Teach me something new.";
		} else if ((*i) == GOSSIPTYPE_TAXI) {
			pkg << (unsigned long)92;		// 92 = taxi
			pkg << (unsigned char)4;
			pkg << (unsigned char)0;
			pkg << "Fly me some place!";
		} else if ((*i) == GOSSIPTYPE_GUILD) {
			pkg << (unsigned long)93;		// 93 = Guild Master
			pkg << (unsigned char)5;
			pkg << (unsigned char)0;
			pkg << "Guild Management";
		} else if ((*i) == 11) {
			pkg << (unsigned long)94;		// 94 = Tabard Vendor
			pkg << (unsigned char)6;
			pkg << (unsigned char)0;
			pkg << "Make a guild tabard";
		}
	}
	pkg << (unsigned long)100;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "I'm done talking to you.";

	// Put any quests we have on the list, this 132s.. will look at later.
	/*
	std::list<unsigned long> Quests;

	if(DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].size() > 0)
	{
	// we have quests
	for(std::list<unsigned long>::iterator l=DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].begin();l!=DataManager.CreatureQuestRelation[pCreature->pTemplate->guid].end();l++)
	Quests.push_back((*l));
	}

	if(DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].size() > 0)
	{
	// we have involvers
	for(std::list<unsigned long>::iterator l=DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].begin();l!=DataManager.CreatureInvolvedRelation[pCreature->pTemplate->guid].end();l++)
	Quests.push_back((*l));
	}

	if(Quests.size() > 0)
	{
	CQuestInfo *pQuest;
	pkg << (unsigned long)Quests.size();		// Number of quests
	for(std::list<unsigned long>::iterator q=Quests.begin();q!=Quests.end();q++)
	{
	pkg << (unsigned long)(*q);
	pkg << (unsigned long)0;					// Icon
	pkg << (unsigned long)0;					// Current
	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, (*q)))
	pkg << "Quest not found in DB!";
	else
	pkg << pQuest->Data.title;
	}
	}*/

	pClient->Send(&pkg);
}
