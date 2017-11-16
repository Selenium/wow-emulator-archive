#if !defined(NPCS_H)
#define NPCS_H

#ifdef NPCS

class NPC
{
	public:
		NPC();
		~NPC();

		void QueryVendorItems(Mob *, Client *);

		//Functions
		DoubleWord HandlePackets(Client *, Packet *);
		void HandleMSG_LIST_INVENTORY(Client *, Packet *);
		void HandleMSG_BUY_ITEM(Client *, Packet *);
		void HandleMSG_BUY_ITEM_IN_SLOT(Client *, Packet *);
		void HandleMSG_SELL_ITEM(Client *, Packet *);
};

#endif

#endif