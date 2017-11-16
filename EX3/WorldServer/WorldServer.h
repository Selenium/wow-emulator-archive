// (c) AbyssX Group
#if !defined(WORLDSERVER_H)
#define WORLDSERVER_H

struct UPTIME
{
	time_t TimeStamp;
};

class WorldServer : public Server, public Singleton<WorldServer>
{
	public:
		WorldServer();
		~WorldServer();

		void Run(void);

		WorldPort WP;

#ifdef CHANNELS
		ChannelHandler CHandler;
#endif

#ifdef MOBS
		MobDB Mob_DB;
		Population POP;
#endif

#ifdef NPCS
		NPC NPCs;
#endif
		char LIP[64];
		DoubleWord LPort;
		
		void HandlerMSG_AUTH_SESSION(Client *, Packet *);
		void HandlerMSG_PING(Client *, Packet *);
		void HandlerMSG_TEXT_EMOTE(Client *, Packet *);
		void HandlerMSG_MOVE_ASSORTED(Client *, Packet *);
		void HandlerMSG_QUERY_TIME(Client *, Packet *);
		void HandlerMSG_MESSAGECHAT(Client *, Packet *);
		void HandlerMSG_SET_SELECTION(Client *, Packet *);

		//! Gets the Current Time of Server and Sends it to The Client...
		DoubleWord GetGameTime(void);

		//! Gets a new system (ITEM GUID)
		QuadWord GetNewItemGUID();

		void SendToPlayer(Packet *pack, Player *player);
		void SendToAllPlayers(Packet *pack);
		void SendToPlayersInRange(Packet *pack, Player *player);
		void SendToPlayersInRange(Packet *pack, Mob *mob);
		void SendToPlayersInRangeMinusSelf(Packet *pack, Player *player);
		void SendToPlayersInRegion(Packet *pack, Region *region);
		void SendToPlayersInRegionMinusSelf(Packet *pack, Region *region, Player *ply);

		void AnnounceToAll(char *fmt, ...);
		void IRCTOWOW(char *fmt, ...);
		void AnnounceTo(Client *cli, char *fmt, ...);

		void TeleportAllToBattleZone();
		void TeleportAllPlayersToHome();

		void LoadDatabases();
		void GetVariables();
		void SaveVariables();
		void UpdatePlayers(bool);

		//! Shutdowns the server Itself...
		void Shutdown();

		//! WorldServer Lists...
		map<Client *, string> mUserID;
		map<Byte, RegionManager *> mRegionManagers;

		DoubleWord Quantity;
		DoubleWord MAX_PLAYERS;
		DoubleWord mNextMOBEntry;
		DoubleWord mNextITEMEntry;
		QuadWord mNextGUID;
		QuadWord mNextMOBGUID;
		QuadWord mNextITEMGUID;
		bool mDebug;
		int mPort;

		Client *LoginClient;
		UPTIME uptime;
		string GMPASSWORD;

		void CloseConnection(Client *cli);

#ifdef IRCBOT
		int mIRCPort;
		string mIRCHost;
		Client *mIRCClient;
		IRCBot mIRCBot;
#endif

	protected:
		virtual void ClientConnected(Client *);
		virtual void ClientDisconnected(Client *);
		virtual void ClientDataRecvd(Client *);
};

#endif
