// Copyright (C) 2004 Team Python
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

// WorldServer.h: interface for the WorldServer class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WORLDSERVER_H__640A742F_9A0B_4F43_B406_7FA0546820C1__INCLUDED_)
#define AFX_WORLDSERVER_H__640A742F_9A0B_4F43_B406_7FA0546820C1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "Server.h"
#include "Common.h"
#include "GameClient.h"
#include "time.h"

#include "Group.h"

#include "ObjectMgr.h"

// include handlers
#include "ChatHandler.h"
#include "CharacterHandler.h"
#include "MovementHandler.h"
#include "QueryHandler.h"
#include "QuestHandler.h"
#include "TaxiHandler.h"
#include "GroupHandler.h"
#include "SpellHandler.h"
#include "SkillHandler.h"
#include "ItemHandler.h"
#include "NPCHandler.h"
#include "Combat.h"
#include "Item.h"
#include "MiscHandler.h"
#include "PetHandler.h" 
#include "AuraHandler.h" 

class Object;
class Character;
class Unit;
class Quest;


// Distance a Player can "see" other objects and receive updates from them
#define UPDATE_DISTANCE 155.8

//Defined for updates
#define UPDATE_COUNT 3
#define UPDATE_SET 0
#define UPDATE_OBJECT 1
#define UPDATE_LOGOUT 2

struct updateTimer{
	uint32 interval;
	uint32 currTime;
};

class WorldServer : public Server, public Singleton < WorldServer >  
{
	friend class ChatHandler;
	friend class CharacterHandler;
	friend class MovementHandler;
    friend class QueryHandler;
    friend class QuestHandler;
    friend class CombatHandler;
    friend class SpellHandler;
    friend class NPCHandler;
    friend class SkillHandler;
	friend class MiscHandler;
	friend class PetHandler;
	friend class AuraHandler;
	friend class Character;
	friend class RealmListSrv;

public:
	WorldServer();
	~WorldServer();

	void updateRealm(char *);

	int dbstate;

	Group * WorldServer::GetGroupByLeader(char* name);
	void AddGroup(Group* pGroup);
	void DelGroup(Group* pGroup);
    void Update( uint32 time );  // update the world server every frame


	uint32 GetClientsConnected(){return mClients.size();}

	void SetMotd(char *newMotd);
	uint8 *GetMotd(){ return motd; }

	void SendGlobalMessage(wowWData* data, GameClient *pSelf);
	void SendZoneMessage(wowWData* data, GameClient *pSelf, int flag);
	void SendAreaMessage(wowWData* data, GameClient *pSelf, int flag);
	void SendUnitZoneMessage(wowWData* data, int zoneid, int mapid);
	void SendUnitAreaMessage(wowWData* data, Unit *pUnit);

	float CalcDistance(Unit *pCa, Unit *pCb);
	float CalcDistanceByPosition(Unit *pCa, float x, float y, float z);


	//Overloaded function, not second arguments so it truly send to -everyone-
	void SendGlobalMessage(wowWData* data);
	int SendMessageToPlayer(wowWData *data, char* name);  // name of the player to send a message to
    int SendMessageToPlayer(wowWData *data, uint32 guid);  // name of the player to send a message to

	void SendWorldText(uint8 *text);
    void SendWorldText(uint8 *text, GameClient *pSelf);

    inline void addQuest(Quest* pQuest) { mQuestHandler.addQuest(pQuest); };
    inline Quest* getQuest(uint32 quest_id) { return mQuestHandler.getQuest(quest_id); };
	inline void addCreature(Unit *pUnit) { mCreatures[pUnit->getGUID()] = pUnit; }
	
    uint32 addCreatureName(uint8* name);
    inline uint8 * getCreatureName( uint32 entry ) {
		if( mCreatureNames.find( entry ) != mCreatureNames.end( ) )
			return mCreatureNames[entry];
		return 0;
    };
    void saveCreatures();

	TALENT *Talents; 
   inline void SetTalentDatabase(TALENT *pTalents) 
   { 
      memcpy(Talents, pTalents, sizeof(TALENT)*MAXTALENTID); 
   } 
   inline TALENT *GetTalentDatabase() { return Talents; }

    void SetInitialWorldSettings();
    std::map< uint32, Unit*> getCreatureMap() { return mCreatures; };
    std::map< uint32, Character*> getCharacterMap() { return mCharacters; };
    std::map< uint32, Item*> getItemMap() { return mItems; };

    void CheckForInRangeObjects(Object* obj);

	void AddItem(Item* pItem);
	Item *GetItem(uint32 itemid);

    inline Unit *GetCreature(uint32 unitguid) { return GetValidCreature(unitguid); };
    inline Unit * WorldServer::GetValidCreature(uint32 unitguid)
    {
	    std::map<uint32, Unit*>::iterator itr = mCreatures.find(unitguid);
	    if (itr == mCreatures.end())
		    return NULL;
	    else
		    return itr->second;
    }

	GameClient * GetClientByName(char* name);

    inline long int updateGameTime(){
      // Update Server time
      long int thisTime = time(NULL);
      m_gameTime += thisTime - m_lastTick;
      m_lastTick = thisTime;
      return m_gameTime; 
     };

    uint32 m_hiCharGuid;  // highest GUID, used for creating new objects
    uint32 m_hiCreatureGuid;  // highest GUID, used for creating new objects
    uint32 m_hiItemGuid;  // highest GUID, used for creating new objects
    uint32 m_hiGoGuid;
	
    DatabaseInterface *dbi;
	void server_sockevent(struct nlink_server *cptr, unsigned short revents, void * myNet);
	void client_sockevent(struct nlink_client *cptr, unsigned short revents);
	void disconnect_client(	struct nlink_client *cptr );

	void eventStart( );
	void eventStop( );

	//START OF LINA COMMAND BY SELECTION 1.3
	inline Character *GetCharacter(uint32 unitguid) { return GetValidCharacter(unitguid); };
    inline Character *WorldServer::GetValidCharacter(uint32 unitguid)
    {
	    std::map<uint32, Character*>::iterator itr = mCharacters.find(unitguid);
	    if (itr == mCharacters.end())
		    return NULL;
	    else
		    return itr->second;
    }
	//END OF LINA COMMAND BY SELECTION 1.3

	void setAttackGroupUnit(Unit * pUnite, Unit * pVictim) ;

	Unit * GetClosestUnit(Unit * pUnite) 
	{
		Unit * pUnit = NULL;
		pUnite->closest_dist = 1000;
		uint32 unitguid = pUnite->getGUID();
		WorldServer::CreatureMap::iterator itr;
		for (itr = mCreatures.begin(); itr != mCreatures.end(); itr++)
		{
			if(itr->second->isAlive())
			{
				uint32 distance = (uint32)CalcDistance(pUnite, itr->second);
				if (distance < pUnite->closest_dist)
				{
					if(itr->second->getGUID() != unitguid)
					{
						pUnit = itr->second;
						pUnite->closest_dist = distance;
					}
				}
			}
		}
		return pUnit;
	}

	Character * GetClosestChar(Unit * pUnite)
	{
		Character * pChar = NULL;
		pUnite->closest_dist = 1000;
		uint32 unitguid = pUnite->getGUID();
		WorldServer::CharacterMap::iterator itr;
		for (itr = mCharacters.begin(); itr != mCharacters.end(); ++itr)
		{
			if(itr->second->isAlive())
			{
				uint32 distance = (uint32)CalcDistance(pUnite, itr->second);
				if (distance < pUnite->closest_dist)
				{
					if(itr->second->getGUID() != unitguid)
					{
						pChar = itr->second;
						pUnite->closest_dist = distance;
					}
				}
			}
		}
		return pChar;
	}

	uint32 Save(char* who); //LINA GLOBAL SAVE COMMAND

	void LoadHelp(){mChatHandler.LoadHelp(true);}; //LINA RELOAD COMMAND

protected:

    void LogoutPlayer(GameClient *pClient);
	
	// Update Stuff
	void initUpdates();
	void updateTimes(uint32 uTime);
	bool updatePassed(int updateType);
	void updateReset();
	
	updateTimer m_updateTimer[UPDATE_COUNT];

	uint32	mClientsConnected;

	uint8	*motd;
	uint16	motd_size;

    // map text emote to emote animation id
   	typedef std::map< uint8, uint8> EmotesMap;
	EmotesMap mEmotes;

    // map entry to a creature name
	typedef std::map< uint32, uint8*> CreatureNameMap;
	CreatureNameMap mCreatureNames;

    long int m_gameTime; // uh oh!  attempting to synchronize time!
    long int m_lastTick;

    ///// Object Tables ////
    // These tables are modified as creatures are created and destroyed in the world

	// Group List
	typedef std::list< Group * > GroupList;
	GroupList mGroupList;
	
	// Map of all item types in the game
	typedef std::map< uint32, Item*> ItemMap;
	ItemMap mItems;

	// Map of active characters in the game 
	typedef std::map< uint32, Character*> CharacterMap; 
	CharacterMap mCharacters; 
    
	// Map of active creatures in the game 
	typedef std::map< uint32, Unit*> CreatureMap; 
	CreatureMap mCreatures; 

	int killingItem; //thread safety
	int dontkillItem;

public:
    ObjectMgr           mObjectMgr;

	// Message Handlers
	ChatHandler         mChatHandler;
    TaxiHandler         mTaxiHandler;
    ItemHandler         mItemHandler;
    GroupHandler		mGroupHandler;
	QueryHandler        mQueryHandler;
    QuestHandler        mQuestHandler;
	MovementHandler     mMovementHandler;
	CharacterHandler    mCharacterHandler;
    CombatHandler       mCombatHandler;
    SpellHandler        mSpellHandler;
    NPCHandler          mNPCHandler;
	MiscHandler			mMiscHandler;
    SkillHandler		mSkillHandler;
	PetHandler          mPetHandler; 
	AuraHandler         mAuraHandler; 



};



#endif // !defined(AFX_WORLDSERVER_H__640A742F_9A0B_4F43_B406_7FA0546820C1__INCLUDED_)
