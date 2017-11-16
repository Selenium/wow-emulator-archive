#ifndef WOWPYTHONSERVER_DATABASEINTERFACE_H
#define WOWPYTHONSERVER_DATABASEINTERFACE_H

#include "Common.h"
#include "../game/Spell.h"
#include "../game/MiscHandler.h"
extern int playerlimit;

class Unit;
class Character;
class Path;
class ChatCommand;
struct wowWData;

class DatabaseInterface {
  friend class Database;
public:
  uint32 getNPC_TEXT_TYPE( uint32 textID );
  uint32 getNextTextID( uint32 tType , uint32 guid );
  int doQuery( const char * query );
  uint64 doQueryId( const char * query );
  int IsNameTaken(char * charname);
  int GetNameGUID(char * charname);
  bool GetPlayerNameFromGUID(uint32 guid, uint8 *name);
  void addCharacter( Character * newChar );
  std::set< Character * > enumCharacters( int account_id );
  void removeCharacter( Character * newChar );
  void setCharacter( Character * diffChar );
  void setHighestGuids();

  uint32 getGlobalTaxiNodeMask( uint32 curloc );

  uint32 getPath( uint32 source, uint32 destination );
  uint32 getTaxiPrice( uint32 source, uint32 destination );
  void getTaxiDest( uint32 node, float &x, float &y, float &z );
  void getPathNodes( uint32 path, Path *pathnodes );
  uint32 getNearestTaxiNode( float x, float y, float z, uint16 continent );

  void getTrainerSpells( Character * pChar, const uint32 *trainer, wowWData & data ); //load spells for this char
  int getTrainerSpellsCount( const uint32 *trainer ); //count how many spells a given trainer has
  int getTrainerSpellsPrice( uint32 spellGuid, uint32 trainerGuid ); //get the price for a specific spell
  int addTrainerSpell ( const uint32 *trainer, uint32 iSpellGuid, uint32 iSpellPrice ); //add spells to trainer

  void updateCreature(Unit *pUnit);
  void saveCreature(Unit *pUnit);
  std::set< Unit * > loadCreatures();
  void loadCreatureNames(std::map< uint32, uint8*> & p_names);
  void saveCreatureNames(std::map< uint32, uint8*> p_names);
  void spawnSpiritHealers( );
  bool isSpiritHealer(uint32 guid);
  void getClosestSpiritHealer(float &x, float &y, float &z, uint16 &mapID);

  void loadItems();

  void loadQuests();  // load the quests into QuestHandler
  void loadQuestStatus(Character *pChar);   // load quest progress for this character
  void saveQuestStatus(Character *pChar);   // save quest progress for this character

  int Login(char* username, char* password, char* ip);
  int getAccountLvl(int account_id);
  char * getAccountPass(int account_id);

  // <WoW Chile Dev Team> Start Change
  int IsCharMoveExist(uint32 guid);
  // <WoW Chile Dev Team> Stop Change
  // <WoW Chile Dev Team> Start Change
  /*
  ///////////////////////////// NIMROD //////////////////////////////////////
  int DatabaseInterface::addUserGuild(char *member, char *leader); // adds a user to a clan -- agrega a un wn al clan
  int addNewGuild(char *lider, char *nombre, char *motd); // agrega un clan // adds a guild
  char* DatabaseInterface::getGuildMotd(char* usuario); //get motd -- saca el mensaje del dia
  int DatabaseInterface::setGuildMotd(char *lider, char *mensaje); // set new guild motd -- pone nuevo motd
  int DatabaseInterface::removeUserGuild(char *member, char *leader); // remove an user from the guild -- saca a 1 user del clan
  int DatabaseInterface::disbandGuild(char *leader); // disband the guild -- desarma el clan
  int DatabaseInterface::setGuildRank(char *leader, char *member, int rank); // gives a rank to a user -- da ranking a un wn
  /////////////////////////////// END NIMROD /////////////////////////////////////////
  */
  // <WoW Chile Dev Team> Stop Change

  /////////////////////////////////////////////////////////////////////////////////////////
  void DatabaseInterface::Get_Spell_Information( uint32 spellid, SpellInformation &SpellInfo); //angelic|999
  SpellInformation DatabaseInterface::GetSpellInformation( uint32 spellid ); //angelic|999
  void DatabaseInterface::OutputLog ( char *fCaller, char *fInformation ); //angelic|999
  uint32 DatabaseInterface::NULLToNumeric ( const char *input ); //angelic|999
  /////////////////////////////////////////////////////////////////////////////////////////

  SocialData* getFriendList(uint32 guid);
  void AddFriend(uint32 guid, uint32 friendid, char *charname);
  void RemoveFriend(uint32 guid, uint32 friendid);

  void DatabaseInterface::loadTalents();

  void loadChatCommand(const char *name, ChatCommand * cmd);

  void AllowIP(char* ip);
  void BanIP(char* ip);
  void RemoveIP(char* ip);
  int Firewall(char* ip);

protected:

  DatabaseInterface( void * handle );
  ~DatabaseInterface( );

  /// Handle to the database connection represented by this object
  void * mDatabaseConnection;
};

#endif
