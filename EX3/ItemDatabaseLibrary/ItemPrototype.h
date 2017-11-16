// (c) AbyssX Group
#if !defined(ITEMPROTOTYPE_H)
#define ITEMPROTOTYPE_H


class ItemPrototype
{
private:
	ItemPrototypeData data;
	char* outputBuffer;
	short buffersize;
	bool infoSet;
	bool built;
	void Build();
public:
	ItemPrototype();
	ItemPrototype(const ItemPrototypeData *data);
	void SetPrototypeData(const ItemPrototypeData *data);
	ItemPrototypeData *GetModifiablePrototypeData();
	const ItemPrototypeData *GetPrototypeData();
	const char *GetPrototypePacket();
	const short GetPacketSize();
	const bool IsInfoSet();
	const bool IsBuilt();
	~ItemPrototype();
};

#endif