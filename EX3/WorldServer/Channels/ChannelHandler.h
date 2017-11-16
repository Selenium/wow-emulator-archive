#if !defined(CHANNELHANDLER_H)
#define CHANNELHANDLER_H

#ifdef CHANNELS

class ChannelHandler
{
	public:
		ChannelHandler();
		~ChannelHandler();
		DoubleWord HandlePackets(Client *, Packet *);
		void HandlerMSG_CHANNEL_LIST(Client *,Packet *);
		void HandlerMSG_JOIN_CHANNEL(Client *,Packet *);
		void HandlerMSG_LEAVE_CHANNEL(Client *,Packet *);
		void HandlerMSG_CHANNEL_PASSWORD(Client *,Packet *);
		void HandlerMSG_CHANNEL_SET_OWNER(Client *,Packet *);
		void HandlerMSG_CHANNEL_OWNER(Client *,Packet *);
		void HandlerMSG_CHANNEL_MODERATOR(Client *,Packet *);
		void HandlerMSG_CHANNEL_UMODERATOR(Client *,Packet *);
		void HandlerMSG_CHANNEL_MUTE(Client *,Packet *);
		void HandlerMSG_CHANNEL_UNMUTE(Client *,Packet *);
		void HandlerMSG_CHANNEL_INVITE(Client *,Packet *); // Unsupported
		void HandlerMSG_CHANNEL_KICK(Client *,Packet *);
		void HandlerMSG_CHANNEL_BAN(Client *,Packet *);
		void HandlerMSG_CHANNEL_UNBAN(Client *,Packet *);
		void HandlerMSG_CHANNEL_ANNOUNCEMENTS(Client *,Packet *);
		void HandlerMSG_CHANNEL_MODERATE(Client *,Packet *);
		ChannelManager *mChannelManager;
};

#endif

#endif