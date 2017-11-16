#ifndef UPDATEOBJECT_H
#define UPDATEOBJECT_H

class CUpdateObject
{
	map<unsigned long, unsigned long> UpdateFields;
	unsigned long maxField;
	char numBlocks;
	long maskSize;
	unsigned long MakeUpdateBlock(char *buffer, bool reset);

	void SendCompressedUpdate(guid_t guid, unsigned long len);
	void SendCompressedUpdateOnlyPlayer(CPlayer *pPlayer, guid_t guid, unsigned long len);
	void SendCompressedUpdateNotMe(guid_t guid, unsigned long len);
public:
	CUpdateObject(unsigned long maxBits)
	{
		maxField = maxBits;
		numBlocks = (char)((maxField>>5) + ((maxField & 31) ? 1 : 0));
		maskSize = (numBlocks << 2);
	};

	inline bool UpdateDirty() {return UpdateFields.size() > 0;};

	void UpdateObject(guid_t guid, unsigned long guidHigh, bool reset);
	void UpdateItem(guid_t guid, CPlayer *owner, bool reset = true);
	void UpdateObjectOnlyPlayer(CPlayer *pPlayer, guid_t guid, unsigned long guidHigh, bool reset);
	void UpdateObjectNotMe(guid_t guid, unsigned long guidHigh, bool reset);
	void UpdateObjectOnlyMe(guid_t guid, unsigned long guidHigh, bool reset);

	inline virtual void UpdateObject(bool reset = true) {throw "CUpdateObject::UpdateObject() - not overriden";};
	inline virtual void UpdateObjectNotMe(bool reset = true) {throw "CUpdateObject::UpdateNotMe() - not override";};
	inline virtual void UpdateObjectOnlyMe(bool reset = true) {throw "CUpdateObject::UpdateObjectOnlyMe() - not overriden";};
#define FADD32(type) \
	inline void AddUpdateVal(unsigned long field, type val) \
	{\
	UpdateFields[field] = *(unsigned long*)&val;\
	};
	FADD32(int)
	FADD32(unsigned int)
	FADD32(float)
	FADD32(unsigned long)
	FADD32(long)
#undef FADD32
	inline void AddUpdateVal(unsigned long field, unsigned long valLow, unsigned long valHigh)
	{
		UpdateFields[field] = valLow;
		UpdateFields[field+1] = valHigh;
	};
};

#endif // UPDATEOBJECT_H
