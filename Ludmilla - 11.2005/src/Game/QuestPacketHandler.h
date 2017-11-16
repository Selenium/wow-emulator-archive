/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#ifndef __QUEST_PACKETS_H
#define __QUEST_PACKETS_H

#include "Quest.h"
#include "Creature.h"
#include "npchandler.h"

#define MAX_GOSSIP_ENTRIES 20

enum POIIcons {
	POI_GRAY_CRATE           =   0,
	POI_RED_CRATE            =   1,
	POI_BLUE_CRATE           =   2,

    POI_GRAY_GUARDPOST       =   5,
	POI_RED_GUARDPOST        =   12,
	POI_GRAY_RED_GUARDPOST   =   13,
	POI_ALLIANCE_GUARDPOST   =   14,

    POI_BUILDING             =   4,
    POI_RED_FLAG             =   6,
    POI_CEMETARY             =   7,

    POI_GRAY_FORTRESS        =   3,
	POI_GRAY_BLUE_FORTRESS   =   8,
	POI_RED_FORTRESS         =   9,
	POI_BLUE_FORTRESS        =   10,
	POI_GRAY_RED_FORTRESS    =   11,
};


enum {
	FAILEDREASON_DUPE_ITEM_FOUND = 0x10,
    FAILEDREASON_FAILED			 = 0,
    FAILEDREASON_INV_FULL		 = 4,
};

enum
{
    INVALIDREASON_DONT_HAVE_REQ = 0,
    INVALIDREASON_DONT_HAVE_REQ_ITEMS = 0x13,
    INVALIDREASON_DONT_HAVE_REQ_MONEY = 0x15,
    INVALIDREASON_DONT_HAVE_RACE = 6,
    INVALIDREASON_DONT_HAVE_LEVEL = 1,
    INVALIDREASON_HAVE_QUEST = 13,
    INVALIDREASON_HAVE_TIMED_QUEST = 12,
};

struct GossipData {
	uint32 iDataSender;
	uint32 iDataSub;
};

struct GossipMessage {
	uint8 iIcon;
	bool  bInputBox;
	std::string sMessage;

	GossipData Data;
};

/* GossipQuest Item
    - iQuest -> Quest ID
	- iIcon  -> Is Dialog Status Icon
	- bCurrent -> true for current quest
	- sTitle -> title for the quest list menu
*/
struct GossipQuest {
	uint32 iQuest;
	uint8  iIcon;
	bool   bCurrent;

	std::string sTitle;
};


class NPCGossipMenu
{
public:
	NPCGossipMenu();
	~NPCGossipMenu();

	void AddMessage(uint8 icon, bool bInputBox, char* text );
	void AddMessage(uint8 icon, bool bInputBox, char* text, GossipData data);
	void AddMessage(uint8 icon, bool bInputBox, std::string text, GossipData data);

	void Clear();

	GossipData GetOptionUserData( uint32 OptionId );

	GossipMessage m_Items[MAX_GOSSIP_ENTRIES];
	uint16 m_ItemsNr;
};

class NPCQuestMenu
{
public:
	NPCQuestMenu();
	NPCQuestMenu( std::string Title );
	~NPCQuestMenu();

	void AddCurrentQuest( Quest *pQuest, uint8 icon );
	void AddAvailableQuest( Quest *pQuest, uint8 icon );

	void AddCurrentQuest( uint32 qid, uint8 icon );
	void AddAvailableQuest( uint32 qid, uint8 icon );

	bool QuestIsInList( Quest *pQuest );
	void Clear();

	GossipQuest m_Items[MAX_GOSSIP_ENTRIES];

	std::string m_MenuTitle;
	uint16 m_QuestsNr;
};

class QuestPacketHandler : public Singleton< QuestPacketHandler >
{
public:
	void SendNPCQuestStatus( WorldSession *Wrld, int questStatus, uint64 creatureGUID );
	void SendRewardToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID );
	void SendRequestItemsToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID, bool Completable );

	void SendShortQuestDetailsToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID );
	void SendFullQuestDetailsToPlayer ( WorldSession *Wrld, Quest *pQuest );

	void SendQuestCompleteToPlayer( WorldSession *Wrld, Quest *pQuest );
	void SendQuestFailedToPlayer( WorldSession *Wrld, uint32 iReason );

	void SendCloseGossipToPlayer( WorldSession *Wrld );

	void SendQuestLogFullMessage( WorldSession *Wrld );

	void SendQuestConfirmAccept( WorldSession *Wrld, Quest *pQuest ) {}; // Dummy ...

    void SendQuestUpdateSetTimer( WorldSession *Wrld, Quest *pQuest, uint32 TimerValue);
	void SendQuestUpdateAddItem( WorldSession *Wrld, Quest *pQuest, uint32 iLogItem, uint32 iLogNr);
	void SendQuestUpdateAddKill( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID, uint32 iNrMob, uint32 iLogMob );
	void SendQuestUpdateComplete( WorldSession *Wrld, Quest *pQuest );
	void SendQuestUpdateFailed( WorldSession *Wrld, Quest *pQuest );
	void SendQuestUpdateFailedTimer( WorldSession *Wrld, Quest *pQuest );
	void SendQuestCompleteToLog( WorldSession *Wrld, Quest *pQuest );
	void SendQuestIncompleteToLog( WorldSession *Wrld, Quest *pQuest );
	void SendPointOfInterest( WorldSession *Wrld, float X, float Y, uint32 Icon, uint32 Flags, uint32 Data, const std::string locName );

	void SendQuestInvalid( WorldSession *Wrld, uint32 iReason );

	void SendGossipMenu( WorldSession *Wrld, NPCGossipMenu *gMenu, NPCQuestMenu *qMenu, uint32 TitleTextId, uint64 creatureGUID );
	void SendQuestMenu( WorldSession *Wrld, NPCQuestMenu *qMenu, QEmote eEmote, uint64 creatureGUID );

	void SendVendorList( WorldSession *Wrld, uint64 creatureGUID);
	void SendTrainerList( WorldSession *Wrld, uint64 creatureGUID, std::string trtext);
	void SendTaxiList( WorldSession *Wrld, uint64 creatureGUID);
	void SendPetitionList( WorldSession *Wrld, uint64 creatureGUID);
	void SendBattleList( WorldSession *Wrld, uint64 creatureGUID) {}; // Dummy
	void SendBankerList( WorldSession *Wrld, uint64 creatureGUID);
	void SendInnkeeperList( WorldSession *Wrld, uint64 creatureGUID);
	void SendSpiritHealerList( WorldSession *Wrld, uint64 creatureGUID);
	void SendTabardList( WorldSession *Wrld, uint64 creatureGUID);
	void SendAuctionerList( WorldSession *Wrld, uint64 creatureGUID);

};


#endif
