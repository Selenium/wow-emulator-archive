/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#ifndef WOWSERVER_QUEST_H
#define WOWSERVER_QUEST_H
 

enum QuestClass
{
	QUEST_CLASS_NONE            = 0,
	QUEST_CLASS_WARRIOR         = 1,
	QUEST_CLASS_PALADIN         = 2,
	QUEST_CLASS_HUNTER          = 3,
	QUEST_CLASS_ROGUE           = 4,
	QUEST_CLASS_PRIEST          = 5,
	QUEST_CLASS_UNK0            = 6,
	QUEST_CLASS_SHAMAN          = 7,
	QUEST_CLASS_MAGE            = 8,
	QUEST_CLASS_WARLOCK         = 9,
	QUEST_CLASS_UNK1            = 10,
	QUEST_CLASS_DRUID           = 11,
};

enum QuestRase
{
	QUEST_RACE_NONE            = 0,
	QUEST_RACE_HUMAN           = 1,
	QUEST_RACE_ORC             = 2,
	QUEST_RACE_DWARF           = 3,
	QUEST_RACE_NIGHTELF        = 4,
	QUEST_RACE_UNDEAD          = 5,
	QUEST_RACE_TAUREN          = 6,
	QUEST_RACE_GNOME           = 7,
	QUEST_RACE_TROLL           = 8,
};

enum QuestTradeSkill
{
	QUEST_TRSKILL_NONE           = 0,
	QUEST_TRSKILL_ALCHEMY        = 1,
	QUEST_TRSKILL_BLACKSMITHING  = 2,
	QUEST_TRSKILL_COOKING        = 3,
	QUEST_TRSKILL_ENCHANTING     = 4,
	QUEST_TRSKILL_ENGINEERING    = 5,
	QUEST_TRSKILL_FIRSTAID       = 6,
	QUEST_TRSKILL_HERBALISM      = 7,
	QUEST_TRSKILL_LEATHERWORKING = 8,
	QUEST_TRSKILL_POISONS        = 9,
	QUEST_TRSKILL_TAILORING      = 10,
	QUEST_TRSKILL_MINING         = 11,
	QUEST_TRSKILL_FISHING        = 12,
	QUEST_TRSKILL_SKINNING       = 13,
	QUEST_TRSKILL_JEWELCRAFTING  = 14,
};

enum QuestStatus
{
    QUEST_STATUS_NONE           = 0, 
    QUEST_STATUS_COMPLETE       = 1,
    QUEST_STATUS_UNAVAILABLE    = 2,    // need to be higher level
    QUEST_STATUS_INCOMPLETE     = 3,
    QUEST_STATUS_AVAILABLE      = 4,
};

enum DialogStatus
{
    DIALOG_STATUS_NONE           = 0, 
    DIALOG_STATUS_UNAVAILABLE    = 1,
    DIALOG_STATUS_CHAT           = 2,
    DIALOG_STATUS_INCOMPLETE     = 3,
    DIALOG_STATUS_REWARD_REP     = 4,
    DIALOG_STATUS_AVAILABLE      = 5,
    DIALOG_STATUS_REWARD         = 6, 
};

enum QuestBehavior
{
    QUEST_BEHAVIOR_UNDEFINED          = 0, 
    QUEST_BEHAVIOR_DELIVER            = 1, 
    QUEST_BEHAVIOR_KILL               = 2, 

    QUEST_BEHAVIOR_SPEAKTO            = 4, 
	QUEST_BEHAVIOR_REPEATABLE         = 8,
	QUEST_BEHAVIOR_EXPLORE            = 16,
	QUEST_BEHAVIOR_TIMED              = 32,
	QUEST_BEHAVIOR_REPUTATION         = 128,
};


class Quest
{
public:
    Quest()
    {
        m_zone = 0;
        memset(m_questItemId, 0, 16);
        memset(m_questItemCount, 0, 16);
        memset(m_questMobId, 0, 16);
        memset(m_questMobCount, 0, 16);

        memset(m_choiceItemId, 0, 24);
        memset(m_choiceItemCount, 0, 24);

        memset(m_rewardItemId, 0, 16);
        memset(m_rewardItemCount, 0, 16);

        m_choiceRewards = 0;
        m_itemRewards = 0;
        m_rewardGold = 0;

        m_requiredLevel = 0;
        m_questLevel    = 0;

        m_previousQuests = 0;
		m_previousQuests_Lock = 0;
        m_lockQuests     = 0; // <PavkaM>

		m_srcItem        = 0;
		m_nextQuest      = 0;
		m_learnSpell     = 0;
		m_timeMinutes    = 0;
		m_questType 	 = 0;

	    m_questRaces     = QUEST_RACE_NONE;
	    m_questClass     = QUEST_CLASS_NONE;
	    m_questTrSkill 	 = QUEST_TRSKILL_NONE;

		m_questBehavior = QUEST_BEHAVIOR_UNDEFINED;

		m_repFaction[0] = 0;
		m_repFaction[1] = 0;

		m_repValue[0] = 0;
		m_repValue[1] = 0;

		m_LocMap   = 0;
		m_LocX     = 0;
		m_LocY	   = 0;	
		m_LocOpt   = 0;
    }

    uint32 m_questId;
    uint32 m_zone;
	uint32 m_questFlags;

    // String descriptions sent to Client
    std::string m_title;
    std::string m_details;
    std::string m_objectives;
    std::string m_completedText;
    std::string m_incompleteText;

    std::string m_secondText;   // ...
    std::string m_partText[4];  // ...

    // Quest pre-requisites
    uint32 m_requiredLevel;     // level you are required to be to do this quest
	uint32 m_questLevel;        // <PavkaM> the quest level itself.

    uint32 m_previousQuests;     // <PavkaM> Number of pre-reqs
    uint32 m_previousQuest[10];  // <PavkaM> id of a previous quest that much be completed first

    uint32 m_previousQuests_Lock;     // <PavkaM> Number of pre-reqs
    uint32 m_previousQuest_Lock[10];  // <PavkaM> id of a previous quest that much be completed first

    uint32 m_lockQuests;         // <PavkaM> Number of locks
    uint32 m_lockQuest[10];      // <PavkaM> id of a quest that needs to be locked once this one is completed

    uint32 m_questItemId[4];    // entry ID of the item type to find
    uint32 m_questItemCount[4]; // number of items to find

    uint32 m_questMobId[4];     // entry ID of the mob to be slain for this quest
    uint32 m_questMobCount[4];  // number of mobs to slay

    // Rewards
    uint16 m_choiceRewards;   // number of items to choose from, max 5?
    uint32 m_choiceItemId[6];    // entry ID of the items to choose for a reward
    uint32 m_choiceItemCount[6]; // number of each item to be awarded

    uint16 m_itemRewards;       // number of items always rewarded
    uint32 m_rewardItemId[4];   // entry ID of the items to be awarded
    uint32 m_rewardItemCount[4];// count of each item to be awarded

    uint32 m_rewardGold;        // gold reward
	uint32 m_repFaction[2];
	uint32 m_repValue[2];

    uint32 m_srcItem;           // ...

    uint32 m_nextQuest;         // ...
	uint32 m_learnSpell;        // ...
	uint32 m_timeMinutes;       // ...
	uint32 m_questType;			// ...

	uint32  m_questRaces;
	uint32  m_questClass;
	uint32  m_questTrSkill;

	uint32  m_questBehavior;

	int m_LocMap;
	float m_LocX, m_LocY, m_LocOpt;

/*
   Helper functions !
*/
	uint32 GenerateQuestXP( Player *pPlayer );
	bool QuestIsTakable( Player *pPlayer );
	bool QuestIsCompatible( Player *pPlayer );
	bool QuestReputationSatisfied( Player *pPlayer );
	bool QuestTradeSkillSatisfied( Player *pPlayer );
	bool QuestRaceSatisfied( Player *pPlayer );
	bool QuestClassSatisfied( Player *pPlayer );
	bool QuestLevelSatisfied( Player *pPlayer );
	bool QuestCanShowAvailable( Player *pPlayer );
	bool QuestCanShowUnsatified( Player *pPlayer );
	bool QuestPreReqSatisfied( Player *pPlayer );
	bool QuestRewardIsTaken( Player *pPlayer );
	bool HasBehavior( uint32 bhflag );

};


#endif
