#if !defined(PLAYERSHANDLER_H)
#define PLAYERSHANDLER_H

class PlayersHandler : public Singleton<PlayersHandler>
{
	public:
		PlayersHandler();
		~PlayersHandler();

		//! This is the function that update all the Regions in the Server...
		//void CheckRegion(Player *ply, Byte oldmap, bool part2 = false);

		void MoveTroughRegion(Player *ply);
		void MapChange(Player *ply, Byte oldmap, bool PlayerChangingMap);

		//! Teleports a Player from a Place to Another and Update Regions...
		bool TeleportPlayer(Player *ply, Byte map, Float x, Float y, Float z);

		//! Calculates the Distance Between a Player and Another...
		Float DistBetween(Player *, Player *);

		//! Sends the Update Packet to a Player when it gets in Range...
		void PlayerInRange(Client *cli, Player *ply);

		//! Sends the Update Packet to a Player when it gets out of Range...
		void PlayerOutOfRange(Client *cli, Player *ply);

		//! That Function Is Responsable for the Player Joining the World!
		void PlayerJoinedWorld(Player *ply);

		//! That Function Is Responsable for the Player Lefting the World!
		void PlayerLeftWorld(Player *ply);

		Player *FindPlayer(Client *cli);
		Player *FindPlayer(QuadWord guid);
		Player *FindPlayer(const char *name);

		ObjectManager<Player *> mPlayers;

		//! Counts Number of Things in the Server...
		int NumberPlayers(void);
		int NumberGMs(void);

		//Packets
		DoubleWord HandlePackets(Client *cli, Packet *pack);

		void HandlerMSG_CHAR_ENUM(Client *, Packet *);
		void HandlerMSG_CHAR_CREATE(Client *, Packet *);
		void HandlerMSG_CHAR_DELETE(Client *, Packet *);
		void HandlerMSG_PLAYER_LOGIN(Client *, Packet *);
		void HandlerMSG_LOGOUT_REQUEST(Client *, Packet *);
		void HandlerMSG_SETSHEATHED(Client *cli, Packet *pack);
		void HandlerMSG_REPOP_REQUEST(Client *, Packet *);
		void HandlerMSG_ZONEUPDATE(Client *, Packet *);
		void HandlerMSG_MOVE_WORLDPORT_ACK(Client *, Packet *);
		void HandlerMSG_NAME_QUERY(Client *, Packet *);
		void HandlerMSG_WHO(Client *, Packet *);

};

#endif