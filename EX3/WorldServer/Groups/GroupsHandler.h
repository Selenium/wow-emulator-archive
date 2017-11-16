// (c) AbyssX Group
#if !defined(GROUPSHANDLER_H)
#define GROUPSHANDLER_H

#ifdef GROUPS

class GroupsHandler : public Singleton<GroupsHandler>
{
	public:
		GroupsHandler();
		~GroupsHandler();

		//Functions
		DoubleWord HandlePackets(Client *, Packet *);
		void AddPlayer(Player *, Player *, Packet *);
		void GetPartyList(Player *ply);
		void HandlerMSG_LOOT_METHOD(Client *, Packet *);
		void HandlerMSG_GROUP_SET_LEADER(Client *, Packet *);
		void HandlerMSG_GROUP_INVITE(Client *, Packet *);
		void HandlerMSG_GROUP_ACCEPT(Client *, Packet *);
		void HandlerMSG_GROUP_DECLINE(Client *, Packet *);
		void HandlerMSG_GROUP_DISBAND(Client *, Packet *);
		void HandlerMSG_GROUP_UNINVITE(Client *, Packet *);
		void HandlerMSG_GROUP_UNINVITE_GUID(Client *, Packet *);
		void RemoveFromGroup(Player *);
		void SendToGroup(Packet *, Player *, int);
		void ShareXP(Player *ply, DoubleWord XP);
		void ShareMONEY(Player *ply, DoubleWord MONEY);
		bool CompareRanges(Player *ply);
		list<GroupsData *> mGroups;
};

#endif

#endif
