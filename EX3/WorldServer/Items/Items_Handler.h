#if !defined(ITEMS_HANDLER_H)
#define ITEMS_HANDLER_H

#ifdef ITEMS

class Items_Handler : public Singleton<Items_Handler>
{
	public:
		Items_Handler();
		~Items_Handler();
		DoubleWord HandlePackets(Client *, Packet *);
		void MSG_ITEM_QUERY_SINGLE(Client *, Packet *);
		void MSG_SWAP_INV_ITEM(Client *, Packet *);
		void MSG_AUTOEQUIP_ITEM(Client *, Packet *);
		void MSG_DESTROYITEM(Client *, Packet *);
		void MSG_LOOT(Client *, Packet *);
		void MSG_AUTOSTORE_LOOT_ITEM(Client *, Packet *);
		void MSG_LOOT_RELEASE(Client *, Packet *);
		void MSG_LOOT_MONEY(Client *, Packet *);
		bool QuerySingleItem(DoubleWord,Packet *);
		bool LoadDB_Items();
		bool LoadStarting_Items();
		Word ItemUpdate(DoubleWord, QuadWord GUID, Player *, Client *);
		void ParseChat(QuadWord GUID, Client *, Player *, char *);
		void SendInventory(Client *, Word, Word, Word, bool, bool, Word, Word, Player *);
		void MoveToSlot(Player *, Word, Word);
		Item *FindItem(DoubleWord);
		void DestroyItemByGUID(Player *, QuadWord);
		void DestroyItem(Player *, Word);
		DoubleWord GetStartingSlotByType(DoubleWord TYPE);
		
		list<Item *> mItem;

		bool mDebug;
};

#endif
#endif