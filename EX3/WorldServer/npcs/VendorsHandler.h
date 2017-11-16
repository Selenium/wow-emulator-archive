#if !defined(VENDORSHANDLER_H)
#define VENDORSHANDLER_H

#ifdef NPCS

class VendorsHandler : public Singleton<VendorsHandler>
{
	public:
		VendorsHandler();
		~VendorsHandler();
		void LoadVendorItems();
		bool DelVendorItems(DoubleWord, DoubleWord);
		bool AddVendorItems(string,DoubleWord);
		void ParseChat(Player *,char *,Client *);
		DoubleWord CountItems(Mob *);
		void BuildData(Packet *, Mob *);

		list<VENDOR_DB *> mVendorItems;
};

#endif

#endif