// (c) AbyssX Group
#if !defined(PLAYER_H)
#define PLAYER_H

//! Represents a logged in player in the game.
/*! Players are fetched from the database at initialization and then stored in memory during the player
session. Every now and then, the player is saved back to the database. */

struct Resistances
{
	int BPhysical;
	int BHoly;
	int BFire;
	int BNature;
	int BFrost;
	int BShadow;

	int PPhysical;
	int PHoly;
	int PFire;
	int PNature;
	int PFrost;
	int PShadow;

	int NPhysical;
	int NHoly;
	int NFire;
	int NNature;
	int NFrost;
	int NShadow;
};

struct Stats
{
	int BStrenght;
	int BAgility;
	int BIntellect;
	int BSpirit;
	int BStamina;

	int PStrenght;
	int PAgility;
	int PIntellect;
	int PSpirit;
	int PStamina;

	int NStrenght;
	int NAgility;
	int NIntellect;
	int NSpirit;
	int NStamina;
};

class Player : public Unit
{
	public:
		//! Used to wrap the created player map iterator into our own type.
		typedef map<QuadWord, Player *>::iterator PlayersCreatedIterator;

		//! Used to wrap the created mob map iterator into our own type.
		typedef map<QuadWord, Mob *>::iterator MobsCreatedIterator;

#ifdef CHANNELS
		//!Used to wrap the channels list interator to our own type.
		typedef list<Channel *>::iterator ChannelsIterator;
#endif

		//! Returns the beginning iterator of created-players.
		/*! @return begin() of mPlayersCreated. */
		PlayersCreatedIterator PlayersCreatedBegin(void) { return mPlayersCreated.begin(); };

		//! Returns the ending iterator of created players.
		/*! @return end() of mPlayersCreated. */
		PlayersCreatedIterator PlayersCreatedEnd(void) { return mPlayersCreated.end(); };

		//! Returns the beginning iterator of created mobs.
		/*! @return begin() of mMobsCreated. */
		MobsCreatedIterator MobsCreatedBegin(void) { return mMobsCreated.begin(); };

		//! Returns the ending iterator of created mobs.
		/*! @return end() of mMobsCreated. */
		MobsCreatedIterator MobsCreatedEnd(void) { return mMobsCreated.end(); };



#ifdef CHANNELS
		//! Returns the beginning iterator of created-players.
		/*! @return begin() of mChannels. */
		ChannelsIterator ChannelsBegin(void) { return mChannels.begin(); };

		//! Returns the ending iterator of created players.
		/*! @return end() of mChannels. */
		ChannelsIterator ChannelsEnd(void) { return mChannels.end(); };

		void AddChannel(Channel *chan) { mChannels.push_back(chan); };

		void RemoveChannel(Channel *chan)
		{
			if(mChannels.empty())
				return;
			bool rem = false;
			ChannelsIterator i;
			for(i = mChannels.begin(); i!= mChannels.end(); i++)
			{
				if(chan == (*i))
				{
					rem = true;
					break;
				}
			}
			if(rem) mChannels.remove(chan);
		}

		void ClearChannels();

#endif
		//! Temporary, since we do not have account/accountid mapping and stuff yet,
		//! just trying to get Character replaced without too much work being done
		//! all at once
		string mAccount;

		//! Temporary, since all characters are stored, clients are set NULL or not
		//! if the player is logged in or not
		void SetClient(Client *cli) { mClient = cli; };

		// Constructor: Player.
		/*! Creates a new player session from the sent parameters and loads its settings from the database. */
		Player(QuadWord objectGuid, const char *name, DoubleWord accountId, Client *client);

		// Destructor: ~Player.
		/*! Destroys a player object and releases all used resources. */
		~Player();

		//! Sets the Mount flag on or off
		/*! @param isMounted true for Player, false to disable */
		void SetMount(bool isMounted) { mMount = isMounted; };

		//! Returns GM status
		/*! @return boolean indicating GM or not */
		bool IsMounted(void) { return mMount; };

		//! Sets the GM flag on or off
		/*! @param isGM true for GM, false to disable */
		void SetGM(bool isGM) { mGM = isGM; };

		//! Returns GM status
		/*! @return boolean indicating GM or not */
		bool IsGM(void) { return mGM; };

		//! Gets the client that logged in with this player.
		/*! @return A pointer to the client that logged in with this player. */
		Client *GetClient(void) { return mClient; };

		//! Gets the accountId that this player was logged in using.
		/*! @return Account id that the player was logged in with. */
		DoubleWord GetAccountId(void) { return mAccountId; };

		//! Gets the player's skin type.
		/*! @return The player's type of skin. */
		Byte GetSkinType(void) { return mSkin; };

		//! Sets the player's skin type.
		/*! @param skinType The player's new type of skin. */
		void SetSkinType(Byte skinType) { mSkin = skinType; };

		//! Gets the player's face type.
		/*! @return The player's type of face. */
		Byte GetFaceType(void) { return mFace; };

		//! Sets the player's face type.
		/*! @param faceType The player's new type of face. */
		void SetFaceType(Byte faceType) { mFace = faceType; };

		//! Gets the player's hair style.
		/*! @return The player's hair style. */
		Byte GetHairStyle(void) { return mHairStyle; };

		//! Sets the player's hair style.
		/*! @param hairStyle The player's new hair style. */
		void SetHairStyle(Byte hairStyle) { mHairStyle = hairStyle; };

		//! Gets the player's hair color.
		/*! @return The player's hair color. */
		Byte GetHairColor(void) { return mHairColor; };

		//! Sets the player's hair color.
		/*! @param hairColor The player's new hair color. */
		void SetHairColor(Byte hairColor) { mHairColor = hairColor; };

		//! Gets the player's facial hair type.
		/*! @return The player's type of facial hair. */
		Byte GetFacialHairType(void) { return mFacialHair; };

		//! Sets the player's facial hair type.
		/*! @param facialHairType The player's new type of facial hair. */
		void SetFacialHairType(Byte facialHairType) { mFacialHair = facialHairType; };

		//! Gets the zone that the player is currently in.
		/*! @return An id number representing the zone that the player is in. */
		DoubleWord GetCurrentZone(void) { return mZoneId; };

		//! Sets the zone that the player is currently in.
		/*! @param zoneId An id number representing the zone that the player is in. */
		void SetCurrentZone(DoubleWord zoneId) { mZoneId = zoneId; };

		//! Gets the map that the player is currently in.
		/*! @return An id number representing the map that the player is in. */
		DoubleWord GetCurrentMap(void) { return mMapId; };

		//! Sets the map that the player is currently in.
		/*! @param mapId An id number representing the map that the player is in. */
		void SetCurrentMap(DoubleWord mapId) { mMapId = mapId; };

		//! Gets the player's current amount of experience points.
		/*! @return The amount of experience points this player has. */
		DoubleWord GetExperiencePoints(void) { return mExperiencePoints; };

		//! Sets the player's current amount of experience points.
		/*! @param experiencePoints The new number of experience points this player should have. */
		void SetExperiencePoints(DoubleWord experiencePoints) { mExperiencePoints = experiencePoints; };
		
		//! Gets the amount of experience points required to reach next level.
		/*! @return The amount of experience points required to reach next level. */
		DoubleWord GetExperienceNextLevel(void) { return mExperienceNextLevel; };

		Word Getspellcount(void) {return spellcount; };

		void Setspellcount(Word count) {spellcount = count; };
		//! Sets the amount of experience points required to reach next level.
		/*! @param expNextLevel The new number of experience points required to reach next level. */
		void SetExperienceNextLevel(DoubleWord expNextLevel) { mExperienceNextLevel = expNextLevel; };

		//! Gets the rest state for this player.
		/*! @return The rest state. */
		Byte GetRestState(void) { return mRestState; };

		//! Sets the rest state for this player.
		/*! @param restStat The new rest state. */
		void SetRestState(Byte restState) { mRestState = restState; };

		bool GetPvPState(void) { return mPvP; };
		void SetPvPState(bool pvpstate) { mPvP = pvpstate; };

		string GetPvPVictim(void) { return mVictim; };
		void SetPvPVictim(string Vict) { mVictim = Vict; };

		//! Gets the Party for This Player.
		/*! @return The party ID. */
		GroupsData *GetParty(void) { return mParty; };

		//! Sets the Party for this player.
		/*! @param partyId The new party ID. */
		void SetParty(GroupsData *party) { mParty = party; };

		QuadWord GetHostTrack(void) { return mHostTrack; };

		void SetHostTrack(QuadWord HostTrack) { mHostTrack = HostTrack; };

		QuadWord GetTarget(void) { return mTarget; };

		void SetTarget(QuadWord TARGET) { mTarget = TARGET; };

		void SetCommunication(bool status) { mCommunication = status; };

		bool GetCommunication(void) { return mCommunication; };

		bool GetRegenerationStatus(void) { return mRegenerating; };

		void SetRegenerationStatus(bool r) { mRegenerating = r; };

		bool GetResSickness(void) { return mResSickness; };

		void SetResSickness(bool r) { mResSickness = r; };

		QuadWord GetInventory(Word);

		void SetInventory(Word, QuadWord);

		QuadWord GetBackPack(Word);

		void SetBackPack(Word, QuadWord);

		//! Overrides the method from the Object class.
		/*! @return The player-specific model. */
		Word GetObjectModel();

		/*! @return The player-specific mount-model. */
		DoubleWord GetMountModelID(bool flying);

		//! Gets the last move packet
		/*! @return Packet pointer */
		Packet *GetLastMovePacket(void) { return mLastMovePacket; };

		//! Gets the last strafe packet
		/*! @return Packet pointer */
		Packet *GetLastStrafePacket(void) { return mLastStrafePacket; };

		//! Gets the last swim packet
		/*! @return Packet pointer */
		Packet *GetLastSwimPacket(void) { return mLastSwimPacket; };

		//! Gets the last turn packet
		/*! @return Packet pointer */
		Packet *GetLastTurnPacket(void) { return mLastTurnPacket; };

		//! Gets the last walk packet
		/*! @return Packet pointer */
		Packet *GetLastWalkPacket(void) { return mLastWalkPacket; };

		//! Sets the last move packet
		/*! @param pack Packet to set from */
		void SetLastMovePacket(Packet *pack);

		//! Sets the last strafe packet
		/*! @param pack Packet to set from */
		void SetLastStrafePacket(Packet *pack);

		//! Gets the last swim packet
		/*! @param pack Packet to set from */
		void SetLastSwimPacket(Packet *pack);

		//! Sets the last turn packet
		/*! @param pack Packet to set from */
		void SetLastTurnPacket(Packet *pack);

		//! Sets the last walk packet
		/*! @param pack Packet to set from */
		void SetLastWalkPacket(Packet *pack);

		//! Checks if a player has received our creation
		/*! @param guid guid of the player to check */
		bool HasReceivedCreate(QuadWord guid) { return (mPlayersCreated.find(guid) != mPlayersCreated.end()); };

		//! Adds a player to this player's "players-created" list.
		/*! @param guid Player to add to the list. */
		void AddCreatedPlayer(Player *player);

		//! Removes a player from this player's "players-createdr" list.
		/*! @param guid Player to remove from the list. */
		void RemoveCreatedPlayer(Player *player);

		//! Clears the list of created-for players.
		void ClearCreatedPlayers() { mPlayersCreated.clear(); };
	
		//! Checks if a mob has received our creation
		/*! @param guid guid of the player to check */
		bool HasReceivedMobCreate(QuadWord guid) { return (mMobsCreated.find(guid) != mMobsCreated.end()); };

		//! Adds a player to this player's "mobs created" list.
		/*! @param guid mob to add to the list. */
		void AddCreatedMob(Mob *mob);

		//! Removes a mob from this player's "mob created" list.
		/*! @param guid Mob to remove from the list. */
		void RemoveCreatedMob(Mob *mob);

		//! Clears the list of created-for mobs.
		void ClearCreatedMobs() { mMobsCreated.clear(); };


		//! Saves the character to the database.
		int Save(void);
		
		//! Loads the character from the database.
		int Load(QuadWord guid);

		//! Get The New start Zone for a new Char Made.
		DoubleWord GetStartZone();

		//! Get The New Start Continent for a new Char Made.
		DoubleWord GetStartMap();

		//! Set The New Start X, Y and Z Coordinates as well, when a new char is made.
		void SetStartCoordinates();

		Float *GetStartCoordinates();

		// Following not using

		//! Gets the player's status.
		/*! @return The player's status. */
		Byte GetStatus(void) { return mStatus; };

		//! Sets the player's status.
		/*! @param status The player's new status. */
		void SetStatus(Byte status) { mStatus = status; };

		//! Gets the player's "See Movie Bool".
		bool GetMovie(void) { return mMovie; };

		//! Sets the player's "See Movie Bool".
		void SetMovie(bool m) { mMovie = m; };

		void SetLootTarget(QuadWord t) { mLootTarget = t; };
		QuadWord GetLootTarget(void) { return mLootTarget; };

		void SetArmed(bool t) { mArmed = t; };
		bool GetArmed(void) { return mArmed; };

		void SetGhost(bool t) { mGhost = t; };
		bool GetGhost(void) { return mGhost; };

		void SetFlying(bool t) { mFlying = t; };
		bool GetFlying(void) { return mFlying; };

		//! Sets the Player Faction.
		/*! @param The Player Race Faction. */
		void SetRaceFaction();

		//! Gets the Intro Movie for the char when its Created!
		void GetPlayerMovie();

		//! Sets the Object Emote in A9 for the player
		void SetPlayerEmote(DoubleWord);
		DoubleWord GetPlayerEmote(void) { return mPlayerEmote; };

		//! Gets the Attack Speed in MS for the Player!
		DoubleWord GetAttackSpeed();

		//! Updates Player Status With The Wanted Item Status!!!!!!!
		void Equip(Item *item);
		void UnEquip(Item *item);

		//! Add Status / Resistances Into A9 Packet...
		void AddStats(ObjectUpdate *objupd);

#ifdef ITEMS
		//! Find Player Items Over the List
		Player_Item* FindPlayerItem(QuadWord);
		void DeletePlayerItem(QuadWord);
		void NewPlayerItem(Player_Item *pitem);
		void CreateItems(Player *ply2, Word);
		DoubleWord GetSlot();
		void GetStartingItems();
		void CreateItem(DoubleWord ENTRY);
#endif

		//! Mount/UnMount
		void Mount();

		void Replenish();
		void Recover();
		void RessurectionSickness();
		void Sheathe();
		void GmPowers();

		//! Gets the talent points of this player.
		/*! @return The total talent points. */
		//DoubleWord GetTalentPoints(void) { return mTalentPoints; };

		//! Sets the talent points of this player.
		/*! @param talentPoints The new amount of talent points. */
		//void SetTalentPoints(DoubleWord talentPoints) { mTalentPoints = talentPoints; };

		//! Gets the skill points of this player.
		/*! @return The total skill points. */
		//DoubleWord GetSkillPoints(void) { return mSkillPoints; };

		//! Sets the skill points of this player.
		/*! @param skillPoints The new amount of skill points. */
		//void SetSkillPoints(DoubleWord skillPoints) { mSkillPoints = skillPoints; };

		//! Gets the chat filters active for this player.
		/*! @return The active chat filters for this player. */
		//DoubleWord GetChatFilters(void) { return mChatFilters; };

		//! Sets the chat filters active for this player.
		/*! @param chatFilters The new chat filters to use for this player. */
		//void SetChatFilters(DoubleWord chatFilters) { mChatFilters = chatFilters; };

		//! Gets the value of an explored zone for this player.
		/*! @param index Index into the array of 32 explored zones.
			@return The explored zone variable specified by [index]. */
		//DoubleWord GetExploredZone(DoubleWord index) { return mExploredZones[index]; };

		//! Sets the value of an explored zone for this player.
		/*! @param index Index into the array of 32 explored zones.
			@param exploredZone The new explored zone value to set for the specified [index]. */
		//void SetExploredZone(DoubleWord index, DoubleWord exploredZone) { mExploredZones[index] = exploredZone; };

		void LevelUP();

		//! Player Stats
		Stats mStats;

		//! Player Resistances
		Resistances mResistances;

		//! Player ROOT/UNROOT (Walk or NOT)
		void ROOT();
		void UnROOT();

		//! Players is moving or not
		void SetMoved(bool moved) { mMoved = moved; };
		bool HasMoved(void) { return mMoved; };

	private:
		//! Account id that this player belongs to.
		DoubleWord mAccountId;

		//! The players type of skin.
		Byte mSkin;

		//! The player's type of face.
		Byte mFace;

		//! The player's type of hair style.
		Byte mHairStyle;
		
		//! The player's hair color.
		Byte mHairColor;

		//! The player's type of facial hair.
		Byte mFacialHair;

		//! The client that has logged in with this player.
		Client *mClient;

		//! The zone that this player is in.1
		/*! @todo Which field in the A9 takes care of current player zone? */
		DoubleWord mZoneId;

		//! The map that this player is in.
		/*! @todo Which field in the A9 takes care of current player map? */
		DoubleWord mMapId;

		//! Amount of experience points that this player has.
		DoubleWord mExperiencePoints;

		//! Amount of experience points required for next level up.
		DoubleWord mExperienceNextLevel;

		//! Rest state. 1-5, 1 being well rested.
		Byte mRestState;

		//! Party
		GroupsData *mParty;

		QuadWord mHostTrack;

		QuadWord mTarget;

		//! Number of spell the player has learned, used for determining the proper slot for spells
		DoubleWord spellcount;

		Float mCoords[2];

		bool mCommunication;

		//! Player GM flag
		bool mGM;

		//! Player Mount flag
		bool mMount;

		//! Player PvP State
		bool mPvP;

		//! Setting Life Regen State
		bool mRegenerating;

		//! Setting Ressurection Sickness;
		bool mResSickness;

		//! Inventory Array
		QuadWord mInventory[20];

		//! BackPack Array.
		QuadWord mBackPack[17];

		//! PvP Victim;
		string mVictim;

		//! Last move packet
		Packet *mLastMovePacket;

		//! Last strafe packet
		Packet *mLastStrafePacket;

		//! Last swim packet
		Packet *mLastSwimPacket;

		//! Last turn packet
		Packet *mLastTurnPacket;

		//! Last walk packet
		Packet *mLastWalkPacket;

		//! List of players that have been created according to us
		map<QuadWord, Player *> mPlayersCreated;

		//! List of mobs that have been created according to us
		map<QuadWord, Mob *> mMobsCreated;

#ifdef CHANNELS
		//! List of channels joined
		list<Channel *> mChannels;
#endif

#ifdef ITEMS
		//! Contains the Player Items in it...
		list<Player_Item *> mPItem;
#endif

		// Following not using

		//! Player status, such as GM, DND, AFK.
		/*! @todo Find out what each status bit is and make an enum for this. */
		Byte mStatus;

		//! Intro Enabling Var...
		bool mMovie;

		//! Loot Target
		QuadWord mLootTarget;

		//! Using Weapons or Not
		bool mArmed;

		//! Ghost or Not
		bool mGhost;

		//! Flying or not
		bool mFlying;

		//! Moving or Not
		bool mMoved;

		//! Player Emote
		DoubleWord mPlayerEmote;

		//! Amount of talent points.
		/*! @todo Is the talent points dword separated into different bytes? */
		//DoubleWord mTalentPoints;

		//! Amount of skill points.
		/*! @todo Is the skill points dword separated into different bytes? */
		//DoubleWord mSkillPoints;

		//! Chat filters, don't know what they do yet.
		/*! @todo Find out what chat filters do. */
		//DoubleWord mChatFilters;

		//! Explored zones.
		/*! @todo Find out how explored zones are used. */
		//DoubleWord mExploredZones[32];
};

#endif
