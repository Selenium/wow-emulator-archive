#ifndef WOWPYTHONSERVER_DATABASEINTERFACE_H
#define WOWPYTHONSERVER_DATABASEINTERFACE_H

#include "Common.h"
#include "../game/Spell.h"
#include "../game/AreaTrigger.h"
#include "../game/MiscHandler.h"

class Unit;
class Character;
class Path;
class ChatCommand;
struct NetworkPacket;

class DatabaseInterface
{
	friend class Database;
public:
	int doQuery (const char * query);
	uint64 doQueryId (const char * query);
	int IsNameTaken(char * charname);
	int GetNameGUID(char * charname);
	bool GetPlayerNameFromGUID(uint32 guid, uint8 *name);
	void addCharacter (Character * newChar);
	std::set< Character * > enumCharacters (int account_id);
	void removeCharacter (Character * newChar);
	void setCharacter (Character * diffChar);
	void setHighestGuids();

	uint32 getGlobalTaxiNodeMask (uint32 curloc);

	uint32 getPath (uint32 source, uint32 destination);
	void getPathNodes (uint32 path, Path *pathnodes);
	uint32 getNearestTaxiNode (float x, float y, float z, uint16 continent);

	AreaTrigger *getAreaTriggerInformation(uint32 AreaTriggerID); //Area Trigger stuff


	void getTrainerSpells (Character * pChar, guid trainer, NetworkPacket & data); //load spells for this Trainer
	//int getTrainerSpellsCount (guid Trainer); //count how many spells a given trainer has
	int getTrainerSpellsPrice (guid Spell, guid trainer); //get the price for a specific spell
	int addTrainerSpell (guid Trainer, guid Spell, uint32 SpellPrice); //add spells to trainer

	void updateCreature(Unit *pUnit);
	void saveCreature(Unit *pUnit);
	std::set< Unit * > loadCreatures();
	void loadCreatureNames(std::map< uint32, uint8*> & p_names);
	void saveCreatureNames(std::map< uint32, uint8*> p_names);
	void spawnSpiritHealers ();
	bool isSpiritHealer(uint32 guid);
	void getClosestSpiritHealer(float &x, float &y, float &z, uint16 &mapID);

	void loadItems();

	void loadQuests();  // load the quests into QuestHandler
	void loadQuestStatus(Character *pChar);   // load quest progress for this character
	void saveQuestStatus(Character *pChar);   // save quest progress for this character

	//gossip stuff//////
	void loadTextRelation();
	void loadNPCText();
	void loadTextOptions();
	////////////////////

	int Login(char* username, char* ip);
	int getAccountLvl(int account_id);
	char * getAccountPass(int account_id);

	int IsCharMoveExist(uint32 guid);
	/*
	 ///////////////////////////// NIMROD //////////////////////////////////////
	 int addUserGuild(char *member, char *leader); // adds a user to a clan -- agrega a un wn al clan
	 int addNewGuild(char *lider, char *nombre, char *motd); // agrega un clan // adds a guild
	 char* getGuildMotd(char* usuario); //get motd -- saca el mensaje del dia
	 int setGuildMotd(char *lider, char *mensaje); // set new guild motd -- pone nuevo motd
	 int removeUserGuild(char *member, char *leader); // remove an user from the guild -- saca a 1 user del clan
	 int disbandGuild(char *leader); // disband the guild -- desarma el clan
	 int setGuildRank(char *leader, char *member, int rank); // gives a rank to a user -- da ranking a un wn
	 /////////////////////////////// END NIMROD /////////////////////////////////////////
	 */

	void Get_Spell_Information (uint32 spellid, SpellInformation &SpellInfo);
	SpellInformation GetSpellInformation (uint32 spellid);
	void OutputLog (char *fCaller, char *fInformation);
	uint32 NULLToNumeric (const char *input);

	SocialData* getFriendList(uint32 guid);
	void AddFriend(uint32 guid, uint32 friendid, char *charname);
	void RemoveFriend(uint32 guid, uint32 friendid);

	void loadTalents();

	void loadChatCommand(const char *name, ChatCommand * cmd);

	void AllowIP(char* ip);
	void BanIP(char* ip);
	void RemoveIP(char* ip);
	int Firewall(char* ip);


protected:

	DatabaseInterface (void * handle);
	~DatabaseInterface ();

	/// Handle to the database connection represented by this object
	void * mDatabaseConnection;
};

#endif
